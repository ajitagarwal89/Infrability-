using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_Settings_AuditHistoryList : System.Web.UI.Page
{
    #region Data Members
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    AuditHistoryListBAL auditHistoryListBAL = new AuditHistoryListBAL();
    AuditHistoryListUI auditHistoryListUI = new AuditHistoryListUI();
    string gblRecordId = string.Empty;
    protected int widestData;

    #endregion Data Members
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AuditHistoryListUI auditHistoryListUI = new AuditHistoryListUI();

            if (Request.QueryString["recordId"] != null)
            {

                auditHistoryListUI.RecordId = Request.QueryString["recordId"];
                gblRecordId = Request.QueryString["recordId"];
                BindList(auditHistoryListUI);
            }
        }

    }

    //protected void gvData_OnRowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        Label lblNewValue = (Label)e.Row.FindControl("lblNewValue");
    //        lblNewValue.Text = lblNewValue.Text.Replace(",", "<br />");
    //    }
    //}
    private void BindList(AuditHistoryListUI auditHistoryListUI)
    {
        try
        {
            auditHistoryListUI.RecordId = gblRecordId;

            DataTable dtb = auditHistoryListBAL.GetAudit_IUD_SelectByRecordId(auditHistoryListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvData.DataSource = dtb;
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    dtb.Rows[i]["OldValue"] = Regex.Replace(Convert.ToString(dtb.Rows[i]["OldValue"]), @",", "<br/>");
                    dtb.Rows[i]["NewValue"] = Regex.Replace(Convert.ToString(dtb.Rows[i]["NewValue"]), @",", "<br/>");
                }
                gvData.DataSource = dtb;
                gvData.DataBind();
                gvData.Visible = false;
                gvData.Visible = true;
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvData.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "System_Settings_AuditHistoryList.CS";
            logExcpUIobj.RecordId = "Audit History";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[System_Settings_AuditHistoryList : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {

    }

    protected void lnkBack_Click(object sender, EventArgs e)
    {
        AuditHistoryListUI auditHistoryListUI = new AuditHistoryListUI();
        Response.Redirect(auditHistoryListUI.FormName = Request.QueryString["Form"] + "?recordId=" + Request.QueryString["recordId"] + "");
    }

}


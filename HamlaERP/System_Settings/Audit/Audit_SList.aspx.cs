using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class System_Settings_Audit_SList : System.Web.UI.Page
{
    #region Data Members
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    Audit_SListBAL audit_SListBAL = new Audit_SListBAL();
    Audit_SListUI audit_SListUI = new Audit_SListUI();
    #endregion Data Members

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            BindList();
        }

    }


    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    DataTable dtb = new DataTable();
        //    dtb = audit_IUDListBAL.GetAudit_IUDListForExportToExcel();

        //    string exportedFileName = "Audit IUD" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
        //    Response.Clear();
        //    Response.Charset = "";
        //    Response.ContentType = "application/ms-excel";
        //    Response.Buffer = true;
        //    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", exportedFileName));
        //    System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        //    System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
        //    System.Web.UI.WebControls.DataGrid dg = new System.Web.UI.WebControls.DataGrid();

        //    dg.AllowPaging = false;
        //    dg.HeaderStyle.BackColor = System.Drawing.Color.RoyalBlue;
        //    dg.HeaderStyle.ForeColor = System.Drawing.Color.White;

        //    dg.DataSource = dtb;
        //    dg.DataBind();
        //    dg.RenderControl(htmlWrite);
        //    Response.Write(stringWrite.ToString());
        //    Response.End();

        //}
        //catch (Exception exp)
        //{
        //    logExcpUIobj.MethodName = "lnkExportToExcel_Click()";
        //    logExcpUIobj.ResourceName = "System_Settings_Audit_IUDList.CS";
        //    logExcpUIobj.RecordId = "Export To excel";
        //    logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
        //    logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

        //    log.Error("[System_Settings_Audit_IUDList : lnkExportToExcel_Click] An error occured in the processing of Records. Details : [" + exp.ToString() + "]");
        //}
    }

    #region Main Search
    protected void btnMainSearch_Click(object sender, EventArgs e)
    {
    //    btnHtmlSearch.Visible = false;
    //    btnHtmlClose.Visible = true;
    //    audit_IUDListUI.Search = txtSearch.Text;
    //    BindCardListBySearchParameters(audit_IUDListUI);
    }

    private void BindCardListBySearchParameters(Audit_IUDListUI audit_IUDListUI)
    {
    //    try
    //    {
    //        DataTable dtb = audit_IUDListBAL.GetAssetAudit_UIDListSearchParameters(audit_IUDListUI);

    //        if (dtb.Rows.Count > 0 && dtb != null)
    //        {
    //            gvData.DataSource = dtb;
    //            gvData.DataBind();
    //            divError.Visible = false;
    //        }
    //        else
    //        {
    //            divError.Visible = true;
    //            lblError.Text = Resources.GlobalResource.msgNoRecordFound;
    //            gvData.Visible = false;
    //        }
    //    }
    //    catch (Exception exp)
    //    {
    //        logExcpUIobj.MethodName = "BindCardListBySearchParameters()";
    //        logExcpUIobj.ResourceName = "System_Settings_Audit_IUDList.CS";
    //        logExcpUIobj.RecordId = "All";
    //        logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
    //        logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

    //        log.Error("[System_Settings_Audit_IUDList : BindCardListBySearchParameters] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
    //    }
    }

    protected void btnClearMainSearch_Click(object sender, EventArgs e)
    {
        BindList();
        gvData.Visible = true;
        btnHtmlSearch.Visible = true;
        btnHtmlClose.Visible = false;
        txtSearch.Text = "";
        txtSearch.Focus();
    }
    #endregion Main Search

     
    #region Methods

    private void BindList()
    {
        try
        {
            DataTable dtb = audit_SListBAL.GetAudit_SList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvData.DataSource = dtb;
                gvData.DataBind();
                divError.Visible = false;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvData.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "System_Settings_CardList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_Audit_SList : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods
}
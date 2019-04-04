using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using log4net;
using Finware;


public partial class System_Settings_OrganizationList : PageBase
{
    #region Data Members
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    OrganizationListBAL organizationListBAL = new OrganizationListBAL();
    OrganizationListUI organizationListUI = new OrganizationListUI();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        //base.Page_Load(sender, e);
        if (!this.IsPostBack)
        {
            BindOrganizationList();
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrganizationForm.aspx");
    }

    protected void gvColLnkBtn_Click(object sender, EventArgs e)
    {
        string organizationId = (sender as LinkButton).CommandArgument;
        Response.Redirect("OrganizationForm.aspx?OrganizationId=" + organizationId);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        CheckBox ch;
        for (int i = 0; i < gvData.Items.Count; i++)
        {
            ch = (CheckBox)gvData.Items[i].Cells[0].FindControl("chkrow");
            if (ch.Checked == true)
            {
                try
                {
                    organizationListUI.Tbl_OrganizationId = gvData.Items[i].Cells[1].Text;

                    if (organizationListBAL.DeleteOrganization(organizationListUI) == 1)
                    {
                        BindOrganizationList();
                        divSuccess.Visible = true;
                        lblSuccess.Text = Resources.GlobalResource.msgRecordDeleteSuccessfully;
                    }
                    else
                    {
                        divError.Visible = true;
                        lblError.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;
                    }
                }
                catch (Exception exp)
                {
                    logExcpUIobj.MethodName = "btnDelete_Click()";
                    logExcpUIobj.ResourceName = "System_Settings_OrganizationList.CS";
                    logExcpUIobj.RecordId = organizationListUI.Tbl_OrganizationId;
                    logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                    logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                    log.Error("[System_Settings_OrganizationList : btnDelete_Click] An error occured in the processing of Record Id : " + organizationListUI.Tbl_OrganizationId + ". Details : [" + exp.ToString() + "]");
                }
            }
        }

    }

    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtb = new DataTable();
            dtb = organizationListBAL.GetOrganizationList();

            string exportedFileName = "Organization_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            Response.Clear();
            Response.Charset = "";
            Response.ContentType = "application/ms-excel";
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", exportedFileName));
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
            System.Web.UI.WebControls.DataGrid dg = new System.Web.UI.WebControls.DataGrid();

            dg.AllowPaging = false;
            dg.HeaderStyle.BackColor = System.Drawing.Color.RoyalBlue;
            dg.HeaderStyle.ForeColor = System.Drawing.Color.White;

            dg.DataSource = dtb;
            dg.DataBind();
            dg.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "lnkExportToExcel_Click()";
            logExcpUIobj.ResourceName = "System_Settings_OrganizationList.CS";
            logExcpUIobj.RecordId = "Export To excel";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OrganizationList : lnkExportToExcel_Click] An error occured in the processing of Records. Details : [" + exp.ToString() + "]");
        }
    }

    #region Main Search

    protected void btnMainSearch_Click(object sender, EventArgs e)
    {
        btnHtmlSearch.Visible = false;
        btnHtmlClose.Visible = true;
        organizationListUI.Search = txtSearch.Text;
        BindOrganizationListBySearchParameters(organizationListUI);
    }

    protected void btnClearMainSearch_Click(object sender, EventArgs e)
    {
        BindOrganizationList();
        gvData.Visible = true;
        btnHtmlSearch.Visible = true;
        btnHtmlClose.Visible = false;
        txtSearch.Text = "";
        txtSearch.Focus();
    }

    #endregion Main Search
    #endregion Events

    #region Methods

    private void BindOrganizationList()
    {
        try
        {
            DataTable dtb = organizationListBAL.GetOrganizationList();

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
            logExcpUIobj.MethodName = "BindOrganizationList()";
            logExcpUIobj.ResourceName = "System_Settings_OrganizationList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OrganizationList : BindOrganizationList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    private void BindOrganizationListBySearchParameters(OrganizationListUI organizationListUI)
    {
        try
        {
            DataTable dtb = organizationListBAL.GetOrganizationListBySearchParameters(organizationListUI);

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
            logExcpUIobj.MethodName = "BindOrganizationListBySearchParameters()";
            logExcpUIobj.ResourceName = "System_Settings_OrganizationList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OrganizationList : BindOrganizationListBySearchParameters] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods
}
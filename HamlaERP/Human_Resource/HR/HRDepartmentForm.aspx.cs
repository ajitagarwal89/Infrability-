using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Finware;
using log4net;
using System.Data;


public partial class Human_Resource_Organization_Structure_Manage_Position_HRDepartmentForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    HRDepartmentFormBAL hRDepartmentFormBAL = new HRDepartmentFormBAL();
    HRDepartmentFormUI hRDepartmentFormUI = new HRDepartmentFormUI();
    HRDivisionListUI hRDivisionListUI = new HRDivisionListUI();
    HRDivisionListBAL hRDivisionListBAL = new HRDivisionListBAL();

    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        HRDepartmentFormUI hRDepartmentFormUI = new HRDepartmentFormUI();


        if (!Page.IsPostBack)
        {
            if (Request.QueryString["HR_DepartmentId"] != null || Request.QueryString["recordId"] != null)
            {
                hRDepartmentFormUI.Tbl_HR_DepartmentId = (Request.QueryString["HR_DepartmentId"] != null ? Request.QueryString["HR_DepartmentId"] : Request.QueryString["recordId"]);


                FillForm(hRDepartmentFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnAuditHistory.Visible = true;
                lblHeading.Text = "Update HR Department";

            }
            else
            {
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New HR Department";
            }
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            hRDepartmentFormUI.CreatedBy = SessionContext.UserGuid;
            hRDepartmentFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            hRDepartmentFormUI.Tbl_HRDivisionId = txtHRDivisionGuid.Text;
            hRDepartmentFormUI.DepartmentCode = txtDepartmentCode.Text;
            hRDepartmentFormUI.Description = txtDescription.Text;
          
            if (hRDepartmentFormBAL.AddHRDepartment(hRDepartmentFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                divError.Visible = true;
                divSuccess.Visible = false;
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "Human_Resource_Organization_Structure_Manage_Position_HRDepartment.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_Organization_Structure_Manage_Position_HRDepartment : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            hRDepartmentFormUI.Tbl_HR_DepartmentId = Request.QueryString["HR_DepartmentId"];
            hRDepartmentFormUI.ModifiedBy = SessionContext.UserGuid;
            hRDepartmentFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            hRDepartmentFormUI.Tbl_HRDivisionId = txtHRDivisionGuid.Text;
            hRDepartmentFormUI.DepartmentCode = txtDepartmentCode.Text;
            hRDepartmentFormUI.Description = txtDescription.Text;


            if (hRDepartmentFormBAL.UpdateHRDepartment(hRDepartmentFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
                hRDepartmentFormUI.Tbl_HR_DepartmentId = Request.QueryString["HR_DepartmentId"];
                FillForm(hRDepartmentFormUI);
            }
            else
            {
                divError.Visible = true;
                divSuccess.Visible = false;
                lblError.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "Human_Resource_Organization_Structure_Manage_Position_HRDepartment.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_Organization_Structure_Manage_Position_HRDepartment : btnUpdate_Click] An error occured in the processing of Record Id : " + hRDepartmentFormUI.Tbl_HR_DepartmentId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        HRDepartmentFormUI hRDepartmentFormUI = new HRDepartmentFormUI();
        try
        {
            hRDepartmentFormUI.Tbl_HR_DepartmentId = Request.QueryString["HR_DepartmentId"];

            if (hRDepartmentFormBAL.DeleteHRDepartment(hRDepartmentFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordDeleteSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                divError.Visible = true;
                divSuccess.Visible = false;
                lblError.Text = Resources.GlobalResource.msgCouldNotDeleteRecord;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnDelete_Click()";
            logExcpUIobj.ResourceName = "Human_Resource_Organization_Structure_Manage_Position_HRDepartment.CS";
            logExcpUIobj.RecordId = hRDepartmentFormUI.Tbl_HR_DepartmentId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_Organization_Structure_Manage_Position_HRDepartment : btnDelete_Click] An error occured in the processing of Record Id : " + hRDepartmentFormUI.Tbl_HR_DepartmentId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Human_Resource/HR/HRDepartmentList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Human_Resource/HR/HRDepartmentForm.aspx";
        string recordId = Request.QueryString["HR_DepartmentId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    #region HRDivision Search
    protected void btnHRDivisionSearch_Click(object sender, EventArgs e)
    {
        btnHtmlHRDivisionSearch.Visible = false;
        btnHtmlHRDivisionClose.Visible = true;
        SearchHRDivisionList();
    }
    protected void btnClearHRDivisionSearch_Click(object sender, EventArgs e)
    {
        BindHRDivisionList();
        gvHRDivisionSearch.Visible = true;
        btnHtmlHRDivisionSearch.Visible = true;
        btnHtmlHRDivisionClose.Visible = false;
        txtHRDivisionSearch.Text = "";
        txtHRDivisionSearch.Focus();
    }
    protected void btnHRDivisionRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindHRDivisionList();
    }
    #endregion HRDivision Search

    #endregion Events

    #region Methods
    private void FillForm(HRDepartmentFormUI hRDepartmentFormUI)
    {
        try
        {
            DataTable dtb = hRDepartmentFormBAL.GetHRDepartmentListById(hRDepartmentFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtDepartmentCode.Text = dtb.Rows[0]["DepartmentCode"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                txtHRDivision.Text= dtb.Rows[0]["tbl_HR_Division"].ToString();
                txtHRDivisionGuid.Text= dtb.Rows[0]["tbl_HR_DivisionId"].ToString();
            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotLoadData;
                divError.Visible = true;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "FillForm()";
            logExcpUIobj.ResourceName = "Human_Resource_Organization_Structure_Manage_Position_HRDepartment.CS";
            logExcpUIobj.RecordId = hRDepartmentFormUI.Tbl_HR_DepartmentId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_Organization_Structure_Manage_Position_HRDepartment : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region HRDivision Search
    private void SearchHRDivisionList()
    {
        try
        {
            HRDivisionListUI hRDivisionListUI = new HRDivisionListUI();
            hRDivisionListUI.Search = txtHRDivisionSearch.Text;
            DataTable dtb = hRDivisionListBAL.GetHRDivisionListBySearchParameters(hRDivisionListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvHRDivisionSearch.DataSource = dtb;
                gvHRDivisionSearch.DataBind();
                divHRDivisionSearchError.Visible = false;
            }
            else
            {
                divHRDivisionSearchError.Visible = true;
                lblHRDivisionSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvHRDivisionSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchHRDivisionList()";
            logExcpUIobj.ResourceName = "Human_Resource_Organization_Structure_Manage_Position_HRDepartmentForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_Organization_Structure_Manage_Position_HRDepartmentForm : SearchHRDivisionList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindHRDivisionList()
    {
        try
        {
            DataTable dtb = hRDivisionListBAL.GetHRDivisionList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvHRDivisionSearch.DataSource = dtb;
                gvHRDivisionSearch.DataBind();
                divHRDivisionSearchError.Visible = false;

            }
            else
            {
                divHRDivisionSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvHRDivisionSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindHRDivisionList()";
            logExcpUIobj.ResourceName = "Human_Resource_Organization_Structure_Manage_Position_HRDepartmentForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_Organization_Structure_Manage_Position_HRDepartmentForm : BindHRDivisionList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  HRDivision Serach

    #endregion Methods
}
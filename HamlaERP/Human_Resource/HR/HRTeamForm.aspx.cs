using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Finware;
using log4net;
using System.Data;


public partial class Human_Resource_HRTeamForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    HRTeamFormBAL hRTeamFormBAL = new HRTeamFormBAL();
    HRTeamFormUI hRTeamFormUI = new HRTeamFormUI();

    BatchListBAL batchListBAL = new BatchListBAL();
    BatchListUI batchListUI = new BatchListUI();
    HRDepartmentListBAL hRDepartmentListBAL = new HRDepartmentListBAL();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        HRTeamFormUI hRTeamFormUI = new HRTeamFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["HRTeamId"] != null || Request.QueryString["recordId"] != null)
            {
                hRTeamFormUI.Tbl_HR_TeamId = (Request.QueryString["HRTeamId"] != null ? Request.QueryString["HRTeamId"] : Request.QueryString["recordId"]) ;



                FillForm(hRTeamFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update HR Team";
            }
            else
            {            
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New HR Team";
              
            }
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            hRTeamFormUI.CreatedBy = SessionContext.UserGuid;
            hRTeamFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            hRTeamFormUI.Tbl_HR_DepartmentId = txtHRDepartmentGuid.Text;
            hRTeamFormUI.TeamCode = txtTeamCode.Text;
            hRTeamFormUI.Description = txtDescription.Text;
         
            if (hRTeamFormBAL.AddHRTeam(hRTeamFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Human_Resource_HRTeamForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_HRTeamForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            hRTeamFormUI.Tbl_HR_TeamId = Request.QueryString["HRTeamId"];
            hRTeamFormUI.ModifiedBy = SessionContext.UserGuid;
            hRTeamFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            hRTeamFormUI.Tbl_HR_DepartmentId = txtHRDepartmentGuid.Text;
            hRTeamFormUI.TeamCode = txtTeamCode.Text;
            hRTeamFormUI.Description = txtDescription.Text;
            if (hRTeamFormBAL.UpdateHRTeam(hRTeamFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
                hRTeamFormUI.Tbl_HR_TeamId = Request.QueryString["HRTeamId"];
                FillForm(hRTeamFormUI);
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
            logExcpUIobj.ResourceName = "Human_Resource_HRTeamForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_HRTeamForm : btnUpdate_Click] An error occured in the processing of Record Id : " + hRTeamFormUI.Tbl_HR_TeamId+ ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        HRTeamFormUI hRTeamFormUI = new HRTeamFormUI();
        try
        {
            hRTeamFormUI.Tbl_HR_TeamId = Request.QueryString["HRTeamId"];

            if (hRTeamFormBAL.DeleteHRTeam(hRTeamFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Human_Resource_HRTeamForm.CS";
            logExcpUIobj.RecordId = hRTeamFormUI.Tbl_HR_TeamId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_HRTeamForm : btnDelete_Click] An error occured in the processing of Record Id : " + hRTeamFormUI.Tbl_HR_TeamId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("HRTeamList.aspx");
    }

    #region HRDepartment Search
    protected void btnHRDepartmentSearch_Click(object sender, EventArgs e)
    {
        btnHtmlHRDepartmentSearch.Visible = false;
        btnHtmlHRDepartmentClose.Visible = true;
        SearchHRDepartmentList();
    }
    protected void btnClearHRDepartmentSearch_Click(object sender, EventArgs e)
    {
        BindHRDepartmentList();
        gvHRDepartmentSearch.Visible = true;
        btnHtmlHRDepartmentSearch.Visible = true;
        btnHtmlHRDepartmentClose.Visible = false;
        txtHRDepartmentSearch.Text = "";
        txtHRDepartmentSearch.Focus();
    }
    protected void btnHRDepartmentRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindHRDepartmentList();
    }
    #endregion Batch Search

        protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Human_Resource/HR/HRTeamForm.aspx";
        string recordId = Request.QueryString["HRTeamId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }
    #endregion Events

    #region Methods
    private void FillForm(HRTeamFormUI hRTeamFormUI)
    {
        try
        {
            DataTable dtb = hRTeamFormBAL.GetHRTeamListById(hRTeamFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtHRDepartment.Text = dtb.Rows[0]["tbl_HR_Department"].ToString();
                txtHRDepartmentGuid.Text = dtb.Rows[0]["tbl_HR_DepartmentId"].ToString();
                txtTeamCode.Text = dtb.Rows[0]["TeamCode"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
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
            logExcpUIobj.ResourceName = "Human_Resource_HRTeamForm.CS";
            logExcpUIobj.RecordId = hRTeamFormUI.Tbl_HR_TeamId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_HRTeamForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region Department Search    
    private void SearchHRDepartmentList()
    {
        try
        {
            HRDepartmentListUI hRDepartmentListUI = new HRDepartmentListUI();
            hRDepartmentListUI.Search = txtHRDepartmentSearch.Text;


            DataTable dtb = hRDepartmentListBAL.GetHRDepartmentListBySearchParameters(hRDepartmentListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvHRDepartmentSearch.DataSource = dtb;
                gvHRDepartmentSearch.DataBind();
                divHRDepartmentSearchError.Visible = false;
            }
            else
            {
                divHRDepartmentSearchError.Visible = true;
                lblHRDepartmentSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvHRDepartmentSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchHRDepartmentList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm : SearchHRDepartmentList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindHRDepartmentList()
    {
        try
        {
            DataTable dtb = hRDepartmentListBAL.GetHRDepartmentList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvHRDepartmentSearch.DataSource = dtb;
                gvHRDepartmentSearch.DataBind();
                divHRDepartmentSearchError.Visible = false;

            }
            else
            {
                divHRDepartmentSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvHRDepartmentSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindHRDepartmentList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm : BindHRDepartmentList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Department Search
    #endregion Methods
}
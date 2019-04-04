using Finware;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Human_Resource_HR_EmployeeEducationForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    EmployeeListBAL employeeListBAL = new EmployeeListBAL();
    EmployeeListUI employeeListUI = new EmployeeListUI();

    EmployeeEducationFormBAL employeeEducationFormBAL = new EmployeeEducationFormBAL();
    EmployeeEducationFormUI employeeEducationFormUI = new EmployeeEducationFormUI();

    #endregion Data Members

    #region Events
    protected override  void Page_Load(object sender, EventArgs e)
    {
        EmployeeEducationFormUI employeeEducationFormUI = new EmployeeEducationFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["EmployeeEducationId"] != null || Request.QueryString["recordId"] != null)
            {
                employeeEducationFormUI.Tbl_EmployeeEducationId=(Request.QueryString["EmployeeEducationId"] != null ? Request.QueryString["EmployeeEducationId"] : Request.QueryString["recordId"]) ; 


                FillForm(employeeEducationFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnAuditHistory.Visible = true;
                lblHeading.Text = "Update Employee Education";
            }
            else
            {



                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New Employee Education";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            employeeEducationFormUI.CreatedBy = SessionContext.UserGuid;
            employeeEducationFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            employeeEducationFormUI.Tbl_EmployeeId = txtEmployeeGuid.Text;
            employeeEducationFormUI.School = txtSchool.Text;
            employeeEducationFormUI.Major = txtMajor.Text;
            employeeEducationFormUI.Year = txtYear.Text;
            employeeEducationFormUI.Degree= txtDegree.Text;
            employeeEducationFormUI.GPA =Convert.ToDecimal(txtGPA.Text);
            employeeEducationFormUI.Note = txtNote.Text;

            if (employeeEducationFormBAL.AddEmployeeEducation(employeeEducationFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
                divError.Visible = true;
                divSuccess.Visible = false;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "Human_Resource_HR_EmployeeEducationForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_HR_EmployeeEducationForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            employeeEducationFormUI.ModifiedBy = SessionContext.UserGuid;
            employeeEducationFormUI.Tbl_EmployeeEducationId = Request.QueryString["EmployeeEducationId"];
            employeeEducationFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            employeeEducationFormUI.Tbl_EmployeeId = txtEmployeeGuid.Text;
            employeeEducationFormUI.School = txtSchool.Text;
            employeeEducationFormUI.Major = txtMajor.Text;
            employeeEducationFormUI.Year = txtYear.Text;
            employeeEducationFormUI.Degree = txtDegree.Text;
            employeeEducationFormUI.GPA = Convert.ToDecimal(txtGPA.Text);
            employeeEducationFormUI.Note = txtNote.Text;


            if (employeeEducationFormBAL.UpdateEmployeeEducation(employeeEducationFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                divError.Visible = true;
                divSuccess.Visible = false;
                lblError.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "Human_Resource_HR_EmployeeEducationForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            log.Error("[Human_Resource_HR_EmployeeEducationForm : btnUpdate_Click] An error occured in the processing of Record Id : " + employeeEducationFormUI.Tbl_EmployeeEducationId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            employeeEducationFormUI.Tbl_EmployeeEducationId = Request.QueryString["EmployeeEducationId"];

            if (employeeEducationFormBAL.DeleteEmployeeEducation(employeeEducationFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Human_Resource_HR_EmployeeEducationForm.CS";
            logExcpUIobj.RecordId = employeeEducationFormUI.Tbl_EmployeeEducationId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_HR_EmployeeEducationForm : btnDelete_Click] An error occured in the processing of Record Id : " + employeeEducationFormUI.Tbl_EmployeeEducationId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Human_Resource/HR/EmployeeEducationForm.aspx";
        string recordId = Request.QueryString["EmployeeEducationId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeEducationList.aspx");
    }

    #region Events Employee Search

    protected void btnEmployeeSearch_Click(object sender, EventArgs e)
    {
        btnHtmlEmployeeSearch.Visible = false;
        btnHtmlEmployeeClose.Visible = true;
        SearchEmployeeList();
    }

    protected void btnClearEmployeeSearch_Click(object sender, EventArgs e)
    {
        BindEmployeeList();
        gvEmployeeSearch.Visible = true;
        btnHtmlEmployeeSearch.Visible = true;
        btnHtmlEmployeeClose.Visible = false;
        txtEmployeeSearch.Text = "";
        txtEmployeeSearch.Focus();
    }

    protected void btnEmployeeRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindEmployeeList();
    }
    #endregion Events Employee Search
    #endregion Events

    #region Methods
    private void FillForm(EmployeeEducationFormUI employeeEducationFormUI)
    {
        try
        {
            DataTable dtb = employeeEducationFormBAL.GetEmployeeEducationListById(employeeEducationFormUI);

            if (dtb.Rows.Count > 0)
            {
                
               txtEmployee.Text = dtb.Rows[0]["tbl_Employee"].ToString();
               txtEmployeeGuid.Text = dtb.Rows[0]["tbl_EmployeeId"].ToString();
                txtSchool.Text = dtb.Rows[0]["School"].ToString();
                txtMajor.Text = dtb.Rows[0]["Major"].ToString();
                txtYear.Text = dtb.Rows[0]["Year"].ToString();
                txtDegree.Text = dtb.Rows[0]["Degree"].ToString();
                txtGPA.Text = dtb.Rows[0]["GPA"].ToString();
                txtNote.Text = dtb.Rows[0]["Note"].ToString();
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
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = employeeEducationFormUI.Tbl_EmployeeEducationId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_CurrencyForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region Methods Employee Search
    public void BindEmployeeList()
    {
        try
        {
            DataTable dtb = employeeListBAL.GetEmployeeList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvEmployeeSearch.DataSource = dtb;
                gvEmployeeSearch.DataBind();
                divEmployeeSearchError.Visible = false;
            }
            else
            {
                divEmployeeSearchError.Visible = true;
                lblEmployeeSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvEmployeeSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindEmployeeList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_EmployeeContacts_Supplier_Master_Creation_EmployeeContactsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_EmployeeContacts_Supplier_Master_Creation_EmployeeContactsForm : BindEmployeeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    public void SearchEmployeeList()
    {
        try
        {
            EmployeeListUI employeeListUI = new EmployeeListUI();
            employeeListUI.Search = txtEmployeeSearch.Text;

            DataTable dtb = employeeListBAL.GetEmployeeListBySearchParameters(employeeListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvEmployeeSearch.DataSource = dtb;
                gvEmployeeSearch.DataBind();
                divEmployeeSearchError.Visible = false;
            }
            else
            {
                divEmployeeSearchError.Visible = true;
                lblEmployeeSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvEmployeeSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchEmployeeList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_EmployeeContacts_Supplier_Master_Creation_EmployeeContactsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_EmployeeContacts_Supplier_Master_Creation_EmployeeContactsForm : SearchEmployeeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods Employee Search
    #endregion Methods
}
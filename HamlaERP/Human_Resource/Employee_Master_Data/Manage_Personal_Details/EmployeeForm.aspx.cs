using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    EmployeeFormBAL employeeFormBAL = new EmployeeFormBAL();
    CountryListBAL countryListBAL = new CountryListBAL();
    //EmployeeGroupListBAL employeeGroupListBAL = new EmployeeGroupListBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    HRDivisionListBAL hRDivisionListBAL = new HRDivisionListBAL();
    HRDepartmentListBAL hRDepartmentListBAL = new HRDepartmentListBAL();
    HR_PositionListBAL hR_PositionListBAL = new HR_PositionListBAL();
    HR_BranchListBAL hR_BranchListBAL = new HR_BranchListBAL();
    HR_SupervisorListBAL hR_SupervisorListBAL = new HR_SupervisorListBAL();

    int invoiceTypeInvoice = 1;
    int invoiceTypeReturn = 2;
    int invoiceTypeCreditMemo = 3;
    int invoiceTypePayment = 4;


    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        EmployeeFormUI employeeFormUI = new EmployeeFormUI();

        if (!Page.IsPostBack)
        {
            BindEmployeeNationalTypeDropDown();
            BindEmploymentTypeDropDown();
            if (Request.QueryString["EmployeeId"] != null || Request.QueryString["recordId"] != null)
            {
                employeeFormUI.Tbl_EmployeeId = (Request.QueryString["EmployeeId"] != null ? Request.QueryString["EmployeeId"] : Request.QueryString["recordId"]);

                FillForm(employeeFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnAuditHistory.Visible = true;
                lblHeading.Text = "Update Employee";

            }
            else
            {

                employeeFormUI.InvoiceType = invoiceTypeInvoice;
                GetSerialNumber(employeeFormUI);
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New Employee";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int hRStatus = 0;
        int gender = 0;
        int maritalStatus = 0;
        EmployeeFormUI employeeFormUI = new EmployeeFormUI();
        try
        {

            employeeFormUI.CreatedBy = SessionContext.UserGuid;
            employeeFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            employeeFormUI.EmployeeCode = txtEmployeeCode.Text;
            employeeFormUI.FirstName = txtFirstName.Text;
            employeeFormUI.MiddleName = txtMiddleName.Text;
            employeeFormUI.LastName = txtLastName.Text;
            employeeFormUI.Contact = txtContact.Text;
            employeeFormUI.Opt_EmployeeNationalType = Convert.ToInt32(ddlOpt_EmployeeNationalType.SelectedValue);
            employeeFormUI.IqamaBathaqaNumber = txtIqamaBathaqaNumber.Text;
            employeeFormUI.Address = txtAddress.Text;
            employeeFormUI.City = txtCity.Text;
            employeeFormUI.State = txtState.Text;
            employeeFormUI.ZipCode = txtZipCode.Text;
            employeeFormUI.Tbl_CountryId = txtCountryGuid.Text;
            employeeFormUI.Phone = txtPhone.Text;
            employeeFormUI.Mobile = txtMobile.Text;
            employeeFormUI.FaxNo = txtFaxNo.Text;
            employeeFormUI.Email = txtEmail.Text;
            employeeFormUI.Tbl_HR_DivisionId = txtHR_DivisionGuid.Text;
            employeeFormUI.Tbl_HR_DepartmentId = txtHR_DepartmentGuid.Text;
            employeeFormUI.Tbl_HR_PositionId = txtHR_PositionGuid.Text;
            employeeFormUI.Tbl_HR_BranchId = txtHR_BranchGuid.Text;
            employeeFormUI.Tbl_HR_SupervisorId = txtHR_SupervisorGuid.Text;
            employeeFormUI.SeniorityDate =DateTime.Parse(txtSeniorityDate.Text);
            employeeFormUI.HireDate = DateTime.Parse(txtHireDate.Text);
            employeeFormUI.AdjustedHireDate = DateTime.Parse(txtAdjustedHireDate.Text);
            employeeFormUI.LastWorkingDay = DateTime.Parse(txtLastWorkingDay.Text);
            employeeFormUI.InactivatedDate = DateTime.Parse(txtInactivatedDate.Text);
            employeeFormUI.Reason = txtReason.Text;
            employeeFormUI.Tbl_Country_Nationality = txtCountry_NationalityGuid.Text;
            if (rdbActive.Checked)
            {
                hRStatus = 1;
                employeeFormUI.HRStatus = hRStatus;
            }
            else if (rdbInActive.Checked)
            {
                hRStatus = 2;
                employeeFormUI.HRStatus = hRStatus;
            }
            employeeFormUI.opt_EmploymentType = Convert.ToInt32(ddlopt_EmploymentType.SelectedValue);
            employeeFormUI.DOB =DateTime.Parse(txtDOB.Text);
            if (rdbMale.Checked)
            {
                gender = 1;
                employeeFormUI.Gender = gender;
            }
            else if (rdbFemale.Checked)
            {
                gender = 2;
                employeeFormUI.Gender = gender;
            }

            if (rdbMARRIED.Checked)
            {
                maritalStatus = 1;
                employeeFormUI.MaritalStatus = maritalStatus;
            }
            else if (rdbSINGLE.Checked)
            {
                maritalStatus = 2;
                employeeFormUI.MaritalStatus = maritalStatus;
            }
            employeeFormUI.WorkHoursPerYear = Convert.ToInt32(txtWorkHoursPerYear.Text);
            employeeFormUI.PassportNumber = txtPassportNumber.Text;
            employeeFormUI.PassportExp = DateTime.Parse(txtPassportExp.Text);
            employeeFormUI.IqamaBathaqaExp = DateTime.Parse(txtIqamaBathaqaExp.Text);
            if (employeeFormBAL.AddEmployee(employeeFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                divSuccess.Visible = false;
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        int hRStatus = 0;
        int gender = 0;
        int maritalStatus = 0;
        EmployeeFormUI employeeFormUI = new EmployeeFormUI();
        try
        {
            employeeFormUI.ModifiedBy = SessionContext.UserGuid;
            employeeFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            employeeFormUI.Tbl_EmployeeId = Request.QueryString["EmployeeId"];
            employeeFormUI.EmployeeCode = txtEmployeeCode.Text;
            employeeFormUI.FirstName = txtFirstName.Text;
            employeeFormUI.MiddleName = txtMiddleName.Text;
            employeeFormUI.LastName = txtLastName.Text;
            employeeFormUI.Contact = txtContact.Text;
            employeeFormUI.Opt_EmployeeNationalType = Convert.ToInt32(ddlOpt_EmployeeNationalType.SelectedValue);
            employeeFormUI.IqamaBathaqaNumber = txtIqamaBathaqaNumber.Text;
            employeeFormUI.Address = txtAddress.Text;
            employeeFormUI.City = txtCity.Text;
            employeeFormUI.State = txtState.Text;
            employeeFormUI.ZipCode = txtZipCode.Text;
            employeeFormUI.Tbl_CountryId = txtCountryGuid.Text;
            employeeFormUI.Phone = txtPhone.Text;
            employeeFormUI.Mobile = txtMobile.Text;
            employeeFormUI.FaxNo = txtFaxNo.Text;
            employeeFormUI.Email = txtEmail.Text;
            employeeFormUI.Tbl_HR_DivisionId = txtHR_DivisionGuid.Text;
            employeeFormUI.Tbl_HR_DepartmentId = txtHR_DepartmentGuid.Text;
            employeeFormUI.Tbl_HR_PositionId = txtHR_PositionGuid.Text;
            employeeFormUI.Tbl_HR_BranchId = txtHR_BranchGuid.Text;
            employeeFormUI.Tbl_HR_SupervisorId = txtHR_SupervisorGuid.Text;
            employeeFormUI.SeniorityDate = DateTime.Parse(txtSeniorityDate.Text);
            employeeFormUI.HireDate = DateTime.Parse(txtHireDate.Text);
            employeeFormUI.AdjustedHireDate = DateTime.Parse(txtAdjustedHireDate.Text);
            employeeFormUI.LastWorkingDay = DateTime.Parse(txtLastWorkingDay.Text);
            employeeFormUI.InactivatedDate = DateTime.Parse(txtInactivatedDate.Text);
            employeeFormUI.Reason = txtReason.Text;
            employeeFormUI.Tbl_Country_Nationality = txtCountry_NationalityGuid.Text;
            if (rdbActive.Checked)
            {
                hRStatus = 1;
                employeeFormUI.HRStatus = hRStatus;
            }
            else if (rdbInActive.Checked)
            {
                hRStatus = 2;
                employeeFormUI.HRStatus = hRStatus;
            }
            employeeFormUI.opt_EmploymentType = Convert.ToInt32(ddlopt_EmploymentType.SelectedValue);
            employeeFormUI.DOB = DateTime.Parse(txtDOB.Text);
            if (rdbMale.Checked)
            {
                gender = 1;
                employeeFormUI.Gender = gender;
            }
            else if (rdbFemale.Checked)
            {
                gender = 2;
                employeeFormUI.Gender = gender;
            }

            if (rdbMARRIED.Checked)
            {
                maritalStatus = 1;
                employeeFormUI.MaritalStatus = maritalStatus;
            }
            else if (rdbSINGLE.Checked)
            {
                maritalStatus = 2;
                employeeFormUI.MaritalStatus = maritalStatus;
            }
            employeeFormUI.WorkHoursPerYear = Convert.ToInt32(txtWorkHoursPerYear.Text);
            employeeFormUI.PassportNumber = txtPassportNumber.Text;
            employeeFormUI.PassportExp = DateTime.Parse(txtPassportExp.Text);
            employeeFormUI.IqamaBathaqaExp = DateTime.Parse(txtIqamaBathaqaExp.Text);
            if (employeeFormBAL.UpdateEmployee(employeeFormUI) == 1)
            {
                divSuccess.Visible = true;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = employeeFormUI.Tbl_EmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : btnUpdate_Click] An error occured in the processing of Record Id : " + employeeFormUI.Tbl_EmployeeId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        EmployeeFormUI employeeFormUI = new EmployeeFormUI();
        try
        {
            employeeFormUI.Tbl_EmployeeId = Request.QueryString["EmployeeId"];

            if (employeeFormBAL.DeleteEmployee(employeeFormUI) == 1)
            {
                divSuccess.Visible = true;
                lblSuccess.Text = Resources.GlobalResource.msgRecordDeleteSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotDeleteRecord;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnDelete_Click()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = employeeFormUI.Tbl_EmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : btnDelete_Click] An error occured in the processing of Record Id : " + employeeFormUI.Tbl_EmployeeId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeList.aspx");
    }
    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Human_Resource/Employee_Master_Data/Manage_Personal_Details/EmployeeForm.aspx";
        string recordId = Request.QueryString["EmployeeId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    #region Events Country Search

    protected void btnCountrySearch_Click(object sender, EventArgs e)
    {
        btnHtmlCountrySearch.Visible = false;
        btnHtmlCountryClose.Visible = true;
        SearchCountryList();
    }

    protected void btnClearCountrySearch_Click(object sender, EventArgs e)
    {
        BindCountryList();
        gvCountrySearch.Visible = true;
        btnHtmlCountrySearch.Visible = true;
        btnHtmlCountryClose.Visible = false;
        txtCountrySearch.Text = "";
        txtCountrySearch.Focus();
    }

    protected void btnCountryRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindCountryList();
    }

    #endregion Events Country Search
   
    #region Events HR_Division Search

    protected void btnHR_DivisionSearch_Click(object sender, EventArgs e)
    {
        btnHtmlHR_DivisionSearch.Visible = false;
        btnHtmlHR_DivisionClose.Visible = true;
        SearchHR_DivisionList();
    }

    protected void btnClearHR_DivisionSearch_Click(object sender, EventArgs e)
    {
        BindHR_DivisionList();
        gvHR_DivisionSearch.Visible = true;
        btnHtmlHR_DivisionSearch.Visible = true;
        btnHtmlHR_DivisionClose.Visible = false;
        txtHR_DivisionSearch.Text = "";
        txtHR_DivisionSearch.Focus();
    }

    protected void btnHR_DivisionRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindHR_DivisionList();
    }

    #endregion Events HR_Division Search
    
    #region Events HR_Department Search

    protected void btnHR_DepartmentSearch_Click(object sender, EventArgs e)
    {
        btnHtmlHR_DepartmentSearch.Visible = false;
        btnHtmlHR_DepartmentClose.Visible = true;
        SearchHR_DepartmentList();
    }

    protected void btnClearHR_DepartmentSearch_Click(object sender, EventArgs e)
    {
        BindHR_DepartmentList();
        gvHR_DepartmentSearch.Visible = true;
        btnHtmlHR_DepartmentSearch.Visible = true;
        btnHtmlHR_DepartmentClose.Visible = false;
        txtHR_DepartmentSearch.Text = "";
        txtHR_DepartmentSearch.Focus();
    }

    protected void btnHR_DepartmentRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindHR_DepartmentList();
    }

    #endregion Events HR_Department Search
    
    #region Events HR_Branch Search

    protected void btnHR_BranchSearch_Click(object sender, EventArgs e)
    {
        btnHtmlHR_BranchSearch.Visible = false;
        btnHtmlHR_BranchClose.Visible = true;
        SearchHR_BranchList();
    }

    protected void btnClearHR_BranchSearch_Click(object sender, EventArgs e)
    {
        BindHR_BranchList();
        gvHR_BranchSearch.Visible = true;
        btnHtmlHR_BranchSearch.Visible = true;
        btnHtmlHR_BranchClose.Visible = false;
        txtHR_BranchSearch.Text = "";
        txtHR_BranchSearch.Focus();
    }

    protected void btnHR_BranchRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindHR_BranchList();
    }

    #endregion Events HR_Branch Search
    
    #region Events HR_Position Search

    protected void btnHR_PositionSearch_Click(object sender, EventArgs e)
    {
        btnHtmlHR_PositionSearch.Visible = false;
        btnHtmlHR_PositionClose.Visible = true;
        SearchHR_PositionList();
    }

    protected void btnClearHR_PositionSearch_Click(object sender, EventArgs e)
    {
        BindHR_PositionList();
        gvHR_PositionSearch.Visible = true;
        btnHtmlHR_PositionSearch.Visible = true;
        btnHtmlHR_PositionClose.Visible = false;
        txtHR_PositionSearch.Text = "";
        txtHR_PositionSearch.Focus();
    }

    protected void btnHR_PositionRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindHR_PositionList();
    }

    #endregion Events HR_Position Search
    
    #region Events HR_Supervisor Search

    protected void btnHR_SupervisorSearch_Click(object sender, EventArgs e)
    {
        btnHtmlHR_SupervisorSearch.Visible = false;
        btnHtmlHR_SupervisorClose.Visible = true;
        SearchHR_SupervisorList();
    }

    protected void btnClearHR_SupervisorSearch_Click(object sender, EventArgs e)
    {
        BindHR_SupervisorList();
        gvHR_SupervisorSearch.Visible = true;
        btnHtmlHR_SupervisorSearch.Visible = true;
        btnHtmlHR_SupervisorClose.Visible = false;
        txtHR_SupervisorSearch.Text = "";
        txtHR_SupervisorSearch.Focus();
    }

    protected void btnHR_SupervisorRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindHR_SupervisorList();
    }

    #endregion Events HR_Supervisor Search
    
    #region Events Country_Nationality Search

    protected void btnCountry_NationalitySearch_Click(object sender, EventArgs e)
    {
        btnHtmlCountry_NationalitySearch.Visible = false;
        btnHtmlCountry_NationalityClose.Visible = true;
        SearchCountry_NationalityList();
    }

    protected void btnClearCountry_NationalitySearch_Click(object sender, EventArgs e)
    {
        BindCountry_NationalityList();
        gvCountry_NationalitySearch.Visible = true;
        btnHtmlCountry_NationalitySearch.Visible = true;
        btnHtmlCountry_NationalityClose.Visible = false;
        txtCountry_NationalitySearch.Text = "";
        txtCountry_NationalitySearch.Focus();
    }

    protected void btnCountry_NationalityRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindCountry_NationalityList();
    }

    #endregion Events Country_Nationality Search



    #endregion Events

    #region Methods

    private void GetSerialNumber(EmployeeFormUI employeeFormUI)
    {
        try
        {
            DataTable dtb = employeeFormBAL.GetSerialNumber(employeeFormUI);
            if (dtb.Rows.Count > 0)
            {
                txtEmployeeCode.Text = dtb.Rows[0][0].ToString();

            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotLoadData;
                divError.Visible = true;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetSerialNumber()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = employeeFormUI.Tbl_EmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : GetSerialNumber] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void FillForm(EmployeeFormUI employeeFormUI)
    {
        try
        {
            DataTable dtb = employeeFormBAL.GetEmployeeListById(employeeFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtEmployeeCode.Text = dtb.Rows[0]["EmployeeCode"].ToString();
                txtFirstName.Text = dtb.Rows[0]["FirstName"].ToString();
                txtMiddleName.Text = dtb.Rows[0]["MiddleName"].ToString();
                txtLastName.Text = dtb.Rows[0]["LastName"].ToString();
                txtContact.Text = dtb.Rows[0]["Contact"].ToString();
                ddlOpt_EmployeeNationalType.SelectedValue = dtb.Rows[0]["Opt_EmployeeNationalType"].ToString();
                txtIqamaBathaqaNumber.Text = dtb.Rows[0]["IqamaBathaqaNumber"].ToString();
                txtAddress.Text = dtb.Rows[0]["Address"].ToString();
                txtCity.Text = dtb.Rows[0]["City"].ToString();
                txtState.Text = dtb.Rows[0]["State"].ToString();
                txtZipCode.Text = dtb.Rows[0]["ZipCode"].ToString();
                txtCountryGuid.Text = dtb.Rows[0]["tbl_CountryId"].ToString();
                txtCountry.Text = dtb.Rows[0]["CountryName"].ToString();
                txtPhone.Text = dtb.Rows[0]["Phone"].ToString();
                txtMobile.Text = dtb.Rows[0]["Mobile"].ToString();
                txtFaxNo.Text = dtb.Rows[0]["FaxNo"].ToString();
                txtEmail.Text = dtb.Rows[0]["Email"].ToString();
                txtHR_BranchGuid.Text = dtb.Rows[0]["tbl_HR_BranchId"].ToString();
                txtHR_Branch.Text = dtb.Rows[0]["tbl_HR_Branch"].ToString();
                txtHR_DepartmentGuid.Text = dtb.Rows[0]["tbl_HR_DepartmentId"].ToString();
                txtHR_Department.Text = dtb.Rows[0]["tbl_HR_Department"].ToString();
                txtHR_DivisionGuid.Text = dtb.Rows[0]["tbl_HR_DivisionId"].ToString();
                txtHR_Division.Text = dtb.Rows[0]["tbl_HR_Division"].ToString();
                txtHR_PositionGuid.Text = dtb.Rows[0]["tbl_HR_PositionId"].ToString();
                txtHR_Position.Text = dtb.Rows[0]["tbl_HR_Position"].ToString();
                txtHR_SupervisorGuid.Text = dtb.Rows[0]["tbl_HR_SupervisorId"].ToString();
                txtHR_Supervisor.Text = dtb.Rows[0]["tbl_HR_Supervisor"].ToString();
                txtSeniorityDate.Text = dtb.Rows[0]["SeniorityDate"].ToString();
                txtHireDate.Text = dtb.Rows[0]["HireDate"].ToString();
                txtAdjustedHireDate.Text = dtb.Rows[0]["AdjustedHireDate"].ToString();
                txtLastWorkingDay.Text = dtb.Rows[0]["LastWorkingDay"].ToString();
                txtInactivatedDate.Text = dtb.Rows[0]["InactivatedDate"].ToString();
                txtReason.Text = dtb.Rows[0]["Reason"].ToString();
                txtCountry_NationalityGuid.Text = dtb.Rows[0]["tbl_CountryId"].ToString();
                txtCountry_Nationality.Text = dtb.Rows[0]["CountryName"].ToString();
                if (dtb.Rows[0]["HRStatus"].ToString() == "ACTIVE")
                {
                    rdbActive.Checked = true;
                }
                else if (dtb.Rows[0]["HRStatus"].ToString() == "INACTIVE")
                {
                    rdbInActive.Checked = true;
                }
                ddlopt_EmploymentType.SelectedValue = dtb.Rows[0]["opt_EmploymentType"].ToString();
                txtDOB.Text= dtb.Rows[0]["DOB"].ToString();
                if (dtb.Rows[0]["Gender"].ToString() == "MALE")
                {
                    rdbMale.Checked = true;
                }
                else if (dtb.Rows[0]["Gender"].ToString() == "FEMALE")
                {

                    rdbFemale.Checked = true;
                }
                if (dtb.Rows[0]["MaritalStatus"].ToString() == "MARRIED")
                {
                    rdbMARRIED.Checked = true;

                }
                else if (dtb.Rows[0]["MaritalStatus"].ToString() == "SINGLE")
                {
                    rdbSINGLE.Checked = true;
                }
                txtWorkHoursPerYear.Text = dtb.Rows[0]["WorkHoursPerYear"].ToString();
                txtPassportNumber.Text = dtb.Rows[0]["PassportNumber"].ToString();
                txtPassportExp.Text= dtb.Rows[0]["PassportExp"].ToString();
                txtIqamaBathaqaExp.Text= dtb.Rows[0]["IqamaBathaqaExp"].ToString();
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = employeeFormUI.Tbl_EmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : FillForm] An error occured in the processing of Record Id : " + employeeFormUI.Tbl_EmployeeId + ". Details : [" + exp.ToString() + "]");
        }
    }

    private void BindEmployeeNationalTypeDropDown()
    {
        OptionSetListUI optionSetListUI = new OptionSetListUI();
        optionSetListUI.TableName = "tbl_Employee";
        optionSetListUI.OptionSetName = "Opt_EmployeeNationalType";
        try
        {

            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);

            if (dtb.Rows.Count > 0)
            {
                ddlOpt_EmployeeNationalType.DataSource = dtb;
                ddlOpt_EmployeeNationalType.DataBind();

                ddlOpt_EmployeeNationalType.DataTextField = "OptionSetLable";
                ddlOpt_EmployeeNationalType.DataValueField = "OptionSetValue";
                ddlOpt_EmployeeNationalType.DataBind();
            }
            else
            {
                ddlOpt_EmployeeNationalType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindEmployeeNationalTypeDropDown()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "OptionSet Name " + optionSetListUI.OptionSetName;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : BindEmployeeNationalTypeDropDown] An error occured in the processing of Record OptionSet Name " + optionSetListUI.OptionSetName + ".  Details : [" + exp.ToString() + "]");
        }
    }
    private void BindEmploymentTypeDropDown()
    {
        OptionSetListUI optionSetListUI = new OptionSetListUI();
        optionSetListUI.TableName = "tbl_Employee";
        optionSetListUI.OptionSetName = "opt_EmploymentType";
        try
        {

            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);

            if (dtb.Rows.Count > 0)
            {
                ddlopt_EmploymentType.DataSource = dtb;
                ddlopt_EmploymentType.DataBind();

                ddlopt_EmploymentType.DataTextField = "OptionSetLable";
                ddlopt_EmploymentType.DataValueField = "OptionSetValue";
                ddlopt_EmploymentType.DataBind();
            }
            else
            {
                ddlopt_EmploymentType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindEmploymentTypeDropDown()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "OptionSet Name " + optionSetListUI.OptionSetName;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : BindEmploymentTypeDropDown] An error occured in the processing of Record OptionSet Name " + optionSetListUI.OptionSetName + ".  Details : [" + exp.ToString() + "]");
        }
    }

    #region Methods Country Search
    public void BindCountryList()
    {
        try
        {
            DataTable dtb = countryListBAL.GetCountryList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCountrySearch.DataSource = dtb;
                gvCountrySearch.DataBind();
                divCountrySearchError.Visible = false;
            }
            else
            {
                divCountrySearchError.Visible = true;
                lblCountrySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCountrySearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCountryList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : BindCountryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void SearchCountryList()
    {
        try
        {
            CountryListUI countryListUI = new CountryListUI();
            countryListUI.Search = txtCountrySearch.Text;

            DataTable dtb = countryListBAL.GetCountryListBySearchParameters(countryListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCountrySearch.DataSource = dtb;
                gvCountrySearch.DataBind();
                divCountrySearchError.Visible = false;
            }
            else
            {
                divCountrySearchError.Visible = true;
                lblCountrySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCountrySearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchCountryList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : SearchCountryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods Country Search
   
    #region Methods HR_Division Search
    public void BindHR_DivisionList()
    {
        try
        {
            DataTable dtb = hRDivisionListBAL.GetHRDivisionList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvHR_DivisionSearch.DataSource = dtb;
                gvHR_DivisionSearch.DataBind();
                divHR_DivisionSearchError.Visible = false;
            }
            else
            {
                divHR_DivisionSearchError.Visible = true;
                lblHR_DivisionSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvHR_DivisionSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindHR_DivisionList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : BindHR_DivisionList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void SearchHR_DivisionList()
    {
        try
        {
            
            HRDivisionListUI hR_DivisionListUI = new HRDivisionListUI();
            hR_DivisionListUI.Search = txtHR_DivisionSearch.Text;

            DataTable dtb = hRDivisionListBAL.GetHRDivisionListBySearchParameters(hR_DivisionListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvHR_DivisionSearch.DataSource = dtb;
                gvHR_DivisionSearch.DataBind();
                divHR_DivisionSearchError.Visible = false;
            }
            else
            {
                divHR_DivisionSearchError.Visible = true;
                lblHR_DivisionSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvHR_DivisionSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchHR_DivisionList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : SearchHR_DivisionList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods HR_Division Search

    #region Methods HRDepartment Search
    public void BindHR_DepartmentList()
    {
        try
        {
            DataTable dtb = hRDepartmentListBAL.GetHRDepartmentList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvHR_DepartmentSearch.DataSource = dtb;
                gvHR_DepartmentSearch.DataBind();
                divHR_DepartmentSearchError.Visible = false;
            }
            else
            {
                divHR_DepartmentSearchError.Visible = true;
                lblHR_DepartmentSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvHR_DepartmentSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindHRDepartmentList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : BindHRDepartmentList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    public void SearchHR_DepartmentList()
    {
        try
        {

            HRDepartmentListUI hRDepartmentListUI = new HRDepartmentListUI();
            hRDepartmentListUI.Search = txtHR_DepartmentSearch.Text;

            DataTable dtb = hRDepartmentListBAL.GetHRDepartmentListBySearchParameters(hRDepartmentListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvHR_DepartmentSearch.DataSource = dtb;
                gvHR_DepartmentSearch.DataBind();
                divHR_DepartmentSearchError.Visible = false;
            }
            else
            {
                divHR_DepartmentSearchError.Visible = true;
                lblHR_DepartmentSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvHR_DepartmentSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchHRDepartmentList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : SearchHRDepartmentList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods HRDepartment Search

    #region Methods HR_Branch Search
    public void BindHR_BranchList()
    {
        try
        {
            DataTable dtb = hR_BranchListBAL.GetHR_BranchList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvHR_BranchSearch.DataSource = dtb;
                gvHR_BranchSearch.DataBind();
                divHR_BranchSearchError.Visible = false;
            }
            else
            {
                divHR_BranchSearchError.Visible = true;
                lblHR_BranchSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvHR_BranchSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindHR_BranchList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : BindHR_BranchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void SearchHR_BranchList()
    {
        try
        {

            HR_BranchListUI hR_BranchListUI = new HR_BranchListUI();
            hR_BranchListUI.Search = txtHR_BranchSearch.Text;

            DataTable dtb = hR_BranchListBAL.GetHR_BranchListBySearchParameters(hR_BranchListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvHR_BranchSearch.DataSource = dtb;
                gvHR_BranchSearch.DataBind();
                divHR_BranchSearchError.Visible = false;
            }
            else
            {
                divHR_BranchSearchError.Visible = true;
                lblHR_BranchSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvHR_BranchSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchHR_BranchList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : SearchHR_BranchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods HR_Branch Search
   
    #region Methods HR_Position Search
    public void BindHR_PositionList()
    {
        try
        {
            DataTable dtb = hR_PositionListBAL.GetHR_PositionList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvHR_PositionSearch.DataSource = dtb;
                gvHR_PositionSearch.DataBind();
                divHR_PositionSearchError.Visible = false;
            }
            else
            {
                divHR_PositionSearchError.Visible = true;
                lblHR_PositionSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvHR_PositionSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindHR_PositionList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : BindHR_PositionList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void SearchHR_PositionList()
    {
        try
        {

            HR_PositionListUI hR_PositionListUI = new HR_PositionListUI();
            hR_PositionListUI.Search = txtHR_PositionSearch.Text;

            DataTable dtb = hR_PositionListBAL.GetHR_PositionListBySearchParameters(hR_PositionListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvHR_PositionSearch.DataSource = dtb;
                gvHR_PositionSearch.DataBind();
                divHR_PositionSearchError.Visible = false;
            }
            else
            {
                divHR_PositionSearchError.Visible = true;
                lblHR_PositionSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvHR_PositionSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchHR_PositionList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : SearchHR_PositionList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods HR_Position Search

    #region Methods HR_Supervisor Search
    public void BindHR_SupervisorList()
    {
        try
        {
            DataTable dtb = hR_SupervisorListBAL.GetHR_SupervisorList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvHR_SupervisorSearch.DataSource = dtb;
                gvHR_SupervisorSearch.DataBind();
                divHR_SupervisorSearchError.Visible = false;
            }
            else
            {
                divHR_SupervisorSearchError.Visible = true;
                lblHR_SupervisorSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvHR_SupervisorSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindHR_SupervisorList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : BindHR_SupervisorList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void SearchHR_SupervisorList()
    {
        try
        {

            HR_SupervisorListUI hR_SupervisorListUI = new HR_SupervisorListUI();
            hR_SupervisorListUI.Search = txtHR_SupervisorSearch.Text;

            DataTable dtb = hR_SupervisorListBAL.GetHR_SupervisorListBySearchParameters(hR_SupervisorListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvHR_SupervisorSearch.DataSource = dtb;
                gvHR_SupervisorSearch.DataBind();
                divHR_SupervisorSearchError.Visible = false;
            }
            else
            {
                divHR_SupervisorSearchError.Visible = true;
                lblHR_SupervisorSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvHR_SupervisorSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchHR_SupervisorList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : SearchHR_SupervisorList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods HR_Supervisor Search

    #region Methods Country_Nationality Search
    public void BindCountry_NationalityList()
    {
        try
        {
            DataTable dtb = countryListBAL.GetCountryList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCountry_NationalitySearch.DataSource = dtb;
                gvCountry_NationalitySearch.DataBind();
                divCountry_NationalitySearchError.Visible = false;
            }
            else
            {
                divCountry_NationalitySearchError.Visible = true;
                lblCountry_NationalitySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCountry_NationalitySearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCountry_NationalityList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : BindCountry_NationalityList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void SearchCountry_NationalityList()
    {
        try
        {
            CountryListUI countryListUI = new CountryListUI();
            countryListUI.Search = txtCountry_NationalitySearch.Text;

            DataTable dtb = countryListBAL.GetCountryListBySearchParameters(countryListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCountry_NationalitySearch.DataSource = dtb;
                gvCountry_NationalitySearch.DataBind();
                divCountry_NationalitySearchError.Visible = false;
            }
            else
            {
                divCountry_NationalitySearchError.Visible = true;
                lblCountry_NationalitySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCountry_NationalitySearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchCountry_NationalityList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : SearchCountry_NationalityList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods Country_Nationality Search

    //#region Methods Employee Group Search
    //public void BindEmployeeGroupList()
    //{
    //    try
    //    {
    //        DataTable dtb = employeeGroupListBAL.GetEmployeeGroupList();

    //        if (dtb.Rows.Count > 0 && dtb != null)
    //        {
    //            gvEmployeeGroupSearch.DataSource = dtb;
    //            gvEmployeeGroupSearch.DataBind();
    //            divEmployeeGroupSearchError.Visible = false;
    //        }
    //        else
    //        {
    //            divEmployeeGroupSearchError.Visible = true;
    //            lblEmployeeGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
    //            gvEmployeeGroupSearch.Visible = false;
    //        }
    //    }
    //    catch (Exception exp)
    //    {
    //        logExcpUIobj.MethodName = "BindEmployeeGroupList()";
    //        logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
    //        logExcpUIobj.RecordId = "All";
    //        logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
    //        logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

    //        log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : BindEmployeeGroupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
    //    }
    //}

    //public void SearchEmployeeGroupList()
    //{
    //    try
    //    {
    //        EmployeeGroupListUI employeeGroupListUI = new EmployeeGroupListUI();
    //        employeeGroupListUI.Search = txtCountrySearch.Text;

    //        DataTable dtb = employeeGroupListBAL.GetEmployeeGroupListBySearchParameters(employeeGroupListUI);

    //        if (dtb.Rows.Count > 0 && dtb != null)
    //        {
    //            gvEmployeeGroupSearch.DataSource = dtb;
    //            gvEmployeeGroupSearch.DataBind();
    //            divEmployeeGroupSearchError.Visible = false;
    //        }
    //        else
    //        {
    //            divEmployeeGroupSearchError.Visible = true;
    //            lblEmployeeGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
    //            gvEmployeeGroupSearch.Visible = false;
    //        }

    //    }
    //    catch (Exception exp)
    //    {
    //        logExcpUIobj.MethodName = "EmployeeGroup()";
    //        logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
    //        logExcpUIobj.RecordId = "All";
    //        logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
    //        logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

    //        log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : EmployeeGroup] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
    //    }
    //}
    //#endregion Methods Employee Group Search

    #endregion Methods
}
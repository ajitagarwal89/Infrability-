using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;


public partial class Human_Resource_Employee_Dependents_EmployeeDependentsForm :PageBase 
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    EmployeeDependentsFormBAL employeeDependentsFormBAL = new EmployeeDependentsFormBAL();
    CountryListBAL countryListBAL = new CountryListBAL();
    EmployeeListBAL employeeListBAL = new EmployeeListBAL();

    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    HRDepartmentListBAL hRDepartmentListBAL = new HRDepartmentListBAL();
    #endregion Data Members
    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        EmployeeDependentsFormUI employeeDependentsFormUI = new EmployeeDependentsFormUI();

        if (!Page.IsPostBack)
        {
          
            BindRelationshipDropDown();
            if (Request.QueryString["EmployeeDependentsId"] != null || Request.QueryString["recordId"] != null)
            {
                employeeDependentsFormUI.Tbl_EmployeeDependentsId = (Request.QueryString["EmployeeDependentsId"] != null ? Request.QueryString["EmployeeDependentsId"] : Request.QueryString["recordId"]);

                FillForm(employeeDependentsFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnAuditHistory.Visible = true;
                lblHeading.Text = "Update Employee Dependents";
            }
            else
            {



                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New Employee Dependents";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
       
        int gender = 0;
     
        EmployeeDependentsFormUI employeeDependentsFormUI = new EmployeeDependentsFormUI();
        try
        {

            employeeDependentsFormUI.CreatedBy = SessionContext.UserGuid;
            employeeDependentsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            employeeDependentsFormUI.Tbl_EmployeeId = txtEmployeeGuid.Text;
            employeeDependentsFormUI.Tbl_CountryId = txtCountryGuid.Text;
            employeeDependentsFormUI.Tbl_HR_DepartmentId = txtHR_DepartmentGuid.Text;
            employeeDependentsFormUI.Opt_Relationship = Convert.ToInt32(ddlOpt_Relationship.SelectedValue);

            employeeDependentsFormUI.FirstName = txtFirstName.Text;
            employeeDependentsFormUI.MiddleName = txtMiddleName.Text;
            employeeDependentsFormUI.LastName = txtLastName.Text;
            employeeDependentsFormUI.DOB = DateTime.Parse(txtDOB.Text);
            if (rdbMale.Checked)
            {
                gender = 1;
                employeeDependentsFormUI.Gender = gender;
            }
            else if (rdbFemale.Checked)
            {
                gender = 2;
                employeeDependentsFormUI.Gender = gender;
            }
            employeeDependentsFormUI.HomePhone = txtHomePhone.Text;
            employeeDependentsFormUI.WorkPhone = txtWorkPhone.Text;
            employeeDependentsFormUI.Ext = txtExt.Text;
            employeeDependentsFormUI.Address1 = txtAddress1.Text;
            employeeDependentsFormUI.Address2 = txtAddress2.Text;
            employeeDependentsFormUI.City = txtCity.Text;
            employeeDependentsFormUI.State = txtState.Text;
            employeeDependentsFormUI.ZipCode = txtZipCode.Text;

        
         
             if (employeeDependentsFormBAL.AddEmployeeDependents(employeeDependentsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Human_Resource_Employee_Dependents_EmployeeDependentsForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_Employee_Dependents_EmployeeDependentsForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        int gender = 0;
        EmployeeDependentsFormUI employeeDependentsFormUI = new EmployeeDependentsFormUI();
        try
        {
            employeeDependentsFormUI.ModifiedBy = SessionContext.UserGuid;
            employeeDependentsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            employeeDependentsFormUI.Tbl_EmployeeDependentsId = Request.QueryString["EmployeeDependentsId"];
            employeeDependentsFormUI.Tbl_EmployeeId = txtEmployeeGuid.Text;
            employeeDependentsFormUI.Tbl_CountryId = txtCountryGuid.Text;
            employeeDependentsFormUI.Tbl_HR_DepartmentId = txtHR_DepartmentGuid.Text;
            employeeDependentsFormUI.Opt_Relationship = Convert.ToInt32(ddlOpt_Relationship.SelectedValue);

            employeeDependentsFormUI.FirstName = txtFirstName.Text;
            employeeDependentsFormUI.MiddleName = txtMiddleName.Text;
            employeeDependentsFormUI.LastName = txtLastName.Text;
            employeeDependentsFormUI.DOB = DateTime.Parse(txtDOB.Text);
            if (rdbMale.Checked)
            {
                gender = 1;
                employeeDependentsFormUI.Gender = gender;
            }
            else if (rdbFemale.Checked)
            {
                gender = 2;
                employeeDependentsFormUI.Gender = gender;
            }
            employeeDependentsFormUI.HomePhone = txtHomePhone.Text;
            employeeDependentsFormUI.WorkPhone = txtWorkPhone.Text;
            employeeDependentsFormUI.Ext = txtExt.Text;
            employeeDependentsFormUI.Address1 = txtAddress1.Text;
            employeeDependentsFormUI.Address2 = txtAddress2.Text;
            employeeDependentsFormUI.City = txtCity.Text;
            employeeDependentsFormUI.State = txtState.Text;
            employeeDependentsFormUI.ZipCode = txtZipCode.Text;

            if (employeeDependentsFormBAL.UpdateEmployeeDependents(employeeDependentsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Human_Resource_Employee_Dependents_EmployeeDependentsForm.CS";
            logExcpUIobj.RecordId = employeeDependentsFormUI.Tbl_EmployeeDependentsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_Employee_Dependents_EmployeeDependentsForm : btnUpdate_Click] An error occured in the processing of Record Id : " + employeeDependentsFormUI.Tbl_EmployeeDependentsId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        EmployeeDependentsFormUI employeeDependentsFormUI = new EmployeeDependentsFormUI();
        try
        {
            employeeDependentsFormUI.Tbl_EmployeeDependentsId = Request.QueryString["EmployeeDependentsId"];

            if (employeeDependentsFormBAL.DeleteEmployeeDependents(employeeDependentsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Human_Resource_Employee_Dependents_EmployeeDependentsForm.CS";
            logExcpUIobj.RecordId = employeeDependentsFormUI.Tbl_EmployeeDependentsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_Employee_Dependents_EmployeeDependentsForm : btnDelete_Click] An error occured in the processing of Record Id : " + employeeDependentsFormUI.Tbl_EmployeeDependentsId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeDependentsList.aspx");
    }


    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Human_Resource/Employee_Dependents/EmployeeDependentsForm.aspx";
        string recordId = Request.QueryString["EmployeeDependentsId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
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

   #endregion Events

    #region Methods
    private void FillForm(EmployeeDependentsFormUI employeeDependentsFormUI)
    {
        try
        {
            DataTable dtb = employeeDependentsFormBAL.GetEmployeeDependentsListById(employeeDependentsFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtEmployee.Text = dtb.Rows[0]["tbl_Employee"].ToString();
                txtEmployeeGuid.Text = dtb.Rows[0]["tbl_EmployeeId"].ToString();

                txtCountryGuid.Text = dtb.Rows[0]["tbl_CountryId"].ToString();
                txtCountry.Text = dtb.Rows[0]["CountryName"].ToString();
                txtHR_DepartmentGuid.Text = dtb.Rows[0]["tbl_HR_DepartmentId"].ToString();
                txtHR_Department.Text = dtb.Rows[0]["tbl_HR_Department"].ToString();
                ddlOpt_Relationship.SelectedValue = dtb.Rows[0]["Opt_Relationship"].ToString();

                txtFirstName.Text = dtb.Rows[0]["FirstName"].ToString();
                txtMiddleName.Text = dtb.Rows[0]["MiddleName"].ToString();
                txtLastName.Text = dtb.Rows[0]["LastName"].ToString();

                txtDOB.Text = dtb.Rows[0]["DOB"].ToString();
                if (dtb.Rows[0]["Gender"].ToString() == "MALE")
                {
                    rdbMale.Checked = true;
                }
                else if (dtb.Rows[0]["Gender"].ToString() == "FEMALE")
                {

                    rdbFemale.Checked = true;
                }

                txtHomePhone.Text = dtb.Rows[0]["HomePhone"].ToString();
                txtWorkPhone.Text = dtb.Rows[0]["WorkPhone"].ToString();
                txtExt.Text = dtb.Rows[0]["Ext"].ToString();
                txtAddress1.Text = dtb.Rows[0]["Address1"].ToString();
                txtAddress2.Text = dtb.Rows[0]["Address2"].ToString();

                txtCity.Text = dtb.Rows[0]["City"].ToString();
                txtState.Text = dtb.Rows[0]["State"].ToString();
                txtZipCode.Text = dtb.Rows[0]["ZipCode"].ToString();

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
            logExcpUIobj.ResourceName = "Human_Resource_Employee_Dependents_EmployeeDependentsForm.CS";
            logExcpUIobj.RecordId = employeeDependentsFormUI.Tbl_EmployeeDependentsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_Employee_Dependents_EmployeeDependentsForm : FillForm] An error occured in the processing of Record Id : " + employeeDependentsFormUI.Tbl_EmployeeDependentsId + ". Details : [" + exp.ToString() + "]");
        }
    }
    private void BindRelationshipDropDown()
    {
        OptionSetListUI optionSetListUI = new OptionSetListUI();
        optionSetListUI.TableName = "tbl_EmployeeDependents";
        optionSetListUI.OptionSetName = "opt_Relationship";
        try
        {

            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);

            if (dtb.Rows.Count > 0)
            {
                ddlOpt_Relationship.DataSource = dtb;
                ddlOpt_Relationship.DataBind();

                ddlOpt_Relationship.DataTextField = "OptionSetLable";
                ddlOpt_Relationship.DataValueField = "OptionSetValue";
                ddlOpt_Relationship.DataBind();
                ddlOpt_Relationship.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlOpt_Relationship.SelectedIndex = 0;
            }
            else
            {
                ddlOpt_Relationship.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindRelationshipDropDown()";
            logExcpUIobj.ResourceName = "Human_Resource_Employee_Dependents_EmployeeDependentsForm.CS";
            logExcpUIobj.RecordId = "OptionSet Name " + optionSetListUI.OptionSetName;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_Employee_Dependents_EmployeeDependentsForm : BindRelationshipDropDown] An error occured in the processing of Record OptionSet Name " + optionSetListUI.OptionSetName + ".  Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Human_Resource_Employee_Dependents_EmployeeDependentsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_Employee_Dependents_EmployeeDependentsForm : BindEmployeeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Human_Resource_Employee_Dependents_EmployeeDependentsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_Employee_Dependents_EmployeeDependentsForm : SearchEmployeeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods Employee Search

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
            logExcpUIobj.ResourceName = "Human_Resource_Employee_Dependents_EmployeeDependentsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_Employee_Dependents_EmployeeDependentsForm : BindCountryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Human_Resource_Employee_Dependents_EmployeeDependentsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_Employee_Dependents_EmployeeDependentsForm : SearchCountryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods Country Search
    
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
            logExcpUIobj.ResourceName = "Human_Resource_Employee_Dependents_EmployeeDependentsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_Employee_Dependents_EmployeeDependentsForm : BindHRDepartmentList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Human_Resource_Employee_Dependents_EmployeeDependentsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_Employee_Dependents_EmployeeDependentsForm : SearchHRDepartmentList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods HRDepartment Search

   
     #endregion Methods

}
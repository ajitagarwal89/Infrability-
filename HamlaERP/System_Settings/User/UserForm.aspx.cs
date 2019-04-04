using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_UserForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    CountryListBAL countryListBAL = new CountryListBAL();
    UserFormUI userFormUI = new UserFormUI();
    UserFormBAL userFormBAL = new UserFormBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        UserFormUI userFormUI = new UserFormUI();

        if (!Page.IsPostBack)
        {
            BindDepartmentDropDown();
            BindDesignationDropDown();

            if (Request.QueryString["UserId"] != null || Request.QueryString["UserId"] != null)
            {
                userFormUI.Tbl_UserId = (Request.QueryString["UserId"] != null ? Request.QueryString["UserId"] : Request.QueryString["recordId"]);


                FillForm(userFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update User";
            }
            else
            {              
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New User";
            }
        }
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            userFormUI.CreatedBy = SessionContext.UserGuid;
            userFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            userFormUI.FullName = txtFullName.Text.Trim();
            userFormUI.EmployeeCode = txtEmployeeCode.Text.Trim();
            userFormUI.DOB = Convert.ToDateTime(txtDOB.Text.ToString());
            userFormUI.PermanentAddress = txtPermanentAddress.Text.Trim();
            userFormUI.CorrespondanceAddress = txtCorrespondanceAddress.Text.Trim();
            userFormUI.City = txtCity.Text.Trim();
            userFormUI.State = txtState.Text.Trim();
            userFormUI.PostalCode = txtPostalCode.Text.Trim();
            userFormUI.Tbl_CountryId = txtCountryGuid.Text.Trim();
            userFormUI.PhoneNo = txtPhone.Text.Trim();
            userFormUI.FaxNo = txtFax.Text.Trim();
            userFormUI.Mobile = txtMobile.Text.Trim();
            userFormUI.Email = txtEmail.Text.ToLower();
            userFormUI.Opt_Department = Convert.ToInt32(ddlOpt_Department.SelectedValue.ToString());
            userFormUI.DateOfJoining = Convert.ToDateTime(txtDateOfJoining.Text.ToString());
            userFormUI.Opt_Designation = Convert.ToInt32(ddlopt_Designation.SelectedValue.ToString());
            userFormUI.UserName = txtUserName.Text.Trim();
            userFormUI.Password = txtPassword.Text.Trim();
           
            if (userFormBAL.AddUser(userFormUI) == 1)
            {
                divSuccess.Visible = true;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
                divError.Visible = true;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "System_Settings_UserForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_UserForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        try
        {
            userFormUI.ModifiedBy = SessionContext.UserGuid;
            userFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            userFormUI.Tbl_UserId = Request.QueryString["UserId"];
            userFormUI.FullName = txtFullName.Text.Trim();
            userFormUI.EmployeeCode = txtEmployeeCode.Text.Trim();
            userFormUI.DOB = Convert.ToDateTime(txtDOB.Text.ToString());
            userFormUI.PermanentAddress = txtPermanentAddress.Text.Trim();
            userFormUI.CorrespondanceAddress = txtCorrespondanceAddress.Text.Trim();
            userFormUI.City = txtCity.Text.Trim();
            userFormUI.State = txtState.Text.Trim();
            userFormUI.PostalCode = txtPostalCode.Text.Trim();
            userFormUI.Tbl_CountryId = txtCountryGuid.Text.Trim();
            userFormUI.PhoneNo = txtPhone.Text.Trim();
            userFormUI.FaxNo = txtFax.Text.Trim();
            userFormUI.Mobile = txtMobile.Text.Trim();
            userFormUI.Email = txtEmail.Text.ToLower();
            userFormUI.Opt_Department = Convert.ToInt32(ddlOpt_Department.SelectedValue.ToString());
            userFormUI.DateOfJoining = Convert.ToDateTime(txtDateOfJoining.Text.ToString());
            userFormUI.Opt_Designation = Convert.ToInt32(ddlopt_Designation.SelectedValue.ToString());
            userFormUI.UserName = txtUserName.Text.Trim();
            userFormUI.Password = txtPassword.Text.Trim();

            if (userFormBAL.UpdateUser(userFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_UserForm.CS";
            logExcpUIobj.RecordId = userFormUI.Tbl_UserId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : btnUpdate_Click] An error occured in the processing of Record Id : " + userFormUI.Tbl_UserId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            userFormUI.Tbl_UserId = Request.QueryString["UserId"];

            if (userFormBAL.DeleteUser(userFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_UserForm.CS";
            logExcpUIobj.RecordId = userFormUI.Tbl_UserId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : btnDelete_Click] An error occured in the processing of Record Id : " + userFormUI.Tbl_UserId  + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
       Response.Redirect("UserList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/System_Settings/UserForm.aspx";
        string recordId = Request.QueryString["UserId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    #endregion Events

    #region Methods
    private void FillForm(UserFormUI userFormUI)
    {
        try
        {
            DataTable dtb = userFormBAL.GetUserListById(userFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtFullName.Text = dtb.Rows[0]["FullName"].ToString();
                txtEmployeeCode.Text = dtb.Rows[0]["EmployeeCode"].ToString();
                txtDOB.Text = dtb.Rows[0]["DOB"].ToString();
                txtPermanentAddress.Text = dtb.Rows[0]["PermanentAddress"].ToString();
                txtCorrespondanceAddress.Text = dtb.Rows[0]["CorrespondanceAddress"].ToString();
                txtCity.Text = dtb.Rows[0]["City"].ToString();
                txtState.Text = dtb.Rows[0]["State"].ToString(); 
                txtPostalCode.Text = dtb.Rows[0]["PostalCode"].ToString();
                txtCountryGuid.Text = dtb.Rows[0]["tbl_CountryId"].ToString();
                txtCountry.Text = dtb.Rows[0]["CountryName"].ToString();
                txtPhone.Text = dtb.Rows[0]["PhoneNo"].ToString();
                txtFax.Text = dtb.Rows[0]["FaxNo"].ToString();
                txtMobile.Text = dtb.Rows[0]["Mobile"].ToString();
                txtEmail.Text = dtb.Rows[0]["Email"].ToString();
                ddlOpt_Department.SelectedValue = dtb.Rows[0]["Department"].ToString();
                txtDateOfJoining.Text = dtb.Rows[0]["DateOfJoining"].ToString();
                ddlopt_Designation.SelectedValue = dtb.Rows[0]["Designation"].ToString();
                txtUserName.Text = dtb.Rows[0]["UserName"].ToString();
                txtPassword.Text = dtb.Rows[0]["Password"].ToString();
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
            logExcpUIobj.ResourceName = "System_Settings_UserForm.CS";
            logExcpUIobj.RecordId = userFormUI.Tbl_UserId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_UserForm : FillForm] An error occured in the processing of Record Id : " + userFormUI.Tbl_UserId + ". Details : [" + exp.ToString() + "]");
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
    private void BindDepartmentDropDown()
    {
        OptionSetListUI optionSetListUI = new OptionSetListUI();
        optionSetListUI.TableName = "tbl_User";
        optionSetListUI.OptionSetName = "Opt_Department";
        try
        {

            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);

            if (dtb.Rows.Count > 0)
            {
                ddlOpt_Department.DataSource = dtb;
                ddlOpt_Department.DataBind();

                ddlOpt_Department.DataTextField = "OptionSetLable";
                ddlOpt_Department.DataValueField = "OptionSetValue";
                ddlOpt_Department.DataBind();
            }
            else
            {
                ddlOpt_Department.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindDepartmentDropDown()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "OptionSet Name " + optionSetListUI.OptionSetName;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_UserForm : BindDepartmentDropDown] An error occured in the processing of Record OptionSet Name " + optionSetListUI.OptionSetName + ".  Details : [" + exp.ToString() + "]");
        }

    }
    private void BindDesignationDropDown()
    {
        OptionSetListUI optionSetListUI = new OptionSetListUI();
        optionSetListUI.TableName = "tbl_User";
        optionSetListUI.OptionSetName = "Opt_Designation";
        try
        {

            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);

            if (dtb.Rows.Count > 0)
            {
                ddlopt_Designation.DataSource = dtb;
                ddlopt_Designation.DataBind();

                ddlopt_Designation.DataTextField = "OptionSetLable";
                ddlopt_Designation.DataValueField = "OptionSetValue";
                ddlopt_Designation.DataBind();
            }
            else
            {
                ddlopt_Designation.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindEmployeeNationalTypeDropDown()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "OptionSet Name " + optionSetListUI.OptionSetName;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_UserForm : BindDesignationDropDown] An error occured in the processing of Record OptionSet Name " + optionSetListUI.OptionSetName + ".  Details : [" + exp.ToString() + "]");
        }

    }
    #endregion Methods
}
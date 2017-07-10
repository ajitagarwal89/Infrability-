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

    EmployeeGroupListBAL employeeGroupListBAL = new EmployeeGroupListBAL();

    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();

    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        EmployeeFormUI employeeFormUI = new EmployeeFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["EmployeeId"] != null)
            {
                employeeFormUI.Tbl_EmployeeId = Request.QueryString["EmployeeId"];

                BindStatuDropDown();
                FillForm(employeeFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Employee";
            }
            else
            {

                BindStatuDropDown();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Employee";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        EmployeeFormUI employeeFormUI = new EmployeeFormUI();
        try
        {

            employeeFormUI.CreatedBy = SessionContext.UserGuid;
            employeeFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            employeeFormUI.EmployeeCode = txtEmployeeCode.Text;
            employeeFormUI.Name = txtName.Text;
            employeeFormUI.ShortName = txtShortName.Text;
            employeeFormUI.ChequeName = txtChequeName.Text;
            employeeFormUI.Contact = txtContact.Text;
            employeeFormUI.Address = txtAddress.Text;
            employeeFormUI.City = txtCity.Text;
            employeeFormUI.ZipCode = txtZipCode.Text;

            employeeFormUI.Tbl_CountryId = txtCountryGuid.Text;
            employeeFormUI.Phone = txtPhone.Text;
            employeeFormUI.Mobile = txtMobile.Text;
            employeeFormUI.FaxNo = txtFaxNo.Text;
            employeeFormUI.Email = txtEmail.Text;
            employeeFormUI.Comment1 = txtComment1.Text;
            employeeFormUI.Comment2 = txtComment2.Text;
            employeeFormUI.Opt_Status = Convert.ToInt32(ddlStatus.SelectedValue);
            if (txtEmployeeGroupGuid.Text != "")
                employeeFormUI.Tbl_EmployeeGroupId = txtEmployeeGroupGuid.Text;
            else
                employeeFormUI.Tbl_EmployeeGroupId = null;

            if (chkOnHold.Checked == true)
                employeeFormUI.OnHold = true;
            else
                employeeFormUI.OnHold = false;


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
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        EmployeeFormUI employeeFormUI = new EmployeeFormUI();
        try
        {
            employeeFormUI.ModifiedBy = SessionContext.UserGuid;
            employeeFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            employeeFormUI.Tbl_EmployeeId = Request.QueryString["EmployeeId"];

            employeeFormUI.EmployeeCode = txtEmployeeCode.Text;
            employeeFormUI.Name = txtName.Text;
            employeeFormUI.ShortName = txtShortName.Text;
            employeeFormUI.ChequeName = txtChequeName.Text;
            employeeFormUI.Contact = txtContact.Text;
            employeeFormUI.Address = txtAddress.Text;
            employeeFormUI.City = txtCity.Text;
            employeeFormUI.ZipCode = txtZipCode.Text;

            employeeFormUI.Tbl_CountryId = txtCountryGuid.Text;
            employeeFormUI.Phone = txtPhone.Text;
            employeeFormUI.Mobile = txtMobile.Text;
            employeeFormUI.FaxNo = txtFaxNo.Text;
            employeeFormUI.Email = txtEmail.Text;
            employeeFormUI.Comment1 = txtComment1.Text;
            employeeFormUI.Comment2 = txtComment2.Text;
            employeeFormUI.Opt_Status = Convert.ToInt32(ddlStatus.SelectedValue);
            employeeFormUI.Tbl_EmployeeGroupId = txtEmployeeGroupGuid.Text;

            if (chkOnHold.Checked == true)
                employeeFormUI.OnHold = true;
            else
                employeeFormUI.OnHold = false;

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
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = employeeFormUI.Tbl_EmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : btnUpdate_Click] An error occured in the processing of Record Id : " + employeeFormUI.Tbl_EmployeeId + ".  Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = employeeFormUI.Tbl_EmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : btnDelete_Click] An error occured in the processing of Record Id : " + employeeFormUI.Tbl_EmployeeId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeList.aspx");
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

    #region Events Employee Group Search

    protected void btnEmployeeGroupSearch_Click(object sender, EventArgs e)
    {
        btnHtmlEmployeeGroupSearch.Visible = false;
        btnHtmlEmployeeGroupClose.Visible = true;
        SearchEmployeeGroupList();
    }

    protected void btnClearEmployeeGroupSearch_Click(object sender, EventArgs e)
    {
        BindEmployeeGroupList();
        gvEmployeeGroupSearch.Visible = true;
        btnHtmlEmployeeGroupSearch.Visible = true;
        btnHtmlEmployeeGroupClose.Visible = false;
        txtEmployeeGroupSearch.Text = "";
        txtEmployeeGroupSearch.Focus();
    }

    protected void btnEmployeeGroupRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindEmployeeGroupList();
    }

    #endregion Events Employee Group Search

    #endregion Events

    #region Methods
    private void FillForm(EmployeeFormUI employeeFormUI)
    {
        try
        {
            DataTable dtb = employeeFormBAL.GetEmployeeListById(employeeFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtEmployeeCode.Text = dtb.Rows[0]["EmployeeCode"].ToString();
                txtName.Text = dtb.Rows[0]["Name"].ToString();
                txtShortName.Text = dtb.Rows[0]["ShortName"].ToString();
                txtChequeName.Text = dtb.Rows[0]["ChequeName"].ToString();
                txtContact.Text = dtb.Rows[0]["Contact"].ToString();
                txtAddress.Text = dtb.Rows[0]["Address"].ToString();
                txtCity.Text = dtb.Rows[0]["City"].ToString();
                txtZipCode.Text = dtb.Rows[0]["ZipCode"].ToString();

                txtCountryGuid.Text = dtb.Rows[0]["tbl_CountryId"].ToString();
                txtCountry.Text = dtb.Rows[0]["CountryName"].ToString();

                txtPhone.Text = dtb.Rows[0]["Phone"].ToString();
                txtMobile.Text = dtb.Rows[0]["Mobile"].ToString();
                txtFaxNo.Text = dtb.Rows[0]["FaxNo"].ToString();
                txtEmail.Text = dtb.Rows[0]["Email"].ToString();
                txtComment1.Text = dtb.Rows[0]["Comment1"].ToString();
                txtComment2.Text = dtb.Rows[0]["Comment2"].ToString();
                ddlStatus.SelectedValue = dtb.Rows[0]["Opt_Status"].ToString();
                txtEmployeeGroupGuid.Text = dtb.Rows[0]["tbl_EmployeeGroupId"].ToString();
                txtEmployeeGroup.Text = dtb.Rows[0]["EmployeeGroupName"].ToString();

                if (Convert.ToBoolean(dtb.Rows[0]["OnHold"]) == true)
                    chkOnHold.Checked = true;
                else
                    chkOnHold.Checked = false;

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
            logExcpUIobj.RecordId = employeeFormUI.Tbl_EmployeeGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : FillForm] An error occured in the processing of Record Id : " + employeeFormUI.Tbl_EmployeeGroupId + ". Details : [" + exp.ToString() + "]");
        }
    }

    private void BindStatuDropDown()
    {
        OptionSetListUI optionSetListUI = new OptionSetListUI();
        optionSetListUI.TableName = "tbl_Employee";
        optionSetListUI.OptionSetName = "Opt_Status";
        try
        {

            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);

            if (dtb.Rows.Count > 0)
            {
                ddlStatus.DataSource = dtb;
                ddlStatus.DataBind();

                ddlStatus.DataTextField = "OptionSetLable";
                ddlStatus.DataValueField = "OptionSetValue";
                ddlStatus.DataBind();
            }
            else
            {
                ddlStatus.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindStatuDropDown()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "OptionSet Name " + optionSetListUI.OptionSetName;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : BindStatuDropDown] An error occured in the processing of Record OptionSet Name " + optionSetListUI.OptionSetName + ".  Details : [" + exp.ToString() + "]");
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

    #region Methods Employee Group Search
    public void BindEmployeeGroupList()
    {
        try
        {
            DataTable dtb = employeeGroupListBAL.GetEmployeeGroupList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvEmployeeGroupSearch.DataSource = dtb;
                gvEmployeeGroupSearch.DataBind();
                divEmployeeGroupSearchError.Visible = false;
            }
            else
            {
                divEmployeeGroupSearchError.Visible = true;
                lblEmployeeGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvEmployeeGroupSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindEmployeeGroupList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : BindEmployeeGroupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void SearchEmployeeGroupList()
    {
        try
        {
            EmployeeGroupListUI employeeGroupListUI = new EmployeeGroupListUI();
            employeeGroupListUI.Search = txtCountrySearch.Text;

            DataTable dtb = employeeGroupListBAL.GetEmployeeGroupListBySearchParameters(employeeGroupListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvEmployeeGroupSearch.DataSource = dtb;
                gvEmployeeGroupSearch.DataBind();
                divEmployeeGroupSearchError.Visible = false;
            }
            else
            {
                divEmployeeGroupSearchError.Visible = true;
                lblEmployeeGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvEmployeeGroupSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "EmployeeGroup()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : EmployeeGroup] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods Employee Group Search

    #endregion Methods
}
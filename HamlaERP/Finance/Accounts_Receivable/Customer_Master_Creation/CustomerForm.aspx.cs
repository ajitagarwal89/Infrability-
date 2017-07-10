using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;


public partial class Finance_Accounts_Receivable_Customer_Master_Creation_CustomerForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    CustomerFormBAL customerFormBAL = new CustomerFormBAL();

    CountryListBAL countryListBAL = new CountryListBAL();

    CustomerGroupListBAL customerGroupListBAL = new CustomerGroupListBAL();

    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();

    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        CustomerFormUI customerFormUI = new CustomerFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CustomerId"] != null)
            {
                customerFormUI.Tbl_CustomerId = Request.QueryString["CustomerId"];

                BindStatuDropDown();
                FillForm(customerFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Customer";
            }
            else
            {

                BindStatuDropDown();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Customer";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        CustomerFormUI customerFormUI = new CustomerFormUI();
        try
        {

            customerFormUI.CreatedBy = SessionContext.UserGuid;
            customerFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            customerFormUI.CustomerCode = txtCustomerCode.Text;
            customerFormUI.Name = txtName.Text;
            customerFormUI.ShortName = txtShortName.Text;
            customerFormUI.StatementName = txtStatementName.Text;
            customerFormUI.Contact = txtContact.Text;
            customerFormUI.Address = txtAddress.Text;
            customerFormUI.City = txtCity.Text;
            customerFormUI.ZipCode = txtZipCode.Text;

            customerFormUI.Tbl_CountryId = txtCountryGuid.Text;
            customerFormUI.Phone = txtPhone.Text;
            customerFormUI.Mobile = txtMobile.Text;
            customerFormUI.FaxNo = txtFaxNo.Text;
            customerFormUI.Email = txtEmail.Text;
            customerFormUI.Comment1 = txtComment1.Text;
            customerFormUI.Comment2 = txtComment2.Text;
            customerFormUI.Opt_Status = Convert.ToInt32(ddlStatus.SelectedValue);
            customerFormUI.Tbl_CustomerGroupId = txtCustomerGroupGuid.Text;

            if (chkOnHold.Checked == true)
                customerFormUI.OnHold = true;
            else
                customerFormUI.OnHold = false;


            if (customerFormBAL.AddCustomer(customerFormUI) == 1)
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
        CustomerFormUI customerFormUI = new CustomerFormUI();
        try
        {
            customerFormUI.ModifiedBy = SessionContext.UserGuid;
            customerFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            customerFormUI.Tbl_CustomerId = Request.QueryString["CustomerId"];

            customerFormUI.CustomerCode = txtCustomerCode.Text;
            customerFormUI.Name = txtName.Text;
            customerFormUI.ShortName = txtShortName.Text;
            customerFormUI.StatementName = txtStatementName.Text;
            customerFormUI.Contact = txtContact.Text;
            customerFormUI.Address = txtAddress.Text;
            customerFormUI.City = txtCity.Text;
            customerFormUI.ZipCode = txtZipCode.Text;

            customerFormUI.Tbl_CountryId = txtCountryGuid.Text;
            customerFormUI.Phone = txtPhone.Text;
            customerFormUI.Mobile = txtMobile.Text;
            customerFormUI.FaxNo = txtFaxNo.Text;
            customerFormUI.Email = txtEmail.Text;
            customerFormUI.Comment1 = txtComment1.Text;
            customerFormUI.Comment2 = txtComment2.Text;
            customerFormUI.Opt_Status = Convert.ToInt32(ddlStatus.SelectedValue);
            customerFormUI.Tbl_CustomerGroupId = txtCustomerGroupGuid.Text;

            if (chkOnHold.Checked == true)
                customerFormUI.OnHold = true;
            else
                customerFormUI.OnHold = false;

            if (customerFormBAL.UpdateCustomer(customerFormUI) == 1)
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
            logExcpUIobj.RecordId = customerFormUI.Tbl_CustomerId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : btnUpdate_Click] An error occured in the processing of Record Id : " + customerFormUI.Tbl_CustomerId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        CustomerFormUI customerFormUI = new CustomerFormUI();
        try
        {
            customerFormUI.Tbl_CustomerId = Request.QueryString["CustomerId"];

            if (customerFormBAL.DeleteCustomer(customerFormUI) == 1)
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
            logExcpUIobj.RecordId = customerFormUI.Tbl_CustomerId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : btnDelete_Click] An error occured in the processing of Record Id : " + customerFormUI.Tbl_CustomerId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerList.aspx");
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

    #region Events Customer Group Search

    protected void btnCustomerGroupSearch_Click(object sender, EventArgs e)
    {
        btnHtmlCustomerGroupSearch.Visible = false;
        btnHtmlCustomerGroupClose.Visible = true;
        SearchCustomerGroupList();
    }

    protected void btnClearCustomerGroupSearch_Click(object sender, EventArgs e)
    {
        BindCustomerGroupList();
        gvCustomerGroupSearch.Visible = true;
        btnHtmlCustomerGroupSearch.Visible = true;
        btnHtmlCustomerGroupClose.Visible = false;
        txtCustomerGroupSearch.Text = "";
        txtCustomerGroupSearch.Focus();
    }

    protected void btnCustomerGroupRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindCustomerGroupList();
    }

    #endregion Events Customer Group Search
    #endregion Events

    #region Methods
    private void FillForm(CustomerFormUI customerFormUI)
    {
        try
        {
            DataTable dtb = customerFormBAL.GetCustomerListById(customerFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtCustomerCode.Text = dtb.Rows[0]["CustomerCode"].ToString();
                txtName.Text = dtb.Rows[0]["Name"].ToString();
                txtShortName.Text = dtb.Rows[0]["ShortName"].ToString();
                txtStatementName.Text = dtb.Rows[0]["StatementName"].ToString();
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
                txtCustomerGroupGuid.Text = dtb.Rows[0]["tbl_CustomerGroupId"].ToString();
                txtCustomerGroup.Text = dtb.Rows[0]["CustomerGroupName"].ToString();

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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Customer_Supplier_Master_Creation_CustomerForm.CS";
            logExcpUIobj.RecordId = customerFormUI.Tbl_CustomerGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Customer_Supplier_Master_Creation_CustomerForm : FillForm] An error occured in the processing of Record Id : " + customerFormUI.Tbl_CustomerGroupId + ". Details : [" + exp.ToString() + "]");
        }
    }


    private void BindStatuDropDown()
    {
        OptionSetListUI optionSetListUI = new OptionSetListUI();
        optionSetListUI.TableName = "tbl_Customer";
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Customer_Supplier_Master_Creation_CustomerForm.CS";
            logExcpUIobj.RecordId = "OptionSet Name " + optionSetListUI.OptionSetName;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Customer_Supplier_Master_Creation_CustomerForm : BindStatuDropDown] An error occured in the processing of Record OptionSet Name " + optionSetListUI.OptionSetName + ".  Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Customer_Supplier_Master_Creation_CustomerForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Customer_Supplier_Master_Creation_CustomerForm : BindCountryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Customer_Supplier_Master_Creation_CustomerForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Customer_Supplier_Master_Creation_CustomerForm : SearchCountryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods Country Search


    #region Methods Customer Group Search

    public void BindCustomerGroupList()
    {
        try
        {
            DataTable dtb = customerGroupListBAL.GetCustomerGroupList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCustomerGroupSearch.DataSource = dtb;
                gvCustomerGroupSearch.DataBind();
                divCustomerGroupSearchError.Visible = false;
            }
            else
            {
                divCustomerGroupSearchError.Visible = true;
                lblCustomerGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCustomerGroupSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCustomerGroupList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Customer_Supplier_Master_Creation_CustomerForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Customer_Supplier_Master_Creation_CustomerForm : BindCustomerGroupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void SearchCustomerGroupList()
    {
        try
        {
            CustomerGroupListUI customerGroupListUI = new CustomerGroupListUI();
            customerGroupListUI.Search = txtCountrySearch.Text;

            DataTable dtb = customerGroupListBAL.GetCustomerGroupListBySearchParameters(customerGroupListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCustomerGroupSearch.DataSource = dtb;
                gvCustomerGroupSearch.DataBind();
                divCustomerGroupSearchError.Visible = false;
            }
            else
            {
                divCustomerGroupSearchError.Visible = true;
                lblCustomerGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCustomerGroupSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "CustomerGroup()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Customer_Supplier_Master_Creation_CustomerForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Customer_Supplier_Master_Creation_CustomerForm : CustomerGroup] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    #endregion Methods Customer Group Search

    #endregion Methods
}
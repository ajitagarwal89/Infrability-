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
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();

    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        CustomerFormUI customerFormUI = new CustomerFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CustomerId"] != null || Request.QueryString["recordId"] != null)
            {
                customerFormUI.Tbl_CustomerId = (Request.QueryString["CustomerId"] != null ? Request.QueryString["CustomerId"] : Request.QueryString["recordId"]);



                BindStatuDropDown();
                FillForm(customerFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnAuditHistory.Visible = true;
                lblHeading.Text = "Update Customer";
            }
            else
            {

                BindStatuDropDown();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;    
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
            customerFormUI.Tbl_GLAccountId_Cash = txtGLAccountId_CashGuid.Text.Trim(); ;
            customerFormUI.Tbl_GLAccountId_AccountReceivable = txtAccountReceivableGuid.Text.Trim();
            customerFormUI.Tbl_GLAccountId_Sales = txtCostOfSalesGuid.Text.Trim();
            customerFormUI.Tbl_GLAccountId_CostOfSales = txtCostOfSalesGuid.Text.Trim();
            customerFormUI.Tbl_GLAccountId_Inventory = txtInventoryGuid.Text.Trim();
            customerFormUI.Tbl_GLAccountId_AccuralDifferedA_C = txtAccuralDifferedA_CGuid.Text.Trim();

            if (customerFormBAL.AddCustomer(customerFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
               // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
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
            customerFormUI.Tbl_GLAccountId_Cash = txtGLAccountId_CashGuid.Text.Trim(); ;
            customerFormUI.Tbl_GLAccountId_AccountReceivable = txtAccountReceivableGuid.Text.Trim();
            customerFormUI.Tbl_GLAccountId_Sales = txtCostOfSalesGuid.Text.Trim();
            customerFormUI.Tbl_GLAccountId_CostOfSales = txtCostOfSalesGuid.Text.Trim();
            customerFormUI.Tbl_GLAccountId_Inventory = txtInventoryGuid.Text.Trim();
            customerFormUI.Tbl_GLAccountId_AccuralDifferedA_C = txtAccuralDifferedA_CGuid.Text.Trim();

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

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Finance/Accounts_Receivable/Customer_Master_Creation/CustomerForm.aspx";
        string recordId = Request.QueryString["CustomerId"];
        Response.Redirect("~/System_Settings/AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
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

    #region AccountCashSearch
    protected void btnAccountCashSearch_Click(object sender, EventArgs e)
    {
        btnHtmlGLAccountId_CashSearch.Visible = false;
        btnHtmlGLAccountId_CashClose.Visible = true;
        SearchCashList();

    }
    protected void btnClearAccountCashSearch_Click(object sender, EventArgs e)
    {
        BindCashList();
        gvGLAccountId_CashSearch.Visible = true;
        btnHtmlGLAccountId_CashSearch.Visible = true;
        btnHtmlGLAccountId_CashClose.Visible = false;
        txtGLAccountId_Cash.Text = "";
        txtGLAccountId_Cash.Focus();

    }
    protected void btnAccountCashRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindCashList();
    }
    #endregion
    #region AccountReceivableSearch
    protected void btnAccountReceivableSearch_Click(object sender, EventArgs e)
    {
        btnHtmlAccountReceivableSearch.Visible = false;
        btnHtmlAccountReceivableClose.Visible = true;
        SearchAccountReceivableList();

    }
    protected void btnClearAccountReceivableSearch_Click(object sender, EventArgs e)
    {
        BindAccountReceivable();
        gvAccountReceivableSearch.Visible = true;
        btnHtmlAccountReceivableSearch.Visible = true;
        btnHtmlAccountReceivableClose.Visible = false;
        txtAccountReceivableSearch.Text = "";
        txtAccountReceivableSearch.Focus();

    }
    protected void btnAccountReceivableRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindAccountReceivable();

    }

    protected void btnSalesSearch_Click(object sender, EventArgs e)
    {
        btnHtmlSalesSearch.Visible = false;
        btnHtmlSalesClose.Visible = true;
        SearchSalesList();
    }
    protected void btnClearSalesSearch_Click(object sender, EventArgs e)
    {
        BindSalesList();
        gvSalesSearch.Visible = true;
        btnHtmlSalesSearch.Visible = true;
        btnHtmlSalesClose.Visible = false;
        txtSalesSearch.Focus();
    }
    protected void btnSalesRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindSalesList();
    }
    protected void btnCostOfSalesSearch_Click(object sender, EventArgs e)
    {
        btnHtmlCostOfSalesSearch.Visible = false;
        btnHtmlCostOfSalesClose.Visible = true;
        SearchCostOfSalestList();
    }
    protected void btnClearCostOfSalesSearch_Click(object sender, EventArgs e)
    {
        BindCostOfSales();
        gvCostOfSalesSearch.Visible = true;
        btnHtmlCostOfSalesSearch.Visible = true;
        btnHtmlCostOfSalesClose.Visible = false;
        txtCostOfSalesSearch.Text = "";
        txtCostOfSalesSearch.Focus();
    }
    protected void btnCostOfSalesRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindCostOfSales();
    }


    protected void btnInventorySearch_Click(object sender, EventArgs e)
    {

        btnHtmlInventorySearch.Visible = false;
        btnHtmlInventoryClose.Visible = true;
        SearchInventoryList();
    }
    protected void btnClearInventorySearch_Click(object sender, EventArgs e)
    {

        BindInventoryList();
        gvInventorySearch.Visible = true;
        btnHtmlInventorySearch.Visible = true;
        btnHtmlInventoryClose.Visible = false;
        txtInventorySearch.Text = "";
        txtInventorySearch.Focus();

    }
    protected void btnInventoryRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindInventoryList();
    }

    protected void btnAccuralDifferedA_CSearch_Click(object sender, EventArgs e)
    {
        btnHtmlAccuralDifferedA_CSearch.Visible = false;
        btnHtmlAccuralDifferedA_CClose.Visible = true;
        SearchAccuralDifferedA_CList();
    }
    protected void btnClearAccuralDifferedA_CSearch_Click(object sender, EventArgs e)
    {
        BindAccuralDifferedA_CList();
        gvAccuralDifferedA_CSearch.Visible = true;
        btnHtmlAccuralDifferedA_CSearch.Visible = true;
        btnHtmlAccuralDifferedA_CClose.Visible = false;
        txtAccuralDifferedA_CSearch.Text = "";
        txtAccuralDifferedA_CSearch.Focus();

    }
    protected void btnAccuralDifferedA_CRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindAccuralDifferedA_CList();
    }


    #endregion Model popup
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
                txtGLAccountId_Cash.Text = dtb.Rows[0]["Cash"].ToString();
                txtGLAccountId_CashGuid.Text = dtb.Rows[0]["Tbl_GLAccountId_Cash"].ToString();

                txtAccountReceivable.Text = dtb.Rows[0]["AccountReceivable"].ToString();
                txtAccountReceivableGuid.Text = dtb.Rows[0]["tbl_GLAccountId_AccountReceivable"].ToString();

                txtSales.Text = dtb.Rows[0]["Sales"].ToString();
                txtSalesGuid.Text = dtb.Rows[0]["tbl_GLAccountId_Sales"].ToString();

                txtCostOfSales.Text = dtb.Rows[0]["CostOfSales"].ToString();
                txtCostOfSalesGuid.Text = dtb.Rows[0]["tbl_GLAccountId_CostOfSales"].ToString();

                txtInventory.Text = dtb.Rows[0]["Inventory"].ToString();
                txtInventoryGuid.Text = dtb.Rows[0]["tbl_GLAccountId_Inventory"].ToString();

                txtAccuralDifferedA_C.Text = dtb.Rows[0]["AccuralDifferedA_C"].ToString();
                txtAccuralDifferedA_CGuid.Text = dtb.Rows[0]["tbl_GLAccountId_AccuralDifferedA_C"].ToString();

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

    #region SearchCash
    private void SearchCashList()
    {
        try
        {
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtGLAccountId_CashSearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountId_CashSearch.DataSource = dtb;
                gvGLAccountId_CashSearch.DataBind();
                divGLAccountId_CashSearchError.Visible = false;
            }
            else
            {
                divGLAccountId_CashSearchError.Visible = true;
                lblGLAccountId_CashSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountId_CashSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchCashList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : SearchCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindCashList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountId_CashSearch.DataSource = dtb;
                gvGLAccountId_CashSearch.DataBind();
                divGLAccountId_CashSearchError.Visible = false;
            }
            else
            {
                divGLAccountId_CashSearchError.Visible = true;
                lblGLAccountId_CashSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountId_CashSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCashList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : BindCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion
    #region SearchAccountReceivable
    private void SearchAccountReceivableList()
    {
        try
        {
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtAccountReceivableSearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAccountReceivableSearch.DataSource = dtb;
                gvAccountReceivableSearch.DataBind();
                divAccountReceivableSearchError.Visible = false;

            }
            else
            {
                gvAccountReceivableSearch.Visible = true;
                lblAccountReceivableSearchError.Text = Resources.GlobalResource.msgNoRecordFound;

                gvAccountReceivableSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchAccountReceivableList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : SearchAccountPayableList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindAccountReceivable()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAccountReceivableSearch.DataSource = dtb;
                gvAccountReceivableSearch.DataBind();
                divAccountReceivableSearchError.Visible = false;
            }
            else
            {
                divAccountReceivableSearchError.Visible = true;
                lblAccountReceivableSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAccountReceivableSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindAccountReceivable()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : BindAccountReceivable] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion
    #region SearchSales
    private void SearchSalesList()
    {
        {

            try
            {
                GLAccountListUI gLAccountListUI = new GLAccountListUI();

                gLAccountListUI.Search = txtSalesSearch.Text;

                DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    gvSalesSearch.DataSource = dtb;
                    gvSalesSearch.DataBind();
                    divSalesSearchError.Visible = false;
                }
                else
                {
                    divSalesSearchError.Visible = true;
                    lblSalesSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                    gvSalesSearch.Visible = false;
                }

            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "SearchSalesList()";
                logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
                logExcpUIobj.RecordId = "All";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : SearchSalesList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
        }
    }
    private void BindSalesList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSalesSearch.DataSource = dtb;
                gvSalesSearch.DataBind();
                divSalesSearchError.Visible = false;
            }
            else
            {
                divSalesSearchError.Visible = true;
                lblSalesSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSalesSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindSalesList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : BindPurchaseList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion
    #region SearchCostOfSalest
    private void SearchCostOfSalestList()
    {
        try
        {
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtCostOfSalesSearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCostOfSalesSearch.DataSource = dtb;
                gvCostOfSalesSearch.DataBind();
                divCostOfSalesSearchError.Visible = false;
            }
            else
            {
                divCostOfSalesSearchError.Visible = true;
                lblCostOfSalesSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCostOfSalesSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchCostOfSalestList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : SearchCostOfSalestList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindCostOfSales()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCostOfSalesSearch.DataSource = dtb;
                gvCostOfSalesSearch.DataBind();
                divCostOfSalesSearchError.Visible = false;
            }
            else
            {
                divCostOfSalesSearchError.Visible = true;
                lblCostOfSalesSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCostOfSalesSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCostOfSales()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : BindCostOfSales] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion
    #region SearchInventory
    private void SearchInventoryList()
    {
        try
        {
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtInventorySearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvInventorySearch.DataSource = dtb;
                gvInventorySearch.DataBind();
                divInventorySearchError.Visible = false;
            }
            else
            {
                divInventorySearchError.Visible = true;
                lblInventorySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvInventorySearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchInventoryList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : SearchInventoryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindInventoryList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvInventorySearch.DataSource = dtb;
                gvInventorySearch.DataBind();
                divInventorySearchError.Visible = false;
            }
            else
            {
                divInventorySearchError.Visible = true;
                lblInventorySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvInventorySearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindInventoryList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : BindInventoryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion
    #region SearchAccuralDifferedA
    private void SearchAccuralDifferedA_CList()
    {
        try
        {
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtAccuralDifferedA_CSearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAccuralDifferedA_CSearch.DataSource = dtb;
                gvAccuralDifferedA_CSearch.DataBind();
                divAccuralDifferedA_CSearchError.Visible = false;
            }
            else
            {
                divAccuralDifferedA_CSearchError.Visible = true;
                lblAccuralDifferedA_CSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAccuralDifferedA_CSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchAccuralDifferedA_CList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : SearchAccuralDifferedA_CList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindAccuralDifferedA_CList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAccuralDifferedA_CSearch.DataSource = dtb;
                gvAccuralDifferedA_CSearch.DataBind();
                divAccuralDifferedA_CSearchError.Visible = false;
            }
            else
            {
                divAccuralDifferedA_CSearchError.Visible = true;
                lblAccuralDifferedA_CSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAccuralDifferedA_CSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindAccuralDifferedA_CList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : BindAccuralDifferedA_CList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion
    #endregion Methods
}
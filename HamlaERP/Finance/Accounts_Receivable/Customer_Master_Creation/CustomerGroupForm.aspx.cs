using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    CustomerGroupFormBAL customerGroupFormBAL = new CustomerGroupFormBAL();
    CustomerGroupFormUI customerGroupFormUI = new CustomerGroupFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    CustomerGroupListBAL customerGroupListBAL = new CustomerGroupListBAL();
    PaymentTermsListBAL paymentTermsListBAL = new PaymentTermsListBAL();
    PaymentTermsListUI paymentTermsListUI = new PaymentTermsListUI();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    CurrencyListUI currencyListUI = new CurrencyListUI();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        CustomerGroupFormUI customerGroupFormUI = new CustomerGroupFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CustomerGroupId"] != null)
            {
                customerGroupFormUI.Tbl_CustomerGroupId = Request.QueryString["CustomerGroupId"];

                BindBalanceTypeDropDown();
                BindMinimumPaymentDropDown();
                BindCreditLimitDropDown();
                BindWriteoffDropDown();
                BindStatementCycleDropDown();

                FillForm(customerGroupFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update CustomerGroup";
            }
            else
            {
                BindBalanceTypeDropDown();
                BindMinimumPaymentDropDown();
                BindCreditLimitDropDown();
                BindWriteoffDropDown();
                BindStatementCycleDropDown();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New CustomerGroup";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            customerGroupFormUI.CreatedBy = SessionContext.UserGuid;
            customerGroupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            if (txtCustomerGroupId_SelfGuid.Text != "")
                customerGroupFormUI.Tbl_CustomerGroupId_Self = txtCustomerGroupId_SelfGuid.Text;
            else customerGroupFormUI.Tbl_CustomerGroupId_Self = null;

            customerGroupFormUI.Description = txtDescription.Text;
            if (chckIsDefault.Checked == true)
                customerGroupFormUI.IsDefault = true;
            else
                customerGroupFormUI.CalendarYear = false;

            customerGroupFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            customerGroupFormUI.Opt_BalanceType = Convert.ToInt32(ddlOpt_BalanceType.SelectedValue);
            customerGroupFormUI.Opt_MinimumPayment = Convert.ToInt32(ddlOpt_MinimumPayment.SelectedValue);
            customerGroupFormUI.MinimumPaymentAmount = Convert.ToDecimal(txtMinimumPaymentAmount.Text);
            customerGroupFormUI.Opt_CreditLimit = Convert.ToInt32(ddlOpt_CreditLimit.SelectedValue);
            customerGroupFormUI.CreditLimitAmount = Convert.ToDecimal(txtCreditLimitAmount.Text);
            customerGroupFormUI.Opt_Writeoff = Convert.ToInt32(ddlOpt_WriteOff.SelectedValue);
            customerGroupFormUI.WriteoffAmount = Convert.ToDecimal(txtWriteOffAmount.Text);
            customerGroupFormUI.TradeDiscount = Convert.ToDecimal(txtTradeDiscount.Text);
            customerGroupFormUI.Tbl_PaymentTermsId = txtPaymentTermGuid.Text;

            if (chckCalendarYear.Checked == true)
                customerGroupFormUI.CalendarYear = true;
            else
                customerGroupFormUI.CalendarYear = false;

            if (chckFiscalYear.Checked == true)
                customerGroupFormUI.FiscalYear = true;
            else
                customerGroupFormUI.FiscalYear = false;

            if (chckTransaction.Checked == true)
                customerGroupFormUI.Transaction = true;
            else
                customerGroupFormUI.Transaction = false;

            if (chckDistribution.Checked == true)
                customerGroupFormUI.Distribution = true;
            else
                customerGroupFormUI.Distribution = false;
            customerGroupFormUI.Opt_StatementCycle = Convert.ToInt32(ddlOpt_StatementCycle.SelectedValue);


            if (customerGroupFormBAL.AddCustomerGroup(customerGroupFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_SupplierGroupForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            customerGroupFormUI.ModifiedBy = SessionContext.UserGuid;
            customerGroupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            customerGroupFormUI.Tbl_CustomerGroupId = Request.QueryString["CustomerGroupId"];

            if (txtCustomerGroupId_SelfGuid.Text != "")
                customerGroupFormUI.Tbl_CustomerGroupId_Self = txtCustomerGroupId_SelfGuid.Text;
            else customerGroupFormUI.Tbl_CustomerGroupId_Self = null;

            customerGroupFormUI.Description = txtDescription.Text;
            if (chckIsDefault.Checked == true)
                customerGroupFormUI.IsDefault = true;
            else
                customerGroupFormUI.CalendarYear = false;

            customerGroupFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            customerGroupFormUI.Opt_BalanceType = Convert.ToInt32(ddlOpt_BalanceType.SelectedValue);
            customerGroupFormUI.Opt_MinimumPayment = Convert.ToInt32(ddlOpt_MinimumPayment.SelectedValue);
            customerGroupFormUI.MinimumPaymentAmount = Convert.ToDecimal(txtMinimumPaymentAmount.Text);
            customerGroupFormUI.Opt_CreditLimit = Convert.ToInt32(ddlOpt_CreditLimit.SelectedValue);
            customerGroupFormUI.CreditLimitAmount = Convert.ToDecimal(txtCreditLimitAmount.Text);
            customerGroupFormUI.Opt_Writeoff = Convert.ToInt32(ddlOpt_WriteOff.SelectedValue);
            customerGroupFormUI.WriteoffAmount = Convert.ToDecimal(txtWriteOffAmount.Text);
            customerGroupFormUI.TradeDiscount = Convert.ToDecimal(txtTradeDiscount.Text);
            customerGroupFormUI.Tbl_PaymentTermsId = txtPaymentTermGuid.Text;

            if (chckCalendarYear.Checked == true)
                customerGroupFormUI.CalendarYear = true;
            else
                customerGroupFormUI.CalendarYear = false;

            if (chckFiscalYear.Checked == true)
                customerGroupFormUI.FiscalYear = true;
            else
                customerGroupFormUI.FiscalYear = false;

            if (chckTransaction.Checked == true)
                customerGroupFormUI.Transaction = true;
            else
                customerGroupFormUI.Transaction = false;

            if (chckDistribution.Checked == true)
                customerGroupFormUI.Distribution = true;
            else
                customerGroupFormUI.Distribution = false;
            customerGroupFormUI.Opt_StatementCycle = Convert.ToInt32(ddlOpt_StatementCycle.SelectedValue);




            if (customerGroupFormBAL.UpdateCustomerGroup(customerGroupFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
            }
            else
            {
                divSuccess.Visible = false;
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm : btnUpdate_Click] An error occured in the processing of Record Id : " + customerGroupFormUI.Tbl_CustomerGroupId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            customerGroupFormUI.Tbl_CustomerGroupId = Request.QueryString["CustomerGroupId"];

            if (customerGroupFormBAL.DeleteCustomerGroup(customerGroupFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordDeleteSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                divSuccess.Visible = false;
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotDeleteRecord;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnDelete_Click()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm.CS";
            logExcpUIobj.RecordId = customerGroupFormUI.Tbl_CustomerGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm : btnDelete_Click] An error occured in the processing of Record Id : " + customerGroupFormUI.Tbl_CustomerGroupId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerGroupList.aspx");
    }
    #endregion Events

    #region Events Customer Group
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
    #endregion

    #region Events Payments Terms
    protected void btnPaymentTermsSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPaymentTermsSearch.Visible = false;
        btnHtmlPaymentTermsClose.Visible = true;
        SearchPaymentTermsList();

    }
    protected void btnClearPaymentTermsSearch_Click(object sender, EventArgs e)
    {
        BindPaymentTermsList();
        gvPaymentTermsSearch.Visible = true;
        btnHtmlPaymentTermsSearch.Visible = true;
        btnHtmlPaymentTermsClose.Visible = false;
        txtPaymentTermsSearch.Text = "";
        txtPaymentTermsSearch.Focus();

    }
    protected void btnPaymentTermsRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPaymentTermsList();
    }
    #endregion

    #region Currency Search
    protected void btnCurrencySearch_Click(object sender, EventArgs e)
    {
        btnHtmlCurrencySearch.Visible = false;
        btnHtmlCurrencyClose.Visible = true;
        SearchCurrency();
    }
    protected void btnClearCurrencySearch_Click(object sender, EventArgs e)
    {
        BindCurrencyList();
    }
    protected void btnCurrencyRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindCurrencyList();

    }

    #endregion

    #region Methods Search and Bind

    private void SearchCustomerGroupList()
    {
        try
        {
            CustomerGroupListUI customerGroupListUI = new CustomerGroupListUI();

            customerGroupListUI.Search = txtCustomerGroupSearch.Text;

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
            logExcpUIobj.MethodName = "SearchCustomerGroupList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm : SearchCustomerGroupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindCustomerGroupList()
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm : BindCustomerGroupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }


    private void SearchPaymentTermsList()
    {
        try
        {
            PaymentTermsListBAL paymentTermsListBAL = new PaymentTermsListBAL();
            PaymentTermsListUI paymentTermsListUI = new PaymentTermsListUI();

            paymentTermsListUI.Search = txtPaymentTermsSearch.Text;

            DataTable dtb = paymentTermsListBAL.GetPaymentTermsListBySearchParameters(paymentTermsListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPaymentTermsSearch.DataSource = dtb;
                gvPaymentTermsSearch.DataBind();
                divPaymentTermsSearchError.Visible = false;
            }
            else
            {
                divPaymentTermsSearchError.Visible = true;
                lblPaymentTermsSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPaymentTermsSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchPaymentTermsList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }


    }
    private void BindPaymentTermsList()
    {
        try
        {
            DataTable dtb = paymentTermsListBAL.GetPaymentTermsList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPaymentTermsSearch.DataSource = dtb;
                gvPaymentTermsSearch.DataBind();
                divPaymentTermsSearchError.Visible = false;
            }
            else
            {
                divPaymentTermsSearchError.Visible = true;
                lblPaymentTermsSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPaymentTermsSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPaymentTermsList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm : BindPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    private void SearchCurrency()
    {
        try
        {
            CurrencyListUI currencyListUI = new CurrencyListUI();
            currencyListUI.Search = txtCurrencySearch.Text;
            DataTable dtb = currencyListBAL.GetCurrencyListBySearchParameters(currencyListUI);


            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCurrencySearch.DataSource = dtb;
                gvCurrencySearch.DataBind();
                divError.Visible = false;

            }
            else
            {
                divCurrencySearchError.Visible = true;
                lblCurrencySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCurrencySearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchCurrency()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm : SearchCurrency] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindCurrencyList()
    {
        try
        {
            DataTable dtb = currencyListBAL.GetCurrencyList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCurrencySearch.DataSource = dtb;
                gvCurrencySearch.DataBind();
                divCurrencySearchError.Visible = false;

            }
            else
            {
                divCurrencySearchError.Visible = true;
                lblCurrencySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCurrencySearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion

    #region Methods
    private void FillForm(CustomerGroupFormUI customerGroupFormUI)
    {
        try
        {
            DataTable dtb = customerGroupFormBAL.GetCustomerGroupListById(customerGroupFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtCustomerGroupId_SelfGuid.Text = dtb.Rows[0]["tbl_CustomerGroupId_Self"].ToString();
                txtCustomerGroupId_Self.Text = dtb.Rows[0]["CustomerGroupId_Self"].ToString();
                txtDescription.Text = dtb.Rows[0]["description"].ToString();
                chckIsDefault.Checked = Convert.ToBoolean(dtb.Rows[0]["IsDefault"].ToString());
                txtCurrencyGuid.Text = dtb.Rows[0]["tbl_CurrencyId"].ToString();
                txtCurrency.Text = dtb.Rows[0]["CurrencyName"].ToString();
                ddlOpt_BalanceType.SelectedValue = dtb.Rows[0]["Opt_BalanceType"].ToString();
                ddlOpt_MinimumPayment.SelectedValue = dtb.Rows[0]["Opt_MinimumPayment"].ToString();
                txtMinimumPaymentAmount.Text = dtb.Rows[0]["MinimumPaymentAmount"].ToString();
                ddlOpt_CreditLimit.SelectedValue = dtb.Rows[0]["Opt_CreditLimit"].ToString();
                txtCreditLimitAmount.Text = dtb.Rows[0]["CreditLimitAmount"].ToString();
                ddlOpt_WriteOff.SelectedValue = dtb.Rows[0]["Opt_WriteOff"].ToString();
                txtWriteOffAmount.Text = dtb.Rows[0]["WriteoffAmount"].ToString();
                txtTradeDiscount.Text = dtb.Rows[0]["TradeDiscount"].ToString();
                txtPaymentTermGuid.Text = dtb.Rows[0]["tbl_PaymentTermsId"].ToString();
                txtPaymentTerms.Text = dtb.Rows[0]["PaymentTermsName"].ToString();
                chckCalendarYear.Checked = Convert.ToBoolean(dtb.Rows[0]["CalendarYear"].ToString());
                chckFiscalYear.Checked = Convert.ToBoolean(dtb.Rows[0]["FiscalYear"].ToString());
                chckTransaction.Checked = Convert.ToBoolean(dtb.Rows[0]["Transaction"].ToString());
                chckDistribution.Checked = Convert.ToBoolean(dtb.Rows[0]["Distribution"].ToString());
                ddlOpt_StatementCycle.SelectedValue = dtb.Rows[0]["Opt_StatementCycle"].ToString();


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
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm.CS";
            logExcpUIobj.RecordId = customerGroupFormUI.Tbl_CustomerGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindMinimumPaymentDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_CustomerGroup";
            optionSetListUI.OptionSetName = "Opt_MinimumPayment";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);

            if (dtb.Rows.Count > 0)
            {
                ddlOpt_MinimumPayment.DataSource = dtb;
                ddlOpt_MinimumPayment.DataBind();
                ddlOpt_MinimumPayment.DataTextField = "OptionSetLable";
                ddlOpt_MinimumPayment.DataValueField = "OptionSetValue";
                ddlOpt_MinimumPayment.DataBind();
            }
            else
            {
                ddlOpt_MinimumPayment.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindMinimumPaymentDropDown()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm : BindMinimumPaymentDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindCreditLimitDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_CustomerGroup";
            optionSetListUI.OptionSetName = "Opt_CreditLimit";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);

            if (dtb.Rows.Count > 0)
            {
                ddlOpt_CreditLimit.DataSource = dtb;
                ddlOpt_CreditLimit.DataBind();
                ddlOpt_CreditLimit.DataTextField = "OptionSetLable";
                ddlOpt_CreditLimit.DataValueField = "OptionSetValue";
                ddlOpt_CreditLimit.DataBind();
            }
            else
            {
                ddlOpt_CreditLimit.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCreditLimitDropDown()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm : BindCreditLimitDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindWriteoffDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_CustomerGroup";
            optionSetListUI.OptionSetName = "Opt_Writeoff";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);

            if (dtb.Rows.Count > 0)
            {
                ddlOpt_WriteOff.DataSource = dtb;
                ddlOpt_WriteOff.DataBind();
                ddlOpt_WriteOff.DataTextField = "OptionSetLable";
                ddlOpt_WriteOff.DataValueField = "OptionSetValue";
                ddlOpt_WriteOff.DataBind();
            }
            else
            {
                ddlOpt_WriteOff.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindWriteOffDropDown()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm : BindWriteOfftDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindStatementCycleDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_CustomerGroup";
            optionSetListUI.OptionSetName = "Opt_StatementCycle";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);

            if (dtb.Rows.Count > 0)
            {
                ddlOpt_StatementCycle.DataSource = dtb;
                ddlOpt_StatementCycle.DataBind();
                ddlOpt_StatementCycle.DataTextField = "OptionSetLable";
                ddlOpt_StatementCycle.DataValueField = "OptionSetValue";
                ddlOpt_StatementCycle.DataBind();
            }
            else
            {
                ddlOpt_StatementCycle.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindStatementCycleDropDown()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm :  BindStatementCycleDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void BindBalanceTypeDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_CustomerGroup";
            optionSetListUI.OptionSetName = "Opt_BalanceType";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);

            if (dtb.Rows.Count > 0)
            {
                ddlOpt_BalanceType.DataSource = dtb;
                ddlOpt_BalanceType.DataBind();
                ddlOpt_BalanceType.DataTextField = "OptionSetLable";
                ddlOpt_BalanceType.DataValueField = "OptionSetValue";
                ddlOpt_BalanceType.DataBind();
            }
            else
            {
                ddlOpt_BalanceType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindBalanceTypeDropDown()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm : BindBalanceTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
}
#endregion Methods

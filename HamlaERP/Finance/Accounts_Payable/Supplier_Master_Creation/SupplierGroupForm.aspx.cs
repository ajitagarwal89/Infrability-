using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Accounts_Payable_Supplier_Master_Creation_SupplierGroupForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    SupplierGroupFormBAL supplierGroupFormBAL = new SupplierGroupFormBAL();
    SupplierGroupFormUI supplierGroupFormUI = new SupplierGroupFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    SupplierGroupListBAL supplierGroupListBAL = new SupplierGroupListBAL();
    PaymentTermsListBAL paymentTermsListBAL = new PaymentTermsListBAL();
    PaymentTermsListUI paymentTermsListUI = new PaymentTermsListUI();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    CurrencyListUI currencyListUI = new CurrencyListUI();


    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        SupplierGroupFormUI supplierGroupFormUI = new SupplierGroupFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["SupplierGroupId"] != null)
            {
                supplierGroupFormUI.Tbl_SupplierGroupId = Request.QueryString["SupplierGroupId"];

                BindMinimumPaymentDropDown();
                BindMaximunInvoiceAmountDropDown();
                BindCreditLimitDropDown();
                BindWriteoffDropDown();

                FillForm(supplierGroupFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update SupplierGroup";
            }
            else
            {

                BindMinimumPaymentDropDown();
                BindMaximunInvoiceAmountDropDown();
                BindCreditLimitDropDown();
                BindWriteoffDropDown();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New SupplierGroup";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            supplierGroupFormUI.CreatedBy = SessionContext.UserGuid;
            supplierGroupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            if (txtSupplierGroupId_SelfGuid.Text != "")
                supplierGroupFormUI.Tbl_SupplierGroupId_Self = txtSupplierGroupId_SelfGuid.Text;
            else supplierGroupFormUI.Tbl_SupplierGroupId_Self = null;

            supplierGroupFormUI.Description = txtDescription.Text;
            supplierGroupFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            supplierGroupFormUI.Tbl_PaymentTermsId = txtPaymentTermGuid.Text;
            supplierGroupFormUI.TradeDiscount = Convert.ToDecimal(txtTradeDiscount.Text);
            supplierGroupFormUI.Opt_MinimumPayment = Convert.ToInt32(ddlOpt_MinimumPayment.SelectedValue);
            supplierGroupFormUI.Opt_MaximumInvoiceAmount = Convert.ToInt32(ddlOpt_MaximumInvoiceAmount.SelectedValue);
            supplierGroupFormUI.Opt_CreditLimit = Convert.ToInt32(ddlOpt_CreditLimit.SelectedValue);
            supplierGroupFormUI.Opt_Writeoff = Convert.ToInt32(ddlOpt_WriteOff.SelectedValue);
            if (chckCalendarYear.Checked == true)
                supplierGroupFormUI.CalendarYear = true;
            else
                supplierGroupFormUI.CalendarYear = false;

            if (chckFiscalYear.Checked == true)
                supplierGroupFormUI.FiscalYear = true;
            else
                supplierGroupFormUI.FiscalYear = false;

            if (chckTransaction.Checked == true)
                supplierGroupFormUI.Transaction = true;
            else
                supplierGroupFormUI.Transaction = false;

            if (chckDistribution.Checked == true)
                supplierGroupFormUI.Distribution = true;
            else
                supplierGroupFormUI.Distribution = false;


            if (supplierGroupFormBAL.AddSupplierGroup(supplierGroupFormUI) == 1)
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
                

            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "System_Settings_SupplierGroupForm.CS";
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
            supplierGroupFormUI.ModifiedBy = SessionContext.UserGuid;
            supplierGroupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            supplierGroupFormUI.Tbl_SupplierGroupId = Request.QueryString["SupplierGroupId"];

            if (txtSupplierGroupId_SelfGuid.Text != "")
                supplierGroupFormUI.Tbl_SupplierGroupId_Self = txtSupplierGroupId_SelfGuid.Text;
            else supplierGroupFormUI.Tbl_SupplierGroupId_Self = null;

            supplierGroupFormUI.Description = txtDescription.Text;
            supplierGroupFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            supplierGroupFormUI.Tbl_PaymentTermsId = txtPaymentTermGuid.Text;
            supplierGroupFormUI.TradeDiscount = Convert.ToDecimal(txtTradeDiscount.Text);
            supplierGroupFormUI.Opt_MinimumPayment = Convert.ToInt32(ddlOpt_MinimumPayment.SelectedValue);
            supplierGroupFormUI.Opt_MaximumInvoiceAmount = Convert.ToInt32(ddlOpt_MaximumInvoiceAmount.SelectedValue);
            supplierGroupFormUI.Opt_CreditLimit = Convert.ToInt32(ddlOpt_CreditLimit.SelectedValue);
            supplierGroupFormUI.Opt_Writeoff = Convert.ToInt32(ddlOpt_WriteOff.SelectedValue);
            if (chckCalendarYear.Checked == true)
                supplierGroupFormUI.CalendarYear = true;
            else
                supplierGroupFormUI.CalendarYear = false;

            if (chckFiscalYear.Checked == true)
                supplierGroupFormUI.FiscalYear = true;
            else
                supplierGroupFormUI.FiscalYear = false;

            if (chckTransaction.Checked == true)
                supplierGroupFormUI.Transaction = true;
            else
                supplierGroupFormUI.Transaction = false;

            if (chckDistribution.Checked == true)
                supplierGroupFormUI.Distribution = true;
            else
                supplierGroupFormUI.Distribution = false;




            if (supplierGroupFormBAL.UpdateSupplierGroup(supplierGroupFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
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
            logExcpUIobj.ResourceName = "System_Settings_SupplierGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_SupplierGroupForm : btnUpdate_Click] An error occured in the processing of Record Id : " + supplierGroupFormUI.Tbl_SupplierGroupId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            supplierGroupFormUI.Tbl_SupplierGroupId = Request.QueryString["SupplierGroupId"];

            if (supplierGroupFormBAL.DeleteSupplierGroup(supplierGroupFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_SupplierGroupForm.CS";
            logExcpUIobj.RecordId = supplierGroupFormUI.Tbl_SupplierGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_SupplierGroupForm : btnDelete_Click] An error occured in the processing of Record Id : " + supplierGroupFormUI.Tbl_SupplierGroupId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("SupplierGroupList.aspx");
    }

    #endregion Events


    #region Events Supplier Group
    protected void btnSupplierGroupSearch_Click(object sender, EventArgs e)
    {
        btnHtmlSupplierGroupSearch.Visible = false;
        btnHtmlSupplierGroupClose.Visible = true;
        SearchSupplierGroupList();

    }
    protected void btnClearSupplierGroupSearch_Click(object sender, EventArgs e)
    {
        BindSupplierGroupList();
        gvSupplierGroupSearch.Visible = true;
        btnHtmlSupplierGroupSearch.Visible = true;
        btnHtmlSupplierGroupClose.Visible = false;
        txtSupplierGroupSearch.Text = "";
        txtSupplierGroupSearch.Focus();

    }
    protected void btnSupplierGroupRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindSupplierGroupList();
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

    private void SearchSupplierGroupList()
    {
        try
        {
            SupplierGroupListUI supplierGroupListUI = new SupplierGroupListUI();

            supplierGroupListUI.Search = txtSupplierGroupSearch.Text;

            DataTable dtb = supplierGroupListBAL.GetSupplierGroupListBySearchParameters(supplierGroupListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSupplierGroupSearch.DataSource = dtb;
                gvSupplierGroupSearch.DataBind();
                divSupplierGroupSearchError.Visible = false;
            }
            else
            {
                divSupplierGroupSearchError.Visible = true;
                lblSupplierGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSupplierGroupSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchSupplierGroupList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm : SearchSupplierGroupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindSupplierGroupList()
    {
        try
        {
            DataTable dtb = supplierGroupListBAL.GetSupplierGroupList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSupplierGroupSearch.DataSource = dtb;
                gvSupplierGroupSearch.DataBind();
                divSupplierGroupSearchError.Visible = false;
            }
            else
            {
                divSupplierGroupSearchError.Visible = true;
                lblSupplierGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSupplierGroupSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindSupplierGroupList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SearchSupplierGroup : BindSupplierGroupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_SupplierGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SearchSupplierGroup : BindPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "System_Settings_CurrencyList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_CurrencyList : SearchCurrency] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "System_Settings_CurrencyList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[System_Settings_CurrencyList : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion


    #region Methods
    private void FillForm(SupplierGroupFormUI supplierGroupFormUI)
    {
        try
        {
            DataTable dtb = supplierGroupFormBAL.GetSupplierGroupListById(supplierGroupFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtSupplierGroupId_SelfGuid.Text = dtb.Rows[0]["tbl_SupplierGroupId_Self"].ToString();
                txtSupplierGroupId_Self.Text = dtb.Rows[0]["SupplierGroupId_Self"].ToString();
                txtDescription.Text = dtb.Rows[0]["description"].ToString();
                txtCurrencyGuid.Text = dtb.Rows[0]["tbl_CurrencyId"].ToString();
                txtCurrency.Text = dtb.Rows[0]["CurrencyName"].ToString();
                txtPaymentTermGuid.Text = dtb.Rows[0]["tbl_PaymentTermsId"].ToString();
                txtPaymentTerms.Text = dtb.Rows[0]["PaymentTermsName"].ToString();
                txtTradeDiscount.Text = dtb.Rows[0]["TradeDiscount"].ToString();
                ddlOpt_MinimumPayment.SelectedValue = dtb.Rows[0]["Opt_MinimumPayment"].ToString();
                ddlOpt_MaximumInvoiceAmount.SelectedValue = dtb.Rows[0]["Opt_MaximumInvoiceAmount"].ToString();
                ddlOpt_CreditLimit.SelectedValue = dtb.Rows[0]["Opt_CreditLimit"].ToString();
                ddlOpt_WriteOff.SelectedValue = dtb.Rows[0]["Opt_WriteOff"].ToString();
                chckCalendarYear.Checked = Convert.ToBoolean(dtb.Rows[0]["CalendarYear"].ToString());
                chckFiscalYear.Checked = Convert.ToBoolean(dtb.Rows[0]["FiscalYear"].ToString());
                chckTransaction.Checked = Convert.ToBoolean(dtb.Rows[0]["Transaction"].ToString());
                chckDistribution.Checked = Convert.ToBoolean(dtb.Rows[0]["Distribution"].ToString());
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
            logExcpUIobj.ResourceName = "System_Settings_SupplierGroupForm.CS";
            logExcpUIobj.RecordId = supplierGroupFormUI.Tbl_SupplierGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_SupplierGroupForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindMinimumPaymentDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_SupplierGroup";
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
            logExcpUIobj.ResourceName = "System_Settings_SupplierGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_SupplierGroupForm : BindMinimumPaymentDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindMaximunInvoiceAmountDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_SupplierGroup";
            optionSetListUI.OptionSetName = "Opt_MaximumInvoiceAmount";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);

            if (dtb.Rows.Count > 0)
            {
                ddlOpt_MaximumInvoiceAmount.DataSource = dtb;
                ddlOpt_MaximumInvoiceAmount.DataBind();
                ddlOpt_MaximumInvoiceAmount.DataTextField = "OptionSetLable";
                ddlOpt_MaximumInvoiceAmount.DataValueField = "OptionSetValue";
                ddlOpt_MaximumInvoiceAmount.DataBind();
            }
            else
            {
                ddlOpt_MaximumInvoiceAmount.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindMaximunInvoiceAmountDropDown()";
            logExcpUIobj.ResourceName = "System_Settings_SupplierGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_SupplierGroupForm : BindMaximunInvoiceAmountDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindCreditLimitDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_SupplierGroup";
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
            logExcpUIobj.ResourceName = "System_Settings_SupplierGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_SupplierGroupForm : BindCreditLimitDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindWriteoffDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_SupplierGroup";
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
            logExcpUIobj.ResourceName = "System_Settings_SupplierGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_SupplierGroupForm : BindWriteOfftDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods
}
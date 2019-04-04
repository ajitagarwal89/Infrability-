using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    SupplierEmployeeGroupFormBAL SupplierEmployeeGroupFormBAL = new SupplierEmployeeGroupFormBAL();
    SupplierEmployeeGroupFormUI SupplierEmployeeGroupFormUI = new SupplierEmployeeGroupFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    SupplierEmployeeGroupListBAL SupplierEmployeeGroupListBAL = new SupplierEmployeeGroupListBAL();
    PaymentTermsListBAL paymentTermsListBAL = new PaymentTermsListBAL();
    PaymentTermsListUI paymentTermsListUI = new PaymentTermsListUI();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    CurrencyListUI currencyListUI = new CurrencyListUI();

    #endregion Data Members

    #region Events

    protected override void Page_Load(object sender, EventArgs e)
    {
        SupplierEmployeeGroupFormUI supplierEmployeeGroupFormUI = new SupplierEmployeeGroupFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["SupplierEmployeeGroupId"] != null || Request.QueryString["recordId"] != null)
            {
                supplierEmployeeGroupFormUI.Tbl_SupplierEmployeeGroupId = (Request.QueryString["SupplierEmployeeGroupId"] != null ? Request.QueryString["SupplierEmployeeGroupId"] : Request.QueryString["recordId"]);


                BindMinimumPaymentDropDown();
                BindMaximunInvoiceAmountDropDown();
                BindCreditLimitDropDown();
                BindWriteoffDropDown();

                FillForm(supplierEmployeeGroupFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnAuditHistory.Visible = false;    
                lblHeading.Text = "Update SupplierEmployeeGroup";
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
                lblHeading.Text = "Add New SupplierEmployeeGroup";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            SupplierEmployeeGroupFormUI.CreatedBy = SessionContext.UserGuid;
            SupplierEmployeeGroupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            if (txtSupplierEmployeeGroupId_SelfGuid.Text != "")
                SupplierEmployeeGroupFormUI.Tbl_SupplierEmployeeGroupId_Self = txtSupplierEmployeeGroupId_SelfGuid.Text;
            else
                SupplierEmployeeGroupFormUI.Tbl_SupplierEmployeeGroupId_Self = "00000000-0000-0000-0000-000000000001";

            SupplierEmployeeGroupFormUI.Description = txtDescription.Text;
            SupplierEmployeeGroupFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            SupplierEmployeeGroupFormUI.Tbl_PaymentTermsId = txtPaymentTermGuid.Text;
            SupplierEmployeeGroupFormUI.TradeDiscount = Convert.ToDecimal(txtTradeDiscount.Text);
            SupplierEmployeeGroupFormUI.Opt_MinimumPayment = Convert.ToInt32(ddlOpt_MinimumPayment.SelectedValue);
            SupplierEmployeeGroupFormUI.Opt_MaximumInvoiceAmount = Convert.ToInt32(ddlOpt_MaximumInvoiceAmount.SelectedValue);
            SupplierEmployeeGroupFormUI.Opt_CreditLimit = Convert.ToInt32(ddlOpt_CreditLimit.SelectedValue);
            SupplierEmployeeGroupFormUI.Opt_Writeoff = Convert.ToInt32(ddlOpt_WriteOff.SelectedValue);
            if (chckCalendarYear.Checked == true)
                SupplierEmployeeGroupFormUI.CalendarYear = true;
            else
                SupplierEmployeeGroupFormUI.CalendarYear = false;

            if (chckFiscalYear.Checked == true)
                SupplierEmployeeGroupFormUI.FiscalYear = true;
            else
                SupplierEmployeeGroupFormUI.FiscalYear = false;

            if (chckTransaction.Checked == true)
                SupplierEmployeeGroupFormUI.Transaction = true;
            else
                SupplierEmployeeGroupFormUI.Transaction = false;

            if (chckDistribution.Checked == true)
                SupplierEmployeeGroupFormUI.Distribution = true;
            else
                SupplierEmployeeGroupFormUI.Distribution = false;


            if (SupplierEmployeeGroupFormBAL.AddSupplierEmployeeGroup(SupplierEmployeeGroupFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            SupplierEmployeeGroupFormUI.ModifiedBy = SessionContext.UserGuid;
            SupplierEmployeeGroupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            SupplierEmployeeGroupFormUI.Tbl_SupplierEmployeeGroupId = Request.QueryString["SupplierEmployeeGroupId"];

            if (txtSupplierEmployeeGroupId_SelfGuid.Text != "")
                SupplierEmployeeGroupFormUI.Tbl_SupplierEmployeeGroupId_Self = txtSupplierEmployeeGroupId_SelfGuid.Text;
            else SupplierEmployeeGroupFormUI.Tbl_SupplierEmployeeGroupId_Self = null;

            SupplierEmployeeGroupFormUI.Description = txtDescription.Text;
            SupplierEmployeeGroupFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            SupplierEmployeeGroupFormUI.Tbl_PaymentTermsId = txtPaymentTermGuid.Text;
            SupplierEmployeeGroupFormUI.TradeDiscount = Convert.ToDecimal(txtTradeDiscount.Text);
            SupplierEmployeeGroupFormUI.Opt_MinimumPayment = Convert.ToInt32(ddlOpt_MinimumPayment.SelectedValue);
            SupplierEmployeeGroupFormUI.Opt_MaximumInvoiceAmount = Convert.ToInt32(ddlOpt_MaximumInvoiceAmount.SelectedValue);
            SupplierEmployeeGroupFormUI.Opt_CreditLimit = Convert.ToInt32(ddlOpt_CreditLimit.SelectedValue);
            SupplierEmployeeGroupFormUI.Opt_Writeoff = Convert.ToInt32(ddlOpt_WriteOff.SelectedValue);
            if (chckCalendarYear.Checked == true)
                SupplierEmployeeGroupFormUI.CalendarYear = true;
            else
                SupplierEmployeeGroupFormUI.CalendarYear = false;

            if (chckFiscalYear.Checked == true)
                SupplierEmployeeGroupFormUI.FiscalYear = true;
            else
                SupplierEmployeeGroupFormUI.FiscalYear = false;

            if (chckTransaction.Checked == true)
                SupplierEmployeeGroupFormUI.Transaction = true;
            else
                SupplierEmployeeGroupFormUI.Transaction = false;

            if (chckDistribution.Checked == true)
                SupplierEmployeeGroupFormUI.Distribution = true;
            else
                SupplierEmployeeGroupFormUI.Distribution = false;




            if (SupplierEmployeeGroupFormBAL.UpdateSupplierEmployeeGroup(SupplierEmployeeGroupFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm : btnUpdate_Click] An error occured in the processing of Record Id : " + SupplierEmployeeGroupFormUI.Tbl_SupplierEmployeeGroupId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            SupplierEmployeeGroupFormUI.Tbl_SupplierEmployeeGroupId = Request.QueryString["SupplierEmployeeGroupId"];

            if (SupplierEmployeeGroupFormBAL.DeleteSupplierEmployeeGroup(SupplierEmployeeGroupFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm.CS";
            logExcpUIobj.RecordId = SupplierEmployeeGroupFormUI.Tbl_SupplierEmployeeGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm : btnDelete_Click] An error occured in the processing of Record Id : " + SupplierEmployeeGroupFormUI.Tbl_SupplierEmployeeGroupId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("SupplierEmployeeGroupList.aspx");
    }


    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Finance/Accounts_Payable/Supplier_Master_Creation/SupplierEmployeeGroupForm.aspx";
        string recordId = Request.QueryString["SupplierEmployeeGroupId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    #endregion

    #region Events Employee Group
    protected void btnSupplierEmployeeGroupSearch_Click(object sender, EventArgs e)
    {
        btnHtmlSupplierEmployeeGroupSearch.Visible = false;
        btnHtmlSupplierEmployeeGroupClose.Visible = true;
        SearchSupplierEmployeeGroupList();

    }
    protected void btnClearSupplierEmployeeGroupSearch_Click(object sender, EventArgs e)
    {
        BindSupplierEmployeeGroupList();
        gvSupplierEmployeeGroupSearch.Visible = true;
        btnHtmlSupplierEmployeeGroupSearch.Visible = true;
        btnHtmlSupplierEmployeeGroupClose.Visible = false;
        txtSupplierEmployeeGroupSearch.Text = "";
        txtSupplierEmployeeGroupSearch.Focus();

    }
    protected void btnSupplierEmployeeGroupRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindSupplierEmployeeGroupList();
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

    #region Events Currency Search
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

    private void SearchSupplierEmployeeGroupList()
    {
        try
        {
            SupplierEmployeeGroupListUI SupplierEmployeeGroupListUI = new SupplierEmployeeGroupListUI();

            SupplierEmployeeGroupListUI.Search = txtSupplierEmployeeGroupSearch.Text;

            DataTable dtb = SupplierEmployeeGroupListBAL.GetSupplierEmployeeGroupListBySearchParameters(SupplierEmployeeGroupListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSupplierEmployeeGroupSearch.DataSource = dtb;
                gvSupplierEmployeeGroupSearch.DataBind();
                divSupplierEmployeeGroupSearchError.Visible = false;
            }
            else
            {
                divSupplierEmployeeGroupSearchError.Visible = true;
                lblSupplierEmployeeGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSupplierEmployeeGroupSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchSupplierEmployeeGroupList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm : SearchSupplierGroupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindSupplierEmployeeGroupList()
    {
        try
        {
            DataTable dtb = SupplierEmployeeGroupListBAL.GetSupplierEmployeeGroupList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSupplierEmployeeGroupSearch.DataSource = dtb;
                gvSupplierEmployeeGroupSearch.DataBind();
                divSupplierEmployeeGroupSearchError.Visible = false;
            }
            else
            {
                divSupplierEmployeeGroupSearchError.Visible = true;
                lblSupplierEmployeeGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSupplierEmployeeGroupSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindSupplierEmployeeGroupList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm : BindSupplierEmployeeGroupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm : BindPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm : SearchCurrency] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[System_Settings_CurrencyList : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion

    #region Methods
    private void FillForm(SupplierEmployeeGroupFormUI SupplierEmployeeGroupFormUI)
    {
        try
        {
            DataTable dtb = SupplierEmployeeGroupFormBAL.GetSupplierEmployeeGroupListById(SupplierEmployeeGroupFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtSupplierEmployeeGroupId_SelfGuid.Text = dtb.Rows[0]["tbl_SupplierEmployeeGroupId_Self"].ToString();
                txtSupplierEmployeeGroupId_Self.Text = dtb.Rows[0]["SupplierEmployeeGroupId_Self"].ToString();
                txtDescription.Text = dtb.Rows[0]["description"].ToString();
                txtCurrencyGuid.Text = dtb.Rows[0]["tbl_CurrencyId"].ToString();
                txtCurrency.Text = dtb.Rows[0]["CurrencyName"].ToString();
                txtPaymentTermGuid.Text = dtb.Rows[0]["tbl_PaymentTermsId"].ToString();
                txtPaymentTerms.Text = dtb.Rows[0]["PaymentTermsName"].ToString();
                txtTradeDiscount.Text = dtb.Rows[0]["TradeDiscount"].ToString();
                ddlOpt_MinimumPayment.SelectedValue = dtb.Rows[0]["Opt_MinimumPayment"].ToString();
                ddlOpt_MaximumInvoiceAmount.SelectedValue = dtb.Rows[0]["Opt_MaximumInvoiceAmount"].ToString();
                ddlOpt_CreditLimit.SelectedValue = dtb.Rows[0]["Opt_CreditLimit"].ToString();
                ddlOpt_WriteOff.SelectedValue = dtb.Rows[0]["Opt_Writeoff"].ToString();
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm.CS";
            logExcpUIobj.RecordId = SupplierEmployeeGroupFormUI.Tbl_SupplierEmployeeGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindMinimumPaymentDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_SupplierEmployeeGroup";
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm : BindMinimumPaymentDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindMaximunInvoiceAmountDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_SupplierEmployeeGroup";
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm : BindMaximunInvoiceAmountDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindCreditLimitDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_SupplierEmployeeGroup";
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm : BindCreditLimitDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindWriteoffDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_SupplierEmployeeGroup";
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeGroupForm : BindWriteOfftDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods
}
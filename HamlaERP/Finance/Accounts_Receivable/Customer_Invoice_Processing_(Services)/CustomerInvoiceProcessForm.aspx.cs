using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Accounts_Receivable_Customer_Invoice_Processing__Services_CustomerInvoiceProcessForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    PayablesListBAL payablesListBAL = new PayablesListBAL();
    BatchListBAL batchListBAL = new BatchListBAL();
    BatchListUI batchListUI = new BatchListUI();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    CurrencyListUI currencyListUI = new CurrencyListUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    CustomerListBAL customerListBAL = new CustomerListBAL();

    CustomerInvoiceProcessFormBAL customerInvoiceProcessFormBAL = new CustomerInvoiceProcessFormBAL();
    CustomerInvoiceProcessFormUI customerInvoiceProcessFormUI = new CustomerInvoiceProcessFormUI();

    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        CustomerInvoiceProcessFormUI customerInvoiceProcessFormUI = new CustomerInvoiceProcessFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CustomerInvoiceProcessId"] != null)
            {
                customerInvoiceProcessFormUI.Tbl_CustomerInvoiceProcessId = Request.QueryString["CustomerInvoiceProcessId"];

                BindDocumentTypeDropDownList();
                FillForm(customerInvoiceProcessFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Customer Invoice Process";
            }
            else
            {

                BindDocumentTypeDropDownList();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Customer InvoiceProcess";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            customerInvoiceProcessFormUI.CreatedBy = SessionContext.UserGuid;
            customerInvoiceProcessFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            customerInvoiceProcessFormUI.Opt_DocumentType = Convert.ToByte(ddlOpt_DocumentType.SelectedValue);
            customerInvoiceProcessFormUI.Tbl_BatchId = txtBatchGuid.Text.Trim().ToString();
            customerInvoiceProcessFormUI.DocumentNumber=txtDocumentNumber.Text.Trim().ToString();
            customerInvoiceProcessFormUI.DocumentDate = DateTime.Parse(txtDocumentDate.Text.ToString());
            customerInvoiceProcessFormUI.Description = txtDescription.Text.ToString();
            customerInvoiceProcessFormUI.PostingDate = DateTime.Parse(txtPostingDate.Text.ToString());
            customerInvoiceProcessFormUI.InvoiceDate= DateTime.Parse(txtInvoiceDate.Text.ToString());
            customerInvoiceProcessFormUI.InvoiceIssueDate= DateTime.Parse(txtInvoiceIssueDate.Text.ToString());
            customerInvoiceProcessFormUI.Tbl_CustomerId = txtCustomerGuid.Text.Trim().ToString();
            customerInvoiceProcessFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text.Trim().ToString();
            customerInvoiceProcessFormUI.Tbl_PaymentTermsId = txtPaymentTermseGuid.Text.ToString();
            customerInvoiceProcessFormUI.PONumber = txtPONumber.Text.ToString();
            customerInvoiceProcessFormUI.Cost = Convert.ToDecimal(txtCost.Text);
            customerInvoiceProcessFormUI.Sales = Convert.ToDecimal(txtSales.Text);
            customerInvoiceProcessFormUI.TradeDiscount= Convert.ToDecimal(txtTradeDiscount.Text);
            customerInvoiceProcessFormUI.Freight= Convert.ToDecimal(txtFreight.Text);
            customerInvoiceProcessFormUI.Total = Convert.ToDecimal(txtTotal.Text);
            customerInvoiceProcessFormUI.Tbl_PayablesId_BankTransfer = txtPayablesBankGuid.Text.Trim().ToString();
            customerInvoiceProcessFormUI.BankTransferAmount = Convert.ToDecimal(txtBankTransferAmount.Text);
            customerInvoiceProcessFormUI.Tbl_PayablesId_Cash= txtPayablesCashGuid.Text.Trim().ToString();
            customerInvoiceProcessFormUI.CashAmount = Convert.ToDecimal(txtCash.Text);
            customerInvoiceProcessFormUI.Tbl_PayablesId_Cheque=txtPayablesChequeGuid.Text.Trim().ToString();
            customerInvoiceProcessFormUI.ChequeAmount = Convert.ToDecimal(txtCheque.Text);
            customerInvoiceProcessFormUI.Tbl_PayablesId_CreditCard = txtPayablesCreditCardGuid.Text.Trim().ToString();
            customerInvoiceProcessFormUI.CreditCardAmount = Convert.ToDecimal(txtCreditCard.Text);
            customerInvoiceProcessFormUI.OnAccount = Convert.ToDecimal(txtOnAccount.Text);

            if (customerInvoiceProcessFormBAL.AddCustomerInvoiceProcess(customerInvoiceProcessFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Invoice_Processing__Services_CustomerInvoiceProcessForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Invoice_Processing__Services_CustomerInvoiceProcessForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            customerInvoiceProcessFormUI.ModifiedBy = SessionContext.UserGuid;
            customerInvoiceProcessFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            customerInvoiceProcessFormUI.Tbl_CustomerInvoiceProcessId = Request.QueryString["CustomerInvoiceProcessId"];
            customerInvoiceProcessFormUI.Opt_DocumentType = Convert.ToByte(ddlOpt_DocumentType.SelectedValue);
            customerInvoiceProcessFormUI.Tbl_BatchId = txtBatchGuid.Text.Trim().ToString();
            customerInvoiceProcessFormUI.DocumentNumber = txtDocumentNumber.Text.Trim().ToString();
            customerInvoiceProcessFormUI.DocumentDate = DateTime.Parse(txtDocumentDate.Text.ToString());
            customerInvoiceProcessFormUI.Description = txtDescription.Text.ToString();
            customerInvoiceProcessFormUI.PostingDate = DateTime.Parse(txtPostingDate.Text.ToString());
            customerInvoiceProcessFormUI.InvoiceDate = DateTime.Parse(txtInvoiceDate.Text.ToString());
            customerInvoiceProcessFormUI.InvoiceIssueDate = DateTime.Parse(txtInvoiceIssueDate.Text.ToString());
            customerInvoiceProcessFormUI.Tbl_CustomerId = txtCustomerGuid.Text.Trim().ToString();
            customerInvoiceProcessFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text.Trim().ToString();
            customerInvoiceProcessFormUI.Tbl_PaymentTermsId = txtPaymentTermseGuid.Text.ToString();
            customerInvoiceProcessFormUI.PONumber = txtPONumber.Text.ToString();
            customerInvoiceProcessFormUI.Cost = Convert.ToDecimal(txtCost.Text);
            customerInvoiceProcessFormUI.Sales = Convert.ToDecimal(txtSales.Text);
            customerInvoiceProcessFormUI.TradeDiscount = Convert.ToDecimal(txtTradeDiscount.Text);
            customerInvoiceProcessFormUI.Freight = Convert.ToDecimal(txtFreight.Text);
            customerInvoiceProcessFormUI.Total = Convert.ToDecimal(txtTotal.Text);
            customerInvoiceProcessFormUI.Tbl_PayablesId_BankTransfer = txtPayablesBankGuid.Text.Trim().ToString();
            customerInvoiceProcessFormUI.BankTransferAmount = Convert.ToDecimal(txtBankTransferAmount.Text);
            customerInvoiceProcessFormUI.Tbl_PayablesId_Cash = txtPayablesCashGuid.Text.Trim().ToString();
            customerInvoiceProcessFormUI.CashAmount = Convert.ToDecimal(txtCash.Text);
            customerInvoiceProcessFormUI.Tbl_PayablesId_Cheque = txtPayablesChequeGuid.Text.Trim().ToString();
            customerInvoiceProcessFormUI.ChequeAmount = Convert.ToDecimal(txtCheque.Text);
            customerInvoiceProcessFormUI.Tbl_PayablesId_CreditCard = txtPayablesCreditCardGuid.Text.Trim().ToString();
            customerInvoiceProcessFormUI.CreditCardAmount = Convert.ToDecimal(txtCreditCard.Text);
            customerInvoiceProcessFormUI.OnAccount = Convert.ToDecimal(txtOnAccount.Text);
            if (customerInvoiceProcessFormBAL.UpdateCustomerInvoiceProcess(customerInvoiceProcessFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Invoice_Processing__Services_CustomerInvoiceProcessForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Invoice_Processing__Services_CustomerInvoiceProcessForm : btnUpdate_Click] An error occured in the processing of Record Id : " + customerInvoiceProcessFormUI.Tbl_CustomerInvoiceProcessId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            customerInvoiceProcessFormUI.Tbl_CustomerInvoiceProcessId = Request.QueryString["CustomerInvoiceProcessId"];

            if (customerInvoiceProcessFormBAL.DeleteCustomerInvoiceProcess(customerInvoiceProcessFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = customerInvoiceProcessFormUI.Tbl_CustomerInvoiceProcessId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Invoice_Processing__Services_CustomerInvoiceProcessForm : btnDelete_Click] An error occured in the processing of Record Id : " + customerInvoiceProcessFormUI.Tbl_CustomerInvoiceProcessId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerInvoiceProcessList.aspx");
    }

    #region Search and populate mondal popup value
    #region BatchSearch
    protected void btnBatchSearch_Click(object sender, EventArgs e)
    {
        btnHtmlBatchSearch.Visible = false;
        btnHtmlBatchClose.Visible = true;
        SearchBatchList();
    }
    protected void btnClearBatchSearch_Click(object sender, EventArgs e)
    {
        BindBatchList();
        gvBatchSearch.Visible = true;
        btnHtmlBatchSearch.Visible = true;
        btnHtmlBatchClose.Visible = false;
        txtBatchSearch.Text = "";
        txtBatchSearch.Focus();
    }
    protected void btnBatchRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindBatchList();
    }
    #endregion
    #region PaymentTermsSearch
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
    #region CurrencySearch
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
    #region PayablesBankSearch
    protected void btnPayablesBankSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPayablesBankSearch.Visible = false;
        btnHtmlPayablesBankClose.Visible = true;
        SearchPayablesBankList();
    }
    protected void btnClearPayablesBankSearch_Click(object sender, EventArgs e)
    {
        BindPayablesBankList();
        gvPayablesBankSearch.Visible = true;
        btnHtmlPayablesBankSearch.Visible = true;
        btnHtmlPayablesBankClose.Visible = false;
        txtPayablesBankSearch.Text = "";
        txtPayablesBankSearch.Focus();
    }
    protected void btnPayablesBankRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPayablesBankList();
    }
    #endregion
    #region PayablesCashSearch
    protected void btnPayablesCashSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPayablesCashSearch.Visible = false;
        btnHtmlPayablesCashClose.Visible = true;
        SearchPayablesCashList();
    }
    protected void btnClearPayablesCashSearch_Click(object sender, EventArgs e)
    {
        BindPayablesCashList();
        gvPayablesCashSearch.Visible = true;
        btnHtmlPayablesCashSearch.Visible = true;
        btnHtmlPayablesCashClose.Visible = false;
        txtPayablesCashSearch.Text = "";
        txtPayablesCashSearch.Focus();
    }
    protected void btnPayablesCashRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPayablesCashList();
    }
    #endregion
    #region PayablesChequeSearch 
    protected void btnPayablesChequeSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPayablesChequeSearch.Visible = false;
        btnHtmlPayablesChequeClose.Visible = true;
        SearchPayablesChequeList();
    }
    protected void btnClearPayablesChequeSearch_Click(object sender, EventArgs e)
    {
        BindPayablesChequeList();
        gvPayablesChequeSearch.Visible = true;
        btnHtmlPayablesChequeSearch.Visible = true;
        btnHtmlPayablesChequeClose.Visible = false;
        txtPayablesChequeSearch.Text = "";
        txtPayablesChequeSearch.Focus();
    }
    protected void btnPayablesChequeRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPayablesChequeList();
    }
    #endregion
    #region PayablesCreditCardSearch
    protected void btnPayablesCreditCardSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPayablesCreditCardSearch.Visible = false;
        btnHtmlPayablesCreditCardClose.Visible = true;
        SearchPayablesCreditCardList();
    }
    protected void btnClearPayablesCreditCardSearch_Click(object sender, EventArgs e)
    {
        BindPayablesCreditCardList();
        gvPayablesCreditCardSearch.Visible = true;
        btnHtmlPayablesCreditCardSearch.Visible = true;
        btnHtmlPayablesCreditCardClose.Visible = false;
        txtPayablesCreditCardSearch.Text = "";
        txtPayablesCreditCardSearch.Focus();
    }
    protected void btnPayablesCreditCardRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPayablesCreditCardList();
    }
    #endregion
    #region CustomerSearch
    protected void btnCustomerSearch_Click(object sender, EventArgs e)
    {
        btnHtmlCustomerSearch.Visible = false;
        btnHtmlCustomerClose.Visible = true;
        SearchCustomerList();
    }
    protected void btnClearCustomerSearch_Click(object sender, EventArgs e)
    {
        BindCustomerList();
        gvCustomerSearch.Visible = true;
        btnHtmlCustomerSearch.Visible = true;
        btnHtmlCustomerClose.Visible = false;
        txtCustomerSearch.Text = "";
        txtCustomerSearch.Focus();
    }
    protected void btnCustomerRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindBatchList();
    }
    #endregion
    #endregion
    #endregion Events    

    #region Methods

    #region Bind drop down List
    private void BindDocumentTypeDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_NonPOBasedInvoice";
            optionSetListUI.OptionSetName = "Opt_DocumentType";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlOpt_DocumentType.DataSource = dtb;
                ddlOpt_DocumentType.DataBind();
                ddlOpt_DocumentType.DataTextField = "OptionSetLable";
                ddlOpt_DocumentType.DataValueField = "OptionSetValue";
                ddlOpt_DocumentType.DataBind();
            }
            else
            {
                ddlOpt_DocumentType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindDocumentTypeDropDownList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm : BindDocumentTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion
    private void FillForm(CustomerInvoiceProcessFormUI customerInvoiceProcessFormUI)
    {
        try
        {
            DataTable dtb = customerInvoiceProcessFormBAL.GetCustomerInvoiceProcessListById(customerInvoiceProcessFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtBatchGuid.Text = dtb.Rows[0]["tbl_BatchId"].ToString();
                txtBatch.Text = dtb.Rows[0]["BatchName"].ToString();
                txtDocumentNumber.Text = dtb.Rows[0]["DocumentNumber"].ToString();
                txtDocumentDate.Text= dtb.Rows[0]["DocumentDate"].ToString();
                txtDescription.Text= dtb.Rows[0]["Description"].ToString();
                txtPostingDate.Text=dtb.Rows[0]["PostingDate"].ToString();
                txtInvoiceDate.Text= dtb.Rows[0]["InvoiceDate"].ToString();
                txtInvoiceIssueDate.Text= dtb.Rows[0]["InvoiceIssueDate"].ToString();
                txtCustomerGuid.Text= dtb.Rows[0]["tbl_CustomerId"].ToString();
                txtCustomer.Text = dtb.Rows[0]["CustomerName"].ToString();
                txtCurrencyGuid.Text= dtb.Rows[0]["tbl_CurrencyId"].ToString();
                txtCurrency.Text= dtb.Rows[0]["CurrencyName"].ToString();
                txtPaymentTermseGuid.Text= dtb.Rows[0]["tbl_PaymentTermsId"].ToString();
                txtPaymentTerms.Text = dtb.Rows[0]["PaymentTermsName"].ToString();
                txtPONumber.Text= dtb.Rows[0]["PONumber"].ToString();
                txtCost.Text= dtb.Rows[0]["Cost"].ToString();
                txtSales.Text =  dtb.Rows[0]["Sales"].ToString();
                txtTradeDiscount.Text= dtb.Rows[0]["TradeDiscount"].ToString();
                txtFreight.Text= dtb.Rows[0]["Freight"].ToString();
                txtTotal.Text = dtb.Rows[0]["Total"].ToString();
                txtPayablesBankGuid.Text= dtb.Rows[0]["tbl_PayablesId_BankTransfer"].ToString();
                txtPayablesBank.Text = dtb.Rows[0]["PaymentNumberBank"].ToString();
                txtBankTransferAmount.Text = dtb.Rows[0]["BankTransferAmount"].ToString();
                txtPayablesCashGuid.Text = dtb.Rows[0]["tbl_PayablesId_Cash"].ToString();
                txtPayablesCash.Text = dtb.Rows[0]["PayablesTypeCash"].ToString();
                txtCash.Text = dtb.Rows[0]["CashAmount"].ToString();
                txtCheque.Text= dtb.Rows[0]["ChequeAmount"].ToString();
                txtPayablesChequeGuid.Text= dtb.Rows[0]["tbl_PayablesId_Cheque"].ToString();
                txtPayablesCheque.Text = dtb.Rows[0]["PayablesTypeCheque"].ToString();
                txtPayablesCreditCardGuid.Text= dtb.Rows[0]["tbl_PayablesId_CreditCard"].ToString();
                txtPayablesCreditCard.Text = dtb.Rows[0]["PayablesTypeCard"].ToString();
                txtCheque.Text= dtb.Rows[0]["ChequeAmount"].ToString();
                txtCreditCard.Text= dtb.Rows[0]["CreditCardAmount"].ToString();
                txtOnAccount.Text= dtb.Rows[0]["OnAccount"].ToString();

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
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Invoice_Processing__Services_CustomerInvoiceProcessForm.CS";
            logExcpUIobj.RecordId = customerInvoiceProcessFormUI.Tbl_CustomerInvoiceProcessId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Invoice_Processing__Services_CustomerInvoiceProcessForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void BindCustomerList()
    {
        try
        {
            DataTable dtb = customerListBAL.GetCustomerList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCustomerSearch.DataSource = dtb;
                gvCustomerSearch.DataBind();
                divCustomerSearchError.Visible = false;

            }
            else
            {
                divCustomerSearchError.Visible = true;
                lblCustomerSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCustomerSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCustomerList()";
            logExcpUIobj.ResourceName = "System_Settings_CurrencyList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_CurrencyList : BindCustomerList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void SearchCustomerList()
    {
        try
        {
            CustomerListUI customerListUI = new CustomerListUI();
            customerListUI.Search = txtCustomerSearch.Text;
            DataTable dtb = customerListBAL.GetCustomerListBySearchParameters(customerListUI);


            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCustomerSearch.DataSource = dtb;
                gvCustomerSearch.DataBind();
                divCustomerSearchError.Visible = false;

            }
            else
            {
                divCustomerSearchError.Visible = true;
                lblCustomerSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCustomerSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchCustomer()";
            logExcpUIobj.ResourceName = "System_Settings_CurrencyList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_CurrencyList : SearchCustomer] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void SearchBatchList()
    {
        try
        {
            BatchListUI batchListUI = new BatchListUI();
            batchListUI.Search = txtBatchSearch.Text;


            DataTable dtb = batchListBAL.GetBatchListBySearchParameters(batchListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvBatchSearch.DataSource = dtb;
                gvBatchSearch.DataBind();
                divBatchSearchError.Visible = false;
            }
            else
            {
                divBatchSearchError.Visible = true;
                lblBatchSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvBatchSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchBatchList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm : SearchBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindBatchList()
    {
        try
        {
            DataTable dtb = batchListBAL.GetBatchList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvBatchSearch.DataSource = dtb;
                gvBatchSearch.DataBind();
                divBatchSearchError.Visible = false;

            }
            else
            {
                divBatchSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvBatchSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindBatchList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm : BindBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void SearchPaymentTermsList()
    {
        try
        {
            PaymentTermsListBAL paymentTermsListBAL = new PaymentTermsListBAL();
            PaymentTermsListUI PaymentTermsListUI = new PaymentTermsListUI();

            batchListUI.Search = txtPaymentTermsSearch.Text;


            DataTable dtb = paymentTermsListBAL.GetPaymentTermsListBySearchParameters(PaymentTermsListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPaymentTermsSearch.DataSource = dtb;
                gvPaymentTermsSearch.DataBind();
                divPaymentTermsSearchError.Visible = false;
            }
            else
            {
                divPaymentTermsSearchError.Visible = true;
                lblPaymentTermsSearchSucces.Text = Resources.GlobalResource.msgNoRecordFound;
                gvBatchSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchPaymentTermsList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindPaymentTermsList()
    {
        try
        {
            PaymentTermsListBAL paymentTermsListBAL = new PaymentTermsListBAL();
            PaymentTermsListUI PaymentTermsListUI = new PaymentTermsListUI();
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
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPaymentTermsSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPaymentTermsList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm : BindPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
    private void SearchPayablesBankList()
    {
        try
        {
            PayablesListUI payablesListUI = new PayablesListUI();
            payablesListUI.Search = txtPayablesBankSearch.Text;
            DataTable dtb = payablesListBAL.GetPayablesListBySearchParameters(payablesListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPayablesBankSearch.DataSource = dtb;
                gvPayablesBankSearch.DataBind();
                divPayablesBankSearchError.Visible = false;
            }
            else
            {
                divPayablesBankSearchError.Visible = true;
                lblPayablesBankSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPayablesBankSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchPayablesBankList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : SearchPayablesBankList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindPayablesBankList()
    {
        int payabletype = 1;
        int processtype = 1;
        PayablesListUI payablesListUI = new PayablesListUI();

        try
        {
            payablesListUI.Opt_PayablesType = payabletype;
            payablesListUI.Opt_ProcessType = processtype;
            DataTable dtb = payablesListBAL.GetPayablesListByPayablesAndProcessType(payablesListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPayablesBankSearch.DataSource = dtb;
                gvPayablesBankSearch.DataBind();
                divPayablesBankSearchError.Visible = false;

            }
            else
            {
                divBatchSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvBatchSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPayablesBankList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : BindPayablesBankList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void SearchPayablesCashList()
    {
        try
        {
            PayablesListUI payablesListUI = new PayablesListUI();
            payablesListUI.Search = txtPayablesCashSearch.Text;


            DataTable dtb = payablesListBAL.GetPayablesListBySearchParameters(payablesListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPayablesCashSearch.DataSource = dtb;
                gvPayablesCashSearch.DataBind();
                divPayablesCashSearchError.Visible = false;
            }
            else
            {
                divPayablesCashSearchError.Visible = true;
                lblPayablesCashSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPayablesCashSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchPayablesCashList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : SearchPayablesCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindPayablesCashList()
    {
        int payabletype = 3;
        int processtype = 1;
        PayablesListUI payablesListUI = new PayablesListUI();

        try
        {
            payablesListUI.Opt_PayablesType = payabletype;
            payablesListUI.Opt_ProcessType = processtype;
            DataTable dtb = payablesListBAL.GetPayablesListByPayablesAndProcessType(payablesListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPayablesCashSearch.DataSource = dtb;
                gvPayablesCashSearch.DataBind();
                divPayablesCashSearchError.Visible = false;

            }
            else
            {
                divPayablesCashSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPayablesCashSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPayablesCashList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : BindPayablesCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void SearchPayablesChequeList()
    {
        try
        {
            PayablesListUI payablesListUI = new PayablesListUI();
            payablesListUI.Search = txtPayablesChequeSearch.Text;


            DataTable dtb = payablesListBAL.GetPayablesListBySearchParameters(payablesListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPayablesChequeSearch.DataSource = dtb;
                gvPayablesChequeSearch.DataBind();
                divPayablesChequeSearchError.Visible = false;
            }
            else
            {
                divPayablesChequeSearchError.Visible = true;
                lblPayablesChequeSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPayablesChequeSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchPayablesChequeList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : SearchPayablesChequeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindPayablesChequeList()
    {
        int payablestype = 2;
        int processtype = 1;
        PayablesListUI payablesListUI = new PayablesListUI();

        try
        {
            payablesListUI.Opt_PayablesType = payablestype;
            payablesListUI.Opt_ProcessType = processtype;
            DataTable dtb = payablesListBAL.GetPayablesListByPayablesAndProcessType(payablesListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPayablesChequeSearch.DataSource = dtb;
                gvPayablesChequeSearch.DataBind();
                divPayablesChequeSearchError.Visible = false;

            }
            else
            {
                divPayablesChequeSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPayablesChequeSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPayablesChequeList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : BindPayablesChequeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void SearchPayablesCreditCardList()
    {
        try
        {
            PayablesListUI payablesListUI = new PayablesListUI();

            payablesListUI.Search = txtPayablesCreditCard.Text;


            DataTable dtb = payablesListBAL.GetPayablesListBySearchParameters(payablesListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPayablesCreditCardSearch.DataSource = dtb;
                gvPayablesCreditCardSearch.DataBind();
                divPayablesCreditCardSearchError.Visible = false;
            }
            else
            {
                divBatchSearchError.Visible = true;
                lblBatchSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvBatchSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchPayablesCreditCardList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : SearchPayablesCreditCardList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindPayablesCreditCardList()
    {
        int payablestype = 4;
        int processtype = 1;
        PayablesListUI payablesListUI = new PayablesListUI();

        try
        {
            payablesListUI.Opt_PayablesType = payablestype;
            payablesListUI.Opt_ProcessType = processtype;
            DataTable dtb = payablesListBAL.GetPayablesListByPayablesAndProcessType(payablesListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPayablesCreditCardSearch.DataSource = dtb;
                gvPayablesCreditCardSearch.DataBind();
                divPayablesCreditCardSearchError.Visible = false;

            }
            else
            {
                divPayablesCreditCardSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPayablesCreditCardSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPayablesCreditCardList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : BindPayablesCreditCardList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
  
    #endregion Methods
}
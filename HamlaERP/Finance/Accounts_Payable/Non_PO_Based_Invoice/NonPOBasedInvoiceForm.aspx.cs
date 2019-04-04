using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : PageBase
{
    #region Data Members

    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    NonPOBasedInvoiceFormBAL nonPOBasedInvoiceFormBAL = new NonPOBasedInvoiceFormBAL();
    NonPOBasedInvoiceFormUI nonPOBasedInvoiceFormUI = new NonPOBasedInvoiceFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    BatchListBAL batchListBAL = new BatchListBAL();
    SupplierListBAL supplierListBAL = new SupplierListBAL();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    PaymentTermsListBAL paymentTermsListBAL = new PaymentTermsListBAL();
    PayablesListBAL payablesListBAL = new PayablesListBAL();

    DateTime fiscalPeriodStartDate = SessionContext.FiscalPeriodStartDate;
    DateTime fiscalPeriodEndDate = SessionContext.FiscalPeriodEndDate;

    int invoiceTypeInvoice = 1;
    int invoiceTypeReturn = 2;
    int invoiceTypeCreditMemo = 3;
    int invoiceTypePayment = 4;

    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        NonPOBasedInvoiceFormUI nonPOBasedInvoiceFormUI = new NonPOBasedInvoiceFormUI();
        if (!Page.IsPostBack)
        {
            BindDocumentTypeDropDownList();
            if (Request.QueryString["NonPOBasedInvoiceId"] != null || Request.QueryString["recordId"] != null)
            {
                nonPOBasedInvoiceFormUI.Tbl_NonPOBasedInvoiceId = (Request.QueryString["NonPOBasedInvoiceId"] != null ? Request.QueryString["NonPOBasedInvoiceId"] : Request.QueryString["recordId"]);

                BindDocumentTypeDropDownList();
                BindPayablesTypeDropDownList();
                FillForm(nonPOBasedInvoiceFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnPost.Visible = true;
                btnAuditHistory.Visible = true;
                lblHeading.Text = "Update Non PO Based Invoice";
            }
            else
            {

                nonPOBasedInvoiceFormUI.InvoiceType = invoiceTypeInvoice;
                GetSerialNumber(nonPOBasedInvoiceFormUI);
                BindPayablesTypeDropDownList();
                BindDocumentTypeDropDownList();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                btnPost.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New Non PO Based Invoice";
            }
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int payablesType = Convert.ToInt32(ddlOpt_PayablesType.SelectedValue);
            int bank = (int)Enums.CommonEnum.Payabletype.BankTransfer;
            int Cheque = (int)Enums.CommonEnum.Payabletype.Cheque;
            int Cash = (int)Enums.CommonEnum.Payabletype.Cash;
            int card = (int)Enums.CommonEnum.Payabletype.CreditCard;
            nonPOBasedInvoiceFormUI.CreatedBy = SessionContext.UserGuid;
            nonPOBasedInvoiceFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            nonPOBasedInvoiceFormUI.Tbl_BatchId = txtBatchGuid.Text;
            nonPOBasedInvoiceFormUI.Tbl_SupplierId = txtSupplierGuid.Text;
            nonPOBasedInvoiceFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            nonPOBasedInvoiceFormUI.Tbl_PaymentTermsId = txtPaymentTermsGuid.Text;
            if (chkInterCompany.Checked)
            {
                nonPOBasedInvoiceFormUI.InterCompany = true;
            }
            else
            {
                nonPOBasedInvoiceFormUI.InterCompany = false;
            }
            nonPOBasedInvoiceFormUI.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text);
            nonPOBasedInvoiceFormUI.VoucherNumber = txtVoucherNumber.Text;
            nonPOBasedInvoiceFormUI.Opt_DocumentType = int.Parse(ddlOpt_DocumentType.SelectedValue.ToString());
            nonPOBasedInvoiceFormUI.DocumentDate = Convert.ToDateTime(txtDocumentDate.Text);
            nonPOBasedInvoiceFormUI.Description = txtDescription.Text;
            nonPOBasedInvoiceFormUI.PostingDate = Convert.ToDateTime(txtPostingDate.Text);
            nonPOBasedInvoiceFormUI.ReceivedDate = Convert.ToDateTime(txtReceivedDate.Text);
            nonPOBasedInvoiceFormUI.DocumentNumber = txtDocumentNumber.Text;
            nonPOBasedInvoiceFormUI.PONumber = txtPONumber.Text;
            nonPOBasedInvoiceFormUI.Purchase = Convert.ToDecimal(txtPurchase.Text);
            nonPOBasedInvoiceFormUI.TradeDiscount = Convert.ToDecimal(txtTradeDiscount.Text);
            nonPOBasedInvoiceFormUI.Freight = Convert.ToDecimal(txtFreight.Text);
            nonPOBasedInvoiceFormUI.Total = Convert.ToDecimal(txtTotal.Text);
            nonPOBasedInvoiceFormUI.Opt_PayablesType = int.Parse(ddlOpt_PayablesType.SelectedValue.ToString());
            if (payablesType == bank)
            {
                nonPOBasedInvoiceFormUI.Tbl_PayablesId_BankTransfer = txtPayablesBankGuid.Text;
                nonPOBasedInvoiceFormUI.BankTransferAmount = Convert.ToDecimal(txtBankTransferAmount.Text);
            }
            else
            {
                nonPOBasedInvoiceFormUI.Tbl_PayablesId_BankTransfer = null;
                nonPOBasedInvoiceFormUI.BankTransferAmount = 0;
            }

            if (payablesType == Cash)
            {
                nonPOBasedInvoiceFormUI.Tbl_PayablesId_Cash = txtPayablesCashGuid.Text;
                nonPOBasedInvoiceFormUI.CashAmount = Convert.ToDecimal(txtCashAmount.Text);
            }
            else
            {
                nonPOBasedInvoiceFormUI.Tbl_PayablesId_Cash = null;
                nonPOBasedInvoiceFormUI.CashAmount = 0;
            }
            if (payablesType == Cheque)
            {
                nonPOBasedInvoiceFormUI.Tbl_PayablesId_Cheque = txtPayablesChequeGuid.Text;
                nonPOBasedInvoiceFormUI.ChequeAmount = Convert.ToDecimal(txtChequeAmount.Text);
            }

            else
            {
                nonPOBasedInvoiceFormUI.Tbl_PayablesId_Cheque = null;
                nonPOBasedInvoiceFormUI.ChequeAmount = 0;
            }
            if (payablesType == card)
            {
                nonPOBasedInvoiceFormUI.Tbl_PayablesId_CreditCard = txtPayablesCreditCardGuid.Text;
                nonPOBasedInvoiceFormUI.CreditCardAmount = Convert.ToDecimal(txtCreditCardAmount.Text);
            }
            else
            {
                nonPOBasedInvoiceFormUI.Tbl_PayablesId_CreditCard = null;
                nonPOBasedInvoiceFormUI.CreditCardAmount = 0;
            }


            nonPOBasedInvoiceFormUI.OnAccount = Convert.ToDecimal(txtOnAccount.Text);

            if (nonPOBasedInvoiceFormBAL.AddNonPOBasedInvoice(nonPOBasedInvoiceFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        NonPOBasedInvoiceFormUI nonPOBasedInvoiceFormUI = new NonPOBasedInvoiceFormUI();
        try
        {
            int payablesType = Convert.ToInt32(ddlOpt_PayablesType.SelectedValue);
            int bank = (int)Enums.CommonEnum.Payabletype.BankTransfer;
            int Cheque = (int)Enums.CommonEnum.Payabletype.Cheque;
            int Cash = (int)Enums.CommonEnum.Payabletype.Cash;
            int card = (int)Enums.CommonEnum.Payabletype.CreditCard;
            nonPOBasedInvoiceFormUI.CreatedBy = SessionContext.UserGuid;
            nonPOBasedInvoiceFormUI.ModifiedBy = SessionContext.UserGuid;
            nonPOBasedInvoiceFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            nonPOBasedInvoiceFormUI.Tbl_NonPOBasedInvoiceId = Request.QueryString["NonPOBasedInvoiceId"];
            nonPOBasedInvoiceFormUI.Tbl_BatchId = txtBatchGuid.Text;
            nonPOBasedInvoiceFormUI.Tbl_SupplierId = txtSupplierGuid.Text;
            nonPOBasedInvoiceFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            nonPOBasedInvoiceFormUI.Tbl_PaymentTermsId = txtPaymentTermsGuid.Text;
            if (chkInterCompany.Checked)
            {
                nonPOBasedInvoiceFormUI.InterCompany = true;
            }
            else
            {
                nonPOBasedInvoiceFormUI.InterCompany = false;
            }
            nonPOBasedInvoiceFormUI.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text);
            nonPOBasedInvoiceFormUI.VoucherNumber = txtVoucherNumber.Text;
            nonPOBasedInvoiceFormUI.Opt_DocumentType = int.Parse(ddlOpt_DocumentType.SelectedValue.ToString());
            nonPOBasedInvoiceFormUI.DocumentDate = Convert.ToDateTime(txtDocumentDate.Text);
            nonPOBasedInvoiceFormUI.Description = txtDescription.Text;
            nonPOBasedInvoiceFormUI.PostingDate = Convert.ToDateTime(txtPostingDate.Text);
            nonPOBasedInvoiceFormUI.ReceivedDate = Convert.ToDateTime(txtReceivedDate.Text);
            nonPOBasedInvoiceFormUI.DocumentNumber = txtDocumentNumber.Text;
            nonPOBasedInvoiceFormUI.PONumber = txtPONumber.Text;
            nonPOBasedInvoiceFormUI.Purchase = Convert.ToDecimal(txtPurchase.Text);
            nonPOBasedInvoiceFormUI.TradeDiscount = Convert.ToDecimal(txtTradeDiscount.Text);
            nonPOBasedInvoiceFormUI.Freight = Convert.ToDecimal(txtFreight.Text);
            nonPOBasedInvoiceFormUI.Total = Convert.ToDecimal(txtTotal.Text);
            nonPOBasedInvoiceFormUI.Opt_PayablesType = int.Parse(ddlOpt_PayablesType.SelectedValue.ToString());
            if (payablesType == bank)
            {
                nonPOBasedInvoiceFormUI.Tbl_PayablesId_BankTransfer = txtPayablesBankGuid.Text;
                nonPOBasedInvoiceFormUI.BankTransferAmount = Convert.ToDecimal(txtBankTransferAmount.Text);
            }
            else
            {
                nonPOBasedInvoiceFormUI.Tbl_PayablesId_BankTransfer = null;
                nonPOBasedInvoiceFormUI.BankTransferAmount = 0;
            }

            if (payablesType == Cash)
            {
                nonPOBasedInvoiceFormUI.Tbl_PayablesId_Cash = txtPayablesCashGuid.Text;
                nonPOBasedInvoiceFormUI.CashAmount = Convert.ToDecimal(txtCashAmount.Text);
            }
            else
            {
                nonPOBasedInvoiceFormUI.Tbl_PayablesId_Cash = null;
                nonPOBasedInvoiceFormUI.CashAmount = 0;
            }
            if (payablesType == Cheque)
            {
                nonPOBasedInvoiceFormUI.Tbl_PayablesId_Cheque = txtPayablesChequeGuid.Text;
                nonPOBasedInvoiceFormUI.ChequeAmount = Convert.ToDecimal(txtChequeAmount.Text);
            }

            else
            {
                nonPOBasedInvoiceFormUI.Tbl_PayablesId_Cheque = null;
                nonPOBasedInvoiceFormUI.ChequeAmount = 0;
            }
            if (payablesType == card)
            {
                nonPOBasedInvoiceFormUI.Tbl_PayablesId_CreditCard = txtPayablesCreditCardGuid.Text;
                nonPOBasedInvoiceFormUI.CreditCardAmount = Convert.ToDecimal(txtCreditCardAmount.Text);
            }
            else
            {
                nonPOBasedInvoiceFormUI.Tbl_PayablesId_CreditCard = null;
                nonPOBasedInvoiceFormUI.CreditCardAmount = 0;
            }


            nonPOBasedInvoiceFormUI.OnAccount = Convert.ToDecimal(txtOnAccount.Text);
            if (nonPOBasedInvoiceFormBAL.UpdateNonPOBasedInvoice(nonPOBasedInvoiceFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : btnUpdate_Click] An error occured in the processing of Record Id : " + nonPOBasedInvoiceFormUI.Tbl_NonPOBasedInvoiceId + ".  Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            nonPOBasedInvoiceFormUI.Tbl_NonPOBasedInvoiceId = Request.QueryString["NonPOBasedInvoiceId"];
            if (nonPOBasedInvoiceFormBAL.DeleteNonPOBasedInvoice(nonPOBasedInvoiceFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = nonPOBasedInvoiceFormUI.Tbl_NonPOBasedInvoiceId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : btnDelete_Click] An error occured in the processing of Record Id : " + nonPOBasedInvoiceFormUI.Tbl_NonPOBasedInvoiceId + ". Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("NonPOBasedInvoiceList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Finance/Accounts_Payable/Non_PO_Based_Invoice/NonPOBasedInvoiceForm.aspx";
        string recordId = Request.QueryString["NonPOBasedInvoiceId"];
        Response.Redirect("~/System_Settings/AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    protected void btnPost_Click(object sender, EventArgs e)
    {
        try
        {
            bool isPosted = true;
            nonPOBasedInvoiceFormUI.ModifiedBy = SessionContext.UserGuid;
            nonPOBasedInvoiceFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            nonPOBasedInvoiceFormUI.Tbl_NonPOBasedInvoiceId = Request.QueryString["NonPOBasedInvoiceId"];
            nonPOBasedInvoiceFormUI.IsPosted = isPosted;

            if (nonPOBasedInvoiceFormBAL.UpdatePostingNonPOBasedInvoice(nonPOBasedInvoiceFormUI) == 1)
            {
                divSuccess.Visible = true;
                lblSuccess.Text = Resources.GlobalResource.msgRecordPostedSuccessfully;
                btnPost.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotPostRecord;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnPost_Click()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = nonPOBasedInvoiceFormUI.Tbl_NonPOBasedInvoiceId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : btnPost_Click] An error occured in the processing of Record Id : " + nonPOBasedInvoiceFormUI.Tbl_NonPOBasedInvoiceId + ".  Details : [" + exp.ToString() + "]");
        }
    }

        #region Batch Search
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
    #endregion Batch Search

    #region Supplier Search
    protected void btnSupplierSearch_Click(object sender, EventArgs e)
    {
        btnHtmlSupplierSearch.Visible = false;
        btnHtmlSupplierClose.Visible = true;
        SearchSupplierList();
    }
    protected void btnClearSupplierSearch_Click(object sender, EventArgs e)
    {
        BindSupplierList();
        gvSupplierSearch.Visible = true;
        btnHtmlSupplierSearch.Visible = true;
        btnHtmlSupplierClose.Visible = false;
        txtSupplierSearch.Text = "";
        txtSupplierSearch.Focus();
    }
    protected void btnSupplierRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindSupplierList();
    }
    #endregion Supplier Search

    #region Currency Search
    protected void btnCurrencySearch_Click(object sender, EventArgs e)
    {
        btnHtmlCurrencySearch.Visible = false;
        btnHtmlCurrencyClose.Visible = true;
        SearchCurrencyList();
    }
    protected void btnClearCurrencySearch_Click(object sender, EventArgs e)
    {
        BindCurrencyList();
        gvCurrencySearch.Visible = true;
        btnHtmlCurrencySearch.Visible = true;
        btnHtmlCurrencyClose.Visible = false;
        txtCurrencySearch.Text = "";
        txtCurrencySearch.Focus();
    }
    protected void btnCurrencyRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindCurrencyList();
    }
    #endregion Currency Search

    #region Payment Terms Search
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
    #endregion Payment Terms Search

    #region PayablesBank Search
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
    #endregion PayablesBank Search

    #region Payables Cash Search
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
    #endregion Payables Cash Search

    #region Payables Cheque Search
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
    #endregion Payables Cheque Search

    #region Payables Credit Card Search
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
    #endregion Payables Credit Card Search

    protected void ddlOpt_PayablesType_Load(object sender, EventArgs e)
    {
        int payablesType = Convert.ToInt32(ddlOpt_PayablesType.SelectedValue);
        int bank = (int)Enums.CommonEnum.Payabletype.BankTransfer;
        int Cheque = (int)Enums.CommonEnum.Payabletype.Cheque;
        int card = (int)Enums.CommonEnum.Payabletype.CreditCard;
        int cash = (int)Enums.CommonEnum.Payabletype.Cash;

        divBank.Visible = false;
        divCreditCard.Visible = false;
        divCheque.Visible = false;
        divCash.Visible = false;

        if (payablesType == bank)
        {
            divBank.Visible = true;
            divCreditCard.Visible = false;
            divCheque.Visible = false;
            divCash.Visible = false;
        }
        else if (payablesType == Cheque)
        {
            divCheque.Visible = true;
            divBank.Visible = false;
            divCreditCard.Visible = false;
            divCash.Visible = false;
        }
        else if (payablesType == card)
        {
            divCheque.Visible = false;
            divBank.Visible = false;
            divCreditCard.Visible = true;
            divCash.Visible = false;
        }
        else
        {
            divCheque.Visible = false;
            divBank.Visible = false;
            divCreditCard.Visible = false;
            divCash.Visible = true;

        }
    }

    protected void txtInvoiceDate_TextChanged(object sender, EventArgs e)
    {
        if (txtInvoiceDate.Text != "")
        {
            DateTime invoiceDate = Convert.ToDateTime(txtInvoiceDate.Text.ToString());

            if (invoiceDate < fiscalPeriodStartDate && invoiceDate > fiscalPeriodEndDate)
            {
                txtInvoiceDate.Text = "";
                txtInvoiceDate.Focus();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                "err_msg", "alert('Invoice Date can not be greater the Financial closing Date!)');", true);
            }
        }
    }
    #endregion Events

    #region  Methods

    private void BindPayablesTypeDropDownList()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_NonPOBasedInvoice";
            optionSetListUI.OptionSetName = "Opt_PayablesType";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlOpt_PayablesType.DataSource = dtb;

                ddlOpt_PayablesType.DataTextField = "OptionSetLable";
                ddlOpt_PayablesType.DataValueField = "OptionSetValue";

                ddlOpt_PayablesType.DataBind();

                ddlOpt_PayablesType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlOpt_PayablesType.SelectedIndex = 0;
            }
            else
            {
                ddlOpt_PayablesType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPayablesTypeDropDownList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : BindPayablesTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void GetSerialNumber(NonPOBasedInvoiceFormUI nonPOBasedInvoiceFormUI)
    {
        try
        {
            DataTable dtb = nonPOBasedInvoiceFormBAL.GetSerialNumber(nonPOBasedInvoiceFormUI);
            if (dtb.Rows.Count > 0)
            {
                txtVoucherNumber.Text = dtb.Rows[0][0].ToString();

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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = nonPOBasedInvoiceFormUI.Tbl_NonPOBasedInvoiceId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : GetSerialNumber] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : BindDocumentTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void FillForm(NonPOBasedInvoiceFormUI nonPOBasedInvoiceFormUI)
    {
        try
        {
            DataTable dtb = nonPOBasedInvoiceFormBAL.GetNonPOBasedInvoiceListById(nonPOBasedInvoiceFormUI);
            if (dtb.Rows.Count > 0)
            {
                txtBatchGuid.Text = dtb.Rows[0]["tbl_BatchId"].ToString();
                txtBatch.Text = dtb.Rows[0]["BatchName"].ToString();
                txtCurrencyGuid.Text = dtb.Rows[0]["tbl_CurrencyId"].ToString();
                txtCurrency.Text = dtb.Rows[0]["CurrencyName"].ToString();
                txtPayablesBankGuid.Text = dtb.Rows[0]["tbl_PayablesId_BankTransfer"].ToString();
                txtPayablesBank.Text = dtb.Rows[0]["BankName"].ToString();
                txtPayablesCashGuid.Text = dtb.Rows[0]["tbl_PayablesId_Cash"].ToString();
                txtPayablesCash.Text = dtb.Rows[0]["PayablesTypeCash"].ToString();
                txtPayablesChequeGuid.Text = dtb.Rows[0]["tbl_PayablesId_Cheque"].ToString();
                txtPayablesCheque.Text = dtb.Rows[0]["PayablesTypeCheque"].ToString();
                txtSupplierGuid.Text = dtb.Rows[0]["tbl_SupplierId"].ToString();
                txtSupplier.Text = dtb.Rows[0]["SupplierName"].ToString();
                txtPayablesCreditCardGuid.Text = dtb.Rows[0]["tbl_PayablesId_CreditCard"].ToString();
                txtPayablesCreditCard.Text = dtb.Rows[0]["CardName"].ToString();
                txtPaymentTermsGuid.Text = dtb.Rows[0]["tbl_PaymentTermsId"].ToString();
                txtPaymentTerms.Text = dtb.Rows[0]["PaymentTermsName"].ToString();
                chkInterCompany.Checked = Convert.ToBoolean(dtb.Rows[0]["InterCompany"].ToString());
                txtInvoiceDate.Text = dtb.Rows[0]["InvoiceDate"].ToString();
                txtVoucherNumber.Text = dtb.Rows[0]["VoucherNumber"].ToString();
                ddlOpt_DocumentType.SelectedValue = dtb.Rows[0]["Opt_DocumentType"].ToString();
                ddlOpt_PayablesType.SelectedValue = dtb.Rows[0]["Opt_PayablesType"].ToString();
                txtDocumentDate.Text = dtb.Rows[0]["DocumentDate"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                txtPostingDate.Text = dtb.Rows[0]["PostingDate"].ToString();
                txtReceivedDate.Text = dtb.Rows[0]["ReceivedDate"].ToString();
                txtDocumentNumber.Text = dtb.Rows[0]["DocumentNumber"].ToString();
                txtPONumber.Text = dtb.Rows[0]["PONumber"].ToString();
                txtPurchase.Text = dtb.Rows[0]["Purchase"].ToString();
                txtTradeDiscount.Text = dtb.Rows[0]["TradeDiscount"].ToString();
                txtFreight.Text = dtb.Rows[0]["Freight"].ToString();
                txtTotal.Text = dtb.Rows[0]["Total"].ToString();
                txtBankTransferAmount.Text = dtb.Rows[0]["BankTransferAmount"].ToString();
                txtCashAmount.Text = dtb.Rows[0]["CashAmount"].ToString();
                txtChequeAmount.Text = dtb.Rows[0]["ChequeAmount"].ToString();
                txtCreditCardAmount.Text = dtb.Rows[0]["CreditCardAmount"].ToString();
                txtOnAccount.Text = dtb.Rows[0]["OnAccount"].ToString();
                bool isPosted = Convert.ToBoolean(dtb.Rows[0]["IsPosted"]);

                if (isPosted == true)
                {
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnPost.Enabled = false;
                }
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = nonPOBasedInvoiceFormUI.Tbl_NonPOBasedInvoiceId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region Batch Search
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : SearchBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : BindBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  BatchSerach

    #region Supplier Search
    private void SearchSupplierList()
    {
        try
        {
            SupplierListUI supplierListUI = new SupplierListUI();
            supplierListUI.Search = txtSupplierSearch.Text;
            DataTable dtb = supplierListBAL.GetSupplierListBySearchParameters(supplierListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSupplierSearch.DataSource = dtb;
                gvSupplierSearch.DataBind();
                divSupplierSearchError.Visible = false;
            }
            else
            {
                divSupplierSearchError.Visible = true;
                lblSupplierSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSupplierSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchSupplierList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : SearchSupplierList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindSupplierList()
    {
        try
        {
            DataTable dtb = supplierListBAL.GetSupplierList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSupplierSearch.DataSource = dtb;
                gvSupplierSearch.DataBind();
                divSupplierSearchError.Visible = false;
            }
            else
            {
                divSupplierSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSupplierSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindSupplierList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : BindSupplierList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Supplier Serach

    #region Currency Search
    private void SearchCurrencyList()
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
            logExcpUIobj.MethodName = "SearchCurrencyList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : SearchCurrencyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCurrencySearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCurrencyList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : BindCurrencyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Currency Serach

    #region Payment Terms Search
    private void SearchPaymentTermsList()
    {
        try
        {
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPaymentTermsSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPaymentTermsList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : BindPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Payment Terms Serach

    #region PayablesBank Search
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
    #endregion  PayablesBank Serach

    #region Payables Cash Search
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
    #endregion  Payables Cash Serach

    #region Payables Cheque Search
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
    #endregion Payables Cheque Serach

    #region Payables Credit Card Search
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
    #endregion  Payables Credit Card Serach

    #endregion Methods   
}
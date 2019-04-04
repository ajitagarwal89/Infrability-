using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm :PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    DownPaymentToSupplierFormBAL downPaymentToSupplierFormBAL = new DownPaymentToSupplierFormBAL();
    DownPaymentToSupplierFormUI downPaymentToSupplierFormUI = new DownPaymentToSupplierFormUI();
    SourceDocumentListBAL sourceDocumentListBAL = new SourceDocumentListBAL();
    BatchListBAL batchListBAL = new BatchListBAL();
    SupplierListBAL supplierListBAL = new SupplierListBAL();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    PayablesListBAL payablesListBAL = new PayablesListBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();

    DateTime fiscalPeriodStartDate = SessionContext.FiscalPeriodStartDate;
    DateTime fiscalPeriodEndDate = SessionContext.FiscalPeriodEndDate;


    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        DownPaymentToSupplierFormUI downPaymentToSupplierFormUI = new DownPaymentToSupplierFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["DownPaymentToSupplierId"] != null || Request.QueryString["recordId"] != null)
            {
                downPaymentToSupplierFormUI.Tbl_DownPaymentToSupplierId = (Request.QueryString["DownPaymentToSupplierId"] != null ? Request.QueryString["DownPaymentToSupplierId"] : Request.QueryString["recordId"]);

                BindPayablesTypeDropDownList();
                BindDocumentTypeDropDownList();
                FillForm(downPaymentToSupplierFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnApply.Visible = true;
                btnDistribution.Visible = true;
                btnPost.Visible = true;
                btnAuditHistory.Visible = true;
                txtPaymentDate.ReadOnly = true;
                lblHeading.Text = "Update Down Payment To Supplier";
            }
            else
            {
                
                GetSerialNumber();
                BindPayablesTypeDropDownList();
                BindDocumentTypeDropDownList();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnApply.Visible = false;
                btnDistribution.Visible = false;
                btnPost.Visible = false;
                btnAuditHistory.Visible = false;

                lblHeading.Text = "Add New Down Payment To Supplier";
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int payablesType = Convert.ToInt32(ddlOpt_PayablesType.SelectedValue);
            int bank = (int)Enums.CommonEnum.Payabletype.BankTransfer;
            int cheque = (int)Enums.CommonEnum.Payabletype.Cheque;
            int card = (int)Enums.CommonEnum.Payabletype.CreditCard;
            int cash = (int)Enums.CommonEnum.Payabletype.Cash;

            downPaymentToSupplierFormUI.CreatedBy = SessionContext.UserGuid;
            downPaymentToSupplierFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            downPaymentToSupplierFormUI.Tbl_BatchId = txtBatchGuid.Text;
            downPaymentToSupplierFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            if (chkIsAutoAppliyTo.Checked)
            {
                downPaymentToSupplierFormUI.IsAutoAppliyTo = true;
            }
            else
            {
                downPaymentToSupplierFormUI.IsAutoAppliyTo = false;
            }
           
            downPaymentToSupplierFormUI.Opt_PayablesType = int.Parse(ddlOpt_PayablesType.SelectedValue.ToString());
            downPaymentToSupplierFormUI.Tbl_SupplierId = txtSupplierGuid.Text;
            if (payablesType == bank)
            {
                downPaymentToSupplierFormUI.Tbl_PayablesId_BankTransfer = txtPayablesBankGuid.Text;
                downPaymentToSupplierFormUI.BankTransferAmount = Convert.ToDecimal(txtBankTransferAmount.Text);
            }
            else {
                downPaymentToSupplierFormUI.Tbl_PayablesId_BankTransfer = null;
                downPaymentToSupplierFormUI.BankTransferAmount = 0;
            }
            if (payablesType == cash)
            {

                downPaymentToSupplierFormUI.Tbl_PayablesId_Cash = txtPayablesCashGuid.Text;
                downPaymentToSupplierFormUI.CashAmount = Convert.ToDecimal(txtCashAmount.Text);
            }
            else {

                downPaymentToSupplierFormUI.Tbl_PayablesId_Cash = null; 
                downPaymentToSupplierFormUI.CashAmount = 0;
            }
            if (payablesType == cheque)
            {
                downPaymentToSupplierFormUI.Tbl_PayablesId_Cheque = txtPayablesChequeGuid.Text;
                downPaymentToSupplierFormUI.ChequeAmount = Convert.ToDecimal(txtChequeAmount.Text);
            }
            else
            {
                downPaymentToSupplierFormUI.Tbl_PayablesId_Cheque = null;
                downPaymentToSupplierFormUI.ChequeAmount = 0;
            }


            if (payablesType == card)
            {

                downPaymentToSupplierFormUI.Tbl_PayablesId_CreditCard = txtPayablesCreditCardGuid.Text;
                downPaymentToSupplierFormUI.CreditCardAmount = Convert.ToDecimal(txtCreditCardAmount.Text);
            }
            else
            {
                downPaymentToSupplierFormUI.Tbl_PayablesId_CreditCard = null;
                downPaymentToSupplierFormUI.CreditCardAmount = 0;

            }

            downPaymentToSupplierFormUI.Tbl_SourceDocumentId = txtSourceDocumentGuid.Text;
            downPaymentToSupplierFormUI.PaymentNumber = txtPaymentNumber.Text;
            downPaymentToSupplierFormUI.PaymentDate = DateTime.Parse(txtPaymentDate.Text.ToString());




            downPaymentToSupplierFormUI.DocumentNumber = txtDocumentNumber.Text;
          
            downPaymentToSupplierFormUI.Comments = txtComments.Text;
            downPaymentToSupplierFormUI.Unapplied = Decimal.Parse(txtUnapplied.Text.ToString());
            downPaymentToSupplierFormUI.Applied = Decimal.Parse(txtApplied.Text.ToString());
            downPaymentToSupplierFormUI.Total = Convert.ToDecimal(txtTotal.Text);


            downPaymentToSupplierFormUI.ApplyDate = DateTime.Parse(txtApplyDate.Text.ToString());
            downPaymentToSupplierFormUI.opt_DocumentType = int.Parse(ddlOpt_DocumentType.SelectedValue.ToString());
            if (downPaymentToSupplierFormBAL.AddDownPaymentToSupplier(downPaymentToSupplierFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DownPaymentToSupplierFormUI downPaymentToSupplierFormUI = new DownPaymentToSupplierFormUI();
        try
        {
            int payablesType = Convert.ToInt32(ddlOpt_PayablesType.SelectedValue);
            int bank = (int)Enums.CommonEnum.Payabletype.BankTransfer;
            int cheque = (int)Enums.CommonEnum.Payabletype.Cheque;
            int card = (int)Enums.CommonEnum.Payabletype.CreditCard;
            int cash = (int)Enums.CommonEnum.Payabletype.Cash;

            downPaymentToSupplierFormUI.ModifiedBy = SessionContext.UserGuid;
            downPaymentToSupplierFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            downPaymentToSupplierFormUI.Tbl_DownPaymentToSupplierId = Request.QueryString["DownPaymentToSupplierId"];
            downPaymentToSupplierFormUI.Tbl_BatchId = txtBatchGuid.Text;
            downPaymentToSupplierFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            if (chkIsAutoAppliyTo.Checked)
            {
                downPaymentToSupplierFormUI.IsAutoAppliyTo = true;
            }
            else
            {
                downPaymentToSupplierFormUI.IsAutoAppliyTo = false;
            }
            
            downPaymentToSupplierFormUI.Opt_PayablesType = int.Parse(ddlOpt_PayablesType.SelectedValue.ToString());
            downPaymentToSupplierFormUI.Tbl_SupplierId = txtSupplierGuid.Text;
            if (payablesType == bank)
            {
                downPaymentToSupplierFormUI.Tbl_PayablesId_BankTransfer = txtPayablesBankGuid.Text;
                downPaymentToSupplierFormUI.BankTransferAmount = Convert.ToDecimal(txtBankTransferAmount.Text);
            }
            else
            {
                downPaymentToSupplierFormUI.Tbl_PayablesId_BankTransfer = null;
                downPaymentToSupplierFormUI.BankTransferAmount = 0;
            }
            if (payablesType == cash)
            {

                downPaymentToSupplierFormUI.Tbl_PayablesId_Cash = txtPayablesCashGuid.Text;
                downPaymentToSupplierFormUI.CashAmount = Convert.ToDecimal(txtCashAmount.Text);
            }
            else
            {

                downPaymentToSupplierFormUI.Tbl_PayablesId_Cash = null;
                downPaymentToSupplierFormUI.CashAmount = 0;
            }
            if (payablesType == cheque)
            {
                downPaymentToSupplierFormUI.Tbl_PayablesId_Cheque = txtPayablesChequeGuid.Text;
                downPaymentToSupplierFormUI.ChequeAmount = Convert.ToDecimal(txtChequeAmount.Text);
            }
            else
            {
                downPaymentToSupplierFormUI.Tbl_PayablesId_Cheque = null;
                downPaymentToSupplierFormUI.ChequeAmount = 0;
            }


            if (payablesType == card)
            {

                downPaymentToSupplierFormUI.Tbl_PayablesId_CreditCard = txtPayablesCreditCardGuid.Text;
                downPaymentToSupplierFormUI.CreditCardAmount = Convert.ToDecimal(txtCreditCardAmount.Text);
            }
            else
            {
                downPaymentToSupplierFormUI.Tbl_PayablesId_CreditCard = null;
                downPaymentToSupplierFormUI.CreditCardAmount = 0;

            }

            downPaymentToSupplierFormUI.Tbl_SourceDocumentId = txtSourceDocumentGuid.Text;
            downPaymentToSupplierFormUI.PaymentNumber = txtPaymentNumber.Text;
            downPaymentToSupplierFormUI.PaymentDate = DateTime.Parse(txtPaymentDate.Text.ToString());




            downPaymentToSupplierFormUI.DocumentNumber = txtDocumentNumber.Text;
           
            downPaymentToSupplierFormUI.Comments = txtComments.Text;
            downPaymentToSupplierFormUI.Unapplied = Decimal.Parse(txtUnapplied.Text.ToString());
            downPaymentToSupplierFormUI.Applied = Decimal.Parse(txtApplied.Text.ToString());
            downPaymentToSupplierFormUI.Total = Convert.ToDecimal(txtTotal.Text);


            downPaymentToSupplierFormUI.ApplyDate = DateTime.Parse(txtApplyDate.Text.ToString());
            downPaymentToSupplierFormUI.opt_DocumentType = int.Parse(ddlOpt_DocumentType.SelectedValue.ToString());

            if (downPaymentToSupplierFormBAL.UpdateDownPaymentToSupplier(downPaymentToSupplierFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : btnUpdate_Click] An error occured in the processing of Record Id : " + downPaymentToSupplierFormUI.Tbl_DownPaymentToSupplierId + ".  Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            downPaymentToSupplierFormUI.Tbl_DownPaymentToSupplierId = Request.QueryString["DownPaymentToSupplierId"];
            if (downPaymentToSupplierFormBAL.DeleteDownPaymentToSupplier(downPaymentToSupplierFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = downPaymentToSupplierFormUI.Tbl_DownPaymentToSupplierId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : btnDelete_Click] An error occured in the processing of Record Id : " + downPaymentToSupplierFormUI.Tbl_DownPaymentToSupplierId + ". Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("DownPaymentToSupplierList.aspx");
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["DownPaymentToSupplierId"] != null)
        {
            string downPaymentToSupplierId = Request.QueryString["DownPaymentToSupplierId"];
            Response.Redirect("DownPaymentToSupplierApplyForm.aspx?DownPaymentToSupplierId=" + downPaymentToSupplierId);
        }
    }

    protected void btnDistribution_Click(object sender, EventArgs e)
    {
        string downPaymentToSupplierId = Request.QueryString["DownPaymentToSupplierId"];
        Response.Redirect("DownPaymentToSupplierDistributionForm.aspx?DownPaymentToSupplierId=" + downPaymentToSupplierId);

    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~Finance/Bank_Accounting/Down_Payment_Suppliers/DownPaymentToSupplierForm.aspx";
        string recordId = Request.QueryString["DownPaymentToSupplierId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    protected void btnPost_Click(object sender, EventArgs e)
    {
        try
        {
            bool isPosted = true;
            downPaymentToSupplierFormUI.ModifiedBy = SessionContext.UserGuid;
            downPaymentToSupplierFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            downPaymentToSupplierFormUI.Tbl_DownPaymentToSupplierId = Request.QueryString["DownPaymentToSupplierId"];
            downPaymentToSupplierFormUI.IsPosted = isPosted;

            if (downPaymentToSupplierFormBAL.UpdatePostingDownPaymentToSupplier(downPaymentToSupplierFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = downPaymentToSupplierFormUI.Tbl_DownPaymentToSupplierId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : btnPost_Click] An error occured in the processing of Record Id : " + downPaymentToSupplierFormUI.Tbl_DownPaymentToSupplierId + ".  Details : [" + exp.ToString() + "]");
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

    #region Search SourceDocument
    protected void btnSource_DocumentSearch_Click(object sender, EventArgs e)
    {
        btnHtmlSource_DocumentSearch.Visible = false;
        btnHtmlSource_DocumentClose.Visible = true;
        SearchSource_DocumentList();
    }

    protected void btnClearSource_DocumentSearch_Click(object sender, EventArgs e)
    {
        BindDocumentSearchList();
        gvSource_DocumentSearch.Visible = true;
        btnHtmlSource_DocumentSearch.Visible = true;
        btnHtmlSource_DocumentClose.Visible = false;
        txtSource_DocumentSearch.Text = "";
        txtSource_DocumentSearch.Focus();
    }
    protected void btnSource_DocumentRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindDocumentSearchList();
    }

    #endregion Search SourceDocument
    protected void ddlOpt_PayablesType_Load(object sender, EventArgs e)
    {
        int payablesType = Convert.ToInt32(ddlOpt_PayablesType.SelectedValue);
        int bank = (int)Enums.CommonEnum.Payabletype.BankTransfer;
        int Cheque = (int)Enums.CommonEnum.Payabletype.Cheque;
        int card = (int)Enums.CommonEnum.Payabletype.CreditCard;
        int cash = (int)Enums.CommonEnum.Payabletype.Cash;


        divCreditCard.Visible = false;
        divCheque.Visible = false;
        divCash.Visible = false;
        if (payablesType == bank)
        {
            divCheque.Visible = false;
            divBank.Visible = true;
            divCreditCard.Visible = false;
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
            divCreditCard.Visible = true;
            divCash.Visible = false;
            divBank.Visible = false;
        }
        else
        {
            divCheque.Visible = false;
            divCreditCard.Visible = false;
            divCash.Visible = true;
            divBank.Visible = false;
        }
    }
    protected void txtPaymentDate_TextChanged(object sender, EventArgs e)
    {
        if (txtPaymentDate.Text != "")
        {
            DateTime paymentDate = Convert.ToDateTime(txtPaymentDate.Text.ToString());

            if (paymentDate < fiscalPeriodStartDate && paymentDate > fiscalPeriodEndDate)
            {
                txtPaymentDate.Text = "";
                txtPaymentDate.Focus();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                "err_msg", "alert('Payment Date can not be greater the Financial closing Date!)');", true);
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
            optionSetListUI.TableName = "tbl_DownPaymentToSupplier";
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : BindPayablesTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void FillForm(DownPaymentToSupplierFormUI downPaymentToSupplierFormUI)
    {
        try
        {
            DataTable dtb = downPaymentToSupplierFormBAL.GetDownPaymentToSupplierListById(downPaymentToSupplierFormUI);
            if (dtb.Rows.Count > 0)
            {
                txtBatchGuid.Text = dtb.Rows[0]["tbl_BatchId"].ToString();
                txtBatch.Text = dtb.Rows[0]["BatchName"].ToString();
                txtCurrencyGuid.Text = dtb.Rows[0]["tbl_CurrencyId"].ToString();
                txtCurrency.Text = dtb.Rows[0]["CurrencyName"].ToString();
                ddlOpt_PayablesType.SelectedValue= dtb.Rows[0]["Opt_PayablesType"].ToString();
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
                txtSourceDocumentGuid.Text= dtb.Rows[0]["tbl_SourceDocumentId"].ToString();
                txtSourceDocument.Text = dtb.Rows[0]["tbl_SourceDocument"].ToString();
                txtTotal.Text = dtb.Rows[0]["Total"].ToString();
                txtBankTransferAmount.Text = dtb.Rows[0]["BankTransferAmount"].ToString();
                txtCashAmount.Text = dtb.Rows[0]["CashAmount"].ToString();
                txtChequeAmount.Text = dtb.Rows[0]["ChequeAmount"].ToString();
                txtCreditCardAmount.Text = dtb.Rows[0]["CreditCardAmount"].ToString();
                txtPaymentNumber.Text= dtb.Rows[0]["PaymentNumber"].ToString();
                txtPaymentDate.Text = dtb.Rows[0]["PaymentDate"].ToString();
                txtApplied.Text = dtb.Rows[0]["Applied"].ToString();
                txtUnapplied.Text = dtb.Rows[0]["Unapplied"].ToString();
                chkIsAutoAppliyTo.Checked = Convert.ToBoolean(dtb.Rows[0]["IsAutoAppliyTo"].ToString());
                
               
                txtDocumentNumber.Text = dtb.Rows[0]["DocumentNumber"].ToString();
                txtComments.Text = dtb.Rows[0]["Comments"].ToString();
                txtApplyDate.Text= dtb.Rows[0]["ApplyDate"].ToString();
                ddlOpt_DocumentType.SelectedValue = dtb.Rows[0]["DocumentType"].ToString();

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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = downPaymentToSupplierFormUI.Tbl_DownPaymentToSupplierId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : SearchBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : BindBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : SearchSupplierList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : BindSupplierList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : SearchCurrencyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : BindCurrencyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Currency Serach

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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : SearchPayablesBankList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : BindPayablesBankList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : SearchPayablesCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : BindPayablesCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : SearchPayablesChequeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : BindPayablesChequeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : SearchPayablesCreditCardList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : BindPayablesCreditCardList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Payables Credit Card Serach

    #region SourceDocument Search 
    private void SearchSource_DocumentList()
    {

        try
        {
            SourceDocumentListUI sourceDocumentListUI = new SourceDocumentListUI();
            sourceDocumentListUI.Search = txtSource_DocumentSearch.Text;


            DataTable dtb = sourceDocumentListBAL.GetSourceDocumentListBySearchParameters(sourceDocumentListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSource_DocumentSearch.DataSource = dtb;
                gvSource_DocumentSearch.DataBind();
                divSource_DocumentSearchError.Visible = false;
            }
            else
            {
                divSource_DocumentSearchError.Visible = true;
                lblSource_DocumentSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSource_DocumentSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchSource_DocumentList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : SearchSource_DocumentList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindDocumentSearchList()
    {
        try
        {
            DataTable dtb = sourceDocumentListBAL.GetSourceDocumentList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSource_DocumentSearch.DataSource = dtb;
                gvSource_DocumentSearch.DataBind();
                divError.Visible = false;
                gvSource_DocumentSearch.Visible = true;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSource_DocumentSearch.Visible = false;
            }

            txtSource_DocumentSearch.Text = "";
            txtSource_DocumentSearch.Focus();
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindDocumentSearchList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : BindDocumentSearchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion SourceDocument Search

    private void BindDocumentTypeDropDownList()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_DownPaymentToSupplier";
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : BindDocumentTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void GetSerialNumber()
    {
        try
        {
            DataTable dtb = downPaymentToSupplierFormBAL.GetSerialNumber();
            if (dtb.Rows.Count > 0)
            {
              txtDocumentNumber.Text = dtb.Rows[0][0].ToString();

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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : GetSerialNumber] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #endregion Methods




}
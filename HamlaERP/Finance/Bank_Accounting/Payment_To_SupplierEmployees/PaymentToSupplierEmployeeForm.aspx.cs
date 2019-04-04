using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeForm : PageBase
{
    #region Data Members

    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    PaymentToSupplierEmployeeFormBAL paymentToSupplierEmployeeFormBAL = new PaymentToSupplierEmployeeFormBAL();
    PaymentToSupplierEmployeeFormUI paymentToSupplierEmployeeFormUI = new PaymentToSupplierEmployeeFormUI();
    SourceDocumentListBAL sourceDocumentListBAL = new SourceDocumentListBAL();
    BatchListBAL batchListBAL = new BatchListBAL();
    
    SupplierEmployeeListBAL supplierEmployeeListBAL = new SupplierEmployeeListBAL();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    PayablesListBAL payablesListBAL = new PayablesListBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();

    DateTime fiscalPeriodStartDate = SessionContext.FiscalPeriodStartDate;
    DateTime fiscalPeriodEndDate = SessionContext.FiscalPeriodEndDate;
    #endregion End Data Member

    #region Events

    protected override void Page_Load(object sender, EventArgs e)
    {
        PaymentToSupplierEmployeeFormUI paymentToSupplierEmployeeFormUI = new PaymentToSupplierEmployeeFormUI();
        if (!Page.IsPostBack)
        {

            BindDocumentTypeDropDownList();

            if (Request.QueryString["PaymentToSupplierEmployeeId"] != null || Request.QueryString["recordId"] != null)
            {
                paymentToSupplierEmployeeFormUI.Tbl_PaymentToSupplierEmployeeId = (Request.QueryString["PaymentToSupplierEmployeeId"] != null ? Request.QueryString["PaymentToSupplierEmployeeId"] : Request.QueryString["recordId"]);
                BindDocumentTypeDropDownList();
                FillForm(paymentToSupplierEmployeeFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnApply.Visible = true;
                btnDistribution.Visible = true;
                btnPost.Visible = true;
                btnAuditHistory.Visible = true;

                lblHeading.Text = "Update Payment To Supplier Employee";
            }
            else
            {
                GetSerialNumber();
                BindDocumentTypeDropDownList();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnApply.Visible = false;
                btnDistribution.Visible = false;
                btnPost.Visible = false;
                btnAuditHistory.Visible = false;
                txtPaymentDate.ReadOnly = true;
                lblHeading.Text = "Add New Payment To Supplier Employee";
            }
        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            paymentToSupplierEmployeeFormUI.CreatedBy = SessionContext.UserGuid;
            paymentToSupplierEmployeeFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            paymentToSupplierEmployeeFormUI.Tbl_BatchId = txtBatchGuid.Text;
            paymentToSupplierEmployeeFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            paymentToSupplierEmployeeFormUI.Tbl_SupplierEmployeeId = txtSupplierEmployeeGuid.Text;
            paymentToSupplierEmployeeFormUI.Tbl_PayablesId_BankTransfer = txtPayablesBankGuid.Text;
            paymentToSupplierEmployeeFormUI.Tbl_PayablesId_Cash = txtPayablesCashGuid.Text;
            paymentToSupplierEmployeeFormUI.Tbl_PayablesId_Cheque = txtPayablesChequeGuid.Text;
            paymentToSupplierEmployeeFormUI.Tbl_PayablesId_CreditCard = txtPayablesCreditCardGuid.Text;
            paymentToSupplierEmployeeFormUI.Tbl_SourceDocumentId = txtSourceDocumentGuid.Text;
            paymentToSupplierEmployeeFormUI.PaymentNumber = txtPaymentNumber.Text;
            paymentToSupplierEmployeeFormUI.PaymentDate = DateTime.Parse(txtPaymentDate.Text.ToString());
            paymentToSupplierEmployeeFormUI.BankTransferAmount = Convert.ToDecimal(txtBankTransferAmount.Text);
            paymentToSupplierEmployeeFormUI.CashAmount = Convert.ToDecimal(txtCashAmount.Text);
            paymentToSupplierEmployeeFormUI.ChequeAmount = Convert.ToDecimal(txtChequeAmount.Text);
            paymentToSupplierEmployeeFormUI.CreditCardAmount = Convert.ToDecimal(txtCreditCardAmount.Text);
            paymentToSupplierEmployeeFormUI.Unapplied = Decimal.Parse(txtUnapplied.Text.ToString());
            paymentToSupplierEmployeeFormUI.Applied = Decimal.Parse(txtApplied.Text.ToString());
            paymentToSupplierEmployeeFormUI.Total = Convert.ToDecimal(txtTotal.Text);
            if (chkIsAutoAppliyTo.Checked)
            { paymentToSupplierEmployeeFormUI.IsAutoApplyTo = true; }
            else
            {
                paymentToSupplierEmployeeFormUI.IsAutoApplyTo = false;
            }
           

           
            paymentToSupplierEmployeeFormUI.ApplyDate = DateTime.Parse(txtApplyDate.Text.ToString());
            paymentToSupplierEmployeeFormUI.opt_DocumentType = int.Parse(ddlOpt_DocumentType.SelectedValue.ToString());

            if (paymentToSupplierEmployeeFormBAL.AddPaymentToSupplierEmployee(paymentToSupplierEmployeeFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        try
        {
            paymentToSupplierEmployeeFormUI.ModifiedBy = SessionContext.UserGuid;
            paymentToSupplierEmployeeFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            paymentToSupplierEmployeeFormUI.Tbl_PaymentToSupplierEmployeeId = Request.QueryString["PaymentToSupplierEmployeeId"];
            paymentToSupplierEmployeeFormUI.Tbl_BatchId = txtBatchGuid.Text;
            paymentToSupplierEmployeeFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            paymentToSupplierEmployeeFormUI.Tbl_SupplierEmployeeId = txtSupplierEmployeeGuid.Text;
            paymentToSupplierEmployeeFormUI.Tbl_PayablesId_BankTransfer = txtPayablesBankGuid.Text;
            paymentToSupplierEmployeeFormUI.Tbl_PayablesId_Cash = txtPayablesCashGuid.Text;
            paymentToSupplierEmployeeFormUI.Tbl_PayablesId_Cheque = txtPayablesChequeGuid.Text;
            paymentToSupplierEmployeeFormUI.Tbl_PayablesId_CreditCard = txtPayablesCreditCardGuid.Text;
            paymentToSupplierEmployeeFormUI.Tbl_SourceDocumentId = txtSourceDocumentGuid.Text;
            paymentToSupplierEmployeeFormUI.PaymentNumber = txtPaymentNumber.Text;
            paymentToSupplierEmployeeFormUI.PaymentDate = DateTime.Parse(txtPaymentDate.Text.ToString());
            paymentToSupplierEmployeeFormUI.BankTransferAmount = Convert.ToDecimal(txtBankTransferAmount.Text);
            paymentToSupplierEmployeeFormUI.CashAmount = Convert.ToDecimal(txtCashAmount.Text);
            paymentToSupplierEmployeeFormUI.ChequeAmount = Convert.ToDecimal(txtChequeAmount.Text);
            paymentToSupplierEmployeeFormUI.CreditCardAmount = Convert.ToDecimal(txtCreditCardAmount.Text);
            paymentToSupplierEmployeeFormUI.Unapplied = Decimal.Parse(txtUnapplied.Text.ToString());
            paymentToSupplierEmployeeFormUI.Applied = Decimal.Parse(txtApplied.Text.ToString());
            paymentToSupplierEmployeeFormUI.Total = Convert.ToDecimal(txtTotal.Text);
            if (chkIsAutoAppliyTo.Checked)
            {
                paymentToSupplierEmployeeFormUI.IsAutoApplyTo = true;
            }
            else
            {
                paymentToSupplierEmployeeFormUI.IsAutoApplyTo = false;
            }
           

            
            paymentToSupplierEmployeeFormUI.ApplyDate = DateTime.Parse(txtApplyDate.Text.ToString());
            paymentToSupplierEmployeeFormUI.opt_DocumentType = int.Parse(ddlOpt_DocumentType.SelectedValue.ToString());

            if (paymentToSupplierEmployeeFormBAL.UpdatePaymentToSupplierEmployee(paymentToSupplierEmployeeFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm : btnUpdate_Click] An error occured in the processing of Record Id : " + paymentToSupplierEmployeeFormUI.Tbl_PaymentToSupplierEmployeeId + ".  Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            paymentToSupplierEmployeeFormUI.Tbl_PaymentToSupplierEmployeeId = Request.QueryString["PaymentToSupplierEmployeeId"];
            if (paymentToSupplierEmployeeFormBAL.DeletePaymentToSupplierEmployee(paymentToSupplierEmployeeFormUI) == 1)
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
            logExcpUIobj.RecordId = paymentToSupplierEmployeeFormUI.Tbl_PaymentToSupplierEmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : btnDelete_Click] An error occured in the processing of Record Id : " + paymentToSupplierEmployeeFormUI.Tbl_PaymentToSupplierEmployeeId + ". Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnPost_Click(object sender, EventArgs e)
    {
        try
        {
            bool isPosted = true;
            paymentToSupplierEmployeeFormUI.ModifiedBy = SessionContext.UserGuid;
            paymentToSupplierEmployeeFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            paymentToSupplierEmployeeFormUI.Tbl_PaymentToSupplierEmployeeId = Request.QueryString["PaymentToSupplierEmployeeId"];
            paymentToSupplierEmployeeFormUI.IsPosted = isPosted;

            if (paymentToSupplierEmployeeFormBAL.UpdatePostingPaymentToSupplierEmployee(paymentToSupplierEmployeeFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeForm.CS";
            logExcpUIobj.RecordId = paymentToSupplierEmployeeFormUI.Tbl_PaymentToSupplierEmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeForm : btnPost_Click] An error occured in the processing of Record Id : " + paymentToSupplierEmployeeFormUI.Tbl_PaymentToSupplierEmployeeId + ".  Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaymentToSupplierEmployeeList.aspx");
    }
    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Finance/Bank_Accounting/Payment_To_Employees/PaymentToSupplierEmployeeForm.aspx";
        string recordId = Request.QueryString["PaymentToSupplierEmployeeId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    
    protected void btnApply_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["PaymentToSupplierEmployeeId"] != null)
        {
            string paymentToSupplierEmployeeId = Request.QueryString["PaymentToSupplierEmployeeId"];
            Response.Redirect("PaymentToSupplierEmployeeApplyForm.aspx?PaymentToSupplierEmployeeId=" + paymentToSupplierEmployeeId);
        }

    }
    protected void btnDistribution_Click(object sender, EventArgs e)
    {
        string paymentToSupplierEmployeeId = Request.QueryString["PaymentToSupplierEmployeeId"];
        Response.Redirect("PaymentToSupplierEmployeeDistributionForm.aspx?PaymentToSupplierEmployeeId=" + paymentToSupplierEmployeeId);
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


    #region SupplierEmployee Search
    protected void btnSupplierEmployeeSearch_Click(object sender, EventArgs e)
    {
        btnHtmlSupplierEmployeeSearch.Visible = false;
        btnHtmlSupplierEmployeeClose.Visible = true;
        SearchSupplierEmployeeList();
    }
    protected void btnClearSupplierEmployeeSearch_Click(object sender, EventArgs e)
    {
        BindSupplierEmployeeList();
        gvSupplierEmployeeSearch.Visible = true;
        btnHtmlSupplierEmployeeSearch.Visible = true;
        btnHtmlSupplierEmployeeClose.Visible = false;
        txtSupplierEmployeeSearch.Text = "";
        txtSupplierEmployeeSearch.Focus();
    }
    protected void btnSupplierEmployeeRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindSupplierEmployeeList();
    }
    #endregion Employee Search

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
                "err_msg", "alert('PaymentDate Date can not be greater the Financial closing Date!)');", true);
            }
        }
    }
    #endregion End Event

    #region  Methods

    private void GetSerialNumber()
    {
        try
        {
            DataTable dtb = paymentToSupplierEmployeeFormBAL.GetSerialNumber();
            if (dtb.Rows.Count > 0)
            {
                txtPaymentNumber.Text = dtb.Rows[0][0].ToString();

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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_SupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_Supplier_Master_Creation_SupplierForm : GetSerialNumber] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void FillForm(PaymentToSupplierEmployeeFormUI paymentToSupplierEmployeeFormUI)
    {
        try
        {
            DataTable dtb = paymentToSupplierEmployeeFormBAL.GetPaymentToSupplierEmployeeListById(paymentToSupplierEmployeeFormUI);
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
                txtSupplierEmployeeGuid.Text = dtb.Rows[0]["tbl_SupplierEmployeeId"].ToString();
                txtSupplierEmployee.Text = dtb.Rows[0]["SupplierEmployeeName"].ToString();
                txtPayablesCreditCardGuid.Text = dtb.Rows[0]["tbl_PayablesId_CreditCard"].ToString();
                txtPayablesCreditCard.Text = dtb.Rows[0]["CardName"].ToString();
                txtSourceDocumentGuid.Text = dtb.Rows[0]["tbl_SourceDocumentId"].ToString();
                txtSourceDocument.Text = dtb.Rows[0]["tbl_SourceDocument"].ToString();
                txtTotal.Text = dtb.Rows[0]["Total"].ToString();
                txtBankTransferAmount.Text = dtb.Rows[0]["BankTransferAmount"].ToString();
                txtCashAmount.Text = dtb.Rows[0]["CashAmount"].ToString();
                txtChequeAmount.Text = dtb.Rows[0]["ChequeAmount"].ToString();
                txtCreditCardAmount.Text = dtb.Rows[0]["CreditCardAmount"].ToString();
                txtPaymentNumber.Text = dtb.Rows[0]["PaymentNumber"].ToString();
                txtPaymentDate.Text = dtb.Rows[0]["PaymentDate"].ToString();
                txtApplied.Text = dtb.Rows[0]["Applied"].ToString();
                txtUnapplied.Text = dtb.Rows[0]["Unapplied"].ToString();
                
                chkIsAutoAppliyTo.Checked = Convert.ToBoolean(dtb.Rows[0]["IsAutoAppliyTo"].ToString());
              
                txtApplyDate.Text = dtb.Rows[0]["ApplyDate"].ToString();
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm.CS";
            logExcpUIobj.RecordId = paymentToSupplierEmployeeFormUI.Tbl_PaymentToSupplierEmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm : SearchBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm : BindBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  BatchSerach

    #region SupplierEmployee Search
    private void SearchSupplierEmployeeList()
    {
        try
        {
            SupplierEmployeeListUI supplierEmployeeListUI = new SupplierEmployeeListUI();
            supplierEmployeeListUI.Search = txtSupplierEmployeeSearch.Text;
            DataTable dtb = supplierEmployeeListBAL.GetSupplierEmployeeListBySearchParameters(supplierEmployeeListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSupplierEmployeeSearch.DataSource = dtb;
                gvSupplierEmployeeSearch.DataBind();
                divSupplierEmployeeSearchError.Visible = false;
            }
            else
            {
                divSupplierEmployeeSearchError.Visible = true;
                lblSupplierEmployeeSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSupplierEmployeeSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchEmployeeList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm : SearchEmployeeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindSupplierEmployeeList()
    {
        try
        {
            DataTable dtb = supplierEmployeeListBAL.GetSupplierEmployeeList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSupplierEmployeeSearch.DataSource = dtb;
                gvSupplierEmployeeSearch.DataBind();
                divSupplierEmployeeSearchError.Visible = false;
            }
            else
            {
                divSupplierEmployeeSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSupplierEmployeeSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindEmployeeList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm : BindEmployeeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Supplier Employee Serach

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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm : SearchCurrencyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm : BindCurrencyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm : SearchPayablesBankList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm : SearchPayablesCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm : BindPayablesCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm : SearchPayablesChequeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm : BindPayablesChequeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm : SearchPayablesCreditCardList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm : BindPayablesCreditCardList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm : SearchSource_DocumentList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToSupplierEmployeeForm : BindDocumentSearchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion SourceDocument Search

    private void BindDocumentTypeDropDownList()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_PaymentToSupplierEmployee";
            optionSetListUI.OptionSetName = "opt_DocumentType";
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
    #endregion End Method

  
}
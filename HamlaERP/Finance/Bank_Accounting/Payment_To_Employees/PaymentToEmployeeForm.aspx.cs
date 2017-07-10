using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;


public partial class Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm : System.Web.UI.Page
{

    #region Data Members

    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    PaymentToEmployeeFormBAL paymentToEmployeeFormBAL = new PaymentToEmployeeFormBAL();
    PaymentToEmployeeFormUI paymentToEmployeeFormUI = new PaymentToEmployeeFormUI();
    SourceDocumentListBAL sourceDocumentListBAL = new SourceDocumentListBAL();
    BatchListBAL batchListBAL = new BatchListBAL();
    EmployeeListBAL employeeListBAL = new EmployeeListBAL();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    PayablesListBAL payablesListBAL = new PayablesListBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    #endregion End Data Member

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        PaymentToEmployeeFormUI paymentToEmployeeFormUI = new PaymentToEmployeeFormUI();
        if (!Page.IsPostBack)
        {

            BindDocumentTypeDropDownList();

            if (Request.QueryString["PaymentToEmployeeId"] != null)
            {
                paymentToEmployeeFormUI.Tbl_PaymentToEmployeeId = Request.QueryString["PaymentToEmployeeId"];
                BindDocumentTypeDropDownList();
                FillForm(paymentToEmployeeFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnApply.Visible = true;
                btnDistribution.Visible = true;
                
                lblHeading.Text = "Update Payment To Employee";
            }
            else
            {
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnApply.Visible = false;
                btnDistribution.Visible = false;
                lblHeading.Text = "Add New Payment To Employee";
            }
        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            paymentToEmployeeFormUI.CreatedBy = SessionContext.UserGuid;
            paymentToEmployeeFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            paymentToEmployeeFormUI.Tbl_BatchId = txtBatchGuid.Text;
            paymentToEmployeeFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            paymentToEmployeeFormUI.Tbl_EmployeeId = txtEmployeeGuid.Text;
            paymentToEmployeeFormUI.Tbl_PayablesId_BankTransfer = txtPayablesBankGuid.Text;
            paymentToEmployeeFormUI.Tbl_PayablesId_Cash = txtPayablesCashGuid.Text;
            paymentToEmployeeFormUI.Tbl_PayablesId_Cheque = txtPayablesChequeGuid.Text;
            paymentToEmployeeFormUI.Tbl_PayablesId_CreditCard = txtPayablesCreditCardGuid.Text;
            paymentToEmployeeFormUI.Tbl_SourceDocumentId = txtSourceDocumentGuid.Text;
            paymentToEmployeeFormUI.PaymentNumber = txtPaymentNumber.Text;
            paymentToEmployeeFormUI.PaymentDate = DateTime.Parse(txtPaymentDate.Text.ToString());
            paymentToEmployeeFormUI.BankTransferAmount = Convert.ToDecimal(txtBankTransferAmount.Text);
            paymentToEmployeeFormUI.CashAmount = Convert.ToDecimal(txtCashAmount.Text);
            paymentToEmployeeFormUI.ChequeAmount = Convert.ToDecimal(txtChequeAmount.Text);
            paymentToEmployeeFormUI.CreditCardAmount = Convert.ToDecimal(txtCreditCardAmount.Text);
            paymentToEmployeeFormUI.Unapplied = Decimal.Parse(txtUnapplied.Text.ToString());
            paymentToEmployeeFormUI.Applied = Decimal.Parse(txtApplied.Text.ToString());
            paymentToEmployeeFormUI.Total = Convert.ToDecimal(txtTotal.Text);
            if (chkIsAutoAppliyTo.Checked)
            { paymentToEmployeeFormUI.IsAutoAppliyTo = true; }
            else
            {
                paymentToEmployeeFormUI.IsAutoAppliyTo = false;
            }
            if (chkIsPosted.Checked)
            {
                paymentToEmployeeFormUI.IsPosted = true;
            }
            else
            {
                paymentToEmployeeFormUI.IsPosted = false;
            }

            paymentToEmployeeFormUI.PostingDate = DateTime.Parse(txtPostingDate.Text.ToString());
            paymentToEmployeeFormUI.ApplyDate = DateTime.Parse(txtApplyDate.Text.ToString());
            paymentToEmployeeFormUI.opt_DocumentType = int.Parse(ddlOpt_DocumentType.SelectedValue.ToString());

            if (paymentToEmployeeFormBAL.AddPaymentToEmployee(paymentToEmployeeFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        try
        {
            paymentToEmployeeFormUI.ModifiedBy = SessionContext.UserGuid;
            paymentToEmployeeFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            paymentToEmployeeFormUI.Tbl_PaymentToEmployeeId = Request.QueryString["PaymentToEmployeeId"];
            paymentToEmployeeFormUI.Tbl_BatchId = txtBatchGuid.Text;
            paymentToEmployeeFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            paymentToEmployeeFormUI.Tbl_EmployeeId = txtEmployeeGuid.Text;
            paymentToEmployeeFormUI.Tbl_PayablesId_BankTransfer = txtPayablesBankGuid.Text;
            paymentToEmployeeFormUI.Tbl_PayablesId_Cash = txtPayablesCashGuid.Text;
            paymentToEmployeeFormUI.Tbl_PayablesId_Cheque = txtPayablesChequeGuid.Text;
            paymentToEmployeeFormUI.Tbl_PayablesId_CreditCard = txtPayablesCreditCardGuid.Text;
            paymentToEmployeeFormUI.Tbl_SourceDocumentId = txtSourceDocumentGuid.Text;
            paymentToEmployeeFormUI.PaymentNumber = txtPaymentNumber.Text;
            paymentToEmployeeFormUI.PaymentDate = DateTime.Parse(txtPaymentDate.Text.ToString());
            paymentToEmployeeFormUI.BankTransferAmount = Convert.ToDecimal(txtBankTransferAmount.Text);
            paymentToEmployeeFormUI.CashAmount = Convert.ToDecimal(txtCashAmount.Text);
            paymentToEmployeeFormUI.ChequeAmount = Convert.ToDecimal(txtChequeAmount.Text);
            paymentToEmployeeFormUI.CreditCardAmount = Convert.ToDecimal(txtCreditCardAmount.Text);
            paymentToEmployeeFormUI.Unapplied = Decimal.Parse(txtUnapplied.Text.ToString());
            paymentToEmployeeFormUI.Applied = Decimal.Parse(txtApplied.Text.ToString());
            paymentToEmployeeFormUI.Total = Convert.ToDecimal(txtTotal.Text);
            if (chkIsPosted.Checked)
            {
                paymentToEmployeeFormUI.IsAutoAppliyTo = true;
            }
            else
            {
                paymentToEmployeeFormUI.IsAutoAppliyTo = false;
            }
            if (chkIsPosted.Checked)
            {
                paymentToEmployeeFormUI.IsPosted = true;
            }
            else
            {
                paymentToEmployeeFormUI.IsPosted = false;
            }

            paymentToEmployeeFormUI.PostingDate = DateTime.Parse(txtPostingDate.Text.ToString());
            paymentToEmployeeFormUI.ApplyDate = DateTime.Parse(txtApplyDate.Text.ToString());
            paymentToEmployeeFormUI.opt_DocumentType = int.Parse(ddlOpt_DocumentType.SelectedValue.ToString());

            if (paymentToEmployeeFormBAL.UpdatePaymentToEmployee(paymentToEmployeeFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm : btnUpdate_Click] An error occured in the processing of Record Id : " + paymentToEmployeeFormUI.Tbl_PaymentToEmployeeId + ".  Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            paymentToEmployeeFormUI.Tbl_PaymentToEmployeeId = Request.QueryString["PaymentToEmployeeId"];
            if (paymentToEmployeeFormBAL.DeletePaymentToEmployee(paymentToEmployeeFormUI) == 1)
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
            logExcpUIobj.RecordId = paymentToEmployeeFormUI.Tbl_PaymentToEmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : btnDelete_Click] An error occured in the processing of Record Id : " + paymentToEmployeeFormUI.Tbl_PaymentToEmployeeId + ". Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaymentToEmployeeList.aspx");
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["PaymentToEmployeeId"] != null)
        {
            string paymentToEmployeeId = Request.QueryString["PaymentToEmployeeId"];
            Response.Redirect("PaymentToEmployeeApplyForm.aspx?PaymentToEmployeeId=" + paymentToEmployeeId);
        }

    }
    protected void btnDistribution_Click(object sender, EventArgs e)
    {
        string paymentToEmployeeId = Request.QueryString["PaymentToEmployeeId"];
        Response.Redirect("PaymentToEmployeeDistributionForm.aspx?PaymentToEmployeeId=" + paymentToEmployeeId);
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


    #region Employee Search
    protected void btnEmployeeSearch_Click(object sender, EventArgs e)
    {
        btnHtmlEmployeeSearch.Visible = false;
        btnHtmlEmployeeClose.Visible = true;
        SearchEmployeeList();
    }
    protected void btnClearEmployeeSearch_Click(object sender, EventArgs e)
    {
        BindEmployeeList();
        gvEmployeeSearch.Visible = true;
        btnHtmlEmployeeSearch.Visible = true;
        btnHtmlEmployeeClose.Visible = false;
        txtEmployeeSearch.Text = "";
        txtEmployeeSearch.Focus();
    }
    protected void btnEmployeeRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindEmployeeList();
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
    #endregion End Event

    #region  Methods
    private void FillForm(PaymentToEmployeeFormUI paymentToEmployeeFormUI)
    {
        try
        {
            DataTable dtb = paymentToEmployeeFormBAL.GetPaymentToEmployeeListById(paymentToEmployeeFormUI);
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
                txtEmployeeGuid.Text = dtb.Rows[0]["tbl_EmployeeId"].ToString();
                txtEmployee.Text = dtb.Rows[0]["EmployeeName"].ToString();
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
                txtApplyDate.Text = dtb.Rows[0]["ApplyDate"].ToString();
                ddlOpt_DocumentType.SelectedValue = dtb.Rows[0]["DocumentType"].ToString();

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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm.CS";
            logExcpUIobj.RecordId = paymentToEmployeeFormUI.Tbl_PaymentToEmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm : SearchBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm : BindBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  BatchSerach

    #region Employee Search
    private void SearchEmployeeList()
    {
        try
        {
            EmployeeListUI employeeListUI = new EmployeeListUI();
            employeeListUI.Search = txtEmployeeSearch.Text;
            DataTable dtb = employeeListBAL.GetEmployeeListBySearchParameters(employeeListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvEmployeeSearch.DataSource = dtb;
                gvEmployeeSearch.DataBind();
                divEmployeeSearchError.Visible = false;
            }
            else
            {
                divEmployeeSearchError.Visible = true;
                lblEmployeeSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvEmployeeSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchEmployeeList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm : SearchEmployeeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindEmployeeList()
    {
        try
        {
            DataTable dtb = employeeListBAL.GetEmployeeList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvEmployeeSearch.DataSource = dtb;
                gvEmployeeSearch.DataBind();
                divEmployeeSearchError.Visible = false;
            }
            else
            {
                divEmployeeSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvEmployeeSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindEmployeeList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm : BindEmployeeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Employee Serach

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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm : SearchCurrencyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm : BindCurrencyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm : SearchPayablesBankList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm : SearchPayablesCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm : BindPayablesCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm : SearchPayablesChequeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm : BindPayablesChequeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm : SearchPayablesCreditCardList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm : BindPayablesCreditCardList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm : SearchSource_DocumentList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employee_PaymentToEmployeeForm : BindDocumentSearchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion SourceDocument Search

    private void BindDocumentTypeDropDownList()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_PaymentToEmployee";
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
    #endregion End Method


}
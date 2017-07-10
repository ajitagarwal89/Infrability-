using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    PaymentToSupplierFormBAL paymentToSupplierFormBAL = new PaymentToSupplierFormBAL();
    PaymentToSupplierFormUI paymentToSupplierFormUI = new PaymentToSupplierFormUI();
    PaymentToSupplierListBAL paymentToSupplierListBAL = new PaymentToSupplierListBAL();
    BatchListBAL batchListBAL = new BatchListBAL();
    BatchListUI batchListUI = new BatchListUI();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    CurrencyListUI currencyListUI = new CurrencyListUI();
    PayablesListBAL payablesListBAL = new PayablesListBAL();
    SupplierListBAL supplierListBAL = new SupplierListBAL();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        PaymentToSupplierFormUI paymentToSupplierFormUI = new PaymentToSupplierFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["PaymentToSupplierId"] != null)
            {
                paymentToSupplierFormUI.Tbl_PaymentToSupplierId = Request.QueryString["PaymentToSupplierId"];

                
                FillForm(paymentToSupplierFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnApply.Visible = true;
                btnDistribution.Visible = true;
                lblHeading.Text = "Update Payment To Supplier";
            }
            else
            {

               

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnApply.Visible = false;
                btnDistribution.Visible = false;
                lblHeading.Text = "Add New Payment To Supplier";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            paymentToSupplierFormUI.CreatedBy = SessionContext.UserGuid;
            paymentToSupplierFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            paymentToSupplierFormUI.PaymentNumber = txtPaymentNumber.Text;
            paymentToSupplierFormUI.PaymentDate = Convert.ToDateTime(txtPaymentDate.Text);
            paymentToSupplierFormUI.Tbl_BatchId = txtBatchIdGuid.Text;
            paymentToSupplierFormUI.Tbl_SupplierId = txtSupplierGuid.Text;
            paymentToSupplierFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            paymentToSupplierFormUI.Tbl_PayablesId_BankTransfer = txtPayablesBankGuid.Text;
            paymentToSupplierFormUI.BankTransferAmount = Convert.ToDecimal(txtBankTransferAmount.Text);
            paymentToSupplierFormUI.Tbl_PayablesId_Cash = txtPayablesCashGuid.Text;
            paymentToSupplierFormUI.CashAmount = Convert.ToDecimal(txtCashAmount.Text);
            paymentToSupplierFormUI.Tbl_PayablesId_Cheque = txtPayablesChequeGuid.Text;
            paymentToSupplierFormUI.ChequeAmount = Convert.ToDecimal(txtChequeAmount.Text);
            paymentToSupplierFormUI.Tbl_PayablesId_CreditCard = txtPayablesCreditCardGuid.Text;
            paymentToSupplierFormUI.CreditCardAmount = Convert.ToDecimal(txtCreditCardAmount.Text);
            paymentToSupplierFormUI.Unapplied = Convert.ToDecimal(txtUnapplied.Text);
            paymentToSupplierFormUI.Applied = Convert.ToDecimal(txtApplied.Text);
            paymentToSupplierFormUI.Total = Convert.ToDecimal(txtTotal.Text);        

            if (paymentToSupplierFormBAL.AddPaymentToSupplier(paymentToSupplierFormUI) == 1)
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
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            paymentToSupplierFormUI.ModifiedBy = SessionContext.UserGuid;
            paymentToSupplierFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            paymentToSupplierFormUI.Tbl_PaymentToSupplierId = Request.QueryString["PaymentToSupplierId"];

            paymentToSupplierFormUI.PaymentNumber = txtPaymentNumber.Text;
            paymentToSupplierFormUI.PaymentDate = Convert.ToDateTime(txtPaymentDate.Text);
            paymentToSupplierFormUI.Tbl_BatchId = txtBatchIdGuid.Text;
            paymentToSupplierFormUI.Tbl_SupplierId = txtSupplierGuid.Text;
            paymentToSupplierFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            paymentToSupplierFormUI.Tbl_PayablesId_BankTransfer = txtPayablesBankGuid.Text;
            paymentToSupplierFormUI.BankTransferAmount = Convert.ToDecimal(txtBankTransferAmount.Text);
            paymentToSupplierFormUI.Tbl_PayablesId_Cash = txtPayablesCashGuid.Text;
            paymentToSupplierFormUI.CashAmount = Convert.ToDecimal(txtCashAmount.Text);
            paymentToSupplierFormUI.Tbl_PayablesId_Cheque = txtPayablesChequeGuid.Text;
            paymentToSupplierFormUI.ChequeAmount = Convert.ToDecimal(txtChequeAmount.Text);
            paymentToSupplierFormUI.Tbl_PayablesId_CreditCard = txtPayablesCreditCardGuid.Text;
            paymentToSupplierFormUI.CreditCardAmount = Convert.ToDecimal(txtCreditCardAmount.Text);
            paymentToSupplierFormUI.Unapplied = Convert.ToDecimal(txtUnapplied.Text);
            paymentToSupplierFormUI.Applied = Convert.ToDecimal(txtApplied.Text);
            paymentToSupplierFormUI.Total = Convert.ToDecimal(txtTotal.Text);


            if (paymentToSupplierFormBAL.UpdatePaymentToSupplier(paymentToSupplierFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm : btnUpdate_Click] An error occured in the processing of Record Id : " + paymentToSupplierFormUI.Tbl_PaymentToSupplierId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            paymentToSupplierFormUI.Tbl_PaymentToSupplierId = Request.QueryString["PaymentToSupplierId"];

            if (paymentToSupplierFormBAL.DeletePaymentToSupplier(paymentToSupplierFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = paymentToSupplierFormUI.Tbl_PaymentToSupplierId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm : btnDelete_Click] An error occured in the processing of Record Id : " + paymentToSupplierFormUI.Tbl_PaymentToSupplierId + ". Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaymentToSupplierList.aspx");
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["PaymentToSupplierId"] != null)
        {
            string paymentToSupplierId = Request.QueryString["PaymentToSupplierId"];
            Response.Redirect("PaymentToSupplierApplyForm.aspx?PaymentToSupplierId=" + paymentToSupplierId);
        }
    }

    protected void btnDistribution_Click(object sender, EventArgs e)
    {
        string paymentToSupplierId = Request.QueryString["PaymentToSupplierId"];
        Response.Redirect("PaymentToSupplierDistributionForm.aspx?PaymentToSupplierId=" + paymentToSupplierId);

    }

    #endregion Events

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
        SearchSupplier();
    }
    protected void btnClearSupplierSearch_Click(object sender, EventArgs e)
    {
        BindSupplierList();
    }
    protected void btnSupplierRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindSupplierList();

    }

    #endregion Currency Search

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

    #region Methods Search

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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm : SearchBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm : BindBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Batch Search

    #region Supplier Search
    private void SearchSupplier()
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
                divError.Visible = false;

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
            logExcpUIobj.MethodName = "SearchSupplier()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm : SearchSupplier] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
                lblSupplierSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSupplierSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Supplier Search

    #region Currency Search
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm : SearchCurrency] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Currency Search

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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm : SearchPayablesBankList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm : BindPayablesBankList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  PayablesBank Search

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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm : SearchPayablesCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm : BindPayablesCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Payables Cash Search

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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm : SearchPayablesChequeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm : BindPayablesChequeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm : SearchPayablesCreditCardList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm : BindPayablesCreditCardList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Payables Credit Card Serach
    #endregion 

    #region Methods
    private void FillForm(PaymentToSupplierFormUI paymentToSupplierFormUI)
    {
        try
        {
            DataTable dtb = paymentToSupplierFormBAL.GetPaymentToSupplierListById(paymentToSupplierFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtPaymentNumber.Text = dtb.Rows[0]["PaymentNumber"].ToString();
                txtPaymentDate.Text = dtb.Rows[0]["PaymentDate"].ToString();
                txtBatchIdGuid.Text = dtb.Rows[0]["tbl_BatchId"].ToString();
                txtBatchId.Text = dtb.Rows[0]["BatchName"].ToString();
                txtSupplierGuid.Text= dtb.Rows[0]["tbl_SupplierId"].ToString();
                txtSupplierId.Text= dtb.Rows[0]["SupplierName"].ToString();
                txtCurrencyGuid.Text = dtb.Rows[0]["tbl_CurrencyId"].ToString();
                txtCurrency.Text= dtb.Rows[0]["CurrencyName"].ToString();
                txtPayablesBankGuid.Text = dtb.Rows[0]["tbl_PayablesId_BankTransfer"].ToString();
                txtPayablesBank.Text = dtb.Rows[0]["BankName"].ToString();
                txtBankTransferAmount.Text = dtb.Rows[0]["BankTransferAmount"].ToString();
                txtPayablesCashGuid.Text = dtb.Rows[0]["tbl_PayablesId_Cash"].ToString();
                txtPayablesCash.Text = dtb.Rows[0]["PayablesTypeCash"].ToString();
                txtCashAmount.Text = dtb.Rows[0]["CashAmount"].ToString();
                txtPayablesChequeGuid.Text = dtb.Rows[0]["tbl_PayablesId_Cheque"].ToString();
                txtPayablesCheque.Text = dtb.Rows[0]["PaymentNumberCheque"].ToString();
                txtChequeAmount.Text = dtb.Rows[0]["ChequeAmount"].ToString();
                txtPayablesCreditCardGuid.Text = dtb.Rows[0]["tbl_PayablesId_CreditCard"].ToString();
                txtPayablesCreditCard.Text = dtb.Rows[0]["CardName"].ToString();
                txtCreditCardAmount.Text= dtb.Rows[0]["CreditCardAmount"].ToString();
                txtUnapplied.Text = dtb.Rows[0]["Unapplied"].ToString();
                txtApplied.Text = dtb.Rows[0]["Applied"].ToString();
                txtTotal.Text= dtb.Rows[0]["Total"].ToString();


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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = paymentToSupplierFormUI.Tbl_PaymentToSupplierId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods
}
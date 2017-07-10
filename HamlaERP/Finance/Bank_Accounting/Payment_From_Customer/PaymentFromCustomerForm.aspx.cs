using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;
public partial class Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();



    PaymentFromCustomerListBAL paymentFromCustomerListBAL = new PaymentFromCustomerListBAL();
    PaymentFromCustomerFormUI paymentFromCustomerFormUI = new PaymentFromCustomerFormUI();
    PaymentFromCustomerFormBAL paymentFromCustomerFormBAL = new PaymentFromCustomerFormBAL();
    SourceDocumentListBAL sourceDocumentListBAL = new SourceDocumentListBAL();
    BatchListBAL batchListBAL = new BatchListBAL();
    BatchListUI batchListUI = new BatchListUI();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    CurrencyListUI currencyListUI = new CurrencyListUI();
    CustomerListBAL customerListBAL = new CustomerListBAL();
    EmployeeListBAL employeeListBAL = new EmployeeListBAL();
    EmployeeListUI employeeListUI = new EmployeeListUI();
    PayablesListBAL payablesListBAL = new PayablesListBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    #endregion Data Members

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
         PaymentFromCustomerFormUI  paymentFromCustomerFormUI = new  PaymentFromCustomerFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["PaymentFromCustomerId"] != null)
            {
                paymentFromCustomerFormUI.Tbl_PaymentFromCustomerId = Request.QueryString["PaymentFromCustomerId"];

                FillForm(paymentFromCustomerFormUI);
                BindDocumentTypeDropDownList();

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnApply.Visible = true;
                btnDistribution.Visible = true;
                lblHeading.Text = "Update PaymentFromCustomer";
            }
            else
            {
                BindDocumentTypeDropDownList();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnApply.Visible = false;
                btnDistribution.Visible = false;
                lblHeading.Text = "Add New PaymentFromCustomer";
            }
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            paymentFromCustomerFormUI.CreatedBy = SessionContext.UserGuid;
            paymentFromCustomerFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            paymentFromCustomerFormUI.ReceiptNumber = txtReceiptNumber.Text;
            paymentFromCustomerFormUI.ReceiptDate = Convert.ToDateTime(txtReceiptDate.Text);
            paymentFromCustomerFormUI.Tbl_BatchId = txtBatchIdGuid.Text;
            paymentFromCustomerFormUI.Tbl_CustomerId = txtCustomerGuid.Text;
            paymentFromCustomerFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            paymentFromCustomerFormUI.Tbl_PayablesId_Cash = txtPayablesCashGuid.Text;
            paymentFromCustomerFormUI.CashAmount = Convert.ToDecimal(txtCashAmount.Text);
            paymentFromCustomerFormUI.Tbl_PayablesId_Cheque = txtPayablesChequeGuid.Text;
            paymentFromCustomerFormUI.ChequeAmount = Convert.ToDecimal(txtChequeAmount.Text);
            paymentFromCustomerFormUI.Tbl_PayablesId_CreditCard = txtPayablesCreditCardGuid.Text;
            paymentFromCustomerFormUI.CreditCardAmount = Convert.ToDecimal(txtCreditCardAmount.Text);
            paymentFromCustomerFormUI.DocumentNumber = txtDocumentNumber.Text;
            paymentFromCustomerFormUI.Comments = txtComments.Text;
            if (chckIsAutoApplyTo.Checked == true)
            {
                paymentFromCustomerFormUI.IsAutoAppliyTo = true;
            }
            else
            {
                paymentFromCustomerFormUI.IsAutoAppliyTo = false;
            }
            if (chckIsPosted.Checked == true)
            {
                paymentFromCustomerFormUI.IsPosted = true;
            }
            else
            {
                paymentFromCustomerFormUI.IsPosted = false;
            }
            paymentFromCustomerFormUI.PostingDate = Convert.ToDateTime(txtPostingDate.Text);
            paymentFromCustomerFormUI.ApplyDate = Convert.ToDateTime(txtApplyDate.Text);
            paymentFromCustomerFormUI.Tbl_SourceDocumentId = txtSourceDocumentGuid.Text;
            paymentFromCustomerFormUI.opt_DocumentType = Convert.ToInt32(ddlOpt_DocumentType.SelectedValue);
            paymentFromCustomerFormUI.Total = Convert.ToDecimal(txtTotal.Text);

            if (paymentFromCustomerFormBAL.AddPaymentFromCustomer(paymentFromCustomerFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
                divSuccess.Visible = false;
                divError.Visible = true;


            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            paymentFromCustomerFormUI.ModifiedBy = SessionContext.UserGuid;
            paymentFromCustomerFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            paymentFromCustomerFormUI.Tbl_PaymentFromCustomerId = Request.QueryString["PaymentFromCustomerId"];

            paymentFromCustomerFormUI.ReceiptNumber = txtReceiptNumber.Text;
            paymentFromCustomerFormUI.ReceiptDate = Convert.ToDateTime(txtReceiptDate.Text);
            paymentFromCustomerFormUI.Tbl_BatchId = txtBatchIdGuid.Text;
            paymentFromCustomerFormUI.Tbl_CustomerId = txtCustomerGuid.Text;
            paymentFromCustomerFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            paymentFromCustomerFormUI.Tbl_PayablesId_Cash = txtPayablesCashGuid.Text;
            paymentFromCustomerFormUI.CashAmount = Convert.ToDecimal(txtCashAmount.Text);
            paymentFromCustomerFormUI.Tbl_PayablesId_Cheque = txtPayablesChequeGuid.Text;
            paymentFromCustomerFormUI.ChequeAmount = Convert.ToDecimal(txtChequeAmount.Text);
            paymentFromCustomerFormUI.Tbl_PayablesId_CreditCard = txtPayablesCreditCardGuid.Text;
            paymentFromCustomerFormUI.CreditCardAmount = Convert.ToDecimal(txtCreditCardAmount.Text);
            paymentFromCustomerFormUI.DocumentNumber = txtDocumentNumber.Text;
            paymentFromCustomerFormUI.Comments = txtComments.Text;
            if (chckIsAutoApplyTo.Checked == true)
            {
                paymentFromCustomerFormUI.IsAutoAppliyTo = true;
            }
            else
            {
                paymentFromCustomerFormUI.IsAutoAppliyTo = false;
            }
            if (chckIsPosted.Checked == true)
            {
                paymentFromCustomerFormUI.IsPosted = true;
            }
            else
            {
                paymentFromCustomerFormUI.IsPosted = false;
            }
            paymentFromCustomerFormUI.PostingDate = Convert.ToDateTime(txtPostingDate.Text);
            paymentFromCustomerFormUI.ApplyDate = Convert.ToDateTime(txtApplyDate.Text);
            paymentFromCustomerFormUI.Tbl_SourceDocumentId = txtSourceDocumentGuid.Text;
            paymentFromCustomerFormUI.opt_DocumentType = Convert.ToInt32(ddlOpt_DocumentType.SelectedValue);

            if (paymentFromCustomerFormBAL.UpdatePaymentFromCustomer(paymentFromCustomerFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm : btnUpdate_Click] An error occured in the processing of Record Id : " + paymentFromCustomerFormUI.Tbl_PaymentFromCustomerId + ".  Details : [" + exp.ToString() + "]");
        }


    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
             paymentFromCustomerFormUI.Tbl_PaymentFromCustomerId = Request.QueryString["PaymentFromCustomerId"];

            if (paymentFromCustomerFormBAL.DeletePaymentFromCustomer(paymentFromCustomerFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm.CS";
            logExcpUIobj.RecordId =  paymentFromCustomerFormUI.Tbl_PaymentFromCustomerId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm : btnDelete_Click] An error occured in the processing of Record Id : " +  paymentFromCustomerFormUI.Tbl_PaymentFromCustomerId + ". Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaymentFromCustomerList.aspx");
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["PaymentFromCustomerId"] != null)
        {
            string paymentFromCustomerId = Request.QueryString["PaymentFromCustomerId"];
            Response.Redirect("PaymentFromCustomerApplyForm.aspx?PaymentFromCustomerId=" + paymentFromCustomerId);
        }
    }

    protected void btnDistribution_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["PaymentFromCustomerId"] != null)
        {
            string paymentFromCustomerId = Request.QueryString["PaymentFromCustomerId"];
            Response.Redirect("PaymentFromCustomerDistributionForm.aspx?PaymentFromCustomerId=" + paymentFromCustomerId);
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

    #region SourceDocument Search
    protected void btnSourceDocumentSearch_Click(object sender, EventArgs e)
    {
        btnHtmlSourceDocumentSearch.Visible = false;
        btnHtmlSourceDocumentClose.Visible = true;
        SearchSourceDocumentList();
    }
    protected void btnClearSourceDocumentSearch_Click(object sender, EventArgs e)
    {
        BindSourceDocumentList();
        gvSourceDocumentSearch.Visible = true;
        btnHtmlSourceDocumentSearch.Visible = true;
        btnHtmlSourceDocumentClose.Visible = false;
        txtSourceDocumentSearch.Text = "";
        txtSourceDocumentSearch.Focus();
    }
    protected void btnSourceDocumentRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindSourceDocumentList();
    }
    #endregion 

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
    #endregion

    #region Methods

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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm : SearchBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm : BindBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Batch Search

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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm : SearchCurrency] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            log.Error("[Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Currency Search

    #region Search  BindCustomer
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerFormt.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm : BindCustomerList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm : SearchCustomer] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion

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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm : SearchPayablesCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindPayablesCashList()
    {
        int payableTypeCash = 3;
        int processTypeSale = 1;
        PayablesListUI payablesListUI = new PayablesListUI();

        try
        {
            payablesListUI.Opt_PayablesType = payableTypeCash;
            payablesListUI.Opt_ProcessType = processTypeSale;
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm : BindPayablesCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm: SearchPayablesChequeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindPayablesChequeList()
    {
        int payablesTypeCheque = 2;
        int processTypeCheque = 1;
        PayablesListUI payablesListUI = new PayablesListUI();

        try
        {
            payablesListUI.Opt_PayablesType = payablesTypeCheque;
            payablesListUI.Opt_ProcessType = processTypeCheque;
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm : BindPayablesChequeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm : SearchPayablesCreditCardList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindPayablesCreditCardList()
    {
        int payablesTypeCreditCard = 4;
        int processTypeCreditCard = 1;
        PayablesListUI payablesListUI = new PayablesListUI();

        try
        {
            payablesListUI.Opt_PayablesType = payablesTypeCreditCard;
            payablesListUI.Opt_ProcessType = processTypeCreditCard;
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm : BindPayablesCreditCardList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Payables Credit Card Serach

    #region SourceDocument Search    
    private void SearchSourceDocumentList()
    {
        try
        {
            SourceDocumentListUI sourceDocumentListUI = new SourceDocumentListUI();
            sourceDocumentListUI.Search = txtSourceDocumentSearch.Text;


            DataTable dtb = sourceDocumentListBAL.GetSourceDocumentListBySearchParameters(sourceDocumentListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSourceDocumentSearch.DataSource = dtb;
                gvSourceDocumentSearch.DataBind();
                divSourceDocumentSearchError.Visible = false;
            }
            else
            {
                divSourceDocumentSearchError.Visible = true;
                lblSourceDocumentSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSourceDocumentSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchsourceDocumentList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerForm : SearchsourceDocumentList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindSourceDocumentList()
    {
        try
        {
            DataTable dtb = sourceDocumentListBAL.GetSourceDocumentList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSourceDocumentSearch.DataSource = dtb;
                gvSourceDocumentSearch.DataBind();
                divSourceDocumentSearchError.Visible = false;

            }
            else
            {
                divSourceDocumentSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSourceDocumentSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindSourceDocumentList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm : BindSourceDocumentList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion 
    private void BindDocumentTypeDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_PaymentFromCustomer";
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerForm : BindDocumentTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }


    private void FillForm( PaymentFromCustomerFormUI paymentFromCustomerFormUI)
    {
        try
        {
            DataTable dtb =  paymentFromCustomerFormBAL.GetPaymentFromCustomerListById(paymentFromCustomerFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtReceiptNumber.Text = dtb.Rows[0]["ReceiptNumber"].ToString();
                txtReceiptDate.Text = dtb.Rows[0]["ReceiptDate"].ToString();
                txtBatchIdGuid.Text = dtb.Rows[0]["tbl_BatchId"].ToString();
                txtBatchId.Text = dtb.Rows[0]["BatchName"].ToString();
                txtCustomerGuid.Text = dtb.Rows[0]["tbl_CustomerId"].ToString();
                txtCustomer.Text = dtb.Rows[0]["CustomerName"].ToString();
                txtCurrencyGuid.Text = dtb.Rows[0]["tbl_CurrencyId"].ToString();
                txtCurrency.Text = dtb.Rows[0]["CurrencyName"].ToString();
                txtPayablesCashGuid.Text = dtb.Rows[0]["tbl_PayablesId_Cash"].ToString();
                txtPayablesCash.Text = dtb.Rows[0]["PaymentNumberCash"].ToString();
                txtCashAmount.Text = dtb.Rows[0]["CashAmount"].ToString();
                txtPayablesChequeGuid.Text = dtb.Rows[0]["tbl_PayablesId_Cheque"].ToString();
                txtPayablesCheque.Text = dtb.Rows[0]["PaymentNumberCheque"].ToString();
                txtPayablesCreditCardGuid.Text = dtb.Rows[0]["tbl_PayablesId_CreditCard"].ToString();
                txtPayablesCreditCard.Text = dtb.Rows[0]["PaymentNumberCard"].ToString();
                txtChequeAmount.Text = dtb.Rows[0]["ChequeAmount"].ToString();
                txtCreditCardAmount.Text = dtb.Rows[0]["CreditCardAmount"].ToString();
                txtDocumentNumber.Text = dtb.Rows[0]["DocumentNumber"].ToString();
                txtComments.Text = dtb.Rows[0]["Comments"].ToString();
                chckIsPosted.Checked = Convert.ToBoolean(dtb.Rows[0]["IsPosted"].ToString());
                chckIsAutoApplyTo.Checked = Convert.ToBoolean(dtb.Rows[0]["IsAutoAppliyTo"].ToString());
                txtPostingDate.Text = dtb.Rows[0]["PostingDate"].ToString();
                txtApplyDate.Text= dtb.Rows[0]["ApplyDate"].ToString();
                txtSourceDocumentGuid.Text= dtb.Rows[0]["tbl_SourceDocumentId"].ToString();
                txtSourceDocument.Text= dtb.Rows[0]["DocumentNumber"].ToString();
                ddlOpt_DocumentType.SelectedIndex = Convert.ToInt32(dtb.Rows[0]["opt_DocumentType"].ToString());

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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_ _Payment_ PaymentFromCustomerForm.CS";
            logExcpUIobj.RecordId =  paymentFromCustomerFormUI.Tbl_PaymentFromCustomerId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #endregion
}

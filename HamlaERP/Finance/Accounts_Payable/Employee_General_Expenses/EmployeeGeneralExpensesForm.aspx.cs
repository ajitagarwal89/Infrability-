﻿using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;
//using ConversionClasses;

public partial class Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    EmployeeGeneralExpensesFormBAL employeeGeneralExpensesFormBAL = new EmployeeGeneralExpensesFormBAL();
    EmployeeGeneralExpensesFormUI employeeGeneralExpensesFormUI = new EmployeeGeneralExpensesFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    EmployeeGeneralExpensesListBAL employeeGeneralExpensesListBAL = new EmployeeGeneralExpensesListBAL();
    BatchListBAL batchListBAL = new BatchListBAL();
    BatchListUI batchListUI = new BatchListUI();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    CurrencyListUI currencyListUI = new CurrencyListUI();
    EmployeeListBAL employeeListBAL = new EmployeeListBAL();
    EmployeeListUI employeeListUI = new EmployeeListUI();
    PayablesListBAL payablesListBAL = new PayablesListBAL();

    CommonDateClasses commonDateClasses = new CommonDateClasses();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        EmployeeGeneralExpensesFormUI employeeGeneralExpensesFormUI = new EmployeeGeneralExpensesFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["EmployeeGeneralExpensesId"] != null)
            {
                employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId = Request.QueryString["EmployeeGeneralExpensesId"];

                BindDocumentTypeDropDownList();


                FillForm(employeeGeneralExpensesFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update EmployeeGeneralExpenses";
            }
            else
            {
                BindDocumentTypeDropDownList();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New EmployeeGeneralExpenses";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            employeeGeneralExpensesFormUI.CreatedBy = SessionContext.UserGuid;
            employeeGeneralExpensesFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            employeeGeneralExpensesFormUI.VoucherNumber = txtVoucherNumber.Text;

            if (chckInterCompany.Checked == true)
                employeeGeneralExpensesFormUI.InterCompany = true;
            else employeeGeneralExpensesFormUI.InterCompany = false;
            employeeGeneralExpensesFormUI.Tbl_BatchId = txtBatchIdGuid.Text;
            employeeGeneralExpensesFormUI.Opt_DocumentType = Convert.ToInt32(ddlOpt_DocumentType.SelectedValue);
            employeeGeneralExpensesFormUI.DocumentDate = Convert.ToDateTime(txtDocumentDate.Text);
            employeeGeneralExpensesFormUI.Description = txtDescription.Text;
            employeeGeneralExpensesFormUI.PostingDate = Convert.ToDateTime(txtPostingDate.Text);
            employeeGeneralExpensesFormUI.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text);
            employeeGeneralExpensesFormUI.ReceivedDate = Convert.ToDateTime(txtReceivedDate.Text);
            employeeGeneralExpensesFormUI.Tbl_EmployeeId = txtEmployeeIdGuid.Text;
            employeeGeneralExpensesFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            employeeGeneralExpensesFormUI.Expenses = Convert.ToDecimal(txtExpenses.Text);
            employeeGeneralExpensesFormUI.Tbl_Payables_BankTransfer = txtPayablesBankGuid.Text;
            employeeGeneralExpensesFormUI.BankTransferAmount = Convert.ToDecimal(txtBankTransferAmount.Text);
            employeeGeneralExpensesFormUI.Tbl_Payables_Cash = txtPayablesCashGuid.Text;
            employeeGeneralExpensesFormUI.Cash = Convert.ToDecimal(txtCash.Text);
            employeeGeneralExpensesFormUI.Tbl_Payables_Cheque = txtPayablesChequeGuid.Text;
            employeeGeneralExpensesFormUI.Cheque = Convert.ToDecimal(txtCheque.Text);
            employeeGeneralExpensesFormUI.Tbl_Payables_CreditCard = txtPayablesCreditCardGuid.Text;
            employeeGeneralExpensesFormUI.CreditCard = Convert.ToDecimal(txtCreditCard.Text);
            employeeGeneralExpensesFormUI.OnAccount = Convert.ToDecimal(txtOnAmount.Text);






            if (employeeGeneralExpensesFormBAL.AddEmployeeGeneralExpenses(employeeGeneralExpensesFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            employeeGeneralExpensesFormUI.ModifiedBy = SessionContext.UserGuid;
            employeeGeneralExpensesFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId = Request.QueryString["EmployeeGeneralExpensesId"];
            employeeGeneralExpensesFormUI.VoucherNumber = txtVoucherNumber.Text;

            if (chckInterCompany.Checked == true)
                employeeGeneralExpensesFormUI.InterCompany = true;
            else employeeGeneralExpensesFormUI.InterCompany = false;
            employeeGeneralExpensesFormUI.Tbl_BatchId = txtBatchIdGuid.Text;
            employeeGeneralExpensesFormUI.Opt_DocumentType = Convert.ToInt32(ddlOpt_DocumentType.SelectedValue);
            employeeGeneralExpensesFormUI.DocumentDate = Convert.ToDateTime(txtDocumentDate.Text);
            employeeGeneralExpensesFormUI.Description = txtDescription.Text;
            employeeGeneralExpensesFormUI.PostingDate = Convert.ToDateTime(txtPostingDate.Text);
            employeeGeneralExpensesFormUI.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text);
            employeeGeneralExpensesFormUI.ReceivedDate = Convert.ToDateTime(txtReceivedDate.Text);
            employeeGeneralExpensesFormUI.Tbl_EmployeeId = txtEmployeeIdGuid.Text;
            employeeGeneralExpensesFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            employeeGeneralExpensesFormUI.Expenses = Convert.ToDecimal(txtExpenses.Text);
            employeeGeneralExpensesFormUI.Tbl_Payables_BankTransfer = txtPayablesBankGuid.Text;
            employeeGeneralExpensesFormUI.BankTransferAmount = Convert.ToDecimal(txtBankTransferAmount.Text);
            employeeGeneralExpensesFormUI.Tbl_Payables_Cash = txtPayablesCashGuid.Text;
            employeeGeneralExpensesFormUI.Cash = Convert.ToDecimal(txtCash.Text);
            employeeGeneralExpensesFormUI.Tbl_Payables_Cheque = txtPayablesChequeGuid.Text;
            employeeGeneralExpensesFormUI.Cheque = Convert.ToDecimal(txtCheque.Text);
            employeeGeneralExpensesFormUI.Tbl_Payables_CreditCard = txtPayablesCreditCardGuid.Text;
            employeeGeneralExpensesFormUI.CreditCard = Convert.ToDecimal(txtCreditCard.Text);
            employeeGeneralExpensesFormUI.OnAccount = Convert.ToDecimal(txtOnAmount.Text);





            if (employeeGeneralExpensesFormBAL.UpdateEmployeeGeneralExpenses(employeeGeneralExpensesFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm : btnUpdate_Click] An error occured in the processing of Record Id : " + employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId + ".  Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId = Request.QueryString["EmployeeGeneralExpensesId"];

            if (employeeGeneralExpensesFormBAL.DeleteEmployeeGeneralExpenses(employeeGeneralExpensesFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm.CS";
            logExcpUIobj.RecordId = employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm : btnDelete_Click] An error occured in the processing of Record Id : " + employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId + ". Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeGeneralExpensesList.aspx");
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

    #region Methods Search And Bind

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
    #endregion Currency Search

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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm : SearchEmployeeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm : BindEmployeeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Employee Search

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
    #endregion Methods Search And Bind

    #region Methods

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



    private void FillForm(EmployeeGeneralExpensesFormUI employeeGeneralExpensesFormUI)
    {
        try
        {
            DataTable dtb = employeeGeneralExpensesFormBAL.GetEmployeeGeneralExpensesListById(employeeGeneralExpensesFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtVoucherNumber.Text = dtb.Rows[0]["VoucherNumber"].ToString();
                chckInterCompany.Checked = Convert.ToBoolean(dtb.Rows[0]["InterCompany"].ToString());
                txtBatchIdGuid.Text = dtb.Rows[0]["tbl_BatchId"].ToString();
                txtBatchId.Text = dtb.Rows[0]["BatchName"].ToString();
                ddlOpt_DocumentType.SelectedValue = dtb.Rows[0]["Opt_DocumentType"].ToString();
                txtDocumentDate.Text = commonDateClasses.DateInTextBox(dtb.Rows[0]["DocumentDate"].ToString());
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                txtPostingDate.Text = commonDateClasses.DateInTextBox(dtb.Rows[0]["PostingDate"].ToString());
                txtInvoiceDate.Text = commonDateClasses.DateInTextBox(dtb.Rows[0]["InvoiceDate"].ToString());
                txtReceivedDate.Text = commonDateClasses.DateInTextBox(dtb.Rows[0]["ReceivedDate"].ToString());
                txtEmployeeIdGuid.Text = dtb.Rows[0]["tbl_EmployeeId"].ToString();
                txtEmployeeId.Text = dtb.Rows[0]["EmployeeName"].ToString();
                txtCurrencyGuid.Text = dtb.Rows[0]["tbl_CurrencyId"].ToString();
                txtCurrency.Text = dtb.Rows[0]["CurrencyName"].ToString();
                txtExpenses.Text = dtb.Rows[0]["Expenses"].ToString();
                txtPayablesBankGuid.Text = dtb.Rows[0]["tbl_Payables_BankTransfer"].ToString();
                txtPayablesBank.Text = dtb.Rows[0]["BankName"].ToString();
                txtBankTransferAmount.Text = dtb.Rows[0]["BankTransferAmount"].ToString();
                txtPayablesCashGuid.Text = dtb.Rows[0]["tbl_Payables_Cash"].ToString();
                txtPayablesCash.Text = dtb.Rows[0]["PayablesTypeCash"].ToString();
                txtCash.Text = dtb.Rows[0]["Cash"].ToString();
                txtPayablesChequeGuid.Text = dtb.Rows[0]["tbl_Payables_Cheque"].ToString();
                txtPayablesCheque.Text = dtb.Rows[0]["ProcessTypeCheque"].ToString();
                txtCheque.Text = dtb.Rows[0]["Cheque"].ToString();
                txtPayablesCreditCardGuid.Text = dtb.Rows[0]["tbl_Payables_CreditCard"].ToString();
                txtPayablesCreditCard.Text = dtb.Rows[0]["CardName"].ToString();
                txtCreditCard.Text = dtb.Rows[0]["CreditCard"].ToString();
                txtOnAmount.Text = dtb.Rows[0]["OnAccount"].ToString();

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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm.CS";
            logExcpUIobj.RecordId = employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #endregion 

}
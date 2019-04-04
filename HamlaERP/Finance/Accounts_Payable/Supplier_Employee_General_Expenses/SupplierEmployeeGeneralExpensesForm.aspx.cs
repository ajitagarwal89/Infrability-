using Finware;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Finance_Accounts_Payable_Supplier_General_Expenses_SupplierEmployeeGeneralExpensesForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    SupplierEmployeeGeneralExpensesFormBAL supplierEmployeeGeneralExpensesFormBAL = new SupplierEmployeeGeneralExpensesFormBAL();
    SupplierEmployeeGeneralExpensesFormUI supplierEmployeeGeneralExpensesFormUI= new SupplierEmployeeGeneralExpensesFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    EmployeeGeneralExpensesListBAL employeeGeneralExpensesListBAL = new EmployeeGeneralExpensesListBAL();
    BatchListBAL batchListBAL = new BatchListBAL();
    BatchListUI batchListUI = new BatchListUI();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    CurrencyListUI currencyListUI = new CurrencyListUI();
    PayablesListBAL payablesListBAL = new PayablesListBAL();

    CommonClasses commonClasses = new CommonClasses();
    SupplierEmployeeListBAL supplierEmployeeListBAL = new SupplierEmployeeListBAL();

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
        if (!Page.IsPostBack)
        {

            if (Request.QueryString["SupplierEmployeeGeneralExpensesId"] != null || Request.QueryString["recordId"] != null)
            {
                supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId = (Request.QueryString["SupplierEmployeeGeneralExpensesId"] != null ? Request.QueryString["SupplierEmployeeGeneralExpensesId"] : Request.QueryString["recordId"]);

                BindDocumentTypeDropDownList();
                BindPayablesTypeDropDownList();

                FillForm(supplierEmployeeGeneralExpensesFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnPost.Visible = true;
                btnAuditHistory.Visible = true;
                txtInvoiceDate.ReadOnly = true;
                lblHeading.Text = "Update Supplier Employee General Expenses";
            }
            else
            {
                supplierEmployeeGeneralExpensesFormUI.InvoiceType = invoiceTypeInvoice;
                GetSerialNumber(supplierEmployeeGeneralExpensesFormUI);
                BindDocumentTypeDropDownList();
                BindPayablesTypeDropDownList();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                btnPost.Visible = false;
                lblHeading.Text = "Add New Supplier Employee General Expenses";
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

            supplierEmployeeGeneralExpensesFormUI.CreatedBy = SessionContext.UserGuid;
            supplierEmployeeGeneralExpensesFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            supplierEmployeeGeneralExpensesFormUI.VoucherNumber = txtVoucherNumber.Text;

            if (chckInterCompany.Checked == true)
                supplierEmployeeGeneralExpensesFormUI.InterCompany = true;
            else supplierEmployeeGeneralExpensesFormUI.InterCompany = false;
            supplierEmployeeGeneralExpensesFormUI.Tbl_BatchId = txtBatchIdGuid.Text;
            supplierEmployeeGeneralExpensesFormUI.Opt_DocumentType = Convert.ToInt32(ddlOpt_DocumentType.SelectedValue.ToString());
            supplierEmployeeGeneralExpensesFormUI.DocumentDate = Convert.ToDateTime(txtDocumentDate.Text);
            supplierEmployeeGeneralExpensesFormUI.Description = txtDescription.Text;
            
            supplierEmployeeGeneralExpensesFormUI.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text);
            supplierEmployeeGeneralExpensesFormUI.ReceivedDate = Convert.ToDateTime(txtReceivedDate.Text);
            supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeId = txtSupplierGuid.Text;
            supplierEmployeeGeneralExpensesFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            supplierEmployeeGeneralExpensesFormUI.Expenses = Convert.ToDecimal(txtExpenses.Text);
            supplierEmployeeGeneralExpensesFormUI.Opt_PayablesType = Convert.ToInt32(ddlOpt_PayablesType.SelectedValue.ToString());

            if (payablesType == bank)
            {
                supplierEmployeeGeneralExpensesFormUI.Tbl_Payables_BankTransfer = txtPayablesBankGuid.Text;
                supplierEmployeeGeneralExpensesFormUI.BankTransferAmount = Convert.ToDecimal(txtBankTransferAmount.Text);
            }
            else
            {
                supplierEmployeeGeneralExpensesFormUI.Tbl_Payables_BankTransfer = null;
                supplierEmployeeGeneralExpensesFormUI.BankTransferAmount = 0;
            }
            if (payablesType == Cash)
            {
                supplierEmployeeGeneralExpensesFormUI.Tbl_Payables_Cash = txtPayablesCashGuid.Text;
                supplierEmployeeGeneralExpensesFormUI.Cash = Convert.ToDecimal(txtCash.Text);
            }
            else
            {
                supplierEmployeeGeneralExpensesFormUI.Tbl_Payables_Cash = null;
                supplierEmployeeGeneralExpensesFormUI.Cash = 0;
            }
            if (payablesType == Cheque)
            {
                supplierEmployeeGeneralExpensesFormUI.Tbl_Payables_Cheque = txtPayablesChequeGuid.Text;
                supplierEmployeeGeneralExpensesFormUI.Cheque = Convert.ToDecimal(txtCheque.Text);
            }
            else
            {
                supplierEmployeeGeneralExpensesFormUI.Tbl_Payables_Cheque = null;
                supplierEmployeeGeneralExpensesFormUI.Cheque = 0;
            }

            if (payablesType == card)
            {
                supplierEmployeeGeneralExpensesFormUI.Tbl_Payables_CreditCard = txtPayablesCreditCardGuid.Text;
                supplierEmployeeGeneralExpensesFormUI.CreditCard = Convert.ToDecimal(txtCreditCard.Text);
            }
            else
            {
                supplierEmployeeGeneralExpensesFormUI.Tbl_Payables_CreditCard = null;
                supplierEmployeeGeneralExpensesFormUI.CreditCard = 0;
            }

            supplierEmployeeGeneralExpensesFormUI.OnAccount = Convert.ToDecimal(txtOnAmount.Text);

            if (supplierEmployeeGeneralExpensesFormBAL.AddSupplierEmployeeGeneralExpenses(supplierEmployeeGeneralExpensesFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_General_Expenses_SupplierEmployeeGeneralExpensesForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_General_Expenses_SupplierEmployeeGeneralExpensesForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            int payablesType = Convert.ToInt32(ddlOpt_PayablesType.SelectedValue);
            int bank = (int)Enums.CommonEnum.Payabletype.BankTransfer;
            int Cheque = (int)Enums.CommonEnum.Payabletype.Cheque;
            int Cash = (int)Enums.CommonEnum.Payabletype.Cash;
            int card = (int)Enums.CommonEnum.Payabletype.CreditCard;

            supplierEmployeeGeneralExpensesFormUI.ModifiedBy = SessionContext.UserGuid;
            supplierEmployeeGeneralExpensesFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId = Request.QueryString["SupplierEmployeeGeneralExpensesId"];
            supplierEmployeeGeneralExpensesFormUI.VoucherNumber = txtVoucherNumber.Text;

            if (chckInterCompany.Checked == true)
                supplierEmployeeGeneralExpensesFormUI.InterCompany = true;
            else supplierEmployeeGeneralExpensesFormUI.InterCompany = false;
            supplierEmployeeGeneralExpensesFormUI.Tbl_BatchId = txtBatchIdGuid.Text;
            supplierEmployeeGeneralExpensesFormUI.Opt_DocumentType = Convert.ToInt32(ddlOpt_DocumentType.SelectedValue.ToString());
            supplierEmployeeGeneralExpensesFormUI.DocumentDate = Convert.ToDateTime(txtDocumentDate.Text);
            supplierEmployeeGeneralExpensesFormUI.Description = txtDescription.Text;
         
            supplierEmployeeGeneralExpensesFormUI.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text);
            supplierEmployeeGeneralExpensesFormUI.ReceivedDate = Convert.ToDateTime(txtReceivedDate.Text);
            supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeId = txtSupplierGuid.Text;
            supplierEmployeeGeneralExpensesFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            supplierEmployeeGeneralExpensesFormUI.Expenses = Convert.ToDecimal(txtExpenses.Text);
            supplierEmployeeGeneralExpensesFormUI.Opt_PayablesType = Convert.ToInt32(ddlOpt_PayablesType.SelectedValue.ToString());

            if (payablesType == bank)
            {
                supplierEmployeeGeneralExpensesFormUI.Tbl_Payables_BankTransfer = txtPayablesBankGuid.Text;
                supplierEmployeeGeneralExpensesFormUI.BankTransferAmount = Convert.ToDecimal(txtBankTransferAmount.Text);
            }
            else
            {
                supplierEmployeeGeneralExpensesFormUI.Tbl_Payables_BankTransfer = null;
                supplierEmployeeGeneralExpensesFormUI.BankTransferAmount = 0;
            }
            if (payablesType == Cash)
            {
                supplierEmployeeGeneralExpensesFormUI.Tbl_Payables_Cash = txtPayablesCashGuid.Text;
                supplierEmployeeGeneralExpensesFormUI.Cash = Convert.ToDecimal(txtCash.Text);
            }
            else
            {
                supplierEmployeeGeneralExpensesFormUI.Tbl_Payables_Cash = null;
                supplierEmployeeGeneralExpensesFormUI.Cash = 0;
            }

            if (payablesType == Cheque)
            {
                supplierEmployeeGeneralExpensesFormUI.Tbl_Payables_Cheque = txtPayablesChequeGuid.Text;
                supplierEmployeeGeneralExpensesFormUI.Cheque = Convert.ToDecimal(txtCheque.Text);
            }
            else
            {
                supplierEmployeeGeneralExpensesFormUI.Tbl_Payables_Cheque = null;
                supplierEmployeeGeneralExpensesFormUI.Cheque = 0;
            }

            if (payablesType == card)
            {
                supplierEmployeeGeneralExpensesFormUI.Tbl_Payables_CreditCard = txtPayablesCreditCardGuid.Text;
                supplierEmployeeGeneralExpensesFormUI.CreditCard = Convert.ToDecimal(txtCreditCard.Text);
            }
            else
            {
                supplierEmployeeGeneralExpensesFormUI.Tbl_Payables_CreditCard = null;
                supplierEmployeeGeneralExpensesFormUI.CreditCard = 0;
            }

            supplierEmployeeGeneralExpensesFormUI.OnAccount = Convert.ToDecimal(txtOnAmount.Text);

            if (supplierEmployeeGeneralExpensesFormBAL.UpdateSupplierEmployeeGeneralExpenses(supplierEmployeeGeneralExpensesFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_General_Expenses_SupplierEmployeeGeneralExpensesForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_General_Expenses_SupplierEmployeeGeneralExpensesForm : btnUpdate_Click] An error occured in the processing of Record Id : " + supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId + ".  Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId = Request.QueryString["SupplierEmployeeGeneralExpensesId"];

            if (supplierEmployeeGeneralExpensesFormBAL.DeleteSupplierEmployeeGeneralExpenses(supplierEmployeeGeneralExpensesFormUI) == 1)
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
            logExcpUIobj.RecordId = supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm : btnDelete_Click] An error occured in the processing of Record Id : " + supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId + ". Details : [" + exp.ToString() + "]");
        }

    }
    protected void btnPost_Click(object sender, EventArgs e)
    {
        try
        {
            bool isPosted = true;
            supplierEmployeeGeneralExpensesFormUI.ModifiedBy = SessionContext.UserGuid;
            supplierEmployeeGeneralExpensesFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId = Request.QueryString["SupplierEmployeeGeneralExpensesId"];
            supplierEmployeeGeneralExpensesFormUI.IsPosted = isPosted;

            if (supplierEmployeeGeneralExpensesFormBAL.UpdatePostingSupplierEmployeeGeneralExpenses(supplierEmployeeGeneralExpensesFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_General_Expenses_SupplierEmployeeGeneralExpensesForm.CS";
            logExcpUIobj.RecordId = supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_General_Expenses_SupplierEmployeeGeneralExpensesForm : btnPost_Click] An error occured in the processing of Record Id : " + supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId + ".  Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("SupplierEmployeeGeneralExpensesList.aspx");
    }


    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Finance/Accounts_Payable/Supplier_Employee_General_Expenses/SupplierEmployeeGeneralExpensesForm.aspx";
        string recordId = Request.QueryString["SupplierEmployeeGeneralExpensesId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    protected void ddlOpt_PayablesType_SelectedIndexChanged(object sender, EventArgs e)
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
        else if (payablesType == cash)

        {
            divCheque.Visible = false;
            divBank.Visible = false;
            divCreditCard.Visible = false;
            divCash.Visible = true;
        }
        else
        {
            divCheque.Visible = false;
            divBank.Visible = false;
            divCreditCard.Visible = false;
            divCash.Visible = false;
        }

    }

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
        else if (payablesType == cash)
        {
            divCheque.Visible = false;
            divBank.Visible = false;
            divCreditCard.Visible = false;
            divCash.Visible = true;
        }
        else {
            divCheque.Visible = false;
            divBank.Visible = false;
            divCreditCard.Visible = false;
            divCash.Visible = false;
        }
           
        {
           
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

   
    #endregion

    #region Methods

    private void GetSerialNumber(SupplierEmployeeGeneralExpensesFormUI supplierEmployeeGeneralExpensesFormUI)
    {
        try
        {
            DataTable dtb = supplierEmployeeGeneralExpensesFormBAL.GetSerialNumber(supplierEmployeeGeneralExpensesFormUI);
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm.CS";
            logExcpUIobj.RecordId = supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm : GetSerialNumber] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void BindPayablesTypeDropDownList()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_SupplierEmployeeGeneralExpenses";
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm : BindPayablesTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void BindDocumentTypeDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_SupplierEmployeeGeneralExpenses";
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

    private void FillForm(SupplierEmployeeGeneralExpensesFormUI supplierEmployeeGeneralExpensesFormUI)
    {
        try
        {
            DataTable dtb = supplierEmployeeGeneralExpensesFormBAL.GetSupplierEmployeeGeneralExpensesListById(supplierEmployeeGeneralExpensesFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtVoucherNumber.Text = dtb.Rows[0]["VoucherNumber"].ToString();
                chckInterCompany.Checked = Convert.ToBoolean(dtb.Rows[0]["InterCompany"].ToString());
                txtBatchIdGuid.Text = dtb.Rows[0]["tbl_BatchId"].ToString();
                txtBatchId.Text = dtb.Rows[0]["BatchName"].ToString();
                ddlOpt_DocumentType.SelectedValue = dtb.Rows[0]["Opt_DocumentType"].ToString();
                txtDocumentDate.Text = Convert.ToString(commonClasses.DateFormatMMDDYYY(Convert.ToDateTime(dtb.Rows[0]["DocumentDate"])));
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
               
                txtInvoiceDate.Text = Convert.ToString(commonClasses.DateFormatMMDDYYY(Convert.ToDateTime(dtb.Rows[0]["InvoiceDate"])));
                txtReceivedDate.Text = Convert.ToString(commonClasses.DateFormatMMDDYYY(Convert.ToDateTime(dtb.Rows[0]["ReceivedDate"])));
                ddlOpt_PayablesType.SelectedValue = dtb.Rows[0]["Opt_PayablesType"].ToString();
                txtSupplierGuid.Text = dtb.Rows[0]["tbl_SupplierEmployeeId"].ToString();
                txtSupplier.Text = dtb.Rows[0]["SupplierEmployeeName"].ToString();
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm.CS";
            logExcpUIobj.RecordId = supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
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

    #region Supplier Search
    private void SearchSupplierList()
    {
        try
        {
            SupplierEmployeeListUI supplierListUI = new SupplierEmployeeListUI();
            supplierListUI.Search = txtSupplierSearch.Text;
            DataTable dtb = supplierEmployeeListBAL.GetSupplierEmployeeListBySearchParameters(supplierListUI);
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
            DataTable dtb = supplierEmployeeListBAL.GetSupplierEmployeeList();
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
    #endregion

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

    

}

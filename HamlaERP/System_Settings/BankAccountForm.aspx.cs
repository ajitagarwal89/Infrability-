using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_BankAccount : System.Web.UI.Page
{

    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    CountryListBAL countryListBAL = new CountryListBAL();

    BankAccountFormBAL bankAccountFormBAL = new BankAccountFormBAL();
    BankAccountFormUI bankAccountFormUI = new BankAccountFormUI();
    BankListBAL bankListBAL = new BankListBAL();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    GLAccountListUI gLAccountListUI = new GLAccountListUI();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    CurrencyListUI currencyListUI = new CurrencyListUI();
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {

        BankAccountFormUI bankAccountExpensesFormUI = new BankAccountFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["BankAccountId"] != null)
            {
                bankAccountFormUI.Tbl_BankAccountId = Request.QueryString["BankAccountId"];

                FillForm(bankAccountFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update BankAccount";
            }
            else
            {
                

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New BankAccount";
            }
        }


    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {

            bankAccountFormUI.CreatedBy = SessionContext.UserGuid;
            bankAccountFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            bankAccountFormUI.BankAccountId = txtBankAccountId.Text;
            bankAccountFormUI.Description = txtDescription.Text;
            if (ChckIsInactive.Checked == true)
                bankAccountFormUI.IsInactive = true;
            else
                bankAccountFormUI.IsInactive = false;

            bankAccountFormUI.IBAN = txtIban.Text;
            bankAccountFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            bankAccountFormUI.CurrentChequebookBalance = Convert.ToDecimal(txtChequebookBal.Text);
            bankAccountFormUI.CashAccountBalance = Convert.ToDecimal(txtCashAccountBal.Text);
            bankAccountFormUI.Tbl_GLAccount_CashAccount = txtGLAccountGuid.Text;
            bankAccountFormUI.NextChequeNumber = Convert.ToInt64(txtNextChckNmbr.Text);
            bankAccountFormUI.NextDepositNumber = Convert.ToInt64(txtNextDepositNumber.Text);
            bankAccountFormUI.LastReconciledBalance = Convert.ToDecimal(txtlastRecounciledBal.Text);
            bankAccountFormUI.LastReconciledDate = Convert.ToDateTime(txtLastRecounciledDate.Text);
            bankAccountFormUI.AccountNumber = txtAccountNumber.Text;
            bankAccountFormUI.Tbl_BankId = txtBankGuid.Text;
            bankAccountFormUI.DuplicateChequeNumber = txtDuplicateChequeNumber.Text;
            bankAccountFormUI.OverrideChequeNumber = txtOverrideChequeNmbr.Text;

            if (bankAccountFormBAL.AddBankAccount(bankAccountFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BankAccount.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BankAccount : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        try
        {
            bankAccountFormUI.ModifiedBy = SessionContext.UserGuid;
            bankAccountFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            bankAccountFormUI.Tbl_BankAccountId = Request.QueryString["BankAccountId"];

            bankAccountFormUI.BankAccountId = txtBankAccountId.Text;
            bankAccountFormUI.Description = txtDescription.Text;
            if (ChckIsInactive.Checked == true)
                bankAccountFormUI.IsInactive = true;
            else
                bankAccountFormUI.IsInactive = false;

            bankAccountFormUI.IBAN = txtIban.Text;
            bankAccountFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            bankAccountFormUI.CurrentChequebookBalance = Convert.ToDecimal(txtChequebookBal.Text);
            bankAccountFormUI.CashAccountBalance = Convert.ToDecimal(txtCashAccountBal.Text);
            bankAccountFormUI.Tbl_GLAccount_CashAccount = txtGLAccountGuid.Text;
            bankAccountFormUI.NextChequeNumber = Convert.ToInt64(txtNextChckNmbr.Text);
            bankAccountFormUI.NextDepositNumber = Convert.ToInt64(txtNextDepositNumber.Text);
            bankAccountFormUI.LastReconciledBalance = Convert.ToDecimal(txtlastRecounciledBal.Text);
            bankAccountFormUI.LastReconciledDate = Convert.ToDateTime(txtLastRecounciledDate.Text);
            bankAccountFormUI.AccountNumber = txtAccountNumber.Text;
            bankAccountFormUI.Tbl_BankId = txtBankGuid.Text;
            bankAccountFormUI.DuplicateChequeNumber = txtDuplicateChequeNumber.Text;
            bankAccountFormUI.OverrideChequeNumber = txtOverrideChequeNmbr.Text;

            if (bankAccountFormBAL.UpdateBankAccount(bankAccountFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BankAccount.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BankAccount : btnUpdate_Click] An error occured in the processing of Record Id : " + bankAccountFormUI.Tbl_BankAccountId + ".  Details : [" + exp.ToString() + "]");
        }


    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            bankAccountFormUI.Tbl_BankAccountId = Request.QueryString["BankAccountId"];

            if (bankAccountFormBAL.DeleteBankAccount(bankAccountFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BankAccount.CS";
            logExcpUIobj.RecordId = bankAccountFormUI.Tbl_BankAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BankAccount : btnDelete_Click] An error occured in the processing of Record Id : " + bankAccountFormUI.Tbl_BankAccountId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("BankAccountList.aspx");
    }

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

    #endregion

    #region Events GL Account
    protected void btnGLAccountSearch_Click(object sender, EventArgs e)
    {
        btnHtmlGLAccountSearch.Visible = false;
        btnHtmlGLAccountClose.Visible = true;
        SearchGLAccountList();

    }
    protected void btnClearGLAccountSearch_Click(object sender, EventArgs e)
    {
        BindGLAccountList();
        gvGLAccountSearch.Visible = true;
        btnHtmlGLAccountSearch.Visible = true;
        btnHtmlGLAccountClose.Visible = false;
        txtGLAccountSearch.Text = "";
        txtGLAccountSearch.Focus();

    }
    protected void btnGLAccountRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindGLAccountList();
    }
    #endregion

    #region Bank Search
    protected void btnBankSearch_Click(object sender, EventArgs e)
    {
        btnHtmlBankSearch.Visible = false;
        btnHtmlBankClose.Visible = true;
        SearchBank();
    }
    protected void btnClearBankSearch_Click(object sender, EventArgs e)
    {
        BindBankList();
    }
    protected void btnBankRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindBankList();

    }

    #endregion

    #endregion

    #region Methods And Bind
    private void SearchGLAccountList()
    {
        try
        {
            GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtGLAccountSearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountSearch.DataSource = dtb;
                gvGLAccountSearch.DataBind();
                divGLAccountSearchError.Visible = false;
            }
            else
            {
                divGLAccountSearchError.Visible = true;
                lblGLAccountSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchGLAccountList()";
            logExcpUIobj.ResourceName = "System_Settings_BankAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BankAccount : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }


    }
    private void BindGLAccountList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountSearch.DataSource = dtb;
                gvGLAccountSearch.DataBind();
                divGLAccountSearchError.Visible = false;
            }
            else
            {
                divGLAccountSearchError.Visible = true;
                lblGLAccountSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindGLAccountList()";
            logExcpUIobj.ResourceName = "System_Settings_BankAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BankAccount : BindGLAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "System_Settings_BankAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BankAccount : SearchCurrency] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "System_Settings_BankAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[System_Settings_BankAccount : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    private void SearchBank()
    {
        try
        {
            BankListUI bankListUI = new BankListUI();
            bankListUI.Search = txtBankSearch.Text;
            DataTable dtb = bankListBAL.GetBankListBySearchParameters(bankListUI);


            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvBankSearch.DataSource = dtb;
                gvBankSearch.DataBind();
                divError.Visible = false;

            }
            else
            {
                divBankSearchError.Visible = true;
                lblBankSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvBankSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchBank()";
            logExcpUIobj.ResourceName = "System_Settings_BankAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BankAccount : SearchBank] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindBankList()
    {
        try
        {
            DataTable dtb = bankListBAL.GetBankList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvBankSearch.DataSource = dtb;
                gvBankSearch.DataBind();
                divBankSearchError.Visible = false;

            }
            else
            {
                divBankSearchError.Visible = true;
                lblBankSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvBankSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "System_Settings_BankAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[System_Settings_BankAccount : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion


    #region Methods

    private void FillForm(BankAccountFormUI bankAccountFormUI)
    {
        try
        {
            DataTable dtb = bankAccountFormBAL.GetBankAccountListById(bankAccountFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtBankAccountId.Text = dtb.Rows[0]["BankAccountId"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                ChckIsInactive.Checked = Convert.ToBoolean(dtb.Rows[0]["IsInactive"].ToString());
                txtIban.Text= dtb.Rows[0]["IBAN"].ToString();
                txtCurrencyGuid.Text = dtb.Rows[0]["tbl_CurrencyId"].ToString();
                txtCurrency.Text= dtb.Rows[0]["CurrencyName"].ToString();
                txtChequebookBal.Text= dtb.Rows[0]["CurrentChequebookBalance"].ToString();
                txtCashAccountBal.Text= dtb.Rows[0]["CashAccountBalance"].ToString();
                txtGLAccountGuid.Text= dtb.Rows[0]["tbl_GLAccount_CashAccount"].ToString();
                txtGLAccount.Text= dtb.Rows[0]["tbl_GLAccount"].ToString();
                txtNextChckNmbr.Text= dtb.Rows[0]["NextChequeNumber"].ToString();
                txtNextDepositNumber.Text= dtb.Rows[0]["NextDepositNumber"].ToString();
                txtlastRecounciledBal.Text= dtb.Rows[0]["LastReconciledBalance"].ToString();
                //txtLastRecounciledDate.Text=dtb.Rows[0]["LastReconciledDate"].ToString();
                txtAccountNumber.Text = dtb.Rows[0]["AccountNumber"].ToString();
                txtBankGuid.Text= dtb.Rows[0]["tbl_BankId"].ToString();
                txtBank.Text= dtb.Rows[0]["BankName"].ToString();
                txtDuplicateChequeNumber.Text = dtb.Rows[0]["DuplicateChequeNumber"].ToString();
                txtOverrideChequeNmbr.Text= dtb.Rows[0]["OverrideChequeNumber"].ToString();
            }
            else
            {
                
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotLoadData;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "FillForm()";
            logExcpUIobj.ResourceName = "System_Settings_BankAccount.CS";
            logExcpUIobj.RecordId = bankAccountFormUI.Tbl_BankAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BankAccount : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }



    #endregion


}

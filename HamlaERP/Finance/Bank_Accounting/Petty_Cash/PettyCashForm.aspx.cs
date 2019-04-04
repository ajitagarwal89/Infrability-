using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Bank_Accounting_Petty_Cash_PettyCashForm : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    PettyCashFormBAL pettyCashFormBAL = new PettyCashFormBAL();
    PettyCashFormUI pettyCashFormUI = new PettyCashFormUI();
    PettyCashListBAL pettyCashListBAL = new PettyCashListBAL();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    CurrencyListUI currencyListUI = new CurrencyListUI();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();


    CommonDateClasses commonDateClasses = new CommonDateClasses();
    #endregion Data Members

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        PettyCashFormUI pettyCashFormUI = new PettyCashFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["PettyCashId"] != null || Request.QueryString["recordId"] != null)
            {
                pettyCashFormUI.Tbl_PettyCashId = (Request.QueryString["PettyCashId"] != null ? Request.QueryString["PettyCashId"] : Request.QueryString["recordId"]);


                FillForm(pettyCashFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnAuditHistory.Visible = true;
                lblHeading.Text = "Update Petty Cash";
            }
            else
            {

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New Petty Cash";
            }
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            pettyCashFormUI.CreatedBy = SessionContext.UserGuid;
            pettyCashFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            pettyCashFormUI.PettyCashId = txtPettyCashId.Text;
            pettyCashFormUI.Description = txtDescription.Text;
            if (chckIsInactive.Checked==true)
            {
                pettyCashFormUI.IsInactive = true;
            }
            else
            {
                pettyCashFormUI.IsInactive = false;
            }
            pettyCashFormUI.IBAN = txtIBAN.Text;
            pettyCashFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            pettyCashFormUI.CurrentPettyCashBalance = Convert.ToDecimal(txtCurrentPettyCashBal.Text);
            pettyCashFormUI.CashAccountBalance = Convert.ToDecimal(txtCashAccountBal.Text);
            pettyCashFormUI.Tbl_GLAccount_CashAccount = txtGLAccountGuid.Text;
            pettyCashFormUI.NextPettyCashNumber = Convert.ToInt64(txtNextPettyCashNumber.Text);
            pettyCashFormUI.NextDepositNumber = Convert.ToInt64(txtNextDepositNumber.Text);
            pettyCashFormUI.AccountNumber = txtAccountNumber.Text;
            pettyCashFormUI.DuplicateChequeNumber = txtDuplicateChequeuNo.Text;
            pettyCashFormUI.OverrideChequeNumber = txtOverrideChequeNumber.Text;

           
            if (pettyCashFormBAL.AddPettyCash(pettyCashFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Petty_Cash_PettyCashForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Petty_Cash_PettyCashForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            pettyCashFormUI.ModifiedBy = SessionContext.UserGuid;
            pettyCashFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            pettyCashFormUI.Tbl_PettyCashId = Request.QueryString["PettyCashId"];

            pettyCashFormUI.PettyCashId = txtPettyCashId.Text;
            pettyCashFormUI.Description = txtDescription.Text;
            if (chckIsInactive.Checked == true)
            {
                pettyCashFormUI.IsInactive = true;
            }
            else
            {
                pettyCashFormUI.IsInactive = false;
            }
            pettyCashFormUI.IBAN = txtIBAN.Text;
            pettyCashFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            pettyCashFormUI.CurrentPettyCashBalance = Convert.ToDecimal(txtCurrentPettyCashBal.Text);
            pettyCashFormUI.CashAccountBalance = Convert.ToDecimal(txtCashAccountBal.Text);
            pettyCashFormUI.Tbl_GLAccount_CashAccount = txtGLAccountGuid.Text;
            pettyCashFormUI.NextPettyCashNumber = Convert.ToInt64(txtNextPettyCashNumber.Text);
            pettyCashFormUI.NextDepositNumber = Convert.ToInt64(txtNextDepositNumber.Text);
            pettyCashFormUI.AccountNumber = txtAccountNumber.Text;
            pettyCashFormUI.DuplicateChequeNumber = txtDuplicateChequeuNo.Text;
            pettyCashFormUI.OverrideChequeNumber = txtOverrideChequeNumber.Text;


            if (pettyCashFormBAL.UpdatePettyCash(pettyCashFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Petty_Cash_PettyCashForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Petty_Cash_PettyCashForm : btnUpdate_Click] An error occured in the processing of Record Id : " + pettyCashFormUI.Tbl_PettyCashId + ".  Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            pettyCashFormUI.Tbl_PettyCashId = Request.QueryString["PettyCashId"];

            if (pettyCashFormBAL.DeletePettyCash(pettyCashFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Petty_Cash_PettyCashForm.CS";
            logExcpUIobj.RecordId = pettyCashFormUI.Tbl_PettyCashId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Petty_Cash_PettyCashForm : btnDelete_Click] An error occured in the processing of Record Id : " + pettyCashFormUI.Tbl_PettyCashId + ". Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PettyCashList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Finance/Bank_Accounting/Petty_Cash/PettyCashForm.aspx";
        string recordId = Request.QueryString["PettyCashId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
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

    #endregion Currency Search

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

    #endregion

    #region Methods

    private void FillForm(PettyCashFormUI pettyCashFormUI)
    {
        try
        {
            DataTable dtb = pettyCashFormBAL.GetPettyCashListById(pettyCashFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtPettyCashId.Text= dtb.Rows[0]["PettyCashId"].ToString();
                txtDescription.Text= dtb.Rows[0]["Description"].ToString();         
                chckIsInactive.Checked = Convert.ToBoolean(dtb.Rows[0]["IsInactive"].ToString());
                txtIBAN.Text= dtb.Rows[0]["IBAN"].ToString();
                txtCurrencyGuid.Text= dtb.Rows[0]["tbl_CurrencyId"].ToString();
                txtCurrency.Text = dtb.Rows[0]["CurrencyName"].ToString();
                txtCurrentPettyCashBal.Text= dtb.Rows[0]["CurrentPettyCashBalance"].ToString();
                txtCashAccountBal.Text= dtb.Rows[0]["CashAccountBalance"].ToString();
                txtGLAccountGuid.Text= dtb.Rows[0]["tbl_GLAccount_CashAccount"].ToString();
                txtGLAccount.Text = dtb.Rows[0]["CashAccount"].ToString();
                txtNextPettyCashNumber.Text= dtb.Rows[0]["NextPettyCashNumber"].ToString();
                txtNextDepositNumber.Text = dtb.Rows[0]["NextDepositNumber"].ToString();
                txtAccountNumber.Text = dtb.Rows[0]["AccountNumber"].ToString();
                txtDuplicateChequeuNo.Text= dtb.Rows[0]["DuplicateChequeNumber"].ToString();
                txtOverrideChequeNumber.Text= dtb.Rows[0]["OverrideChequeNumber"].ToString();

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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Petty_Cash_PettyCashForm.CS";
            logExcpUIobj.RecordId = pettyCashFormUI.Tbl_PettyCashId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Petty_Cash_PettyCashForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }


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

    #region Gl Account
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Petty_Cash_PettyCashForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Petty_Cash_PettyCashForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Petty_Cash_PettyCashForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Petty_Cash_PettyCashForm : BindGLAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion

    #endregion

}
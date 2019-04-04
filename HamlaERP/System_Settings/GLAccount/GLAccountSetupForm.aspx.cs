using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;


public partial class System_Settings_GLAccountSetupForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    GLAccountListUI gLAccountListUI = new GLAccountListUI();
    GLAccountSetupFormBAL gLAccountSetupFormBAL = new GLAccountSetupFormBAL();
    GLAccountSetupFormUI gLAccountSetupFormUI = new GLAccountSetupFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();

    #endregion Data Members
    #region Events
    protected override void  Page_Load(object sender, EventArgs e)
    {
        GLAccountSetupFormUI gLAccountSetupFormUI = new GLAccountSetupFormUI();


        if (!Page.IsPostBack)
        {
          
            if (Request.QueryString["GLAccountSetupId"] != null || Request.QueryString["recordId"] != null)
            {
                gLAccountSetupFormUI.Tbl_GLAccountSetupId = (Request.QueryString["GLAccountSetupId"] != null ? Request.QueryString["GLAccountSetupId"] : Request.QueryString["recordId"]);
                FillForm(gLAccountSetupFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update GLAccountSetup";
            }
            else
            {


                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New GLAccountSetup";
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            gLAccountSetupFormUI.CreatedBy = SessionContext.UserGuid;
            gLAccountSetupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            if (chkDisplay.Checked)
            { gLAccountSetupFormUI.Display = true; }
            else {
                gLAccountSetupFormUI.Display = false;
            }
         
         
            gLAccountSetupFormUI.Tbl_GLAccountId_Account = txtGLAccountId_AccountGuid.Text;

            if (chkAccounts.Checked)
            {
                gLAccountSetupFormUI.Accounts = true;
            }
            else {
                gLAccountSetupFormUI.Accounts = false;
            }

            if (chkTransactions.Checked)
            {
                gLAccountSetupFormUI.Transactions = true;
            }
            else
            {
                gLAccountSetupFormUI.Transactions = false;
            }

            if (chkPostingToHistory.Checked)
            {
                gLAccountSetupFormUI.PostingToHistory = true;
            }
            else
            {
                gLAccountSetupFormUI.PostingToHistory = false;
            }
            if (chkDeletionOfSavedTransactions.Checked)
            {
                gLAccountSetupFormUI.DeletionOfSavedTransactions = true;
            }
            else
            {
                gLAccountSetupFormUI.DeletionOfSavedTransactions = false;
            }


            if (gLAccountSetupFormBAL.AddGLAccountSetup(gLAccountSetupFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_GLAccountSetupForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountSetupForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            gLAccountSetupFormUI.ModifiedBy = SessionContext.UserGuid;
            gLAccountSetupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            gLAccountSetupFormUI.Tbl_GLAccountSetupId = Request.QueryString["GLAccountSetupId"];
            if (chkDisplay.Checked)
            { gLAccountSetupFormUI.Display = true; }
            else
            {
                gLAccountSetupFormUI.Display = false;
            }
          
            gLAccountSetupFormUI.Tbl_GLAccountId_Account = txtGLAccountId_AccountGuid.Text;

            if (chkAccounts.Checked)
            {
                gLAccountSetupFormUI.Accounts = true;
            }
            else
            {
                gLAccountSetupFormUI.Accounts = false;
            }

            if (chkTransactions.Checked)
            {
                gLAccountSetupFormUI.Transactions = true;
            }
            else
            {
                gLAccountSetupFormUI.Transactions = false;
            }

            if (chkPostingToHistory.Checked)
            {
                gLAccountSetupFormUI.PostingToHistory = true;
            }
            else
            {
                gLAccountSetupFormUI.PostingToHistory = false;
            }
            if (chkDeletionOfSavedTransactions.Checked)
            {
                gLAccountSetupFormUI.DeletionOfSavedTransactions = true;
            }
            else
            {
                gLAccountSetupFormUI.DeletionOfSavedTransactions = false;
            }




            if (gLAccountSetupFormBAL.UpdateGLAccountSetup(gLAccountSetupFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_GLAccountSetupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountSetupForm : btnUpdate_Click] An error occured in the processing of Record Id : " + gLAccountSetupFormUI.Tbl_GLAccountSetupId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            gLAccountSetupFormUI.Tbl_GLAccountSetupId = Request.QueryString["GLAccountSetupId"];

            if (gLAccountSetupFormBAL.DeleteGLAccountSetup(gLAccountSetupFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_GLAccountSetupForm.CS";
            logExcpUIobj.RecordId = gLAccountSetupFormUI.Tbl_GLAccountSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountSetupForm : btnDelete_Click] An error occured in the processing of Record Id : " + gLAccountSetupFormUI.Tbl_GLAccountSetupId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("GLAccountSetupList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/System_Settings/GLAccountSetupForm.aspx";
        string recordId = Request.QueryString["GLAccountSetupId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }
    #region GLAccountId_Account

    protected void btnGLAccountId_AccountSearch_Click(object sender, EventArgs e)
    {
        btnHtmlGLAccountId_AccountSearch.Visible = false;
        btnHtmlGLAccountId_AccountClose.Visible = true;
        SearchGLAccountId_AccountList();

    }
    protected void btnClearGLAccountId_AccountSearch_Click(object sender, EventArgs e)
    {
        BindGLAccountId_AccountList();
        gvGLAccountId_AccountSearch.Visible = true;
        btnHtmlGLAccountId_AccountSearch.Visible = true;
        btnHtmlGLAccountId_AccountClose.Visible = false;
        txtGLAccountId_AccountSearch.Text = "";
        txtGLAccountId_AccountSearch.Focus();

    }
    protected void btnGLAccountId_AccountRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindGLAccountId_AccountList();
    }

    #endregion


    #endregion Events
    #region Method
    private void FillForm(GLAccountSetupFormUI gLAccountSetupFormUI)
    {
        try
        {
            DataTable dtb = gLAccountSetupFormBAL.GetGLAccountSetupListById(gLAccountSetupFormUI);

            if (dtb.Rows.Count > 0)
            {

                if (Convert.ToBoolean(dtb.Rows[0]["Display"]) == true)
                {
                    chkDisplay.Checked = true; 
                }
                else {
                    chkDisplay.Checked = false;
                }

            
                txtGLAccountId_AccountGuid.Text = dtb.Rows[0]["tbl_GLAccountId_Account"].ToString();
                txtGLAccountId_Account.Text = dtb.Rows[0]["GLAccountId_Account"].ToString();

                if (Convert.ToBoolean(dtb.Rows[0]["Accounts"]) == true)
                {
                    chkAccounts.Checked = true;
                }
                else
                {
                    chkAccounts.Checked = false;
                }
                if (Convert.ToBoolean(dtb.Rows[0]["Transactions"]) == true)
                {
                    chkTransactions.Checked = true;
                }
                else
                {
                    chkTransactions.Checked = false;
                }
                if (Convert.ToBoolean(dtb.Rows[0]["PostingToHistory"]) == true)
                {
                    chkPostingToHistory.Checked = true;
                }
                else
                {
                    chkPostingToHistory.Checked = false;
                }
                if (Convert.ToBoolean(dtb.Rows[0]["DeletionOfSavedTransactions"]) == true)
                {
                    chkDeletionOfSavedTransactions.Checked = true;
                }
                else
                {
                    chkDeletionOfSavedTransactions.Checked = false;
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
            logExcpUIobj.ResourceName = "System_Settings_GLAccountSetupForm.CS";
            logExcpUIobj.RecordId = gLAccountSetupFormUI.Tbl_GLAccountSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountSetupForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void SearchGLAccountId_AccountList()
    {
        try
        {
            GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtGLAccountId_AccountSearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountId_AccountSearch.DataSource = dtb;
                gvGLAccountId_AccountSearch.DataBind();
                divGLAccountId_AccountSearchError.Visible = false;
            }
            else
            {
                divGLAccountId_AccountSearchError.Visible = true;
                lblGLAccountId_AccountSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountId_AccountSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchGLAccountId_CashList()";
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountSummaryForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountSummaryForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }


    }
    private void BindGLAccountId_AccountList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountId_AccountSearch.DataSource = dtb;
                gvGLAccountId_AccountSearch.DataBind();
                divGLAccountId_AccountSearchError.Visible = false;
            }
            else
            {
                divGLAccountId_AccountSearchError.Visible = true;
                lblGLAccountId_AccountSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountId_AccountSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindGLAccountId_AccountList()";
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountSummaryForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountSummaryForm : BindGLAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }


    #endregion Method
}

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;
public partial class System_Settings_GLAccountEntryDetailsForm : System.Web.UI.Page
{

    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    GLAccountEntryDetailsFormBAL gLAccountEntryDetailsFormBAL = new GLAccountEntryDetailsFormBAL();
    GLAccountEntryDetailsFormUI gLAccountEntryDetailsFormUI = new GLAccountEntryDetailsFormUI();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    GLAccountEntryListBAL gLAccountEntryListBAL = new GLAccountEntryListBAL();
    #endregion Data Members

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        GLAccountEntryDetailsFormUI gLAccountEntryDetailsFormUI = new GLAccountEntryDetailsFormUI();
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["GLAccountEntryDetailsId"] != null)
            {
                gLAccountEntryDetailsFormUI.Tbl_GLAccountEntryDetailsId = Request.QueryString["GLAccountEntryDetailsId"];
                FillForm(gLAccountEntryDetailsFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update GLAccount Entry Details";
            }

            else
            {

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New GLAccount Entry Details";
            }

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            gLAccountEntryDetailsFormUI.CreatedBy = SessionContext.UserGuid;
            gLAccountEntryDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            gLAccountEntryDetailsFormUI.Tbl_GLAccountEntryId = txtGLAccountEntryGuid.Text;
            gLAccountEntryDetailsFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text;

            gLAccountEntryDetailsFormUI.Debit = Convert.ToDecimal(txtDebit.Text.ToString());
            gLAccountEntryDetailsFormUI.Credit = Convert.ToDecimal(txtCredit.Text.ToString());

            if (gLAccountEntryDetailsFormBAL.AddGLAccountEntryDetails(gLAccountEntryDetailsFormUI) == 1)
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
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "System_Settings_BudgetForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountEntryDetailsForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            gLAccountEntryDetailsFormUI.ModifiedBy = SessionContext.UserGuid;
            gLAccountEntryDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            gLAccountEntryDetailsFormUI.Tbl_GLAccountEntryDetailsId = Request.QueryString["GLAccountEntryDetailsId"];
            gLAccountEntryDetailsFormUI.Tbl_GLAccountEntryId = txtGLAccountEntryGuid.Text;
            gLAccountEntryDetailsFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text;
            gLAccountEntryDetailsFormUI.Debit = Convert.ToDecimal(txtDebit.Text.ToString());
            gLAccountEntryDetailsFormUI.Credit = Convert.ToDecimal(txtCredit.Text.ToString());


            if (gLAccountEntryDetailsFormBAL.UpdateGLAccountEntryDetails(gLAccountEntryDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BudgetForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountEntryDetailsForm : btnUpdate_Click] An error occured in the processing of Record Id : " + gLAccountEntryDetailsFormUI.Tbl_GLAccountEntryDetailsId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            gLAccountEntryDetailsFormUI.Tbl_GLAccountEntryDetailsId = Request.QueryString["GLAccountEntryDetailsId"];

            if (gLAccountEntryDetailsFormBAL.DeleteGLAccountEntryDetails(gLAccountEntryDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BudgetForm.CS";
            logExcpUIobj.RecordId = gLAccountEntryDetailsFormUI.Tbl_GLAccountEntryDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountEntryDetailsForm : btnDelete_Click] An error occured in the processing of Record Id : " + gLAccountEntryDetailsFormUI.Tbl_GLAccountEntryDetailsId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("GLAccountEntryDetailsList.aspx");
    }



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

    #region Account Entry
    protected void btnGLAccountEntrySearch_Click(object sender, EventArgs e)
    {
        btnHtmlGLAccountEntrySearch.Visible = false;
        btnHtmlGLAccountEntryClose.Visible = true;
        SearchGLAccountEntryList();
    }
    protected void btnClearGLAccountEntrySearch_Click(object sender, EventArgs e)
    {
        BindGLAccountEntryList();
        gvGLAccountEntrySearch.Visible = true;
        btnHtmlGLAccountEntrySearch.Visible = true;
        btnHtmlGLAccountEntryClose.Visible = false;
        txtGLAccountEntrySearch.Text = "";
        txtGLAccountEntrySearch.Focus();
    }
    protected void btnGLAccountEntryRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindGLAccountEntryList();
    }
    #endregion AccountEntry

    #endregion Event


    #region Methods Search And Bind
    #region GlAccount
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountSummaryForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountSummaryForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountSummaryForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountSummaryForm : BindGLAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion

    #region Account Entry

    private void SearchGLAccountEntryList()
    {
        try
        {
            GLAccountEntryListUI gLAccountEntryListUI = new GLAccountEntryListUI();
            gLAccountEntryListUI.Search = txtGLAccountEntrySearch.Text;

            DataTable dtb = gLAccountEntryListBAL.GetGLAccountEntryListBySearchParameters(gLAccountEntryListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountEntrySearch.DataSource = dtb;
                gvGLAccountEntrySearch.DataBind();
                divGLAccountEntrySearchError.Visible = false;
            }
            else
            {
                divGLAccountEntrySearchError.Visible = true;
                lblGLAccountEntrySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountEntrySearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchGLAccountEntryList()";
            logExcpUIobj.ResourceName = "System_Settings_GLAccountEntryForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountEntryForm : SearchGLAccountEntryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }


    private void BindGLAccountEntryList()
    {
        try
        {
            DataTable dtb = gLAccountEntryListBAL.GetGLAccountEntryList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountEntrySearch.DataSource = dtb;
                gvGLAccountEntrySearch.DataBind();
                divGLAccountEntrySearchError.Visible = false;

            }
            else
            {
                divGLAccountEntrySearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountEntrySearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindGLAccountEntryhList()";
            logExcpUIobj.ResourceName = "System_Settings_GLAccountEntryForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountEntryForm : BindGLAccountEntryhList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }


    #endregion Account Entry


    private void FillForm(GLAccountEntryDetailsFormUI gLAccountEntryDetailsFormUI)
    {
        try
        {

            DataTable dtb = gLAccountEntryDetailsFormBAL.GetGLAccountEntryDetailsListById(gLAccountEntryDetailsFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtGLAccountEntry.Text = dtb.Rows[0]["tbl_GLAccountEntry"].ToString();
                txtGLAccountEntryGuid.Text = dtb.Rows[0]["tbl_GLAccountEntryId"].ToString();
                txtGLAccount.Text = dtb.Rows[0]["AccountNumber"].ToString();
                txtGLAccountGuid.Text = dtb.Rows[0]["tbl_GLAccount"].ToString();
                txtDebit.Text = dtb.Rows[0]["Debit"].ToString();
                txtCredit.Text = dtb.Rows[0]["Credit"].ToString();

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
            logExcpUIobj.ResourceName = "System_Settings_GLAccountEntryForm.CS";
            logExcpUIobj.RecordId = gLAccountEntryDetailsFormUI.Tbl_GLAccountEntryDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountEntryDetailsForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion

}
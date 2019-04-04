using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;
public partial class System_Settings_GeneralJournalDetailsForm : PageBase
{

    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    GeneralJournalDetailsFormBAL generalJournalDetailsFormBAL = new GeneralJournalDetailsFormBAL();
    GeneralJournalDetailsFormUI generalJournalDetailsFormUI = new GeneralJournalDetailsFormUI();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    GeneralJournalListBAL generalJournalListBAL = new GeneralJournalListBAL();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        GeneralJournalDetailsFormUI generalJournalDetailsFormUI = new GeneralJournalDetailsFormUI();
        if (!Page.IsPostBack)
        {


            if (Request.QueryString["GeneralJournalDetailsId"] != null || Request.QueryString["recordId"] != null)
            {
                   generalJournalDetailsFormUI.Tbl_GeneralJournalDetailsId = (Request.QueryString["GeneralJournalDetailsId"] != null ? Request.QueryString["GeneralJournalDetailsId"] : Request.QueryString["recordId"]);
                FillForm(generalJournalDetailsFormUI);
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
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New GLAccount Entry Details";
            }

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            generalJournalDetailsFormUI.CreatedBy = SessionContext.UserGuid;
            generalJournalDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            generalJournalDetailsFormUI.Tbl_GeneralJournalId = txtGeneralJournalGuid.Text;
            generalJournalDetailsFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text;

            generalJournalDetailsFormUI.Debit = Convert.ToDecimal(txtDebit.Text.ToString());
            generalJournalDetailsFormUI.Credit = Convert.ToDecimal(txtCredit.Text.ToString());

            if (generalJournalDetailsFormBAL.AddGeneralJournalDetails(generalJournalDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalDetailsForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalDetailsForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            generalJournalDetailsFormUI.ModifiedBy = SessionContext.UserGuid;
            generalJournalDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            generalJournalDetailsFormUI.Tbl_GeneralJournalDetailsId = Request.QueryString["GeneralJournalDetailsId"];
            generalJournalDetailsFormUI.Tbl_GeneralJournalId = txtGeneralJournalGuid.Text;
            generalJournalDetailsFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text;
            generalJournalDetailsFormUI.Debit = Convert.ToDecimal(txtDebit.Text.ToString());
            generalJournalDetailsFormUI.Credit = Convert.ToDecimal(txtCredit.Text.ToString());

            if (generalJournalDetailsFormBAL.UpdateGeneralJournalDetails(generalJournalDetailsFormUI) == 1)
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
              //  this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalDetailsForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalDetailsForm : btnUpdate_Click] An error occured in the processing of Record Id : " + generalJournalDetailsFormUI.Tbl_GeneralJournalDetailsId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            generalJournalDetailsFormUI.Tbl_GeneralJournalDetailsId = Request.QueryString["GeneralJournalDetailsId"];

            if (generalJournalDetailsFormBAL.DeleteGeneralJournalDetails(generalJournalDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalDetailsForm.CS";
            logExcpUIobj.RecordId = generalJournalDetailsFormUI.Tbl_GeneralJournalDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalDetailsForm : btnDelete_Click] An error occured in the processing of Record Id : " + generalJournalDetailsFormUI.Tbl_GeneralJournalDetailsId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("GeneralJournalDetailsList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/System_Settings/GeneralJournalDetailsForm.aspx";
        string recordId = Request.QueryString["GeneralJournalDetailsId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
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
    protected void btnGeneralJournalSearch_Click(object sender, EventArgs e)
    {
        btnHtmlGeneralJournalSearch.Visible = false;
        btnHtmlGeneralJournalClose.Visible = true;
        SearchGeneralJournalList();
    }
    protected void btnClearGeneralJournalSearch_Click(object sender, EventArgs e)
    {
        BindGeneralJournalList();
        gvGeneralJournalSearch.Visible = true;
        btnHtmlGeneralJournalSearch.Visible = true;
        btnHtmlGeneralJournalClose.Visible = false;
        txtGeneralJournalSearch.Text = "";
        txtGeneralJournalSearch.Focus();
    }
    protected void btnGeneralJournalRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindGeneralJournalList();
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

    private void SearchGeneralJournalList()
    {
        try
        {
            GeneralJournalListUI generalJournalListUI = new GeneralJournalListUI();
            generalJournalListUI.Search = txtGeneralJournalSearch.Text;

            DataTable dtb = generalJournalListBAL.GetGeneralJournalListBySearchParameters(generalJournalListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGeneralJournalSearch.DataSource = dtb;
                gvGeneralJournalSearch.DataBind();
                divGeneralJournalSearchError.Visible = false;
            }
            else
            {
                divGeneralJournalSearchError.Visible = true;
                lblGeneralJournalSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGeneralJournalSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchGeneralJournalList()";
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalForm : SearchGeneralJournalList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }


    private void BindGeneralJournalList()
    {
        try
        {
            DataTable dtb = generalJournalListBAL.GetGeneralJournalList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGeneralJournalSearch.DataSource = dtb;
                gvGeneralJournalSearch.DataBind();
                divGeneralJournalSearchError.Visible = false;

            }
            else
            {
                divGeneralJournalSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGeneralJournalSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindGeneralJournalList()";
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalForm : BindGeneralJournalList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }


    #endregion Account Entry


    private void FillForm(GeneralJournalDetailsFormUI generalJournalDetailsFormUI)
    {
        try
        {

            DataTable dtb = generalJournalDetailsFormBAL.GetGeneralJournalDetailsListById(generalJournalDetailsFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtGeneralJournal.Text = dtb.Rows[0]["tbl_GeneralJournal"].ToString();
                txtGeneralJournalGuid.Text = dtb.Rows[0]["tbl_GeneralJournalId"].ToString();
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
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalDetailsForm.CS";
            logExcpUIobj.RecordId = generalJournalDetailsFormUI.Tbl_GeneralJournalDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalDetailsForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion

}
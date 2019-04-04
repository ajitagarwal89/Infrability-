using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_General_Ledger_GLAccountConfigurationSettings_GLAccountConfigurationSettingsForm : PageBase
{

    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    GLAccountConfigurationSettingsFormBAL gLAccountConfigurationSettingsFormBAL = new GLAccountConfigurationSettingsFormBAL();
    GLAccountConfigurationSettingsFormUI gLAccountConfigurationSettingsFormUI = new GLAccountConfigurationSettingsFormUI();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    GLAccountListUI gLAccountListUI = new GLAccountListUI();
   
    #endregion Data Members
    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        GLAccountConfigurationSettingsFormUI gLAccountConfigurationSettingsFormUI = new GLAccountConfigurationSettingsFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["GLAccountConfigurationSettingsId"] != null || Request.QueryString["recordId"] != null)
            {
                gLAccountConfigurationSettingsFormUI.Tbl_GLAccountConfigurationSettingsId = (Request.QueryString["GLAccountConfigurationSettingsId"] != null ? Request.QueryString["GLAccountConfigurationSettingsId"] : Request.QueryString["recordId"]);


                FillForm(gLAccountConfigurationSettingsFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnAuditHistory.Visible = true;
                lblHeading.Text = "Update GLAccount Configuration Settings";
            }
            else
            {
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New GLAccount Configuration Settings";
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            gLAccountConfigurationSettingsFormUI.CreatedBy = SessionContext.UserGuid;
            gLAccountConfigurationSettingsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            gLAccountConfigurationSettingsFormUI.Tbl_GLAccountId_RetainedEarning = txtGLAccountRetainedEarningGuid.Text;
            if (chkPostingToHistory.Checked)
            {
                gLAccountConfigurationSettingsFormUI.PostingToHistory = true;
            }
            else
            {
                gLAccountConfigurationSettingsFormUI.PostingToHistory = false;
            }
            if (chkDeletionOfSavedTransaction.Checked)
            {
                gLAccountConfigurationSettingsFormUI.DeletionOfSavedTransaction = true;
            }
            else
            {
                gLAccountConfigurationSettingsFormUI.DeletionOfSavedTransaction = false;
            }

           if (gLAccountConfigurationSettingsFormBAL.AddGLAccountConfigurationSettings(gLAccountConfigurationSettingsFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {

                divError.Visible = true;
                divSuccess.Visible = false;
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GLAccountConfigurationSettings_GLAccountConfigurationSettingsForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GLAccountConfigurationSettings_GLAccountConfigurationSettingsForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            gLAccountConfigurationSettingsFormUI.ModifiedBy = SessionContext.UserGuid;
            gLAccountConfigurationSettingsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            gLAccountConfigurationSettingsFormUI.Tbl_GLAccountConfigurationSettingsId = Request.QueryString["GLAccountConfigurationSettingsId"];

            gLAccountConfigurationSettingsFormUI.Tbl_GLAccountId_RetainedEarning = txtGLAccountRetainedEarningGuid.Text;
            if (chkPostingToHistory.Checked)
            {
                gLAccountConfigurationSettingsFormUI.PostingToHistory = true;
            }
            else
            {
                gLAccountConfigurationSettingsFormUI.PostingToHistory = false;
            }
            if (chkDeletionOfSavedTransaction.Checked)
            {
                gLAccountConfigurationSettingsFormUI.DeletionOfSavedTransaction = true;
            }
            else
            {
                gLAccountConfigurationSettingsFormUI.DeletionOfSavedTransaction = false;
            }


            if (gLAccountConfigurationSettingsFormBAL.UpdateGLAccountConfigurationSettings(gLAccountConfigurationSettingsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GLAccountConfigurationSettings_GLAccountConfigurationSettingsForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GLAccountConfigurationSettings_GLAccountConfigurationSettingsForm : btnUpdate_Click] An error occured in the processing of Record Id : " + gLAccountConfigurationSettingsFormUI.Tbl_GLAccountConfigurationSettingsId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            gLAccountConfigurationSettingsFormUI.Tbl_GLAccountConfigurationSettingsId = Request.QueryString["GLAccountConfigurationSettingsId"];

            if (gLAccountConfigurationSettingsFormBAL.DeleteGLAccountConfigurationSettings(gLAccountConfigurationSettingsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GLAccountConfigurationSettings_GLAccountConfigurationSettingsForm.CS";
            logExcpUIobj.RecordId = gLAccountConfigurationSettingsFormUI.Tbl_GLAccountConfigurationSettingsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GLAccountConfigurationSettings_GLAccountConfigurationSettingsForm : btnDelete_Click] An error occured in the processing of Record Id : " + gLAccountConfigurationSettingsFormUI.Tbl_GLAccountConfigurationSettingsId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("GLAccountConfigurationSettingsList.aspx");
    }
    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/GLAccountConfigurationSettings/GLAccountConfigurationSettingsForm.aspx";
        string recordId = Request.QueryString["GLAccountConfigurationSettingsId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    #region Events GLAccountRetainedEarning
    protected void btnGLAccountRetainedEarningSearch_Click(object sender, EventArgs e)
    {
        btnHtmlGLAccountRetainedEarningSearch.Visible = false;
        btnHtmlGLAccountRetainedEarningClose.Visible = true;
        SearchGLAccountRetainedEarningList();

    }
    protected void btnClearGLAccountRetainedEarningSearch_Click(object sender, EventArgs e)
    {
        BindGLAccountRetainedEarningList();
        gvGLAccountRetainedEarningSearch.Visible = true;
        btnHtmlGLAccountRetainedEarningSearch.Visible = true;
        btnHtmlGLAccountRetainedEarningClose.Visible = false;
        txtGLAccountRetainedEarningSearch.Text = "";
        txtGLAccountRetainedEarningSearch.Focus();

    }
    protected void btnGLAccountRetainedEarningRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindGLAccountRetainedEarningList();
    }
    #endregion
    #endregion
    #region Methods
    private void SearchGLAccountRetainedEarningList()
    {
        try
        {
            GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtGLAccountRetainedEarningSearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountRetainedEarningSearch.DataSource = dtb;
                gvGLAccountRetainedEarningSearch.DataBind();
                divGLAccountRetainedEarningSearchError.Visible = false;
            }
            else
            {
                divGLAccountRetainedEarningSearchError.Visible = true;
                lblGLAccountRetainedEarningSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountRetainedEarningSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchGLAccountList()";
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GLAccountConfigurationSettings_GLAccountConfigurationSettingsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GLAccountConfigurationSettings_GLAccountConfigurationSettingsForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }


    }
    private void BindGLAccountRetainedEarningList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountRetainedEarningSearch.DataSource = dtb;
                gvGLAccountRetainedEarningSearch.DataBind();
                divGLAccountRetainedEarningSearchError.Visible = false;
            }
            else
            {
                divGLAccountRetainedEarningSearchError.Visible = true;
                lblGLAccountRetainedEarningSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountRetainedEarningSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindGLAccountList()";
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GLAccountConfigurationSettings_GLAccountConfigurationSettingsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GLAccountConfigurationSettings_GLAccountConfigurationSettingsForm : BindGLAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
      

    private void FillForm(GLAccountConfigurationSettingsFormUI gLAccountConfigurationSettingsFormUI)
    {
        try
        {
            DataTable dtb = gLAccountConfigurationSettingsFormBAL.GetGLAccountConfigurationSettingsListById(gLAccountConfigurationSettingsFormUI);

            if (dtb.Rows.Count > 0)
            {

                txtGLAccountRetainedEarningGuid.Text = dtb.Rows[0]["tbl_GLAccountId_RetainedEarning"].ToString();
                txtGLAccountRetainedEarning.Text = dtb.Rows[0]["RetainedEarning"].ToString();
                chkPostingToHistory.Checked=Convert.ToBoolean(dtb.Rows[0]["PostingToHistory"].ToString());
                chkDeletionOfSavedTransaction.Checked=Convert.ToBoolean(dtb.Rows[0]["DeletionOfSavedTransaction"].ToString());
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GLAccountConfigurationSettings_GLAccountConfigurationSettingsForm.CS";
            logExcpUIobj.RecordId = gLAccountConfigurationSettingsFormUI.Tbl_GLAccountConfigurationSettingsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GLAccountConfigurationSettings_GLAccountConfigurationSettingsForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods
}
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;
using System.Globalization;

public partial class System_Settings_GeneralJournalForm : PageBase
{

    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    CurrencyListBAL currencyListBAL = new CurrencyListBAL();

    BatchListBAL batchListBAL = new BatchListBAL();

    SourceDocumentListBAL sourceDocumentListBAL = new SourceDocumentListBAL();

    GeneralJournalFormBAL generalJournalFormBAL = new GeneralJournalFormBAL();
    GeneralJournalFormUI generalJournalFormUI = new GeneralJournalFormUI();
    GeneralJournalListBAL generalJournalListBAL = new GeneralJournalListBAL();

    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();

    GeneralJournalDetailsFormBAL generalJournalDetailsFormBAL = new GeneralJournalDetailsFormBAL();
    GeneralJournalDetailsFormUI generalJournalDetailsFormUI = new GeneralJournalDetailsFormUI();

    OrganizationListBAL organizationListBAL = new OrganizationListBAL();
    OrganizationListUI organizationListUI = new OrganizationListUI();

    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();

    CommonClasses commonClasses = new CommonClasses();
    DateTime date;



    #endregion

    #region Events

    protected override void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["GeneralJournalId"] != null || Request.QueryString["recordId"] != null)
            {
                generalJournalFormUI.Tbl_GeneralJournalId = (Request.QueryString["GeneralJournalId"] != null ? Request.QueryString["GeneralJournalId"] : Request.QueryString["recordId"]);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update GeneralJournal";
                BindGeneralJournalTypeDropDownList();
                txtJournalEntry.ReadOnly = true;
                divGeneralJournalDetailsAdd.Visible = true;
                FillForm(generalJournalFormUI);
                BindList();

            }
            else
            {
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                GetSerialNoGeneralJournal();
                BindGeneralJournalTypeDropDownList();
                txtJournalEntry.ReadOnly = true;
                divGeneralJournalDetailsAdd.Visible = false;
                lblHeading.Text = "Add New GeneralJournal";
            }
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            generalJournalFormUI.CreatedBy = SessionContext.UserGuid;
            generalJournalFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            generalJournalFormUI.JournalEntry = txtJournalEntry.Text;

            if (txtGeneralJournalId_SelfGuid.Text == "")
                generalJournalFormUI.Tbl_GeneralJournalId_Self = null;
            else
                generalJournalFormUI.Tbl_GeneralJournalId_Self = txtGeneralJournalId_SelfGuid.Text;


            generalJournalFormUI.Opt_GeneralJournalType = int.Parse(ddlOpt_GeneralJournalType.SelectedValue);

            if (txtBatchGuid.Text == "")
                generalJournalFormUI.Tbl_BatchId = null;
            else
                generalJournalFormUI.Tbl_BatchId = txtBatchGuid.Text;

            if (rdbStanndard.Checked == true)
                generalJournalFormUI.TransactionType = true;
            else
                generalJournalFormUI.TransactionType = false;

            generalJournalFormUI.TransactionDate = DateTime.Parse(txtTransactionDate.Text.ToString());

            generalJournalFormUI.Tbl_SourceDocumentId = txtSourceDocumentGuid.Text;
            generalJournalFormUI.Reference = txtReference.Text;
            generalJournalFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;

            if (generalJournalFormBAL.AddGeneralJournal(generalJournalFormUI) == 1)
            {
                divSuccess.Visible = true;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
                divError.Visible = true;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            generalJournalFormUI.ModifiedBy = SessionContext.UserGuid;
            generalJournalFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            generalJournalFormUI.Tbl_GeneralJournalId = Request.QueryString["GeneralJournalId"];
            generalJournalFormUI.JournalEntry = txtJournalEntry.Text;

            if (txtGeneralJournalId_SelfGuid.Text == "")
                generalJournalFormUI.Tbl_GeneralJournalId_Self = null;
            else
                generalJournalFormUI.Tbl_GeneralJournalId_Self = txtGeneralJournalId_SelfGuid.Text;

            generalJournalFormUI.Opt_GeneralJournalType = int.Parse(ddlOpt_GeneralJournalType.SelectedValue);

            if (txtBatchGuid.Text == "")
                generalJournalFormUI.Tbl_BatchId = null;
            else
                generalJournalFormUI.Tbl_BatchId = txtBatchGuid.Text;

            if (rdbStanndard.Checked == true)
                generalJournalFormUI.TransactionType = true;
            else
                generalJournalFormUI.TransactionType = false;

            generalJournalFormUI.TransactionDate = DateTime.Parse(txtTransactionDate.Text.ToString());

            generalJournalFormUI.Tbl_SourceDocumentId = txtSourceDocumentGuid.Text;
            generalJournalFormUI.Reference = txtReference.Text;
            generalJournalFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;


            if (generalJournalFormBAL.UpdateGeneralJournal(generalJournalFormUI) == 1)
            {
                divSuccess.Visible = true;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;

            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;

            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalForm : btnUpdate_Click] An error occured in the processing of Record Id : " + generalJournalFormUI.Tbl_GeneralJournalId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            generalJournalFormUI.Tbl_GeneralJournalId = Request.QueryString["GeneralJournalId"];

            if (generalJournalFormBAL.DeleteGeneralJournal(generalJournalFormUI) == 1)
            {
                divSuccess.Visible = true;
                lblSuccess.Text = Resources.GlobalResource.msgRecordDeleteSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);

            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotDeleteRecord;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnDelete_Click()";
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalForm.CS";
            logExcpUIobj.RecordId = generalJournalFormUI.Tbl_GeneralJournalId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalForm : btnDelete_Click] An error occured in the processing of Record Id : " + generalJournalFormUI.Tbl_GeneralJournalId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/Finance/General_Ledger/GL_GeneralJournal/GeneralJournalList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Finance/General_Ledger/GL_GeneralJournal/GeneralJournalForm.aspx";
        string recordId = Request.QueryString["GeneralJournalId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    protected void gvData_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        gvData.CurrentPageIndex = e.NewPageIndex;
        BindList();

    }

    protected void btnPost_Click(object sender, EventArgs e)
    {
        try
        {
            bool isPosted = true;
            generalJournalFormUI.ModifiedBy = SessionContext.UserGuid;
            generalJournalFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            generalJournalFormUI.Tbl_GeneralJournalId = Request.QueryString["GeneralJournalId"];
            generalJournalFormUI.IsPosted = isPosted;

            if (generalJournalFormBAL.UpdatePostingGeneralJournal(generalJournalFormUI) == 1)
            {
                divSuccess.Visible = true;
                lblSuccess.Text = Resources.GlobalResource.msgRecordPostedSuccessfully;
                btnPost.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                gvData.Columns[15].Visible = false;
                gvData.Columns[14].Visible = false;
                btnAdd.Visible = false;
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
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalForm.CS";
            logExcpUIobj.RecordId = generalJournalFormUI.Tbl_GeneralJournalId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalForm : btnPost_Click] An error occured in the processing of Record Id : " + generalJournalFormUI.Tbl_GeneralJournalId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void txtTransactionDate_TextChanged(object sender, EventArgs e)
    {
        //if (txtTransactionDate.Text != "")
        //{
        //    DateTime fiscalPeriodStartDate = Convert.ToDateTime(SessionContext.FiscalPeriodStartDate);
        //    DateTime fiscalPeriodEndDate = Convert.ToDateTime(SessionContext.FiscalPeriodEndDate);

        //    DateTime transactionDate = commonClasses.DateFormatMMDDYYY(Convert.ToDateTime(Convert.ToDateTime(txtTransactionDate.Text)));

        //    int resultStart = DateTime.Compare(transactionDate, fiscalPeriodStartDate);
        //    int resultEnd = DateTime.Compare(transactionDate, fiscalPeriodEndDate);

        //    //   if (transactionDate < fiscalPeriodStartDate && transactionDate > fiscalPeriodEndDate)
        //    if (resultStart > 0 && resultEnd < 0)
        //    {

        //    }
        //    else
        //    {
        //        txtTransactionDate.Text = "";
        //        txtTransactionDate.Focus();
        //        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
        //        "err_msg", "alert('Invoice Date can not be greater the Financial closing Date!)');", true);
        //    }
        //}
    }

    #region Events Seach Batch
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
    protected void gvBatchSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBatchSearch.PageIndex = e.NewPageIndex;
        BindBatchList();
    }
    #endregion

    #region Events Seach Currency
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
    protected void gvCurrencySearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCurrencySearch.PageIndex = e.NewPageIndex;
        BindCurrencyList();
    }
    #endregion

    #region Events Seach Document
    protected void btnSource_DocumentSearch_Click(object sender, EventArgs e)
    {
        btnHtmlSource_DocumentSearch.Visible = false;
        btnHtmlSource_DocumentClose.Visible = true;
        SearchSource_DocumentList();
    }
    protected void btnClearSource_DocumentSearch_Click(object sender, EventArgs e)
    {
        BindDocumentSearchList();
        gvSource_DocumentSearch.Visible = true;
        btnHtmlSource_DocumentSearch.Visible = true;
        btnHtmlSource_DocumentClose.Visible = false;
        txtSource_DocumentSearch.Text = "";
        txtSource_DocumentSearch.Focus();
    }
    protected void btnSource_DocumentRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindDocumentSearchList();
    }
    protected void gvSource_DocumentSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSource_DocumentSearch.PageIndex = e.NewPageIndex;
        BindDocumentSearchList();
    }
    #endregion

    #region Event Search General JournalId Self
    protected void btnGeneralJournalId_SelfSearch_Click(object sender, EventArgs e)
    {
        btnHtmlGeneralJournalId_SelfSearch.Visible = false;
        btnHtmlGeneralJournalId_SelfClose.Visible = true;
        SearchGeneralJournalId_SelfList();
    }
    protected void btnClearGeneralJournalId_SelfSearch_Click(object sender, EventArgs e)
    {
        BindGeneralJournalId_SelfList();
        gvGeneralJournalId_SelfSearch.Visible = true;
        btnHtmlGeneralJournalId_SelfSearch.Visible = true;
        btnHtmlGeneralJournalId_SelfClose.Visible = false;
        txtGeneralJournalId_SelfSearch.Text = "";
        txtGeneralJournalId_SelfSearch.Focus();
    }
    protected void btnGeneralJournalId_SelfRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindGeneralJournalId_SelfList();
    }
    protected void gvGeneralJournalId_SelfSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvGeneralJournalId_SelfSearch.PageIndex = e.NewPageIndex;
        BindGeneralJournalId_SelfList();
    }
    #endregion  Event Search General JournalId Self

    #region Events Search GL Account
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
    #endregion Events Search GL Account

    #region Events Search GL AccountUpd
    protected void btnGLAccountUpdSearch_Click(object sender, EventArgs e)
    {
        btnHtmlGLAccountUpdSearch.Visible = false;
        btnHtmlGLAccountUpdClose.Visible = true;
        SearchUpdGLAccountList();

    }
    protected void btnClearGLAccountUpdSearch_Click(object sender, EventArgs e)
    {
        BindUpdGLAccountList();
        gvGLAccountUpdSearch.Visible = true;
        btnHtmlGLAccountUpdSearch.Visible = true;
        btnHtmlGLAccountUpdClose.Visible = false;
        txtGLAccountUpdSearch.Text = "";
        txtGLAccountUpdSearch.Focus();

    }
    protected void btnGLAccountUpdRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindUpdGLAccountList();
    }
    #endregion Events Search GL Account  

    #region Events Search Company
    protected void btnCompanySearch_Click(object sender, EventArgs e)
    {
        btnHtmlCompanySearch.Visible = false;
        btnHtmlCompanyClose.Visible = true;
        SearchCompanyList();

    }
    protected void btnClearCompanySearch_Click(object sender, EventArgs e)
    {
        BindCompanyList();
        gvCompanySearch.Visible = true;
        btnHtmlCompanySearch.Visible = true;
        btnHtmlCompanyClose.Visible = false;
        txtCompanySearch.Text = "";
        txtCompanySearch.Focus();

    }
    protected void btnCompanyRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindCompanyList();
    }
    #endregion Events Search Company    

    #region Events UpdSearch Company
    protected void btnCompanyUpdSearch_Click(object sender, EventArgs e)
    {
        btnHtmlCompanyUpdSearch.Visible = false;
        btnHtmlCompanyUpdClose.Visible = true;
        SearchCompanyUpdList();

    }
    protected void btnClearCompanyUpdSearch_Click(object sender, EventArgs e)
    {
        BindCompanyUpdList();
        gvCompanyUpdSearch.Visible = true;
        btnHtmlCompanyUpdSearch.Visible = true;
        btnHtmlCompanyUpdClose.Visible = false;
        txtCompanyUpdSearch.Text = "";
        txtCompanyUpdSearch.Focus();

    }
    protected void btnCompanyUpdRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindCompanyUpdList();
    }
    #endregion Events Search Company    

    #region General Journal Details       

    protected void btnGenerelJournalDetailSave_Click(object sender, EventArgs e)
    {
        try
        {
            generalJournalDetailsFormUI.CreatedBy = SessionContext.UserGuid;
            generalJournalDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            generalJournalDetailsFormUI.Tbl_GeneralJournalId = Request.QueryString["GeneralJournalId"];
            generalJournalDetailsFormUI.Tbl_OrganizationId_Company = txtCompanyGuidAdd.Text;
            generalJournalDetailsFormUI.Tbl_GLAccountId = txtGLAccountGuidAdd.Text;
            generalJournalDetailsFormUI.Debit = Convert.ToDecimal(txtDebitAdd.Text.ToString());
            generalJournalDetailsFormUI.Credit = Convert.ToDecimal(txtCreditAdd.Text.ToString());
            generalJournalDetailsFormUI.Description = txtDescriptionAdd.Text;
            generalJournalDetailsFormUI.DistributionReference = txtDistributionReferenceAdd.Text;
            generalJournalDetailsFormUI.TotalDebit = Convert.ToDecimal(txtTotalDebitAdd.Text);
            generalJournalDetailsFormUI.TotalCredit = Convert.ToDecimal(txtTotalCreditAdd.Text);
            generalJournalDetailsFormUI.Difference = Convert.ToDecimal(txtDifferenceAdd.Text);

            if (generalJournalDetailsFormBAL.AddGeneralJournalDetails(generalJournalDetailsFormUI) == 1)
            { this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearGeneralDetailsForm();", true); }

            else
            { this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearGeneralDetailsForm();", true); }

            BindList();
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnGenerelJournalDetailSave_Click()";
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalDetailsForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalDetailsForm : btnGenerelJournalDetailSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnGenerelJournalDetailUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            generalJournalDetailsFormUI.ModifiedBy = SessionContext.UserGuid;
            generalJournalDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            generalJournalDetailsFormUI.Tbl_GeneralJournalDetailsId = txtGeneralJournalDetailsGuid.Text;
            generalJournalDetailsFormUI.Tbl_GeneralJournalId = Request.QueryString["GeneralJournalId"];
            generalJournalDetailsFormUI.Tbl_OrganizationId_Company = txtCompanyGuidUpdate.Text;
            generalJournalDetailsFormUI.Tbl_GLAccountId = txtGLAccountGuidUpdate.Text;
            generalJournalDetailsFormUI.Debit = Convert.ToDecimal(txtDebitUpdate.Text.ToString());
            generalJournalDetailsFormUI.Credit = Convert.ToDecimal(txtCreditUpdate.Text.ToString());
            generalJournalDetailsFormUI.Description = txtDescriptionUpdate.Text;
            generalJournalDetailsFormUI.DistributionReference = txtDistributionReferenceUpdate.Text;
            generalJournalDetailsFormUI.TotalDebit = Convert.ToDecimal(txtTotalDebitUpdate.Text);
            generalJournalDetailsFormUI.TotalCredit = Convert.ToDecimal(txtTotalCreditUpdate.Text);
            generalJournalDetailsFormUI.Difference = Convert.ToDecimal(txtDifferenceUpdate.Text);

            if (generalJournalDetailsFormBAL.UpdateGeneralJournalDetails(generalJournalDetailsFormUI) == 1)
            { this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearGeneralDetailsForm();", true); }
            else
            { this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearGeneralDetailsForm();", true); }

            BindList();

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnGenerelJournalDetailUpdate_Click()";
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalDetailsForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalDetailsForm : btnGenerelJournalDetailUpdate_Click] An error occured in the processing of Record Id : " + generalJournalDetailsFormUI.Tbl_GeneralJournalDetailsId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {

        string generalJournalDetailsId = (sender as LinkButton).CommandArgument;

        try
        {

            generalJournalDetailsFormUI.Tbl_GeneralJournalDetailsId = generalJournalDetailsId;

            if (generalJournalDetailsFormBAL.DeleteGeneralJournalDetails(generalJournalDetailsFormUI) == 1)
            {
                divSuccess.Visible = true;
                lblSuccess.Text = Resources.GlobalResource.msgRecordDeleteSuccessfully;

            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotDeleteRecord;
            }



            BindList();
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "lnkDelete_Click()";
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalList.CS";
            logExcpUIobj.RecordId = generalJournalDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalList : lnkDelete_Click] An error occured in the processing of Record Id :  Details : [" + exp.ToString() + "]");
        }

    }

    protected void gvCompanySearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCompanySearch.PageIndex = e.NewPageIndex;
        BindCompanyList();
    }

    protected void gvGLAccountSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvGLAccountSearch.PageIndex = e.NewPageIndex;
        BindGLAccountList();
    }

    protected void gvCompanyUpdSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCompanyUpdSearch.PageIndex = e.NewPageIndex;
        BindCompanyUpdList();

    }

    protected void gvGLAccountUpdSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvGLAccountUpdSearch.PageIndex = e.NewPageIndex;
        BindUpdGLAccountList();
    }

    #endregion General Journal Details

    #endregion

    #region Methods

    private void FillForm(GeneralJournalFormUI generalJournalFormUI)
    {
        try
        {
            DataTable dtb = generalJournalFormBAL.GetGeneralJournalListById(generalJournalFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtJournalEntry.Text = dtb.Rows[0]["JournalEntry"].ToString();

                txtGeneralJournalId_Self.Text = dtb.Rows[0]["GeneralJournalId_Self"].ToString();
                txtGeneralJournalId_SelfGuid.Text = dtb.Rows[0]["tbl_GeneralJournalId_Self"].ToString();
                txtBatchGuid.Text = dtb.Rows[0]["tbl_BatchId"].ToString();
                txtBatch.Text = dtb.Rows[0]["BatchName"].ToString();
                if (Convert.ToBoolean(dtb.Rows[0]["TransactionType"]) == true)
                    rdbStanndard.Checked = true;
                else
                    rdbReversing.Checked = true;
                txtTransactionDate.Text = dtb.Rows[0]["TransactionDate"].ToString();
                txtSourceDocument.Text = dtb.Rows[0]["SourceDocument"].ToString();
                txtSourceDocumentGuid.Text = dtb.Rows[0]["tbl_SourceDocumentId"].ToString();
                ddlOpt_GeneralJournalType.SelectedValue = dtb.Rows[0]["Opt_GeneralJournalType"].ToString();
                txtCurrencyGuid.Text = dtb.Rows[0]["tbl_CurrencyId"].ToString();
                txtCurrency.Text = dtb.Rows[0]["CurrencyName"].ToString();
                txtReference.Text = dtb.Rows[0]["Reference"].ToString();

                bool isPosted = Convert.ToBoolean(dtb.Rows[0]["IsPosted"]);

                if (isPosted == true)
                {
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnPost.Enabled = false;
                    gvData.Columns[15].Visible = false;
                    gvData.Columns[14].Visible = false;
                    btnAdd.Visible = false;
                }
                else if (txtBatchGuid.Text != "")
                {
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
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
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalForm.CS";
            logExcpUIobj.RecordId = generalJournalFormUI.Tbl_GeneralJournalId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    public void GetSerialNoGeneralJournal()
    {
        try
        {

            DataTable dtb = generalJournalFormBAL.GetSerialNoGeneralJournal();

            if (dtb.Rows.Count > 0)
            {
                txtJournalEntry.Text = dtb.Rows[0]["SerialNumber"].ToString();
            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotLoadData;
                divError.Visible = true;

            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetSerialNoGeneralJournal()";
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalForm.CS";
            logExcpUIobj.RecordId = generalJournalFormUI.Tbl_GeneralJournalId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalForm : GetSerialNoGeneralJournal] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindGeneralJournalTypeDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_GeneralJournal";
            optionSetListUI.OptionSetName = "Opt_GeneralJournalType";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlOpt_GeneralJournalType.DataSource = dtb;
                ddlOpt_GeneralJournalType.DataBind();
                ddlOpt_GeneralJournalType.DataTextField = "OptionSetLable";
                ddlOpt_GeneralJournalType.DataValueField = "OptionSetValue";
                ddlOpt_GeneralJournalType.DataBind();
                ddlOpt_GeneralJournalType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlOpt_GeneralJournalType.SelectedIndex = 0;

            }
            else
            {
                ddlOpt_GeneralJournalType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindGeneralJournalTypeDropDownList()";
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[System_Settings_GeneralJournalForm : BindGeneralJournalTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindList()
    {
        try
        {
            generalJournalFormUI.Tbl_GeneralJournalId = (Request.QueryString["GeneralJournalId"] != null ? Request.QueryString["GeneralJournalId"] : Request.QueryString["recordId"]);

            DataTable dtb = generalJournalDetailsFormBAL.GetGeneralJournalListById(generalJournalFormUI);


            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvData.DataSource = dtb;
                gvData.DataBind();
                divError.Visible = false;
                gvData.Visible = true;
            }
            else
            {
                DataRow dr = dtb.NewRow();
                dtb.Rows.Add(dr);
                gvData.DataSource = dtb;
                gvData.DataBind();
            }



        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalForm : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalForm : SearchBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalForm : BindBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    #endregion Batch Search

    #region Document Search 
    private void SearchSource_DocumentList()
    {

        try
        {
            SourceDocumentListUI sourceDocumentListUI = new SourceDocumentListUI();
            sourceDocumentListUI.Search = txtSource_DocumentSearch.Text;


            DataTable dtb = sourceDocumentListBAL.GetSourceDocumentListBySearchParameters(sourceDocumentListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSource_DocumentSearch.DataSource = dtb;
                gvSource_DocumentSearch.DataBind();
                divSource_DocumentSearchError.Visible = false;
            }
            else
            {
                divSource_DocumentSearchError.Visible = true;
                lblSource_DocumentSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSource_DocumentSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchSource_DocumentList()";
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalForm : SearchSource_DocumentList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindDocumentSearchList()
    {
        try
        {
            DataTable dtb = sourceDocumentListBAL.GetSourceDocumentList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSource_DocumentSearch.DataSource = dtb;
                gvSource_DocumentSearch.DataBind();
                divError.Visible = false;
                gvSource_DocumentSearch.Visible = true;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSource_DocumentSearch.Visible = false;
            }

            txtSource_DocumentSearch.Text = "";
            txtSource_DocumentSearch.Focus();
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindDocumentSearchList()";
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalForm : BindDocumentSearchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion

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
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalForm : SearchCurrency] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalForm : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion Currency    

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

    #region GlAccountUpd
    private void SearchUpdGLAccountList()
    {
        try
        {
            GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtGLAccountSearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountUpdSearch.DataSource = dtb;
                gvGLAccountUpdSearch.DataBind();
                divGLAccountSearchUpdError.Visible = false;
            }
            else
            {
                divGLAccountSearchUpdError.Visible = true;
                lblGLAccountUpdSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountUpdSearch.Visible = false;
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
    private void BindUpdGLAccountList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountUpdSearch.DataSource = dtb;
                gvGLAccountUpdSearch.DataBind();
                divGLAccountSearchUpdError.Visible = false;
            }
            else
            {
                divGLAccountSearchUpdError.Visible = true;
                lblGLAccountUpdSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountUpdSearch.Visible = false;
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

    #region Company
    private void SearchCompanyList()
    {
        try
        {
            OrganizationListBAL organizationListBAL = new OrganizationListBAL();
            OrganizationListUI organizationListUI = new OrganizationListUI();
            organizationListUI.Search = txtCompanySearch.Text;

            DataTable dtb = organizationListBAL.GetOrganizationListBySearchParameters(organizationListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCompanySearch.DataSource = dtb;
                gvCompanySearch.DataBind();
                divCompanySearchError.Visible = false;
            }
            else
            {
                divCompanySearchError.Visible = true;
                lblCompanySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCompanySearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchCompanyList()";
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalForm : SearchCompanyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }


    }
    private void BindCompanyList()
    {
        try
        {
            DataTable dtb = organizationListBAL.GetOrganizationList();

            if (dtb.Rows.Count > 0)
            {
                gvCompanySearch.DataSource = dtb;
                gvCompanySearch.DataBind();
                divCompanySearchError.Visible = false;
            }
            else
            {
                divCompanySearchError.Visible = true;
                lblCompanySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCompanySearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCompanyList()";
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalForm : BindCompanyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion

    #region CompanyUpd
    private void SearchCompanyUpdList()
    {
        try
        {
            OrganizationListBAL organizationListBAL = new OrganizationListBAL();
            OrganizationListUI organizationListUI = new OrganizationListUI();
            organizationListUI.Search = txtCompanySearch.Text;

            DataTable dtb = organizationListBAL.GetOrganizationListBySearchParameters(organizationListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCompanyUpdSearch.DataSource = dtb;
                gvCompanyUpdSearch.DataBind();
                divCompanyUpdSearchError.Visible = false;
            }
            else
            {
                divCompanyUpdSearchError.Visible = true;
                lblCompanyUpdSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCompanyUpdSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchCompanyList()";
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalForm : SearchCompanyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }


    }
    private void BindCompanyUpdList()
    {
        try
        {
            DataTable dtb = organizationListBAL.GetOrganizationList();

            if (dtb.Rows.Count > 0)
            {
                gvCompanyUpdSearch.DataSource = dtb;
                gvCompanyUpdSearch.DataBind();
                divCompanyUpdSearchError.Visible = false;
            }
            else
            {
                divCompanyUpdSearchError.Visible = true;
                lblCompanyUpdSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCompanyUpdSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCompanyList()";
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalForm : BindCompanyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion

    #region GeneralJournalId_Self
    private void SearchGeneralJournalId_SelfList()
    {
        try
        {
            GeneralJournalListUI generalJournalListUI = new GeneralJournalListUI();
            generalJournalListUI.Search = txtGeneralJournalId_SelfSearch.Text;

            DataTable dtb = generalJournalListBAL.GetGeneralJournalListBySearchParameters(generalJournalListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGeneralJournalId_SelfSearch.DataSource = dtb;
                gvGeneralJournalId_SelfSearch.DataBind();
                divGeneralJournalId_SelfSearchError.Visible = false;
            }
            else
            {
                divGeneralJournalId_SelfSearchError.Visible = true;
                lblGeneralJournalId_SelfSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGeneralJournalId_SelfSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchGeneralJournalId_SelfList()";
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalForm : SearchGeneralJournalId_SelfList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }

    private void BindGeneralJournalId_SelfList()
    {
        try
        {
            DataTable dtb = generalJournalListBAL.GetGeneralJournalList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGeneralJournalId_SelfSearch.DataSource = dtb;
                gvGeneralJournalId_SelfSearch.DataBind();
                divGeneralJournalId_SelfSearchError.Visible = false;

            }
            else
            {
                divGeneralJournalId_SelfSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGeneralJournalId_SelfSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindGeneralJournalId_SelfList()";
            logExcpUIobj.ResourceName = "System_Settings_GeneralJournalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GeneralJournalForm : BindGeneralJournalId_SelfList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion   GeneralJournalId_Self

    #endregion




}
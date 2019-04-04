using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_General_Ledger_GL_Integration_GLAccountBudgetDetailsForm : PageBase
{
    #region Data Members

    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    GLAccountBudgetDetailsFormBAL gLAccountBudgetDetailsFormBAL = new GLAccountBudgetDetailsFormBAL();
    GLAccountBudgetDetailsFormUI gLAccountBudgetDetailsFormUI = new GLAccountBudgetDetailsFormUI();
    FiscalPeriodListBAL fiscalPeriodListBAL = new FiscalPeriodListBAL();
    GLAccountBudgetListBAL gLAccountBudgetListBAL = new GLAccountBudgetListBAL();

    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        GLAccountBudgetDetailsFormUI gLAccountBudgetDetailsFormUI = new GLAccountBudgetDetailsFormUI();
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["GLAccountBudgetDetailsId"] != null || Request.QueryString["recordId"] != null)
            {
                gLAccountBudgetDetailsFormUI.Tbl_GLAccountBudgetDetailsId = (Request.QueryString["GLAccountBudgetDetailsId"] != null ? Request.QueryString["GLAccountBudgetDetailsId"] : Request.QueryString["recordId"]);

                FillForm(gLAccountBudgetDetailsFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnAuditHistory.Visible = true;
                lblHeading.Text = "Update GL Account Budget Details";
            }
            else
            {
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = Visible;
                lblHeading.Text = "Add New GL Account Budget Details";
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            gLAccountBudgetDetailsFormUI.CreatedBy = SessionContext.UserGuid;
            gLAccountBudgetDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            gLAccountBudgetDetailsFormUI.Tbl_GLAccountBudgetId = txtGLAccountBudgetGuid.Text;
            gLAccountBudgetDetailsFormUI.Tbl_FiscalPeriodId = txtFiscalPeriodGuid.Text;
            gLAccountBudgetDetailsFormUI.Period = int.Parse(txtPeriod.Text);
            gLAccountBudgetDetailsFormUI.PeriodDate = DateTime.Parse(txtPeriodDate.Text);
            gLAccountBudgetDetailsFormUI.PeriodName = txtPeriodName.Text;
            gLAccountBudgetDetailsFormUI.Amount = Convert.ToDecimal(txtAmount.Text);
            if (gLAccountBudgetDetailsFormBAL.AddGLAccountBudgetDetails(gLAccountBudgetDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountBudgetDetailsForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountBudgetDetailsForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            gLAccountBudgetDetailsFormUI.ModifiedBy = SessionContext.UserGuid;
            gLAccountBudgetDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            gLAccountBudgetDetailsFormUI.Tbl_GLAccountBudgetDetailsId = Request.QueryString["GLAccountBudgetDetailsId"];
            gLAccountBudgetDetailsFormUI.Tbl_GLAccountBudgetId = txtGLAccountBudgetGuid.Text;
            gLAccountBudgetDetailsFormUI.Tbl_FiscalPeriodId = txtFiscalPeriodGuid.Text;
            gLAccountBudgetDetailsFormUI.Period = int.Parse(txtPeriod.Text);
            gLAccountBudgetDetailsFormUI.PeriodDate = DateTime.Parse(txtPeriodDate.Text);
            gLAccountBudgetDetailsFormUI.PeriodName = txtPeriodName.Text;
            gLAccountBudgetDetailsFormUI.Amount = Convert.ToDecimal(txtAmount.Text);
            if (gLAccountBudgetDetailsFormBAL.UpdateGLAccountBudgetDetails(gLAccountBudgetDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountBudgetDetailsForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountBudgetDetailsForm : btnUpdate_Click] An error occured in the processing of Record Id : " + gLAccountBudgetDetailsFormUI.Tbl_GLAccountBudgetDetailsId + ".  Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            gLAccountBudgetDetailsFormUI.Tbl_GLAccountBudgetDetailsId = Request.QueryString["GLAccountBudgetDetailsId"];

            if (gLAccountBudgetDetailsFormBAL.DeleteGLAccountBudgetDetails(gLAccountBudgetDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountBudgetDetailsForm.CS";
            logExcpUIobj.RecordId = gLAccountBudgetDetailsFormUI.Tbl_GLAccountBudgetDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountBudgetDetailsForm : btnDelete_Click] An error occured in the processing of Record Id : " + gLAccountBudgetDetailsFormUI.Tbl_GLAccountBudgetDetailsId + ". Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("GLAccountBudgetDetailsList.aspx");
    }
    #region GLAccountBudget Search
    protected void btnGLAccountBudgetSearch_Click(object sender, EventArgs e)
    {
        btnHtmlGLAccountBudgetSearch.Visible = false;
        btnHtmlGLAccountBudgetClose.Visible = true;
        SearchGLAccountBudgetList();
    }
    protected void btnClearGLAccountBudgetSearch_Click(object sender, EventArgs e)
    {
        BindGLAccountBudgetList();
        gvGLAccountBudgetSearch.Visible = true;
        btnHtmlGLAccountBudgetSearch.Visible = true;
        btnHtmlGLAccountBudgetClose.Visible = false;
        txtGLAccountBudgetSearch.Text = "";
        txtGLAccountBudgetSearch.Focus();
    }
    protected void btnGLAccountBudgetRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindGLAccountBudgetList();
    }
    #endregion GLAccountBudget Search

    #region FiscalPeriod Search
    protected void btnFiscalPeriodSearch_Click(object sender, EventArgs e)
    {
        btnHtmlGLAccountBudgetSearch.Visible = false;
        btnHtmlGLAccountBudgetClose.Visible = true;
        SearchGLAccountBudgetList();
    }
    protected void btnClearFiscalPeriodSearch_Click(object sender, EventArgs e)
    {
        BindFiscalPeriodList();
        gvFiscalPeriodSearch.Visible = true;
        btnHtmlFiscalPeriodSearch.Visible = true;
        btnHtmlFiscalPeriodClose.Visible = false;
        txtFiscalPeriodSearch.Text = "";
        txtFiscalPeriodSearch.Focus();
    }
    protected void btnFiscalPeriodRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindFiscalPeriodList();
    }
    #endregion GLAccountBudget Search

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Finance/General_Ledger/GL_Integration/GLAccountBudgetDetailsForm.aspx";
        string recordId = Request.QueryString["GLAccountBudgetDetailsId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    #endregion Events

    #region Methods
    private void FillForm(GLAccountBudgetDetailsFormUI gLAccountBudgetDetailsFormUI)
    {
        try
        {
            DataTable dtb = gLAccountBudgetDetailsFormBAL.GetGLAccountBudgetDetailsListById(gLAccountBudgetDetailsFormUI);
            if (dtb.Rows.Count > 0)
            {
                txtGLAccountBudgetGuid.Text = dtb.Rows[0]["tbl_GLAccountBudgetId"].ToString();
                txtGLAccountBudget.Text = dtb.Rows[0]["GLAccountNumber"].ToString();
                txtFiscalPeriodGuid.Text = dtb.Rows[0]["tbl_FiscalPeriodId"].ToString();
                txtFiscalPeriod.Text= dtb.Rows[0]["tbl_FiscalPeriod"].ToString(); //need to change
                txtPeriod.Text= dtb.Rows[0]["Period"].ToString();
                txtPeriodDate.Text= dtb.Rows[0]["PeriodDate"].ToString();
                txtPeriodName.Text= dtb.Rows[0]["PeriodName"].ToString();
                txtAmount.Text= dtb.Rows[0]["Amount"].ToString();
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountBudgetDetailsForm.CS";
            logExcpUIobj.RecordId = gLAccountBudgetDetailsFormUI.Tbl_GLAccountBudgetDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountBudgetDetailsForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region GLAccountBudget Search
    private void SearchGLAccountBudgetList()
    {
        try
        {

            GLAccountBudgetListUI gLAccountBudgetListUI = new GLAccountBudgetListUI();
            gLAccountBudgetListUI.Search = txtGLAccountBudgetSearch.Text;


            DataTable dtb =  gLAccountBudgetListBAL.GetGLAccountBudgetListBySearchParameters(gLAccountBudgetListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountBudgetSearch.DataSource = dtb;
                gvGLAccountBudgetSearch.DataBind();
                divGLAccountBudgetSearchError.Visible = false;
            }
            else
            {
                divGLAccountBudgetSearchError.Visible = true;
                lblGLAccountBudgetSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountBudgetSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchGLAccountBudgetList()";
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountBudgetDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountBudgetDetailsForm : SearchGLAccountBudgetList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindGLAccountBudgetList()
    {
        try
        {
            DataTable dtb = gLAccountBudgetListBAL.GetGLAccountBudgetList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountBudgetSearch.DataSource = dtb;
                gvGLAccountBudgetSearch.DataBind();
                divGLAccountBudgetSearchError.Visible = false;
            }
            else
            {
                divGLAccountBudgetSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountBudgetSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindGLAccountBudgetList()";
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountBudgetDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountBudgetDetailsForm : BindGLAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  GLAccountBudget Serach

    #region FiscalPeriod Search
    private void SearchFiscalPeriodList()
    {
        try
        {
            FiscalPeriodListUI fiscalPeriodListUI = new FiscalPeriodListUI();
            fiscalPeriodListUI.Search = txtFiscalPeriodSearch.Text;
            DataTable dtb = fiscalPeriodListBAL.GetFiscalPeriodListBySearchParameters(fiscalPeriodListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvFiscalPeriodSearch.DataSource = dtb;
                gvFiscalPeriodSearch.DataBind();
                divFiscalPeriodSearchError.Visible = false;
            }
            else
            {
                divFiscalPeriodSearchError.Visible = true;
                lblFiscalPeriodSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvFiscalPeriodSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchFiscalPeriodList()";
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountBudgetDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountBudgetDetailsForm : SearchGLAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindFiscalPeriodList()
    {
        try
        {
            DataTable dtb = fiscalPeriodListBAL.GetFiscalPeriodList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvFiscalPeriodSearch.DataSource = dtb;
                gvFiscalPeriodSearch.DataBind();
                divFiscalPeriodSearchError.Visible = false;
            }
            else
            {
                divFiscalPeriodSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvFiscalPeriodSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindFiscalPeriodList()";
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountBudgetDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountBudgetDetailsForm : BindFiscalPeriodList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  FiscalPeriod Serach
    #endregion Methods
}
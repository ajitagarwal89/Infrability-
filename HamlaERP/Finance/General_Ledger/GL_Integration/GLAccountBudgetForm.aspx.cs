using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_General_Ledger_GL_Integration_GLAccountBudgetForm : PageBase
{
    #region Data Members

    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    GLAccountBudgetFormBAL gLAccountBudgetFormBAL = new GLAccountBudgetFormBAL();
    GLAccountBudgetFormUI gLAccountBudgetFormUI = new GLAccountBudgetFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    BudgetListBAL budgetListBAL = new BudgetListBAL();

    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        GLAccountBudgetFormUI gLAccountBudgetFormUI = new GLAccountBudgetFormUI();
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["GLAccountBudgetId"] != null || Request.QueryString["recordId"] != null)
            {
                gLAccountBudgetFormUI.Tbl_GLAccountBudgetId =(Request.QueryString["GLAccountBudgetId"] != null ? Request.QueryString["GLAccountBudgetId"] : Request.QueryString["recordId"]);
                BindBasedOnDropDownList();
                BindBudgetYearDropDownList();
                BindCalculationMethodDropDownList();
                FillForm(gLAccountBudgetFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnAuditHistory.Visible = true;
                lblHeading.Text = "Update GL Account Budget";
            }
            else
            {
                BindBasedOnDropDownList();
                BindBudgetYearDropDownList();
                BindCalculationMethodDropDownList();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New GL Account Budget";
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            gLAccountBudgetFormUI.CreatedBy = SessionContext.UserGuid;
            gLAccountBudgetFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            gLAccountBudgetFormUI.Tbl_BudgetId = txtBudgetGuid.Text;
            gLAccountBudgetFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text;
            gLAccountBudgetFormUI.Tbl_ButdetId_SourceBudgetId = txtButdetId_SourceBudgetGuid.Text;
            gLAccountBudgetFormUI.Opt_BasedOn = int.Parse(ddlOpt_BasedOn.SelectedValue.ToString());
            gLAccountBudgetFormUI.Opt_BudgetYear = int.Parse(ddlOpt_BudgetYear.SelectedValue.ToString());
            gLAccountBudgetFormUI.Opt_CalculationMethod = int.Parse(ddlOpt_CalculationMethod.SelectedValue.ToString());
            gLAccountBudgetFormUI.Year = int.Parse(txtYear.Text);
            gLAccountBudgetFormUI.Percentage = Convert.ToDecimal(txtPercentage.Text);
            gLAccountBudgetFormUI.Amount = Convert.ToDecimal(txtAmount.Text);
            if (chkIsIncrease.Checked)
            {
                gLAccountBudgetFormUI.IsIncrease = true;
            }
            else
            {
                gLAccountBudgetFormUI.IsIncrease = false;
            }
            if (chkDisplay.Checked)
            {
                gLAccountBudgetFormUI.Display = true;
            }
            else
            {
                gLAccountBudgetFormUI.Display = false;
            }
            if (chkIncludeBiginningBalance.Checked)
            {
                gLAccountBudgetFormUI.IncludeBiginningBalance = true;
            }
            else
            {
                gLAccountBudgetFormUI.IncludeBiginningBalance = false;
            }
            if (gLAccountBudgetFormBAL.AddGLAccountBudget(gLAccountBudgetFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                divSuccess.Visible = false;
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountBudgetForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountBudgetForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            gLAccountBudgetFormUI.ModifiedBy = SessionContext.UserGuid;
            gLAccountBudgetFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            gLAccountBudgetFormUI.Tbl_GLAccountBudgetId = Request.QueryString["GLAccountBudgetId"];
            gLAccountBudgetFormUI.Tbl_BudgetId = txtBudgetGuid.Text;
            gLAccountBudgetFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text;
            gLAccountBudgetFormUI.Tbl_ButdetId_SourceBudgetId = txtButdetId_SourceBudgetGuid.Text;
            gLAccountBudgetFormUI.Opt_BasedOn = int.Parse(ddlOpt_BasedOn.SelectedValue.ToString());
            gLAccountBudgetFormUI.Opt_BudgetYear = int.Parse(ddlOpt_BudgetYear.SelectedValue.ToString());
            gLAccountBudgetFormUI.Opt_CalculationMethod = int.Parse(ddlOpt_CalculationMethod.SelectedValue.ToString());
            gLAccountBudgetFormUI.Year = int.Parse(txtYear.Text);
            gLAccountBudgetFormUI.Percentage = Convert.ToDecimal(txtPercentage.Text);
            gLAccountBudgetFormUI.Amount = Convert.ToDecimal(txtAmount.Text);
            if (chkIsIncrease.Checked)
            {
                gLAccountBudgetFormUI.IsIncrease = true;
            }
            else
            {
                gLAccountBudgetFormUI.IsIncrease = false;
            }
            if (chkDisplay.Checked)
            {
                gLAccountBudgetFormUI.Display = true;
            }
            else
            {
                gLAccountBudgetFormUI.Display = false;
            }
            if (chkIncludeBiginningBalance.Checked)
            {
                gLAccountBudgetFormUI.IncludeBiginningBalance = true;
            }
            else
            {
                gLAccountBudgetFormUI.IncludeBiginningBalance = false;
            }
            if (gLAccountBudgetFormBAL.UpdateGLAccountBudget(gLAccountBudgetFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountBudgetForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountBudgetForm : btnUpdate_Click] An error occured in the processing of Record Id : " + gLAccountBudgetFormUI.Tbl_GLAccountBudgetId + ".  Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            gLAccountBudgetFormUI.Tbl_GLAccountBudgetId = Request.QueryString["GLAccountBudgetId"];
            if (gLAccountBudgetFormBAL.DeleteGLAccountBudget(gLAccountBudgetFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountBudgetForm.CS";
            logExcpUIobj.RecordId = gLAccountBudgetFormUI.Tbl_GLAccountBudgetId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountBudgetForm : btnDelete_Click] An error occured in the processing of Record Id : " + gLAccountBudgetFormUI.Tbl_GLAccountBudgetId + ". Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("GLAccountBudgetList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Finance/General_Ledger/GL_Integration/GLAccountBudgetForm.aspx";
        string recordId = Request.QueryString["GLAccountBudgetId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    #region GLAccount Search
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
    #endregion GLAccount Search
    #region Budget Search
    protected void btnBudgetSearch_Click(object sender, EventArgs e)
    {
        btnHtmlBudgetSearch.Visible = false;
        btnHtmlBudgetClose.Visible = true;
        SearchBudgetList();
    }
    protected void btnClearBudgetSearch_Click(object sender, EventArgs e)
    {
        BindBudgetList();
        gvBudgetSearch.Visible = true;
        btnHtmlBudgetSearch.Visible = true;
        btnHtmlBudgetClose.Visible = false;
        txtBudgetSearch.Text = "";
        txtBudgetSearch.Focus();
    }
    protected void btnBudgetRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindBudgetList();
    }
    #endregion Budget Search

    #region SourceBudget Search
    protected void btnSourceBudgetSearch_Click(object sender, EventArgs e)
    {
        btnHtmlSourceBudgetSearch.Visible = false;
        btnHtmlSourceBudgetClose.Visible = true;
        SearchSourceBudgetList();
    }
    protected void btnClearSourceBudgetSearch_Click(object sender, EventArgs e)
    {
        BindSourceBudgetList();
        gvSourceBudgetSearch.Visible = true;
        btnHtmlSourceBudgetSearch.Visible = true;
        btnHtmlSourceBudgetClose.Visible = false;
        txtSourceBudgetSearch.Text = "";
        txtSourceBudgetSearch.Focus();
    }
    protected void btnSourceBudgetRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindSourceBudgetList();
    }
    #endregion SourceBudget Search

    #endregion Events

    #region Methods
    private void BindBasedOnDropDownList()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_GLAccountBudget";
            optionSetListUI.OptionSetName = "Opt_BasedOn";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {
                ddlOpt_BasedOn.DataSource = dtb;
                ddlOpt_BasedOn.DataBind();
                ddlOpt_BasedOn.DataTextField = "OptionSetLable";
                ddlOpt_BasedOn.DataValueField = "OptionSetValue";
                ddlOpt_BasedOn.DataBind();
            }
            else
            {
                ddlOpt_BasedOn.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindBasedOnDropDownList()";
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountBudgetForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountBudgetForm : BindBasedOnDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void BindBudgetYearDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_GLAccountBudget";
            optionSetListUI.OptionSetName = "Opt_BudgetYear";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlOpt_BudgetYear.DataSource = dtb;
                ddlOpt_BudgetYear.DataBind();
                ddlOpt_BudgetYear.DataTextField = "OptionSetLable";
                ddlOpt_BudgetYear.DataValueField = "OptionSetValue";
                ddlOpt_BudgetYear.DataBind();
            }
            else
            {
                ddlOpt_BudgetYear.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindBudgetYearDropDownList()";
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountBudgetForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountBudgetForm : BindBudgetYearDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void BindCalculationMethodDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_GLAccountBudget";
            optionSetListUI.OptionSetName = "Opt_CalculationMethod";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlOpt_CalculationMethod.DataSource = dtb;
                ddlOpt_CalculationMethod.DataBind();
                ddlOpt_CalculationMethod.DataTextField = "OptionSetLable";
                ddlOpt_CalculationMethod.DataValueField = "OptionSetValue";
                ddlOpt_CalculationMethod.DataBind();
            }
            else
            {
                ddlOpt_CalculationMethod.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCalculationMethodDropDownList()";
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountBudgetForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountBudgetForm : BindCalculationMethodDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void FillForm(GLAccountBudgetFormUI gLAccountBudgetFormUI)
    {
        try
        {
            DataTable dtb = gLAccountBudgetFormBAL.GetGLAccountBudgetListById(gLAccountBudgetFormUI);
            if (dtb.Rows.Count > 0)
            {
                txtGLAccountGuid.Text = dtb.Rows[0]["tbl_GLAccountId"].ToString();
                txtGLAccount.Text = dtb.Rows[0]["AccountNumber"].ToString();
                txtBudgetGuid.Text = dtb.Rows[0]["tbl_BudgetId"].ToString();
                txtBudget.Text = dtb.Rows[0]["BudgetNumber"].ToString();
                txtButdetId_SourceBudgetGuid.Text = dtb.Rows[0]["tbl_BudgetId"].ToString();
                txtButdetId_SourceBudgetId.Text = dtb.Rows[0]["BudgetNumber"].ToString();
                ddlOpt_BasedOn.SelectedValue = dtb.Rows[0]["Opt_BasedOn"].ToString();
                ddlOpt_BudgetYear.SelectedValue = dtb.Rows[0]["Opt_BudgetYear"].ToString();
                ddlOpt_CalculationMethod.SelectedValue = dtb.Rows[0]["Opt_CalculationMethod"].ToString();
                txtYear.Text = dtb.Rows[0]["Year"].ToString();
                txtPercentage.Text = dtb.Rows[0]["Percentage"].ToString();
                txtAmount.Text = dtb.Rows[0]["Amount"].ToString();
                chkIsIncrease.Checked = Convert.ToBoolean(dtb.Rows[0]["IsIncrease"].ToString());
                chkDisplay.Checked = Convert.ToBoolean(dtb.Rows[0]["Display"].ToString());
                chkIncludeBiginningBalance.Checked = Convert.ToBoolean(dtb.Rows[0]["IncludeBiginningBalance"].ToString());
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountBudgetForm.CS";
            logExcpUIobj.RecordId = gLAccountBudgetFormUI.Tbl_GLAccountBudgetId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountBudgetForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region GLAccount Search
    private void SearchGLAccountList()
    {
        try
        {
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : SearchGLAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindGLAccountList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : BindGLAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  GLAccount Serach

    #region Budget Search
    private void SearchBudgetList()
    {
        try
        {
            BudgetListUI budgetListUI = new BudgetListUI();
            budgetListUI.Search = txtBudgetSearch.Text;
            DataTable dtb = budgetListBAL.GetBudgetListBySearchParameters(budgetListUI);
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
            logExcpUIobj.MethodName = "SearchBudgetList()";
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountBudgetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountBudgetForm : SearchGLAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindBudgetList()
    {
        try
        {
            DataTable dtb = budgetListBAL.GetBudgetList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvBudgetSearch.DataSource = dtb;
                gvBudgetSearch.DataBind();
                divBudgetSearchError.Visible = false;
            }
            else
            {
                divBudgetSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvBudgetSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindBudgetList()";
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountBudgetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountBudgetForm : BindBudgetList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Budget Serach

    #region SourceBudget Search
    private void SearchSourceBudgetList()
    {
        try
        {
            BudgetListUI budgetListUI = new BudgetListUI();
            budgetListUI.Search = txtSourceBudgetSearch.Text;
            DataTable dtb = budgetListBAL.GetBudgetListBySearchParameters(budgetListUI);
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
            logExcpUIobj.MethodName = "SearchSourceBudgetList()";
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountBudgetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountBudgetForm : SearchSourceBudgetList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindSourceBudgetList()
    {
        try
        {
            DataTable dtb = budgetListBAL.GetBudgetList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSourceBudgetSearch.DataSource = dtb;
                gvSourceBudgetSearch.DataBind();
                divBudgetSearchError.Visible = false;
            }
            else
            {
                divBudgetSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSourceBudgetSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindSourceBudgetList()";
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountBudgetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountBudgetForm : BindSourceBudgetList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  SourceBudget Serach
    #endregion Methods
}
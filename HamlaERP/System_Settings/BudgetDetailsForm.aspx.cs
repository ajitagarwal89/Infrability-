using System;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_BudgetDetailsForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    BudgetDetailsFormBAL budgetDetailsFormBAL = new BudgetDetailsFormBAL();
    BudgetDetailsFormUI budgetDetailsFormUI = new BudgetDetailsFormUI();
    BudgetListBAL budgetListBAL = new BudgetListBAL();
    FiscalPeriodDetailsListBAL fiscalPeriodDetailsListBAL = new FiscalPeriodDetailsListBAL();

    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        BudgetDetailsFormUI budgetDetailsFormUI = new BudgetDetailsFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["BudgetDetailsId"] != null)
            {
                budgetDetailsFormUI.Tbl_BudgetDetailsId = Request.QueryString["BudgetDetailsId"];


                FillForm(budgetDetailsFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update BudgetDetails";
            }
            else
            {


                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New BudgetDetails";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            budgetDetailsFormUI.CreatedBy = SessionContext.UserGuid;
            budgetDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            budgetDetailsFormUI.Tbl_BudgetId = txtBudgetGuid.Text.Trim().ToString();
            budgetDetailsFormUI.Tbl_FiscalPeriodId = txtFiscalPeriodGuid.Text.Trim().ToString();
            budgetDetailsFormUI.Period = Convert.ToInt32(txtPeriod.Text.ToString());
            budgetDetailsFormUI.Amount = Convert.ToDecimal(txtAmount.Text.Trim().ToString());
            budgetDetailsFormUI.PeriodDate = DateTime.Parse(txtPeriodDate.Text.ToString());
            budgetDetailsFormUI.PeriodName = txtPeriodName.Text.Trim().ToString();
            if (budgetDetailsFormBAL.AddBudgetDetails(budgetDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BudgetDetailsForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BudgetDetailsForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {

            budgetDetailsFormUI.ModifiedBy = SessionContext.UserGuid;
            budgetDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            budgetDetailsFormUI.Tbl_BudgetDetailsId = Request.QueryString["BudgetDetailsId"];
            budgetDetailsFormUI.Tbl_BudgetId = txtBudgetGuid.Text.Trim().ToString();
            budgetDetailsFormUI.Tbl_FiscalPeriodId = txtFiscalPeriodGuid.Text.Trim().ToString();
            budgetDetailsFormUI.Period = Convert.ToInt32(txtPeriod.Text.ToString());
            budgetDetailsFormUI.Amount = Convert.ToDecimal(txtAmount.Text.Trim().ToString());
            budgetDetailsFormUI.PeriodDate = DateTime.Parse(txtPeriodDate.Text.ToString());
            budgetDetailsFormUI.PeriodName = txtPeriodName.Text.Trim().ToString();

            if (budgetDetailsFormBAL.UpdateBudgetDetails(budgetDetailsFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
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
            logExcpUIobj.ResourceName = "System_Settings_BudgetDetailsForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BudgetDetailsForm : btnUpdate_Click] An error occured in the processing of Record Id : " + budgetDetailsFormUI.Tbl_BudgetDetailsId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            budgetDetailsFormUI.Tbl_BudgetDetailsId = Request.QueryString["BatchId"];

            if (budgetDetailsFormBAL.DeleteBudgetDetails(budgetDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BudgetDetailsForm.CS";
            logExcpUIobj.RecordId = budgetDetailsFormUI.Tbl_BudgetDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BudgetDetailsForm : btnDelete_Click] An error occured in the processing of Record Id : " + budgetDetailsFormUI.Tbl_BudgetDetailsId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("BudgetDetailsList.aspx");
    }
    #endregion Events

    #region Methods
    private void FillForm(BudgetDetailsFormUI budgetDetailsFormUI)
    {
        try
        {
            DataTable dtb = budgetDetailsFormBAL.GetBudgetDetailsListById(budgetDetailsFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtBudgetGuid.Text = dtb.Rows[0]["tbl_BudgetId"].ToString();
                txtBudget.Text = dtb.Rows[0]["tbl_Budget"].ToString();
                txtFiscalPeriodGuid.Text = dtb.Rows[0]["tbl_FiscalPeriodId"].ToString();
                txtFiscalPeriod.Text = dtb.Rows[0]["tbl_FiscalPeriod"].ToString();
                txtPeriodDate.Text = dtb.Rows[0]["PeriodDate"].ToString();
                txtPeriod.Text = dtb.Rows[0]["Period"].ToString();
                txtPeriodName.Text = dtb.Rows[0]["PeriodName"].ToString();
                txtAmount.Text = dtb.Rows[0]["Amount"].ToString();

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
            logExcpUIobj.ResourceName = "System_Settings_BudgetDetailsForm.CS";
            logExcpUIobj.RecordId = this.budgetDetailsFormUI.Tbl_BudgetDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BudgetDetailsForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods

    #region Mondal pop up

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

    protected void btnFiscalPeriodSearch_Click(object sender, EventArgs e)
    {
        btnHtmlBudgetSearch.Visible = false;
        btnHtmlBudgetClose.Visible = true;
        SearchFiscalPeriodList();
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
        System.Threading.Thread.Sleep(5000);
        BindFiscalPeriodList();
    }


    #endregion

    #region Bind

    private void SearchFiscalPeriodList()
    {
        try
        {
            FiscalPeriodDetailsListUI fiscalPeriodDetailsListUI = new FiscalPeriodDetailsListUI();

            fiscalPeriodDetailsListUI.Search = txtFiscalPeriodSearch.Text;


            DataTable dtb = fiscalPeriodDetailsListBAL.GetFiscalPeriodDetailsListBySearchParameters(fiscalPeriodDetailsListUI);

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
            DataTable dtb = fiscalPeriodDetailsListBAL.GetFiscalPeriodDetailsList();

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

    private void SearchBudgetList()
    {
        try
        {

            BudgetListUI budgetListUI = new BudgetListUI();
            budgetListUI.Search = txtBudgetSearch.Text;


            DataTable dtb = budgetListBAL.GetBudgetListBySearchParameters(budgetListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvBudgetSearch.DataSource = dtb;
                gvBudgetSearch.DataBind();
                divBudgetSearchError.Visible = false;
            }
            else
            {
                divBudgetSearchError.Visible = true;
                lblBudgetSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvBudgetSearch.Visible = false;
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountBudgetDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountBudgetDetailsForm : BindGLAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion

}
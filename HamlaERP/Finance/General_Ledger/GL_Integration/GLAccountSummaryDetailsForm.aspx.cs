using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_General_Ledger_GL_Integration_GLAccountSummaryDetailsForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    GLAccountSummaryDetailsFormBAL gLAccountSummaryDetailsFormBAL = new GLAccountSummaryDetailsFormBAL();
    GLAccountSummaryDetailsFormUI gLAccountSummaryDetailsFormUI = new GLAccountSummaryDetailsFormUI();
    GLAccountSummaryDetailsListBAL gLAccountSummaryDetailsListBAL = new GLAccountSummaryDetailsListBAL();
    GLAccountSummaryListBAL gLAccountSummaryListBAL = new GLAccountSummaryListBAL();
    GLAccountSummaryListUI gLAccountSummaryListUI = new GLAccountSummaryListUI();
    FiscalPeriodDetailsListBAL fiscalPeriodDetailsListBAL = new FiscalPeriodDetailsListBAL();
    FiscalPeriodDetailsListUI fiscalPeriodDetailsListUI = new FiscalPeriodDetailsListUI();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        GLAccountSummaryDetailsFormUI gLAccountSummaryDetailsFormUI = new GLAccountSummaryDetailsFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["GLAccountSummaryDetailsId"] != null)
            {
                gLAccountSummaryDetailsFormUI.Tbl_GLAccountSummaryDetailsId = Request.QueryString["GLAccountSummaryDetailsId"];


                FillForm(gLAccountSummaryDetailsFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update GLAccountSummaryDetails";
            }
            else
            {



                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New GLAccountSummaryDetails";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            gLAccountSummaryDetailsFormUI.CreatedBy = SessionContext.UserGuid;
            gLAccountSummaryDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            gLAccountSummaryDetailsFormUI.Tbl_GLAccountSummaryId = txtGLAccountSummaryGuid.Text;
            gLAccountSummaryDetailsFormUI.Tbl_FiscalPeriodId = txtFiscalPeriodGuid.Text;
            gLAccountSummaryDetailsFormUI.Period = Convert.ToInt32(txtPeriod.Text);
            gLAccountSummaryDetailsFormUI.PeriodName = txtPeriodName.Text;
            gLAccountSummaryDetailsFormUI.PeriodDate = Convert.ToDateTime(txtPeriodDate.Text);
            gLAccountSummaryDetailsFormUI.DebitAmount = Convert.ToDecimal(txtDebitAmount.Text);
            gLAccountSummaryDetailsFormUI.CreditAmount = Convert.ToDecimal(txtCreditAmount.Text);
            gLAccountSummaryDetailsFormUI.NetChageAmount = Convert.ToDecimal(txtNetChargeAmount.Text);
            gLAccountSummaryDetailsFormUI.PeriodBalanceAmount = Convert.ToDecimal(txtNetChargeAmount.Text);

            if (gLAccountSummaryDetailsFormBAL.AddGLAccountSummaryDetails(gLAccountSummaryDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountSummaryForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountSummaryForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            gLAccountSummaryDetailsFormUI.Tbl_GLAccountSummaryDetailsId = Request.QueryString["GLAccountSummaryDetailsId"];
            gLAccountSummaryDetailsFormUI.ModifiedBy = SessionContext.UserGuid;
            gLAccountSummaryDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            gLAccountSummaryDetailsFormUI.Tbl_GLAccountSummaryId = txtGLAccountSummaryGuid.Text;
            gLAccountSummaryDetailsFormUI.Tbl_FiscalPeriodId = txtFiscalPeriodGuid.Text;
            gLAccountSummaryDetailsFormUI.Period = Convert.ToInt32(txtPeriod.Text);
            gLAccountSummaryDetailsFormUI.PeriodName = txtPeriodName.Text;
            gLAccountSummaryDetailsFormUI.PeriodDate = Convert.ToDateTime(txtPeriodDate.Text);
            gLAccountSummaryDetailsFormUI.DebitAmount = Convert.ToDecimal(txtDebitAmount.Text);
            gLAccountSummaryDetailsFormUI.CreditAmount = Convert.ToDecimal(txtCreditAmount.Text);
            gLAccountSummaryDetailsFormUI.NetChageAmount = Convert.ToDecimal(txtNetChargeAmount.Text);
            gLAccountSummaryDetailsFormUI.PeriodBalanceAmount = Convert.ToDecimal(txtNetChargeAmount.Text);



            if (gLAccountSummaryDetailsFormBAL.UpdateGLAccountSummaryDetails(gLAccountSummaryDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : btnUpdate_Click] An error occured in the processing of Record Id : " + gLAccountSummaryDetailsFormUI.Tbl_GLAccountSummaryDetailsId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            gLAccountSummaryDetailsFormUI.Tbl_GLAccountSummaryDetailsId = Request.QueryString["GLAccountSummaryDetailsId"];

            if (gLAccountSummaryDetailsFormBAL.DeleteGLAccountSummaryDetails(gLAccountSummaryDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountSummaryForm.CS";
            logExcpUIobj.RecordId = gLAccountSummaryDetailsFormUI.Tbl_GLAccountSummaryDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountSummaryForm : btnDelete_Click] An error occured in the processing of Record Id : " + gLAccountSummaryDetailsFormUI.Tbl_GLAccountSummaryDetailsId + ". Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("GLAccountSummaryDetailsList.aspx");
    }

    #endregion Events

    #region Events Fiscal Period 
    protected void btnFiscalPeriodSearch_Click(object sender, EventArgs e)
    {
        btnHtmlFiscalPeriodSearch.Visible = false;
        btnHtmlFiscalPeriodClose.Visible = true;
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
        System.Threading.Thread.Sleep(1000);
        BindFiscalPeriodList();
    }
    #endregion

    #region Events GL Account
    protected void btnGLAccountSummarySearch_Click(object sender, EventArgs e)
    {
        btnHtmlGLAccountSummarySearch.Visible = false;
        btnHtmlGLAccountSummaryClose.Visible = true;
        SearchGLAccountSummaryList();

    }
    protected void btnClearGLAccountSummarySearch_Click(object sender, EventArgs e)
    {
        BindGLAccountSummaryList();
        gvGLAccountSummarySearch.Visible = true;
        btnHtmlGLAccountSummarySearch.Visible = true;
        btnHtmlGLAccountSummaryClose.Visible = false;
        txtGLAccountSummarySearch.Text = "";
        txtGLAccountSummarySearch.Focus();

    }
    protected void btnGLAccountSummaryRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindGLAccountSummaryList();
    }
    #endregion
   
    #region Fiscal Period 
    private void SearchFiscalPeriodList()
    {
        try
        {
            FiscalPeriodDetailsListBAL fiscalPeriodDetailsListBAL = new FiscalPeriodDetailsListBAL();
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountSummaryForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountSummaryForm : SearchFiscalPeriodSetupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
                lblFiscalPeriodSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvFiscalPeriodSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindFiscalPeriodList()";
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountSummaryForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountSummaryForm : BindFiscalPeriodSetupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Fiscal Period 

    #region Gl Account Summary
    private void SearchGLAccountSummaryList()
    {
        try
        {
            GLAccountSummaryListBAL gLAccountSummaryListBAL = new GLAccountSummaryListBAL();
            GLAccountSummaryListUI gLAccountSummaryListUI = new GLAccountSummaryListUI();

            gLAccountSummaryListUI.Search = txtGLAccountSummarySearch.Text;

            DataTable dtb = gLAccountSummaryListBAL.GetGLAccountSummaryListBySearchParameters(gLAccountSummaryListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountSummarySearch.DataSource = dtb;
                gvGLAccountSummarySearch.DataBind();
                divGLAccountSummarySearchError.Visible = false;
            }
            else
            {
                divGLAccountSummarySearchError.Visible = true;
                lblGLAccountSummarySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountSummarySearch.Visible = false;
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
    private void BindGLAccountSummaryList()
    {
        try
        {
            DataTable dtb = gLAccountSummaryListBAL.GetGLAccountSummaryList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountSummarySearch.DataSource = dtb;
                gvGLAccountSummarySearch.DataBind();
                divGLAccountSummarySearchError.Visible = false;
            }
            else
            {
                divGLAccountSummarySearchError.Visible = true;
                lblGLAccountSummarySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountSummarySearch.Visible = false;
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

    #region Methods
    private void FillForm(GLAccountSummaryDetailsFormUI gLAccountSummaryDetailsFormUI)
    {

        try
        {
            DataTable dtb = gLAccountSummaryDetailsFormBAL.GetGLAccountSummaryDetailsListById(gLAccountSummaryDetailsFormUI);

            if (dtb.Rows.Count > 0)
            {

                txtGLAccountSummaryGuid.Text= dtb.Rows[0]["tbl_GLAccountSummaryId"].ToString();
                txtGLAccountSummary.Text = dtb.Rows[0]["tbl_GLAccount"].ToString();
                txtFiscalPeriodGuid.Text = dtb.Rows[0]["tbl_FiscalPeriodId"].ToString();
                txtFiscalPeriod.Text = dtb.Rows[0]["tbl_FiscalPeriod"].ToString();
                txtPeriod.Text = dtb.Rows[0]["Period"].ToString();
                txtPeriodName.Text = dtb.Rows[0]["PeriodName"].ToString();
                txtPeriodDate.Text = dtb.Rows[0]["PeriodDate"].ToString();
                txtDebitAmount.Text = dtb.Rows[0]["DebitAmount"].ToString();
                txtCreditAmount.Text= dtb.Rows[0]["CreditAmount"].ToString();
                txtNetChargeAmount.Text = dtb.Rows[0]["NetChageAmount"].ToString();
                txtPeriodBalanceAmount.Text = dtb.Rows[0]["PeriodBalanceAmount"].ToString();




            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotLoadData;
                divError.Visible = true;
                divSuccess.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "FillForm()";
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountSummaryForm.CS";
            logExcpUIobj.RecordId = gLAccountSummaryDetailsFormUI.Tbl_GLAccountSummaryDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountSummaryForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods
}
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_General_Ledger_GL_Integration_GLAccountSummaryForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    GLAccountSummaryFormBAL gLAccountSummaryFormBAL = new GLAccountSummaryFormBAL();
    GLAccountSummaryFormUI gLAccountSummaryFormUI = new GLAccountSummaryFormUI();
    GLAccountSummaryListBAL gLAccountSummaryListBAL = new GLAccountSummaryListBAL();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    GLAccountListUI gLAccountListUI = new GLAccountListUI();
    FiscalPeriodListBAL fiscalPeriodListBAL = new FiscalPeriodListBAL();
    FiscalPeriodListUI fiscalPeriodListUI = new FiscalPeriodListUI();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        GLAccountSummaryFormUI gLAccountSummaryFormUI = new GLAccountSummaryFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["GLAccountSummaryId"] != null)
            {
                gLAccountSummaryFormUI.Tbl_GLAccountSummaryId = Request.QueryString["GLAccountSummaryId"];


                FillForm(gLAccountSummaryFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update GLAccountSummary";
            }
            else
            {



                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New GLAccountSummary";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            gLAccountSummaryFormUI.CreatedBy = SessionContext.UserGuid;
            gLAccountSummaryFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            gLAccountSummaryFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text;
            gLAccountSummaryFormUI.Tbl_FiscalPeriodId = txtFiscalPeriodGuid.Text;



            if (gLAccountSummaryFormBAL.AddGLAccountSummary(gLAccountSummaryFormUI) == 1)
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
            gLAccountSummaryFormUI.ModifiedBy = SessionContext.UserGuid;
            gLAccountSummaryFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            gLAccountSummaryFormUI.Tbl_GLAccountSummaryId = Request.QueryString["GLAccountSummaryId"];

            gLAccountSummaryFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text;
            gLAccountSummaryFormUI.Tbl_FiscalPeriodId = txtFiscalPeriodGuid.Text;




            if (gLAccountSummaryFormBAL.UpdateGLAccountSummary(gLAccountSummaryFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountSummaryForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountSummaryForm : btnUpdate_Click] An error occured in the processing of Record Id : " + gLAccountSummaryFormUI.Tbl_GLAccountSummaryId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            gLAccountSummaryFormUI.Tbl_GLAccountSummaryId = Request.QueryString["GLAccountSummaryId"];

            if (gLAccountSummaryFormBAL.DeleteGLAccountSummary(gLAccountSummaryFormUI) == 1)
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
            logExcpUIobj.RecordId = gLAccountSummaryFormUI.Tbl_GLAccountSummaryId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountSummaryForm : btnDelete_Click] An error occured in the processing of Record Id : " + gLAccountSummaryFormUI.Tbl_GLAccountSummaryId + ". Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("GLAccountSummaryList.aspx");
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

    #region Fiscal Period 
    private void SearchFiscalPeriodList()
    {
        try
        {
            FiscalPeriodListBAL fiscalPeriodListBAL = new FiscalPeriodListBAL();
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountSummaryForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountSummaryForm : SearchFiscalPeriodList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountSummaryForm : BindFiscalPeriodList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Fiscal Period 

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

    #region Methods
    private void FillForm(GLAccountSummaryFormUI gLAccountSummaryFormUI)
    {
        try
        {
            DataTable dtb = gLAccountSummaryFormBAL.GetGLAccountSummaryListById(gLAccountSummaryFormUI);

            if (dtb.Rows.Count > 0)
            {

                txtGLAccountGuid.Text = dtb.Rows[0]["tbl_GLAccountId"].ToString();
                txtGLAccount.Text = dtb.Rows[0]["AccountNumber"].ToString();
                txtFiscalPeriodGuid.Text = dtb.Rows[0]["tbl_FiscalPeriodId"].ToString();
                txtFiscalPeriod.Text = dtb.Rows[0]["NumberOfPeriod"].ToString();

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
            logExcpUIobj.RecordId = gLAccountSummaryFormUI.Tbl_GLAccountSummaryId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountSummaryForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods
}
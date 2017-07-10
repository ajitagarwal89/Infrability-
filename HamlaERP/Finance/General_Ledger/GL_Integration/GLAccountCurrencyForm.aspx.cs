using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_General_Ledger_GL_Integration_GLAccountCurrencyForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    GLAccountCurrencyFormBAL gLAccountCurrencyFormBAL = new GLAccountCurrencyFormBAL();
    GLAccountCurrencyFormUI gLAccountCurrencyFormUI = new GLAccountCurrencyFormUI();
    GLAccountCurrencyListBAL gLAccountCurrencyListBAL = new GLAccountCurrencyListBAL();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    GLAccountListUI gLAccountListUI = new GLAccountListUI();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    CurrencyListUI currencyListUI = new CurrencyListUI();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        GLAccountCurrencyFormUI gLAccountCurrencyFormUI = new GLAccountCurrencyFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["GLAccountCurrencyId"] != null)
            {
                gLAccountCurrencyFormUI.Tbl_GLAccountCurrencyId = Request.QueryString["GLAccountCurrencyId"];

                
                FillForm(gLAccountCurrencyFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update GLAccountCurrency";
            }
            else
            {

                

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New GLAccountCurrency";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            gLAccountCurrencyFormUI.CreatedBy = SessionContext.UserGuid;
            gLAccountCurrencyFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            gLAccountCurrencyFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text;
            gLAccountCurrencyFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;


            if (gLAccountCurrencyFormBAL.AddGLAccountCurrency(gLAccountCurrencyFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountCurrencyForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountCurrencyForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            gLAccountCurrencyFormUI.ModifiedBy = SessionContext.UserGuid;
            gLAccountCurrencyFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            gLAccountCurrencyFormUI.Tbl_GLAccountCurrencyId = Request.QueryString["GLAccountCurrencyId"];

            gLAccountCurrencyFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text;
            gLAccountCurrencyFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
          

            if (gLAccountCurrencyFormBAL.UpdateGLAccountCurrency(gLAccountCurrencyFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountCurrencyForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountCurrencyForm : btnUpdate_Click] An error occured in the processing of Record Id : " + gLAccountCurrencyFormUI.Tbl_GLAccountCurrencyId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            gLAccountCurrencyFormUI.Tbl_GLAccountCurrencyId = Request.QueryString["GLAccountCurrencyId"];

            if (gLAccountCurrencyFormBAL.DeleteGLAccountCurrency(gLAccountCurrencyFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountCurrencyForm.CS";
            logExcpUIobj.RecordId = gLAccountCurrencyFormUI.Tbl_GLAccountCurrencyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountCurrencyForm : btnDelete_Click] An error occured in the processing of Record Id : " + gLAccountCurrencyFormUI.Tbl_GLAccountCurrencyId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("GLAccountCurrencyList.aspx");
    }
    #endregion Events

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

    #region Currency Search
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

    #endregion

    #region Methods And Bind
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountCurrencyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountCurrencyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountCurrencyForm : BindGLAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

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
            logExcpUIobj.ResourceName = "System_Settings_CurrencyList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_CurrencyList : SearchCurrency] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "System_Settings_CurrencyList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[System_Settings_CurrencyList : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion

    #region Methods
    private void FillForm(GLAccountCurrencyFormUI gLAccountCurrencyFormUI)
    {
        try
        {
            DataTable dtb = gLAccountCurrencyFormBAL.GetGLAccountCurrencyListById(gLAccountCurrencyFormUI);

            if (dtb.Rows.Count > 0)
            {

                txtGLAccountGuid.Text = dtb.Rows[0]["tbl_GLAccountId"].ToString();
                txtGLAccount.Text = dtb.Rows[0]["tbl_GLAccount"].ToString();
                txtCurrencyGuid.Text= dtb.Rows[0]["tbl_CurrencyId"].ToString();
                txtCurrency.Text= dtb.Rows[0]["CurrencyName"].ToString();

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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountCurrencyForm.CS";
            logExcpUIobj.RecordId = gLAccountCurrencyFormUI.Tbl_GLAccountCurrencyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountCurrencyForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods
}
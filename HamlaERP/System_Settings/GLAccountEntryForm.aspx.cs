using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;
using System.Globalization;

public partial class System_Settings_GLAccountEntryForm : PageBase
{

    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    BatchListBAL batchListBAL = new BatchListBAL();
    SourceDocumentListBAL sourceDocumentListBAL = new SourceDocumentListBAL();
    GLAccountEntryFormBAL gLAccountEntryFormBAL = new GLAccountEntryFormBAL();
    GLAccountEntryFormUI gLAccountEntryFormUI = new GLAccountEntryFormUI();
    DateTime date;
    #endregion

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        GLAccountEntryFormUI gLAccountEntryFormUI = new GLAccountEntryFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["GLAccountEntryId"] != null)
            {
                gLAccountEntryFormUI.Tbl_GLAccountEntryId = Request.QueryString["GLAccountEntryId"];

                FillForm(gLAccountEntryFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update GLAccountEntry";
            }
            else
            {



                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New GLAccountEntry";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            gLAccountEntryFormUI.CreatedBy = SessionContext.UserGuid;
            gLAccountEntryFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            gLAccountEntryFormUI.JournalEntry = txtJournal.Text;                      

            gLAccountEntryFormUI.Tbl_BatchId = txtBatchGuid.Text;
            if (chkTransactionType.Checked == true)
                gLAccountEntryFormUI.TransactionType = true;
            else
                gLAccountEntryFormUI.TransactionType = false;

            gLAccountEntryFormUI.TransactionDate = DateTime.Parse(txtTransactionDate.Text.ToString());

            gLAccountEntryFormUI.Tbl_SourceDocument = txtSourceDocumentGuid.Text;
            gLAccountEntryFormUI.Reference = txtReference.Text;
            gLAccountEntryFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            if (gLAccountEntryFormBAL.AddGLAccountEntry(gLAccountEntryFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_GLAccountEntryForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountEntryForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            gLAccountEntryFormUI.ModifiedBy = SessionContext.UserGuid;
            gLAccountEntryFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            gLAccountEntryFormUI.Tbl_GLAccountEntryId = Request.QueryString["GLAccountEntryId"];
            gLAccountEntryFormUI.JournalEntry = txtJournal.Text;

            gLAccountEntryFormUI.Tbl_BatchId = txtBatchGuid.Text;
            if (chkTransactionType.Checked == true)
                gLAccountEntryFormUI.TransactionType = true;
            else
                gLAccountEntryFormUI.TransactionType = false;

            gLAccountEntryFormUI.TransactionDate = DateTime.Parse(txtTransactionDate.Text.ToString());

            gLAccountEntryFormUI.Tbl_SourceDocument = txtSourceDocumentGuid.Text;
            gLAccountEntryFormUI.Reference = txtReference.Text;
            gLAccountEntryFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;






            if (gLAccountEntryFormBAL.UpdateGLAccountEntry(gLAccountEntryFormUI) == 1)
            {
                divSuccess.Visible = true;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "System_Settings_GLAccountEntryForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountEntryForm : btnUpdate_Click] An error occured in the processing of Record Id : " + gLAccountEntryFormUI.Tbl_GLAccountEntryId + ".  Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            gLAccountEntryFormUI.Tbl_GLAccountEntryId = Request.QueryString["GLAccountEntryId"];

            if (gLAccountEntryFormBAL.DeleteGLAccountEntry(gLAccountEntryFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_GLAccountEntryForm.CS";
            logExcpUIobj.RecordId = gLAccountEntryFormUI.Tbl_GLAccountEntryId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountEntryForm : btnDelete_Click] An error occured in the processing of Record Id : " + gLAccountEntryFormUI.Tbl_GLAccountEntryId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("GLAccountEntryList.aspx");
    }


    #region Batch Search


    #endregion
    #endregion

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
  
    #endregion

    #region Methods

    private void FillForm(GLAccountEntryFormUI gLAccountEntryFormUI)
    {
        try
        {

            DataTable dtb = gLAccountEntryFormBAL.GetGLAccountEntryListById(gLAccountEntryFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtJournal.Text = dtb.Rows[0]["JournalEntry"].ToString();
                txtBatchGuid.Text = dtb.Rows[0]["Tbl_BatchId"].ToString();
                txtBatch.Text = dtb.Rows[0]["BatchName"].ToString();
                if (Convert.ToBoolean(dtb.Rows[0]["TransactionType"]) == true)
          
                    chkTransactionType.Checked = true;
                else
                    chkTransactionType.Checked = false;

               
                if (DateTime.TryParseExact(txtTransactionDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                                           DateTimeStyles.None, out date))
                    txtTransactionDate.Text =dtb.Rows[0]["TransactionDate"].ToString();
                txtSourceDocument.Text = dtb.Rows[0]["SourceDocumentName"].ToString();
                txtSourceDocumentGuid.Text = dtb.Rows[0]["Tbl_SourceDocument"].ToString();
                txtReference.Text = dtb.Rows[0]["Reference"].ToString();
                txtCurrency.Text = dtb.Rows[0]["CurrencyName"].ToString();
                txtCurrencyGuid.Text = dtb.Rows[0]["Tbl_CurrencyId"].ToString();
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
            logExcpUIobj.RecordId = gLAccountEntryFormUI.Tbl_GLAccountEntryId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountEntryForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "System_Settings_GLAccountEntryForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountEntryForm : SearchBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "System_Settings_GLAccountEntryForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountEntryForm : BindBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "System_Settings_GLAccountEntryForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountEntryForm : SearchSource_DocumentList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "System_Settings_GLAccountEntryForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountEntryForm : BindDocumentSearchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
    #endregion Currency
    #endregion
}
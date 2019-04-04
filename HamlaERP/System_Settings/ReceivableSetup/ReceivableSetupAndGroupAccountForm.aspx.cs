using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_ReceivableSetupAndGroupAccountForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    ChequeBookListBAL chequeBookListBAL = new ChequeBookListBAL();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();

      ReceivableSetupListBAL receivableSetupListBAL = new ReceivableSetupListBAL();
      ReceivableSetupGroupListBAL receivableSetupGroupListBAL = new ReceivableSetupGroupListBAL();
    ReceivableSetupAndGroupAccountFormBAL receivableSetupAndGroupAccountFormBAL = new ReceivableSetupAndGroupAccountFormBAL();
    ReceivableSetupAndGroupAccountFormUI receivableSetupAndGroupAccountFormUI = new ReceivableSetupAndGroupAccountFormUI();

    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        ReceivableSetupAndGroupAccountFormUI receivableSetupAndGroupAccountFormUI = new ReceivableSetupAndGroupAccountFormUI();


        if (!Page.IsPostBack)
        {
     
            if (Request.QueryString["ReceivableSetupAndGroupAccountId"] != null || Request.QueryString["recordId"] != null)
            {
                receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupAndGroupAccountId = (Request.QueryString["ReceivableSetupAndGroupAccountId"] != null ? Request.QueryString["BatchId"] : Request.QueryString["recordId"]);
                FillForm(receivableSetupAndGroupAccountFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Receivable Setup AndG roupAccount";
            }
            else
            {


                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New Receivable Setup And GroupAccount";
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ReceivableSetupAndGroupAccountFormUI receivableSetupAndGroupAccountFormUI = new ReceivableSetupAndGroupAccountFormUI();
            receivableSetupAndGroupAccountFormUI.CreatedBy = SessionContext.UserGuid;
            receivableSetupAndGroupAccountFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupId = txtReceivableSetupGuid.Text;
            receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupGroupId = txtRecievableSetupGroupGuid.Text;
            receivableSetupAndGroupAccountFormUI.Description= txtDescription.Text;
            receivableSetupAndGroupAccountFormUI.Tbl_ChequeBookId = txtChequeBookGuid.Text;
            if (chkCashAccountFrom.Checked)
            { receivableSetupAndGroupAccountFormUI.CashAccountFrom =true; }
            else
            { receivableSetupAndGroupAccountFormUI.CashAccountFrom = false; }
            receivableSetupAndGroupAccountFormUI.Tbl_GLAccountId_Cash= txtGLAccountId_CashGuid.Text;
            receivableSetupAndGroupAccountFormUI.Tbl_GLAccountId_AccountReceivable = txtGLAccountId_AccountReceivableGuid.Text;
            receivableSetupAndGroupAccountFormUI.Tbl_GLAccountId_Sales = txtGLAccountId_SalesGuid.Text;
            receivableSetupAndGroupAccountFormUI.Tbl_GLAccountId_CostOfSales = txtGLAccountId_CostOfSalesGuid.Text;
            receivableSetupAndGroupAccountFormUI.Tbl_GLAccountId_Inventory = txtGLAccountId_InventoryGuid.Text;
            receivableSetupAndGroupAccountFormUI.Tbl_GLAccountId_AccuralDifferedA_C = txtGLAccountId_AccuralDifferedA_CGuid.Text;
            if (receivableSetupAndGroupAccountFormBAL.AddReceivableSetupAndGroupAccount(receivableSetupAndGroupAccountFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_ReceivableSetupAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableSetupAndGroupAccountForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            receivableSetupAndGroupAccountFormUI.ModifiedBy = SessionContext.UserGuid;
            receivableSetupAndGroupAccountFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupAndGroupAccountId = Request.QueryString["ReceivableSetupAndGroupAccountId"];
            receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupId = txtReceivableSetupGuid.Text;
            receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupGroupId = txtRecievableSetupGroupGuid.Text;
            receivableSetupAndGroupAccountFormUI.Description = txtDescription.Text;
            receivableSetupAndGroupAccountFormUI.Tbl_ChequeBookId = txtChequeBookGuid.Text;
            if (chkCashAccountFrom.Checked)
            { receivableSetupAndGroupAccountFormUI.CashAccountFrom = true; }
            else
            { receivableSetupAndGroupAccountFormUI.CashAccountFrom = false; }
            receivableSetupAndGroupAccountFormUI.Tbl_GLAccountId_Cash = txtGLAccountId_CashGuid.Text;
            receivableSetupAndGroupAccountFormUI.Tbl_GLAccountId_AccountReceivable = txtGLAccountId_AccountReceivableGuid.Text;
            receivableSetupAndGroupAccountFormUI.Tbl_GLAccountId_Sales = txtGLAccountId_SalesGuid.Text;
            receivableSetupAndGroupAccountFormUI.Tbl_GLAccountId_CostOfSales = txtGLAccountId_CostOfSalesGuid.Text;
            receivableSetupAndGroupAccountFormUI.Tbl_GLAccountId_Inventory = txtGLAccountId_InventoryGuid.Text;
            receivableSetupAndGroupAccountFormUI.Tbl_GLAccountId_AccuralDifferedA_C = txtGLAccountId_AccuralDifferedA_CGuid.Text;
            if (receivableSetupAndGroupAccountFormBAL.UpdateReceivableSetupAndGroupAccount(receivableSetupAndGroupAccountFormUI) == 1)



                if (receivableSetupAndGroupAccountFormBAL.UpdateReceivableSetupAndGroupAccount(receivableSetupAndGroupAccountFormUI) == 1)
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
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableSetupAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableSetupAndGroupAccountForm : btnUpdate_Click] An error occured in the processing of Record Id : " + receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupAndGroupAccountId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ReceivableSetupAndGroupAccountFormUI receivableSetupAndGroupAccountFormUI = new ReceivableSetupAndGroupAccountFormUI();
        try
        {
            receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupAndGroupAccountId = Request.QueryString["BatchId"];

            if (receivableSetupAndGroupAccountFormBAL.DeleteReceivableSetupAndGroupAccount(receivableSetupAndGroupAccountFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : btnDelete_Click] An error occured in the processing of Record Id : " + receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReceivableSetupAndGroupAccountList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/System_Settings/ReceivableSetupAndGroupAccountForm.aspx";
        string recordId = Request.QueryString["ReceivableSetupAndGroupAccountId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    #region Recievable Setup  Event
    protected void btnRecievableSetupSearch_Click(object sender, EventArgs e)
    {
        btnHtmlRecievableSetupSearch.Visible = false;
        btnHtmlRecievableSetupClose.Visible = true;
        SearchRecievableSetupList();
    }
    protected void btnClearRecievableSetupSearch_Click(object sender, EventArgs e)
    {
        BindRecievableSetupList();
        gvRecievableSetupSearch.Visible = true;
        btnHtmlRecievableSetupSearch.Visible = true;
        btnHtmlRecievableSetupClose.Visible = false;
        txtRecievableSetupSearch.Text = "";
        txtRecievableSetupSearch.Focus();
    }
    protected void btnRecievableSetupRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindRecievableSetupList();
    }
    #endregion Recievable event


    #region Recievable Setup Group Event
    protected void btnRecievableSetupGroupSearch_Click(object sender, EventArgs e)
    {
        btnHtmlRecievableSetupGroupSearch.Visible = false;
        btnHtmlRecievableSetupGroupClose.Visible = true;
        SearchRecievableSetupGroupList();
    }
    protected void btnClearRecievableSetupGroupSearch_Click(object sender, EventArgs e)
    {
        BindRecievableSetupGroupList();
        gvRecievableSetupGroupSearch.Visible = true;
        btnHtmlRecievableSetupGroupSearch.Visible = true;
        btnHtmlRecievableSetupGroupClose.Visible = false;
        txtRecievableSetupGroupSearch.Text = "";
        txtRecievableSetupGroupSearch.Focus();
    }
    protected void btnRecievableSetupGroupRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindRecievableSetupGroupList();
    }
    #endregion Recievable event


    #region Cheque book Event
    protected void btnChequeBookSearch_Click(object sender, EventArgs e)
    {
        btnHtmlChequeBookSearch.Visible = false;
        btnHtmlChequeBookClose.Visible = true;
        SearchChequeBookList();

    }
    protected void btnClearChequeBookSearch_Click(object sender, EventArgs e)
    {
        BindChequeBookList();
        gvChequeBookSearch.Visible = true;
        btnHtmlChequeBookSearch.Visible = true;
        btnHtmlChequeBookClose.Visible = false;
        txtChequeBook.Text = "";
        txtChequeBook.Focus();

    }
    protected void btnChequeBookRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindChequeBookList();
    }

    #endregion Cheque book event

    #region GLAccountId cash

    protected void btnGLAccountId_CashSearch_Click(object sender, EventArgs e)
    {
        btnHtmlGLAccountId_CashSearch.Visible = false;
        btnHtmlGLAccountId_CashClose.Visible = true;
        SearchGLAccountId_CashList();

    }
    protected void btnClearGLAccountId_CashSearch_Click(object sender, EventArgs e)
    {
        BindGLAccountId_CashList();
        gvGLAccountId_CashSearch.Visible = true;
        btnHtmlGLAccountId_CashSearch.Visible = true;
        btnHtmlGLAccountId_CashClose.Visible = false;
        txtGLAccountId_CashSearch.Text = "";
        txtGLAccountId_CashSearch.Focus();

    }
    protected void btnGLAccountId_CashRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindGLAccountId_CashList();
    }

    #endregion

    #region GLAccountId_AccountReceivable
    protected void btnGLAccountId_AccountReceivableSearch_Click(object sender, EventArgs e)
    {
        btnHtmlGLAccountId_AccountReceivableSearch.Visible = false;
        btnHtmlGLAccountId_AccountReceivableClose.Visible = true;
        SearchGLAccountId_AccountReceivableList();

    }
    protected void btnClearGLAccountId_AccountReceivableSearch_Click(object sender, EventArgs e)
    {
        BindGLAccountId_AccountReceivableList();
        gvGLAccountId_AccountReceivableSearch.Visible = true;
        btnHtmlGLAccountId_AccountReceivableSearch.Visible = true;
        btnHtmlGLAccountId_AccountReceivableClose.Visible = false;
        txtGLAccountId_AccountReceivableSearch.Text = "";
        txtGLAccountId_AccountReceivableSearch.Focus();

    }
    protected void btnGLAccountId_AccountReceivableRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindGLAccountId_AccountReceivableList();
    }

    #endregion

    #region  GLAccountId_Sales
    protected void btnGLAccountId_SalesSearch_Click(object sender, EventArgs e)
    {
        btnHtmlGLAccountId_SalesSearch.Visible = false;
        btnHtmlGLAccountId_SalesClose.Visible = true;
        SearchGLAccountId_SalesList();

    }
    protected void btnClearGLAccountId_SalesSearch_Click(object sender, EventArgs e)
    {
        BindGLAccountId_SalesList();
        gvGLAccountId_SalesSearch.Visible = true;
        btnHtmlGLAccountId_SalesSearch.Visible = true;
        btnHtmlGLAccountId_SalesClose.Visible = false;
        txtGLAccountId_SalesSearch.Text = "";
        txtGLAccountId_SalesSearch.Focus();

    }
    protected void btnGLAccountId_SalesRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindGLAccountId_SalesList();
    }
    #endregion

    #region  GLAccountId_CostOfSales
    protected void btnGLAccountId_CostOfSalesSearch_Click(object sender, EventArgs e)
    {
        btnHtmlGLAccountId_CostOfSalesSearch.Visible = false;
        btnHtmlGLAccountId_CostOfSalesClose.Visible = true;
        SearchGLAccountId_CostOfSalesList();

    }
    protected void btnClearGLAccountId_CostOfSalesSearch_Click(object sender, EventArgs e)
    {
        BindGLAccountId_CostOfSalesList();
        gvGLAccountId_CostOfSalesSearch.Visible = true;
        btnHtmlGLAccountId_CostOfSalesSearch.Visible = true;
        btnHtmlGLAccountId_CostOfSalesClose.Visible = false;
        txtGLAccountId_CostOfSalesSearch.Text = "";
        txtGLAccountId_CostOfSalesSearch.Focus();

    }
    protected void btnGLAccountId_CostOfSalesRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindGLAccountId_CostOfSalesList();
    }
    #endregion

    #region  GLAccountId_Inventory
    protected void btnGLAccountId_InventorySearch_Click(object sender, EventArgs e)
    {
        btnHtmlGLAccountId_InventorySearch.Visible = false;
        btnHtmlGLAccountId_InventoryClose.Visible = true;
        SearchGLAccountId_InventoryList();

    }
    protected void btnClearGLAccountId_InventorySearch_Click(object sender, EventArgs e)
    {
        BindGLAccountId_InventoryList();
        gvGLAccountId_InventorySearch.Visible = true;
        btnHtmlGLAccountId_InventorySearch.Visible = true;
        btnHtmlGLAccountId_InventoryClose.Visible = false;
        txtGLAccountId_InventorySearch.Text = "";
        txtGLAccountId_InventorySearch.Focus();

    }
    protected void btnGLAccountId_InventoryRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindGLAccountId_InventoryList();
    }
    #endregion

    #region  GLAccountId_AccuralDifferedA_C
    protected void btnGLAccountId_AccuralDifferedA_CSearch_Click(object sender, EventArgs e)
    {
        btnHtmlGLAccountId_AccuralDifferedA_CSearch.Visible = false;
        btnHtmlGLAccountId_AccuralDifferedA_CClose.Visible = true;
        SearchGLAccountId_AccuralDifferedA_CList();

    }
    protected void btnClearGLAccountId_AccuralDifferedA_CSearch_Click(object sender, EventArgs e)
    {
        BindGLAccountId_AccuralDifferedA_CList();
        gvGLAccountId_AccuralDifferedA_CSearch.Visible = true;
        btnHtmlGLAccountId_AccuralDifferedA_CSearch.Visible = true;
        btnHtmlGLAccountId_AccuralDifferedA_CClose.Visible = false;
        txtGLAccountId_AccuralDifferedA_CSearch.Text = "";
        txtGLAccountId_AccuralDifferedA_CSearch.Focus();

    }
    protected void btnGLAccountId_AccuralDifferedA_CRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindGLAccountId_AccuralDifferedA_CList();
    }
    #endregion



    #endregion Events
    #region Methods
    private void FillForm(ReceivableSetupAndGroupAccountFormUI receivableSetupAndGroupAccountFormUI)
    {
        try
        {
            receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupAndGroupAccountId = Request.QueryString["ReceivableSetupAndGroupAccountId"];
            DataTable dtb = receivableSetupAndGroupAccountFormBAL.GetReceivableSetupAndGroupAccountListById(receivableSetupAndGroupAccountFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtReceivableSetup.Text = dtb.Rows[0]["tbl_ReceivableSetup"].ToString();
                txtReceivableSetupGuid.Text = dtb.Rows[0]["tbl_ReceivableSetupId"].ToString();
                txtRecievableSetupGroup.Text = dtb.Rows[0]["tbl_ReceivableSetupGroup"].ToString();
                txtRecievableSetupGroupGuid.Text=dtb.Rows[0]["tbl_ReceivableSetupGroupId"].ToString();
                txtDescription.Text= dtb.Rows[0]["Description"].ToString();
                txtChequeBook.Text=dtb.Rows[0]["ChequeBookName"].ToString();
                txtChequeBookGuid.Text= dtb.Rows[0]["tbl_ChequeBookId"].ToString();
                if (Convert.ToBoolean(dtb.Rows[0]["CashAccountFrom"])==true)
                    {
                    chkCashAccountFrom.Checked = true; }
                else { chkCashAccountFrom.Checked = false; }
                txtGLAccountId_Cash.Text= dtb.Rows[0]["Cash"].ToString();
                txtGLAccountId_CashGuid.Text = dtb.Rows[0]["tbl_GLAccountId_Cash"].ToString();
                txtGLAccountId_AccountReceivable.Text = dtb.Rows[0]["AccountReceivable"].ToString();
                txtGLAccountId_AccountReceivableGuid.Text = dtb.Rows[0]["tbl_GLAccountId_AccountReceivable"].ToString();
                txtGLAccountId_Sales.Text = dtb.Rows[0]["Sales"].ToString();
                txtGLAccountId_SalesGuid.Text = dtb.Rows[0]["tbl_GLAccountId_Sales"].ToString();
                txtGLAccountId_CostOfSales.Text= dtb.Rows[0]["CostOfSales"].ToString();
                txtGLAccountId_CostOfSalesGuid.Text= dtb.Rows[0]["tbl_GLAccountId_CostOfSales"].ToString();
                txtGLAccountId_InventoryGuid.Text= dtb.Rows[0]["tbl_GLAccountId_Inventory"].ToString();
                txtGLAccountId_Inventory.Text= dtb.Rows[0]["Inventory"].ToString();
                txtGLAccountId_AccuralDifferedA_CGuid.Text = dtb.Rows[0]["tbl_GLAccountId_AccuralDifferedA_C"].ToString();
                txtGLAccountId_AccuralDifferedA_C.Text = dtb.Rows[0]["AccuralDifferedA_C"].ToString();

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
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region RecievableSetup
    private void BindRecievableSetupList()
    {
        try
        {
            DataTable dtb = receivableSetupListBAL.GetReceivableSetupList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvRecievableSetupSearch.DataSource = dtb;
                gvRecievableSetupSearch.DataBind();
                divRecievableSetupSearchError.Visible = false;

            }
            else
            {
                divRecievableSetupSearchError.Visible = true;
                lblRecievableSetupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvRecievableSetupSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCustomerList()";
            logExcpUIobj.ResourceName = "System_Settings_CurrencyList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_CurrencyList : BindCustomerList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void SearchRecievableSetupList()
    {
        try
        {
            ReceivableSetupListUI receivableSetupListUI = new ReceivableSetupListUI();
            receivableSetupListUI.Search = txtRecievableSetupSearch.Text;
            DataTable dtb = receivableSetupListBAL.GetReceivableSetupListBySearchParameters(receivableSetupListUI);


            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvRecievableSetupSearch.DataSource = dtb;
                gvRecievableSetupSearch.DataBind();
                divRecievableSetupSearchError.Visible = false;

            }
            else
            {
                divRecievableSetupSearchError.Visible = true;
                lblRecievableSetupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvRecievableSetupSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchRecievableSetupGroup()";
            logExcpUIobj.ResourceName = "System_Settings_CurrencyList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_CurrencyList : SearchCustomer] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion

    #region SearchChequeBook
    private void SearchChequeBookList()
    {

        {
            try
            {
                ChequeBookListBAL chequeBookListBAL = new ChequeBookListBAL();
                ChequeBookListUI chequeBookListUI = new ChequeBookListUI();


                chequeBookListUI.Search = txtChequeBookSearch.Text;

                DataTable dtb = chequeBookListBAL.GetChequeBookListBySearchParameters(chequeBookListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    gvChequeBookSearch.DataSource = dtb;
                    gvChequeBookSearch.DataBind();
                    divChequeBookSearchError.Visible = false;
                }
                else
                {
                    divChequeBookSearchError.Visible = true;
                    lblChequeBookSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                    gvChequeBookSearch.Visible = false;
                }

            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "SearchChequeBookList()";
                logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
                logExcpUIobj.RecordId = "All";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : SearchChequeBookList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
        }
    }
    private void BindChequeBookList()
    {
        try
        {
            DataTable dtb = chequeBookListBAL.GetChequeBookList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvChequeBookSearch.DataSource = dtb;
                gvChequeBookSearch.DataBind();
                divChequeBookSearchError.Visible = false;
            }
            else
            {
                divChequeBookSearchError.Visible = true;
                lblChequeBookSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvChequeBookSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindChequeBookList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : BindCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion

    #region ReceivableSetupGroup
    private void BindRecievableSetupGroupList()
    {
        try
        {
            DataTable dtb = receivableSetupGroupListBAL.GetReceivableSetupGroupList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvRecievableSetupGroupSearch.DataSource = dtb;
                gvRecievableSetupGroupSearch.DataBind();
                divRecievableSetupGroupSearchError.Visible = false;

            }
            else
            {
                divRecievableSetupGroupSearchError.Visible = true;
                lblRecievableSetupGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvRecievableSetupGroupSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCustomerList()";
            logExcpUIobj.ResourceName = "System_Settings_CurrencyList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_CurrencyList : BindCustomerList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void SearchRecievableSetupGroupList()
    {
        try
        {
            ReceivableSetupGroupListUI receivableSetupGroupListUI = new ReceivableSetupGroupListUI();
            receivableSetupGroupListUI.Search = txtRecievableSetupGroupSearch.Text;
            DataTable dtb = receivableSetupGroupListBAL.GetReceivableSetupGroupListBySearchParameters(receivableSetupGroupListUI);


            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvRecievableSetupGroupSearch.DataSource = dtb;
                gvRecievableSetupGroupSearch.DataBind();
                divRecievableSetupGroupSearchError.Visible = false;

            }
            else
            {
                divRecievableSetupGroupSearchError.Visible = true;
                lblRecievableSetupGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvRecievableSetupGroupSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchRecievableSetupGroup()";
            logExcpUIobj.ResourceName = "System_Settings_CurrencyList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_CurrencyList : SearchCustomer] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion

    #region GLAccountId_Cash
    private void SearchGLAccountId_CashList()
    {
        try
        {
            GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtGLAccountId_CashSearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountId_CashSearch.DataSource = dtb;
                gvGLAccountId_CashSearch.DataBind();
                divGLAccountId_CashSearchError.Visible = false;
            }
            else
            {
                divGLAccountId_CashSearchError.Visible = true;
                lblGLAccountId_CashSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountId_CashSearch.Visible = false;
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
    private void BindGLAccountId_CashList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountId_CashSearch.DataSource = dtb;
                gvGLAccountId_CashSearch.DataBind();
                divGLAccountId_CashSearchError.Visible = false;
            }
            else
            {
                divGLAccountId_CashSearchError.Visible = true;
                lblGLAccountId_CashSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountId_CashSearch.Visible = false;
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

    # region BindGLAccountId_AccountReceivableList
    private void BindGLAccountId_AccountReceivableList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountId_AccountReceivableSearch.DataSource = dtb;
                gvGLAccountId_AccountReceivableSearch.DataBind();
                divGLAccountId_AccountReceivableSearchError.Visible = false;
            }
            else
            {
                divGLAccountId_AccountReceivableSearchError.Visible = true;
                lblGLAccountId_AccountReceivableSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountId_AccountReceivableSearch.Visible = false;
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
    private void SearchGLAccountId_AccountReceivableList()
    {
        try
        {
            GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtGLAccountId_AccountReceivableSearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountId_AccountReceivableSearch.DataSource = dtb;
                gvGLAccountId_AccountReceivableSearch.DataBind();
                divGLAccountId_AccountReceivableSearchError.Visible = false;
            }
            else
            {
                divGLAccountId_AccountReceivableSearchError.Visible = true;
                lblGLAccountId_AccountReceivableSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountId_AccountReceivableSearch.Visible = false;
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

    #endregion
    #region GLAccountId_Sales
    private void BindGLAccountId_SalesList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountId_SalesSearch.DataSource = dtb;
                gvGLAccountId_SalesSearch.DataBind();
                divGLAccountId_SalesSearchError.Visible = false;
            }
            else
            {
                divGLAccountId_SalesSearchError.Visible = true;
                lblGLAccountId_SalesSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountId_SalesSearch.Visible = false;
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
    private void SearchGLAccountId_SalesList()
    {
        try
        {
            GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtGLAccountId_SalesSearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountId_SalesSearch.DataSource = dtb;
                gvGLAccountId_SalesSearch.DataBind();
                divGLAccountId_SalesSearchError.Visible = false;
            }
            else
            {
                divGLAccountId_SalesSearchError.Visible = true;
                lblGLAccountId_SalesSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountId_SalesSearch.Visible = false;
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
    #endregion

    #region GLAccountId_CostOfSales
    private void BindGLAccountId_CostOfSalesList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountId_CostOfSalesSearch.DataSource = dtb;
                gvGLAccountId_CostOfSalesSearch.DataBind();
                divGLAccountId_CostOfSalesSearchError.Visible = false;
            }
            else
            {
                divGLAccountId_CostOfSalesSearchError.Visible = true;
                lblGLAccountId_CostOfSalesSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountId_CostOfSalesSearch.Visible = false;
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
    private void SearchGLAccountId_CostOfSalesList()
    {
        try
        {
            GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtGLAccountId_CostOfSalesSearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountId_CostOfSalesSearch.DataSource = dtb;
                gvGLAccountId_CostOfSalesSearch.DataBind();
                divGLAccountId_CostOfSalesSearchError.Visible = false;
            }
            else
            {
                divGLAccountId_CostOfSalesSearchError.Visible = true;
                lblGLAccountId_CostOfSalesSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountId_CostOfSalesSearch.Visible = false;
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

    #endregion


    #region GLAccountId_Inventory
    private void BindGLAccountId_InventoryList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountId_InventorySearch.DataSource = dtb;
                gvGLAccountId_InventorySearch.DataBind();
                divGLAccountId_InventorySearchError.Visible = false;
            }
            else
            {
                divGLAccountId_InventorySearchError.Visible = true;
                lblGLAccountId_InventorySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountId_InventorySearch.Visible = false;
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
    private void SearchGLAccountId_InventoryList()
    {
        try
        {
            GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtGLAccountId_InventorySearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountId_InventorySearch.DataSource = dtb;
                gvGLAccountId_InventorySearch.DataBind();
                divGLAccountId_InventorySearchError.Visible = false;
            }
            else
            {
                divGLAccountId_InventorySearchError.Visible = true;
                lblGLAccountId_InventorySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountId_InventorySearch.Visible = false;
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

    #endregion
    #region GLAccountId_AccuralDifferedA_C
    private void BindGLAccountId_AccuralDifferedA_CList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountId_AccuralDifferedA_CSearch.DataSource = dtb;
                gvGLAccountId_AccuralDifferedA_CSearch.DataBind();
                divGLAccountId_AccuralDifferedA_CSearchError.Visible = false;
            }
            else
            {
                divGLAccountId_AccuralDifferedA_CSearchError.Visible = true;
                lblGLAccountId_AccuralDifferedA_CSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountId_AccuralDifferedA_CSearch.Visible = false;
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
    private void SearchGLAccountId_AccuralDifferedA_CList()
    {
        try
        {
            GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtGLAccountId_AccuralDifferedA_CSearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountId_AccuralDifferedA_CSearch.DataSource = dtb;
                gvGLAccountId_AccuralDifferedA_CSearch.DataBind();
                divGLAccountId_AccuralDifferedA_CSearchError.Visible = false;
            }
            else
            {
                divGLAccountId_AccuralDifferedA_CSearchError.Visible = true;
                lblGLAccountId_AccuralDifferedA_CSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountId_AccuralDifferedA_CSearch.Visible = false;
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

    #endregion

    #endregion Methods

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using log4net;
using Finware;
using System.Data.SqlClient;

public partial class Finance_Accounts_Payable_Setup_PayableSetupForm : PageBase
{

    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    PayableSetupPeriod_FormUI payableSetupPeriodFormUI = new PayableSetupPeriod_FormUI();
    PayableSetupPeriodFormBAL payableSetupPeriodFormBAL = new PayableSetupPeriodFormBAL();
    PayableSetupFormUI payableSetupFormUI = new PayableSetupFormUI();
    PayableSetupFormBAL payableSetupFormBal = new PayableSetupFormBAL();
    PayableSetupListBAL payableSetupListBal = new PayableSetupListBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    ChequeBookListBAL chequeBookListBAL = new ChequeBookListBAL();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    PayableSetupGroupListBAL payableSetupAndGroupListBAL = new PayableSetupGroupListBAL();
    PayableSetupAndGroupAccountFormUI payableSetupAndGroupAccountFormUI = new PayableSetupAndGroupAccountFormUI();
    PayableSetupAndGroupAccountFormBAL payableSetupAndGroupAccountFormBAL = new PayableSetupAndGroupAccountFormBAL();
    PayableSetupAndGroupAccountListBAL payableSetupAndGroupAccountListBAL = new PayableSetupAndGroupAccountListBAL();
    #endregion Data Members

    protected override void Page_Load(object sender, EventArgs e)
    {


        PayableSetupFormUI payableSetupFormUI = new PayableSetupFormUI();
        if (!Page.IsPostBack)
        {
            
            BindDocumentTypeDropDownList();
            if (Request.QueryString["PayableSetupId"] != null || Request.QueryString["recordId"] != null)
            {
                payableSetupFormUI.Tbl_PayableSetupId = (Request.QueryString["PayableSetupId"] != null ? Request.QueryString["PayableSetupId"] : Request.QueryString["recordId"]);
                FillForm(payableSetupFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Payable Setup";
                BindList();
            }
            else
            {


                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New Payable Setup";
                BindList();
            }
        }


    }
   
    #region Methods
    private void FillForm(PayableSetupFormUI payableSetupFormUI)
    {
        try
        {
            DataTable dtb = payableSetupFormBal.GetPayableSetupListById(payableSetupFormUI);

            if (dtb.Rows.Count > 0)
            {

                txtChequeBook.Text = dtb.Rows[0]["tbl_ChequeBook"].ToString();
                txtChequeBookGuid.Text = dtb.Rows[0]["tbl_ChequeBookId"].ToString();
                txtvendorHold.Text = dtb.Rows[0]["RemoveVendorHold"].ToString();
                txtInvoiceamount.Text = dtb.Rows[0]["ExceedMaxInvoiceAmount"].ToString();
                txtWriteOffAmount.Text = dtb.Rows[0]["ExceedMaxWriteOffAmount"].ToString();
                txtInvoiceDescription.Text = dtb.Rows[0]["InvoiceDescription"].ToString();
                txtInvoiceCode.Text = dtb.Rows[0]["InvoiceCode"].ToString();
                txtReturnDescription.Text = dtb.Rows[0]["ReturnDescription"].ToString();
                txtReturnCode.Text = dtb.Rows[0]["ReturnCode"].ToString();
                txtCreditMemoDescription.Text = dtb.Rows[0]["CreditMemoDescription"].ToString();
                txtCreditMemoCode.Text = dtb.Rows[0]["CreditMemoCode"].ToString();
                txtPaymentDescription.Text = dtb.Rows[0]["PaymentDescription"].ToString();
                txtPaymentCode.Text = dtb.Rows[0]["PaymentCode"].ToString();
                ddlSummaryView.SelectedValue = dtb.Rows[0]["Opt_SummaryView"].ToString();



                if (Convert.ToBoolean(dtb.Rows[0]["AgingPeriods"]) == true)
                    
                {
                    rdbAgeingDocumentDate.Checked = true;
                }

                else
                {
                    rdbAgeingDueDate.Checked = false;
                }
                if (Convert.ToBoolean(dtb.Rows[0]["ApplyBy"]) == true)
                { rdbApplyByDocumentDate.Checked = true; }

                else { rdbApplyByDuedate.Checked = false; }
                if (Convert.ToBoolean(dtb.Rows[0]["PrintHistoricalAgedTrialBalance"]) == true)
                { chkTrialbalance.Checked = true; }

                else { chkTrialbalance.Checked = false; }
                if (Convert.ToBoolean(dtb.Rows[0]["DeleteUnpostedPrintedDocuments"]) == true)
                { chkPrinteddocuments.Checked = true; }

                else { chkPrinteddocuments.Checked = false; }

                
                txtPayableSetupGroup.Text = dtb.Rows[0]["tbl_PayableSetupGroup"].ToString();
                txtPayableSetupGroupGuid.Text = dtb.Rows[0]["tbl_PayableSetupGroupId"].ToString();

                txtPayableSetupAndGroupAccount.Text= dtb.Rows[0]["tbl_PayableSetupAndGroupAccount"].ToString();
                txtPayableSetupAndGroupAccountGUID.Text= dtb.Rows[0]["tbl_PayableSetupAndGroupAccountid"].ToString();

                txtGLAccountId_Cash.Text = dtb.Rows[0]["Cash"].ToString();
                txtGLAccountId_CashGuid.Text = dtb.Rows[0]["tbl_GLAccountId_Cash"].ToString();

                txtGLAccountId_AccountReceivable.Text = dtb.Rows[0]["AccountReceivable"].ToString();
                txtGLAccountId_AccountReceivableGuid.Text = dtb.Rows[0]["tbl_GLAccountId_AccountReceivable"].ToString();

                txtGLAccountId_Sales.Text = dtb.Rows[0]["Sales"].ToString();
                txtGLAccountId_SalesGuid.Text = dtb.Rows[0]["tbl_GLAccountId_Sales"].ToString();

                txtGLAccountId_CostOfSales.Text = dtb.Rows[0]["CostOfSales"].ToString();
                txtGLAccountId_CostOfSalesGuid.Text = dtb.Rows[0]["tbl_GLAccountId_CostOfSales"].ToString();

                txtGLAccountId_Inventory.Text = dtb.Rows[0]["Inventory"].ToString();
                txtGLAccountId_InventoryGuid.Text = dtb.Rows[0]["tbl_GLAccountId_Inventory"].ToString();

                txtGLAccountId_AccuralDifferedA_C.Text = dtb.Rows[0]["AccuralDifferedA_C"].ToString();
                txtGLAccountId_AccuralDifferedA_CGuid.Text = dtb.Rows[0]["tbl_GLAccountId_AccuralDifferedA_C"].ToString();

                if (Convert.ToBoolean(dtb.Rows[0]["AllowDuplicateInvoicesPerVendor"]) == true)
                { rdbYes.Checked = true; }

                else { rdbNo.Checked = false; }


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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupForm.CS";
            logExcpUIobj.RecordId = payableSetupFormUI.Tbl_PayableSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindList()
    {
        try
        {

            if (Request.QueryString["PayableSetupId"] == null)
            {

                payableSetupFormUI.Tbl_PayableSetupId = "3a3f2adb-2cdd-4dbb-b7d7-d9a2469f5f1d";

            }
            else
            {
                payableSetupFormUI.Tbl_PayableSetupId = Request.QueryString["PayableSetupId"].ToString();

            }
            DataTable dtb = payableSetupPeriodFormBAL.GetPayableSetupPeriodById(payableSetupFormUI);
            

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPeriod.DataSource = dtb;
                gvPeriod.DataBind();
                divError.Visible = false;
                gvPeriod.Visible = true;
            }
            else
            {

                DataRow dr = dtb.NewRow();
                dtb.Rows.Add(dr);
                gvPeriod.DataSource = dtb;
                gvPeriod.DataBind();
                gvPeriod.Rows[0].Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupForm : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

   

    private void BindDocumentTypeDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_PayableSetup";
            optionSetListUI.OptionSetName = "Opt_SummaryView";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlSummaryView.DataSource = dtb;
                ddlSummaryView.DataBind();
                ddlSummaryView.DataTextField = "OptionSetLable";
                ddlSummaryView.DataValueField = "OptionSetValue";
                ddlSummaryView.DataBind();
                ddlSummaryView.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlSummaryView.SelectedIndex = 0;
            }
            else
            {
                ddlSummaryView.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindDocumentTypeDropDownList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupForm : BindDocumentTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region  ChequeBookSearch
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
                logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupForm.CS";
                logExcpUIobj.RecordId = "All";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Finance_Accounts_Payable_Setup_PayableSetupForm : SearchChequeBookList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupForm : BindCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion

    #region SearchCash
    private void SearchCashList()
    {
        try
        {
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
            logExcpUIobj.MethodName = "SearchCashList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupForm : SearchCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindCashList()
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
            logExcpUIobj.MethodName = "BindCashList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupForm : BindCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion

    #region SearchAccountReceivable
    private void SearchAccountReceivableList()
    {
        try
        {
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtAccountReceivableSearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAccountReceivableSearch.DataSource = dtb;
                gvAccountReceivableSearch.DataBind();
                divGLAccountId_AccountReceivableSearchError.Visible = false;

            }
            else
            {
                gvAccountReceivableSearch.Visible = true;
                lblAccountReceivableSearchError.Text = Resources.GlobalResource.msgNoRecordFound;

                gvAccountReceivableSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchAccountReceivableList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupForm : SearchAccountPayableList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindAccountReceivable()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAccountReceivableSearch.DataSource = dtb;
                gvAccountReceivableSearch.DataBind();
                divGLAccountId_AccountReceivableSearchError.Visible = false;
            }
            else
            {
                divGLAccountId_AccountReceivableSearchError.Visible = true;
                lblAccountReceivableSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAccountReceivableSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindAccountReceivable()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupForm : BindAccountReceivable] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion
    #region SearchSales
    private void SearchSalesList()
    {
        {

            try
            {
                GLAccountListUI gLAccountListUI = new GLAccountListUI();

                gLAccountListUI.Search = txtSalesSearch.Text;

                DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    gvSalesSearch.DataSource = dtb;
                    gvSalesSearch.DataBind();
                    divGLAccountId_SalesSearchError.Visible = false;
                }
                else
                {
                    divGLAccountId_SalesSearchError.Visible = true;
                    lblSalesSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                    gvSalesSearch.Visible = false;
                }

            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "SearchSalesList()";
                logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupForm.CS";
                logExcpUIobj.RecordId = "All";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Finance_Accounts_Payable_Setup_PayableSetupForm : SearchSalesList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
        }
    }
    private void BindSalesList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSalesSearch.DataSource = dtb;
                gvSalesSearch.DataBind();
                divGLAccountId_SalesSearchError.Visible = false;
            }
            else
            {
                divGLAccountId_SalesSearchError.Visible = true;
                lblSalesSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSalesSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindSalesList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupForm : BindPurchaseList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion
    #region SearchCostOfSales
    private void SearchCostOfSalestList()
    {
        try
        {
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtCostOfSalesSearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCostOfSalesSearch.DataSource = dtb;
                gvCostOfSalesSearch.DataBind();
                divGLAccountId_CostOfSalesSearchError.Visible = false;
            }
            else
            {
                divGLAccountId_CostOfSalesSearchError.Visible = true;
                lblCostOfSalesSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCostOfSalesSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchCostOfSalestList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupForm : SearchCostOfSalestList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindCostOfSales()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCostOfSalesSearch.DataSource = dtb;
                gvCostOfSalesSearch.DataBind();
                divGLAccountId_CostOfSalesSearchError.Visible = false;
            }
            else
            {
                divGLAccountId_CostOfSalesSearchError.Visible = true;
                lblCostOfSalesSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCostOfSalesSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCostOfSales()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupForm : BindCostOfSales] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion
    #region SearchInventory
    private void SearchInventoryList()
    {
        try
        {
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtInventorySearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvInventorySearch.DataSource = dtb;
                gvInventorySearch.DataBind();
                divGLAccountId_InventorySearchError.Visible = false;
            }
            else
            {
                divGLAccountId_InventorySearchError.Visible = true;
                lblGLAccountId_InventorySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvInventorySearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchInventoryList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupForm : SearchInventoryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindInventoryList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvInventorySearch.DataSource = dtb;
                gvInventorySearch.DataBind();
                divGLAccountId_InventorySearchError.Visible = false;
            }
            else
            {
                divGLAccountId_InventorySearchError.Visible = true;
                lblGLAccountId_InventorySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvInventorySearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindInventoryList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupForm : BindInventoryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion
    #region SearchAccuralDifferedA
    private void SearchAccuralDifferedA_CList()
    {
        try
        {
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtAccuralDifferedA_CSearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAccuralDifferedA_CSearch.DataSource = dtb;
                gvAccuralDifferedA_CSearch.DataBind();
                divGLAccountId_AccuralDifferedA_CSearchError.Visible = false;
            }
            else
            {
                divGLAccountId_AccuralDifferedA_CSearchError.Visible = true;
                lblGLAccountId_AccuralDifferedA_CSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAccuralDifferedA_CSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchAccuralDifferedA_CList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupForm : SearchAccuralDifferedA_CList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindAccuralDifferedA_CList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAccuralDifferedA_CSearch.DataSource = dtb;
                gvAccuralDifferedA_CSearch.DataBind();
                divGLAccountId_AccuralDifferedA_CSearchError.Visible = false;
            }
            else
            {
                divGLAccountId_AccuralDifferedA_CSearchError.Visible = true;
                lblGLAccountId_AccuralDifferedA_CSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAccuralDifferedA_CSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindAccuralDifferedA_CList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupForm : BindAccuralDifferedA_CList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion

    #region SearchPayableSetupGroup
    private void SearchPayableSetupGroup()
    {

        {
            try
            {

                PayableSetupGroupListUI payableSetupGroupListUI = new PayableSetupGroupListUI();



                payableSetupGroupListUI.Search = txtPayableSetupGroupSearch.Text;

                DataTable dtb = payableSetupAndGroupListBAL.GetPayableSetupGroupListBySearchParameters(payableSetupGroupListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    gvPayableSetupGroupSearch.DataSource = dtb;
                    gvPayableSetupGroupSearch.DataBind();
                    divPayableSetupGroupSearchError.Visible = false;
                }
                else
                {
                    divPayableSetupGroupSearchError.Visible = true;
                    lblPayableSetupGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                    gvPayableSetupGroupSearch.Visible = false;
                }

            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "SearchPayableSetupGroup_Self()";
                logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupForm.CS";
                logExcpUIobj.RecordId = "All";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Finance_Accounts_Payable_Setup_PayableSetupForm : SearchPayableSetupGroup_Self] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
        }
    }
    private void BindPayableSetupGroup()
    {
        try
        {
            DataTable dtb = payableSetupAndGroupListBAL.GetPayableSetupGroup_List();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPayableSetupGroupSearch.DataSource = dtb;
                gvPayableSetupGroupSearch.DataBind();
                divPayableSetupGroupSearchError.Visible = false;
            }
            else
            {
                divPayableSetupGroupSearchError.Visible = true;
                lblPayableSetupGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPayableSetupGroupSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPayableSetupGroup()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupForm : BindPayableSetupGroup_Self] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion

    #region SearchPayableSetupAndGroupAccount
    private void SearchPayableSetupAndGroupAccount()
    {

        {
            try
            {

                PayableSetupAndGroupAccountListUI payableSetupAndGroupAccountAccountListUI = new PayableSetupAndGroupAccountListUI();



                payableSetupAndGroupAccountAccountListUI.Search = txtPayableSetupAndGroupAccountSearch.Text;

                DataTable dtb = payableSetupAndGroupAccountListBAL.GetPayableSetupAndGroupAccountListBySearchParameters(payableSetupAndGroupAccountAccountListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    gvPayableSetupAndGroupAccountSearch.DataSource = dtb;
                    gvPayableSetupAndGroupAccountSearch.DataBind();
                    divPayableSetupAndGroupAccountSearchError.Visible = false;
                }
                else
                {
                    divPayableSetupAndGroupAccountSearchError.Visible = true;
                    lblPayableSetupAndGroupAccountSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                    gvPayableSetupAndGroupAccountSearch.Visible = false;
                }

            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "SearchPayableSetupGroup_Self()";
                logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupForm.CS";
                logExcpUIobj.RecordId = "All";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Finance_Accounts_Payable_Setup_PayableSetupForm : SearchPayableSetupGroup_Self] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
        }
    }
    private void BindPayableSetupAndGroupAccount()
    {
        try
        {
            DataTable dtb = payableSetupAndGroupAccountListBAL.GetPayableSetupAndGroupAccount_List();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPayableSetupAndGroupAccountSearch.DataSource = dtb;
                gvPayableSetupAndGroupAccountSearch.DataBind();
                divPayableSetupAndGroupAccountSearchError.Visible = false;
            }
            else
            {
                divPayableSetupAndGroupAccountSearchError.Visible = true;
                lblPayableSetupAndGroupAccountSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPayableSetupAndGroupAccountSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPayableSetupGroup()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupForm : BindPayableSetupGroup_Self] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion
    #endregion Methods
    #region Events


    #region  PayableSetupGroupSearch
    protected void btnPayableSetupGroupSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPayableSetupGroupSearch.Visible = false;
        btnHtmlPayableSetupGroupClose.Visible = true;
        SearchPayableSetupGroup();

    }
    protected void btnClearPayableSetupGroupSearch_Click(object sender, EventArgs e)
    {
        BindPayableSetupGroup();
        gvPayableSetupGroupSearch.Visible = true;
        btnHtmlPayableSetupGroupSearch.Visible = true;
        btnHtmlPayableSetupGroupClose.Visible = false;
        txtPayableSetupGroup.Text = "";
        txtPayableSetupGroup.Focus();

    }
    protected void btnPayableSetupGroupRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPayableSetupGroup();
    }
    #endregion


    #region  PayableSetupAndGroupAccountSearch
    protected void btnPayableSetupAndGroupAccountSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPayableSetupAndGroupAccountSearch.Visible = false;
        btnHtmlPayableSetupAndGroupAccountClose.Visible = true;
        SearchPayableSetupAndGroupAccount();

    }
    protected void btnClearPayableSetupAndGroupAccountSearch_Click(object sender, EventArgs e)
    {
        BindPayableSetupAndGroupAccount();
        gvPayableSetupAndGroupAccountSearch.Visible = true;
        btnHtmlPayableSetupAndGroupAccountSearch.Visible = true;
        btnHtmlPayableSetupAndGroupAccountClose.Visible = false;
        txtPayableSetupAndGroupAccount.Text = "";
        txtPayableSetupAndGroupAccount.Focus();

    }
    protected void btnPayableSetupAndGroupAccountRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPayableSetupAndGroupAccount();
    }
    #endregion
    protected void gvPeriod_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName.Equals("Add"))
        {
            try
            {

                payableSetupFormUI.Tbl_PayableSetupId =Convert.ToString(HttpContext.Current.Session["PayableSetupId"]);
                 DataTable dtb = payableSetupPeriodFormBAL.GetPayableSetupPeriodById(payableSetupFormUI);

                if (dtb.Rows.Count < 6)
                {


                    if (Request.QueryString["PayableSetupId"] == null)
                    {
                        
                        payableSetupPeriodFormUI.Tbl_PayableSetupId = Convert.ToString(HttpContext.Current.Session["PayableSetupId"]);
                    }
                    else
                    {
                        payableSetupPeriodFormUI.Tbl_PayableSetupId = Request.QueryString["PayableSetupId"];
                    }
                    TextBox CurrentPeriod = (TextBox)gvPeriod.FooterRow.FindControl("txtCurrentPeriod");
                    TextBox From = (TextBox)gvPeriod.FooterRow.FindControl("txtFrom");
                    TextBox To = (TextBox)gvPeriod.FooterRow.FindControl("txtTo");
                    payableSetupPeriodFormUI.CreatedBy = SessionContext.UserGuid;
                    payableSetupPeriodFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                    payableSetupPeriodFormUI.CurrentPeriod = CurrentPeriod.Text;
                    payableSetupPeriodFormUI.From = Convert.ToInt32(From.Text.ToString());
                    payableSetupPeriodFormUI.To = Convert.ToInt32(To.Text.ToString());

                    if (payableSetupPeriodFormBAL.AddPayableSetupPeriod(payableSetupPeriodFormUI) == 1)
                    {
                        divSuccess.Visible = true;
                        divError.Visible = false;
                        lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                        BindList();
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);

                    }
                    else
                    {
                        divSuccess.Visible = true;
                        divError.Visible = false;
                        lblSuccess.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
                        gvPeriod.EditIndex = -1;
                        BindList();

                    }

                }
                else
                {
                    divSuccess.Visible = true;
                    divError.Visible = false;
                    lblSuccess.Text = Resources.GlobalResource.msgRecordExceeded;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
                    gvPeriod.EditIndex = -1;
                    BindList();

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }

    protected void gvPeriod_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvPeriod.EditIndex = e.NewEditIndex;
        this.BindList();
    }

    protected void gvPeriod_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvPeriod.EditIndex = -1;
        BindList();
    }

    protected void gvPeriod_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        payableSetupPeriodFormUI.ModifiedBy = SessionContext.UserGuid;
        payableSetupPeriodFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
      
        if (Request.QueryString["PayableSetupId"] == null)
        { payableSetupPeriodFormUI.Tbl_PayableSetupId = Convert.ToString(HttpContext.Current.Session["PayableSetupId"]);  }
        else {
            payableSetupPeriodFormUI.Tbl_PayableSetupId = Request.QueryString["PayableSetupId"];
        }
      
        
        TextBox CurrentPeriod = (TextBox)gvPeriod.Rows[e.RowIndex].FindControl("txtCurrentPeriod");
        TextBox From = (TextBox)gvPeriod.Rows[e.RowIndex].FindControl("txtFrom");
        TextBox To = (TextBox)gvPeriod.Rows[e.RowIndex].FindControl("txtTo");
        payableSetupPeriodFormUI.CurrentPeriod = CurrentPeriod.Text;
        payableSetupPeriodFormUI.From = Convert.ToInt32(From.Text.ToString());
        payableSetupPeriodFormUI.To = Convert.ToInt32(To.Text.ToString());
        payableSetupPeriodFormUI.Tbl_PayableSetupPeriodId = gvPeriod.DataKeys[e.RowIndex]["tbl_PayableSetupPeriodId"].ToString();
        if (payableSetupPeriodFormBAL.UpdatePayableSetupPeriod(payableSetupPeriodFormUI) == 1)
        {
            divSuccess.Visible = true;
            divError.Visible = false;
            lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            gvPeriod.EditIndex = -1;
            BindList();
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {

            payableSetupFormUI.CreatedBy = SessionContext.UserGuid;
            payableSetupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            if (rdbAgeingDueDate.Checked)
            {

                payableSetupFormUI.AgingPeriods = true;
            }
            else if (rdbAgeingDocumentDate.Checked)
            {

                payableSetupFormUI.AgingPeriods = false;
            }
            if (rdbApplyByDocumentDate.Checked)
            {

                payableSetupFormUI.ApplyBy = true;
            }
            else if (rdbApplyByDuedate.Checked)
            {

                payableSetupFormUI.ApplyBy = false;
            }
            payableSetupFormUI.Opt_SummaryView = Convert.ToInt32(ddlSummaryView.SelectedValue);
            payableSetupFormUI.Tbl_ChequeBookId = txtChequeBookGuid.Text;
            payableSetupFormUI.RemoveVendorHold = txtvendorHold.Text;
            payableSetupFormUI.ExceedMaxInvoiceAmount = txtInvoiceamount.Text;
            payableSetupFormUI.ExceedMaxWriteOffAmount = txtWriteOffAmount.Text;
            if (chkTrialbalance.Checked == true)
            {
                payableSetupFormUI.PrintHistoricalAgedTrialBalance = true;
            }
            else
            {
                payableSetupFormUI.PrintHistoricalAgedTrialBalance = false;
            }
            if (chkPrinteddocuments.Checked == true)
            {
                payableSetupFormUI.DeleteUnpostedPrintedDocuments = true;
            }
            else
            {
                payableSetupFormUI.DeleteUnpostedPrintedDocuments = false;
            }
            if (rdbYes.Checked)
            {

                payableSetupFormUI.AllowDuplicateInvoicesPerVendor = true;
            }
            else if (rdbNo.Checked)
            {

                payableSetupFormUI.AllowDuplicateInvoicesPerVendor = false;
            }

            payableSetupFormUI.InvoiceDescription = txtInvoiceDescription.Text;
            payableSetupFormUI.InvoiceCode = txtInvoiceCode.Text;
            payableSetupFormUI.ReturnDescription = txtReturnDescription.Text;
            payableSetupFormUI.ReturnCode = txtReturnCode.Text;
            payableSetupFormUI.CreditMemoDescription = txtCreditMemoDescription.Text;
            payableSetupFormUI.CreditMemoCode = txtCreditMemoCode.Text;
            payableSetupFormUI.PaymentDescription = txtPaymentDescription.Text;
            payableSetupFormUI.PaymentCode = txtPaymentCode.Text;
            payableSetupFormUI.Tbl_PayableSetupGroupId = Guid.Parse(txtPayableSetupGroupGuid.Text).ToString(); 
            payableSetupFormUI.Tbl_PayableSetupAndGroupAccountId =Guid.Parse(txtPayableSetupAndGroupAccountGUID.Text).ToString();
            payableSetupFormUI.Tbl_GLAccountId_Cash = txtGLAccountId_CashGuid.Text;
            payableSetupFormUI.Tbl_GLAccountId_AccountReceivable = txtGLAccountId_AccountReceivableGuid.Text;
            payableSetupFormUI.Tbl_GLAccountId_Sales = txtGLAccountId_SalesGuid.Text;
            payableSetupFormUI.Tbl_GLAccountId_CostOfSales = txtGLAccountId_CostOfSalesGuid.Text;
            payableSetupFormUI.Tbl_GLAccountId_Inventory = txtGLAccountId_InventoryGuid.Text;
            payableSetupFormUI.Tbl_GLAccountId_AccuralDifferedA_C = txtGLAccountId_AccuralDifferedA_CGuid.Text;


            if (payableSetupFormBal.AddPayableSetup(payableSetupFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
                divSuccess.Visible = false;
                divError.Visible = true;


            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            payableSetupFormUI.Tbl_PayableSetupId = Request.QueryString["PayableSetupId"];

            if (payableSetupFormBal.DeletePayableSetup(payableSetupFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupForm.CS";
            logExcpUIobj.RecordId = payableSetupFormUI.Tbl_PayableSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupForm : btnDelete_Click] An error occured in the processing of Record Id : " + payableSetupFormUI.Tbl_PayableSetupId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PayableSetupList.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        try
        {
            payableSetupFormUI.ModifiedBy = SessionContext.UserGuid;
            payableSetupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            payableSetupFormUI.Tbl_PayableSetupId = Request.QueryString["PayableSetupId"];
            if (rdbAgeingDueDate.Checked)
            {

                payableSetupFormUI.AgingPeriods = true;
            }
            else if (rdbAgeingDocumentDate.Checked)
            {

                payableSetupFormUI.AgingPeriods = false;
            }
            if (rdbApplyByDocumentDate.Checked)
            {

                payableSetupFormUI.ApplyBy = true;
            }
            else if (rdbApplyByDuedate.Checked)
            {

                payableSetupFormUI.ApplyBy = false;
            }
            payableSetupFormUI.Opt_SummaryView = Convert.ToInt32(ddlSummaryView.SelectedValue);
            payableSetupFormUI.Tbl_ChequeBookId = txtChequeBookGuid.Text;
            payableSetupFormUI.RemoveVendorHold = txtvendorHold.Text;
            payableSetupFormUI.ExceedMaxInvoiceAmount = txtInvoiceamount.Text;
            payableSetupFormUI.ExceedMaxWriteOffAmount = txtWriteOffAmount.Text;
            if (chkTrialbalance.Checked == true)
            {
                payableSetupFormUI.PrintHistoricalAgedTrialBalance = true;
            }
            else
            {
                payableSetupFormUI.PrintHistoricalAgedTrialBalance = false;
            }
            if (chkPrinteddocuments.Checked == true)
            {
                payableSetupFormUI.DeleteUnpostedPrintedDocuments = true;
            }
            else
            {
                payableSetupFormUI.DeleteUnpostedPrintedDocuments = false;
            }
            if (rdbYes.Checked)
            {

                payableSetupFormUI.AllowDuplicateInvoicesPerVendor = true;
            }
            else if (rdbNo.Checked)
            {

                payableSetupFormUI.AllowDuplicateInvoicesPerVendor = false;
            }

            payableSetupFormUI.InvoiceDescription = txtInvoiceDescription.Text;
            payableSetupFormUI.InvoiceCode = txtInvoiceCode.Text;
            payableSetupFormUI.ReturnDescription = txtReturnDescription.Text;
            payableSetupFormUI.ReturnCode = txtReturnCode.Text;
            payableSetupFormUI.CreditMemoDescription = txtCreditMemoDescription.Text;
            payableSetupFormUI.CreditMemoCode = txtCreditMemoCode.Text;
            payableSetupFormUI.PaymentDescription = txtPaymentDescription.Text;
            payableSetupFormUI.PaymentCode = txtPaymentCode.Text;
            payableSetupFormUI.Tbl_PayableSetupGroupId = Guid.Parse(txtPayableSetupGroupGuid.Text).ToString();
            payableSetupFormUI.Tbl_PayableSetupAndGroupAccountId = Guid.Parse(txtPayableSetupAndGroupAccountGUID.Text).ToString();
            payableSetupFormUI.Tbl_GLAccountId_Cash = txtGLAccountId_CashGuid.Text;
            payableSetupFormUI.Tbl_GLAccountId_AccountReceivable = txtGLAccountId_AccountReceivableGuid.Text;
            payableSetupFormUI.Tbl_GLAccountId_Sales = txtGLAccountId_SalesGuid.Text;
            payableSetupFormUI.Tbl_GLAccountId_CostOfSales = txtGLAccountId_CostOfSalesGuid.Text;
            payableSetupFormUI.Tbl_GLAccountId_Inventory = txtGLAccountId_InventoryGuid.Text;
            payableSetupFormUI.Tbl_GLAccountId_AccuralDifferedA_C = txtGLAccountId_AccuralDifferedA_CGuid.Text;

            if (payableSetupFormBal.UpdatePayableSetup(payableSetupFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupForm : btnUpdate_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }



    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Finance/Accounts_Payable/Setup/PayableSetupForm.aspx";
        string recordId = Request.QueryString["PayableSetupId"];
        Response.Redirect("~/System_Settings/AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    #region AccountCashSearch
    protected void btnAccountCashSearch_Click(object sender, EventArgs e)
    {
        btnHtmlGLAccountId_CashSearch.Visible = false;
        btnHtmlGLAccountId_CashClose.Visible = true;
        SearchCashList();

    }
    protected void btnClearAccountCashSearch_Click(object sender, EventArgs e)
    {
        BindCashList();
        gvGLAccountId_CashSearch.Visible = true;
        btnHtmlGLAccountId_CashSearch.Visible = true;
        btnHtmlGLAccountId_CashClose.Visible = false;
        txtGLAccountId_Cash.Text = "";
        txtGLAccountId_Cash.Focus();

    }
    protected void btnAccountCashRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindCashList();
    }
    #endregion
    #region AccountReceivableSearch
    protected void btnAccountReceivableSearch_Click(object sender, EventArgs e)
    {
        btnHtmlAccountReceivableSearch.Visible = false;
        btnHtmlAccountReceivableClose.Visible = true;
        SearchAccountReceivableList();

    }
    protected void btnClearAccountReceivableSearch_Click(object sender, EventArgs e)
    {
        BindAccountReceivable();
        gvAccountReceivableSearch.Visible = true;
        btnHtmlAccountReceivableSearch.Visible = true;
        btnHtmlAccountReceivableClose.Visible = false;
        txtAccountReceivableSearch.Text = "";
        txtAccountReceivableSearch.Focus();

    }
    protected void btnAccountReceivableRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindAccountReceivable();

    }

    protected void btnSalesSearch_Click(object sender, EventArgs e)
    {
        btnHtmlSalesSearch.Visible = false;
        btnHtmlSalesClose.Visible = true;
        SearchSalesList();
    }
    protected void btnClearSalesSearch_Click(object sender, EventArgs e)
    {
        BindSalesList();
        gvSalesSearch.Visible = true;
        btnHtmlSalesSearch.Visible = true;
        btnHtmlSalesClose.Visible = false;
        txtSalesSearch.Focus();
    }
    protected void btnSalesRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindSalesList();
    }
    protected void btnCostOfSalesSearch_Click(object sender, EventArgs e)
    {
        btnHtmlCostOfSalesSearch.Visible = false;
        btnHtmlCostOfSalesClose.Visible = true;
        SearchCostOfSalestList();
    }
    protected void btnClearCostOfSalesSearch_Click(object sender, EventArgs e)
    {
        BindCostOfSales();
        gvCostOfSalesSearch.Visible = true;
        btnHtmlCostOfSalesSearch.Visible = true;
        btnHtmlCostOfSalesClose.Visible = false;
        txtCostOfSalesSearch.Text = "";
        txtCostOfSalesSearch.Focus();
    }
    protected void btnCostOfSalesRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindCostOfSales();
    }


    protected void btnInventorySearch_Click(object sender, EventArgs e)
    {

        btnHtmlInventorySearch.Visible = false;
        btnHtmlInventoryClose.Visible = true;
        SearchInventoryList();
    }
    protected void btnClearInventorySearch_Click(object sender, EventArgs e)
    {

        BindInventoryList();
        gvInventorySearch.Visible = true;
        btnHtmlInventorySearch.Visible = true;
        btnHtmlInventoryClose.Visible = false;
        txtInventorySearch.Text = "";
        txtInventorySearch.Focus();

    }
    protected void btnInventoryRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindInventoryList();
    }

    protected void btnAccuralDifferedA_CSearch_Click(object sender, EventArgs e)
    {
        btnHtmlAccuralDifferedA_CSearch.Visible = false;
        btnHtmlAccuralDifferedA_CClose.Visible = true;
        SearchAccuralDifferedA_CList();
    }
    protected void btnClearAccuralDifferedA_CSearch_Click(object sender, EventArgs e)
    {
        BindAccuralDifferedA_CList();
        gvAccuralDifferedA_CSearch.Visible = true;
        btnHtmlAccuralDifferedA_CSearch.Visible = true;
        btnHtmlAccuralDifferedA_CClose.Visible = false;
        txtAccuralDifferedA_CSearch.Text = "";
        txtAccuralDifferedA_CSearch.Focus();

    }
    protected void btnAccuralDifferedA_CRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindAccuralDifferedA_CList();
    }


    #endregion Model popup
    #endregion Events

}


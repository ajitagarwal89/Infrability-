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
using System.Text;

public partial class System_Settings_ReceivableConfigurationSettingForm : System.Web.UI.Page
{
    #region Data Members
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    ReceivableSetupPeriodFormBAL receivableSetupPeriodFormBAL = new ReceivableSetupPeriodFormBAL();
    ReceivableSetupPeriod_FormUI receivableSetupPeriod_FormUI = new ReceivableSetupPeriod_FormUI();
    ReceivableSetupFormUI receivableSetupFormUI = new ReceivableSetupFormUI();
    ReceivableSetupFormBAL receivableSetupFormBAL = new ReceivableSetupFormBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    ChequeBookListBAL chequeBookListBAL = new ChequeBookListBAL();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    ReceivableSetupGroupListBAL receivableSetupGroupListBAL = new ReceivableSetupGroupListBAL();
    ReceivableSetupAndGroupAccountListBAL receivableSetupAndGroupAccountListBAL = new ReceivableSetupAndGroupAccountListBAL();
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ReceivableSetupId"] != null || Request.QueryString["recordId"] != null)
            {
                receivableSetupFormUI.Tbl_ReceivableSetupId = (Request.QueryString["ReceivableSetupId"] != null ? Request.QueryString["ReceivableSetupId"] : Request.QueryString["recordId"]);
                BindDocumentTypeDropDownList();
                BindDocumentFormateDropDownList();
                FillForm(receivableSetupFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Receivable Configuration Setting ";
                BindList();
            }
            else
            {
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add Receivable Configuration Setting";
                BindDocumentTypeDropDownList();
                BindDocumentFormateDropDownList();
                BindList();
            }
        }
       
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            receivableSetupFormUI.CreatedBy = SessionContext.UserGuid;
            receivableSetupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            if (rdbDueDate.Checked == true)
            {
                receivableSetupFormUI.IsAgingPeriods = true;
            }
            else if (rdbDocumentDate.Checked == true)
            {
                receivableSetupFormUI.IsAgingPeriods = false;
            }
           
            if (rdbDocumentDate1.Checked == true)
            { receivableSetupFormUI.IsApplyBy = true; }
            else if (rdbDuedate1.Checked == true)
            { receivableSetupFormUI.IsApplyBy = false; }


            receivableSetupFormUI.Tbl_CheckBookId = txtChequeBookGuid.Text;
            receivableSetupFormUI.Opt_DocumentFormate = Convert.ToInt32(ddlDocumentFormat.SelectedValue);
            receivableSetupFormUI.Opt_SummaryView = Convert.ToInt32(ddlSummaryView.SelectedValue);
            receivableSetupFormUI.ExceedCardLimit = Convert.ToDecimal(txtExceedCredit.Text.Trim().ToString());
            receivableSetupFormUI.RemoveCustomerHold = txtRemoveCustomerHold.Text.Trim().ToString();
            receivableSetupFormUI.ExceedMaximumWriteOffs = Convert.ToDecimal(txtWriteOffAmount.Text.Trim().ToString());
            if (chkunposteddocuments.Checked)
            {
                receivableSetupFormUI.IsReprintStatements = true;
            }
            else
            {
                receivableSetupFormUI.IsReprintStatements = false;
            }
            if (chkTrialbalance.Checked)
            {
                receivableSetupFormUI.IsPrintTrialBalance = true;
            }
            else
            {
                receivableSetupFormUI.IsPrintTrialBalance = false;
            }
            receivableSetupFormUI.SaleInvoiceDescription = txtSaleInvoiceDescription.Text;
            receivableSetupFormUI.SaleInvoiceCode = txtSaleInvoiceCode.Text;
          
            receivableSetupFormUI.DebitMemoDescription = txtDebitMemoDescription.Text;
            receivableSetupFormUI.DebitMemoCode = txtDebitMemoCode.Text;
         
            receivableSetupFormUI.CreditMemoDescription = txtCreditMemoDescription.Text;
            receivableSetupFormUI.CreditMemoCode = txtCreditMemoCode.Text;      
        
            receivableSetupFormUI.ReturnDescription = txtReturnDescription.Text;
            receivableSetupFormUI.ReturnCode = txtReturnCode.Text;

            receivableSetupFormUI.CashReceiptDescription = txtCashReceiptDescription.Text;
            receivableSetupFormUI.CashReceiptCode = txtCashReceiptCode.Text; 
                     
            receivableSetupFormUI.StatementsPrintedDate = Convert.ToDateTime(txtStatementsPrintedDate.Text);
            receivableSetupFormUI.BalanceForwardAccountsAgedDate = Convert.ToDateTime(txtBalanceForwardAccountsAgedDate.Text);
            receivableSetupFormUI.OpenitemAccountsAgedDate = Convert.ToDateTime(txtOpenitemAccountsAgedDate.Text);
            if (chkSale.Checked == true)
            {
                receivableSetupFormUI.Sales = true;
            }
            else {
                receivableSetupFormUI.Sales = false;
            }
            if (chkDiscount.Checked)
            {
                receivableSetupFormUI.Discount = true;
            }
            else
            {
                receivableSetupFormUI.Discount = false;
            }
            if (chkFreight.Checked)
            {
                receivableSetupFormUI.Freight = true;
            }
            else {
                receivableSetupFormUI.Freight = false;
            }
            receivableSetupFormUI.Tbl_ReceivableSetupGroupId = txtRecievableSetupGroupGuid.Text;
            receivableSetupFormUI.Tbl_ReceivableSetupAndGroupAccountId = txtReceivableSetupAndGroupAccountGuid.Text;
            receivableSetupFormUI.Tbl_GLAccountId_Cash = txtGLAccountId_CashGuid.Text;
            receivableSetupFormUI.Tbl_GLAccountId_AccountReceivable = txtGLAccountId_AccountReceivableGuid.Text;
            receivableSetupFormUI.Tbl_GLAccountId_Sales = txtGLAccountId_SalesGuid.Text;
            receivableSetupFormUI.Tbl_GLAccountId_CostOfSales = txtGLAccountId_CostOfSalesGuid.Text;
            receivableSetupFormUI.Tbl_GLAccountId_Inventory = txtGLAccountId_InventoryGuid.Text;
            receivableSetupFormUI.Tbl_GLAccountId_AccuralDifferedA_C = txtGLAccountId_AccuralDifferedA_CGuid.Text;

            if (receivableSetupFormBAL.AddReceivableSetup(receivableSetupFormUI) == 1)
            {
                divSuccess.Visible = true;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ClearForm", "ClearForm();", true);
            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
                divError.Visible = true;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ClearForm", "ClearForm();", true);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableConfigurationSettingForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableConfigurationSettingForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }


    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            receivableSetupFormUI.ModifiedBy = SessionContext.UserGuid;
            receivableSetupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            receivableSetupFormUI.Tbl_ReceivableSetupId = Request.QueryString["ReceivableSetupId"];
            if (rdbDueDate.Checked == true)
            {
                receivableSetupFormUI.IsAgingPeriods = true;
            }
            else if (rdbDocumentDate.Checked == true)
            {
                receivableSetupFormUI.IsAgingPeriods = false;
            }           

            if (rdbDocumentDate1.Checked == true)
            { receivableSetupFormUI.IsApplyBy = true; }
            else if (rdbDuedate1.Checked == true)
            { receivableSetupFormUI.IsApplyBy = false; }

            receivableSetupFormUI.Tbl_CheckBookId = txtChequeBookGuid.Text;
            receivableSetupFormUI.Opt_DocumentFormate = Convert.ToInt32(ddlDocumentFormat.SelectedValue);
            receivableSetupFormUI.Opt_SummaryView = Convert.ToInt32(ddlSummaryView.SelectedValue);
            receivableSetupFormUI.ExceedCardLimit = Convert.ToDecimal(txtExceedCredit.Text.Trim().ToString());
            receivableSetupFormUI.RemoveCustomerHold = txtRemoveCustomerHold.Text.Trim().ToString();
            receivableSetupFormUI.ExceedMaximumWriteOffs = Convert.ToDecimal(txtWriteOffAmount.Text.Trim().ToString());
            if (chkunposteddocuments.Checked)
            {
                receivableSetupFormUI.IsReprintStatements = true;
            }
            else
            {
                receivableSetupFormUI.IsReprintStatements = false;
            }
            if (chkTrialbalance.Checked)
            {
                receivableSetupFormUI.IsPrintTrialBalance = true;
            }
            else
            {
                receivableSetupFormUI.IsPrintTrialBalance = false;
            }
            receivableSetupFormUI.SaleInvoiceDescription = txtSaleInvoiceDescription.Text;
            receivableSetupFormUI.SaleInvoiceCode = txtSaleInvoiceCode.Text;
         
            receivableSetupFormUI.DebitMemoDescription = txtDebitMemoDescription.Text;
            receivableSetupFormUI.DebitMemoCode = txtDebitMemoCode.Text;
          
            receivableSetupFormUI.CreditMemoDescription = txtCreditMemoDescription.Text;
            receivableSetupFormUI.CreditMemoCode = txtCreditMemoCode.Text;
          
     
            receivableSetupFormUI.ReturnDescription = txtReturnDescription.Text;
            receivableSetupFormUI.ReturnCode = txtReturnCode.Text;
         
            receivableSetupFormUI.CashReceiptDescription = txtCashReceiptDescription.Text;
            receivableSetupFormUI.CashReceiptCode = txtCashReceiptCode.Text;
         
            receivableSetupFormUI.StatementsPrintedDate = Convert.ToDateTime(txtStatementsPrintedDate.Text);
            receivableSetupFormUI.BalanceForwardAccountsAgedDate = Convert.ToDateTime(txtBalanceForwardAccountsAgedDate.Text);
            receivableSetupFormUI.OpenitemAccountsAgedDate = Convert.ToDateTime(txtOpenitemAccountsAgedDate.Text);
            if (chkSale.Checked == true)
            {
                receivableSetupFormUI.Sales = true;
            }
            else
            {
                receivableSetupFormUI.Sales = false;
            }
            if (chkDiscount.Checked)
            {
                receivableSetupFormUI.Discount = true;
            }
            else
            {
                receivableSetupFormUI.Discount = false;
            }
            if (chkFreight.Checked)
            {
                receivableSetupFormUI.Freight = true;
            }
            else
            {
                receivableSetupFormUI.Freight = false;
            }
            receivableSetupFormUI.Tbl_ReceivableSetupGroupId = txtRecievableSetupGroupGuid.Text;
            receivableSetupFormUI.Tbl_ReceivableSetupAndGroupAccountId = txtReceivableSetupAndGroupAccountGuid.Text;
            receivableSetupFormUI.Tbl_GLAccountId_Cash = txtGLAccountId_CashGuid.Text;
            receivableSetupFormUI.Tbl_GLAccountId_AccountReceivable = txtGLAccountId_AccountReceivableGuid.Text;
            receivableSetupFormUI.Tbl_GLAccountId_Sales = txtGLAccountId_SalesGuid.Text;
            receivableSetupFormUI.Tbl_GLAccountId_CostOfSales = txtGLAccountId_CostOfSalesGuid.Text;
            receivableSetupFormUI.Tbl_GLAccountId_Inventory = txtGLAccountId_InventoryGuid.Text;
            receivableSetupFormUI.Tbl_GLAccountId_AccuralDifferedA_C = txtGLAccountId_AccuralDifferedA_CGuid.Text;
            if (receivableSetupFormBAL.UpdateReceivableSetup(receivableSetupFormUI) == 1)
            {
                divSuccess.Visible = true;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;
                divError.Visible = true;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "ReceivableConfigurationSettingForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableConfigurationSettingForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            receivableSetupFormUI.Tbl_ReceivableSetupId = Request.QueryString["ReceivableSetupId"];

            if (receivableSetupFormBAL.DeleteReceivableSetup(receivableSetupFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_ReceivableConfigurationSettingForm.CS";
            logExcpUIobj.RecordId = receivableSetupFormUI.Tbl_ReceivableSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableConfigurationSettingForm : btnDelete_Click] An error occured in the processing of Record Id : " + receivableSetupFormUI.Tbl_ReceivableSetupId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReceivableConfigurationSettingList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/System_Settings/ReceivableConfigurationSettingForm.aspx";
        string recordId = Request.QueryString["ReceivableSetupId"];
        Response.Redirect("~/System_Settings/AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    #region ChequeBook
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
    #endregion

    #region RecievableSetupGroup
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


    #region ReceivableSetupAndGroupAccount
    protected void btnReceivableSetupAndGroupAccountSearch_Click(object sender, EventArgs e)
    {
        btnHtmlReceivableSetupAndGroupAccountSearch.Visible = false;
        btnHtmlReceivableSetupAndGroupAccountClose.Visible = true;
        SearchReceivableSetupAndGroupAccountList();
    }
    protected void btnClearReceivableSetupAndGroupAccountSearch_Click(object sender, EventArgs e)
    {
        BindReceivableSetupAndGroupAccountList();
        gvReceivableSetupAndGroupAccountSearch.Visible = true;
        btnHtmlReceivableSetupAndGroupAccountSearch.Visible = true;
        btnHtmlReceivableSetupAndGroupAccountClose.Visible = false;
        txtReceivableSetupAndGroupAccountSearch.Text = "";
        txtReceivableSetupAndGroupAccountSearch.Focus();
    }
    protected void btnReceivableSetupAndGroupAccountRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindReceivableSetupAndGroupAccountList();
    }
    #endregion Recievable event
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

    #region Grid View
    #region event
    protected void gvPeriod_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Add"))
        {
            try
            {
                DataTable dtb = receivableSetupPeriodFormBAL.GetReceivableSetupPeriodList();
                    if (dtb.Rows.Count <=5)
                {

                    if (Request.QueryString["ReceivableSetupId"] == null)
                    {
                        receivableSetupPeriod_FormUI.Tbl_ReceivableSetupId = "935C0062-91CF-4E31-9DE2-23F76B5314BD";
                    }
                    else
                    {
                        receivableSetupPeriod_FormUI.Tbl_ReceivableSetupId = Request.QueryString["ReceivableSetupPeriodId"];
                    }
                    TextBox CurrentPeriod = (TextBox)gvPeriod.FooterRow.FindControl("txtCurrentPeriod");
                    TextBox From = (TextBox)gvPeriod.FooterRow.FindControl("txtFrom");
                    TextBox To = (TextBox)gvPeriod.FooterRow.FindControl("txtTo");
                    receivableSetupPeriod_FormUI.CreatedBy = SessionContext.UserGuid;
                    receivableSetupPeriod_FormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                    receivableSetupPeriod_FormUI.CurrentPeriod = CurrentPeriod.Text;
                    receivableSetupPeriod_FormUI.From = Convert.ToInt32(From.Text.ToString());
                    receivableSetupPeriod_FormUI.To = Convert.ToInt32(To.Text.ToString());

                    if (receivableSetupPeriodFormBAL.AddReceivableSetupPeriod(receivableSetupPeriod_FormUI) == 1)
                    {
                        divSuccess.Visible = true;
                        divError.Visible = false;
                        lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
                        BindList();
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
                else {
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
        receivableSetupPeriod_FormUI.ModifiedBy = SessionContext.UserGuid;
        receivableSetupPeriod_FormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
        if (Request.QueryString["ReceivableSetupId"] == null)
        {
            receivableSetupPeriod_FormUI.Tbl_ReceivableSetupId = "935C0062-91CF-4E31-9DE2-23F76B5314BD";
        }
        else
        {
            receivableSetupPeriod_FormUI.Tbl_ReceivableSetupId = Request.QueryString["ReceivableSetupId"];
        }
        Guid tbl_ReceivalbeSetupPeriodId = Guid.Parse(gvPeriod.DataKeys[e.RowIndex].Value.ToString());
        TextBox CurrentPeriod = (TextBox)gvPeriod.Rows[e.RowIndex].FindControl("txtCurrentPeriod");
        TextBox From = (TextBox)gvPeriod.Rows[e.RowIndex].FindControl("txtFrom");
        TextBox To = (TextBox)gvPeriod.Rows[e.RowIndex].FindControl("txtTo");
        receivableSetupPeriod_FormUI.Tbl_ReceivableSetupPeriodId = tbl_ReceivalbeSetupPeriodId.ToString();
        receivableSetupPeriod_FormUI.CurrentPeriod = CurrentPeriod.Text;
        receivableSetupPeriod_FormUI.From = Convert.ToInt32(From.Text.ToString());
        receivableSetupPeriod_FormUI.To = Convert.ToInt32(To.Text.ToString());
        if (receivableSetupPeriodFormBAL.UpdateReceivalbeSetupPeriod(receivableSetupPeriod_FormUI) == 1)
        {
            divSuccess.Visible = true;
            divError.Visible = false;
            lblSuccess.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            gvPeriod.EditIndex = -1;
            BindList();

        }
    }
        protected void gvPeriod_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
            {
            Guid tbl_ReceivalbeSetupPeriodId = Guid.Parse(gvPeriod.DataKeys[e.RowIndex].Value.ToString());
            receivableSetupPeriod_FormUI.Tbl_ReceivableSetupPeriodId = tbl_ReceivalbeSetupPeriodId.ToString();
            if (receivableSetupPeriodFormBAL.DeleteReceivalbeSetupPeriod(receivableSetupPeriod_FormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordDeleteSuccessfully;

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
                BindList();

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
            logExcpUIobj.MethodName = "gvPeriod_RowDeleting()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableConfigurationSettingForm.CS";
            logExcpUIobj.RecordId = receivableSetupPeriod_FormUI.Tbl_ReceivableSetupPeriodId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableConfigurationSettingForm : gvPeriod_RowDeleting] An error occured in the processing of Record Id : " + receivableSetupPeriod_FormUI.Tbl_ReceivableSetupPeriodId + ". Details : [" + exp.ToString() + "]");
        }
    }
    #endregion
    #region Grid View Method
    private void BindList()
    {
        try
        {
            DataTable dtb = receivableSetupPeriodFormBAL.GetReceivableSetupPeriodList();

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
            logExcpUIobj.ResourceName = "System_Settings_ReceivableConfigurationSettingForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableConfigurationSettingForm : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion

    #endregion
    #endregion

    #region Method
    private void BindDocumentTypeDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_ReceivableSetup";
            optionSetListUI.OptionSetName = "Opt_SummaryView";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlSummaryView.DataSource = dtb;
                ddlSummaryView.DataBind();
                ddlSummaryView.DataTextField = "OptionSetLable";
                ddlSummaryView.DataValueField = "OptionSetValue";
                ddlSummaryView.DataBind();
            }
            else
            {
                ddlSummaryView.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindDocumentTypeDropDownList()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableConfigurationSettingForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableConfigurationSettingForm : BindDocumentTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void BindDocumentFormateDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_ReceivableSetup";
            optionSetListUI.OptionSetName = "Opt_DocumentFormate";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlDocumentFormat.DataSource = dtb;
                ddlDocumentFormat.DataBind();
                ddlDocumentFormat.DataTextField = "OptionSetLable";
                ddlDocumentFormat.DataValueField = "OptionSetValue";
                ddlDocumentFormat.DataBind();
            }
            else
            {
                ddlDocumentFormat.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindDocumentFormateDropDownList()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableConfigurationSettingForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableConfigurationSettingForm : BindDocumentFormateDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }
    private void FillForm(ReceivableSetupFormUI receivableSetupFormUI)
    {
        try
        {
            DataTable dtb = receivableSetupFormBAL.GetReceivableSetupListById(receivableSetupFormUI);

            if (dtb.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dtb.Rows[0]["IsAgingPeriods"]) == true)
                {
                    rdbDueDate.Checked = true;
                }
                else
                {
                    rdbDocumentDate.Checked = true;
                }
                if (Convert.ToBoolean(dtb.Rows[0]["IsApplyBy"]) == true)
                { rdbDuedate1.Checked = true; }
                else
                {
                    rdbDocumentDate.Checked = true;
                }
                txtChequeBookGuid.Text = dtb.Rows[0]["tbl_CheckBookId"].ToString();
                txtChequeBook.Text = dtb.Rows[0]["ChequeBookName"].ToString();
                ddlDocumentFormat.SelectedValue = dtb.Rows[0]["Opt_DocumentFormateLabel"].ToString();
                ddlSummaryView.SelectedValue = dtb.Rows[0]["Opt_SummaryViewLabel"].ToString();
                txtExceedCredit.Text = dtb.Rows[0]["ExceedCardLimit"].ToString();
                txtRemoveCustomerHold.Text = dtb.Rows[0]["RemoveCustomerHold"].ToString();
                txtWriteOffAmount.Text = dtb.Rows[0]["ExceedMaximumWriteOffs"].ToString();
                 txtSaleInvoiceDescription.Text = dtb.Rows[0]["SaleInvoiceDescription"].ToString();
                txtSaleInvoiceCode.Text= dtb.Rows[0]["SaleInvoiceCode"].ToString();
               
                txtDebitMemoDescription.Text = dtb.Rows[0]["DebitMemoDescription"].ToString();
                txtDebitMemoCode.Text= dtb.Rows[0]["DebitMemoCode"].ToString();
              
                txtCreditMemoDescription.Text = dtb.Rows[0]["CreditMemoDescription"].ToString();
                txtCreditMemoCode.Text= dtb.Rows[0]["CreditMemoCode"].ToString();             
                txtReturnDescription.Text = dtb.Rows[0]["ReturnDescription"].ToString();
                txtReturnCode.Text= dtb.Rows[0]["ReturnCode"].ToString();            
                txtCashReceiptDescription.Text= dtb.Rows[0]["CashReceiptDescription"].ToString();
                txtCashReceiptCode.Text= dtb.Rows[0]["CashReceiptCode"].ToString();            
                txtStatementsPrintedDate.Text = dtb.Rows[0]["StatementsPrintedDate"].ToString();
                txtBalanceForwardAccountsAgedDate.Text = dtb.Rows[0]["BalanceForwardAccountsAgedDate"].ToString();
                txtOpenitemAccountsAgedDate.Text= dtb.Rows[0]["OpenitemAccountsAgedDate"].ToString();
                if (Convert.ToBoolean(dtb.Rows[0]["IsReprintStatements"]) == true)
                {
                    chkunposteddocuments.Checked = true;
                }
                else {
                    chkunposteddocuments.Checked = true;
                }
                if (Convert.ToBoolean(dtb.Rows[0]["IsPrintTrialBalance"]) == true)
                {
                    chkTrialbalance.Checked = true;
                }
                else
                {
                    chkTrialbalance.Checked = true;
                }
                if (Convert.ToBoolean(dtb.Rows[0]["Sales"]) == true)
                {
                    chkSale.Checked = true;
                }
                else
                {
                    chkSale.Checked = false;
                }
                if (Convert.ToBoolean(dtb.Rows[0]["Discount"]) == true)
                { chkDiscount.Checked = true; }
                else {
                    chkDiscount.Checked = false;
                }

                if (Convert.ToBoolean(dtb.Rows[0]["Freight"]) == true)
                { chkFreight.Checked = true; }
                else
                {
                    chkFreight.Checked = false;
                }
                txtRecievableSetupGroup.Text = dtb.Rows[0]["tbl_ReceivableSetupGroup"].ToString();
                txtRecievableSetupGroupGuid.Text = dtb.Rows[0]["tbl_ReceivableSetupGroupId"].ToString();
                txtReceivableSetupAndGroupAccount.Text = dtb.Rows[0]["tbl_ReceivableSetupAndGroupAccount"].ToString();
                txtReceivableSetupAndGroupAccountGuid.Text = dtb.Rows[0]["tbl_ReceivableSetupAndGroupAccountId"].ToString();
                txtGLAccountId_Cash.Text = dtb.Rows[0]["Cash"].ToString();
                txtGLAccountId_CashGuid.Text = dtb.Rows[0]["tbl_GLAccountId_Cash"].ToString();
                txtGLAccountId_AccountReceivable.Text = dtb.Rows[0]["AccountReceivable"].ToString();
                txtGLAccountId_AccountReceivableGuid.Text = dtb.Rows[0]["tbl_GLAccountId_AccountReceivable"].ToString();
                txtGLAccountId_Sales.Text = dtb.Rows[0]["Sales"].ToString();
                txtGLAccountId_SalesGuid.Text = dtb.Rows[0]["tbl_GLAccountId_Sales"].ToString();
                txtGLAccountId_CostOfSales.Text = dtb.Rows[0]["CostOfSales"].ToString();
                txtGLAccountId_CostOfSalesGuid.Text = dtb.Rows[0]["tbl_GLAccountId_CostOfSales"].ToString();
                txtGLAccountId_InventoryGuid.Text = dtb.Rows[0]["tbl_GLAccountId_Inventory"].ToString();
                txtGLAccountId_Inventory.Text = dtb.Rows[0]["Inventory"].ToString();
                txtGLAccountId_AccuralDifferedA_CGuid.Text = dtb.Rows[0]["tbl_GLAccountId_AccuralDifferedA_C"].ToString();
                txtGLAccountId_AccuralDifferedA_C.Text = dtb.Rows[0]["AccuralDifferedA_C"].ToString();
                // receivableSetupFormUI.Tbl_ReceivableSetupId = Request.QueryString["ReceivableSetupId"];
                dtb = receivableSetupFormBAL.GetReceivalbeSetupPeriodIdListById(receivableSetupFormUI);
                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    gvPeriod.DataSource = dtb;
                    gvPeriod.DataBind();
                    divError.Visible = false;
                    gvPeriod.Visible = true;
                }
                else
                {
                    divError.Visible = true;
                    lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                    gvPeriod.Visible = false;
                }
               


            }
            else
            {
                divError.Visible = true;
                divSuccess.Visible = false;
                lblError.Text = Resources.GlobalResource.msgCouldNotLoadData;

            }

        }
        catch (Exception exp)
             {
            logExcpUIobj.MethodName = "FillForm()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableConfigurationSettingForm.CS";
            logExcpUIobj.RecordId = this.receivableSetupFormUI.Tbl_ReceivableSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableConfigurationSettingForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

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
            logExcpUIobj.MethodName = "BindRecievableSetupGroupList()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableConfigurationSettingForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableConfigurationSettingForm : BindRecievableSetupGroupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.MethodName = "SearchRecievableSetupGroupList()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableConfigurationSettingForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableConfigurationSettingForm : SearchRecievableSetupGroupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion

    #region ReceivableSetupAndGroupAccount
    private void BindReceivableSetupAndGroupAccountList()
    {
        try
        {
            DataTable dtb = receivableSetupAndGroupAccountListBAL.GetReceivableSetupAndGroupAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvReceivableSetupAndGroupAccountSearch.DataSource = dtb;
                gvReceivableSetupAndGroupAccountSearch.DataBind();
                divReceivableSetupAndGroupAccountSearchError.Visible = false;

            }
            else
            {
                divReceivableSetupAndGroupAccountSearchError.Visible = true;
                lblReceivableSetupAndGroupAccountSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvReceivableSetupAndGroupAccountSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindReceivableSetupAndGroupAccountList()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableConfigurationSettingForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableConfigurationSettingForm : BindReceivableSetupAndGroupAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void SearchReceivableSetupAndGroupAccountList()
    {
        try
        {
            ReceivableSetupAndGroupAccountListUI receivableSetupAndGroupAccountListUI = new ReceivableSetupAndGroupAccountListUI();
            receivableSetupAndGroupAccountListUI.Search = txtReceivableSetupAndGroupAccountSearch.Text;
            DataTable dtb = receivableSetupAndGroupAccountListBAL.GetReceivableSetupAndGroupAccountListBySearchParameters(receivableSetupAndGroupAccountListUI);


            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvReceivableSetupAndGroupAccountSearch.DataSource = dtb;
                gvReceivableSetupAndGroupAccountSearch.DataBind();
                divReceivableSetupAndGroupAccountSearchError.Visible = false;

            }
            else
            {
                divReceivableSetupAndGroupAccountSearchError.Visible = true;
                lblReceivableSetupAndGroupAccountSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvReceivableSetupAndGroupAccountSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchReceivableSetupAndGroupAccountList()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableConfigurationSettingForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableConfigurationSettingForm : SearchReceivableSetupAndGroupAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.MethodName = "SearchGLAccountId_CashList()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableConfigurationSettingForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableConfigurationSettingForm : SearchGLAccountId_CashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.MethodName = "BindGLAccountId_CashList()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableConfigurationSettingForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableConfigurationSettingForm : BindGLAccountId_CashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion

    # region GLAccountId_AccountReceivable
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
            logExcpUIobj.MethodName = "BindGLAccountId_AccountReceivableList()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableConfigurationSettingForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableConfigurationSettingForm : BindGLAccountId_AccountReceivableList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.MethodName = "SearchGLAccountId_AccountReceivableList()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableConfigurationSettingForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableConfigurationSettingForm : SearchGLAccountId_AccountReceivableList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.MethodName = "BindGLAccountId_SalesList()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableConfigurationSettingForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableConfigurationSettingForm : BindGLAccountId_SalesList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.MethodName = "SearchGLAccountId_SalesList()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableConfigurationSettingForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableConfigurationSettingForm : SearchGLAccountId_SalesList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.MethodName = "BindGLAccountId_CostOfSalesList()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableConfigurationSettingForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableConfigurationSettingForm : BindGLAccountId_CostOfSalesList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.MethodName = "SearchGLAccountId_CostOfSalesList()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableConfigurationSettingForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableConfigurationSettingForm : SearchGLAccountId_CostOfSalesList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.MethodName = "BindGLAccountId_InventoryList()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableConfigurationSettingForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableConfigurationSettingForm : BindGLAccountId_InventoryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.MethodName = "SearchGLAccountId_InventoryList()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableConfigurationSettingForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableConfigurationSettingForm : SearchGLAccountId_InventoryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.MethodName = "BindGLAccountId_AccuralDifferedA_CList()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableConfigurationSettingForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableConfigurationSettingForm : BindGLAccountId_AccuralDifferedA_CList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.MethodName = "SearchGLAccountId_AccuralDifferedA_CList()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableConfigurationSettingForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableConfigurationSettingForm : SearchGLAccountId_AccuralDifferedA_CList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }


    }

    #endregion
    #endregion
}
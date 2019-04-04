using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Finware;
using log4net;


public partial class System_Settings_BankAccountingSetupForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    BankAccountingSetupFormBAL bankAccountingSetupFormBAL = new BankAccountingSetupFormBAL();
    BankAccountingSetupFormUI bankAccountingSetupFormUI = new BankAccountingSetupFormUI();
    ChequeBookListBAL chequeBookListBAL = new ChequeBookListBAL();
    ChequeBookListUI chequeBookFormUI = new ChequeBookListUI();

    #endregion Data Members

    #region Event
    protected override void Page_Load(object sender, EventArgs e)
    {
        BatchFormUI batchFormUI = new BatchFormUI();


        if (!Page.IsPostBack)        {

            
            if (Request.QueryString["BankAccountingSetupId"] != null || Request.QueryString["recordId"] != null)
            {
                bankAccountingSetupFormUI.Tbl_BankAccountingSetupId = (Request.QueryString["BankAccountingSetupId"] != null ? Request.QueryString["BankAccountingSetupId"] : Request.QueryString["recordId"]);
                FillForm(bankAccountingSetupFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update BankAccountingSetup";
            }
            else
            {


                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New BankAccountingSetup";
            }
        }

    }

   

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            bankAccountingSetupFormUI.CreatedBy = SessionContext.UserGuid;
            bankAccountingSetupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            bankAccountingSetupFormUI.Depositcode = txtDepositcode.Text;
            bankAccountingSetupFormUI.Deposit =Convert.ToDecimal(txtDeposit.Text);
            bankAccountingSetupFormUI.ReceiptCode = txtReceiptCode.Text;
            bankAccountingSetupFormUI.Receipt = Convert.ToDecimal(txtReceipt.Text);
            bankAccountingSetupFormUI.CheckCode = txtCheckCode.Text;
            bankAccountingSetupFormUI.Check = Convert.ToDecimal(txtCheck.Text);
            bankAccountingSetupFormUI.WithdrawalCode = txtWithdrawalCode.Text;
            bankAccountingSetupFormUI.Withdrawal = Convert.ToDecimal(txtWithdrawal.Text);
            bankAccountingSetupFormUI.IncreaseAdjustmentCode = txtIncreaseAdjustmentCode.Text;
            bankAccountingSetupFormUI.IncreaseAdjustment = Convert.ToDecimal(txtIncreaseAdjustment.Text);
            bankAccountingSetupFormUI.DecreaseAdjustmentCode = txtDecreaseAdjustmentCode.Text;
            bankAccountingSetupFormUI.DecreaseAdjustment = Convert.ToDecimal(txtDecreaseAdjustment.Text);
            bankAccountingSetupFormUI.TransferCode = txtTransferCode.Text;
            bankAccountingSetupFormUI.Transfer = Convert.ToDecimal(txtTransfer.Text);
            if (chkIsTransaction_Reconcilation.Checked)
            { bankAccountingSetupFormUI.IsTransaction_Reconcilation = true; }
            else { bankAccountingSetupFormUI.IsTransaction_Reconcilation = true; }
            bankAccountingSetupFormUI.Tbl_ChequeBookId = txtChequeBookGuid.Text;
            bankAccountingSetupFormUI.InterestIncomeCode = txtInterestIncomeCode.Text;
            bankAccountingSetupFormUI.InterestIncome = Convert.ToDecimal(txtInterestIncome.Text);
            bankAccountingSetupFormUI.OtherIncomeCode = txtOtherIncomeCode.Text;
            bankAccountingSetupFormUI.OtherIncome = Convert.ToDecimal(txtOtherIncome.Text);
            bankAccountingSetupFormUI.OtherExpenseCode = txtOtherExpenseCode.Text;
            bankAccountingSetupFormUI.OtherExpense = Convert.ToDecimal(txtOtherExpense.Text);
            bankAccountingSetupFormUI.ServiceChargeCode = txtServiceChargeCode.Text;
            bankAccountingSetupFormUI.ServiceCharge = Convert.ToDecimal(txtServiceCharge.Text);

            if (bankAccountingSetupFormBAL.AddBankAccountingSetup(bankAccountingSetupFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BankAccountingSetupForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BankAccountingSetupForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            bankAccountingSetupFormUI.ModifiedBy = SessionContext.UserGuid;
            bankAccountingSetupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            bankAccountingSetupFormUI.Tbl_BankAccountingSetupId = Request.QueryString["BankAccountingSetupId"];
            bankAccountingSetupFormUI.Depositcode = txtDepositcode.Text;
            bankAccountingSetupFormUI.Deposit = Convert.ToDecimal(txtDeposit.Text);
            bankAccountingSetupFormUI.ReceiptCode = txtReceiptCode.Text;
            bankAccountingSetupFormUI.Receipt = Convert.ToDecimal(txtReceipt.Text);
            bankAccountingSetupFormUI.CheckCode = txtCheckCode.Text;
            bankAccountingSetupFormUI.Check = Convert.ToDecimal(txtCheck.Text);
            bankAccountingSetupFormUI.WithdrawalCode = txtWithdrawalCode.Text;
            bankAccountingSetupFormUI.Withdrawal = Convert.ToDecimal(txtWithdrawal.Text);
            bankAccountingSetupFormUI.IncreaseAdjustmentCode = txtIncreaseAdjustmentCode.Text;
            bankAccountingSetupFormUI.IncreaseAdjustment = Convert.ToDecimal(txtIncreaseAdjustment.Text);
            bankAccountingSetupFormUI.DecreaseAdjustmentCode = txtDecreaseAdjustmentCode.Text;
            bankAccountingSetupFormUI.DecreaseAdjustment = Convert.ToDecimal(txtDecreaseAdjustment.Text);
            bankAccountingSetupFormUI.TransferCode = txtTransferCode.Text;
            bankAccountingSetupFormUI.Transfer = Convert.ToDecimal(txtTransfer.Text);
            if (chkIsTransaction_Reconcilation.Checked)
            { bankAccountingSetupFormUI.IsTransaction_Reconcilation = true; }
            else { bankAccountingSetupFormUI.IsTransaction_Reconcilation = true; }
            bankAccountingSetupFormUI.Tbl_ChequeBookId = txtChequeBookGuid.Text;
            bankAccountingSetupFormUI.InterestIncomeCode = txtInterestIncomeCode.Text;
            bankAccountingSetupFormUI.InterestIncome = Convert.ToDecimal(txtInterestIncome.Text);
            bankAccountingSetupFormUI.OtherIncomeCode = txtOtherIncomeCode.Text;
            bankAccountingSetupFormUI.OtherIncome = Convert.ToDecimal(txtOtherIncome.Text);
            bankAccountingSetupFormUI.OtherExpenseCode = txtOtherExpenseCode.Text;
            bankAccountingSetupFormUI.OtherExpense = Convert.ToDecimal(txtOtherExpense.Text);
            bankAccountingSetupFormUI.ServiceChargeCode = txtServiceChargeCode.Text;
            bankAccountingSetupFormUI.ServiceCharge = Convert.ToDecimal(txtServiceCharge.Text);


            if (bankAccountingSetupFormBAL.UpdateBankAccountingSetup(bankAccountingSetupFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
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
            logExcpUIobj.ResourceName = "System_Settings_BankAccountingSetupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BankAccountingSetupForm : btnUpdate_Click] An error occured in the processing of Record Id : " + bankAccountingSetupFormUI.Tbl_BankAccountingSetupId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            bankAccountingSetupFormUI.Tbl_BankAccountingSetupId = Request.QueryString["BankAccountingSetupId"];

            if (bankAccountingSetupFormBAL.DeleteBankAccountingSetup(bankAccountingSetupFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BankAccountingSetupForm.CS";
            logExcpUIobj.RecordId = bankAccountingSetupFormUI.Tbl_BankAccountingSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BankAccountingSetupForm : btnDelete_Click] An error occured in the processing of Record Id : " + bankAccountingSetupFormUI.Tbl_BankAccountingSetupId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("BankAccountingSetupList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/System_Settings/BankAccountingSetupForm .aspx";
        string recordId = Request.QueryString["BankAccountingSetupID"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

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
    #endregion Event
    #region Method

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
            logExcpUIobj.MethodName = "System_Settings_BankAccountingSetupForm()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BankAccountingSetupForm : BindChequeBookList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }

    private void FillForm(BankAccountingSetupFormUI bankAccountingSetupFormUI)
    {
        try
        {
            DataTable dtb = bankAccountingSetupFormBAL.GetBankAccountingSetupById(bankAccountingSetupFormUI);

            if (dtb.Rows.Count > 0)
            {

                txtDepositcode.Text = dtb.Rows[0]["Depositcode"].ToString();
                txtDeposit.Text = dtb.Rows[0]["Deposit"].ToString();
                txtReceiptCode.Text = dtb.Rows[0]["ReceiptCode"].ToString();
                txtReceipt.Text = dtb.Rows[0]["Receipt"].ToString();
                txtCheckCode.Text = dtb.Rows[0]["CheckCode"].ToString();
                txtCheck.Text = dtb.Rows[0]["Check"].ToString();
                txtWithdrawalCode.Text = dtb.Rows[0]["WithdrawalCode"].ToString();
                txtWithdrawal.Text = dtb.Rows[0]["Withdrawal"].ToString();
                txtIncreaseAdjustmentCode.Text = dtb.Rows[0]["IncreaseAdjustmentCode"].ToString();
                txtIncreaseAdjustment.Text = dtb.Rows[0]["IncreaseAdjustment"].ToString();
                txtDecreaseAdjustmentCode.Text = dtb.Rows[0]["DecreaseAdjustmentCode"].ToString();
                txtDecreaseAdjustment.Text = dtb.Rows[0]["DecreaseAdjustment"].ToString();
                txtTransferCode.Text = dtb.Rows[0]["TransferCode"].ToString();
                txtTransfer.Text = dtb.Rows[0]["Transfer"].ToString();

                if (Convert.ToBoolean(dtb.Rows[0]["IsTransaction_Reconcilation"]) == true)
                {
                    chkIsTransaction_Reconcilation.Checked = true;
                }

                else
                {
                    chkIsTransaction_Reconcilation.Checked = false;
                }
                txtChequeBookGuid.Text = dtb.Rows[0]["tbl_ChequeBookId"].ToString();
                txtChequeBook.Text = dtb.Rows[0]["ChequeBookName"].ToString();
                txtInterestIncomeCode.Text = dtb.Rows[0]["InterestIncomeCode"].ToString();
                txtInterestIncome.Text = dtb.Rows[0]["InterestIncome"].ToString();
                txtOtherIncomeCode.Text = dtb.Rows[0]["OtherIncomeCode"].ToString();
                txtOtherIncome.Text = dtb.Rows[0]["OtherIncome"].ToString();
                txtOtherExpenseCode.Text = dtb.Rows[0]["OtherExpenseCode"].ToString();
                txtOtherExpense.Text = dtb.Rows[0]["OtherExpense"].ToString();
                txtServiceChargeCode.Text = dtb.Rows[0]["ServiceChargeCode"].ToString();
                txtServiceCharge.Text = dtb.Rows[0]["ServiceCharge"].ToString();
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
            logExcpUIobj.ResourceName = "System_Settings_BankAccountingSetupForm.CS";
            logExcpUIobj.RecordId = bankAccountingSetupFormUI.Tbl_BankAccountingSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BankAccountingSetupForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion
    #endregion
}
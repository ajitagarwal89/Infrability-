using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using log4net;
using Finware;

public partial class Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    PayableSetupGroupFormUI payableSetupGroupFormUI = new PayableSetupGroupFormUI();
    PayableSetupGroupFormBAL payableSetupGroupFormBAL = new PayableSetupGroupFormBAL();

    PayableSetupGroupListBAL payableSetupGroupListBAL = new PayableSetupGroupListBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    ChequeBookListBAL chequeBookListBAL = new ChequeBookListBAL();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    CurrencyListUI currencyListUI = new CurrencyListUI();
    PaymentTermsListBAL paymentTermsListBAL = new PaymentTermsListBAL();
   

    PayableSetupAndGroupAccountFormUI payableSetupAndGroupAccountFormUI = new PayableSetupAndGroupAccountFormUI();
    PayableSetupAndGroupAccountFormBAL payableSetupAndGroupAccountFormBAL = new PayableSetupAndGroupAccountFormBAL();

    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    PayableSetupListBAL payableSetupListBAL = new PayableSetupListBAL();

    #endregion Data Members
    protected override void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            BindPayableAccountTypeDropDownList();

            if (Request.QueryString["PayableSetupAndGroupAccountId"] != null || Request.QueryString["recordId"] != null)
            {
                payableSetupAndGroupAccountFormUI.tbl_PayableSetupAndGroupAccountId = (Request.QueryString["PayableSetupAndGroupAccountId"] != null ? Request.QueryString["PayableSetupAndGroupAccountId"] : Request.QueryString["recordId"]);
                FillForm(payableSetupAndGroupAccountFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update PayableSetupAndGroupAccount";
            }
            else
            {


                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New PayableSetupAndGroupAccount";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            payableSetupAndGroupAccountFormUI.CreatedBy = SessionContext.UserGuid;
            payableSetupAndGroupAccountFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            payableSetupAndGroupAccountFormUI.tbl_PayableSetup = txtPayableSetupGuid.Text;
            payableSetupAndGroupAccountFormUI.tbl_PayableSetupGroupId = Guid.Parse(txtPayableSetupGroupGuid.Text).ToString(); 
            payableSetupAndGroupAccountFormUI.tbl_ChequeBookId = txtChequeBookGuid.Text;
            payableSetupAndGroupAccountFormUI.Opt_AccountType = Convert.ToInt32(ddlAccountType.SelectedValue);


            if (chkPaymentMode.Checked)
            {
                payableSetupAndGroupAccountFormUI.PaymentMode = true;
            }
            else
            {
                payableSetupAndGroupAccountFormUI.PaymentMode = false;
            }
            payableSetupAndGroupAccountFormUI.tbl_GLAccountId_Cash = txtGLAccountId_CashGuid.Text;
            payableSetupAndGroupAccountFormUI.tbl_GLAccountId_AccountReceivable = txtGLAccountId_AccountReceivableGuid.Text;
            payableSetupAndGroupAccountFormUI.tbl_GLAccountId_Sales = txtGLAccountId_SalesGuid.Text;
            payableSetupAndGroupAccountFormUI.tbl_GLAccountId_CostOfSales = txtGLAccountId_CostOfSalesGuid.Text;
            payableSetupAndGroupAccountFormUI.tbl_GLAccountId_Inventory = txtGLAccountId_InventoryGuid.Text;
            payableSetupAndGroupAccountFormUI.tbl_GLAccountId_AccuralDifferedA_C = txtGLAccountId_AccuralDifferedA_CGuid.Text;
            if (payableSetupAndGroupAccountFormBAL.AddPayableSetupAndGroupAccount(payableSetupAndGroupAccountFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            payableSetupAndGroupAccountFormUI.ModifiedBy = SessionContext.UserGuid;
            payableSetupAndGroupAccountFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            payableSetupAndGroupAccountFormUI.tbl_PayableSetupAndGroupAccountId = Request.QueryString["PayableSetupAndGroupAccountId"];
            payableSetupAndGroupAccountFormUI.tbl_PayableSetup = txtPayableSetupGuid.Text;
            payableSetupAndGroupAccountFormUI.tbl_PayableSetupGroupId =Guid.Parse(txtPayableSetupGroupGuid.Text).ToString();
            payableSetupAndGroupAccountFormUI.tbl_ChequeBookId = txtChequeBookGuid.Text;
            payableSetupAndGroupAccountFormUI.Opt_AccountType = Convert.ToInt32(ddlAccountType.SelectedValue);


            if (chkPaymentMode.Checked)
            {
                payableSetupAndGroupAccountFormUI.PaymentMode = true;
            }
            else
            {
                payableSetupAndGroupAccountFormUI.PaymentMode = false;
            }
            payableSetupAndGroupAccountFormUI.tbl_GLAccountId_Cash = txtGLAccountId_CashGuid.Text;
            payableSetupAndGroupAccountFormUI.tbl_GLAccountId_AccountReceivable = txtGLAccountId_AccountReceivableGuid.Text;
            payableSetupAndGroupAccountFormUI.tbl_GLAccountId_Sales = txtGLAccountId_SalesGuid.Text;
            payableSetupAndGroupAccountFormUI.tbl_GLAccountId_CostOfSales = txtGLAccountId_CostOfSalesGuid.Text;
            payableSetupAndGroupAccountFormUI.tbl_GLAccountId_Inventory = txtGLAccountId_InventoryGuid.Text;
            payableSetupAndGroupAccountFormUI.tbl_GLAccountId_AccuralDifferedA_C = txtGLAccountId_AccuralDifferedA_CGuid.Text;


            if (payableSetupAndGroupAccountFormBAL.UpdatePayableSetupAndGroupAccount(payableSetupAndGroupAccountFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm : btnUpdate_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            payableSetupAndGroupAccountFormUI.tbl_PayableSetupAndGroupAccountId = Request.QueryString["PayableSetupAndGroupAccountId"];

            if (payableSetupAndGroupAccountFormBAL.DeletePayableSetupAndGroupAccount(payableSetupAndGroupAccountFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = payableSetupAndGroupAccountFormUI.tbl_PayableSetupAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm : btnDelete_Click] An error occured in the processing of Record Id : " + payableSetupAndGroupAccountFormUI.tbl_PayableSetupAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PayableSetupAndGroupAccountList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Finance/Accounts_Payable/Setup/PayableSetupAndGroupAccountForm.aspx";
        string recordId = Request.QueryString["PayableSetupAndGroupAccountId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    #region  BindPayableAccountTypeDropDownList
    private void BindPayableAccountTypeDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_PayableSetupAndGroupAccount";
            optionSetListUI.OptionSetName = "Opt_AccountType";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlAccountType.DataSource = dtb;

                ddlAccountType.DataTextField = "OptionSetLable";
                ddlAccountType.DataValueField = "OptionSetValue";

                ddlAccountType.DataBind();

                ddlAccountType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlAccountType.SelectedIndex = 0;
            }
            else
            {
                ddlAccountType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPayablesTypeDropDownList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm : BindPayablesTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion
    #region Methods
    private void FillForm(PayableSetupAndGroupAccountFormUI payableSetupAndGroupAccountFormUI)
    {
        try
        {
            DataTable dtb = payableSetupAndGroupAccountFormBAL.GetPayableSetupAndGroupAccountListById(this.payableSetupAndGroupAccountFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtPayableSetup.Text= dtb.Rows[0]["tbl_PayableSetup"].ToString();
                txtPayableSetupGuid.Text= dtb.Rows[0]["tbl_PayableSetupId"].ToString();
                txtPayableSetupGroup.Text = dtb.Rows[0]["tbl_PayableSetupGroup"].ToString();
                txtPayableSetupGroupGuid.Text = dtb.Rows[0]["tbl_PayableSetupGroupId"].ToString();
                txtChequeBook.Text = dtb.Rows[0]["ChequeBookName"].ToString();
                txtChequeBookGuid.Text = dtb.Rows[0]["tbl_ChequeBookId"].ToString();
                ddlAccountType.SelectedValue = dtb.Rows[0]["Opt_AccountType"].ToString();
                if (Convert.ToBoolean(dtb.Rows[0]["PaymentMode"]) == true)
                {
                    chkPaymentMode.Checked = true;
                }
                else
                {
                    chkPaymentMode.Checked = false;
                }
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = payableSetupAndGroupAccountFormUI.tbl_PayableSetupAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods

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
                logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm.CS";
                logExcpUIobj.RecordId = "All";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm : SearchChequeBookList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm : BindCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion


    #region  PayableSetupSearch
    protected void btnPayableSetupSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPayableSetupSearch.Visible = false;
        btnHtmlPayableSetupClose.Visible = true;
        SearchPayableSetupList();

    }
    protected void btnClearPayableSetupSearch_Click(object sender, EventArgs e)
    {
        BindPayableSetupList();
        gvPayableSetupSearch.Visible = true;
        btnHtmlPayableSetupSearch.Visible = true;
        btnHtmlPayableSetupClose.Visible = false;
        txtPayableSetup.Text = "";
        txtPayableSetup.Focus();

    }
    protected void btnPayableSetupRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPayableSetupList();
    }
    #endregion

    #region SearchPayableSetup
    private void SearchPayableSetupList()
    {

        {
            try
            {
                PayableSetupListBAL payableSetupListBAL = new PayableSetupListBAL();
                PayableSetupListUI payableSetupListUI = new PayableSetupListUI();


                payableSetupListUI.Search = txtChequeBookSearch.Text;

                DataTable dtb = payableSetupListBAL.GetPayableSetupListtBySearchParameters(payableSetupListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    gvPayableSetupSearch.DataSource = dtb;
                    gvPayableSetupSearch.DataBind();
                    divPayableSetupSearchError.Visible = false;
                }
                else
                {
                    divPayableSetupSearchError.Visible = true;
                    lblPayableSetupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                    gvPayableSetupSearch.Visible = false;
                }

            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "SearchChequeBookList()";
                logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm.CS";
                logExcpUIobj.RecordId = "All";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm : SearchChequeBookList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
        }
    }
    private void BindPayableSetupList()
    {
        try
        {
            DataTable dtb = payableSetupListBAL.GetPayableSetupList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPayableSetupSearch.DataSource = dtb;
                gvPayableSetupSearch.DataBind();
                divPayableSetupSearchError.Visible = false;
            }
            else
            {
                divPayableSetupSearchError.Visible = true;
                lblPayableSetupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPayableSetupSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindChequeBookList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm : BindCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion

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

    #region SearchPayableSetupGroup
    private void SearchPayableSetupGroup()
    {

        {
            try
            {

                PayableSetupGroupListUI payableSetupGroupListUI = new PayableSetupGroupListUI();



                payableSetupGroupListUI.Search = txtPayableSetupGroupSearch.Text;

                DataTable dtb = payableSetupGroupListBAL.GetPayableSetupGroupListBySearchParameters(payableSetupGroupListUI);

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
                logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm.CS";
                logExcpUIobj.RecordId = "All";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm : SearchPayableSetupGroup_Self] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
        }
    }
    private void BindPayableSetupGroup()
    {
        try
        {
            DataTable dtb = payableSetupGroupListBAL.GetPayableSetupGroup_List();

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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm : BindPayableSetupGroup_Self] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion




    #region Model popup


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




    #region Bind And Search


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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm : SearchCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm : BindCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm : SearchAccountPayableList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm : BindAccountReceivable] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
                logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm.CS";
                logExcpUIobj.RecordId = "All";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm : SearchSalesList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm : BindPurchaseList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm : SearchCostOfSalestList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm : BindCostOfSales] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm : SearchInventoryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm : BindInventoryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm : SearchAccuralDifferedA_CList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm : BindAccuralDifferedA_CList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion


}
#endregion Bind And Search
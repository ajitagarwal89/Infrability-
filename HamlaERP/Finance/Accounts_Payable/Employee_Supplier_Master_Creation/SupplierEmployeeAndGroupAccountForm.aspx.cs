using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeAndGroupAccountForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    SupplierEmployeeAndGroupAccountFormBAL supplierEmployeeAndGroupAccountFormBAL = new SupplierEmployeeAndGroupAccountFormBAL();
    SupplierEmployeeAndGroupAccountFormUI supplierEmployeeAndGroupAccountFormUI = new SupplierEmployeeAndGroupAccountFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    GLAccountListUI gLAccountListUI = new GLAccountListUI();
    SupplierEmployeeGroupListBAL supplierEmployeeGroupListBAL = new SupplierEmployeeGroupListBAL();
    SupplierEmployeeGroupListUI supplierEmployeeGroupListUI = new SupplierEmployeeGroupListUI();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        SupplierEmployeeAndGroupAccountFormUI supplierEmployeeAndGroupAccountFormUI = new SupplierEmployeeAndGroupAccountFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["SupplierEmployeeAndGroupAccountId"] != null || Request.QueryString["recordId"] != null)
            {
                supplierEmployeeAndGroupAccountFormUI.Tbl_SupplierEmployeeAndGroupAccountId = (Request.QueryString["SupplierEmployeeAndGroupAccountId"] != null ? Request.QueryString["SupplierEmployeeAndGroupAccountId"] : Request.QueryString["recordId"]);


                BindOptionAccountTypeDropDown();
                FillForm(supplierEmployeeAndGroupAccountFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnAuditHistory.Visible = true;
                lblHeading.Text = "Update Supplier Employee And GroupAccount";
            }
            else
            {

                BindOptionAccountTypeDropDown();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;    
                lblHeading.Text = "Add New Supplier Employee And GroupAccount";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            supplierEmployeeAndGroupAccountFormUI.CreatedBy = SessionContext.UserGuid;
            supplierEmployeeAndGroupAccountFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            supplierEmployeeAndGroupAccountFormUI.Tbl_SupplierEmployeeGroupId = txtSupplierEmployeeGroupGuid.Text;
            supplierEmployeeAndGroupAccountFormUI.Opt_AccountType = Convert.ToByte(ddlOpt_AccountType.SelectedValue);

            if (chkPaymentMode.Checked == true)
                supplierEmployeeAndGroupAccountFormUI.PaymentMode = true;
            else
                supplierEmployeeAndGroupAccountFormUI.PaymentMode = false;

            supplierEmployeeAndGroupAccountFormUI.Tbl_GLAccountId_Cash = txtGLAccountId_CashGuid.Text.Trim(); ;
            supplierEmployeeAndGroupAccountFormUI.Tbl_GLAccountId_AccountPayable = txtAccountPayableGuid.Text.Trim();
            supplierEmployeeAndGroupAccountFormUI.Tbl_GLAccountId_Purchase = txtPurchaseGuid.Text.Trim();
            supplierEmployeeAndGroupAccountFormUI.Tbl_GLAccountId_TradeDiscount = txtTradeDiscountGuid.Text.Trim();
            supplierEmployeeAndGroupAccountFormUI.Tbl_GLAccountId_Freight = txtFreightGuid.Text.Trim();
            supplierEmployeeAndGroupAccountFormUI.Tbl_GLAccountId_AccruedPurchase = txtAccruedPurchaseguid.Text.Trim();


            if (supplierEmployeeAndGroupAccountFormBAL.AddSupplierEmployeeAndGroupAccount(supplierEmployeeAndGroupAccountFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeAndGroupAccountList.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeAndGroupAccountList : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            supplierEmployeeAndGroupAccountFormUI.ModifiedBy = SessionContext.UserGuid;
            supplierEmployeeAndGroupAccountFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            supplierEmployeeAndGroupAccountFormUI.Tbl_SupplierEmployeeAndGroupAccountId = Request.QueryString["SupplierEmployeeAndGroupAccountId"];

            supplierEmployeeAndGroupAccountFormUI.Tbl_SupplierEmployeeGroupId = txtSupplierEmployeeGroupGuid.Text;
            supplierEmployeeAndGroupAccountFormUI.Opt_AccountType = Convert.ToByte(ddlOpt_AccountType.SelectedValue);

            if (chkPaymentMode.Checked == true)
                supplierEmployeeAndGroupAccountFormUI.PaymentMode = true;
            else
                supplierEmployeeAndGroupAccountFormUI.PaymentMode = false;

            supplierEmployeeAndGroupAccountFormUI.Tbl_GLAccountId_Cash = txtGLAccountId_CashGuid.Text.Trim(); ;
            supplierEmployeeAndGroupAccountFormUI.Tbl_GLAccountId_AccountPayable = txtAccountPayableGuid.Text.Trim();
            supplierEmployeeAndGroupAccountFormUI.Tbl_GLAccountId_Purchase = txtPurchaseGuid.Text.Trim();
            supplierEmployeeAndGroupAccountFormUI.Tbl_GLAccountId_TradeDiscount = txtTradeDiscountGuid.Text.Trim();
            supplierEmployeeAndGroupAccountFormUI.Tbl_GLAccountId_Freight = txtFreightGuid.Text.Trim();
            supplierEmployeeAndGroupAccountFormUI.Tbl_GLAccountId_AccruedPurchase = txtAccruedPurchaseguid.Text.Trim();
            if (supplierEmployeeAndGroupAccountFormBAL.UpdateSupplierEmployeeAndGroupAccount(supplierEmployeeAndGroupAccountFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeAndGroupAccountList.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeAndGroupAccountList : btnUpdate_Click] An error occured in the processing of Record Id : " + supplierEmployeeAndGroupAccountFormUI.Tbl_SupplierEmployeeAndGroupAccountId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            supplierEmployeeAndGroupAccountFormUI.Tbl_SupplierEmployeeAndGroupAccountId = Request.QueryString["SupplierEmployeeAndGroupAccountId"];

            if (supplierEmployeeAndGroupAccountFormBAL.DeleteSupplierEmployeeAndGroupAccount(supplierEmployeeAndGroupAccountFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeAndGroupAccountList.CS";
            logExcpUIobj.RecordId = supplierEmployeeAndGroupAccountFormUI.Tbl_SupplierEmployeeAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeAndGroupAccountList : btnDelete_Click] An error occured in the processing of Record Id : " + supplierEmployeeAndGroupAccountFormUI.Tbl_SupplierEmployeeAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("SupplierEmployeeAndGroupAccountList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Finance/Accounts_Payable/Supplier_Master_Creation/SupplierEmployeeAndGroupAccountForm.aspx";
        string recordId = Request.QueryString["SupplierEmployeeAndGroupAccountId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }



    #region Events Search
    #region SupplierEmployee Group
    protected void btnSupplierEmployeeGroupSearch_Click(object sender, EventArgs e)
    {
        btnHtmlSupplierEmployeeGroupSearch.Visible = false;
        btnHtmlSupplierEmployeeGroupClose.Visible = true;
        SearchSupplierEmployeeGroupList();

    }
    protected void btnClearSupplierEmployeeGroupSearch_Click(object sender, EventArgs e)
    {
        BindSupplierEmployeeGroupList();
        gvSupplierEmployeeGroupSearch.Visible = true;
        btnHtmlSupplierEmployeeGroupSearch.Visible = true;
        btnHtmlSupplierEmployeeGroupClose.Visible = false;
        txtSupplierEmployeeGroupSearch.Text = "";
        txtSupplierEmployeeGroupSearch.Focus();

    }
    protected void btnSupplierEmployeeGroupRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindSupplierEmployeeGroupList();
    }

    #endregion

    #region CashSearch
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
   
    #region AccountPayableSearch
    protected void btnAccountPayableSearch_Click(object sender, EventArgs e)
    {
        btnHtmlAccountPayableSearch.Visible = false;
        btnHtmlAccountPayableClose.Visible = true;
        SearchAccountPayableList();

    }
    protected void btnClearAccountPayableSearch_Click(object sender, EventArgs e)
    {
        BindAccountPayable();
        gvAccountPayableSearch.Visible = true;
        btnHtmlAccountPayableSearch.Visible = true;
        btnHtmlAccountPayableClose.Visible = false;
        txtAccountPayableSearch.Text = "";
        txtAccountPayableSearch.Focus();

    }
    protected void btnAccountPayableRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindAccountPayable();

    }
    #endregion
   
    #region PurchaseSearch
    protected void btnPurchaseSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPurchaseSearch.Visible = false;
        btnHtmlPurchaseClose.Visible = true;
        SearchPurchaseList();
    }
    protected void btnClearPurchaseSearch_Click(object sender, EventArgs e)
    {
        BindPurchaseList();
        gvPurchaseSearch.Visible = true;
        btnHtmlPurchaseSearch.Visible = true;
        btnHtmlPurchaseClose.Visible = false;
        SearchPurchaseList();
    }
    protected void btnPurchaseRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPurchaseList();
    }
    #endregion
   
    #region Trade DiscountSearch
    protected void btnTradeDiscountSearch_Click(object sender, EventArgs e)
    {
        btnHtmlTradeDiscountSearch.Visible = false;
        btnHtmlTradeDiscountClose.Visible = true;
        SearchTradeDiscountList();
    }
    protected void btnClearTradeDiscountSearch_Click(object sender, EventArgs e)
    {
        BindTradeDiscount();
        gvTradeDiscountSearch.Visible = true;
        btnHtmlTradeDiscountSearch.Visible = true;
        btnHtmlTradeDiscountClose.Visible = false;
        txtTradeDiscountSearch.Text = "";
        txtTradeDiscountSearch.Focus();
    }
    protected void btnTradeDiscountRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindTradeDiscount();
    }
    #endregion TradeDiscountSearch
      
    #region FreightSearch
    protected void btnFreightSearch_Click(object sender, EventArgs e)
    {

        btnHtmlFreightSearch.Visible = false;
        btnHtmlFreightClose.Visible = true;
        SearchFreightList();
    }
    protected void btnClearFreightSearch_Click(object sender, EventArgs e)
    {

        BindFreightList();
        gvFreightSearch.Visible = true;
        btnHtmlFreightSearch.Visible = true;
        btnHtmlFreightClose.Visible = false;
        txtFreightSearch.Text = "";
        txtFreightSearch.Focus();

    }

    protected void btnFreightRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindFreightList();
    }

    #endregion
   
    #region  Accrued PurchaseSearch
    protected void btnAccruedPurchaseSearch_Click(object sender, EventArgs e)
    {
        btnHtmlAccruedPurchaseSearch.Visible = false;
        btnHtmlAccruedPurchaseClose.Visible = true;
        SearchAccruedPurchaseList();
    }
    protected void btnClearAccruedPurchaseSearch_Click(object sender, EventArgs e)
    {
        BindAccruedPurchaseList();
        gvAccruedPurchaseSearch.Visible = true;
        btnHtmlAccruedPurchaseSearch.Visible = true;
        btnHtmlAccruedPurchaseClose.Visible = false;
        txtAccruedPurchaseSearch.Text = "";
        txtAccruedPurchaseSearch.Focus();

    }
    protected void btnAccruedPurchaseRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindAccruedPurchaseList();
    }
    #endregion
    #endregion Events Search

    #endregion Events

    #region Methods
    private void FillForm(SupplierEmployeeAndGroupAccountFormUI supplierEmployeeAndGroupAccountFormUI)
    {
        try
        {
            DataTable dtb = supplierEmployeeAndGroupAccountFormBAL.GetSupplierEmployeeAndGroupAccountListById(supplierEmployeeAndGroupAccountFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtSupplierEmployeeGroupGuid.Text = dtb.Rows[0]["tbl_SupplierEmployeeGroupId"].ToString();

                txtSupplierEmployeeGroup.Text = dtb.Rows[0]["tbl_SupplierEmployeeGroup"].ToString();
                ddlOpt_AccountType.SelectedValue = dtb.Rows[0]["Opt_AccountType"].ToString();
                if (Convert.ToBoolean(dtb.Rows[0]["PaymentMode"]) == true)
                {
                    chkPaymentMode.Checked = true;
                }
                else
                {
                    chkPaymentMode.Checked = false;
                }
                txtGLAccountId_CashGuid.Text = dtb.Rows[0]["tbl_GLAccountId_Cash"].ToString();
                txtGLAccountId_Cash.Text = dtb.Rows[0]["Cash"].ToString();
                txtAccountPayable.Text = dtb.Rows[0]["AccountPayable"].ToString();
                txtAccountPayableGuid.Text = dtb.Rows[0]["tbl_GLAccountId_AccountPayable"].ToString();
                txtPurchase.Text = dtb.Rows[0]["Purchase"].ToString();
                txtPurchaseGuid.Text = dtb.Rows[0]["tbl_GLAccountId_Purchase"].ToString();
                txtTradeDiscount.Text = dtb.Rows[0]["TradeDiscount"].ToString();
                txtTradeDiscountGuid.Text = dtb.Rows[0]["tbl_GLAccountId_TradeDiscount"].ToString();
                txtFeight.Text = dtb.Rows[0]["Freight"].ToString();
                txtFreightGuid.Text = dtb.Rows[0]["tbl_GLAccountId_Freight"].ToString();
                txtAccruedPurchase.Text = dtb.Rows[0]["AccruedPurchase"].ToString();
                txtAccruedPurchaseguid.Text = dtb.Rows[0]["tbl_GLAccountId_AccruedPurchase"].ToString();
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeAndGroupAccountList.CS";
            logExcpUIobj.RecordId = supplierEmployeeAndGroupAccountFormUI.Tbl_SupplierEmployeeAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeAndGroupAccountList : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }



    #region BindOption Account TypeDropDown
    private void BindOptionAccountTypeDropDown()
    {
        OptionSetListUI optionSetListUI = new OptionSetListUI();
        optionSetListUI.TableName = "tbl_SupplierAndGroupAccount";
        optionSetListUI.OptionSetName = "Opt_AccountType";

        DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
        if (dtb.Rows.Count > 0)
        {
            ddlOpt_AccountType.DataSource = dtb;
            ddlOpt_AccountType.DataBind();
            ddlOpt_AccountType.DataTextField = "OptionSetLable";
            ddlOpt_AccountType.DataValueField = "OptionSetValue";
            ddlOpt_AccountType.DataBind();
        }
        else
        {
            ddlOpt_AccountType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "-1"));
        }
    }
    #endregion

    #region SearchSupplierEmployeeGroup
    private void SearchSupplierEmployeeGroupList()
    {
        try
        {
            SupplierEmployeeGroupListBAL supplierEmployeeGroupListBAL = new SupplierEmployeeGroupListBAL();
            SupplierEmployeeGroupListUI supplierEmployeeGroupListUI = new SupplierEmployeeGroupListUI();

            supplierEmployeeGroupListUI.Search = txtSupplierEmployeeGroupSearch.Text;

            DataTable dtb = supplierEmployeeGroupListBAL.GetSupplierEmployeeGroupListBySearchParameters(supplierEmployeeGroupListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSupplierEmployeeGroupSearch.DataSource = dtb;
                gvSupplierEmployeeGroupSearch.DataBind();
                divSupplierEmployeeGroupSearchError.Visible = false;
                gvSupplierEmployeeGroupSearch.Visible = true;
            }
            else
            {
                divSupplierEmployeeGroupSearchError.Visible = true;
                lblSupplierEmployeeGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSupplierEmployeeGroupSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchEmployeeGroupList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm : SearchEmployeeGroupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindSupplierEmployeeGroupList()
    {
        try
        {
            DataTable dtb = supplierEmployeeGroupListBAL.GetSupplierEmployeeGroupList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSupplierEmployeeGroupSearch.DataSource = dtb;
                gvSupplierEmployeeGroupSearch.DataBind();
                divSupplierEmployeeGroupSearchError.Visible = false;
            }
            else
            {
                divSupplierEmployeeGroupSearchError.Visible = true;
                lblSupplierEmployeeGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSupplierEmployeeGroupSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindEmployeeGroupList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SearchSupplierGroup : BindEmployeeGroupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
                gvGLAccountId_CashSearch.Visible = true;
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm : SearchCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm : BindCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion
 
    #region SearchAccountPayable
    private void SearchAccountPayableList()
    {
        try
        {
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtAccountPayableSearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAccountPayableSearch.DataSource = dtb;
                gvAccountPayableSearch.DataBind();
                divAccountPayableSearchError.Visible = false;
                gvAccountPayableSearch.Visible = true;

            }
            else
            {
                gvAccountPayableSearch.Visible = true;
                lblAccountPayableSearchError.Text = Resources.GlobalResource.msgNoRecordFound;

                gvAccountPayableSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchAccountPayableList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm : SearchAccountPayableList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindAccountPayable()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAccountPayableSearch.DataSource = dtb;
                gvAccountPayableSearch.DataBind();
                divAccountPayableSearchError.Visible = false;
            }
            else
            {
                divAccountPayableSearchError.Visible = true; ;
                lblAccountPayableSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAccountPayableSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindAccountPayable()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm : BindAccountPayable] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }


    }
    #endregion
    
    # region SearchPurchase
    private void SearchPurchaseList()
    {

        try
        {
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtPurchaseSearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPurchaseSearch.DataSource = dtb;
                gvPurchaseSearch.DataBind();
                divPurchaseSearchError.Visible = false;
                gvPurchaseSearch.Visible = true;
            }
            else
            {
                divPurchaseSearchError.Visible = true;
                lblPurchaseSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPurchaseSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchPurchaseList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm : SearchPurchaseList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindPurchaseList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPurchaseSearch.DataSource = dtb;
                gvPurchaseSearch.DataBind();
                divPurchaseSearchError.Visible = false;
            }
            else
            {
                divPurchaseSearchError.Visible = true;
                lblPurchaseSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPurchaseSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPurchaseList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm : BindPurchaseList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion
    
    #region SearchTradeDiscount
    private void SearchTradeDiscountList()
    {
        try
        {
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtTradeDiscountSearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvTradeDiscountSearch.DataSource = dtb;
                gvTradeDiscountSearch.DataBind();
                divTradeDiscountSearchError.Visible = false;
                gvTradeDiscountSearch.Visible = true;
            }
            else
            {
                divTradeDiscountSearchError.Visible = true;
                lblTradeDiscountSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvTradeDiscountSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchTradeDiscountList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm : SearchTradeDiscountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindTradeDiscount()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvTradeDiscountSearch.DataSource = dtb;
                gvTradeDiscountSearch.DataBind();
                divTradeDiscountSearchError.Visible = false;
            }
            else
            {
                divTradeDiscountSearchError.Visible = true;
                lblTradeDiscountSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvTradeDiscountSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindTradeDiscount()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm : BindTradeDiscount] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion
    
    #region  SearchFreight
    private void SearchFreightList()
    {
        try
        {
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtFreightSearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvFreightSearch.DataSource = dtb;
                gvFreightSearch.DataBind();
                divFreightSearchError.Visible = false;
                gvFreightSearch.Visible = true;
            }
            else
            {
                divFreightSearchError.Visible = true;
                lblFreightSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvFreightSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchFreightList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm : SearchFreightList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindFreightList()
    {

        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvFreightSearch.DataSource = dtb;
                gvFreightSearch.DataBind();
                divFreightSearchError.Visible = false;
            }
            else
            {
                divFreightSearchError.Visible = true;
                lblFreightSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvFreightSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindFreightList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm : BindFreightList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion

    #region  SearchAccruedPurchase
    private void SearchAccruedPurchaseList()
    {
        try
        {
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtAccruedPurchaseSearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAccruedPurchaseSearch.DataSource = dtb;
                gvAccruedPurchaseSearch.DataBind();
                divAccruedPurchaseSearchError.Visible = false;
                gvAccruedPurchaseSearch.Visible = true;
            }
            else
            {
                divAccruedPurchaseSearchError.Visible = true;
                lblAccruedPurchaseSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAccruedPurchaseSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchAccruedPurchaseList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm : SearchAccruedPurchaseList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindAccruedPurchaseList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAccruedPurchaseSearch.DataSource = dtb;
                gvAccruedPurchaseSearch.DataBind();
                divAccruedPurchaseSearchError.Visible = false;
            }
            else
            {
                divAccruedPurchaseSearchError.Visible = true;
                lblAccruedPurchaseSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAccruedPurchaseSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindAccruedPurchaseList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_Master_Creation_SupplierAndGroupAccountForm : BindAccruedPurchaseList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion
    
    #endregion Methods
}
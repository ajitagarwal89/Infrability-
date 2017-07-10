using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    CustomerGroupListBAL customerGroupListBAL = new CustomerGroupListBAL();
    CustomerGroupListUI CustomerGroupFormUI = new CustomerGroupListUI();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    ChequeBookListBAL chequeBookListBAL = new ChequeBookListBAL();

    CustomerAndGroupAccountFormBAL customerAndGroupAccountFormBAL = new CustomerAndGroupAccountFormBAL();
    CustomerAndGroupAccountFormUI customerAndGroupAccountFormUI = new CustomerAndGroupAccountFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();

    #endregion Data Members

    #region Events

    protected override void Page_Load(object sender, EventArgs e)
    {
        CustomerAndGroupAccountFormUI customerAndGroupAccountFormUI = new CustomerAndGroupAccountFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CustomerAndGroupAccountId"] != null)
            {
                customerAndGroupAccountFormUI.Tbl_CustomerAndGroupAccountId = Request.QueryString["CustomerAndGroupAccountId"];

                BindOptionAccountTypeDropDown();

                FillForm(customerAndGroupAccountFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Customer And GroupAccount";
            }
            else
            {

                BindOptionAccountTypeDropDown();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Customer And GroupAccount";
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            customerAndGroupAccountFormUI.CreatedBy = SessionContext.UserGuid;
            customerAndGroupAccountFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            customerAndGroupAccountFormUI.Tbl_CustomerGroupId = txtCustomerGroupGuid.Text;
            customerAndGroupAccountFormUI.Opt_AccountType = Convert.ToByte(ddlOpt_AccountType.SelectedValue);

            if (chkPaymentMode.Checked == true)
                customerAndGroupAccountFormUI.PaymentMode = true;
            else
                customerAndGroupAccountFormUI.PaymentMode = false;

            customerAndGroupAccountFormUI.Tbl_GLAccountId_Cash = txtGLAccountId_CashGuid.Text.Trim(); ;
            customerAndGroupAccountFormUI.Tbl_ChequeBookId = txtChequeBookGuid.Text.Trim();
            customerAndGroupAccountFormUI.Tbl_GLAccountId_AccountReceivable = txtAccountReceivableGuid.Text.Trim();
            customerAndGroupAccountFormUI.Tbl_GLAccountId_Sales = txtCostOfSalesGuid.Text.Trim();
            customerAndGroupAccountFormUI.Tbl_GLAccountId_CostOfSales = txtCostOfSalesGuid.Text.Trim();
            customerAndGroupAccountFormUI.Tbl_GLAccountId_Inventory = txtInventoryGuid.Text.Trim();
            customerAndGroupAccountFormUI.Tbl_GLAccountId_AccuralDifferedA_C = txtAccuralDifferedA_CGuid.Text.Trim();

            if (customerAndGroupAccountFormBAL.AddCustomerAndGroupAccount(customerAndGroupAccountFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            customerAndGroupAccountFormUI.ModifiedBy = SessionContext.UserGuid;
            customerAndGroupAccountFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            customerAndGroupAccountFormUI.Tbl_CustomerAndGroupAccountId = Request.QueryString["CustomerAndGroupAccountId"];
            customerAndGroupAccountFormUI.Tbl_CustomerGroupId = txtCustomerGroupGuid.Text;
            customerAndGroupAccountFormUI.Opt_AccountType = Convert.ToByte(ddlOpt_AccountType.SelectedValue);

            if (chkPaymentMode.Checked == true)
                customerAndGroupAccountFormUI.PaymentMode = true;
            else
                customerAndGroupAccountFormUI.PaymentMode = false;

            customerAndGroupAccountFormUI.Tbl_GLAccountId_Cash = txtGLAccountId_CashGuid.Text.Trim(); ;
            customerAndGroupAccountFormUI.Tbl_ChequeBookId = txtChequeBookGuid.Text.Trim();
            customerAndGroupAccountFormUI.Tbl_GLAccountId_AccountReceivable = txtAccountReceivableGuid.Text.Trim();
            customerAndGroupAccountFormUI.Tbl_GLAccountId_Sales = txtCostOfSalesGuid.Text.Trim();
            customerAndGroupAccountFormUI.Tbl_GLAccountId_CostOfSales = txtCostOfSalesGuid.Text.Trim();
            customerAndGroupAccountFormUI.Tbl_GLAccountId_Inventory = txtInventoryGuid.Text.Trim();
            customerAndGroupAccountFormUI.Tbl_GLAccountId_AccuralDifferedA_C = txtAccuralDifferedA_CGuid.Text.Trim();


            if (customerAndGroupAccountFormBAL.UpdateCustomerAndGroupAccount(customerAndGroupAccountFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : btnUpdate_Click] An error occured in the processing of Record Id : " + customerAndGroupAccountFormUI.Tbl_CustomerAndGroupAccountId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            customerAndGroupAccountFormUI.Tbl_CustomerAndGroupAccountId = Request.QueryString["CustomerAndGroupAccountId"];

            if (customerAndGroupAccountFormBAL.DeleteCustomerAndGroupAccount(customerAndGroupAccountFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = customerAndGroupAccountFormUI.Tbl_CustomerAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : btnDelete_Click] An error occured in the processing of Record Id : " + customerAndGroupAccountFormUI.Tbl_CustomerAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerAndGroupAccountList.aspx");
    }

    #region Model popup
    #region  CustomerGroupSearch
    protected void btnCustomerGroupSearch_Click(object sender, EventArgs e)
    {
        btnHtmlCustomerGroupSearch.Visible = false;
        btnHtmlCustomerGroupClose.Visible = true;
        SearchCustomerGroupList();
    }
    protected void btnClearCustomerGroupSearch_Click(object sender, EventArgs e)
    {
        BindCustomerGroupList();
        gvCustomerGroupSearch.Visible = true;
        btnHtmlCustomerGroupSearch.Visible = true;
        btnHtmlCustomerGroupClose.Visible = false;
        txtCustomerGroupSearch.Text = "";
        txtCustomerGroupSearch.Focus();

    }
    protected void btnCustomerGroupRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindCustomerGroupList();
    }
    #endregion
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
    #endregion
    #endregion Events

    #region Method
    private void FillForm(CustomerAndGroupAccountFormUI customerAndGroupAccountFormUI)
    {
        try
        {
            DataTable dtb = customerAndGroupAccountFormBAL.GetCustomerAndGroupAccountListById(customerAndGroupAccountFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtCustomerGroup.Text = dtb.Rows[0]["tbl_CustomerGroup"].ToString();
                txtCustomerGroupGuid.Text = dtb.Rows[0]["Tbl_CustomerGroupId"].ToString();

                ddlOpt_AccountType.SelectedValue = dtb.Rows[0]["Opt_AccountType"].ToString();
                if (Convert.ToBoolean(dtb.Rows[0]["PaymentMode"]) == true)
                {
                    chkPaymentMode.Checked = true;
                }
                else
                {
                    chkPaymentMode.Checked = false;
                }
                txtGLAccountId_Cash.Text = dtb.Rows[0]["Cash"].ToString();
                txtGLAccountId_CashGuid.Text = dtb.Rows[0]["Tbl_GLAccountId_Cash"].ToString();

                txtChequeBook.Text = dtb.Rows[0]["ChequeBookName"].ToString();
                txtChequeBookGuid.Text = dtb.Rows[0]["tbl_ChequeBookId"].ToString();

                txtAccountReceivable.Text = dtb.Rows[0]["AccountReceivable"].ToString();
                txtAccountReceivableGuid.Text = dtb.Rows[0]["tbl_GLAccountId_AccountReceivable"].ToString();

                txtSales.Text = dtb.Rows[0]["Sales"].ToString();
                txtSalesGuid.Text = dtb.Rows[0]["tbl_GLAccountId_Sales"].ToString();

                txtCostOfSales.Text = dtb.Rows[0]["CostOfSales"].ToString();
                txtCostOfSalesGuid.Text = dtb.Rows[0]["tbl_GLAccountId_CostOfSales"].ToString();

                txtInventory.Text = dtb.Rows[0]["Inventory"].ToString();
                txtInventoryGuid.Text = dtb.Rows[0]["tbl_GLAccountId_Inventory"].ToString();

                txtAccuralDifferedA_C.Text = dtb.Rows[0]["AccuralDifferedA_C"].ToString();
                txtAccuralDifferedA_CGuid.Text = dtb.Rows[0]["tbl_GLAccountId_AccuralDifferedA_C"].ToString();

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
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = customerAndGroupAccountFormUI.Tbl_CustomerAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #region Drop Down list
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
    #endregion Drop Down list
    #region Bind And Search
    #region SearchCustomer
    private void SearchCustomerGroupList()
    {
        try
        {

            CustomerGroupListUI customerGroupListUI = new CustomerGroupListUI();
            customerGroupListUI.Search = txtCustomerGroupSearch.Text;

            DataTable dtb = customerGroupListBAL.GetCustomerGroupListBySearchParameters(customerGroupListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCustomerGroupSearch.DataSource = dtb;
                gvCustomerGroupSearch.DataBind();
                divCustomerGroupSearchError.Visible = false;
            }
            else
            {
                divCustomerGroupSearchError.Visible = true;
                lblCustomerGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCustomerGroupSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchCustomerGroupList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : SearchSupplierGroupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindCustomerGroupList()
    {
        try
        {
            DataTable dtb = customerGroupListBAL.GetCustomerGroupList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCustomerGroupSearch.DataSource = dtb;
                gvCustomerGroupSearch.DataBind();
                divCustomerGroupSearchError.Visible = false;
            }
            else
            {
                divCustomerGroupSearchError.Visible = true;
                lblCustomerGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCustomerGroupSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCustomerGroupList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SearchSupplierGroup : BindCustomerGroupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : SearchCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : BindCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
                divAccountReceivableSearchError.Visible = false;

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
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : SearchAccountPayableList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
                divAccountReceivableSearchError.Visible = false;
            }
            else
            {
                divAccountReceivableSearchError.Visible = true;
                lblAccountReceivableSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAccountReceivableSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindAccountReceivable()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : BindAccountReceivable] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
                    divSalesSearchError.Visible = false;
                }
                else
                {
                    divSalesSearchError.Visible = true;
                    lblSalesSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                    gvSalesSearch.Visible = false;
                }

            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "SearchSalesList()";
                logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
                logExcpUIobj.RecordId = "All";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : SearchSalesList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
                divSalesSearchError.Visible = false;
            }
            else
            {
                divSalesSearchError.Visible = true;
                lblSalesSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSalesSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindSalesList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : BindPurchaseList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion
    #region SearchCostOfSalest
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
                divCostOfSalesSearchError.Visible = false;
            }
            else
            {
                divCostOfSalesSearchError.Visible = true;
                lblCostOfSalesSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCostOfSalesSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchCostOfSalestList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : SearchCostOfSalestList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
                divCostOfSalesSearchError.Visible = false;
            }
            else
            {
                divCostOfSalesSearchError.Visible = true;
                lblCostOfSalesSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCostOfSalesSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCostOfSales()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : BindCostOfSales] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
                divInventorySearchError.Visible = false;
            }
            else
            {
                divInventorySearchError.Visible = true;
                lblInventorySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvInventorySearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchInventoryList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : SearchInventoryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
                divInventorySearchError.Visible = false;
            }
            else
            {
                divInventorySearchError.Visible = true;
                lblInventorySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvInventorySearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindInventoryList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : BindInventoryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
                divAccuralDifferedA_CSearchError.Visible = false;
            }
            else
            {
                divAccuralDifferedA_CSearchError.Visible = true;
                lblAccuralDifferedA_CSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAccuralDifferedA_CSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchAccuralDifferedA_CList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : SearchAccuralDifferedA_CList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
                divAccuralDifferedA_CSearchError.Visible = false;
            }
            else
            {
                divAccuralDifferedA_CSearchError.Visible = true;
                lblAccuralDifferedA_CSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAccuralDifferedA_CSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindAccuralDifferedA_CList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount : BindAccuralDifferedA_CList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion
    #endregion
    #endregion Method


}

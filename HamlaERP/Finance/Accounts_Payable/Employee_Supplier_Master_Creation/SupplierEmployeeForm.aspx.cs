using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    SupplierEmployeeFormBAL supplieremployeeFormBAL = new SupplierEmployeeFormBAL();
    SupplierEmployeeFormUI supplierEmployeeFormUI = new SupplierEmployeeFormUI();
    SupplierEmployeeGroupListBAL supplierEmployeeGroupListBAL = new SupplierEmployeeGroupListBAL();

    SupplierEmployeeAndGroupAccountListBAL supplierEmployeeAndGroupAccountListBAL = new SupplierEmployeeAndGroupAccountListBAL();

    CountryListBAL countryListBAL = new CountryListBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    GLAccountListUI gLAccountListUI = new GLAccountListUI();
    #endregion Data Members

    #region Events
    protected override void  Page_Load(object sender, EventArgs e)
    {
        SupplierEmployeeFormUI supplierEmployeeFormUI = new SupplierEmployeeFormUI();

        if (!Page.IsPostBack)
        {
            BindStatuDropDown();
            if (Request.QueryString["SupplierEmployeeId"] != null || Request.QueryString["recordId"] != null)
            {
                supplierEmployeeFormUI.Tbl_SupplierEmployeeId = (Request.QueryString["SupplierEmployeeId"] != null ? Request.QueryString["SupplierEmployeeId"] : Request.QueryString["recordId"]);

                FillForm(supplierEmployeeFormUI);
              
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Supplier Employee";
            }
            else
            {
                GetSerialNumber();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New  Supplier Employee";
            }
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SupplierEmployeeFormUI supplierEmployeeFormUI = new SupplierEmployeeFormUI();
        try
        {

            supplierEmployeeFormUI.CreatedBy = SessionContext.UserGuid;
            supplierEmployeeFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            supplierEmployeeFormUI.SupplierEmployeeCode = txtSupplierEmployeeCode.Text;
            supplierEmployeeFormUI.Name = txtName.Text;
            supplierEmployeeFormUI.ShortName = txtShortName.Text;
            supplierEmployeeFormUI.ChequeName = txtChequeName.Text;
            supplierEmployeeFormUI.Contact = txtContact.Text;
            supplierEmployeeFormUI.Address = txtAddress.Text;
            supplierEmployeeFormUI.City = txtCity.Text;
            supplierEmployeeFormUI.ZipCode = txtZipCode.Text;

            supplierEmployeeFormUI.Tbl_CountryId = txtCountryGuid.Text;
            supplierEmployeeFormUI.Phone = txtPhone.Text;
            supplierEmployeeFormUI.Mobile = txtMobile.Text;
            supplierEmployeeFormUI.FaxNo = txtFaxNo.Text;
            supplierEmployeeFormUI.Email = txtEmail.Text;
            supplierEmployeeFormUI.Comment1 = txtComment1.Text;
            supplierEmployeeFormUI.Comment2 = txtComment2.Text;
            supplierEmployeeFormUI.Opt_Status = int.Parse(ddlStatus.SelectedValue);
            supplierEmployeeFormUI.Tbl_SupplierEmployeeGroupId = txtSupplierEmployeeGroupGuid.Text;
            if (chkOnHold.Checked == true)
                supplierEmployeeFormUI.OnHold = true;
            else
                supplierEmployeeFormUI.OnHold = false;

            supplierEmployeeFormUI.Tbl_GLAccountId_Cash = txtGLAccountId_CashGuid.Text.Trim(); ;
            supplierEmployeeFormUI.Tbl_GLAccountId_AccountPayable = txtAccountPayableGuid.Text.Trim();
            supplierEmployeeFormUI.Tbl_GLAccountId_Purchase = txtPurchaseGuid.Text.Trim();
            supplierEmployeeFormUI.Tbl_GLAccountId_TradeDiscount = txtTradeDiscountGuid.Text.Trim();
            supplierEmployeeFormUI.Tbl_GLAccountId_Freight = txtFreightGuid.Text.Trim();
            supplierEmployeeFormUI.Tbl_GLAccountId_AccruedPurchase = txtAccruedPurchaseguid.Text.Trim();


            if (supplieremployeeFormBAL.AddSupplierEmployee(supplierEmployeeFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                divSuccess.Visible = false;
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SupplierEmployeeFormUI SupplierEmployeeFormUI = new SupplierEmployeeFormUI();
        try
        {
            SupplierEmployeeFormUI.ModifiedBy = SessionContext.UserGuid;
            SupplierEmployeeFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            SupplierEmployeeFormUI.Tbl_SupplierEmployeeId = Request.QueryString["SupplierEmployeeId"];

            SupplierEmployeeFormUI.SupplierEmployeeCode = txtSupplierEmployeeCode.Text;
            SupplierEmployeeFormUI.Name = txtName.Text;
            SupplierEmployeeFormUI.ShortName = txtShortName.Text;
            SupplierEmployeeFormUI.ChequeName = txtChequeName.Text;
            SupplierEmployeeFormUI.Contact = txtContact.Text;
            SupplierEmployeeFormUI.Address = txtAddress.Text;
            SupplierEmployeeFormUI.City = txtCity.Text;
            SupplierEmployeeFormUI.ZipCode = txtZipCode.Text;

            SupplierEmployeeFormUI.Tbl_CountryId = txtCountryGuid.Text;
            SupplierEmployeeFormUI.Phone = txtPhone.Text;
            SupplierEmployeeFormUI.Mobile = txtMobile.Text;
            SupplierEmployeeFormUI.FaxNo = txtFaxNo.Text;
            SupplierEmployeeFormUI.Email = txtEmail.Text;
            SupplierEmployeeFormUI.Comment1 = txtComment1.Text;
            SupplierEmployeeFormUI.Comment2 = txtComment2.Text;
            SupplierEmployeeFormUI.Opt_Status = Convert.ToInt32(ddlStatus.SelectedValue);
            supplierEmployeeFormUI.Tbl_SupplierEmployeeGroupId = txtSupplierEmployeeGroupGuid.Text;

            if (chkOnHold.Checked == true)
                SupplierEmployeeFormUI.OnHold = true;
            else
                SupplierEmployeeFormUI.OnHold = false;

            supplierEmployeeFormUI.Tbl_GLAccountId_Cash = txtGLAccountId_CashGuid.Text.Trim(); ;
            supplierEmployeeFormUI.Tbl_GLAccountId_AccountPayable = txtAccountPayableGuid.Text.Trim();
            supplierEmployeeFormUI.Tbl_GLAccountId_Purchase = txtPurchaseGuid.Text.Trim();
            supplierEmployeeFormUI.Tbl_GLAccountId_TradeDiscount = txtTradeDiscountGuid.Text.Trim();
            supplierEmployeeFormUI.Tbl_GLAccountId_Freight = txtFreightGuid.Text.Trim();
            supplierEmployeeFormUI.Tbl_GLAccountId_AccruedPurchase = txtAccruedPurchaseguid.Text.Trim();

            if (supplieremployeeFormBAL.UpdateSupplierEmployee(SupplierEmployeeFormUI) == 1)
            {
                divSuccess.Visible = true;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = SupplierEmployeeFormUI.Tbl_SupplierEmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : btnUpdate_Click] An error occured in the processing of Record Id : " + SupplierEmployeeFormUI.Tbl_SupplierEmployeeId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        SupplierEmployeeFormUI supplierEmployeeFormUI = new SupplierEmployeeFormUI();
        try
        {
            supplierEmployeeFormUI.Tbl_SupplierEmployeeId = Request.QueryString["SupplierEmployeeId"];

            if (supplieremployeeFormBAL.DeleteSupplierEmployee(supplierEmployeeFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = supplierEmployeeFormUI.Tbl_SupplierEmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : btnDelete_Click] An error occured in the processing of Record Id : " + supplierEmployeeFormUI.Tbl_SupplierEmployeeId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("SupplierEmployeeList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {

        string Form = "~/Finance/Accounts_Payable/Employee_Supplier_Master_Creation/SupplierEmployeeForm.aspx";
        string recordId = Request.QueryString["SupplierEmployeeId"];
        Response.Redirect("~/System_Settings/AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    #region Events Country Search

    protected void btnCountrySearch_Click(object sender, EventArgs e)
    {
        btnHtmlCountrySearch.Visible = false;
        btnHtmlCountryClose.Visible = true;
        SearchCountryList();
    }

    protected void btnClearCountrySearch_Click(object sender, EventArgs e)
    {
        BindCountryList();
        gvCountrySearch.Visible = true;
        btnHtmlCountrySearch.Visible = true;
        btnHtmlCountryClose.Visible = false;
        txtCountrySearch.Text = "";
        txtCountrySearch.Focus();
    }

    protected void btnCountryRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindCountryList();
    }

    #endregion Events Country Search

    #region SupplierEmployeeGroup Search
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
    #endregion SupplierEmployeeGroup Search

    #region SupplierEmployeeAndGroupAccount Search
    protected void btnSupplierEmployeeAndGroupAccountSearch_Click(object sender, EventArgs e)
    {
        btnHtmlSupplierEmployeeAndGroupAccountSearch.Visible = false;
        btnHtmlSupplierEmployeeAndGroupAccountClose.Visible = true;
        SearchSupplierEmployeeAndGroupAccountList();
    }
    protected void btnClearSupplierEmployeeAndGroupAccountSearch_Click(object sender, EventArgs e)
    {
        BindSupplierEmployeeAndGroupAccountList();
        gvSupplierEmployeeAndGroupAccountSearch.Visible = true;
        btnHtmlSupplierEmployeeAndGroupAccountSearch.Visible = true;
        btnHtmlSupplierEmployeeAndGroupAccountClose.Visible = false;
        txtSupplierEmployeeAndGroupAccountSearch.Text = "";
        txtSupplierEmployeeAndGroupAccountSearch.Focus();
    }
    protected void btnSupplierEmployeeAndGroupAccountRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindSupplierEmployeeAndGroupAccountList();
    }
    #endregion SupplierEmployeeAndGroupAccount Search

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
    #endregion Events

    #region Methods

    private void GetSerialNumber()
    {
        try
        {
            DataTable dtb = supplieremployeeFormBAL.GetSerialNumber();
            if (dtb.Rows.Count > 0)
            {
               txtSupplierEmployeeCode.Text = dtb.Rows[0][0].ToString();

            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotLoadData;
                divError.Visible = true;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetSerialNumber()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierForm : GetSerialNumber] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void FillForm(SupplierEmployeeFormUI supplierEmployeeFormUI)
    {
        try
        {
            DataTable dtb = supplieremployeeFormBAL.GetSupplierEmployeeListById(supplierEmployeeFormUI);

            if (dtb.Rows.Count > 0)
            {

                txtSupplierEmployeeGroupGuid.Text = dtb.Rows[0]["tbl_SupplierEmployeeGroupId"].ToString();
                txtSupplierEmployeeGroup.Text = dtb.Rows[0]["SupplierEmployeeGroupName"].ToString();
                txtSupplierEmployeeCode.Text = dtb.Rows[0]["SupplierEmployeeCode"].ToString();
                txtName.Text = dtb.Rows[0]["Name"].ToString();
                txtShortName.Text = dtb.Rows[0]["ShortName"].ToString();
                txtChequeName.Text = dtb.Rows[0]["ChequeName"].ToString();
                txtContact.Text = dtb.Rows[0]["Contact"].ToString();
                txtAddress.Text = dtb.Rows[0]["Address"].ToString();
                txtCity.Text = dtb.Rows[0]["City"].ToString();
                txtZipCode.Text = dtb.Rows[0]["ZipCode"].ToString();
                txtCountryGuid.Text = dtb.Rows[0]["tbl_CountryId"].ToString();
                txtCountry.Text = dtb.Rows[0]["CountryName"].ToString();
                txtPhone.Text = dtb.Rows[0]["Phone"].ToString();
                txtMobile.Text = dtb.Rows[0]["Mobile"].ToString();
                txtFaxNo.Text = dtb.Rows[0]["FaxNo"].ToString();
                txtEmail.Text = dtb.Rows[0]["Email"].ToString();
                txtComment1.Text = dtb.Rows[0]["Comment1"].ToString();
                txtComment2.Text = dtb.Rows[0]["Comment2"].ToString();
                ddlStatus.SelectedValue = dtb.Rows[0]["Status"].ToString();
               
                if (Convert.ToBoolean(dtb.Rows[0]["OnHold"]) == true)
                    chkOnHold.Checked = true;
                else
                    chkOnHold.Checked = false;
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = supplierEmployeeFormUI.Tbl_SupplierEmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : FillForm] An error occured in the processing of Record Id : " + supplierEmployeeFormUI.Tbl_SupplierEmployeeId + ". Details : [" + exp.ToString() + "]");
        }
    }

    private void BindStatuDropDown()
    {
        OptionSetListUI optionSetListUI = new OptionSetListUI();
        optionSetListUI.TableName = "tbl_SupplierEmployee";
        optionSetListUI.OptionSetName = "Opt_Status";
        try
        {

            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);

            if (dtb.Rows.Count > 0)
            {
                ddlStatus.DataSource = dtb;
                ddlStatus.DataBind();

                ddlStatus.DataTextField = "OptionSetLable";
                ddlStatus.DataValueField = "OptionSetValue";
                ddlStatus.DataBind();
            }
            else
            {
                ddlStatus.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindStatuDropDown()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "OptionSet Name " + optionSetListUI.OptionSetName;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : BindStatuDropDown] An error occured in the processing of Record OptionSet Name " + optionSetListUI.OptionSetName + ".  Details : [" + exp.ToString() + "]");
        }
    }

    #region Methods Country Search
    public void BindCountryList()
    {
        try
        {
            DataTable dtb = countryListBAL.GetCountryList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCountrySearch.DataSource = dtb;
                gvCountrySearch.DataBind();
                divCountrySearchError.Visible = false;
            }
            else
            {
                divCountrySearchError.Visible = true;
                lblCountrySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCountrySearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCountryList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : BindCountryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void SearchCountryList()
    {
        try
        {
            CountryListUI countryListUI = new CountryListUI();
            countryListUI.Search = txtCountrySearch.Text;

            DataTable dtb = countryListBAL.GetCountryListBySearchParameters(countryListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCountrySearch.DataSource = dtb;
                gvCountrySearch.DataBind();
                divCountrySearchError.Visible = false;
            }
            else
            {
                divCountrySearchError.Visible = true;
                lblCountrySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCountrySearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchCountryList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : SearchCountryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods Country Search


    #region  SearchSupplierEmployeeGroup
    #region SupplierEmployeeGroup Search
    private void SearchSupplierEmployeeGroupList()
    {
        try
        {
            SupplierEmployeeGroupListUI supplierEmployeeGroupListUI = new SupplierEmployeeGroupListUI();
            supplierEmployeeGroupListUI.Search = txtSupplierEmployeeGroupSearch.Text;
            DataTable dtb = supplierEmployeeGroupListBAL.GetSupplierEmployeeGroupListBySearchParameters(supplierEmployeeGroupListUI);
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
            logExcpUIobj.MethodName = "SearchSupplierEmployeeGroupList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : SearchSupplierEmployeeGroupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSupplierEmployeeGroupSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindSupplierEmployeeGroupList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : BindSupplierEmployeeGroupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Supplier Serach
    #endregion

    #region  SearchSupplierEmployeeAndGroupAccount

    private void SearchSupplierEmployeeAndGroupAccountList()
    {
        try
        {
            SupplierEmployeeAndGroupAccountListUI supplierEmployeeAndGroupAccountListUI = new SupplierEmployeeAndGroupAccountListUI();
            supplierEmployeeAndGroupAccountListUI.Search = txtSupplierEmployeeAndGroupAccountSearch.Text;
            DataTable dtb = supplierEmployeeAndGroupAccountListBAL.GetSupplierEmployeeAndGroupAccountListBySearchParameters(supplierEmployeeAndGroupAccountListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSupplierEmployeeAndGroupAccountSearch.DataSource = dtb;
                gvSupplierEmployeeAndGroupAccountSearch.DataBind();
                divSupplierEmployeeAndGroupAccountSearchError.Visible = false;
            }
            else
            {
                divSupplierEmployeeAndGroupAccountSearchError.Visible = true;
                lblSupplierEmployeeAndGroupAccountSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSupplierEmployeeAndGroupAccountSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchSupplierEmployeeAndGroupAccountList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : SearchSupplierEmployeeAndGroupAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindSupplierEmployeeAndGroupAccountList()
    {
        try
        {
            DataTable dtb = supplierEmployeeAndGroupAccountListBAL.GetSupplierEmployeeAndGroupAccountList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSupplierEmployeeAndGroupAccountSearch.DataSource = dtb;
                gvSupplierEmployeeAndGroupAccountSearch.DataBind();
                divSupplierEmployeeAndGroupAccountSearchError.Visible = false;
            }
            else
            {
                divSupplierEmployeeAndGroupAccountSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSupplierEmployeeAndGroupAccountSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindSupplierEmployeeAndGroupAccountList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm : BindSupplierEmployeeAndGroupAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  SupplierEmployeeAndGroupAccount Search
   

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

    #region SearchPurchase
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
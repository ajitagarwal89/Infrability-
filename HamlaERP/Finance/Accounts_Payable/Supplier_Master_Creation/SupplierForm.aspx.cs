using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Accounts_Payable_Supplier_Master_Creation_SupplierForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    SupplierFormBAL supplierFormBAL = new SupplierFormBAL();

    CountryListBAL countryListBAL = new CountryListBAL();

    SupplierGroupListBAL supplierGroupListBAL = new SupplierGroupListBAL();

    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    GLAccountListUI gLAccountListUI = new GLAccountListUI();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        SupplierFormUI supplierFormUI = new SupplierFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["SupplierId"] != null || Request.QueryString["recordId"] != null)
            {
                supplierFormUI.Tbl_SupplierId = (Request.QueryString["SupplierId"] != null ? Request.QueryString["SupplierId"] : Request.QueryString["recordId"]);


                BindStatuDropDown();
                FillForm(supplierFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnAuditHistory.Visible = true;
                lblHeading.Text = "Update Supplier";
            }
            else
            {

                BindStatuDropDown();
                GetSerialNumber();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;    
                lblHeading.Text = "Add New Supplier";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SupplierFormUI supplierFormUI = new SupplierFormUI();
        try
        {

            supplierFormUI.CreatedBy = SessionContext.UserGuid;
            supplierFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            supplierFormUI.SupplierCode = txtSupplierCode.Text;
            supplierFormUI.Name = txtName.Text;
            supplierFormUI.ShortName = txtShortName.Text;
            supplierFormUI.ChequeName = txtChequeName.Text;
            supplierFormUI.Contact = txtContact.Text;
            supplierFormUI.Address = txtAddress.Text;
            supplierFormUI.City = txtCity.Text;
            supplierFormUI.ZipCode = txtZipCode.Text;

            supplierFormUI.Tbl_CountryId = txtCountryGuid.Text;
            supplierFormUI.Phone = txtPhone.Text;
            supplierFormUI.Mobile = txtMobile.Text;
            supplierFormUI.FaxNo = txtFaxNo.Text;
            supplierFormUI.Email = txtEmail.Text;
            supplierFormUI.Comment1 = txtComment1.Text;
            supplierFormUI.Comment2 = txtComment2.Text;
            supplierFormUI.Opt_Status = Convert.ToInt32(ddlStatus.SelectedValue);
            supplierFormUI.Tbl_SupplierGroupId = txtSupplierGroupGuid.Text;

            if (chkOnHold.Checked == true)
                supplierFormUI.OnHold = true;
            else
                supplierFormUI.OnHold = false;
            supplierFormUI.Tbl_GLAccountId_Cash = txtGLAccountId_CashGuid.Text.Trim(); ;
            supplierFormUI.Tbl_GLAccountId_AccountPayable = txtAccountPayableGuid.Text.Trim();
            supplierFormUI.Tbl_GLAccountId_Purchase = txtPurchaseGuid.Text.Trim();
            supplierFormUI.Tbl_GLAccountId_TradeDiscount = txtTradeDiscountGuid.Text.Trim();
            supplierFormUI.Tbl_GLAccountId_Freight = txtFreightGuid.Text.Trim();
            supplierFormUI.Tbl_GLAccountId_AccruedPurchase = txtAccruedPurchaseguid.Text.Trim();

            if (supplierFormBAL.AddSupplier(supplierFormUI) == 1)
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
        SupplierFormUI supplierFormUI = new SupplierFormUI();
        try
        {
            supplierFormUI.ModifiedBy = SessionContext.UserGuid;
            supplierFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            supplierFormUI.Tbl_SupplierId = Request.QueryString["SupplierId"];

            supplierFormUI.SupplierCode = txtSupplierCode.Text;
            supplierFormUI.Name = txtName.Text;
            supplierFormUI.ShortName = txtShortName.Text;
            supplierFormUI.ChequeName = txtChequeName.Text;
            supplierFormUI.Contact = txtContact.Text;
            supplierFormUI.Address = txtAddress.Text;
            supplierFormUI.City = txtCity.Text;
            supplierFormUI.ZipCode = txtZipCode.Text;

            supplierFormUI.Tbl_CountryId = txtCountryGuid.Text;
            supplierFormUI.Phone = txtPhone.Text;
            supplierFormUI.Mobile = txtMobile.Text;
            supplierFormUI.FaxNo = txtFaxNo.Text;
            supplierFormUI.Email = txtEmail.Text;
            supplierFormUI.Comment1 = txtComment1.Text;
            supplierFormUI.Comment2 = txtComment2.Text;
            supplierFormUI.Opt_Status = Convert.ToInt32(ddlStatus.SelectedValue);
            supplierFormUI.Tbl_SupplierGroupId = txtSupplierGroupGuid.Text;

            if (chkOnHold.Checked == true)
                supplierFormUI.OnHold = true;
            else
                supplierFormUI.OnHold = false;
            supplierFormUI.Tbl_GLAccountId_Cash = txtGLAccountId_CashGuid.Text.Trim(); ;
            supplierFormUI.Tbl_GLAccountId_AccountPayable = txtAccountPayableGuid.Text.Trim();
            supplierFormUI.Tbl_GLAccountId_Purchase = txtPurchaseGuid.Text.Trim();
            supplierFormUI.Tbl_GLAccountId_TradeDiscount = txtTradeDiscountGuid.Text.Trim();
            supplierFormUI.Tbl_GLAccountId_Freight = txtFreightGuid.Text.Trim();
            supplierFormUI.Tbl_GLAccountId_AccruedPurchase = txtAccruedPurchaseguid.Text.Trim();


            if (supplierFormBAL.UpdateSupplier(supplierFormUI) == 1)
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
            logExcpUIobj.RecordId = supplierFormUI.Tbl_SupplierId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : btnUpdate_Click] An error occured in the processing of Record Id : " + supplierFormUI.Tbl_SupplierId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        SupplierFormUI supplierFormUI = new SupplierFormUI();
        try
        {
            supplierFormUI.Tbl_SupplierId = Request.QueryString["SupplierId"];

            if (supplierFormBAL.DeleteSupplier(supplierFormUI) == 1)
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
            logExcpUIobj.RecordId = supplierFormUI.Tbl_SupplierId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : btnDelete_Click] An error occured in the processing of Record Id : " + supplierFormUI.Tbl_SupplierId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("SupplierList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Finance/Accounts_Payable/Supplier_Master_Creation/SupplierForm.aspx";
        string recordId = Request.QueryString["SupplierId"];
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

    #region Events Supplier Group Search

    protected void btnSupplierGroupSearch_Click(object sender, EventArgs e)
    {
        btnHtmlSupplierGroupSearch.Visible = false;
        btnHtmlSupplierGroupClose.Visible = true;
        SearchSupplierGroupList();
    }

    protected void btnClearSupplierGroupSearch_Click(object sender, EventArgs e)
    {
        BindSupplierGroupList();
        gvSupplierGroupSearch.Visible = true;
        btnHtmlSupplierGroupSearch.Visible = true;
        btnHtmlSupplierGroupClose.Visible = false;
        txtSupplierGroupSearch.Text = "";
        txtSupplierGroupSearch.Focus();
    }

    protected void btnSupplierGroupRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindSupplierGroupList();
    }

    #endregion Events Supplier Group Search

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

    # region AccountPayableSearch
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

    #region  TradeDiscountSearch
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
    #endregion

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

    #region AccruedPurchaseSearch
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
            DataTable dtb = supplierFormBAL.GetSerialNumber();
            if (dtb.Rows.Count > 0)
            {
                txtSupplierCode.Text = dtb.Rows[0][0].ToString();

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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_SupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_Supplier_Master_Creation_SupplierForm : GetSerialNumber] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }


    private void FillForm(SupplierFormUI supplierFormUI)
    {
        try
        {
            DataTable dtb = supplierFormBAL.GetSupplierListById(supplierFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtSupplierCode.Text = dtb.Rows[0]["SupplierCode"].ToString();
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
                ddlStatus.SelectedValue = dtb.Rows[0]["Opt_Status"].ToString();
                txtSupplierGroupGuid.Text = dtb.Rows[0]["tbl_SupplierGroupId"].ToString();
                txtSupplierGroup.Text = dtb.Rows[0]["tbl_SupplierGroup"].ToString();

                if (Convert.ToBoolean(dtb.Rows[0]["OnHold"]) == true)
                    chkOnHold.Checked = true;
                else
                    chkOnHold.Checked = false;
                txtGLAccountId_CashGuid.Text = dtb.Rows[0]["tbl_GLAccountId_Cash"].ToString();
                txtGLAccountId_Cash.Text = dtb.Rows[0]["Cash"].ToString();
                txtAccountPayableGuid.Text = dtb.Rows[0]["tbl_GLAccountId_AccountPayable"].ToString();
                txtAccountPayable.Text = dtb.Rows[0]["AccountPayable"].ToString();
                txtPurchase.Text = dtb.Rows[0]["Purchase"].ToString();
                txtPurchaseGuid.Text = dtb.Rows[0]["tbl_GLAccountId_Purchase"].ToString();
                txtTradeDiscount.Text = dtb.Rows[0]["TradeDiscount"].ToString();
                txtTradeDiscountGuid.Text = dtb.Rows[0]["tbl_GLAccountId_TradeDiscount"].ToString();
                txtFreight.Text = dtb.Rows[0]["Freight"].ToString();
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Supplier_Master_Creation_SupplierForm.CS";
            logExcpUIobj.RecordId = supplierFormUI.Tbl_SupplierGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_Supplier_Master_Creation_SupplierForm : FillForm] An error occured in the processing of Record Id : " + supplierFormUI.Tbl_SupplierGroupId + ". Details : [" + exp.ToString() + "]");
        }
    }


    private void BindStatuDropDown()
    {
        OptionSetListUI optionSetListUI = new OptionSetListUI();
        optionSetListUI.TableName = "tbl_Supplier";
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Supplier_Master_Creation_SupplierForm.CS";
            logExcpUIobj.RecordId = "OptionSet Name " + optionSetListUI.OptionSetName;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_Supplier_Master_Creation_SupplierForm : BindStatuDropDown] An error occured in the processing of Record OptionSet Name " + optionSetListUI.OptionSetName + ".  Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Supplier_Master_Creation_SupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_Supplier_Master_Creation_SupplierForm : BindCountryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Supplier_Master_Creation_SupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_Supplier_Master_Creation_SupplierForm : SearchCountryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods Country Search


    #region Methods Supplier Group Search

    public void BindSupplierGroupList()
    {
        try
        {
            DataTable dtb = supplierGroupListBAL.GetSupplierGroupList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSupplierGroupSearch.DataSource = dtb;
                gvSupplierGroupSearch.DataBind();
                divSupplierGroupSearchError.Visible = false;
            }
            else
            {
                divSupplierGroupSearchError.Visible = true;
                lblSupplierGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSupplierGroupSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindSupplierGroupList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Supplier_Master_Creation_SupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_Supplier_Master_Creation_SupplierForm : BindSupplierGroupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void SearchSupplierGroupList()
    {
        try
        {
            SupplierGroupListUI supplierGroupListUI = new SupplierGroupListUI();
            supplierGroupListUI.Search = txtCountrySearch.Text;

            DataTable dtb = supplierGroupListBAL.GetSupplierGroupListBySearchParameters(supplierGroupListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSupplierGroupSearch.DataSource = dtb;
                gvSupplierGroupSearch.DataBind();
                divSupplierGroupSearchError.Visible = false;
            }
            else
            {
                divSupplierGroupSearchError.Visible = true;
                lblSupplierGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSupplierGroupSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SupplierGroup()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Supplier_Master_Creation_SupplierForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_Supplier_Master_Creation_SupplierForm : SupplierGroup] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    #endregion Methods Supplier Group Search

    #region  SearchCash
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
                divSupplierGroupSearchError.Visible = true;
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
                divSupplierGroupSearchError.Visible = true;
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

    #region  SearchAccountPayable
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
                divSupplierGroupSearchError.Visible = true;
                lblSupplierGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
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

    #region  SearchPurchase
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

    #region TradeDiscount
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

    #region SearchFreight
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

    #region AccruedPurchase
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
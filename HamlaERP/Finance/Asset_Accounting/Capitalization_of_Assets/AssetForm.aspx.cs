using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Assets_Asset_AssetForm : PageBase
{

    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();  
    EmployeeListBAL employeeListBAL = new EmployeeListBAL();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    LocationListBAL locationListBAL = new LocationListBAL();
    LocationListUI locatrionListUI = new LocationListUI();
    PhysicalLocationListBAL physicalLocationListBAL = new PhysicalLocationListBAL();
    AssetAndGroupAccountListBAL assetAndGroupAccountListBAL = new AssetAndGroupAccountListBAL();
    AssetGroupListBAL assetGroupListBAL = new AssetGroupListBAL();
    AssetGroupListUI assetGroupListUI = new AssetGroupListUI();
    AssetFormBAL assetFormBAL = new AssetFormBAL();
    AssetFormUI assetFormUI = new AssetFormUI();
    StructureListBAL structureListBAL = new StructureListBAL();
    StructureListUI structureListUI = new StructureListUI();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    GLAccountListUI gLAccountListUI = new GLAccountListUI();

      int invoiceTypeInvoice    = 1;
	  int invoiceTypeReturn     = 2;
	  int invoiceTypeCreditMemo = 3;
      int invoiceTypePayment    = 4;

    #endregion end Data member

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        AssetFormUI assetFormUI = new AssetFormUI();
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["AssetId"] != null || Request.QueryString["recordId"] != null)
            {
                assetFormUI.Tbl_AssetId = (Request.QueryString["AssetId"] != null ? Request.QueryString["AssetId"] : Request.QueryString["recordId"]);


                {
                    Bindopt_StatusDropDownList();
                    Bind_opt_TypeDropDownList();
                    assetFormUI.Tbl_AssetId = Request.QueryString["AssetId"];
                    FillForm(assetFormUI);
                    btnSave.Visible = false;
                    btnClear.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnAuditHistory.Visible = true;
                    lblHeading.Text = "Update Asset";
                }
            }
            else
            {
                Bindopt_StatusDropDownList();
                Bind_opt_TypeDropDownList();
                assetFormUI.InvoiceType = invoiceTypeInvoice;
                GetSerialNumber(assetFormUI);
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;

                lblHeading.Text = "Add New Asset";
            }

        }
    }
    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Finance/Asset_Accounting/Capitalization_of_Assets/AssetForm.aspx";
        string recordId = Request.QueryString["AssetId"];
        Response.Redirect("~/System_Settings/AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }


    public void btnSave_Click(object sender, EventArgs e)
    {
        
        try
        {
            assetFormUI.CreatedBy = SessionContext.UserGuid;
            assetFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            assetFormUI.AssetCode = txtAssetCode.Text;
            assetFormUI.Description = txtDescription.Text;
            assetFormUI.ExtendedDescription = txtExtendedDescription.Text;
            assetFormUI.ShortName = txtShortName.Text;
            assetFormUI.Tbl_AssetGroupId = txtAssetGroupGuid.Text;
            assetFormUI.opt_Type = int.Parse(ddlopt_Status.SelectedValue.ToString());
            assetFormUI.Tbl_AssetAndGroupAccountId = txtAssetAndGroupAccountGuid.Text;
            assetFormUI.AcquisitionDate= DateTime.Parse(txtAcquisitionDate.Text.ToString());
            assetFormUI.AcquisitionCost = Convert.ToDecimal(txtAcquisitionCost.Text);
            assetFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            assetFormUI.Tbl_LocationId = txtLocationGuid.Text;
            assetFormUI.Tbl_PhysicalLocationId = txtPhysicalLocationGuid.Text;
            assetFormUI.AssetBarcode = txtAssetBarcode.Text;
            assetFormUI.Tbl_StructureId = txtStructureGuid.Text;
            assetFormUI.Tbl_EmployeeId = txtEmployeeGuid.Text;
            assetFormUI.ManufacturerName = txtManufacturerName.Text;
            assetFormUI.Quantity = Convert.ToDecimal(txtQuantity.Text);
            assetFormUI.LastMaintenanceDate = DateTime.Parse(txtLastMaintenanceDate.Text);
            assetFormUI.DateAdded = DateTime.Parse(txtDateAdded.Text);
            assetFormUI.opt_Status= int.Parse(ddlopt_Status.SelectedValue.ToString());
            assetFormUI.SerialNumber = txtSerialNumber.Text;
            assetFormUI.ModalNumber = txtModalNumber.Text;
            assetFormUI.WarrantyDate = DateTime.Parse(txtWarrantyDate.Text);
            assetFormUI.Tbl_GLAccount_DepreciationExpense = txtDepreciationExpenseGuid.Text;
            assetFormUI.Tbl_GLAccount_AccumulatedDepreciation = txtAccumulatedDepreciationGuid.Text;
            assetFormUI.Tbl_GLAccount_PriorYearDepreciation = txtPriorYearDepreciationGuid.Text;
            assetFormUI.Tbl_GLAccount_AssetCost = txtAssetCostGuid.Text;
            assetFormUI.Tbl_GLAccount_Clearing = txtClearingGuid.Text;
            if (assetFormBAL.AddAsset(assetFormUI) == 1)
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
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_Asset_AssetForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
        assetFormUI.ModifiedBy = SessionContext.UserGuid;
        assetFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
        assetFormUI.Tbl_AssetId = Request.QueryString["AssetId"];
        assetFormUI.AssetCode = txtAssetCode.Text;
        assetFormUI.Description = txtDescription.Text;
        assetFormUI.ExtendedDescription = txtExtendedDescription.Text;
        assetFormUI.ShortName = txtShortName.Text;
        assetFormUI.Tbl_AssetGroupId = txtAssetGroupGuid.Text;
        assetFormUI.opt_Type = int.Parse(ddlopt_Status.SelectedValue.ToString());
        assetFormUI.Tbl_AssetAndGroupAccountId = txtAssetAndGroupAccountGuid.Text;
        assetFormUI.AcquisitionDate = DateTime.Parse(txtAcquisitionDate.Text.ToString());
        assetFormUI.AcquisitionCost = Convert.ToDecimal(txtAcquisitionCost.Text);
        assetFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
        assetFormUI.Tbl_LocationId = txtLocationGuid.Text;
        assetFormUI.Tbl_PhysicalLocationId = txtPhysicalLocationGuid.Text;
        assetFormUI.AssetBarcode = txtAssetBarcode.Text;
        assetFormUI.Tbl_StructureId = txtStructureGuid.Text;
        assetFormUI.Tbl_EmployeeId = txtEmployeeGuid.Text;
        assetFormUI.ManufacturerName = txtManufacturerName.Text;
        assetFormUI.Quantity = Convert.ToDecimal(txtQuantity.Text);
        assetFormUI.LastMaintenanceDate = DateTime.Parse(txtLastMaintenanceDate.Text);
        assetFormUI.DateAdded = DateTime.Parse(txtDateAdded.Text);
        assetFormUI.opt_Status = int.Parse(ddlopt_Status.SelectedValue.ToString());
        assetFormUI.SerialNumber = txtSerialNumber.Text;
        assetFormUI.ModalNumber = txtModalNumber.Text;
        assetFormUI.WarrantyDate = DateTime.Parse(txtWarrantyDate.Text);
        assetFormUI.Tbl_GLAccount_DepreciationExpense = txtDepreciationExpenseGuid.Text;
        assetFormUI.Tbl_GLAccount_AccumulatedDepreciation = txtAccumulatedDepreciationGuid.Text;
        assetFormUI.Tbl_GLAccount_PriorYearDepreciation = txtPriorYearDepreciationGuid.Text;
        assetFormUI.Tbl_GLAccount_AssetCost = txtAssetCostGuid.Text;
        assetFormUI.Tbl_GLAccount_Clearing = txtClearingGuid.Text;
        assetFormUI.Tbl_GLAccount_DepreciationExpense = txtDepreciationExpenseGuid.Text;
        assetFormUI.Tbl_GLAccount_AccumulatedDepreciation = txtAccumulatedDepreciationGuid.Text;
        assetFormUI.Tbl_GLAccount_PriorYearDepreciation = txtPriorYearDepreciationGuid.Text;
        assetFormUI.Tbl_GLAccount_AssetCost = txtAssetCostGuid.Text;
        assetFormUI.Tbl_GLAccount_Clearing = txtClearingGuid.Text;


            if (assetFormBAL.UpdateAsset(assetFormUI) == 1)
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
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_Asset_AssetForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            assetFormUI.Tbl_AssetId = Request.QueryString["AssetId"];
            if (assetFormBAL.DeleteAsset(assetFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = assetFormUI.Tbl_AssetId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_Asset_AssetForm : btnDelete_Click] An error occured in the processing of Record Id : " + assetFormUI.Tbl_AssetId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetList.aspx");
    }



    #region Employee Search
    protected void btnEmployeeSearch_Click(object sender, EventArgs e)
    {
        btnHtmlEmployeeSearch.Visible = false;
        btnHtmlEmployeeClose.Visible = true;
        SearchEmployeeList();
    }
    protected void btnClearEmployeeSearch_Click(object sender, EventArgs e)
    {
        BindEmployeeList();
        gvEmployeeSearch.Visible = true;
        btnHtmlEmployeeSearch.Visible = true;
        btnHtmlEmployeeClose.Visible = false;
        txtEmployeeSearch.Text = "";
        txtEmployeeSearch.Focus();
    }
    protected void btnEmployeeRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindEmployeeList();
    }
    #endregion Employee Search

    #region AssetGroup Search
    protected void btnAssetGroupSearch_Click(object sender, EventArgs e)
    {
        btnHtmlAssetGroupSearch.Visible = false;
        btnHtmlAssetGroupClose.Visible = true;
        SearchAssetGroupList();
    }
    protected void btnClearAssetGroupSearch_Click(object sender, EventArgs e)
    {
        BindAssetGroupList();
        gvAssetGroupSearch.Visible = true;
        btnHtmlAssetGroupSearch.Visible = true;
        btnHtmlAssetGroupClose.Visible = false;
        txtAssetGroupSearch.Text = "";
        txtAssetGroupSearch.Focus();
    }
    protected void btnAssetGroupRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindAssetGroupList();
    }
    #endregion AssetGroup Search

    #region AssetAndGroupAccount Search
    protected void btnAssetAndGroupAccountSearch_Click(object sender, EventArgs e)
    {
        btnHtmlAssetAndGroupAccountSearch.Visible = false;
        btnHtmlAssetAndGroupAccountClose.Visible = true;
        SearchAssetAndGroupAccountList();
    }
    protected void btnClearAssetAndGroupAccountSearch_Click(object sender, EventArgs e)
    {
        BindAssetAndGroupAccountList();
        gvAssetAndGroupAccountSearch.Visible = true;
        btnHtmlAssetAndGroupAccountSearch.Visible = true;
        btnHtmlAssetAndGroupAccountClose.Visible = false;
        txtAssetAndGroupAccountSearch.Text = "";
        txtAssetAndGroupAccountSearch.Focus();
    }
    protected void btnAssetAndGroupAccountRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindAssetAndGroupAccountList();
    }
    #endregion AssetGroup Search

    #region Location Search
    protected void btnLocationSearch_Click(object sender, EventArgs e)
    {
        btnHtmlLocationSearch.Visible = false;
        btnHtmlLocationClose.Visible = true;
        SearchLocationList();
    }
    protected void btnClearLocationSearch_Click(object sender, EventArgs e)
    {
        BindLocationList();
        gvLocationSearch.Visible = true;
        btnHtmlLocationSearch.Visible = true;
        btnHtmlLocationClose.Visible = false;
        txtLocationSearch.Text = "";
        txtLocationSearch.Focus();
    }
    protected void btnLocationRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindLocationList();
    }
    #endregion Location Search

    #region Physical Location Search
    protected void btnPhysicalLocationSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPhysicalLocationSearch.Visible = false;
        btnHtmlPhysicalLocationClose.Visible = true;
        SearchPhysicalLocationList();
    }
    protected void btnClearPhysicalLocationSearch_Click(object sender, EventArgs e)
    {
        BindPhysicalLocationList();
        gvPhysicalLocationSearch.Visible = true;
        btnHtmlPhysicalLocationSearch.Visible = true;
        btnHtmlPhysicalLocationClose.Visible = false;
        txtPhysicalLocationSearch.Text = "";
        txtPhysicalLocationSearch.Focus();
    }
    protected void btnPhysicalLocationRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPhysicalLocationList();
    }
    #endregion Location Search

    #region Currency Search
    protected void btnCurrencySearch_Click(object sender, EventArgs e)
    {
        btnHtmlCurrencySearch.Visible = false;
        btnHtmlCurrencyClose.Visible = true;
        SearchCurrencyList();
    }
    protected void btnClearCurrencySearch_Click(object sender, EventArgs e)
    {
        BindCurrencyList();
        gvCurrencySearch.Visible = true;
        btnHtmlCurrencySearch.Visible = true;
        btnHtmlCurrencyClose.Visible = false;
        txtCurrencySearch.Text = "";
        txtCurrencySearch.Focus();
    }
    protected void btnCurrencyRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindCurrencyList();
    }
    #endregion Currency Search

    #region Structure Search
    protected void btnStructureSearch_Click(object sender, EventArgs e)
    {
        btnHtmlStructureSearch.Visible = false;
        btnHtmlStructureClose.Visible = true;
        SearchStructureList();
    }
    protected void btnClearStructureSearch_Click(object sender, EventArgs e)
    {
        BindStructureList();
        gvStructureSearch.Visible = true;
        btnHtmlStructureSearch.Visible = true;
        btnHtmlStructureClose.Visible = false;
        txtStructureSearch.Text = "";
        txtStructureSearch.Focus();
    }
    protected void btnStructureRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindStructureList();
    }
    #endregion Structure Search

    #region  DepreciationExpense
    protected void btnDepreciationExpenseSearch_Click(object sender, EventArgs e)
    {
        btnHtmlDepreciationExpenseSearch.Visible = false;
        btnHtmlDepreciationExpenseClose.Visible = true;
        SearchDepreciationExpenseList();
    }
    protected void btnClearDepreciationExpenseSearch_Click(object sender, EventArgs e)
    {
        BindDepreciationExpenseList();
        gvDepreciationExpenseSearch.Visible = true;
        btnHtmlDepreciationExpenseSearch.Visible = true;
        btnHtmlDepreciationExpenseClose.Visible = false;
        txtDepreciationExpenseSearch.Text = "";
        txtDepreciationExpenseSearch.Focus();

    }
    protected void btnDepreciationExpenseRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindDepreciationExpenseList();
    }
    #endregion

    #region  AccumulatedDepreciationSearch
    protected void btnAccumulatedDepreciationSearch_Click(object sender, EventArgs e)
    {
        btnHtmlAccumulatedDepreciationSearch.Visible = false;
        btnHtmlAccumulatedDepreciationClose.Visible = true;
        SearchAccumulatedDepreciationList();
    }
    protected void btnClearAccumulatedDepreciationSearch_Click(object sender, EventArgs e)
    {
        BindAccumulatedDepreciationList();
        gvAccumulatedDepreciationSearch.Visible = true;
        btnHtmlAccumulatedDepreciationSearch.Visible = true;
        btnHtmlAccumulatedDepreciationClose.Visible = false;
        txtAccumulatedDepreciationSearch.Text = "";
        txtAccumulatedDepreciationSearch.Focus();

    }
    protected void btnAccumulatedDepreciationRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindAccumulatedDepreciationList();
    }
    #endregion

    #region PriorYearDepreciation Search
    protected void btnPriorYearDepreciationSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPriorYearDepreciationSearch.Visible = false;
        btnHtmlPriorYearDepreciationClose.Visible = true;
        SearchPriorYearDepreciationList();
    }
    protected void btnClearPriorYearDepreciationSearch_Click(object sender, EventArgs e)
    {
        BindPriorYearDepreciationList();
        gvPriorYearDepreciationSearch.Visible = true;
        btnHtmlPriorYearDepreciationSearch.Visible = true;
        btnHtmlPriorYearDepreciationClose.Visible = false;
        txtPriorYearDepreciationSearch.Text = "";
        txtPriorYearDepreciationSearch.Focus();

    }
    protected void btnPriorYearDepreciationRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPriorYearDepreciationList();
    }
    #endregion

    #region AssetCostSearch
    protected void btnAssetCostSearch_Click(object sender, EventArgs e)
    {
        btnHtmlAssetCostSearch.Visible = false;
        btnHtmlAssetCostClose.Visible = true;
        SearchAssetCostList();
    }
    protected void btnClearAssetCostSearch_Click(object sender, EventArgs e)
    {
        BindAssetCostList();
        gvAssetCostSearch.Visible = true;
        btnHtmlAssetCostSearch.Visible = true;
        btnHtmlAssetCostClose.Visible = false;
        txtAssetCostSearch.Text = "";
        txtAssetCostSearch.Focus();

    }
    protected void btnAssetCostRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindAssetCostList();
    }
    #endregion

    #region  Clearing Search
    protected void btnClearingSearch_Click(object sender, EventArgs e)
    {
        btnHtmlClearingSearch.Visible = false;
        btnHtmlClearingClose.Visible = true;
        SearchClearingList();
    }
    protected void btnClearClearingSearch_Click(object sender, EventArgs e)
    {
        BindClearingList();
        gvClearingSearch.Visible = true;
        btnHtmlClearingSearch.Visible = true;
        btnHtmlClearingClose.Visible = false;
        txtClearingSearch.Text = "";
        txtClearingSearch.Focus();

    }
    protected void btnClearingRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindClearingList();
    }
    #endregion
    #endregion

    #region Method

    private void FillForm(AssetFormUI assetFormUI)
    {
        try { 
        DataTable dtb = assetFormBAL.GetAssetListById(assetFormUI);
        if (dtb.Rows.Count > 0)
        {
            txtAssetCode.Text = dtb.Rows[0]["AssetCode"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                txtExtendedDescription.Text= dtb.Rows[0]["ExtendedDescription"].ToString();
                txtShortName.Text = dtb.Rows[0]["ShortName"].ToString();
                txtAssetGroup.Text = dtb.Rows[0]["tbl_AssetGroup"].ToString();
                txtAssetGroupGuid.Text = dtb.Rows[0]["tbl_AssetGroupId"].ToString();
                ddlopt_Status.SelectedValue = dtb.Rows[0]["Type"].ToString();
                txtAssetAndGroupAccount.Text = dtb.Rows[0]["tbl_AssetAndGroupAccount"].ToString();
                txtAssetAndGroupAccountGuid.Text = dtb.Rows[0]["tbl_AssetAndGroupAccountId"].ToString();
                txtStructureGuid.Text= dtb.Rows[0]["tbl_StructureId"].ToString();
                txtStructure.Text = dtb.Rows[0]["tbl_Structure"].ToString();
                txtAcquisitionDate.Text = dtb.Rows[0]["AcquisitionDate"].ToString();
                txtAcquisitionCost.Text = dtb.Rows[0]["AcquisitionCost"].ToString();
                txtCurrency.Text = dtb.Rows[0]["CurrencyName"].ToString();
                txtCurrencyGuid.Text = dtb.Rows[0]["tbl_CurrencyId"].ToString();
                txtLocation.Text = dtb.Rows[0]["tbl_Location"].ToString();
                txtLocationGuid.Text = dtb.Rows[0]["tbl_LocationId"].ToString();
                txtPhysicalLocation.Text = dtb.Rows[0]["tbl_PhysicalLocation"].ToString();
                txtPhysicalLocationGuid.Text = dtb.Rows[0]["tbl_PhysicalLocationId"].ToString();
                txtAssetBarcode.Text = dtb.Rows[0]["AssetBarcode"].ToString();
                txtEmployee.Text = dtb.Rows[0]["tbl_Employee"].ToString();
                txtEmployeeGuid.Text = dtb.Rows[0]["tbl_EmployeeId"].ToString();
                txtManufacturerName.Text = dtb.Rows[0]["ManufacturerName"].ToString();
                txtQuantity.Text = dtb.Rows[0]["Quantity"].ToString();
                txtLastMaintenanceDate.Text = dtb.Rows[0]["LastMaintenanceDate"].ToString();
                txtDateAdded.Text = dtb.Rows[0]["DateAdded"].ToString();
                ddlopt_Status.SelectedValue = dtb.Rows[0]["Status"].ToString();
                txtSerialNumber.Text = dtb.Rows[0]["SerialNumber"].ToString();
                txtModalNumber.Text = dtb.Rows[0]["ModalNumber"].ToString();
                txtWarrantyDate.Text = dtb.Rows[0]["WarrantyDate"].ToString();
                txtDepreciationExpense.Text = dtb.Rows[0]["DepreciationExpense"].ToString();
                txtDepreciationExpenseGuid.Text = dtb.Rows[0]["tbl_GLAccountId_DepreciationExpense"].ToString();
                txtAccumulatedDepreciation.Text = dtb.Rows[0]["AccumulatedDepreciation"].ToString();
                txtAccumulatedDepreciationGuid.Text = dtb.Rows[0]["tbl_GLAccountId_AccumulatedDepreciation"].ToString();
                txtPriorYearDepreciation.Text = dtb.Rows[0]["PriorYearDepreciation"].ToString();
                txtPriorYearDepreciationGuid.Text = dtb.Rows[0]["tbl_GLAccountId_PriorYearDepreciation"].ToString();
                txtAssetCost.Text = dtb.Rows[0]["AssetCost"].ToString();
                txtAssetCostGuid.Text = dtb.Rows[0]["tbl_GLAccountId_AssetCost"].ToString();
                txtClearing.Text = dtb.Rows[0]["Clearing"].ToString();
                txtClearingGuid.Text = dtb.Rows[0]["tbl_GLAccountId_Clearing"].ToString();
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
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = assetFormUI.Tbl_AssetId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_Asset_AssetForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    //private void FillGuid(AssetFormUI assetFormUI)
    //{
    //    try
    //    {
    //           assetFormUI.Tbl_AssetGroupId = txtAssetGroupGuid.Text;
    //           DataTable dtb = assetFormBAL.GetAssetGroupById(assetFormUI);
    //        if (dtb.Rows.Count > 0)
    //        {

    //            txtAssetAndGroupAccount.Text = dtb.Rows[0]["tbl_AssetAndGroupAccountId"].ToString();
    //            txtAssetAndGroupAccountGuid.Text = dtb.Rows[0]["tbl_AssetAndGroupAccountId"].ToString();
    //            txtDepreciationExpenseGuid.Text = dtb.Rows[0]["tbl_GLAccountId_DepreciationExpense"].ToString();
    //            txtDepreciationExpense.Text = dtb.Rows[0]["DepreciationExpense"].ToString();
    //            txtAccumulatedDepreciationGuid.Text = dtb.Rows[0]["tbl_GLAccountId_AccumulatedDepreciation"].ToString();
    //            txtAccumulatedDepreciation.Text = dtb.Rows[0]["AccumulatedDepreciation"].ToString();
    //            txtPriorYearDepreciationGuid.Text = dtb.Rows[0]["tbl_GLAccountId_PriorYearDepreciation"].ToString();
    //            txtPriorYearDepreciation.Text = dtb.Rows[0]["PriorYearDepreciation"].ToString();
    //            txtAssetCost.Text = dtb.Rows[0]["AssetCost"].ToString();
    //            txtAssetCostGuid.Text = dtb.Rows[0]["tbl_GLAccountId_AssetCost"].ToString();
    //            txtClearing.Text = dtb.Rows[0]["Clearing"].ToString();
    //            txtClearingGuid.Text = dtb.Rows[0]["tbl_GLAccountId_Clearing"].ToString();

    //        }
           
    //    }
    //    catch (Exception exp)
    //    {
    //        logExcpUIobj.MethodName = "FillForm()";
    //        logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
    //        logExcpUIobj.RecordId = assetFormUI.Tbl_AssetId;
    //        logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
    //        logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
    //        log.Error("[Assets_Asset_AssetForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
    //    }
    //}
    private void Bind_opt_TypeDropDownList()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_Asset";
            optionSetListUI.OptionSetName = "opt_Type";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {
                ddlOpt_opt_Type.DataSource = dtb;
                ddlOpt_opt_Type.DataBind();
                ddlOpt_opt_Type.DataTextField = "OptionSetLable";
                ddlOpt_opt_Type.DataValueField = "OptionSetValue";
                ddlOpt_opt_Type.DataBind();
            }
            else
            {
                ddlOpt_opt_Type.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "Bind_opt_TypeDropDownList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_Asset_AssetForm : Bind_opt_TypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void Bindopt_StatusDropDownList()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_Asset";
            optionSetListUI.OptionSetName = "Opt_Status";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {
                ddlopt_Status.DataSource = dtb;
                ddlopt_Status.DataBind();
                ddlopt_Status.DataTextField = "OptionSetLable";
                ddlopt_Status.DataValueField = "OptionSetValue";
                ddlopt_Status.DataBind();
            }
            else
            {
                ddlopt_Status.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "Bindopt_StatusDropDownList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_Asset_AssetForm : Bindopt_StatusDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void GetSerialNumber(AssetFormUI assetFormUI)
    {
        try
        {
            DataTable dtb = assetFormBAL.GetSerialNumber(assetFormUI);
            if (dtb.Rows.Count > 0)
            {
                txtSerialNumber.Text = dtb.Rows[0][0].ToString();

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
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = assetFormUI.Tbl_AssetId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_Asset_AssetForm : GetSerialNumber] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region Employee Search
    private void SearchEmployeeList()
    {
        try
        {
            EmployeeListUI employeeListUI = new EmployeeListUI();
            employeeListUI.Search = txtEmployeeSearch.Text;
            DataTable dtb = employeeListBAL.GetEmployeeListBySearchParameters(employeeListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvEmployeeSearch.DataSource = dtb;
                gvEmployeeSearch.DataBind();
                divEmployeeSearchError.Visible = false;
            }
            else
            {
                divEmployeeSearchError.Visible = true;
                lblEmployeeSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvEmployeeSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchEmployeeList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_Asset_AssetForm : SearchEmployeeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindEmployeeList()
    {
        try
        {
            DataTable dtb = employeeListBAL.GetEmployeeList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvEmployeeSearch.DataSource = dtb;
                gvEmployeeSearch.DataBind();
                divEmployeeSearchError.Visible = false;
            }
            else
            {
                divEmployeeSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvEmployeeSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindEmployeeList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_Asset_AssetForm : BindEmployeeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Employee Serach

    #region AssetGroup Search
    private void SearchAssetGroupList()
    {
        try
        {
           
            AssetGroupListUI assetGroupListUI = new AssetGroupListUI();
            assetGroupListUI.Tbl_AssetGroupId = txtAssetGroupSearch.Text;
            DataTable dtb = assetGroupListBAL.AssetGroupListBySearchParameters(assetGroupListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAssetGroupSearch.DataSource = dtb;
                gvAssetGroupSearch.DataBind();
                divAssetGroupSearchError.Visible = false;
            }
            else
            {
                divAssetGroupSearchError.Visible = true;
                lblAssetGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAssetGroupSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchAssetGroupList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_Asset_AssetForm : SearchAssetGroupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindAssetGroupList()
    {
        try
        {
            DataTable dtb = assetGroupListBAL.GetAssetGroupList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAssetGroupSearch.DataSource = dtb;
                gvAssetGroupSearch.DataBind();
                divAssetGroupSearchError.Visible = false;
            }
            else
            {
                divAssetGroupSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAssetGroupSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindAssetGroupList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_Asset_AssetForm : BindAssetGroupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Asset Group Serach

    #region AssetAndGroupAccount Search
    private void SearchAssetAndGroupAccountList()
    {
        try
        {
            AssetAndGroupAccountListUI assetAndGroupAccountListUI = new AssetAndGroupAccountListUI();
            assetAndGroupAccountListUI.Search = txtAssetAndGroupAccountSearch.Text;
            DataTable dtb = assetAndGroupAccountListBAL.GetAssetAndGroupAccountListBySearchParameters(assetAndGroupAccountListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAssetAndGroupAccountSearch.DataSource = dtb;
                gvAssetAndGroupAccountSearch.DataBind();
                divAssetAndGroupAccountSearchError.Visible = false;
            }
            else
            {
                divEmployeeSearchError.Visible = true;
                lblAssetAndGroupAccountSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAssetAndGroupAccountSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchAssetAndGroupAccountList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_Asset_AssetForm : SearchAssetAndGroupAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindAssetAndGroupAccountList()
    {
        try
        {
            DataTable dtb = assetAndGroupAccountListBAL.GetAssetAndGroupAccountList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAssetAndGroupAccountSearch.DataSource = dtb;
                gvAssetAndGroupAccountSearch.DataBind();
                divAssetAndGroupAccountSearchError.Visible = false;
            }
            else
            {
                divAssetAndGroupAccountSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAssetAndGroupAccountSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchAssetAndGroupAccountList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_Asset_AssetForm : SearchAssetAndGroupAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  AssetAndGroupAccount Serach

    #region Currency Search
    private void SearchCurrencyList()
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
            logExcpUIobj.MethodName = "SearchCurrencyList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_Asset_AssetForm : SearchCurrencyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCurrencySearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCurrencyList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_Asset_AssetForm : BindCurrencyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Currency Serach

    #region Structure Search
    private void SearchStructureList()
    {
        try
        {
            StructureListUI structureListUI = new StructureListUI();
            structureListUI.Search = txtStructureSearch.Text;
            DataTable dtb = structureListBAL.GetStructureListBySearchParameters(structureListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvStructureSearch.DataSource = dtb;
                gvStructureSearch.DataBind();
                divStructureSearchError.Visible = false;
            }
            else
            {
                divStructureSearchError.Visible = true;
                lblStructureSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvStructureSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchStructureList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_Asset_AssetForm : SearchStructureList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindStructureList()
    {
        try
        {
            DataTable dtb = structureListBAL.GetStructureList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvStructureSearch.DataSource = dtb;
                gvStructureSearch.DataBind();
                divStructureSearchError.Visible = false;

            }
            else
            {
                divStructureSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvStructureSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindStructureList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_Asset_AssetForm : BindStructureList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Structure Serach

    #region Location Search
    private void SearchLocationList()
    {
        try
        {
            LocationListUI locationListUI = new LocationListUI();
            locationListUI.Search = txtLocationSearch.Text;
            DataTable dtb = locationListBAL.GetLocationListBySearchParameters(locationListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvLocationSearch.DataSource = dtb;
                gvLocationSearch.DataBind();
                divLocationSearchError.Visible = false;
            }
            else
            {
                divLocationSearchError.Visible = true;
                lblLocationSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvLocationSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchLocationList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_Asset_AssetForm : SearchLocationList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindLocationList()
    {
        try
        {
            DataTable dtb = locationListBAL.GetLocationList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvLocationSearch.DataSource = dtb;
                gvLocationSearch.DataBind();
                divLocationSearchError.Visible = false;
            }
            else
            {
                divLocationSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvLocationSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindLocationList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_Asset_AssetForm : BindBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Location search

    #region Physical Location Search

    private void SearchPhysicalLocationList()
    {
        try
        {
            PhysicalLocationListUI physicalLocationListUI = new PhysicalLocationListUI();
            physicalLocationListUI.Search = txtPhysicalLocationSearch.Text;
            DataTable dtb = physicalLocationListBAL.GetPhysicalLocationListBySearchParameters(physicalLocationListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPhysicalLocationSearch.DataSource = dtb;
                gvPhysicalLocationSearch.DataBind();
                divPhysicalLocationSearchError.Visible = false;
            }
            else
            {
                divPhysicalLocationSearchError.Visible = true;
                lblPhysicalLocationSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPhysicalLocationSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchPhysicalLocationList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_Asset_AssetForm : SearchPhysicalLocationList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindPhysicalLocationList()
    {
        try
        {
            DataTable dtb = physicalLocationListBAL.GetPhysicalLocationList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPhysicalLocationSearch.DataSource = dtb;
                gvPhysicalLocationSearch.DataBind();
                divPhysicalLocationSearchError.Visible = false;
            }
            else
            {
                divPhysicalLocationSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPhysicalLocationSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPhysicalLocationList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_Asset_AssetForm : BindPhysicalLocationList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    #endregion Physical location


    #region Search DepreciationExpense	
    private void SearchDepreciationExpenseList()
    {
        {

            try
            {
                GLAccountListUI gLAccountListUI = new GLAccountListUI();

                gLAccountListUI.Search = txtDepreciationExpenseSearch.Text;

                DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    gvDepreciationExpenseSearch.DataSource = dtb;
                    gvDepreciationExpenseSearch.DataBind();
                    divDepreciationExpenseSearchError.Visible = false;
                }
                else
                {
                    divDepreciationExpenseSearchError.Visible = true;
                    lblDepreciationExpenseSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                    gvDepreciationExpenseSearch.Visible = false;
                }

            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "SearchDepreciationExpenseList()";
                logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
                logExcpUIobj.RecordId = "All";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Assets_Asset_AssetForm : SearchDepreciationExpenseList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
        }
    }
    private void BindDepreciationExpenseList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvDepreciationExpenseSearch.DataSource = dtb;
                gvDepreciationExpenseSearch.DataBind();
                divDepreciationExpenseSearchError.Visible = false;
            }
            else
            {
                divDepreciationExpenseSearchError.Visible = true;
                lblDepreciationExpenseSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvDepreciationExpenseSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindDepreciationExpenseList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_Asset_AssetForm : BindPurchaseList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion

    #region AccumulatedDepreciation Search
    private void SearchAccumulatedDepreciationList()
    {
        {

            try
            {
                GLAccountListUI gLAccountListUI = new GLAccountListUI();

                gLAccountListUI.Search = txtAccumulatedDepreciationSearch.Text;

                DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    gvAccumulatedDepreciationSearch.DataSource = dtb;
                    gvAccumulatedDepreciationSearch.DataBind();
                    divAccumulatedDepreciationSearchError.Visible = false;
                }
                else
                {
                    divAccumulatedDepreciationSearchError.Visible = true;
                    lblAccumulatedDepreciationSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                    gvAccumulatedDepreciationSearch.Visible = false;
                }

            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "SearchAccumulatedDepreciationList()";
                logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
                logExcpUIobj.RecordId = "All";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Assets_Asset_AssetForm : SearchDepreciationReserveList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
        }
    }
    private void BindAccumulatedDepreciationList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAccumulatedDepreciationSearch.DataSource = dtb;
                gvAccumulatedDepreciationSearch.DataBind();
                divAccumulatedDepreciationSearchError.Visible = false;
            }
            else
            {
                divAccumulatedDepreciationSearchError.Visible = true;
                lblAccumulatedDepreciationSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAccumulatedDepreciationSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindAccumulatedDepreciationList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_Asset_AssetForm : BindAccumulatedDepreciationList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion

    #region Search PriorYearDepreciation 
    private void SearchPriorYearDepreciationList()
    {
        {

            try
            {
                GLAccountListUI gLAccountListUI = new GLAccountListUI();

                gLAccountListUI.Search = txtPriorYearDepreciationSearch.Text;

                DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    gvPriorYearDepreciationSearch.DataSource = dtb;
                    gvPriorYearDepreciationSearch.DataBind();
                    divPriorYearDepreciationSearchError.Visible = false;
                }
                else
                {
                    divPriorYearDepreciationSearchError.Visible = true;
                    lblPriorYearDepreciationSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                    gvPriorYearDepreciationSearch.Visible = false;
                }

            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "SearchPriorYearDepreciationList()";
                logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
                logExcpUIobj.RecordId = "All";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Assets_Asset_AssetForm : SearchPriorYearDepreciationList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
        }
    }
    private void BindPriorYearDepreciationList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPriorYearDepreciationSearch.DataSource = dtb;
                gvPriorYearDepreciationSearch.DataBind();
                divPriorYearDepreciationSearchError.Visible = false;
            }
            else
            {
                divPriorYearDepreciationSearchError.Visible = true;
                lblPriorYearDepreciationSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPriorYearDepreciationSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPriorYearDepreciationList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_Asset_AssetForm : BindPriorYearDepreciationList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion

    #region Search AssetCost
    private void SearchAssetCostList()
    {
        {

            try
            {
                GLAccountListUI gLAccountListUI = new GLAccountListUI();

                gLAccountListUI.Search = txtAssetCostSearch.Text;

                DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    gvAssetCostSearch.DataSource = dtb;
                    gvAssetCostSearch.DataBind();
                    divAssetCostSearchError.Visible = false;
                }
                else
                {
                    divAssetCostSearchError.Visible = true;
                    lblAssetCostSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                    gvAssetCostSearch.Visible = false;
                }

            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "SearchAssetCostList()";
                logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
                logExcpUIobj.RecordId = "All";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Assets_Asset_AssetForm : SearchAssetCostList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
        }
    }
    private void BindAssetCostList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAssetCostSearch.DataSource = dtb;
                gvAssetCostSearch.DataBind();
                divAssetCostSearchError.Visible = false;
            }
            else
            {
                divAssetCostSearchError.Visible = true;
                lblAssetCostSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAssetCostSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindAssetCostList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_Asset_AssetForm : BindAssetCostList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion

    #region Search Clearing
    private void SearchClearingList()
    {
        {

            try
            {
                GLAccountListUI gLAccountListUI = new GLAccountListUI();

                gLAccountListUI.Search = txtClearingSearch.Text;

                DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    gvClearingSearch.DataSource = dtb;
                    gvClearingSearch.DataBind();
                    divClearingSearchError.Visible = false;
                }
                else
                {
                    divClearingSearchError.Visible = true;
                    lblClearingSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                    gvClearingSearch.Visible = false;
                }

            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "SearchClearingList()";
                logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
                logExcpUIobj.RecordId = "All";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Assets_Asset_AssetForm : SearchClearingList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
        }
    }
    private void BindClearingList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvClearingSearch.DataSource = dtb;
                gvClearingSearch.DataBind();
                divClearingSearchError.Visible = false;
            }
            else
            {
                divClearingSearchError.Visible = true;
                lblClearingSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvClearingSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindClearingList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_Asset_AssetForm : BindClearingList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion
    #endregion Method


    protected void txtAssetGroup_TextChanged1(object sender, EventArgs e)
    {
        //if (Request.QueryString["AssetId"] != null || Request.QueryString["recordId"] != null)
        //{
            
        //    FillGuid(assetFormUI);
        //}
    }
}
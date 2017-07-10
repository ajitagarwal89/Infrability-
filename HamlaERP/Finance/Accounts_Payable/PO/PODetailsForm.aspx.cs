using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Accounts_Payable_PO_PODetailsForm : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    PODetailsFormBAL pODetailsFormBAL = new PODetailsFormBAL();
    PODetailsFormUI pODetailsFormUI = new PODetailsFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    PODetailsListBAL pODetailsListBAL = new PODetailsListBAL();
  
    PODetailsListBAL pOdetailsListBAL = new PODetailsListBAL ();
    PODetailsListUI pOdetailsListUI = new PODetailsListUI();
    LocationListBAL locationListBAL = new LocationListBAL();
    LocationListUI locationListUI = new LocationListUI();
    POListBAL pOListBAL = new POListBAL();
    AssetListBAL assetListBAL = new AssetListBAL();
    AssetListUI assetListUI = new AssetListUI();
    PayablesListBAL payablesListBAL = new PayablesListBAL();

    CommonDateClasses commonDateClasses = new CommonDateClasses();
    #endregion Data Members

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        PODetailsFormUI pODetailsFormUI = new PODetailsFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["PODetailsId"] != null)
            {
                pODetailsFormUI.Tbl_PODetailsId = Request.QueryString["PODetailsId"];

                FillForm(pODetailsFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update PO Details";
            }
            else
            {

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New PO Details";
            }
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            pODetailsFormUI.CreatedBy = SessionContext.UserGuid;
            pODetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            pODetailsFormUI.Tbl_POId = txtPOIdGuid.Text;
            pODetailsFormUI.Tbl_AssetId_FixedAsset = txtAssetIdGuid.Text;
            pODetailsFormUI.UOM = txtUOM.Text;
            pODetailsFormUI.Description = txtDescription.Text;
            pODetailsFormUI.Tbl_LocationId = txtLocationGuid.Text;
            pODetailsFormUI.QuantityOrdered = Convert.ToDecimal(txtQuantityOrdered.Text);
            pODetailsFormUI.QuantityCanceled = Convert.ToDecimal(txtQuantityCanceled.Text);
            pODetailsFormUI.UnitCost = Convert.ToDecimal(txtUnitCost.Text);
            pODetailsFormUI.ExtendedCost = Convert.ToDecimal(txtUnitCost.Text);
            if (pODetailsFormBAL.AddPODetails(pODetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_PODetailsForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_PODetailsForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            pODetailsFormUI.ModifiedBy = SessionContext.UserGuid;
            pODetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            pODetailsFormUI.Tbl_PODetailsId = Request.QueryString["PODetailsId"];
            pODetailsFormUI.Tbl_POId = txtPOIdGuid.Text;
            pODetailsFormUI.Tbl_AssetId_FixedAsset = txtAssetIdGuid.Text;
            pODetailsFormUI.UOM = txtUOM.Text;
            pODetailsFormUI.Description = txtDescription.Text;
            pODetailsFormUI.Tbl_LocationId = txtLocationGuid.Text;
            pODetailsFormUI.QuantityOrdered = Convert.ToDecimal(txtQuantityOrdered.Text);
            pODetailsFormUI.QuantityCanceled = Convert.ToDecimal(txtQuantityCanceled.Text);
            pODetailsFormUI.UnitCost = Convert.ToDecimal(txtUnitCost.Text);
            pODetailsFormUI.ExtendedCost = Convert.ToDecimal(txtUnitCost.Text);

            if (pODetailsFormBAL.UpdatePODetails(pODetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_PODetailsForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_PODetailsForm : btnUpdate_Click] An error occured in the processing of Record Id : " + pODetailsFormUI.Tbl_PODetailsId + ".  Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            pODetailsFormUI.Tbl_PODetailsId = Request.QueryString["PODetailsId"];

            if (pODetailsFormBAL.DeletePODetails(pODetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_PODetailsForm.CS";
            logExcpUIobj.RecordId = pODetailsFormUI.Tbl_PODetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm : btnDelete_Click] An error occured in the processing of Record Id : " + pODetailsFormUI.Tbl_PODetailsId + ". Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PODetailsList.aspx");
    }

    #region PO Search
    protected void btnPOSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPOSearch.Visible = false;
        btnHtmlPOClose.Visible = true;
        SearchPOList();
    }
    protected void btnClearPOSearch_Click(object sender, EventArgs e)
    {
        BindPOList();
        gvPOSearch.Visible = true;
        btnHtmlPOSearch.Visible = true;
        btnHtmlPOClose.Visible = false;
        txtPOSearch.Text = "";
        txtPOSearch.Focus();
    }
    protected void btnPORefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPOList();
    }
    #endregion Batch Search

    #region Asset Search
    protected void btnAssetSearch_Click(object sender, EventArgs e)
    {
        btnHtmlAssetSearch.Visible = false;
        btnHtmlAssetClose.Visible = true;
        SearchAssetList();
    }
    protected void btnClearAssetSearch_Click(object sender, EventArgs e)
    {
        BindAssetList();
        gvAssetSearch.Visible = true;
        btnHtmlAssetSearch.Visible = true;
        btnHtmlAssetClose.Visible = false;
        txtAssetSearch.Text = "";
        txtAssetSearch.Focus();
    }
    protected void btnAssetRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindAssetList();
    }
    #endregion Asset Search

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
    #endregion Events

    #region Methods
    #region PO Search    
    private void SearchPOList()
    {
        try
        {
            POListUI POListUI = new POListUI();
            POListUI.Search = txtPOSearch.Text;


            DataTable dtb = pOListBAL.GetPOListBySearchParameters(POListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPOSearch.DataSource = dtb;
                gvPOSearch.DataBind();
                divPOSearchError.Visible = false;
            }
            else
            {
                divPOSearchError.Visible = true;
                lblPOSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPOSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchPOList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_PODetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_PODetailsForm : SearchPOList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindPOList()
    {
        try
        {
            DataTable dtb = pOListBAL.GetPOList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPOSearch.DataSource = dtb;
                gvPOSearch.DataBind();
                divPOSearchError.Visible = false;

            }
            else
            {
                divPOSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPOSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPOList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_PODetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_PODetailsForm : BindPOList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Batch Search

    #region Asset Search    
    private void SearchAssetList()
    {
        try
        {
            AssetListUI AssetListUI = new AssetListUI();
            AssetListUI.Search = txtAssetSearch.Text;


            DataTable dtb = assetListBAL.GetAssetListSearchParameters(assetListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAssetSearch.DataSource = dtb;
                gvAssetSearch.DataBind();
                divAssetSearchError.Visible = false;
            }
            else
            {
                divAssetSearchError.Visible = true;
                lblAssetSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAssetSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchAssetList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_PODetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_PODetailsForm : SearchAssetList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindAssetList()
    {
        try
        {
            DataTable dtb = assetListBAL.GetAssetList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAssetSearch.DataSource = dtb;
                gvAssetSearch.DataBind();
                divAssetSearchError.Visible = false;

            }
            else
            {
                divAssetSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAssetSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindAssetList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_PODetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_PODetailsForm : BindAssetList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Asset Search


    #region Location Search    
    private void SearchLocationList()
    {
        try
        {
            LocationListUI LocationListUI = new LocationListUI();
            LocationListUI.Search = txtLocationSearch.Text;


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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_PODetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_PODetailsForm : SearchLocationList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_PODetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_PODetailsForm : BindLocationList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Location Search

    private void FillForm(PODetailsFormUI pODetailsFormUI)
    {
        try
        {
            DataTable dtb = pODetailsFormBAL.GetPODetailsListById(pODetailsFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtPOId.Text = dtb.Rows[0]["tbl_PO"].ToString();
                txtPOIdGuid.Text = dtb.Rows[0]["tbl_POId"].ToString();
                txtAssetId.Text = dtb.Rows[0]["FixedAsset"].ToString();
                txtAssetIdGuid.Text = dtb.Rows[0]["tbl_AssetId_FixedAsset"].ToString();
                txtUOM.Text = dtb.Rows[0]["UOM"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                txtLocation.Text = dtb.Rows[0]["tbl_Location"].ToString();
                txtLocationGuid.Text = dtb.Rows[0]["tbl_LocationId"].ToString();
                txtQuantityOrdered.Text = dtb.Rows[0]["QuantityOrdered"].ToString();
                txtQuantityCanceled.Text = dtb.Rows[0]["QuantityCanceled"].ToString();
                txtUnitCost.Text = dtb.Rows[0]["UnitCost"].ToString();
                txtExtendedCost.Text = dtb.Rows[0]["ExtendedCost"].ToString();

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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_PODetailsForm.CS";
            logExcpUIobj.RecordId = pODetailsFormUI.Tbl_PODetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_PODetailsForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }




    #endregion
}
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferDetailsForm : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    AssetTransferDetailsFormBAL assetTransferDetailsFormBAL = new AssetTransferDetailsFormBAL();
    AssetTransferDetailsFormUI assetTransferDetailsFormUI = new AssetTransferDetailsFormUI();
    AssetListBAL assetListBAL = new AssetListBAL();
    LocationListBAL locationListBAL = new LocationListBAL();
    AssetTransferListBAL assetTransferListBAL = new AssetTransferListBAL();

    #endregion Data Members
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        AssetTransferDetailsFormUI assetTransferDetailsFormUI = new AssetTransferDetailsFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["AssetTransferDetailsId"] != null)
            {
                assetTransferDetailsFormUI.Tbl_AssetTransferDetailsId = Request.QueryString["AssetTransferDetailsId"];
                FillForm(assetTransferDetailsFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Asset Transefer Details";
            }
            else
            {
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Asset Transfer Details";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            assetTransferDetailsFormUI.CreatedBy = SessionContext.UserGuid;
            assetTransferDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            assetTransferDetailsFormUI.Tbl_AssetTransferId = txtAssetTransferGuid.Text;
            assetTransferDetailsFormUI.Tbl_AssetId = txtAssetGuid.Text;
            assetTransferDetailsFormUI.UOM = txtUOM.Text;
            assetTransferDetailsFormUI.Quantity = txtQuantity.Text;
            assetTransferDetailsFormUI.Description = txtDescription.Text;
            assetTransferDetailsFormUI.Tbl_LocationId_From = txtLocation_FromGuid.Text;
            assetTransferDetailsFormUI.Tbl_LocationId_To = txtLocation_ToGuid.Text;

            assetTransferDetailsFormUI.SubTotal = Decimal.Parse(txtSubTotal.Text);
            assetTransferDetailsFormUI.QuantityAvailable = int.Parse(txtQuantityAvailable.Text);
            if (assetTransferDetailsFormBAL.AddAssetTransferDetails(assetTransferDetailsFormUI) == 1)
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
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferDetailsForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferDetailsForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            assetTransferDetailsFormUI.ModifiedBy = SessionContext.UserGuid;
            assetTransferDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            assetTransferDetailsFormUI.Tbl_AssetTransferDetailsId = Request.QueryString["AssetTransferDetailsId"];
            assetTransferDetailsFormUI.Tbl_AssetTransferId = txtAssetTransferGuid.Text;
            assetTransferDetailsFormUI.Tbl_AssetId = txtAssetGuid.Text;
            assetTransferDetailsFormUI.UOM = txtUOM.Text;
            assetTransferDetailsFormUI.Quantity = txtQuantity.Text;
            assetTransferDetailsFormUI.Description = txtDescription.Text;
            assetTransferDetailsFormUI.Tbl_LocationId_From = txtLocation_FromGuid.Text;
            assetTransferDetailsFormUI.Tbl_LocationId_To = txtLocation_ToGuid.Text;

            assetTransferDetailsFormUI.SubTotal = Decimal.Parse(txtSubTotal.Text);
            assetTransferDetailsFormUI.QuantityAvailable = int.Parse(txtQuantityAvailable.Text);
            if (assetTransferDetailsFormBAL.UpdateAssetTransferDetails(assetTransferDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferDetailsForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferDetailsForm : btnUpdate_Click] An error occured in the processing of Record Id : " + assetTransferDetailsFormUI.Tbl_AssetTransferDetailsId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            assetTransferDetailsFormUI.Tbl_AssetTransferDetailsId = Request.QueryString["AssetTransferDetailsId"];

            if (assetTransferDetailsFormBAL.DeleteAssetTransferDetails(assetTransferDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferDetailsForm.CS";
            logExcpUIobj.RecordId = assetTransferDetailsFormUI.Tbl_AssetTransferDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferDetailsForm : btnDelete_Click] An error occured in the processing of Record Id : " + assetTransferDetailsFormUI.Tbl_AssetTransferDetailsId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetTransferDetailsList.aspx");
    }

    #region AssetTransfer Search
    protected void btnAssetTransferSearch_Click(object sender, EventArgs e)
    {
        btnHtmlAssetTransferSearch.Visible = false;
        btnHtmlAssetTransferClose.Visible = true;
        SearchAssetTransferList();
    }
    protected void btnClearAssetTransferSearch_Click(object sender, EventArgs e)
    {
        BindAssetTransferList();
        gvAssetTransferSearch.Visible = true;
        btnHtmlAssetTransferSearch.Visible = true;
        btnHtmlAssetTransferClose.Visible = false;
        txtAssetTransferSearch.Text = "";
        txtAssetTransferSearch.Focus();
    }
    protected void btnAssetTransferRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindAssetTransferList();
    }
    #endregion AssetTransfer Search

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
  
    #region LocationFrom Search
    protected void btnLocationFromSearch_Click(object sender, EventArgs e)
    {
        btnHtmlLocationFromSearch.Visible = false;
        btnHtmlLocationFromClose.Visible = true;
        SearchLocationFromList();
    }
    protected void btnClearLocationFromSearch_Click(object sender, EventArgs e)
    {
        BindLocationFromList();
        gvLocationFromSearch.Visible = true;
        btnHtmlLocationFromSearch.Visible = true;
        btnHtmlLocationFromClose.Visible = false;
        txtLocationFromSearch.Text = "";
        txtLocationFromSearch.Focus();
    }
    protected void btnLocationFromRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindLocationFromList();
    }
    #endregion LocationFrom Search

    #region LocationTo Search
    protected void btnLocationToSearch_Click(object sender, EventArgs e)
    {
        btnHtmlLocationToSearch.Visible = false;
        btnHtmlLocationToClose.Visible = true;
        SearchLocationToList();
    }
    protected void btnClearLocationToSearch_Click(object sender, EventArgs e)
    {
        BindLocationToList();
        gvLocationToSearch.Visible = true;
        btnHtmlLocationToSearch.Visible = true;
        btnHtmlLocationToClose.Visible = false;
        txtLocationToSearch.Text = "";
        txtLocationToSearch.Focus();
    }
    protected void btnLocationToRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindLocationToList();
    }
    #endregion LocationTo Search
  
    #endregion Events

    #region Methods

    private void FillForm(AssetTransferDetailsFormUI assetTransferDetailsFormUI)
    {
        try
        {
            DataTable dtb = assetTransferDetailsFormBAL.GetAssetTransferDetailsListById(assetTransferDetailsFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtAssetTransferGuid.Text= dtb.Rows[0]["tbl_AssetTransferId"].ToString();
               txtAssetTransfer.Text= dtb.Rows[0]["tbl_AssetTransfer"].ToString();
                txtAssetGuid.Text= dtb.Rows[0]["tbl_AssetId"].ToString();
                txtAsset.Text= dtb.Rows[0]["tbl_Asset"].ToString();
                txtUOM.Text= dtb.Rows[0]["UOM"].ToString();
                txtQuantity.Text= dtb.Rows[0]["Quantity"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                txtLocation_FromGuid.Text= dtb.Rows[0]["tbl_LocationId_From"].ToString();
                txtLocationId_From.Text= dtb.Rows[0]["tbl_Location_From"].ToString();
                txtLocation_ToGuid.Text= dtb.Rows[0]["tbl_LocationId_To"].ToString();
                txtLocationId_To.Text= dtb.Rows[0]["tbl_Location_To"].ToString();
                txtSubTotal.Text= dtb.Rows[0]["SubTotal"].ToString();
                txtQuantityAvailable.Text= dtb.Rows[0]["QuantityAvailable"].ToString();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "FillForm()";
            logExcpUIobj.ResourceName = "Asset_Purchase_AssetTransferDetailsForm.CS";
            logExcpUIobj.RecordId = this.assetTransferDetailsFormUI.Tbl_AssetTransferDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Asset_Purchase_AssetTransferDetailsForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region AssetTransfer Search
    private void SearchAssetTransferList()
    {
        try
        {
            AssetTransferListUI assetTransferListUI = new AssetTransferListUI();
            assetTransferListUI.Search = txtAssetTransferSearch.Text;
            DataTable dtb = assetTransferListBAL.GetAssetTransferListBySearchParameters(assetTransferListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAssetTransferSearch.DataSource = dtb;
                gvAssetTransferSearch.DataBind();
                divAssetTransferSearchError.Visible = false;
                gvAssetTransferSearch.Visible = true;
            }
            else
            {
                divAssetTransferSearchError.Visible = true;
                lblAssetTransferSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAssetTransferSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchAssetTransferList()";
            logExcpUIobj.ResourceName = "Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferDetailsForm : SearchAssetTransferList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindAssetTransferList()
    {
        try
        {
            DataTable dtb = assetTransferListBAL.GetAssetTransferList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAssetTransferSearch.DataSource = dtb;
                gvAssetTransferSearch.DataBind();
                divAssetTransferSearchError.Visible = false;
            }
            else
            {
                divAssetTransferSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAssetTransferSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindAssetTransferList()";
            logExcpUIobj.ResourceName = "Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferDetailsForm : BindAssetTransferList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  AssetTransfer search

    #region Asset Search
    private void SearchAssetList()
    {
        try
        {
            AssetListUI assetListUI = new AssetListUI();
            assetListUI.Search = txtAssetSearch.Text;
            DataTable dtb = assetListBAL.GetAssetListSearchParameters(assetListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAssetSearch.DataSource = dtb;
                gvAssetSearch.DataBind();
                divAssetSearchError.Visible = false;
                gvAssetSearch.Visible = true;
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
            logExcpUIobj.ResourceName = "Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferDetailsForm : SearchAssetList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_Asset_AssetForm : BindAssetList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Asset search
   
    #region LocationFrom Search
    private void SearchLocationFromList()
    {
        try
        {
            LocationListUI locationFromListUI = new LocationListUI();
            locationFromListUI.Search = txtLocationFromSearch.Text;
            DataTable dtb = locationListBAL.GetLocationListBySearchParameters(locationFromListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvLocationFromSearch.DataSource = dtb;
                gvLocationFromSearch.DataBind();
                divLocationFromSearchError.Visible = false;
                gvLocationFromSearch.Visible = true;
            }
            else
            {
                divLocationFromSearchError.Visible = true;
                lblLocationFromSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvLocationFromSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchLocationFromList()";
            logExcpUIobj.ResourceName = "Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferDetailsForm : SearchLocationFromList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindLocationFromList()
    {
        try
        {
            DataTable dtb = locationListBAL.GetLocationList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvLocationFromSearch.DataSource = dtb;
                gvLocationFromSearch.DataBind();
                divLocationFromSearchError.Visible = false;
            }
            else
            {
                divLocationFromSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvLocationFromSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindLocationFromList()";
            logExcpUIobj.ResourceName = "Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferDetailsForm : BindLocationFromList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  LocationFrom search

    #region LocationTo Search
    private void SearchLocationToList()
    {
        try
        {
            LocationListUI locationToListUI = new LocationListUI();
            locationToListUI.Search = txtLocationToSearch.Text;
            DataTable dtb = locationListBAL.GetLocationListBySearchParameters(locationToListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvLocationToSearch.DataSource = dtb;
                gvLocationToSearch.DataBind();
                divLocationToSearchError.Visible = false;
                gvLocationToSearch.Visible = true;
            }
            else
            {
                divLocationToSearchError.Visible = true;
                lblLocationToSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvLocationToSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchLocationToList()";
            logExcpUIobj.ResourceName = "Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferDetailsForm : SearchLocationToList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindLocationToList()
    {
        try
        {
            DataTable dtb = locationListBAL.GetLocationList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvLocationToSearch.DataSource = dtb;
                gvLocationToSearch.DataBind();
                divLocationToSearchError.Visible = false;
            }
            else
            {
                divLocationToSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvLocationToSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindLocationToList()";
            logExcpUIobj.ResourceName = "Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferDetailsForm : BindLocationToList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  LocationTo search
  
    #endregion Methods

}
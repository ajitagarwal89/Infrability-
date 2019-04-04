using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Assets_AssetPurchaseDetails_AssetPurchaseDetailsForm : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    AssetPurchaseDetailsFormBAL assetPurchaseDetailsFormBAL = new AssetPurchaseDetailsFormBAL();
    AssetPurchaseDetailsFormUI assetPurchaseDetailsFormUI = new AssetPurchaseDetailsFormUI();
    LocationListBAL locationListBAL = new LocationListBAL();
    AssetListBAL assetListBAL = new AssetListBAL();
    //PONumberListBAL pONumberListBAL = new PONumberListBAL();
    POListBAL pOListBAL = new POListBAL();
    AssetPurchaseListBAL assetPurchaseListBAL = new AssetPurchaseListBAL();

    #endregion Data Members

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        AssetPurchaseDetailsFormUI assetPurchaseDetailsFormUI = new AssetPurchaseDetailsFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["AssetPurchaseDetailsId"] != null ||Request.QueryString["recordId"]!=null)
            {
                assetPurchaseDetailsFormUI.Tbl_AssetPurchaseDetailsId = (Request.QueryString["AssetPurchaseDetailsId"] != null ? Request.QueryString["AssetPurchaseDetailsId"] : Request.QueryString["recordId"] );
                //BindOrganizationDropDown();
                FillForm(assetPurchaseDetailsFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update AssetPurchaseDetails";
            }
            else
            {

                //BindOrganizationDropDown();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New AssetPurchaseDetails";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            assetPurchaseDetailsFormUI.CreatedBy = SessionContext.UserGuid;
            assetPurchaseDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            assetPurchaseDetailsFormUI.Tbl_AssetPurchaseId = txtAssetPurchaseGuid.Text;
            assetPurchaseDetailsFormUI.Tbl_PONumberId = txtPONumberGuid.Text;
            assetPurchaseDetailsFormUI.Tbl_AssetId = txtAssetGuid.Text;
            assetPurchaseDetailsFormUI.UOM = txtUOM.Text;
            assetPurchaseDetailsFormUI.Tbl_LocationId = txtLocationGuid.Text;
            assetPurchaseDetailsFormUI.Description = txtDescription.Text;
            assetPurchaseDetailsFormUI.QuantityOrdered =Convert.ToDecimal(txtQuantityOrdered.Text); 
            assetPurchaseDetailsFormUI.QuantityShipped =Convert.ToDecimal(txtQuantityShipped.Text);
            assetPurchaseDetailsFormUI.QuantityInvoiced = Convert.ToDecimal(txtQuantityInvoiced.Text);
            assetPurchaseDetailsFormUI.PreviouslyInvoiced = Convert.ToDecimal(txtPreviouslyInvoiced.Text);
            assetPurchaseDetailsFormUI.PreviouslyShipped = Convert.ToDecimal(txtPreviouslyShipped.Text);
            assetPurchaseDetailsFormUI.UnitCost = Convert.ToDecimal(txtUnitCost.Text);
            assetPurchaseDetailsFormUI.ExtendedCost = Convert.ToDecimal(txtExtendedCost.Text);

            /*
             fields Parameter
             */

            if (assetPurchaseDetailsFormBAL.AddAssetPurchaseDetails(assetPurchaseDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Assets_AssetPurchaseDetails_AssetPurchaseDetailsForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetPurchaseDetails_AssetPurchaseDetailsForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            assetPurchaseDetailsFormUI.ModifiedBy = SessionContext.UserGuid;
            assetPurchaseDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            assetPurchaseDetailsFormUI.Tbl_AssetPurchaseDetailsId = Request.QueryString["AssetPurchaseDetailsId"];
            assetPurchaseDetailsFormUI.Tbl_AssetPurchaseId = txtAssetPurchaseGuid.Text;
            assetPurchaseDetailsFormUI.Tbl_PONumberId = txtPONumberGuid.Text;
            assetPurchaseDetailsFormUI.Tbl_AssetId = txtAssetGuid.Text;
            assetPurchaseDetailsFormUI.UOM = txtUOM.Text;
            assetPurchaseDetailsFormUI.Tbl_LocationId = txtLocationGuid.Text;
            assetPurchaseDetailsFormUI.Description = txtDescription.Text;
            assetPurchaseDetailsFormUI.QuantityOrdered = Convert.ToDecimal(txtQuantityOrdered.Text);
            assetPurchaseDetailsFormUI.QuantityShipped = Convert.ToDecimal(txtQuantityShipped.Text);
            assetPurchaseDetailsFormUI.QuantityInvoiced = Convert.ToDecimal(txtQuantityInvoiced.Text);
            assetPurchaseDetailsFormUI.PreviouslyInvoiced = Convert.ToDecimal(txtPreviouslyInvoiced.Text);
            assetPurchaseDetailsFormUI.UnitCost = Convert.ToDecimal(txtUnitCost.Text);
            assetPurchaseDetailsFormUI.ExtendedCost = Convert.ToDecimal(txtExtendedCost.Text);
            /*
               fields Parameter
               */

            if (assetPurchaseDetailsFormBAL.UpdateAssetPurchaseDetails(assetPurchaseDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Assets_AssetPurchaseDetails_AssetPurchaseDetailsForm.CS";
            logExcpUIobj.RecordId = assetPurchaseDetailsFormUI.Tbl_AssetPurchaseDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetPurchaseDetails_AssetPurchaseDetailsForm : btnUpdate_Click] An error occured in the processing of Record Id : " + assetPurchaseDetailsFormUI.Tbl_AssetPurchaseDetailsId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            assetPurchaseDetailsFormUI.Tbl_AssetPurchaseDetailsId = Request.QueryString["AssetPurchaseDetailsId"];

            if (assetPurchaseDetailsFormBAL.DeleteAssetPurchaseDetails(assetPurchaseDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Assets_AssetPurchaseDetails_AssetPurchaseDetailsForm.CS";
            logExcpUIobj.RecordId = assetPurchaseDetailsFormUI.Tbl_AssetPurchaseDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetPurchaseDetails_AssetPurchaseDetailsForm : btnDelete_Click] An error occured in the processing of Record Id : " + assetPurchaseDetailsFormUI.Tbl_AssetPurchaseDetailsId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetPurchaseDetailsList.aspx");
    }

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

    #region PONumber Search
    protected void btnPONumberSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPONumberSearch.Visible = false;
        btnHtmlPONumberClose.Visible = true;
        SearchPONumberList();
    }
    protected void btnClearPONumberSearch_Click(object sender, EventArgs e)
    {
        BindPONumberList();
        gvPONumberSearch.Visible = true;
        btnHtmlPONumberSearch.Visible = true;
        btnHtmlPONumberClose.Visible = false;
        txtPONumberSearch.Text = "";
        txtPONumberSearch.Focus();
    }
    protected void btnPONumberRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPONumberList();
    }
    #endregion PONumber Search

    #region AssetPurchase Search
    protected void btnAssetPurchaseSearch_Click(object sender, EventArgs e)
    {
        btnHtmlAssetPurchaseSearch.Visible = false;
        btnHtmlAssetPurchaseClose.Visible = true;
        SearchAssetPurchasetList();
    }
    protected void btnClearAssetPurchaseSearch_Click(object sender, EventArgs e)
    {
        BindAssetPurchaseList();
        gvAssetPurchaseSearch.Visible = true;
        btnHtmlAssetPurchaseSearch.Visible = true;
        btnHtmlAssetPurchaseClose.Visible = false;
        txtAssetPurchaseSearch.Text = "";
        txtAssetPurchaseSearch.Focus();
    }
    protected void btnAssetPurchaseRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindAssetPurchaseList();
    }
    #endregion Asset Search

    #region back to Audit History
    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Finance/Asset_Accounting/Disposal_of_Assets/AssetDisposalDetailsForm.aspx";
        string recordId = Request.QueryString["AssetPurchaseDetailsId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }
    #endregion 

    #endregion Events

    #region Methods
    private void FillForm(AssetPurchaseDetailsFormUI assetPurchaseDetailsFormUI)
    {
        try
        {
            DataTable dtb = assetPurchaseDetailsFormBAL.GetAssetPurchaseDetailsListById(assetPurchaseDetailsFormUI);

            if (dtb.Rows.Count > 0)
            {
             
                txtAssetPurchaseGuid.Text=dtb.Rows[0]["tbl_AssetPurchaseId"].ToString();
                txtAssetPurchase.Text = dtb.Rows[0]["tbl_AssetPurchase"].ToString();
                txtPONumberGuid.Text= dtb.Rows[0]["tbl_POId"].ToString();
                txtPONumber.Text= dtb.Rows[0]["tbl_PO"].ToString();
                txtAsset.Text = dtb.Rows[0]["tbl_Asset"].ToString();
                txtAssetGuid.Text= dtb.Rows[0]["tbl_AssetId"].ToString();
                txtUOM.Text= dtb.Rows[0]["UOM"].ToString();
                 txtLocationGuid.Text= dtb.Rows[0]["tbl_LocationId"].ToString();
                txtLocation.Text= dtb.Rows[0]["tbl_Location"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                txtQuantityOrdered.Text= dtb.Rows[0]["QuantityOrdered"].ToString();
                txtQuantityShipped.Text = dtb.Rows[0]["QuantityShipped"].ToString();
                txtQuantityInvoiced.Text= dtb.Rows[0]["QuantityInvoiced"].ToString();
                txtPreviouslyInvoiced.Text= dtb.Rows[0]["PreviouslyShipped"].ToString();
                txtPreviouslyShipped.Text=dtb.Rows[0]["PreviouslyInvoiced"].ToString();
                txtUnitCost.Text= dtb.Rows[0]["UnitCost"].ToString();
                txtExtendedCost.Text= dtb.Rows[0]["ExtendedCost"].ToString();
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
            logExcpUIobj.ResourceName = "Assets_AssetPurchaseDetails_AssetPurchaseDetailsForm.CS";
            logExcpUIobj.RecordId = assetPurchaseDetailsFormUI.Tbl_AssetPurchaseDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetPurchaseDetails_AssetPurchaseDetailsForm : FillForm] An error occured in the processing of Record Id : " + assetPurchaseDetailsFormUI.Tbl_AssetPurchaseDetailsId + ". Details : [" + exp.ToString() + "]");
        }
    }

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
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_Asset_AssetForm : SearchAssetList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_Asset_AssetForm : BindAssetList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Asset search

    #region PONunber Search
    private void SearchPONumberList()
    {
        try
        {
            POListUI pONumberListUI = new POListUI();
            pONumberListUI.Search = txtPONumberSearch.Text;
            DataTable dtb = pOListBAL.GetPOListBySearchParameters(pONumberListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPONumberSearch.DataSource = dtb;
                gvPONumberSearch.DataBind();
                divPONumberSearchError.Visible = false;
            }
            else
            {
                divPONumberSearchError.Visible = true;
                lblPONumberSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPONumberSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "Assets_AssetPurchaseDetails_AssetPurchaseDetailsForm()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetPurchaseDetails_AssetPurchaseDetailsForm : SearchPONumberList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindPONumberList()
    {
        try
        {
            DataTable dtb = pOListBAL.GetPOList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPONumberSearch.DataSource = dtb;
                gvPONumberSearch.DataBind();
                divPONumberSearchError.Visible = false;
            }
            else
            {
                divPONumberSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPONumberSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPONumberList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_Asset_AssetForm : BindAssetList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Asset search

    #region AssetPurchase Search
    private void SearchAssetPurchasetList()
    {
        try
        {
            AssetPurchaseListUI assetPurchasetListUI = new AssetPurchaseListUI();
            assetPurchasetListUI.Search = txtAssetSearch.Text;
            DataTable dtb = assetPurchaseListBAL.GetAssetPurchaseListSearchParameters(assetPurchasetListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAssetPurchaseSearch.DataSource = dtb;
                gvAssetPurchaseSearch.DataBind();
                divAssetPurchaseSearchError.Visible = false;
            }
            else
            {
                divAssetPurchaseSearchError.Visible = true;
                lblAssetPurchaseSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAssetPurchaseSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchAssetPurchaseList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_Asset_AssetForm : SearchAssetList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindAssetPurchaseList()
    {
        try
        {
            DataTable dtb = assetListBAL.GetAssetList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAssetPurchaseSearch.DataSource = dtb;
                gvAssetPurchaseSearch.DataBind();
                divAssetPurchaseSearchError.Visible = false;
            }
            else
            {
                divAssetPurchaseSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAssetPurchaseSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindAssetPurchaseList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_Asset_AssetForm : BindAssetList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Asset search

    #endregion Methods

   
}
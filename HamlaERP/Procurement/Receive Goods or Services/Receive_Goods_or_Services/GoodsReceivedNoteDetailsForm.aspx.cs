using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDetailsForm : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    GoodsReceivedNoteDetailsFormBAL goodsReceivedNoteDetailsFormBAL = new GoodsReceivedNoteDetailsFormBAL();
    GoodsReceivedNoteDetailsFormUI goodsReceivedNoteDetailsFormUI = new GoodsReceivedNoteDetailsFormUI();
    AssetListBAL assetListBAL = new AssetListBAL();
    LocationListBAL locationListBAL = new LocationListBAL();
    GoodsReceivedNoteListBAL goodsReceivedNoteListBAL = new GoodsReceivedNoteListBAL();
    POListBAL pOListBAL = new POListBAL();
    #endregion Data Members

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        GoodsReceivedNoteDetailsFormUI goodsReceivedNoteDetailsFormUI = new GoodsReceivedNoteDetailsFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["GoodsReceivedNoteDetailsId"] != null)
            {
                goodsReceivedNoteDetailsFormUI.Tbl_GoodsReceivedNoteDetailsId = Request.QueryString["GoodsReceivedNoteDetailsId"];
                FillForm(goodsReceivedNoteDetailsFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Goods Received Note Details";
            }
            else
            {
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Goods Received Note Details";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            goodsReceivedNoteDetailsFormUI.CreatedBy = SessionContext.UserGuid;
            goodsReceivedNoteDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            goodsReceivedNoteDetailsFormUI.Tbl_GoodsReceivedNoteId = txtGoodsReceivedNoteGuid.Text;
            goodsReceivedNoteDetailsFormUI.Tbl_POId = txtPOGuid.Text;
            goodsReceivedNoteDetailsFormUI.Tbl_AssetId = txtAssetGuid.Text;
            goodsReceivedNoteDetailsFormUI.UOM = txtUOM.Text;
            goodsReceivedNoteDetailsFormUI.Tbl_LocationId = txtLocationGuid.Text;
            goodsReceivedNoteDetailsFormUI.Description = txtDescription.Text;
            goodsReceivedNoteDetailsFormUI.QuantityOrdered= Decimal.Parse(txtQuantityOrdered.Text);
            goodsReceivedNoteDetailsFormUI.QuantityShipped = Decimal.Parse(txtQuantityShipped.Text);
            goodsReceivedNoteDetailsFormUI.QuantityInvoiced = Decimal.Parse(txtQuantityInvoiced.Text);
            goodsReceivedNoteDetailsFormUI.PreviouslyShipped = Decimal.Parse(txtPreviouslyShipped.Text);
            goodsReceivedNoteDetailsFormUI.PreviouslyInvoiced = Decimal.Parse(txtPreviouslyInvoiced.Text);
            goodsReceivedNoteDetailsFormUI.UnitCost= Decimal.Parse(txtUnitCost.Text);
            goodsReceivedNoteDetailsFormUI.ExtendedCost = Decimal.Parse(txtExtendedCost.Text);
            if (goodsReceivedNoteDetailsFormBAL.AddGoodsReceivedNoteDetails(goodsReceivedNoteDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDetailsForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDetailsForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            goodsReceivedNoteDetailsFormUI.ModifiedBy = SessionContext.UserGuid;
            goodsReceivedNoteDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            goodsReceivedNoteDetailsFormUI.Tbl_GoodsReceivedNoteDetailsId = Request.QueryString["GoodsReceivedNoteDetailsId"];
            goodsReceivedNoteDetailsFormUI.Tbl_GoodsReceivedNoteId = txtGoodsReceivedNoteGuid.Text;
            goodsReceivedNoteDetailsFormUI.Tbl_POId = txtPOGuid.Text;
            goodsReceivedNoteDetailsFormUI.Tbl_AssetId = txtAssetGuid.Text;
            goodsReceivedNoteDetailsFormUI.UOM = txtUOM.Text;
            goodsReceivedNoteDetailsFormUI.Tbl_LocationId = txtLocationGuid.Text;
            goodsReceivedNoteDetailsFormUI.Description = txtDescription.Text;
            goodsReceivedNoteDetailsFormUI.QuantityOrdered = Decimal.Parse(txtQuantityOrdered.Text);
            goodsReceivedNoteDetailsFormUI.QuantityShipped = Decimal.Parse(txtQuantityShipped.Text);
            goodsReceivedNoteDetailsFormUI.QuantityInvoiced = Decimal.Parse(txtQuantityInvoiced.Text);
            goodsReceivedNoteDetailsFormUI.PreviouslyShipped = Decimal.Parse(txtPreviouslyShipped.Text);
            goodsReceivedNoteDetailsFormUI.PreviouslyInvoiced = Decimal.Parse(txtPreviouslyInvoiced.Text);
            goodsReceivedNoteDetailsFormUI.UnitCost = Decimal.Parse(txtUnitCost.Text);
            goodsReceivedNoteDetailsFormUI.ExtendedCost = Decimal.Parse(txtExtendedCost.Text);
            if (goodsReceivedNoteDetailsFormBAL.UpdateGoodsReceivedNoteDetails(goodsReceivedNoteDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDetailsForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDetailsForm : btnUpdate_Click] An error occured in the processing of Record Id : " + goodsReceivedNoteDetailsFormUI.Tbl_GoodsReceivedNoteDetailsId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            goodsReceivedNoteDetailsFormUI.Tbl_GoodsReceivedNoteDetailsId = Request.QueryString["GoodsReceivedNoteDetailsId"];

            if (goodsReceivedNoteDetailsFormBAL.DeleteGoodsReceivedNoteDetails(goodsReceivedNoteDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDetailsForm.CS";
            logExcpUIobj.RecordId = goodsReceivedNoteDetailsFormUI.Tbl_GoodsReceivedNoteDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDetailsForm : btnDelete_Click] An error occured in the processing of Record Id : " + goodsReceivedNoteDetailsFormUI.Tbl_GoodsReceivedNoteDetailsId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("GoodsReceivedNoteDetailsList.aspx");
    }


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
    #endregion PO Search
    #region GoodsReceivedNote Search
    protected void btnGoodsReceivedNoteSearch_Click(object sender, EventArgs e)
    {
        btnHtmlGoodsReceivedNoteSearch.Visible = false;
        btnHtmlGoodsReceivedNoteClose.Visible = true;
        SearchGoodsReceivedNoteList();
    }
    protected void btnClearGoodsReceivedNoteSearch_Click(object sender, EventArgs e)
    {
        BindGoodsReceivedNoteList();
        gvGoodsReceivedNoteSearch.Visible = true;
        btnHtmlGoodsReceivedNoteSearch.Visible = true;
        btnHtmlGoodsReceivedNoteClose.Visible = false;
        txtGoodsReceivedNoteSearch.Text = "";
        txtGoodsReceivedNoteSearch.Focus();
    }
    protected void btnGoodsReceivedNoteRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindGoodsReceivedNoteList();
    }
    #endregion GoodsReceivedNote Search

    #endregion Events

    #region Methods
    private void FillForm(GoodsReceivedNoteDetailsFormUI goodsReceivedNoteDetailsFormUI)
    {
        try
        {
            DataTable dtb = goodsReceivedNoteDetailsFormBAL.GetGoodsReceivedNoteDetailsListById(goodsReceivedNoteDetailsFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtGoodsReceivedNoteGuid.Text= dtb.Rows[0]["tbl_GoodsReceivedNoteId"].ToString();
                txtGoodsReceivedNote.Text = dtb.Rows[0]["tbl_GoodsReceivedNote"].ToString();
                txtPOGuid.Text = dtb.Rows[0]["tbl_POId"].ToString();
                txtPO.Text = dtb.Rows[0]["tbl_PO"].ToString();
                txtAssetGuid.Text= dtb.Rows[0]["tbl_AssetId"].ToString();
                txtAsset.Text = dtb.Rows[0]["tbl_Asset"].ToString();
                txtUOM.Text= dtb.Rows[0]["UOM"].ToString();
                txtLocationGuid.Text= dtb.Rows[0]["tbl_LocationId"].ToString();
                txtLocation.Text = dtb.Rows[0]["tbl_Location"].ToString();
                txtDescription.Text= dtb.Rows[0]["Description"].ToString();
                txtQuantityOrdered.Text= dtb.Rows[0]["QuantityOrdered"].ToString();
                txtQuantityInvoiced.Text= dtb.Rows[0]["QuantityInvoiced"].ToString();
                txtQuantityShipped.Text = dtb.Rows[0]["QuantityShipped"].ToString();
                txtPreviouslyShipped.Text = dtb.Rows[0]["PreviouslyShipped"].ToString();
                txtPreviouslyInvoiced.Text = dtb.Rows[0]["PreviouslyInvoiced"].ToString();
                txtUnitCost.Text = dtb.Rows[0]["UnitCost"].ToString();
                txtExtendedCost.Text = dtb.Rows[0]["ExtendedCost"].ToString();
}
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "FillForm()";
            logExcpUIobj.ResourceName = "Asset_GoodsReceivedNoteDetailsForm.CS";
            logExcpUIobj.RecordId = this.goodsReceivedNoteDetailsFormUI.Tbl_GoodsReceivedNoteDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Asset_GoodsReceivedNoteDetailsForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

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
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDetailsForm : SearchAssetList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDetailsForm : BindAssetList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Asset search
   
    #region  Location Search
    public void BindLocationList()
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
                lblLocationSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvLocationSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "Search_SearchLocation.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Search_SearchLocation : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void SearchLocationList()
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
                gvLocationSearch.Visible = true;
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
            logExcpUIobj.ResourceName = "PhysicalLocation_PhysicalLocationForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PhysicalLocation_PhysicalLocationForm : SearchLocationList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Location Search

    #region GoodsReceivedNote Search
    private void SearchGoodsReceivedNoteList()
    {
        try
        {
            GoodsReceivedNoteListUI goodsReceivedNoteListUI = new GoodsReceivedNoteListUI();
            goodsReceivedNoteListUI.Search = txtGoodsReceivedNoteSearch.Text;
            DataTable dtb = goodsReceivedNoteListBAL.GetGoodsReceivedNoteListBySearchParameters(goodsReceivedNoteListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGoodsReceivedNoteSearch.DataSource = dtb;
                gvGoodsReceivedNoteSearch.DataBind();
                divGoodsReceivedNoteSearchError.Visible = false;
                gvGoodsReceivedNoteSearch.Visible = true;
            }
            else
            {
                divGoodsReceivedNoteSearchError.Visible = true;
                lblGoodsReceivedNoteSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGoodsReceivedNoteSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchGoodsReceivedNoteList()";
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDetailsForm : SearchGoodsReceivedNoteList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindGoodsReceivedNoteList()
    {
        try
        {
            DataTable dtb = goodsReceivedNoteListBAL.GetGoodsReceivedNoteList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGoodsReceivedNoteSearch.DataSource = dtb;
                gvGoodsReceivedNoteSearch.DataBind();
                divGoodsReceivedNoteSearchError.Visible = false;
            }
            else
            {
                divGoodsReceivedNoteSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGoodsReceivedNoteSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindGoodsReceivedNoteList()";
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDetailsForm : BindGoodsReceivedNoteList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  GoodsReceivedNote search

    #region PO Search
    private void SearchPOList()
    {
        try
        {
            POListUI pOListUI = new POListUI();
            pOListUI.Search = txtPOSearch.Text;
            DataTable dtb = pOListBAL.GetPOListBySearchParameters(pOListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPOSearch.DataSource = dtb;
                gvPOSearch.DataBind();
                divPOSearchError.Visible = false;
                gvPOSearch.Visible = true;
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
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDetailsForm : SearchPOList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDetailsForm : BindPOList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  PO search
    #endregion Methods

}
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferForm : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    AssetTransferFormBAL assetTransferFormBAL = new AssetTransferFormBAL();
    AssetTransferFormUI assetTransferFormUI = new AssetTransferFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    AssetTransferListBAL assetTransferListBAL = new AssetTransferListBAL();
    BatchListBAL batchListBAL = new BatchListBAL();
    BatchListUI batchListUI = new BatchListUI();
    LocationListBAL locationListBAL = new LocationListBAL();


    #endregion Data Members

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        AssetTransferFormUI assetTransferFormUI = new AssetTransferFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["AssetTransferId"] != null)
            {
                assetTransferFormUI.Tbl_AssetTransferId = Request.QueryString["AssetTransferId"];

                BindDocumentTypeDropDownList();


                FillForm(assetTransferFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Asset Transfer";
            }
            else
            {
                BindDocumentTypeDropDownList();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Asset Transfer";
            }
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            assetTransferFormUI.CreatedBy = SessionContext.UserGuid;
            assetTransferFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            assetTransferFormUI.opt_DocumentType= Convert.ToInt16(ddlOpt_DocumentType.SelectedValue);
            assetTransferFormUI.Number = txtNumber.Text;
            assetTransferFormUI.Tbl_BatchId = txtBatchIdGuid.Text;
            assetTransferFormUI.Date = Convert.ToDateTime(txtDate.Text);
            assetTransferFormUI.Tbl_LocationId_From = txtLocation_FromGuid.Text;
            assetTransferFormUI.Tbl_LocationId_To = txtLocation_ToGuid.Text;

            if (assetTransferFormBAL.AddAssetTransfer(assetTransferFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            assetTransferFormUI.ModifiedBy = SessionContext.UserGuid;
            assetTransferFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            assetTransferFormUI.Tbl_AssetTransferId = Request.QueryString["AssetTransferId"];

            assetTransferFormUI.opt_DocumentType = Convert.ToInt16(ddlOpt_DocumentType.SelectedValue);
            assetTransferFormUI.Number = txtNumber.Text;
            assetTransferFormUI.Tbl_BatchId = txtBatchIdGuid.Text;
            assetTransferFormUI.Date = Convert.ToDateTime(txtDate.Text);
            assetTransferFormUI.Tbl_LocationId_From = txtLocation_FromGuid.Text;
            assetTransferFormUI.Tbl_LocationId_To = txtLocation_ToGuid.Text;




            if (assetTransferFormBAL.UpdateAssetTransfer(assetTransferFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferForm : btnUpdate_Click] An error occured in the processing of Record Id : " + assetTransferFormUI.Tbl_AssetTransferId + ".  Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            assetTransferFormUI.Tbl_AssetTransferId = Request.QueryString["AssetTransferId"];

            if (assetTransferFormBAL.DeleteAssetTransfer(assetTransferFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferForm.CS";
            logExcpUIobj.RecordId = assetTransferFormUI.Tbl_AssetTransferId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferForm : btnDelete_Click] An error occured in the processing of Record Id : " + assetTransferFormUI.Tbl_AssetTransferId + ". Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetTransferList.aspx");
    }

    #region Batch Search
    protected void btnBatchSearch_Click(object sender, EventArgs e)
    {
        btnHtmlBatchSearch.Visible = false;
        btnHtmlBatchClose.Visible = true;
        SearchBatchList();
    }
    protected void btnClearBatchSearch_Click(object sender, EventArgs e)
    {
        BindBatchList();
        gvBatchSearch.Visible = true;
        btnHtmlBatchSearch.Visible = true;
        btnHtmlBatchClose.Visible = false;
        txtBatchSearch.Text = "";
        txtBatchSearch.Focus();
    }
    protected void btnBatchRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindBatchList();
    }
    #endregion Batch Search

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
    private void BindDocumentTypeDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_AssetTransfer";
            optionSetListUI.OptionSetName = "opt_DocumentType";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlOpt_DocumentType.DataSource = dtb;
                ddlOpt_DocumentType.DataBind();
                ddlOpt_DocumentType.DataTextField = "OptionSetLable";
                ddlOpt_DocumentType.DataValueField = "OptionSetValue";
                ddlOpt_DocumentType.DataBind();
            }
            else
            {
                ddlOpt_DocumentType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindDocumentTypeDropDownList()";
            logExcpUIobj.ResourceName = "Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferForm : BindDocumentTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void FillForm(AssetTransferFormUI assetTransferFormUI)
    {
        try
        {
            DataTable dtb = assetTransferFormBAL.GetAssetTransferListById(assetTransferFormUI);

            if (dtb.Rows.Count > 0)
            {                       
                ddlOpt_DocumentType.SelectedValue = dtb.Rows[0]["DocumentType"].ToString();
                txtNumber.Text = dtb.Rows[0]["Number"].ToString();
                txtBatchIdGuid.Text= dtb.Rows[0]["tbl_BatchId"].ToString();
                txtBatchId.Text= dtb.Rows[0]["tbl_Batch"].ToString();
                txtDate.Text = dtb.Rows[0]["Date"].ToString();
                txtLocation_FromGuid.Text= dtb.Rows[0]["tbl_LocationId_From"].ToString();
                txtLocationId_From.Text= dtb.Rows[0]["tbl_Location_From"].ToString();
                txtLocation_ToGuid.Text= dtb.Rows[0]["tbl_LocationId_To"].ToString();
                txtLocationId_To.Text= dtb.Rows[0]["tbl_Location_To"].ToString();
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
            logExcpUIobj.ResourceName = "Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferForm.CS";
            logExcpUIobj.RecordId = assetTransferFormUI.Tbl_AssetTransferId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region Batch Search    
    private void SearchBatchList()
    {
        try
        {
            BatchListUI batchListUI = new BatchListUI();
            batchListUI.Search = txtBatchSearch.Text;


            DataTable dtb = batchListBAL.GetBatchListBySearchParameters(batchListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvBatchSearch.DataSource = dtb;
                gvBatchSearch.DataBind();
                divBatchSearchError.Visible = false;
            }
            else
            {
                divBatchSearchError.Visible = true;
                lblBatchSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvBatchSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchBatchList()";
            logExcpUIobj.ResourceName = "Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferForm : SearchBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindBatchList()
    {
        try
        {
            DataTable dtb = batchListBAL.GetBatchList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvBatchSearch.DataSource = dtb;
                gvBatchSearch.DataBind();
                divBatchSearchError.Visible = false;

            }
            else
            {
                divBatchSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvBatchSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindBatchList()";
            logExcpUIobj.ResourceName = "Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferForm : BindBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Batch Search

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

    #endregion

}
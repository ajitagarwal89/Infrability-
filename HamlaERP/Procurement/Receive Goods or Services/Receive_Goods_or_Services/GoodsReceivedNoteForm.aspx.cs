using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm : System.Web.UI.Page
{
    #region Data Members

    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    GoodsReceivedNoteFormBAL goodsReceivedNoteFormBAL = new GoodsReceivedNoteFormBAL();
    GoodsReceivedNoteFormUI goodsReceivedNoteFormUI = new GoodsReceivedNoteFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    BatchListBAL batchListBAL = new BatchListBAL();
    SupplierListBAL supplierListBAL = new SupplierListBAL();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    PODetailsListBAL pODetailsListBAL = new PODetailsListBAL();
    PODetailsListUI pODetailsUI = new PODetailsListUI();
    GoodsReceivedNoteDetailsFormBAL goodsReceivedNoteDetailsFormBAL = new GoodsReceivedNoteDetailsFormBAL();
    GoodsReceivedNoteDetailsFormUI goodsReceivedNoteDetailsFormUI = new GoodsReceivedNoteDetailsFormUI();
    POListBAL pOListBAL = new POListBAL();
    POListUI pOListUI = new POListUI();
    GoodsReceivedNoteListBAL goodsReceivedNoteListBAL = new GoodsReceivedNoteListBAL();
    GoodsReceivedNoteDetailsListBAL goodsReceivedNoteDetailsListBAL = new GoodsReceivedNoteDetailsListBAL();
    #endregion Data Members

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        GoodsReceivedNoteFormUI goodsReceivedNoteFormUI = new GoodsReceivedNoteFormUI();
        if (!Page.IsPostBack)


        {

            if (Request.QueryString["POId"] != null)
            {

                BindReceivedTypeDropDownList();
            
                pOListUI.Tbl_POId = Request.QueryString["POId"];
                txtPOGuid.Text = Request.QueryString["POId"];
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;

                btnGoodsReceivedNoteDetails.Visible = false;
                divGoodsReceivedNoteDetails.Visible = false;
                btnSaveGoodsReceivedNoteDetails.Visible = false;
                BindPO();

            }
            else if (Request.QueryString["GoodsReceivedNoteId"] != null)
            {
                BindReceivedTypeDropDownList();
                goodsReceivedNoteFormUI.Tbl_POId = SessionContext.tbl_POId;
                goodsReceivedNoteFormUI.Tbl_GoodsReceivedNoteId = Request.QueryString["GoodsReceivedNoteId"];
                BindReceivedTypeDropDownList();
                FillForm(goodsReceivedNoteFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnPost.Visible = true;
                btnGoodsReceivedNoteDetails.Visible = true;
                lblHeading.Text = "Update Good Received Note";
                divGoodsReceivedNoteDetails.Visible = false;
                btnGoodsReceivedNoteDetails.Visible = false;
                btnSaveGoodsReceivedNoteDetails.Visible = false;
                BindPODetails();
            }


            else
            {
                BindReceivedTypeDropDownList();
               // divPO.Visible = false;
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnPost.Visible = false;
                btnSaveGoodsReceivedNoteDetails.Visible = false;
                btnGoodsReceivedNoteDetails.Visible = false;
                lblHeading.Text = "Add New Good Received Note";
            }
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            goodsReceivedNoteFormUI.CreatedBy = SessionContext.UserGuid;
            goodsReceivedNoteFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            goodsReceivedNoteFormUI.Tbl_POId = txtPOGuid.Text;
            goodsReceivedNoteFormUI.Tbl_BatchId = txtBatchGuid.Text;
            goodsReceivedNoteFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            goodsReceivedNoteFormUI.Tbl_SupplierId = txtSupplierGuid.Text;
            goodsReceivedNoteFormUI.opt_ReceivedType = int.Parse(ddlOpt_ReceivedType.SelectedValue.ToString());
            goodsReceivedNoteFormUI.GoodsReceivedNoteNumber = txtGoodsReceivedNoteNumber.Text;
            goodsReceivedNoteFormUI.SupplierDocumentNumber = txtSupplierDocumentNumber.Text;
            goodsReceivedNoteFormUI.Date = DateTime.Parse(txtDate.Text);
            goodsReceivedNoteFormUI.SubTotal = Decimal.Parse(txtSubTotal.Text);
            goodsReceivedNoteFormUI.TradeDiscount = Decimal.Parse(txtTradeDiscount.Text);
            goodsReceivedNoteFormUI.Freight = Decimal.Parse(txtFreight.Text);
            goodsReceivedNoteFormUI.Miscellaneous = Decimal.Parse(txtMiscellaneous.Text);
            goodsReceivedNoteFormUI.Total = Decimal.Parse(txtTotal.Text);
            if (goodsReceivedNoteFormBAL.AddGoodsReceivedNote(goodsReceivedNoteFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        GoodsReceivedNoteFormUI goodsReceivedNoteFormUI = new GoodsReceivedNoteFormUI();
        try
        {
         
            goodsReceivedNoteFormUI.ModifiedBy = SessionContext.UserGuid;
            goodsReceivedNoteFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            goodsReceivedNoteFormUI.Tbl_GoodsReceivedNoteId = Request.QueryString["GoodsReceivedNoteId"];
            goodsReceivedNoteFormUI.Tbl_POId = txtPOGuid.Text;
            goodsReceivedNoteFormUI.Tbl_BatchId = txtBatchGuid.Text;
            goodsReceivedNoteFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            goodsReceivedNoteFormUI.Tbl_SupplierId = txtSupplierGuid.Text;
            goodsReceivedNoteFormUI.opt_ReceivedType = int.Parse(ddlOpt_ReceivedType.SelectedValue.ToString());
            goodsReceivedNoteFormUI.GoodsReceivedNoteNumber = txtGoodsReceivedNoteNumber.Text;
            goodsReceivedNoteFormUI.SupplierDocumentNumber = txtSupplierDocumentNumber.Text;
            goodsReceivedNoteFormUI.Date = DateTime.Parse(txtDate.Text);
            goodsReceivedNoteFormUI.SubTotal = Decimal.Parse(txtSubTotal.Text);
            goodsReceivedNoteFormUI.TradeDiscount = Decimal.Parse(txtTradeDiscount.Text);
            goodsReceivedNoteFormUI.Freight = Decimal.Parse(txtFreight.Text);
            goodsReceivedNoteFormUI.Miscellaneous = Decimal.Parse(txtMiscellaneous.Text);
            goodsReceivedNoteFormUI.Total = Decimal.Parse(txtTotal.Text);
            if (goodsReceivedNoteFormBAL.UpdateGoodsReceivedNote(goodsReceivedNoteFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm : btnUpdate_Click] An error occured in the processing of Record Id : " + goodsReceivedNoteFormUI.Tbl_GoodsReceivedNoteId + ".  Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            goodsReceivedNoteFormUI.Tbl_GoodsReceivedNoteId = Request.QueryString["GoodsReceivedNoteId"];
            if (goodsReceivedNoteFormBAL.DeleteGoodsReceivedNote(goodsReceivedNoteFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm.CS";
            logExcpUIobj.RecordId = goodsReceivedNoteFormUI.Tbl_GoodsReceivedNoteId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm : btnDelete_Click] An error occured in the processing of Record Id : " + goodsReceivedNoteFormUI.Tbl_GoodsReceivedNoteId + ". Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnPost_Click(object sender, EventArgs e)
    {
        try
        {
            bool isPosted = true;
            goodsReceivedNoteFormUI.ModifiedBy = SessionContext.UserGuid;
            goodsReceivedNoteFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            goodsReceivedNoteFormUI.Tbl_GoodsReceivedNoteId = Request.QueryString["GoodsReceivedNoteId"];
            goodsReceivedNoteFormUI.IsPosted = isPosted;

            if (goodsReceivedNoteFormBAL.UpdatePostingGoodsReceivedNote(goodsReceivedNoteFormUI) == 1)
            {
                divSuccess.Visible = true;
                lblSuccess.Text = Resources.GlobalResource.msgRecordPostedSuccessfully;
                btnPost.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotPostRecord;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnPost_Click()";
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm.CS";
            logExcpUIobj.RecordId = goodsReceivedNoteFormUI.Tbl_GoodsReceivedNoteId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm : btnPost_Click] An error occured in the processing of Record Id : " + goodsReceivedNoteFormUI.Tbl_GoodsReceivedNoteId + ".  Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("GoodsReceivedNoteList.aspx");
    }

    protected void btnGoodsReceivedNoteDetails_Click(object sender, EventArgs e)
    {
        string pOId = SessionContext.tbl_POId;
        string goodsReceivedNoteId = Request.QueryString["GoodsReceivedNoteId"];
       
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

    #region Supplier Search
    protected void btnSupplierSearch_Click(object sender, EventArgs e)
    {
        btnHtmlSupplierSearch.Visible = false;
        btnHtmlSupplierClose.Visible = true;
        SearchSupplierList();
    }
    protected void btnClearSupplierSearch_Click(object sender, EventArgs e)
    {
        BindSupplierList();
        gvSupplierSearch.Visible = true;
        btnHtmlSupplierSearch.Visible = true;
        btnHtmlSupplierClose.Visible = false;
        txtSupplierSearch.Text = "";
        txtSupplierSearch.Focus();
    }
    protected void btnSupplierRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindSupplierList();
    }
    #endregion Supplier Search

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

    protected void gvData_SelectedIndexChanged(object sender, EventArgs e)
    {

        btnSave.Visible = false;
        btnClear.Visible = false;
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        divGoodsReceivedNote.Visible = false;
        btnSaveGoodsReceivedNoteDetails.Visible = true;
        divGoodsReceivedNoteDetails.Visible = true;
        PODetailsListUI pODetailsListUI = new PODetailsListUI();
        pODetailsListUI.Tbl_POId = SessionContext.tbl_POId;
        DataTable dtb = pODetailsListBAL.GetPODetailsListBySearchParameters(pODetailsListUI);

        if (dtb.Rows.Count > 0 && dtb != null)
        {
            BindGoodsReceivedNote();
            txtPODetailsGuid.Text = dtb.Rows[0]["tbl_PODetailsId"].ToString();
            txtPODetails.Text = dtb.Rows[0]["tbl_PO"].ToString();
            txtPOIdGuid.Text = dtb.Rows[0]["tbl_POId"].ToString();
            txtPOId.Text = dtb.Rows[0]["tbl_PO"].ToString();
            txtAssetGuid.Text = dtb.Rows[0]["tbl_AssetId_FixedAsset"].ToString();
            txtAsset.Text = dtb.Rows[0]["FixedAsset"].ToString();
            txtUOM.Text = dtb.Rows[0]["UOM"].ToString();
            txtLocationGuid.Text = dtb.Rows[0]["tbl_LocationId"].ToString();
            txtLocation.Text = dtb.Rows[0]["tbl_Location"].ToString();
            txtDescription.Text = dtb.Rows[0]["Description"].ToString();
            txtQuantityOrdered.Text = dtb.Rows[0]["QuantityOrdered"].ToString();
            txtUnitCost.Text = dtb.Rows[0]["UnitCost"].ToString();
            txtExtendedCost.Text = dtb.Rows[0]["ExtendedCost"].ToString();


        }
        else
        {
            divError.Visible = true;
            lblError.Text = Resources.GlobalResource.msgNoRecordFound;

        }

    }

    private void BindGoodsReceivedNote()
    {
        try
        {
            GoodsReceivedNoteListUI goodsReceivedNoteListUI = new GoodsReceivedNoteListUI();
            goodsReceivedNoteListUI.Tbl_GoodsReceivedNoteId = Request.QueryString["GoodsReceivedNoteId"];
            DataTable dtb = goodsReceivedNoteListBAL.GetGoodsReceivedNoteListById(goodsReceivedNoteListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {

                txtGoodsReceivedNoteGuid.Text = dtb.Rows[0]["tbl_GoodsReceivedNoteId"].ToString();
                txtGoodsReceivedNote.Text = dtb.Rows[0]["GoodsReceivedNoteNumber"].ToString();

            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;

            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindGoodsReceivedNote()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm : BindPODetaild] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnSaveGoodsReceivedNoteDetails_Click(object sender, EventArgs e)
    {
        try
        {

            goodsReceivedNoteDetailsFormUI.CreatedBy = SessionContext.UserGuid;
            goodsReceivedNoteDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            goodsReceivedNoteDetailsFormUI.Tbl_GoodsReceivedNoteId = txtGoodsReceivedNoteGuid.Text;
            goodsReceivedNoteDetailsFormUI.tbl_PODetailsId = txtPODetailsGuid.Text;
            goodsReceivedNoteDetailsFormUI.Tbl_POId = txtPOIdGuid.Text;
            goodsReceivedNoteDetailsFormUI.Tbl_AssetId = txtAssetGuid.Text;
            goodsReceivedNoteDetailsFormUI.UOM = txtUOM.Text;
            goodsReceivedNoteDetailsFormUI.Tbl_LocationId = txtLocationGuid.Text;
            goodsReceivedNoteDetailsFormUI.Description = txtDescription.Text;
            goodsReceivedNoteDetailsFormUI.QuantityOrdered = Decimal.Parse(txtQuantityOrdered.Text);
            goodsReceivedNoteDetailsFormUI.QuantityShipped = Decimal.Parse(txtQuantityShipped.Text);
            goodsReceivedNoteDetailsFormUI.QuantityInvoiced = 0;
            goodsReceivedNoteDetailsFormUI.PreviouslyShipped = 0;
            goodsReceivedNoteDetailsFormUI.PreviouslyInvoiced = 0;
            goodsReceivedNoteDetailsFormUI.UnitCost = Decimal.Parse(txtUnitCost.Text);
            goodsReceivedNoteDetailsFormUI.ExtendedCost = Decimal.Parse(txtExtendedCost.Text);
            if (goodsReceivedNoteDetailsFormBAL.AddGoodsReceivedNoteDetails(goodsReceivedNoteDetailsFormUI) == 1)
            {
                divSuccess1.Visible = true;
                divError1.Visible = false;
                lblSuccess1.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearFormDetails();", true);
   
                divGoodsReceivedNoteDetail.Visible = true;
                BindGoodsReceivedNoteDetails();

            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
                divSuccess1.Visible = false;
                divError1.Visible = true;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearFormDetails();", true);
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

  

    protected void txtQuantityShipped_TextChanged(object sender, EventArgs e)
    {
        if (txtQuantityShipped.Text != "" && txtQuantityOrdered.Text != "")
        {
            if (Convert.ToDecimal(txtQuantityShipped.Text) <= Convert.ToDecimal(txtQuantityOrdered.Text))
            {
            }
            else
            {
                txtQuantityShipped.Text = "";
                ScriptManager.RegisterStartupScript(this, GetType(), "alertmsg", "alert('Please Enter Quantity Of Shipped Value less then equal (<=) Quantity Of Ordered ');", true);
            }
        }
        else
            ScriptManager.RegisterStartupScript(this, GetType(), "alertmsg", "alert('Please Enter Quantity Of Shipped Value less then equal (<=) Quantity Of Ordered ');", true);
    }

    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblGoodsReceivedNoteDetail.Text = "Goods Received Note Details";
            GoodsReceivedNoteDetailsListUI goodsReceivedNoteDetailsListUI = new GoodsReceivedNoteDetailsListUI();
            goodsReceivedNoteDetailsListUI.Tbl_GoodsReceivedNoteDetailsId = Request.QueryString["GoodsReceivedNoteDetailsId"];

            DataTable dtb = goodsReceivedNoteDetailsListBAL.GetGoodsReceivedNoteDetailsListBySearchParameters(goodsReceivedNoteDetailsListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
               
                txtPODetailsGuid.Text = dtb.Rows[0]["tbl_PODetailsId"].ToString();
                txtPODetails.Text = dtb.Rows[0]["tbl_PO"].ToString();
                txtGoodsReceivedNoteGuid.Text= dtb.Rows[0]["tbl_GoodsReceivedNoteId"].ToString();
                txtGoodsReceivedNote.Text = dtb.Rows[0]["tbl_GoodsReceivedNote"].ToString();
                txtPOIdGuid.Text = dtb.Rows[0]["tbl_POId"].ToString();
                txtPOId.Text = dtb.Rows[0]["tbl_PO"].ToString();
                txtAssetGuid.Text = dtb.Rows[0]["tbl_AssetId"].ToString();
                txtAsset.Text = dtb.Rows[0]["tbl_Asset"].ToString();
                txtUOM.Text = dtb.Rows[0]["UOM"].ToString();
                txtLocationGuid.Text = dtb.Rows[0]["tbl_LocationId"].ToString();
                txtLocation.Text = dtb.Rows[0]["tbl_Location"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                txtQuantityOrdered.Text = dtb.Rows[0]["QuantityOrdered"].ToString();
                txtQuantityShipped.Text = dtb.Rows[0]["QuantityShipped"].ToString();
                txtUnitCost.Text = dtb.Rows[0]["UnitCost"].ToString();
                txtExtendedCost.Text = dtb.Rows[0]["ExtendedCost"].ToString();
                txtPreviouslyInvoiced.Text= dtb.Rows[0]["PreviouslyInvoiced"].ToString();
                txtPreviouslyShipped.Text= dtb.Rows[0]["PreviouslyShipped"].ToString();
                txtQuantityInvoiced.Text= dtb.Rows[0]["QuantityInvoiced"].ToString();

            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                //gvdetails.Visible = true;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GoodsReceivedNoteDetails()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm : GoodsReceivedNoteDetails] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    #endregion Events

    #region  Methods
    private void BindReceivedTypeDropDownList()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_GoodsReceivedNote";
            optionSetListUI.OptionSetName = "Opt_ReceivedType";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {
                ddlOpt_ReceivedType.DataSource = dtb;
                ddlOpt_ReceivedType.DataBind();
                ddlOpt_ReceivedType.DataTextField = "OptionSetLable";
                ddlOpt_ReceivedType.DataValueField = "OptionSetValue";
                ddlOpt_ReceivedType.DataBind();
            }
            else
            {
                ddlOpt_ReceivedType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindDocumentTypeDropDownList()";
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm : BindDocumentTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void FillForm(GoodsReceivedNoteFormUI goodsReceivedNoteFormUI)
    {
        divPO.Visible = true;
        try
        {
            DataTable dtb = goodsReceivedNoteFormBAL.GetGoodsReceivedNoteListById(goodsReceivedNoteFormUI);
            if (dtb.Rows.Count > 0)
            {
              
                txtPO.Text = dtb.Rows[0]["tbl_PO"].ToString();
                txtPOGuid.Text = dtb.Rows[0]["tbl_POId"].ToString();
                txtBatchGuid.Text = dtb.Rows[0]["tbl_BatchId"].ToString();
                txtBatch.Text = dtb.Rows[0]["tbl_Batch"].ToString();
                txtCurrencyGuid.Text = dtb.Rows[0]["tbl_CurrencyId"].ToString();
                txtCurrency.Text = dtb.Rows[0]["CurrencyName"].ToString();
                txtSupplierGuid.Text = dtb.Rows[0]["tbl_SupplierId"].ToString();
                txtSupplier.Text = dtb.Rows[0]["tbl_Supplier"].ToString();
                ddlOpt_ReceivedType.SelectedValue = dtb.Rows[0]["Opt_ReceivedType"].ToString();
                txtGoodsReceivedNoteNumber.Text = dtb.Rows[0]["GoodsReceivedNoteNumber"].ToString();
                txtSupplierDocumentNumber.Text = dtb.Rows[0]["SupplierDocumentNumber"].ToString();
                txtDate.Text = dtb.Rows[0]["Date"].ToString();
                txtSubTotal.Text = dtb.Rows[0]["SubTotal"].ToString();
                txtTradeDiscount.Text = dtb.Rows[0]["TradeDiscount"].ToString();
                txtFreight.Text = dtb.Rows[0]["Freight"].ToString();
                txtMiscellaneous.Text = dtb.Rows[0]["Miscellaneous"].ToString();
                txtTotal.Text = dtb.Rows[0]["Total"].ToString();
                bool isPosted = Convert.ToBoolean(dtb.Rows[0]["IsPosted"]);

                if (isPosted == true)
                {
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnPost.Enabled = false;
                }

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
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm.CS";
            logExcpUIobj.RecordId = goodsReceivedNoteFormUI.Tbl_GoodsReceivedNoteId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindGoodsReceivedNoteDetails()
    {
        try
        {
            lblGoodsReceivedNoteDetail.Text = "Goods Received Note Details";
            GoodsReceivedNoteDetailsListUI goodsReceivedNoteDetailsListUI = new GoodsReceivedNoteDetailsListUI();
            goodsReceivedNoteDetailsListUI.Tbl_GoodsReceivedNoteDetailsId = Request.QueryString["GoodsReceivedNoteDetailsId"];
          
            DataTable dtb = goodsReceivedNoteDetailsListBAL.GetGoodsReceivedNoteDetailsListBySearchParameters(goodsReceivedNoteDetailsListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {

                gvdetails.DataSource = dtb;
                gvdetails.DataBind();
                divError.Visible = false;
                gvdetails.Visible = true;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                //gvdetails.Visible = true;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GoodsReceivedNoteDetails()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm : GoodsReceivedNoteDetails] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
                gvBatchSearch.Visible = true;
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
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm : SearchBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm : BindBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  BatchSerach


    #region Supplier Search
    private void SearchSupplierList()
    {
        try
        {
            SupplierListUI supplierListUI = new SupplierListUI();
            supplierListUI.Search = txtSupplierSearch.Text;
            DataTable dtb = supplierListBAL.GetSupplierListBySearchParameters(supplierListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSupplierSearch.DataSource = dtb;
                gvSupplierSearch.DataBind();
                divSupplierSearchError.Visible = false;
                gvSupplierSearch.Visible = true;
            }
            else
            {
                divSupplierSearchError.Visible = true;
                lblSupplierSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSupplierSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchSupplierList()";
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm : SearchSupplierList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindSupplierList()
    {
        try
        {
            DataTable dtb = supplierListBAL.GetSupplierList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSupplierSearch.DataSource = dtb;
                gvSupplierSearch.DataBind();
                divSupplierSearchError.Visible = false;
            }
            else
            {
                divSupplierSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSupplierSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindSupplierList()";
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm : BindSupplierList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Supplier Serach

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
                gvCurrencySearch.Visible = true;
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
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm : SearchCurrencyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm : BindCurrencyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Currency Serach

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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm : SearchPOList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm : BindPOList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  PO search
    private void BindPO()
    {
        try
        {
            POListUI pOListUI = new POListUI();
            pOListUI.Tbl_POId = Request.QueryString["POId"];
            DataTable dtb = pOListBAL.GetPOListById(pOListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                txtPO.Text = dtb.Rows[0]["PONumber"].ToString();
                txtSupplier.Text = dtb.Rows[0]["Supplier"].ToString();
                txtSupplierGuid.Text = dtb.Rows[0]["tbl_SupplierId"].ToString();
                txtCurrency.Text = dtb.Rows[0]["CurrencyName"].ToString();
                txtCurrencyGuid.Text = dtb.Rows[0]["tbl_CurrencyId"].ToString();
                txtSubTotal.Text = dtb.Rows[0]["SubTotal"].ToString();
                txtTradeDiscount.Text = dtb.Rows[0]["TradeDiscount"].ToString();
                txtFreight.Text = dtb.Rows[0]["Freight"].ToString();
                txtMiscellaneous.Text = dtb.Rows[0]["Miscellaneous"].ToString();
                txtTotal.Text = dtb.Rows[0]["Total"].ToString();

            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;

            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPODetaild()";
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm : BindPODetaild] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    private void BindPODetails()
    {
        try
        {
            lblPurchaseOrder.Text = "Puchase Order Details";
            PODetailsListUI pODetailsListUI = new PODetailsListUI();
            pODetailsListUI.Tbl_POId = Request.QueryString["POId"];
            pODetailsListUI.Tbl_POId = txtPOIdGuid.Text;
            DataTable dtb = pODetailsListBAL.GetPODetailsListBySearchParameters(pODetailsListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {

                gvData.DataSource = dtb;
                gvData.DataBind();
                divError.Visible = false;
                gvData.Visible = true;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvData.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPODetaild()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm : BindPODetaild] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    #endregion Methods








    
}
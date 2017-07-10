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
    
    #endregion Data Members

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        GoodsReceivedNoteFormUI goodsReceivedNoteFormUI = new GoodsReceivedNoteFormUI();
        if (!Page.IsPostBack)
        {
            BindReceivedTypeDropDownList();
            if (Request.QueryString["GoodsReceivedNoteId"] != null)
            {
                goodsReceivedNoteFormUI.Tbl_GoodsReceivedNoteId = Request.QueryString["GoodsReceivedNoteId"];
                BindReceivedTypeDropDownList();
                FillForm(goodsReceivedNoteFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Good Received Note";
            }
            else
            {
                BindReceivedTypeDropDownList();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
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
            goodsReceivedNoteFormUI.Tbl_BatchId = txtBatchGuid.Text;
            goodsReceivedNoteFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            goodsReceivedNoteFormUI.Tbl_SupplierId = txtSupplierGuid.Text;
            goodsReceivedNoteFormUI.opt_ReceivedType = int.Parse(ddlOpt_ReceivedType.SelectedValue.ToString());
            goodsReceivedNoteFormUI.GoodsReceivedNoteNumber =txtGoodsReceivedNoteNumber.Text;
            goodsReceivedNoteFormUI.SupplierDocumentNumber= txtSupplierDocumentNumber.Text;
            goodsReceivedNoteFormUI.Date =DateTime.Parse(txtDate.Text);
            goodsReceivedNoteFormUI.SubTotal =Decimal.Parse(txtSubTotal.Text);
            goodsReceivedNoteFormUI.TradeDiscount =Decimal.Parse(txtTradeDiscount.Text);
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
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("GoodsReceivedNoteList.aspx");
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
        try
        {
            DataTable dtb = goodsReceivedNoteFormBAL.GetGoodsReceivedNoteListById(goodsReceivedNoteFormUI);
            if (dtb.Rows.Count > 0)
            {
                txtBatchGuid.Text = dtb.Rows[0]["tbl_BatchId"].ToString();
                txtBatch.Text = dtb.Rows[0]["tbl_Batch"].ToString();
                txtCurrencyGuid.Text = dtb.Rows[0]["tbl_CurrencyId"].ToString();
                txtCurrency.Text = dtb.Rows[0]["CurrencyName"].ToString();
                txtSupplierGuid.Text = dtb.Rows[0]["tbl_SupplierId"].ToString();
                txtSupplier.Text = dtb.Rows[0]["tbl_Supplier"].ToString();
                ddlOpt_ReceivedType.SelectedValue = dtb.Rows[0]["Opt_ReceivedType"].ToString();
                txtGoodsReceivedNoteNumber.Text= dtb.Rows[0]["GoodsReceivedNoteNumber"].ToString();
                txtSupplierDocumentNumber.Text = dtb.Rows[0]["SupplierDocumentNumber"].ToString();
                txtDate.Text= dtb.Rows[0]["Date"].ToString();
                txtSubTotal.Text = dtb.Rows[0]["SubTotal"].ToString();
                txtTradeDiscount.Text= dtb.Rows[0]["TradeDiscount"].ToString();
                txtFreight.Text= dtb.Rows[0]["Freight"].ToString();
                txtMiscellaneous.Text = dtb.Rows[0]["Miscellaneous"].ToString();
                txtTotal.Text = dtb.Rows[0]["Total"].ToString();

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

   

    #endregion Methods

}
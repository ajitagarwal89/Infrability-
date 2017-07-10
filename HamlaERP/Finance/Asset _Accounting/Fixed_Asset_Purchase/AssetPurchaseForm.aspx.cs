using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Assets_AssetPurchase_AssetPurchaseForm : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    OptionSetListUI optionSetListUI = new OptionSetListUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    BatchListBAL batchListBAL = new BatchListBAL();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    SupplierListBAL supplierListBAL = new SupplierListBAL();
    AssetPurchaseFormBAL assetPurchaseFormBAL = new AssetPurchaseFormBAL();
    AssetPurchaseFormUI assetPurchaseFormUI= new AssetPurchaseFormUI();
    #endregion Data Members

    #region Events
    protected  void Page_Load(object sender, EventArgs e)
    {
        AssetPurchaseFormUI assetPurchaseFormUI = new AssetPurchaseFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["AssetPurchaseId"] != null)
            {
                assetPurchaseFormUI.Tbl_AssetPurchaseId = Request.QueryString["AssetPurchaseId"];
                BindReceiptTypeDropDownList();


                FillForm(assetPurchaseFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Asset Purchase";
            }
            else
            {
                BindReceiptTypeDropDownList();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Asset Purchase";
            }
        }
    }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            assetPurchaseFormUI.CreatedBy = SessionContext.UserGuid;
            assetPurchaseFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            assetPurchaseFormUI.opt_ReceiptType = int.Parse(ddlopt_ReceiptType.SelectedValue.ToString());
            assetPurchaseFormUI.ReceiptNumber = txtReceiptNumber.Text;
            assetPurchaseFormUI.Tbl_SupplierId = txtSupplierGuid.Text;
            assetPurchaseFormUI.SupplierDocumentNumber = txtSupplierDocumentNumber.Text;
            assetPurchaseFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            assetPurchaseFormUI.Date = DateTime.Parse(txtDate.Text);
            assetPurchaseFormUI.Tbl_BatchId = txtBatchGuid.Text;
            assetPurchaseFormUI.SubTotal = Convert.ToDecimal(txtSubTotal.Text);
            assetPurchaseFormUI.TradeDiscount = Convert.ToDecimal(txtTradeDiscount.Text);
            assetPurchaseFormUI.Frieght = Convert.ToDecimal(txtFrieght.Text);
            assetPurchaseFormUI.Miscellaneous = Convert.ToDecimal(txtMiscellaneous.Text);
            assetPurchaseFormUI.MainTotal = Convert.ToDecimal(txtMainTotal.Text);
            /*
             fields Parameter
             */

            if (assetPurchaseFormBAL.AddAssetPurchase(assetPurchaseFormUI) == 1)
            {
                divSuccess.Visible = true;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
                divError.Visible = true;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "Assets_AssetPurchase_AssetPurchaseForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetPurchase_AssetPurchaseForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            assetPurchaseFormUI.ModifiedBy = SessionContext.UserGuid;
            assetPurchaseFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            assetPurchaseFormUI.Tbl_AssetPurchaseId = Request.QueryString["AssetPurchaseId"];
            assetPurchaseFormUI.opt_ReceiptType = int.Parse(ddlopt_ReceiptType.SelectedValue.ToString());
            assetPurchaseFormUI.ReceiptNumber = txtReceiptNumber.Text;
            assetPurchaseFormUI.Tbl_SupplierId = txtSupplierGuid.Text;
            assetPurchaseFormUI.SupplierDocumentNumber = txtSupplierDocumentNumber.Text;
            assetPurchaseFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            assetPurchaseFormUI.Date = DateTime.Parse(txtDate.Text);
            assetPurchaseFormUI.Tbl_BatchId = txtBatchGuid.Text;
            assetPurchaseFormUI.SubTotal = Convert.ToDecimal(txtSubTotal.Text);
            assetPurchaseFormUI.TradeDiscount = Convert.ToDecimal(txtTradeDiscount.Text);
            assetPurchaseFormUI.Frieght = Convert.ToDecimal(txtFrieght.Text);
            assetPurchaseFormUI.Miscellaneous = Convert.ToDecimal(txtMiscellaneous.Text);
            assetPurchaseFormUI.MainTotal = Convert.ToDecimal(txtMainTotal.Text);
            /*
               fields Parameter
               */

            if (assetPurchaseFormBAL.UpdateAssetPurchase(assetPurchaseFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Assets_AssetPurchase_AssetPurchaseForm.CS";
            logExcpUIobj.RecordId = assetPurchaseFormUI.Tbl_AssetPurchaseId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetPurchase_AssetPurchaseForm : btnUpdate_Click] An error occured in the processing of Record Id : " + assetPurchaseFormUI.Tbl_AssetPurchaseId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            assetPurchaseFormUI.Tbl_AssetPurchaseId = Request.QueryString["AssetPurchaseId"];

            if (assetPurchaseFormBAL.DeleteAssetPurchase(assetPurchaseFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Assets_AssetPurchase_AssetPurchaseForm.CS";
            logExcpUIobj.RecordId = assetPurchaseFormUI.Tbl_AssetPurchaseId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetPurchase_AssetPurchaseForm : btnDelete_Click] An error occured in the processing of Record Id : " + assetPurchaseFormUI.Tbl_AssetPurchaseId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetPurchaseList.aspx");
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

    #region Methods
    private void FillForm(AssetPurchaseFormUI assetPurchaseFormUI)
    {
        try
        {
            DataTable dtb = assetPurchaseFormBAL.GetAssetPurchaseListById(assetPurchaseFormUI);

            if (dtb.Rows.Count > 0)
            {
                ddlopt_ReceiptType.SelectedValue = dtb.Rows[0]["ReceiptType"].ToString();
                txtReceiptNumber.Text = dtb.Rows[0]["ReceiptNumber"].ToString();
                txtSupplierGuid.Text= dtb.Rows[0]["tbl_SupplierId"].ToString();
                txtSupplier.Text = dtb.Rows[0]["tbl_Supplier"].ToString();
                txtSupplierDocumentNumber.Text= dtb.Rows[0]["SupplierDocumentNumber"].ToString();
                txtCurrencyGuid.Text= dtb.Rows[0]["tbl_CurrencyId"].ToString();
                txtCurrency.Text = dtb.Rows[0]["CurrencyName"].ToString();
                txtDate.Text= dtb.Rows[0]["Date"].ToString();
                txtBatchGuid.Text= dtb.Rows[0]["tbl_BatchId"].ToString();
                txtBatch.Text = dtb.Rows[0]["tbl_Batch"].ToString();
                txtSubTotal.Text= dtb.Rows[0]["SubTotal"].ToString();
                txtTradeDiscount.Text= dtb.Rows[0]["TradeDiscount"].ToString();
                txtFrieght.Text= dtb.Rows[0]["Frieght"].ToString();
                txtMiscellaneous.Text= dtb.Rows[0]["Miscellaneous"].ToString();
                txtMainTotal.Text= dtb.Rows[0]["MainTotal"].ToString();

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
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = assetPurchaseFormUI.Tbl_AssetPurchaseId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : FillForm] An error occured in the processing of Record Id : " + assetPurchaseFormUI.Tbl_AssetPurchaseId + ". Details : [" + exp.ToString() + "]");
        }
    }
    private void BindReceiptTypeDropDownList()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_AssetPurchase";
            optionSetListUI.OptionSetName = "Opt_ReceiptType";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {
                ddlopt_ReceiptType.DataSource = dtb;
                ddlopt_ReceiptType.DataBind();
                ddlopt_ReceiptType.DataTextField = "OptionSetLable";
                ddlopt_ReceiptType.DataValueField = "OptionSetValue";
                ddlopt_ReceiptType.DataBind();
            }
            else
            {
                ddlopt_ReceiptType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindReceiptTypeDropDownList()";
            logExcpUIobj.ResourceName = "Assets_AssetPurchase_AssetPurchaseForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_AssetPurchase_AssetPurchaseForm : BindReceiptTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Assets_AssetPurchase_AssetPurchaseForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetPurchase_AssetPurchaseForm : SearchBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Assets_AssetPurchase_AssetPurchaseForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_AssetPurchase_AssetPurchaseForm : BindBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Assets_AssetPurchase_AssetPurchaseForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_AssetPurchase_AssetPurchaseForm : SearchSupplierList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Assets_AssetPurchase_AssetPurchaseForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetPurchase_AssetPurchaseForm : BindSupplierList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Assets_AssetPurchase_AssetPurchaseForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetPurchase_AssetPurchaseForm : SearchCurrencyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Assets_AssetPurchase_AssetPurchaseForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetPurchase_AssetPurchaseForm : BindCurrencyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Currency Serach

    #endregion Methods
}
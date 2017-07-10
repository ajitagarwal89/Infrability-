using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm : PageBase
{
    #region Data Members

    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    POBasedInvoiceFormBAL pOBasedInvoiceFormBAL = new POBasedInvoiceFormBAL();
    POBasedInvoiceFormUI pOBasedInvoiceFormUI = new POBasedInvoiceFormUI();
    BatchListBAL batchListBAL = new BatchListBAL();
    SupplierListBAL supplierListBAL = new SupplierListBAL();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    PaymentTermsListBAL paymentTermsListBAL = new PaymentTermsListBAL();

    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        POBasedInvoiceFormUI pOBasedInvoiceFormUI = new POBasedInvoiceFormUI();
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["POBasedInvoiceId"] != null)
            {
                pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId  = Request.QueryString["POBasedInvoiceId"];
                FillForm(pOBasedInvoiceFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update PO Based Invoice";
            }
            else
            {
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New PO Based Invoice";
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            pOBasedInvoiceFormUI.CreatedBy = SessionContext.UserGuid;
            pOBasedInvoiceFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            pOBasedInvoiceFormUI.Tbl_BatchId = txtBatchGuid.Text;
            pOBasedInvoiceFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            pOBasedInvoiceFormUI.Tbl_SupplierId = txtSupplierGuid.Text;
            pOBasedInvoiceFormUI.Tbl_PaymentTermsId = txtPaymentTermsGuid.Text;
            pOBasedInvoiceFormUI.ReceiptNumber = txtReceiptNumber.Text;
            pOBasedInvoiceFormUI.PostingDate = DateTime.Parse(txtPostingDate.Text);
            pOBasedInvoiceFormUI.SubTotalAmount = Convert.ToDecimal(txtSubTotalAmount.Text);
            pOBasedInvoiceFormUI.TradeDiscountAmount = Convert.ToDecimal(txtTradeDiscountAmount.Text);
            pOBasedInvoiceFormUI.FreightAmount = Convert.ToDecimal(txtFreightAmount.Text);
            pOBasedInvoiceFormUI.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);
            pOBasedInvoiceFormUI.InvoiceDate = DateTime.Parse(txtInvoiceDate.Text);
            if (pOBasedInvoiceFormBAL.AddPOBasedInvoice(pOBasedInvoiceFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            pOBasedInvoiceFormUI.ModifiedBy = SessionContext.UserGuid;
            pOBasedInvoiceFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId = Request.QueryString["POBasedInvoiceId"];
            pOBasedInvoiceFormUI.Tbl_BatchId = txtBatchGuid.Text;
            pOBasedInvoiceFormUI.Tbl_SupplierId = txtSupplierGuid.Text;
            pOBasedInvoiceFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            pOBasedInvoiceFormUI.Tbl_PaymentTermsId = txtPaymentTermsGuid.Text;
            pOBasedInvoiceFormUI.ReceiptNumber = txtReceiptNumber.Text;
            pOBasedInvoiceFormUI.PostingDate = DateTime.Parse(txtPostingDate.Text);
            pOBasedInvoiceFormUI.SubTotalAmount = Convert.ToDecimal(txtSubTotalAmount.Text);
            pOBasedInvoiceFormUI.TradeDiscountAmount = Convert.ToDecimal(txtTradeDiscountAmount.Text);
            pOBasedInvoiceFormUI.FreightAmount = Convert.ToDecimal(txtFreightAmount.Text);
            pOBasedInvoiceFormUI.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);
            pOBasedInvoiceFormUI.InvoiceDate = DateTime.Parse(txtInvoiceDate.Text);
            if (pOBasedInvoiceFormBAL.UpdatePOBasedInvoice(pOBasedInvoiceFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm : btnUpdate_Click] An error occured in the processing of Record Id : " +pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId + ".  Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
           pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId = Request.QueryString["POBasedInvoiceId"];

            if (pOBasedInvoiceFormBAL.DeletePOBasedInvoice(pOBasedInvoiceFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm : btnDelete_Click] An error occured in the processing of Record Id : " +pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId + ". Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("POBasedInvoiceList.aspx");
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

    #region Payment Terms Search
    protected void btnPaymentTermsSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPaymentTermsSearch.Visible = false;
        btnHtmlPaymentTermsClose.Visible = true;
        SearchPaymentTermsList();
    }
    protected void btnClearPaymentTermsSearch_Click(object sender, EventArgs e)
    {
        BindPaymentTermsList();
        gvPaymentTermsSearch.Visible = true;
        btnHtmlPaymentTermsSearch.Visible = true;
        btnHtmlPaymentTermsClose.Visible = false;
        txtPaymentTermsSearch.Text = "";
        txtPaymentTermsSearch.Focus();
    }
    protected void btnPaymentTermsRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPaymentTermsList();
    }
    #endregion Payment Terms Search
   
    #endregion Events

    #region Methods
    private void FillForm(POBasedInvoiceFormUI pOBasedInvoiceFormUI)
    {
        try
        {
            DataTable dtb =pOBasedInvoiceFormBAL.GetPOBasedInvoiceListById(pOBasedInvoiceFormUI);
            if (dtb.Rows.Count > 0)
            {
                txtBatchGuid.Text = dtb.Rows[0]["tbl_BatchId"].ToString();
                txtBatch.Text = dtb.Rows[0]["BatchName"].ToString();
                txtCurrencyGuid.Text = dtb.Rows[0]["tbl_CurrencyId"].ToString();
                txtCurrency.Text = dtb.Rows[0]["CurrencyName"].ToString();
                txtSupplierGuid.Text = dtb.Rows[0]["tbl_SupplierId"].ToString();
                txtSupplier.Text = dtb.Rows[0]["SupplierName"].ToString();
                txtPaymentTermsGuid.Text = dtb.Rows[0]["tbl_PaymentTermsId"].ToString();
                txtPaymentTerms.Text = dtb.Rows[0]["PaymentTermsName"].ToString();
                txtInvoiceDate.Text = dtb.Rows[0]["InvoiceDate"].ToString();
                txtPostingDate.Text = dtb.Rows[0]["PostingDate"].ToString();
                txtTradeDiscountAmount.Text = dtb.Rows[0]["TradeDiscountAmount"].ToString();
                txtFreightAmount.Text = dtb.Rows[0]["FreightAmount"].ToString();
                txtTotalAmount.Text = dtb.Rows[0]["TotalAmount"].ToString();
                txtReceiptNumber.Text = dtb.Rows[0]["ReceiptNumber"].ToString();
                txtSubTotalAmount.Text = dtb.Rows[0]["SubTotalAmount"].ToString();
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm.CS";
            logExcpUIobj.RecordId =pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm : SearchBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm : BindBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm : SearchSupplierList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm : BindSupplierList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm : SearchCurrencyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm : BindCurrencyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Currency Serach

    #region Payment Terms Search
    private void SearchPaymentTermsList()
    {
        try
        {
            PaymentTermsListUI paymentTermsListUI = new PaymentTermsListUI();
            paymentTermsListUI.Search = txtPaymentTermsSearch.Text;
            DataTable dtb = paymentTermsListBAL.GetPaymentTermsListBySearchParameters(paymentTermsListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPaymentTermsSearch.DataSource = dtb;
                gvPaymentTermsSearch.DataBind();
                divPaymentTermsSearchError.Visible = false;
            }
            else
            {
                divPaymentTermsSearchError.Visible = true;
                lblPaymentTermsSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPaymentTermsSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchPaymentTermsList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindPaymentTermsList()
    {
        try
        {
            DataTable dtb = paymentTermsListBAL.GetPaymentTermsList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPaymentTermsSearch.DataSource = dtb;
                gvPaymentTermsSearch.DataBind();
                divPaymentTermsSearchError.Visible = false;
            }
            else
            {
                divPaymentTermsSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPaymentTermsSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPaymentTermsList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm : BindPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Payment Terms Serach

    #endregion Methods
}
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Accounts_Receivable_Customer__Invoice__With_Sales_Order_CustomerInvoiceForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    BatchListBAL batchListBAL = new BatchListBAL();
    SitesListBAL sitesListBAL = new SitesListBAL();
    CustomerListBAL customerListBAL = new CustomerListBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    InvoiceAndOrderTypeListBAL invoiceAndOrderTypeListBAL = new InvoiceAndOrderTypeListBAL();


    CustomerInvoiceFormBAL customerInvoiceFormBAL = new CustomerInvoiceFormBAL();
    CustomerInvoiceFormUI customerInvoiceFormUI = new CustomerInvoiceFormUI();

    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        CustomerInvoiceFormUI customerInvoiceFormUI = new CustomerInvoiceFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CustomerInvoiceId"] != null)
            {
                customerInvoiceFormUI.Tbl_CustomerInvoiceId = Request.QueryString["CustomerInvoiceId"];

                BindInvoiceTypeDropDownList();
                BindDocumentStatusList();
                FillForm(customerInvoiceFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Customer Invoice";
            }
            else
            {
                BindDocumentStatusList();
                BindInvoiceTypeDropDownList();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Customer Invoice";
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            customerInvoiceFormUI.CreatedBy = SessionContext.UserGuid;
            customerInvoiceFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            customerInvoiceFormUI.DocumentDate = DateTime.Parse(txtDocumentDate.Text.ToString());
            customerInvoiceFormUI.Opt_InvoiceAndOrderType = Convert.ToByte(ddlOpt_InvoiceAndOrderType.SelectedValue);
            customerInvoiceFormUI.Tbl_InvoiceAndOrderTypeId = txtInvoiceAndOrderTypeGuid.Text.Trim().ToString();
            customerInvoiceFormUI.DocumentNumber = txtDocumentNumber.Text.Trim().ToString();
            customerInvoiceFormUI.Tbl_BatchId = txtBatchGuid.Text.Trim().ToString();
            customerInvoiceFormUI.Tbl_CustomerId = txtCustomerGuid.Text.Trim().ToString();
            customerInvoiceFormUI.Tbl_SitesId = txtSitesGuid.Text.Trim().ToString();
            customerInvoiceFormUI.CustomerPONumber = txtCustomerPONumber.Text.Trim().ToString();
            customerInvoiceFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text.Trim().ToString();
            customerInvoiceFormUI.AmountReceived = Convert.ToDecimal(txtAmountReceived.Text.ToString());
            customerInvoiceFormUI.OnAccount = Convert.ToDecimal(txtOnAccount.Text.ToString());
            customerInvoiceFormUI.SubTotalAmount = Convert.ToDecimal(txtSubTotalAmount.Text.ToString());
            customerInvoiceFormUI.TradeDiscountAmount = Convert.ToDecimal(txtTradeDiscountAmount.Text.ToString());
            customerInvoiceFormUI.FreightAmount = Convert.ToDecimal(txtFreightAmount.Text.ToString());
            customerInvoiceFormUI.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text.ToString());
            //customerInvoiceFormUI.Opt_DocumentStatus = Convert.ToByte(ddlOpt_DocumentStatus.SelectedValue);
            customerInvoiceFormUI.Opt_DocumentStatus = 0;
            customerInvoiceFormUI.PostingDate = DateTime.Parse(txtPostingDate.Text.ToString());
            customerInvoiceFormUI.QuoteDate = DateTime.Parse(txtQuoteDate.Text.ToString());
            customerInvoiceFormUI.OrderDate = DateTime.Parse(txtOrderDate.Text.ToString());
            customerInvoiceFormUI.InvoiceDate = DateTime.Parse(txtInvoiceDate.Text.ToString());
            customerInvoiceFormUI.BackOrderDate = DateTime.Parse(txtBackOrderDate.Text.ToString());
            customerInvoiceFormUI.ReturnDate = DateTime.Parse(txtReturnDate.Text.ToString());
            customerInvoiceFormUI.RequestedShipDate = DateTime.Parse(txtRequestedShipDate.Text.ToString());
            customerInvoiceFormUI.DateFulfilled = DateTime.Parse(txtDateFulfilled.Text.ToString());
            customerInvoiceFormUI.ActualShipDate = DateTime.Parse(txtActualShipDate.Text.ToString());

            if (customerInvoiceFormBAL.AddCustomerInvoice(customerInvoiceFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            customerInvoiceFormUI.ModifiedBy = SessionContext.UserGuid;
            customerInvoiceFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            customerInvoiceFormUI.Tbl_CustomerInvoiceId = Request.QueryString["CustomerInvoiceId"];
            customerInvoiceFormUI.DocumentDate = DateTime.Parse(txtDocumentDate.Text.ToString());
            customerInvoiceFormUI.Opt_InvoiceAndOrderType = Convert.ToByte(ddlOpt_InvoiceAndOrderType.SelectedValue);
            customerInvoiceFormUI.Tbl_InvoiceAndOrderTypeId = txtInvoiceAndOrderTypeGuid.Text.Trim().ToString();
            customerInvoiceFormUI.DocumentNumber = txtDocumentNumber.Text.Trim().ToString();
            customerInvoiceFormUI.Tbl_BatchId = txtBatchGuid.Text.Trim().ToString();
            customerInvoiceFormUI.Tbl_CustomerId = txtCustomerGuid.Text.Trim().ToString();
            customerInvoiceFormUI.Tbl_SitesId = txtSitesGuid.Text.Trim().ToString();
            customerInvoiceFormUI.CustomerPONumber = txtCustomerPONumber.Text.Trim().ToString();
            customerInvoiceFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text.Trim().ToString();
            customerInvoiceFormUI.AmountReceived = Convert.ToDecimal(txtAmountReceived.Text.ToString());
            customerInvoiceFormUI.OnAccount = Convert.ToDecimal(txtOnAccount.Text.ToString());
            customerInvoiceFormUI.SubTotalAmount = Convert.ToDecimal(txtSubTotalAmount.Text.ToString());
            customerInvoiceFormUI.TradeDiscountAmount = Convert.ToDecimal(txtTradeDiscountAmount.Text.ToString());
            customerInvoiceFormUI.FreightAmount = Convert.ToDecimal(txtFreightAmount.Text.ToString());
            customerInvoiceFormUI.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text.ToString());
            //customerInvoiceFormUI.Opt_DocumentStatus = Convert.ToByte(ddlOpt_DocumentStatus.SelectedValue);
            customerInvoiceFormUI.Opt_DocumentStatus = 0;
            customerInvoiceFormUI.PostingDate = DateTime.Parse(txtPostingDate.Text.ToString());
            customerInvoiceFormUI.QuoteDate = DateTime.Parse(txtQuoteDate.Text.ToString());
            customerInvoiceFormUI.OrderDate = DateTime.Parse(txtOrderDate.Text.ToString());
            customerInvoiceFormUI.InvoiceDate = DateTime.Parse(txtInvoiceDate.Text.ToString());
            customerInvoiceFormUI.BackOrderDate = DateTime.Parse(txtBackOrderDate.Text.ToString());
            customerInvoiceFormUI.ReturnDate = DateTime.Parse(txtReturnDate.Text.ToString());
            customerInvoiceFormUI.RequestedShipDate = DateTime.Parse(txtRequestedShipDate.Text.ToString());
            customerInvoiceFormUI.DateFulfilled = DateTime.Parse(txtDateFulfilled.Text.ToString());
            customerInvoiceFormUI.ActualShipDate = DateTime.Parse(txtActualShipDate.Text.ToString());


            if (customerInvoiceFormBAL.UpdateCustomerInvoice(customerInvoiceFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : btnUpdate_Click] An error occured in the processing of Record Id : " + customerInvoiceFormUI.Tbl_CustomerInvoiceId + ".  Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            customerInvoiceFormUI.Tbl_CustomerInvoiceId = Request.QueryString["CustomerInvoiceId"];

            if (customerInvoiceFormBAL.DeleteCustomerInvoice(customerInvoiceFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = customerInvoiceFormUI.Tbl_CustomerInvoiceId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : btnDelete_Click] An error occured in the processing of Record Id : " + customerInvoiceFormUI.Tbl_CustomerInvoiceId + ". Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerInvoiceList.aspx");
    }

    #region Batch search
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
    #endregion

    #region CurrencySearch
    protected void btnCurrencySearch_Click(object sender, EventArgs e)
    {
        btnHtmlCurrencySearch.Visible = false;
        btnHtmlCurrencyClose.Visible = true;
        SearchCurrency();
    }
    protected void btnClearCurrencySearch_Click(object sender, EventArgs e)
    {
        BindCurrencyList();
    }
    protected void btnCurrencyRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindCurrencyList();

    }
    #endregion

    #region CustomerSearch
    protected void btnCustomerSearch_Click(object sender, EventArgs e)
    {
        btnHtmlCustomerSearch.Visible = false;
        btnHtmlCustomerClose.Visible = true;
        SearchCustomerList();
    }
    protected void btnClearCustomerSearch_Click(object sender, EventArgs e)
    {
        BindCustomerList();
        gvCustomerSearch.Visible = true;
        btnHtmlCustomerSearch.Visible = true;
        btnHtmlCustomerClose.Visible = false;
        txtCustomerSearch.Text = "";
        txtCustomerSearch.Focus();
    }
    protected void btnCustomerRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindBatchList();
    }
    #endregion

    #region SitesSearch
    protected void btnSitesSearch_Click(object sender, EventArgs e)
    {
        btnHtmlSitesSearch.Visible = false;
        btnHtmlSitesClose.Visible = true;
        SearchSitesList();
    }
    protected void btnClearSitesSearch_Click(object sender, EventArgs e)
    {
        BindSitesList();
        gvSitesSearch.Visible = true;
        btnHtmlSitesSearch.Visible = true;
        btnHtmlSitesClose.Visible = false;
        txtSitesSearch.Text = "";
        txtSitesSearch.Focus();
    }
    protected void btnSitesRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindSitesList();
    }


    #endregion

    #region Invoice And Order TypeSearch
    protected void btnInvoiceAndOrderTypeSearch_Click(object sender, EventArgs e)
    {
        btnHtmlInvoiceAndOrderTypeSearch.Visible = false;
        btnHtmlInvoiceAndOrderTypeClose.Visible = true;
        SearchInvoiceAndOrderTypeList();
    }
    protected void btnClearInvoiceAndOrderTypeSearch_Click(object sender, EventArgs e)
    {
        BindInvoiceAndOrderTypeList();
        gvInvoiceAndOrderTypeSearch.Visible = true;
        btnHtmlInvoiceAndOrderTypeSearch.Visible = true;
        btnHtmlInvoiceAndOrderTypeClose.Visible = false;
        txtInvoiceAndOrderTypeSearch.Text = "";
        txtInvoiceAndOrderTypeSearch.Focus();
    }
    protected void btnInvoiceAndOrderTypeRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindInvoiceAndOrderTypeList();
    }
    #endregion

  
    #endregion Events

    #region Methods
    private void FillForm(CustomerInvoiceFormUI customerInvoiceFormUI)
    {
        try
        {
            DataTable dtb = customerInvoiceFormBAL.GetCustomerInvoiceListById(customerInvoiceFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtDocumentDate.Text = dtb.Rows[0]["DocumentDate"].ToString();
                ddlOpt_InvoiceAndOrderType.SelectedValue = dtb.Rows[0]["Opt_InvoiceAndOrderTypeLable"].ToString();
                txtInvoiceAndOrderTypeGuid.Text = dtb.Rows[0]["tbl_InvoiceAndOrderTypeId"].ToString();
                txtInvoiceAndOrderType.Text = dtb.Rows[0]["tbl_InvoiceAndOrderTypeId"].ToString();
                txtInvoiceAndOrderType.Text = dtb.Rows[0]["Opt_InvoiceAndOrderTypeLable"].ToString();
                txtDocumentNumber.Text = dtb.Rows[0]["DocumentNumber"].ToString();
                txtBatchGuid.Text = dtb.Rows[0]["tbl_BatchId"].ToString();
                txtBatch.Text = dtb.Rows[0]["BatchName"].ToString();
                txtCustomerGuid.Text = dtb.Rows[0]["tbl_CustomerId"].ToString();
                txtCustomer.Text = dtb.Rows[0]["CustomerName"].ToString();
                txtSitesGuid.Text = dtb.Rows[0]["tbl_SitesId"].ToString();
                txtSites.Text = dtb.Rows[0]["SiteNumber"].ToString();
                txtCustomerPONumber.Text = dtb.Rows[0]["CustomerPONumber"].ToString();
                txtCurrencyGuid.Text = dtb.Rows[0]["tbl_CurrencyId"].ToString();
                txtCurrency.Text = dtb.Rows[0]["CurrencyName"].ToString();
                txtAmountReceived.Text = dtb.Rows[0]["AmountReceived"].ToString();
                txtOnAccount.Text = dtb.Rows[0]["OnAccount"].ToString();
                txtSubTotalAmount.Text = dtb.Rows[0]["SubTotalAmount"].ToString();
                txtTradeDiscountAmount.Text = dtb.Rows[0]["TradeDiscountAmount"].ToString();
                txtFreightAmount.Text = dtb.Rows[0]["FreightAmount"].ToString();
                txtTotalAmount.Text = dtb.Rows[0]["TotalAmount"].ToString();
                //ddlOpt_DocumentStatus.SelectedValue = dtb.Rows[0]["Opt_DocumentStatus"].ToString();
                txtPostingDate.Text = dtb.Rows[0]["PostingDate"].ToString();
                txtQuoteDate.Text = dtb.Rows[0]["QuoteDate"].ToString();
                txtOrderDate.Text = dtb.Rows[0]["OrderDate"].ToString();
                txtInvoiceDate.Text = dtb.Rows[0]["InvoiceDate"].ToString();
                txtBackOrderDate.Text = dtb.Rows[0]["BackOrderDate"].ToString();
                txtReturnDate.Text = dtb.Rows[0]["ReturnDate"].ToString();
                txtRequestedShipDate.Text = dtb.Rows[0]["RequestedShipDate"].ToString();
                txtDateFulfilled.Text = dtb.Rows[0]["DateFulfilled"].ToString();
                txtActualShipDate.Text = dtb.Rows[0]["ActualShipDate"].ToString();
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
            logExcpUIobj.RecordId = customerInvoiceFormUI.Tbl_CustomerInvoiceId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #region BindInvoiceTypeDropDownList
    private void BindInvoiceTypeDropDownList()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_InvoiceAndOrderType";
            optionSetListUI.OptionSetName = "Opt_InvoiceAndOrderType";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {
                ddlOpt_InvoiceAndOrderType.DataSource = dtb;
                ddlOpt_InvoiceAndOrderType.DataBind();
                ddlOpt_InvoiceAndOrderType.DataTextField = "OptionSetLable";
                ddlOpt_InvoiceAndOrderType.DataValueField = "OptionSetValue";
                ddlOpt_InvoiceAndOrderType.DataBind();
            }
            else
            {
                ddlOpt_InvoiceAndOrderType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindOriginDropDownList()";
            logExcpUIobj.ResourceName = "System_Settings_InvoiceAndOrderTypeForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_InvoiceAndOrderTypeForm : BindInvoiceTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion BindInvoiceTypeDropDownList
    #region BindDocumentStatusList
    private void BindDocumentStatusList()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_Customer";
            optionSetListUI.OptionSetName = "Opt_Status";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {
                ddlOpt_DocumentStatus.DataSource = dtb;
                ddlOpt_DocumentStatus.DataBind();
                ddlOpt_DocumentStatus.DataTextField = "OptionSetLable";
                ddlOpt_DocumentStatus.DataValueField = "OptionSetValue";
                ddlOpt_DocumentStatus.DataBind();
            }
            else
            {
                ddlOpt_DocumentStatus.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindDocumentStatusList()";
            logExcpUIobj.ResourceName = "System_Settings_InvoiceAndOrderTypeForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_InvoiceAndOrderTypeForm : BindDocumentStatusList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion BindDocumentStatusList

    #region SearchBatch
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
            logExcpUIobj.ResourceName = "System_Settings_GLAccountEntryForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountEntryForm : SearchBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "System_Settings_GLAccountEntryForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountEntryForm : BindBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion SearchBatch
    #region Search Country
    private void SearchCurrency()
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
                divError.Visible = false;

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
            logExcpUIobj.MethodName = "SearchCurrency()";
            logExcpUIobj.ResourceName = "System_Settings_CurrencyList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_CurrencyList : SearchCurrency] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
                lblCurrencySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCurrencySearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "System_Settings_CurrencyList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_CurrencyList : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion
    #region Search  BindCustomer
    private void BindCustomerList()
    {
        try
        {
            DataTable dtb = customerListBAL.GetCustomerList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCustomerSearch.DataSource = dtb;
                gvCustomerSearch.DataBind();
                divCustomerSearchError.Visible = false;

            }
            else
            {
                divCustomerSearchError.Visible = true;
                lblCustomerSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCustomerSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCustomerList()";
            logExcpUIobj.ResourceName = "System_Settings_CurrencyList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_CurrencyList : BindCustomerList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void SearchCustomerList()
    {
        try
        {
            CustomerListUI customerListUI = new CustomerListUI();
            customerListUI.Search = txtCustomerSearch.Text;
            DataTable dtb = customerListBAL.GetCustomerListBySearchParameters(customerListUI);


            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCustomerSearch.DataSource = dtb;
                gvCustomerSearch.DataBind();
                divCustomerSearchError.Visible = false;

            }
            else
            {
                divCustomerSearchError.Visible = true;
                lblCustomerSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCustomerSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchCustomer()";
            logExcpUIobj.ResourceName = "System_Settings_CurrencyList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_CurrencyList : SearchCustomer] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion
    #region  SearchSites
    private void BindSitesList()
    {
        try
        {
            DataTable dtb = sitesListBAL.GetSitesList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSitesSearch.DataSource = dtb;
                gvSitesSearch.DataBind();
                divSitesSearchError.Visible = false;

            }
            else
            {
                divSitesSearchError.Visible = true;
                lblSitesSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSitesSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindSitesList()";
            logExcpUIobj.ResourceName = "System_Settings_CurrencyList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_CurrencyList : BindSitesList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void SearchSitesList()
    {
        try
        {
            SitesListUI sitesListUI = new SitesListUI();
            sitesListUI.Search = txtCustomerSearch.Text;
            DataTable dtb = sitesListBAL.GetSitesListBySearchParameters(sitesListUI);


            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSitesSearch.DataSource = dtb;
                gvSitesSearch.DataBind();
                divSitesSearchError.Visible = false;

            }
            else
            {
                divSitesSearchError.Visible = true;
                lblSitesSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSitesSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchSites()";
            logExcpUIobj.ResourceName = "System_Settings_CurrencyList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_CurrencyList : SearchSites] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion
    #region SearchInvoiceAndOrderType
    private void BindInvoiceAndOrderTypeList()
    {
        try
        {
            DataTable dtb = invoiceAndOrderTypeListBAL.GetInvoiceAndOrderTypeList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvInvoiceAndOrderTypeSearch.DataSource = dtb;
                gvInvoiceAndOrderTypeSearch.DataBind();
                divInvoiceAndOrderTypeSearchError.Visible = false;

            }
            else
            {
                divInvoiceAndOrderTypeSearchError.Visible = true;
                lblInvoiceAndOrderTypeSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvInvoiceAndOrderTypeSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindInvoiceAndOrderTypeList()";
            logExcpUIobj.ResourceName = "System_Settings_CurrencyList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_CurrencyList : BindInvoiceAndOrderTypeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void SearchInvoiceAndOrderTypeList()
    {
        try
        {
            InvoiceAndOrderTypeListUI invoiceAndOrderTypeListUI = new InvoiceAndOrderTypeListUI();
            invoiceAndOrderTypeListUI.Search = txtCustomerSearch.Text;
            DataTable dtb = invoiceAndOrderTypeListBAL.GetInvoiceAndOrderTypeListBySearchParameters(invoiceAndOrderTypeListUI);


            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvInvoiceAndOrderTypeSearch.DataSource = dtb;
                gvInvoiceAndOrderTypeSearch.DataBind();
                divInvoiceAndOrderTypeSearchError.Visible = false;

            }
            else
            {
                divInvoiceAndOrderTypeSearchError.Visible = true;
                lblInvoiceAndOrderTypeSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvInvoiceAndOrderTypeSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchInvoiceAndOrderTypeList()";
            logExcpUIobj.ResourceName = "System_Settings_CurrencyList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_CurrencyList : SearchInvoiceAndOrderTypeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion

    #endregion Methods











}
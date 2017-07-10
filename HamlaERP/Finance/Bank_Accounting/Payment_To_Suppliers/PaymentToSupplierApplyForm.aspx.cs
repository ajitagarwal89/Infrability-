using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm : System.Web.UI.Page
{

    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    PaymentToSupplierApplyFormBAL paymentToSupplierApplyFormBAL = new PaymentToSupplierApplyFormBAL();
    PaymentToSupplierApplyFormUI paymentToSupplierApplyFormUI = new PaymentToSupplierApplyFormUI();
    NonPOBasedInvoiceListBAL nonPOBasedInvoiceListBAL = new NonPOBasedInvoiceListBAL();
    PaymentToSupplierApplyListUI paymentToSupplierApplyListUI = new PaymentToSupplierApplyListUI();
    POBasedInvoiceListBAL pOBasedInvoiceListBAL = new POBasedInvoiceListBAL();
    PaymentToSupplierApplyListBAL paymentToSupplierApplyListBAL = new PaymentToSupplierApplyListBAL();

    PaymentToSupplierListBAL paymentToSupplierListBAL = new PaymentToSupplierListBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    #endregion Data Members 
    
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            if (Request.QueryString["PaymentToSupplierId"] != null)
            {
                paymentToSupplierApplyListUI.Tbl_PaymentToSupplierId = Request.QueryString["PaymentToSupplierId"];
                BindPaymentToSupplierApply(paymentToSupplierApplyListUI);
                BindTypeDropDownList();
            }
            else if (Request.QueryString["PaymentToSupplierApplyId"] != null)
            {
                paymentToSupplierApplyFormUI.Tbl_PaymentToSupplierApplyId = Request.QueryString["PaymentToSupplierApplyId"];

                BindTypeDropDownList();
                FillForm(paymentToSupplierApplyFormUI);
                divNonPOBasedInvoice.Visible = false;
                divPOBasedInvoice.Visible = false;
                if (rdbNonPOBasedInvoiceId.Checked)
                    divNonPOBasedInvoice.Visible = true;
                else if (rdbPOBasedInvoiceId.Checked)
                    divPOBasedInvoice.Visible = true;

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update  Payment To Supplier Apply";
            }
            else
            {
                BindTypeDropDownList();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Payment To Supplier Apply";
            }
        }
    }

    protected void rdbNonPOBasedInvoiceId_CheckedChanged(object sender, EventArgs e)
    {

        divNonPOBasedInvoice.Visible = true;
        divPOBasedInvoice.Visible = false;
    }

    protected void rdbPOBasedInvoiceId_CheckedChanged(object sender, EventArgs e)
    {
        divPOBasedInvoice.Visible = true;
        divNonPOBasedInvoice.Visible = false;

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int applyToDocumentTypeNonPOBaseInvoice = 1;
        int applyToDocumentTypePOBaseInvoice = 2;

        try
        {
            paymentToSupplierApplyFormUI.CreatedBy = SessionContext.UserGuid;
            paymentToSupplierApplyFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            paymentToSupplierApplyFormUI.Tbl_PaymentToSupplierId = txtPaymentToSupplierGuid.Text;
            paymentToSupplierApplyFormUI.Tbl_CurrencyId_ApplyToCurrency = txtCurrencyId_ApplyToCurrencyGuid.Text;

            if (rdbNonPOBasedInvoiceId.Checked)
            {
                paymentToSupplierApplyFormUI.Tbl_ApplyToDocument = txtApplyToDocumentNonPOBasedInvoiceGuid.Text;
                paymentToSupplierApplyFormUI.opt_ApplyToDocumentType = applyToDocumentTypeNonPOBaseInvoice;
            }
            else if (rdbPOBasedInvoiceId.Checked)
            {
                paymentToSupplierApplyFormUI.Tbl_ApplyToDocument = txtApplyToDocumentPOBasedInvoiceGuid.Text;
                paymentToSupplierApplyFormUI.opt_ApplyToDocumentType = applyToDocumentTypePOBaseInvoice;
            }
            paymentToSupplierApplyFormUI.opt_Type = int.Parse(ddloptType.SelectedValue.ToString());
            paymentToSupplierApplyFormUI.DueDate = DateTime.Parse(txtDueDate.Text.ToString());
            paymentToSupplierApplyFormUI.RemainingAmount = Convert.ToDecimal(txtRemainingAmount.Text);
            paymentToSupplierApplyFormUI.ApplyAmount = Decimal.Parse(txtApplyAmount.Text);
            paymentToSupplierApplyFormUI.OrignalDocumentAmount = Convert.ToDecimal(txtOrignalDocumentAmount.Text);
            paymentToSupplierApplyFormUI.DiscountDate = DateTime.Parse(txtDiscountDate.Text);
            if (paymentToSupplierApplyFormBAL.AddPaymentToSupplierApply(paymentToSupplierApplyFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int applyToDocumentTypeNonPOBaseInvoice = 1;
        int applyToDocumentTypePOBaseInvoice = 2;

        PaymentToSupplierApplyFormUI paymentToSupplierApplyFormUI = new PaymentToSupplierApplyFormUI();
        try
        {
            paymentToSupplierApplyFormUI.ModifiedBy = SessionContext.UserGuid;
            paymentToSupplierApplyFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            paymentToSupplierApplyFormUI.Tbl_PaymentToSupplierId = txtPaymentToSupplierGuid.Text;
            paymentToSupplierApplyFormUI.Tbl_CurrencyId_ApplyToCurrency = txtCurrencyId_ApplyToCurrencyGuid.Text;
            if (rdbNonPOBasedInvoiceId.Checked)
            {
                paymentToSupplierApplyFormUI.Tbl_ApplyToDocument = txtApplyToDocumentNonPOBasedInvoiceGuid.Text;
                paymentToSupplierApplyFormUI.opt_ApplyToDocumentType = applyToDocumentTypeNonPOBaseInvoice;
            }
            else if (rdbPOBasedInvoiceId.Checked)
            {
                paymentToSupplierApplyFormUI.Tbl_ApplyToDocument = txtApplyToDocumentPOBasedInvoiceGuid.Text;
                paymentToSupplierApplyFormUI.opt_ApplyToDocumentType = applyToDocumentTypePOBaseInvoice;
            }
            paymentToSupplierApplyFormUI.opt_Type = int.Parse(ddloptType.SelectedValue.ToString());
            paymentToSupplierApplyFormUI.DueDate = DateTime.Parse(txtDueDate.Text.ToString());
            paymentToSupplierApplyFormUI.RemainingAmount = Convert.ToDecimal(txtRemainingAmount.Text);
            paymentToSupplierApplyFormUI.ApplyAmount = Decimal.Parse(txtApplyAmount.Text);
            paymentToSupplierApplyFormUI.OrignalDocumentAmount = Convert.ToDecimal(txtOrignalDocumentAmount.Text);
            paymentToSupplierApplyFormUI.DiscountDate = DateTime.Parse(txtDiscountDate.Text);
            paymentToSupplierApplyFormUI.Tbl_PaymentToSupplierApplyId = Request.QueryString["PaymentToSupplierApplyId"];
            if (paymentToSupplierApplyFormBAL.UpdatePaymentToSupplierApply(paymentToSupplierApplyFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm : btnUpdate_Click] An error occured in the processing of Record Id : " + paymentToSupplierApplyFormUI.Tbl_PaymentToSupplierApplyId + ".  Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            paymentToSupplierApplyFormUI.Tbl_PaymentToSupplierApplyId = Request.QueryString["PaymentToSupplierApplyId"];
            if (paymentToSupplierApplyFormBAL.DeletePaymentToSupplierApply(paymentToSupplierApplyFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = paymentToSupplierApplyFormUI.Tbl_PaymentToSupplierApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm : btnDelete_Click] An error occured in the processing of Record Id : " + paymentToSupplierApplyFormUI.Tbl_PaymentToSupplierApplyId + ". Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaymentToSupplierApplyList.aspx");
    }

    #region SupplierSearch

    protected void btnPaymentToSupplierSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPaymentToSupplierSearch.Visible = false;
        btnHtmlPaymentToSupplierClose.Visible = true;
        SearchSupplierList();
    }
    protected void btnClearPaymentToSupplierSearch_Click(object sender, EventArgs e)
    {

        BindSupplierList();
        gvPaymentToSupplierSearch.Visible = true;
        btnHtmlPaymentToSupplierSearch.Visible = true;
        btnHtmlPaymentToSupplierClose.Visible = false;
        txtPaymentToSupplierSearch.Text = "";
        txtPaymentToSupplierSearch.Focus();
    }
    protected void btnPaymentToSupplierRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindSupplierList();
    }
    #endregion SupplierSearch

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

    #region NonPOBasedInvoiceSearch
    protected void btnApplyToDocumentNonPOBasedInvoiceSearch_Click(object sender, EventArgs e)
    {
        btnApplyToDocumentNonPOBasedInvoiceSearch.Visible = false;
        btnHtmlApplyToDocumentNonPOBasedInvoiceClose.Visible = true;
        SearchNonPOBasedInvoiceList();
    }

    protected void btnClearApplyToDocumentNonPOBasedInvoiceSearch_Click(object sender, EventArgs e)
    {
        BindNonPOBasedInvoiceSearchList();
        gvApplyToDocumentNonPOBasedInvoiceSearch.Visible = true;
        btnHtmlApplyToDocumentNonPOBasedInvoiceSearch.Visible = true;
        btnHtmlApplyToDocumentNonPOBasedInvoiceClose.Visible = false;
        txtApplyToDocumentNonPOBasedInvoiceSearch.Text = "";
        txtApplyToDocumentNonPOBasedInvoiceSearch.Focus();
    }
    protected void btnApplyToDocumentNonPOBasedInvoiceRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindNonPOBasedInvoiceSearchList();
    }
    #endregion NonPOBasedInvoiceSearch

    #region POBasedInvoiceSearch
    protected void btnApplyToDocumentPOBasedInvoiceSearch_Click(object sender, EventArgs e)
    {
        btnApplyToDocumentPOBasedInvoiceSearch.Visible = false;
        btnHtmlApplyToDocumentPOBasedInvoiceClose.Visible = true;
        SearchPOBasedInvoiceList();
    }

    protected void btnClearApplyToDocumentPOBasedInvoiceSearch_Click(object sender, EventArgs e)
    {
        BindPOBasedInvoiceSearchList();
        gvApplyToDocumentPOBasedInvoiceSearch.Visible = true;
        btnHtmlApplyToDocumentPOBasedInvoiceSearch.Visible = true;
        btnHtmlApplyToDocumentPOBasedInvoiceClose.Visible = false;
        txtApplyToDocumentPOBasedInvoiceSearch.Text = "";
        txtApplyToDocumentPOBasedInvoiceSearch.Focus();
    }
    protected void btnApplyToDocumentPOBasedInvoiceRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPOBasedInvoiceSearchList();
    }
    #endregion POBasedInvoiceSearch

    #endregion Events

    #region Methods

    private void FillForm(PaymentToSupplierApplyFormUI paymentToSupplierApplyFormUI)
    {
        try
        {
            DataTable dtb = paymentToSupplierApplyFormBAL.GetPaymentToSupplierApplyListById(paymentToSupplierApplyFormUI);
            if (dtb.Rows.Count > 0)
            {
                txtPaymentToSupplierGuid.Text = dtb.Rows[0]["tbl_PaymentToSupplierId"].ToString();
                txtPaymentToSupplier.Text = dtb.Rows[0]["tbl_Supplier"].ToString();
                if (int.Parse(dtb.Rows[0]["opt_ApplyToDocumentType"].ToString()) == 1)
                {
                    rdbNonPOBasedInvoiceId.Checked = true;
                    txtApplyToDocumentNonPOBasedInvoice.Text = dtb.Rows[0]["PONumberNPOBI"].ToString();
                    txtApplyToDocumentNonPOBasedInvoiceGuid.Text = dtb.Rows[0]["tbl_ApplyToDocument"].ToString();
                }
                else if (int.Parse(dtb.Rows[0]["opt_ApplyToDocumentType"].ToString()) == 2)
                {
                    rdbPOBasedInvoiceId.Checked = true;
                    txtApplyToDocumentPOBasedInvoice.Text = dtb.Rows[0]["PONumberPOBI"].ToString();
                    txtApplyToDocumentPOBasedInvoiceGuid.Text = dtb.Rows[0]["tbl_ApplyToDocument"].ToString();
                }

                txtDueDate.Text = dtb.Rows[0]["DueDate"].ToString();
                txtRemainingAmount.Text = dtb.Rows[0]["RemainingAmount"].ToString();
                txtApplyAmount.Text = dtb.Rows[0]["ApplyAmount"].ToString();
                ddloptType.SelectedValue = dtb.Rows[0]["Type"].ToString();
                txtOrignalDocumentAmount.Text = dtb.Rows[0]["OrignalDocumentAmount"].ToString();
                txtDiscountDate.Text = dtb.Rows[0]["DiscountDate"].ToString();
                txtCurrencyId_ApplyToCurrencyGuid.Text = dtb.Rows[0]["tbl_CurrencyId_ApplyToCurrency"].ToString();
                txtCurrencyId_ApplyToCurrency.Text = dtb.Rows[0]["ApplyToCurrency"].ToString();

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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = paymentToSupplierApplyFormUI.Tbl_PaymentToSupplierApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void BindTypeDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_DownPaymentToSupplierApply";
            optionSetListUI.OptionSetName = "opt_Type";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddloptType.DataSource = dtb;
                ddloptType.DataBind();
                ddloptType.DataTextField = "OptionSetLable";
                ddloptType.DataValueField = "OptionSetValue";
                ddloptType.DataBind();
            }
            else
            {
                ddloptType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindTypeDropDownList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm : BindTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    public void BindPaymentToSupplierApply(PaymentToSupplierApplyListUI paymentToSupplierApplyListUI)
    {

        try
        {
            DataTable dtb = paymentToSupplierApplyListBAL.GetPaymentToSupplierApplyListByPaymentToSupplierId(paymentToSupplierApplyListUI);
            {
                if (dtb.Rows.Count > 0)
                {
                    txtPaymentToSupplierGuid.Text = dtb.Rows[0]["tbl_PaymentToSupplierId"].ToString();
                    txtPaymentToSupplier.Text = dtb.Rows[0]["tbl_PaymentToSupplier"].ToString();
                    txtSupplierId.Text = dtb.Rows[0]["tbl_Supplier"].ToString();
                    txtSupplierName.Text = dtb.Rows[0]["tbl_Supplier"].ToString();
                    txtType.Text = dtb.Rows[0]["DocumentType"].ToString();
                    txtCurrencyID.Text = dtb.Rows[0]["CurrencyName"].ToString();
                    txtDocumentNumber.Text = dtb.Rows[0]["DocumentNumber"].ToString();
                    txtOrignalAmount.Text = dtb.Rows[0]["Total"].ToString();
                    txtApplydate.Text = dtb.Rows[0]["ApplyDate"].ToString();
                    txtUnappliedAmount.Text = dtb.Rows[0]["Total"].ToString();

                    gvData.DataSource = dtb;
                    gvData.DataBind();
                    divError.Visible = false;
                    gvData.Visible = true;

                }
                else
                {
                    gvData.Visible = false;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearFormAppy();", true);
                }
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "txtDownPaymentcust_TextChanged()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = paymentToSupplierApplyFormUI.Tbl_PaymentToSupplierApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm : txtDownPaymentcust_TextChanged] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region Search  BindSupplier
    private void BindSupplierList()
    {
        try
        {
            DataTable dtb = paymentToSupplierListBAL.GetPaymentToSupplierList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPaymentToSupplierSearch.DataSource = dtb;
                gvPaymentToSupplierSearch.DataBind();
                divPaymentToSupplierSearchError.Visible = false;

            }
            else
            {
                divPaymentToSupplierSearchError.Visible = true;
                lblPaymentToSupplierSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPaymentToSupplierSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCustomerList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm : BindCustomerList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void SearchSupplierList()
    {
        try
        {
            PaymentToSupplierListUI paymentToSupplierListUI = new PaymentToSupplierListUI();
            CustomerListUI customerListUI = new CustomerListUI();
            customerListUI.Search = txtPaymentToSupplierSearch.Text;
            DataTable dtb = paymentToSupplierListBAL.GetPaymentToSupplierListById(paymentToSupplierListUI);


            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPaymentToSupplierSearch.DataSource = dtb;
                gvPaymentToSupplierSearch.DataBind();
                divPaymentToSupplierSearchError.Visible = false;

            }
            else
            {
                divPaymentToSupplierSearchError.Visible = true;
                lblPaymentToSupplierSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPaymentToSupplierSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchCustomer()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm : SearchCustomer] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion

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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm : SearchCurrencyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm : BindCurrencyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Currency Serach

    #region NonPOBasedInvoice Search
    private void SearchNonPOBasedInvoiceList()
    {

        try
        {
            NonPOBasedInvoiceListUI nonPOBasedInvoiceListUI = new NonPOBasedInvoiceListUI();
            nonPOBasedInvoiceListUI.Search = txtApplyToDocumentNonPOBasedInvoiceSearch.Text;


            DataTable dtb = nonPOBasedInvoiceListBAL.GetNonPOBasedInvoiceListBySearchParameters(nonPOBasedInvoiceListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvApplyToDocumentNonPOBasedInvoiceSearch.DataSource = dtb;
                gvApplyToDocumentNonPOBasedInvoiceSearch.DataBind();
                divApplyToDocumentNonPOBasedInvoiceSearchError.Visible = false;
            }
            else
            {
                divApplyToDocumentNonPOBasedInvoiceSearchError.Visible = true;
                lblApplyToDocumentNonPOBasedInvoiceSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvApplyToDocumentNonPOBasedInvoiceSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchNonPOBasedInvoiceList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm : SearchNonPOBasedInvoiceList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindNonPOBasedInvoiceSearchList()
    {
        try
        {
            DataTable dtb = nonPOBasedInvoiceListBAL.GetNonPOBasedInvoiceList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvApplyToDocumentNonPOBasedInvoiceSearch.DataSource = dtb;
                gvApplyToDocumentNonPOBasedInvoiceSearch.DataBind();
                divError.Visible = false;
                gvApplyToDocumentNonPOBasedInvoiceSearch.Visible = true;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvApplyToDocumentNonPOBasedInvoiceSearch.Visible = false;
            }

            txtApplyToDocumentNonPOBasedInvoiceSearch.Text = "";
            txtApplyToDocumentNonPOBasedInvoiceSearch.Focus();
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindNonPOBasedInvoiceSearchList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm : BindNonPOBasedInvoiceSearchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion NonPOBasedInvoice Search

    #region POBasedInvoice Search
    private void SearchPOBasedInvoiceList()
    {

        try
        {
            POBasedInvoiceListUI POBasedInvoiceListUI = new POBasedInvoiceListUI();
            POBasedInvoiceListUI.Search = txtApplyToDocumentPOBasedInvoiceSearch.Text;


            DataTable dtb = pOBasedInvoiceListBAL.GetPOBasedInvoiceListBySearchParameters(POBasedInvoiceListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvApplyToDocumentPOBasedInvoiceSearch.DataSource = dtb;
                gvApplyToDocumentPOBasedInvoiceSearch.DataBind();
                divApplyToDocumentPOBasedInvoiceSearchError.Visible = false;
            }
            else
            {
                divApplyToDocumentPOBasedInvoiceSearchError.Visible = true;
                lblApplyToDocumentPOBasedInvoiceSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvApplyToDocumentPOBasedInvoiceSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchPOBasedInvoiceList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm : SearchPOBasedInvoiceList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindPOBasedInvoiceSearchList()
    {
        try
        {
            DataTable dtb = pOBasedInvoiceListBAL.GetPOBasedInvoiceList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvApplyToDocumentPOBasedInvoiceSearch.DataSource = dtb;
                gvApplyToDocumentPOBasedInvoiceSearch.DataBind();
                divError.Visible = false;
                gvApplyToDocumentPOBasedInvoiceSearch.Visible = true;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvApplyToDocumentPOBasedInvoiceSearch.Visible = false;
            }

            txtApplyToDocumentPOBasedInvoiceSearch.Text = "";
            txtApplyToDocumentPOBasedInvoiceSearch.Focus();
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPOBasedInvoiceSearchList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierApplyForm : BindPOBasedInvoiceSearchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion POBasedInvoice Search

  

    #endregion Methods
}
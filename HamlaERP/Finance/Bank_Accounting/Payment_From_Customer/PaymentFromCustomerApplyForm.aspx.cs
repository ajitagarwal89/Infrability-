using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Bank_Accounting_Payment_From_Customers_PaymentFromCustomerApplyForm : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    PaymentFromCustomerApplyFormBAL paymentFromCustomerApplyFormBAL = new PaymentFromCustomerApplyFormBAL();
    PaymentFromCustomerApplyFormUI paymentFromCustomerApplyFormUI = new PaymentFromCustomerApplyFormUI();
    PaymentFromCustomerApplyListUI paymentFromCustomerApplyListUI = new PaymentFromCustomerApplyListUI();
    PaymentFromCustomerApplyListBAL paymentFromCustomerApplyListBAL = new PaymentFromCustomerApplyListBAL();

    SourceDocumentListBAL sourceDocumentListBAL = new SourceDocumentListBAL();
    PaymentFromCustomerListBAL paymentFromCustomerListBAL = new PaymentFromCustomerListBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    CustomerInvoiceProcessListBAL customerInvoiceProcessListBAL = new CustomerInvoiceProcessListBAL();
    CustomerInvoiceListBAL customerInvoiceListBAL = new CustomerInvoiceListBAL();
    #endregion Data Members 

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            if (Request.QueryString["PaymentFromCustomerId"] != null)
            {
                paymentFromCustomerApplyListUI.Tbl_PaymentFromCustomerId = Request.QueryString["PaymentFromCustomerId"];
                BindPaymentFromCustomerApply(paymentFromCustomerApplyListUI);
                BindTypeDropDownList();
            }
            else if (Request.QueryString["PaymentFromCustomerApplyId"] != null)
            {
                paymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId = Request.QueryString["PaymentFromCustomerApplyId"];

                BindTypeDropDownList();
                FillForm(paymentFromCustomerApplyFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update  Payment From Customer Apply";
            }
            else
            {
                BindTypeDropDownList();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Payment From Customer Apply";
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int applyToDocumentCustomerInvoice = 1;
        int applyToDocumentCustomerInvoiceProcess = 2;

        try
        {
            paymentFromCustomerApplyFormUI.CreatedBy = SessionContext.UserGuid;
            paymentFromCustomerApplyFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            paymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerId = txtPaymentFromCustomerGuid.Text;
            if(rdbtnCustomerInvoice.Checked)
            {
                paymentFromCustomerApplyFormUI.Tbl_ApplyToDocument = txtApplyotDocumentCIPGuid.Text;
                paymentFromCustomerApplyFormUI.opt_ApplyToDocumentType = applyToDocumentCustomerInvoice;
            }
            if(RdbtnCustomerInvoiceProcess.Checked)
            {
                paymentFromCustomerApplyFormUI.Tbl_ApplyToDocument = txtApplyotDocumentCIPGuid.Text;
                paymentFromCustomerApplyFormUI.opt_ApplyToDocumentType = applyToDocumentCustomerInvoiceProcess;
            }
            paymentFromCustomerApplyFormUI.DueDate = Convert.ToDateTime(txtDueDate.Text);
            paymentFromCustomerApplyFormUI.RemainingAmount = Convert.ToDecimal(txtRemainingAmount.Text);
            paymentFromCustomerApplyFormUI.ApplyAmount = Convert.ToDecimal(txtApplyAmount.Text);           
            paymentFromCustomerApplyFormUI.opt_Type = Convert.ToInt32(ddloptType.SelectedValue.ToString());
            paymentFromCustomerApplyFormUI.OrignalDocumentAmount = Convert.ToDecimal(txtOrignalDocumentAmount.Text);
            paymentFromCustomerApplyFormUI.DiscountDate = Convert.ToDateTime(txtDiscountDate.Text);
            paymentFromCustomerApplyFormUI.Tbl_CurrencyId_ApplyToCurrency = txtCurrencyId_ApplyToCurrencyGuid.Text;
            if (paymentFromCustomerApplyFormBAL.AddPaymentFromCustomerApply(paymentFromCustomerApplyFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_From_Customers_PaymentFromCustomerApplyForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_From_Customers_PaymentFromCustomerApplyForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int applyToDocumentCustomerInvoice = 1;
        int applyToDocumentCustomerInvoiceProcess = 2;

       
        try
        {
            paymentFromCustomerApplyFormUI.ModifiedBy = SessionContext.UserGuid;
            paymentFromCustomerApplyFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            paymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId = Request.QueryString["PaymentFromCustomerApplyId"];
            paymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerId = txtPaymentFromCustomerGuid.Text;

            if (rdbtnCustomerInvoice.Checked)
            {
                paymentFromCustomerApplyFormUI.Tbl_ApplyToDocument = txtApplyotDocumentCIPGuid.Text;
                paymentFromCustomerApplyFormUI.opt_ApplyToDocumentType = applyToDocumentCustomerInvoice;
            }
            if (RdbtnCustomerInvoiceProcess.Checked)
            {
                paymentFromCustomerApplyFormUI.Tbl_ApplyToDocument = txtApplyotDocumentCIPGuid.Text;
                paymentFromCustomerApplyFormUI.opt_ApplyToDocumentType = applyToDocumentCustomerInvoiceProcess;
            }

            paymentFromCustomerApplyFormUI.DueDate = Convert.ToDateTime(txtDueDate.Text);
            paymentFromCustomerApplyFormUI.RemainingAmount = Convert.ToDecimal(txtRemainingAmount.Text);
            paymentFromCustomerApplyFormUI.ApplyAmount = Convert.ToDecimal(txtApplyAmount.Text);
            paymentFromCustomerApplyFormUI.opt_Type = Convert.ToInt32(ddloptType.SelectedValue.ToString());
            paymentFromCustomerApplyFormUI.OrignalDocumentAmount = Convert.ToDecimal(txtOrignalDocumentAmount.Text);
            paymentFromCustomerApplyFormUI.DiscountDate = Convert.ToDateTime(txtDiscountDate.Text);
            paymentFromCustomerApplyFormUI.Tbl_CurrencyId_ApplyToCurrency = txtCurrencyId_ApplyToCurrencyGuid.Text;

            if (paymentFromCustomerApplyFormBAL.UpdatePaymentFromCustomerApply(paymentFromCustomerApplyFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_From_Customers_PaymentFromCustomerApplyForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_From_Customers_PaymentFromCustomerApplyForm : btnUpdate_Click] An error occured in the processing of Record Id : " + paymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId + ".  Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            paymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId = Request.QueryString["PaymentFromCustomerApplyId"];
            if (paymentFromCustomerApplyFormBAL.DeletePaymentFromCustomerApply(paymentFromCustomerApplyFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_From_Customers_PaymentFromCustomerApplyForm.CS";
            logExcpUIobj.RecordId = paymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_From_Customers_PaymentFromCustomerApplyForm : btnDelete_Click] An error occured in the processing of Record Id : " + paymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId + ". Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaymentFromCustomerApplyList.aspx");
    }
    protected void rdbtnCustomerInvoice_CheckedChanged(object sender, EventArgs e)
    {
        divCustomerInvoice.Visible = true;
        divCustomerInvoiceProcess.Visible = false;
    }
    protected void RdbtnCustomerInvoiceProcess_CheckedChanged(object sender, EventArgs e)
    {
        divCustomerInvoiceProcess.Visible = true;
        divCustomerInvoice.Visible = false;

    }

    #region CustomerSearch

    protected void btnPaymentFromCustomerSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPaymentFromCustomerSearch.Visible = false;
        btnHtmlPaymentFromCustomerClose.Visible = true;
        SearchCustomerList();
    }
    protected void btnClearPaymentFromCustomerSearch_Click(object sender, EventArgs e)
    {

        BindCustomerList();
        gvPaymentFromCustomerSearch.Visible = true;
        btnHtmlPaymentFromCustomerSearch.Visible = true;
        btnHtmlPaymentFromCustomerClose.Visible = false;
        txtPaymentFromCustomerSearch.Text = "";
        txtPaymentFromCustomerSearch.Focus();
    }
    protected void btnPaymentFromCustomerRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindCustomerList();
    }
    #endregion CustomerSearch

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

    #region Customer Invoice 
    protected void btnCustomerInvoiceSearch_Click(object sender, EventArgs e)
    {
        btnHtmlCustomerInvoiceSearch.Visible = false;
        btnHtmlCustomerInvoiceClose.Visible = true;
        SearchCustomerInvoiceList();
    }
    protected void btnClearCustomerInvoiceSearch_Click(object sender, EventArgs e)
    {
        BindCustomerInvoiceList();
        gvCustomerInvoiceSearch.Visible = true;
        btnHtmlCustomerInvoiceSearch.Visible = true;
        btnHtmlCustomerInvoiceClose.Visible = false;
        txtCustomerInvoiceSearch.Text = "";
        txtCustomerInvoiceSearch.Focus();
    }
    protected void btnCustomerInvoiceRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindCustomerInvoiceList();
    }
    #endregion  

    #region Customer Invoice Process
    protected void btnCustomerInvoiceProcessSearch_Click(object sender, EventArgs e)
    {
        btnHtmlCustomerInvoiceProcessSearch.Visible = false;
        btnHtmlCustomerInvoiceProcessClose.Visible = true;
        SearchCustomerInvoiceProcessList();
    }
    protected void btnClearCustomerInvoiceProcessSearch_Click(object sender, EventArgs e)
    {
        BindCustomerInvoiceProcessList();
        gvCustomerInvoiceProcessSearch.Visible = true;
        btnHtmlCustomerInvoiceProcessSearch.Visible = true;
        btnHtmlCustomerInvoiceProcessClose.Visible = false;
        txtCustomerInvoiceProcessSearch.Text = "";
        txtCustomerInvoiceProcessSearch.Focus();
    }
    protected void btnCustomerInvoiceProcessRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindCustomerInvoiceProcessList();
    }
    #endregion

    #endregion

    #region Methods

    private void FillForm(PaymentFromCustomerApplyFormUI paymentFromCustomerApplyFormUI)
    {
        try
        {
            DataTable dtb = paymentFromCustomerApplyFormBAL.GetPaymentFromCustomerApplyListById(paymentFromCustomerApplyFormUI);
            if (dtb.Rows.Count > 0)
            {
                txtPaymentFromCustomerGuid.Text = dtb.Rows[0]["tbl_PaymentFromCustomerId"].ToString();
                txtPaymentFromCustomer.Text = dtb.Rows[0]["tbl_Customer"].ToString();
                txtApplyToDocumentGuid.Text = "00000000-0000-0000-0000-000000000001";
                txtDueDate.Text = dtb.Rows[0]["DueDate"].ToString();
                txtRemainingAmount.Text = dtb.Rows[0]["RemainingAmount"].ToString();
                txtApplyAmount.Text = dtb.Rows[0]["ApplyAmount"].ToString();
                ddloptType.SelectedValue = dtb.Rows[0]["Type"].ToString();
                txtOrignalDocumentAmount.Text = dtb.Rows[0]["OrignalDocumentAmount"].ToString();
                txtDiscountDate.Text = dtb.Rows[0]["DiscountDate"].ToString();
                txtCurrencyId_ApplyToCurrencyGuid.Text = dtb.Rows[0]["tbl_CurrencyId_ApplyToCurrency"].ToString();
                txtCurrencyId_ApplyToCurrency.Text = dtb.Rows[0]["CurrencyName"].ToString();

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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_PaymentFromCustomerApplyForm.CS";
            logExcpUIobj.RecordId = paymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_PaymentFromCustomerApplyForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void BindTypeDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_DownPaymentFromCustomerApply";
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_PaymentFromCustomerApplyForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_PaymentFromCustomerApplyForm : BindTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    public void BindPaymentFromCustomerApply(PaymentFromCustomerApplyListUI paymentFromCustomerApplyListUI)
    {

        try
        {
            DataTable dtb = paymentFromCustomerApplyListBAL.GetPaymentFromCustomerApplyListByPaymentFromCustomerId(paymentFromCustomerApplyListUI);
            {
                if (dtb.Rows.Count > 0)
                {
                    txtPaymentFromCustomer.Text = dtb.Rows[0]["tbl_PaymentFromCustomer"].ToString();
                    txtPaymentFromCustomerGuid.Text = dtb.Rows[0]["tbl_PaymentFromCustomerId"].ToString();
                    txtCustomerID.Text = dtb.Rows[0]["tbl_Customer"].ToString();
                    txtCustomerName.Text = dtb.Rows[0]["tbl_Customer"].ToString();
                    txtType.Text = dtb.Rows[0]["Type"].ToString();
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_From_Customers_PaymentFromCustomerApplyForm.CS";
            logExcpUIobj.RecordId = paymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_From_Customers_PaymentFromCustomerApplyForm : txtDownPaymentcust_TextChanged] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region Search  BindCustomer
    private void BindCustomerList()
    {
        try
        {
            DataTable dtb = paymentFromCustomerListBAL.GetPaymentFromCustomerList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPaymentFromCustomerSearch.DataSource = dtb;
                gvPaymentFromCustomerSearch.DataBind();
                divPaymentFromCustomerSearchError.Visible = false;

            }
            else
            {
                divPaymentFromCustomerSearchError.Visible = true;
                lblPaymentFromCustomerSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPaymentFromCustomerSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCustomerList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_From_Customers_PaymentFromCustomerApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_From_Customers_PaymentFromCustomerApplyForm : BindCustomerList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void SearchCustomerList()
    {
        try
        {
            PaymentFromCustomerListUI paymentFromCustomerListUI = new PaymentFromCustomerListUI();
            CustomerListUI customerListUI = new CustomerListUI();
            customerListUI.Search = txtPaymentFromCustomerSearch.Text;
            DataTable dtb = paymentFromCustomerListBAL.GetPaymentFromCustomerListById(paymentFromCustomerListUI);


            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPaymentFromCustomerSearch.DataSource = dtb;
                gvPaymentFromCustomerSearch.DataBind();
                divPaymentFromCustomerSearchError.Visible = false;

            }
            else
            {
                divPaymentFromCustomerSearchError.Visible = true;
                lblPaymentFromCustomerSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPaymentFromCustomerSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchCustomer()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_From_Customers_PaymentFromCustomerApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_From_Customers_PaymentFromCustomerApplyForm : SearchCustomer] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_From_Customers_PaymentFromCustomerApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_From_Customers_PaymentFromCustomerApplyForm : SearchCurrencyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_From_Customers_PaymentFromCustomerApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_From_Customers_PaymentFromCustomerApplyForm : BindCurrencyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Currency Serach

    #region Customer Invoice Search    
    private void SearchCustomerInvoiceList()
    {
        try
        {
            CustomerInvoiceListUI customerInvoiceListUI = new CustomerInvoiceListUI();
            customerInvoiceListUI.Search = txtCustomerInvoiceSearch.Text;


            DataTable dtb = customerInvoiceListBAL.GetCustomerInvoiceListBySearchParameters(customerInvoiceListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCustomerInvoiceSearch.DataSource = dtb;
                gvCustomerInvoiceSearch.DataBind();
                divCustomerInvoiceSearchError.Visible = false;
            }
            else
            {
                divCustomerInvoiceSearchError.Visible = true;
                lblCustomerInvoiceSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCustomerInvoiceSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchApplytoDocumentList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_Default.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_Default : SearchApplytoDocumentList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindCustomerInvoiceList()
    {
        try
        {
            DataTable dtb = customerInvoiceListBAL.GetCustomerInvoiceList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCustomerInvoiceSearch.DataSource = dtb;
                gvCustomerInvoiceSearch.DataBind();
                divCustomerInvoiceSearchError.Visible = false;

            }
            else
            {
                divCustomerInvoiceSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCustomerInvoiceSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindApplytoDocumentList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_Default.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_Default : BindApplytoDocumentList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion

    #region Customer Invoice Process Search    
    private void SearchCustomerInvoiceProcessList()
    {
        try
        {
            CustomerInvoiceProcessListUI customerInvoiceProcessListUI = new CustomerInvoiceProcessListUI();
            customerInvoiceProcessListUI.Search = txtCustomerInvoiceProcessSearch.Text;


            DataTable dtb = customerInvoiceProcessListBAL.GetCustomerInvoiceProcessListBySearchParameters(customerInvoiceProcessListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCustomerInvoiceProcessSearch.DataSource = dtb;
                gvCustomerInvoiceProcessSearch.DataBind();
                divCustomerInvoiceProcessSearchError.Visible = false;
            }
            else
            {
                divCustomerInvoiceProcessSearchError.Visible = true;
                lblCustomerInvoiceProcessSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCustomerInvoiceProcessSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchCustomerInvoiceProcessList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_Default.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_Default : SearchCustomerInvoiceProcessList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindCustomerInvoiceProcessList()
    {
        try
        {
            DataTable dtb = customerInvoiceProcessListBAL.GetCustomerInvoiceProcessList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCustomerInvoiceProcessSearch.DataSource = dtb;
                gvCustomerInvoiceProcessSearch.DataBind();
                divCustomerInvoiceProcessSearchError.Visible = false;

            }
            else
            {
                divCustomerInvoiceProcessSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCustomerInvoiceProcessSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCustomerInvoiceProcessList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_Default.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_Default : BindCustomerInvoiceProcessList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  

    #endregion Methods

}
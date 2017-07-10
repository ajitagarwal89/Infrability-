using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;



public partial class Finance_Bank_Accounting_Customer_Down_Payment_Default : System.Web.UI.Page
{

    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();


    DownPaymentFromCustomerApplyFormBAL downPaymentFromCustomerApplyFormBAL = new DownPaymentFromCustomerApplyFormBAL();
    DownPaymentFromCustomerApplyFormUI downPaymentFromCustomerApplyFormUI = new DownPaymentFromCustomerApplyFormUI();

    DownPaymentFromCustomerApplyListBAL downPaymentFromCustomerApplyListBAL = new DownPaymentFromCustomerApplyListBAL();
    DownPaymentFromCustomerApplyListUI downPaymentFromCustomerApplyListUI = new DownPaymentFromCustomerApplyListUI();

    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    CustomerInvoiceListBAL customerInvoiceListBAL = new CustomerInvoiceListBAL();
    CustomerInvoiceProcessListBAL customerInvoiceProcessListBAL = new CustomerInvoiceProcessListBAL();

    SourceDocumentListBAL sourceDocumentListBAL = new SourceDocumentListBAL();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    CurrencyListUI currencyListUI = new CurrencyListUI();
    DownPaymentFromCustomerListBAL downPaymentFromCustomerListBAL = new DownPaymentFromCustomerListBAL();
    DownPaymentFromCustomerListUI downPaymentFromCustomerListUI = new DownPaymentFromCustomerListUI();
    DownPaymentFromCustomerFormBAL downPaymentFromCustomerFormBAL = new DownPaymentFromCustomerFormBAL();
    DownPaymentFromCustomerFormUI downPaymentFromCustomerFormUI = new DownPaymentFromCustomerFormUI();

    #endregion Data Members

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {      
        if (!Page.IsPostBack)
        {

            if (Request.QueryString["DownPaymentFromCustomerId"] != null)
            {
                downPaymentFromCustomerApplyListUI.Tbl_DownPaymentFromCustomerId = Request.QueryString["DownPaymentFromCustomerId"];
                BindDownPaymentFromCustomerApply(downPaymentFromCustomerApplyListUI);
                BindTypeDropDownList();
            }



            else if (Request.QueryString["DownPaymentFromCustomerApplyId"] != null)
            {
                downPaymentFromCustomerApplyFormUI.Tbl_DownPaymentFromCustomerApplyId = Request.QueryString["DownPaymentFromCustomerApplyId"];

                BindTypeDropDownList();

                FillForm(downPaymentFromCustomerApplyFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update DownPaymentFromCustomerApply";
            }
            else
            {

                BindTypeDropDownList();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New DownPaymentFromCustomerApply";
            }
        }

    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        int applyToDocumentCustomerInvoice = 1;
        int applyToDocumentCustomerInvoiceProcess = 2;


        try
        {

            downPaymentFromCustomerApplyFormUI.CreatedBy = SessionContext.UserGuid;
            downPaymentFromCustomerApplyFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            downPaymentFromCustomerApplyFormUI.Tbl_DownPaymentFromCustomerId = txtDownPaymentcustGuid.Text;
            if (rdbtnCustomerInvoice.Checked)
            {
                downPaymentFromCustomerApplyFormUI.Tbl_ApplyToDocument = txtApplyToDocumentGuid.Text;
                downPaymentFromCustomerApplyFormUI.opt_ApplyToDocumentType = applyToDocumentCustomerInvoice;
            }
            else if (RdbtnCustomerInvoiceProcess.Checked)
            {
                downPaymentFromCustomerApplyFormUI.Tbl_ApplyToDocument = txtApplyotDocumentCIPGuid.Text;
                downPaymentFromCustomerApplyFormUI.opt_ApplyToDocumentType = applyToDocumentCustomerInvoiceProcess;
            }
            downPaymentFromCustomerApplyFormUI.DueDate = Convert.ToDateTime(txtDueDate.Text);
            downPaymentFromCustomerApplyFormUI.RemainingAmount = Convert.ToDecimal(txtRemainingAmount.Text);
            downPaymentFromCustomerApplyFormUI.ApplyAmount = Convert.ToDecimal(txtApplyAmount.Text);
            downPaymentFromCustomerApplyFormUI.opt_Type = Convert.ToInt32(ddloptType.SelectedValue);
            downPaymentFromCustomerApplyFormUI.OrignalDocumentAmount = Convert.ToDecimal(txtOrignalDocumentAmount.Text);
            downPaymentFromCustomerApplyFormUI.DiscountDate = Convert.ToDateTime(txtDiscountDate.Text);
            downPaymentFromCustomerApplyFormUI.Tbl_CurrencyId_ApplyToCurrency = txtCurrencyGuid.Text;


            if (downPaymentFromCustomerApplyFormBAL.AddDownPaymentFromCustomerApply(downPaymentFromCustomerApplyFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_Default.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_Default : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
     {
        int applyToDocumentCustomerInvoice = 1;
        int applyToDocumentCustomerInvoiceProcess = 2;

        try
        {        
            downPaymentFromCustomerApplyFormUI.ModifiedBy = SessionContext.UserGuid;
            downPaymentFromCustomerApplyFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            downPaymentFromCustomerApplyFormUI.Tbl_DownPaymentFromCustomerApplyId = Request.QueryString["DownPaymentFromCustomerApplyId"];
            downPaymentFromCustomerApplyFormUI.Tbl_DownPaymentFromCustomerId = txtDownPaymentcustGuid.Text;
            if (rdbtnCustomerInvoice.Checked)
            {
                downPaymentFromCustomerApplyFormUI.Tbl_ApplyToDocument = txtApplyToDocumentGuid.Text;
                downPaymentFromCustomerApplyFormUI.opt_ApplyToDocumentType = applyToDocumentCustomerInvoice;
            }
            else if (RdbtnCustomerInvoiceProcess.Checked)
            {
                downPaymentFromCustomerApplyFormUI.Tbl_ApplyToDocument = txtApplyotDocumentCIPGuid.Text;
                downPaymentFromCustomerApplyFormUI.opt_ApplyToDocumentType = applyToDocumentCustomerInvoiceProcess;
            }
            downPaymentFromCustomerApplyFormUI.DueDate = Convert.ToDateTime(txtDueDate.Text);           
            downPaymentFromCustomerApplyFormUI.RemainingAmount = Convert.ToDecimal(txtRemainingAmount.Text);
            downPaymentFromCustomerApplyFormUI.ApplyAmount = Convert.ToDecimal(txtApplyAmount.Text);
            downPaymentFromCustomerApplyFormUI.opt_Type = Convert.ToInt32(ddloptType.SelectedValue);
            downPaymentFromCustomerApplyFormUI.OrignalDocumentAmount = Convert.ToDecimal(txtOrignalDocumentAmount.Text);
            downPaymentFromCustomerApplyFormUI.DiscountDate = Convert.ToDateTime(txtDiscountDate.Text);
            downPaymentFromCustomerApplyFormUI.Tbl_CurrencyId_ApplyToCurrency = txtCurrencyGuid.Text;


            if (downPaymentFromCustomerApplyFormBAL.UpdateDownPaymentFromCustomerApply(downPaymentFromCustomerApplyFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_Default.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_Default : btnUpdate_Click] An error occured in the processing of Record Id : " + downPaymentFromCustomerApplyFormUI.Tbl_DownPaymentFromCustomerApplyId + ".  Details : [" + exp.ToString() + "]");
        }


    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            downPaymentFromCustomerApplyFormUI.Tbl_DownPaymentFromCustomerApplyId = Request.QueryString["DownPaymentFromCustomerApplyId"];

            if (downPaymentFromCustomerApplyFormBAL.DeleteDownPaymentFromCustomerApply(downPaymentFromCustomerApplyFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_Default.CS";
            logExcpUIobj.RecordId = downPaymentFromCustomerApplyFormUI.Tbl_DownPaymentFromCustomerApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_Default : btnDelete_Click] An error occured in the processing of Record Id : " + downPaymentFromCustomerApplyFormUI.Tbl_DownPaymentFromCustomerApplyId + ". Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("DownPaymentFromCustomerApplyList.aspx");
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

    protected void txtDownPaymentcust_TextChanged(object sender, EventArgs e)
    {
        downPaymentFromCustomerApplyListUI.Tbl_DownPaymentFromCustomerId = txtDownPaymentcustGuid.Text;
        BindDownPaymentFromCustomerApply(downPaymentFromCustomerApplyListUI);

    }


    #region DownPaymentCust Search
    protected void btnDownPaymentCustSearch_Click(object sender, EventArgs e)
    {
        btnHtmlDownPaymentCustSearch.Visible = false;
        btnHtmlDownPaymentCustClose.Visible = true;
        SearchDownPaymentCustList();
    }
    protected void btnClearDownPaymentCustSearch_Click(object sender, EventArgs e)
    {
        BindDownPaymentCustList();
        gvDownPaymentCustSearch.Visible = true;
        btnHtmlDownPaymentCustSearch.Visible = true;
        btnHtmlDownPaymentCustClose.Visible = false;
        txtDownPaymentCustSearch.Text = "";
        txtDownPaymentCustSearch.Focus();
    }
    protected void btnDownPaymentCustRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindDownPaymentCustList();
    }
    #endregion  Search

    #region Currency Search
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
    #endregion Batch Search

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
            logExcpUIobj.MethodName = "BindDocumentTypeDropDownList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_Default.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_Default : BindDocumentTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void FillForm(DownPaymentFromCustomerApplyFormUI downPaymentFromCustomerApplyFormUI)
    {
        try
        {
            DataTable dtb = downPaymentFromCustomerApplyFormBAL.GetDownPaymentFromCustomerApplyListById(downPaymentFromCustomerApplyFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtDownPaymentcustGuid.Text = dtb.Rows[0]["tbl_DownPaymentFromCustomerId"].ToString();
                txtDownPaymentcust.Text = dtb.Rows[0]["tbl_DownPaymentFromCustomer"].ToString();
                txtApplyToDocumentGuid.Text = dtb.Rows[0]["tbl_ApplyToDocument"].ToString();
                txtDueDate.Text = dtb.Rows[0]["DueDate"].ToString();
                txtRemainingAmount.Text = dtb.Rows[0]["RemainingAmount"].ToString();
                txtApplyAmount.Text = dtb.Rows[0]["ApplyAmount"].ToString();
                ddloptType.SelectedValue = dtb.Rows[0]["opt_Type"].ToString();
                txtOrignalDocumentAmount.Text = dtb.Rows[0]["OrignalDocumentAmount"].ToString();
                txtDiscountDate.Text = dtb.Rows[0]["DiscountDate"].ToString();
                txtCurrencyGuid.Text = dtb.Rows[0]["tbl_CurrencyId_ApplyToCurrency"].ToString();
                txtCurrency.Text = dtb.Rows[0]["CurrencyName"].ToString();

                downPaymentFromCustomerApplyListUI.Tbl_DownPaymentFromCustomerId = dtb.Rows[0]["tbl_DownPaymentFromCustomerId"].ToString();
                BindDownPaymentFromCustomerApply(downPaymentFromCustomerApplyListUI);
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotLoadData;

            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "FillForm()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_Default.CS";
            logExcpUIobj.RecordId = downPaymentFromCustomerApplyFormUI.Tbl_DownPaymentFromCustomerApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_Default : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }

    public void BindDownPaymentFromCustomerApply(DownPaymentFromCustomerApplyListUI downPaymentFromCustomerApplyListUI)
    {

        try
        {
            DataTable dtb = downPaymentFromCustomerApplyListBAL.GetDownPaymentFromCustomerApplyListByDownPaymentFromCustomerId(downPaymentFromCustomerApplyListUI);
            {
                if (dtb.Rows.Count > 0)
                {
                    txtDownPaymentcust.Text = dtb.Rows[0]["tbl_DownPaymentFromCustomer"].ToString();
                    txtDownPaymentcustGuid.Text = dtb.Rows[0]["tbl_DownPaymentFromCustomerId"].ToString();
                    txtCustomerID.Text = dtb.Rows[0]["tbl_Customer"].ToString();
                    txtCustomerName.Text = dtb.Rows[0]["tbl_Customer"].ToString();
                    txtType.Text = dtb.Rows[0]["opt_DocumentType"].ToString();
                    txtCurrencyID.Text = dtb.Rows[0]["CurrencyName"].ToString();
                    txtDocumentNumber.Text = dtb.Rows[0]["DocumentNumber"].ToString();
                    txtOrignalAmount.Text = dtb.Rows[0]["TotalAmount"].ToString();
                    txtApplydate.Text = dtb.Rows[0]["ApplyDate"].ToString();
                    txtUnappliedAmount.Text = dtb.Rows[0]["TotalAmount"].ToString();

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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_Default.CS";
            logExcpUIobj.RecordId = downPaymentFromCustomerApplyFormUI.Tbl_DownPaymentFromCustomerApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_Default : txtDownPaymentcust_TextChanged] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region DownPaymentCust Search    
    private void SearchDownPaymentCustList()
    {
        try
        {
            DownPaymentFromCustomerListUI DownPaymentFromCustomerListUI = new DownPaymentFromCustomerListUI();
            downPaymentFromCustomerListUI.Search = txtDownPaymentCustSearch.Text;


            DataTable dtb = downPaymentFromCustomerListBAL.GetDownPaymentFromCustomerListBySearchParameters(downPaymentFromCustomerListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvDownPaymentCustSearch.DataSource = dtb;
                gvDownPaymentCustSearch.DataBind();
                divDownPaymentCustSearchError.Visible = false;
            }
            else
            {
                divDownPaymentCustSearchError.Visible = true;
                lblDownPaymentCustSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvDownPaymentCustSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchDownPaymentCustList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_Default.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_Default : SearchBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindDownPaymentCustList()
    {
        try
        {
            DataTable dtb = downPaymentFromCustomerListBAL.GetDownPaymentFromCustomerList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvDownPaymentCustSearch.DataSource = dtb;
                gvDownPaymentCustSearch.DataBind();
                divDownPaymentCustSearchError.Visible = false;

            }
            else
            {
                divDownPaymentCustSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvDownPaymentCustSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindBatchList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_Default.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_Default : BindBatchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion 

    #region Currency Search
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm : SearchCurrency] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Currency Search

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

    #endregion



  
}






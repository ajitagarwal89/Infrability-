using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Accounts_Receivable_Customer__Invoice__With_Sales_Order_CustomerInvoiceDistribution : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    CustomerInvoiceDistributionFormBAL customerInvoiceDistributionFormBAL = new CustomerInvoiceDistributionFormBAL();
    CustomerInvoiceDistributionFormUI customerInvoiceDistributionFormUI = new CustomerInvoiceDistributionFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    CustomerInvoiceDistributionListBAL customerInvoiceDistributionListBAL = new CustomerInvoiceDistributionListBAL();


    CustomerInvoiceListBAL customerInvoiceListBAL = new CustomerInvoiceListBAL();
    CustomerInvoiceListUI customerInvoiceListUI = new CustomerInvoiceListUI();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    GLAccountListUI gLAccountListUI = new GLAccountListUI();

    CommonDateClasses commonDateClasses = new CommonDateClasses();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {

        CustomerInvoiceDistributionFormUI customerInvoiceDistributionFormUI = new CustomerInvoiceDistributionFormUI();

        if (!Page.IsPostBack)
        {

            if (Request.QueryString["CustomerInvoiceDistributionId"] != null)
            {
                customerInvoiceDistributionFormUI.Tbl_CustomerInvoiceDistributionId = Request.QueryString["CustomerInvoiceDistributionId"];

                BindCustomerInvoiceDistribution(customerInvoiceDistributionFormUI);
                BindGLAccountTypeDropDownList();
                btnAuditHistory.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btnBack.Visible = true;
            }         
            else  if (Request.QueryString["CustomerInvoiceDistributionId"] != null || Request.QueryString["recordId"] != null)
            {
                customerInvoiceDistributionFormUI.Tbl_CustomerInvoiceDistributionId = (Request.QueryString["CustomerInvoiceDistributionId"] != null ? Request.QueryString["CustomerInvoiceDistributionId"] : Request.QueryString["recordId"]);

                BindGLAccountTypeDropDownList();


                FillForm(customerInvoiceDistributionFormUI);

                
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Customer Invoice Distribution";
            }
            else
            {
                BindGLAccountTypeDropDownList();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New Customer Invoice Distribution";
            }
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int accountType = Convert.ToInt32(ddlOpt_GLAccountType.SelectedValue);
            int credit = (int)Enums.CommonEnum.type.Credit;
            int debit = (int)Enums.CommonEnum.type.Debit;

            if (ddlOpt_GLAccountType.SelectedIndex != 0)
            {

                customerInvoiceDistributionFormUI.CreatedBy = SessionContext.UserGuid;
                customerInvoiceDistributionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

                customerInvoiceDistributionFormUI.Tbl_CustomerInvoiceId = txtCustomerInvoiceIdGuid.Text;
                customerInvoiceDistributionFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text;
                customerInvoiceDistributionFormUI.Opt_GLAccountType = Convert.ToInt16(ddlOpt_GLAccountType.SelectedValue);
                customerInvoiceDistributionFormUI.Description = txtDescription.Text;
                customerInvoiceDistributionFormUI.DistributionReference = txtDistributionReference.Text;

                if (accountType == credit)
                {
                    customerInvoiceDistributionFormUI.Credit = Decimal.Parse(txtCredit.Text);
                    customerInvoiceDistributionFormUI.OriginatingCredit = Convert.ToDecimal(txtCredit.Text);

                }
                else
                {
                    customerInvoiceDistributionFormUI.Credit = 0;
                    customerInvoiceDistributionFormUI.OriginatingCredit = 0;

                }
                if (accountType == debit)
                {
                    customerInvoiceDistributionFormUI.Debit = Decimal.Parse(txtDebit.Text);
                    customerInvoiceDistributionFormUI.OriginatingDebit = Convert.ToDecimal(txtOriginatingDebit.Text);


                }
                else
                {
                    customerInvoiceDistributionFormUI.Debit = 0;
                    customerInvoiceDistributionFormUI.OriginatingDebit = 0;

                }

                if (customerInvoiceDistributionFormBAL.AddCustomerInvoiceDistribution(customerInvoiceDistributionFormUI) == 1)
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
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Please select GL Account type');", true);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer__Invoice__With_Sales_Order_CustomerInvoiceDistribution.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer__Invoice__With_Sales_Order_CustomerInvoiceDistribution : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            int accountType = Convert.ToInt32(ddlOpt_GLAccountType.SelectedValue);
            int credit = (int)Enums.CommonEnum.type.Credit;
            int debit = (int)Enums.CommonEnum.type.Debit;

            if (ddlOpt_GLAccountType.SelectedIndex != 0)
            {
                customerInvoiceDistributionFormUI.ModifiedBy = SessionContext.UserGuid;
            customerInvoiceDistributionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            customerInvoiceDistributionFormUI.Tbl_CustomerInvoiceDistributionId = Request.QueryString["CustomerInvoiceDistributionId"];

            customerInvoiceDistributionFormUI.Tbl_CustomerInvoiceId = txtCustomerInvoiceIdGuid.Text;
            customerInvoiceDistributionFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text;
            customerInvoiceDistributionFormUI.Opt_GLAccountType = Convert.ToInt16(ddlOpt_GLAccountType.SelectedValue);
            customerInvoiceDistributionFormUI.Description = txtDescription.Text;
            customerInvoiceDistributionFormUI.DistributionReference = txtDistributionReference.Text;
                if (accountType == credit)
                {
                    customerInvoiceDistributionFormUI.Credit = Decimal.Parse(txtCredit.Text);
                    customerInvoiceDistributionFormUI.OriginatingCredit = Convert.ToDecimal(txtCredit.Text);

                }
                else
                {
                    customerInvoiceDistributionFormUI.Credit = 0;
                    customerInvoiceDistributionFormUI.OriginatingCredit = 0;

                }
                if (accountType == debit)
                {
                    customerInvoiceDistributionFormUI.Debit = Decimal.Parse(txtDebit.Text);
                    customerInvoiceDistributionFormUI.OriginatingDebit = Convert.ToDecimal(txtOriginatingDebit.Text);


                }
                else
                {
                    customerInvoiceDistributionFormUI.Debit = 0;
                    customerInvoiceDistributionFormUI.OriginatingDebit = 0;

                }

            if (customerInvoiceDistributionFormBAL.UpdateCustomerInvoiceDistribution(customerInvoiceDistributionFormUI) == 1)
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
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Please select GL Account type');", true);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer__Invoice__With_Sales_Order_CustomerInvoiceDistribution.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer__Invoice__With_Sales_Order_CustomerInvoiceDistribution : btnUpdate_Click] An error occured in the processing of Record Id : " + customerInvoiceDistributionFormUI.Tbl_CustomerInvoiceDistributionId + ".  Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            customerInvoiceDistributionFormUI.Tbl_CustomerInvoiceDistributionId = Request.QueryString["CustomerInvoiceDistributionId"];

            if (customerInvoiceDistributionFormBAL.DeleteCustomerInvoiceDistribution(customerInvoiceDistributionFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer__Invoice__With_Sales_Order_CustomerInvoiceDistribution.CS";
            logExcpUIobj.RecordId = customerInvoiceDistributionFormUI.Tbl_CustomerInvoiceDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer_Invoice_With_Sales_Order_CustomerInvoiceDistribution : btnDelete_Click] An error occured in the processing of Record Id : " + customerInvoiceDistributionFormUI.Tbl_CustomerInvoiceDistributionId + ". Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerInvoiceDistributionList.aspx");
    }

    protected void txtCustomerInvoiceId_TextChanged(object sender, EventArgs e)
    {
        customerInvoiceDistributionFormUI.Tbl_CustomerInvoiceId = txtCustomerInvoiceIdGuid.Text;
        BindCustomerInvoiceDistribution(customerInvoiceDistributionFormUI);
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Finance/Accounts_Receivable/Customer_Invoice_(With_Sales_Order)/CustomerInvoiceDistributionForm.aspx";
        string recordId = Request.QueryString["CustomerInvoiceDistributionId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    #region Customer Invoice Id Search
    protected void btnCustomerInvoiceIdSearch_Click(object sender, EventArgs e)
    {
        btnHtmlCustomerInvoiceIdSearch.Visible = false;
        btnHtmlCustomerInvoiceIdClose.Visible = true;
        SearchCustomerInvoiceIdList();
    }
    protected void btnClearCustomerInvoiceIdSearch_Click(object sender, EventArgs e)
    {
        BindCustomerInvoiceIdList();
        gvCustomerInvoiceIdSearch.Visible = true;
        btnHtmlCustomerInvoiceIdSearch.Visible = true;
        btnHtmlCustomerInvoiceIdClose.Visible = false;
        txtCustomerInvoiceIdSearch.Text = "";
        txtCustomerInvoiceIdSearch.Focus();
    }
    protected void btnCustomerInvoiceIdRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindCustomerInvoiceIdList();
    }
    #endregion  Search

    #region Events GL Account
    protected void btnGLAccountSearch_Click(object sender, EventArgs e)
    {
        btnHtmlGLAccountSearch.Visible = false;
        btnHtmlGLAccountClose.Visible = true;
        SearchGLAccountList();

    }
    protected void btnClearGLAccountSearch_Click(object sender, EventArgs e)
    {
        BindGLAccountList();
        gvGLAccountSearch.Visible = true;
        btnHtmlGLAccountSearch.Visible = true;
        btnHtmlGLAccountClose.Visible = false;
        txtGLAccountSearch.Text = "";
        txtGLAccountSearch.Focus();

    }
    protected void btnGLAccountRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindGLAccountList();
    }
    #endregion
    protected void ddlOpt_GLAccountType_SelectedIndexChanged(object sender, EventArgs e)
    {
        AccountType();
    }
    #endregion

    #region Methods

    #region CustomerInvoiceId Search    
    private void SearchCustomerInvoiceIdList()
    {
        try
        {
            CustomerInvoiceListUI CustomerInvoiceListUI = new CustomerInvoiceListUI();
            CustomerInvoiceListUI.Search = txtCustomerInvoiceIdSearch.Text;


            DataTable dtb = customerInvoiceListBAL.GetCustomerInvoiceListBySearchParameters(CustomerInvoiceListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCustomerInvoiceIdSearch.DataSource = dtb;
                gvCustomerInvoiceIdSearch.DataBind();
                divCustomerInvoiceIdSearchError.Visible = false;
            }
            else
            {
                divCustomerInvoiceIdSearchError.Visible = true;
                lblCustomerInvoiceIdSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCustomerInvoiceIdSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchCustomerInvoiceIdList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer__Invoice__With_Sales_Order_CustomerInvoiceDistribution.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer__Invoice__With_Sales_Order_CustomerInvoiceDistribution : SearchCustomerInvoiceIdList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindCustomerInvoiceIdList()
    {
        try
        {
            DataTable dtb = customerInvoiceListBAL.GetCustomerInvoiceList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCustomerInvoiceIdSearch.DataSource = dtb;
                gvCustomerInvoiceIdSearch.DataBind();
                divCustomerInvoiceIdSearchError.Visible = false;

            }
            else
            {
                divCustomerInvoiceIdSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCustomerInvoiceIdSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCustomerInvoiceIdList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer__Invoice__With_Sales_Order_CustomerInvoiceDistribution.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer__Invoice__With_Sales_Order_CustomerInvoiceDistribution : BindCustomerInvoiceIdList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion CustomerInvoiceId Search

    #region Gl Account
    private void SearchGLAccountList()
    {
        try
        {
            GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtGLAccountSearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountSearch.DataSource = dtb;
                gvGLAccountSearch.DataBind();
                divGLAccountSearchError.Visible = false;
            }
            else
            {
                divGLAccountSearchError.Visible = true;
                lblGLAccountSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchGLAccountList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer__Invoice__With_Sales_Order_CustomerInvoiceDistribution.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer__Invoice__With_Sales_Order_CustomerInvoiceDistribution : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }


    }
    private void BindGLAccountList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountSearch.DataSource = dtb;
                gvGLAccountSearch.DataBind();
                divGLAccountSearchError.Visible = false;
            }
            else
            {
                divGLAccountSearchError.Visible = true;
                lblGLAccountSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindGLAccountList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer__Invoice__With_Sales_Order_CustomerInvoiceDistribution.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer__Invoice__With_Sales_Order_CustomerInvoiceDistribution : BindGLAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion

    private void BindGLAccountTypeDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_CustomerInvoiceDistribution";
            optionSetListUI.OptionSetName = "opt_GLAccountType";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlOpt_GLAccountType.DataSource = dtb;
                ddlOpt_GLAccountType.DataBind();
                ddlOpt_GLAccountType.DataTextField = "OptionSetLable";
                ddlOpt_GLAccountType.DataValueField = "OptionSetValue";
                ddlOpt_GLAccountType.DataBind();
                ddlOpt_GLAccountType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlOpt_GLAccountType.SelectedIndex = 0;

            }
            else
            {
                ddlOpt_GLAccountType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindDocumentTypeDropDownList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer__Invoice__With_Sales_Order_CustomerInvoiceDistribution.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer__Invoice__With_Sales_Order_CustomerInvoiceDistribution : BindGLAccountTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void FillForm(CustomerInvoiceDistributionFormUI CustomerInvoiceDistributionFormUI)
    {
        try
        {
            DataTable dtb = customerInvoiceDistributionFormBAL.GetCustomerInvoiceDistributionListById(CustomerInvoiceDistributionFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtCustomerInvoiceIdGuid.Text = dtb.Rows[0]["tbl_CustomerInvoiceId"].ToString();
                txtCustomerInvoiceId.Text = dtb.Rows[0]["tbl_CustomerInvoice"].ToString();
                txtGLAccountGuid.Text = dtb.Rows[0]["tbl_GLAccountId"].ToString();
                txtGLAccount.Text = dtb.Rows[0]["tbl_GLAccount"].ToString();
                ddlOpt_GLAccountType.SelectedValue = dtb.Rows[0]["GLAccountType"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                txtDistributionReference.Text = dtb.Rows[0]["DistributionReference"].ToString();
                txtDebit.Text = dtb.Rows[0]["Debit"].ToString();
                txtCredit.Text = dtb.Rows[0]["Credit"].ToString();
                txtOriginatingDebit.Text = dtb.Rows[0]["OriginatingDebit"].ToString();
                txtOriginatingCredit.Text = dtb.Rows[0]["OriginatingCredit"].ToString();
               
            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotLoadData;
                divError.Visible = true;
                divSuccess.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "FillForm()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer__Invoice__With_Sales_Order_CustomerInvoiceDistribution.CS";
            logExcpUIobj.RecordId = CustomerInvoiceDistributionFormUI.Tbl_CustomerInvoiceDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Receivable_Customer__Invoice__With_Sales_Order_CustomerInvoiceDistribution : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindCustomerInvoiceDistribution(CustomerInvoiceDistributionFormUI customerInvoiceDistributionFormUI)
    {
        try
        {

            DataTable dtb = customerInvoiceDistributionFormBAL.GetCustomerInvoiceDistribution_SelectByCustomerInvoiceId(customerInvoiceDistributionFormUI);
            {
                if (dtb.Rows.Count > 0)
                {
                    txtCustomerInvoiceId.Text = dtb.Rows[0]["tbl_CustomerInvoice"].ToString();
                    txtCustomerInvoiceIdGuid.Text = dtb.Rows[0]["tbl_CustomerInvoiceId"].ToString();
                    txtsupplierCode.Text = dtb.Rows[0]["SupplierCode"].ToString();
                    txtSupplierName.Text = dtb.Rows[0]["Name"].ToString();
                    txtReceiptnumber.Text = dtb.Rows[0]["tbl_CustomerInvoice"].ToString();
                    txtDocumentNumber.Text = dtb.Rows[0]["DocumentNumber"].ToString();
                    txtCurrencyName.Text = dtb.Rows[0]["CurrencyName"].ToString();
                    txtFunctionalAmount.Text = dtb.Rows[0]["TotalAmount"].ToString();
                    txtOrginatingAmount.Text = dtb.Rows[0]["TotalAmount"].ToString();

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
            logExcpUIobj.RecordId = customerInvoiceDistributionFormUI.Tbl_CustomerInvoiceId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_Default : txtDownPaymentcust_TextChanged] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void AccountType()
    {
        int accountType = Convert.ToInt32(ddlOpt_GLAccountType.SelectedValue);
        int credit = (int)Enums.CommonEnum.type.Credit;
        int debit = (int)Enums.CommonEnum.type.Debit;
        if (accountType == credit)
        {
            divDedit1.Visible = false;
            divDedit2.Visible = false;

            divCredit1.Visible = true;
            divCredit2.Visible = true;

        }
        else if (accountType == debit)
        {
            divDedit1.Visible = true;
            divDedit2.Visible = true;

            divCredit1.Visible = false;
            divCredit2.Visible = false;
        }

    }

    #endregion



   
}
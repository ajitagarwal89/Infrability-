using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeGroupForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    EmployeeGroupFormBAL employeeGroupFormBAL = new EmployeeGroupFormBAL();
    EmployeeGroupFormUI employeeGroupFormUI = new EmployeeGroupFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    EmployeeGroupListBAL employeeGroupListBAL = new EmployeeGroupListBAL();
    PaymentTermsListBAL paymentTermsListBAL = new PaymentTermsListBAL();
    PaymentTermsListUI paymentTermsListUI = new PaymentTermsListUI();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    CurrencyListUI currencyListUI = new CurrencyListUI();

    #endregion Data Members

    #region Events

    protected override void Page_Load(object sender, EventArgs e)
    {
        EmployeeGroupFormUI employeeGroupFormUI = new EmployeeGroupFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["EmployeeGroupId"] != null)
            {
                employeeGroupFormUI.Tbl_EmployeeGroupId = Request.QueryString["EmployeeGroupId"];

                BindMinimumPaymentDropDown();
                BindMaximunInvoiceAmountDropDown();
                BindCreditLimitDropDown();
                BindWriteoffDropDown();

                FillForm(employeeGroupFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update EmployeeGroup";
            }
            else
            {

                BindMinimumPaymentDropDown();
                BindMaximunInvoiceAmountDropDown();
                BindCreditLimitDropDown();
                BindWriteoffDropDown();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New EmployeeGroup";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            employeeGroupFormUI.CreatedBy = SessionContext.UserGuid;
            employeeGroupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            if (txtEmployeeGroupId_SelfGuid.Text != "")
                employeeGroupFormUI.Tbl_EmployeeGroupId_Self = txtEmployeeGroupId_SelfGuid.Text;
            else employeeGroupFormUI.Tbl_EmployeeGroupId_Self = null;

            employeeGroupFormUI.Description = txtDescription.Text;
            employeeGroupFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            employeeGroupFormUI.Tbl_PaymentTermsId = txtPaymentTermGuid.Text;
            employeeGroupFormUI.TradeDiscount = Convert.ToDecimal(txtTradeDiscount.Text);
            employeeGroupFormUI.Opt_MinimumPayment = Convert.ToInt32(ddlOpt_MinimumPayment.SelectedValue);
            employeeGroupFormUI.Opt_MaximumInvoiceAmount = Convert.ToInt32(ddlOpt_MaximumInvoiceAmount.SelectedValue);
            employeeGroupFormUI.Opt_CreditLimit = Convert.ToInt32(ddlOpt_CreditLimit.SelectedValue);
            employeeGroupFormUI.Opt_Writeoff = Convert.ToInt32(ddlOpt_WriteOff.SelectedValue);
            if (chckCalendarYear.Checked == true)
                employeeGroupFormUI.CalendarYear = true;
            else
                employeeGroupFormUI.CalendarYear = false;

            if (chckFiscalYear.Checked == true)
                employeeGroupFormUI.FiscalYear = true;
            else
                employeeGroupFormUI.FiscalYear = false;

            if (chckTransaction.Checked == true)
                employeeGroupFormUI.Transaction = true;
            else
                employeeGroupFormUI.Transaction = false;

            if (chckDistribution.Checked == true)
                employeeGroupFormUI.Distribution = true;
            else
                employeeGroupFormUI.Distribution = false;


            if (employeeGroupFormBAL.AddEmployeeGroup(employeeGroupFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                
                divSuccess.Visible = false;
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;

            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeGroupForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeGroupForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            employeeGroupFormUI.ModifiedBy = SessionContext.UserGuid;
            employeeGroupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            employeeGroupFormUI.Tbl_EmployeeGroupId = Request.QueryString["EmployeeGroupId"];

            if (txtEmployeeGroupId_SelfGuid.Text != "")
                employeeGroupFormUI.Tbl_EmployeeGroupId_Self = txtEmployeeGroupId_SelfGuid.Text;
            else employeeGroupFormUI.Tbl_EmployeeGroupId_Self = null;

            employeeGroupFormUI.Description = txtDescription.Text;
            employeeGroupFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            employeeGroupFormUI.Tbl_PaymentTermsId = txtPaymentTermGuid.Text;
            employeeGroupFormUI.TradeDiscount = Convert.ToDecimal(txtTradeDiscount.Text);
            employeeGroupFormUI.Opt_MinimumPayment = Convert.ToInt32(ddlOpt_MinimumPayment.SelectedValue);
            employeeGroupFormUI.Opt_MaximumInvoiceAmount = Convert.ToInt32(ddlOpt_MaximumInvoiceAmount.SelectedValue);
            employeeGroupFormUI.Opt_CreditLimit = Convert.ToInt32(ddlOpt_CreditLimit.SelectedValue);
            employeeGroupFormUI.Opt_Writeoff = Convert.ToInt32(ddlOpt_WriteOff.SelectedValue);
            if (chckCalendarYear.Checked == true)
                employeeGroupFormUI.CalendarYear = true;
            else
                employeeGroupFormUI.CalendarYear = false;

            if (chckFiscalYear.Checked == true)
                employeeGroupFormUI.FiscalYear = true;
            else
                employeeGroupFormUI.FiscalYear = false;

            if (chckTransaction.Checked == true)
                employeeGroupFormUI.Transaction = true;
            else
                employeeGroupFormUI.Transaction = false;

            if (chckDistribution.Checked == true)
                employeeGroupFormUI.Distribution = true;
            else
                employeeGroupFormUI.Distribution = false;




            if (employeeGroupFormBAL.UpdateEmployeeGroup(employeeGroupFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeGroupForm : btnUpdate_Click] An error occured in the processing of Record Id : " + employeeGroupFormUI.Tbl_EmployeeGroupId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            employeeGroupFormUI.Tbl_EmployeeGroupId = Request.QueryString["EmployeeGroupId"];

            if (employeeGroupFormBAL.DeleteEmployeeGroup(employeeGroupFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordDeleteSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                divSuccess.Visible = false;
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotDeleteRecord;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnDelete_Click()";
            logExcpUIobj.ResourceName = "System_Settings_EmployeeGroupForm.CS";
            logExcpUIobj.RecordId = employeeGroupFormUI.Tbl_EmployeeGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_EmployeeGroupForm : btnDelete_Click] An error occured in the processing of Record Id : " + employeeGroupFormUI.Tbl_EmployeeGroupId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeGroupList.aspx");
    }
    #endregion

    #region Events Employee Group
    protected void btnEmployeeGroupSearch_Click(object sender, EventArgs e)
    {
        btnHtmlEmployeeGroupSearch.Visible = false;
        btnHtmlEmployeeGroupClose.Visible = true;
        SearchEmployeeGroupList();

    }
    protected void btnClearEmployeeGroupSearch_Click(object sender, EventArgs e)
    {
        BindEmployeeGroupList();
        gvEmployeeGroupSearch.Visible = true;
        btnHtmlEmployeeGroupSearch.Visible = true;
        btnHtmlEmployeeGroupClose.Visible = false;
        txtEmployeeGroupSearch.Text = "";
        txtEmployeeGroupSearch.Focus();

    }
    protected void btnEmployeeGroupRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindEmployeeGroupList();
    }
    #endregion

    #region Events Payments Terms
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
    #endregion

    #region Events Currency Search
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

    #region Methods Search and Bind

    private void SearchEmployeeGroupList()
    {
        try
        {
            EmployeeGroupListUI employeeGroupListUI = new EmployeeGroupListUI();

            employeeGroupListUI.Search = txtEmployeeGroupSearch.Text;

            DataTable dtb = employeeGroupListBAL.GetEmployeeGroupListBySearchParameters(employeeGroupListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvEmployeeGroupSearch.DataSource = dtb;
                gvEmployeeGroupSearch.DataBind();
                divEmployeeGroupSearchError.Visible = false;
            }
            else
            {
                divEmployeeGroupSearchError.Visible = true;
                lblEmployeeGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvEmployeeGroupSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchEmployeeGroupList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_EmployeeGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_Master_Creation_EmployeeGroupForm : SearchSupplierGroupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindEmployeeGroupList()
    {
        try
        {
            DataTable dtb = employeeGroupListBAL.GetEmployeeGroupList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvEmployeeGroupSearch.DataSource = dtb;
                gvEmployeeGroupSearch.DataBind();
                divEmployeeGroupSearchError.Visible = false;
            }
            else
            {
                divEmployeeGroupSearchError.Visible = true;
                lblEmployeeGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvEmployeeGroupSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindEmployeeGroupList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_EmployeeGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SearchEmployeeGroup : BindEmployeeGroupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }


    private void SearchPaymentTermsList()
    {
        try
        {
            PaymentTermsListBAL paymentTermsListBAL = new PaymentTermsListBAL();
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_EmployeeGrouptForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_Master_Creation_EmployeeGroupForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
                lblPaymentTermsSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPaymentTermsSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPaymentTermsList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_EmployeeGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SearchEmployeeGroup : BindPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

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

    #region Methods
    private void FillForm(EmployeeGroupFormUI employeeGroupFormUI)
    {
        try
        {
            DataTable dtb = employeeGroupFormBAL.GetEmployeeGroupListById(employeeGroupFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtEmployeeGroupId_SelfGuid.Text = dtb.Rows[0]["tbl_EmployeeGroupId_Self"].ToString();
                txtEmployeeGroupId_Self.Text = dtb.Rows[0]["EmployeeGroupId_Self"].ToString();
                txtDescription.Text = dtb.Rows[0]["description"].ToString();
                txtCurrencyGuid.Text = dtb.Rows[0]["tbl_CurrencyId"].ToString();
                txtCurrency.Text = dtb.Rows[0]["CurrencyName"].ToString();
                txtPaymentTermGuid.Text = dtb.Rows[0]["tbl_PaymentTermsId"].ToString();
                txtPaymentTerms.Text = dtb.Rows[0]["PaymentTermsName"].ToString();
                txtTradeDiscount.Text = dtb.Rows[0]["TradeDiscount"].ToString();
                ddlOpt_MinimumPayment.SelectedValue = dtb.Rows[0]["Opt_MinimumPayment"].ToString();
                ddlOpt_MaximumInvoiceAmount.SelectedValue = dtb.Rows[0]["Opt_MaximumInvoiceAmount"].ToString();
                ddlOpt_CreditLimit.SelectedValue = dtb.Rows[0]["Opt_CreditLimit"].ToString();
                ddlOpt_WriteOff.SelectedValue = dtb.Rows[0]["Opt_Writeoff"].ToString();
                chckCalendarYear.Checked = Convert.ToBoolean(dtb.Rows[0]["CalendarYear"].ToString());
                chckFiscalYear.Checked = Convert.ToBoolean(dtb.Rows[0]["FiscalYear"].ToString());
                chckTransaction.Checked = Convert.ToBoolean(dtb.Rows[0]["Transaction"].ToString());
                chckDistribution.Checked = Convert.ToBoolean(dtb.Rows[0]["Distribution"].ToString());
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
            logExcpUIobj.ResourceName = "System_Settings_EmployeeGroupForm.CS";
            logExcpUIobj.RecordId = employeeGroupFormUI.Tbl_EmployeeGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_EmployeeGroupForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindMinimumPaymentDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_EmployeeGroup";
            optionSetListUI.OptionSetName = "Opt_MinimumPayment";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);

            if (dtb.Rows.Count > 0)
            {
                ddlOpt_MinimumPayment.DataSource = dtb;
                ddlOpt_MinimumPayment.DataBind();
                ddlOpt_MinimumPayment.DataTextField = "OptionSetLable";
                ddlOpt_MinimumPayment.DataValueField = "OptionSetValue";
                ddlOpt_MinimumPayment.DataBind();
            }
            else
            {
                ddlOpt_MinimumPayment.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindMinimumPaymentDropDown()";
            logExcpUIobj.ResourceName = "System_Settings_EmployeeGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_EmployeeGroupForm : BindMinimumPaymentDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindMaximunInvoiceAmountDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_EmployeeGroup";
            optionSetListUI.OptionSetName = "Opt_MaximumInvoiceAmount";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);

            if (dtb.Rows.Count > 0)
            {
                ddlOpt_MaximumInvoiceAmount.DataSource = dtb;
                ddlOpt_MaximumInvoiceAmount.DataBind();
                ddlOpt_MaximumInvoiceAmount.DataTextField = "OptionSetLable";
                ddlOpt_MaximumInvoiceAmount.DataValueField = "OptionSetValue";
                ddlOpt_MaximumInvoiceAmount.DataBind();
            }
            else
            {
                ddlOpt_MaximumInvoiceAmount.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindMaximunInvoiceAmountDropDown()";
            logExcpUIobj.ResourceName = "System_Settings_EmployeeGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_EmployeeGroupForm : BindMaximunInvoiceAmountDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindCreditLimitDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_EmployeeGroup";
            optionSetListUI.OptionSetName = "Opt_CreditLimit";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);

            if (dtb.Rows.Count > 0)
            {
                ddlOpt_CreditLimit.DataSource = dtb;
                ddlOpt_CreditLimit.DataBind();
                ddlOpt_CreditLimit.DataTextField = "OptionSetLable";
                ddlOpt_CreditLimit.DataValueField = "OptionSetValue";
                ddlOpt_CreditLimit.DataBind();
            }
            else
            {
                ddlOpt_CreditLimit.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCreditLimitDropDown()";
            logExcpUIobj.ResourceName = "System_Settings_EmployeeGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_EmployeeGroupForm : BindCreditLimitDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindWriteoffDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_EmployeeGroup";
            optionSetListUI.OptionSetName = "Opt_Writeoff";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);

            if (dtb.Rows.Count > 0)
            {
                ddlOpt_WriteOff.DataSource = dtb;
                ddlOpt_WriteOff.DataBind();
                ddlOpt_WriteOff.DataTextField = "OptionSetLable";
                ddlOpt_WriteOff.DataValueField = "OptionSetValue";
                ddlOpt_WriteOff.DataBind();
            }
            else
            {
                ddlOpt_WriteOff.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindWriteOffDropDown()";
            logExcpUIobj.ResourceName = "System_Settings_EmployeeGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_EmployeeGroupForm : BindWriteOfftDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods
}
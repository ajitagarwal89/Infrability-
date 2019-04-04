using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeApplyForm : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    PaymentToSupplierEmployeeApplyFormBAL paymentToSupplierEmployeeApplyFormBAL = new PaymentToSupplierEmployeeApplyFormBAL();
    PaymentToSupplierEmployeeApplyFormUI paymentToSupplierEmployeeApplyFormUI = new PaymentToSupplierEmployeeApplyFormUI();
    EmployeeGeneralExpensesListBAL employeeGeneralExpensesListBAL = new EmployeeGeneralExpensesListBAL();
    PaymentToSupplierEmployeeListBAL paymentToSupplierEmployeeListBAL = new PaymentToSupplierEmployeeListBAL();
    PaymentToSupplierEmployeeApplyListUI paymentToSupplierEmployeeApplyListUI = new PaymentToSupplierEmployeeApplyListUI();
    PaymentToSupplierEmployeeApplyListBAL paymentToSupplierEmployeeApplyListBAL = new PaymentToSupplierEmployeeApplyListBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();

    #endregion Data Members 

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            if (Request.QueryString["PaymentToSupplierEmployeeId"] != null)
            {
                paymentToSupplierEmployeeApplyListUI.Tbl_PaymentToSupplierEmployeeId = Request.QueryString["PaymentToSupplierEmployeeId"];
                BindPaymentToSupplierEmployeeApply(paymentToSupplierEmployeeApplyListUI);
                BindTypeDropDownList();
            }
            else if (Request.QueryString["PaymentToSupplierEmployeeApplyId"] != null)
            {
                paymentToSupplierEmployeeApplyFormUI.Tbl_PaymentToSupplierEmployeeApplyId = Request.QueryString["PaymentToSupplierEmployeeApplyId"];

                BindTypeDropDownList();
                FillForm(paymentToSupplierEmployeeApplyFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update  Payment To Supplier Employee Apply";
            }
            else
            {
                BindTypeDropDownList();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Payment To Supplier Employee Apply";
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int opt_applytodocumenttype = 1;
        try
        {
            paymentToSupplierEmployeeApplyFormUI.CreatedBy = SessionContext.UserGuid;
            paymentToSupplierEmployeeApplyFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            paymentToSupplierEmployeeApplyFormUI.Tbl_PaymentToSupplierEmployeeId = txtPaymentToSupplierEmployeeGuid.Text;
            paymentToSupplierEmployeeApplyFormUI.Tbl_ApplyToDocument = txtApplyToDocumentEmployeeGeneralExpensesGuid.Text;
            paymentToSupplierEmployeeApplyFormUI.opt_ApplyToDocumentType = opt_applytodocumenttype;
            paymentToSupplierEmployeeApplyFormUI.opt_Type = int.Parse(ddloptType.SelectedValue.ToString());
            paymentToSupplierEmployeeApplyFormUI.DueDate = DateTime.Parse(txtDueDate.Text.ToString());
            paymentToSupplierEmployeeApplyFormUI.RemainingAmount = Convert.ToDecimal(txtRemainingAmount.Text);
            paymentToSupplierEmployeeApplyFormUI.ApplyAmount = Decimal.Parse(txtApplyAmount.Text);
            paymentToSupplierEmployeeApplyFormUI.OrignalDocumentAmount = Convert.ToDecimal(txtOrignalDocumentAmount.Text);
            paymentToSupplierEmployeeApplyFormUI.DiscountDate = DateTime.Parse(txtDiscountDate.Text);
            if (paymentToSupplierEmployeeApplyFormBAL.AddPaymentToSupplierEmployeeApply(paymentToSupplierEmployeeApplyFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeApplyForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeApplyForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int opt_applytodocumenttype = 1;
        PaymentToSupplierEmployeeApplyFormUI paymentToSupplierEmployeeApplyFormUI = new PaymentToSupplierEmployeeApplyFormUI();
        try
        {
            paymentToSupplierEmployeeApplyFormUI.ModifiedBy = SessionContext.UserGuid;
            paymentToSupplierEmployeeApplyFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            paymentToSupplierEmployeeApplyFormUI.Tbl_PaymentToSupplierEmployeeId = txtPaymentToSupplierEmployeeGuid.Text;
            paymentToSupplierEmployeeApplyFormUI.Tbl_ApplyToDocument = txtApplyToDocumentEmployeeGeneralExpensesGuid.Text;
            paymentToSupplierEmployeeApplyFormUI.opt_ApplyToDocumentType = opt_applytodocumenttype;
            paymentToSupplierEmployeeApplyFormUI.opt_Type = int.Parse(ddloptType.SelectedValue.ToString());
            paymentToSupplierEmployeeApplyFormUI.DueDate = DateTime.Parse(txtDueDate.Text.ToString());
            paymentToSupplierEmployeeApplyFormUI.RemainingAmount = Convert.ToDecimal(txtRemainingAmount.Text);
            paymentToSupplierEmployeeApplyFormUI.ApplyAmount = Decimal.Parse(txtApplyAmount.Text);
            paymentToSupplierEmployeeApplyFormUI.OrignalDocumentAmount = Convert.ToDecimal(txtOrignalDocumentAmount.Text);
            paymentToSupplierEmployeeApplyFormUI.DiscountDate = DateTime.Parse(txtDiscountDate.Text);
            paymentToSupplierEmployeeApplyFormUI.Tbl_PaymentToSupplierEmployeeApplyId = Request.QueryString["PaymentToSupplierEmployeeApplyId"];
            if (paymentToSupplierEmployeeApplyFormBAL.UpdatePaymentToSupplierEmployeeApply(paymentToSupplierEmployeeApplyFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeApplyForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeApplyForm : btnUpdate_Click] An error occured in the processing of Record Id : " + paymentToSupplierEmployeeApplyFormUI.Tbl_PaymentToSupplierEmployeeApplyId + ".  Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            paymentToSupplierEmployeeApplyFormUI.Tbl_PaymentToSupplierEmployeeApplyId = Request.QueryString["PaymentToSupplierEmployeeApplyId"];
            if (paymentToSupplierEmployeeApplyFormBAL.DeletePaymentToSupplierEmployeeApply(paymentToSupplierEmployeeApplyFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeApplyForm.CS";
            logExcpUIobj.RecordId = paymentToSupplierEmployeeApplyFormUI.Tbl_PaymentToSupplierEmployeeApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeApplyForm : btnDelete_Click] An error occured in the processing of Record Id : " + paymentToSupplierEmployeeApplyFormUI.Tbl_PaymentToSupplierEmployeeApplyId + ". Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaymentToSupplierEmployeeApplyList.aspx");
    }

    #region SupplierEmployee Search
    protected void btnPaymentToSupplierEmployeeSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPaymentToSupplierEmployeeSearch.Visible = false;
        btnHtmlPaymentToSupplierEmployeeClose.Visible = true;
        SearchSupplierEmployeeList();
    }
    protected void btnClearPaymentToSupplierEmployeeSearch_Click(object sender, EventArgs e)
    {

        BindSupplierEmployeeList();
        gvPaymentToSupplierEmployeeSearch.Visible = true;
        btnHtmlPaymentToSupplierEmployeeSearch.Visible = true;
        btnHtmlPaymentToSupplierEmployeeClose.Visible = false;
        txtPaymentToSupplierEmployeeSearch.Text = "";
        txtPaymentToSupplierEmployeeSearch.Focus();
    }
    protected void btnPaymentToSupplierEmployeeRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindSupplierEmployeeList();
    }
    #endregion SupplierEmployee Search

    #region ApplyToDocumentEmployeeGeneralExpenses Search
    protected void btnApplyToDocumentEmployeeGeneralExpensesSearch_Click(object sender, EventArgs e)
    {
        btnHtmlApplyToDocumentEmployeeGeneralExpensesSearch.Visible = false;
        btnHtmlApplyToDocumentEmployeeGeneralExpensesClose.Visible = true;
        SearchApplyToDocumentEmployeeGeneralExpensesList();
    }

    protected void btnClearApplyToDocumentEmployeeGeneralExpensesSearch_Click(object sender, EventArgs e)
    {
        BindApplyToDocumentEmployeeGeneralExpensesSearchList();
        gvApplyToDocumentEmployeeGeneralExpensesSearch.Visible = true;
        btnHtmlApplyToDocumentEmployeeGeneralExpensesSearch.Visible = true;
        btnHtmlApplyToDocumentEmployeeGeneralExpensesClose.Visible = false;
        txtApplyToDocumentEmployeeGeneralExpensesSearch.Text = "";
        txtApplyToDocumentEmployeeGeneralExpensesSearch.Focus();
    }
    protected void btnApplyToDocumentEmployeeGeneralExpensesRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindApplyToDocumentEmployeeGeneralExpensesSearchList();
    }
    #endregion ApplyToDocumentEmployeeGeneralExpenses Search

    #endregion Events

    #region Methods

    private void FillForm(PaymentToSupplierEmployeeApplyFormUI paymentToSupplierEmployeeApplyFormUI)
    {
        try
        {
            DataTable dtb = paymentToSupplierEmployeeApplyFormBAL.GetPaymentToSupplierEmployeeApplyListById(paymentToSupplierEmployeeApplyFormUI);
            if (dtb.Rows.Count > 0)
            {
                txtPaymentToSupplierEmployeeGuid.Text = dtb.Rows[0]["tbl_PaymentToSupplierEmployeeId"].ToString();
                txtPaymentToSupplierEmployee.Text = dtb.Rows[0]["tbl_SupplierEmployee"].ToString();
                txtApplyToDocumentEmployeeGeneralExpensesGuid.Text = dtb.Rows[0]["tbl_ApplyTodocument"].ToString();
                txtApplyToDocumentEmployeeGeneralExpenses.Text = dtb.Rows[0]["tbl_ApplyToDocumentEmpExp"].ToString();
                txtDueDate.Text = dtb.Rows[0]["DueDate"].ToString();
                txtRemainingAmount.Text = dtb.Rows[0]["RemainingAmount"].ToString();
                txtApplyAmount.Text = dtb.Rows[0]["ApplyAmount"].ToString();
                ddloptType.SelectedValue = dtb.Rows[0]["opt_Type"].ToString();
                txtOrignalDocumentAmount.Text = dtb.Rows[0]["OrignalDocumentAmount"].ToString();
                txtDiscountDate.Text = dtb.Rows[0]["DiscountDate"].ToString();

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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeApplyForm.CS";
            logExcpUIobj.RecordId = paymentToSupplierEmployeeApplyFormUI.Tbl_PaymentToSupplierEmployeeApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeApplyForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void BindTypeDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_PaymentToSupplierEmployeeApply";
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeApplyForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeApplyForm : BindTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }


    public void BindPaymentToSupplierEmployeeApply(PaymentToSupplierEmployeeApplyListUI paymentToSupplierEmployeeApplyListUI)
    {

        try
        {
            DataTable dtb = paymentToSupplierEmployeeApplyListBAL.GetPaymentToSupplierEmployeeApplyListByPaymentToEmployeeId(paymentToSupplierEmployeeApplyListUI);
            {
                if (dtb.Rows.Count > 0)
                {
                    txtPaymentToSupplierEmployee.Text = dtb.Rows[0]["tbl_PaymentToSupplierEmployee"].ToString();
                    txtPaymentToSupplierEmployeeGuid.Text = dtb.Rows[0]["tbl_PaymentToSupplierEmployeeId"].ToString();
                    txtEmployeeId.Text = dtb.Rows[0]["tbl_Employee"].ToString();
                    txtEmployeename.Text = dtb.Rows[0]["tbl_Employee"].ToString();
                    txtType.Text = dtb.Rows[0]["Type"].ToString();
                   // txtCurrencyID.Text = dtb.Rows[0]["CurrencyName"].ToString();
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeApplyForm.CS";
            logExcpUIobj.RecordId = paymentToSupplierEmployeeApplyFormUI.Tbl_PaymentToSupplierEmployeeApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeApplyForm : txtDownPaymentcust_TextChanged] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region Search  BindSupplierEmployee
    private void BindSupplierEmployeeList()
    {
        try
        {
            DataTable dtb = paymentToSupplierEmployeeListBAL.GetPaymentToSupplierEmployeeList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPaymentToSupplierEmployeeSearch.DataSource = dtb;
                gvPaymentToSupplierEmployeeSearch.DataBind();
                divPaymentToSupplierEmployeeSearchError.Visible = false;
               

            }
            else
            {
                divPaymentToSupplierEmployeeSearchError.Visible = true;
                lblPaymentToSupplierEmployeeSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPaymentToSupplierEmployeeSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCustomerList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeApplyForm : BindCustomerList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void SearchSupplierEmployeeList()
    {
        try
        {
            PaymentToSupplierEmployeeListUI paymentToSupplierEmployeeListUI = new PaymentToSupplierEmployeeListUI();
            CustomerListUI customerListUI = new CustomerListUI();
            customerListUI.Search = txtPaymentToSupplierEmployeeSearch.Text;
            DataTable dtb = paymentToSupplierEmployeeListBAL.GetPaymentToSupplierEmployeeListById(paymentToSupplierEmployeeListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPaymentToSupplierEmployeeSearch.DataSource = dtb;
                gvPaymentToSupplierEmployeeSearch.DataBind();
                divPaymentToSupplierEmployeeSearchError.Visible = false;
                gvPaymentToSupplierEmployeeSearch.Visible = true;
            }
            else
            {
                divPaymentToSupplierEmployeeSearchError.Visible = true;
                lblPaymentToSupplierEmployeeSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPaymentToSupplierEmployeeSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchCustomer()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeApplyForm : SearchCustomer] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion

    #region ApplyToDocumentEmployeeGeneralExpenses Search
    private void SearchApplyToDocumentEmployeeGeneralExpensesList()
    {

        try
        {
            EmployeeGeneralExpensesListUI employeeGeneralExpensesListUI = new EmployeeGeneralExpensesListUI();
            employeeGeneralExpensesListUI.Search = txtApplyToDocumentEmployeeGeneralExpensesSearch.Text;


            DataTable dtb = employeeGeneralExpensesListBAL.GetEmployeeGeneralExpensesListBySearchParameters(employeeGeneralExpensesListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvApplyToDocumentEmployeeGeneralExpensesSearch.DataSource = dtb;
                gvApplyToDocumentEmployeeGeneralExpensesSearch.DataBind();
                divApplyToDocumentEmployeeGeneralExpensesSearchError.Visible = false;
            }
            else
            {
                divApplyToDocumentEmployeeGeneralExpensesSearchError.Visible = true;
                lblApplyToDocumentEmployeeGeneralExpensesSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvApplyToDocumentEmployeeGeneralExpensesSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchApplyToDocumentEmployeeGeneralExpensesList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeApplyForm : SearchApplyToDocumentEmployeeGeneralExpensesList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindApplyToDocumentEmployeeGeneralExpensesSearchList()
    {
        try
        {
            DataTable dtb = employeeGeneralExpensesListBAL.GetEmployeeGeneralExpensesList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvApplyToDocumentEmployeeGeneralExpensesSearch.DataSource = dtb;
                gvApplyToDocumentEmployeeGeneralExpensesSearch.DataBind();
                divError.Visible = false;
                gvApplyToDocumentEmployeeGeneralExpensesSearch.Visible = true;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvApplyToDocumentEmployeeGeneralExpensesSearch.Visible = false;
            }

            txtApplyToDocumentEmployeeGeneralExpensesSearch.Text = "";
            txtApplyToDocumentEmployeeGeneralExpensesSearch.Focus();
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindApplyToDocumentEmployeeGeneralExpensesSearchList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeApplyForm : BindApplyToDocumentEmployeeGeneralExpensesSearchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion ApplyToDocumentEmployeeGeneralExpenses Search

    #endregion Methods
}
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Bank_Accounting_Payment_To_Employees_PaymentToEmployeeApplyForm : System.Web.UI.Page
{

    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    PaymentToEmployeeApplyFormBAL paymentToEmployeeApplyFormBAL = new PaymentToEmployeeApplyFormBAL();
    PaymentToEmployeeApplyFormUI paymentToEmployeeApplyFormUI = new PaymentToEmployeeApplyFormUI();
    EmployeeGeneralExpensesListBAL employeeGeneralExpensesListBAL = new EmployeeGeneralExpensesListBAL();
    PaymentToEmployeeListBAL paymentToEmployeeListBAL = new PaymentToEmployeeListBAL();
    PaymentToEmployeeApplyListUI paymentToEmployeeApplyListUI = new PaymentToEmployeeApplyListUI();
    PaymentToEmployeeApplyListBAL paymentToEmployeeApplyListBAL = new PaymentToEmployeeApplyListBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();

    #endregion Data Members 

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            if (Request.QueryString["PaymentToEmployeeId"] != null)
            {
                paymentToEmployeeApplyListUI.Tbl_PaymentToEmployeeId = Request.QueryString["PaymentToEmployeeId"];
                BindPaymentToEmployeeApply(paymentToEmployeeApplyListUI);
                BindTypeDropDownList();
            }
            else if (Request.QueryString["PaymentToEmployeeApplyId"] != null)
            {
                paymentToEmployeeApplyFormUI.Tbl_PaymentToEmployeeApplyId = Request.QueryString["PaymentToEmployeeApplyId"];

                BindTypeDropDownList();
                FillForm(paymentToEmployeeApplyFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update  Payment To Employee Apply";
            }
            else
            {
                BindTypeDropDownList();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Payment To Employee Apply";
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int opt_applytodocumenttype = 1;
        try
        {
            paymentToEmployeeApplyFormUI.CreatedBy = SessionContext.UserGuid;
            paymentToEmployeeApplyFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            paymentToEmployeeApplyFormUI.Tbl_PaymentToEmployeeId = txtPaymentToEmployeeGuid.Text;
            paymentToEmployeeApplyFormUI.Tbl_ApplyToDocument = txtApplyToDocumentEmployeeGeneralExpensesGuid.Text;
            paymentToEmployeeApplyFormUI.opt_ApplyToDocumentType = opt_applytodocumenttype;
            paymentToEmployeeApplyFormUI.opt_Type = int.Parse(ddloptType.SelectedValue.ToString());
            paymentToEmployeeApplyFormUI.DueDate = DateTime.Parse(txtDueDate.Text.ToString());
            paymentToEmployeeApplyFormUI.RemainingAmount = Convert.ToDecimal(txtRemainingAmount.Text);
            paymentToEmployeeApplyFormUI.ApplyAmount = Decimal.Parse(txtApplyAmount.Text);
            paymentToEmployeeApplyFormUI.OrignalDocumentAmount = Convert.ToDecimal(txtOrignalDocumentAmount.Text);
            paymentToEmployeeApplyFormUI.DiscountDate = DateTime.Parse(txtDiscountDate.Text);
            if (paymentToEmployeeApplyFormBAL.AddPaymentToEmployeeApply(paymentToEmployeeApplyFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employees_PaymentToEmployeeApplyForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_To_Employees_PaymentToEmployeeApplyForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int opt_applytodocumenttype = 1;
        PaymentToEmployeeApplyFormUI paymentToEmployeeApplyFormUI = new PaymentToEmployeeApplyFormUI();
        try
        {
            paymentToEmployeeApplyFormUI.ModifiedBy = SessionContext.UserGuid;
            paymentToEmployeeApplyFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            paymentToEmployeeApplyFormUI.Tbl_PaymentToEmployeeId = txtPaymentToEmployeeGuid.Text;
            paymentToEmployeeApplyFormUI.Tbl_ApplyToDocument = txtApplyToDocumentEmployeeGeneralExpensesGuid.Text;
            paymentToEmployeeApplyFormUI.opt_ApplyToDocumentType = opt_applytodocumenttype;
            paymentToEmployeeApplyFormUI.opt_Type = int.Parse(ddloptType.SelectedValue.ToString());
            paymentToEmployeeApplyFormUI.DueDate = DateTime.Parse(txtDueDate.Text.ToString());
            paymentToEmployeeApplyFormUI.RemainingAmount = Convert.ToDecimal(txtRemainingAmount.Text);
            paymentToEmployeeApplyFormUI.ApplyAmount = Decimal.Parse(txtApplyAmount.Text);
            paymentToEmployeeApplyFormUI.OrignalDocumentAmount = Convert.ToDecimal(txtOrignalDocumentAmount.Text);
            paymentToEmployeeApplyFormUI.DiscountDate = DateTime.Parse(txtDiscountDate.Text);
            paymentToEmployeeApplyFormUI.Tbl_PaymentToEmployeeApplyId = Request.QueryString["PaymentToEmployeeApplyId"];
            if (paymentToEmployeeApplyFormBAL.UpdatePaymentToEmployeeApply(paymentToEmployeeApplyFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employees_PaymentToEmployeeApplyForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_To_Employees_PaymentToEmployeeApplyForm : btnUpdate_Click] An error occured in the processing of Record Id : " + paymentToEmployeeApplyFormUI.Tbl_PaymentToEmployeeApplyId + ".  Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            paymentToEmployeeApplyFormUI.Tbl_PaymentToEmployeeApplyId = Request.QueryString["PaymentToEmployeeApplyId"];
            if (paymentToEmployeeApplyFormBAL.DeletePaymentToEmployeeApply(paymentToEmployeeApplyFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employees_PaymentToEmployeeApplyForm.CS";
            logExcpUIobj.RecordId = paymentToEmployeeApplyFormUI.Tbl_PaymentToEmployeeApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_To_Employees_PaymentToEmployeeApplyForm : btnDelete_Click] An error occured in the processing of Record Id : " + paymentToEmployeeApplyFormUI.Tbl_PaymentToEmployeeApplyId + ". Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaymentToEmployeeApplyList.aspx");
    }

    #region EmployeeSearch
    protected void btnPaymentToEmployeeSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPaymentToEmployeeSearch.Visible = false;
        btnHtmlPaymentToEmployeeClose.Visible = true;
        SearchEmployeeList();
    }
    protected void btnClearPaymentToEmployeeSearch_Click(object sender, EventArgs e)
    {

        BindEmployeeList();
        gvPaymentToEmployeeSearch.Visible = true;
        btnHtmlPaymentToEmployeeSearch.Visible = true;
        btnHtmlPaymentToEmployeeClose.Visible = false;
        txtPaymentToEmployeeSearch.Text = "";
        txtPaymentToEmployeeSearch.Focus();
    }
    protected void btnPaymentToEmployeeRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindEmployeeList();
    }
    #endregion EmployeeSearch

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

    private void FillForm(PaymentToEmployeeApplyFormUI paymentToEmployeeApplyFormUI)
    {
        try
        {
            DataTable dtb = paymentToEmployeeApplyFormBAL.GetPaymentToEmployeeApplyListById(paymentToEmployeeApplyFormUI);
            if (dtb.Rows.Count > 0)
            {
                txtPaymentToEmployeeGuid.Text = dtb.Rows[0]["tbl_PaymentToEmployeeId"].ToString();
                txtPaymentToEmployee.Text = dtb.Rows[0]["tbl_Employee"].ToString();
                txtApplyToDocumentEmployeeGeneralExpensesGuid.Text = dtb.Rows[0]["tbl_ApplyTodocument"].ToString();
                txtApplyToDocumentEmployeeGeneralExpenses.Text = dtb.Rows[0]["tbl_ApplyToDocumentEmpExp"].ToString();
                txtDueDate.Text = dtb.Rows[0]["DueDate"].ToString();
                txtRemainingAmount.Text = dtb.Rows[0]["RemainingAmount"].ToString();
                txtApplyAmount.Text = dtb.Rows[0]["ApplyAmount"].ToString();
                ddloptType.SelectedValue = dtb.Rows[0]["Type"].ToString();
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employees_PaymentToEmployeeApplyForm.CS";
            logExcpUIobj.RecordId = paymentToEmployeeApplyFormUI.Tbl_PaymentToEmployeeApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Payment_To_Employees_PaymentToEmployeeApplyForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void BindTypeDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_PaymentToEmployeeApply";
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employees_PaymentToEmployeeApplyForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employees_PaymentToEmployeeApplyForm : BindTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }


    public void BindPaymentToEmployeeApply(PaymentToEmployeeApplyListUI paymentToEmployeeApplyListUI)
    {

        try
        {
            DataTable dtb = paymentToEmployeeApplyListBAL.GetPaymentToEmployeeApplyListByPaymentToEmployeeId(paymentToEmployeeApplyListUI);
            {
                if (dtb.Rows.Count > 0)
                {
                    txtPaymentToEmployee.Text = dtb.Rows[0]["tbl_DownPaymentToSupplier"].ToString();
                    txtPaymentToEmployeeGuid.Text = dtb.Rows[0]["tbl_PaymentToEmployeeId"].ToString();
                    txtEmployeeId.Text = dtb.Rows[0]["tbl_Employee"].ToString();
                    txtEmployeename.Text = dtb.Rows[0]["tbl_Employee"].ToString();
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employees_PaymentToEmployeeApplyForm.CS";
            logExcpUIobj.RecordId = paymentToEmployeeApplyFormUI.Tbl_PaymentToEmployeeApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employees_PaymentToEmployeeApplyForm : txtDownPaymentcust_TextChanged] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region Search  BindEmployee
    private void BindEmployeeList()
    {
        try
        {
            DataTable dtb = paymentToEmployeeListBAL.GetPaymentToEmployeeList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPaymentToEmployeeSearch.DataSource = dtb;
                gvPaymentToEmployeeSearch.DataBind();
                divPaymentToEmployeeSearchError.Visible = false;

            }
            else
            {
                divPaymentToEmployeeSearchError.Visible = true;
                lblPaymentToEmployeeSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPaymentToEmployeeSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCustomerList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employees_PaymentToEmployeeApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employees_PaymentToEmployeeApplyForm : BindCustomerList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void SearchEmployeeList()
    {
        try
        {
            PaymentToEmployeeListUI paymentToEmployeeListUI = new PaymentToEmployeeListUI();
            CustomerListUI customerListUI = new CustomerListUI();
            customerListUI.Search = txtPaymentToEmployeeSearch.Text;
            DataTable dtb = paymentToEmployeeListBAL.GetPaymentToEmployeeListById(paymentToEmployeeListUI);


            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPaymentToEmployeeSearch.DataSource = dtb;
                gvPaymentToEmployeeSearch.DataBind();
                divPaymentToEmployeeSearchError.Visible = false;

            }
            else
            {
                divPaymentToEmployeeSearchError.Visible = true;
                lblPaymentToEmployeeSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPaymentToEmployeeSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchCustomer()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employees_PaymentToEmployeeApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employees_PaymentToEmployeeApplyForm : SearchCustomer] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employees_PaymentToEmployeeApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employees_PaymentToEmployeeApplyForm : SearchApplyToDocumentEmployeeGeneralExpensesList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Employees_PaymentToEmployeeApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Employees_PaymentToEmployeeApplyForm : BindApplyToDocumentEmployeeGeneralExpensesSearchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion ApplyToDocumentEmployeeGeneralExpenses Search

    #endregion Methods

}
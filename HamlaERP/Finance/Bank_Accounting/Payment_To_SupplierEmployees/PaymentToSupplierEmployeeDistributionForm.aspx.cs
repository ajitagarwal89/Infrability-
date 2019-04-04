using Finware;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeDistributionForm : System.Web.UI.Page
{
    #region Data Members

    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    PaymentToSupplierEmployeeListBAL PaymentToSupplierEmployeeListBAL = new PaymentToSupplierEmployeeListBAL();
    PaymentToSupplierEmployeeDistributionFormBAL paymentToSupplierEmployeeDistributionFormBAL = new PaymentToSupplierEmployeeDistributionFormBAL();
    PaymentToSupplierEmployeeDistributionFormUI paymentToSupplierEmployeeDistributionFormUI = new PaymentToSupplierEmployeeDistributionFormUI();

    #endregion Data Members

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        PaymentToSupplierEmployeeDistributionFormUI paymentToSupplierEmployeeDistributionFormUI = new PaymentToSupplierEmployeeDistributionFormUI();
        if (!Page.IsPostBack)
        {

            if (Request.QueryString["PaymentToSupplierEmployeeId"] != null)

            {
                paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeId = Request.QueryString["PaymentToSupplierEmployeeId"];
                BindPaymentToSupplierEmployeeDistribution(paymentToSupplierEmployeeDistributionFormUI);
                BindTypeDropDownList();
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
            }
            else if (Request.QueryString["PaymentToSupplierEmployeeDistributionId"] != null)
            {
                paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeDistributionId = Request.QueryString["PaymentToSupplierEmployeeDistributionId"];
                BindTypeDropDownList();
                FillForm(paymentToSupplierEmployeeDistributionFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update PaymentToSupplierEmployeeDistribution";

            }
            else
            {
                BindTypeDropDownList();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Payment To Employee Distribution";
            }
        }

    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            paymentToSupplierEmployeeDistributionFormUI.CreatedBy = SessionContext.UserGuid;
            paymentToSupplierEmployeeDistributionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeId = txtPaymentToSupplierEmployeeGuid.Text.Trim();
            paymentToSupplierEmployeeDistributionFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text.Trim();
            int type = Convert.ToInt32(ddlOptionType.SelectedValue);
            paymentToSupplierEmployeeDistributionFormUI.opt_Type = int.Parse(ddlOptionType.SelectedValue);


            if (type == 1)
            {
                paymentToSupplierEmployeeDistributionFormUI.Credit = Convert.ToDecimal(txtCredit.Text == "" ? "0.00" : txtCredit.Text);
                paymentToSupplierEmployeeDistributionFormUI.OriginatingCredit = Convert.ToDecimal(txtOriginatingCredit.Text == "" ? "0.00" : txtOriginatingCredit.Text);
            }
            else
            {
                paymentToSupplierEmployeeDistributionFormUI.Credit = 0;
                paymentToSupplierEmployeeDistributionFormUI.OriginatingCredit = 0;
            }
            if (type == 2)
            {

                paymentToSupplierEmployeeDistributionFormUI.Debit = Convert.ToDecimal(txtDebit.Text == "" ? "0.00" : txtDebit.Text);
                paymentToSupplierEmployeeDistributionFormUI.OriginatingDebit = Convert.ToDecimal(txtOriginatingDebit.Text == "" ? "0.00" : txtOriginatingDebit.Text);
            }
            else
            {
                paymentToSupplierEmployeeDistributionFormUI.Debit = 0;
                paymentToSupplierEmployeeDistributionFormUI.OriginatingDebit = 0;
            }
            paymentToSupplierEmployeeDistributionFormUI.Description = txtDescription.Text;
            paymentToSupplierEmployeeDistributionFormUI.DistributionReference = txtDistributionReference.Text.Trim();
            //paymentToSupplierEmployeeDistributionFormUI.CompanyId = "00000000-0000-0000-0000-000000000002";
            //paymentToSupplierEmployeeDistributionFormUI.CorrespondenceCompanyId = "00000000-0000-0000-0000-000000000001";
            paymentToSupplierEmployeeDistributionFormUI.Tbl_OrganizationIdCorrespondence= "00000000-0000-0000-0000-000000000001"; 
            if (paymentToSupplierEmployeeDistributionFormBAL.AddPaymentToSupplierEmployeeDistribution(paymentToSupplierEmployeeDistributionFormUI) == 1)
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
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Employee_Payment_Processing_PaymentToSupplierEmployeeDistribution.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Employee_Payment_Processing_PaymentToSupplierEmployeeDistribution : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            paymentToSupplierEmployeeDistributionFormUI.ModifiedBy = SessionContext.UserGuid;
            paymentToSupplierEmployeeDistributionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeDistributionId = Request.QueryString["PaymentToSupplierEmployeeDistributionId"];
            paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeId = txtPaymentToSupplierEmployeeGuid.Text.Trim();
            paymentToSupplierEmployeeDistributionFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text.Trim();
            int type = Convert.ToInt32(ddlOptionType.SelectedValue);
            paymentToSupplierEmployeeDistributionFormUI.opt_Type = int.Parse(ddlOptionType.SelectedValue);

            if (type == 1)
            {
                paymentToSupplierEmployeeDistributionFormUI.Credit = Convert.ToDecimal(txtCredit.Text == "" ? "0.00" : txtCredit.Text);
                paymentToSupplierEmployeeDistributionFormUI.OriginatingCredit = Convert.ToDecimal(txtOriginatingCredit.Text == "" ? "0.00" : txtOriginatingCredit.Text);
            }
            else
            {
                paymentToSupplierEmployeeDistributionFormUI.Credit = 0;
                paymentToSupplierEmployeeDistributionFormUI.OriginatingCredit = 0;
            }
            if (type == 2)
            {

                paymentToSupplierEmployeeDistributionFormUI.Debit = Convert.ToDecimal(txtDebit.Text == "" ? "0.00" : txtDebit.Text);
                paymentToSupplierEmployeeDistributionFormUI.OriginatingDebit = Convert.ToDecimal(txtOriginatingDebit.Text == "" ? "0.00" : txtOriginatingDebit.Text);
            }
            else
            {
                paymentToSupplierEmployeeDistributionFormUI.Debit = 0;
                paymentToSupplierEmployeeDistributionFormUI.OriginatingDebit = 0;
            }

        
            paymentToSupplierEmployeeDistributionFormUI.Description = txtDescription.Text;
            paymentToSupplierEmployeeDistributionFormUI.DistributionReference = txtDistributionReference.Text.Trim();
            //paymentToSupplierEmployeeDistributionFormUI.CompanyId = "00000000-0000-0000-0000-000000000002";
            //paymentToSupplierEmployeeDistributionFormUI.CorrespondenceCompanyId = "00000000-0000-0000-0000-000000000001";
            paymentToSupplierEmployeeDistributionFormUI.Tbl_OrganizationIdCorrespondence= "00000000-0000-0000-0000-000000000001"; 
            if (paymentToSupplierEmployeeDistributionFormBAL.UpdatePaymentToSupplierEmployeeDistribution(paymentToSupplierEmployeeDistributionFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
            }
            else
            {
                divError.Visible = true;
                divSuccess.Visible = false;
                lblError.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionForm.CS";
            logExcpUIobj.RecordId = paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionForm : btnUpdate_Click] An error occured in the processing of Record Id : " + paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeDistributionId + ".  Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeDistributionId = Request.QueryString["PaymentToSupplierEmployeeDistributionId"];

            if (paymentToSupplierEmployeeDistributionFormBAL.DeletePaymentToSupplierEmployeeDistribution(paymentToSupplierEmployeeDistributionFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionForm.CS";
            logExcpUIobj.RecordId = paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionForm : btnDelete_Click] An error occured in the processing of Record Id : " + paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeDistributionId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaymentToSupplierEmployeeDistributionList.aspx");
    }

    protected void txtPaymentToSupplierEmployee_TextChanged(object sender, EventArgs e)
    {
        paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeId = txtPaymentToSupplierEmployeeGuid.Text;
        BindPaymentToSupplierEmployeeDistribution(paymentToSupplierEmployeeDistributionFormUI);
    }

    #region DownPaymentToSupplier Search
    protected void btnPaymentToSupplierEmployeeSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPaymentToSupplierEmployeeSearch.Visible = false;
        btnHtmlPaymentToSupplierEmployeeClose.Visible = true;
        SearchPaymentToSupplierEmployeeList();
    }

    protected void btnClearPaymentToSupplierEmployeeSearch_Click(object sender, EventArgs e)
    {
        BindPaymentToSupplierEmployeeSearchList();
        gvPaymentToSupplierEmployeeSearch.Visible = true;
        btnHtmlPaymentToSupplierEmployeeSearch.Visible = true;
        btnHtmlPaymentToSupplierEmployeeClose.Visible = false;
        txtPaymentToSupplierEmployeeSearch.Text = "";
        txtPaymentToSupplierEmployeeSearch.Focus();
    }
    protected void btnPaymentToSupplierEmployeeRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPaymentToSupplierEmployeeSearchList();
    }

    #endregion DownPaymentToSupplier Search

    #region Events GL Account Search
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


    #endregion


    #region Methods
    private void FillForm(PaymentToSupplierEmployeeDistributionFormUI paymentToSupplierEmployeeDistributionFormUI)
    {
        try
        {
            DataTable dtb = paymentToSupplierEmployeeDistributionFormBAL.GetPaymentToSupplierEmployeeDistributionListById(paymentToSupplierEmployeeDistributionFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtPaymentToSupplierEmployee.Text = dtb.Rows[0]["tbl_PaymentToSupplierEmployee"].ToString();
                txtPaymentToSupplierEmployeeGuid.Text = dtb.Rows[0]["tbl_PaymentToSupplierEmployeeId"].ToString();
                txtGLAccount.Text = dtb.Rows[0]["tbl_GLAccount"].ToString();
                txtGLAccountGuid.Text = dtb.Rows[0]["tbl_GLAccountId"].ToString();
                ddlOptionType.SelectedValue = dtb.Rows[0]["opt_Type"].ToString();
                txtDebit.Text = dtb.Rows[0]["Debit"].ToString();
                txtOriginatingDebit.Text = dtb.Rows[0]["OriginatingDebit"].ToString();
                txtCredit.Text = dtb.Rows[0]["Credit"].ToString();
                txtOriginatingCredit.Text = dtb.Rows[0]["OriginatingCredit"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                txtDistributionReference.Text = dtb.Rows[0]["DistributionReference"].ToString();

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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionForm.CS";
            logExcpUIobj.RecordId = paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierEmployeeDistributionForm : FillForm] An error occured in the processing of Record Id : " + paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeDistributionId + ". Details : [" + exp.ToString() + "]");
        }
    }
    private void BindPaymentToSupplierEmployeeDistribution(PaymentToSupplierEmployeeDistributionFormUI paymentToSupplierEmployeeDistributionFormUI)
    {
        try
        {

            DataTable dtb = paymentToSupplierEmployeeDistributionFormBAL.GetGetPaymentToSupplierEmployeeDistribution_SelectByPaymentToEmployeeId(paymentToSupplierEmployeeDistributionFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtPaymentToSupplierEmployee.Text = dtb.Rows[0]["tbl_PaymentToSupplierEmployee"].ToString();
                txtPaymentToSupplierEmployeeGuid.Text = dtb.Rows[0]["tbl_PaymentToSupplierEmployeeId"].ToString();
                txtEmployeeCode.Text = dtb.Rows[0]["EmployeeCode"].ToString();
                txtEmployeeName.Text = dtb.Rows[0]["tbl_Employee"].ToString();
                txtPaymentNumber.Text = dtb.Rows[0]["tbl_PaymentToSupplierEmployee"].ToString();
                txtDocumentNumber.Text = dtb.Rows[0]["DocumentNumber"].ToString();
                txtDocumentType.Text = dtb.Rows[0]["DocumentType"].ToString();
                txtCurrencyName.Text = dtb.Rows[0]["CurrencyName"].ToString();
                txtfunctionalAmount.Text = dtb.Rows[0]["Total"].ToString();
                lblOriginatingAmount.Text = dtb.Rows[0]["Total"].ToString();
                txtReferenceNo.Text = dtb.Rows[0]["DistributionReference"].ToString();
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
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPaymentToSupplierEmployeeDistribution()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Employee_Payment_Processing_PaymentToSupplierEmployeeDistributionForm.CS";
            logExcpUIobj.RecordId = paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Employee_Payment_Processing_PaymentToSupplierEmployeeDistributionForm : BindPaymentToSupplierEmployeeDistribution] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void BindTypeDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_PaymentToSupplierEmployeeDistribution";
            optionSetListUI.OptionSetName = "opt_Type";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlOptionType.DataSource = dtb;
                ddlOptionType.DataBind();
                ddlOptionType.DataTextField = "OptionSetLable";
                ddlOptionType.DataValueField = "OptionSetValue";
                ddlOptionType.DataBind();
                ddlOptionType.Items.Insert(0, new ListItem(Resources.GlobalResource.OptionType_msgSelectPayablesType, "0"));
                ddlOptionType.SelectedIndex = 0;
            }
            else
            {
                ddlOptionType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindDocumentTypeDropDownList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierEmployeeDistributionForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierEmployeeDistributionForm : BindDocumentTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region PaymentToSupplierEmployee Search
    private void SearchPaymentToSupplierEmployeeList()
    {

        try
        {
            PaymentToSupplierEmployeeListBAL PaymentToSupplierEmployeeListBAL = new PaymentToSupplierEmployeeListBAL();
            PaymentToSupplierEmployeeListUI PaymentToSupplierEmployeeListUI = new PaymentToSupplierEmployeeListUI();

            PaymentToSupplierEmployeeListUI.Search = txtPaymentToSupplierEmployeeSearch.Text;


            DataTable dtb = PaymentToSupplierEmployeeListBAL.GetPaymentToSupplierEmployeeListBySearchParameters(PaymentToSupplierEmployeeListUI);

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
            logExcpUIobj.MethodName = "SearchPaymentToSupplierEmployeeList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm : SearchDownPaymentToSupplierList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindPaymentToSupplierEmployeeSearchList()
    {
        try
        {
            DataTable dtb = PaymentToSupplierEmployeeListBAL.GetPaymentToSupplierEmployeeList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPaymentToSupplierEmployeeSearch.DataSource = dtb;
                gvPaymentToSupplierEmployeeSearch.DataBind();
                divError.Visible = false;
                gvPaymentToSupplierEmployeeSearch.Visible = true;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPaymentToSupplierEmployeeSearch.Visible = false;
            }

            txtPaymentToSupplierEmployeeSearch.Text = "";
            txtPaymentToSupplierEmployeeSearch.Focus();
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPaymentToSupplierEmployeeSearchList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm : BindDownPaymentToSupplierSearchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    #endregion DownPaymentToSupplier Search

    #region GLAccount Search
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountSummaryForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountSummaryForm : BindGLAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierEmployeeDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierEmployeeDistributionForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }


    }
    #endregion GLAccount Search

    #endregion End Method



}
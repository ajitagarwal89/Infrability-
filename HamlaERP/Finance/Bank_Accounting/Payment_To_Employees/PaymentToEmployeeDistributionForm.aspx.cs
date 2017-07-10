using Finware;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Finance_Bank_Accounting_Employee_Payment_Processing_PaymentToEmployeeDistributionForm : System.Web.UI.Page
{
    #region Data Members

    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    PaymentToEmployeeListBAL paymentToEmployeeListBAL = new PaymentToEmployeeListBAL();
    PaymentToEmployeeDistributionFormBAL paymentToEmployeeDistributionFormBAL = new PaymentToEmployeeDistributionFormBAL();
    PaymentToEmployeeDistributionFormUI paymentToEmployeeDistributionFormUI = new PaymentToEmployeeDistributionFormUI();

    #endregion Data Members

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        PaymentToEmployeeDistributionFormUI paymentToEmployeeDistributionFormUI = new PaymentToEmployeeDistributionFormUI();
        if (!Page.IsPostBack)
        {

            if (Request.QueryString["PaymentToEmployeeId"] != null)

            {
                paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeId = Request.QueryString["PaymentToEmployeeId"];
                BindPaymentToEmployeeDistribution(paymentToEmployeeDistributionFormUI);
                BindTypeDropDownList();
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
            }
            else if (Request.QueryString["PaymentToEmployeeDistributionId"] != null)
            {
                paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId = Request.QueryString["PaymentToEmployeeDistributionId"];
                BindTypeDropDownList();
                FillForm(paymentToEmployeeDistributionFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update PaymentToEmployeeDistribution";

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
            paymentToEmployeeDistributionFormUI.CreatedBy = SessionContext.UserGuid;
            paymentToEmployeeDistributionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeId = txtPaymentToEmployeeGuid.Text.Trim();
            paymentToEmployeeDistributionFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text.Trim();
            int type = Convert.ToInt32(ddlOptionType.SelectedValue);
            paymentToEmployeeDistributionFormUI.opt_Type = int.Parse(ddlOptionType.SelectedValue);

            if (type == 1)
            {
                paymentToEmployeeDistributionFormUI.Debit = Convert.ToDecimal(txtDebit.Text == "" ? "0.00" : txtDebit.Text);
                paymentToEmployeeDistributionFormUI.OriginatingDebit = Convert.ToDecimal(txtOriginatingDebit.Text == "" ? "0.00" : txtOriginatingDebit.Text);
            }
            else
            {
                paymentToEmployeeDistributionFormUI.Debit = 0;
                paymentToEmployeeDistributionFormUI.OriginatingDebit = 0;
            }

            if (type == 2)
            {
                paymentToEmployeeDistributionFormUI.Credit = Convert.ToDecimal(txtCredit.Text == "" ? "0.00" : txtCredit.Text);
                paymentToEmployeeDistributionFormUI.OriginatingCredit = Convert.ToDecimal(txtOriginatingCredit.Text == "" ? "0.00" : txtOriginatingCredit.Text);
            }
            else
            {
                paymentToEmployeeDistributionFormUI.Credit = 0;
                paymentToEmployeeDistributionFormUI.OriginatingCredit = 0;
            }
            paymentToEmployeeDistributionFormUI.Description = txtDescription.Text;
            paymentToEmployeeDistributionFormUI.DistributionReference = txtDistributionReference.Text.Trim();
            paymentToEmployeeDistributionFormUI.CompanyId = "00000000-0000-0000-0000-000000000002";
            paymentToEmployeeDistributionFormUI.CorrespondenceCompanyId = "00000000-0000-0000-0000-000000000001";

            if (paymentToEmployeeDistributionFormBAL.AddPaymentToEmployeeDistribution(paymentToEmployeeDistributionFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Employee_Payment_Processing_PaymentToEmployeeDistribution.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Employee_Payment_Processing_PaymentToEmployeeDistribution : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            paymentToEmployeeDistributionFormUI.ModifiedBy = SessionContext.UserGuid;
            paymentToEmployeeDistributionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId = Request.QueryString["PaymentToEmployeeDistributionId"];
            paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeId = txtPaymentToEmployeeGuid.Text.Trim();
            paymentToEmployeeDistributionFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text.Trim();
            int type = Convert.ToInt32(ddlOptionType.SelectedValue);
            paymentToEmployeeDistributionFormUI.opt_Type = int.Parse(ddlOptionType.SelectedValue);

            if (type == 1)
            {
                paymentToEmployeeDistributionFormUI.Debit = Convert.ToDecimal(txtDebit.Text == "" ? "0.00" : txtDebit.Text);
                paymentToEmployeeDistributionFormUI.OriginatingDebit = Convert.ToDecimal(txtOriginatingDebit.Text == "" ? "0.00" : txtOriginatingDebit.Text);
            }
            else
            {
                paymentToEmployeeDistributionFormUI.Debit = 0;
                paymentToEmployeeDistributionFormUI.OriginatingDebit = 0;
            }

            if (type == 2)
            {
                paymentToEmployeeDistributionFormUI.Credit = Convert.ToDecimal(txtCredit.Text == "" ? "0.00" : txtCredit.Text);
                paymentToEmployeeDistributionFormUI.OriginatingCredit = Convert.ToDecimal(txtOriginatingCredit.Text == "" ? "0.00" : txtOriginatingCredit.Text);
            }
            else
            {
                paymentToEmployeeDistributionFormUI.Credit = 0;
                paymentToEmployeeDistributionFormUI.OriginatingCredit = 0;
            }
            paymentToEmployeeDistributionFormUI.Description = txtDescription.Text;
            paymentToEmployeeDistributionFormUI.DistributionReference = txtDistributionReference.Text.Trim();
            paymentToEmployeeDistributionFormUI.CompanyId = "00000000-0000-0000-0000-000000000002";
            paymentToEmployeeDistributionFormUI.CorrespondenceCompanyId = "00000000-0000-0000-0000-000000000001";
            if (paymentToEmployeeDistributionFormBAL.UpdatePaymentToEmployeeDistribution(paymentToEmployeeDistributionFormUI) == 1)
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
            logExcpUIobj.RecordId = paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionForm : btnUpdate_Click] An error occured in the processing of Record Id : " + paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId + ".  Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId = Request.QueryString["PaymentToEmployeeDistributionId"];

            if (paymentToEmployeeDistributionFormBAL.DeletePaymentToEmployeeDistribution(paymentToEmployeeDistributionFormUI) == 1)
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
            logExcpUIobj.RecordId = paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionForm : btnDelete_Click] An error occured in the processing of Record Id : " + paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaymentToEmployeeDistributionList.aspx");
    }

    protected void txtPaymentToEmployee_TextChanged(object sender, EventArgs e)
    {
        paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeId = txtPaymentToEmployeeGuid.Text;
        BindPaymentToEmployeeDistribution(paymentToEmployeeDistributionFormUI);
    }

    #region DownPaymentToSupplier Search
    protected void btnPaymentToEmployeeSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPaymentToEmployeeSearch.Visible = false;
        btnHtmlPaymentToEmployeeClose.Visible = true;
        SearchPaymentToEmployeeList();
    }

    protected void btnClearPaymentToEmployeeSearch_Click(object sender, EventArgs e)
    {
        BindPaymentToEmployeeSearchList();
        gvPaymentToEmployeeSearch.Visible = true;
        btnHtmlPaymentToEmployeeSearch.Visible = true;
        btnHtmlPaymentToEmployeeClose.Visible = false;
        txtPaymentToEmployeeSearch.Text = "";
        txtPaymentToEmployeeSearch.Focus();
    }
    protected void btnPaymentToEmployeeRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPaymentToEmployeeSearchList();
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
    private void FillForm(PaymentToEmployeeDistributionFormUI paymentToEmployeeDistributionFormUI)
    {
        try
        {
            DataTable dtb = paymentToEmployeeDistributionFormBAL.GetGetPaymentToEmployeeDistribution_SelectByPaymentToEmployeeId(paymentToEmployeeDistributionFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtPaymentToEmployee.Text = dtb.Rows[0]["tbl_PaymentToEmployee"].ToString();
                txtPaymentToEmployeeGuid.Text = dtb.Rows[0]["tbl_PaymentToEmployeeId"].ToString();
                txtGLAccount.Text = dtb.Rows[0]["tbl_GLAccount"].ToString();
                txtGLAccountGuid.Text = dtb.Rows[0]["tbl_GLAccountId"].ToString();
                ddlOptionType.SelectedValue = dtb.Rows[0]["Type"].ToString();
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
            logExcpUIobj.RecordId = paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_DownPaymentToSupplierDistributionForm : FillForm] An error occured in the processing of Record Id : " + paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId + ". Details : [" + exp.ToString() + "]");
        }
    }
    private void BindPaymentToEmployeeDistribution(PaymentToEmployeeDistributionFormUI paymentToEmployeeDistributionFormUI)
    {
        try
        {

            DataTable dtb = paymentToEmployeeDistributionFormBAL.GetGetPaymentToEmployeeDistribution_SelectByPaymentToEmployeeId(paymentToEmployeeDistributionFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtPaymentToEmployee.Text = dtb.Rows[0]["tbl_PaymentToEmployee"].ToString();
                txtPaymentToEmployeeGuid.Text = dtb.Rows[0]["tbl_PaymentToEmployeeId"].ToString();
                txtEmployeeCode.Text = dtb.Rows[0]["EmployeeCode"].ToString();
                txtEmployeeName.Text = dtb.Rows[0]["tbl_Employee"].ToString();
                txtPaymentNumber.Text = dtb.Rows[0]["tbl_PaymentToEmployee"].ToString();
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
            logExcpUIobj.MethodName = "BindPaymentToEmployeeDistribution()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Employee_Payment_Processing_PaymentToEmployeeDistributionForm.CS";
            logExcpUIobj.RecordId = paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Employee_Payment_Processing_PaymentToEmployeeDistributionForm : BindPaymentToEmployeeDistribution] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void BindTypeDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_PaymentToEmployeeDistribution";
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_DownPaymentToSupplierDistributionForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_DownPaymentToSupplierDistributionForm : BindDocumentTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region PaymentToEmployee Search
    private void SearchPaymentToEmployeeList()
    {

        try
        {
            PaymentToEmployeeListBAL paymentToEmployeeListBAL = new PaymentToEmployeeListBAL();
            PaymentToEmployeeListUI paymentToEmployeeListUI = new PaymentToEmployeeListUI();

            paymentToEmployeeListUI.Search = txtPaymentToEmployeeSearch.Text;


            DataTable dtb = paymentToEmployeeListBAL.GetPaymentToEmployeeListBySearchParameters(paymentToEmployeeListUI);

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
            logExcpUIobj.MethodName = "SearchPaymentToEmployeeList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm : SearchDownPaymentToSupplierList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindPaymentToEmployeeSearchList()
    {
        try
        {
            DataTable dtb = paymentToEmployeeListBAL.GetPaymentToEmployeeList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPaymentToEmployeeSearch.DataSource = dtb;
                gvPaymentToEmployeeSearch.DataBind();
                divError.Visible = false;
                gvPaymentToEmployeeSearch.Visible = true;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPaymentToEmployeeSearch.Visible = false;
            }

            txtPaymentToEmployeeSearch.Text = "";
            txtPaymentToEmployeeSearch.Focus();
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPaymentToEmployeeSearchList()";
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_DownPaymentToSupplierDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_DownPaymentToSupplierDistributionForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }


    }
    #endregion GLAccount Search

    #endregion End Method




}
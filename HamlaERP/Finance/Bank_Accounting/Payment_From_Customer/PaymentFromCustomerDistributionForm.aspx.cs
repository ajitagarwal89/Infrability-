using Finware;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Finance_Bank_Accounting_Customer_Receipts_PaymentFromCustomerDistributionForm : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
     PaymentFromCustomerListBAL paymentFromCustomerListBAL = new PaymentFromCustomerListBAL();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();

    PaymentFromCustomerDistributionFormBAL paymentFromCustomerDistributionFormBAL = new PaymentFromCustomerDistributionFormBAL();
    PaymentFromCustomerDistributionFormUI paymentFromCustomerDistributionFormUI = new PaymentFromCustomerDistributionFormUI();
    #endregion Data Members

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        PaymentFromCustomerDistributionFormUI paymentFromCustomerDistributionFormUI = new PaymentFromCustomerDistributionFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["PaymentFromCustomerId"] != null)
            {
                paymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerId = Request.QueryString["PaymentFromCustomerId"];
                BindPaymentFromDistribution(paymentFromCustomerDistributionFormUI);
                BindTypeDropDownList();
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
            }

           else if (Request.QueryString["PaymentFromCustomerDistributionId"] != null)
            {
                paymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId = Request.QueryString["PaymentFromCustomerDistributionId"];

                BindTypeDropDownList();
                FillForm(paymentFromCustomerDistributionFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Payment From Customer Distribution";
            }
            else 
            {
                BindTypeDropDownList();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Payment From CustomerDistribution";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            paymentFromCustomerDistributionFormUI.CreatedBy = SessionContext.UserGuid;
            paymentFromCustomerDistributionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            paymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerId = txtCustomerGuid.Text.Trim();
            paymentFromCustomerDistributionFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text.Trim();
            int type = Convert.ToInt32(ddlOptionType.SelectedValue);
            paymentFromCustomerDistributionFormUI.opt_Type = int.Parse(ddlOptionType.SelectedValue);

            if (type == 2)
            {
                paymentFromCustomerDistributionFormUI.Debit = Convert.ToDecimal(txtDebit.Text);
                paymentFromCustomerDistributionFormUI.OriginatingDebit = Convert.ToDecimal(txtOriginatingDebit.Text);
            }
            else
            {
                paymentFromCustomerDistributionFormUI.Debit = 0;
                paymentFromCustomerDistributionFormUI.OriginatingDebit = 0;
            }

            if (type == 1)
            {
                paymentFromCustomerDistributionFormUI.Credit = Convert.ToDecimal(txtCredit.Text);
                paymentFromCustomerDistributionFormUI.OriginatingCredit = Convert.ToDecimal(txtOriginatingCredit.Text);
            }
            else
            {
                paymentFromCustomerDistributionFormUI.Credit = 0;
                paymentFromCustomerDistributionFormUI.OriginatingCredit = 0;
            }
            paymentFromCustomerDistributionFormUI.Description = txtDescription.Text;
            paymentFromCustomerDistributionFormUI.DistributionReference = txtDistributionReference.Text.Trim();

            if (paymentFromCustomerDistributionFormBAL.AddPaymentFromCustomerDistribution(paymentFromCustomerDistributionFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Receipts_PaymentFromCustomerDistributionForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Receipts_PaymentFromCustomerDistributionForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            paymentFromCustomerDistributionFormUI.ModifiedBy = SessionContext.UserGuid;
            paymentFromCustomerDistributionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            paymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId = Request.QueryString["PaymentFromCustomerDistributionId"];
            paymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerId = txtCustomerGuid.Text.Trim();
            paymentFromCustomerDistributionFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text.Trim();        
            int type = Convert.ToInt32(ddlOptionType.SelectedValue);
            paymentFromCustomerDistributionFormUI.opt_Type = int.Parse(ddlOptionType.SelectedValue);

            if (type == 2)
            {
                paymentFromCustomerDistributionFormUI.Debit = Convert.ToDecimal(txtDebit.Text == "" ? "0.00" : txtDebit.Text);
                paymentFromCustomerDistributionFormUI.OriginatingDebit = Convert.ToDecimal(txtOriginatingDebit.Text == "" ? "0.00" : txtOriginatingDebit.Text);
            }
            else
            {
                paymentFromCustomerDistributionFormUI.Debit = 0;
                paymentFromCustomerDistributionFormUI.OriginatingDebit = 0;
            }

            if (type == 1)
            {
                paymentFromCustomerDistributionFormUI.Credit = Convert.ToDecimal(txtCredit.Text == "" ? "0.00" : txtCredit.Text);
                paymentFromCustomerDistributionFormUI.OriginatingCredit = Convert.ToDecimal(txtOriginatingCredit.Text == "" ? "0.00" : txtOriginatingCredit.Text);
            }
            else
            {
                paymentFromCustomerDistributionFormUI.Credit = 0;
                paymentFromCustomerDistributionFormUI.OriginatingCredit = 0;
            }
            paymentFromCustomerDistributionFormUI.Description = txtDescription.Text;
            paymentFromCustomerDistributionFormUI.DistributionReference = txtDistributionReference.Text.Trim();

            if (paymentFromCustomerDistributionFormBAL.UpdatePaymentFromCustomerDistribution(paymentFromCustomerDistributionFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Receipts_PaymentFromCustomerDistributionForm.CS";
            logExcpUIobj.RecordId = paymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Receipts_PaymentFromCustomerDistributionForm : btnUpdate_Click] An error occured in the processing of Record Id : " + paymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            paymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId = Request.QueryString["PaymentFromCustomerDistributionId"];

            if (paymentFromCustomerDistributionFormBAL.DeletePaymentFromCustomerDistribution(paymentFromCustomerDistributionFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Receipts_PaymentFromCustomerDistributionForm.CS";
            logExcpUIobj.RecordId = paymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Receipts_PaymentFromCustomerDistributionForm : btnDelete_Click] An error occured in the processing of Record Id : " + paymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaymentFromCustomerDistributionList.aspx");
    }

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
        BindCustomerList();
    }
    #endregion

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

    protected void ddlOptionType_SelectedIndexChanged(object sender, EventArgs e)
    {
        int Opt_Type = Convert.ToInt32(ddlOptionType.SelectedValue);
        int credit = (int)Enums.CommonEnum.type.Credit;
        int debit = (int)Enums.CommonEnum.type.Debit;
        if (Opt_Type == credit)
        {
            divDebit.Visible = false;
            divOriginatingDebit.Visible = false;
            divCredit.Visible = true;
            divOriginatingCredit.Visible = true;
        }
        else if (Opt_Type == debit)
        {
            divDebit.Visible = true;
            divOriginatingDebit.Visible = true;
            divCredit.Visible = false;
            divOriginatingCredit.Visible = false;
        }
       
    }

    protected void txtCustomer_TextChanged(object sender, EventArgs e)
    {
    paymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerId = txtCustomerGuid.Text;
    BindPaymentFromDistribution(paymentFromCustomerDistributionFormUI);
    }

  
    #endregion Events

    #region Methods
    private void FillForm(PaymentFromCustomerDistributionFormUI paymentFromCustomerDistributionFormUI)
    {
        try
        {
            DataTable dtb = paymentFromCustomerDistributionFormBAL.GetPaymentFromCustomerDistributionListById(paymentFromCustomerDistributionFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtCustomer.Text = dtb.Rows[0]["tbl_Customer"].ToString();
                txtCustomerGuid.Text = dtb.Rows[0]["tbl_CustomerId"].ToString();
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Receipts_PaymentFromCustomerDistributionForm.CS";
            logExcpUIobj.RecordId = paymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Receipts_PaymentFromCustomerDistributionForm : FillForm] An error occured in the processing of Record Id : " + paymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId + ". Details : [" + exp.ToString() + "]");
        }
    }

    private void BindTypeDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_PaymentFromCustomerDistribution";
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Receipts_PaymentFromCustomerDistributionForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Receipts_PaymentFromCustomerDistributionForm : BindDocumentTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindPaymentFromDistribution(PaymentFromCustomerDistributionFormUI paymentFromCustomerDistributionFormUI)
    {
        try
        {
          
            DataTable dtb = paymentFromCustomerDistributionFormBAL.GetPaymentFromCustomerDistribution_SelectByPaymentFromCustomerId(paymentFromCustomerDistributionFormUI);
            {
                if (dtb.Rows.Count > 0)
                {
                    txtCustomer.Text = dtb.Rows[0]["tbl_Customer"].ToString();
                    txtCustomerGuid.Text = dtb.Rows[0]["tbl_PaymentFromCustomerId"].ToString();
                    //txtCustomerCode.Text = dtb.Rows[0]["CustomerCode"].ToString();
                    txtCustomerName.Text = dtb.Rows[0]["tbl_Customer"].ToString();
                    txtReceiptnumber.Text = dtb.Rows[0]["tbl_PaymentFromCustomer"].ToString();
                    //txtDocumentNumber.Text = dtb.Rows[0]["DocumentNumber"].ToString();
                    //txtDocumentType.Text = dtb.Rows[0]["DocumentType"].ToString();
                    txtCurrencyName.Text = dtb.Rows[0]["CurrencyName"].ToString();
                    //txtFunctionalAmount.Text = dtb.Rows[0]["TotalAmount"].ToString();
                    //txtOrginatingAmount.Text = dtb.Rows[0]["TotalAmount"].ToString();
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
            logExcpUIobj.RecordId = paymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_Default : txtDownPaymentcust_TextChanged] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Receipts_PaymentFromCustomerDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Receipts_PaymentFromCustomerDistributionForm : BindCustomerList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void SearchCustomerList()
    {
        try
        {
          PaymentFromCustomerListUI paymentFromCustomerListUI = new PaymentFromCustomerListUI();
            CustomerListUI customerListUI = new CustomerListUI();
            customerListUI.Search = txtCustomerSearch.Text;
            DataTable dtb = paymentFromCustomerListBAL.GetPaymentFromCustomerListById(paymentFromCustomerListUI);


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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Receipts_PaymentFromCustomerDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Receipts_PaymentFromCustomerDistributionForm : SearchCustomer] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion

    #region GLAccount Search
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Receipts_PaymentFromCustomerDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Receipts_PaymentFromCustomerDistributionForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Receipts_PaymentFromCustomerDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Receipts_PaymentFromCustomerDistributionForm : BindGLAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion
    #endregion Methods

   
}
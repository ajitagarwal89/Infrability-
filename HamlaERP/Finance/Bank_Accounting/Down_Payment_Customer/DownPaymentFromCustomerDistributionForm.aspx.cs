using Finware;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionForm : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    DownPaymentFromCustomerListBAL downPaymentFromCustomerListBAL = new DownPaymentFromCustomerListBAL();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();

    DownPaymentFromCustomerDistributionFormBAL downPaymentFromCustomerDistributionFormBAL = new DownPaymentFromCustomerDistributionFormBAL();
    DownPaymentFromCustomerDistributionFormUI downPaymentFromCustomerDistributionFormUI = new DownPaymentFromCustomerDistributionFormUI();
    DownPaymentFromCustomerFormUI downPaymentFromCustomerFormUI = new DownPaymentFromCustomerFormUI();
    DownPaymentFromCustomerFormBAL downPaymentFromCustomerFormBAL = new DownPaymentFromCustomerFormBAL();
    #endregion Data Members

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        DownPaymentFromCustomerDistributionFormUI downPaymentFromCustomerDistributionFormUI = new DownPaymentFromCustomerDistributionFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["DownPaymentFromCustomerId"] != null)
            {
                downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerId = Request.QueryString["DownPaymentFromCustomerId"];
                BindDownPaymentFromDistribution(downPaymentFromCustomerDistributionFormUI);
                BindTypeDropDownList();
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
            }


            else if (Request.QueryString["DownPaymentFromCustomerDistributionId"] != null)
            {
                downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerDistributionId = Request.QueryString["DownPaymentFromCustomerDistributionId"];

                BindTypeDropDownList();
                FillForm(downPaymentFromCustomerDistributionFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Down PaymentFromCustomerDistribution";
            }
            else
            {
                BindTypeDropDownList();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Down Payment From CustomerDistribution";
            }
        }
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            downPaymentFromCustomerDistributionFormUI.CreatedBy = SessionContext.UserGuid;
            downPaymentFromCustomerDistributionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerId = txtCustomerGuid.Text.Trim();
            downPaymentFromCustomerDistributionFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text.Trim();
            downPaymentFromCustomerDistributionFormUI.opt_Type = int.Parse(ddlOptionType.SelectedValue);
            downPaymentFromCustomerDistributionFormUI.Debit = Convert.ToDecimal(txtDebit.Text == "" ? "0.00" : txtDebit.Text);
            downPaymentFromCustomerDistributionFormUI.OriginatingDebit = Convert.ToDecimal(txtOriginatingDebit.Text == "" ? "0.00" : txtOriginatingDebit.Text);
            downPaymentFromCustomerDistributionFormUI.Credit = Convert.ToDecimal(txtCredit.Text == "" ? "0.00" : txtCredit.Text);
            downPaymentFromCustomerDistributionFormUI.OriginatingCredit = Convert.ToDecimal(txtOriginatingCredit.Text == "" ? "0.00" : txtOriginatingCredit.Text);
            downPaymentFromCustomerDistributionFormUI.Description = txtDescription.Text;
            downPaymentFromCustomerDistributionFormUI.DistributionReference = txtDistributionReference.Text.Trim();

            if (downPaymentFromCustomerDistributionFormBAL.AddDownPaymentFromCustomerDistribution(downPaymentFromCustomerDistributionFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            downPaymentFromCustomerDistributionFormUI.ModifiedBy = SessionContext.UserGuid;
            downPaymentFromCustomerDistributionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerDistributionId = Request.QueryString["DownPaymentFromCustomerDistributionId"];
            downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerId = txtCustomerGuid.Text.Trim();
            downPaymentFromCustomerDistributionFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text.Trim();
            downPaymentFromCustomerDistributionFormUI.opt_Type = int.Parse(ddlOptionType.SelectedValue);
            downPaymentFromCustomerDistributionFormUI.Debit = Convert.ToDecimal(txtDebit.Text == "" ? "0.00" : txtDebit.Text);
            downPaymentFromCustomerDistributionFormUI.OriginatingDebit = Convert.ToDecimal(txtOriginatingDebit.Text == "" ? "0.00" : txtOriginatingDebit.Text);
            downPaymentFromCustomerDistributionFormUI.Credit = Convert.ToDecimal(txtCredit.Text == "" ? "0.00" : txtCredit.Text);
            downPaymentFromCustomerDistributionFormUI.OriginatingCredit = Convert.ToDecimal(txtOriginatingCredit.Text == "" ? "0.00" : txtOriginatingCredit.Text);
            downPaymentFromCustomerDistributionFormUI.Description = txtDescription.Text;
            downPaymentFromCustomerDistributionFormUI.DistributionReference = txtDistributionReference.Text.Trim();

            if (downPaymentFromCustomerDistributionFormBAL.UpdateDownPaymentFromCustomerDistribution(downPaymentFromCustomerDistributionFormUI) == 1)
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
            logExcpUIobj.RecordId = downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionForm : btnUpdate_Click] An error occured in the processing of Record Id : " + downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerDistributionId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerDistributionId = Request.QueryString["DownPaymentFromCustomerDistributionId"];

            if (downPaymentFromCustomerDistributionFormBAL.DeleteDownPaymentFromCustomerDistribution(downPaymentFromCustomerDistributionFormUI) == 1)
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
            logExcpUIobj.RecordId = downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionForm : btnDelete_Click] An error occured in the processing of Record Id : " + downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerDistributionId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("DownPaymentFromCustomerDistributionList.aspx");
    }

    protected void txtCustomer_TextChanged(object sender, EventArgs e)
    {
        downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerId = txtCustomerGuid.Text;
        BindDownPaymentFromDistribution(downPaymentFromCustomerDistributionFormUI);
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
        else
        {

        }
    }

    #endregion Events

    #region Methods
    private void FillForm(DownPaymentFromCustomerDistributionFormUI downPaymentFromCustomerDistributionFormUI)
    {
        try
        {
            DataTable dtb = downPaymentFromCustomerDistributionFormBAL.GetDownPaymentFromCustomerDistributionListById(downPaymentFromCustomerDistributionFormUI);

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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionForm.CS";
            logExcpUIobj.RecordId = downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionForm : FillForm] An error occured in the processing of Record Id : " + downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerDistributionId + ". Details : [" + exp.ToString() + "]");
        }
    }

    private void BindTypeDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_DownPaymentFromCustomerDistribution";
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionForm : BindDocumentTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    public void BindDownPaymentFromDistribution(DownPaymentFromCustomerDistributionFormUI downPaymentFromCustomerDistributionFormUI)
    {

        try
        {
            downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerId = Request.QueryString["DownPaymentFromCustomerId"];
            DataTable dtb = downPaymentFromCustomerDistributionFormBAL.GetDownPaymentFromCustomerDistribution_SelectByDownPaymentFromCustomerId(downPaymentFromCustomerDistributionFormUI);            
                if (dtb.Rows.Count > 0)
                {
                    txtCustomer.Text = dtb.Rows[0]["tbl_Customer"].ToString();
                    txtCustomerGuid.Text = dtb.Rows[0]["tbl_DownPaymentFromCustomerId"].ToString();
                    txtCustomerCode.Text = dtb.Rows[0]["CustomerCode"].ToString();
                    txtCustomerName.Text = dtb.Rows[0]["tbl_Customer"].ToString();
                    txtReceiptnumber.Text = dtb.Rows[0]["tbl_DownPaymentFromCustomer"].ToString();
                    txtDocumentNumber.Text = dtb.Rows[0]["DocumentNumber"].ToString();
                    txtDocumentType.Text = dtb.Rows[0]["DocumentType"].ToString();
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
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "txtDownPaymentcust_TextChanged()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_Default.CS";
            logExcpUIobj.RecordId = downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerId;
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
            DataTable dtb = downPaymentFromCustomerListBAL.GetDownPaymentFromCustomerList();

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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionForm : BindCustomerList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void SearchCustomerList()
    {
        try
        {
            DownPaymentFromCustomerListUI downPaymentFromCustomerListUI = new DownPaymentFromCustomerListUI();
            CustomerListUI customerListUI = new CustomerListUI();
            customerListUI.Search = txtCustomerSearch.Text;
            DataTable dtb = downPaymentFromCustomerListBAL.GetDownPaymentFromCustomerListById(downPaymentFromCustomerListUI);


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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionForm : SearchCustomer] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountSummaryForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountSummaryForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountSummaryForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountSummaryForm : BindGLAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion
    #endregion Methods






}
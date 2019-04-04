using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceDistributionForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    NonPOBasedInvoiceDistributionFormBAL nonPOBasedInvoiceDistributionFormBAL = new NonPOBasedInvoiceDistributionFormBAL();
    NonPOBasedInvoiceDistributionFormUI nonPOBasedInvoiceDistributionFormUI = new NonPOBasedInvoiceDistributionFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    NonPOBasedInvoiceDistributionListBAL nonPOBasedInvoiceDistributionListBAL = new NonPOBasedInvoiceDistributionListBAL();


    NonPOBasedInvoiceListBAL nonPOBasedInvoiceListBAL = new NonPOBasedInvoiceListBAL();
    NonPOBasedInvoiceListUI nonPOBasedInvoiceListUI = new NonPOBasedInvoiceListUI();
    NonPOBasedInvoiceFormUI nonPOBasedInvoiceFormUI = new NonPOBasedInvoiceFormUI();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    GLAccountListUI gLAccountListUI = new GLAccountListUI();


    CommonDateClasses commonDateClasses = new CommonDateClasses();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
           
            if (Request.QueryString["NonPOBasedInvoiceDistributionId"] != null)
            {
                nonPOBasedInvoiceDistributionFormUI.Tbl_NonPOBasedInvoiceDistributionId = Request.QueryString["NonPOBasedInvoiceDistributionId"];

                BindGLAccountTypeDropDownList();


                FillForm(nonPOBasedInvoiceDistributionFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Non PO Based Invoice Distribution";
            }
           else if (Request.QueryString["NonPOBasedInvoiceDistributionId"] != null || Request.QueryString["recordId"] != null)
            {
                nonPOBasedInvoiceDistributionFormUI.Tbl_NonPOBasedInvoiceDistributionId = (Request.QueryString["NonPOBasedInvoiceDistributionId"] != null ? Request.QueryString["NonPOBasedInvoiceDistributionId"] : Request.QueryString["recordId"]);
                BindNonPOBasedInvoiceDistribution(nonPOBasedInvoiceDistributionFormUI);
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
            }
            else
            {
                BindGLAccountTypeDropDownList();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;    
                lblHeading.Text = "Add New Non PO Based Invoice Distribution";
            }
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            nonPOBasedInvoiceDistributionFormUI.CreatedBy = SessionContext.UserGuid;
            nonPOBasedInvoiceDistributionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            nonPOBasedInvoiceDistributionFormUI.Tbl_NonPOBasedInvoiceId = txtNonPOBasedInvoiceIdGuid.Text;
            nonPOBasedInvoiceDistributionFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text;
            nonPOBasedInvoiceDistributionFormUI.Opt_GLAccountType = Convert.ToInt16(ddlOpt_GLAccountType.SelectedValue);
            nonPOBasedInvoiceDistributionFormUI.Description = txtDescription.Text;
            nonPOBasedInvoiceDistributionFormUI.DistributionReference = txtDistributionReference.Text;
            nonPOBasedInvoiceDistributionFormUI.Debit = Convert.ToDecimal(txtDebit.Text);
            nonPOBasedInvoiceDistributionFormUI.Credit = Convert.ToDecimal(txtCredit.Text);
            nonPOBasedInvoiceDistributionFormUI.OriginatingDebit = Convert.ToDecimal(txtOriginatingDebit.Text);
            nonPOBasedInvoiceDistributionFormUI.OriginatingCredit = Convert.ToDecimal(txtCredit.Text);
            nonPOBasedInvoiceDistributionFormUI.ExchangeRate = Convert.ToDecimal(txtExchangeRate.Text);

            if (nonPOBasedInvoiceDistributionFormBAL.AddNonPOBasedInvoiceDistribution(nonPOBasedInvoiceDistributionFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceDistributionForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceDistributionForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            nonPOBasedInvoiceDistributionFormUI.ModifiedBy = SessionContext.UserGuid;
            nonPOBasedInvoiceDistributionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            nonPOBasedInvoiceDistributionFormUI.Tbl_NonPOBasedInvoiceDistributionId = Request.QueryString["NonPOBasedInvoiceDistributionId"];

            nonPOBasedInvoiceDistributionFormUI.Tbl_NonPOBasedInvoiceId = txtNonPOBasedInvoiceIdGuid.Text;
            nonPOBasedInvoiceDistributionFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text;
            nonPOBasedInvoiceDistributionFormUI.Opt_GLAccountType = Convert.ToInt16(ddlOpt_GLAccountType.SelectedValue);
            nonPOBasedInvoiceDistributionFormUI.Description = txtDescription.Text;
            nonPOBasedInvoiceDistributionFormUI.DistributionReference = txtDistributionReference.Text;
            nonPOBasedInvoiceDistributionFormUI.Debit = Convert.ToDecimal(txtDebit.Text);
            nonPOBasedInvoiceDistributionFormUI.Credit = Convert.ToDecimal(txtCredit.Text);
            nonPOBasedInvoiceDistributionFormUI.OriginatingDebit = Convert.ToDecimal(txtOriginatingDebit.Text);
            nonPOBasedInvoiceDistributionFormUI.OriginatingCredit = Convert.ToDecimal(txtCredit.Text);
            nonPOBasedInvoiceDistributionFormUI.ExchangeRate = Convert.ToDecimal(txtExchangeRate.Text);



            if (nonPOBasedInvoiceDistributionFormBAL.UpdateNonPOBasedInvoiceDistribution(nonPOBasedInvoiceDistributionFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceDistributionForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceDistributionForm : btnUpdate_Click] An error occured in the processing of Record Id : " + nonPOBasedInvoiceDistributionFormUI.Tbl_NonPOBasedInvoiceDistributionId + ".  Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            nonPOBasedInvoiceDistributionFormUI.Tbl_NonPOBasedInvoiceDistributionId = Request.QueryString["NonPOBasedInvoiceDistributionId"];

            if (nonPOBasedInvoiceDistributionFormBAL.DeleteNonPOBasedInvoiceDistribution(nonPOBasedInvoiceDistributionFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_General_Expenses_NonPOBasedInvoiceDistributionForm.CS";
            logExcpUIobj.RecordId = nonPOBasedInvoiceDistributionFormUI.Tbl_NonPOBasedInvoiceDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceDistributionForm : btnDelete_Click] An error occured in the processing of Record Id : " + nonPOBasedInvoiceDistributionFormUI.Tbl_NonPOBasedInvoiceDistributionId + ". Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("NonPOBasedInvoiceDistributionList.aspx");
    }

    protected void txtNonPOBasedInvoiceId_TextChanged(object sender, EventArgs e)
    {
        nonPOBasedInvoiceDistributionFormUI.Tbl_NonPOBasedInvoiceId = txtNonPOBasedInvoiceIdGuid.Text;
        BindNonPOBasedInvoiceDistribution(nonPOBasedInvoiceDistributionFormUI);
    }

    protected void ddlOpt_GLAccountType_TextChanged(object sender, EventArgs e)
    {
        int Opt_Type = Convert.ToInt32(ddlOpt_GLAccountType.SelectedValue);
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

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Finance/Accounts_Payable/Non_PO_Based_Invoice/NonPOBasedInvoiceDistributionForm.aspx";
        string recordId = Request.QueryString["NonPOBasedInvoiceDistributionId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }



    #region Non PO Based Invoice Id Search
    protected void btnNonPOBasedInvoiceIdSearch_Click(object sender, EventArgs e)
    {
        btnHtmlNonPOBasedInvoiceIdSearch.Visible = false;
        btnHtmlNonPOBasedInvoiceIdClose.Visible = true;
        SearchNonPOBasedInvoiceIdList();
    }
    protected void btnClearNonPOBasedInvoiceIdSearch_Click(object sender, EventArgs e)
    {
        BindNonPOBasedInvoiceIdList();
        gvNonPOBasedInvoiceIdSearch.Visible = true;
        btnHtmlNonPOBasedInvoiceIdSearch.Visible = true;
        btnHtmlNonPOBasedInvoiceIdClose.Visible = false;
        txtNonPOBasedInvoiceIdSearch.Text = "";
        txtNonPOBasedInvoiceIdSearch.Focus();
    }
    protected void btnNonPOBasedInvoiceIdRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindNonPOBasedInvoiceIdList();
    }
    #endregion Batch Search

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

    #endregion

    #region Methods

    #region NonPOBasedInvoiceId Search    
    private void SearchNonPOBasedInvoiceIdList()
    {
        try
        {
            NonPOBasedInvoiceListUI nonPOBasedInvoiceListUI = new NonPOBasedInvoiceListUI();
            nonPOBasedInvoiceListUI.Search = txtNonPOBasedInvoiceIdSearch.Text;


            DataTable dtb = nonPOBasedInvoiceListBAL.GetNonPOBasedInvoiceListBySearchParameters(nonPOBasedInvoiceListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvNonPOBasedInvoiceIdSearch.DataSource = dtb;
                gvNonPOBasedInvoiceIdSearch.DataBind();
                divNonPOBasedInvoiceIdSearchError.Visible = false;
            }
            else
            {
                divNonPOBasedInvoiceIdSearchError.Visible = true;
                lblNonPOBasedInvoiceIdSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvNonPOBasedInvoiceIdSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchNonPOBasedInvoiceIdList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceDistributionForm : SearchNonPOBasedInvoiceIdList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindNonPOBasedInvoiceIdList()
    {
        try
        {
            DataTable dtb = nonPOBasedInvoiceListBAL.GetNonPOBasedInvoiceList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvNonPOBasedInvoiceIdSearch.DataSource = dtb;
                gvNonPOBasedInvoiceIdSearch.DataBind();
                divNonPOBasedInvoiceIdSearchError.Visible = false;

            }
            else
            {
                divNonPOBasedInvoiceIdSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvNonPOBasedInvoiceIdSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindNonPOBasedInvoiceIdList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceDistributionForm : BindNonPOBasedInvoiceIdList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion NonPOBasedInvoiceId Search

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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceDistributionForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceDistributionForm : BindGLAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion

    private void BindGLAccountTypeDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_NonPOBasedInvoiceDistribution";
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceDistributionForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceDistributionForm : BindGLAccountTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void FillForm( NonPOBasedInvoiceDistributionFormUI nonPOBasedInvoiceDistributionFormUI)
    {
        try
        {
            DataTable dtb = nonPOBasedInvoiceDistributionFormBAL.GetNonPOBasedInvoiceDistributionListById(nonPOBasedInvoiceDistributionFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtNonPOBasedInvoiceIdGuid.Text= dtb.Rows[0]["tbl_NonPOBasedInvoiceId"].ToString();
                txtNonPOBasedInvoiceId.Text = dtb.Rows[0]["tbl_POBasedInvoice"].ToString();
                txtGLAccountGuid.Text= dtb.Rows[0]["tbl_GLAccountId"].ToString();
                txtGLAccount.Text= dtb.Rows[0]["tbl_GLAccount"].ToString();
                ddlOpt_GLAccountType.SelectedValue = dtb.Rows[0]["GLAccountType"].ToString();
                txtDescription.Text= dtb.Rows[0]["Description"].ToString();
                txtDistributionReference.Text = dtb.Rows[0]["DistributionReference"].ToString();
                txtDebit.Text= dtb.Rows[0]["Debit"].ToString();
                txtCredit.Text= dtb.Rows[0]["Credit"].ToString();
                txtOriginatingDebit.Text= dtb.Rows[0]["OriginatingDebit"].ToString();
                txtOriginatingCredit.Text = dtb.Rows[0]["OriginatingCredit"].ToString();
                txtExchangeRate.Text= dtb.Rows[0]["ExchangeRate"].ToString();
                ddlOpt_GLAccountType.SelectedValue = dtb.Rows[0]["opt_GLAccountType"].ToString();
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceDistributionForm.CS";
            logExcpUIobj.RecordId = nonPOBasedInvoiceDistributionFormUI.Tbl_NonPOBasedInvoiceDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceDistributionForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindNonPOBasedInvoiceDistribution(NonPOBasedInvoiceDistributionFormUI nonPOBasedInvoiceDistributionFormUI)
    {
        try
        {

            DataTable dtb = nonPOBasedInvoiceDistributionFormBAL.GetNonPOBasedInvoiceDistribution_SelectByNonPOBasedInvoiceId(nonPOBasedInvoiceDistributionFormUI);
            {
                if (dtb.Rows.Count > 0)
                {
                    txtNonPOBasedInvoiceId.Text = dtb.Rows[0]["tbl_POBasedInvoice"].ToString();
                    txtNonPOBasedInvoiceIdGuid.Text = dtb.Rows[0]["tbl_NonPOBasedInvoiceId"].ToString();
                    txtSupplierCode.Text = dtb.Rows[0]["SupplierCode"].ToString();
                    txtSupplierName.Text = dtb.Rows[0]["Name"].ToString();
                    txtReceiptnumber.Text = dtb.Rows[0]["tbl_POBasedInvoice"].ToString();
                    txtDocumentNumber.Text = dtb.Rows[0]["DocumentNumber"].ToString();                  
                    txtCurrencyName.Text = dtb.Rows[0]["CurrencyName"].ToString();
                    txtFunctionalAmount.Text = dtb.Rows[0]["Total"].ToString();
                    txtOrginatingAmount.Text = dtb.Rows[0]["Total"].ToString();
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
            logExcpUIobj.RecordId = nonPOBasedInvoiceDistributionFormUI.Tbl_NonPOBasedInvoiceId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_Default : txtDownPaymentcust_TextChanged] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }



    #endregion





}
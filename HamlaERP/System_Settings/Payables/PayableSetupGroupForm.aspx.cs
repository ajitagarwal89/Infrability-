using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using log4net;
using Finware;
using System.Data.SqlClient;

public partial class Finance_Accounts_Payable_Setup_PayableSetupGroupForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    PayableSetupGroupFormUI payableSetupGroupFormUI = new PayableSetupGroupFormUI();
    PayableSetupGroupFormBAL payableSetupGroupFormBAL = new PayableSetupGroupFormBAL();
    PayableSetupGroupListBAL payableSetupGroupListBAL = new PayableSetupGroupListBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    ChequeBookListBAL chequeBookListBAL = new ChequeBookListBAL();
    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    CurrencyListUI currencyListUI = new CurrencyListUI();
    PaymentTermsListBAL paymentTermsListBAL = new PaymentTermsListBAL();
    PayableSetupListBAL payableSetupListBAL = new PayableSetupListBAL();
    #endregion Data Members
    protected override void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            
            if (Request.QueryString["PayableSetupGroupId"] != null || Request.QueryString["recordId"] != null)
            {
                BindPayablesTypeMinPaymentDropDownList();
                BindPayablesTypeMaxInvoiceAmtDropDownList();
                BindPayablesTypeCreditLimitDropDownList();
                BindPayablesTypeWriteOffDropDownList();
                payableSetupGroupFormUI.Tbl_PayableSetupGroupId = (Request.QueryString["PayableSetupGroupId"] != null ? Request.QueryString["PayableSetupGroupId"] : Request.QueryString["recordId"]);
                FillForm(payableSetupGroupFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update PayableSetup Group";
            }
            else
            {
BindPayablesTypeMinPaymentDropDownList();
            BindPayablesTypeMaxInvoiceAmtDropDownList();
            BindPayablesTypeCreditLimitDropDownList();
            BindPayablesTypeWriteOffDropDownList();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New PayableSetup Group";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            payableSetupGroupFormUI.CreatedBy = SessionContext.UserGuid;
            payableSetupGroupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            payableSetupGroupFormUI.tbl_PayableSetup = txtPayableSetupGuid.Text;
            payableSetupGroupFormUI.tbl_PayableSetupGroupId_Self = txtGroupIDGuid.Text;
            if (chkDefault.Checked)
            {
                payableSetupGroupFormUI.Default = true;
            }
            else
            {
                payableSetupGroupFormUI.Default = false;
            }


            payableSetupGroupFormUI.Description = txtDescription.Text;
            payableSetupGroupFormUI.tbl_CurrencyId = txtCurrencyGuid.Text;
            payableSetupGroupFormUI.tbl_PaymentTermsId = txtPaymentTermsGuid.Text;
            payableSetupGroupFormUI.PaymentPriority = txtPaymentPriority.Text;
            payableSetupGroupFormUI.MinimumOrder = txtMinimumOrder.Text;
            payableSetupGroupFormUI.TradeDiscount = txtTradeDiscount.Text;
            payableSetupGroupFormUI.Opt_MinimumPayment =Convert.ToInt32(ddlMinimumPayment.SelectedValue.ToString());
            payableSetupGroupFormUI.Opt_MaximumInvoiceAmt = Convert.ToInt32(ddlMaxInvoiceAmt.SelectedValue.ToString());
            payableSetupGroupFormUI.Opt_CreditLimit= Convert.ToInt32(ddlCreditLimit.SelectedValue.ToString());
            payableSetupGroupFormUI.Opt_WriteOff= Convert.ToInt32(ddlWriteOff.SelectedValue.ToString());
            if (chkCalenderYear.Checked == true)
            {
                payableSetupGroupFormUI.CalenderYear = true;
            }
            else
            {
                payableSetupGroupFormUI.CalenderYear = false;
            }
            if (chkTransaction.Checked == true)
            {
                payableSetupGroupFormUI.Transaction = true;
            }
            else
            {
                payableSetupGroupFormUI.Transaction = false;
            }
            if (chkFiscalYear.Checked==true)
            {

                payableSetupGroupFormUI.FiscalYear = true;
            }
            else
            {
                payableSetupGroupFormUI.FiscalYear = false;
            }
            if (chkDistribution.Checked==true)
            {

                payableSetupGroupFormUI.Distribution = true;
            }
            else
            {
                payableSetupGroupFormUI.Distribution = false;
            }

          
            if (payableSetupGroupFormBAL.AddPayableSetupGroup(payableSetupGroupFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupGroupForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupGroupForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            payableSetupGroupFormUI.ModifiedBy = SessionContext.UserGuid;
            payableSetupGroupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            payableSetupGroupFormUI.Tbl_PayableSetupGroupId = Request.QueryString["PayableSetupGroupId"];
            payableSetupGroupFormUI.tbl_PayableSetup = txtPayableSetupGuid.Text;
            payableSetupGroupFormUI.tbl_PayableSetupGroupId_Self = txtGroupIDGuid.Text;
            if (chkDefault.Checked)
            {
                payableSetupGroupFormUI.Default = true;
            }
            else
            {
                payableSetupGroupFormUI.Default = false;
            }


            payableSetupGroupFormUI.Description = txtDescription.Text;
            payableSetupGroupFormUI.tbl_CurrencyId = txtCurrencyGuid.Text;
            payableSetupGroupFormUI.tbl_PaymentTermsId = txtPaymentTermsGuid.Text;
            payableSetupGroupFormUI.PaymentPriority = txtPaymentPriority.Text;
            payableSetupGroupFormUI.MinimumOrder = txtMinimumOrder.Text;
            payableSetupGroupFormUI.TradeDiscount = txtTradeDiscount.Text;
            payableSetupGroupFormUI.Opt_MinimumPayment = Convert.ToInt32(ddlMinimumPayment.SelectedValue.ToString());
            payableSetupGroupFormUI.Opt_MaximumInvoiceAmt = Convert.ToInt32(ddlMaxInvoiceAmt.SelectedValue.ToString());
            payableSetupGroupFormUI.Opt_CreditLimit = Convert.ToInt32(ddlCreditLimit.SelectedValue.ToString());
            payableSetupGroupFormUI.Opt_WriteOff = Convert.ToInt32(ddlWriteOff.SelectedValue.ToString());
            if (chkCalenderYear.Checked == true)
            {
                payableSetupGroupFormUI.CalenderYear = true;
            }
            else
            {
                payableSetupGroupFormUI.CalenderYear = false;
            }
            if (chkTransaction.Checked == true)
            {
                payableSetupGroupFormUI.Transaction = true;
            }
            else
            {
                payableSetupGroupFormUI.Transaction = false;
            }
            if (chkFiscalYear.Checked == true)
            {

                payableSetupGroupFormUI.FiscalYear = true;
            }
            else
            {
                payableSetupGroupFormUI.FiscalYear = false;
            }
            if (chkDistribution.Checked == true)
            {

                payableSetupGroupFormUI.Distribution = true;
            }
            else
            {
                payableSetupGroupFormUI.Distribution = false;
            }

            if (payableSetupGroupFormBAL.UpdatePayableSetupGroup(payableSetupGroupFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupGroupForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupGroupForm : btnUpdate_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        PayableSetupGroupFormUI payableSetupGroupFormUI = new PayableSetupGroupFormUI();
        try
        {
            payableSetupGroupFormUI.Tbl_PayableSetupGroupId = Request.QueryString["PayableSetupGroupId"];

            if (payableSetupGroupFormBAL.DeletePayableSetupGroup(payableSetupGroupFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupGroupForm.CS";
            logExcpUIobj.RecordId = payableSetupGroupFormUI.Tbl_PayableSetupGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupGroupForm : btnDelete_Click] An error occured in the processing of Record Id : " + payableSetupGroupFormUI.Tbl_PayableSetupGroupId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PayableSetupGroupList.aspx");
    }

   

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Finance/Accounts_Payable/Setup/PayableSetupGroupForm.aspx";
        string recordId = Request.QueryString["PayableSetupGroupId"];
        Response.Redirect("~/System_Settings/AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    #region  BindPayablesTypeMinPaymentDropDownList
    private void BindPayablesTypeMinPaymentDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_PayableSetupGroup";
            optionSetListUI.OptionSetName = "Opt_MinimumPayment";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlMinimumPayment.DataSource = dtb;

                ddlMinimumPayment.DataTextField = "OptionSetLable";
                ddlMinimumPayment.DataValueField = "OptionSetValue";

                ddlMinimumPayment.DataBind();

                ddlMinimumPayment.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlMinimumPayment.SelectedIndex = 0;
            }
            else
            {
                ddlMinimumPayment.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPayablesTypeDropDownList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupGroupForm : BindPayablesTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion


    #region  BindPayablesTypeMaxInvoiceAmtDropDownList
    private void BindPayablesTypeMaxInvoiceAmtDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_PayableSetupGroup";
            optionSetListUI.OptionSetName = "Opt_MaximumInvoiceAmt";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlMaxInvoiceAmt.DataSource = dtb;

                ddlMaxInvoiceAmt.DataTextField = "OptionSetLable";
                ddlMaxInvoiceAmt.DataValueField = "OptionSetValue";

                ddlMaxInvoiceAmt.DataBind();

                ddlMaxInvoiceAmt.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlMaxInvoiceAmt.SelectedIndex = 0;
            }
            else
            {
                ddlMaxInvoiceAmt.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPayablesTypeMaxInvoiceAmtDropDownList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupGroupForm : BindPayablesTypeMaxInvoiceAmtDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion

    #region  BindPayablesTypeCreditLimitDropDownList
    private void BindPayablesTypeCreditLimitDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_PayableSetupGroup";
            optionSetListUI.OptionSetName = "Opt_CreditLimit";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlCreditLimit.DataSource = dtb;

                ddlCreditLimit.DataTextField = "OptionSetLable";
                ddlCreditLimit.DataValueField = "OptionSetValue";

                ddlCreditLimit.DataBind();

                ddlCreditLimit.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlCreditLimit.SelectedIndex = 0;
            }
            else
            {
                ddlCreditLimit.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPayablesTypeCreditLimitDropDownList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupGroupForm : BindPayablesTypeCreditLimitDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion


    #region  BindPayablesTypeCreditLimitDropDownList
    private void BindPayablesTypeWriteOffDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_PayableSetupGroup";
            optionSetListUI.OptionSetName = "Opt_WriteOff";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlWriteOff.DataSource = dtb;

                ddlWriteOff.DataTextField = "OptionSetLable";
                ddlWriteOff.DataValueField = "OptionSetValue";

                ddlWriteOff.DataBind();

                ddlWriteOff.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlWriteOff.SelectedIndex = 0;
            }
            else
            {
                ddlCreditLimit.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPayablesTypeCreditLimitDropDownList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupGroupForm : BindPayablesTypeCreditLimitDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion
    #region  PayableSetupGroupSearch
    protected void btnPayableSetupGroupSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPayableSetupGroupSearch.Visible = false;
        btnHtmlPayableSetupGroupClose.Visible = true;
        SearchPayableSetupGroup_Self();

    }
    protected void btnClearPayableSetupGroupSearch_Click(object sender, EventArgs e)
    {
        BindPayableSetupGroup_Self();
        gvPayableSetupGroupSearch.Visible = true;
        btnHtmlPayableSetupGroupSearch.Visible = true;
        btnHtmlPayableSetupGroupClose.Visible = false;
        txtGroupID.Text = "";
        txtGroupID.Focus();

    }
    protected void btnPayableSetupGroupRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPayableSetupGroup_Self();
    }
    #endregion

    #region SearchPayableSetupGroup_Self
    private void SearchPayableSetupGroup_Self()
    {

        {
            try
            {
                PayableSetupGroupListBAL payableSetupGroupListBAL = new PayableSetupGroupListBAL();
                PayableSetupGroupListUI payableSetupGroupListUI = new PayableSetupGroupListUI();



                payableSetupGroupListUI.Search = txtGroupID.Text;

                DataTable dtb = payableSetupGroupListBAL.GetPayableSetupGroupListBySearchParameters(payableSetupGroupListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    gvPayableSetupGroupSearch.DataSource = dtb;
                    gvPayableSetupGroupSearch.DataBind();
                    divPayableSetupGroupSearchError.Visible = false;
                }
                else
                {
                    divPayableSetupGroupSearchError.Visible = true;
                    lblPayableSetupGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                    gvPayableSetupGroupSearch.Visible = false;
                }

            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "SearchPayableSetupGroup_Self()";
                logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupGroupForm.CS";
                logExcpUIobj.RecordId = "All";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Finance_Accounts_Payable_Setup_PayableSetupGroupForm : SearchPayableSetupGroup_Self] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
        }
    }
    private void BindPayableSetupGroup_Self()
    {
        try
        {
            DataTable dtb = payableSetupGroupListBAL.GetPayableSetupGroup_List();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPayableSetupGroupSearch.DataSource = dtb;
                gvPayableSetupGroupSearch.DataBind();
                divPayableSetupGroupSearchError.Visible = false;
            }
            else
            {
                divPayableSetupGroupSearchError.Visible = true;
                lblPayableSetupGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPayableSetupGroupSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPayableSetupGroup_Self()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupGroupForm : BindPayableSetupGroup_Self] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion

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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupGroupForm : SearchCurrency] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupGroupForm : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Currency Search
    #region Payment Terms Search
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
    #endregion Payment Terms Search
    #region Payment Terms Search
    private void SearchPaymentTermsList()
    {
        try
        {
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupGroupForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPaymentTermsSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPaymentTermsList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_PayableSetupGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_Setup_PayableSetupGroupForm : BindPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Payment Terms Serach

    #region  PayableSetupSearch
    protected void btnPayableSetupSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPayableSetupSearch.Visible = false;
        btnHtmlPayableSetupClose.Visible = true;
        SearchPayableSetupList();

    }
    protected void btnClearPayableSetupSearch_Click(object sender, EventArgs e)
    {
        BindPayableSetupList();
        gvPayableSetupSearch.Visible = true;
        btnHtmlPayableSetupSearch.Visible = true;
        btnHtmlPayableSetupClose.Visible = false;
        txtPayableSetup.Text = "";
        txtPayableSetup.Focus();

    }
    protected void btnPayableSetupRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPayableSetupList();
    }
    #endregion

    #region SearchPayableSetup
    private void SearchPayableSetupList()
    {

        {
            try
            {
                PayableSetupGroupListBAL payableSetupGroupListBAL = new PayableSetupGroupListBAL();
                PayableSetupGroupListUI payableSetupGroupListUI = new PayableSetupGroupListUI();


                payableSetupGroupListUI.Search = txtPayableSetupSearch.Text;

                DataTable dtb = payableSetupGroupListBAL.GetPayableSetupGroupListBySearchParameters(payableSetupGroupListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    gvPayableSetupGroupSearch.DataSource = dtb;
                    gvPayableSetupGroupSearch.DataBind();
                    divPayableSetupGroupSearchError.Visible = false;
                }
                else
                {
                    divPayableSetupGroupSearchError.Visible = true;
                    lblPayableSetupGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                    gvPayableSetupGroupSearch.Visible = false;
                }

            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "SearchChequeBookList()";
                logExcpUIobj.ResourceName = "System_Settings_Payable_SetupForm.CS";
                logExcpUIobj.RecordId = "All";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[System_Settings_Payable_SetupForm : SearchChequeBookList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
        }
    }
    private void BindPayableSetupList()
    {
        try
        {
            DataTable dtb = payableSetupListBAL.GetPayableSetupList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPayableSetupSearch.DataSource = dtb;
                gvPayableSetupSearch.DataBind();
                divPayableSetupSearchError.Visible = false;
            }
            else
            {
                divPayableSetupSearchError.Visible = true;
                lblPayableSetupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPayableSetupSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindChequeBookList()";
            logExcpUIobj.ResourceName = "System_Settings_Payable_SetupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_Payable_SetupForm : BindCashList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion


    private void FillForm(PayableSetupGroupFormUI payableSetupGroupFormUI)
    {
        try
        {
            DataTable dtb = payableSetupGroupFormBAL.GetPayableSetupGroupListById(payableSetupGroupFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtPayableSetup.Text= dtb.Rows[0]["tbl_PayableSetup"].ToString();
                txtPayableSetupGuid.Text= dtb.Rows[0]["tbl_PayableSetupId"].ToString();
                txtGroupID.Text= dtb.Rows[0]["PayableSetupGroupId_Self"].ToString();
                txtGroupIDGuid.Text = dtb.Rows[0]["tbl_PayableSetupGroupId_Self"].ToString();
                if (Convert.ToBoolean(dtb.Rows[0]["Default"]) == true)
                { chkDefault.Checked = true; }
                else { chkDefault.Checked = false; }
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                txtCurrency.Text = dtb.Rows[0]["CurrencyName"].ToString();
                txtCurrencyGuid.Text = dtb.Rows[0]["tbl_CurrencyId"].ToString();
                txtPaymentTerms.Text = dtb.Rows[0]["PaymentTermsName"].ToString();
                txtPaymentTermsGuid.Text = dtb.Rows[0]["tbl_PaymentTermsId"].ToString();
                txtPaymentPriority.Text = dtb.Rows[0]["PaymentPriority"].ToString();
                txtMinimumOrder.Text = dtb.Rows[0]["MinimumOrder"].ToString();
                txtTradeDiscount.Text = dtb.Rows[0]["TradeDiscount"].ToString();
                ddlMinimumPayment.SelectedValue = dtb.Rows[0]["Opt_MinimumPayment"].ToString();
                ddlMaxInvoiceAmt.SelectedValue = dtb.Rows[0]["Opt_MaximumInvoiceAmt"].ToString();
                ddlCreditLimit.SelectedValue = dtb.Rows[0]["Opt_CreditLimit"].ToString();
                ddlWriteOff.SelectedValue = dtb.Rows[0]["Opt_WriteOff"].ToString();
                if (Convert.ToBoolean(dtb.Rows[0]["CalenderYear"]) == true)
                { chkCalenderYear.Checked = true; }
                else { chkCalenderYear.Checked = false; }
                if (Convert.ToBoolean(dtb.Rows[0]["Transaction"]) == true)
                { chkTransaction.Checked = true; }
                else { chkTransaction.Checked = false; }
                if (Convert.ToBoolean(dtb.Rows[0]["FiscalYear"]) == true)
                { chkFiscalYear.Checked = true; }
                else { chkFiscalYear.Checked = false; }
                if (Convert.ToBoolean(dtb.Rows[0]["Distribution"]) == true)
                { chkDistribution.Checked = true; }
                else { chkDistribution.Checked = false; }



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
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = payableSetupGroupFormUI.Tbl_PayableSetupGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_PayablesForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
}
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;
using System.IO;
using System.Collections.Generic;


public partial class System_Settings_ReceivableSetupGroupForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    CustomerListBAL customerListBAL = new CustomerListBAL();
    PaymentTermsListBAL paymentTermsListBAL = new PaymentTermsListBAL();
    ReceivableSetupGroupFormBAL receivableSetupGroupFormBAL = new ReceivableSetupGroupFormBAL();
    ReceivableSetupGroupFormUI receivableSetupGroupFormUI = new ReceivableSetupGroupFormUI();
    ReceivableSetupListBAL receivableSetupListBAL = new ReceivableSetupListBAL();
    ReceivableSetupListUI receivableSetupListUI = new ReceivableSetupListUI();
    Audit_IUD audit_IUD = new Audit_IUD();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    ReceivableSetupGroupListBAL ReceivableSetupGroupListBAL = new ReceivableSetupGroupListBAL();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        ReceivableSetupGroupFormUI receivableSetupGroupFormUI = new ReceivableSetupGroupFormUI();

        if (!Page.IsPostBack)
        {
            BindStatementCycleDropDownList();
            BindWriteOffDropDownList();
            BindCreditLimitDropDownList();
            BindMinimumPaymentDropDownList();
            if (Request.QueryString["ReceivableSetupGroupId"] != null || Request.QueryString["recordId"] != null)
            {
                receivableSetupGroupFormUI.Tbl_ReceivableSetupGroupId = (Request.QueryString["ReceivableSetupGroupId"] != null ? Request.QueryString["ReceivableSetupGroupId"] : Request.QueryString["recordId"]);
                FillForm(receivableSetupGroupFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update ReceivableSetupGroup";
            }
            else
            {
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New ReceivableSetupGroup";
            }
            
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            receivableSetupGroupFormUI.CreatedBy = SessionContext.UserGuid;
            receivableSetupGroupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            receivableSetupGroupFormUI.Tbl_ReceivableSetupGroupId_Self = txtReceivableSetupGroupId_SelfGuid.Text;

            receivableSetupGroupFormUI.Tbl_ReceivableSetupId = txtReceivableSetupGuid.Text;
            if (chkDefault.Checked)
            {
                receivableSetupGroupFormUI.ISDefault = true;
            }
            else {
                receivableSetupGroupFormUI.ISDefault = true;
            }
            receivableSetupGroupFormUI.Description = txtDescription.Text;
          
            receivableSetupGroupFormUI.Tbl_PaymentTermsId = txtPaymentTermseGuid.Text;
            if (rdbOpenItem.Checked)
            { receivableSetupGroupFormUI.ISBalanceType = true; }
            else if (rdbBalanceForward.Checked)
                {
                    receivableSetupGroupFormUI.ISBalanceType = false;
                }
            receivableSetupGroupFormUI.opt_MinimumPayment = Convert.ToInt32(ddl_OptMinimumPayment.SelectedValue);
            receivableSetupGroupFormUI.MinimumPayment = Convert.ToDecimal(txtMiniumPayment.Text);

            receivableSetupGroupFormUI.opt_CreditLimit = Convert.ToInt32(ddl_OptCreditLimit.SelectedValue);
            receivableSetupGroupFormUI.CreditLimit =Convert.ToDecimal(txtCreditLimit.Text);
            receivableSetupGroupFormUI.opt_WriteOff = Convert.ToInt32(ddl_OptWriteOff.SelectedValue);
            receivableSetupGroupFormUI.WriteOff = Convert.ToDecimal(txtWriteOff.Text);
            receivableSetupGroupFormUI.TradeDiscount = Convert.ToDecimal(txtTradeDiscount.Text);
            receivableSetupGroupFormUI.Opt_StatementCycle = Convert.ToInt32(ddlStatementCycle.SelectedValue);

            if (chkCalendarYear.Checked)
            { receivableSetupGroupFormUI.IsCalendar = true; }
            else {
                receivableSetupGroupFormUI.IsCalendar = false;
            }

            if (chkFiscalYear.Checked)
            { receivableSetupGroupFormUI.IsFiscalYear = true; }
            else {
                receivableSetupGroupFormUI.IsFiscalYear = false;
            }
            if (chkTransaction.Checked)
            { receivableSetupGroupFormUI.IsTransaction = true; }
            else
            {
                receivableSetupGroupFormUI.IsTransaction = false;
            }
            if (chkDistribution.Checked)
            { receivableSetupGroupFormUI.IsDistribution = true; }
            else
            {
                receivableSetupGroupFormUI.IsDistribution = false;
            }       

            if (receivableSetupGroupFormBAL.AddRecievableSetupGroup(receivableSetupGroupFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;               
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);

                            }
            else
            {

                divError.Visible = true;
                divSuccess.Visible = false;
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableSetupGroupForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableSetupGroupForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            receivableSetupGroupFormUI.ModifiedBy = SessionContext.UserGuid;
            receivableSetupGroupFormUI.Tbl_ReceivableSetupGroupId = Request.QueryString["ReceivableSetupGroupId"];
            receivableSetupGroupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            receivableSetupGroupFormUI.Tbl_ReceivableSetupGroupId_Self = txtReceivableSetupGroupId_SelfGuid.Text;

            receivableSetupGroupFormUI.Tbl_ReceivableSetupId = txtReceivableSetupGuid.Text;
            if (chkDefault.Checked)
            {
                receivableSetupGroupFormUI.ISDefault = true;
            }
            else
            {
                receivableSetupGroupFormUI.ISDefault = true;
            }
            receivableSetupGroupFormUI.Description = txtDescription.Text;

            receivableSetupGroupFormUI.Tbl_PaymentTermsId = txtPaymentTermseGuid.Text;
            if (rdbOpenItem.Checked)
            { receivableSetupGroupFormUI.ISBalanceType = true; }
            else if (rdbBalanceForward.Checked)
            {
                receivableSetupGroupFormUI.ISBalanceType = false;
            }
            receivableSetupGroupFormUI.opt_MinimumPayment = Convert.ToInt32(ddl_OptMinimumPayment.SelectedValue);
            receivableSetupGroupFormUI.MinimumPayment = Convert.ToDecimal(txtMiniumPayment.Text);

            receivableSetupGroupFormUI.opt_CreditLimit = Convert.ToInt32(ddl_OptCreditLimit.SelectedValue);
            receivableSetupGroupFormUI.CreditLimit = Convert.ToDecimal(txtCreditLimit.Text);
            receivableSetupGroupFormUI.opt_WriteOff = Convert.ToInt32(ddl_OptWriteOff.SelectedValue);
            receivableSetupGroupFormUI.WriteOff = Convert.ToDecimal(txtWriteOff.Text);
            receivableSetupGroupFormUI.TradeDiscount = Convert.ToDecimal(txtTradeDiscount.Text);
            receivableSetupGroupFormUI.Opt_StatementCycle = Convert.ToInt32(ddlStatementCycle.SelectedValue);

            if (chkCalendarYear.Checked)
            { receivableSetupGroupFormUI.IsCalendar = true; }
            else
            {
                receivableSetupGroupFormUI.IsCalendar = false;
            }

            if (chkFiscalYear.Checked)
            { receivableSetupGroupFormUI.IsFiscalYear = true; }
            else
            {
                receivableSetupGroupFormUI.IsFiscalYear = false;
            }
            if (chkTransaction.Checked)
            { receivableSetupGroupFormUI.IsTransaction = true; }
            else
            {
                receivableSetupGroupFormUI.IsTransaction = false;
            }
            if (chkDistribution.Checked)
            { receivableSetupGroupFormUI.IsDistribution = true; }
            else
            {
                receivableSetupGroupFormUI.IsDistribution = false;
            }

            if (receivableSetupGroupFormBAL.UpdateReceivableSetupGroup(receivableSetupGroupFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_ReceivableSetupGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableSetupGroupForm : btnUpdate_Click] An error occured in the processing of Record Id : " + receivableSetupGroupFormUI.Tbl_ReceivableSetupGroupId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            receivableSetupGroupFormUI.Tbl_ReceivableSetupGroupId = Request.QueryString["ReceivableSetupGroupId"];

            if (receivableSetupGroupFormBAL.DeleteRecievableSetupGroup(receivableSetupGroupFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_ReceivableSetupGroupForm.CS";
            logExcpUIobj.RecordId = receivableSetupGroupFormUI.Tbl_ReceivableSetupGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableSetupGroupForm : btnDelete_Click] An error occured in the processing of Record Id : " + receivableSetupGroupFormUI.Tbl_ReceivableSetupGroupId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReceivableSetupGroupList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/System_Settings/ReceivableSetupGroupForm.aspx";
        string recordId = Request.QueryString["ReceivableSetupGroupId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    #region ReceivableSetupGroup
    protected void btnReceivableSetupGroupId_SelfSearch_Click(object sender, EventArgs e)
    {
        btnHtmlReceivableSetupGroupId_SelfSearch.Visible = false;
        btnHtmlReceivableSetupGroupId_SelfClose.Visible = true;
        SearchReceivableSetupGroupId_SelfList();
    }
    protected void btnClearReceivableSetupGroupId_SelfSearch_Click(object sender, EventArgs e)
    {
        BindReceivableSetupGroupId_SelfList();
        gvReceivableSetupGroupId_SelfSearch.Visible = true;
        btnHtmlReceivableSetupGroupId_SelfSearch.Visible = true;
        btnHtmlReceivableSetupGroupId_SelfClose.Visible = false;
        txtReceivableSetupGroupId_SelfSearch.Text = "";
        txtReceivableSetupGroupId_SelfSearch.Focus();
    }
    protected void btnReceivableSetupGroupId_SelfRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindReceivableSetupGroupId_SelfList();
    }
    #endregion
    #region PaymentTermsSearch
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
    #region Recievable Setup  Event
    protected void btnReceivableSetupSearch_Click(object sender, EventArgs e)
    {
        btnHtmlReceivableSetupSearch.Visible = false;
        btnHtmlReceivableSetupClose.Visible = true;
        SearchReceivableSetupList();
    }
    protected void btnClearReceivableSetupSearch_Click(object sender, EventArgs e)
    {
        BindReceivableSetupList();
        gvReceivableSetupSearch.Visible = true;
        btnHtmlReceivableSetupSearch.Visible = true;
        btnHtmlReceivableSetupClose.Visible = false;
        txtReceivableSetupSearch.Text = "";
        txtReceivableSetupSearch.Focus();
    }
    protected void btnReceivableSetupRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindReceivableSetupList();
    }
    #endregion Recievable event
      

    #endregion Events

    #region Methods

    private void BindStatementCycleDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_ReceivableSetupGroup";
            optionSetListUI.OptionSetName = "Opt_StatementCycle";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlStatementCycle.DataSource = dtb;
                ddlStatementCycle.DataBind();
                ddlStatementCycle.DataTextField = "OptionSetLable";
                ddlStatementCycle.DataValueField = "OptionSetValue";
                ddlStatementCycle.DataBind();
            }
            else
            {
                ddlStatementCycle.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindDocumentTypeDropDownList()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableSetupGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableSetupGroupForm : BindDocumentTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindMinimumPaymentDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_ReceivableSetupGroup";
            optionSetListUI.OptionSetName = "Opt_MinimumPayment";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddl_OptMinimumPayment.DataSource = dtb;
                ddl_OptMinimumPayment.DataBind();
                ddl_OptMinimumPayment.DataTextField = "OptionSetLable";
                ddl_OptMinimumPayment.DataValueField = "OptionSetValue";
                ddl_OptMinimumPayment.DataBind();
            }
            else
            {
                ddl_OptMinimumPayment.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindMinimumPaymentDropDownList()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableSetupGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableSetupGroupForm : BindMinimumPaymentDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void BindCreditLimitDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_ReceivableSetupGroup";
            optionSetListUI.OptionSetName = "Opt_CreditLimit";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddl_OptCreditLimit.DataSource = dtb;
                ddl_OptCreditLimit.DataBind();
                ddl_OptCreditLimit.DataTextField = "OptionSetLable";
                ddl_OptCreditLimit.DataValueField = "OptionSetValue";
                ddl_OptCreditLimit.DataBind();
            }
            else
            {
                ddl_OptCreditLimit.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCreditLimitDropDownList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableSetupGroupForm : BindCreditLimitDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void BindWriteOffDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_ReceivableSetupGroup";
            optionSetListUI.OptionSetName = "Opt_Writeoff";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddl_OptWriteOff.DataSource = dtb;
                ddl_OptWriteOff.DataBind();
                ddl_OptWriteOff.DataTextField = "OptionSetLable";
                ddl_OptWriteOff.DataValueField = "OptionSetValue";
                ddl_OptWriteOff.DataBind();
            }
            else
            {
                ddlStatementCycle.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindDocumentTypeDropDownList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableSetupGroupForm : BindDocumentTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void FillForm(ReceivableSetupGroupFormUI receivableSetupGroupFormUI)
    {
        try
        {
            DataTable dtb = receivableSetupGroupFormBAL.GetReceivableSetupGroupListById(receivableSetupGroupFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtReceivableSetupGroupId_Self.Text = dtb.Rows[0]["Description"].ToString();
                txtReceivableSetupGroupId_SelfGuid.Text= dtb.Rows[0]["tbl_ReceivableSetupGroupId_Self"].ToString();
                txtReceivableSetupGuid.Text = dtb.Rows[0]["tbl_ReceivableSetupId"].ToString();
                txtReceivableSetup.Text = dtb.Rows[0]["ReceivableSetupId"].ToString();

                if (Convert.ToBoolean(dtb.Rows[0]["IsDefault"]) == true)
                {
                    chkDefault.Checked = true;
                }
                else { chkDefault.Checked = false; }
                txtDescription.Text= dtb.Rows[0]["Description"].ToString();

                if (Convert.ToBoolean(dtb.Rows[0]["ISBalanceType"]) == true)
                {
                    rdbOpenItem.Checked = true;
                }
                else if (Convert.ToBoolean(dtb.Rows[0]["ISBalanceType"]) == false)
                {
                    rdbBalanceForward.Checked = true;
                }
                               
                txtPaymentTerms.Text=dtb.Rows[0]["PaymentTermsName"].ToString();
                txtPaymentTermseGuid.Text= dtb.Rows[0]["tbl_PaymentTermsId"].ToString();
                ddl_OptMinimumPayment.SelectedValue = dtb.Rows[0]["Opt_MinimumPayment"].ToString();
                txtMiniumPayment.Text = dtb.Rows[0]["MinimumPayment"].ToString();
                ddl_OptCreditLimit.SelectedValue = dtb.Rows[0]["Opt_CreditLimit"].ToString();
                txtCreditLimit.Text = dtb.Rows[0]["CreditLimit"].ToString();
                ddl_OptWriteOff.SelectedValue = dtb.Rows[0]["Opt_WriteOff"].ToString();
                txtWriteOff.Text = dtb.Rows[0]["WriteOff"].ToString();
                txtTradeDiscount.Text= dtb.Rows[0]["TradeDiscount"].ToString();
                ddlStatementCycle.SelectedValue = dtb.Rows[0]["Opt_StatementCycle"].ToString();
                if (Convert.ToBoolean(dtb.Rows[0]["IsCalendar"]) == true)
                {
                    chkCalendarYear.Checked=true;
                }
                else {
                    chkCalendarYear.Checked = false;
                }
                if (Convert.ToBoolean(dtb.Rows[0]["IsFiscalYear"]) == true)
                {
                    chkFiscalYear.Checked = true;
                }
                else
                {
                    chkFiscalYear.Checked = false;
                }
                if (Convert.ToBoolean(dtb.Rows[0]["IsTransaction"]) == true)
                {
                    chkTransaction.Checked = true;
                }
                else
                {
                    chkTransaction.Checked = false;
                }
                if (Convert.ToBoolean(dtb.Rows[0]["IsDistribution"]) == true)
                {
                    chkDistribution.Checked = true;
                }
                else
                {
                    chkDistribution.Checked = false;
                }
            }
            else
            {
                divError.Visible = true;
                divSuccess.Visible = false;
                lblError.Text = Resources.GlobalResource.msgCouldNotLoadData;

            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "FillForm()";
            logExcpUIobj.ResourceName = "System_Settings_BankForm.CS";
            logExcpUIobj.RecordId = this.receivableSetupGroupFormUI.Tbl_ReceivableSetupGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableSetupGroupForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void SearchPaymentTermsList()
    {
        try
        {
            PaymentTermsListBAL paymentTermsListBAL = new PaymentTermsListBAL();
            PaymentTermsListUI PaymentTermsListUI = new PaymentTermsListUI();

            PaymentTermsListUI.Search = txtPaymentTermsSearch.Text;


            DataTable dtb = paymentTermsListBAL.GetPaymentTermsListBySearchParameters(PaymentTermsListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPaymentTermsSearch.DataSource = dtb;
                gvPaymentTermsSearch.DataBind();
                divPaymentTermsSearchError.Visible = false;
            }
            else
            {
                divPaymentTermsSearchError.Visible = true;
                lblPaymentTermsSearchSucces.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPaymentTermsSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchPaymentTermsList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableSetupGroupForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindPaymentTermsList()
    {
        try
        {
            PaymentTermsListBAL paymentTermsListBAL = new PaymentTermsListBAL();
            PaymentTermsListUI PaymentTermsListUI = new PaymentTermsListUI();
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableSetupGroupForm : BindPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    private void BindReceivableSetupGroupId_SelfList()
    {
        try
        {
            DataTable dtb = ReceivableSetupGroupListBAL.GetReceivableSetupGroupList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvReceivableSetupGroupId_SelfSearch.DataSource = dtb;
                gvReceivableSetupGroupId_SelfSearch.DataBind();
                divRecievableSetupGroupId_SelfSearchError.Visible = false;

            }
            else
            {
                divRecievableSetupGroupId_SelfSearchError.Visible = true;
                lblReceivableSetupGroupId_SelfSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvReceivableSetupGroupId_SelfSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCustomerList()";
            logExcpUIobj.ResourceName = "System_Settings_CurrencyList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableSetupGroupForm : BindReceivableSetupGroupId_SelfList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void SearchReceivableSetupGroupId_SelfList()
    {
        try
        {
            ReceivableSetupGroupListUI ReceivableSetupGroupListUI = new ReceivableSetupGroupListUI();
            ReceivableSetupGroupListUI.Search = txtReceivableSetupGroupId_SelfSearch.Text;
            DataTable dtb = ReceivableSetupGroupListBAL.GetReceivableSetupGroupListBySearchParameters(ReceivableSetupGroupListUI);


            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvReceivableSetupGroupId_SelfSearch.DataSource = dtb;
                gvReceivableSetupGroupId_SelfSearch.DataBind();
                divRecievableSetupGroupId_SelfSearchError.Visible = false;

            }
            else
            {
                divRecievableSetupGroupId_SelfSearchError.Visible = true;
                lblReceivableSetupGroupId_SelfSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvReceivableSetupGroupId_SelfSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "Searchtbl_ReceivableSetupGroupId_Self()";
            logExcpUIobj.ResourceName = "System_Settings_CurrencyList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableSetupGroupForm : SearchReceivableSetupGroupId_SelfList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }

    private void BindReceivableSetupList()
    {
        try
        {
            DataTable dtb = receivableSetupListBAL.GetReceivableSetupList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvReceivableSetupSearch.DataSource = dtb;
                gvReceivableSetupSearch.DataBind();
                divReceivableSetupSearchError.Visible = false;

            }
            else
            {
                divReceivableSetupSearchError.Visible = true;
                lblReceivableSetupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvReceivableSetupSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindReceivableSetupList()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableSetupGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableSetupGroupForm : BindReceivableSetupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void SearchReceivableSetupList()
    {
        try
        {
            ReceivableSetupListUI receivableSetupListUI = new ReceivableSetupListUI();
            receivableSetupListUI.Search = txtReceivableSetupSearch.Text;
            DataTable dtb = receivableSetupListBAL.GetReceivableSetupListBySearchParameters(receivableSetupListUI);


            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvReceivableSetupSearch.DataSource = dtb;
                gvReceivableSetupSearch.DataBind();
                divReceivableSetupSearchError.Visible = false;

            }
            else
            {
                divReceivableSetupSearchError.Visible = true;
                lblReceivableSetupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvReceivableSetupSearch.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchReceivableSetupList()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableSetupGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableSetupGroupForm : SearchRecievableSetupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }


    #endregion Methods
}
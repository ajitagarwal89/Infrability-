using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;
using System.IO;
using System.Collections.Generic;

public partial class System_Settings_PayablesForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    PayablesFormUI payablesFormUI = new PayablesFormUI();
    PayablesFormBAL payablesFormBAL = new PayablesFormBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    BankListUI bankListUI = new BankListUI();
    BankListBAL bankListBAL = new BankListBAL();
    CardListUI cardListUI = new CardListUI();
    CardListBAL cardListBAL = new CardListBAL();
    private IEnumerable<FileInfo> logs;

    public object logList { get; private set; }

    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        PayablesFormUI payablesFormUI = new PayablesFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["PayablesId"] != null || Request.QueryString["recordId"] != null)
            {
                payablesFormUI.Tbl_PayablesId = (Request.QueryString["PayablesId"] != null ? Request.QueryString["PayablesId"] : Request.QueryString["recordId"]);


                BindPayablesTypeDropDownList();
                BindProcessTypeDropDownList();
                //ddlOpt_PayablesType.Items.Add(new ListItem("Select Payables Type", "0", true));
                //ddlOpt_ProcessType.Items.Add(new ListItem("Select Process Type", "0", true));
                FillForm(payablesFormUI);
                divCreditCard.Visible = false;
                divChequeNumber.Visible = false;
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Payables";
            }
            else
            {

                BindPayablesTypeDropDownList();
                BindProcessTypeDropDownList();
                //divCreditCard.Visible = false;
                //divChequeNumber.Visible = false;
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New Payables";
                divBank.Visible = false;
                divCreditCard.Visible = false;
                divChequeNumber.Visible = false;
                divPayment.Visible = false;
                divReceipt.Visible = false;
            }



        }
    }

    protected void ddlOpt_PayablesType_SelectedIndexChanged(object sender, EventArgs e)
    {
        RelatedPayables();
    }

    protected void ddlOpt_ProcessType_SelectedIndexChanged(object sender, EventArgs e)
    {
        RelatedPayables();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {
            int payablesType = Convert.ToInt32(ddlOpt_PayablesType.SelectedValue);
            int ProcessType = Convert.ToByte(ddlOpt_ProcessType.SelectedValue);

            int bank = (int)Enums.CommonEnum.Payabletype.BankTransfer;
            int Cheque = (int)Enums.CommonEnum.Payabletype.Cheque;
            int Cash = (int)Enums.CommonEnum.Payabletype.Cash;
            int card = (int)Enums.CommonEnum.Payabletype.CreditCard;

            int Sales = (int)Enums.CommonEnum.ProcessType.Sales;
            int Purchase = (int)Enums.CommonEnum.ProcessType.Purchase;


            payablesFormUI.CreatedBy = SessionContext.UserGuid;
            payablesFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            payablesFormUI.Opt_PayablesType = payablesType;
            payablesFormUI.Opt_ProcessType = Convert.ToByte(ddlOpt_ProcessType.SelectedValue);


            if (payablesType == bank)
                payablesFormUI.Tbl_Bank_AccountId = txtBankGuid.Text.Trim().ToString();
            else
                payablesFormUI.Tbl_Bank_AccountId = null;


            if (payablesType == Cheque)

                payablesFormUI.ChequeNumber = txtChequeNumber.Text.Trim().ToString();

            else
                payablesFormUI.ChequeNumber = null;


            if (payablesType == Cash)
            {
                payablesFormUI.Tbl_Bank_AccountId = null;
                payablesFormUI.Tbl_CardId = null;
                payablesFormUI.ChequeNumber = null;
            }
            if (payablesType == card)
                payablesFormUI.Tbl_CardId = txtCreditCardGuid.Text.Trim().ToString();

            else
                payablesFormUI.Tbl_CardId = null;

            payablesFormUI.DocumentNumber = txtDocumentNumber.Text.Trim().ToString();
            if (ProcessType == Sales)
                payablesFormUI.ReceiptNumber = txtReceiptNumber.Text.Trim().ToString();
            payablesFormUI.PaymentNumber = null;
            if (ProcessType == Purchase)
                payablesFormUI.PaymentNumber = txtPaymentNumber.Text.Trim().ToString();
            payablesFormUI.ReceiptNumber = null;

            if (txtPayablesDate.Text != "")
                payablesFormUI.PayablesDate = DateTime.Parse(txtPayablesDate.Text.ToString());



            if (payablesFormBAL.AddPayables(payablesFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_PayablesForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_PayablesForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            int payablesType = Convert.ToInt32(ddlOpt_PayablesType.SelectedValue);
            int ProcessType = Convert.ToByte(ddlOpt_ProcessType.SelectedValue);

            int bank = (int)Enums.CommonEnum.Payabletype.BankTransfer;
            int Cheque = (int)Enums.CommonEnum.Payabletype.Cheque;
            int Cash = (int)Enums.CommonEnum.Payabletype.Cash;
            int card = (int)Enums.CommonEnum.Payabletype.CreditCard;

            int Sales = (int)Enums.CommonEnum.ProcessType.Sales;
            int Purchase = (int)Enums.CommonEnum.ProcessType.Purchase;
            payablesFormUI.ModifiedBy = SessionContext.UserGuid;
            payablesFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            payablesFormUI.Tbl_PayablesId = Request.QueryString["PayablesId"];
            payablesFormUI.Opt_PayablesType = payablesType;
            payablesFormUI.Opt_ProcessType = Convert.ToByte(ddlOpt_ProcessType.SelectedValue);


            if (payablesType == bank)
                payablesFormUI.Tbl_Bank_AccountId = txtBankGuid.Text.Trim().ToString();
            else
                payablesFormUI.Tbl_Bank_AccountId = null;


            if (payablesType == Cheque)

                payablesFormUI.ChequeNumber = txtChequeNumber.Text.Trim().ToString();

            else
                payablesFormUI.ChequeNumber = null;


            if (payablesType == Cash)
            {
                payablesFormUI.Tbl_Bank_AccountId = null;
                payablesFormUI.Tbl_CardId = null;
                payablesFormUI.ChequeNumber = null;
            }
            if (payablesType == card)
                payablesFormUI.Tbl_CardId = txtCreditCardGuid.Text.Trim().ToString();

            else
                payablesFormUI.Tbl_CardId = null;

            payablesFormUI.DocumentNumber = txtDocumentNumber.Text.Trim().ToString();
            if (ProcessType == Sales)
                payablesFormUI.ReceiptNumber = txtReceiptNumber.Text.Trim().ToString();
            payablesFormUI.PaymentNumber = null;
            if (ProcessType == Purchase)
                payablesFormUI.PaymentNumber = txtPaymentNumber.Text.Trim().ToString();
            payablesFormUI.ReceiptNumber = null;


            if (txtPayablesDate.Text != "")
                payablesFormUI.PayablesDate = DateTime.Parse(txtPayablesDate.Text.ToString());


            if (payablesFormBAL.UpdatePayables(payablesFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_PayablesForm : btnUpdate_Click] An error occured in the processing of Record Id : " + payablesFormUI.Tbl_PayablesId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            payablesFormUI.Tbl_PayablesId = Request.QueryString["PayablesId"];

            if (payablesFormBAL.DeletePayables(payablesFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = payablesFormUI.Tbl_PayablesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_PayablesForm : btnDelete_Click] An error occured in the processing of Record Id : " + payablesFormUI.Tbl_PayablesId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PayablesList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/System_Settings/PayablesForm.aspx";
        string recordId = Request.QueryString["PayablesId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    #region Modal Setup
    #region BankSearch
    protected void btnBankSearch_Click(object sender, EventArgs e)
    {
        btnHtmlBankSearch.Visible = false;
        btnHtmlBankClose.Visible = true;
        BindBankListBySearchParameters();
    }
    protected void btnClearBankSearch_Click(object sender, EventArgs e)
    {
        BindBankList();
        gvBankSearch.Visible = true;
        btnHtmlBankSearch.Visible = true;
        btnHtmlBankClose.Visible = false;
        txtBankSearch.Text = "";
        txtBankSearch.Focus();
    }
    protected void btnBankRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindBankList();
    }
    #endregion

    #region CreditCardSearch
    protected void btnCreditCardSearch_Click(object sender, EventArgs e)
    {
        btnHtmlCreditCardSearch.Visible = false;
        btnHtmlCreditCardClose.Visible = true;
        BindCreditCardListBySearchParameters();
    }
    protected void btnClearCreditCardSearch_Click(object sender, EventArgs e)
    {
        BindCreditCardList();
        gvCreditCardSearch.Visible = true;
        btnHtmlCreditCardSearch.Visible = true;
        btnHtmlCreditCardClose.Visible = false;
        txtCreditCardSearch.Text = "";
        txtCreditCardSearch.Focus();
    }
    protected void btnCreditCardRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindCreditCardList();
    }
    #endregion
    #endregion
    #endregion Events

    #region Methods
    private void FillForm(PayablesFormUI payablesFormUI)
    {
        try
        {
            DataTable dtb = payablesFormBAL.GetPayablesListById(payablesFormUI);

            if (dtb.Rows.Count > 0)
            {

                ddlOpt_PayablesType.SelectedValue = dtb.Rows[0]["opt_PayablesType"].ToString();
                ddlOpt_ProcessType.SelectedValue = dtb.Rows[0]["opt_ProcessType"].ToString();
                txtBank.Text = dtb.Rows[0]["BankName"].ToString();
                txtBankGuid.Text = dtb.Rows[0]["tbl_Bank_AccountId"].ToString();
                txtCreditCard.Text = dtb.Rows[0]["CardName"].ToString();
                txtCreditCardGuid.Text = dtb.Rows[0]["tbl_CardId"].ToString();
                txtDocumentNumber.Text = dtb.Rows[0]["DocumentNumber"].ToString();
                txtReceiptNumber.Text = dtb.Rows[0]["ReceiptNumber"].ToString();
                txtChequeNumber.Text = dtb.Rows[0]["ChequeNumber"].ToString();
                txtPayablesDate.Text = dtb.Rows[0]["PayablesDate"].ToString();
                txtPaymentNumber.Text = dtb.Rows[0]["PaymentNumber"].ToString();
                RelatedPayables();
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
            logExcpUIobj.RecordId = payablesFormUI.Tbl_PayablesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_PayablesForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #region  BindPayablesTypeDropDownList
    private void BindPayablesTypeDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_Payables";
            optionSetListUI.OptionSetName = "Opt_PayablesType";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlOpt_PayablesType.DataSource = dtb;

                ddlOpt_PayablesType.DataTextField = "OptionSetLable";
                ddlOpt_PayablesType.DataValueField = "OptionSetValue";

                ddlOpt_PayablesType.DataBind();

                ddlOpt_PayablesType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlOpt_PayablesType.SelectedIndex = 0;
            }
            else
            {
                ddlOpt_PayablesType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPayablesTypeDropDownList()";
            logExcpUIobj.ResourceName = "System_Settings_PayablesForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_PayablesForm : BindPayablesTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion
    #region  BindProcessTypeDropDownList
    private void BindProcessTypeDropDownList()
    {

        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_Payables";
            optionSetListUI.OptionSetName = "Opt_ProcessType";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlOpt_ProcessType.DataSource = dtb;
                ddlOpt_ProcessType.DataBind();
                ddlOpt_ProcessType.DataTextField = "OptionSetLable";
                ddlOpt_ProcessType.DataValueField = "OptionSetValue";
                ddlOpt_ProcessType.DataBind();
                ddlOpt_ProcessType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlOpt_PayablesType.SelectedIndex = 0;

            }
            else
            {
                ddlOpt_ProcessType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindProcessTypeDropDownList()";
            logExcpUIobj.ResourceName = "System_Settings_PayablesForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_PayablesForm : BindProcessTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }
    #endregion
    #region modal popUp
    #region BindBankListBySearchParameters
    private void BindBankListBySearchParameters()
    {
        try
        {
            DataTable dtb = bankListBAL.GetBankListBySearchParameters(bankListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvBankSearch.DataSource = dtb;
                gvBankSearch.DataBind();
                divBankSearchError.Visible = false;
            }
            else
            {
                divBankSearchError.Visible = true;
                lblBankSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvBankSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindBankListBySearchParameters()";
            logExcpUIobj.ResourceName = "System_Settings_PayablesForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_PayablesForm : BindBankListBySearchParameters] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindBankList()
    {
        try
        {
            DataTable dtb = bankListBAL.GetBankList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvBankSearch.DataSource = dtb;
                gvBankSearch.DataBind();
                divBankSearchError.Visible = false;
            }
            else
            {
                divBankSearchError.Visible = true;
                lblBankSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvBankSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindBankList()";
            logExcpUIobj.ResourceName = "System_Settings_PayablesForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_PayablesForm : BindBankList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion
    # region BindCreditCardList
    private void BindCreditCardList()
    {
        try
        {
            DataTable dtb = cardListBAL.GetCardList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCreditCardSearch.DataSource = dtb;
                gvCreditCardSearch.DataBind();
                divCreditCardSearchError.Visible = false;
            }
            else
            {
                divCreditCardSearchError.Visible = true;
                lblCreditCardSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCreditCardSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCreditCardList()";
            logExcpUIobj.ResourceName = "System_Settings_PayablesForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_PayablesForm : BindCreditCardList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindCreditCardListBySearchParameters()
    {
        try
        {
            DataTable dtb = cardListBAL.GetCardListBySearchParameters(cardListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCreditCardSearch.DataSource = dtb;
                gvCreditCardSearch.DataBind();
                divCreditCardSearchError.Visible = false;
            }
            else
            {
                divCreditCardSearchError.Visible = true;
                lblCreditCardSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCreditCardSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCardListBySearchParameters()";
            logExcpUIobj.ResourceName = "System_Settings_PayablesForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_PayablesForm : BindCreditCardListBySearchParameters] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion
    #endregion

    private void RelatedPayables()
    {
        int payablesType = Convert.ToInt32(ddlOpt_PayablesType.SelectedValue);
        int bank = (int)Enums.CommonEnum.Payabletype.BankTransfer;
        int Cheque = (int)Enums.CommonEnum.Payabletype.Cheque;
        int card = (int)Enums.CommonEnum.Payabletype.CreditCard;
        int cash = (int)Enums.CommonEnum.Payabletype.Cash;

        int ProcessType = Convert.ToByte(ddlOpt_ProcessType.SelectedValue);
        int Sales = (int)Enums.CommonEnum.ProcessType.Sales;
        int Purchase = (int)Enums.CommonEnum.ProcessType.Purchase;

        divBank.Visible = false;
        divCreditCard.Visible = false;
        divChequeNumber.Visible = false;

        divPayment.Visible = false;
        divReceipt.Visible = false;

        if (payablesType == bank)
        {
            if (ProcessType == Sales)
            {
                divPayment.Visible = false;
                divReceipt.Visible = true;

                divBank.Visible = true;
                divCreditCard.Visible = false;
                divChequeNumber.Visible = false;
            }
            else if (ProcessType == Purchase)
            {
                divReceipt.Visible = false;
                divPayment.Visible = true;

                divBank.Visible = true;
                divCreditCard.Visible = false;
                divChequeNumber.Visible = false;
            }
        }
        else if (payablesType == Cheque)
        {
            if (ProcessType == Sales)
            {
                divPayment.Visible = false;
                divReceipt.Visible = true;

                divBank.Visible = false;
                divCreditCard.Visible = false;
                divChequeNumber.Visible = true;
            }
            else if (ProcessType == Purchase)
            {
                divReceipt.Visible = false;
                divPayment.Visible = true;

                divBank.Visible = false;
                divCreditCard.Visible = false;
                divChequeNumber.Visible = true;
            }

        }
        else if (payablesType == card)
        {
            if (ProcessType == Sales)
            {
                divPayment.Visible = false;
                divReceipt.Visible = true;

                divBank.Visible = false;
                divCreditCard.Visible = true;
                divChequeNumber.Visible = false;
            }
            else if (ProcessType == Purchase)
            {
                divReceipt.Visible = false;
                divPayment.Visible = true;

                divBank.Visible = false;
                divCreditCard.Visible = true;
                divChequeNumber.Visible = false;
            }

        }
        else if (payablesType == cash)
        {
            if (ProcessType == Sales)
            {
                divPayment.Visible = false;
                divReceipt.Visible = true;
            }
            else if (ProcessType == Purchase)
            {
                divReceipt.Visible = false;
                divPayment.Visible = true;


            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Please select other option');", true);
        }

    }
    #endregion Methods

}
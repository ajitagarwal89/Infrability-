using Finware;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Finance_Bank_Accounting_Payment_To_Suppliers_DownPaymentToSupplierDistributionForm : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    DownPaymentToSupplierListBAL downPaymentToSupplierListBAL = new DownPaymentToSupplierListBAL();

    DownPaymentToSupplierDistributionFormBAL downPaymentToSupplierDistributionFormBAL = new DownPaymentToSupplierDistributionFormBAL();
    DownPaymentToSupplierDistributionFormUI downPaymentToSupplierDistributionFormUI = new DownPaymentToSupplierDistributionFormUI();
    #endregion Data Members


    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        DownPaymentToSupplierDistributionFormUI downPaymentToSupplierDistributionFormUI = new DownPaymentToSupplierDistributionFormUI();
        if (!Page.IsPostBack)
        {

            if (Request.QueryString["DownPaymentToSupplierId"] != null)
            {
                downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierId = Request.QueryString["DownPaymentToSupplierId"];
                BindGetDownPaymentToSupplierDistribution_SelectByDownPaymentToSupplierId(downPaymentToSupplierDistributionFormUI);
                BindTypeDropDownList();
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
           
            }
            else if (Request.QueryString["DownPaymentToSupplierDistributionId"] != null)
            {
                downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierDistributionId = Request.QueryString["DownPaymentToSupplierDistributionId"];

                BindTypeDropDownList();
                FillForm(downPaymentToSupplierDistributionFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update DownPaymentToSupplierDistribution";

            }
            else
            {
                BindTypeDropDownList();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New DownPaymentToSupplierDistribution";
            }
        }
    }

    

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            downPaymentToSupplierDistributionFormUI.CreatedBy = SessionContext.UserGuid;
            downPaymentToSupplierDistributionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierId = txtDownPaymentToSupplierGuid.Text.Trim();
            downPaymentToSupplierDistributionFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text.Trim();
            int type = Convert.ToInt32(ddlOptionType.SelectedValue);
            downPaymentToSupplierDistributionFormUI.opt_Type = int.Parse(ddlOptionType.SelectedValue);
            if (type ==2)
            {
                downPaymentToSupplierDistributionFormUI.Debit = Convert.ToDecimal(txtDebit.Text == "" ? "0.00" : txtDebit.Text);
                downPaymentToSupplierDistributionFormUI.OriginatingDebit = Convert.ToDecimal(txtOriginatingDebit.Text == "" ? "0.00" : txtOriginatingDebit.Text);
            }
            else
            {
                downPaymentToSupplierDistributionFormUI.Debit = 0;
                downPaymentToSupplierDistributionFormUI.OriginatingDebit = 0;
            }

            if (type == 1)
            {
                downPaymentToSupplierDistributionFormUI.Credit = Convert.ToDecimal(txtCredit.Text == "" ? "0.00" : txtCredit.Text);
                downPaymentToSupplierDistributionFormUI.OriginatingCredit = Convert.ToDecimal(txtOriginatingCredit.Text == "" ? "0.00" : txtOriginatingCredit.Text);
            }
            else
            {
                downPaymentToSupplierDistributionFormUI.Credit = 0;
                downPaymentToSupplierDistributionFormUI.OriginatingCredit = 0;
            }
            downPaymentToSupplierDistributionFormUI.Description = txtDescription.Text;
            downPaymentToSupplierDistributionFormUI.DistributionReference = txtDistributionReference.Text.Trim();
            downPaymentToSupplierDistributionFormUI.CompanyId = "00000000-0000-0000-0000-000000000002";
            downPaymentToSupplierDistributionFormUI.CorrespondenceCompanyId = "00000000-0000-0000-0000-000000000001";

            if (downPaymentToSupplierDistributionFormBAL.AddDownPaymentToSupplierDistribution(downPaymentToSupplierDistributionFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Suppliers_DownPaymentToSupplierDistributionForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_DownPaymentToSupplierDistributionForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            downPaymentToSupplierDistributionFormUI.ModifiedBy = SessionContext.UserGuid;
            downPaymentToSupplierDistributionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierDistributionId = Request.QueryString["DownPaymentToSupplierDistributionId"];
            downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierId = txtDownPaymentToSupplierGuid.Text.Trim();
            downPaymentToSupplierDistributionFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text.Trim();
            downPaymentToSupplierDistributionFormUI.opt_Type = int.Parse(ddlOptionType.SelectedValue);
            int type = Convert.ToInt32(ddlOptionType.SelectedValue);
            downPaymentToSupplierDistributionFormUI.opt_Type = int.Parse(ddlOptionType.SelectedValue);
            if (type == 2)
            {
                downPaymentToSupplierDistributionFormUI.Debit = Convert.ToDecimal(txtDebit.Text == "" ? "0.00" : txtDebit.Text);
                downPaymentToSupplierDistributionFormUI.OriginatingDebit = Convert.ToDecimal(txtOriginatingDebit.Text == "" ? "0.00" : txtOriginatingDebit.Text);
            }
            else
            {
                downPaymentToSupplierDistributionFormUI.Debit = 0;
                downPaymentToSupplierDistributionFormUI.OriginatingDebit = 0;
            }

            if (type == 1)
            {
                downPaymentToSupplierDistributionFormUI.Credit = Convert.ToDecimal(txtCredit.Text == "" ? "0.00" : txtCredit.Text);
                downPaymentToSupplierDistributionFormUI.OriginatingCredit = Convert.ToDecimal(txtOriginatingCredit.Text == "" ? "0.00" : txtOriginatingCredit.Text);
            }
            else
            {
                downPaymentToSupplierDistributionFormUI.Credit = 0;
                downPaymentToSupplierDistributionFormUI.OriginatingCredit = 0;
            }
            downPaymentToSupplierDistributionFormUI.Description = txtDescription.Text;
            downPaymentToSupplierDistributionFormUI.DistributionReference = txtDistributionReference.Text.Trim();
            downPaymentToSupplierDistributionFormUI.CompanyId = "00000000-0000-0000-0000-000000000001";
            downPaymentToSupplierDistributionFormUI.CorrespondenceCompanyId = "00000000-0000-0000-0000-000000000001";
            if (downPaymentToSupplierDistributionFormBAL.UpdateDownPaymentToSupplierDistribution(downPaymentToSupplierDistributionFormUI) == 1)
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
            logExcpUIobj.RecordId = downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionForm : btnUpdate_Click] An error occured in the processing of Record Id : " + downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierDistributionId + ".  Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierDistributionId = Request.QueryString["DownPaymentFromCustomerDistributionId"];

            if (downPaymentToSupplierDistributionFormBAL.DeleteDownPaymentToSupplierDistribution(downPaymentToSupplierDistributionFormUI) == 1)
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
            logExcpUIobj.RecordId = downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionForm : btnDelete_Click] An error occured in the processing of Record Id : " + downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierDistributionId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Finance/Bank_Accounting/Down_Payment_Suppliers/DownPaymentToSupplierDistributionList.aspx");
    }

    #region DownPaymentToSupplier Search
    protected void btnDownPaymentToSupplierSearch_Click(object sender, EventArgs e)
    {
        btnHtmlDownPaymentToSupplierSearch.Visible = false;
        btnHtmlDownPaymentToSupplierClose.Visible = true;
        SearchDownPaymentToSupplierList();
    }

    protected void btnClearDownPaymentToSupplierSearch_Click(object sender, EventArgs e)
    {
        BindDownPaymentToSupplierSearchList();
        gvDownPaymentToSupplierSearch.Visible = true;
        btnHtmlDownPaymentToSupplierSearch.Visible = true;
        btnHtmlDownPaymentToSupplierClose.Visible = false;
        txtDownPaymentToSupplierSearch.Text = "";
        txtDownPaymentToSupplierSearch.Focus();
    }
    protected void btnDownPaymentToSupplierRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindDownPaymentToSupplierSearchList();
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
        protected void txtDownPaymentToSupplier_TextChanged(object sender, EventArgs e)
    {
        downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierId = txtDownPaymentToSupplierGuid.Text;
        BindGetDownPaymentToSupplierDistribution_SelectByDownPaymentToSupplierId(downPaymentToSupplierDistributionFormUI);

    }
    #endregion Events

    #region Methods
    private void FillForm(DownPaymentToSupplierDistributionFormUI downPaymentToSupplierDistributionFormUI)
    {
        try
        {
            DataTable dtb = downPaymentToSupplierDistributionFormBAL.GetDownPaymentToSupplierDistributionListById(downPaymentToSupplierDistributionFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtDownPaymentToSupplier.Text = dtb.Rows[0]["tbl_Supplier"].ToString();
                txtDownPaymentToSupplierGuid.Text = dtb.Rows[0]["tbl_DownPaymentToSupplierId"].ToString();
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
            logExcpUIobj.RecordId = downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_DownPaymentToSupplierDistributionForm : FillForm] An error occured in the processing of Record Id : " + downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierDistributionId + ". Details : [" + exp.ToString() + "]");
        }
    }

    private void BindTypeDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_DownPaymentFromCustomerApply";
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

    private void BindGetDownPaymentToSupplierDistribution_SelectByDownPaymentToSupplierId(DownPaymentToSupplierDistributionFormUI downPaymentToSupplierDistributionFormUI)
    {
        downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierId = Request.QueryString["DownPaymentToSupplierId"];
        DataTable dtb = downPaymentToSupplierDistributionFormBAL.GetDownPaymentToSupplierDistribution_SelectByDownPaymentToSupplierId(downPaymentToSupplierDistributionFormUI);
        {
            if (dtb.Rows.Count > 0)
            {
                txtDownPaymentToSupplier.Text = dtb.Rows[0]["tbl_Supplier"].ToString();
                txtDownPaymentToSupplierGuid.Text =dtb.Rows[0]["tbl_DownPaymentToSupplierId"].ToString();
                txtSupplierCode.Text = dtb.Rows[0]["SupplierCode"].ToString();
                txtPaymentToSupplier.Text= dtb.Rows[0]["tbl_Supplier"].ToString();
                txtPaymentNumber.Text = dtb.Rows[0]["tbl_DownPaymentToSupplier"].ToString();
                txtDocumentNumber.Text = dtb.Rows[0]["DocumentNumber"].ToString();
                txtDocumentType.Text = dtb.Rows[0]["DocumentType"].ToString();
                txtCurrencyName.Text = dtb.Rows[0]["CurrencyName"].ToString();
                txtfunctionalAmount.Text = dtb.Rows[0]["Total"].ToString();
                txtOriginatingAmount.Text = dtb.Rows[0]["Total"].ToString();
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

    #region DownPaymentToSupplier Search
    private void SearchDownPaymentToSupplierList()
    {

        try
        {
            DownPaymentToSupplierListUI DownPaymentToSupplierListUI = new DownPaymentToSupplierListUI();
            DownPaymentToSupplierListUI.Search = txtDownPaymentToSupplierSearch.Text;


            DataTable dtb = downPaymentToSupplierListBAL.GetDownPaymentToSupplierListBySearchParameters(DownPaymentToSupplierListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvDownPaymentToSupplierSearch.DataSource = dtb;
                gvDownPaymentToSupplierSearch.DataBind();
                divDownPaymentToSupplierSearchError.Visible = false;
            }
            else
            {
                divDownPaymentToSupplierSearchError.Visible = true;
                lblDownPaymentToSupplierSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvDownPaymentToSupplierSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchDownPaymentToSupplierList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm : SearchDownPaymentToSupplierList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindDownPaymentToSupplierSearchList()
    {
        try
        {
            DataTable dtb = downPaymentToSupplierListBAL.GetDownPaymentToSupplierList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvDownPaymentToSupplierSearch.DataSource = dtb;
                gvDownPaymentToSupplierSearch.DataBind();
                divError.Visible = false;
                gvDownPaymentToSupplierSearch.Visible = true;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvDownPaymentToSupplierSearch.Visible = false;
            }

            txtDownPaymentToSupplierSearch.Text = "";
            txtDownPaymentToSupplierSearch.Focus();
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindDownPaymentToSupplierSearchList()";
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
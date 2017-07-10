using Finware;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Finance_Bank_Accounting_Payment_To_Supplier_PaymentToSupplierDistributionForm : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    PaymentToSupplierListBAL PaymentToSupplierListBAL = new PaymentToSupplierListBAL();
    PaymentToSupplierListUI paymentToSupplierListUI = new PaymentToSupplierListUI();
    PaymentToSupplierDistributionFormBAL PaymentToSupplierDistributionFormBAL = new PaymentToSupplierDistributionFormBAL();
    PaymentToSupplierDistributionFormUI PaymentToSupplierDistributionFormUI = new PaymentToSupplierDistributionFormUI();


    #endregion Data Members

    #region Event
    protected void Page_Load(object sender, EventArgs e)
    {
        PaymentToSupplierDistributionFormUI PaymentToSupplierDistributionFormUI = new PaymentToSupplierDistributionFormUI();
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["PaymentToSupplierId"] != null)
            {
                PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierId = Request.QueryString["PaymentToSupplierId"];
                BindGetPaymentToSupplierDistribution_SelectByPaymentToSupplierId(PaymentToSupplierDistributionFormUI);
                BindTypeDropDownList();

                btnUpdate.Visible = false;
                btnDelete.Visible = false;

            }

            else if (Request.QueryString["PaymentToSupplierDistributionId"] != null)
            {

                PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierDistributionId = Request.QueryString["PaymentToSupplierDistributionId"];
                BindTypeDropDownList();
                FillForm(PaymentToSupplierDistributionFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                divSupllierSpecification.Visible = false;
                lblHeading.Text = "Update Payment To Supplier Distribution";


            }
            else
            {

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New  Payment To Supplie Distribution";




            }


        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            PaymentToSupplierDistributionFormUI.CreatedBy = SessionContext.UserGuid;
            PaymentToSupplierDistributionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierId = txtPaymentToSupplierGuid.Text.Trim();
            PaymentToSupplierDistributionFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text.Trim();
            int type = Convert.ToInt32(ddlOptionType.SelectedValue);
            PaymentToSupplierDistributionFormUI.opt_Type = int.Parse(ddlOptionType.SelectedValue);

            if (type == 2)
            {
                PaymentToSupplierDistributionFormUI.Debit = Convert.ToDecimal(txtDebit.Text);
                PaymentToSupplierDistributionFormUI.OriginatingDebit = Convert.ToDecimal(txtOriginatingDebit.Text);
            }
            else
            {
                PaymentToSupplierDistributionFormUI.Debit = 0;
                PaymentToSupplierDistributionFormUI.OriginatingDebit = 0;
            }

            if (type == 1)
            {
                PaymentToSupplierDistributionFormUI.Credit = Convert.ToDecimal(txtCredit.Text);
                PaymentToSupplierDistributionFormUI.OriginatingCredit = Convert.ToDecimal(txtOriginatingCredit.Text);
            }
            else
            {
                PaymentToSupplierDistributionFormUI.Credit = 0;
                PaymentToSupplierDistributionFormUI.OriginatingCredit = 0;
            }
            PaymentToSupplierDistributionFormUI.Description = txtDescription.Text;
            PaymentToSupplierDistributionFormUI.DistributionReference = txtDistributionReference.Text.Trim();
            PaymentToSupplierDistributionFormUI.CompanyId = "00000000-0000-0000-0000-000000000002";
            PaymentToSupplierDistributionFormUI.CorrespondenceCompanyId = "00000000-0000-0000-0000-000000000001";

            if (PaymentToSupplierDistributionFormBAL.AddPaymentToSupplierDistribution(PaymentToSupplierDistributionFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Supplier_PaymentToSupplierDistributionForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Supplier_PaymentToSupplierDistributionForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            PaymentToSupplierDistributionFormUI.ModifiedBy = SessionContext.UserGuid;
            PaymentToSupplierDistributionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierDistributionId = Request.QueryString["PaymentToSupplierDistributionId"];
            PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierId = txtPaymentToSupplierGuid.Text.Trim();
            PaymentToSupplierDistributionFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text.Trim();
            PaymentToSupplierDistributionFormUI.opt_Type = int.Parse(ddlOptionType.SelectedValue);
            int type = Convert.ToInt32(ddlOptionType.SelectedValue);
            PaymentToSupplierDistributionFormUI.opt_Type = int.Parse(ddlOptionType.SelectedValue);
            if (type == 1)
            {
                PaymentToSupplierDistributionFormUI.Debit = Convert.ToDecimal(txtDebit.Text == "" ? "0.00" : txtDebit.Text);
                PaymentToSupplierDistributionFormUI.OriginatingDebit = Convert.ToDecimal(txtOriginatingDebit.Text == "" ? "0.00" : txtOriginatingDebit.Text);
            }
            else
            {
                PaymentToSupplierDistributionFormUI.Debit = 0;
                PaymentToSupplierDistributionFormUI.OriginatingDebit = 0;
            }

            if (type == 2)
            {
                PaymentToSupplierDistributionFormUI.Credit = Convert.ToDecimal(txtCredit.Text == "" ? "0.00" : txtCredit.Text);
                PaymentToSupplierDistributionFormUI.OriginatingCredit = Convert.ToDecimal(txtOriginatingCredit.Text == "" ? "0.00" : txtOriginatingCredit.Text);
            }
            else
            {
                PaymentToSupplierDistributionFormUI.Credit = 0;
                PaymentToSupplierDistributionFormUI.OriginatingCredit = 0;
            }
            PaymentToSupplierDistributionFormUI.Description = txtDescription.Text;
            PaymentToSupplierDistributionFormUI.DistributionReference = txtDistributionReference.Text.Trim();
            PaymentToSupplierDistributionFormUI.CompanyId = "00000000-0000-0000-0000-000000000001";
            PaymentToSupplierDistributionFormUI.CorrespondenceCompanyId = "00000000-0000-0000-0000-000000000001";
            if (PaymentToSupplierDistributionFormBAL.UpdatePaymentToSupplierDistribution(PaymentToSupplierDistributionFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Supplier_PaymentToSupplierDistributionForm.CS";
            logExcpUIobj.RecordId = PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Supplier_PaymentToSupplierDistributionForm : btnUpdate_Click] An error occured in the processing of Record Id : " + PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierDistributionId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierDistributionId = Request.QueryString["PaymentToSupplierDistributionId"];

            if (PaymentToSupplierDistributionFormBAL.DeletePaymentToSupplierDistribution(PaymentToSupplierDistributionFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Supplier_PaymentToSupplierDistributionForm.CS";
            logExcpUIobj.RecordId = PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Supplier_PaymentToSupplierDistributionForm : btnDelete_Click] An error occured in the processing of Record Id : " + PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierDistributionId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaymentToSupplierDistributionList.aspx");
    }

    #region PaymentToSupplier Search
    protected void btnPaymentToSupplierSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPaymentToSupplierSearch.Visible = false;
        btnHtmlPaymentToSupplierClose.Visible = true;
        SearchPaymentToSupplierList();
    }

    protected void btnClearPaymentToSupplierSearch_Click(object sender, EventArgs e)
    {
        BindPaymentToSupplierSearchList();
        gvPaymentToSupplierSearch.Visible = true;
        btnHtmlPaymentToSupplierSearch.Visible = true;
        btnHtmlPaymentToSupplierClose.Visible = false;
        txtPaymentToSupplierSearch.Text = "";
        txtPaymentToSupplierSearch.Focus();
    }
    protected void btnPaymentToSupplierRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPaymentToSupplierSearchList();
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

    protected void txtPaymentToSupplier_TextChanged(object sender, EventArgs e)
    {
        PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierId = txtPaymentToSupplierGuid.Text;
        BindGetPaymentToSupplierDistribution_SelectByPaymentToSupplierId(PaymentToSupplierDistributionFormUI);


    }

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
    #endregion Event end

    #region Methods
    private void FillForm(PaymentToSupplierDistributionFormUI PaymentToSupplierDistributionFormUI)
    {
        try
        {
            DataTable dtb = PaymentToSupplierDistributionFormBAL.GetPaymentToSupplierDistributionListById(PaymentToSupplierDistributionFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtPaymentToSupplier.Text = dtb.Rows[0]["tbl_Supplier"].ToString();
                txtPaymentToSupplierGuid.Text = dtb.Rows[0]["tbl_PaymentToSupplierId"].ToString();
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Payment_DownPaymentFromCustomerDistributionForm.CS";
            logExcpUIobj.RecordId = PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSupplierDistributionForm : FillForm] An error occured in the processing of Record Id : " + PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierDistributionId + ". Details : [" + exp.ToString() + "]");
        }
    }

    public void BindGetPaymentToSupplierDistribution_SelectByPaymentToSupplierId(PaymentToSupplierDistributionFormUI PaymentToSupplierDistributionFormU)
    {
        PaymentToSupplierDistributionFormU.Tbl_PaymentToSupplierId = Request.QueryString["PaymentToSupplierId"];
        DataTable dtb = PaymentToSupplierDistributionFormBAL.GetPaymentToSupplierDistribution_SelectByDownPaymentToSupplierId(PaymentToSupplierDistributionFormU);
        {
            if (dtb.Rows.Count > 0)
            {
                txtPaymentToSupplier.Text = dtb.Rows[0]["tbl_Supplier"].ToString();
                txtPaymentToSupplierGuid.Text = dtb.Rows[0]["tbl_PaymentToSupplierId"].ToString();
                txtGLAccountID.Text = dtb.Rows[0]["tbl_GLAccount"].ToString();
                txtSupplier.Text = dtb.Rows[0]["tbl_SupplierId"].ToString();
                txtSupplier.Text = dtb.Rows[0]["tbl_Supplier"].ToString();
                txtPaymentNumber.Text = dtb.Rows[0]["tbl_PaymentToSupplier"].ToString();
                txtOriginatingAmount.Text = dtb.Rows[0]["OriginatingCredit"].ToString();
                txtfunctionalAmount.Text = dtb.Rows[0]["Credit"].ToString();
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

    private void BindTypeDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_PaymentToSupplierDistribution";
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

    #region PaymentToSupplier Search
    private void SearchPaymentToSupplierList()
    {

        try
        {
            PaymentToSupplierListUI paymentToSupplierListUI = new PaymentToSupplierListUI();
            paymentToSupplierListUI.Search = txtPaymentToSupplierSearch.Text;


            DataTable dtb = PaymentToSupplierListBAL.GetPaymentToSupplierListBySearchParameters(paymentToSupplierListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPaymentToSupplierSearch.DataSource = dtb;
                gvPaymentToSupplierSearch.DataBind();
                divPaymentToSupplierSearchError.Visible = false;
            }
            else
            {
                divPaymentToSupplierSearchError.Visible = true;
                lblPaymentToSupplierSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPaymentToSupplierSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchPaymentToSupplierList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm : SearchDownPaymentToSupplierList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindPaymentToSupplierSearchList()
    {
        try
        {
            DataTable dtb = PaymentToSupplierListBAL.GetPaymentToSupplierList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPaymentToSupplierSearch.DataSource = dtb;
                gvPaymentToSupplierSearch.DataBind();
                divError.Visible = false;
                gvPaymentToSupplierSearch.Visible = true;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPaymentToSupplierSearch.Visible = false;
            }

            txtPaymentToSupplierSearch.Text = "";
            txtPaymentToSupplierSearch.Focus();
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPaymentToSupplierSearchList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Supplier_PaymentToSupplierDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Supplier_PaymentToSupplierDistributionForm : BindDownPaymentToSupplierSearchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Supplier_PaymentToSupplierDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Supplier_PaymentToSupplierDistributionForm : BindGLAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Payment_To_Supplier_PaymentToSupplierDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Payment_To_Supplier_PaymentToSupplierDistributionForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }


    }
    #endregion GLAccount Search

    #endregion End Method




}
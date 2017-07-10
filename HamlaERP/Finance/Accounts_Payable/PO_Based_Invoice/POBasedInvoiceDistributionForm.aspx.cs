using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDistributionForm : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    POBasedInvoiceDistributionFormBAL pOBasedInvoiceDistributionFormBAL = new POBasedInvoiceDistributionFormBAL();
    POBasedInvoiceDistributionFormUI pOBasedInvoiceDistributionFormUI = new POBasedInvoiceDistributionFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    POBasedInvoiceListBAL pOBasedInvoiceListBAL = new POBasedInvoiceListBAL();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    #endregion Data Members
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        POBasedInvoiceDistributionFormUI pOBasedInvoiceDistributionFormUI = new POBasedInvoiceDistributionFormUI();

        if (!Page.IsPostBack)
        {

            if (Request.QueryString["POBasedInvoiceDistributionId"] != null)
            {
                pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId = Request.QueryString["POBasedInvoiceDistributionId"];
                BindGLAccountTypeDropDown();
                FillForm(pOBasedInvoiceDistributionFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update PO Based Invoice Distribution";
            }
            else
            {
                BindGLAccountTypeDropDown();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New PO Based Invoice Distribution";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            pOBasedInvoiceDistributionFormUI.CreatedBy = SessionContext.UserGuid;
            pOBasedInvoiceDistributionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceId = txtPOBasedInvoiceGuid.Text;
            pOBasedInvoiceDistributionFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text;
            pOBasedInvoiceDistributionFormUI.Description = txtDescription.Text;
            pOBasedInvoiceDistributionFormUI.opt_GLAccountType = int.Parse(ddlopt_GLAccountType.SelectedValue);
            pOBasedInvoiceDistributionFormUI.DistributionReference = txtDistributionReference.Text;
            pOBasedInvoiceDistributionFormUI.Debit = Decimal.Parse(txtDebit.Text);
            pOBasedInvoiceDistributionFormUI.Credit = Decimal.Parse(txtCredit.Text);
            pOBasedInvoiceDistributionFormUI.OriginatingDebit = Decimal.Parse(txtOriginatingDebit.Text);
            pOBasedInvoiceDistributionFormUI.OriginatingCredit = Decimal.Parse(txtOriginatingCredit.Text);
            pOBasedInvoiceDistributionFormUI.ExchangeRate = Decimal.Parse(txtExchangeRate.Text);

            if (pOBasedInvoiceDistributionFormBAL.AddPOBasedInvoiceDistribution(pOBasedInvoiceDistributionFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDistributionForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDistributionForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            pOBasedInvoiceDistributionFormUI.ModifiedBy = SessionContext.UserGuid;
            pOBasedInvoiceDistributionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId = Request.QueryString["POBasedInvoiceDistributionId"];
            pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceId = txtPOBasedInvoiceGuid.Text;
            pOBasedInvoiceDistributionFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text;
            pOBasedInvoiceDistributionFormUI.Description = txtDescription.Text;
            pOBasedInvoiceDistributionFormUI.opt_GLAccountType = int.Parse(ddlopt_GLAccountType.SelectedValue);
            pOBasedInvoiceDistributionFormUI.DistributionReference = txtDistributionReference.Text;
            pOBasedInvoiceDistributionFormUI.Debit = Decimal.Parse(txtDebit.Text);
            pOBasedInvoiceDistributionFormUI.Credit = Decimal.Parse(txtCredit.Text);
            pOBasedInvoiceDistributionFormUI.OriginatingDebit = Decimal.Parse(txtOriginatingDebit.Text);
            pOBasedInvoiceDistributionFormUI.OriginatingCredit = Decimal.Parse(txtOriginatingCredit.Text);
            pOBasedInvoiceDistributionFormUI.ExchangeRate = Decimal.Parse(txtExchangeRate.Text);

            if (pOBasedInvoiceDistributionFormBAL.UpdatePOBasedInvoiceDistribution(pOBasedInvoiceDistributionFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDistributionForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDistributionForm : btnUpdate_Click] An error occured in the processing of Record Id : " + pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId = Request.QueryString["POBasedInvoiceDistributionId"];

            if (pOBasedInvoiceDistributionFormBAL.DeletePOBasedInvoiceDistribution(pOBasedInvoiceDistributionFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDistributionForm.CS";
            logExcpUIobj.RecordId = pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDistributionForm : btnDelete_Click] An error occured in the processing of Record Id : " + pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("POBasedInvoiceDistributionList.aspx");
    }

    #region GLAccount Search
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
    #endregion  GLAccount Search
   
    #region POBasedInvoice Search
    protected void btnPOBasedInvoiceSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPOBasedInvoiceSearch.Visible = false;
        btnHtmlPOBasedInvoiceClose.Visible = true;
        SearchPOBasedInvoiceList();
    }
    protected void btnClearPOBasedInvoiceSearch_Click(object sender, EventArgs e)
    {
        BindPOBasedInvoiceList();
        gvPOBasedInvoiceSearch.Visible = true;
        btnHtmlPOBasedInvoiceSearch.Visible = true;
        btnHtmlPOBasedInvoiceClose.Visible = false;
        txtPOBasedInvoiceSearch.Text = "";
        txtPOBasedInvoiceSearch.Focus();
    }
    protected void btnPOBasedInvoiceRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPOBasedInvoiceList();
    }
    #endregion POBasedInvoice Search
    
    #endregion Events

    #region Methods 

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
                gvGLAccountSearch.Visible = true;
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDistributionForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDistributionForm : BindGLAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion

    #region POBasedInvoice Search
    private void SearchPOBasedInvoiceList()
    {
        try
        {
            POBasedInvoiceListUI pOBasedInvoiceListUI = new POBasedInvoiceListUI();
            pOBasedInvoiceListUI.Search = txtPOBasedInvoiceSearch.Text;
            DataTable dtb = pOBasedInvoiceListBAL.GetPOBasedInvoiceListBySearchParameters(pOBasedInvoiceListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPOBasedInvoiceSearch.DataSource = dtb;
                gvPOBasedInvoiceSearch.DataBind();
                divPOBasedInvoiceSearchError.Visible = false;
                gvPOBasedInvoiceSearch.Visible = true;
            }
            else
            {
                divPOBasedInvoiceSearchError.Visible = true;
                lblPOBasedInvoiceSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPOBasedInvoiceSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchPOBasedInvoiceList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDistributionForm : SearchPOBasedInvoiceList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindPOBasedInvoiceList()
    {
        try
        {
            DataTable dtb = pOBasedInvoiceListBAL.GetPOBasedInvoiceList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPOBasedInvoiceSearch.DataSource = dtb;
                gvPOBasedInvoiceSearch.DataBind();
                divPOBasedInvoiceSearchError.Visible = false;
            }
            else
            {
                divPOBasedInvoiceSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPOBasedInvoiceSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPOBasedInvoiceList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDistributionForm : BindPOBasedInvoiceList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  POBasedInvoice search
    private void FillForm(POBasedInvoiceDistributionFormUI pOBasedInvoiceDistributionFormUI)
    {
        try
        {
            DataTable dtb = pOBasedInvoiceDistributionFormBAL.GetPOBasedInvoiceDistributionListById(pOBasedInvoiceDistributionFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtGLAccountGuid.Text = dtb.Rows[0]["tbl_GLAccountId"].ToString();
                txtGLAccount.Text = dtb.Rows[0]["tbl_GLAccount"].ToString();
                txtPOBasedInvoiceGuid.Text = dtb.Rows[0]["tbl_POBasedInvoiceId"].ToString();
                txtPOBasedInvoice.Text = dtb.Rows[0]["tbl_POBasedInvoice"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                ddlopt_GLAccountType.SelectedValue = dtb.Rows[0]["opt_GLAccountType"].ToString();
                txtDistributionReference.Text = dtb.Rows[0]["DistributionReference"].ToString();
                txtDebit.Text = dtb.Rows[0]["Debit"].ToString();
                txtCredit.Text = dtb.Rows[0]["Credit"].ToString();
                txtOriginatingCredit.Text = dtb.Rows[0]["OriginatingCredit"].ToString();
                txtOriginatingDebit.Text = dtb.Rows[0]["OriginatingDebit"].ToString();
                txtExchangeRate.Text = dtb.Rows[0]["ExchangeRate"].ToString();
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDistributionForm.CS";
            logExcpUIobj.RecordId = this.pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDistributionForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region Bind GlAccountType DropDown
    private void BindGLAccountTypeDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_POBasedInvoiceDistribution";
            optionSetListUI.OptionSetName = "opt_GLAccountType";

            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {
                ddlopt_GLAccountType.DataSource = dtb;
                ddlopt_GLAccountType.DataBind();
                ddlopt_GLAccountType.DataTextField = "OptionSetLable";
                ddlopt_GLAccountType.DataValueField = "OptionSetValue";
                ddlopt_GLAccountType.DataBind();

            }
            else
            {
                ddlopt_GLAccountType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "-1"));
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindGLAccountTypeDropDown()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDistributionForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDistributionForm : BindGLAccountTypeDropDown] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #endregion Bind GlAccountType DropDown
    #endregion Methods
}
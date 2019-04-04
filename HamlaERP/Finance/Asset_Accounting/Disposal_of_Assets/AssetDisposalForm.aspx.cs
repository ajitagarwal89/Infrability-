using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Assets_AssetDisposal_AssetDisposalForm : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    AssetDisposalFormBAL assetDisposalFormBAL = new AssetDisposalFormBAL();
    AssetDisposalFormUI assetDisposalFormUI = new AssetDisposalFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();

    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    AssetListBAL assetListBAL = new AssetListBAL();

    int invoiceTypeInvoice = 1;
    int invoiceTypeReturn = 2;
    int invoiceTypeCreditMemo = 3;
    int invoiceTypePayment = 4;


    #endregion Data Members

    #region Events
    protected  void Page_Load(object sender, EventArgs e)
    {
        AssetDisposalFormUI assetDisposalFormUI = new AssetDisposalFormUI();
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["AssetDisposalId"] != null)
            {
                assetDisposalFormUI.Tbl_AssetDisposalId = Request.QueryString["AssetDisposalId"];

                BindRetirementTypeDropDown();
                FillForm(assetDisposalFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Asset Disposal";
            }
            else
            {

                BindRetirementTypeDropDown();
                assetDisposalFormUI.InvoiceType = invoiceTypeInvoice;
                GetSerialNumber(assetDisposalFormUI);
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Asset Disposal";
            }
        }
    }    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            assetDisposalFormUI.CreatedBy = SessionContext.UserGuid;
            assetDisposalFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            assetDisposalFormUI.AssetDisposalCode = txtAssetDisposalCode.Text;
            assetDisposalFormUI.Tbl_AssetId = txtAssetGuid.Text;
            assetDisposalFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            assetDisposalFormUI.RetirementDate = DateTime.Parse(txtRetirementDate.Text);
            assetDisposalFormUI.opt_RetirementType = int.Parse(ddlOpt_RetirementType.SelectedValue);
            assetDisposalFormUI.RetirementEvent = txtRetirementEvent.Text;
            /*
             fields Parameter
             */

            if (assetDisposalFormBAL.AddAssetDisposal(assetDisposalFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Assets_AssetDisposal_AssetDisposalForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetDisposal_AssetDisposalForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            assetDisposalFormUI.ModifiedBy = SessionContext.UserGuid;
            assetDisposalFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            assetDisposalFormUI.Tbl_AssetDisposalId = Request.QueryString["AssetDisposalId"];
            assetDisposalFormUI.AssetDisposalCode = txtAssetDisposalCode.Text;
            assetDisposalFormUI.Tbl_AssetId = txtAssetGuid.Text;
            assetDisposalFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            assetDisposalFormUI.RetirementDate = DateTime.Parse(txtRetirementDate.Text);
            assetDisposalFormUI.opt_RetirementType = int.Parse(ddlOpt_RetirementType.SelectedValue);
            assetDisposalFormUI.RetirementEvent = txtRetirementEvent.Text;
            /*
               fields Parameter
               */

            if (assetDisposalFormBAL.UpdateAssetDisposal(assetDisposalFormUI) == 1)
            {
                divSuccess.Visible = true;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "Assets_AssetDisposal_AssetDisposalForm.CS";
            logExcpUIobj.RecordId = assetDisposalFormUI.Tbl_AssetDisposalId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetDisposal_AssetDisposalForm : btnUpdate_Click] An error occured in the processing of Record Id : " + assetDisposalFormUI.Tbl_AssetDisposalId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            assetDisposalFormUI.Tbl_AssetDisposalId = Request.QueryString["AssetDisposalId"];

            if (assetDisposalFormBAL.DeleteAssetDisposal(assetDisposalFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Assets_AssetDisposal_AssetDisposalForm.CS";
            logExcpUIobj.RecordId = assetDisposalFormUI.Tbl_AssetDisposalId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetDisposal_AssetDisposalForm : btnDelete_Click] An error occured in the processing of Record Id : " + assetDisposalFormUI.Tbl_AssetDisposalId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetDisposalList.aspx");
    }

    #region Currency Search
    protected void btnCurrencySearch_Click(object sender, EventArgs e)
    {
        btnHtmlCurrencySearch.Visible = false;
        btnHtmlCurrencyClose.Visible = true;
        SearchCurrencyList();
    }
    protected void btnClearCurrencySearch_Click(object sender, EventArgs e)
    {
        BindCurrencyList();
        gvCurrencySearch.Visible = true;
        btnHtmlCurrencySearch.Visible = true;
        btnHtmlCurrencyClose.Visible = false;
        txtCurrencySearch.Text = "";
        txtCurrencySearch.Focus();
    }
    protected void btnCurrencyRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindCurrencyList();
    }
    #endregion Currency Search

    #region Asset Search
    protected void btnAssetSearch_Click(object sender, EventArgs e)
    {
        btnHtmlAssetSearch.Visible = false;
        btnHtmlAssetClose.Visible = true;
        SearchAssetList();
    }
    protected void btnClearAssetSearch_Click(object sender, EventArgs e)
    {
        BindAssetList();
        gvAssetSearch.Visible = true;
        btnHtmlAssetSearch.Visible = true;
        btnHtmlAssetClose.Visible = false;
        txtAssetSearch.Text = "";
        txtAssetSearch.Focus();
    }
    protected void btnAssetRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindAssetList();
    }
    #endregion Asset Search

    #endregion Events

    #region Methods

    private void GetSerialNumber(AssetDisposalFormUI assetDisposalFormUI)
    {
        try
        {
            DataTable dtb = assetDisposalFormBAL.GetSerialNumber(assetDisposalFormUI);
            if (dtb.Rows.Count > 0)
            {
                txtAssetDisposalCode.Text = dtb.Rows[0][0].ToString();

            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotLoadData;
                divError.Visible = true;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetSerialNumber()";
            logExcpUIobj.ResourceName = "Assets_AssetDisposal_AssetDisposalForm.CS";
            logExcpUIobj.RecordId = assetDisposalFormUI.Tbl_AssetDisposalId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_AssetDisposal_AssetDisposalForm : GetSerialNumber] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void FillForm(AssetDisposalFormUI assetDisposalFormUI)
    {
        try
        {
            DataTable dtb = assetDisposalFormBAL.GetAssetDisposalListById(assetDisposalFormUI);

            if (dtb.Rows.Count > 0)
            {
             
                txtAssetDisposalCode.Text = dtb.Rows[0]["AssetDisposalCode"].ToString();
                txtAsset.Text = dtb.Rows[0]["tbl_Asset"].ToString();
                txtAssetGuid.Text = dtb.Rows[0]["tbl_AssetId"].ToString();
                txtCurrency.Text = dtb.Rows[0]["CurrencyName"].ToString();
                txtCurrencyGuid.Text = dtb.Rows[0]["tbl_CurrencyId"].ToString();
                txtRetirementDate.Text = dtb.Rows[0]["RetirementDate"].ToString();
                ddlOpt_RetirementType.Text = dtb.Rows[0]["RetirementType"].ToString();
                txtRetirementEvent.Text = dtb.Rows[0]["RetirementEvent"].ToString();
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
            logExcpUIobj.ResourceName = "Assets_AssetDisposal_AssetDisposalForm.CS";
            logExcpUIobj.RecordId = assetDisposalFormUI.Tbl_AssetDisposalId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetDisposal_AssetDisposalForm : FillForm] An error occured in the processing of Record Id : " + assetDisposalFormUI.Tbl_AssetDisposalId + ". Details : [" + exp.ToString() + "]");
        }
    }

    private void BindRetirementTypeDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_AssetDisposal";
            optionSetListUI.OptionSetName = "Opt_RetirementType";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {
                ddlOpt_RetirementType.DataSource = dtb;
                ddlOpt_RetirementType.DataBind();
                ddlOpt_RetirementType.DataTextField = "OptionSetLable";
                ddlOpt_RetirementType.DataValueField = "OptionSetValue";
                ddlOpt_RetirementType.DataBind();
            }
            else
            {
                ddlOpt_RetirementType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "Bindopt_StatusDropDownList()";
            logExcpUIobj.ResourceName = "Assets_AssetDisposal_AssetDisposalForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_AssetDisposal_AssetDisposalForm : Bindopt_StatusDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region Currency Search
    private void SearchCurrencyList()
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
            logExcpUIobj.MethodName = "SearchCurrencyList()";
            logExcpUIobj.ResourceName = "Assets_AssetDisposal_AssetDisposalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetDisposal_AssetDisposalForm : SearchCurrencyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCurrencySearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCurrencyList()";
            logExcpUIobj.ResourceName = "Assets_AssetDisposal_AssetDisposalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetDisposal_AssetDisposalForm : BindCurrencyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Currency Serach


    #region Asset Search
    private void SearchAssetList()
    {
        try
        {
            AssetListUI assetListUI = new AssetListUI();
            assetListUI.Search = txtAssetSearch.Text;
            DataTable dtb = assetListBAL.GetAssetListSearchParameters(assetListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAssetSearch.DataSource = dtb;
                gvAssetSearch.DataBind();
                divAssetSearchError.Visible = false;
            }
            else
            {
                divAssetSearchError.Visible = true;
                lblAssetSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAssetSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchAssetList()";
            logExcpUIobj.ResourceName = "Assets_AssetDisposal_AssetDisposalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetDisposal_AssetDisposalForm : SearchAssetList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindAssetList()
    {
        try
        {
            DataTable dtb = assetListBAL.GetAssetList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAssetSearch.DataSource = dtb;
                gvAssetSearch.DataBind();
                divAssetSearchError.Visible = false;
            }
            else
            {
                divAssetSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAssetSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindAssetList()";
            logExcpUIobj.ResourceName = "Assets_AssetDisposal_AssetDisposalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_AssetDisposal_AssetDisposalForm : BindAssetList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Asset search
    #endregion Methods
}
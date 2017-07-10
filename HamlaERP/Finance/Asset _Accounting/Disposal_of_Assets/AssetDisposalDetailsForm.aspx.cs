using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Asset__Accounting_Disposal_of_Assets_AssetDisposalDetailsForm : System.Web.UI.Page
{

    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    AssetDisposalDetailsFormBAL assetDisposalDetailsFormBAL = new AssetDisposalDetailsFormBAL();
    AssetDisposalDetailsFormUI assetDisposalDetailsFormUI = new AssetDisposalDetailsFormUI();
    AssetDisposalListBAL assetDisposalListBAL = new AssetDisposalListBAL();

    #endregion Data Members

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        AssetDisposalDetailsFormUI assetDisposalDetailsFormUI = new AssetDisposalDetailsFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["AssetDisposalDetailsId"] != null)
            {
                assetDisposalDetailsFormUI.Tbl_AssetDisposalDetailsId = Request.QueryString["AssetDisposalDetailsId"];
                FillForm(assetDisposalDetailsFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Asset Disposal Details";
            }
            else
            {
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Asset Disposal Details";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            assetDisposalDetailsFormUI.CreatedBy = SessionContext.UserGuid;
            assetDisposalDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            assetDisposalDetailsFormUI.Tbl_AssetDisposalId =txtAssetDisposalGuid.Text;
            assetDisposalDetailsFormUI.Quantity =Decimal.Parse(txtQuantity.Text);
            assetDisposalDetailsFormUI.Cost =Decimal.Parse(txtCost.Text);
            assetDisposalDetailsFormUI.Percent = Decimal.Parse(txtPercent.Text);
            assetDisposalDetailsFormUI.CashProceeds = Decimal.Parse(txtCashProceeds.Text);
            assetDisposalDetailsFormUI.NonCashProceeds = Decimal.Parse(txtNonCashProceeds.Text);
            assetDisposalDetailsFormUI.ExpensesOfSales = Decimal.Parse(txtExpensesOfSales.Text);
            assetDisposalDetailsFormUI.OriginatingAmount = Decimal.Parse(txtOriginatingAmount.Text);
            if (assetDisposalDetailsFormBAL.AddAssetDisposalDetails(assetDisposalDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Asset__Accounting_Disposal_of_Assets_AssetDisposalDetailsForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Asset__Accounting_Disposal_of_Assets_AssetDisposalDetailsForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            assetDisposalDetailsFormUI.ModifiedBy = SessionContext.UserGuid;
            assetDisposalDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            assetDisposalDetailsFormUI.Tbl_AssetDisposalDetailsId = Request.QueryString["AssetDisposalDetailsId"];
            assetDisposalDetailsFormUI.Tbl_AssetDisposalId = txtAssetDisposalGuid.Text;
            assetDisposalDetailsFormUI.Quantity = Decimal.Parse(txtQuantity.Text);
            assetDisposalDetailsFormUI.Cost = Decimal.Parse(txtCost.Text);
            assetDisposalDetailsFormUI.Percent = Decimal.Parse(txtPercent.Text);
            assetDisposalDetailsFormUI.CashProceeds = Decimal.Parse(txtCashProceeds.Text);
            assetDisposalDetailsFormUI.NonCashProceeds = Decimal.Parse(txtNonCashProceeds.Text);
            assetDisposalDetailsFormUI.ExpensesOfSales = Decimal.Parse(txtExpensesOfSales.Text);
            assetDisposalDetailsFormUI.OriginatingAmount = Decimal.Parse(txtOriginatingAmount.Text);
            if (assetDisposalDetailsFormBAL.UpdateAssetDisposalDetails(assetDisposalDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Asset__Accounting_Disposal_of_Assets_AssetDisposalDetailsForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Asset__Accounting_Disposal_of_Assets_AssetDisposalDetailsForm : btnUpdate_Click] An error occured in the processing of Record Id : " + assetDisposalDetailsFormUI.Tbl_AssetDisposalDetailsId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            assetDisposalDetailsFormUI.Tbl_AssetDisposalDetailsId = Request.QueryString["AssetDisposalDetailsId"];

            if (assetDisposalDetailsFormBAL.DeleteAssetDisposalDetails(assetDisposalDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Asset__Accounting_Disposal_of_Assets_AssetDisposalDetailsForm.CS";
            logExcpUIobj.RecordId = assetDisposalDetailsFormUI.Tbl_AssetDisposalDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Asset__Accounting_Disposal_of_Assets_AssetDisposalDetailsForm : btnDelete_Click] An error occured in the processing of Record Id : " + assetDisposalDetailsFormUI.Tbl_AssetDisposalDetailsId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetDisposalDetailsList.aspx");
    }

    #region AssetDisposal Search
    protected void btnAssetDisposalSearch_Click(object sender, EventArgs e)
    {
        btnHtmlAssetDisposalSearch.Visible = false;
        btnHtmlAssetDisposalClose.Visible = true;
        SearchAssetDisposalList();
    }
    protected void btnClearAssetDisposalSearch_Click(object sender, EventArgs e)
    {
        BindAssetDisposalList();
        gvAssetDisposalSearch.Visible = true;
        btnHtmlAssetDisposalSearch.Visible = true;
        btnHtmlAssetDisposalClose.Visible = false;
        txtAssetDisposalSearch.Text = "";
        txtAssetDisposalSearch.Focus();
    }
    protected void btnAssetDisposalRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindAssetDisposalList();
    }
    #endregion AssetDisposal Search


    #endregion Events

    #region Methods
    private void FillForm(AssetDisposalDetailsFormUI assetDisposalDetailsFormUI)
    {
        try
        {
            DataTable dtb = assetDisposalDetailsFormBAL.GetAssetDisposalDetailsListById(assetDisposalDetailsFormUI);

            if (dtb.Rows.Count > 0)
            {
              txtAssetDisposalGuid.Text = dtb.Rows[0]["tbl_AssetDisposalId"].ToString();
               txtAssetDisposal.Text = dtb.Rows[0]["tbl_AssetDisposal"].ToString();
              txtQuantity.Text = dtb.Rows[0]["Quantity"].ToString();
               txtCost.Text = dtb.Rows[0]["Cost"].ToString();
                txtPercent.Text = dtb.Rows[0]["Percent"].ToString();
               txtCashProceeds.Text = dtb.Rows[0]["CashProceeds"].ToString();
              txtNonCashProceeds.Text = dtb.Rows[0]["NonCashProceeds"].ToString();
               txtExpensesOfSales.Text = dtb.Rows[0]["ExpensesOfSales"].ToString();
               txtOriginatingAmount.Text = dtb.Rows[0]["OriginatingAmount"].ToString();
                
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "FillForm()";
            logExcpUIobj.ResourceName = "Finance_Asset__Accounting_Disposal_of_Assets_AssetDisposalDetailsForm.CS";
            logExcpUIobj.RecordId = this.assetDisposalDetailsFormUI.Tbl_AssetDisposalDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Asset__Accounting_Disposal_of_Assets_AssetDisposalDetailsForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region AssetDisposal Search
    private void SearchAssetDisposalList()
    {
        try
        {
            AssetDisposalListUI assetDisposalListUI = new AssetDisposalListUI();
            assetDisposalListUI.Search = txtAssetDisposalSearch.Text;
            DataTable dtb = assetDisposalListBAL.GetAssetDisposalListSearchParameters(assetDisposalListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAssetDisposalSearch.DataSource = dtb;
                gvAssetDisposalSearch.DataBind();
                divAssetDisposalSearchError.Visible = false;
                gvAssetDisposalSearch.Visible = true;
            }
            else
            {
                divAssetDisposalSearchError.Visible = true;
                lblAssetDisposalSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAssetDisposalSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchAssetDisposalList()";
            logExcpUIobj.ResourceName = "Finance_Asset__Accounting_Disposal_of_Assets_AssetDisposalDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Asset__Accounting_Disposal_of_Assets_AssetDisposalDetailsForm : SearchAssetDisposalList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindAssetDisposalList()
    {
        try
        {
            DataTable dtb = assetDisposalListBAL.GetAssetDisposalList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAssetDisposalSearch.DataSource = dtb;
                gvAssetDisposalSearch.DataBind();
                divAssetDisposalSearchError.Visible = false;
            }
            else
            {
                divAssetDisposalSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAssetDisposalSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindAssetDisposalList()";
            logExcpUIobj.ResourceName = "Finance_Asset__Accounting_Disposal_of_Assets_AssetDisposalDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Asset__Accounting_Disposal_of_Assets_AssetDisposalDetailsForm : BindAssetDisposalList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  AssetDisposal search


    #endregion Methods

}
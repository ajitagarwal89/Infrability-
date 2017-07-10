using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Asset_AssetBookForm : System.Web.UI.Page
{

    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    AssetBookFormBAL assetBookFormBAL = new AssetBookFormBAL();
    AssetBookFormUI assetBookFormUI = new AssetBookFormUI();
    AssetListBAL assetListBAL = new AssetListBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    #endregion Data Members

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        AssetBookFormUI assetBookFormUI = new AssetBookFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["AssetBookId"] != null)
            {
                assetBookFormUI.Tbl_AssetBookId = Request.QueryString["AssetBookId"];
                BindStatusDropDown();
                BindAveragingConventionDropDown();
                BindDepreciationMethodDropDown();
                FillForm(assetBookFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Asset Book";
            }
            else
            {
                BindStatusDropDown();
                BindAveragingConventionDropDown();
                BindDepreciationMethodDropDown();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Asset Book";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            assetBookFormUI.CreatedBy = SessionContext.UserGuid;
            assetBookFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            assetBookFormUI.Tbl_AssetId = txtAssetGuid.Text;
            assetBookFormUI.AssetBookCode = txtAssetBookCode.Text;
            assetBookFormUI.PlaceInServiceDate = DateTime.Parse(txtPlaceInServiceDate.Text);
            assetBookFormUI.DepreciatedDueDate = DateTime.Parse(txtDepreciatedDueDate.Text);
            assetBookFormUI.BeginYearCost =Decimal.Parse(txtBeginYearCost.Text);
            assetBookFormUI.CostBasis = Decimal.Parse(txtCostBasis.Text);
            assetBookFormUI.ScrapValue =Decimal.Parse(txtScrapValue.Text);
            assetBookFormUI.YearlyDepreciationRate =Decimal.Parse(txtYearlyDepreciationRate.Text);
            assetBookFormUI.CurrentDepreciation = Decimal.Parse(txtCurrentDepreciation.Text);
            assetBookFormUI.NetBookValue =Decimal.Parse(txtNetBookValue.Text);
            assetBookFormUI.opt_DepreciationMethod = int.Parse(ddlopt_DepreciationMethod.SelectedValue);
            assetBookFormUI.opt_AveragingConvention = int.Parse(ddlopt_AveragingConvention.SelectedValue);
            if (chkFullDepreciationFlag.Checked)
            {
                assetBookFormUI.FullDepreciationFlag = true;
            }
            else
            {
                assetBookFormUI.FullDepreciationFlag = false;
            }           
            assetBookFormUI.opt_Status = int.Parse(ddlopt_Status.SelectedValue);
            assetBookFormUI.OriginalLifeYear = int.Parse(txtOriginalLifeYear.Text);
            assetBookFormUI.OriginalLifeDay = int.Parse(txtOriginalLifeDay.Text);
            if (assetBookFormBAL.AddAssetBook(assetBookFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Asset_AssetBookForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Asset_AssetBookForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            assetBookFormUI.ModifiedBy = SessionContext.UserGuid;
            assetBookFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            assetBookFormUI.Tbl_AssetBookId = Request.QueryString["AssetBookId"];
            assetBookFormUI.Tbl_AssetId = txtAssetGuid.Text;
            assetBookFormUI.AssetBookCode = txtAssetBookCode.Text;
            assetBookFormUI.PlaceInServiceDate = DateTime.Parse(txtPlaceInServiceDate.Text);
            assetBookFormUI.DepreciatedDueDate = DateTime.Parse(txtDepreciatedDueDate.Text);
            assetBookFormUI.BeginYearCost = Decimal.Parse(txtBeginYearCost.Text);
            assetBookFormUI.CostBasis = Decimal.Parse(txtCostBasis.Text);
            assetBookFormUI.ScrapValue = Decimal.Parse(txtScrapValue.Text);
            assetBookFormUI.YearlyDepreciationRate = Decimal.Parse(txtYearlyDepreciationRate.Text);
            assetBookFormUI.CurrentDepreciation = Decimal.Parse(txtCurrentDepreciation.Text);
            assetBookFormUI.NetBookValue = Decimal.Parse(txtNetBookValue.Text);
            assetBookFormUI.opt_DepreciationMethod = int.Parse(ddlopt_DepreciationMethod.SelectedValue.ToString());
            assetBookFormUI.opt_AveragingConvention = int.Parse(ddlopt_AveragingConvention.SelectedValue.ToString());
            if (chkFullDepreciationFlag.Checked)
            {
                assetBookFormUI.FullDepreciationFlag = true;
            }
            else
            {
                assetBookFormUI.FullDepreciationFlag = false;
            }
            assetBookFormUI.opt_Status = int.Parse(ddlopt_Status.SelectedValue.ToString());
            assetBookFormUI.OriginalLifeYear = int.Parse(txtOriginalLifeYear.Text);
            assetBookFormUI.OriginalLifeDay = int.Parse(txtOriginalLifeDay.Text);
            if (assetBookFormBAL.UpdateAssetBook(assetBookFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Asset_AssetBookForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Asset_AssetBookForm : btnUpdate_Click] An error occured in the processing of Record Id : " + assetBookFormUI.Tbl_AssetBookId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            assetBookFormUI.Tbl_AssetBookId = Request.QueryString["AssetBookId"];

            if (assetBookFormBAL.DeleteAssetBook(assetBookFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Asset_AssetBookForm.CS";
            logExcpUIobj.RecordId = assetBookFormUI.Tbl_AssetBookId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Asset_AssetBookForm : btnDelete_Click] An error occured in the processing of Record Id : " + assetBookFormUI.Tbl_AssetBookId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetBookList.aspx");
    }

   
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
    private void FillForm(AssetBookFormUI assetBookFormUI)
    {
        try
        {
            DataTable dtb = assetBookFormBAL.GetAssetBookListById(assetBookFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtAssetGuid.Text = dtb.Rows[0]["tbl_AssetId"].ToString();
                txtAsset.Text = dtb.Rows[0]["tbl_Asset"].ToString();
                txtAssetBookCode.Text = dtb.Rows[0]["AssetBookCode"].ToString();
                txtPlaceInServiceDate.Text= dtb.Rows[0]["PlaceInServiceDate"].ToString();
                txtDepreciatedDueDate.Text = dtb.Rows[0]["DepreciatedDueDate"].ToString();
                txtBeginYearCost.Text = dtb.Rows[0]["BeginYearCost"].ToString();
                txtCostBasis.Text = dtb.Rows[0]["CostBasis"].ToString();
                txtScrapValue.Text = dtb.Rows[0]["ScrapValue"].ToString();
                txtYearlyDepreciationRate.Text = dtb.Rows[0]["YearlyDepreciationRate"].ToString();
                txtCurrentDepreciation.Text = dtb.Rows[0]["CurrentDepreciation"].ToString();
                txtNetBookValue.Text = dtb.Rows[0]["NetBookValue"].ToString();
                ddlopt_DepreciationMethod.SelectedValue = dtb.Rows[0]["opt_DepreciationMethod"].ToString();
                ddlopt_AveragingConvention.SelectedValue = dtb.Rows[0]["opt_AveragingConvention"].ToString();
                chkFullDepreciationFlag.Checked = Convert.ToBoolean(dtb.Rows[0]["FullDepreciationFlag"].ToString()); 
                ddlopt_Status.SelectedValue = dtb.Rows[0]["opt_Status"].ToString();
                txtOriginalLifeYear.Text= dtb.Rows[0]["OriginalLifeYear"].ToString();
                txtOriginalLifeDay.Text = dtb.Rows[0]["OriginalLifeDay"].ToString();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "FillForm()";
            logExcpUIobj.ResourceName = "Asset_AssetBookForm.CS";
            logExcpUIobj.RecordId = this.assetBookFormUI.Tbl_AssetBookId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Asset_AssetBookForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

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
                gvAssetSearch.Visible = true;
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
            logExcpUIobj.ResourceName = "Asset_AssetBookForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Asset_AssetBookForm : SearchAssetList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Asset_AssetBookForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Asset_AssetBookForm : BindAssetList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Asset search
    
    #region Bind Status DropDown
    private void BindStatusDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_AssetBook";
            optionSetListUI.OptionSetName = "opt_Status";

            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {
                ddlopt_Status.DataSource = dtb;
                ddlopt_Status.DataBind();
                ddlopt_Status.DataTextField = "OptionSetLable";
                ddlopt_Status.DataValueField = "OptionSetValue";
                ddlopt_Status.DataBind();

            }
            else
            {
                ddlopt_Status.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "-1"));
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindStatusDropDown()";
            logExcpUIobj.ResourceName = "Asset_AssetBookForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Asset_AssetBookForm : BindStatusDropDown] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #endregion Bind Status DropDown
    
    #region Bind AveragingConvention DropDown
    private void BindAveragingConventionDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_AssetBook";
            optionSetListUI.OptionSetName = "opt_AveragingConvention";

            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {
                ddlopt_AveragingConvention.DataSource = dtb;
                ddlopt_AveragingConvention.DataBind();
                ddlopt_AveragingConvention.DataTextField = "OptionSetLable";
                ddlopt_AveragingConvention.DataValueField = "OptionSetValue";
                ddlopt_AveragingConvention.DataBind();

            }
            else
            {
                ddlopt_AveragingConvention.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "-1"));
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindAveragingConventionDropDown()";
            logExcpUIobj.ResourceName = "Asset_AssetBookForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Asset_AssetBookForm : BindAveragingConventionDropDown] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #endregion Bind AveragingConvention DropDown

    #region Bind DepreciationMethod DropDown
    private void BindDepreciationMethodDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_AssetBook";
            optionSetListUI.OptionSetName = "opt_DepreciationMethod";

            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {
                ddlopt_DepreciationMethod.DataSource = dtb;
                ddlopt_DepreciationMethod.DataBind();
                ddlopt_DepreciationMethod.DataTextField = "OptionSetLable";
                ddlopt_DepreciationMethod.DataValueField = "OptionSetValue";
                ddlopt_DepreciationMethod.DataBind();

            }
            else
            {
                ddlopt_DepreciationMethod.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "-1"));
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindDepreciationMethodDropDown()";
            logExcpUIobj.ResourceName = "Asset_AssetBookForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Asset_AssetBookForm : BindDepreciationMethodDropDown] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #endregion Bind DepreciationMethod DropDown

    #endregion Methods


}
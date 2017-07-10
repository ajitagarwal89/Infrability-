using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Assets_AssetBookGroupSetup_AssetBookGroupSetupForm : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    AssetBookGroupSetupFormBAL assetBookGroupSetupFormBAL = new AssetBookGroupSetupFormBAL();
    AssetBookGroupSetupFormUI assetBookGroupSetupFormUI = new AssetBookGroupSetupFormUI();
    AssetGroupListBAL assetGroupListBAL = new AssetGroupListBAL();
    AssetGroupListUI assetGroupListUI = new AssetGroupListUI();
    AssetBookSetupListBAL assetBookSetupListBAL = new AssetBookSetupListBAL();
    AssetBookSetupListUI assetBookSetupListUI = new AssetBookSetupListUI();
    OptionSetListBAL optionSetListBAL=new OptionSetListBAL();
    #endregion Data Members

    #region Events
    protected  void Page_Load(object sender, EventArgs e)
    {
        AssetBookGroupSetupFormUI assetBookGroupSetupFormUI = new AssetBookGroupSetupFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["AssetBookGroupSetupId"] != null)
            {
                assetBookGroupSetupFormUI.Tbl_AssetBookGroupSetupId = Request.QueryString["AssetBookGroupSetupId"];

                BindDepreciationMethod();
                BindAveragingConvention();
                FillForm(assetBookGroupSetupFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Asset Book Group Setup";
            }
            else
            {

                BindDepreciationMethod();
                BindAveragingConvention();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Asset Book Group Setup";
            }
        }
    }

   

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            assetBookGroupSetupFormUI.CreatedBy = SessionContext.UserGuid;
            assetBookGroupSetupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            assetBookGroupSetupFormUI.AssetBookGroupSetupCode = txtAssetBookGroupSetupCode.Text;
            assetBookGroupSetupFormUI.Tbl_AssetBookSetupId = txtAssetBookSetupGuid.Text;
            assetBookGroupSetupFormUI.Tbl_AssetGroupId = txtAssetGroupGuid.Text;
            assetBookGroupSetupFormUI.opt_DepreciationMethod = int.Parse(ddlOpt_DepreciationMethod.SelectedValue);
            assetBookGroupSetupFormUI.opt_AveragingConvention = int.Parse(ddlOpt_AveragingConvention.SelectedValue);
            assetBookGroupSetupFormUI.OriginalLifeYear = int.Parse(txtOriginalLifeYear.Text);
            assetBookGroupSetupFormUI.OriginalLifeDay = int.Parse(txtOriginalLifeDay.Text);
            assetBookGroupSetupFormUI.ScrapValue = Convert.ToDecimal(txtScrapValue.Text);
            /*
             fields Parameter
             */

            if (assetBookGroupSetupFormBAL.AddAssetBookGroupSetup(assetBookGroupSetupFormUI) == 1)
            {
                divSuccess.Visible = true;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
                divError.Visible = true;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "Assets_AssetBookGroupSetup_AssetBookGroupSetupForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetBookGroupSetup_AssetBookGroupSetupForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            assetBookGroupSetupFormUI.ModifiedBy = SessionContext.UserGuid;
            assetBookGroupSetupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            assetBookGroupSetupFormUI.Tbl_AssetBookGroupSetupId = Request.QueryString["AssetBookGroupSetupId"];
            assetBookGroupSetupFormUI.AssetBookGroupSetupCode = txtAssetBookGroupSetupCode.Text;
            assetBookGroupSetupFormUI.Tbl_AssetBookSetupId = txtAssetBookSetupGuid.Text;
            assetBookGroupSetupFormUI.Tbl_AssetGroupId = txtAssetGroupGuid.Text;
            assetBookGroupSetupFormUI.opt_DepreciationMethod = int.Parse(ddlOpt_DepreciationMethod.SelectedValue);
            assetBookGroupSetupFormUI.opt_AveragingConvention = int.Parse(ddlOpt_AveragingConvention.SelectedValue);
            assetBookGroupSetupFormUI.OriginalLifeYear = int.Parse(txtOriginalLifeYear.Text);
            assetBookGroupSetupFormUI.OriginalLifeDay = int.Parse(txtOriginalLifeDay.Text);
            assetBookGroupSetupFormUI.ScrapValue = Convert.ToDecimal(txtScrapValue.Text);
            /*
               fields Parameter
               */

            if (assetBookGroupSetupFormBAL.UpdateAssetBookGroupSetup(assetBookGroupSetupFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Assets_AssetBookGroupSetup_AssetBookGroupSetupForm.CS";
            logExcpUIobj.RecordId = assetBookGroupSetupFormUI.Tbl_AssetBookGroupSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetBookGroupSetup_AssetBookGroupSetupForm : btnUpdate_Click] An error occured in the processing of Record Id : " + assetBookGroupSetupFormUI.Tbl_AssetBookGroupSetupId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            assetBookGroupSetupFormUI.Tbl_AssetBookGroupSetupId = Request.QueryString["AssetBookGroupSetupId"];

            if (assetBookGroupSetupFormBAL.DeleteAssetBookGroupSetup(assetBookGroupSetupFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Assets_AssetBookGroupSetup_AssetBookGroupSetupForm.CS";
            logExcpUIobj.RecordId = assetBookGroupSetupFormUI.Tbl_AssetBookGroupSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetBookGroupSetup_AssetBookGroupSetupForm : btnDelete_Click] An error occured in the processing of Record Id : " + assetBookGroupSetupFormUI.Tbl_AssetBookGroupSetupId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetBookGroupSetupList.aspx");
    }

    #region AssetGroup Search
    protected void btnAssetGroupSearch_Click(object sender, EventArgs e)
    {
        btnHtmlAssetGroupSearch.Visible = false;
        btnHtmlAssetGroupClose.Visible = true;
        SearchAssetGroupList();
    }
    protected void btnClearAssetGroupSearch_Click(object sender, EventArgs e)
    {
        BindAssetGroupList();
        gvAssetGroupSearch.Visible = true;
        btnHtmlAssetGroupSearch.Visible = true;
        btnHtmlAssetGroupClose.Visible = false;
        txtAssetGroupSearch.Text = "";
        txtAssetGroupSearch.Focus();
    }
    protected void btnAssetGroupRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindAssetGroupList();
    }
    #endregion AssetGroup Search



    #region AssetBookSetup Search
    protected void btnAssetBookSetupSearch_Click(object sender, EventArgs e)
    {
        btnHtmlAssetBookSetupSearch.Visible = false;
        btnHtmlAssetBookSetupClose.Visible = true;
        SearchAssetBookSetupList();
    }
    protected void btnClearAssetBookSetupSearch_Click(object sender, EventArgs e)
    {
        BindAssetBookSetupList();
        gvAssetBookSetupSearch.Visible = true;
        btnHtmlAssetBookSetupSearch.Visible = true;
        btnHtmlAssetBookSetupClose.Visible = false;
        txtAssetBookSetupSearch.Text = "";
        txtAssetBookSetupSearch.Focus();
    }
    protected void btnAssetBookSetupRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindAssetBookSetupList();
    }
    #endregion AssetGroup Search
    #endregion Events

    #region Methods
    private void FillForm(AssetBookGroupSetupFormUI assetBookGroupSetupFormUI)
    {
        try
        {
            DataTable dtb = assetBookGroupSetupFormBAL.GetAssetBookGroupSetupListById(assetBookGroupSetupFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtAssetBookGroupSetupCode.Text= dtb.Rows[0]["AssetBookGroupSetupCode"].ToString();
                txtAssetGroup.Text = dtb.Rows[0]["tbl_AssetGroup"].ToString();
                txtAssetGroupGuid.Text = dtb.Rows[0]["tbl_AssetGroupId"].ToString();

                txtAssetBookSetupGuid.Text = dtb.Rows[0]["tbl_AssetBookSetupId"].ToString();
                txtAssetBookSetup.Text = dtb.Rows[0]["tbl_AssetBookSetup"].ToString();

                ddlOpt_DepreciationMethod.Text = dtb.Rows[0]["DepreciationMethod"].ToString();
                ddlOpt_AveragingConvention.Text = dtb.Rows[0]["AveragingConvention"].ToString();
                txtOriginalLifeYear.Text = dtb.Rows[0]["OriginalLifeYear"].ToString();
                txtOriginalLifeDay.Text = dtb.Rows[0]["OriginalLifeDay"].ToString();
                txtScrapValue.Text = dtb.Rows[0]["ScrapValue"].ToString();
                
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
            logExcpUIobj.ResourceName = "Assets_AssetBookGroupSetup_AssetBookGroupSetupForm.CS";
            logExcpUIobj.RecordId = assetBookGroupSetupFormUI.Tbl_AssetBookGroupSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetBookGroupSetup_AssetBookGroupSetupForm : FillForm] An error occured in the processing of Record Id : " + assetBookGroupSetupFormUI.Tbl_AssetBookGroupSetupId + ". Details : [" + exp.ToString() + "]");
        }
    }

    #region AssetGroup Search
    private void SearchAssetGroupList()
    {
        try
        {

            AssetGroupListUI assetGroupListUI = new AssetGroupListUI();
            assetGroupListUI.Search = txtAssetGroupSearch.Text;
            DataTable dtb = assetGroupListBAL.AssetGroupListBySearchParameters(assetGroupListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAssetGroupSearch.DataSource = dtb;
                gvAssetGroupSearch.DataBind();
                divAssetGroupSearchError.Visible = false;
            }
            else
            {
                divAssetGroupSearchError.Visible = true;
                lblAssetGroupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAssetGroupSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchAssetGroupList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_Asset_AssetForm : SearchAssetGroupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindAssetGroupList()
    {
        try
        {
            DataTable dtb = assetGroupListBAL.GetAssetGroupList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAssetGroupSearch.DataSource = dtb;
                gvAssetGroupSearch.DataBind();
                divAssetGroupSearchError.Visible = false;
            }
            else
            {
                divAssetGroupSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAssetGroupSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindAssetGroupList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_Asset_AssetForm : BindAssetGroupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Asset Group Serach

    #region AssetBookSetup Search
    private void SearchAssetBookSetupList()
    {
        try
        {

            AssetBookSetupListUI assetBookSetupListUI = new AssetBookSetupListUI();
            assetBookSetupListUI.Search = txtAssetBookSetupSearch.Text;
            DataTable dtb = assetBookSetupListBAL.GetAssetBookSetupListById(assetBookSetupListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAssetBookSetupSearch.DataSource = dtb;
                gvAssetBookSetupSearch.DataBind();
                divAssetBookSetupSearchError.Visible = false;
            }
            else
            {
                divAssetBookSetupSearchError.Visible = true;
                lblAssetBookSetupSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAssetBookSetupSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchAssetBookSetupList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_Asset_AssetForm : SearchAssetBookSetupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindAssetBookSetupList()
    {
        try
        {
            DataTable dtb = assetBookSetupListBAL.GetAssetBookSetupList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAssetBookSetupSearch.DataSource = dtb;
                gvAssetBookSetupSearch.DataBind();
                divAssetBookSetupSearchError.Visible = false;
            }
            else
            {
                divAssetBookSetupSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAssetBookSetupSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindAssetBookSetupList()";
            logExcpUIobj.ResourceName = "Assets_Asset_AssetForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_Asset_AssetForm : BindAssetBookSetupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Asset Group Serach
    private void BindDepreciationMethod()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_AssetBookGroupSetup";
            optionSetListUI.OptionSetName = "Opt_DepreciationMethod";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {
                ddlOpt_DepreciationMethod.DataSource = dtb;
                ddlOpt_DepreciationMethod.DataBind();
                ddlOpt_DepreciationMethod.DataTextField = "OptionSetLable";
                ddlOpt_DepreciationMethod.DataValueField = "OptionSetValue";
                ddlOpt_DepreciationMethod.DataBind();
            }
            else
            {
                ddlOpt_DepreciationMethod.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindDepreciationMethod()";
            logExcpUIobj.ResourceName = "Assets_AssetBookSetup_AssetBookSetupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_AssetBookSetup_AssetBookSetupForm : BindDepreciationMethod] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindAveragingConvention()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_AssetBookGroupSetup";
            optionSetListUI.OptionSetName = "Opt_AveragingConvention";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {
                ddlOpt_AveragingConvention.DataSource = dtb;
                ddlOpt_AveragingConvention.DataBind();
                ddlOpt_AveragingConvention.DataTextField = "OptionSetLable";
                ddlOpt_AveragingConvention.DataValueField = "OptionSetValue";
                ddlOpt_AveragingConvention.DataBind();
            }
            else
            {
                ddlOpt_AveragingConvention.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "Bindopt_CurrentyFiscalYearDropDownList()";
            logExcpUIobj.ResourceName = "Assets_AssetBookSetup_AssetBookSetupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_AssetBookSetup_AssetBookSetupForm : Bindopt_CurrentyFiscalYearDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }


    #endregion Methods
}
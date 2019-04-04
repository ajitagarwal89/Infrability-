using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_AssetGroupForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    AssetGroupFormBAL assetGroupFormBAL = new AssetGroupFormBAL();
    AssetGroupFormUI assetGroupFormUI = new AssetGroupFormUI();    
    AssetAndGroupAccountListBAL assetAndGroupAccountListBAL = new AssetAndGroupAccountListBAL();
    #endregion Data Members
    protected override void Page_Load(object sender, EventArgs e)
    {
        AssetGroupFormUI assetGroupFormUI = new AssetGroupFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["AssetGroupId"] != null || Request.QueryString["recordId"] != null)
            {
                assetGroupFormUI.Tbl_AssetGroupId = (Request.QueryString["AssetGroupId"] != null ? Request.QueryString["AssetGroupId"] : Request.QueryString["recordId"]);


                FillForm(assetGroupFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnAuditHistory.Visible = true;
                lblHeading.Text = "Update Asset Group";
            }
            else
            {

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;    
                lblHeading.Text = "Add New Asset Group";
            }
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            assetGroupFormUI.CreatedBy = SessionContext.UserGuid;
            assetGroupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            assetGroupFormUI.Description = txtDescription.Text;
            assetGroupFormUI.Tbl_AssetAndGroupAccountId = txtAssetAndGroupAccountIdGuid.Text;
          //  assetGroupFormUI.Tbl_InsuranceId = txtInsuranceIdGuid.Text;
            assetGroupFormUI.AssetGroupCode = txtAssetGroupCode.Text;
            if (assetGroupFormBAL.AddAssetGroup(assetGroupFormUI) == 1)
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
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "System_Settings_AssetGroupForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AssetGroupForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            assetGroupFormUI.Tbl_AssetGroupId = Request.QueryString["AssetGroupId"];
            assetGroupFormUI.ModifiedBy = SessionContext.UserGuid;
            assetGroupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            assetGroupFormUI.Description = txtDescription.Text;
            assetGroupFormUI.Tbl_AssetAndGroupAccountId = txtAssetAndGroupAccountIdGuid.Text;
           // assetGroupFormUI.Tbl_InsuranceId = txtInsuranceIdGuid.Text;
            assetGroupFormUI.AssetGroupCode = txtAssetGroupCode.Text;

            if (assetGroupFormBAL.UpdateAssetGroup(assetGroupFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
                assetGroupFormUI.Tbl_AssetGroupId = Request.QueryString["AssetGroupId"];
                FillForm(assetGroupFormUI);
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
            logExcpUIobj.ResourceName = "System_Settings_AssetGroupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AssetGroupForm : btnUpdate_Click] An error occured in the processing of Record Id : " + assetGroupFormUI.Tbl_AssetGroupId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        AssetGroupFormUI assetGroupFormUI = new AssetGroupFormUI();
        try
        {
            assetGroupFormUI.Tbl_AssetGroupId = Request.QueryString["AssetGroupId"];

            if (assetGroupFormBAL.DeleteAssetGroup(assetGroupFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_AssetGroupForm.CS";
            logExcpUIobj.RecordId = assetGroupFormUI.Tbl_AssetGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AssetGroupForm : btnDelete_Click] An error occured in the processing of Record Id : " + assetGroupFormUI.Tbl_AssetGroupId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetGroupList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Finance/Asset_Accounting/Capitalization_of_Assets/AssetGroupForm.aspx";
        string recordId = Request.QueryString["AssetGroupId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    #region Asset And Group Account Search
    protected void btnAssetAndGroupAccountSearch_Click(object sender, EventArgs e)
    {
        btnHtmlAssetAndGroupAccountSearch.Visible = false;
        btnHtmlAssetAndGroupAccountClose.Visible = true;
        SearchAssetAndGroupAccountList();
    }
    protected void btnClearAssetAndGroupAccountSearch_Click(object sender, EventArgs e)
    {
        BindAssetAndGroupAccountList();
        gvAssetAndGroupAccountSearch.Visible = true;
        btnHtmlAssetAndGroupAccountSearch.Visible = true;
        btnHtmlAssetAndGroupAccountClose.Visible = false;
        txtAssetAndGroupAccountSearch.Text = "";
        txtAssetAndGroupAccountSearch.Focus();
    }
    protected void btnAssetAndGroupAccountRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);       
    }
    #endregion  Search

    #region Methods
    private void FillForm(AssetGroupFormUI assetGroupFormUI)
    {
        try
        {
            DataTable dtb = assetGroupFormBAL.GetAssetGroupListById(assetGroupFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                txtAssetAndGroupAccountIdGuid.Text= dtb.Rows[0]["tbl_AssetAndGroupAccountId"].ToString();
                txtAssetAndGroupAccountId.Text= dtb.Rows[0]["tbl_AssetAndGroupAccount"].ToString();
                //txtInsuranceIdGuid.Text= dtb.Rows[0]["tbl_InsuranceId"].ToString();
                //txtInsuranceId.Text= dtb.Rows[0]["tbl_Insurance"].ToString();
                txtAssetGroupCode.Text= dtb.Rows[0]["AssetGroupCode"].ToString();
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
            logExcpUIobj.ResourceName = "System_Settings_AssetGroupForm.CS";
            logExcpUIobj.RecordId = assetGroupFormUI.Tbl_AssetGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AssetGroupForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    

    #region Asset And Group Account Search    
    private void SearchAssetAndGroupAccountList()
    {
        try
        {

            AssetAndGroupAccountListUI assetAndGroupAccountListUI = new AssetAndGroupAccountListUI();
            assetAndGroupAccountListUI.Search = txtAssetAndGroupAccountSearch.Text;


            DataTable dtb = assetAndGroupAccountListBAL.GetAssetAndGroupAccountListBySearchParameters(assetAndGroupAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAssetAndGroupAccountSearch.DataSource = dtb;
                gvAssetAndGroupAccountSearch.DataBind();
                divAssetAndGroupAccountSearchError.Visible = false;
            }
            else
            {
                divAssetAndGroupAccountSearchError.Visible = true;
                lblAssetAndGroupAccountSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAssetAndGroupAccountSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchAssetAndGroupAccountList()";
            logExcpUIobj.ResourceName = "System_Settings_AssetGroupForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AssetGroupForm : SearchInsuranceList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindAssetAndGroupAccountList()
    {
        try
        {
            DataTable dtb = assetAndGroupAccountListBAL.GetAssetAndGroupAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAssetAndGroupAccountSearch.DataSource = dtb;
                gvAssetAndGroupAccountSearch.DataBind();
                divAssetAndGroupAccountSearchError.Visible = false;

            }
            else
            {
                divAssetAndGroupAccountSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAssetAndGroupAccountSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindAssetAndGroupAccountList()";
            logExcpUIobj.ResourceName = "System_Settings_ssetAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AssetGroupForm : BindAssetAndGroupAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion 
    #endregion Methods
}
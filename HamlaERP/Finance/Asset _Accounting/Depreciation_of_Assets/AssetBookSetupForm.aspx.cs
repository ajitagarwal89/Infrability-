using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Assets_AssetBookSetup_AssetBookSetupForm : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    BatchFormBAL batchFormBAL = new BatchFormBAL();
    BatchFormUI batchFormUI = new BatchFormUI();

    AssetBookSetupFormBAL assetBookSetupFormBAL = new AssetBookSetupFormBAL();
    AssetBookSetupFormUI assetBookSetupFormUI = new AssetBookSetupFormUI();

    #endregion Data Members

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        AssetBookSetupFormUI assetBookSetupFormUI = new AssetBookSetupFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["AssetBookSetupId"] != null)
            {
                assetBookSetupFormUI.Tbl_AssetBookSetupId = Request.QueryString["AssetBookSetupId"];

                
                //FillForm(batchFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Asset Book Setup";
            }
            else
            {
    
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Asset Book Setup";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            assetBookSetupFormUI.CreatedBy = SessionContext.UserGuid;
            assetBookSetupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            assetBookSetupFormUI.AssetBookSetupCode = txtAssetBookSetupCode.Text;
            assetBookSetupFormUI.Description = txtDescription.Text;
            assetBookSetupFormUI.opt_CurrentyFiscalYear = int.Parse(ddlopt_CurrentyFiscalYear.SelectedValue.ToString());
            assetBookSetupFormUI.opt_DepreciatedPeriod = int.Parse(ddlopt_DepreciatedPeriod.SelectedValue.ToString());

         

            if (assetBookSetupFormBAL.AddAssetBookSetup(assetBookSetupFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Assets_AssetBookSetup_AssetBookSetupForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetBookSetup_AssetBookSetupForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            assetBookSetupFormUI.ModifiedBy = SessionContext.UserGuid;
            assetBookSetupFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            assetBookSetupFormUI.Tbl_AssetBookSetupId = Request.QueryString["AssetBookSetupId"];
            assetBookSetupFormUI.AssetBookSetupCode = txtAssetBookSetupCode.Text;
            assetBookSetupFormUI.Description = txtDescription.Text;
            assetBookSetupFormUI.opt_CurrentyFiscalYear = int.Parse(ddlopt_CurrentyFiscalYear.SelectedValue.ToString());
            assetBookSetupFormUI.opt_DepreciatedPeriod = int.Parse(ddlopt_DepreciatedPeriod.SelectedValue.ToString());
                      

            if (assetBookSetupFormBAL.UpdateAssetBookSetup(assetBookSetupFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Assets_AssetBookSetup_AssetBookSetupForm.CS";
            logExcpUIobj.RecordId = batchFormUI.Tbl_BatchId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetBookSetup_AssetBookSetupForm : btnUpdate_Click] An error occured in the processing of Record Id : " + batchFormUI.Tbl_BatchId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            assetBookSetupFormUI.Tbl_AssetBookSetupId = Request.QueryString["AssetBookSetupId"];

            if (assetBookSetupFormBAL.DeleteAssetBookSetup(assetBookSetupFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Assets_AssetBookSetup_AssetBookSetupForm.CS";
            logExcpUIobj.RecordId = batchFormUI.Tbl_BatchId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetBookSetup_AssetBookSetupForm : btnDelete_Click] An error occured in the processing of Record Id : " + batchFormUI.Tbl_BatchId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetBookSetupList.aspx");
    }
    #endregion Events

    #region Methods
    private void FillForm(AssetBookSetupFormUI assetBookSetupFormUI)
    {
        try
        {
            DataTable dtb = assetBookSetupFormBAL.GetAssetBookSetupListById(assetBookSetupFormUI);

            if (dtb.Rows.Count > 0)
            {
               // txtName.Text = dtb.Rows[0]["Name"].ToString();
                //ddlCountry.SelectedValue = dtb.Rows[0]["tbl_CountryId"].ToString();
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
            logExcpUIobj.RecordId = batchFormUI.Tbl_BatchId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetBookSetup_AssetBookSetupForm : FillForm] An error occured in the processing of Record Id : " + batchFormUI.Tbl_BatchId + ". Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods
}
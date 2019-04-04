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
   
    AssetBookSetupFormBAL assetBookSetupFormBAL = new AssetBookSetupFormBAL();
    AssetBookSetupFormUI assetBookSetupFormUI = new AssetBookSetupFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();


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

                Bindopt_CurrentyFiscalYearDropDownList();
                Bindopt_DepreciatedPeriodDropDownList();
                FillForm(assetBookSetupFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Asset Book Setup";
            }
            else
            {
                Bindopt_CurrentyFiscalYearDropDownList();
                Bindopt_DepreciatedPeriodDropDownList();

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
            logExcpUIobj.RecordId = assetBookSetupFormUI.Tbl_AssetBookSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetBookSetup_AssetBookSetupForm : btnUpdate_Click] An error occured in the processing of Record Id : " + assetBookSetupFormUI.Tbl_AssetBookSetupId + ".  Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.RecordId = assetBookSetupFormUI.Tbl_AssetBookSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetBookSetup_AssetBookSetupForm : btnDelete_Click] An error occured in the processing of Record Id : " + assetBookSetupFormUI.Tbl_AssetBookSetupId + ". Details : [" + exp.ToString() + "]");
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

                txtAssetBookSetupCode.Text = dtb.Rows[0]["AssetBookSetupCode"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                //ddlopt_CurrentyFiscalYear.SelectedValue= dtb.Rows[0]["Name"].ToString();
                //ddlopt_DepreciatedPeriod.SelectedValue= dtb.Rows[0]["Name"].ToString();
              
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
            logExcpUIobj.RecordId = assetBookSetupFormUI.Tbl_AssetBookSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetBookSetup_AssetBookSetupForm : FillForm] An error occured in the processing of Record Id : " + assetBookSetupFormUI.Tbl_AssetBookSetupId + ". Details : [" + exp.ToString() + "]");
        }
    }

    private void Bindopt_DepreciatedPeriodDropDownList()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_AssetBookSetup";
            optionSetListUI.OptionSetName = "Opt_DepreciatedPeriod";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {
                ddlopt_DepreciatedPeriod.DataSource = dtb;
                ddlopt_DepreciatedPeriod.DataBind();
                ddlopt_DepreciatedPeriod.DataTextField = "OptionSetLable";
                ddlopt_DepreciatedPeriod.DataValueField = "OptionSetValue";
                ddlopt_DepreciatedPeriod.DataBind();
            }
            else
            {
                ddlopt_DepreciatedPeriod.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "Bindopt_DepreciatedPeriodDropDownList()";
            logExcpUIobj.ResourceName = "Assets_AssetBookSetup_AssetBookSetupForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_AssetBookSetup_AssetBookSetupForm : Bindopt_DepreciatedPeriodDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }

    private void Bindopt_CurrentyFiscalYearDropDownList()
    {

        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_AssetBookSetup";
            optionSetListUI.OptionSetName = "Opt_CurrentyFiscalYear";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {
                ddlopt_CurrentyFiscalYear.DataSource = dtb;
                ddlopt_CurrentyFiscalYear.DataBind();
                ddlopt_CurrentyFiscalYear.DataTextField = "OptionSetLable";
                ddlopt_CurrentyFiscalYear.DataValueField = "OptionSetValue";
                ddlopt_CurrentyFiscalYear.DataBind();
            }
            else
            {
                ddlopt_CurrentyFiscalYear.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
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
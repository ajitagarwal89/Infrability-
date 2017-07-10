using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_SitesForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    SitesFormBAL sitesFormBAL = new SitesFormBAL();
    SitesFormUI sitesFormUI = new SitesFormUI();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        SitesFormUI sitesFormUI = new SitesFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["SitesId"] != null)
            {
                sitesFormUI.Tbl_SitesId = Request.QueryString["SitesId"];

               
                FillForm(sitesFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Sites";
            }
            else
            {

                //BindOrganizationDropDown();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Sites";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            sitesFormUI.CreatedBy = SessionContext.UserGuid;
            sitesFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            sitesFormUI.SiteNumber = txtSiteNumber.Text;
            sitesFormUI.Description = txtDescription.Text;


            if (sitesFormBAL.AddSites(sitesFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_SitesForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_SitesForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            sitesFormUI.Tbl_SitesId = Request.QueryString["SitesId"];
            sitesFormUI.ModifiedBy = SessionContext.UserGuid;
            sitesFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            sitesFormUI.SiteNumber = txtSiteNumber.Text;
            sitesFormUI.Description = txtDescription.Text;
            

            if (sitesFormBAL.UpdateSites(sitesFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_SitesForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_SitesForm : btnUpdate_Click] An error occured in the processing of Record Id : " + sitesFormUI.Tbl_SitesId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            sitesFormUI.Tbl_SitesId = Request.QueryString["SitesId"];

            if (sitesFormBAL.DeleteSites(sitesFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_SitesForm.CS";
            logExcpUIobj.RecordId = sitesFormUI.Tbl_SitesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_SitesForm : btnDelete_Click] An error occured in the processing of Record Id : " + sitesFormUI.Tbl_SitesId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("SitesList.aspx");
    }
    #endregion Events

    #region Methods
    private void FillForm(SitesFormUI sitesFormUI)
    {
        try
        {
            DataTable dtb = sitesFormBAL.GetSitesListById(sitesFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtSiteNumber.Text = dtb.Rows[0]["SiteNumber"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
             
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
            logExcpUIobj.ResourceName = "System_Settings_SitesForm.CS";
            logExcpUIobj.RecordId = sitesFormUI.Tbl_SitesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_SitesForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods
}
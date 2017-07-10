using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Finware;
using log4net;
using System.Data;

public partial class System_Settings_OrganizationTypeForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    OrganizationTypeFormBAL organizationTypeFormBAL = new OrganizationTypeFormBAL();
    OrganizationTypeFormUI organizationTypeFormUI = new OrganizationTypeFormUI();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        OrganizationTypeFormUI organizationTypeFormUI = new OrganizationTypeFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["OrganizationTypeId"] != null)
            {
                organizationTypeFormUI.Tbl_OrganizationTypeId = Request.QueryString["OrganizationTypeId"];

              
                FillForm(organizationTypeFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update OrganizationType";
            }
            else
            {

                //BindOrganizationDropDown();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New OrganizationType";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            organizationTypeFormUI.CreatedBy = SessionContext.UserGuid;
            organizationTypeFormUI.Tbl_OrganizationTypeId = SessionContext.OrganizationId;
            organizationTypeFormUI.OrganizationType = txtOrganizationType.Text;

           

            if (organizationTypeFormBAL.AddOrganizationType(organizationTypeFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_OrganizationTypeForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OrganizationTypeForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            organizationTypeFormUI.Tbl_OrganizationTypeId = Request.QueryString["OrganizationTypeId"];
            organizationTypeFormUI.ModifiedBy = SessionContext.UserGuid;

            organizationTypeFormUI.OrganizationType = txtOrganizationType.Text;
            

            if (organizationTypeFormBAL.UpdateOrganizationType(organizationTypeFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
                organizationTypeFormUI.Tbl_OrganizationTypeId = Request.QueryString["OrganizationTypeId"];
                FillForm(organizationTypeFormUI);
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
            logExcpUIobj.ResourceName = "System_Settings_OrganizationTypeForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OrganizationTypeForm : btnUpdate_Click] An error occured in the processing of Record Id : " + organizationTypeFormUI.Tbl_OrganizationTypeId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        OrganizationTypeFormUI organizationTypeFormUI = new OrganizationTypeFormUI();
        try
        {
            organizationTypeFormUI.Tbl_OrganizationTypeId = Request.QueryString["OrganizationTypeId"];

            if (organizationTypeFormBAL.DeleteOrganizationType(organizationTypeFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = organizationTypeFormUI.Tbl_OrganizationTypeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OrganizationTypeForm : btnDelete_Click] An error occured in the processing of Record Id : " + organizationTypeFormUI.Tbl_OrganizationTypeId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrganizationTypeList.aspx");
    }
    #endregion Events

    #region Methods
    private void FillForm(OrganizationTypeFormUI organizationTypeFormUI)
    {
        try
        {
            DataTable dtb = organizationTypeFormBAL.GetOrganizationTypeListById(organizationTypeFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtOrganizationType.Text = dtb.Rows[0]["OrganizationType"].ToString();
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
            logExcpUIobj.ResourceName = "System_Settings_OrganizationTypeForm.CS";
            logExcpUIobj.RecordId = organizationTypeFormUI.Tbl_OrganizationTypeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OrganizationTypeForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods
}
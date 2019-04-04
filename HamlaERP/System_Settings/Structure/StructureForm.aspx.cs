using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;


public partial class System_Settings_StructureForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    StructureFormBAL structureFormBAL = new StructureFormBAL();
    StructureFormUI structureFormUI = new StructureFormUI();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        StructureFormUI structureFormUI = new StructureFormUI();
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["StructureId"] != null || Request.QueryString["recordId"] != null)
            {
                structureFormUI.Tbl_StructureId = (Request.QueryString["StructureId"] != null ? Request.QueryString["StructureId"] : Request.QueryString["recordId"]);



                FillForm(structureFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Structure";
            }
            else
            {

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New Structure";
            }
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            structureFormUI.CreatedBy = SessionContext.UserGuid;
            structureFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            structureFormUI.StructureCode = txtStructureCode.Text;
            structureFormUI.Description = txtDescription.Text.Trim();


            if (structureFormBAL.AddStructure(structureFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_StructureForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_StructureForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            structureFormUI.ModifiedBy = SessionContext.UserGuid;
            structureFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            structureFormUI.StructureCode = txtStructureCode.Text;
            structureFormUI.Description = txtDescription.Text.Trim();
            structureFormUI.Tbl_StructureId = Request.QueryString["StructureId"];

            if (structureFormBAL.UpdateStructure(structureFormUI) == 1)
            {
                divSuccess.Visible = true;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
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
            logExcpUIobj.ResourceName = "System_Settings_StructureForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_StructureForm : btnUpdate_Click] An error occured in the processing of Record Id : " + structureFormUI.Tbl_StructureId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            structureFormUI.Tbl_StructureId = Request.QueryString["StructureId"];

            if (structureFormBAL.DeleteStructure(structureFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_StructureForm.CS";
            logExcpUIobj.RecordId = structureFormUI.Tbl_StructureId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_StructureForm : btnDelete_Click] An error occured in the processing of Record Id : " + structureFormUI.Tbl_StructureId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("StructureList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/System_Settings/StructureForm.aspx";
        string recordId = Request.QueryString["StructureId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }
    #endregion Events

    #region Methods
    private void FillForm(StructureFormUI StructureFormUI)
    {
        try
        {
            DataTable dtb = structureFormBAL.GetStructureListById(StructureFormUI);

            if (dtb.Rows.Count > 0)
            {

                txtStructureCode.Text = dtb.Rows[0]["StructureCode"].ToString();
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
            logExcpUIobj.ResourceName = "System_Settings_StructureForm.CS";
            logExcpUIobj.RecordId = StructureFormUI.Tbl_StructureId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_StructureForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods

}
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_AuditSettingForm : System.Web.UI.Page
{

    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    CountryListBAL countryListBAL = new CountryListBAL();

    Audit_SettingFormBAL auditSettingFormBAL = new Audit_SettingFormBAL();
    Audit_SettingFormUI auditSettingFormUI = new Audit_SettingFormUI();

    #endregion Data Members

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        Audit_SettingFormUI auditSettingFormUI = new Audit_SettingFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["AuditSettingId"] != null)
            {
                auditSettingFormUI.Tbl_Audit_SettingId = Request.QueryString["AuditSettingId"];
                BindTableDropDown();
                FillForm(auditSettingFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                lblHeading.Text = "Update AuditSetting";
            }
            else
            {
                BindTableDropDown();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;

                lblHeading.Text = "Add New AuditSetting";
            }

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            auditSettingFormUI.CreatedBy = SessionContext.UserGuid;
            auditSettingFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            auditSettingFormUI.ObjectName = txtObjectName.Text;
            if (chkEnableAudit.Checked == true)
            {
                auditSettingFormUI.EnableAudit = true;
            }
            else
            {
                auditSettingFormUI.EnableAudit = true;
            }
            if (auditSettingFormBAL.AddAudit_Setting(auditSettingFormUI) == 1)
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
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "System_Settings_AuditSettingForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AuditSettingForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            auditSettingFormUI.ModifiedBy = SessionContext.UserGuid;
            auditSettingFormUI.Tbl_Audit_SettingId = Request.QueryString["AuditSettingId"];
            auditSettingFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            auditSettingFormUI.ObjectName = txtObjectName.Text;
            if (chkEnableAudit.Checked)
            {
                auditSettingFormUI.EnableAudit = true;
            }
            else
            {
                auditSettingFormUI.EnableAudit = false;
            }
            if (auditSettingFormBAL.UpdateAudit_Setting(auditSettingFormUI) == 1)
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
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "System_Settings_AuditSettingForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AuditSettingForm : btnUpdate_Click] An error occured in the processing of Record Id : " + auditSettingFormUI.Tbl_Audit_SettingId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void ddlTables_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTables.SelectedValue == "0" || ddlTables.SelectedIndex == 0)
        {
            txtObjectName.Text = string.Empty;
        }
        else
        {
            txtObjectName.Text = ddlTables.SelectedItem.Text;
            //txtColumn.Text = Convert.ToString(ddlColoumnByTable.SelectedValue);

        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AuditSettingList.aspx");
    }
    #endregion Events

    #region Methods

    private void FillForm(Audit_SettingFormUI auditsettingFormUI)
    {
        try
        {
            DataTable dtb = auditSettingFormBAL.GetAuditSettinListById(auditsettingFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtObjectName.Text = dtb.Rows[0]["ObjectName"].ToString();
                chkEnableAudit.Checked = Convert.ToBoolean(dtb.Rows[0]["EnableAudit"].ToString());

            }
            else
            {

                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotLoadData;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "FillForm()";
            logExcpUIobj.ResourceName = "System_Settings_AuditSettingForm.CS";
            logExcpUIobj.RecordId = auditsettingFormUI.Tbl_Audit_SettingId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AuditSettingForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }

    private void BindTableDropDown()
    {
        try
        {
            DataTable dtb = auditSettingFormBAL.GetSystemTables();

            if (dtb.Rows.Count > 0)
            {
                ddlTables.DataSource = dtb;

                ddlTables.DataTextField = "NAME";
                ddlTables.DataValueField = "OBJECT_ID";
                ddlTables.DataBind();
                ddlTables.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
            }
            else
            {
                ddlTables.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindOrganizationTypeDropDown()";
            logExcpUIobj.ResourceName = "System_Settings_OptionSetForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSetForm : BindColumnByTablesDropDown] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #endregion Methods
}
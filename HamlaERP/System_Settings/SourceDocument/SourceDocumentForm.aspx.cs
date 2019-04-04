using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_SourceDocumentForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    SourceDocumentFormBAL sourceDocumentFormBAL = new SourceDocumentFormBAL();
    SourceDocumentFormUI sourceDocumentFormUI=new SourceDocumentFormUI ();



  
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        SourceDocumentFormUI sourceDocumentFormUI = new SourceDocumentFormUI();
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["SourceDocumentId"] != null || Request.QueryString["recordId"] != null)
            {
                sourceDocumentFormUI.Tbl_SourceDocumentId = (Request.QueryString["SourceDocumentId"] != null ? Request.QueryString["SourceDocumentId"] : Request.QueryString["recordId"]);

                FillForm(sourceDocumentFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnAuditHistory.Visible = true;
                lblHeading.Text = "Update Source Document";
            }
            else
            {             

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New Source Document";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            sourceDocumentFormUI.CreatedBy = SessionContext.UserGuid;
            sourceDocumentFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            sourceDocumentFormUI.DocumentNumber = txtDocumentNumber.Text.Trim();
            sourceDocumentFormUI.Description = txtDescription.Text.Trim();

           
            if (sourceDocumentFormBAL.AddSourceDocument(sourceDocumentFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_SourceDocumentForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_SourceDocumentForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            sourceDocumentFormUI.ModifiedBy = SessionContext.UserGuid;
            sourceDocumentFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            sourceDocumentFormUI.Tbl_SourceDocumentId = Request.QueryString["SourceDocumentId"];
            sourceDocumentFormUI.DocumentNumber = txtDocumentNumber.Text.Trim();
            sourceDocumentFormUI.Description = txtDescription.Text.Trim();
             

            if (sourceDocumentFormBAL.UpdateSourceDocument(sourceDocumentFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_SourceDocumentForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_SourceDocumentForm : btnUpdate_Click] An error occured in the processing of Record Id : " + sourceDocumentFormUI.Tbl_SourceDocumentId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            sourceDocumentFormUI.Tbl_SourceDocumentId = Request.QueryString["SourceDocumentId"];

            if (sourceDocumentFormBAL.DeleteSourceDocument(sourceDocumentFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_SourceDocumentForm.CS";
            logExcpUIobj.RecordId = sourceDocumentFormUI.Tbl_SourceDocumentId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_SourceDocumentForm : btnDelete_Click] An error occured in the processing of Record Id : " + sourceDocumentFormUI.Tbl_SourceDocumentId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("SourceDocumentList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/System_Settings/SourceDocumentForm.aspx";
        string recordId = Request.QueryString["SourceDocumentId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }
    #endregion Events

    #region Methods
    private void FillForm(SourceDocumentFormUI sourceDocumentFormUI)
    {
        try
        {
            DataTable dtb = sourceDocumentFormBAL.GetSourceDocumentListById(sourceDocumentFormUI);

            if (dtb.Rows.Count > 0)
            {
              
                txtDocumentNumber.Text = dtb.Rows[0]["DocumentNumber"].ToString();
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
            logExcpUIobj.ResourceName = "System_Settings_SourceDocumentForm.CS";
            logExcpUIobj.RecordId = sourceDocumentFormUI.Tbl_SourceDocumentId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_SourceDocumentForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods
}
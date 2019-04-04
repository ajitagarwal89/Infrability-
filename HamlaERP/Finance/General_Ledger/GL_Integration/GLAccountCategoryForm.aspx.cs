using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_General_Ledger_GL_Integration_GLAccountCategoryForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    GLAccountCategoryFormBAL gLAccountCategoryFormBAL = new GLAccountCategoryFormBAL();
    GLAccountCategoryFormUI gLAccountCategoryFormUI = new GLAccountCategoryFormUI();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        GLAccountCategoryFormUI gLAccountCategoryFormUI = new GLAccountCategoryFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["GLAccountCategoryId"] != null || Request.QueryString["recordId"] != null)
            {
                gLAccountCategoryFormUI.Tbl_GLAccountCategoryId = (Request.QueryString["GLAccountCategoryId"] != null ? Request.QueryString["GLAccountCategoryId"] : Request.QueryString["recordId"]);


                FillForm(gLAccountCategoryFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnAuditHistory.Visible = true;
                lblHeading.Text = "Update GLAccountCategory";
            }
            else
            {



                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New GLAccountCategory";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            gLAccountCategoryFormUI.CreatedBy = SessionContext.UserGuid;
            gLAccountCategoryFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;


            gLAccountCategoryFormUI.CategoryNumber = Convert.ToInt32(txtCategoryNumber.Text);
            gLAccountCategoryFormUI.Description = txtDescription.Text;

            if (gLAccountCategoryFormBAL.AddGLAccountCategory(gLAccountCategoryFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_GLAccountCategoryForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountCategoryForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            gLAccountCategoryFormUI.ModifiedBy = SessionContext.UserGuid;
            gLAccountCategoryFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            gLAccountCategoryFormUI.Tbl_GLAccountCategoryId = Request.QueryString["GLAccountCategoryId"];

            gLAccountCategoryFormUI.CategoryNumber = Convert.ToInt32(txtCategoryNumber.Text);
            gLAccountCategoryFormUI.Description = txtDescription.Text;


            if (gLAccountCategoryFormBAL.UpdateGLAccountCategory(gLAccountCategoryFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
                gLAccountCategoryFormUI.Tbl_GLAccountCategoryId = Request.QueryString["GLAccountCategoryId"];
                FillForm(gLAccountCategoryFormUI);
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
            logExcpUIobj.ResourceName = "System_Settings_GLAccountCategoryForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountCategoryForm : btnUpdate_Click] An error occured in the processing of Record Id : " + gLAccountCategoryFormUI.Tbl_GLAccountCategoryId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            gLAccountCategoryFormUI.Tbl_GLAccountCategoryId = Request.QueryString["GLAccountCategoryId"];

            if (gLAccountCategoryFormBAL.DeleteGLAccountCategory(gLAccountCategoryFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_GLAccountCategoryForm.CS";
            logExcpUIobj.RecordId = gLAccountCategoryFormUI.Tbl_GLAccountCategoryId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountCategoryForm : btnDelete_Click] An error occured in the processing of Record Id : " + gLAccountCategoryFormUI.Tbl_GLAccountCategoryId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("GLAccountCategoryList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~Finance/General_Ledger/GL_Integration/GLAccountCategoryForm.aspx";
        string recordId = Request.QueryString["GLAccountCategoryId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }
    #endregion Events

    #region Methods
    private void FillForm(GLAccountCategoryFormUI gLAccountCategoryFormUI)
    {
        try
        {
            DataTable dtb = gLAccountCategoryFormBAL.GetGLAccountCategoryListById(gLAccountCategoryFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtCategoryNumber.Text = dtb.Rows[0]["CategoryNumber"].ToString();
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
            logExcpUIobj.ResourceName = "System_Settings_GLAccountCategoryForm.CS";
            logExcpUIobj.RecordId = gLAccountCategoryFormUI.Tbl_GLAccountCategoryId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountCategoryForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods
}
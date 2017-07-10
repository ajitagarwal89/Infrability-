using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Comments_CommentsForm : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    CommentsFormBAL commentsFormBAL = new CommentsFormBAL();
    CommentsFormUI commentsFormUI = new CommentsFormUI();
    #endregion Data Members

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        CommentsFormUI commentsFormUI = new CommentsFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CommentsId"] != null)
            {
                commentsFormUI.Tbl_CommentsId = Request.QueryString["CommentsId"];
                FillForm(commentsFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Comments";
            }
            else
            {
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Comments";
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            commentsFormUI.CreatedBy = SessionContext.UserGuid;
            commentsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            commentsFormUI.Description = txtDescription.Text;

            if (commentsFormBAL.AddComments(commentsFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
                divSuccess.Visible = false;
                divError.Visible = true;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "Comments_CommentsForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Comments_CommentsForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            commentsFormUI.ModifiedBy = SessionContext.UserGuid;
            commentsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            commentsFormUI.Tbl_CommentsId = Request.QueryString["CommentsId"];
            commentsFormUI.Description = txtDescription.Text;
            if (commentsFormBAL.UpdateComments(commentsFormUI) == 1)
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
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "Comments_CommentsForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Comments_CommentsForm : btnUpdate_Click] An error occured in the processing of Record Id : " + commentsFormUI.Tbl_CommentsId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            commentsFormUI.Tbl_CommentsId = Request.QueryString["CommentsId"];

            if (commentsFormBAL.DeleteComments(commentsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Comments_CommentsForm.CS";
            logExcpUIobj.RecordId = commentsFormUI.Tbl_CommentsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Comments_CommentsForm : btnDelete_Click] An error occured in the processing of Record Id : " + commentsFormUI.Tbl_CommentsId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("CommentsList.aspx");
    }

    #endregion Events

    #region Methods
    private void FillForm(CommentsFormUI commentsFormUI)
    {
        try
        {
            DataTable dtb = commentsFormBAL.GetCommentsListById(commentsFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtDescription.Text= dtb.Rows[0]["Description"].ToString();
                }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "FillForm()";
            logExcpUIobj.ResourceName = "Comments_CommentsForm.CS";
            logExcpUIobj.RecordId = this.commentsFormUI.Tbl_CommentsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Comments_CommentsForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

   
    #endregion Methods


}
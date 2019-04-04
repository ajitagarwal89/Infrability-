using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_ChequeBookForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

   
    ChequeBookFormBAL chequeBookFormBAL = new ChequeBookFormBAL();
    ChequeBookFormUI chequeBookFormUI = new ChequeBookFormUI();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        ChequeBookFormUI chequeBookFormUI = new ChequeBookFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ChequeBookId"] != null || Request.QueryString["recordId"] != null)
            {
                chequeBookFormUI.Tbl_ChequeBookId = (Request.QueryString["ChequeBookId"] != null ? Request.QueryString["ChequeBookId"] : Request.QueryString["recordId"]);
                FillForm(chequeBookFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Cheque Book";
            }
            else
            {

                
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New Cheque Book";
            }
        }
    }

   

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            chequeBookFormUI.CreatedBy = SessionContext.UserGuid;
            chequeBookFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            chequeBookFormUI.ChequeBookNumber = txtChequeBookNumber.Text.Trim().ToString();
            chequeBookFormUI.ChequeBookName = txtChequeBookName.Text.Trim().ToString();
            if (chequeBookFormBAL.AddChequeBook(chequeBookFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;

                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
                divError.Visible = true;
                divSuccess.Visible = false;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "System_Settings_ChequeBookForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ChequeBookForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            chequeBookFormUI.ModifiedBy = SessionContext.UserGuid;
            chequeBookFormUI.Tbl_ChequeBookId = Request.QueryString["ChequeBookId"];
            chequeBookFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            chequeBookFormUI.ChequeBookNumber = txtChequeBookNumber.Text.Trim().ToString();
            chequeBookFormUI.ChequeBookName = txtChequeBookName.Text.Trim().ToString();

            if (chequeBookFormBAL.UpdateChequeBook(chequeBookFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                divSuccess.Visible = false;
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "System_Settings_ChequeBookForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ChequeBookForm : btnUpdate_Click] An error occured in the processing of Record Id : " + chequeBookFormUI.Tbl_ChequeBookId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            chequeBookFormUI.Tbl_ChequeBookId = Request.QueryString["ChequeBookId"];

            if (chequeBookFormBAL.DeleteChequeBook(chequeBookFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_ChequeBookForm.CS";
            logExcpUIobj.RecordId =chequeBookFormUI.Tbl_ChequeBookId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ChequeBookForm : btnDelete_Click] An error occured in the processing of Record Id : " + chequeBookFormUI.Tbl_ChequeBookId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChequeBookList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/System_Settings/ChequeBookForm.aspx";
        string recordId = Request.QueryString["ChequeBookId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }
    #endregion Events

    #region Methods
    private void FillForm(ChequeBookFormUI chequeBookFormUI)
    {

        try
        {
            DataTable dtb = chequeBookFormBAL.GetChequeBookListById(chequeBookFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtChequeBookNumber.Text = dtb.Rows[0]["ChequeBookNumber"].ToString();
                txtChequeBookName.Text = dtb.Rows[0]["ChequeBookName"].ToString();
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
            logExcpUIobj.RecordId = chequeBookFormUI.Tbl_ChequeBookId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ChequeBookForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods
}
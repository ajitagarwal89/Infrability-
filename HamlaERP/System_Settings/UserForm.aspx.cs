using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_UserForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    BatchFormBAL batchFormBAL = new BatchFormBAL();
    BatchFormUI batchFormUI = new BatchFormUI();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        BatchFormUI batchFormUI = new BatchFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["BatchId"] != null)
            {
                batchFormUI.Tbl_BatchId = Request.QueryString["BatchId"];

                //BindOrganizationDropDown();
                FillForm(batchFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Batch";
            }
            else
            {

                //BindOrganizationDropDown();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Batch";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            batchFormUI.CreatedBy = SessionContext.UserGuid;
            batchFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            /*
             fields Parameter
             */

            if (batchFormBAL.AddBatch(batchFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            batchFormUI.ModifiedBy = SessionContext.UserGuid;
            batchFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            batchFormUI.Tbl_BatchId = Request.QueryString["BatchId"];
            /*
               fields Parameter
               */

            if (batchFormBAL.UpdateBatch(batchFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = batchFormUI.Tbl_BatchId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : btnUpdate_Click] An error occured in the processing of Record Id : " + batchFormUI.Tbl_BatchId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            batchFormUI.Tbl_BatchId = Request.QueryString["BatchId"];

            if (batchFormBAL.DeleteBatch(batchFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = batchFormUI.Tbl_BatchId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : btnDelete_Click] An error occured in the processing of Record Id : " + batchFormUI.Tbl_BatchId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("BatchList.aspx");
    }
    #endregion Events

    #region Methods
    private void FillForm(BatchFormUI batchFormUI)
    {
        try
        {
            DataTable dtb = batchFormBAL.GetBatchListById(batchFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtName.Text = dtb.Rows[0]["Name"].ToString();
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

            log.Error("[System_Settings_BatchForm : FillForm] An error occured in the processing of Record Id : " + batchFormUI.Tbl_BatchId + ". Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods
}
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_Segment01Form : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    Segment01FormBAL segment01FormBAL = new Segment01FormBAL();
    Segment01FormUI segment01FormUI = new Segment01FormUI();

    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {

        Segment01FormUI segment01FormUI = new Segment01FormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["Segment01Id"] != null)
            {
                segment01FormUI.Tbl_Segment01Id = Request.QueryString["Segment01Id"];

                FillForm(segment01FormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Segment";
            }
            else
            {
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Segment";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            segment01FormUI.CreatedBy = SessionContext.UserGuid;
            segment01FormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            segment01FormUI.Number = txtNumber.Text;
            segment01FormUI.Description = txtDescription.Text.Trim();




            if (segment01FormBAL.AddSegment01(segment01FormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                divSuccess.Visible = false;
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "System_Settings_Segment01Form.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_Segment01Form : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Segment01FormUI segment01FormUI = new Segment01FormUI();
        try
        {
            segment01FormUI.ModifiedBy = SessionContext.UserGuid;
            segment01FormUI.Tbl_Segment01Id = Request.QueryString["Segment01Id"];
            segment01FormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            segment01FormUI.Number = txtNumber.Text;
            segment01FormUI.Description = txtDescription.Text.Trim();

            if (segment01FormBAL.UpdateSegment01(segment01FormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
            }
            else
            {
                divSuccess.Visible = false;
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "System_Settings_Segment01Form.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_Segment01Form : btnUpdate_Click] An error occured in the processing of Record Id : " + segment01FormUI.Tbl_Segment01Id + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            segment01FormUI.Tbl_Segment01Id = Request.QueryString["Segment01Id"];

            if (segment01FormBAL.DeleteSegment01(segment01FormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_Segment01Form.CS";
            logExcpUIobj.RecordId = segment01FormUI.Tbl_Segment01Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_Segment01Form : btnDelete_Click] An error occured in the processing of Record Id : " + segment01FormUI.Tbl_Segment01Id + ". Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Segment01List.aspx");
    }
    #endregion Events

    #region Methods
    private void FillForm(Segment01FormUI segment01FormUI)
    {
        try
        {
            DataTable dtb = segment01FormBAL.GetSegment01ListById(segment01FormUI);



            if (dtb.Rows.Count > 0)
            {
                txtNumber.Text = dtb.Rows[0]["Number"].ToString();
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
            logExcpUIobj.ResourceName = "System_Settings_Segment01Form.CS";
            logExcpUIobj.RecordId = segment01FormUI.Tbl_Segment01Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[System_Settings_Segment01Form : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods
}
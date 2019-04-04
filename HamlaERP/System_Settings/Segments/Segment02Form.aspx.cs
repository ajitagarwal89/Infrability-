using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_Segment02Form : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    Segment01ListBAL segment01ListBAL = new Segment01ListBAL();

    Segment02FormBAL segment02FormBAL = new Segment02FormBAL();
    Segment02FormUI segment02FormUI = new Segment02FormUI();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        Segment02FormUI segment02FormUI = new Segment02FormUI();


        if (!Page.IsPostBack)
        {
            BindDDLSegment01();
            if (Request.QueryString["Segment02Id"] != null || Request.QueryString["recordId"] != null)
            {
                segment02FormUI.Tbl_Segment02Id = (Request.QueryString["Segment02Id"] != null ? Request.QueryString["Segment02Id"] : Request.QueryString["recordId"]);
                FillForm(segment02FormUI);
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
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New Segment";
            }

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            segment02FormUI.CreatedBy = SessionContext.UserGuid;
            segment02FormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            segment02FormUI.Number = txtNumber.Text;
            segment02FormUI.Description = txtDescription.Text;
            segment02FormUI.Tbl_Segment01Id = ddlSegment01.SelectedValue.ToString();
           


            if (segment02FormBAL.AddSegment02(segment02FormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_Segment02Form.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_Segment02Form : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {


        Segment02FormUI segment02FormUI = new Segment02FormUI();
        try
        {
            segment02FormUI.ModifiedBy = SessionContext.UserGuid;
            segment02FormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            segment02FormUI.Number = txtNumber.Text;
            segment02FormUI.Description = txtDescription.Text;
            segment02FormUI.Tbl_Segment01Id = ddlSegment01.SelectedValue.ToString();
            segment02FormUI.Tbl_Segment02Id = Request.QueryString["Segment02Id"];
            if (segment02FormBAL.UpdateSegment02(segment02FormUI) == 1)
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
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "System_Settings_Segment02Form.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_Segment02Form : btnUpdate_Click] An error occured in the processing of Record Id : " + segment02FormUI.Tbl_Segment02Id + ".  Details : [" + exp.ToString() + "]");
        }



    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            segment02FormUI.Tbl_Segment02Id = Request.QueryString["Segment02Id"];

            if (segment02FormBAL.DeleteSegment02(segment02FormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_Segment02Form.CS";
            logExcpUIobj.RecordId = segment02FormUI.Tbl_Segment02Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_Segment02Form : btnDelete_Click] An error occured in the processing of Record Id : " + segment02FormUI.Tbl_Segment02Id + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Segment02List.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/System_Settings/Segments/Segment02Form.aspx";
        string recordId = Request.QueryString["Segment02Id"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    protected void txtNumber_TextChanged(object sender, EventArgs e)
    {
        try
        {
            AccountFormatFormUI accountFormatFormUI = new AccountFormatFormUI();
            AccountFormatFormBAL accountFormatFormBAL = new AccountFormatFormBAL();
            CommonClasses commonClasses = new CommonClasses();
            int segment = 2;
            accountFormatFormUI.Segment = segment;

            DataTable dtb = accountFormatFormBAL.GetAccountFormatDetails_SelectBySegmentLenght(accountFormatFormUI);

            if (dtb.Rows.Count > 0)
            {
                if (txtNumber.Text.Length != Convert.ToInt32(dtb.Rows[0]["length"].ToString()) || Convert.ToInt32(txtNumber.Text) > commonClasses.MaxLength(Convert.ToInt32(dtb.Rows[0]["length"].ToString())))
                {
                    txtNumber.Text = "";
                }
            }
            else
            { txtNumber.Text = ""; }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "txtNumber_TextChanged";
            logExcpUIobj.ResourceName = "System_Settings_Segment01Form.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_Segment01Form : txtNumber_TextChanged] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }

    #endregion Events

    #region Methods
    private void FillForm(Segment02FormUI segment02FormUI)
    {
        try
        {
            DataTable dtb = segment02FormBAL.GetSegment02ListById(segment02FormUI);

            if (dtb.Rows.Count > 0)
            {
                txtNumber.Text = dtb.Rows[0]["Number"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                ddlSegment01.SelectedValue = dtb.Rows[0]["tbl_Segment01Id"].ToString();


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
            logExcpUIobj.ResourceName = "System_Settings_Segment02Form.CS";
            logExcpUIobj.RecordId = segment02FormUI.Tbl_Segment02Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_Segment02Form : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    public void BindDDLSegment01()
    {
        try
        {
            DataTable dtb = segment01ListBAL.GetSegment01List();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                ddlSegment01.DataSource = dtb;
                ddlSegment01.DataTextField = "Description";
                ddlSegment01.DataValueField = "tbl_Segment01Id";
                ddlSegment01.DataBind();
                ddlSegment01.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));

                divError.Visible = false;
            }
            else
            {
                ddlSegment01.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
                //divError.Visible = true;
                //lblError.Text = Resources.GlobalResource.msgNoRecordFound;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "Search_SearchSegment01.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Search_SearchCountry : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    #endregion Methods


}
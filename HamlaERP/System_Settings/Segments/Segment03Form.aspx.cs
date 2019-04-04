using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_Segment03Form : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    Segment01ListBAL segment01ListBAL = new Segment01ListBAL();
    Segment02ListBAL segment02ListBAL = new Segment02ListBAL();

    Segment03FormBAL segment03FormBAL = new Segment03FormBAL();
    Segment03FormUI segment03FormUI = new Segment03FormUI();

    Segment02ListUI segment02ListUI = new Segment02ListUI();

    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        Segment03FormUI segment03FormUI = new Segment03FormUI();

        if (!Page.IsPostBack)
        {
            BindDDLSegment01();
            if (Request.QueryString["Segment03Id"] != null || Request.QueryString["recordId"] != null)
            {
                segment03FormUI.Tbl_Segment03Id = (Request.QueryString["Segment03Id"] != null ? Request.QueryString["Segment03Id"] : Request.QueryString["recordId"]);
                FillForm(segment03FormUI);
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
            segment03FormUI.CreatedBy = SessionContext.UserGuid;
            segment03FormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            segment03FormUI.Number = txtNumber.Text;
            segment03FormUI.Description = txtDescription.Text;
            segment03FormUI.Tbl_Segment01Id = ddlSegment01.SelectedValue.ToString();
            segment03FormUI.Tbl_Segment02Id = ddlSegment02.SelectedValue.ToString();



            if (segment03FormBAL.AddSegment03(segment03FormUI) == 1)
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


        Segment03FormUI segment03FormUI = new Segment03FormUI();
        try
        {
            segment03FormUI.ModifiedBy = SessionContext.UserGuid;
            segment03FormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            segment03FormUI.Number = txtNumber.Text;
            segment03FormUI.Description = txtDescription.Text;
            segment03FormUI.Tbl_Segment01Id = ddlSegment01.SelectedValue.ToString();
            segment03FormUI.Tbl_Segment02Id = ddlSegment02.SelectedValue.ToString();
            segment03FormUI.Tbl_Segment03Id = Request.QueryString["Segment03Id"];
            if (segment03FormBAL.UpdateSegment03(segment03FormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_Segment03Form.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_Segment03Form : btnUpdate_Click] An error occured in the processing of Record Id : " + segment03FormUI.Tbl_Segment03Id + ".  Details : [" + exp.ToString() + "]");
        }



    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            segment03FormUI.Tbl_Segment03Id = Request.QueryString["Segment03Id"];

            if (segment03FormBAL.DeleteSegment03(segment03FormUI) == 1)
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
            logExcpUIobj.RecordId = segment03FormUI.Tbl_Segment03Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_Segment03Form : btnDelete_Click] An error occured in the processing of Record Id : " + segment03FormUI.Tbl_Segment03Id + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Segment03List.aspx");
    }

    protected void ddlSegment01_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSegment02.Items.Clear();

        segment02ListUI.Tbl_Segment01Id = ddlSegment01.SelectedItem.Value;
        BindDDLSegment02(segment02ListUI);
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/System_Settings/Segments/Segment03Form.aspx";
        string recordId = Request.QueryString["Segment03Id"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    protected void txtNumber_TextChanged(object sender, EventArgs e)
    {
        try
        {
            AccountFormatFormUI accountFormatFormUI = new AccountFormatFormUI();
            AccountFormatFormBAL accountFormatFormBAL = new AccountFormatFormBAL();
            CommonClasses commonClasses = new CommonClasses();
            int segment = 3;
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
    private void FillForm(Segment03FormUI segment03FormUI)
    {
        try
        {
            DataTable dtb = segment03FormBAL.GetSegment03ListById(segment03FormUI);

            if (dtb.Rows.Count > 0)
            {
                txtNumber.Text = dtb.Rows[0]["Number"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();

                segment02ListUI.Tbl_Segment01Id = dtb.Rows[0]["tbl_Segment01Id"].ToString();
                ddlSegment01.SelectedValue = segment02ListUI.Tbl_Segment01Id;
                BindDDLSegment02(segment02ListUI);

                ddlSegment02.SelectedValue = dtb.Rows[0]["tbl_Segment02Id"].ToString();
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
            logExcpUIobj.ResourceName = "System_Settings_Segment03Form.CS";
            logExcpUIobj.RecordId = segment03FormUI.Tbl_Segment03Id;
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

                //ddlSegment02.Items.Clear();                

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

    public void BindDDLSegment02(Segment02ListUI segment02ListUI)
    {
        try
        {
            DataTable dtb = segment02ListBAL.GetSegment02ListBySegment01(segment02ListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                ddlSegment02.DataSource = dtb;
                ddlSegment02.DataTextField = "Description";
                ddlSegment02.DataValueField = "tbl_Segment02Id";
                ddlSegment02.DataBind();
                ddlSegment02.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));

                divError.Visible = false;
            }
            else
            {
                ddlSegment02.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
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
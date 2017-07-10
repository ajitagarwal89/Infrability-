using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_Segment04Form : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    Segment01ListBAL segment01ListBAL = new Segment01ListBAL();
    Segment02ListBAL segment02ListBAL = new Segment02ListBAL();
    Segment03ListBAL segment03ListBAL = new Segment03ListBAL();

    Segment04FormBAL segment04FormBAL = new Segment04FormBAL();
    Segment04FormUI segment04FormUI = new Segment04FormUI();

    Segment02ListUI segment02ListUI = new Segment02ListUI();
    Segment03ListUI segment03ListUI = new Segment03ListUI();

    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        Segment04FormUI segment04FormUI = new Segment04FormUI();

        if (!Page.IsPostBack)
        {
            BindDDLSegment01();
            if (Request.QueryString["Segment04Id"] != null)
            {
                segment04FormUI.Tbl_Segment04Id = Request.QueryString["Segment04Id"];


                FillForm(segment04FormUI);

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
            segment04FormUI.CreatedBy = SessionContext.UserGuid;
            segment04FormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            segment04FormUI.Number = txtNumber.Text;
            segment04FormUI.Description = txtDescription.Text;
            segment04FormUI.Tbl_Segment01Id = ddlSegment01.SelectedValue.ToString();
            segment04FormUI.Tbl_Segment02Id = ddlSegment02.SelectedValue.ToString();
            segment04FormUI.Tbl_Segment03Id = ddlSegment03.SelectedValue.ToString();

            if (segment04FormBAL.AddSegment04(segment04FormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
                Clear();
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
            logExcpUIobj.ResourceName = "System_Settings_Segment04Form.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_Segment04Form : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Segment04FormUI segment04FormUI = new Segment04FormUI();
        try
        {
            segment04FormUI.ModifiedBy = SessionContext.UserGuid;
            segment04FormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            segment04FormUI.Tbl_Segment04Id = Request.QueryString["Segment04Id"];

            segment04FormUI.Number = txtNumber.Text;
            segment04FormUI.Description = txtDescription.Text;

            segment04FormUI.Tbl_Segment01Id = ddlSegment01.SelectedValue.ToString();
            segment04FormUI.Tbl_Segment02Id = ddlSegment02.SelectedValue.ToString();
            segment04FormUI.Tbl_Segment03Id = ddlSegment03.SelectedValue.ToString();

            if (segment04FormBAL.UpdateSegment04(segment04FormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
                Clear();
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
            logExcpUIobj.ResourceName = "System_Settings_Segment04Form.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_Segment04Form : btnUpdate_Click] An error occured in the processing of Record Id : " + segment04FormUI.Tbl_Segment04Id + ".  Details : [" + exp.ToString() + "]");
        }


    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            segment04FormUI.Tbl_Segment04Id = Request.QueryString["Segment04Id"];

            if (segment04FormBAL.DeleteSegment04(segment04FormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_Segment04Form.CS";
            logExcpUIobj.RecordId = segment04FormUI.Tbl_Segment04Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_Segment02Form : btnDelete_Click] An error occured in the processing of Record Id : " + segment04FormUI.Tbl_Segment04Id + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Segment04List.aspx");
    }

    protected void ddlSegment01_SelectedIndexChanged(object sender, EventArgs e)
    {
        segment02ListUI.Tbl_Segment01Id = ddlSegment01.SelectedItem.Value;
        BindDDLSegment02(segment02ListUI);
    }

    protected void ddlSegment02_SelectedIndexChanged(object sender, EventArgs e)
    {
        segment03ListUI.Tbl_Segment02Id = ddlSegment02.SelectedItem.Value;
        BindDDLSegment03(segment03ListUI);
    }

    #endregion Events

    #region Methods
    private void FillForm(Segment04FormUI segment04FormUI)
    {
        try
        {
            DataTable dtb = segment04FormBAL.GetSegment04ListById(segment04FormUI);

            if (dtb.Rows.Count > 0)
            {
                txtNumber.Text = dtb.Rows[0]["Number"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();

                ddlSegment03.SelectedValue = dtb.Rows[0]["tbl_Segment03Id"].ToString();

                ddlSegment02.SelectedValue = dtb.Rows[0]["tbl_Segment02Id"].ToString();

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
            logExcpUIobj.ResourceName = "System_Settings_Segment04Form.CS";
            logExcpUIobj.RecordId = segment04FormUI.Tbl_Segment04Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_Segment04Form : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
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
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
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
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
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

    public void BindDDLSegment03(Segment03ListUI segment03ListUI)
    {
        try
        {
            DataTable dtb = segment03ListBAL.GetSegment03ListBySegment02(segment03ListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                ddlSegment03.DataSource = dtb;
                ddlSegment03.DataTextField = "Description";
                ddlSegment03.DataValueField = "tbl_Segment03Id";
                ddlSegment03.DataBind();
                ddlSegment03.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                divError.Visible = false;
            }
            else
            {
                ddlSegment03.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
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

    public void Clear()
    {
        ddlSegment02.Items.Clear();
        ddlSegment03.Items.Clear();
    }
    #endregion Methods

}
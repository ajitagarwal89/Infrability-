using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_Segment10Form : PageBase
{
    #region Data Members

    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    #region Segments
    Segment01ListBAL segment01ListBAL = new Segment01ListBAL();
    Segment02ListBAL segment02ListBAL = new Segment02ListBAL();
    Segment03ListBAL segment03ListBAL = new Segment03ListBAL();
    Segment04ListBAL segment04ListBAL = new Segment04ListBAL();
    Segment05ListBAL segment05ListBAL = new Segment05ListBAL();
    Segment06ListBAL segment06ListBAL = new Segment06ListBAL();
    Segment07ListBAL segment07ListBAL = new Segment07ListBAL();
    Segment08ListBAL segment08ListBAL = new Segment08ListBAL();
    Segment09ListBAL segment09ListBAL = new Segment09ListBAL();

    Segment10FormBAL segment10FormBAL = new Segment10FormBAL();
    Segment10FormUI segment10FormUI = new Segment10FormUI();

    Segment01ListUI segment01ListUI = new Segment01ListUI();
    Segment02ListUI segment02ListUI = new Segment02ListUI();
    Segment03ListUI segment03ListUI = new Segment03ListUI();
    Segment04ListUI segment04ListUI = new Segment04ListUI();
    Segment05ListUI segment05ListUI = new Segment05ListUI();
    Segment06ListUI segment06ListUI = new Segment06ListUI();
    Segment07ListUI segment07ListUI = new Segment07ListUI();
    Segment08ListUI segment08ListUI = new Segment08ListUI();
    Segment09ListUI segment09ListUI = new Segment09ListUI();

    #endregion Segments

    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        Segment10FormUI segment10FormUI = new Segment10FormUI();
        if (!Page.IsPostBack)
        {
            BindDDLSegment01();
            if (Request.QueryString["Segment10Id"] != null)
            {
                segment10FormUI.Tbl_Segment10Id = Request.QueryString["Segment10Id"];
                FillForm(segment10FormUI);
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
            segment10FormUI.CreatedBy = SessionContext.UserGuid;
            segment10FormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            segment10FormUI.Number = txtNumber.Text;
            segment10FormUI.Description = txtDescription.Text;
            segment10FormUI.Tbl_Segment01Id = ddlSegment01.SelectedValue.ToString();
            segment10FormUI.Tbl_Segment02Id = ddlSegment02.SelectedValue.ToString();
            segment10FormUI.Tbl_Segment03Id = ddlSegment03.SelectedValue.ToString();
            segment10FormUI.Tbl_Segment04Id = ddlSegment04.SelectedValue.ToString();
            segment10FormUI.Tbl_Segment05Id = ddlSegment05.SelectedValue.ToString();
            segment10FormUI.Tbl_Segment06Id = ddlSegment06.SelectedValue.ToString();
            segment10FormUI.Tbl_Segment07Id = ddlSegment07.SelectedValue.ToString();
            segment10FormUI.Tbl_Segment08Id = ddlSegment08.SelectedValue.ToString();
            segment10FormUI.Tbl_Segment09Id = ddlSegment09.SelectedValue.ToString();
            if (segment10FormBAL.AddSegment10(segment10FormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_Segment10Form.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_Segment10Form : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Segment10FormUI segment10FormUI = new Segment10FormUI();
        try
        {
            segment10FormUI.ModifiedBy = SessionContext.UserGuid;
            segment10FormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            segment10FormUI.Number = txtNumber.Text;
            segment10FormUI.Description = txtDescription.Text;
            segment10FormUI.Tbl_Segment01Id = ddlSegment01.SelectedValue.ToString();
            segment10FormUI.Tbl_Segment02Id = ddlSegment02.SelectedValue.ToString();
            segment10FormUI.Tbl_Segment03Id = ddlSegment03.SelectedValue.ToString();
            segment10FormUI.Tbl_Segment04Id = ddlSegment04.SelectedValue.ToString();
            segment10FormUI.Tbl_Segment05Id = ddlSegment05.SelectedValue.ToString();
            segment10FormUI.Tbl_Segment06Id = ddlSegment06.SelectedValue.ToString();
            segment10FormUI.Tbl_Segment07Id = ddlSegment07.SelectedValue.ToString();
            segment10FormUI.Tbl_Segment08Id = ddlSegment08.SelectedValue.ToString();
            segment10FormUI.Tbl_Segment09Id = ddlSegment09.SelectedValue.ToString();
            segment10FormUI.Tbl_Segment10Id = Request.QueryString["Segment10Id"];
            if (segment10FormBAL.UpdateSegment10(segment10FormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_Segment10Form.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[System_Settings_Segment10Form : btnUpdate_Click] An error occured in the processing of Record Id : " + segment10FormUI.Tbl_Segment10Id + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            segment10FormUI.Tbl_Segment10Id = Request.QueryString["Segment10Id"];
            if (segment10FormBAL.DeleteSegment10(segment10FormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_Segment10Form.CS";
            logExcpUIobj.RecordId = segment10FormUI.Tbl_Segment10Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[System_Settings_Segment10Form : btnDelete_Click] An error occured in the processing of Record Id : " + segment10FormUI.Tbl_Segment10Id + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Segment10List.aspx");
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

    protected void ddlSegment03_SelectedIndexChanged(object sender, EventArgs e)
    {
        segment04ListUI.Tbl_Segment03Id = ddlSegment03.SelectedItem.Value;
        BindDDLSegment04(segment04ListUI);
    }

    protected void ddlSegment04_SelectedIndexChanged(object sender, EventArgs e)
    {
        segment05ListUI.Tbl_Segment04Id = ddlSegment04.SelectedItem.Value;
        BindDDLSegment05(segment05ListUI);
    }

    protected void ddlSegment05_SelectedIndexChanged(object sender, EventArgs e)
    {
        segment06ListUI.Tbl_Segment05Id = ddlSegment05.SelectedItem.Value;
        BindDDLSegment06(segment06ListUI);
    }

    protected void ddlSegment06_SelectedIndexChanged(object sender, EventArgs e)
    {
        segment07ListUI.Tbl_Segment06Id = ddlSegment06.SelectedItem.Value;
        BindDDLSegment07(segment07ListUI);
    }

    protected void ddlSegment07_SelectedIndexChanged(object sender, EventArgs e)
    {
        segment08ListUI.Tbl_Segment07Id = ddlSegment07.SelectedItem.Value;
        BindDDLSegment08(segment08ListUI);
    }

    protected void ddlSegment08_SelectedIndexChanged(object sender, EventArgs e)
    {
        segment09ListUI.Tbl_Segment08Id = ddlSegment08.SelectedItem.Value;
        BindDDLSegment09(segment09ListUI);
    }
    #endregion Events

    #region Methods
    private void FillForm(Segment10FormUI segment10FormUI)
    {
        try
        {
            DataTable dtb = segment10FormBAL.GetSegment10ListById(segment10FormUI);

            if (dtb.Rows.Count > 0)
            {
                txtNumber.Text = dtb.Rows[0]["Number"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();

                BindDDLSegment01();

                segment02ListUI.Tbl_Segment01Id = dtb.Rows[0]["tbl_Segment01Id"].ToString();
                ddlSegment01.SelectedValue = segment02ListUI.Tbl_Segment01Id;
                BindDDLSegment02(segment02ListUI);

                segment03ListUI.Tbl_Segment02Id = dtb.Rows[0]["tbl_Segment02Id"].ToString();
                ddlSegment02.SelectedValue = segment03ListUI.Tbl_Segment02Id;
                BindDDLSegment03(segment03ListUI);

                segment04ListUI.Tbl_Segment03Id = dtb.Rows[0]["tbl_Segment03Id"].ToString();
                ddlSegment03.SelectedValue = segment04ListUI.Tbl_Segment03Id;
                BindDDLSegment04(segment04ListUI);

                segment05ListUI.Tbl_Segment04Id = dtb.Rows[0]["tbl_Segment04Id"].ToString();
                ddlSegment04.SelectedValue = segment05ListUI.Tbl_Segment04Id;
                BindDDLSegment05(segment05ListUI);

                segment06ListUI.Tbl_Segment05Id = dtb.Rows[0]["tbl_Segment05Id"].ToString();
                ddlSegment05.SelectedValue = segment06ListUI.Tbl_Segment05Id;
                BindDDLSegment06(segment06ListUI);

                segment07ListUI.Tbl_Segment06Id = dtb.Rows[0]["tbl_Segment06Id"].ToString();
                ddlSegment06.SelectedValue = segment07ListUI.Tbl_Segment06Id;
                BindDDLSegment07(segment07ListUI);

                segment08ListUI.Tbl_Segment07Id = dtb.Rows[0]["tbl_Segment07Id"].ToString();
                ddlSegment07.SelectedValue = segment08ListUI.Tbl_Segment07Id;
                BindDDLSegment08(segment08ListUI);

                segment09ListUI.Tbl_Segment08Id = dtb.Rows[0]["tbl_Segment08Id"].ToString();
                ddlSegment08.SelectedValue = segment09ListUI.Tbl_Segment08Id;
                BindDDLSegment09(segment09ListUI);

                ddlSegment09.SelectedValue = dtb.Rows[0]["tbl_Segment09Id"].ToString();

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
            logExcpUIobj.ResourceName = "System_Settings_Segment10Form.CS";
            logExcpUIobj.RecordId = segment10FormUI.Tbl_Segment10Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[System_Settings_Segment10Form : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
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

    public void BindDDLSegment04(Segment04ListUI segment04ListUI)
    {
        try
        {
            DataTable dtb = segment04ListBAL.GetSegment04ListBySegment03(segment04ListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                ddlSegment04.DataSource = dtb;
                ddlSegment04.DataTextField = "Description";
                ddlSegment04.DataValueField = "tbl_Segment04Id";
                ddlSegment04.DataBind();
                ddlSegment04.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));

                divError.Visible = false;
            }
            else
            {
                ddlSegment04.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
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

    public void BindDDLSegment05(Segment05ListUI segment05ListUI)
    {
        try
        {
            DataTable dtb = segment05ListBAL.GetSegment05ListBySegment04(segment05ListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                ddlSegment05.DataSource = dtb;
                ddlSegment05.DataTextField = "Description";
                ddlSegment05.DataValueField = "tbl_Segment05Id";
                ddlSegment05.DataBind();
                ddlSegment05.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                divError.Visible = false;
            }
            else
            {
                ddlSegment05.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
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

    public void BindDDLSegment06(Segment06ListUI segment06ListUI)
    {
        try
        {
            DataTable dtb = segment06ListBAL.GetSegment06ListBySegment05(segment06ListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                ddlSegment06.DataSource = dtb;
                ddlSegment06.DataTextField = "Description";
                ddlSegment06.DataValueField = "tbl_Segment06Id";
                ddlSegment06.DataBind();
                ddlSegment06.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));

                divError.Visible = false;
            }
            else
            {
                ddlSegment06.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
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

    public void BindDDLSegment07(Segment07ListUI segment07ListUI)
    {
        try
        {
            DataTable dtb = segment07ListBAL.GetSegment07ListBySegment06(segment07ListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                ddlSegment07.DataSource = dtb;
                ddlSegment07.DataTextField = "Description";
                ddlSegment07.DataValueField = "tbl_Segment07Id";
                ddlSegment07.DataBind();
                ddlSegment07.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));

                divError.Visible = false;
            }
            else
            {
                ddlSegment07.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
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

    public void BindDDLSegment08(Segment08ListUI segment08ListUI)
    {
        try
        {
            DataTable dtb = segment08ListBAL.GetSegment08ListBySegment07(segment08ListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                ddlSegment08.DataSource = dtb;
                ddlSegment08.DataTextField = "Description";
                ddlSegment08.DataValueField = "tbl_Segment08Id";
                ddlSegment08.DataBind();
                ddlSegment08.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));

                divError.Visible = false;
            }
            else
            {
                ddlSegment08.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
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

    public void BindDDLSegment09(Segment09ListUI segment09ListUI)
    {
        try
        {
            DataTable dtb = segment09ListBAL.GetSegment09ListBySegment08(segment09ListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                ddlSegment09.DataSource = dtb;
                ddlSegment09.DataTextField = "Description";
                ddlSegment09.DataValueField = "tbl_Segment09Id";
                ddlSegment09.DataBind();
                ddlSegment09.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));

                divError.Visible = false;
            }
            else
            {
                ddlSegment09.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
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
        ddlSegment04.Items.Clear();
        ddlSegment05.Items.Clear();
        ddlSegment06.Items.Clear();
        ddlSegment07.Items.Clear();
        ddlSegment08.Items.Clear();
        ddlSegment09.Items.Clear();
    }

    #endregion Methods


}
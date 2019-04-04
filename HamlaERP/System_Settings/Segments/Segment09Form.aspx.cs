using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_Segment09Form : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    Segment01ListBAL segment01ListBAL = new Segment01ListBAL();
    Segment02ListBAL segment02ListBAL = new Segment02ListBAL();
    Segment03ListBAL segment03ListBAL = new Segment03ListBAL();
    Segment04ListBAL segment04ListBAL = new Segment04ListBAL();
    Segment05ListBAL segment05ListBAL = new Segment05ListBAL();
    Segment06ListBAL segment06ListBAL = new Segment06ListBAL();
    Segment07ListBAL segment07ListBAL = new Segment07ListBAL();
    Segment08ListBAL segment08ListBAL = new Segment08ListBAL();

    Segment09FormBAL segment09FormBAL = new Segment09FormBAL();
    Segment09FormUI segment09FormUI = new Segment09FormUI();

    Segment02ListUI segment02ListUI = new Segment02ListUI();
    Segment03ListUI segment03ListUI = new Segment03ListUI();
    Segment04ListUI segment04ListUI = new Segment04ListUI();
    Segment05ListUI segment05ListUI = new Segment05ListUI();
    Segment06ListUI segment06ListUI = new Segment06ListUI();
    Segment07ListUI segment07ListUI = new Segment07ListUI();
    Segment08ListUI segment08ListUI = new Segment08ListUI();

    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        Segment09FormUI segment09FormUI = new Segment09FormUI();
        if (!Page.IsPostBack)
        {
            BindDDLSegment01();
            if (Request.QueryString["Segment09Id"] != null || Request.QueryString["recordId"] != null)
            {
                segment09FormUI.Tbl_Segment09Id = (Request.QueryString["Segment09Id"] != null ? Request.QueryString["Segment09Id"] : Request.QueryString["recordId"]);
                FillForm(segment09FormUI);
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
            segment09FormUI.CreatedBy = SessionContext.UserGuid;
            segment09FormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            segment09FormUI.Number = txtNumber.Text;
            segment09FormUI.Description = txtDescription.Text;
            segment09FormUI.Tbl_Segment01Id = ddlSegment01.SelectedValue.ToString();
            segment09FormUI.Tbl_Segment02Id = ddlSegment02.SelectedValue.ToString();
            segment09FormUI.Tbl_Segment03Id = ddlSegment03.SelectedValue.ToString();
            segment09FormUI.Tbl_Segment04Id = ddlSegment04.SelectedValue.ToString();
            segment09FormUI.Tbl_Segment05Id = ddlSegment05.SelectedValue.ToString();
            segment09FormUI.Tbl_Segment06Id = ddlSegment06.SelectedValue.ToString();
            segment09FormUI.Tbl_Segment07Id = ddlSegment07.SelectedValue.ToString();
            segment09FormUI.Tbl_Segment08Id = ddlSegment08.SelectedValue.ToString();
            if (segment09FormBAL.AddSegment09(segment09FormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_Segment09Form.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_Segment09Form : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Segment09FormUI segment09FormUI = new Segment09FormUI();
        try
        {
            segment09FormUI.ModifiedBy = SessionContext.UserGuid;
            segment09FormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            segment09FormUI.Number = txtNumber.Text;
            segment09FormUI.Description = txtDescription.Text;
            segment09FormUI.Tbl_Segment01Id = ddlSegment01.SelectedValue.ToString();
            segment09FormUI.Tbl_Segment02Id = ddlSegment02.SelectedValue.ToString();
            segment09FormUI.Tbl_Segment03Id = ddlSegment03.SelectedValue.ToString();
            segment09FormUI.Tbl_Segment04Id = ddlSegment04.SelectedValue.ToString();
            segment09FormUI.Tbl_Segment05Id = ddlSegment05.SelectedValue.ToString();
            segment09FormUI.Tbl_Segment06Id = ddlSegment06.SelectedValue.ToString();
            segment09FormUI.Tbl_Segment07Id = ddlSegment07.SelectedValue.ToString();
            segment09FormUI.Tbl_Segment08Id = ddlSegment08.SelectedValue.ToString();
            segment09FormUI.Tbl_Segment09Id = Request.QueryString["Segment09Id"];
            if (segment09FormBAL.UpdateSegment09(segment09FormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_Segment09Form.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[System_Settings_Segment09Form : btnUpdate_Click] An error occured in the processing of Record Id : " + segment09FormUI.Tbl_Segment09Id + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            segment09FormUI.Tbl_Segment09Id = Request.QueryString["Segment09Id"];
            if (segment09FormBAL.DeleteSegment09(segment09FormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_Segment09Form.CS";
            logExcpUIobj.RecordId = segment09FormUI.Tbl_Segment09Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[System_Settings_Segment09Form : btnDelete_Click] An error occured in the processing of Record Id : " + segment09FormUI.Tbl_Segment09Id + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Segment09List.aspx");
    }

    protected void ddlSegment01_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSegment02.Items.Clear();
        segment02ListUI.Tbl_Segment01Id = ddlSegment01.SelectedItem.Value;
        BindDDLSegment02(segment02ListUI);
    }

    protected void ddlSegment02_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSegment03.Items.Clear();
        segment03ListUI.Tbl_Segment02Id = ddlSegment02.SelectedItem.Value;
        BindDDLSegment03(segment03ListUI);
    }

    protected void ddlSegment03_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSegment04.Items.Clear();
        segment04ListUI.Tbl_Segment03Id = ddlSegment03.SelectedItem.Value;
        BindDDLSegment04(segment04ListUI);
    }

    protected void ddlSegment04_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSegment05.Items.Clear();
        segment05ListUI.Tbl_Segment04Id = ddlSegment04.SelectedItem.Value;
        BindDDLSegment05(segment05ListUI);
    }

    protected void ddlSegment05_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSegment06.Items.Clear();
        segment06ListUI.Tbl_Segment05Id = ddlSegment05.SelectedItem.Value;
        BindDDLSegment06(segment06ListUI);
    }

    protected void ddlSegment06_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSegment07.Items.Clear();
        segment07ListUI.Tbl_Segment06Id = ddlSegment06.SelectedItem.Value;
        BindDDLSegment07(segment07ListUI);
    }

    protected void ddlSegment07_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSegment08.Items.Clear();
        segment08ListUI.Tbl_Segment07Id = ddlSegment07.SelectedItem.Value;
        BindDDLSegment08(segment08ListUI);
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/System_Settings/Segments/Segment09Form.aspx";
        string recordId = Request.QueryString["Segment09Id"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    protected void txtNumber_TextChanged(object sender, EventArgs e)
    {
        try
        {
            AccountFormatFormUI accountFormatFormUI = new AccountFormatFormUI();
            AccountFormatFormBAL accountFormatFormBAL = new AccountFormatFormBAL();
            CommonClasses commonClasses = new CommonClasses();
            int segment = 9;
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
    private void FillForm(Segment09FormUI segment09FormUI)
    {
        try
        {
            DataTable dtb = segment09FormBAL.GetSegment09ListById(segment09FormUI);

            if (dtb.Rows.Count > 0)
            {
                txtNumber.Text = dtb.Rows[0]["Number"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                segment02ListUI.Tbl_Segment01Id = dtb.Rows[0]["tbl_Segment01Id"].ToString();
                ddlSegment01.SelectedValue = dtb.Rows[0]["tbl_Segment01Id"].ToString();

                BindDDLSegment02(segment02ListUI);

                ddlSegment02.SelectedValue = dtb.Rows[0]["tbl_Segment02Id"].ToString();
                segment03ListUI.Tbl_Segment02Id = dtb.Rows[0]["tbl_Segment02Id"].ToString();
                BindDDLSegment03(segment03ListUI);
                ddlSegment03.SelectedValue = dtb.Rows[0]["tbl_Segment03Id"].ToString();
                segment04ListUI.Tbl_Segment03Id = dtb.Rows[0]["tbl_Segment03Id"].ToString();
                BindDDLSegment04(segment04ListUI);
                ddlSegment04.SelectedValue = dtb.Rows[0]["tbl_Segment04Id"].ToString();
                segment05ListUI.Tbl_Segment04Id = dtb.Rows[0]["tbl_Segment04Id"].ToString();
                BindDDLSegment05(segment05ListUI);
                ddlSegment05.SelectedValue = dtb.Rows[0]["tbl_Segment05Id"].ToString();
                segment06ListUI.Tbl_Segment05Id = dtb.Rows[0]["tbl_Segment05Id"].ToString();
                BindDDLSegment06(segment06ListUI);
                ddlSegment06.SelectedValue = dtb.Rows[0]["tbl_Segment06Id"].ToString();

                segment07ListUI.Tbl_Segment06Id = dtb.Rows[0]["tbl_Segment06Id"].ToString();
                BindDDLSegment07(segment07ListUI);
                ddlSegment07.SelectedValue = dtb.Rows[0]["tbl_Segment07Id"].ToString();
                segment08ListUI.Tbl_Segment07Id = dtb.Rows[0]["tbl_Segment07Id"].ToString();
                BindDDLSegment08(segment08ListUI);
                ddlSegment08.SelectedValue = dtb.Rows[0]["tbl_Segment08Id"].ToString();


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
            logExcpUIobj.RecordId = segment09FormUI.Tbl_Segment09Id;
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

                ddlSegment02.Items.Clear();
                ddlSegment03.Items.Clear();
                ddlSegment04.Items.Clear();
                ddlSegment05.Items.Clear();
                ddlSegment06.Items.Clear();
                ddlSegment07.Items.Clear();
                ddlSegment08.Items.Clear();
                
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
                
                ddlSegment03.Items.Clear();
                ddlSegment04.Items.Clear();
                ddlSegment05.Items.Clear();
                ddlSegment06.Items.Clear();
                ddlSegment07.Items.Clear();
                ddlSegment08.Items.Clear();

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

                ddlSegment04.Items.Clear();
                ddlSegment05.Items.Clear();
                ddlSegment06.Items.Clear();
                ddlSegment07.Items.Clear();
                ddlSegment08.Items.Clear();

                divError.Visible = false;
            }
            else
            {
                ddlSegment03.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
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

                ddlSegment05.Items.Clear();
                ddlSegment06.Items.Clear();
                ddlSegment07.Items.Clear();
                ddlSegment08.Items.Clear();

                divError.Visible = false;
            }
            else
            {
                ddlSegment04.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
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

                ddlSegment06.Items.Clear();
                ddlSegment07.Items.Clear();
                ddlSegment08.Items.Clear();

                divError.Visible = false;
            }
            else
            {
                ddlSegment05.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
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

                ddlSegment07.Items.Clear();
                ddlSegment08.Items.Clear();

                divError.Visible = false;
            }
            else
            {
                ddlSegment06.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
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

                ddlSegment08.Items.Clear();

                divError.Visible = false;
            }
            else
            {
                ddlSegment07.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
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
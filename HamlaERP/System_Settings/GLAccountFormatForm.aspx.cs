using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_GLAccountFormatForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    GLAccountFormatFormBAL gLAccountFormatFormBAL = new GLAccountFormatFormBAL();
    GLAccountFormatFormUI gLAccountFormatFormUI = new GLAccountFormatFormUI();
    GLAccountFormatDetailsListBAL gLAccountFormatDetailsListBAL = new GLAccountFormatDetailsListBAL();
    GLAccountFormatDetailsFormUI gLAccountFormatDetailsFormUI = new GLAccountFormatDetailsFormUI();
    GLAccountFormatDetailsListUI gLAccountFormatDetailsListUI = new GLAccountFormatDetailsListUI();
    GLAccountFormatDetailsFormBAL gLAccountFormatDetailsFormBAL = new GLAccountFormatDetailsFormBAL();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        GLAccountFormatFormUI gLAccountFormatFormUI = new GLAccountFormatFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["GLAccountFormatId"] != null)
            {
                gLAccountFormatFormUI.Tbl_GLAccountFormatId = Request.QueryString["GLAccountFormatId"];

                BindMainSegmentDropDown();
                BindAccountFormateDetailsList();
                FillForm(gLAccountFormatFormUI);


                //btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                //btnDelete.Visible = true;
                txtMaximumAccount.ReadOnly = true;
                txtMaximumSegmentLength.ReadOnly = true;
                lblHeading.Text = "Update GLAccountFormat";
            }
            else
            {

                BindMainSegmentDropDown();
                // BindList();
                //btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                //btnDelete.Visible = false;
                lblHeading.Text = "Add New GLAccountFormat";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            gLAccountFormatFormUI.CreatedBy = SessionContext.UserGuid;
            gLAccountFormatFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            gLAccountFormatFormUI.MaximumAccountLength = Convert.ToInt32(txtMaximumAccount.Text);
            gLAccountFormatFormUI.AccountLength = Convert.ToInt32(txtAccountLength.Text);
            gLAccountFormatFormUI.MaximumSegmentLength = Convert.ToInt32(txtMaximumSegmentLength.Text);
            gLAccountFormatFormUI.SegmentLength = Convert.ToInt32(txtSegmentLength.Text);
            gLAccountFormatFormUI.MainSegment = int.Parse(ddlMainSegmentId.SelectedValue.ToString());
            gLAccountFormatFormUI.SeparatedBy = txtSeparatedBy.Text;

            if (gLAccountFormatFormBAL.AddGLAccountFormat(gLAccountFormatFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_GLAccountFormatForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountFormatForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        #region GLAccountFormat
        try
        {

            gLAccountFormatFormUI.Tbl_GLAccountFormatId = Request.QueryString["GLAccountFormatId"];
            gLAccountFormatFormUI.ModifiedBy = SessionContext.UserGuid;
            gLAccountFormatFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            gLAccountFormatFormUI.MaximumAccountLength = Convert.ToInt32(txtMaximumAccount.Text);
            gLAccountFormatFormUI.AccountLength = Convert.ToInt32(txtAccountLength.Text);
            gLAccountFormatFormUI.MaximumSegmentLength = Convert.ToInt32(txtMaximumSegmentLength.Text);
            gLAccountFormatFormUI.SegmentLength = Convert.ToInt32(txtSegmentLength.Text);
            gLAccountFormatFormUI.MainSegment = Convert.ToInt32(ddlMainSegmentId.SelectedValue.ToString());
            gLAccountFormatFormUI.SeparatedBy = txtSeparatedBy.Text;


            if (gLAccountFormatFormBAL.UpdateGLAccountFormat(gLAccountFormatFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
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
            logExcpUIobj.ResourceName = "System_Settings_GLAccountFormatForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountFormatForm : btnUpdate_Click] An error occured in the processing of Record Id : " + gLAccountFormatFormUI.Tbl_GLAccountFormatId + ".  Details : [" + exp.ToString() + "]");
        }
        #endregion GLAccountFormat

        #region  GLAccountFormatDetials
        try
        {
            int gvAccountLength = 0;
            for (int i = 0; i < Convert.ToInt32(txtSegmentLength.Text); i++)
            {
                gvAccountLength = gvAccountLength + Convert.ToInt32(((Label)gvData.Rows[i].FindControl("lblLength")).Text);
            }

            if (gvData.Rows.Count > 0 && gvAccountLength <= Convert.ToInt32(txtMaximumAccount.Text) && gvAccountLength <= Convert.ToInt32(txtAccountLength.Text))
            {
                for (int i = 1; i < gvData.Rows.Count; i++)
                {

                    gLAccountFormatDetailsFormUI.ModifiedBy = SessionContext.UserGuid;
                    gLAccountFormatDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                    gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatId = Request.QueryString["GLAccountFormatId"];
                    gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatDetialsId = gvData.DataKeys[i]["tbl_GLAccountFormatDetailsId"].ToString();
                    gLAccountFormatDetailsFormUI.Length = Convert.ToInt32(((Label)gvData.Rows[i].FindControl("lblLength")).Text);

                    if (Convert.ToInt32(txtSegmentLength.Text) > i)
                        gLAccountFormatDetailsFormUI.IsActive = true;
                    else
                    {
                        gLAccountFormatDetailsFormUI.Length = 0;
                        gLAccountFormatDetailsFormUI.IsActive = false;
                    }

                    if (gLAccountFormatDetailsFormBAL.UpdateGLAccountFormatDetailsSegmentLenght(gLAccountFormatDetailsFormUI) == 1)
                    {
                        BindAccountFormateDetailsList();
                        BindSegmentLenght(Convert.ToInt32(txtSegmentLength.Text));
                        divSuccess.Visible = true;
                        divError.Visible = false;
                        lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
                    }
                    else
                    {
                        divError.Visible = true;
                        divSuccess.Visible = false;
                        lblError.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;
                    }
                }
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnGridUpdate_Click()";
            logExcpUIobj.ResourceName = "System_Settings_GLAccountFormatForm.CS";
            logExcpUIobj.RecordId = gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatDetialsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountFormatForm : btnGridUpdate_Click] An error occured in the processing of Record Id : " + gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatDetialsId + ". Details : [" + exp.ToString() + "]");
        }
        #endregion GLAccountFormatDetials
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            gLAccountFormatFormUI.Tbl_GLAccountFormatId = Request.QueryString["GLAccountFormatId"];

            if (gLAccountFormatFormBAL.DeleteGLAccountFormat(gLAccountFormatFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_GLAccountFormatForm.CS";
            logExcpUIobj.RecordId = gLAccountFormatFormUI.Tbl_GLAccountFormatId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountFormatForm : btnDelete_Click] An error occured in the processing of Record Id : " + gLAccountFormatFormUI.Tbl_GLAccountFormatId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtb = new DataTable();
            gLAccountFormatDetailsListUI.Tbl_GLAccountFormatId = Request.QueryString["GLAccountFormatId"];
            dtb = gLAccountFormatDetailsListBAL.GetGLAccountFormatDetailsListByGLAccountFormatId(gLAccountFormatDetailsListUI);

            string exportedFileName = "AccountFormatDetailsList_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            Response.Clear();
            Response.Charset = "";
            Response.ContentType = "application/ms-excel";
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", exportedFileName));
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
            System.Web.UI.WebControls.DataGrid dg = new System.Web.UI.WebControls.DataGrid();

            dg.AllowPaging = false;
            dg.HeaderStyle.BackColor = System.Drawing.Color.RoyalBlue;
            dg.HeaderStyle.ForeColor = System.Drawing.Color.White;

            dg.DataSource = dtb;
            dg.DataBind();
            dg.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "lnkExportToExcel_Click()";
            logExcpUIobj.ResourceName = "System_Settings_InvoiceAndOrderTypeList.CS";
            logExcpUIobj.RecordId = "Export To excel";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_InvoiceAndOrderTypeList : lnkExportToExcel_Click] An error occured in the processing of Records. Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("GLAccountFormatList.aspx");
    }

    protected void txtSegmentLength_TextChanged(object sender, EventArgs e)
    {
        int NoOfRecord = Convert.ToInt32(txtSegmentLength.Text);
        if (NoOfRecord > 0)
        {
            BindSegmentLenght(NoOfRecord);
        }
    }

    #region GvData

    protected void gvData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvData.EditIndex = e.NewEditIndex;
        BindAccountFormateDetailsList();
        BindSegmentLenght(Convert.ToInt32(txtSegmentLength.Text));

    }

    protected void gvData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvData.EditIndex = -1;
        BindAccountFormateDetailsList();
        BindSegmentLenght(Convert.ToInt32(txtSegmentLength.Text));
    }

    protected void gvData_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int gvAccountLength = 0;
        try
        {
            for (int i = 0; i < Convert.ToInt32(txtSegmentLength.Text); i++)
            {
                if (e.RowIndex == i)
                    gvAccountLength = gvAccountLength + Convert.ToInt32(((TextBox)(gvData.Rows[e.RowIndex].FindControl("txtLength"))).Text.Trim());
                else
                    gvAccountLength = gvAccountLength + Convert.ToInt32(((Label)gvData.Rows[i].FindControl("lblLength")).Text);
            }
            if (gvAccountLength <= Convert.ToInt32(txtMaximumAccount.Text) && gvAccountLength <= Convert.ToInt32(txtAccountLength.Text))
            {
                gLAccountFormatDetailsFormUI.ModifiedBy = SessionContext.UserGuid;
                gLAccountFormatDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatId = Request.QueryString["GLAccountFormatId"];
                gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatDetialsId = gvData.DataKeys[e.RowIndex]["tbl_GLAccountFormatDetailsId"].ToString();
                gLAccountFormatDetailsFormUI.Length = Convert.ToInt32(((TextBox)(gvData.Rows[e.RowIndex].FindControl("txtLength"))).Text.Trim());
                gLAccountFormatDetailsFormUI.IsActive = Convert.ToBoolean(((CheckBox)(gvData.Rows[e.RowIndex].FindControl("chkIsAcive"))).Text.Trim());

                if (gLAccountFormatDetailsFormBAL.UpdateGLAccountFormatDetailsSegmentLenght(gLAccountFormatDetailsFormUI) == 1)
                {
                    BindAccountFormateDetailsList();
                    BindSegmentLenght(Convert.ToInt32(txtSegmentLength.Text));
                    divSuccess.Visible = true;
                    divError.Visible = false;
                    lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
                }
                else
                {
                    divError.Visible = true;
                    divSuccess.Visible = false;
                    lblError.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;
                }
            }
            else
            {
                divError.Visible = true;
                divSuccess.Visible = false;
                lblError.Text = "Addition of Length should not greater than Account Length and Maximum Acount length";
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnGridUpdate_Click()";
            logExcpUIobj.ResourceName = "System_Settings_GLAccountFormatForm.CS";
            logExcpUIobj.RecordId = gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatDetialsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountFormatForm : btnGridUpdate_Click] An error occured in the processing of Record Id : " + gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatDetialsId + ". Details : [" + exp.ToString() + "]");
        }

    }



    #endregion  GvData

    #endregion Events

    #region Methods

    private void FillForm(GLAccountFormatFormUI gLAccountFormatFormUI)
    {
        try
        {
            DataTable dtb = gLAccountFormatFormBAL.GetGLAccountFormatListById(gLAccountFormatFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtMaximumAccount.Text = dtb.Rows[0]["MaximumAccountLength"].ToString();
                txtAccountLength.Text = dtb.Rows[0]["AccountLength"].ToString();
                txtMaximumSegmentLength.Text = dtb.Rows[0]["MaximumSegmentLength"].ToString();
                txtSegmentLength.Text = dtb.Rows[0]["SegmentLength"].ToString();
                ddlMainSegmentId.SelectedValue = dtb.Rows[0]["MainSegment"].ToString();
                txtSeparatedBy.Text = dtb.Rows[0]["SeparatedBy"].ToString();
                int NoOfRecord = Convert.ToInt32(txtSegmentLength.Text);
                BindAccountFormateDetailsList();
                BindSegmentLenght(NoOfRecord);
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
            logExcpUIobj.ResourceName = "System_Settings_GLAccountFormatForm.CS";
            logExcpUIobj.RecordId = gLAccountFormatFormUI.Tbl_GLAccountFormatId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountFormatForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindMainSegmentDropDown()
    {
        try
        {
            gLAccountFormatDetailsListUI.Tbl_GLAccountFormatId = Request.QueryString["GLAccountFormatId"];
            DataTable dtb = gLAccountFormatDetailsListBAL.GetGLAccountFormatDetailsListByGLAccountFormatId(gLAccountFormatDetailsListUI);

            if (dtb.Rows.Count > 0)
            {
                ddlMainSegmentId.DataSource = dtb;
                ddlMainSegmentId.DataBind();

                ddlMainSegmentId.DataTextField = "SegmentName";
                ddlMainSegmentId.DataValueField = "SequenceNumber";
                ddlMainSegmentId.DataBind();
            }
            else
            {
                ddlMainSegmentId.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindMainSegmentDropDown()";
            logExcpUIobj.ResourceName = "System_Settings_OrganizationForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountFormatForm : BindMainSegmentDropDown] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindAccountFormateDetailsList()
    {
        try
        {
            gLAccountFormatDetailsListUI.Tbl_GLAccountFormatId = Request.QueryString["GLAccountFormatId"];
            DataTable dtb = gLAccountFormatDetailsListBAL.GetGLAccountFormatDetailsListByGLAccountFormatId(gLAccountFormatDetailsListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvData.DataSource = dtb;
                gvData.DataBind();
                divError.Visible = false;
                gvData.Visible = true;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvData.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "System_Settings_GLAccountFormatList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountFormatList : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void SegmentVal()
    {
        try
        {
            gLAccountFormatDetailsListUI.Tbl_GLAccountFormatId = Request.QueryString["GLAccountFormatId"];
            DataTable dtb = gLAccountFormatDetailsListBAL.GetGLAccountFormatDetailsListByGLAccountFormatId(gLAccountFormatDetailsListUI);

            if (dtb.Rows.Count > 0)
            {

                gvData.DataSource = dtb;
                gvData.DataBind();
                divError.Visible = false;
                gvData.Visible = true;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvData.Visible = false;
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "txtSegmentLength_TextChanged()";
            logExcpUIobj.ResourceName = "System_Settings_GLAccountFormatForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountFormatForm : txtSegmentLength_TextChanged] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void BindSegmentLenght(int NoOfRecord)
    {
        try
        {
            gLAccountFormatDetailsListUI.Tbl_GLAccountFormatId = Request.QueryString["GLAccountFormatId"];
            DataTable dtb = gLAccountFormatDetailsListBAL.GetGLAccountFormatDetailsListByGLAccountFormatId(gLAccountFormatDetailsListUI);
            gvData.DataSource = dtb;
            gvData.DataBind();
            for (int i = 0; i < gvData.Rows.Count; i++)
            {
                if (NoOfRecord > i)
                {
                    gvData.Rows[i].Visible = true;
                    ddlMainSegmentId.Items[i].Enabled = true;
                }
                else
                {
                    gvData.Rows[i].Visible = false;
                    ddlMainSegmentId.Items[i].Enabled = false;
                }
            }
            txtSegmentLength.Focus();

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "txtSegmentLength_TextChanged()";
            logExcpUIobj.ResourceName = "System_Settings_GLAccountFormatForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountFormatForm : txtSegmentLength_TextChanged] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    #endregion Methods

}


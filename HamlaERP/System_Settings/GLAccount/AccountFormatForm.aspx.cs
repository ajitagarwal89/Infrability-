using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_AccountFormatForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    AccountFormatFormBAL accountFormatFormBAL = new AccountFormatFormBAL();
    AccountFormatFormUI accountFormatFormUI = new AccountFormatFormUI();
    AccountFormatDetailsListBAL accountFormatDetailsListBAL = new AccountFormatDetailsListBAL();
    AccountFormatDetailsFormUI accountFormatDetailsFormUI = new AccountFormatDetailsFormUI();
    AccountFormatDetailsListUI accountFormatDetailsListUI = new AccountFormatDetailsListUI();
    AccountFormatDetailsFormBAL accountFormatDetailsFormBAL = new AccountFormatDetailsFormBAL();
    string accountFormatId = null;
    #endregion Data Members

    #region Events

    protected override void Page_Load(object sender, EventArgs e)
    {
        AccountFormatFormUI accountFormatFormUI = new AccountFormatFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["AccountFormatId"] != null || Request.QueryString["recordId"] != null)
            {
                accountFormatFormUI.Tbl_AccountFormatId = (Request.QueryString["AccountFormatId"] != null ? Request.QueryString["AccountFormatId"] : Request.QueryString["recordId"]);

                BindMainSegmentDropDown();
                BindAccountFormateDetailsList();
                FillForm(accountFormatFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                txtMaximumAccountLength.ReadOnly = true;
                txtMaximumSegment.ReadOnly = true;
                lblHeading.Text = "Update AccountFormat";
            }
            else
            {

                BindMainSegmentDropDown();
                // BindList();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                txtMaximumAccountLength.Text = "66";

                txtMaximumAccountLength.ReadOnly = true;
                txtMaximumSegment.Text = "10";
                txtMaximumSegment.ReadOnly = true;
                lblHeading.Text = "Add New AccountFormat";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        UpdateData();

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        #region AccountFormat
        try
        {
            if (Request.QueryString["AccountFormatId"] != null)
            { accountFormatFormUI.Tbl_AccountFormatId = Request.QueryString["AccountFormatId"]; }
            else { accountFormatFormUI.Tbl_AccountFormatId = Convert.ToString(HttpContext.Current.Session["AccountFormatId"]); }
            accountFormatFormUI.ModifiedBy = SessionContext.UserGuid;
            accountFormatFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            accountFormatFormUI.MaximumAccountLength = Convert.ToInt32(txtMaximumAccountLength.Text);
            accountFormatFormUI.AccountLength = Convert.ToInt32(txtAccountLength.Text);
            accountFormatFormUI.MaximumSegment = Convert.ToInt32(txtMaximumSegment.Text);
            accountFormatFormUI.Segment = Convert.ToInt32(txtSegment.Text);
            accountFormatFormUI.MainSegment = Convert.ToInt32(ddlMainSegmentId.SelectedValue.ToString());
            accountFormatFormUI.SeparatedBy = txtSeparatedBy.Text;


            if (accountFormatFormBAL.UpdateAccountFormat(accountFormatFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_AccountFormatForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AccountFormatForm : btnUpdate_Click] An error occured in the processing of Record Id : " + accountFormatFormUI.Tbl_AccountFormatId + ".  Details : [" + exp.ToString() + "]");
        }
        #endregion AccountFormat

        #region  AccountFormatDetials
        try
        {
            int gvAccountLength = 0;
            for (int i = 0; i < Convert.ToInt32(txtSegment.Text); i++)
            {
                gvAccountLength = gvAccountLength + Convert.ToInt32(((Label)gvData.Rows[i].FindControl("lblLength")).Text);
            }

            if (gvData.Rows.Count > 0 && gvAccountLength <= Convert.ToInt32(txtMaximumAccountLength.Text) && gvAccountLength <= Convert.ToInt32(txtAccountLength.Text))
            {
                for (int i = 1; i < gvData.Rows.Count; i++)
                {

                    accountFormatDetailsFormUI.ModifiedBy = SessionContext.UserGuid;
                    accountFormatDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                    accountFormatDetailsFormUI.Tbl_AccountFormatId = Request.QueryString["AccountFormatId"];
                    accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId = gvData.DataKeys[i]["tbl_AccountFormatDetailsId"].ToString();
                    accountFormatDetailsFormUI.Length = Convert.ToInt32(((Label)gvData.Rows[i].FindControl("lblLength")).Text);

                    if (Convert.ToInt32(txtSegment.Text) > i)
                        accountFormatDetailsFormUI.IsActive = true;
                    else
                    {
                        accountFormatDetailsFormUI.Length = 0;
                        accountFormatDetailsFormUI.IsActive = false;
                    }

                    if (accountFormatDetailsFormBAL.UpdateAccountFormatDetailsSegmentLenght(accountFormatDetailsFormUI) == 1)
                    {
                        BindAccountFormateDetailsList();
                        BindSegmentLenght(Convert.ToInt32(txtSegment.Text));
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
            logExcpUIobj.ResourceName = "System_Settings_AccountFormatForm.CS";
            logExcpUIobj.RecordId = accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AccountFormatForm : btnGridUpdate_Click] An error occured in the processing of Record Id : " + accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId + ". Details : [" + exp.ToString() + "]");
        }
        #endregion AccountFormatDetials
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        DeleteData();
        AccountFormatDetails_DeleteByAccountFormatId();
    }

    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtb = new DataTable();
            accountFormatDetailsListUI.Tbl_AccountFormatId = Request.QueryString["AccountFormatId"];
            dtb = accountFormatDetailsListBAL.GetAccountFormatDetailsListByAccountFormatId(accountFormatDetailsListUI);

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
        Response.Redirect("AccountFormatList.aspx");
    }

    protected void txtMaximumAccountLength_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int maximumAccountLenght = Convert.ToInt32(txtMaximumAccountLength.Text);
            if (maximumAccountLenght <= 66)
            {
                txtMaximumAccountLength.Text.ToString();
            }
            else
            {
                txtMaximumAccountLength.Text = string.Empty;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "txtMaximumAccountLength_TextChanged()";
            logExcpUIobj.ResourceName = "System_Settings_AccountFormatForm.CS";
            logExcpUIobj.RecordId = accountFormatFormUI.Tbl_AccountFormatId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AccountFormatForm : txtMaximumAccountLength_TextChanged] An error occured in the processing of Record Id : " + accountFormatFormUI.Tbl_AccountFormatId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void txtAccountLength_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int accountLength = Convert.ToInt32(txtAccountLength.Text);
            int maximumAccountLenght = Convert.ToInt32(txtMaximumAccountLength.Text);
            if (maximumAccountLenght >= accountLength)
            {
                txtAccountLength.Text.ToString();
            }
            else
            {
                txtAccountLength.Text = string.Empty;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "txtAccountLength_TextChanged()";
            logExcpUIobj.ResourceName = "System_Settings_AccountFormatForm.CS";
            logExcpUIobj.RecordId = accountFormatFormUI.Tbl_AccountFormatId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AccountFormatForm : txtAccountLength_TextChanged] An error occured in the processing of Record Id : " + accountFormatFormUI.Tbl_AccountFormatId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void txtMaximumSegment_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int MaximumSegment = Convert.ToInt32(txtMaximumSegment.Text);
            if (MaximumSegment <= 10)
            {
                txtMaximumSegment.Text.ToString();
            }
            else
            {
                txtMaximumSegment.Text = string.Empty;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "txtMaximumSegment_TextChanged()";
            logExcpUIobj.ResourceName = "System_Settings_AccountFormatForm.CS";
            logExcpUIobj.RecordId = accountFormatFormUI.Tbl_AccountFormatId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AccountFormatForm : txtMaximumSegment_TextChanged] An error occured in the processing of Record Id : " + accountFormatFormUI.Tbl_AccountFormatId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void txtSegment_TextChanged(object sender, EventArgs e)
    {

        try
        {
            int segment = Convert.ToInt32(txtSegment.Text);
            int NoOfRecord = Convert.ToInt32(txtSegment.Text);
            if (Convert.ToInt32(txtAccountLength.Text) > 0 && Convert.ToInt32(txtAccountLength.Text) <= Convert.ToInt32(txtMaximumAccountLength.Text) && (txtSeparatedBy.Text) != "")
            {
                if (segment <= Convert.ToInt32(txtMaximumSegment.Text))
                {
                    if (Request.QueryString["AccountFormatId"] != null)
                    {
                        #region AccountFormat
                        try
                        {
                            DataTable dtd = bindGridView();

                            gvData.DataSource = dtd;
                            gvData.DataBind();
                            DeleteData();

                            AccountFormatDetails_DeleteByAccountFormatId();

                            SaveData();

                        }
                        catch (Exception exp)
                        {
                            logExcpUIobj.MethodName = "txtSegment_TextChanged()";
                            logExcpUIobj.ResourceName = "System_Settings_AccountFormatForm.CS";
                            logExcpUIobj.RecordId = "";
                            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                            log.Error("[System_Settings_AccountFormatForm : btnUpdate_Click] An error occured in the processing of Record Id : " + accountFormatFormUI.Tbl_AccountFormatId + ".  Details : [" + exp.ToString() + "]");
                        }


                        try
                        {
                            if (Convert.ToInt32(txtSegment.Text) == gvData.Rows.Count)
                            {
                                if (Request.QueryString["AccountFormatId"] != null)
                                { accountFormatFormUI.Tbl_AccountFormatId = Request.QueryString["AccountFormatId"]; }
                                else { accountFormatFormUI.Tbl_AccountFormatId = Convert.ToString(HttpContext.Current.Session["AccountFormatId"]); }
                                accountFormatFormUI.ModifiedBy = SessionContext.UserGuid;
                                accountFormatFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

                                accountFormatFormUI.MaximumAccountLength = Convert.ToInt32(txtMaximumAccountLength.Text);
                                accountFormatFormUI.AccountLength = Convert.ToInt32(txtAccountLength.Text);
                                accountFormatFormUI.MaximumSegment = Convert.ToInt32(txtMaximumSegment.Text);
                                accountFormatFormUI.Segment = Convert.ToInt32(txtSegment.Text);
                                accountFormatFormUI.MainSegment = Convert.ToInt32(ddlMainSegmentId.SelectedValue.ToString());
                                accountFormatFormUI.SeparatedBy = txtSeparatedBy.Text;


                                if (accountFormatFormBAL.UpdateAccountFormat(accountFormatFormUI) == 1)
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
                        }
                        catch (Exception exp)
                        {
                            logExcpUIobj.MethodName = "btnUpdate_Click()";
                            logExcpUIobj.ResourceName = "System_Settings_AccountFormatForm.CS";
                            logExcpUIobj.RecordId = "";
                            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                            log.Error("[System_Settings_AccountFormatForm : btnUpdate_Click] An error occured in the processing of Record Id : " + accountFormatFormUI.Tbl_AccountFormatId + ".  Details : [" + exp.ToString() + "]");
                        }
                        #endregion AccountFormat

                        #region  AccountFormatDetials
                        try
                        {
                            int gvAccountLength = 0;
                            for (int i = 0; i < Convert.ToInt32(txtSegment.Text); i++)
                            {
                                gvAccountLength = gvAccountLength + Convert.ToInt32(((Label)gvData.Rows[i].FindControl("lblLength")).Text);
                            }

                            if (gvData.Rows.Count > 0 && gvAccountLength <= Convert.ToInt32(txtMaximumAccountLength.Text) && gvAccountLength <= Convert.ToInt32(txtAccountLength.Text))
                            {
                                for (int i = 1; i < gvData.Rows.Count; i++)
                                {

                                    accountFormatDetailsFormUI.ModifiedBy = SessionContext.UserGuid;
                                    accountFormatDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                                    accountFormatDetailsFormUI.Tbl_AccountFormatId = Request.QueryString["AccountFormatId"];
                                    accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId = gvData.DataKeys[i]["tbl_AccountFormatDetailsId"].ToString();
                                    accountFormatDetailsFormUI.Length = Convert.ToInt32(((Label)gvData.Rows[i].FindControl("lblLength")).Text);

                                    if (Convert.ToInt32(txtSegment.Text) > i)
                                        accountFormatDetailsFormUI.IsActive = true;
                                    else
                                    {
                                        accountFormatDetailsFormUI.Length = 0;
                                        accountFormatDetailsFormUI.IsActive = false;
                                    }

                                    if (accountFormatDetailsFormBAL.UpdateAccountFormatDetailsSegmentLenght(accountFormatDetailsFormUI) == 1)
                                    {
                                        BindAccountFormateDetailsList();
                                        BindSegmentLenght(Convert.ToInt32(txtSegment.Text));
                                        divSuccess.Visible = true;
                                        divError.Visible = false;
                                        btnUpdate.Visible = false;
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
                            logExcpUIobj.ResourceName = "System_Settings_AccountFormatForm.CS";
                            logExcpUIobj.RecordId = accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId;
                            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                            log.Error("[System_Settings_AccountFormatForm : btnGridUpdate_Click] An error occured in the processing of Record Id : " + accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId + ". Details : [" + exp.ToString() + "]");
                        }
                        #endregion AccountFormatDetials

                    }
                    else if (HttpContext.Current.Session["AccountFormatId"] != null)
                    {
                        DataTable dtd = bindGridView();
                        if (gvData.Rows.Count > 0)
                        {
                            if (gvData.Rows.Count > dtd.Rows.Count)
                            {
                                gvData.DataSource = dtd;
                                gvData.DataBind();
                                DeleteData();
                                AccountFormatDetails_DeleteByAccountFormatId();
                                SaveData();
                                BindMainSegmentDropDown();
                            }
                            else
                            {
                                gvData.DataSource = dtd;
                                gvData.DataBind();
                                BindMainSegmentDropDown();
                            }
                        }
                        else
                        {

                            gvData.DataSource = dtd;
                            gvData.DataBind();
                            SaveData();
                            BindMainSegmentDropDown();
                        }
                    }
                    else
                    {
                        DataTable dtd = bindGridView();
                        gvData.DataSource = dtd;
                        gvData.DataBind();
                        SaveData();
                        BindMainSegmentDropDown();

                    }
                }
                else
                    txtSegment.Text = "";
            }
            else
            {
                string alertMag = Resources.GlobalResource.msgTextRequired;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('AccontLength and SeparatedBy can not be Empty');", true);

            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "txtSegment_TextChanged()";
            logExcpUIobj.ResourceName = "System_Settings_AccountFormatForm.CS";
            logExcpUIobj.RecordId = accountFormatFormUI.Tbl_AccountFormatId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AccountFormatForm : txtSegment_TextChanged] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string form = "/System_Settings/GLAccount/AccountFormatForm.aspx";
        string recordId = Request.QueryString["AccountFormatId"];
        Response.Redirect("~/System_Settings/Audit/AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + form);
    }


    #region GvData

    protected void gvData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvData.EditIndex = e.NewEditIndex;
        BindAccountFormateDetailsList();
        BindSegmentLenght(Convert.ToInt32(txtSegment.Text));

    }

    protected void gvData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvData.EditIndex = -1;
        BindAccountFormateDetailsList();
        BindSegmentLenght(Convert.ToInt32(txtSegment.Text));
    }

    protected void gvData_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int gvAccountLength = 0;
        try
        {
            //for (int i = 0; i < Convert.ToInt32(txtSegment.Text); i++)
            //{
            //    if (e.RowIndex == i)
            //        gvAccountLength = gvAccountLength + Convert.ToInt32(((TextBox)(gvData.Rows[e.RowIndex].FindControl("txtLength"))).Text.Trim());
            //    else
            //        gvAccountLength = gvAccountLength + Convert.ToInt32(((Label)gvData.Rows[i].FindControl("lblLength")).Text);
            //}
            if (gvAccountLength <= Convert.ToInt32(txtMaximumAccountLength.Text) || gvAccountLength <= Convert.ToInt32(txtAccountLength.Text))
            {
                accountFormatDetailsFormUI.ModifiedBy = SessionContext.UserGuid;
                accountFormatDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                if (Request.QueryString["AccountFormatId"] != null)
                { accountFormatDetailsFormUI.Tbl_AccountFormatId = Request.QueryString["AccountFormatId"]; }

                else { accountFormatDetailsFormUI.Tbl_AccountFormatId = Convert.ToString(HttpContext.Current.Session["AccountFormatId"]); }

                accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId = gvData.DataKeys[e.RowIndex]["tbl_AccountFormatDetailsId"].ToString();
                accountFormatDetailsFormUI.SequenceNumber = Convert.ToInt32(((Label)(gvData.Rows[e.RowIndex].FindControl("lblSequenceNumber"))).Text.Trim());
                accountFormatDetailsFormUI.SegmentNumber = Convert.ToInt32(((Label)(gvData.Rows[e.RowIndex].FindControl("lblSegmentNumber"))).Text.Trim());
                accountFormatDetailsFormUI.SegmentName = Convert.ToString(((Label)(gvData.Rows[e.RowIndex].FindControl("lblSegmentName"))).Text.Trim());
                accountFormatDetailsFormUI.MaxLength = Convert.ToInt32(((Label)(gvData.Rows[e.RowIndex].FindControl("lblMaxLength"))).Text.Trim());
                accountFormatDetailsFormUI.Length = Convert.ToInt32(((TextBox)(gvData.Rows[e.RowIndex].FindControl("txtLength"))).Text.Trim());
                accountFormatDetailsFormUI.IsActive = Convert.ToBoolean(((CheckBox)(gvData.Rows[e.RowIndex].FindControl("chkIsAcive"))).Text.Trim());

                if (accountFormatDetailsFormBAL.UpdateAccountFormatDetailsSegmentLenght(accountFormatDetailsFormUI) == 1)
                {
                    BindAccountFormateDetailsList();
                    BindSegmentLenght(Convert.ToInt32(txtSegment.Text));
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
            logExcpUIobj.ResourceName = "System_Settings_AccountFormatForm.CS";
            logExcpUIobj.RecordId = accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AccountFormatForm : btnGridUpdate_Click] An error occured in the processing of Record Id : " + accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId + ". Details : [" + exp.ToString() + "]");
        }

    }

    #endregion  GvData

    #endregion Events

    #region Methods

    private void FillForm(AccountFormatFormUI accountFormatFormUI)
    {
        try
        {
            DataTable dtb = accountFormatFormBAL.GetAccountFormatListById(accountFormatFormUI);

            if (dtb.Rows.Count > 0)
            {

                txtMaximumAccountLength.Text = dtb.Rows[0]["MaximumAccountLength"].ToString();
                txtAccountLength.Text = dtb.Rows[0]["AccountLength"].ToString();
                txtMaximumSegment.Text = dtb.Rows[0]["MaximumSegment"].ToString();
                txtSegment.Text = dtb.Rows[0]["Segment"].ToString();
                txtSeparatedBy.Text = dtb.Rows[0]["SeparatedBy"].ToString();
                int NoOfRecord = Convert.ToInt32(txtSegment.Text);
                ddlMainSegmentId.SelectedValue = dtb.Rows[0]["MainSegmentName"].ToString();
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
            logExcpUIobj.ResourceName = "System_Settings_AccountFormatForm.CS";
            logExcpUIobj.RecordId = accountFormatFormUI.Tbl_AccountFormatId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AccountFormatForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindMainSegmentDropDown()
    {
        try
        {
            if (Request.QueryString["AccountFormatId"] != null)
            {
                accountFormatDetailsListUI.Tbl_AccountFormatId = Request.QueryString["AccountFormatId"];
                DataTable dtb = accountFormatDetailsListBAL.GetAccountFormatDetailsListByAccountFormatId(accountFormatDetailsListUI);

                if (dtb.Rows.Count > 0)
                {
                    ddlMainSegmentId.Items.Clear();
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
            else
            {
                accountFormatDetailsListUI.Tbl_AccountFormatId = Convert.ToString(HttpContext.Current.Session["AccountFormatId"]);
                DataTable dtb = accountFormatDetailsListBAL.GetAccountFormatDetailsListByAccountFormatId(accountFormatDetailsListUI);

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
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindMainSegmentDropDown()";
            logExcpUIobj.ResourceName = "System_Settings_OrganizationForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AccountFormatForm : BindMainSegmentDropDown] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindAccountFormateDetailsList()
    {
        try
        {
            if (Request.QueryString["AccountFormatId"] != null)
            {
                accountFormatDetailsListUI.Tbl_AccountFormatId = Request.QueryString["AccountFormatId"];
                DataTable dtb = accountFormatDetailsListBAL.GetAccountFormatDetailsListByAccountFormatId(accountFormatDetailsListUI);

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
            else
            {
                accountFormatDetailsListUI.Tbl_AccountFormatId = Convert.ToString(HttpContext.Current.Session["AccountFormatId"]);
                DataTable dtb = accountFormatDetailsListBAL.GetAccountFormatDetailsListByAccountFormatId(accountFormatDetailsListUI);

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
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "System_Settings_AccountFormatList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AccountFormatList : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void SegmentVal()
    {
        try
        {
            if (Request.QueryString["AccountFormatId"] != null)
            {
                accountFormatDetailsListUI.Tbl_AccountFormatId = Request.QueryString["AccountFormatId"];
                DataTable dtb = accountFormatDetailsListBAL.GetAccountFormatDetailsListByAccountFormatId(accountFormatDetailsListUI);

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
            else
            {
                accountFormatDetailsListUI.Tbl_AccountFormatId = Convert.ToString(HttpContext.Current.Session["AccountFormatId"]);
                DataTable dtb = accountFormatDetailsListBAL.GetAccountFormatDetailsListByAccountFormatId(accountFormatDetailsListUI);

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


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "txtSegment_TextChanged()";
            logExcpUIobj.ResourceName = "System_Settings_AccountFormatForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AccountFormatForm : txtSegment_TextChanged] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void BindSegmentLenght(int NoOfRecord)
    {
        try
        {
            if (Request.QueryString["AccountFormatId"] != null)
            {
                accountFormatDetailsListUI.Tbl_AccountFormatId = Request.QueryString["AccountFormatId"];
                DataTable dtb = accountFormatDetailsListBAL.GetAccountFormatDetailsListByAccountFormatId(accountFormatDetailsListUI);
                gvData.DataSource = dtb;
                gvData.DataBind();
                for (int i = 0; i < gvData.Rows.Count; i++)
                {
                    if (NoOfRecord > i)
                    {
                        gvData.Rows[i].Visible = true;
                        //  ddlMainSegmentId.Items[i].Enabled = true;
                    }
                    else
                    {
                        gvData.Rows[i].Visible = false;
                        // ddlMainSegmentId.Items[i].Enabled = false;
                    }
                }
                txtSegment.Focus();
            }
            else
            {
                accountFormatDetailsListUI.Tbl_AccountFormatId = Convert.ToString(HttpContext.Current.Session["AccountFormatId"]);
                DataTable dtb = accountFormatDetailsListBAL.GetAccountFormatDetailsListByAccountFormatId(accountFormatDetailsListUI);
                gvData.DataSource = dtb;
                gvData.DataBind();
                for (int i = 0; i < gvData.Rows.Count; i++)
                {
                    if (NoOfRecord > i)
                    {
                        gvData.Rows[i].Visible = true;
                        //  ddlMainSegmentId.Items[i].Enabled = true;
                    }
                    else
                    {
                        gvData.Rows[i].Visible = false;
                        // ddlMainSegmentId.Items[i].Enabled = false;
                    }
                }
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "txtSegment_TextChanged()";
            logExcpUIobj.ResourceName = "System_Settings_AccountFormatForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AccountFormatForm : txtSegment_TextChanged] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public DataTable bindGridView()
    {
        int record = Convert.ToInt32(txtSegment.Text);

        DataTable dt = new DataTable();
        dt.Columns.Add("SequenceNumber", typeof(int));
        dt.Columns.Add("SegmentNumber", typeof(int));
        dt.Columns.Add("SegmentName", typeof(string)).ToString();
        dt.Columns.Add("MaxLength", typeof(int));
        dt.Columns.Add("Length", typeof(int));
        dt.Columns.Add("IsActive", typeof(Boolean));
        dt.Columns.Add("tbl_AccountFormatDetailsId", typeof(string));

        for (int count = 1; count <= record; count++)
        {
            if (count < 10)
            {
                dt.Rows.Add(count, txtMaximumAccountLength.Text, "Segment0" + count, txtMaximumSegment.Text, txtAccountLength.Text, true, "00000000-0000-0000-0000-000000000001");
            }
            else { dt.Rows.Add(count, txtMaximumAccountLength.Text, "Segment" + count, txtMaximumSegment.Text, txtAccountLength.Text, true, "00000000-0000-0000-0000-000000000001"); }
        }
        return dt;

    }

    public void SaveData()
    {
        try
        {

            accountFormatFormUI.CreatedBy = SessionContext.UserGuid;
            accountFormatFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            accountFormatFormUI.MaximumAccountLength = Convert.ToInt32(txtMaximumAccountLength.Text);
            accountFormatFormUI.AccountLength = Convert.ToInt32(txtAccountLength.Text);
            accountFormatFormUI.MaximumSegment = Convert.ToInt32(txtMaximumSegment.Text);
            accountFormatFormUI.Segment = Convert.ToInt32(txtSegment.Text);

            if (ddlMainSegmentId.SelectedIndex > 0)
            { accountFormatFormUI.MainSegment = int.Parse(ddlMainSegmentId.SelectedValue.ToString()); }

            accountFormatFormUI.SeparatedBy = txtSeparatedBy.Text;

            if (accountFormatFormBAL.AddAccountFormat(accountFormatFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                string session = HttpContext.Current.Session["AccountFormatId"].ToString();
                if (session != "")
                {
                    foreach (GridViewRow row in gvData.Rows)
                    {
                        accountFormatDetailsFormUI.CreatedBy = SessionContext.UserGuid;
                        accountFormatDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                        accountFormatDetailsFormUI.Tbl_AccountFormatId = Convert.ToString(HttpContext.Current.Session["AccountFormatId"]);
                        accountFormatDetailsFormUI.SequenceNumber = Convert.ToInt32(((Label)row.FindControl("lblSequenceNumber")).Text);
                        accountFormatDetailsFormUI.SegmentNumber = Convert.ToInt32(((Label)row.FindControl("lblSegmentNumber")).Text);
                        accountFormatDetailsFormUI.SegmentName = Convert.ToString(((Label)row.FindControl("lblSegmentName")).Text);
                        accountFormatDetailsFormUI.MaxLength = Convert.ToInt32(((Label)row.FindControl("lblMaxLength")).Text);
                        accountFormatDetailsFormUI.Length = Convert.ToInt32(((Label)row.FindControl("lblLength")).Text);
                        accountFormatDetailsFormUI.IsActive = false;
                        if (accountFormatDetailsFormBAL.AddAccountFormatDetails(accountFormatDetailsFormUI) == 1)
                        {
                            divSuccess.Visible = true;
                            lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                        }
                        else
                        {
                            lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
                            divError.Visible = true;

                        }


                    }

                    accountFormatFormUI.Tbl_AccountFormatId = Convert.ToString(HttpContext.Current.Session["AccountFormatId"]);
                    Request.QueryString.Clear();
                    FillForm(accountFormatFormUI);
                    //gvAccountFormatDetails.Visible = false;
                    //  lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
                }
                else
                {
                    gvData.DataSource = null;
                    gvData.DataBind();
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
                }
            }
            else
            {

                divError.Visible = true;
                divSuccess.Visible = false;
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
                //  this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);

            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "System_Settings_AccountFormatForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AccountFormatForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    public void UpdateData()
    {
        #region AccountFormat
        try
        {
            if (Request.QueryString["AccountFormatId"] != null)
            { accountFormatFormUI.Tbl_AccountFormatId = Request.QueryString["AccountFormatId"]; }
            else { accountFormatFormUI.Tbl_AccountFormatId = Convert.ToString(HttpContext.Current.Session["AccountFormatId"]); }
            accountFormatFormUI.ModifiedBy = SessionContext.UserGuid;
            accountFormatFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            accountFormatFormUI.MaximumAccountLength = Convert.ToInt32(txtMaximumAccountLength.Text);
            accountFormatFormUI.AccountLength = Convert.ToInt32(txtAccountLength.Text);
            accountFormatFormUI.MaximumSegment = Convert.ToInt32(txtMaximumSegment.Text);
            accountFormatFormUI.Segment = Convert.ToInt32(txtSegment.Text);
            accountFormatFormUI.MainSegment = Convert.ToInt32(ddlMainSegmentId.SelectedValue.ToString());
            accountFormatFormUI.SeparatedBy = txtSeparatedBy.Text;


            if (accountFormatFormBAL.UpdateAccountFormat(accountFormatFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_AccountFormatForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AccountFormatForm : btnUpdate_Click] An error occured in the processing of Record Id : " + accountFormatFormUI.Tbl_AccountFormatId + ".  Details : [" + exp.ToString() + "]");
        }
        #endregion AccountFormat

        #region  AccountFormatDetials
        try
        {
            int gvAccountLength = 0;
            for (int i = 0; i < Convert.ToInt32(txtSegment.Text); i++)
            {
                gvAccountLength = gvAccountLength + Convert.ToInt32(((Label)gvData.Rows[i].FindControl("lblLength")).Text);
            }

            if (gvData.Rows.Count > 0 && gvAccountLength <= Convert.ToInt32(txtMaximumAccountLength.Text) && gvAccountLength <= Convert.ToInt32(txtAccountLength.Text))
            {
                for (int i = 1; i < gvData.Rows.Count; i++)
                {

                    accountFormatDetailsFormUI.ModifiedBy = SessionContext.UserGuid;
                    accountFormatDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                    accountFormatDetailsFormUI.Tbl_AccountFormatId = Request.QueryString["AccountFormatId"];
                    accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId = gvData.DataKeys[i]["tbl_AccountFormatDetailsId"].ToString();
                    accountFormatDetailsFormUI.Length = Convert.ToInt32(((Label)gvData.Rows[i].FindControl("lblLength")).Text);

                    if (Convert.ToInt32(txtSegment.Text) > i)
                        accountFormatDetailsFormUI.IsActive = true;
                    else
                    {
                        accountFormatDetailsFormUI.Length = 0;
                        accountFormatDetailsFormUI.IsActive = false;
                    }

                    if (accountFormatDetailsFormBAL.UpdateAccountFormatDetailsSegmentLenght(accountFormatDetailsFormUI) == 1)
                    {
                        BindAccountFormateDetailsList();
                        BindSegmentLenght(Convert.ToInt32(txtSegment.Text));
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
        #endregion  AccountFormatDetials
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnGridUpdate_Click()";
            logExcpUIobj.ResourceName = "System_Settings_AccountFormatForm.CS";
            logExcpUIobj.RecordId = accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AccountFormatForm : btnGridUpdate_Click] An error occured in the processing of Record Id : " + accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId + ". Details : [" + exp.ToString() + "]");
        }
    }

    private void DeleteData()
    {
        try
        {
            accountFormatFormUI.Tbl_AccountFormatId = Request.QueryString["AccountFormatId"];

            if (accountFormatFormBAL.DeleteAccountFormat(accountFormatFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordDeleteSuccessfully;
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
                //gvData.DataSource = null;
                //gvData.Dispose();
            }
            else
            {
                divError.Visible = true;
                divSuccess.Visible = false;
                lblError.Text = Resources.GlobalResource.msgCouldNotDeleteRecord;
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
                //gvData.DataSource = null;
                //gvData.Dispose();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnDelete_Click()";
            logExcpUIobj.ResourceName = "System_Settings_AccountFormatForm.CS";
            logExcpUIobj.RecordId = accountFormatFormUI.Tbl_AccountFormatId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AccountFormatForm : btnDelete_Click] An error occured in the processing of Record Id : " + accountFormatFormUI.Tbl_AccountFormatId + ". Details : [" + exp.ToString() + "]");
        }
    }

    public void AccountFormatDetails_DeleteByAccountFormatId()
    {
        try
        {
            if (Request.QueryString["AccountFormatId"] != null)
            { accountFormatFormUI.Tbl_AccountFormatId = Request.QueryString["AccountFormatId"]; }
            else
            {
                accountFormatFormUI.Tbl_AccountFormatId = Convert.ToString(HttpContext.Current.Session["AccountFormatId"]);
            }

            if (accountFormatFormBAL.AccountFormatDetails_DeleteByAccountFormatId(accountFormatFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordDeleteSuccessfully;
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
                //gvData.DataSource = null;
                //gvData.Dispose();

            }
            else
            {
                divError.Visible = true;
                divSuccess.Visible = false;
                lblError.Text = Resources.GlobalResource.msgCouldNotDeleteRecord;
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
                //gvData.DataSource = null;
                //gvData.Dispose();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AccountFormatedetailsDelete()";
            logExcpUIobj.ResourceName = "System_Settings_AccountFormatForm.CS";
            logExcpUIobj.RecordId = accountFormatFormUI.Tbl_AccountFormatId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AccountFormatForm : AccountFormatedetailsDelete] An error occured in the processing of Record Id : " + accountFormatFormUI.Tbl_AccountFormatId + ". Details : [" + exp.ToString() + "]");
        }
    }

    #endregion Methods


}


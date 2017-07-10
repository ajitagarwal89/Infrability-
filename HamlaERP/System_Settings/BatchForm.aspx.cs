using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_BatchForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    BatchFormBAL batchFormBAL = new BatchFormBAL();
    BatchFormUI batchFormUI = new BatchFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();

    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        BatchFormUI batchFormUI = new BatchFormUI();


        if (!Page.IsPostBack)
        {
            BindBatchTypeDropDownList();
            BindOriginDropDownList();
            BindFrequencyDropDownList();
            if (Request.QueryString["BatchId"] != null)
            {
                batchFormUI.Tbl_BatchId = Request.QueryString["BatchId"];

                FillForm(batchFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Batch";
            }
            else
            {


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
            batchFormUI.Opt_BatchType = int.Parse(ddlOpt_BatchType.SelectedValue.ToString());
            batchFormUI.BatchName = txtBatchName.Text;
            batchFormUI.Comment = txtComment.Text.Trim();
            batchFormUI.Opt_Origin = int.Parse(ddlOpt_Origin.SelectedValue.ToString());
            batchFormUI.PostingDate = DateTime.Parse(txtPostingDate.Text.ToString());
            batchFormUI.NumberOfTimesPosted = int.Parse(txtNumberOfdays.Text.Trim());
            batchFormUI.ControlJournalEntries = int.Parse(txtJournalEntries.Text);
            batchFormUI.ActualJournalEntries = int.Parse(txtActualJournalEntries.Text);
            batchFormUI.Opt_Frequency = int.Parse(ddlOpt_Frequency.SelectedValue.ToString());
            if (chkBreakDownAllocation.Checked)
            {
                batchFormUI.BreakDownAllocation = true;
            }
            else
            {
                batchFormUI.BreakDownAllocation = false;
            }

            batchFormUI.RecurringPosting = int.Parse(txtRecurringPosting.Text.ToString());
            batchFormUI.DaysToIncrement = int.Parse(txtDaysToIncrement.Text);
            batchFormUI.LastDatePosted = DateTime.Parse(txtLastDatePosted.Text.ToString());
            if (chkIsApproved.Checked)
            {
                batchFormUI.IsApproved = true;
            }
            else
            {
                batchFormUI.IsApproved = false;
            }


            if (batchFormBAL.AddBatch(batchFormUI) == 1)
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
            batchFormUI.Opt_BatchType = int.Parse(ddlOpt_BatchType.SelectedValue.ToString());
            batchFormUI.BatchName = txtBatchName.Text;
            batchFormUI.Comment = txtComment.Text.Trim();
            batchFormUI.Opt_Origin = int.Parse(ddlOpt_Origin.SelectedValue.ToString());
            batchFormUI.PostingDate = DateTime.Parse(txtPostingDate.Text.ToString());
            batchFormUI.NumberOfTimesPosted = int.Parse(txtNumberOfdays.Text.Trim());
            batchFormUI.ControlJournalEntries = int.Parse(txtJournalEntries.Text);
            batchFormUI.ActualJournalEntries = int.Parse(txtActualJournalEntries.Text);
            batchFormUI.Opt_Frequency = int.Parse(ddlOpt_Frequency.SelectedValue.ToString());
            if (chkBreakDownAllocation.Checked)
            {
                batchFormUI.BreakDownAllocation = true;
            }
            else
            {
                batchFormUI.BreakDownAllocation = false;
            }

            batchFormUI.RecurringPosting = int.Parse(txtRecurringPosting.Text.ToString());
            batchFormUI.DaysToIncrement = int.Parse(txtDaysToIncrement.Text);
            batchFormUI.LastDatePosted = DateTime.Parse(txtLastDatePosted.Text.ToString());
            if (chkIsApproved.Checked)
            {
                batchFormUI.IsApproved = true;
            }
            else
            {
                batchFormUI.IsApproved = false;
            }



            if (batchFormBAL.UpdateBatch(batchFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                divError.Visible = true;
                divSuccess.Visible = false;
                lblError.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = "";
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

                ddlOpt_BatchType.SelectedValue = dtb.Rows[0]["Opt_BatchType"].ToString();
                txtBatchName.Text = dtb.Rows[0]["BatchName"].ToString();
                txtComment.Text = dtb.Rows[0]["Comment"].ToString();
                ddlOpt_Origin.SelectedValue = dtb.Rows[0]["Opt_Origin"].ToString();
                txtPostingDate.Text = dtb.Rows[0]["PostingDate"].ToString();
                txtNumberOfdays.Text = dtb.Rows[0]["NumberOfTimesPosted"].ToString();
                txtJournalEntries.Text = dtb.Rows[0]["ControlJournalEntries"].ToString();
                txtActualJournalEntries.Text = dtb.Rows[0]["ActualJournalEntries"].ToString();
                ddlOpt_Frequency.SelectedValue = dtb.Rows[0]["Opt_Frequency"].ToString();
                txtRecurringPosting.Text = dtb.Rows[0]["RecurringPosting"].ToString();
                txtDaysToIncrement.Text = dtb.Rows[0]["DaysToIncrement"].ToString();
                if (Convert.ToBoolean(dtb.Rows[0]["BreakDownAllocation"]) == true)
                { chkBreakDownAllocation.Checked = true; }

                else { chkBreakDownAllocation.Checked = false; }

                txtLastDatePosted.Text = dtb.Rows[0]["LastDatePosted"].ToString();

                if (Convert.ToBoolean(dtb.Rows[0]["IsApproved"]) == true)
                {
                    chkIsApproved.Checked = true;
                }
                else
                {
                    chkIsApproved.Checked = false;
                }

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

            log.Error("[System_Settings_BatchForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #region Bind BatchTypeDropDownList
    private void BindBatchTypeDropDownList()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_Batch";
            optionSetListUI.OptionSetName = "Opt_BatchType";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlOpt_BatchType.DataSource = dtb;
                ddlOpt_BatchType.DataBind();
                ddlOpt_BatchType.DataTextField = "OptionSetLable";
                ddlOpt_BatchType.DataValueField = "OptionSetValue";
                ddlOpt_BatchType.DataBind();
            }
            else
            {
                ddlOpt_BatchType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindOrganizationTypeDropDown()";
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : BindBatchTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion
    #region Bind Frequency DropDownList
    private void BindFrequencyDropDownList()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_Batch";
            optionSetListUI.OptionSetName = "Opt_Frequency";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlOpt_Frequency.DataSource = dtb;
                ddlOpt_Frequency.DataBind();
                ddlOpt_Frequency.DataTextField = "OptionSetLable";
                ddlOpt_Frequency.DataValueField = "OptionSetValue";
                ddlOpt_Frequency.DataBind();
            }
            else
            {
                ddlOpt_Origin.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindFrequencyDropDownList()";
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : BindFrequencyDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion
    #region Bind Frequency DropDownList
    private void BindOriginDropDownList()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_Batch";
            optionSetListUI.OptionSetName = "Opt_Origin";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlOpt_Origin.DataSource = dtb;
                ddlOpt_Origin.DataBind();
                ddlOpt_Origin.DataTextField = "OptionSetLable";
                ddlOpt_Origin.DataValueField = "OptionSetValue";
                ddlOpt_Origin.DataBind();
            }
            else
            {
                ddlOpt_Origin.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindOriginDropDownList()";
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchForm : BindOriginDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }
    #endregion
    #endregion Methods
}
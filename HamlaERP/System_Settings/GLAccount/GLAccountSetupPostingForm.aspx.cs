using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using log4net;
using Finware;
using System.Data.SqlClient;

public partial class Finance_Accounts_Payable_Setup_GLAccountSetupPostingForm : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    GLAccountSetupPostingFormUI gLAccountSetupPostingFormUI = new GLAccountSetupPostingFormUI();
    GLAccountSetupPostingFormBAL gLAccountSetupPostingFormBAL = new GLAccountSetupPostingFormBAL();
  
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();

    #endregion Data Members

    #region Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            BindGLAccountSetupPostingSeriesDropDownList();
            BindGLAccountSetupPostingOriginDropDownList();
            
            if (Request.QueryString["GLAccountSetupPostingId"] != null || Request.QueryString["recordId"] != null)
            {
                gLAccountSetupPostingFormUI.Tbl_GLAccountSetupPostingId = (Request.QueryString["GLAccountSetupPostingId"] != null ? Request.QueryString["GLAccountSetupPostingId"] : Request.QueryString["recordId"]);
               FillForm(gLAccountSetupPostingFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update PayableSetup Group";
            }
            else
            {


                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New PayableSetup Group";
            }
        }
    }

   

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            gLAccountSetupPostingFormUI.CreatedBy = SessionContext.UserGuid;
            gLAccountSetupPostingFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            gLAccountSetupPostingFormUI.opt_Series = Convert.ToInt32(ddlSeries.SelectedValue.ToString());
            gLAccountSetupPostingFormUI.opt_Origin = Convert.ToInt32(ddlOrigin.SelectedValue.ToString());
            if (chkPostToGL.Checked)
            {
                gLAccountSetupPostingFormUI.PostToGL = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.PostToGL = false;
            }
            if (chkPostThroughGLFile.Checked)
            {
                gLAccountSetupPostingFormUI.PostThroughGLFile = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.PostThroughGLFile = false;
            }
            if (chkAllowTransactionPosting.Checked)
            {
                gLAccountSetupPostingFormUI.AllowTransactionPosting = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.AllowTransactionPosting = false;
            }
            if (chkIncludeMultiCurrencyInfo.Checked)
            {
                gLAccountSetupPostingFormUI.IncludeMultiCurrencyInfo = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.IncludeMultiCurrencyInfo = false;
            }
            if (chkVerifyNumberOfTransaction.Checked)
            {
                gLAccountSetupPostingFormUI.VerifyNumberOfTransaction = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.VerifyNumberOfTransaction = false;
            }
            if (chkVerifyBatchAmount.Checked)
            {
                gLAccountSetupPostingFormUI.VerifyBatchAmount = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.VerifyBatchAmount = false;
            }
            if (chkTransaction.Checked)
            {
                gLAccountSetupPostingFormUI.Transaction = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.Transaction = false;
            }
            if (chkBatch.Checked)
            {
                gLAccountSetupPostingFormUI.Batch = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.Batch = false;
            }
            if (chkUseAccountSetting.Checked)
            {
                gLAccountSetupPostingFormUI.UseAccountSetting = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.UseAccountSetting = false;
            }
            if (chkPostingDateFromBatch.Checked)
            {
                gLAccountSetupPostingFormUI.PostingDateFromBatch = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.PostingDateFromBatch = false;
            }
            if (chkPostingDateFromTrx.Checked)
            {
                gLAccountSetupPostingFormUI.PostingDateFromTrx = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.PostingDateFromTrx = false;
            }
            if (chkIfExistingBatchAppend.Checked)
            {
               gLAccountSetupPostingFormUI.IfExistingBatchAppend = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.IfExistingBatchAppend = false;
            }
            if (chkIfExistingBatchCreateNew.Checked)
            {
                gLAccountSetupPostingFormUI.IfExistingBatchCreateNew = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.IfExistingBatchCreateNew = false;
            }
            if (chkRequireBatchApproval.Checked)
            {
                gLAccountSetupPostingFormUI.RequireBatchApproval = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.RequireBatchApproval = false;
            }
            gLAccountSetupPostingFormUI.BatchApprovalPassword = txtBatchApprovalPassword.Text;

            if (gLAccountSetupPostingFormBAL.AddGLAccountSetupPosting(gLAccountSetupPostingFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
                divSuccess.Visible = false;
                divError.Visible = true;


            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_GLAccountSetupPostingForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_GLAccountSetupPostingForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            gLAccountSetupPostingFormUI.ModifiedBy = SessionContext.UserGuid;
           gLAccountSetupPostingFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
           gLAccountSetupPostingFormUI.Tbl_GLAccountSetupPostingId = Request.QueryString["GLAccountSetupPostingId"];
            gLAccountSetupPostingFormUI.opt_Series = Convert.ToInt32(ddlSeries.SelectedValue.ToString());
            gLAccountSetupPostingFormUI.opt_Origin = Convert.ToInt32(ddlOrigin.SelectedValue.ToString());
            if (chkPostToGL.Checked)
            {
                gLAccountSetupPostingFormUI.PostToGL = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.PostToGL = false;
            }
            if (chkPostThroughGLFile.Checked)
            {
                gLAccountSetupPostingFormUI.PostThroughGLFile = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.PostThroughGLFile = false;
            }
            if (chkAllowTransactionPosting.Checked)
            {
                gLAccountSetupPostingFormUI.AllowTransactionPosting = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.AllowTransactionPosting = false;
            }
            if (chkIncludeMultiCurrencyInfo.Checked)
            {
                gLAccountSetupPostingFormUI.IncludeMultiCurrencyInfo = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.IncludeMultiCurrencyInfo = false;
            }
            if (chkVerifyNumberOfTransaction.Checked)
            {
                gLAccountSetupPostingFormUI.VerifyNumberOfTransaction = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.VerifyNumberOfTransaction = false;
            }
            if (chkVerifyBatchAmount.Checked)
            {
                gLAccountSetupPostingFormUI.VerifyBatchAmount = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.VerifyBatchAmount = false;
            }
            if (chkTransaction.Checked)
            {
                gLAccountSetupPostingFormUI.Transaction = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.Transaction = false;
            }
            if (chkBatch.Checked)
            {
                gLAccountSetupPostingFormUI.Batch = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.Batch = false;
            }
            if (chkUseAccountSetting.Checked)
            {
                gLAccountSetupPostingFormUI.UseAccountSetting = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.UseAccountSetting = false;
            }
            if (chkPostingDateFromBatch.Checked)
            {
                gLAccountSetupPostingFormUI.PostingDateFromBatch = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.PostingDateFromBatch = false;
            }
            if (chkPostingDateFromTrx.Checked)
            {
                gLAccountSetupPostingFormUI.PostingDateFromTrx = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.PostingDateFromTrx = false;
            }
            if (chkIfExistingBatchAppend.Checked)
            {
                gLAccountSetupPostingFormUI.IfExistingBatchAppend = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.IfExistingBatchAppend = false;
            }
            if (chkIfExistingBatchCreateNew.Checked)
            {
                gLAccountSetupPostingFormUI.IfExistingBatchCreateNew = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.IfExistingBatchCreateNew = false;
            }
            if (chkRequireBatchApproval.Checked)
            {
                gLAccountSetupPostingFormUI.RequireBatchApproval = true;
            }
            else
            {
                gLAccountSetupPostingFormUI.RequireBatchApproval = false;
            }
            gLAccountSetupPostingFormUI.BatchApprovalPassword = txtBatchApprovalPassword.Text;


            if (gLAccountSetupPostingFormBAL.UpdateGLAccountSetupPosting(gLAccountSetupPostingFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_GLAccountSetupPostingForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_GLAccountSetupPostingForm : btnUpdate_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            gLAccountSetupPostingFormUI.Tbl_GLAccountSetupPostingId = Request.QueryString["GLAccountSetupPostingId"];

            if (gLAccountSetupPostingFormBAL.DeleteGLAccountSetupPosting(gLAccountSetupPostingFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_GLAccountSetupPostingForm";
            logExcpUIobj.RecordId = gLAccountSetupPostingFormUI.Tbl_GLAccountSetupPostingId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_GLAccountSetupPostingForm : btnDelete_Click] An error occured in the processing of Record Id : " + gLAccountSetupPostingFormUI.Tbl_GLAccountSetupPostingId + ". Details : [" + exp.ToString() + "]");
        }

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("GLAccountSetupPostingList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Finance/Accounts_Payable/Setup/GLAccountSetupPostingForm.aspx";
        string recordId = Request.QueryString["BatchId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);

    }
    #endregion

    #region Methods
    private void FillForm(GLAccountSetupPostingFormUI gLAccountSetupPostingFormUI)
    {
        try
        {
            DataTable dtb = gLAccountSetupPostingFormBAL.GetGLAccountSetupPostingListById(gLAccountSetupPostingFormUI);

            if (dtb.Rows.Count > 0)
            {

                ddlSeries.SelectedValue = dtb.Rows[0]["opt_Series"].ToString();
                ddlOrigin.SelectedValue = dtb.Rows[0]["opt_Origin"].ToString();
               
                if (Convert.ToBoolean(dtb.Rows[0]["PostToGL"]) == true)
                { chkPostToGL.Checked = true; }

                else { chkPostToGL.Checked = false; }

               
                if (Convert.ToBoolean(dtb.Rows[0]["PostThroughGLFile"]) == true)
                {
                    chkPostThroughGLFile.Checked = true;
                }
                else
                {
                    chkPostThroughGLFile.Checked = false;
                }

                if (Convert.ToBoolean(dtb.Rows[0]["AllowTransactionPosting"]) == true)
                {
                    chkAllowTransactionPosting.Checked = true;
                }
                else
                {
                    chkAllowTransactionPosting.Checked = false;
                }

                if (Convert.ToBoolean(dtb.Rows[0]["IncludeMultiCurrencyInfo"]) == true)
                {
                    chkIncludeMultiCurrencyInfo.Checked = true;
                }
                else
                {
                    chkIncludeMultiCurrencyInfo.Checked = false;
                }

                if (Convert.ToBoolean(dtb.Rows[0]["VerifyNumberOfTransaction"]) == true)
                {
                    chkVerifyNumberOfTransaction.Checked = true;
                }
                else
                {
                    chkVerifyNumberOfTransaction.Checked = false;
                }
                if (Convert.ToBoolean(dtb.Rows[0]["VerifyBatchAmount"]) == true)
                {
                    chkVerifyBatchAmount.Checked = true;
                }
                else
                {
                    chkVerifyBatchAmount.Checked = false;
                }

                if (Convert.ToBoolean(dtb.Rows[0]["Transaction"]) == true)
                {
                    chkTransaction.Checked = true;
                }
                else
                {
                    chkTransaction.Checked = false;
                }

                if (Convert.ToBoolean(dtb.Rows[0]["Batch"]) == true)
                {
                    chkBatch.Checked = true;
                }
                else
                {
                    chkBatch.Checked = false;
                }
                if (Convert.ToBoolean(dtb.Rows[0]["UseAccountSetting"]) == true)
                {
                    chkUseAccountSetting.Checked = true;
                }
                else
                {
                    chkUseAccountSetting.Checked = false;
                }

                if (Convert.ToBoolean(dtb.Rows[0]["PostingDateFromBatch"]) == true)
                {
                    chkPostingDateFromBatch.Checked = true;
                }
                else
                {
                    chkPostingDateFromBatch.Checked = false;
                }



                if (Convert.ToBoolean(dtb.Rows[0]["PostingDateFromTrx"]) == true)
                {
                    chkPostingDateFromTrx.Checked = true;
                }
                else
                {
                    chkPostingDateFromTrx.Checked = false;
                }

                if (Convert.ToBoolean(dtb.Rows[0]["IfExistingBatchAppend"]) == true)
                {
                    chkIfExistingBatchAppend.Checked = true;
                }
                else
                {
                    chkIfExistingBatchAppend.Checked = false;
                }

                if (Convert.ToBoolean(dtb.Rows[0]["IfExistingBatchCreateNew"]) == true)
                {
                    chkIfExistingBatchCreateNew.Checked = true;
                }
                else
                {
                    chkIfExistingBatchCreateNew.Checked = false;
                }
                if (Convert.ToBoolean(dtb.Rows[0]["IfExistingBatchCreateNew"]) == true)
                {
                    chkIfExistingBatchCreateNew.Checked = true;
                }
                else
                {
                    chkIfExistingBatchCreateNew.Checked = false;
                }
                if (Convert.ToBoolean(dtb.Rows[0]["RequireBatchApproval"]) == true)
                {
                    chkRequireBatchApproval.Checked = true;
                }
                else
                {
                    chkRequireBatchApproval.Checked = false;
                }

                txtBatchApprovalPassword.Text = dtb.Rows[0]["BatchApprovalPassword"].ToString();
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_GLAccountSetupPostingForm.CS";
            logExcpUIobj.RecordId = gLAccountSetupPostingFormUI.Tbl_GLAccountSetupPostingId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_GLAccountSetupPostingForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }

    #region  BindGLAccountSetupPostingSeriesDropDownList
    private void BindGLAccountSetupPostingSeriesDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_GLAccountSetupPosting";
            optionSetListUI.OptionSetName = "Opt_Series";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlSeries.DataSource = dtb;

                ddlSeries.DataTextField = "OptionSetLable";
                ddlSeries.DataValueField = "OptionSetValue";

                ddlSeries.DataBind();

                ddlSeries.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlSeries.SelectedIndex = 0;
            }
            else
            {
                ddlSeries.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindGLAccountSetupPostingSeriesDropDownList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_GLAccountSetupPostingForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_GLAccountSetupPostingForm : BindGLAccountSetupPostingSeriesDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion


    #region  BindGLAccountSetupPostingOriginDropDownList
    private void BindGLAccountSetupPostingOriginDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_GLAccountSetupPosting";
            optionSetListUI.OptionSetName = "Opt_Origin";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlOrigin.DataSource = dtb;

                ddlOrigin.DataTextField = "OptionSetLable";
                ddlOrigin.DataValueField = "OptionSetValue";

                ddlOrigin.DataBind();

                ddlOrigin.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlOrigin.SelectedIndex = 0;
            }
            else
            {
                ddlOrigin.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindGLAccountSetupPostingOriginDropDownList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Setup_GLAccountSetupPostingForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Setup_GLAccountSetupPostingForm : BindGLAccountSetupPostingOriginDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion

    #endregion

}
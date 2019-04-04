using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;
using System.Globalization;

public partial class System_Settings_AccountFormatDetialsForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    AccountFormatListBAL gLAccountFormatListBAL = new AccountFormatListBAL();
    AccountFormatDetailsFormBAL accountFormatDetailsFormBAL = new AccountFormatDetailsFormBAL();
    AccountFormatDetailsFormUI accountFormatDetailsFormUI = new AccountFormatDetailsFormUI();
    
    #endregion

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        BatchFormUI batchFormUI = new BatchFormUI();


        AccountFormatDetailsFormUI accountFormatDetailsFormUI = new AccountFormatDetailsFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["AccountFormatDetailsId"] != null || Request.QueryString["recordId"] != null)
            {
                accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId = (Request.QueryString["AccountFormatDetailsId"] != null ? Request.QueryString["AccountFormatDetailsId"] : Request.QueryString["recordId"]);

                FillForm(accountFormatDetailsFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update AccountFormat Details";
            }
            else
            {



                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New  Account Format Details";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            accountFormatDetailsFormUI.CreatedBy = SessionContext.UserGuid;
            accountFormatDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            accountFormatDetailsFormUI.Tbl_AccountFormatId = txtGLAccountFormatGuid.Text;

            accountFormatDetailsFormUI.SequenceNumber =Convert.ToInt32(txtSequenceNumber.Text.ToString());
            if (chkIsActive.Checked == true)
                accountFormatDetailsFormUI.IsActive = true;
            else
                accountFormatDetailsFormUI.IsActive = false;

            accountFormatDetailsFormUI.SegmentNumber =Convert.ToInt32(txtSegmentNumber.Text.ToString());

            accountFormatDetailsFormUI.SegmentName = txtSegmentName.Text;
            accountFormatDetailsFormUI.MaxLength =Convert.ToInt32(txtMaxLength.Text.ToString());
            accountFormatDetailsFormUI.Length =Convert.ToInt32(txtLength.Text.ToString());
            if (accountFormatDetailsFormBAL.AddAccountFormatDetails(accountFormatDetailsFormUI) == 1)
            {
                divSuccess.Visible = true;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
                divError.Visible = true;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "System_Settings_AccountFormatDetailsForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AccountFormatDetailsForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            accountFormatDetailsFormUI.ModifiedBy = SessionContext.UserGuid;
            accountFormatDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId = Request.QueryString["AccountFormatDetailsId"];
            accountFormatDetailsFormUI.Tbl_AccountFormatId = txtGLAccountFormatGuid.Text;
            accountFormatDetailsFormUI.SequenceNumber = Convert.ToInt32(txtSequenceNumber.Text.ToString());

            if (chkIsActive.Checked == true)
                accountFormatDetailsFormUI.IsActive = true;
            else
                accountFormatDetailsFormUI.IsActive = false;

            accountFormatDetailsFormUI.SegmentNumber = Convert.ToInt32(txtSegmentNumber.Text.ToString());
            accountFormatDetailsFormUI.SegmentName = txtSegmentName.Text;
            accountFormatDetailsFormUI.MaxLength = Convert.ToInt32(txtMaxLength.Text.ToString());
            accountFormatDetailsFormUI.Length = Convert.ToInt32(txtLength.Text.ToString());

            if (accountFormatDetailsFormBAL.UpdateAccountFormatDetails(accountFormatDetailsFormUI) == 1)
            {
                divSuccess.Visible = true;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "System_Settings_AccountFormatDetailsForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AccountFormatDetailsForm : btnUpdate_Click] An error occured in the processing of Record Id : " + accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId + ".  Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId = Request.QueryString["AccountFormatDetailsId"];

            if (accountFormatDetailsFormBAL.DeleteAccountFormatDetails(accountFormatDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_AccountFormatDetailsForm.CS";
            logExcpUIobj.RecordId = accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AccountFormatDetailsForm : btnDelete_Click] An error occured in the processing of Record Id : " + accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AccountFormatDetailsList.aspx");
    }


    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/System_Settings/AccountFormatDetailsForm.aspx";
        string recordId = Request.QueryString["AccountFormatDetailsId"];
        Response.Redirect("~/System_Settings/AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }



    #region Events Seach AccountFormat
    protected void btnAccountFormatSearch_Click(object sender, EventArgs e)
    {
        btnHtmlGLAccountFormatSearch.Visible = false;
        btnHtmlGLAccountFormatClose.Visible = true;
        SearchAccountFormatList();
    }
    protected void btnClearAccountFormatSearch_Click(object sender, EventArgs e)
    {
        BindAccountFormatList();
        gvGLAccountFormatSearch.Visible = true;
        btnHtmlGLAccountFormatSearch.Visible = true;
        btnHtmlGLAccountFormatClose.Visible = false;
        txtGLAccountFormatSearch.Text = "";
        txtGLAccountFormatSearch.Focus();
    }
    protected void btnAccountFormatRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindAccountFormatList();
    }
    #endregion
    #endregion Events

    #region Methods
    #region AccountFormat Search    
    private void SearchAccountFormatList()
    {
        try
        {
            AccountFormatListUI accountFormatListUI = new AccountFormatListUI();
            accountFormatListUI.Search = txtGLAccountFormatSearch.Text;


            DataTable dtb = gLAccountFormatListBAL.GetAccountFormatListBySearchParameters(accountFormatListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountFormatSearch.DataSource = dtb;
                gvGLAccountFormatSearch.DataBind();
                divGLAccountFormatSearchError.Visible = false;
            }
            else
            {
                divGLAccountFormatSearchError.Visible = true;
                lblGLAccountFormatSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountFormatSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchAccountFormatList()";
            logExcpUIobj.ResourceName = "System_Settings_AccountFormatDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AccountFormatDetailsForm : SearchAccountFormatList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindAccountFormatList()
    {
        try
        {
            DataTable dtb = gLAccountFormatListBAL.GetAccountFormatList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountFormatSearch.DataSource = dtb;
                gvGLAccountFormatSearch.DataBind();
                divGLAccountFormatSearchError.Visible = false;

            }
            else
            {
                divGLAccountFormatSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountFormatSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindAccountFormatList()";
            logExcpUIobj.ResourceName = "System_Settings_AccountFormatDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AccountFormatDetailsForm : BindAccountFormatList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    #endregion AccountFormat Search

    private void FillForm(AccountFormatDetailsFormUI accountFormatDetailsFormUI)
    {
        try
        {

            DataTable dtb = accountFormatDetailsFormBAL.GetAccountFormatDetailsListById(accountFormatDetailsFormUI);

            if (dtb.Rows.Count > 0)
            {
               txtGLAccountFormatGuid.Text = dtb.Rows[0]["tbl_AccountFormatId"].ToString();
               //txtAccountFormat.Text = dtb.Rows[0]["tbl_AccountFormat"].ToString();
                txtSequenceNumber.Text = dtb.Rows[0]["SequenceNumber"].ToString();
                txtSegmentNumber.Text = dtb.Rows[0]["SegmentNumber"].ToString();
                txtSegmentName.Text = dtb.Rows[0]["SegmentName"].ToString();
                txtMaxLength.Text = dtb.Rows[0]["MaxLength"].ToString();
                txtLength.Text = dtb.Rows[0]["Length"].ToString();
               
                if (Convert.ToBoolean(dtb.Rows[0]["IsActive"]) == true)

                    chkIsActive.Checked = true;
                else
                    chkIsActive.Checked = false;

                
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
            logExcpUIobj.ResourceName = "System_Settings_AccountFormatDetailsForm.CS";
            logExcpUIobj.RecordId = this.accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_AccountFormatDetailsForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods
}
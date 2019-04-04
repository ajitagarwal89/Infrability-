using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Human_Resource_HR_SupervisorForm :PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    HR_SupervisorFormBAL hR_SupervisorFormBAL = new HR_SupervisorFormBAL();
    HR_SupervisorFormUI hR_SupervisorFormUI = new HR_SupervisorFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();

    #endregion Data Members
    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        HR_SupervisorFormUI hR_SupervisorFormUI = new HR_SupervisorFormUI();

        if (!Page.IsPostBack)
        {

            if (Request.QueryString["HR_SupervisorId"] != null || Request.QueryString["recordId"] != null)
            {
                hR_SupervisorFormUI.Tbl_HR_SupervisorId =(Request.QueryString["HR_SupervisorId"] != null ? Request.QueryString["HR_SupervisorId"] : Request.QueryString["recordId"]);

                BindCurrentyFiscalYearDropDown();
                BindDepreciatedPeriodDropDown();

                FillForm(hR_SupervisorFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnAuditHistory.Visible = true;
                lblHeading.Text = "Update HR Supervisor";
            }
            else
            {
                BindCurrentyFiscalYearDropDown();
                BindDepreciatedPeriodDropDown();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New HR Supervisor";
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            hR_SupervisorFormUI.CreatedBy = SessionContext.UserGuid;
            hR_SupervisorFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            hR_SupervisorFormUI.SupervisorCode = txtSupervisorCode.Text;
            hR_SupervisorFormUI.Description = txtDescription.Text;
            hR_SupervisorFormUI.opt_CurrentyFiscalYear = int.Parse(ddlopt_CurrentyFiscalYear.SelectedValue);
            hR_SupervisorFormUI.opt_DepreciatedPeriod = int.Parse(ddlopt_DepreciatedPeriod.SelectedValue);
            if (hR_SupervisorFormBAL.AddHR_Supervisor(hR_SupervisorFormUI) == 1)
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
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "Human_Resource_HR_SupervisorForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_HR_SupervisorForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            hR_SupervisorFormUI.ModifiedBy = SessionContext.UserGuid;
            hR_SupervisorFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            hR_SupervisorFormUI.Tbl_HR_SupervisorId = Request.QueryString["HR_SupervisorId"];
            hR_SupervisorFormUI.SupervisorCode = txtSupervisorCode.Text;
            hR_SupervisorFormUI.Description = txtDescription.Text;
            hR_SupervisorFormUI.opt_CurrentyFiscalYear = int.Parse(ddlopt_CurrentyFiscalYear.SelectedValue);
            hR_SupervisorFormUI.opt_DepreciatedPeriod = int.Parse(ddlopt_DepreciatedPeriod.SelectedValue);

            if (hR_SupervisorFormBAL.UpdateHR_Supervisor(hR_SupervisorFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Human_Resource_HR_SupervisorForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_HR_SupervisorForm : btnUpdate_Click] An error occured in the processing of Record Id : " + hR_SupervisorFormUI.Tbl_HR_SupervisorId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            hR_SupervisorFormUI.Tbl_HR_SupervisorId = Request.QueryString["HR_SupervisorId"];

            if (hR_SupervisorFormBAL.DeleteHR_Supervisor(hR_SupervisorFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Human_Resource_HR_SupervisorForm.CS";
            logExcpUIobj.RecordId = hR_SupervisorFormUI.Tbl_HR_SupervisorId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_HR_SupervisorForm : btnDelete_Click] An error occured in the processing of Record Id : " + hR_SupervisorFormUI.Tbl_HR_SupervisorId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("HR_SupervisorList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Human_Resource/HR/HR_SupervisorForm.aspx";
        string recordId = Request.QueryString["HR_SupervisorId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    #endregion Events

    #region Methods 

    private void FillForm(HR_SupervisorFormUI hR_SupervisorFormUI)
    {
        try
        {
            DataTable dtb = hR_SupervisorFormBAL.GetHR_SupervisorListById(hR_SupervisorFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtSupervisorCode.Text = dtb.Rows[0]["SupervisorCode"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                ddlopt_CurrentyFiscalYear.SelectedValue = dtb.Rows[0]["opt_CurrentyFiscalYear"].ToString();
                ddlopt_DepreciatedPeriod.SelectedValue = dtb.Rows[0]["opt_DepreciatedPeriod"].ToString();

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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_HR_SupervisorForm.CS";
            logExcpUIobj.RecordId = this.hR_SupervisorFormUI.Tbl_HR_SupervisorId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_HR_SupervisorForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region Bind CurrentyFiscalYear DropDown
    private void BindCurrentyFiscalYearDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_HR_Supervisor";
            optionSetListUI.OptionSetName = "opt_CurrentyFiscalYear";

            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {
                ddlopt_CurrentyFiscalYear.DataSource = dtb;
                ddlopt_CurrentyFiscalYear.DataBind();
                ddlopt_CurrentyFiscalYear.DataTextField = "OptionSetLable";
                ddlopt_CurrentyFiscalYear.DataValueField = "OptionSetValue";
                ddlopt_CurrentyFiscalYear.DataBind();
                ddlopt_CurrentyFiscalYear.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlopt_CurrentyFiscalYear.SelectedIndex = 0;

            }
            else
            {
                ddlopt_CurrentyFiscalYear.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "-1"));
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCurrentyFiscalYearDropDown()";
            logExcpUIobj.ResourceName = "Human_Resource_HR_SupervisorForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_HR_SupervisorForm : BindCurrentyFiscalYearDropDown] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #endregion Bind CurrentyFiscalYear DropDown

    #region Bind DepreciatedPeriod DropDown
    private void BindDepreciatedPeriodDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_HR_Supervisor";
            optionSetListUI.OptionSetName = "opt_DepreciatedPeriod";

            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {
                ddlopt_DepreciatedPeriod.DataSource = dtb;
                ddlopt_DepreciatedPeriod.DataBind();
                ddlopt_DepreciatedPeriod.DataTextField = "OptionSetLable";
                ddlopt_DepreciatedPeriod.DataValueField = "OptionSetValue";
                ddlopt_DepreciatedPeriod.DataBind();
                ddlopt_DepreciatedPeriod.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlopt_DepreciatedPeriod.SelectedIndex = 0;

            }
            else
            {
                ddlopt_DepreciatedPeriod.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "-1"));
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindDepreciatedPeriodDropDown()";
            logExcpUIobj.ResourceName = "Human_Resource_HR_SupervisorForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_HR_SupervisorForm : BindDepreciatedPeriodDropDown] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #endregion Bind DepreciatedPeriod DropDown

    #endregion Methods
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Finware;
using log4net;
using System.Data;

public partial class Human_Resource_HR_HRDivisionForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    HRDivisionFormBAL hRDivisionFormBAL = new HRDivisionFormBAL();
    HRDivisionFormUI hRDivisionFormUI = new HRDivisionFormUI();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        HRDivisionFormUI hRDivisionFormUI = new HRDivisionFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["HRDivisionId"] != null || Request.QueryString["recordId"] != null)
            {
                hRDivisionFormUI.Tbl_HRDivisionId = (Request.QueryString["HRDivisionId"] != null ? Request.QueryString["HRDivisionId"] : Request.QueryString["recordId"]);


                FillForm(hRDivisionFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update HR Division";
            }
            else
            {
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New HR Division";
            }
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            hRDivisionFormUI.CreatedBy = SessionContext.UserGuid;
            hRDivisionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            hRDivisionFormUI.DivisionCode = txtDivisionCode.Text;
            hRDivisionFormUI.Description = txtDescription.Text;
            hRDivisionFormUI.Address = txtAddress.Text;
            hRDivisionFormUI.City = txtCity.Text;
            hRDivisionFormUI.State = txtState.Text;
            hRDivisionFormUI.ZipCode = txtZipCode.Text;
            hRDivisionFormUI.Phone = txtPhone.Text;
            hRDivisionFormUI.Extension = txtExtension.Text;
            hRDivisionFormUI.Fax = txtFax.Text;
            hRDivisionFormUI.Email = txtEmail.Text;
                 
            if (hRDivisionFormBAL.AddHRDivision(hRDivisionFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Human_Resource_HR_HRDivisionForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_HR_HRDivisionForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            hRDivisionFormUI.Tbl_HRDivisionId = Request.QueryString["HRDivisionId"];
            hRDivisionFormUI.ModifiedBy = SessionContext.UserGuid;
            hRDivisionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            hRDivisionFormUI.DivisionCode = txtDivisionCode.Text;
            hRDivisionFormUI.Description = txtDescription.Text;
            hRDivisionFormUI.Address = txtAddress.Text;
            hRDivisionFormUI.City = txtCity.Text;
            hRDivisionFormUI.State = txtState.Text;
            hRDivisionFormUI.ZipCode = txtZipCode.Text;
            hRDivisionFormUI.Phone = txtPhone.Text;
            hRDivisionFormUI.Extension = txtExtension.Text;
            hRDivisionFormUI.Fax = txtFax.Text;
            hRDivisionFormUI.Email = txtEmail.Text;

            if (hRDivisionFormBAL.UpdateHRDivision(hRDivisionFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
                hRDivisionFormUI.Tbl_HRDivisionId = Request.QueryString["HRDivisionId"];
                FillForm(hRDivisionFormUI);
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
            logExcpUIobj.ResourceName = "Human_Resource_HR_HRDivisionForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_HR_HRDivisionForm : btnUpdate_Click] An error occured in the processing of Record Id : " + hRDivisionFormUI.Tbl_HRDivisionId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        HRDivisionFormUI hRDivisionFormUI = new HRDivisionFormUI();
        try
        {
            hRDivisionFormUI.Tbl_HRDivisionId = Request.QueryString["HRDivisionId"];

            if (hRDivisionFormBAL.DeleteHRDivision(hRDivisionFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Human_Resource_HR_HRDivisionForm.CS";
            logExcpUIobj.RecordId = hRDivisionFormUI.Tbl_HRDivisionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_HR_HRDivisionForm : btnDelete_Click] An error occured in the processing of Record Id : " + hRDivisionFormUI.Tbl_HRDivisionId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("HRDivisionList.aspx");
    }


    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Human_Resource/HR/HRDivisionForm.aspx";
        string recordId = Request.QueryString["HRDivisionId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }
    #endregion Events

    #region Methods
    private void FillForm(HRDivisionFormUI hRDivisionFormUI)
    {
        try
        {
            DataTable dtb = hRDivisionFormBAL.GetHRDivisionListById(hRDivisionFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtDivisionCode.Text = dtb.Rows[0]["DivisionCode"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                txtAddress.Text = dtb.Rows[0]["Address"].ToString();
                txtCity.Text = dtb.Rows[0]["City"].ToString();
                txtState.Text = dtb.Rows[0]["State"].ToString();
                txtZipCode.Text = dtb.Rows[0]["ZipCode"].ToString();
                txtPhone.Text = dtb.Rows[0]["Phone"].ToString();
                txtExtension.Text = dtb.Rows[0]["Extension"].ToString();
                txtFax.Text = dtb.Rows[0]["Fax"].ToString();
                txtEmail.Text = dtb.Rows[0]["Email"].ToString();
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
            logExcpUIobj.ResourceName = "Human_Resource_HR_HRDivisionForm.CS";
            logExcpUIobj.RecordId = hRDivisionFormUI.Tbl_HRDivisionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Human_Resource_HR_HRDivisionForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods
}
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Human_Resource_HR_PositionForm : PageBase 
{

    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    HR_PositionFormBAL hR_PositionFormBAL = new HR_PositionFormBAL();
    HR_PositionFormUI hR_PositionFormUI = new HR_PositionFormUI();

    HR_PositionListBAL hR_PositionListBAL = new HR_PositionListBAL();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        HR_PositionFormUI hR_PositionFormUI = new HR_PositionFormUI();

        if (!Page.IsPostBack)
        {

            if (Request.QueryString["HR_PositionId"] != null || Request.QueryString["recordId"] != null) 
            {
                hR_PositionFormUI.Tbl_HR_PositionId =(Request.QueryString["HR_PositionId"] != null ? Request.QueryString["HR_PositionId"] : Request.QueryString["recordId"]);



                FillForm(hR_PositionFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnAuditHistory.Visible = true;
                lblHeading.Text = "Update HR Position";
            }
            else
            {
               
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New HR Position";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            hR_PositionFormUI.CreatedBy = SessionContext.UserGuid;
            hR_PositionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            hR_PositionFormUI.PositionCode = txtPositionCode.Text;
            hR_PositionFormUI.Description = txtDescription.Text;
            hR_PositionFormUI.Tbl_PayCodes = "00000000-0000-0000-0000-000000000001";
            hR_PositionFormUI.Tbl_HR_PositionId_Self = txtHR_PositionId_SelfGuid.Text;
           if (hR_PositionFormBAL.AddHR_Position(hR_PositionFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_HR_PositionForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_HR_PositionForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            hR_PositionFormUI.ModifiedBy = SessionContext.UserGuid;
            hR_PositionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            hR_PositionFormUI.Tbl_HR_PositionId = Request.QueryString["HR_PositionId"];
            hR_PositionFormUI.PositionCode = txtPositionCode.Text;
            hR_PositionFormUI.Description = txtDescription.Text;
            hR_PositionFormUI.Tbl_PayCodes = "00000000-0000-0000-0000-000000000001";
           
            hR_PositionFormUI.Tbl_HR_PositionId_Self = txtHR_PositionId_SelfGuid.Text;

            if (hR_PositionFormBAL.UpdateHR_Position(hR_PositionFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_HR_PositionForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_HR_PositionForm : btnUpdate_Click] An error occured in the processing of Record Id : " + hR_PositionFormUI.Tbl_HR_PositionId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            hR_PositionFormUI.Tbl_HR_PositionId = Request.QueryString["HR_PositionId"];

            if (hR_PositionFormBAL.DeleteHR_Position(hR_PositionFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_HR_PositionForm.CS";
            logExcpUIobj.RecordId = hR_PositionFormUI.Tbl_HR_PositionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_HR_PositionForm : btnDelete_Click] An error occured in the processing of Record Id : " + hR_PositionFormUI.Tbl_HR_PositionId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("HR_PositionList.aspx");
    }


    #region HR_PositionId_Self Search
    protected void btnHR_PositionId_SelfSearch_Click(object sender, EventArgs e)
    {
        btnHtmlHR_PositionId_SelfSearch.Visible = false;
        btnHtmlHR_PositionId_SelfClose.Visible = true;
        SearchHR_PositionId_SelfList();

    }
    protected void btnClearHR_PositionId_SelfSearch_Click(object sender, EventArgs e)
    {
        BindHR_PositionId_SelfList();
        gvHR_PositionId_SelfSearch.Visible = true;
        btnHtmlHR_PositionId_SelfSearch.Visible = true;
        btnHtmlHR_PositionId_SelfClose.Visible = false;
        txtHR_PositionId_SelfSearch.Text = "";
        txtHR_PositionId_SelfSearch.Focus();

    }
    protected void btnHR_PositionId_SelfRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindHR_PositionId_SelfList();
    }
    #endregion  HR_PositionId_Self Search


    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Human_Resource/HR/HR_PositionForm.aspx";
        string recordId = Request.QueryString["HR_PositionId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    #endregion Events

    #region Methods 

    #region HR_PositionId_Self Search
    private void SearchHR_PositionId_SelfList()
    {
        try
        {
            HR_PositionListBAL hR_PositionListBAL = new HR_PositionListBAL();
            HR_PositionListUI hR_PositionListUI = new HR_PositionListUI();

            hR_PositionListUI.Search = txtHR_PositionId_SelfSearch.Text;

            DataTable dtb = hR_PositionListBAL.GetHR_PositionListBySearchParameters(hR_PositionListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvHR_PositionId_SelfSearch.DataSource = dtb;
                gvHR_PositionId_SelfSearch.DataBind();
                divHR_PositionId_SelfSearchError.Visible = false;
                gvHR_PositionId_SelfSearch.Visible = true;
            }
            else
            {
                divHR_PositionId_SelfSearchError.Visible = true;
                lblHR_PositionId_SelfSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvHR_PositionId_SelfSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchHR_PositionId_SelfList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_HR_PositionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_HR_PositionForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }


    }
    private void BindHR_PositionId_SelfList()
    {
        try
        {
            DataTable dtb = hR_PositionListBAL.GetHR_PositionList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvHR_PositionId_SelfSearch.DataSource = dtb;
                gvHR_PositionId_SelfSearch.DataBind();
                divHR_PositionId_SelfSearchError.Visible = false;
            }
            else
            {
                divHR_PositionId_SelfSearchError.Visible = true;
                lblHR_PositionId_SelfSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvHR_PositionId_SelfSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindHR_PositionId_SelfList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_HR_PositionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_HR_PositionForm : BindHR_PositionId_SelfList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion

    //#region PayCodes Search
    //private void SearchPayCodesList()
    //{
    //    try
    //    {
    //        PayCodesListUI PayCodesListUI = new PayCodesListUI();
    //        PayCodesListUI.Search = txtPayCodesSearch.Text;
    //        DataTable dtb = PayCodesListBAL.GetPayCodesListBySearchParameters(PayCodesListUI);
    //        if (dtb.Rows.Count > 0 && dtb != null)
    //        {
    //            gvPayCodesSearch.DataSource = dtb;
    //            gvPayCodesSearch.DataBind();
    //            divPayCodesSearchError.Visible = false;
    //            gvPayCodesSearch.Visible = true;
    //        }
    //        else
    //        {
    //            divPayCodesSearchError.Visible = true;
    //            lblPayCodesSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
    //            gvPayCodesSearch.Visible = false;
    //        }
    //    }
    //    catch (Exception exp)
    //    {
    //        logExcpUIobj.MethodName = "SearchPayCodesList()";
    //        logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_HR_PositionForm.CS";
    //        logExcpUIobj.RecordId = "All";
    //        logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
    //        logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

    //        log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_HR_PositionForm : SearchPayCodesList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
    //    }
    //}
    //private void BindPayCodesList()
    //{
    //    try
    //    {
    //        DataTable dtb = PayCodesListBAL.GetPayCodesList();
    //        if (dtb.Rows.Count > 0 && dtb != null)
    //        {
    //            gvPayCodesSearch.DataSource = dtb;
    //            gvPayCodesSearch.DataBind();
    //            divPayCodesSearchError.Visible = false;
    //        }
    //        else
    //        {
    //            divPayCodesSearchError.Visible = true;
    //            lblError.Text = Resources.GlobalResource.msgNoRecordFound;
    //            gvPayCodesSearch.Visible = false;
    //        }
    //    }
    //    catch (Exception exp)
    //    {
    //        logExcpUIobj.MethodName = "BindPayCodesList()";
    //        logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_HR_PositionForm.CS";
    //        logExcpUIobj.RecordId = "All";
    //        logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
    //        logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
    //        log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_HR_PositionForm : BindPayCodesList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
    //    }
    //}
    //#endregion  PayCodes search
    private void FillForm(HR_PositionFormUI hR_PositionFormUI)
    {
        try
        {
            DataTable dtb = hR_PositionFormBAL.GetHR_PositionListById(hR_PositionFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtPositionCode.Text = dtb.Rows[0]["PositionCode"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                txtHR_PositionId_SelfGuid.Text = dtb.Rows[0]["tbl_HR_PositionId_Self"].ToString();
                txtHR_PositionId_Self.Text = dtb.Rows[0]["tbl_HR_Position"].ToString();
               // txtPayCodesGuid.Text = dtb.Rows[0]["tbl_PayCodes"].ToString();
               // txtPayCodes.Text = "00000000-0000-0000-0000-000000000001";
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_HR_PositionForm.CS";
            logExcpUIobj.RecordId = this.hR_PositionFormUI.Tbl_HR_PositionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_HR_PositionForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

   
    #endregion Methods
}
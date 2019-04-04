using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class FiscalPeriodDetailsForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    FiscalPeriodDetailsFormBAL fiscalPeriodDetailsFormBAL = new FiscalPeriodDetailsFormBAL();
    FiscalPeriodDetailsFormUI fiscalPeriodDetailsFormUI = new FiscalPeriodDetailsFormUI();
    FiscalPeriodDetailsListBAL fiscalPeriodDetailsListBAL = new FiscalPeriodDetailsListBAL();
    FiscalPeriodListBAL fiscalPeriodListBAL = new FiscalPeriodListBAL();
    FiscalPeriodListUI fiscalPeriodListUI = new FiscalPeriodListUI();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        FiscalPeriodDetailsFormUI fiscalPeriodDetailsFormUI = new FiscalPeriodDetailsFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["FiscalPeriodDetailsId"] != null || Request.QueryString["recordId"] != null)
            {
                fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodDetailsId =( Request.QueryString["FiscalPeriodDetailsId"] != null ? Request.QueryString["FiscalPeriodDetailsId"] : Request.QueryString["recordId"]);


                FillForm(fiscalPeriodDetailsFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnAuditHistory.Visible = true;
                lblHeading.Text = "Update Fiscal Period Details";
            }
            else
            {



                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New Fiscal Period Details";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            fiscalPeriodDetailsFormUI.CreatedBy = SessionContext.UserGuid;
            fiscalPeriodDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodId = txtFiscalPeriodGuid.Text;
            fiscalPeriodDetailsFormUI.PeriodSequence = Convert.ToInt32(txtPeriod.Text);
            fiscalPeriodDetailsFormUI.PeriodName = txtPeriodName.Text;
            fiscalPeriodDetailsFormUI.PeriodDate = Convert.ToDateTime(txtPeriodDate.Text);
            if (chckClosingFinancial.Checked == true)
                fiscalPeriodDetailsFormUI.ClosingFinancial = true;
            else
                fiscalPeriodDetailsFormUI.ClosingFinancial = false;

            if (ChckClosingHR.Checked == true)
                fiscalPeriodDetailsFormUI.ClosingHR = true;
            else
                fiscalPeriodDetailsFormUI.ClosingHR = false;

            if (ChckClosingProcurement.Checked == true)
                fiscalPeriodDetailsFormUI.ClosingProcurement = true;
            else
                fiscalPeriodDetailsFormUI.ClosingProcurement = false;

            if (fiscalPeriodDetailsFormBAL.AddFiscalPeriodDetails(fiscalPeriodDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodDetailsId = Request.QueryString["FiscalPeriodDetailsId"];
            fiscalPeriodDetailsFormUI.ModifiedBy = SessionContext.UserGuid;
            fiscalPeriodDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodId = txtFiscalPeriodGuid.Text;
            fiscalPeriodDetailsFormUI.PeriodSequence = Convert.ToInt32(txtPeriod.Text);
            fiscalPeriodDetailsFormUI.PeriodName = txtPeriodName.Text;
            fiscalPeriodDetailsFormUI.PeriodDate = Convert.ToDateTime(txtPeriodDate.Text);
            if (chckClosingFinancial.Checked == true)
                fiscalPeriodDetailsFormUI.ClosingFinancial = true;
            else
                fiscalPeriodDetailsFormUI.ClosingFinancial = false;

            if (ChckClosingHR.Checked == true)
                fiscalPeriodDetailsFormUI.ClosingHR = true;
            else
                fiscalPeriodDetailsFormUI.ClosingHR = false;

            if (ChckClosingProcurement.Checked == true)
                fiscalPeriodDetailsFormUI.ClosingProcurement = true;
            else
                fiscalPeriodDetailsFormUI.ClosingProcurement = false;

            if (fiscalPeriodDetailsFormBAL.UpdateFiscalPeriodDetails(fiscalPeriodDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm : btnUpdate_Click] An error occured in the processing of Record Id : " + fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodId = Request.QueryString["FiscalPeriodId"];

            if (fiscalPeriodDetailsFormBAL.DeleteFiscalPeriodDetails(fiscalPeriodDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm.CS";
            logExcpUIobj.RecordId = fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm : btnDelete_Click] An error occured in the processing of Record Id : " + fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodId + ". Details : [" + exp.ToString() + "]");
        }
    }


    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Reporting/Balance_Sheet/Supplier_Masters/FiscalPeriodDetailsForm.aspx";
        string recordId = Request.QueryString["FiscalPeriodDetailsId"];
        Response.Redirect("~/System_Settings/AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    } 
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("FiscalPeriodDetailsList.aspx");
    }
    #endregion Events

    #region Events Fiscal Period 
    protected void btnFiscalPeriodSearch_Click(object sender, EventArgs e)
    {
        btnHtmlFiscalPeriodSearch.Visible = false;
        btnHtmlFiscalPeriodClose.Visible = true;
        SearchFiscalPeriodList();

    }
    protected void btnClearFiscalPeriodSearch_Click(object sender, EventArgs e)
    {
        BindFiscalPeriodList();
        gvFiscalPeriodSearch.Visible = true;
        btnHtmlFiscalPeriodSearch.Visible = true;
        btnHtmlFiscalPeriodClose.Visible = false;
        txtFiscalPeriodSearch.Text = "";
        txtFiscalPeriodSearch.Focus();

    }
    protected void btnFiscalPeriodRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindFiscalPeriodList();
    }
    #endregion

    #region Fiscal Period 
    private void SearchFiscalPeriodList()
    {
        try
        {
            FiscalPeriodListBAL fiscalPeriodListBAL = new FiscalPeriodListBAL();
            FiscalPeriodListUI fiscalPeriodListUI = new FiscalPeriodListUI();

            fiscalPeriodListUI.Search = txtFiscalPeriodSearch.Text;

            DataTable dtb = fiscalPeriodListBAL.GetFiscalPeriodListBySearchParameters(fiscalPeriodListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvFiscalPeriodSearch.DataSource = dtb;
                gvFiscalPeriodSearch.DataBind();
                divFiscalPeriodSearchError.Visible = false;
            }
            else
            {
                divFiscalPeriodSearchError.Visible = true;
                lblFiscalPeriodSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvFiscalPeriodSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchFiscalPeriodList()";
            logExcpUIobj.ResourceName = "Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm : SearchFiscalPeriodList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }


    }
    private void BindFiscalPeriodList()
    {
        try
        {
            DataTable dtb = fiscalPeriodListBAL.GetFiscalPeriodList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvFiscalPeriodSearch.DataSource = dtb;
                gvFiscalPeriodSearch.DataBind();
                divFiscalPeriodSearchError.Visible = false;
            }
            else
            {
                divFiscalPeriodSearchError.Visible = true;
                lblFiscalPeriodSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvFiscalPeriodSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindFiscalPeriodList()";
            logExcpUIobj.ResourceName = "Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm : BindFiscalPeriodList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Fiscal Period 

    #region Methods
    private void FillForm(FiscalPeriodDetailsFormUI fiscalPeriodDetailsFormUI)
    {
        try
        {
            DataTable dtb = fiscalPeriodDetailsFormBAL.GetFiscalPeriodDetailsListById(fiscalPeriodDetailsFormUI);

            if (dtb.Rows.Count > 0)
            {

                txtFiscalPeriodGuid.Text = dtb.Rows[0]["tbl_FiscalPeriodId"].ToString();
                txtFiscalPeriod.Text = dtb.Rows[0]["tbl_FiscalPeriod"].ToString();
                txtPeriod.Text = dtb.Rows[0]["PeriodSequence"].ToString();
                txtPeriodName.Text = dtb.Rows[0]["PeriodName"].ToString();
                txtPeriodDate.Text = dtb.Rows[0]["PeriodDate"].ToString();
                ChckClosingHR.Checked = Convert.ToBoolean(dtb.Rows[0]["ClosingHR"].ToString());
                chckClosingFinancial.Checked = Convert.ToBoolean(dtb.Rows[0]["ClosingFinancial"].ToString());
                ChckClosingProcurement.Checked = Convert.ToBoolean(dtb.Rows[0]["ClosingProcurement"].ToString());

            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotLoadData;
                divError.Visible = true;
                divSuccess.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "FillForm()";
            logExcpUIobj.ResourceName = "Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm.CS";
            logExcpUIobj.RecordId = fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods
}
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    FiscalPeriodFormBAL fiscalPeriodFormBAL = new FiscalPeriodFormBAL();
    FiscalPeriodFormUI fiscalPeriodFormUI = new FiscalPeriodFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();


    FiscalPeriodDetailsListBAL fiscalPeriodDetailsListBAL = new FiscalPeriodDetailsListBAL();
    FiscalPeriodDetailsListUI fiscalPeriodDetailsListUI = new FiscalPeriodDetailsListUI();

    FiscalPeriodDetailsFormBAL fiscalPeriodDetailsFormBAL = new FiscalPeriodDetailsFormBAL();
    FiscalPeriodDetailsFormUI fiscalPeriodDetailsFormUI = new FiscalPeriodDetailsFormUI();
    string FiscalPeriodId = null;
    CommonClasses commonClasses = new CommonClasses();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        FiscalPeriodFormUI fiscalPeriodFormUI = new FiscalPeriodFormUI();

        if (!Page.IsPostBack)
        {

            if (Request.QueryString["FiscalPeriodId"] != null || Request.QueryString["recordId"] != null)
            {
                fiscalPeriodFormUI.Tbl_FiscalPeriodId = (Request.QueryString["FiscalPeriodId"] != null ? Request.QueryString["FiscalPeriodId"] : Request.QueryString["recordId"]);
                fiscalPeriodDetailsListUI.Tbl_FiscalPeriodId = (Request.QueryString["FiscalPeriodId"] != null ? Request.QueryString["FiscalPeriodId"] : Request.QueryString["recordId"]);
                BindYearDropDownList();
                FillForm(fiscalPeriodFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update FiscalPeriod";
                btnAuditHistory.Visible = true;
                txtLastDate.ReadOnly = true;
                txtNumberOfPeriod.ReadOnly = true;
                txtFirstDate.ReadOnly = true;
            }
            else
            {

                BindYearDropDownList();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                txtLastDate.ReadOnly = true;
                txtNumberOfPeriod.ReadOnly = true;
                lblHeading.Text = "Add New FiscalPeriod";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {


            fiscalPeriodFormUI.CreatedBy = SessionContext.UserGuid;
            fiscalPeriodFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            fiscalPeriodFormUI.Opt_Year = int.Parse(ddlOpt_Year.SelectedValue.ToString());
            fiscalPeriodFormUI.FirstDayDate = commonClasses.DateFormatMMDDYYY(Convert.ToDateTime(txtFirstDate.Text));

            fiscalPeriodFormUI.LastDayDate = commonClasses.DateFormatMMDDYYY(Convert.ToDateTime(txtLastDate.Text));

            if (chckHistoricalYear.Checked == true)
                fiscalPeriodFormUI.HistoricalYear = true;
            else
                fiscalPeriodFormUI.HistoricalYear = false;
            fiscalPeriodFormUI.NumberOfPeriod = Convert.ToInt32(txtNumberOfPeriod.Text);


            if (fiscalPeriodFormBAL.AddFiscalPeriod(fiscalPeriodFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                string count = gvFiscalPeriodDetails.Rows.Count.ToString();
                foreach (GridViewRow row in gvFiscalPeriodDetails.Rows)
                {
                    fiscalPeriodDetailsFormUI.CreatedBy = SessionContext.UserGuid;
                    fiscalPeriodDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                    fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodId = Convert.ToString(HttpContext.Current.Session["FiscalPeriodID"]);
                    fiscalPeriodDetailsFormUI.PeriodSequence = Convert.ToInt32(((Label)row.FindControl("lblPeriodSequence")).Text);
                    fiscalPeriodDetailsFormUI.PeriodName = Convert.ToString(((Label)row.FindControl("lblPeriodName")).Text);
                    fiscalPeriodDetailsFormUI.PeriodDate = Convert.ToDateTime(((Label)row.FindControl("lblPeriodDate")).Text);

                    CheckBox chckClosingFinancial = new CheckBox();
                    chckClosingFinancial = (CheckBox)row.FindControl("chkClosingFinancial");

                    CheckBox ChckClosingHR = new CheckBox();
                    ChckClosingHR = (CheckBox)row.FindControl("chkClosingHR");

                    CheckBox ChckClosingProcurement = new CheckBox();
                    ChckClosingProcurement = (CheckBox)row.FindControl("chkClosingProcurement");

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
                    fiscalPeriodDetailsFormUI.IsActive = true;
                    if (fiscalPeriodDetailsFormBAL.AddFiscalPeriodDetails(fiscalPeriodDetailsFormUI) == 1)
                    {
                        divSuccess.Visible = true;
                        lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;

                    }
                    else
                    {

                        divError.Visible = true;
                        divSuccess.Visible = false;
                        lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
                    }
                }

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
        #region Fiscal Period
        try
        {
            fiscalPeriodFormUI.Tbl_FiscalPeriodId = Request.QueryString["FiscalPeriodId"];
            fiscalPeriodFormUI.ModifiedBy = SessionContext.UserGuid;
            fiscalPeriodFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            fiscalPeriodFormUI.Opt_Year = int.Parse(ddlOpt_Year.SelectedValue.ToString());


            fiscalPeriodFormUI.FirstDayDate = Convert.ToDateTime(txtFirstDate.Text);
            fiscalPeriodFormUI.LastDayDate = Convert.ToDateTime(txtLastDate.Text);

            if (chckHistoricalYear.Checked == true)
                fiscalPeriodFormUI.HistoricalYear = true;
            else
                fiscalPeriodFormUI.HistoricalYear = false;
            fiscalPeriodFormUI.NumberOfPeriod = Convert.ToInt32(txtNumberOfPeriod.Text);


            if (fiscalPeriodFormBAL.UpdateFiscalPeriod(fiscalPeriodFormUI) == 1)
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

            log.Error("[Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm : btnUpdate_Click] An error occured in the processing of Record Id : " + fiscalPeriodFormUI.Tbl_FiscalPeriodId + ".  Details : [" + exp.ToString() + "]");
        }
        #endregion  Fiscal Period

        #region Fiscal Period Details
        try
        {
            if (gvFiscalPeriodDetails.Rows.Count > 0)
            {
                for (int i = 0; i < gvFiscalPeriodDetails.Rows.Count; i++)
                {
                    fiscalPeriodDetailsFormUI.ModifiedBy = SessionContext.UserGuid;
                    fiscalPeriodDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                    fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodDetailsId = gvFiscalPeriodDetails.DataKeys[i]["tbl_FiscalPeriodDetailsId"].ToString();

                    CheckBox chckClosingFinancial = new CheckBox();
                    chckClosingFinancial = (CheckBox)gvFiscalPeriodDetails.Rows[i].FindControl("chkClosingFinancial");

                    CheckBox ChckClosingHR = new CheckBox();
                    ChckClosingHR = (CheckBox)gvFiscalPeriodDetails.Rows[i].FindControl("chkClosingHR");

                    CheckBox ChckClosingProcurement = new CheckBox();
                    ChckClosingProcurement = (CheckBox)gvFiscalPeriodDetails.Rows[i].FindControl("chkClosingProcurement");

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

                    if (Convert.ToInt32(txtNumberOfPeriod.Text) > i)
                        fiscalPeriodDetailsFormUI.IsActive = true;
                    else
                        fiscalPeriodDetailsFormUI.IsActive = false;


                    if (fiscalPeriodDetailsFormBAL.UpdateFiscalPeriodDetailsClosingModules(fiscalPeriodDetailsFormUI) == 1)
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
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnGridUpdate_Click()";
            logExcpUIobj.ResourceName = "System_Settings_GLAccountFormatForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

        }
        #endregion   Fiscal Period Details
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            fiscalPeriodFormUI.Tbl_FiscalPeriodId = Request.QueryString["FiscalPeriodId"];

            if (fiscalPeriodFormBAL.DeleteFiscalPeriod(fiscalPeriodFormUI) == 1)
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
            fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodDetailsId = gvFiscalPeriodDetails.DataKeys[0]["tbl_FiscalPeriodDetailsId"].ToString();
            if (fiscalPeriodDetailsFormBAL.DeleteFiscalPeriodDetails(fiscalPeriodDetailsFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordDeleteSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnDelete_Click()";
            logExcpUIobj.ResourceName = "Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm.CS";
            logExcpUIobj.RecordId = fiscalPeriodFormUI.Tbl_FiscalPeriodId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm : btnDelete_Click] An error occured in the processing of Record Id : " + fiscalPeriodFormUI.Tbl_FiscalPeriodId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("FiscalPeriodList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Reporting/Balance_Sheet/Supplier_Masters/FiscalPeriodForm.aspx";
        string recordId = Request.QueryString["FiscalPeriodId"];
        Response.Redirect("~/System_Settings/AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    protected void CheckAll_Click(object sender, EventArgs e)
    {
        ToggleCheckState(false);
    }

    protected void UncheckAll_Click(object sender, EventArgs e)
    {
        ToggleCheckState(true);
    }

    private void ToggleCheckState(bool checkState)
    {

        foreach (GridViewRow row in gvFiscalPeriodDetails.Rows)
        {

            CheckBox cf = (CheckBox)row.FindControl("chkClosingFinancial");
            if (cf != null)
                cf.Checked = checkState;
            CheckBox hr = (CheckBox)row.FindControl("chkClosingHR");
            if (hr != null)
                hr.Checked = checkState;
            CheckBox pr = (CheckBox)row.FindControl("chkClosingProcurement");
            if (pr != null)
                pr.Checked = checkState;
        }
    }

    protected void ddlOpt_Year_SelectedIndexChanged(object sender, EventArgs e)
    {
        fiscalPeriodFormUI.Opt_Year = Convert.ToInt32(ddlOpt_Year.SelectedValue);
        FillFormByFinancialYear(fiscalPeriodFormUI);


    }

    protected void txtFirstDate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlOpt_Year.SelectedIndex > 0)
            {
                if (txtFirstDate.Text == null)
                {
                    DateTime today = DateTime.Today;
                    int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);

                    DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);
                    this.txtFirstDate.Text = startOfMonth.ToString("MM/dd/yyyy");
                }
                else
                {
                    DateTime firstDate = Convert.ToDateTime(txtFirstDate.Text);
                    string selectedYear = Convert.ToDateTime(txtFirstDate.Text).Year.ToString();
                    string selectedDay = Convert.ToDateTime(txtFirstDate.Text).Day.ToString();

                    string financialYear = ddlOpt_Year.SelectedItem.Text;

                    if (selectedDay == "1" && selectedYear == financialYear)
                    {
                        int leapYearChk = Convert.ToInt32(financialYear);
                        if (leapYearChk % 400 == 0)
                        {
                            DateTime lastDate = firstDate.AddDays(365);
                            txtLastDate.Text = commonClasses.DateFormatMMDDYYY(Convert.ToDateTime(lastDate)).ToShortDateString();

                            TimeSpan result = lastDate.Subtract(firstDate);
                            int daysOfYear = Convert.ToInt32(result.Days);
                            txtNumberOfPeriod.Text = Convert.ToString(daysOfYear / 30);

                            DataTable dtd = bindGridView();
                            gvFiscalPeriodDetails.DataSource = dtd;
                            gvFiscalPeriodDetails.DataBind();
                        }
                        else
                        {
                            DateTime lastDate = firstDate.AddDays(364);
                            txtLastDate.Text = commonClasses.DateFormatMMDDYYY(Convert.ToDateTime(lastDate)).ToShortDateString();

                            TimeSpan result = lastDate.Subtract(firstDate);
                            int daysOfYear = Convert.ToInt32(result.Days);
                            txtNumberOfPeriod.Text = Convert.ToString(daysOfYear / 30);

                            DataTable dtd = bindGridView();
                            gvFiscalPeriodDetails.DataSource = dtd;
                            gvFiscalPeriodDetails.DataBind();
                        }
                        if (fiscalPeriodDetailsFormBAL.AddFiscalPeriodDetails(fiscalPeriodDetailsFormUI) == 1)
                        {
                            divSuccess.Visible = true;
                            divError.Visible = false;
                            lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "JsFunc", "alert(Resources.GlobalResource.msgdateFinance,)", true);
                    }
                }
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "txtFirstDate_TextChanged()";
            logExcpUIobj.ResourceName = "Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm.CS";
            logExcpUIobj.RecordId = fiscalPeriodFormUI.Tbl_FiscalPeriodId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm : txtFirstDate_TextChanged] An error occured in the processing of Record Id : " + fiscalPeriodFormUI.Tbl_FiscalPeriodId + ". Details : [" + exp.ToString() + "]");
        }
    }

    #region gvFiscalPeriodDetails

    protected void gvFiscalPeriodDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvFiscalPeriodDetails.EditIndex = e.NewEditIndex;
        //BindFiscalPeriodDetails(Convert.ToInt32(txtNumberOfPeriod.Text));

    }

    protected void gvFiscalPeriodDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvFiscalPeriodDetails.EditIndex = -1;
        //BindFiscalPeriodDetails(Convert.ToInt32(txtNumberOfPeriod.Text));

    }

    protected void gvFiscalPeriodDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int gvAccountLength = 0;
        try
        {
            for (int i = 0; i < Convert.ToInt32(txtNumberOfPeriod.Text); i++)
            {
                //if (e.RowIndex == i)
                //    gvAccountLength = gvAccountLength + Convert.ToInt32(((TextBox)(gvFiscalPeriodDetails.Rows[e.RowIndex].FindControl("txtLength"))).Text.Trim());
                //else
                //    gvAccountLength = gvAccountLength + Convert.ToInt32(((Label)gvFiscalPeriodDetails.Rows[i].FindControl("lblLength")).Text);
            }
            if (gvAccountLength <= Convert.ToInt32(txtNumberOfPeriod.Text) && gvAccountLength <= Convert.ToInt32(txtNumberOfPeriod.Text))
            {

                fiscalPeriodDetailsFormUI.ModifiedBy = SessionContext.UserGuid;
                fiscalPeriodDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodId = Request.QueryString["FiscalPeriodDetailsId"];
                fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodDetailsId = gvFiscalPeriodDetails.DataKeys[e.RowIndex]["tbl_FiscalPeriodDetailsId"].ToString();
                fiscalPeriodDetailsFormUI.PeriodSequence = Convert.ToInt32(((TextBox)gvFiscalPeriodDetails.Rows[e.RowIndex].FindControl("txtPeriodSequence")).Text);
                fiscalPeriodDetailsFormUI.PeriodName = ((TextBox)gvFiscalPeriodDetails.Rows[e.RowIndex].FindControl("txtPeriodName")).Text;
                fiscalPeriodDetailsFormUI.PeriodDate = Convert.ToDateTime(((TextBox)gvFiscalPeriodDetails.Rows[e.RowIndex].FindControl("txtPeriodDate")).Text);


                CheckBox chckClosingFinancial = new CheckBox();
                chckClosingFinancial = (CheckBox)gvFiscalPeriodDetails.Rows[e.RowIndex].FindControl("chkEditClosingFinancial");

                CheckBox ChckClosingHR = new CheckBox();
                ChckClosingHR = (CheckBox)gvFiscalPeriodDetails.Rows[e.RowIndex].FindControl("chkEditClosingHR");

                CheckBox ChckClosingProcurement = new CheckBox();
                ChckClosingProcurement = (CheckBox)gvFiscalPeriodDetails.Rows[e.RowIndex].FindControl("chkEditClosingProcurement");

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

                    //BindFiscalPeriodDetails(Convert.ToInt32(txtNumberOfPeriod.Text));
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
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

        }

    }

    #endregion  gvFiscalPeriodDetails

    #endregion Events

    #region Methods
    private void FillForm(FiscalPeriodFormUI fiscalPeriodFormUI)
    {
        try
        {

            DataSet ds = fiscalPeriodFormBAL.GetFiscalPeriodListById(fiscalPeriodFormUI);
            if (ds.Tables.Count > 0)
            {
                DataTable dtblFiscalPeriod = new DataTable();
                dtblFiscalPeriod = ds.Tables[0];
                if (dtblFiscalPeriod.Rows.Count > 0)
                {
                    ddlOpt_Year.SelectedValue = dtblFiscalPeriod.Rows[0]["Opt_Year"].ToString();
                    chckHistoricalYear.Checked = Convert.ToBoolean(dtblFiscalPeriod.Rows[0]["HistoricalYear"].ToString());
                    txtNumberOfPeriod.Text = dtblFiscalPeriod.Rows[0]["NumberOfPeriod"].ToString();
                    txtFirstDate.Text = Convert.ToDateTime(dtblFiscalPeriod.Rows[0]["FirstDayDate"]).ToString("dd/MM/yyyy");
                    txtLastDate.Text = Convert.ToDateTime(dtblFiscalPeriod.Rows[0]["LastDayDate"]).ToString("dd/MM/yyyy");


                    if (ds.Tables.Count > 1)
                    {
                        DataTable dtblFiscalPeriodDetails = new DataTable();
                        dtblFiscalPeriodDetails = ds.Tables[1];
                        if (dtblFiscalPeriodDetails.Rows.Count > 0 && dtblFiscalPeriodDetails != null)
                        {
                            divError.Visible = false;
                            gvFiscalPeriodDetails.Visible = true;

                            gvFiscalPeriodDetails.DataSource = dtblFiscalPeriodDetails;
                            gvFiscalPeriodDetails.DataBind();
                        }
                        else
                        {
                            divError.Visible = true;
                            gvFiscalPeriodDetails.Visible = false;
                            lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                        }
                    }

                }
                else
                {
                    lblError.Text = Resources.GlobalResource.msgCouldNotLoadData;
                    divError.Visible = true;
                }
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "FillForm()";
            logExcpUIobj.ResourceName = "Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm.CS";
            logExcpUIobj.RecordId = fiscalPeriodFormUI.Tbl_FiscalPeriodId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void FillFormByFinancialYear(FiscalPeriodFormUI fiscalPeriodFormUI)
    {
        try
        {

            DataSet ds = fiscalPeriodFormBAL.GetFiscalPeriodListByFinancialYear(fiscalPeriodFormUI);
            if (ds.Tables.Count > 0)
            {
                DataTable dtblFiscalPeriod = new DataTable();
                dtblFiscalPeriod = ds.Tables[0];
                if (dtblFiscalPeriod.Rows.Count > 0)
                {
                    ddlOpt_Year.SelectedValue = dtblFiscalPeriod.Rows[0]["Opt_Year"].ToString();
                    chckHistoricalYear.Checked = Convert.ToBoolean(dtblFiscalPeriod.Rows[0]["HistoricalYear"].ToString());
                    txtNumberOfPeriod.Text = dtblFiscalPeriod.Rows[0]["NumberOfPeriod"].ToString();
                    txtFirstDate.Text = Convert.ToDateTime(dtblFiscalPeriod.Rows[0]["FirstDayDate"]).ToString("dd/MM/yyyy");
                    txtLastDate.Text = Convert.ToDateTime(dtblFiscalPeriod.Rows[0]["LastDayDate"]).ToString("dd/MM/yyyy");


                    if (ds.Tables.Count > 1)
                    {
                        DataTable dtblFiscalPeriodDetails = new DataTable();
                        dtblFiscalPeriodDetails = ds.Tables[1];
                        if (dtblFiscalPeriodDetails.Rows.Count > 0 && dtblFiscalPeriodDetails != null)
                        {
                            divError.Visible = false;
                            gvFiscalPeriodDetails.Visible = true;

                            gvFiscalPeriodDetails.DataSource = dtblFiscalPeriodDetails;
                            gvFiscalPeriodDetails.DataBind();
                        }

                    }

                }
                else
                {

                    txtFirstDate.Text = "";
                    txtLastDate.Text = "";
                    chckHistoricalYear.Checked = false;
                    txtNumberOfPeriod.Text = "";
                    gvFiscalPeriodDetails.DataSource = null;
                    gvFiscalPeriodDetails.DataBind();
                }
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "FillForm()";
            logExcpUIobj.ResourceName = "Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm.CS";
            logExcpUIobj.RecordId = fiscalPeriodFormUI.Tbl_FiscalPeriodId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindYearDropDownList()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_FiscalPeriod";
            optionSetListUI.OptionSetName = "Opt_Year";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlOpt_Year.DataSource = dtb;
                ddlOpt_Year.DataBind();
                ddlOpt_Year.DataTextField = "OptionSetLable";
                ddlOpt_Year.DataValueField = "OptionSetValue";
                ddlOpt_Year.DataBind();
                ddlOpt_Year.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
            }
            else
            {
                ddlOpt_Year.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindOriginDropDownList()";
            logExcpUIobj.ResourceName = "Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm : BindYearDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }

    public void BindFiscalPeriod(FiscalPeriodDetailsListUI fiscalPeriodDetailsListUI)
    {
        try
        {
            DataTable dtb = fiscalPeriodDetailsListBAL.GetFiscalPeriodDetailsListByFiscalPeriodId(fiscalPeriodDetailsListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                divError.Visible = false;
                gvFiscalPeriodDetails.Visible = true;

                gvFiscalPeriodDetails.DataSource = dtb;
                gvFiscalPeriodDetails.DataBind();
            }
            else
            {
                divError.Visible = true;
                gvFiscalPeriodDetails.Visible = false;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodList : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }

    public DataTable bindGridView()
    {
        DateTime FirstDate = Convert.ToDateTime(txtFirstDate.Text);
        DataTable dt = new DataTable();
        dt.Columns.Add("PeriodSequence", typeof(int));
        dt.Columns.Add("PeriodName", typeof(string));
        dt.Columns.Add("PeriodDate", typeof(DateTime)).ToString();
        dt.Columns.Add("ClosingFinancial", typeof(Boolean));
        dt.Columns.Add("ClosingHR", typeof(Boolean));
        dt.Columns.Add("ClosingProcurement", typeof(Boolean));
        dt.Columns.Add("tbl_FiscalPeriodDetailsId", typeof(Guid));
        dt.Columns.Add("tbl_FiscalPeriodId", typeof(Guid));

        for (int count = 0; count < 12; count++)
        {


            dt.Rows.Add(count + 1, count + 1 + " Period", FirstDate.AddMonths(count), true, true, true, "00000000-0000-0000-0000-000000000001", "00000000-0000-0000-0000-000000000001");
        }
        return dt;


    }
    #endregion Methods    
}



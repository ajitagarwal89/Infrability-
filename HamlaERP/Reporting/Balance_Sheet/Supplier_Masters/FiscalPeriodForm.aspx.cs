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

    CommonDateClasses commonDateClasses = new CommonDateClasses();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        FiscalPeriodFormUI fiscalPeriodFormUI = new FiscalPeriodFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["FiscalPeriodId"] != null)
            {
                fiscalPeriodFormUI.Tbl_FiscalPeriodId = Request.QueryString["FiscalPeriodId"];
                fiscalPeriodDetailsListUI.Tbl_FiscalPeriodId = Request.QueryString["FiscalPeriodId"];
                BindYearDropDownList();
                FillForm(fiscalPeriodFormUI, fiscalPeriodDetailsListUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update FiscalPeriod";
            }
            else
            {

                BindYearDropDownList();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
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
            fiscalPeriodFormUI.FirstDayDate = Convert.ToDateTime(txtFirstDate.Text);
            fiscalPeriodFormUI.LastDayDate = Convert.ToDateTime(txtLastDate.Text);
            if (chckHistoricalYear.Checked == true)
                fiscalPeriodFormUI.HistoricalYear = true;
            else
                fiscalPeriodFormUI.HistoricalYear = false;
            fiscalPeriodFormUI.NumberOfPeriod = Convert.ToInt32(txtNumberOfPeriod.Text);


            if (fiscalPeriodFormBAL.AddFiscalPeriod(fiscalPeriodFormUI) == 1)
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
        #region Fiscal Period
        try
        {
            fiscalPeriodFormUI.Tbl_FiscalPeriodId = Request.QueryString["FiscalPeriodId"];
            fiscalPeriodFormUI.ModifiedBy = SessionContext.UserGuid;
            fiscalPeriodFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            fiscalPeriodFormUI.Opt_Year = int.Parse(ddlOpt_Year.SelectedValue.ToString());

            //fiscalPeriodFormUI.FirstDayDate = Convert.ToDateTime(txtFirstDate.Text.Trim());
            //fiscalPeriodFormUI.LastDayDate = DateTime.Parse(txtLastDate.Text.Trim());

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
                BindFiscalPeriodDetails(Convert.ToInt32(txtNumberOfPeriod.Text));
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnGridUpdate_Click()";
            logExcpUIobj.ResourceName = "System_Settings_GLAccountFormatForm.CS";
            logExcpUIobj.RecordId = ""; //gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatDetialsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            //log.Error("[System_Settings_GLAccountFormatForm : btnGridUpdate_Click] An error occured in the processing of Record Id : " + gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatDetialsId + ". Details : [" + exp.ToString() + "]");
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

    protected void txtNumberOfPeriod_TextChanged(object sender, EventArgs e)
    {
        divError.Visible = false;
        divSuccess.Visible = false;
        if (Request.QueryString["FiscalPeriodId"] != null && txtNumberOfPeriod.Text != "")
        {
            int NoOfRecord = Convert.ToInt32(txtNumberOfPeriod.Text);
            if (NoOfRecord > 0)
            {
                BindFiscalPeriodDetails(NoOfRecord);
            }
        }
    }

    protected void ddlOpt_Year_SelectedIndexChanged(object sender, EventArgs e)
    {

        string financialYear = ddlOpt_Year.SelectedItem.Text;
        if (financialYear != null)
        {
            //BindDDLSegment02(segment02ListUI);
            txtFirstDate.Text = "01-01-" + financialYear;
            txtLastDate.Text = "01-12-" + financialYear;
        }

    }

    #region gvFiscalPeriodDetails

    //protected void gvFiscalPeriodDetails_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    gvFiscalPeriodDetails.EditIndex = e.NewEditIndex;
    //    BindFiscalPeriodDetails(Convert.ToInt32(txtNumberOfPeriod.Text));

    //}

    //protected void gvFiscalPeriodDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    gvFiscalPeriodDetails.EditIndex = -1;
    //    BindFiscalPeriodDetails(Convert.ToInt32(txtNumberOfPeriod.Text));

    //}

    //protected void gvFiscalPeriodDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    int gvAccountLength = 0;
    //    try
    //    {
    //        for (int i = 0; i < Convert.ToInt32(txtNumberOfPeriod.Text); i++)
    //        {
    //            //if (e.RowIndex == i)
    //            //    gvAccountLength = gvAccountLength + Convert.ToInt32(((TextBox)(gvFiscalPeriodDetails.Rows[e.RowIndex].FindControl("txtLength"))).Text.Trim());
    //            //else
    //            //    gvAccountLength = gvAccountLength + Convert.ToInt32(((Label)gvFiscalPeriodDetails.Rows[i].FindControl("lblLength")).Text);
    //        }
    //        if (gvAccountLength <= Convert.ToInt32(txtNumberOfPeriod.Text) && gvAccountLength <= Convert.ToInt32(txtNumberOfPeriod.Text))
    //        {

    //            fiscalPeriodDetailsFormUI.ModifiedBy = SessionContext.UserGuid;
    //            fiscalPeriodDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
    //            fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodId = Request.QueryString["FiscalPeriodDetailsId"];
    //            fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodDetailsId = gvFiscalPeriodDetails.DataKeys[e.RowIndex]["tbl_FiscalPeriodDetailsId"].ToString();
    //            fiscalPeriodDetailsFormUI.PeriodSequence = Convert.ToInt32(((TextBox)gvFiscalPeriodDetails.Rows[e.RowIndex].FindControl("txtPeriodSequence")).Text);
    //            fiscalPeriodDetailsFormUI.PeriodName = ((TextBox)gvFiscalPeriodDetails.Rows[e.RowIndex].FindControl("txtPeriodName")).Text;
    //            fiscalPeriodDetailsFormUI.PeriodDate = Convert.ToDateTime(((TextBox)gvFiscalPeriodDetails.Rows[e.RowIndex].FindControl("txtPeriodDate")).Text);


    //            CheckBox chckClosingFinancial = new CheckBox();
    //            chckClosingFinancial = (CheckBox)gvFiscalPeriodDetails.Rows[e.RowIndex].FindControl("chkEditClosingFinancial");

    //            CheckBox ChckClosingHR = new CheckBox();
    //            ChckClosingHR = (CheckBox)gvFiscalPeriodDetails.Rows[e.RowIndex].FindControl("chkEditClosingHR");

    //            CheckBox ChckClosingProcurement = new CheckBox();
    //            ChckClosingProcurement = (CheckBox)gvFiscalPeriodDetails.Rows[e.RowIndex].FindControl("chkEditClosingProcurement");

    //            if (chckClosingFinancial.Checked == true)
    //                fiscalPeriodDetailsFormUI.ClosingFinancial = true;
    //            else
    //                fiscalPeriodDetailsFormUI.ClosingFinancial = false;

    //            if (ChckClosingHR.Checked == true)
    //                fiscalPeriodDetailsFormUI.ClosingHR = true;
    //            else
    //                fiscalPeriodDetailsFormUI.ClosingHR = false;

    //            if (ChckClosingProcurement.Checked == true)
    //                fiscalPeriodDetailsFormUI.ClosingProcurement = true;
    //            else
    //                fiscalPeriodDetailsFormUI.ClosingProcurement = false;

    //            if (fiscalPeriodDetailsFormBAL.UpdateFiscalPeriodDetails(fiscalPeriodDetailsFormUI) == 1)
    //            {

    //                BindFiscalPeriodDetails(Convert.ToInt32(txtNumberOfPeriod.Text));
    //                divSuccess.Visible = true;
    //                divError.Visible = false;
    //                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
    //            }
    //            else
    //            {
    //                divError.Visible = true;
    //                divSuccess.Visible = false;
    //                lblError.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;
    //            }
    //        }
    //        else
    //        {
    //            divError.Visible = true;
    //            divSuccess.Visible = false;
    //            lblError.Text = "Addition of Length should not greater than Account Length and Maximum Acount length";
    //        }
    //    }
    //    catch (Exception exp)
    //    {
    //        logExcpUIobj.MethodName = "btnGridUpdate_Click()";
    //        logExcpUIobj.ResourceName = "System_Settings_GLAccountFormatForm.CS";
    //        logExcpUIobj.RecordId = ""; //gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatDetialsId;
    //        logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
    //        logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

    //        //log.Error("[System_Settings_GLAccountFormatForm : btnGridUpdate_Click] An error occured in the processing of Record Id : " + gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatDetialsId + ". Details : [" + exp.ToString() + "]");
    //    }

    //}



    #endregion  gvFiscalPeriodDetails

    #endregion Events

    #region Methods
    private void FillForm(FiscalPeriodFormUI fiscalPeriodFormUI, FiscalPeriodDetailsListUI fiscalPeriodDetailsListUI)
    {
        try
        {
            DataTable dtb = fiscalPeriodFormBAL.GetFiscalPeriodListById(fiscalPeriodFormUI);

            if (dtb.Rows.Count > 0)
            {
                ddlOpt_Year.SelectedValue = dtb.Rows[0]["Opt_Year"].ToString();
                chckHistoricalYear.Checked = Convert.ToBoolean(dtb.Rows[0]["HistoricalYear"].ToString());
                txtNumberOfPeriod.Text = dtb.Rows[0]["NumberOfPeriod"].ToString();
                txtFirstDate.Text = commonDateClasses.DateInTextBox(dtb.Rows[0]["FirstDayDate"].ToString());
                txtLastDate.Text = commonDateClasses.DateInTextBox(dtb.Rows[0]["LastDayDate"].ToString());

                BindFiscalPeriod(fiscalPeriodDetailsListUI);
                BindFiscalPeriodDetails(Convert.ToInt32(txtNumberOfPeriod.Text));

                if (gvFiscalPeriodDetails.Rows.Count <= 0)
                {
                    InsertFicalPeriodDetails();
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
            }
            else
            {
                ddlOpt_Year.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
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

    public void BindFiscalPeriodDetails(int NoOfRecord)
    {
        try
        {
            fiscalPeriodDetailsListUI.Tbl_FiscalPeriodId = Request.QueryString["FiscalPeriodId"];
            DataTable dtb = fiscalPeriodDetailsListBAL.GetFiscalPeriodDetailsListByFiscalPeriodId(fiscalPeriodDetailsListUI);

            gvFiscalPeriodDetails.DataSource = dtb;
            gvFiscalPeriodDetails.DataBind();


            for (int i = 0; i < gvFiscalPeriodDetails.Rows.Count; i++)
            {
                if (NoOfRecord > i)
                {
                    gvFiscalPeriodDetails.Rows[i].Visible = true;
                }
                else
                {
                    gvFiscalPeriodDetails.Rows[i].Visible = false;
                }
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

    public void InsertFicalPeriodDetails()
    {
        try
        {
            for (int i = 1; i <= 12; i++)
            {
                fiscalPeriodDetailsFormUI.CreatedBy = SessionContext.UserGuid;
                fiscalPeriodDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

                fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodId = Request.QueryString["FiscalPeriodId"];
                fiscalPeriodDetailsFormUI.PeriodSequence = i;

                if (i < 10)
                {
                    fiscalPeriodDetailsFormUI.PeriodName = "Period0" + i.ToString();
                    fiscalPeriodDetailsFormUI.PeriodDate = Convert.ToDateTime("0" + i.ToString() + "-01 -" + ddlOpt_Year.SelectedItem.Text);
                }
                else
                {
                    fiscalPeriodDetailsFormUI.PeriodName = "Period" + i.ToString();
                    fiscalPeriodDetailsFormUI.PeriodDate = Convert.ToDateTime(i.ToString() + "-01 -" + ddlOpt_Year.SelectedItem.Text);
                }

                fiscalPeriodDetailsFormUI.ClosingFinancial = false;
                fiscalPeriodDetailsFormUI.ClosingHR = false;
                fiscalPeriodDetailsFormUI.ClosingProcurement = false;

                if (Convert.ToInt32(txtNumberOfPeriod.Text) > i)
                    fiscalPeriodDetailsFormUI.IsActive = true;
                else
                    fiscalPeriodDetailsFormUI.IsActive = false;

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

            BindFiscalPeriod(fiscalPeriodDetailsListUI);

            BindFiscalPeriodDetails(Convert.ToInt32(txtNumberOfPeriod.Text));

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

    #endregion Methods


}
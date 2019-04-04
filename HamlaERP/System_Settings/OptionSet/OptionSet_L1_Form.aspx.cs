using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;


public partial class System_Settings_OptionSet_OptionSet_L1_Form : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    OptionSetListUI optionSetListUI = new OptionSetListUI();

    OptionSet_L1FormBAL optionSet_L1FormBAL = new OptionSet_L1FormBAL();
    OptionSet_L1FormUI optionSet_L1FormUI = new OptionSet_L1FormUI();

    OptionSet_L1ListBAL optionSet_L1ListBAL = new OptionSet_L1ListBAL();
    OptionSet_L1ListUI optionSet_L1ListUI = new OptionSet_L1ListUI();

    #endregion Data Members
    protected override void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["OptionSet_L1Id"] != null || Request.QueryString["recordId"] != null)
            {
                optionSet_L1FormUI.Tbl_OptionSet_L1Id = (Request.QueryString["OptionSet_L1Id"] != null ? Request.QueryString["OptionSet_L1Id"] : Request.QueryString["recordId"]);
                BindTableDropDown();
                FillForm(optionSet_L1FormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;

                lblHeading.Text = "Update OptionSet_L1";
            }
            else
            {
                BindTableDropDown();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;

                lblHeading.Text = "Add New OptionSet_L1";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            optionSet_L1FormUI.CreatedBy = SessionContext.UserGuid;
            optionSet_L1FormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            if (ddlOptionSet.SelectedIndex > 0)
                optionSet_L1FormUI.Tbl_OptionSetId = ddlOptionSet.SelectedValue.ToString();
            else
                optionSet_L1FormUI.Tbl_OptionSetId = "00000000-0000-0000-0000-000000000001";

            optionSet_L1FormUI.OptionSetLable = txtOptionSetLable.Text;
            optionSet_L1FormUI.OptionSetValue = txtOptionSetValue.Text;


            if (optionSet_L1FormBAL.AddOptionSet_L1(optionSet_L1FormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_OptionSet_OptionSet_L1_Form.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSet_OptionSet_L1_Form : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            optionSet_L1FormUI.Tbl_OptionSet_L1Id = Request.QueryString["OptionSet_L1Id"];
            optionSet_L1FormUI.ModifiedBy = SessionContext.UserGuid;
            optionSet_L1FormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            if (ddlOptionSet.SelectedIndex > 0)
                optionSet_L1FormUI.Tbl_OptionSetId = ddlOptionSet.SelectedValue.ToString();
            else
                optionSet_L1FormUI.Tbl_OptionSetId = "00000000-0000-0000-0000-000000000001";

            optionSet_L1FormUI.OptionSetLable = txtOptionSetLable.Text;
            optionSet_L1FormUI.OptionSetValue = txtOptionSetValue.Text;


            if (optionSet_L1FormBAL.UpdateOptionSet_L1(optionSet_L1FormUI) == 1)
            {
                divSuccess.Visible = true;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;
                divError.Visible = true;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "System_Settings_OptionSet_OptionSet_L1_Form.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSet_OptionSet_L1_Form : btnUpdate_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            optionSet_L1FormUI.Tbl_OptionSet_L1Id = Request.QueryString["OptionSet_L1Id"];

            if (optionSet_L1FormBAL.DeleteOptionSet_L1(optionSet_L1FormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_OptionSetForm.CS";
            logExcpUIobj.RecordId = optionSet_L1FormUI.Tbl_OptionSet_L1Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSetForm : btnDelete_Click] An error occured in the processing of Record Id : " + optionSet_L1FormUI.Tbl_OptionSet_L1Id + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("OptionSet_L1_List.aspx");
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {

    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/System_Settings/OptionSet/OptionSet_L1_Form.aspx";
        string recordId = Request.QueryString["OptionSet_L1Id"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    protected void ddlTables_SelectedIndexChanged(object sender, EventArgs e)
    {

        ddlColoumnByTable.Items.Clear();
        ddlOptionSet.Items.Clear();

        if (ddlTables.SelectedIndex > 0)
        {
            txtTableName.Text = ddlTables.SelectedItem.Text;
            optionSetListUI.TableObjectId = ddlTables.SelectedValue;
            optionSetListUI.TableName = ddlTables.SelectedItem.Text;
            BindColumnByTablesDropDown(optionSetListUI);
        }
        else
        {
            txtOptionSetLable.Text = "";
            txtOptionSetValue.Text = "";
        }
    }

    protected void ddlColoumnByTable_SelectedIndexChanged(object sender, EventArgs e)
    {

        ddlOptionSet.Items.Clear();
        if (ddlColoumnByTable.SelectedIndex > 0)
        {
            txtOptionSetName.Text = ddlColoumnByTable.SelectedItem.Text;
            optionSetListUI.OptionSetName = ddlColoumnByTable.SelectedItem.Text;
            BindOptionSetDropDown(optionSetListUI);
        }
        else
        {
            txtOptionSetLable.Text = "";
            txtOptionSetValue.Text = "";
        }

    }

    protected void ddlOptionSet_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlOptionSet.SelectedIndex > 0)
        {
            optionSet_L1ListUI.Tbl_OptionSetId = ddlOptionSet.SelectedValue;
        }
        else
        {
            txtOptionSetLable.Text = "";
            txtOptionSetValue.Text = "";
        }
    }

    #region Methods
    private void FillForm(OptionSet_L1FormUI optionSet_L1FormUI)
    {
        try
        {

            DataTable dtb = optionSet_L1FormBAL.GetOptionSet_L1ListById(optionSet_L1FormUI);

            if (dtb.Rows.Count > 0)
            {
                BindTableDropDownListById(optionSet_L1ListUI);
                optionSet_L1ListUI.TableName = dtb.Rows[0]["TableName"].ToString();
                optionSet_L1ListUI.TableObjectId = dtb.Rows[0]["TableObjectId"].ToString();
                ddlTables.SelectedItem.Text = optionSet_L1ListUI.TableName;
                ddlTables.SelectedItem.Value = optionSet_L1ListUI.TableObjectId;

                txtTableName.Text = dtb.Rows[0]["TableName"].ToString();
                //BindColumnDropDownListById(optionSet_L1ListUI);
                BindColumnByTablesDropDown(optionSetListUI);
                optionSet_L1ListUI.OptionSetName = dtb.Rows[0]["OptionSetName"].ToString();
                optionSet_L1ListUI.ColumnObjectId = dtb.Rows[0]["ColumnObjectId"].ToString();
                ddlColoumnByTable.SelectedItem.Text = optionSet_L1ListUI.OptionSetName;
                ddlColoumnByTable.SelectedItem.Value = optionSet_L1ListUI.ColumnObjectId;

                txtOptionSetName.Text = dtb.Rows[0]["OptionSetName"].ToString();
                BindOptionSetDropDown(optionSetListUI);
                optionSet_L1ListUI.OptionSetLable = dtb.Rows[0]["tbl_OptionSet"].ToString();
                optionSet_L1ListUI.Tbl_OptionSetId = dtb.Rows[0]["tbl_OptionSetId"].ToString();
                ddlOptionSet.SelectedItem.Text = optionSet_L1ListUI.OptionSetLable;
                ddlOptionSet.SelectedItem.Value = optionSet_L1ListUI.Tbl_OptionSetId;
                BindOptionSetDropDownListById(optionSet_L1ListUI);



                txtOptionSetLable.Text = dtb.Rows[0]["OptionSetLable"].ToString();
                txtOptionSetValue.Text = dtb.Rows[0]["OptionSetValue1"].ToString();

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
            logExcpUIobj.ResourceName = "System_Settings_OptionSetForm.CS";
            logExcpUIobj.RecordId = optionSet_L1FormUI.Tbl_OptionSet_L1Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSetForm : FillForm] An error occured in the processing of Record Id : " + optionSet_L1FormUI.Tbl_OptionSet_L1Id + ". Details : [" + exp.ToString() + "]");
        }
    }

    private void BindTableDropDown()
    {
        try
        {
            DataTable dtb = optionSetListBAL.GetTableList();

            if (dtb.Rows.Count > 0)
            {
                ddlTables.DataSource = dtb;

                ddlTables.DataTextField = "NAME";
                ddlTables.DataValueField = "OBJECT_ID";
                ddlTables.DataBind();
                ddlTables.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
            }
            else
            {
                ddlTables.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindOrganizationTypeDropDown()";
            logExcpUIobj.ResourceName = "System_Settings_OptionSetForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSetForm : BindColumnByTablesDropDown] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindOptionSetDropDownListById(OptionSet_L1ListUI optionSet_L1ListUI)
    {
        try
        {
            OptionSet_L1ListBAL optionSet_L1ListBAL = new OptionSet_L1ListBAL();

            DataTable dtb = optionSet_L1ListBAL.GetOptionSet_L1ListById(optionSet_L1ListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlOptionSet.DataSource = dtb;
                ddlOptionSet.DataBind();
                ddlOptionSet.DataTextField = "OptionSetLable";
                ddlOptionSet.DataValueField = "tbl_OptionSetId";
                ddlOptionSet.DataBind();
                ddlOptionSet.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlOptionSet.SelectedIndex = 0;
            }
            else
            {
                ddlOptionSet.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindOptionSetDropDownListById()";
            logExcpUIobj.ResourceName = "System_Settings_OptionSet_OptionSet_L1_Form.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSet_OptionSet_L1_Form : BindOptionSetDropDownListById] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }


    private void BindColumnByTablesDropDown(OptionSetListUI optionSetListUI)
    {
        try
        {
            DataTable dtb = optionSetListBAL.GetColumnByTablesList(optionSetListUI);

            if (dtb.Rows.Count > 0)
            {
                ddlColoumnByTable.DataSource = dtb;

                ddlColoumnByTable.DataTextField = "ColumnName";
                ddlColoumnByTable.DataValueField = "Column_Id";
                ddlColoumnByTable.DataBind();
                ddlColoumnByTable.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
            }
            else
            {
                ddlColoumnByTable.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindOrganizationTypeDropDown()";
            logExcpUIobj.ResourceName = "System_Settings_OptionSetForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSetForm : BindColumnByTablesDropDown] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindOptionSetDropDown(OptionSetListUI optionSetListUI)
    {
        try
        {
            optionSetListUI.TableName = txtTableName.Text;
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);

            if (dtb.Rows.Count > 0)
            {

                ddlOptionSet.DataSource = dtb;

                ddlOptionSet.DataTextField = "OptionSetLable";
                ddlOptionSet.DataValueField = "Tbl_OptionSetId";
                ddlOptionSet.DataBind();

                ddlOptionSet.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
            }
            else
            {
                ddlOptionSet.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindOptionSetDropDown()";
            logExcpUIobj.ResourceName = "System_Settings_OptionSet_OptionSet_L1_Form.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSet_OptionSet_L1_Form : BindOptionSetDropDown] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    /////////////////
    private void BindTableDropDownListById(OptionSet_L1ListUI optionSet_L1ListUI)
    {
        try
        {
            OptionSet_L1ListBAL optionSet_L1ListBAL = new OptionSet_L1ListBAL();

            DataTable dtb = optionSet_L1ListBAL.GetOptionSet_L1ListById(optionSet_L1ListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlTables.DataSource = dtb;
                ddlTables.DataBind();
                ddlTables.DataTextField = "TableName";
                ddlTables.DataValueField = "TableObjectId";
                ddlTables.DataBind();
                ddlTables.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlTables.SelectedIndex = 0;
            }
            else
            {
                ddlTables.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindOptionSetDropDownListById()";
            logExcpUIobj.ResourceName = "System_Settings_OptionSet_OptionSet_L1_Form.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSet_OptionSet_L1_Form : BindOptionSetDropDownListById] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void BindColumnDropDownListById(OptionSet_L1ListUI optionSet_L1ListUI)
    {
        try
        {
            OptionSet_L1ListBAL optionSet_L1ListBAL = new OptionSet_L1ListBAL();

            DataTable dtb = optionSet_L1ListBAL.GetOptionSet_L1ListById(optionSet_L1ListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlColoumnByTable.DataSource = dtb;
                ddlColoumnByTable.DataBind();
                ddlColoumnByTable.DataTextField = "OptionSetName";
                ddlColoumnByTable.DataValueField = "ColumnObjectId";
                ddlColoumnByTable.DataBind();
                ddlColoumnByTable.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlColoumnByTable.SelectedIndex = 0;
            }
            else
            {
                ddlColoumnByTable.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindOptionSetDropDownListById()";
            logExcpUIobj.ResourceName = "System_Settings_OptionSet_OptionSet_L1_Form.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSet_OptionSet_L1_Form : BindOptionSetDropDownListById] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    ////////////////

    #endregion Methods   
}
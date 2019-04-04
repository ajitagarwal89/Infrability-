using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_OptionSet_OptionSet_L3_Form : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    OptionSet_L3FormBAL optionSet_L3FormBAL = new OptionSet_L3FormBAL();
    OptionSet_L3FormUI optionSet_L3FormUI = new OptionSet_L3FormUI();
    OptionSet_L3ListBAL optionSet_L3ListBAL = new OptionSet_L3ListBAL();
    OptionSet_L3ListUI optionSet_L3ListUI = new OptionSet_L3ListUI();
    OptionSet_L1ListUI optionSet_L1ListUI = new OptionSet_L1ListUI();
    OptionSetListUI optionSetListUI = new OptionSetListUI();
    OptionSet_L2ListUI optionSet_L2ListUI = new OptionSet_L2ListUI();
   
    #endregion Data Members
    protected void Page_Load(object sender, EventArgs e)
    {
        OptionSet_L3FormUI optionSet_L3FormUI = new OptionSet_L3FormUI();
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["OptionSet_L3Id"] != null || Request.QueryString["recordId"] != null)
            {
                optionSet_L3FormUI.Tbl_OptionSet_L3Id = (Request.QueryString["OptionSet_L3Id"] != null ? Request.QueryString["OptionSet_L3Id"] : Request.QueryString["recordId"]);
                BindOptionSetDropDown();
                BindTableDropDown();
                BindOptionSet_L1_DropDown();
                BindOptionSet_L2_DropDown();
                FillForm(optionSet_L3FormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;

                lblHeading.Text = "Update OptionSet_L3";
            }
            else
            {
                BindOptionSetDropDown();
                BindTableDropDown();
                BindOptionSet_L1_DropDown();
                BindOptionSet_L2_DropDown();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;

                lblHeading.Text = "Add New OptionSet_L3";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            optionSet_L3FormUI.CreatedBy = SessionContext.UserGuid;
            optionSet_L3FormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            if (ddlOptionSetId.SelectedIndex > 0)
                optionSet_L3FormUI.Tbl_OptionSetId = ddlOptionSetId.SelectedValue.ToString();
            else
                optionSet_L3FormUI.Tbl_OptionSetId = "00000000-0000-0000-0000-000000000001";
           
            if (ddlOptionSet_L1Id.SelectedIndex > 0)
                optionSet_L3FormUI.Tbl_OptionSet_L1Id = ddlOptionSet_L1Id.SelectedValue.ToString();
            else
                optionSet_L3FormUI.Tbl_OptionSet_L1Id = "00000000-0000-0000-0000-000000000001";
            if (ddlOptionSet_L2Id.SelectedIndex > 0)
                optionSet_L3FormUI.Tbl_OptionSet_L2Id = ddlOptionSet_L2Id.SelectedValue.ToString();
            else
                optionSet_L3FormUI.Tbl_OptionSet_L2Id = "00000000-0000-0000-0000-000000000001";

           
            optionSet_L3FormUI.OptionSetLable = txtOptionSetLable.Text;
            optionSet_L3FormUI.OptionSetValue = txtOptionSetValue.Text;


            if (optionSet_L3FormBAL.AddOptionSet_L3(optionSet_L3FormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_OptionSet_OptionSet_L3_Form.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSet_OptionSet_L3_Form : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            optionSet_L3FormUI.Tbl_OptionSet_L3Id = Request.QueryString["OptionSet_L3Id"];
            optionSet_L3FormUI.ModifiedBy = SessionContext.UserGuid;
            optionSet_L3FormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            optionSet_L3FormUI.Tbl_OptionSetId = ddlOptionSetId.SelectedValue;
            optionSet_L3FormUI.Tbl_OptionSet_L1Id = ddlOptionSet_L1Id.SelectedValue;
            optionSet_L3FormUI.Tbl_OptionSet_L2Id = ddlOptionSet_L2Id.SelectedValue;
            optionSet_L3FormUI.OptionSetLable = txtOptionSetLable.Text;
            optionSet_L3FormUI.OptionSetValue = txtOptionSetValue.Text;


            if (optionSet_L3FormBAL.UpdateOptionSet_L3(optionSet_L3FormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_OptionSet_OptionSet_L3_Form.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSet_OptionSet_L3_Form : btnUpdate_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            optionSet_L3FormUI.Tbl_OptionSet_L2Id = Request.QueryString["OptionSet_L3Id"];

            if (optionSet_L3FormBAL.DeleteOptionSet_L3(optionSet_L3FormUI) == 1)
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
            logExcpUIobj.RecordId = optionSet_L3FormUI.Tbl_OptionSet_L3Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSetForm : btnDelete_Click] An error occured in the processing of Record Id : " + optionSet_L3FormUI.Tbl_OptionSet_L3Id + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("OptionSet_L3_List.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/System_Settings/OptionSet/OptionSet_L3_Form.aspx";
        string recordId = Request.QueryString["OptionSet_L3Id"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }
    protected void ddlTables_SelectedIndexChanged(object sender, EventArgs e)
    {

        ddlColoumnByTable.Items.Clear();
        ddlOptionSetId.Items.Clear();

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

        ddlOptionSetId.Items.Clear();
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

        if (ddlOptionSetId.SelectedIndex > 0)
        {
            optionSet_L2ListUI.Tbl_OptionSetId = ddlOptionSetId.SelectedValue;
        }
        else
        {
            txtOptionSetLable.Text = "";
            txtOptionSetValue.Text = "";
        }
    }
    #region Methods
    private void FillForm(OptionSet_L3FormUI optionSet_L3FormUI)
    {
        try
        {
            DataTable dtb = optionSet_L3FormBAL.GetOptionSet_L3ListById(optionSet_L3FormUI);

            if (dtb.Rows.Count > 0)
            {
                BindTableDropDownListById(optionSet_L1ListUI);
                optionSet_L3ListUI.TableName = dtb.Rows[0]["TableName"].ToString();
                optionSet_L3ListUI.TableObjectId = dtb.Rows[0]["TableObjectId"].ToString();
                ddlTables.SelectedItem.Text = optionSet_L3ListUI.TableName;
                ddlTables.SelectedItem.Value = optionSet_L3ListUI.TableObjectId;

                txtTableName.Text = dtb.Rows[0]["TableName"].ToString();
                //BindColumnDropDownListById(optionSet_L1ListUI);
                BindColumnByTablesDropDown(optionSetListUI);
                optionSet_L3ListUI.OptionSetName = dtb.Rows[0]["OptionSetName"].ToString();
                optionSet_L3ListUI.ColumnObjectId = dtb.Rows[0]["ColumnObjectId"].ToString();
                ddlColoumnByTable.SelectedItem.Text = optionSet_L3ListUI.OptionSetName;
                ddlColoumnByTable.SelectedItem.Value = optionSet_L3ListUI.ColumnObjectId;

                txtOptionSetName.Text = dtb.Rows[0]["OptionSetName"].ToString();
                BindOptionSetDropDown(optionSetListUI);
                optionSet_L3ListUI.OptionSetLable = dtb.Rows[0]["tbl_OptionSetLable"].ToString();
                optionSet_L3ListUI.Tbl_OptionSetId = dtb.Rows[0]["tbl_OptionSetId"].ToString();
                ddlOptionSetId.SelectedItem.Text = optionSet_L3ListUI.OptionSetLable;
                ddlOptionSetId.SelectedItem.Value = optionSet_L3ListUI.Tbl_OptionSetId;
                BindOptionSetDropDownListById(optionSet_L2ListUI);

                //optionSet_L2FormUI.Tbl_OptionSetId = dtb.Rows[0]["tbl_OptionSetId"].ToString();
                //ddlOptionSetId.SelectedValue = optionSet_L2FormUI.Tbl_OptionSetId;
                //BindOptionSetDropDownListById(optionSet_L2ListUI);
                optionSet_L3FormUI.Tbl_OptionSet_L1Id = dtb.Rows[0]["tbl_OptionSet_L1Id"].ToString();
                ddlOptionSet_L1Id.SelectedValue = optionSet_L3FormUI.Tbl_OptionSet_L1Id;
                BindOptionSet_L1DropDownListById(optionSet_L2ListUI);
                // ddlOptionSetId.SelectedValue = dtb.Rows[0]["tbl_OptionSetId"].ToString(); ;
                optionSet_L3FormUI.Tbl_OptionSet_L2Id = dtb.Rows[0]["tbl_OptionSet_L2Id"].ToString();
                ddlOptionSet_L2Id.SelectedValue = optionSet_L3FormUI.Tbl_OptionSet_L2Id;
                BindOptionSet_L2DropDownListById(optionSet_L3ListUI);
                txtOptionSetLable.Text = dtb.Rows[0]["OptionSetLable"].ToString();
                txtOptionSetValue.Text = dtb.Rows[0]["OptionSetValue"].ToString();

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
            logExcpUIobj.ResourceName = "System_Settings_OptionSet_OptionSet_L3_Form.CS";
            logExcpUIobj.RecordId = optionSet_L3FormUI.Tbl_OptionSet_L3Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSet_OptionSet_L3_Form : FillForm] An error occured in the processing of Record Id : " + optionSet_L3FormUI.Tbl_OptionSet_L3Id + ". Details : [" + exp.ToString() + "]");
        }
    }


    private void BindOptionSetDropDown()
    {
        try
        {

            OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
            DataTable dtb = optionSetListBAL.GetOptionSetList();
            if (dtb.Rows.Count > 0)
            {

                ddlOptionSetId.DataSource = dtb;
                ddlOptionSetId.DataBind();
                ddlOptionSetId.DataTextField = "OptionSetLable";
                ddlOptionSetId.DataValueField = "tbl_OptionSetId";
                ddlOptionSetId.DataBind();
                ddlOptionSetId.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlOptionSetId.SelectedIndex = 0;
                
               

            }
            else
            {
                ddlOptionSetId.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindOptionSetDropDown()";
            logExcpUIobj.ResourceName = "System_Settings_OptionSet_OptionSet_L3_Form.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSet_OptionSet_L3_Form : BindOptionSetDropDown] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void BindOptionSet_L1_DropDown()
    {
        try
        {

            OptionSet_L1ListBAL optionSet_L1ListBAL = new OptionSet_L1ListBAL();
            DataTable dtb = optionSet_L1ListBAL.GetOptionSet_L1List();
            if (dtb.Rows.Count > 0)
            {

                ddlOptionSet_L1Id.DataSource = dtb;
                ddlOptionSet_L1Id.DataBind();
                ddlOptionSet_L1Id.DataTextField = "OptionSetLable";
                ddlOptionSet_L1Id.DataValueField = "tbl_OptionSet_L1Id";
                ddlOptionSet_L1Id.DataBind();
                ddlOptionSet_L1Id.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlOptionSet_L1Id.SelectedIndex = 0;
            }
            else
            {
                ddlOptionSetId.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindOptionSet_L1_DropDown()";
            logExcpUIobj.ResourceName = "System_Settings_OptionSet_OptionSet_L3_Form.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSet_OptionSet_L3_Form : BindOptionSet_L1_DropDown] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void BindOptionSet_L2_DropDown()
    {
        try
        {

            OptionSet_L2ListBAL optionSet_L2ListBAL = new OptionSet_L2ListBAL();
            DataTable dtb = optionSet_L2ListBAL.GetOptionSet_L2List() ;
            if (dtb.Rows.Count > 0)
            {

                ddlOptionSet_L2Id.DataSource = dtb;
                ddlOptionSet_L2Id.DataBind();
                ddlOptionSet_L2Id.DataTextField = "OptionSetLable";
                ddlOptionSet_L2Id.DataValueField = "tbl_OptionSet_L2Id";
                ddlOptionSet_L2Id.DataBind();
                ddlOptionSet_L2Id.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlOptionSet_L2Id.SelectedIndex = 0;
            }
            else
            {
                ddlOptionSetId.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindOptionSet_L2_DropDown()";
            logExcpUIobj.ResourceName = "System_Settings_OptionSet_OptionSet_L3_Form.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSet_OptionSet_L3_Form : BindOptionSet_L2_DropDown] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
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
            logExcpUIobj.ResourceName = "System_Settings_OptionSet_OptionSet_L3_Form.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSet_OptionSet_L3_Form : BindOptionSetDropDownListById] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
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
    private void BindOptionSetDropDown(OptionSetListUI optionSetListUI)
    {
        try
        {
            optionSetListUI.TableName = txtTableName.Text;
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);

            if (dtb.Rows.Count > 0)
            {

                ddlOptionSetId.DataSource = dtb;

                ddlOptionSetId.DataTextField = "OptionSetLable";
                ddlOptionSetId.DataValueField = "Tbl_OptionSetId";
                ddlOptionSetId.DataBind();

                ddlOptionSetId.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
            }
            else
            {
                ddlOptionSetId.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
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
    private void BindOptionSetDropDownListById(OptionSet_L2ListUI optionSet_L2ListUI)
    {
        try
        {
            OptionSet_L2ListBAL optionSet_L2ListBAL = new OptionSet_L2ListBAL();

            DataTable dtb = optionSet_L2ListBAL.GetOptionSet_L2ListById(optionSet_L2ListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlOptionSetId.DataSource = dtb;
                ddlOptionSetId.DataBind();
                ddlOptionSetId.DataTextField = "OptionSetLable";
                ddlOptionSetId.DataValueField = "tbl_OptionSetId";
                ddlOptionSetId.DataBind();
                ddlOptionSetId.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlOptionSetId.SelectedIndex = 0;
            }
            else
            {
                ddlOptionSetId.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
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
    private void BindOptionSet_L1DropDownListById(OptionSet_L2ListUI optionSet_L2ListUI)
    {
        try
        {
            OptionSet_L2ListBAL optionSet_L2ListBAL = new OptionSet_L2ListBAL();

            DataTable dtb = optionSet_L2ListBAL.GetOptionSet_L2ListById(optionSet_L2ListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlOptionSetId.DataSource = dtb;
                ddlOptionSetId.DataBind();
                ddlOptionSetId.DataTextField = "tbl_OptionSet_L1Lable";
                ddlOptionSetId.DataValueField = "tbl_OptionSet_L1Id";
                ddlOptionSetId.DataBind();
                ddlOptionSetId.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlOptionSetId.SelectedIndex = 0;
            }
            else
            {
                ddlOptionSetId.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
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
    private void BindOptionSet_L2DropDownListById(OptionSet_L3ListUI optionSet_L3ListUI)
    {
        try
        {
            OptionSet_L3ListBAL optionSet_L3ListBAL = new OptionSet_L3ListBAL();

            DataTable dtb = optionSet_L3ListBAL.GetOptionSet_L3ListById(optionSet_L3ListUI);
            if (dtb.Rows.Count > 0)
            {

                ddlOptionSetId.DataSource = dtb;
                ddlOptionSetId.DataBind();
                ddlOptionSetId.DataTextField = "tbl_OptionSet_L2Lable";
                ddlOptionSetId.DataValueField = "tbl_OptionSet_L2Id";
                ddlOptionSetId.DataBind();
                ddlOptionSetId.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlOptionSetId.SelectedIndex = 0;
            }
            else
            {
                ddlOptionSetId.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
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


    #endregion Methods
}
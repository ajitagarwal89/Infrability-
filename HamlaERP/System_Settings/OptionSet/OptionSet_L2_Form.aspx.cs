using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_OptionSet_OptionSet_L2_Form : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    OptionSetListUI optionSetListUI = new OptionSetListUI();
    OptionSet_L2FormBAL optionSet_L2FormBAL = new OptionSet_L2FormBAL();
    OptionSet_L2FormUI optionSet_L2FormUI = new OptionSet_L2FormUI();
    OptionSet_L2ListBAL optionSet_L2ListBAL = new OptionSet_L2ListBAL();
    OptionSet_L2ListUI optionSet_L2ListUI = new OptionSet_L2ListUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    OptionSet_L1ListUI optionSet_L1ListUI = new OptionSet_L1ListUI();
    #endregion Data Members
    protected void Page_Load(object sender, EventArgs e)
    {
        OptionSet_L2FormUI optionSet_L2FormUI = new OptionSet_L2FormUI();
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["OptionSet_L2Id"] != null || Request.QueryString["recordId"] != null)
            {
                optionSet_L2FormUI.Tbl_OptionSet_L2Id = (Request.QueryString["OptionSet_L2Id"] != null ? Request.QueryString["OptionSet_L2Id"] : Request.QueryString["recordId"]);
                BindOptionSetDropDown();
                BindTableDropDown();
                BindOptionSet_L1DropDownListById();
                FillForm(optionSet_L2FormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;

                lblHeading.Text = "Update OptionSet_L2";
            }
            else
            {
                BindOptionSetDropDown();
                BindTableDropDown();
                BindOptionSet_L1DropDownListById();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;

                lblHeading.Text = "Add New OptionSet_L2";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            optionSet_L2FormUI.CreatedBy = SessionContext.UserGuid;
            optionSet_L2FormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            if (ddlOptionSetId.SelectedIndex > 0)
                optionSet_L2FormUI.Tbl_OptionSetId = ddlOptionSetId.SelectedValue.ToString();
            else
                optionSet_L2FormUI.Tbl_OptionSetId = "00000000-0000-0000-0000-000000000001";
            
            if (ddlOptionSet_L1Id.SelectedIndex > 0)
                optionSet_L2FormUI.Tbl_OptionSet_L1Id = ddlOptionSet_L1Id.SelectedValue.ToString();
            else
                optionSet_L2FormUI.Tbl_OptionSet_L1Id = "00000000-0000-0000-0000-000000000001";
            optionSet_L2FormUI.OptionSetLable = txtOptionSetLable.Text;
            optionSet_L2FormUI.OptionSetValue = txtOptionSetValue.Text;


            if (optionSet_L2FormBAL.AddOptionSet_L2(optionSet_L2FormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_OptionSet_OptionSet_L2_Form.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSet_OptionSet_L2_Form : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            optionSet_L2FormUI.Tbl_OptionSet_L2Id = Request.QueryString["OptionSet_L2Id"];
            optionSet_L2FormUI.ModifiedBy = SessionContext.UserGuid;
            optionSet_L2FormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            if (ddlOptionSetId.SelectedIndex > 0)
                optionSet_L2FormUI.Tbl_OptionSetId = ddlOptionSetId.SelectedValue.ToString();
            else
                optionSet_L2FormUI.Tbl_OptionSetId = "00000000-0000-0000-0000-000000000001";
           
            if (ddlOptionSet_L1Id.SelectedIndex > 0)
                optionSet_L2FormUI.Tbl_OptionSet_L1Id = ddlOptionSet_L1Id.SelectedValue.ToString();
            else
                optionSet_L2FormUI.Tbl_OptionSet_L1Id = "00000000-0000-0000-0000-000000000001";
           
            optionSet_L2FormUI.OptionSetLable = txtOptionSetLable.Text;
            optionSet_L2FormUI.OptionSetValue = txtOptionSetValue.Text;


            if (optionSet_L2FormBAL.UpdateOptionSet_L2(optionSet_L2FormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_OptionSet_OptionSet_L2_Form.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSet_OptionSet_L2_Form : btnUpdate_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            optionSet_L2FormUI.Tbl_OptionSet_L2Id = Request.QueryString["OptionSet_L2Id"];

            if (optionSet_L2FormBAL.DeleteOptionSet_L2(optionSet_L2FormUI) == 1)
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
            logExcpUIobj.RecordId = optionSet_L2FormUI.Tbl_OptionSet_L2Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSetForm : btnDelete_Click] An error occured in the processing of Record Id : " + optionSet_L2FormUI.Tbl_OptionSet_L2Id + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("OptionSet_L2_List.aspx");
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {

    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/System_Settings/OptionSet/OptionSet_L2_Form.aspx";
        string recordId = Request.QueryString["OptionSet_L2Id"];
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
    private void FillForm(OptionSet_L2FormUI optionSet_L2FormUI)
    {
        try
        {
            DataTable dtb = optionSet_L2FormBAL.GetOptionSet_L2ListById(optionSet_L2FormUI);

            if (dtb.Rows.Count > 0)
            {
                BindTableDropDownListById(optionSet_L1ListUI);
                optionSet_L2ListUI.TableName = dtb.Rows[0]["TableName"].ToString();
                optionSet_L2ListUI.TableObjectId = dtb.Rows[0]["TableObjectId"].ToString();
                ddlTables.SelectedItem.Text = optionSet_L2ListUI.TableName;
                ddlTables.SelectedItem.Value = optionSet_L2ListUI.TableObjectId;

                txtTableName.Text = dtb.Rows[0]["TableName"].ToString();
                //BindColumnDropDownListById(optionSet_L1ListUI);
                BindColumnByTablesDropDown(optionSetListUI);
                optionSet_L2ListUI.OptionSetName = dtb.Rows[0]["OptionSetName"].ToString();
                optionSet_L2ListUI.ColumnObjectId = dtb.Rows[0]["ColumnObjectId"].ToString();
                ddlColoumnByTable.SelectedItem.Text = optionSet_L2ListUI.OptionSetName;
                ddlColoumnByTable.SelectedItem.Value = optionSet_L2ListUI.ColumnObjectId;

                txtOptionSetName.Text = dtb.Rows[0]["OptionSetName"].ToString();
                BindOptionSetDropDown(optionSetListUI);
                optionSet_L2ListUI.OptionSetLable = dtb.Rows[0]["tbl_OptionSetLable"].ToString();
                optionSet_L2ListUI.Tbl_OptionSetId = dtb.Rows[0]["tbl_OptionSetId"].ToString();
                ddlOptionSetId.SelectedItem.Text = optionSet_L2ListUI.OptionSetLable;
                ddlOptionSetId.SelectedItem.Value = optionSet_L2ListUI.Tbl_OptionSetId;
                BindOptionSetDropDownListById(optionSet_L2ListUI);

                //optionSet_L2FormUI.Tbl_OptionSetId = dtb.Rows[0]["tbl_OptionSetId"].ToString();
                //ddlOptionSetId.SelectedValue = optionSet_L2FormUI.Tbl_OptionSetId;
                //BindOptionSetDropDownListById(optionSet_L2ListUI);
                optionSet_L2FormUI.Tbl_OptionSet_L1Id= dtb.Rows[0]["tbl_OptionSet_L1Id"].ToString();
                ddlOptionSet_L1Id.SelectedValue = optionSet_L2FormUI.Tbl_OptionSet_L1Id;
                BindOptionSet_L1DropDownListById(optionSet_L2ListUI);

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
            logExcpUIobj.ResourceName = "System_Settings_OptionSet_OptionSet_L2_Form.CS";
            logExcpUIobj.RecordId = optionSet_L2FormUI.Tbl_OptionSet_L2Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSet_OptionSet_L2_Form : FillForm] An error occured in the processing of Record Id : " + optionSet_L2FormUI.Tbl_OptionSet_L2Id + ". Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "System_Settings_OptionSet_OptionSet_L2_Form.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSet_OptionSet_L2_Form : BindOptionSetDropDown] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void BindOptionSet_L1DropDownListById()
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
            logExcpUIobj.MethodName = "BindOptionSetDropDown()";
            logExcpUIobj.ResourceName = "System_Settings_OptionSet_OptionSet_L2_Form.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSet_OptionSet_L2_Form : BindOptionSetDropDown] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
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
                ddlOptionSetId.DataTextField = "OptionSetLable";
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
    #endregion Methods
}
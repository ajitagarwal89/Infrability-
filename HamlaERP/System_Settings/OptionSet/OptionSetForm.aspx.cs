using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_OptionSetForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    OptionSetFormBAL optionSetFormBAL = new OptionSetFormBAL();
    OptionSetFormUI optionSetFormUI = new OptionSetFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    OptionSetListUI optionSetListUI = new OptionSetListUI();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        OptionSetFormUI optionSetFormUI = new OptionSetFormUI();      

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["OptionSetId"] != null || Request.QueryString["recordId"] != null)
            {
                optionSetFormUI.Tbl_OptionSetId = (Request.QueryString["OptionSetId"] != null ? Request.QueryString["OptionSetId"] : Request.QueryString["recordId"]);
                BindTableDropDown();
                FillForm(optionSetFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;

                lblHeading.Text = "Update Option Set";
            }
            else
            {
                BindTableDropDown();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;

                lblHeading.Text = "Add New Option Set";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            optionSetFormUI.CreatedBy = SessionContext.UserGuid;
            optionSetFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            optionSetFormUI.TableName = txtTableName.Text;            
            optionSetFormUI.OptionSetName = txtOptionSetName.Text;
            optionSetFormUI.OptionSetLable = txtOptionSetLable.Text;
            optionSetFormUI.OptionSetValue = Convert.ToInt32(txtOptionSetValue.Text);
            optionSetFormUI.TableObjectId = Convert.ToString(txtTableObjectId.Text);
            optionSetFormUI.ColumnObjectId = txtColumn.Text;

            if (optionSetFormBAL.AddOptionSet(optionSetFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_OptionSetForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSetForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            optionSetFormUI.ModifiedBy = SessionContext.UserGuid;
            optionSetFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            optionSetFormUI.Tbl_OptionSetId = Request.QueryString["OptionSetId"];

            optionSetFormUI.TableName = txtTableName.Text;
            optionSetFormUI.TableObjectId = Convert.ToString(txtTableObjectId.Text);
            
            optionSetFormUI.OptionSetName = txtOptionSetName.Text;
            optionSetFormUI.OptionSetLable = txtOptionSetLable.Text;
            optionSetFormUI.OptionSetValue = int.Parse(txtOptionSetValue.Text);

            optionSetFormUI.ColumnObjectId = txtColumn.Text;
            if (optionSetFormBAL.UpdateOptionSet(optionSetFormUI) == 1)
            {
                divSuccess.Visible = true;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "System_Settings_OptionSetForm.CS";
            logExcpUIobj.RecordId = optionSetFormUI.Tbl_OptionSetId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSetForm : btnUpdate_Click] An error occured in the processing of Record Id : " + optionSetFormUI.Tbl_OptionSetId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            optionSetFormUI.Tbl_OptionSetId = Request.QueryString["OptionSetId"];

            if (optionSetFormBAL.DeleteOptionSet(optionSetFormUI) == 1)
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
            logExcpUIobj.RecordId = optionSetFormUI.Tbl_OptionSetId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSetForm : btnDelete_Click] An error occured in the processing of Record Id : " + optionSetFormUI.Tbl_OptionSetId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("OptionSetList.aspx");
    }

    protected void ddlTables_SelectedIndexChanged(object sender, EventArgs e)
    {
        OptionSetListUI optionSetListUI = new OptionSetListUI();

        if (ddlTables.SelectedValue == "0" || ddlTables.SelectedIndex == 0)
        {
            ddlColoumnByTable.SelectedIndex = 0;
            txtTableName.Text = "";
            txtOptionSetName.Text = "";
            txtOptionSetLable.Text = "";
            txtOptionSetValue.Text = "";
        }

        else
        {
            optionSetListUI.TableObjectId = ddlTables.SelectedValue;
            txtTableName.Text = ddlTables.SelectedItem.Text;
            txtTableObjectId.Text = Convert.ToString(ddlTables.SelectedValue);
            BindColumnByTablesDropDown(optionSetListUI);
        }
    }

    protected void ddlColoumnByTable_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlColoumnByTable.SelectedValue == "0" || ddlColoumnByTable.SelectedIndex == 0)
        {
            txtOptionSetName.Text = string.Empty;
        }
        else
        {
            txtOptionSetName.Text = ddlColoumnByTable.SelectedItem.Text;
            txtColumn.Text = Convert.ToString(ddlColoumnByTable.SelectedValue);

        }

    }   

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/System_Settings/OptionSetForm.aspx";
        string recordId = Request.QueryString["OptionSetId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }
    #endregion Events

    #region Methods
    private void FillForm(OptionSetFormUI optionSetFormUI)
    {
        try
        {
            DataTable dtb = optionSetFormBAL.GetOptionSetListById(optionSetFormUI);

            if (dtb.Rows.Count > 0)
            {               
                string tableObjectId = dtb.Rows[0]["TableObjectId"].ToString();
                ddlTables.SelectedValue = tableObjectId;
                optionSetListUI.TableObjectId = tableObjectId;
                txtTableObjectId.Text = tableObjectId;
                txtTableName.Text = dtb.Rows[0]["TableName"].ToString();


                BindColumnByTablesDropDown(optionSetListUI);
                string columnObjectId = dtb.Rows[0]["ColumnId"].ToString();
                ddlColoumnByTable.SelectedValue = columnObjectId;
                txtColumn.Text = columnObjectId;
                txtOptionSetName.Text = dtb.Rows[0]["OptionSetName"].ToString();

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
            logExcpUIobj.ResourceName = "System_Settings_OptionSetForm.CS";
            logExcpUIobj.RecordId = optionSetFormUI.Tbl_OptionSetId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OptionSetForm : FillForm] An error occured in the processing of Record Id : " + optionSetFormUI.Tbl_OptionSetId + ". Details : [" + exp.ToString() + "]");
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


    #endregion Methods



}
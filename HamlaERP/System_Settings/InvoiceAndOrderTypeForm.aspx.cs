using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class InvoiceAndOrderTypeForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    InvoiceAndOrderTypeFormBAL invoiceAndOrderTypeFormBAL = new InvoiceAndOrderTypeFormBAL();

    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();


    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        InvoiceAndOrderTypeFormUI invoiceAndOrderTypeFormUI = new InvoiceAndOrderTypeFormUI();

        if (!Page.IsPostBack)
        {
            BindInvoiceTypeDropDownList();
            if (Request.QueryString["InvoiceAndOrderTypeId"] != null)
            {
                invoiceAndOrderTypeFormUI.Tbl_InvoiceAndOrderTypeId = Request.QueryString["InvoiceAndOrderTypeId"];

                FillForm(invoiceAndOrderTypeFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Invoice And Order Type";
            }
            else
            {
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New  Invoice And Order Type";
            }
        }
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            InvoiceAndOrderTypeFormUI invoiceAndOrderTypeFormUI = new InvoiceAndOrderTypeFormUI();
            invoiceAndOrderTypeFormUI.CreatedBy = SessionContext.UserGuid;
            invoiceAndOrderTypeFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            invoiceAndOrderTypeFormUI.Number = txtInvNo.Text;
            invoiceAndOrderTypeFormUI.Opt_InvoiceAndOrderType = int.Parse(ddlOpt_InvoiceAndOrderType.SelectedValue.ToString());

            if (invoiceAndOrderTypeFormBAL.AddInvoiceAndOrderType(invoiceAndOrderTypeFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_InvoiceAndOrderTypeForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_InvoiceAndOrderTypeForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        InvoiceAndOrderTypeFormUI invoiceAndOrderTypeFormUI = new InvoiceAndOrderTypeFormUI();
        try
        {

            invoiceAndOrderTypeFormUI.ModifiedBy = SessionContext.UserGuid;
            invoiceAndOrderTypeFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            invoiceAndOrderTypeFormUI.Tbl_InvoiceAndOrderTypeId = Request.QueryString["InvoiceAndOrderTypeId"];
            invoiceAndOrderTypeFormUI.Number = txtInvNo.Text;
            invoiceAndOrderTypeFormUI.Opt_InvoiceAndOrderType = int.Parse(ddlOpt_InvoiceAndOrderType.SelectedValue.ToString());

            if (invoiceAndOrderTypeFormBAL.UpdateInvoiceAndOrderType(invoiceAndOrderTypeFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                divSuccess.Visible = false;
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "System_Settings_InvoiceAndOrderTypeForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_InvoiceAndOrderTypeForm : btnUpdate_Click] An error occured in the processing of Record Id : " + invoiceAndOrderTypeFormUI.Tbl_InvoiceAndOrderTypeId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        InvoiceAndOrderTypeFormUI invoiceAndOrderTypeFormUI = new InvoiceAndOrderTypeFormUI();
        try
        {
            invoiceAndOrderTypeFormUI.Tbl_InvoiceAndOrderTypeId = Request.QueryString["InvoiceAndOrderTypeId"];

            if (invoiceAndOrderTypeFormBAL.DeleteInvoiceAndOrderType(invoiceAndOrderTypeFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_InvoiceAndOrderTypeForm.CS";
            logExcpUIobj.RecordId = invoiceAndOrderTypeFormUI.Tbl_InvoiceAndOrderTypeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_InvoiceAndOrderTypeForm : btnDelete_Click] An error occured in the processing of Record Id : " + invoiceAndOrderTypeFormUI.Tbl_InvoiceAndOrderTypeId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("InvoiceAndOrderTypeList.aspx");
    }
    #endregion Events

    #region Methods
    private void FillForm(InvoiceAndOrderTypeFormUI invoiceAndOrderTypeFormUI)
    {
        try
        {
            DataTable dtb = invoiceAndOrderTypeFormBAL.GetInvoiceAndOrderTypeListById(invoiceAndOrderTypeFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtInvNo.Text = dtb.Rows[0]["Number"].ToString();
                ddlOpt_InvoiceAndOrderType.SelectedValue = dtb.Rows[0]["tbl_InvoiceAndOrderTypeId"].ToString();
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
            logExcpUIobj.ResourceName = "System_Settings_BatchForm.CS";
            logExcpUIobj.RecordId = invoiceAndOrderTypeFormUI.Tbl_InvoiceAndOrderTypeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_InvoiceAndOrderTypeForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void BindInvoiceTypeDropDownList()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_InvoiceAndOrderType";
            optionSetListUI.OptionSetName = "Opt_InvoiceAndOrderType";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {
                ddlOpt_InvoiceAndOrderType.DataSource = dtb;
                ddlOpt_InvoiceAndOrderType.DataBind();
                ddlOpt_InvoiceAndOrderType.DataTextField = "OptionSetLable";
                ddlOpt_InvoiceAndOrderType.DataValueField = "OptionSetValue";
                ddlOpt_InvoiceAndOrderType.DataBind();
            }
            else
            {
                ddlOpt_InvoiceAndOrderType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindOriginDropDownList()";
            logExcpUIobj.ResourceName = "System_Settings_InvoiceAndOrderTypeForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_InvoiceAndOrderTypeForm : BindInvoiceTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods
}
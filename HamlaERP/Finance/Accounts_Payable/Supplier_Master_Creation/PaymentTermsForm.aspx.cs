using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Accounts_Payable_Supplier_Master_Creation_PaymentTermsForm : PageBase
{
    #region Data Members

    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    PaymentTermsFormBAL paymentTermsFormBAL = new PaymentTermsFormBAL();
    PaymentTermsFormUI paymentTermsFormUI = new PaymentTermsFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
  
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        PaymentTermsFormUI paymentTermsFormUI = new PaymentTermsFormUI();
        if (!Page.IsPostBack)
        {
            BindDiscountTypeDropDownList();
            if (Request.QueryString["PaymentTerms_Id"] != null)
            {
                paymentTermsFormUI.Tbl_PaymentTermsId = Request.QueryString["PaymentTerms_Id"];
                BindDiscountTypeDropDownList();
                FillForm(paymentTermsFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update PaymentTerm";
            }
            else
            {
                BindDiscountTypeDropDownList();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New PaymentTerm";
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
       try
        {
            paymentTermsFormUI.CreatedBy = SessionContext.UserGuid;
            paymentTermsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            paymentTermsFormUI.Opt_DiscountType = int.Parse(ddlOpt_DiscountType.SelectedValue.ToString());
            paymentTermsFormUI.PaymentTermsName = txtName.Text;
            paymentTermsFormUI.DueInDays = int.Parse(txtDueInDays.Text);
            paymentTermsFormUI.DiscountInDays = int.Parse(txtDiscountInDays.Text);
            paymentTermsFormUI.DiscountTypeValue = decimal.Parse(txtDiscountTypeValue.Text);
            if (chkSalesOrPurchase.Checked)
            {
                paymentTermsFormUI.SalesOrPurchase = true;
            }
            else
            {
                paymentTermsFormUI.SalesOrPurchase = false;
            }
            if (paymentTermsFormBAL.AddPaymentTerms(paymentTermsFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
                divError.Visible = true;
                divSuccess.Visible = false;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_PaymentTermsForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_Supplier_Master_Creation_PaymentTermsForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        PaymentTermsFormUI paymentTermsFormUI = new PaymentTermsFormUI();
        try
        {
            paymentTermsFormUI.ModifiedBy = SessionContext.UserGuid;
            paymentTermsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            paymentTermsFormUI.PaymentTermsName = txtName.Text;
            paymentTermsFormUI.DiscountTypeValue = decimal.Parse(txtDiscountTypeValue.Text);
            paymentTermsFormUI.Opt_DiscountType = int.Parse(ddlOpt_DiscountType.SelectedValue);
            paymentTermsFormUI.DueInDays = int.Parse(txtDueInDays.Text);
            paymentTermsFormUI.DiscountInDays = int.Parse(txtDiscountInDays.Text);
            paymentTermsFormUI.Tbl_PaymentTermsId = Request.QueryString["PaymentTerms_Id"];
            if (chkSalesOrPurchase.Checked)
            {
                paymentTermsFormUI.SalesOrPurchase = true;
            }
            else
            {
                paymentTermsFormUI.SalesOrPurchase = false;
            }
            if (paymentTermsFormBAL.UpdatePaymentTerms(paymentTermsFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
                paymentTermsFormUI.Tbl_PaymentTermsId = Request.QueryString["PaymentTerms_Id"];
                BindDiscountTypeDropDownList();
                FillForm(paymentTermsFormUI);
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_PaymentTermsForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Supplier_Master_Creation_PaymentTermsForm : btnUpdate_Click] An error occured in the processing of Record Id : " + paymentTermsFormUI.Tbl_PaymentTermsId + ".  Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            paymentTermsFormUI.Tbl_PaymentTermsId = Request.QueryString["PaymentTerms_Id"];
            if (paymentTermsFormBAL.DeletePaymentTerms(paymentTermsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_PaymentTermsForm.CS";
            logExcpUIobj.RecordId = paymentTermsFormUI.Tbl_PaymentTermsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_Supplier_Master_Creation_PaymentTermsForm : btnDelete_Click] An error occured in the processing of Record Id : " + paymentTermsFormUI.Tbl_PaymentTermsId + ". Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaymentTermsList.aspx");
    }
  
    #endregion Events

    #region Methods
    private void FillForm(PaymentTermsFormUI paymentTermsFormUI)
    {
        try
        {
            DataTable dtb = paymentTermsFormBAL.GetPaymentTermsListById(paymentTermsFormUI);
            if (dtb.Rows.Count > 0)
            {
                txtDiscountInDays.Text = dtb.Rows[0]["DiscountInDays"].ToString();
                txtDiscountTypeValue.Text = dtb.Rows[0]["DiscountTypeValue"].ToString();
                txtDueInDays.Text = dtb.Rows[0]["DueInDays"].ToString();
                txtName.Text = dtb.Rows[0]["PaymentTermsName"].ToString();
                ddlOpt_DiscountType.SelectedValue = dtb.Rows[0]["Opt_DiscountType"].ToString();
                chkSalesOrPurchase.Checked = Convert.ToBoolean(dtb.Rows[0]["SalesOrPurchase"].ToString());
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_PaymentTermsForm.CS";
            logExcpUIobj.RecordId = this.paymentTermsFormUI.Tbl_PaymentTermsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_Supplier_Master_Creation_PaymentTermsForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void BindDiscountTypeDropDownList()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_PaymentTerms";
            optionSetListUI.OptionSetName = "Opt_DiscountType";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {
                ddlOpt_DiscountType.DataSource = dtb;
                ddlOpt_DiscountType.DataBind();
                ddlOpt_DiscountType.DataTextField = "OptionSetLable";
                ddlOpt_DiscountType.DataValueField = "OptionSetValue";
                ddlOpt_DiscountType.DataBind();
            }
            else
            {
                ddlOpt_DiscountType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindDiscountTypeDropDownList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Supplier_Master_Creation_PaymentTermsForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_Supplier_Master_Creation_PaymentTermsForm : BindDiscountTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #endregion Methods
}
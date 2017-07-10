using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_BudgetForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    BudgetFormBAL budgetFormBAL = new BudgetFormBAL();
    BudgetFormUI budgetFormUI = new BudgetFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();

    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        BudgetFormUI budgetFormUI = new BudgetFormUI();

        if (!Page.IsPostBack)
        {

            if (Request.QueryString["BudgetId"] != null)
            {
                budgetFormUI.Tbl_BudgetId = Request.QueryString["BudgetId"];
                BindOptionSetLisDropDown();
                BindOptionBudgetYearDropDown();
                FillForm(budgetFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Budget";
            }
            else
            {

                BindOptionBudgetYearDropDown();
                BindOptionSetLisDropDown();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Budget";
            }
        }
    }

   

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            budgetFormUI.CreatedBy = SessionContext.UserGuid;
            budgetFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            budgetFormUI.BudgetNumber = txtBudgetNumber.Text;
            budgetFormUI.Description = txtDescription.Text;
            budgetFormUI.Opt_BasedOn = Convert.ToByte(ddlBasedOn.SelectedValue);
            budgetFormUI.Opt_BudgetYear = Convert.ToByte(ddlBudgetYear.SelectedValue);

            if (chkAnnual.Checked)
            {
                budgetFormUI.AnnualCapital = true;
            }
            else
            {
                budgetFormUI.AnnualCapital = false;
            }

            budgetFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text;

            if (ChkDisplay.Checked)
            {
                budgetFormUI.Display = true;
            }
            else
            {
                budgetFormUI.Display = false;
            }
            if (budgetFormBAL.AddBudget(budgetFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BudgetForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BudgetForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            budgetFormUI.ModifiedBy = SessionContext.UserGuid;
            budgetFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            budgetFormUI.Tbl_BudgetId = Request.QueryString["BudgetId"];
            budgetFormUI.BudgetNumber = txtBudgetNumber.Text;
            budgetFormUI.Description = txtDescription.Text;
            budgetFormUI.Opt_BasedOn = Convert.ToByte(ddlBasedOn.SelectedValue);
            budgetFormUI.Opt_BudgetYear = Convert.ToByte(ddlBudgetYear.SelectedValue);
            budgetFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text;
            if (chkAnnual.Checked==true)
            {
                budgetFormUI.AnnualCapital = true;
            }
            else
            {
                budgetFormUI.AnnualCapital = false;
            }                      

            if (ChkDisplay.Checked==true)
            {
                budgetFormUI.Display = true;
            }
            else
            {
                budgetFormUI.Display = false;
            }


            if (budgetFormBAL.UpdateBudget(budgetFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BudgetForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BudgetForm : btnUpdate_Click] An error occured in the processing of Record Id : " + budgetFormUI.Tbl_BudgetId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            budgetFormUI.Tbl_BudgetId = Request.QueryString["BudgetId"];

            if (budgetFormBAL.DeleteBudget(budgetFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BudgetForm.CS";
            logExcpUIobj.RecordId = budgetFormUI.Tbl_BudgetId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BudgetForm : btnDelete_Click] An error occured in the processing of Record Id : " + budgetFormUI.Tbl_BudgetId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("BudgetList.aspx");
    }

    #region Events GL Account Search
    protected void btnGLAccountSearch_Click(object sender, EventArgs e)
    {
        btnHtmlGLAccountSearch.Visible = false;
        btnHtmlGLAccountClose.Visible = true;
        SearchGLAccountList();

    }
    protected void btnClearGLAccountSearch_Click(object sender, EventArgs e)
    {
        BindGLAccountList();
        gvGLAccountSearch.Visible = true;
        btnHtmlGLAccountSearch.Visible = true;
        btnHtmlGLAccountClose.Visible = false;
        txtGLAccountSearch.Text = "";
        txtGLAccountSearch.Focus();

    }
    protected void btnGLAccountRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindGLAccountList();
    }
    #endregion
    #endregion Events

    #region Methods Search And Bind

    #region GLAccount Search
    private void SearchGLAccountList()
    {
        try
        {
            GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
            GLAccountListUI gLAccountListUI = new GLAccountListUI();

            gLAccountListUI.Search = txtGLAccountSearch.Text;

            DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountSearch.DataSource = dtb;
                gvGLAccountSearch.DataBind();
                divGLAccountSearchError.Visible = false;
            }
            else
            {
                divGLAccountSearchError.Visible = true;
                lblGLAccountSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchGLAccountList()";
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountSummaryForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountSummaryForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }


    }
    private void BindGLAccountList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountSearch.DataSource = dtb;
                gvGLAccountSearch.DataBind();
                divGLAccountSearchError.Visible = false;
            }
            else
            {
                divGLAccountSearchError.Visible = true;
                lblGLAccountSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindGLAccountList()";
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountSummaryForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountSummaryForm : BindGLAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion
    private void FillForm(BudgetFormUI budgetFormUI)
    {
        try
        {
            DataTable dtb = budgetFormBAL.GetBudgetListById(budgetFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtGLAccountGuid.Text= dtb.Rows[0]["tbl_GLAccountId"].ToString();
                txtGLAccount.Text = dtb.Rows[0]["tbl_GLAccount"].ToString();
                txtBudgetNumber.Text = dtb.Rows[0]["BudgetNumber"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                ddlBasedOn.SelectedValue = dtb.Rows[0]["OptionSetLable"].ToString();
                ddlBudgetYear.SelectedValue = dtb.Rows[0]["OptionSetLable"].ToString();
                if (Convert.ToBoolean(dtb.Rows[0]["AnnualCapital"]) == true)
                    chkAnnual.Checked = true;
                else
                    chkAnnual.Checked = false;
                if (Convert.ToBoolean(dtb.Rows[0]["AnnualCapital"]) == true)
                    if (Convert.ToBoolean(dtb.Rows[0]["Display"]) == true)
                        ChkDisplay.Checked = true;
                    else
                        ChkDisplay.Checked = false;
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
            logExcpUIobj.ResourceName = "System_Settings_BudgetForm.CS";
            logExcpUIobj.RecordId = this.budgetFormUI.Tbl_BudgetId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BudgetForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #region Bind OptionSetLis DropDown
    private void BindOptionSetLisDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_Budget";
            optionSetListUI.OptionSetName = "Opt_BasedOn";

            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {
                ddlBasedOn.DataSource = dtb;
                ddlBasedOn.DataBind();
                ddlBasedOn.DataTextField = "OptionSetLable";
                ddlBasedOn.DataValueField = "OptionSetValue";
                ddlBasedOn.DataBind();
            }
            else
            {
                ddlBasedOn.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "-1"));
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindOptionSetLisDropDown()";
            logExcpUIobj.ResourceName = "System_Settings_BudgetForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BudgetForm : BindOptionSetLisDropDown] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Bind OptionSetLis DropDown

    #region Bind OptionBudgetYear DropDown
    private void BindOptionBudgetYearDropDown()
    {
        OptionSetListUI optionSetListUI = new OptionSetListUI();
        optionSetListUI.TableName = "tbl_Budget";
        optionSetListUI.OptionSetName = "Opt_BudgetYear";

        DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
        if (dtb.Rows.Count > 0)
        {
            ddlBudgetYear.DataSource = dtb;
            ddlBudgetYear.DataBind();
            ddlBudgetYear.DataTextField = "OptionSetLable";
            ddlBudgetYear.DataValueField = "OptionSetValue";
            ddlBudgetYear.DataBind();
        }
        else
        {
            ddlBasedOn.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "-1"));
        }

    }
    #endregion

    #endregion Methods
}
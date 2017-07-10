using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_General_Ledger_GL_Integration_GLAccountForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    GLAccountFormBAL gLAccountFormBAL = new GLAccountFormBAL();
    GLAccountFormUI gLAccountFormUI = new GLAccountFormUI();
    GLAccountListUI gLAccountListUI = new GLAccountListUI();
    GLAccountCategoryListBAL gLAccountCategoryListBAL = new GLAccountCategoryListBAL();
    GLAccountCategoryListUI gLAccountCategoryListUI = new GLAccountCategoryListUI();

    #region AccountFormat
    Segment01ListBAL segment01ListBAL = new Segment01ListBAL();
    Segment02ListBAL segment02ListBAL = new Segment02ListBAL();
    Segment03ListBAL segment03ListBAL = new Segment03ListBAL();
    Segment04ListBAL segment04ListBAL = new Segment04ListBAL();
    Segment05ListBAL segment05ListBAL = new Segment05ListBAL();
    Segment06ListBAL segment06ListBAL = new Segment06ListBAL();
    Segment07ListBAL segment07ListBAL = new Segment07ListBAL();
    Segment08ListBAL segment08ListBAL = new Segment08ListBAL();
    Segment09ListBAL segment09ListBAL = new Segment09ListBAL();
    Segment10ListBAL segment10ListBAL = new Segment10ListBAL();

    Segment01ListUI segment01ListUI = new Segment01ListUI();
    Segment02ListUI segment02ListUI = new Segment02ListUI();
    Segment03ListUI segment03ListUI = new Segment03ListUI();
    Segment04ListUI segment04ListUI = new Segment04ListUI();
    Segment05ListUI segment05ListUI = new Segment05ListUI();
    Segment06ListUI segment06ListUI = new Segment06ListUI();
    Segment07ListUI segment07ListUI = new Segment07ListUI();
    Segment08ListUI segment08ListUI = new Segment08ListUI();
    Segment09ListUI segment09ListUI = new Segment09ListUI();
    Segment10ListUI segment10ListUI = new Segment10ListUI();


    GLAccountFormatListBAL gLAccountFormatListBAL = new GLAccountFormatListBAL();

    #endregion AccountFormat

    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        GLAccountFormUI gLAccountFormUI = new GLAccountFormUI();

        if (!Page.IsPostBack)
        {
            GetGLAccountFormat();
            BindDDLSegment01();
            if (Request.QueryString["GLAccountId"] != null)
            {
                gLAccountFormUI.Tbl_GLAccountId = Request.QueryString["GLAccountId"];

                FillForm(gLAccountFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update GLAccount";
            }
            else
            {
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New GLAccount";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            gLAccountFormUI.CreatedBy = SessionContext.UserGuid;
            gLAccountFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            gLAccountFormUI.AccountNumber = txtAccountNumber.Text;
            gLAccountFormUI.Tbl_GLAccountCategoryId = txtGLAccountCategoryGuid.Text;
            if (chckIsActive.Checked == true)
                gLAccountFormUI.IsActive = true;
            else
                gLAccountFormUI.IsActive = false;

            if (chckAllowAccountEntry.Checked == true)
                gLAccountFormUI.AllowAccountEntry = true;
            else
                gLAccountFormUI.AllowAccountEntry = false;

            if (chckPostingType.Checked == true)
                gLAccountFormUI.PostingType = true;
            else
                gLAccountFormUI.PostingType = false;

            if (chckTypicalBalance.Checked == true)
                gLAccountFormUI.TypicalBalance = true;
            else
                gLAccountFormUI.TypicalBalance = false;

            if (chckAppearInFinance.Checked == true)
                gLAccountFormUI.AppearInFinance = true;
            else
                gLAccountFormUI.AppearInFinance = false;

            if (chckAppearInHR.Checked == true)
                gLAccountFormUI.AppearInHR = true;
            else
                gLAccountFormUI.AppearInHR = false;

            if (chckAppearInProcurement.Checked == true)
                gLAccountFormUI.AppearInProcurement = true;
            else
                gLAccountFormUI.AppearInProcurement = false;

            if (chckAppearInSystemSettings.Checked == true)
                gLAccountFormUI.AppearInSystemSettingss = true;
            else
                gLAccountFormUI.AppearInSystemSettingss = false;

            if (gLAccountFormBAL.AddGLAccount(gLAccountFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            gLAccountFormUI.Tbl_GLAccountId = Request.QueryString["GLAccountId"];
            gLAccountFormUI.ModifiedBy = SessionContext.UserGuid;
            gLAccountFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            gLAccountFormUI.AccountNumber = txtAccountNumber.Text;
            gLAccountFormUI.Tbl_GLAccountCategoryId = txtGLAccountCategoryGuid.Text;
            if (chckIsActive.Checked == true)
                gLAccountFormUI.IsActive = true;
            else
                gLAccountFormUI.IsActive = false;

            if (chckAllowAccountEntry.Checked == true)
                gLAccountFormUI.AllowAccountEntry = true;
            else
                gLAccountFormUI.AllowAccountEntry = false;

            if (chckPostingType.Checked == true)
                gLAccountFormUI.PostingType = true;
            else
                gLAccountFormUI.PostingType = false;

            if (chckTypicalBalance.Checked == true)
                gLAccountFormUI.TypicalBalance = true;
            else
                gLAccountFormUI.TypicalBalance = false;

            if (chckAppearInFinance.Checked == true)
                gLAccountFormUI.AppearInFinance = true;
            else
                gLAccountFormUI.AppearInFinance = false;

            if (chckAppearInHR.Checked == true)
                gLAccountFormUI.AppearInHR = true;
            else
                gLAccountFormUI.AppearInHR = false;

            if (chckAppearInProcurement.Checked == true)
                gLAccountFormUI.AppearInProcurement = true;
            else
                gLAccountFormUI.AppearInProcurement = false;

            if (chckAppearInSystemSettings.Checked == true)
                gLAccountFormUI.AppearInSystemSettingss = true;
            else
                gLAccountFormUI.AppearInSystemSettingss = false;

            if (gLAccountFormBAL.UpdateGLAccount(gLAccountFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountForm : btnUpdate_Click] An error occured in the processing of Record Id : " + gLAccountFormUI.Tbl_GLAccountId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {


        try
        {
            gLAccountFormUI.Tbl_GLAccountId = Request.QueryString["GLAccountId"];

            if (gLAccountFormBAL.DeleteGLAccount(gLAccountFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountForm.CS";
            logExcpUIobj.RecordId = gLAccountFormUI.Tbl_GLAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountForm : btnDelete_Click] An error occured in the processing of Record Id : " + gLAccountFormUI.Tbl_GLAccountId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("GLAccountList.aspx");
    }

    #region Events GL Account
    protected void btnGLAccountCategorySearch_Click(object sender, EventArgs e)
    {
        btnHtmlGLAccountCategorySearch.Visible = false;
        btnHtmlGLAccountCategoryClose.Visible = true;
        SearchGLAccountCategoryList();

    }
    protected void btnClearGLAccountCategorySearch_Click(object sender, EventArgs e)
    {
        BindGLAccountCategoryList();
        gvGLAccountCategorySearch.Visible = true;
        btnHtmlGLAccountCategorySearch.Visible = true;
        btnHtmlGLAccountCategoryClose.Visible = false;
        txtGLAccountCategorySearch.Text = "";
        txtGLAccountCategorySearch.Focus();

    }
    protected void btnGLAccountCategoryRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindGLAccountCategoryList();
    }
    #endregion

    #region AccountFormat
    protected void ddlSegment01_SelectedIndexChanged(object sender, EventArgs e)
    {
        segment02ListUI.Tbl_Segment01Id = ddlSegment01.SelectedItem.Value;
        BindDDLSegment02(segment02ListUI);
        txtAccountNumber.Text = ddlSegment01.SelectedItem.Text;
    }

    protected void ddlSegment02_SelectedIndexChanged(object sender, EventArgs e)
    {
        segment03ListUI.Tbl_Segment02Id = ddlSegment02.SelectedItem.Value;
        BindDDLSegment03(segment03ListUI);
        txtAccountNumber.Text = ddlSegment01.SelectedItem.Text + ViewState["separatedBy"] + ddlSegment02.SelectedItem.Text;
    }

    protected void ddlSegment03_SelectedIndexChanged(object sender, EventArgs e)
    {
        segment04ListUI.Tbl_Segment03Id = ddlSegment03.SelectedItem.Value;
        BindDDLSegment04(segment04ListUI);
        txtAccountNumber.Text = ddlSegment01.SelectedItem.Text + ViewState["separatedBy"] +
                                ddlSegment02.SelectedItem.Text + ViewState["separatedBy"] +
                                ddlSegment03.SelectedItem.Text;
    }

    protected void ddlSegment04_SelectedIndexChanged(object sender, EventArgs e)
    {
        segment05ListUI.Tbl_Segment04Id = ddlSegment04.SelectedItem.Value;
        BindDDLSegment05(segment05ListUI);
        txtAccountNumber.Text = ddlSegment01.SelectedItem.Text + ViewState["separatedBy"] +
                                ddlSegment02.SelectedItem.Text + ViewState["separatedBy"] +
                                ddlSegment03.SelectedItem.Text + ViewState["separatedBy"] +
                                ddlSegment04.SelectedItem.Text;
    }

    protected void ddlSegment05_SelectedIndexChanged(object sender, EventArgs e)
    {
        segment06ListUI.Tbl_Segment05Id = ddlSegment05.SelectedItem.Value;
        BindDDLSegment06(segment06ListUI);
        txtAccountNumber.Text = ddlSegment01.SelectedItem.Text + ViewState["separatedBy"] +
                                ddlSegment02.SelectedItem.Text + ViewState["separatedBy"] +
                                ddlSegment03.SelectedItem.Text + ViewState["separatedBy"] +
                                ddlSegment04.SelectedItem.Text + ViewState["separatedBy"] +
                                ddlSegment05.SelectedItem.Text;
    }

    protected void ddlSegment06_SelectedIndexChanged(object sender, EventArgs e)
    {
        segment07ListUI.Tbl_Segment06Id = ddlSegment06.SelectedItem.Value;
        BindDDLSegment07(segment07ListUI);
        txtAccountNumber.Text = ddlSegment01.SelectedItem.Text + ViewState["separatedBy"] +
                               ddlSegment02.SelectedItem.Text + ViewState["separatedBy"] +
                               ddlSegment03.SelectedItem.Text + ViewState["separatedBy"] +
                               ddlSegment04.SelectedItem.Text + ViewState["separatedBy"] +
                               ddlSegment05.SelectedItem.Text + ViewState["separatedBy"] +
                               ddlSegment06.SelectedItem.Text;
    }

    protected void ddlSegment07_SelectedIndexChanged(object sender, EventArgs e)
    {
        segment08ListUI.Tbl_Segment07Id = ddlSegment07.SelectedItem.Value;
        BindDDLSegment08(segment08ListUI);
        txtAccountNumber.Text = ddlSegment01.SelectedItem.Text + ViewState["separatedBy"] +
                              ddlSegment02.SelectedItem.Text + ViewState["separatedBy"] +
                              ddlSegment03.SelectedItem.Text + ViewState["separatedBy"] +
                              ddlSegment04.SelectedItem.Text + ViewState["separatedBy"] +
                              ddlSegment05.SelectedItem.Text + ViewState["separatedBy"] +
                              ddlSegment06.SelectedItem.Text + ViewState["separatedBy"] +
                              ddlSegment07.SelectedItem.Text;
    }

    protected void ddlSegment08_SelectedIndexChanged(object sender, EventArgs e)
    {
        segment09ListUI.Tbl_Segment08Id = ddlSegment08.SelectedItem.Value;
        BindDDLSegment09(segment09ListUI);
        txtAccountNumber.Text = ddlSegment01.SelectedItem.Text + ViewState["separatedBy"] +
                             ddlSegment02.SelectedItem.Text + ViewState["separatedBy"] +
                             ddlSegment03.SelectedItem.Text + ViewState["separatedBy"] +
                             ddlSegment04.SelectedItem.Text + ViewState["separatedBy"] +
                             ddlSegment05.SelectedItem.Text + ViewState["separatedBy"] +
                             ddlSegment06.SelectedItem.Text + ViewState["separatedBy"] +
                             ddlSegment07.SelectedItem.Text + ViewState["separatedBy"] +
                             ddlSegment08.SelectedItem.Text;
    }

    protected void ddlSegment09_SelectedIndexChanged(object sender, EventArgs e)
    {
        segment10ListUI.Tbl_Segment09Id = ddlSegment09.SelectedItem.Value;
        BindDDLSegment10(segment10ListUI);
        txtAccountNumber.Text = ddlSegment01.SelectedItem.Text + ViewState["separatedBy"] +
                            ddlSegment02.SelectedItem.Text + ViewState["separatedBy"] +
                            ddlSegment03.SelectedItem.Text + ViewState["separatedBy"] +
                            ddlSegment04.SelectedItem.Text + ViewState["separatedBy"] +
                            ddlSegment05.SelectedItem.Text + ViewState["separatedBy"] +
                            ddlSegment06.SelectedItem.Text + ViewState["separatedBy"] +
                            ddlSegment07.SelectedItem.Text + ViewState["separatedBy"] +
                            ddlSegment08.SelectedItem.Text + ViewState["separatedBy"] +
                            ddlSegment09.SelectedItem.Text;
    }

    protected void ddlSegment10_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtAccountNumber.Text = ddlSegment01.SelectedItem.Text + ViewState["separatedBy"] +
                            ddlSegment02.SelectedItem.Text + ViewState["separatedBy"] +
                            ddlSegment03.SelectedItem.Text + ViewState["separatedBy"] +
                            ddlSegment04.SelectedItem.Text + ViewState["separatedBy"] +
                            ddlSegment05.SelectedItem.Text + ViewState["separatedBy"] +
                            ddlSegment06.SelectedItem.Text + ViewState["separatedBy"] +
                            ddlSegment07.SelectedItem.Text + ViewState["separatedBy"] +
                            ddlSegment08.SelectedItem.Text + ViewState["separatedBy"] +
                            ddlSegment09.SelectedItem.Text + ViewState["separatedBy"] +
                            ddlSegment10.SelectedItem.Text;
    }


    #endregion AccountFormat
    #endregion Events 

    #region Methods
    private void FillForm(GLAccountFormUI gLAccountFormUI)
    {
        try
        {
            DataTable dtb = gLAccountFormBAL.GetGLAccountListById(gLAccountFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtAccountNumber.Text = dtb.Rows[0]["AccountNumber"].ToString();
                txtGLAccountCategoryGuid.Text = dtb.Rows[0]["tbl_GLAccountCategoryId"].ToString();
                txtGLAccountCategory.Text = dtb.Rows[0]["GLAccountCategory"].ToString();
                chckIsActive.Checked = Convert.ToBoolean(dtb.Rows[0]["IsActive"].ToString());
                chckAllowAccountEntry.Checked = Convert.ToBoolean(dtb.Rows[0]["AllowAccountEntry"].ToString());
                chckPostingType.Checked = Convert.ToBoolean(dtb.Rows[0]["PostingType"].ToString());
                chckTypicalBalance.Checked = Convert.ToBoolean(dtb.Rows[0]["TypicalBalance"].ToString());
                chckAppearInFinance.Checked = Convert.ToBoolean(dtb.Rows[0]["AppearInFinance"].ToString());
                chckAppearInHR.Checked = Convert.ToBoolean(dtb.Rows[0]["AppearInHR"].ToString());
                chckAppearInProcurement.Checked = Convert.ToBoolean(dtb.Rows[0]["AppearInProcurement"].ToString());
                chckAppearInSystemSettings.Checked = Convert.ToBoolean(dtb.Rows[0]["AppearInSystemSettingss"].ToString());

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
            logExcpUIobj.ResourceName = "System_Settings_GLAccountForm.CS";
            logExcpUIobj.RecordId = gLAccountFormUI.Tbl_GLAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region Account Category
    private void SearchGLAccountCategoryList()
    {
        try
        {
            GLAccountCategoryListBAL gLAccountCategoryListBAL = new GLAccountCategoryListBAL();
            GLAccountCategoryListUI gLAccountCategoryListUI = new GLAccountCategoryListUI();

            gLAccountCategoryListUI.Search = txtGLAccountCategorySearch.Text;

            DataTable dtb = gLAccountCategoryListBAL.GetGLAccountCategoryListBySearchParameters(gLAccountCategoryListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountCategorySearch.DataSource = dtb;
                gvGLAccountCategorySearch.DataBind();
                divGLAccountCategorySearchError.Visible = false;
            }
            else
            {
                divGLAccountCategorySearchError.Visible = true;
                lblGLAccountCategorySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountCategorySearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchGLAccountCategoryList()";
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }


    }
    private void BindGLAccountCategoryList()
    {
        try
        {
            DataTable dtb = gLAccountCategoryListBAL.GetGLAccountCategoryList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGLAccountCategorySearch.DataSource = dtb;
                gvGLAccountCategorySearch.DataBind();
                divGLAccountCategorySearchError.Visible = false;
            }
            else
            {
                divGLAccountCategorySearchError.Visible = true;
                lblGLAccountCategorySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGLAccountCategorySearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindGLAccountCategoryList()";
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountForm : BindGLAccountCategoryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion ccount Category

    #region AccountFormat
    public void BindDDLSegment01()
    {
        try
        {
            DataTable dtb = segment01ListBAL.GetSegment01List();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                ddlSegment01.DataSource = dtb;
                ddlSegment01.DataTextField = "Number";
                ddlSegment01.DataValueField = "tbl_Segment01Id";
                ddlSegment01.DataBind();
                ddlSegment01.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));

                divError.Visible = false;
            }
            else
            {
                ddlSegment01.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "Search_SearchSegment01.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Search_SearchCountry : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void BindDDLSegment02(Segment02ListUI segment02ListUI)
    {
        try
        {
            DataTable dtb = segment02ListBAL.GetSegment02ListBySegment01(segment02ListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                ddlSegment02.DataSource = dtb;

                ddlSegment02.DataTextField = "Number";
                ddlSegment02.DataValueField = "tbl_Segment02Id";
                ddlSegment02.DataBind();
                ddlSegment02.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));

                divError.Visible = false;
            }
            else
            {
                ddlSegment02.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "Search_SearchSegment01.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Search_SearchCountry : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void BindDDLSegment03(Segment03ListUI segment03ListUI)
    {
        try
        {
            DataTable dtb = segment03ListBAL.GetSegment03ListBySegment02(segment03ListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                ddlSegment03.DataSource = dtb;
                ddlSegment03.DataTextField = "Number";
                ddlSegment03.DataValueField = "tbl_Segment03Id";
                ddlSegment03.DataBind();
                ddlSegment03.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));

                divError.Visible = false;
            }
            else
            {
                ddlSegment03.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "Search_SearchSegment01.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Search_SearchCountry : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void BindDDLSegment04(Segment04ListUI segment04ListUI)
    {
        try
        {
            DataTable dtb = segment04ListBAL.GetSegment04ListBySegment03(segment04ListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                ddlSegment04.DataSource = dtb;
                ddlSegment04.DataTextField = "Number";
                ddlSegment04.DataValueField = "tbl_Segment04Id";
                ddlSegment04.DataBind();
                ddlSegment04.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));

                divError.Visible = false;
            }
            else
            {
                ddlSegment04.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "Search_SearchSegment01.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Search_SearchCountry : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void BindDDLSegment05(Segment05ListUI segment05ListUI)
    {
        try
        {
            DataTable dtb = segment05ListBAL.GetSegment05ListBySegment04(segment05ListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                ddlSegment05.DataSource = dtb;
                ddlSegment05.DataTextField = "Number";
                ddlSegment05.DataValueField = "tbl_Segment05Id";
                ddlSegment05.DataBind();
                ddlSegment05.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                divError.Visible = false;
            }
            else
            {
                ddlSegment05.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "Search_SearchSegment01.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Search_SearchCountry : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void BindDDLSegment06(Segment06ListUI segment06ListUI)
    {
        try
        {
            DataTable dtb = segment06ListBAL.GetSegment06ListBySegment05(segment06ListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                ddlSegment06.DataSource = dtb;
                ddlSegment06.DataTextField = "Number";
                ddlSegment06.DataValueField = "tbl_Segment06Id";
                ddlSegment06.DataBind();
                ddlSegment06.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));

                divError.Visible = false;
            }
            else
            {
                ddlSegment06.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "Search_SearchSegment01.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Search_SearchCountry : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void BindDDLSegment07(Segment07ListUI segment07ListUI)
    {
        try
        {
            DataTable dtb = segment07ListBAL.GetSegment07ListBySegment06(segment07ListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                ddlSegment07.DataSource = dtb;
                ddlSegment07.DataTextField = "Number";
                ddlSegment07.DataValueField = "tbl_Segment07Id";
                ddlSegment07.DataBind();
                ddlSegment07.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));

                divError.Visible = false;
            }
            else
            {
                ddlSegment07.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "Search_SearchSegment01.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Search_SearchCountry : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void BindDDLSegment08(Segment08ListUI segment08ListUI)
    {
        try
        {
            DataTable dtb = segment08ListBAL.GetSegment08ListBySegment07(segment08ListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                ddlSegment08.DataSource = dtb;
                ddlSegment08.DataTextField = "Number";
                ddlSegment08.DataValueField = "tbl_Segment08Id";
                ddlSegment08.DataBind();
                ddlSegment08.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));

                divError.Visible = false;
            }
            else
            {
                ddlSegment08.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "Search_SearchSegment01.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Search_SearchCountry : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void BindDDLSegment09(Segment09ListUI segment09ListUI)
    {
        try
        {
            DataTable dtb = segment09ListBAL.GetSegment09ListBySegment08(segment09ListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                ddlSegment09.DataSource = dtb;
                ddlSegment09.DataTextField = "Number";
                ddlSegment09.DataValueField = "tbl_Segment09Id";
                ddlSegment09.DataBind();
                ddlSegment09.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));

                divError.Visible = false;
            }
            else
            {
                ddlSegment09.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "Search_SearchSegment01.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Search_SearchCountry : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void BindDDLSegment10(Segment10ListUI segment10ListUI)
    {
        try
        {
            DataTable dtb = segment10ListBAL.GetSegment10ListBySegment09(segment10ListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                ddlSegment10.DataSource = dtb;
                ddlSegment10.DataTextField = "Number";
                ddlSegment10.DataValueField = "tbl_Segment10Id";
                ddlSegment10.DataBind();
                ddlSegment10.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));

                divError.Visible = false;
            }
            else
            {
                ddlSegment10.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "Search_SearchSegment01.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Search_SearchCountry : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void GetGLAccountFormat()
    {
        try
        {
            DataTable dtb = gLAccountFormatListBAL.GetGLAccountFormatList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                ViewState["SegmentLength"] = Convert.ToInt32(dtb.Rows[0]["SegmentLength"]);
                ViewState["separatedBy"] = dtb.Rows[0]["SeparatedBy"].ToString();
                DisplaySegments();                
                divError.Visible = false;
            }
            else
            {
                divSuccess.Visible = false;
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetGLAccountFormat()";
            logExcpUIobj.ResourceName = "Search_SearchSegment01.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Search_SearchCountry : GetGLAccountFormat] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void DisplaySegments()
    {
        int segmentLength = Convert.ToInt32(ViewState["SegmentLength"]);

        if (segmentLength >= 1)
            ddlSegment01.Visible = true;
        else ddlSegment01.Visible = false;

        if (segmentLength >= 2)
            ddlSegment02.Visible = true;
        else ddlSegment02.Visible = false;

        if (segmentLength >= 3)
            ddlSegment03.Visible = true;
        else ddlSegment03.Visible = false;

        if (segmentLength >= 4)
            ddlSegment04.Visible = true;
        else ddlSegment04.Visible = false;

        if (segmentLength >= 5)
            ddlSegment05.Visible = true;
        else ddlSegment05.Visible = false;

        if (segmentLength >= 6)
            ddlSegment06.Visible = true;
        else ddlSegment06.Visible = false;

        if (segmentLength >= 7)
            ddlSegment07.Visible = true;
        else ddlSegment07.Visible = false;

        if (segmentLength >= 8)
            ddlSegment08.Visible = true;
        else ddlSegment08.Visible = false;

        if (segmentLength >= 9)
            ddlSegment09.Visible = true;
        else ddlSegment09.Visible = false;

        if (segmentLength >= 10)
            ddlSegment10.Visible = true;
        else ddlSegment10.Visible = false;
    }

    #endregion AccountFormat

    #endregion Methods

}
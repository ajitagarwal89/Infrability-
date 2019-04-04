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


    AccountFormatListBAL accountFormatListBAL = new AccountFormatListBAL();

    #endregion AccountFormat

    #endregion Data Members

    #region Events

    protected override void Page_Load(object sender, EventArgs e)
    {
        GLAccountFormUI gLAccountFormUI = new GLAccountFormUI();

        divSuccess.Visible = false;
        divError.Visible = false;

        if (!Page.IsPostBack)
        {
            txtAccountNumber.ReadOnly = true;
            txtDescription.ReadOnly = true;
            GetGLAccountFormat();
            BindDDLSegment01();
            if (Request.QueryString["GLAccountId"] != null || Request.QueryString["recordId"] != null)
            {
                gLAccountFormUI.Tbl_GLAccountId = (Request.QueryString["GLAccountId"] != null ? Request.QueryString["GLAccountId"] : Request.QueryString["recordId"]);

                FillForm(gLAccountFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnAuditHistory.Visible = true;
                lblHeading.Text = "Update GLAccount";
            }
            else
            {
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
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

            gLAccountFormUI.Description = txtDescription.Text;

            gLAccountFormUI.AccountNumber = txtAccountNumber.Text;
            gLAccountFormUI.Tbl_GLAccountCategoryId = txtGLAccountCategoryGuid.Text;
            if (chkInActive.Checked == true)
                gLAccountFormUI.InActive = true;
            else
                gLAccountFormUI.InActive = false;

            if (chkAllowAccountEntry.Checked == true)
                gLAccountFormUI.AllowAccountEntry = true;
            else
                gLAccountFormUI.AllowAccountEntry = false;

            if (rdbBalanceSheet.Checked == true)
                gLAccountFormUI.PostingType = true;
            else if (rdbProfitAndLoss.Checked == true)
                gLAccountFormUI.PostingType = false;

            if (rdbDebit.Checked == true)
                gLAccountFormUI.TypicalBalance = true;
            else if (rdbCredit.Checked == true)
                gLAccountFormUI.TypicalBalance = false;


            if (chkAppearInFinance.Checked == true)
                gLAccountFormUI.AppearInFinance = true;
            else
                gLAccountFormUI.AppearInFinance = false;

            if (chkAppearInHR.Checked == true)
                gLAccountFormUI.AppearInHR = true;
            else
                gLAccountFormUI.AppearInHR = false;

            if (chkAppearInProcurement.Checked == true)
                gLAccountFormUI.AppearInProcurement = true;
            else
                gLAccountFormUI.AppearInProcurement = false;

            if (chkAppearInSystemSettings.Checked == true)
                gLAccountFormUI.AppearInSystemSettingss = true;
            else
                gLAccountFormUI.AppearInSystemSettingss = false;

            if (ddlSegment01.SelectedIndex > 0)
                gLAccountFormUI.Tbl_Segment01Id = ddlSegment01.SelectedValue.ToString();
            else
                gLAccountFormUI.Tbl_Segment01Id = "00000000-0000-0000-0000-000000000001";

            if (ddlSegment02.SelectedIndex > 0)
                gLAccountFormUI.Tbl_Segment02Id = ddlSegment02.SelectedValue.ToString();
            else
                gLAccountFormUI.Tbl_Segment02Id = "00000000-0000-0000-0000-000000000001";

            if (ddlSegment03.SelectedIndex > 0)
                gLAccountFormUI.Tbl_Segment03Id = ddlSegment03.SelectedValue.ToString();
            else
                gLAccountFormUI.Tbl_Segment03Id = "00000000-0000-0000-0000-000000000001";

            if (ddlSegment04.SelectedIndex > 0)
                gLAccountFormUI.Tbl_Segment04Id = ddlSegment04.SelectedValue.ToString();
            else
                gLAccountFormUI.Tbl_Segment04Id = "00000000-0000-0000-0000-000000000001";

            if (ddlSegment05.SelectedIndex > 0)
                gLAccountFormUI.Tbl_Segment05Id = ddlSegment05.SelectedValue.ToString();
            else
                gLAccountFormUI.Tbl_Segment05Id = "00000000-0000-0000-0000-000000000001";

            if (ddlSegment06.SelectedIndex > 0)
                gLAccountFormUI.Tbl_Segment06Id = ddlSegment06.SelectedValue.ToString();
            else
                gLAccountFormUI.Tbl_Segment06Id = "00000000-0000-0000-0000-000000000001";

            if (ddlSegment07.SelectedIndex > 0)
                gLAccountFormUI.Tbl_Segment07Id = ddlSegment07.SelectedValue.ToString();
            else
                gLAccountFormUI.Tbl_Segment07Id = "00000000-0000-0000-0000-000000000001";

            if (ddlSegment08.SelectedIndex > 0)
                gLAccountFormUI.Tbl_Segment08Id = ddlSegment08.SelectedValue.ToString();
            else
                gLAccountFormUI.Tbl_Segment08Id = "00000000-0000-0000-0000-000000000001";

            if (ddlSegment09.SelectedIndex > 0)
                gLAccountFormUI.Tbl_Segment09Id = ddlSegment09.SelectedValue.ToString();
            else
                gLAccountFormUI.Tbl_Segment09Id = "00000000-0000-0000-0000-000000000001";

            if (ddlSegment10.SelectedIndex > 0)
                gLAccountFormUI.Tbl_Segment10Id = ddlSegment10.SelectedValue.ToString();
            else
                gLAccountFormUI.Tbl_Segment10Id = "00000000-0000-0000-0000-000000000001";

            if (IsSegmentSelected() == true)
            {
                if (gLAccountFormBAL.AddGLAccount(gLAccountFormUI) == 1)
                {
                    divSuccess.Visible = true;
                    divError.Visible = false;
                    lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;

                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);


                }

                else
                {

                    divError.Visible = true;
                    divSuccess.Visible = false;
                    lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);

                }


            }
            else
            {
                divError.Visible = true;
                divSuccess.Visible = false;
                lblError.Text = Resources.GlobalResource.msgInCompleteFields;
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

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Finance/General_Ledger/GL_Integration/GLAccountForm.aspx";
        string recordId = Request.QueryString["GLAccountId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            gLAccountFormUI.Tbl_GLAccountId = Request.QueryString["GLAccountId"];
            gLAccountFormUI.ModifiedBy = SessionContext.UserGuid;
            gLAccountFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            gLAccountFormUI.Description = txtDescription.Text;

            gLAccountFormUI.AccountNumber = txtAccountNumber.Text;
            gLAccountFormUI.Tbl_GLAccountCategoryId = txtGLAccountCategoryGuid.Text;
            if (chkInActive.Checked == true)
                gLAccountFormUI.InActive = true;
            else
                gLAccountFormUI.InActive = false;

            if (chkAllowAccountEntry.Checked == true)
                gLAccountFormUI.AllowAccountEntry = true;
            else
                gLAccountFormUI.AllowAccountEntry = false;

            if (rdbBalanceSheet.Checked == true)
                gLAccountFormUI.PostingType = true;
            else
                gLAccountFormUI.PostingType = false;

            if (rdbDebit.Checked)
                gLAccountFormUI.TypicalBalance = true;
            else
                gLAccountFormUI.TypicalBalance = false;

            if (chkAppearInFinance.Checked == true)
                gLAccountFormUI.AppearInFinance = true;
            else
                gLAccountFormUI.AppearInFinance = false;

            if (chkAppearInHR.Checked == true)
                gLAccountFormUI.AppearInHR = true;
            else
                gLAccountFormUI.AppearInHR = false;

            if (chkAppearInProcurement.Checked == true)
                gLAccountFormUI.AppearInProcurement = true;
            else
                gLAccountFormUI.AppearInProcurement = false;

            if (chkAppearInSystemSettings.Checked == true)
                gLAccountFormUI.AppearInSystemSettingss = true;
            else
                gLAccountFormUI.AppearInSystemSettingss = false;

            if (ddlSegment01.SelectedIndex > 0)
                gLAccountFormUI.Tbl_Segment01Id = ddlSegment01.SelectedValue.ToString();
            else
                gLAccountFormUI.Tbl_Segment01Id = "00000000-0000-0000-0000-000000000001";

            if (ddlSegment02.SelectedIndex > 0)
                gLAccountFormUI.Tbl_Segment02Id = ddlSegment02.SelectedValue.ToString();
            else
                gLAccountFormUI.Tbl_Segment02Id = "00000000-0000-0000-0000-000000000001";

            if (ddlSegment03.SelectedIndex > 0)
                gLAccountFormUI.Tbl_Segment03Id = ddlSegment03.SelectedValue.ToString();
            else
                gLAccountFormUI.Tbl_Segment03Id = "00000000-0000-0000-0000-000000000001";

            if (ddlSegment04.SelectedIndex > 0)
                gLAccountFormUI.Tbl_Segment04Id = ddlSegment04.SelectedValue.ToString();
            else
                gLAccountFormUI.Tbl_Segment04Id = "00000000-0000-0000-0000-000000000001";

            if (ddlSegment05.SelectedIndex > 0)
                gLAccountFormUI.Tbl_Segment05Id = ddlSegment05.SelectedValue.ToString();
            else
                gLAccountFormUI.Tbl_Segment05Id = "00000000-0000-0000-0000-000000000001";

            if (ddlSegment06.SelectedIndex > 0)
                gLAccountFormUI.Tbl_Segment06Id = ddlSegment06.SelectedValue.ToString();
            else
                gLAccountFormUI.Tbl_Segment06Id = "00000000-0000-0000-0000-000000000001";

            if (ddlSegment07.SelectedIndex > 0)
                gLAccountFormUI.Tbl_Segment07Id = ddlSegment07.SelectedValue.ToString();
            else
                gLAccountFormUI.Tbl_Segment07Id = "00000000-0000-0000-0000-000000000001";

            if (ddlSegment08.SelectedIndex > 0)
                gLAccountFormUI.Tbl_Segment08Id = ddlSegment08.SelectedValue.ToString();
            else
                gLAccountFormUI.Tbl_Segment08Id = "00000000-0000-0000-0000-000000000001";

            if (ddlSegment09.SelectedIndex > 0)
                gLAccountFormUI.Tbl_Segment09Id = ddlSegment09.SelectedValue.ToString();
            else
                gLAccountFormUI.Tbl_Segment09Id = "00000000-0000-0000-0000-000000000001";

            if (ddlSegment10.SelectedIndex > 0)
                gLAccountFormUI.Tbl_Segment10Id = ddlSegment10.SelectedValue.ToString();
            else
                gLAccountFormUI.Tbl_Segment10Id = "00000000-0000-0000-0000-000000000001";

            if (IsSegmentSelected() == true)
            {
                if (gLAccountFormBAL.UpdateGLAccount(gLAccountFormUI) == 1)
                {
                    divSuccess.Visible = true;
                    divError.Visible = false;
                    lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
                    gLAccountFormUI.Tbl_GLAccountId = "";
                }
                else
                {
                    divError.Visible = true;
                    divSuccess.Visible = false;
                    lblError.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
                    gLAccountFormUI.Tbl_GLAccountId = "";
                }
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
                gLAccountFormUI.Tbl_GLAccountId = "";
            }
            else
            {
                divError.Visible = true;
                divSuccess.Visible = false;
                lblError.Text = Resources.GlobalResource.msgCouldNotDeleteRecord;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
                gLAccountFormUI.Tbl_GLAccountId = "";
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
    protected void gvGLAccountCategorySearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvGLAccountCategorySearch.PageIndex = e.NewPageIndex;
        BindGLAccountCategoryList();
    }
    #endregion

    #region AccountFormat
    protected void ddlSegment01_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSegment02.Items.Clear();
        ddlSegment03.Items.Clear();
        ddlSegment04.Items.Clear();
        ddlSegment05.Items.Clear();
        ddlSegment06.Items.Clear();
        ddlSegment07.Items.Clear();
        ddlSegment08.Items.Clear();
        ddlSegment09.Items.Clear();
        ddlSegment10.Items.Clear();

        segment02ListUI.Tbl_Segment01Id = ddlSegment01.SelectedItem.Value;
        BindDDLSegment02(segment02ListUI);

        if (ddlSegment01.SelectedIndex > 0)
        {
            txtAccountNumber.Text = SplitSegmentNumber(ddlSegment01.SelectedItem.Text);
            txtDescription.Text = SplitSegmentDescription(ddlSegment01.SelectedItem.Text);
        }
        else
        {
            txtAccountNumber.Text = "";
            txtDescription.Text = "";
        }
    }

    protected void ddlSegment02_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSegment03.Items.Clear();
        ddlSegment04.Items.Clear();
        ddlSegment05.Items.Clear();
        ddlSegment06.Items.Clear();
        ddlSegment07.Items.Clear();
        ddlSegment08.Items.Clear();
        ddlSegment09.Items.Clear();
        ddlSegment10.Items.Clear();

        segment03ListUI.Tbl_Segment02Id = ddlSegment02.SelectedItem.Value;
        BindDDLSegment03(segment03ListUI);
        if (ddlSegment02.SelectedIndex > 0)
        {
            txtAccountNumber.Text = SplitSegmentNumber(ddlSegment01.SelectedItem.Text) + ViewState["separatedBy"] + SplitSegmentNumber(ddlSegment02.SelectedItem.Text);

            txtDescription.Text = SplitSegmentDescription(ddlSegment01.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  SplitSegmentDescription(ddlSegment02.SelectedItem.Text);
        }
    }

    protected void ddlSegment03_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSegment04.Items.Clear();
        ddlSegment05.Items.Clear();
        ddlSegment06.Items.Clear();
        ddlSegment07.Items.Clear();
        ddlSegment08.Items.Clear();
        ddlSegment09.Items.Clear();
        ddlSegment10.Items.Clear();

        segment04ListUI.Tbl_Segment03Id = ddlSegment03.SelectedItem.Value;
        BindDDLSegment04(segment04ListUI);

        if (ddlSegment03.SelectedIndex > 0)
        {
            txtAccountNumber.Text = SplitSegmentNumber(ddlSegment01.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment02.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment03.SelectedItem.Text);
            txtDescription.Text = SplitSegmentDescription(ddlSegment01.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment02.SelectedItem.Text) + ViewState["separatedBy"] +
                                  SplitSegmentDescription(ddlSegment03.SelectedItem.Text);
        }
    }

    protected void ddlSegment04_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSegment05.Items.Clear();
        ddlSegment06.Items.Clear();
        ddlSegment07.Items.Clear();
        ddlSegment08.Items.Clear();
        ddlSegment09.Items.Clear();
        ddlSegment10.Items.Clear();

        segment05ListUI.Tbl_Segment04Id = ddlSegment04.SelectedItem.Value;
        BindDDLSegment05(segment05ListUI);
        if (ddlSegment04.SelectedIndex > 0)
        {
            txtAccountNumber.Text = SplitSegmentNumber(ddlSegment01.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment02.SelectedItem.Text) + ViewState["separatedBy"] +
                                 SplitSegmentNumber(ddlSegment03.SelectedItem.Text) + ViewState["separatedBy"] +
                                 SplitSegmentNumber(ddlSegment04.SelectedItem.Text);

            txtDescription.Text = SplitSegmentDescription(ddlSegment01.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment02.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment03.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  SplitSegmentDescription(ddlSegment04.SelectedItem.Text);
        }
    }

    protected void ddlSegment05_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSegment06.Items.Clear();
        ddlSegment07.Items.Clear();
        ddlSegment08.Items.Clear();
        ddlSegment09.Items.Clear();
        ddlSegment10.Items.Clear();

        segment06ListUI.Tbl_Segment05Id = ddlSegment05.SelectedItem.Value;
        BindDDLSegment06(segment06ListUI);
        if (ddlSegment05.SelectedIndex > 0)
        {
            txtAccountNumber.Text = SplitSegmentNumber(ddlSegment01.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment02.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment03.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment04.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment05.SelectedItem.Text);

            txtDescription.Text = SplitSegmentDescription(ddlSegment01.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment02.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment03.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment04.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  SplitSegmentDescription(ddlSegment05.SelectedItem.Text);
        }
    }

    protected void ddlSegment06_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSegment07.Items.Clear();
        ddlSegment08.Items.Clear();
        ddlSegment09.Items.Clear();
        ddlSegment10.Items.Clear();

        segment07ListUI.Tbl_Segment06Id = ddlSegment06.SelectedItem.Value;
        BindDDLSegment07(segment07ListUI);
        if (ddlSegment06.SelectedIndex > 0)
        {
            txtAccountNumber.Text = SplitSegmentNumber(ddlSegment01.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment02.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment03.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment04.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment05.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment06.SelectedItem.Text);

            txtDescription.Text = SplitSegmentDescription(ddlSegment01.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment02.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment03.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment04.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment05.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  SplitSegmentDescription(ddlSegment06.SelectedItem.Text);
        }
    }

    protected void ddlSegment07_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSegment08.Items.Clear();
        ddlSegment09.Items.Clear();
        ddlSegment10.Items.Clear();

        segment08ListUI.Tbl_Segment07Id = ddlSegment07.SelectedItem.Value;
        BindDDLSegment08(segment08ListUI);
        if (ddlSegment07.SelectedIndex > 0)
        {
            txtAccountNumber.Text = SplitSegmentNumber(ddlSegment01.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment02.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment03.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment04.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment05.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment06.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment07.SelectedItem.Text);

            txtDescription.Text = SplitSegmentDescription(ddlSegment01.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment02.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment03.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment04.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment05.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment06.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  SplitSegmentDescription(ddlSegment07.SelectedItem.Text);
        }
    }

    protected void ddlSegment08_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSegment09.Items.Clear();
        ddlSegment10.Items.Clear();

        segment09ListUI.Tbl_Segment08Id = ddlSegment08.SelectedItem.Value;
        BindDDLSegment09(segment09ListUI);
        if (ddlSegment08.SelectedIndex > 0)
        {
            txtAccountNumber.Text = SplitSegmentNumber(ddlSegment01.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment02.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment03.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment04.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment05.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment06.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment07.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment08.SelectedItem.Text);

            txtDescription.Text = SplitSegmentDescription(ddlSegment01.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment02.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment03.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment04.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment05.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment06.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment07.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  SplitSegmentDescription(ddlSegment08.SelectedItem.Text);
        }
    }

    protected void ddlSegment09_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSegment10.Items.Clear();

        segment10ListUI.Tbl_Segment09Id = ddlSegment09.SelectedItem.Value;
        BindDDLSegment10(segment10ListUI);
        if (ddlSegment09.SelectedIndex > 0)
        {
            txtAccountNumber.Text = SplitSegmentNumber(ddlSegment01.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment02.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment03.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment04.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment05.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment06.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment07.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment08.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment09.SelectedItem.Text);

            txtDescription.Text = SplitSegmentDescription(ddlSegment01.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment02.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment03.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment04.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment05.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment06.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment07.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment08.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  SplitSegmentDescription(ddlSegment09.SelectedItem.Text);
        }
    }

    protected void ddlSegment10_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSegment10.SelectedIndex > 0)
        {
            txtAccountNumber.Text = SplitSegmentNumber(ddlSegment01.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment02.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment03.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment04.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment05.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment06.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment07.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment08.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment09.SelectedItem.Text) + ViewState["separatedBy"] +
                                SplitSegmentNumber(ddlSegment10.SelectedItem.Text);

            txtDescription.Text = SplitSegmentDescription(ddlSegment01.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment02.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment03.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment04.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment05.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment06.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment07.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment08.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  //SplitSegmentDescription(ddlSegment09.SelectedItem.Text) + " " + ViewState["separatedBy"] + " " +
                                  SplitSegmentDescription(ddlSegment10.SelectedItem.Text);
        }
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
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                txtAccountNumber.Text = dtb.Rows[0]["AccountNumber"].ToString();
                txtGLAccountCategoryGuid.Text = dtb.Rows[0]["tbl_GLAccountCategoryId"].ToString();
                txtGLAccountCategory.Text = dtb.Rows[0]["GLAccountCategory"].ToString();
                chkInActive.Checked = Convert.ToBoolean(dtb.Rows[0]["InActive"].ToString());
                chkAllowAccountEntry.Checked = Convert.ToBoolean(dtb.Rows[0]["AllowAccountEntry"].ToString());
                if (Convert.ToBoolean(dtb.Rows[0]["PostingType"]) == true)
                { rdbBalanceSheet.Checked = true; }
                else
                {
                    rdbProfitAndLoss.Checked = true;
                }
                if (Convert.ToBoolean(dtb.Rows[0]["TypicalBalance"]) == true)
                {
                    rdbDebit.Checked = true;
                }
                else
                {
                    rdbCredit.Checked = true;
                }

                chkAppearInFinance.Checked = Convert.ToBoolean(dtb.Rows[0]["AppearInFinance"].ToString());
                chkAppearInHR.Checked = Convert.ToBoolean(dtb.Rows[0]["AppearInHR"].ToString());
                chkAppearInProcurement.Checked = Convert.ToBoolean(dtb.Rows[0]["AppearInProcurement"].ToString());
                chkAppearInSystemSettings.Checked = Convert.ToBoolean(dtb.Rows[0]["AppearInSystemSettingss"].ToString());


                BindDDLSegment01();

                segment02ListUI.Tbl_Segment01Id = dtb.Rows[0]["tbl_Segment01Id"].ToString();
                ddlSegment01.SelectedValue = segment02ListUI.Tbl_Segment01Id;
                BindDDLSegment02(segment02ListUI);

                segment03ListUI.Tbl_Segment02Id = dtb.Rows[0]["tbl_Segment02Id"].ToString();
                ddlSegment02.SelectedValue = segment03ListUI.Tbl_Segment02Id;
                BindDDLSegment03(segment03ListUI);

                segment04ListUI.Tbl_Segment03Id = dtb.Rows[0]["tbl_Segment03Id"].ToString();
                ddlSegment03.SelectedValue = segment04ListUI.Tbl_Segment03Id;
                BindDDLSegment04(segment04ListUI);

                segment05ListUI.Tbl_Segment04Id = dtb.Rows[0]["tbl_Segment04Id"].ToString();
                ddlSegment04.SelectedValue = segment05ListUI.Tbl_Segment04Id;
                BindDDLSegment05(segment05ListUI);

                segment06ListUI.Tbl_Segment05Id = dtb.Rows[0]["tbl_Segment05Id"].ToString();
                ddlSegment05.SelectedValue = segment06ListUI.Tbl_Segment05Id;
                BindDDLSegment06(segment06ListUI);

                segment07ListUI.Tbl_Segment06Id = dtb.Rows[0]["tbl_Segment06Id"].ToString();
                ddlSegment06.SelectedValue = segment07ListUI.Tbl_Segment06Id;
                BindDDLSegment07(segment07ListUI);

                segment08ListUI.Tbl_Segment07Id = dtb.Rows[0]["tbl_Segment07Id"].ToString();
                ddlSegment07.SelectedValue = segment08ListUI.Tbl_Segment07Id;
                BindDDLSegment08(segment08ListUI);

                segment09ListUI.Tbl_Segment08Id = dtb.Rows[0]["tbl_Segment08Id"].ToString();
                ddlSegment08.SelectedValue = segment09ListUI.Tbl_Segment08Id;
                BindDDLSegment09(segment09ListUI);

                segment10ListUI.Tbl_Segment09Id = dtb.Rows[0]["tbl_Segment09Id"].ToString();
                ddlSegment09.SelectedValue = segment10ListUI.Tbl_Segment09Id;
                BindDDLSegment10(segment10ListUI);

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
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountForm.CS";
            logExcpUIobj.RecordId = gLAccountFormUI.Tbl_GLAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private string SplitSegmentNumber(string originalText)
    {
        string splitedText = "";
        char[] delimiterChars = { '-' };
        string[] words = originalText.Split(delimiterChars);
        splitedText = words[0].ToString();

        return splitedText;
    }

    private string SplitSegmentDescription(string originalText)
    {

        string splitedText = "";
        char[] delimiterChars = { '-' };
        string[] words = originalText.Split(delimiterChars);
        if (words.Length > 1)
        {
            splitedText = words[1].ToString();
        }
        return splitedText;



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
            int segment = Convert.ToInt32(ViewState["Segment"]);

            if (segment >= 1)
            {
                DataTable dtb = segment01ListBAL.GetSegment01List();

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    ddlSegment01.DataSource = dtb;
                    ddlSegment01.DataTextField = "NumberDD";
                    ddlSegment01.DataValueField = "tbl_Segment01Id";
                    ddlSegment01.DataBind();
                    ddlSegment01.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelect, "0"));
                                        
                    divError.Visible = false;
                }
                else
                {
                    ddlSegment01.Items.Clear();
                    ddlSegment01.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));


                }
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindDDLSegment01()";
            logExcpUIobj.ResourceName = "Finance_General_Ledger_GL_Integration_GLAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_General_Ledger_GL_Integration_GLAccountForm : BindDDLSegment01] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void BindDDLSegment02(Segment02ListUI segment02ListUI)
    {
        try
        {
            int segment = Convert.ToInt32(ViewState["Segment"]);

            if (segment >= 2)
            {
                DataTable dtb = segment02ListBAL.GetSegment02ListBySegment01(segment02ListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    ddlSegment02.DataSource = dtb;

                    ddlSegment02.DataTextField = "NumberDD";
                    ddlSegment02.DataValueField = "tbl_Segment02Id";
                    ddlSegment02.DataBind();
                    ddlSegment02.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelect, "0"));
                    
                    divError.Visible = false;
                }
                else
                {
                    ddlSegment02.Items.Clear();
                    ddlSegment02.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
                }
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
            int segment = Convert.ToInt32(ViewState["Segment"]);

            if (segment >= 3)
            {
                DataTable dtb = segment03ListBAL.GetSegment03ListBySegment02(segment03ListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    ddlSegment03.DataSource = dtb;
                    ddlSegment03.DataTextField = "NumberDD";
                    ddlSegment03.DataValueField = "tbl_Segment03Id";
                    ddlSegment03.DataBind();
                    ddlSegment03.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelect, "0"));
                    
                    divError.Visible = false;
                }
                else
                {
                    ddlSegment03.Items.Clear();
                    ddlSegment03.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
                }
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
            int segment = Convert.ToInt32(ViewState["Segment"]);

            if (segment >= 4)
            {
                DataTable dtb = segment04ListBAL.GetSegment04ListBySegment03(segment04ListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    ddlSegment04.DataSource = dtb;
                    ddlSegment04.DataTextField = "NumberDD";
                    ddlSegment04.DataValueField = "tbl_Segment04Id";
                    ddlSegment04.DataBind();
                    ddlSegment04.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelect, "0"));
                   
                    divError.Visible = false;
                }
                else
                {
                    ddlSegment04.Items.Clear();
                    ddlSegment04.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
                }
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
            int segment = Convert.ToInt32(ViewState["Segment"]);

            if (segment >= 5)
            {
                DataTable dtb = segment05ListBAL.GetSegment05ListBySegment04(segment05ListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    ddlSegment05.DataSource = dtb;
                    ddlSegment05.DataTextField = "NumberDD";
                    ddlSegment05.DataValueField = "tbl_Segment05Id";
                    ddlSegment05.DataBind();
                    ddlSegment05.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelect, "0"));
                  
                    divError.Visible = false;
                }
                else
                {
                    ddlSegment05.Items.Clear();
                    ddlSegment05.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
                }
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
            int segment = Convert.ToInt32(ViewState["Segment"]);

            if (segment >= 6)
            {
                DataTable dtb = segment06ListBAL.GetSegment06ListBySegment05(segment06ListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    ddlSegment06.DataSource = dtb;
                    ddlSegment06.DataTextField = "NumberDD";
                    ddlSegment06.DataValueField = "tbl_Segment06Id";
                    ddlSegment06.DataBind();
                    ddlSegment06.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelect, "0"));
                    
                    divError.Visible = false;
                }
                else
                {
                    ddlSegment06.Items.Clear();
                    ddlSegment06.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
                }
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
            int segment = Convert.ToInt32(ViewState["Segment"]);

            if (segment >= 7)
            {
                DataTable dtb = segment07ListBAL.GetSegment07ListBySegment06(segment07ListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    ddlSegment07.DataSource = dtb;
                    ddlSegment07.DataTextField = "NumberDD";
                    ddlSegment07.DataValueField = "tbl_Segment07Id";
                    ddlSegment07.DataBind();
                    ddlSegment07.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelect, "0"));
                   
                    divError.Visible = false;
                }
                else
                {
                    ddlSegment07.Items.Clear();
                    ddlSegment07.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
                }
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
            int segment = Convert.ToInt32(ViewState["Segment"]);

            if (segment >= 8)
            {
                DataTable dtb = segment08ListBAL.GetSegment08ListBySegment07(segment08ListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    ddlSegment08.DataSource = dtb;
                    ddlSegment08.DataTextField = "NumberDD";
                    ddlSegment08.DataValueField = "tbl_Segment08Id";
                    ddlSegment08.DataBind();
                    ddlSegment08.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelect, "0"));
                    
                    divError.Visible = false;
                }
                else
                {
                    ddlSegment08.Items.Clear();
                    ddlSegment08.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
                }
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
            int segment = Convert.ToInt32(ViewState["Segment"]);

            if (segment >= 9)
            {
                DataTable dtb = segment09ListBAL.GetSegment09ListBySegment08(segment09ListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    ddlSegment09.DataSource = dtb;
                    ddlSegment09.DataTextField = "NumberDD";
                    ddlSegment09.DataValueField = "tbl_Segment09Id";
                    ddlSegment09.DataBind();
                    ddlSegment09.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelect, "0"));
                    
                    divError.Visible = false;
                }
                else
                {
                    ddlSegment09.Items.Clear();
                    ddlSegment09.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
                }
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
            int segment = Convert.ToInt32(ViewState["Segment"]);

            if (segment >= 10)
            {
                DataTable dtb = segment10ListBAL.GetSegment10ListBySegment09(segment10ListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    ddlSegment10.DataSource = dtb;
                    ddlSegment10.DataTextField = "NumberDD";
                    ddlSegment10.DataValueField = "tbl_Segment10Id";
                    ddlSegment10.DataBind();
                    ddlSegment10.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelect, "0"));

                    divError.Visible = false;
                }
                else
                {
                    ddlSegment10.Items.Clear();
                    ddlSegment10.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
                }
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
            DataTable dtb = accountFormatListBAL.GetAccountFormatList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                ViewState["Segment"] = Convert.ToInt32(dtb.Rows[0]["Segment"]);
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
        int segment = Convert.ToInt32(ViewState["Segment"]);

        if (segment >= 1)
            ddlSegment01.Visible = true;
        else ddlSegment01.Visible = false;

        if (segment >= 2)
            ddlSegment02.Visible = true;
        else ddlSegment02.Visible = false;

        if (segment >= 3)
            ddlSegment03.Visible = true;
        else ddlSegment03.Visible = false;

        if (segment >= 4)
            ddlSegment04.Visible = true;
        else ddlSegment04.Visible = false;

        if (segment >= 5)
            ddlSegment05.Visible = true;
        else ddlSegment05.Visible = false;

        if (segment >= 6)
            ddlSegment06.Visible = true;
        else ddlSegment06.Visible = false;

        if (segment >= 7)
            ddlSegment07.Visible = true;
        else ddlSegment07.Visible = false;

        if (segment >= 8)
            ddlSegment08.Visible = true;
        else ddlSegment08.Visible = false;

        if (segment >= 9)
            ddlSegment09.Visible = true;
        else ddlSegment09.Visible = false;

        if (segment >= 10)
            ddlSegment10.Visible = true;
        else ddlSegment10.Visible = false;
    }

    #endregion AccountFormat

    private bool IsSegmentSelected()
    {
        bool selectedSegment = false;
        int segment = Convert.ToInt32(ViewState["Segment"]);
        if (segment == 1)
        {
            if (ddlSegment01.SelectedIndex > 0)
                selectedSegment = true;
        }
        else if (segment == 2)
        {
            if (ddlSegment02.SelectedIndex > 0)
                selectedSegment = true;
        }
        else if (segment == 3)
        {
            if (ddlSegment03.SelectedIndex > 0)
                selectedSegment = true;
        }
        else if (segment == 4)
        {
            if (ddlSegment04.SelectedIndex > 0)
                selectedSegment = true;
        }
        else if (segment == 5)
        {
            if (ddlSegment05.SelectedIndex > 0)
                selectedSegment = true;
        }
        else if (segment == 6)
        {
            if (ddlSegment06.SelectedIndex > 0)
                selectedSegment = true;
        }
        else if (segment == 7)
        {
            if (ddlSegment07.SelectedIndex > 0)
                selectedSegment = true;
        }
        else if (segment == 8)
        {
            if (ddlSegment08.SelectedIndex > 0)
                selectedSegment = true;
        }
        else if (segment == 9)
        {
            if (ddlSegment09.SelectedIndex > 0)
                selectedSegment = true;
        }
        else if (segment == 10)
        {
            if (ddlSegment10.SelectedIndex > 0)
                selectedSegment = true;
        }
        return selectedSegment;
    }

    #endregion Methods


}
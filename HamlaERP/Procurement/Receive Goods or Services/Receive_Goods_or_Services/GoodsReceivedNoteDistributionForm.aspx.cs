using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDistributionForm : System.Web.UI.Page
{

    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    GoodsReceivedNoteDistributionFormBAL goodsReceivedNoteDistributionFormBAL = new GoodsReceivedNoteDistributionFormBAL();
    GoodsReceivedNoteDistributionFormUI goodsReceivedNoteDistributionFormUI = new GoodsReceivedNoteDistributionFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    GoodsReceivedNoteListBAL goodsReceivedNoteListBAL = new GoodsReceivedNoteListBAL();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    #endregion Data Members

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        GoodsReceivedNoteDistributionFormUI goodsReceivedNoteDistributionFormUI = new GoodsReceivedNoteDistributionFormUI();

        if (!Page.IsPostBack)
        {

            if (Request.QueryString["GoodsReceivedNoteDistributionId"] != null)
            {
                goodsReceivedNoteDistributionFormUI.Tbl_GoodsReceivedNoteDistributionId = Request.QueryString["GoodsReceivedNoteDistributionId"];
                BindGLAccountTypeDropDown();
               // AccountType();
                FillForm(goodsReceivedNoteDistributionFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Goods Received Note Distribution";
            }
            else
            {
                BindGLAccountTypeDropDown();
                AccountType();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Goods Received Note Distribution";
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int accountType = Convert.ToInt32(ddlopt_GLAccountType.SelectedValue);
            int credit = (int)Enums.CommonEnum.type.Credit;
            int debit = (int)Enums.CommonEnum.type.Debit;

            if (ddlopt_GLAccountType.SelectedIndex != 0)
            {
                goodsReceivedNoteDistributionFormUI.CreatedBy = SessionContext.UserGuid;
                goodsReceivedNoteDistributionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                goodsReceivedNoteDistributionFormUI.Tbl_GoodsReceivedNoteId = txtGoodsReceivedNoteGuid.Text;
                goodsReceivedNoteDistributionFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text;
                goodsReceivedNoteDistributionFormUI.Description = txtDescription.Text;
                goodsReceivedNoteDistributionFormUI.opt_GLAccountType = int.Parse(ddlopt_GLAccountType.SelectedValue);
                goodsReceivedNoteDistributionFormUI.DistributionReference = txtDistributionReference.Text;
                if (accountType == credit)
                {
                    goodsReceivedNoteDistributionFormUI.Credit = Decimal.Parse(txtCredit.Text);
                }
                else
                {
                    goodsReceivedNoteDistributionFormUI.Credit = 0;
                }
                if (accountType == debit)
                {
                    goodsReceivedNoteDistributionFormUI.Debit = Decimal.Parse(txtDebit.Text);

                }
                else
                {
                    goodsReceivedNoteDistributionFormUI.Debit = 0;
                }



                if (goodsReceivedNoteDistributionFormBAL.AddGoodsReceivedNoteDistribution(goodsReceivedNoteDistributionFormUI) == 1)
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
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Please select  Account type');", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDistributionForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDistributionForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            int accountType = Convert.ToInt32(ddlopt_GLAccountType.SelectedValue);
            int credit = (int)Enums.CommonEnum.type.Credit;
            int debit = (int)Enums.CommonEnum.type.Debit;
            if (ddlopt_GLAccountType.SelectedIndex != 0)
            {
                goodsReceivedNoteDistributionFormUI.ModifiedBy = SessionContext.UserGuid;
                goodsReceivedNoteDistributionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                goodsReceivedNoteDistributionFormUI.Tbl_GoodsReceivedNoteDistributionId = Request.QueryString["GoodsReceivedNoteDistributionId"];
                goodsReceivedNoteDistributionFormUI.Tbl_GoodsReceivedNoteId = txtGoodsReceivedNoteGuid.Text;
                goodsReceivedNoteDistributionFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text;
                goodsReceivedNoteDistributionFormUI.Description = txtDescription.Text;
                goodsReceivedNoteDistributionFormUI.opt_GLAccountType = int.Parse(ddlopt_GLAccountType.SelectedValue);
                goodsReceivedNoteDistributionFormUI.DistributionReference = txtDistributionReference.Text;
                if (accountType == credit)
                {
                    goodsReceivedNoteDistributionFormUI.Credit = Decimal.Parse(txtCredit.Text);
                }
                else
                {
                    goodsReceivedNoteDistributionFormUI.Credit = 0;
                }
                if (accountType == debit)
                {
                    goodsReceivedNoteDistributionFormUI.Debit = Decimal.Parse(txtDebit.Text);

                }
                else
                {
                    goodsReceivedNoteDistributionFormUI.Debit = 0;
                }

                if (goodsReceivedNoteDistributionFormBAL.UpdateGoodsReceivedNoteDistribution(goodsReceivedNoteDistributionFormUI) == 1)
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
            else {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Please Select Account Type');",true);
            }
        }

        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDistributionForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDistributionForm : btnUpdate_Click] An error occured in the processing of Record Id : " + goodsReceivedNoteDistributionFormUI.Tbl_GoodsReceivedNoteDistributionId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            goodsReceivedNoteDistributionFormUI.Tbl_GoodsReceivedNoteDistributionId = Request.QueryString["GoodsReceivedNoteDistributionId"];

            if (goodsReceivedNoteDistributionFormBAL.DeleteGoodsReceivedNoteDistribution(goodsReceivedNoteDistributionFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDistributionForm.CS";
            logExcpUIobj.RecordId = goodsReceivedNoteDistributionFormUI.Tbl_GoodsReceivedNoteDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDistributionForm : btnDelete_Click] An error occured in the processing of Record Id : " + goodsReceivedNoteDistributionFormUI.Tbl_GoodsReceivedNoteDistributionId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("GoodsReceivedNoteDistributionList.aspx");
    }

    #region GLAccount Search
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
    #endregion  GLAccount Search

    #region GoodsReceivedNote Search
    protected void btnGoodsReceivedNoteSearch_Click(object sender, EventArgs e)
    {
        btnHtmlGoodsReceivedNoteSearch.Visible = false;
        btnHtmlGoodsReceivedNoteClose.Visible = true;
        SearchGoodsReceivedNoteList();
    }
    protected void btnClearGoodsReceivedNoteSearch_Click(object sender, EventArgs e)
    {
        BindGoodsReceivedNoteList();
        gvGoodsReceivedNoteSearch.Visible = true;
        btnHtmlGoodsReceivedNoteSearch.Visible = true;
        btnHtmlGoodsReceivedNoteClose.Visible = false;
        txtGoodsReceivedNoteSearch.Text = "";
        txtGoodsReceivedNoteSearch.Focus();
    }
    protected void btnGoodsReceivedNoteRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindGoodsReceivedNoteList();
    }
    #endregion GoodsReceivedNote Search
    #endregion Events

    #region Methods 

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
                gvGLAccountSearch.Visible = true;
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
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDistributionForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDistributionForm : BindGLAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion

    #region GoodsReceivedNote Search
    private void SearchGoodsReceivedNoteList()
    {
        try
        {
            GoodsReceivedNoteListUI goodsReceivedNoteListUI = new GoodsReceivedNoteListUI();
            goodsReceivedNoteListUI.Search = txtGoodsReceivedNoteSearch.Text;
            DataTable dtb = goodsReceivedNoteListBAL.GetGoodsReceivedNoteListBySearchParameters(goodsReceivedNoteListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGoodsReceivedNoteSearch.DataSource = dtb;
                gvGoodsReceivedNoteSearch.DataBind();
                divGoodsReceivedNoteSearchError.Visible = false;
                gvGoodsReceivedNoteSearch.Visible = true;
            }
            else
            {
                divGoodsReceivedNoteSearchError.Visible = true;
                lblGoodsReceivedNoteSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGoodsReceivedNoteSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchGoodsReceivedNoteList()";
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDistributionForm : SearchGoodsReceivedNoteList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindGoodsReceivedNoteList()
    {
        try
        {
            DataTable dtb = goodsReceivedNoteListBAL.GetGoodsReceivedNoteList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvGoodsReceivedNoteSearch.DataSource = dtb;
                gvGoodsReceivedNoteSearch.DataBind();
                divGoodsReceivedNoteSearchError.Visible = false;
            }
            else
            {
                divGoodsReceivedNoteSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvGoodsReceivedNoteSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindGoodsReceivedNoteList()";
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDistributionForm : BindGoodsReceivedNoteList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  GoodsReceivedNote search
    private void FillForm(GoodsReceivedNoteDistributionFormUI goodsReceivedNoteDistributionFormUI)
    {
        try
        {
            DataTable dtb = goodsReceivedNoteDistributionFormBAL.GetGoodsReceivedNoteDistributionListById(goodsReceivedNoteDistributionFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtGLAccountGuid.Text = dtb.Rows[0]["tbl_GLAccountId"].ToString();
                txtGLAccount.Text = dtb.Rows[0]["tbl_GLAccount"].ToString();
                txtGoodsReceivedNoteGuid.Text= dtb.Rows[0]["tbl_GoodsReceivedNoteId"].ToString();
                txtGoodsReceivedNote.Text = dtb.Rows[0]["tbl_GoodsReceivedNote"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                ddlopt_GLAccountType.SelectedValue= dtb.Rows[0]["opt_GLAccountType"].ToString();
                txtDistributionReference.Text= dtb.Rows[0]["DistributionReference"].ToString();
                txtDebit.Text= dtb.Rows[0]["Debit"].ToString();
                txtCredit.Text= dtb.Rows[0]["Credit"].ToString();
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
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDistributionForm.CS";
            logExcpUIobj.RecordId = this.goodsReceivedNoteDistributionFormUI.Tbl_GoodsReceivedNoteDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDistributionForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region Bind GlAccountType DropDown
    private void BindGLAccountTypeDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_GoodsReceivedNoteDistribution";
            optionSetListUI.OptionSetName = "opt_GLAccountType";

            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {
                ddlopt_GLAccountType.DataSource = dtb;
                ddlopt_GLAccountType.DataBind();
                ddlopt_GLAccountType.DataTextField = "OptionSetLable";
                ddlopt_GLAccountType.DataValueField = "OptionSetValue";
                ddlopt_GLAccountType.DataBind();
                ddlopt_GLAccountType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgSelectRecord, "0"));
                ddlopt_GLAccountType.SelectedIndex = 0;
            }
            else
            {
                ddlopt_GLAccountType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "0"));
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindGLAccountTypeDropDown()";
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDistributionForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDistributionForm : BindGLAccountTypeDropDown] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #endregion Bind GlAccountType DropDown
    #endregion Methods
    private void AccountType()
    {int accountType = Convert.ToInt32(ddlopt_GLAccountType.SelectedValue);
        int credit = (int)Enums.CommonEnum.type.Credit;
        int debit = (int)Enums.CommonEnum.type.Debit;
        if (accountType == credit)
        {
            divDedit.Visible = false;
            divCredit.Visible = true;
        }
        else if(accountType == debit)
            {
            divDedit.Visible = true;
            divCredit.Visible = false;

        }

    }
    protected void ddlopt_GLAccountType_SelectedIndexChanged(object sender, EventArgs e)
    {
        AccountType();
    }
       
}
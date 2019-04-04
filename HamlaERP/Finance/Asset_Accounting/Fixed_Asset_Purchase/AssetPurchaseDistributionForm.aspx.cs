using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Asset_Purchase_AssetPurchaseDistributionForm : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    
    AssetPurchaseDistributionFormBAL assetPurchaseDistributionFormBAL = new AssetPurchaseDistributionFormBAL();
    AssetPurchaseDistributionFormUI assetPurchaseDistributionFormUI = new AssetPurchaseDistributionFormUI();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    AssetPurchaseListBAL assetPurchaseListBAL = new AssetPurchaseListBAL();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    #endregion Data Members

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        AssetPurchaseDistributionFormUI assetPurchaseDistributionFormUI = new AssetPurchaseDistributionFormUI();

        if (!Page.IsPostBack)
        {

            if (Request.QueryString["AssetPurchaseDistributionId"] != null)
            {
                assetPurchaseDistributionFormUI.Tbl_AssetPurchaseDistributionId = Request.QueryString["AssetPurchaseDistributionId"];
                BindOptionSetLisDropDown();
              
                FillForm(assetPurchaseDistributionFormUI);
                divCredit.Visible = false;
                divDebit.Visible = false;
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Asset Purchase Distribution";
            }
            else
            {


                BindOptionSetLisDropDown();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                divCredit.Visible = false;
                divDebit.Visible = false;
                lblHeading.Text = "Add New Asset Purchase Distribution";
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
                assetPurchaseDistributionFormUI.CreatedBy = SessionContext.UserGuid;
                assetPurchaseDistributionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                assetPurchaseDistributionFormUI.Tbl_AssetPurchaseId = txtAssetPurchaseGuid.Text;
                assetPurchaseDistributionFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text;
                assetPurchaseDistributionFormUI.opt_GLAccountType = int.Parse(ddlopt_GLAccountType.SelectedValue);
                assetPurchaseDistributionFormUI.Description = txtDescription.Text;
                assetPurchaseDistributionFormUI.DistributionReference = txtDistributionReference.Text;
                if (accountType == credit)
                {
                    assetPurchaseDistributionFormUI.Credit = Decimal.Parse(txtCredit.Text);
                }
                else {
                    assetPurchaseDistributionFormUI.Credit = 0;
                }
                if (accountType == debit)
                {
                    assetPurchaseDistributionFormUI.Debit = Decimal.Parse(txtDebit.Text);
                }
                else {
                    assetPurchaseDistributionFormUI.Debit = 0;
                }
              
                if (assetPurchaseDistributionFormBAL.AddAssetPurchaseDistribution(assetPurchaseDistributionFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Asset_Purchase_AssetPurchaseDistributionForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Asset_Purchase_AssetPurchaseDistributionForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
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
                assetPurchaseDistributionFormUI.ModifiedBy = SessionContext.UserGuid;
                assetPurchaseDistributionFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                assetPurchaseDistributionFormUI.Tbl_AssetPurchaseDistributionId = Request.QueryString["AssetPurchaseDistributionId"];
                assetPurchaseDistributionFormUI.Tbl_AssetPurchaseId = txtAssetPurchaseGuid.Text;
                assetPurchaseDistributionFormUI.Tbl_GLAccountId = txtGLAccountGuid.Text;
                assetPurchaseDistributionFormUI.opt_GLAccountType = int.Parse(ddlopt_GLAccountType.SelectedValue);
                assetPurchaseDistributionFormUI.Description = txtDescription.Text;
                assetPurchaseDistributionFormUI.DistributionReference = txtDistributionReference.Text;
                if (accountType == credit)
                {
                    assetPurchaseDistributionFormUI.Credit = Decimal.Parse(txtCredit.Text);
                }
                else
                {
                    assetPurchaseDistributionFormUI.Credit = 0;
                }
                if (accountType == debit)
                {
                    assetPurchaseDistributionFormUI.Debit = Decimal.Parse(txtDebit.Text);
                }
                else
                {
                    assetPurchaseDistributionFormUI.Debit = 0;
                }


                if (assetPurchaseDistributionFormBAL.UpdateAssetPurchaseDistribution(assetPurchaseDistributionFormUI) == 1)
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Please Select Account Type');", true);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "Asset_Purchase_AssetPurchaseDistributionForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Asset_Purchase_AssetPurchaseDistributionForm : btnUpdate_Click] An error occured in the processing of Record Id : " + assetPurchaseDistributionFormUI.Tbl_AssetPurchaseDistributionId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            assetPurchaseDistributionFormUI.Tbl_AssetPurchaseDistributionId = Request.QueryString["AssetPurchaseDistributionId"];

            if (assetPurchaseDistributionFormBAL.DeleteAssetPurchaseDistribution(assetPurchaseDistributionFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Asset_Purchase_AssetPurchaseDistributionForm.CS";
            logExcpUIobj.RecordId = assetPurchaseDistributionFormUI.Tbl_AssetPurchaseDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Asset_Purchase_AssetPurchaseDistributionForm : btnDelete_Click] An error occured in the processing of Record Id : " + assetPurchaseDistributionFormUI.Tbl_AssetPurchaseDistributionId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetPurchaseDistributionList.aspx");
    }

    #region AssetPurchase Search
    protected void btnAssetPurchaseSearch_Click(object sender, EventArgs e)
    {
        btnHtmlAssetPurchaseSearch.Visible = false;
        btnHtmlAssetPurchaseClose.Visible = true;
        SearchAssetPurchaseList();

    }
    protected void btnClearAssetPurchaseSearch_Click(object sender, EventArgs e)
    {
        BindAssetPurchaseList();
        gvAssetPurchaseSearch.Visible = true;
        btnHtmlAssetPurchaseSearch.Visible = true;
        btnHtmlAssetPurchaseClose.Visible = false;
        txtAssetPurchaseSearch.Text = "";
        txtAssetPurchaseSearch.Focus();

    }
    protected void btnAssetPurchaseRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindAssetPurchaseList();
    }

    #endregion AssetPurchase Search

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

    #endregion Events GL Account Search

    protected void ddlopt_GLAccountType_SelectedIndexChanged(object sender, EventArgs e)
    {
        int AccountType = Convert.ToInt32(ddlopt_GLAccountType.SelectedValue);
        int Credit = (int)Enums.CommonEnum.type.Credit;
        int Debit = (int)Enums.CommonEnum.type.Debit;
        if (AccountType == Credit)
        {
            divCredit.Visible = true;
            divDebit.Visible = false;
        }
        else {
            divCredit.Visible = false;
            divDebit.Visible = true;
        }
    }

    #endregion Events

    #region Methods

    #region AssetPurchase Search
    private void SearchAssetPurchaseList()
    {
        try
        {
            AssetPurchaseListBAL assetPurchaseListBAL = new AssetPurchaseListBAL();
            AssetPurchaseListUI assetPurchaseListUI = new AssetPurchaseListUI();

            assetPurchaseListUI.Search = txtAssetPurchaseSearch.Text;

            DataTable dtb = assetPurchaseListBAL.GetAssetPurchaseListBySearchParameters(assetPurchaseListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAssetPurchaseSearch.DataSource = dtb;
                gvAssetPurchaseSearch.DataBind();
                divAssetPurchaseSearchError.Visible = false;
                gvAssetPurchaseSearch.Visible = true;
            }
            else
            {
                divAssetPurchaseSearchError.Visible = true;
                lblAssetPurchaseSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAssetPurchaseSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchAssetPurchaseList()";
            logExcpUIobj.ResourceName = "Asset_Purchase_AssetPurchaseDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Asset_Purchase_AssetPurchaseDistributionForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }


    }
    private void BindAssetPurchaseList()
    {
        try
        {
            DataTable dtb = assetPurchaseListBAL.GetAssetPurchaseList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAssetPurchaseSearch.DataSource = dtb;
                gvAssetPurchaseSearch.DataBind();
                divAssetPurchaseSearchError.Visible = false;
            }
            else
            {
                divAssetPurchaseSearchError.Visible = true;
                lblAssetPurchaseSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAssetPurchaseSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindAssetPurchaseList()";
            logExcpUIobj.ResourceName = "Asset_Purchase_AssetPurchaseDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Asset_Purchase_AssetPurchaseDistributionForm : BindAssetPurchaseList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion

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
            logExcpUIobj.ResourceName = "Asset_Purchase_AssetPurchaseDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Asset_Purchase_AssetPurchaseDistributionForm : SearchPaymentTermsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Asset_Purchase_AssetPurchaseDistributionForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Asset_Purchase_AssetPurchaseDistributionForm : BindGLAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion
    private void FillForm(AssetPurchaseDistributionFormUI assetPurchaseDistributionFormUI)
    {
        try
        {
            DataTable dtb = assetPurchaseDistributionFormBAL.GetAssetPurchaseDistributionListById(assetPurchaseDistributionFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtAssetPurchaseGuid.Text= dtb.Rows[0]["tbl_AssetPurchaseId"].ToString();
                txtAssetPurchase.Text= dtb.Rows[0]["tbl_AssetPurchase"].ToString();
                txtGLAccountGuid.Text = dtb.Rows[0]["tbl_GLAccountId"].ToString();
                txtGLAccount.Text = dtb.Rows[0]["tbl_GLAccount"].ToString();
                ddlopt_GLAccountType.SelectedValue = dtb.Rows[0]["GLAccountType"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                txtDistributionReference.Text = dtb.Rows[0]["DistributionReference"].ToString();
                txtDebit.Text = dtb.Rows[0]["Debit"].ToString();
                txtCredit.Text = dtb.Rows[0]["Credit"].ToString();

            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "FillForm()";
            logExcpUIobj.ResourceName = "Asset_Purchase_AssetPurchaseDistributionForm.CS";
            logExcpUIobj.RecordId = this.assetPurchaseDistributionFormUI.Tbl_AssetPurchaseDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Asset_Purchase_AssetPurchaseDistributionForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region Bind GlAccountType DropDown
    private void BindOptionSetLisDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_AssetPurchaseDistribution";
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
                ddlopt_GLAccountType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "-1"));
            }


        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindOptionSetLisDropDown()";
            logExcpUIobj.ResourceName = "Asset_Purchase_AssetPurchaseDistributionForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Asset_Purchase_AssetPurchaseDistributionForm : BindOptionSetLisDropDown] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #endregion Bind GlAccountType DropDown

    #endregion Methods


    
}
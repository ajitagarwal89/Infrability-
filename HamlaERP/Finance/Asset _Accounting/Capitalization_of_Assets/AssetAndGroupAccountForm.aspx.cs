using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Assets_AssetAndGroupAccount_AssetAndGroupAccountForm : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    GLAccountListBAL gLAccountListBAL = new GLAccountListBAL();
    GLAccountListUI gLAccountListUI = new GLAccountListUI();
    AssetAndGroupAccountFormBAL assetAndGroupAccountFormBAL = new AssetAndGroupAccountFormBAL();
    AssetAndGroupAccountFormUI assetAndGroupAccountFormUI = new AssetAndGroupAccountFormUI();

    #endregion Data Members

    #region Events
    public void Page_Load(object sender, EventArgs e)
    {
        AssetAndGroupAccountFormUI assetAndGroupAccountFormUI = new AssetAndGroupAccountFormUI();


        if (!Page.IsPostBack)
        {
            if (Request.QueryString["AssetAndGroupAccountId"] != null)
            {
                assetAndGroupAccountFormUI.Tbl_AssetAndGroupAccountId = Request.QueryString["AssetAndGroupAccountId"];

                Bind_opt_TypeDropDownList();
                FillForm(assetAndGroupAccountFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Asset And GroupAccount";
            }
            else
            {

                Bind_opt_TypeDropDownList();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Asset And GroupAccount";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            assetAndGroupAccountFormUI.CreatedBy = SessionContext.UserGuid;
            assetAndGroupAccountFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            assetAndGroupAccountFormUI.AccountCode = txtAccountCode.Text;
            assetAndGroupAccountFormUI.Opt_AccountType = int.Parse(ddlOpt_AccountType.SelectedValue);
            assetAndGroupAccountFormUI.Description = txtDescription.Text;
            assetAndGroupAccountFormUI.Tbl_GLAccount_DepreciationExpense = txtDepreciationExpenseGuid.Text;
            assetAndGroupAccountFormUI.Tbl_GLAccount_AccumulatedDepreciation = txtAccumulatedDepreciationGuid.Text;
            assetAndGroupAccountFormUI.Tbl_GLAccount_PriorYearDepreciation = txtPriorYearDepreciationGuid.Text;
            assetAndGroupAccountFormUI.Tbl_GLAccount_AssetCost = txtAssetCostGuid.Text;            
            assetAndGroupAccountFormUI.Tbl_GLAccount_Clearing = txtClearingGuid.Text;

            /*
             fields Parameter
             */

            if (assetAndGroupAccountFormBAL.AddAssetAndGroupAccount(assetAndGroupAccountFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Assets_AssetAndGroupAccount_AssetAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetAndGroupAccount_AssetAndGroupAccountForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {

            assetAndGroupAccountFormUI.ModifiedBy = SessionContext.UserGuid;
            assetAndGroupAccountFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            assetAndGroupAccountFormUI.Tbl_AssetAndGroupAccountId = Request.QueryString["AssetAndGroupAccountId"];
            assetAndGroupAccountFormUI.AccountCode = txtAccountCode.Text;
            assetAndGroupAccountFormUI.Opt_AccountType = int.Parse(ddlOpt_AccountType.SelectedValue);
            assetAndGroupAccountFormUI.Description = txtDescription.Text;
            assetAndGroupAccountFormUI.Tbl_GLAccount_DepreciationExpense = txtDepreciationExpenseGuid.Text;
            assetAndGroupAccountFormUI.Tbl_GLAccount_AccumulatedDepreciation = txtAccumulatedDepreciationGuid.Text;
            assetAndGroupAccountFormUI.Tbl_GLAccount_PriorYearDepreciation = txtPriorYearDepreciationGuid.Text;
            assetAndGroupAccountFormUI.Tbl_GLAccount_AssetCost = txtAssetCostGuid.Text;
            assetAndGroupAccountFormUI.Tbl_GLAccount_Clearing = txtClearingGuid.Text;


            if (assetAndGroupAccountFormBAL.UpdateAssetAndGroupAccount(assetAndGroupAccountFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Assets_AssetAndGroupAccount_AssetAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = assetAndGroupAccountFormUI.Tbl_AssetAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetAndGroupAccount_AssetAndGroupAccountForm : btnUpdate_Click] An error occured in the processing of Record Id : " + assetAndGroupAccountFormUI.Tbl_AssetAndGroupAccountId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            assetAndGroupAccountFormUI.Tbl_AssetAndGroupAccountId = Request.QueryString["AssetAndGroupAccountId"];

            if (assetAndGroupAccountFormBAL.DeleteAssetAndGroupAccount(assetAndGroupAccountFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Assets_AssetAndGroupAccount_AssetAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = assetAndGroupAccountFormUI.Tbl_AssetAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetAndGroupAccount_AssetAndGroupAccountForm : btnDelete_Click] An error occured in the processing of Record Id : " + assetAndGroupAccountFormUI.Tbl_AssetAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetAndGroupAccountList.aspx");
    }

    #region  DepreciationExpense
    protected void btnDepreciationExpenseSearch_Click(object sender, EventArgs e)
    {
        btnHtmlDepreciationExpenseSearch.Visible = false;
        btnHtmlDepreciationExpenseClose.Visible = true;
        SearchDepreciationExpenseList();
    }
    protected void btnClearDepreciationExpenseSearch_Click(object sender, EventArgs e)
    {
        BindDepreciationExpenseList();
        gvDepreciationExpenseSearch.Visible = true;
        btnHtmlDepreciationExpenseSearch.Visible = true;
        btnHtmlDepreciationExpenseClose.Visible = false;
        txtDepreciationExpenseSearch.Text = "";
        txtDepreciationExpenseSearch.Focus();

    }
    protected void btnDepreciationExpenseRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindDepreciationExpenseList();
    }
    #endregion

    #region  AccumulatedDepreciationSearch
    protected void btnAccumulatedDepreciationSearch_Click(object sender, EventArgs e)
    {
        btnHtmlAccumulatedDepreciationSearch.Visible = false;
        btnHtmlAccumulatedDepreciationClose.Visible = true;
        SearchAccumulatedDepreciationList();
    }
    protected void btnClearAccumulatedDepreciationSearch_Click(object sender, EventArgs e)
    {
        BindAccumulatedDepreciationList();
        gvAccumulatedDepreciationSearch.Visible = true;
        btnHtmlAccumulatedDepreciationSearch.Visible = true;
        btnHtmlAccumulatedDepreciationClose.Visible = false;
        txtAccumulatedDepreciationSearch.Text = "";
        txtAccumulatedDepreciationSearch.Focus();

    }
    protected void btnAccumulatedDepreciationRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindAccumulatedDepreciationList();
    }
    #endregion

    #region PriorYearDepreciation Search
    protected void btnPriorYearDepreciationSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPriorYearDepreciationSearch.Visible = false;
        btnHtmlPriorYearDepreciationClose.Visible = true;
        SearchPriorYearDepreciationList();
    }
    protected void btnClearPriorYearDepreciationSearch_Click(object sender, EventArgs e)
    {
        BindPriorYearDepreciationList();
        gvPriorYearDepreciationSearch.Visible = true;
        btnHtmlPriorYearDepreciationSearch.Visible = true;
        btnHtmlPriorYearDepreciationClose.Visible = false;
        txtPriorYearDepreciationSearch.Text = "";
        txtPriorYearDepreciationSearch.Focus();

    }
    protected void btnPriorYearDepreciationRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPriorYearDepreciationList();
    }
    #endregion

    #region AssetCostSearch
    protected void btnAssetCostSearch_Click(object sender, EventArgs e)
    {
        btnHtmlAssetCostSearch.Visible = false;
        btnHtmlAssetCostClose.Visible = true;
        SearchAssetCostList();
    }
    protected void btnClearAssetCostSearch_Click(object sender, EventArgs e)
    {
        BindAssetCostList();
        gvAssetCostSearch.Visible = true;
        btnHtmlAssetCostSearch.Visible = true;
        btnHtmlAssetCostClose.Visible = false;
        txtAssetCostSearch.Text = "";
        txtAssetCostSearch.Focus();

    }
    protected void btnAssetCostRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindAssetCostList();
    }
    #endregion    
  
    #region  Clearing Search
    protected void btnClearingSearch_Click(object sender, EventArgs e)
    {
        btnHtmlClearingSearch.Visible = false;
        btnHtmlClearingClose.Visible = true;
        SearchClearingList();
    }
    protected void btnClearClearingSearch_Click(object sender, EventArgs e)
    {
        BindClearingList();
        gvClearingSearch.Visible = true;
        btnHtmlClearingSearch.Visible = true;
        btnHtmlClearingClose.Visible = false;
        txtClearingSearch.Text = "";
        txtClearingSearch.Focus();

    }
    protected void btnClearingRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindClearingList();
    }
    #endregion

    #endregion Events

    #region Methods
    private void FillForm(AssetAndGroupAccountFormUI assetAndGroupAccountFormUI)
    {
        try
        {
            DataTable dtb = assetAndGroupAccountFormBAL.GetAssetAndGroupAccountListById(assetAndGroupAccountFormUI);

            if (dtb.Rows.Count > 0)
            {
                ddlOpt_AccountType.SelectedValue = dtb.Rows[0]["AccountType"].ToString();
                txtAccountCode.Text = dtb.Rows[0]["AccountCode"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                txtDepreciationExpenseGuid.Text = dtb.Rows[0]["tbl_GLAccount_DepreciationExpense"].ToString();
                txtDepreciationExpense.Text = dtb.Rows[0]["DepreciationExpense"].ToString();
                txtAccumulatedDepreciationGuid.Text = dtb.Rows[0]["tbl_GLAccount_AccumulatedDepreciation"].ToString();
                txtAccumulatedDepreciation.Text = dtb.Rows[0]["AccumulatedDepreciation"].ToString();
                txtPriorYearDepreciationGuid.Text = dtb.Rows[0]["tbl_GLAccount_PriorYearDepreciation"].ToString();
                txtPriorYearDepreciation.Text = dtb.Rows[0]["PriorYearDepreciation"].ToString();
                txtAssetCost.Text = dtb.Rows[0]["AssetCost"].ToString();
                txtAssetCostGuid.Text = dtb.Rows[0]["tbl_GLAccount_AssetCost"].ToString();
                txtClearing.Text = dtb.Rows[0]["Clearing"].ToString();
                txtClearingGuid.Text = dtb.Rows[0]["tbl_GLAccount_Clearing"].ToString();
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
            logExcpUIobj.ResourceName = "Assets_AssetAndGroupAccount_AssetAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = assetAndGroupAccountFormUI.Tbl_AssetAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetAndGroupAccount_AssetAndGroupAccountForm : FillForm] An error occured in the processing of Record Id : " + assetAndGroupAccountFormUI.Tbl_AssetAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }
    }

    private void Bind_opt_TypeDropDownList()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_AssetAndGroupAccount";
            optionSetListUI.OptionSetName = "Opt_AccountType";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {
                ddlOpt_AccountType.DataSource = dtb;
                ddlOpt_AccountType.DataBind();
                ddlOpt_AccountType.DataTextField = "OptionSetLable";
                ddlOpt_AccountType.DataValueField = "OptionSetValue";
                ddlOpt_AccountType.DataBind();
            }
            else
            {
                ddlOpt_AccountType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "Bind_opt_TypeDropDownList()";
            logExcpUIobj.ResourceName = "Assets_AssetAndGroupAccount_AssetAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Assets_AssetAndGroupAccount_AssetAndGroupAccountForm : Bind_opt_TypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region Search DepreciationExpense	
    private void SearchDepreciationExpenseList()
    {
        {

            try
            {
                GLAccountListUI gLAccountListUI = new GLAccountListUI();

                gLAccountListUI.Search = txtDepreciationExpenseSearch.Text;

                DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    gvDepreciationExpenseSearch.DataSource = dtb;
                    gvDepreciationExpenseSearch.DataBind();
                    divDepreciationExpenseSearchError.Visible = false;
                }
                else
                {
                    divDepreciationExpenseSearchError.Visible = true;
                    lblDepreciationExpenseSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                    gvDepreciationExpenseSearch.Visible = false;
                }

            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "SearchDepreciationExpenseList()";
                logExcpUIobj.ResourceName = "Finance_Accounts_Receivable_Customer_Master_Creation_CustomerAndGroupAccount.CS";
                logExcpUIobj.RecordId = "All";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Assets_AssetAndGroupAccount_AssetAndGroupAccountForm : SearchDepreciationExpenseList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
        }
    }
    private void BindDepreciationExpenseList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvDepreciationExpenseSearch.DataSource = dtb;
                gvDepreciationExpenseSearch.DataBind();
                divDepreciationExpenseSearchError.Visible = false;
            }
            else
            {
                divDepreciationExpenseSearchError.Visible = true;
                lblDepreciationExpenseSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvDepreciationExpenseSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindDepreciationExpenseList()";
            logExcpUIobj.ResourceName = "Assets_AssetAndGroupAccount_AssetAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetAndGroupAccount_AssetAndGroupAccountForm : BindPurchaseList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion

    #region AccumulatedDepreciation Search
    private void SearchAccumulatedDepreciationList()
    {
        {

            try
            {
                GLAccountListUI gLAccountListUI = new GLAccountListUI();

                gLAccountListUI.Search = txtAccumulatedDepreciationSearch.Text;

                DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    gvAccumulatedDepreciationSearch.DataSource = dtb;
                    gvAccumulatedDepreciationSearch.DataBind();
                    divAccumulatedDepreciationSearchError.Visible = false;
                }
                else
                {
                    divAccumulatedDepreciationSearchError.Visible = true;
                    lblAccumulatedDepreciationSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                    gvAccumulatedDepreciationSearch.Visible = false;
                }

            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "SearchAccumulatedDepreciationList()";
                logExcpUIobj.ResourceName = "Assets_AssetAndGroupAccount_AssetAndGroupAccountForm.CS";
                logExcpUIobj.RecordId = "All";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Assets_AssetAndGroupAccount_AssetAndGroupAccountForm : SearchDepreciationReserveList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
        }
    }
    private void BindAccumulatedDepreciationList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAccumulatedDepreciationSearch.DataSource = dtb;
                gvAccumulatedDepreciationSearch.DataBind();
                divAccumulatedDepreciationSearchError.Visible = false;
            }
            else
            {
                divAccumulatedDepreciationSearchError.Visible = true;
                lblAccumulatedDepreciationSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAccumulatedDepreciationSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindAccumulatedDepreciationList()";
            logExcpUIobj.ResourceName = "Assets_AssetAndGroupAccount_AssetAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetAndGroupAccount_AssetAndGroupAccountForm : BindAccumulatedDepreciationList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion

    #region Search PriorYearDepreciation 
    private void SearchPriorYearDepreciationList()
    {
        {

            try
            {
                GLAccountListUI gLAccountListUI = new GLAccountListUI();

                gLAccountListUI.Search = txtPriorYearDepreciationSearch.Text;

                DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    gvPriorYearDepreciationSearch.DataSource = dtb;
                    gvPriorYearDepreciationSearch.DataBind();
                    divPriorYearDepreciationSearchError.Visible = false;
                }
                else
                {
                    divPriorYearDepreciationSearchError.Visible = true;
                    lblPriorYearDepreciationSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                    gvPriorYearDepreciationSearch.Visible = false;
                }

            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "SearchPriorYearDepreciationList()";
                logExcpUIobj.ResourceName = "Assets_AssetAndGroupAccount_AssetAndGroupAccountForm.CS";
                logExcpUIobj.RecordId = "All";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Assets_AssetAndGroupAccount_AssetAndGroupAccountForm : SearchPriorYearDepreciationList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
        }
    }
    private void BindPriorYearDepreciationList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPriorYearDepreciationSearch.DataSource = dtb;
                gvPriorYearDepreciationSearch.DataBind();
                divPriorYearDepreciationSearchError.Visible = false;
            }
            else
            {
                divPriorYearDepreciationSearchError.Visible = true;
                lblPriorYearDepreciationSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPriorYearDepreciationSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPriorYearDepreciationList()";
            logExcpUIobj.ResourceName = "Assets_AssetAndGroupAccount_AssetAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetAndGroupAccount_AssetAndGroupAccountForm : BindPriorYearDepreciationList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion

    #region Search AssetCost
    private void SearchAssetCostList()
    {
        {

            try
            {
                GLAccountListUI gLAccountListUI = new GLAccountListUI();

                gLAccountListUI.Search = txtAssetCostSearch.Text;

                DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    gvAssetCostSearch.DataSource = dtb;
                    gvAssetCostSearch.DataBind();
                    divAssetCostSearchError.Visible = false;
                }
                else
                {
                    divAssetCostSearchError.Visible = true;
                    lblAssetCostSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                    gvAssetCostSearch.Visible = false;
                }

            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "SearchAssetCostList()";
                logExcpUIobj.ResourceName = "Assets_AssetAndGroupAccount_AssetAndGroupAccountForm.CS";
                logExcpUIobj.RecordId = "All";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Assets_AssetAndGroupAccount_AssetAndGroupAccountForm : SearchAssetCostList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
        }
    }
    private void BindAssetCostList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvAssetCostSearch.DataSource = dtb;
                gvAssetCostSearch.DataBind();
                divAssetCostSearchError.Visible = false;
            }
            else
            {
                divAssetCostSearchError.Visible = true;
                lblAssetCostSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvAssetCostSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindAssetCostList()";
            logExcpUIobj.ResourceName = "Assets_AssetAndGroupAccount_AssetAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetAndGroupAccount_AssetAndGroupAccountForm : BindAssetCostList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion  
      
    #region Search Clearing
    private void SearchClearingList()
    {
        {

            try
            {
                GLAccountListUI gLAccountListUI = new GLAccountListUI();

                gLAccountListUI.Search = txtClearingSearch.Text;

                DataTable dtb = gLAccountListBAL.GetGLAccountListBySearchParameters(gLAccountListUI);

                if (dtb.Rows.Count > 0 && dtb != null)
                {
                    gvClearingSearch.DataSource = dtb;
                    gvClearingSearch.DataBind();
                    divClearingSearchError.Visible = false;
                }
                else
                {
                    divClearingSearchError.Visible = true;
                    lblClearingSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                    gvClearingSearch.Visible = false;
                }

            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "SearchClearingList()";
                logExcpUIobj.ResourceName = "Assets_AssetAndGroupAccount_AssetAndGroupAccountForm.CS";
                logExcpUIobj.RecordId = "All";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Assets_AssetAndGroupAccount_AssetAndGroupAccountForm : SearchClearingList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
        }
    }
    private void BindClearingList()
    {
        try
        {
            DataTable dtb = gLAccountListBAL.GetGLAccountList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvClearingSearch.DataSource = dtb;
                gvClearingSearch.DataBind();
                divClearingSearchError.Visible = false;
            }
            else
            {
                divClearingSearchError.Visible = true;
                lblClearingSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvClearingSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindClearingList()";
            logExcpUIobj.ResourceName = "Assets_AssetAndGroupAccount_AssetAndGroupAccountForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetAndGroupAccount_AssetAndGroupAccountForm : BindClearingList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    #endregion
    #endregion Methods
}
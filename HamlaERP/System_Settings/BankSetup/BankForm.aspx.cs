using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_BankForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    CountryListBAL countryListBAL = new CountryListBAL();

    BankFormBAL bankFormBAL = new BankFormBAL();
    BankFormUI bankFormUI = new BankFormUI();
    Audit_IUD audit_IUD = new Audit_IUD();

    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        BankFormUI bankFormUI = new BankFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["BankId"] != null || Request.QueryString["recordId"] != null)
            {
                bankFormUI.Tbl_BankId = (Request.QueryString["BankId"] != null ? Request.QueryString["BankId"] : Request.QueryString["recordId"]);
                FillForm(bankFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Bank";
            }
            else
            {



                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New Bank";
            }
            BindCountryList();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            bankFormUI.CreatedBy = SessionContext.UserGuid;
            bankFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            bankFormUI.BankCode = txtBankCode.Text;
            bankFormUI.BankName = txtBankName.Text;
            bankFormUI.Address = txtAddress.Text;
            bankFormUI.City = txtCity.Text;
            bankFormUI.State = txtState.Text;
            bankFormUI.ZipCode = txtZipCode.Text;
            bankFormUI.Tbl_CountryId = txtCountryGuid.Text;
            bankFormUI.Phone = txtPhone.Text;
            bankFormUI.Mobile = txtMobile.Text;
            bankFormUI.Fax = txtFax.Text;
            bankFormUI.Branch = txtBranch.Text;
            bankFormUI.IBAN = txtIban.Text;

            
            

            if (bankFormBAL.AddBank(bankFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                string newValue = (txtBankCode.Text + ',' + txtBankName.Text + ',' + txtAddress.Text + ',' + txtCity.Text + ',' + txtState.Text + ',' + txtZipCode.Text + ',' + txtCountry.Text+','+ txtPhone.Text+','+ txtMobile.Text+','+ txtFax.Text+','+ txtBranch.Text+','+ txtIban.Text);
                audit_IUD.WebServiceInsert(SessionContext.OrganizationId, "tbl_Bank", "", SessionContext.UserGuid, newValue);
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);


            }
            else
            {
                
                divError.Visible = true;
                divSuccess.Visible = false;
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "System_Settings_BankForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BankForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            bankFormUI.ModifiedBy = SessionContext.UserGuid;
            bankFormUI.Tbl_BankId = Request.QueryString["BankId"];
            bankFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;

            bankFormUI.BankCode = txtBankCode.Text;
            bankFormUI.BankName = txtBankName.Text;
            bankFormUI.Address = txtAddress.Text;
            bankFormUI.City = txtCity.Text;
            bankFormUI.State = txtState.Text;
            bankFormUI.ZipCode = txtZipCode.Text;
            bankFormUI.Tbl_CountryId = txtCountryGuid.Text;
            bankFormUI.Phone = txtPhone.Text;
            bankFormUI.Mobile = txtMobile.Text;
            bankFormUI.Fax = txtFax.Text;
            bankFormUI.Branch = txtBranch.Text;
            bankFormUI.IBAN = txtIban.Text;


            if (bankFormBAL.UpdateBank(bankFormUI) == 1)
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
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "System_Settings_BankForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BankForm : btnUpdate_Click] An error occured in the processing of Record Id : " + bankFormUI.Tbl_BankId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            bankFormUI.Tbl_BankId = Request.QueryString["BankId"];

            if (bankFormBAL.DeleteBank(bankFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_BankForm.CS";
            logExcpUIobj.RecordId = bankFormUI.Tbl_BankId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BankForm : btnDelete_Click] An error occured in the processing of Record Id : " + bankFormUI.Tbl_BankId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("BankList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/System_Settings/BankForm.aspx";
        string recordId = Request.QueryString["BankId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    #region Events Country Search

    protected void btnCountrySearch_Click(object sender, EventArgs e)
    {
        btnHtmlCountrySearch.Visible = false;
        btnHtmlCountryClose.Visible = true;
        //gvCountrySearch.Visible = false;
        SearchCountryList();
    }

    protected void btnClearCountrySearch_Click(object sender, EventArgs e)
    {
        BindCountryList();
        gvCountrySearch.Visible = true;
        btnHtmlCountrySearch.Visible = true;
        btnHtmlCountryClose.Visible = false;
        txtCountrySearch.Text = "";
        txtCountrySearch.Focus();
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindCountryList();
    }

    #endregion Events Country Search
    #endregion Events

    #region Methods
    private void FillForm(BankFormUI bankFormUI)
    {
        try
        {
            DataTable dtb = bankFormBAL.GetBankListById(bankFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtBankCode.Text = dtb.Rows[0]["BankCode"].ToString();
                txtBankName.Text = dtb.Rows[0]["BankName"].ToString();
                txtAddress.Text= dtb.Rows[0]["Address"].ToString();
                txtCity.Text= dtb.Rows[0]["City"].ToString();
                txtState.Text= dtb.Rows[0]["State"].ToString();
                txtCountryGuid.Text= dtb.Rows[0]["tbl_CountryId"].ToString();
                txtCountry.Text= dtb.Rows[0]["CountryName"].ToString();
                txtZipCode.Text= dtb.Rows[0]["ZipCode"].ToString();
                txtPhone.Text= dtb.Rows[0]["Phone"].ToString();
                txtMobile.Text= dtb.Rows[0]["Mobile"].ToString();
                txtFax.Text= dtb.Rows[0]["Fax"].ToString();
                txtBranch.Text= dtb.Rows[0]["Branch"].ToString();
                txtIban.Text= dtb.Rows[0]["IBAN"].ToString();

            }
            else
            {
                divError.Visible = true;
                divSuccess.Visible = false;
                lblError.Text = Resources.GlobalResource.msgCouldNotLoadData;
                
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "FillForm()";
            logExcpUIobj.ResourceName = "System_Settings_BankForm.CS";
            logExcpUIobj.RecordId = this.bankFormUI.Tbl_BankId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BankForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region Methods Country Search
    public void BindCountryList()
    {
        try
        {
            DataTable dtb = countryListBAL.GetCountryList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCountrySearch.DataSource = dtb;
                gvCountrySearch.DataBind();
                divCountrySearchError.Visible = false;
            }
            else
            {
                divCountrySearchError.Visible = true;
                lblCountrySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCountrySearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "Search_SearchCountry.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Search_SearchCountry : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void SearchCountryList()
    {
        try
        {
            CountryListUI countryListUI = new CountryListUI();
            countryListUI.Search = txtCountrySearch.Text;

            DataTable dtb = countryListBAL.GetCountryListBySearchParameters(countryListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCountrySearch.DataSource = dtb;
                gvCountrySearch.DataBind();
                divCountrySearchError.Visible = false;
            }
            else
            {
                divCountrySearchError.Visible = true;
                lblCountrySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCountrySearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchCountryList()";
            logExcpUIobj.ResourceName = "System_Settings_BankForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BankForm : SearchCountryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods Country Search

    #endregion Methods
}
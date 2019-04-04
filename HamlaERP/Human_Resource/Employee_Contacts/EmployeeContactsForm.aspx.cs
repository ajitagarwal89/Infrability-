using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Human_Resource_Employee_Contacts_EmployeeContactsForm : PageBase
{

    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    EmployeeContactsFormBAL employeeContactsFormBAL = new EmployeeContactsFormBAL();
    EmployeeListBAL employeeListBAL = new EmployeeListBAL();
    CountryListBAL countryListBAL = new CountryListBAL();
    #endregion Data Members
    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        EmployeeContactsFormUI employeeContactsFormUI = new EmployeeContactsFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["EmployeeContactsId"] != null|| Request.QueryString["recordId"] != null)
            {
                employeeContactsFormUI.Tbl_EmployeeContactsId = (Request.QueryString["EmployeeContactsId"] != null ? Request.QueryString["EmployeeContactsId"] : Request.QueryString["recordId"]) ;

                FillForm(employeeContactsFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnAuditHistory.Visible = true;
                lblHeading.Text = "Update Employee Contacts";
            }
            else
            {
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New Employee Contacts";
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        EmployeeContactsFormUI employeeContactsFormUI = new EmployeeContactsFormUI();
        try
        {

            employeeContactsFormUI.CreatedBy = SessionContext.UserGuid;
            employeeContactsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            employeeContactsFormUI.Tbl_CountryId = txtCountryGuid.Text;
            employeeContactsFormUI.Contact = txtContact.Text;
            employeeContactsFormUI.Tbl_EmployeeId = txtEmployeeGuid.Text;
            employeeContactsFormUI.Relationship = txtRelationship.Text;
            employeeContactsFormUI.HomePhone = txtHomePhone.Text;
            employeeContactsFormUI.WorkPhone = txtWorkPhone.Text;
            employeeContactsFormUI.Ext = txtExt.Text;
            employeeContactsFormUI.Address = txtAddress.Text;
            employeeContactsFormUI.City = txtCity.Text;
            employeeContactsFormUI.State = txtState.Text;
            employeeContactsFormUI.ZipCode = txtZipCode.Text;

            if (employeeContactsFormBAL.AddEmployeeContacts(employeeContactsFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                divSuccess.Visible = false;
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

            EmployeeContactsFormUI employeeContactsFormUI = new EmployeeContactsFormUI();
            try
            {

                employeeContactsFormUI.ModifiedBy = SessionContext.UserGuid;
                employeeContactsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                employeeContactsFormUI.Tbl_EmployeeContactsId = Request.QueryString["EmployeeContactsId"];
                employeeContactsFormUI.Tbl_CountryId = txtCountryGuid.Text;
                employeeContactsFormUI.Contact = txtContact.Text;
                employeeContactsFormUI.Tbl_EmployeeId = txtEmployeeGuid.Text;
                employeeContactsFormUI.Relationship = txtRelationship.Text;
                employeeContactsFormUI.HomePhone = txtHomePhone.Text;
                employeeContactsFormUI.WorkPhone = txtWorkPhone.Text;
                employeeContactsFormUI.Ext = txtExt.Text;
                employeeContactsFormUI.Address = txtAddress.Text;
                employeeContactsFormUI.City = txtCity.Text;
                employeeContactsFormUI.State = txtState.Text;
                employeeContactsFormUI.ZipCode = txtZipCode.Text;
            if (employeeContactsFormBAL.UpdateEmployeeContacts(employeeContactsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_EmployeeContacts_Supplier_Master_Creation_EmployeeContactsForm.CS";
            logExcpUIobj.RecordId = employeeContactsFormUI.Tbl_EmployeeContactsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_EmployeeContacts_Supplier_Master_Creation_EmployeeContactsForm : btnUpdate_Click] An error occured in the processing of Record Id : " + employeeContactsFormUI.Tbl_EmployeeContactsId + ".  Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        EmployeeContactsFormUI employeeContactsFormUI = new EmployeeContactsFormUI();
        try
        {
            employeeContactsFormUI.Tbl_EmployeeContactsId = Request.QueryString["EmployeeContactsId"];

            if (employeeContactsFormBAL.DeleteEmployeeContacts(employeeContactsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_EmployeeContacts_Supplier_Master_Creation_EmployeeContactsForm.CS";
            logExcpUIobj.RecordId = employeeContactsFormUI.Tbl_EmployeeContactsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_EmployeeContacts_Supplier_Master_Creation_EmployeeContactsForm : btnDelete_Click] An error occured in the processing of Record Id : " + employeeContactsFormUI.Tbl_EmployeeContactsId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Human_Resource/Employee_Contacts/EmployeeContactsForm.aspx";
        string recordId = Request.QueryString["EmployeeContactsId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeContactsList.aspx");
    }

    #region Events Country Search

    protected void btnCountrySearch_Click(object sender, EventArgs e)
    {
        btnHtmlCountrySearch.Visible = false;
        btnHtmlCountryClose.Visible = true;
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

    protected void btnCountryRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindCountryList();
    }

    #endregion Events Country Search

    #region Events Employee Search

    protected void btnEmployeeSearch_Click(object sender, EventArgs e)
    {
        btnHtmlEmployeeSearch.Visible = false;
        btnHtmlEmployeeClose.Visible = true;
        SearchEmployeeList();
    }

    protected void btnClearEmployeeSearch_Click(object sender, EventArgs e)
    {
        BindEmployeeList();
        gvEmployeeSearch.Visible = true;
        btnHtmlEmployeeSearch.Visible = true;
        btnHtmlEmployeeClose.Visible = false;
        txtEmployeeSearch.Text = "";
        txtEmployeeSearch.Focus();
    }

    protected void btnEmployeeRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindEmployeeList();
    }

    #endregion Events Employee Search

    #endregion Events

    #region Methods
    private void FillForm(EmployeeContactsFormUI employeeContactsFormUI)
    {
        try
        {
            DataTable dtb = employeeContactsFormBAL.GetEmployeeContactsListById(employeeContactsFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtEmployee.Text= dtb.Rows[0]["tbl_Employee"].ToString();
                txtEmployeeGuid.Text = dtb.Rows[0]["tbl_EmployeeId"].ToString();
                txtContact.Text = dtb.Rows[0]["Contact"].ToString();
                txtCountryGuid.Text = dtb.Rows[0]["tbl_CountryId"].ToString();
                txtCountry.Text = dtb.Rows[0]["CountryName"].ToString();
                txtRelationship.Text= dtb.Rows[0]["Relationship"].ToString();
                txtHomePhone.Text= dtb.Rows[0]["HomePhone"].ToString();
                txtWorkPhone.Text= dtb.Rows[0]["WorkPhone"].ToString();
                txtExt.Text= dtb.Rows[0]["Ext"].ToString();
                txtAddress.Text= dtb.Rows[0]["Address"].ToString();
                txtCity.Text= dtb.Rows[0]["City"].ToString();
                txtState.Text= dtb.Rows[0]["State"].ToString();
                txtZipCode.Text= dtb.Rows[0]["ZipCode"].ToString();
                
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_EmployeeContacts_Supplier_Master_Creation_EmployeeContactsForm.CS";
            logExcpUIobj.RecordId = employeeContactsFormUI.Tbl_EmployeeContactsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_EmployeeContacts_Supplier_Master_Creation_EmployeeContactsForm : FillForm] An error occured in the processing of Record Id : " + employeeContactsFormUI.Tbl_EmployeeContactsId + ". Details : [" + exp.ToString() + "]");
        }
    }

    #region Methods Employee Search
    public void BindEmployeeList()
    {
        try
        {
            DataTable dtb = employeeListBAL.GetEmployeeList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvEmployeeSearch.DataSource = dtb;
                gvEmployeeSearch.DataBind();
                divEmployeeSearchError.Visible = false;
            }
            else
            {
                divEmployeeSearchError.Visible = true;
                lblEmployeeSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvEmployeeSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindEmployeeList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_EmployeeContacts_Supplier_Master_Creation_EmployeeContactsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_EmployeeContacts_Supplier_Master_Creation_EmployeeContactsForm : BindEmployeeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    public void SearchEmployeeList()
    {
        try
        {
            EmployeeListUI employeeListUI = new EmployeeListUI();
            employeeListUI.Search = txtEmployeeSearch.Text;

            DataTable dtb = employeeListBAL.GetEmployeeListBySearchParameters(employeeListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvEmployeeSearch.DataSource = dtb;
                gvEmployeeSearch.DataBind();
                divEmployeeSearchError.Visible = false;
            }
            else
            {
                divEmployeeSearchError.Visible = true;
                lblEmployeeSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvEmployeeSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchEmployeeList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_EmployeeContacts_Supplier_Master_Creation_EmployeeContactsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_EmployeeContacts_Supplier_Master_Creation_EmployeeContactsForm : SearchEmployeeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods Employee Search
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
            logExcpUIobj.MethodName = "BindCountryList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_EmployeeContacts_Supplier_Master_Creation_EmployeeContactsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_EmployeeContacts_Supplier_Master_Creation_EmployeeContactsForm : BindCountryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_EmployeeContacts_Supplier_Master_Creation_EmployeeContactsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_EmployeeContacts_Supplier_Master_Creation_EmployeeContactsForm : SearchCountryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods Country Search
    


    #endregion Methods
}
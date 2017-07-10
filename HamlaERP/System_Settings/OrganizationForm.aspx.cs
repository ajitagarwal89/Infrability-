using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Finware;
using log4net;

public partial class System_Settings_OrganizationForm : PageBase
{
    #region Data Members
    OrganizationFormBAL organizationFormBAL = new OrganizationFormBAL();
    OrganizationTypeListBAL organizationTypeListBAL = new OrganizationTypeListBAL();
    CountryListBAL countryListBAL = new CountryListBAL();

    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        OrganizationFormUI organizationFormUI = new OrganizationFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["OrganizationId"] != null)
            {
                organizationFormUI.Tbl_OrganizationId = Request.QueryString["OrganizationId"];
                BindOrganizationTypeDropDown();
                FillForm(organizationFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Organisation";
            }
            else
            {
                BindOrganizationTypeDropDown();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Organisation";
            }
            //BindCountryList();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        OrganizationFormUI organizationFormUI = new OrganizationFormUI();

        try
        {
            //=====>>>IMAGE UPLOAD<<<<=============
            Byte[] imgByte = null;

            if (fuLogo.PostedFile != null)
            {
                //To create a PostedFile
                HttpPostedFile File = fuLogo.PostedFile;
                //Create byte Array with file len
                imgByte = new Byte[File.ContentLength];
                //force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength);
            }

            organizationFormUI.CreatedBy = SessionContext.UserGuid;
            organizationFormUI.Tbl_OrganizationTypeId = ddlOrganizationType.SelectedValue.ToString();
            organizationFormUI.OrganizationCode = txtCode.Text.Trim();
            organizationFormUI.Name = txtName.Text.Trim();
            organizationFormUI.Address = txtAddress.Text.Trim();
            organizationFormUI.City = txtCity.Text.Trim();
            organizationFormUI.State = txtState.Text.Trim();
            organizationFormUI.PostalCode = txtPostalCode.Text.Trim();

            organizationFormUI.Tbl_CountryId = lblCountryGuid.Text;

            organizationFormUI.PhoneNo = txtPhone.Text.Trim();
            organizationFormUI.FaxNo = txtFax.Text.Trim();
            organizationFormUI.Mobile = txtMobile.Text.Trim();
            organizationFormUI.WebSite = txtWebsite.Text.Trim();
            organizationFormUI.Email = txtEmail.Text.Trim();
            organizationFormUI.Owner = txtOwner.Text.Trim();
            organizationFormUI.Logo = imgByte;

            if (organizationFormBAL.AddOrganization(organizationFormUI) == 1)
            {
                divSuccess.Visible = true;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
                divError.Visible = true;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "System_Settings_OrganizationForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OrganizationForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        OrganizationFormUI organizationFormUI = new OrganizationFormUI();

        try
        {
            //=====>>>IMAGE UPLOAD<<<<=============
            Byte[] imgByte = null;
            if (fuLogo.PostedFile != null)
            {
                //To create a PostedFile
                HttpPostedFile File = fuLogo.PostedFile;
                //Create byte Array with file len
                imgByte = new Byte[File.ContentLength];
                //force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength);
            }

            organizationFormUI.ModifiedBy = SessionContext.UserGuid;
            organizationFormUI.Tbl_OrganizationId = Request.QueryString["OrganizationId"];
            organizationFormUI.Tbl_OrganizationTypeId = ddlOrganizationType.SelectedValue.ToString();
            organizationFormUI.OrganizationCode = txtCode.Text.Trim();
            organizationFormUI.Name = txtName.Text.Trim();
            organizationFormUI.Address = txtAddress.Text.Trim();
            organizationFormUI.City = txtCity.Text.Trim();
            organizationFormUI.State = txtState.Text.Trim();
            organizationFormUI.PostalCode = txtPostalCode.Text.Trim();
            organizationFormUI.Tbl_CountryId = lblCountryGuid.Text;
            organizationFormUI.PhoneNo = txtPhone.Text.Trim();
            organizationFormUI.FaxNo = txtFax.Text.Trim();
            organizationFormUI.Mobile = txtMobile.Text.Trim();
            organizationFormUI.WebSite = txtWebsite.Text.Trim();
            organizationFormUI.Email = txtEmail.Text.Trim();
            organizationFormUI.Owner = txtOwner.Text.Trim();

            if (imgByte.Length > 0)
                organizationFormUI.Logo = imgByte;
            else
                organizationFormUI.Logo = null;

            if (organizationFormBAL.UpdateOrganization(organizationFormUI) == 1)
            {
                divSuccess.Visible = true;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
                organizationFormUI.Tbl_OrganizationId = Request.QueryString["OrganizationId"];
                BindOrganizationTypeDropDown();
                FillForm(organizationFormUI);
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
            logExcpUIobj.ResourceName = "System_Settings_OrganizationForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OrganizationForm : btnUpdate_Click] An error occured in the processing of Record Id : " + organizationFormUI.Tbl_OrganizationId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        OrganizationFormUI organizationFormUI = new OrganizationFormUI();

        try
        {
            organizationFormUI.Tbl_OrganizationId = Request.QueryString["OrganizationId"];

            if (organizationFormBAL.DeleteOrganization(organizationFormUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_OrganizationList.CS";
            logExcpUIobj.RecordId = organizationFormUI.Tbl_OrganizationId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OrganizationList : btnDelete_Click] An error occured in the processing of Record Id : " + organizationFormUI.Tbl_OrganizationId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrganizationList.aspx");
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
    private void FillForm(OrganizationFormUI organizationFormUI)
    {
        try
        {
            DataTable dtb = organizationFormBAL.GetOrganizationListById(organizationFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtCode.Text = dtb.Rows[0]["organizationcode"].ToString();
                txtName.Text = dtb.Rows[0]["name"].ToString();
                txtWebsite.Text = dtb.Rows[0]["website"].ToString();
                txtPhone.Text = dtb.Rows[0]["phoneno"].ToString();
                txtMobile.Text = dtb.Rows[0]["mobile"].ToString();
                txtFax.Text = dtb.Rows[0]["faxno"].ToString();
                txtCity.Text = dtb.Rows[0]["city"].ToString();
                txtState.Text = dtb.Rows[0]["state"].ToString();
                txtPostalCode.Text = dtb.Rows[0]["postalcode"].ToString();
                txtAddress.Text = dtb.Rows[0]["address"].ToString();
                txtOwner.Text = dtb.Rows[0]["Owner"].ToString();
                txtEmail.Text = dtb.Rows[0]["email"].ToString();
                ddlOrganizationType.SelectedValue = dtb.Rows[0]["tbl_OrganizationTypeId"].ToString();
                txtCountry.Text = dtb.Rows[0]["CountryName"].ToString();
                lblCountryGuid.Text = dtb.Rows[0]["tbl_CountryId"].ToString();

                byte[] imageByte = (byte[])dtb.Rows[0]["Logo"];
                if (imageByte != null)
                {
                    string logo = Convert.ToBase64String(imageByte);
                    imgLogo.ImageUrl = "data:Image/jpg;base64," + logo;
                }

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
            logExcpUIobj.ResourceName = "System_Settings_OrganizationForm.CS";
            logExcpUIobj.RecordId = organizationFormUI.Tbl_OrganizationId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OrganizationForm : FillForm] An error occured in the processing of Record Id : " + organizationFormUI.Tbl_OrganizationId + ". Details : [" + exp.ToString() + "]");
        }
    }

    private void BindOrganizationTypeDropDown()
    {
        try
        {
            DataTable dtb = organizationTypeListBAL.GetOrganizationTypeList();

            if (dtb.Rows.Count > 0)
            {
                ddlOrganizationType.DataSource = dtb;
                ddlOrganizationType.DataBind();

                ddlOrganizationType.DataTextField = "OrganizationType";
                ddlOrganizationType.DataValueField = "tbl_OrganizationTypeId";
                ddlOrganizationType.DataBind();
            }
            else
            {
                ddlOrganizationType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindOrganizationTypeDropDown()";
            logExcpUIobj.ResourceName = "System_Settings_OrganizationForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OrganizationForm : BindOrganizationTypeDropDown] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
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
            logExcpUIobj.ResourceName = "System_Settings_OrganizationForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_OrganizationForm : SearchCountryList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods Country Search

    #endregion Methods
}
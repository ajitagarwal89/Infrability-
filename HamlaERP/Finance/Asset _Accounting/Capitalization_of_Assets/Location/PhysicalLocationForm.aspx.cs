using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Physical_Location_PhysicalLocationForm : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    LocationListBAL locationListBAL = new LocationListBAL();

    PhysicalLocationFormBAL physicalLocationFormBAL = new PhysicalLocationFormBAL();
    PhysicalLocationFormUI physicalLocationFormUI = new PhysicalLocationFormUI();
    #endregion Data Members
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        PhysicalLocationFormUI physicalLocationFormUI = new PhysicalLocationFormUI();


        if (!Page.IsPostBack)
        {
            if (Request.QueryString["PhysicalLocationId"] != null)
            {
                physicalLocationFormUI.Tbl_PhysicalLocationId = Request.QueryString["PhysicalLocationId"];
                FillForm(physicalLocationFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Physical Location";
            }
            else
            {
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Physical Location";
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            physicalLocationFormUI.CreatedBy = SessionContext.UserGuid;
            physicalLocationFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            physicalLocationFormUI.Description = txtDescription.Text;
            physicalLocationFormUI.LastInventoryDate =DateTime.Parse(txtLastInventoryDate.Text);
            physicalLocationFormUI.Tbl_LocationId = txtLocationGuid.Text;
            if (physicalLocationFormBAL.AddPhysicalLocation(physicalLocationFormUI) == 1)
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
            logExcpUIobj.ResourceName = "PhysicalLocation_PhysicalLocationForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PhysicalLocation_PhysicalLocationForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {


        PhysicalLocationFormUI physicalLocationFormUI = new PhysicalLocationFormUI();
        try
        {
            physicalLocationFormUI.ModifiedBy = SessionContext.UserGuid;
            physicalLocationFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            physicalLocationFormUI.LastInventoryDate = DateTime.Parse(txtLastInventoryDate.Text); 
            physicalLocationFormUI.Description = txtDescription.Text;
            physicalLocationFormUI.Tbl_LocationId = txtLocationGuid.Text;
            physicalLocationFormUI.Tbl_PhysicalLocationId = Request.QueryString["PhysicalLocationId"];
            if (physicalLocationFormBAL.UpdatePhysicalLocation(physicalLocationFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);

            }
            else
            {
                divSuccess.Visible = false;
                divError.Visible = true;

                lblError.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "PhysicalLocation_PhysicalLocationForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PhysicalLocation_PhysicalLocationForm : btnUpdate_Click] An error occured in the processing of Record Id : " + physicalLocationFormUI.Tbl_PhysicalLocationId + ".  Details : [" + exp.ToString() + "]");
        }



    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            physicalLocationFormUI.Tbl_PhysicalLocationId = Request.QueryString["PhysicalLocationId"];

            if (physicalLocationFormBAL.DeletePhysicalLocation(physicalLocationFormUI) == 1)
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
            logExcpUIobj.ResourceName = "PhysicalLocation_PhysicalLocationForm.CS";
            logExcpUIobj.RecordId = physicalLocationFormUI.Tbl_PhysicalLocationId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PhysicalLocation_PhysicalLocationForm : btnDelete_Click] An error occured in the processing of Record Id : " + physicalLocationFormUI.Tbl_PhysicalLocationId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PhysicalLocationList.aspx");
    }

    #region Location Search

    protected void btnLocationSearch_Click(object sender, EventArgs e)
    {
        btnHtmlLocationSearch.Visible = false;
        btnHtmlLocationClose.Visible = true;
        SearchLocationList();
    }

    protected void btnClearLocationSearch_Click(object sender, EventArgs e)
    {
        BindLocationList();
        gvLocationSearch.Visible = true;
        btnHtmlLocationSearch.Visible = true;
        btnHtmlLocationClose.Visible = false;
        txtLocationSearch.Text = "";
        txtLocationSearch.Focus();
    }

    protected void btnLocationRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindLocationList();
    }

    #endregion Location Search

    #endregion Events

    #region Methods
    private void FillForm(PhysicalLocationFormUI physicalLocationFormUI)
    {
        try
        {
            DataTable dtb = physicalLocationFormBAL.GetPhysicalLocationListById(physicalLocationFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtLastInventoryDate.Text = dtb.Rows[0]["LastInventoryDate"].ToString();
                txtDescription.Text = dtb.Rows[0]["Description"].ToString();
                txtLocationGuid.Text = dtb.Rows[0]["tbl_LocationId"].ToString();
                txtLocation.Text = dtb.Rows[0]["tbl_Location"].ToString();

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
            logExcpUIobj.ResourceName = "PhysicalLocation_PhysicalLocationForm.CS";
            logExcpUIobj.RecordId = physicalLocationFormUI.Tbl_PhysicalLocationId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PhysicalLocation_PhysicalLocationForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    #region  Location Search
    public void BindLocationList()
    {
        try
        {
            DataTable dtb = locationListBAL.GetLocationList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvLocationSearch.DataSource = dtb;
                gvLocationSearch.DataBind();
                divLocationSearchError.Visible = false;
            }
            else
            {
                divLocationSearchError.Visible = true;
                lblLocationSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvLocationSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "Search_SearchLocation.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Search_SearchLocation : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void SearchLocationList()
    {
        try
        {
            LocationListUI locationListUI = new LocationListUI();
            locationListUI.Search = txtLocationSearch.Text;

            DataTable dtb = locationListBAL.GetLocationListBySearchParameters(locationListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvLocationSearch.DataSource = dtb;
                gvLocationSearch.DataBind();
                divLocationSearchError.Visible = false;
            }
            else
            {
                divLocationSearchError.Visible = true;
                lblLocationSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvLocationSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchLocationList()";
            logExcpUIobj.ResourceName = "PhysicalLocation_PhysicalLocationForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PhysicalLocation_PhysicalLocationForm : SearchLocationList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Location Search

    #endregion Methods

}
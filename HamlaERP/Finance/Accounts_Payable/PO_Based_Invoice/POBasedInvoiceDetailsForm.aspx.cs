using Finware;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    POBasedInvoiceDetailsFormBAL pOBasedInvoiceDetailsFormBAL = new POBasedInvoiceDetailsFormBAL();
    POBasedInvoiceDetailsFormUI pOBasedInvoiceDetailsFormUI = new POBasedInvoiceDetailsFormUI();

    POBasedInvoiceListUI pOBasedInvoiceListUI = new POBasedInvoiceListUI();
    POBasedInvoiceListBAL pOBasedInvoiceListBAL = new POBasedInvoiceListBAL();

    POListBAL pOListBAL = new POListBAL();
    LocationListBAL locationListBAL = new LocationListBAL();

    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        POBasedInvoiceDetailsFormUI pOBasedInvoiceDetailsFormUI = new POBasedInvoiceDetailsFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["POBasedInvoiceDetailsId"] != null || Request.QueryString["recordId"] != null)
            {
                pOBasedInvoiceDetailsFormUI.Tbl_POBasedInvoiceDetailsId = (Request.QueryString["POBasedInvoiceDetailsId"] != null ? Request.QueryString["POBasedInvoiceDetailsId"] : Request.QueryString["recordId"]);

                //BindOrganizationDropDown();
                FillForm(pOBasedInvoiceDetailsFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnAuditHistory.Visible = true;
                lblHeading.Text = "Update POBasedInvoiceDetails";
            }
            else
            {

                //BindOrganizationDropDown();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAuditHistory.Visible = false;
                lblHeading.Text = "Add New POBasedInvoiceDetails";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            pOBasedInvoiceDetailsFormUI.CreatedBy = SessionContext.UserGuid;
            pOBasedInvoiceDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            pOBasedInvoiceDetailsFormUI.Tbl_POBasedInvoiceId = txtlPOBasedInvoiceGuid.Text;
            pOBasedInvoiceDetailsFormUI.Tbl_POId = txtPOGuid.Text;
            pOBasedInvoiceDetailsFormUI.Tbl_LocationId = txtLocationGuid.Text;
            pOBasedInvoiceDetailsFormUI.UOM = txtUOM.Text;
            pOBasedInvoiceDetailsFormUI.Description = txtDescription.Text;
            pOBasedInvoiceDetailsFormUI.QuantityInvoice = Convert.ToDecimal(txtQuantityInvoice.Text);
            pOBasedInvoiceDetailsFormUI.UnitCost = Convert.ToDecimal(txtUnitCost.Text);
            pOBasedInvoiceDetailsFormUI.ExtendedCost = Convert.ToDecimal(txtExtendedCost.Text);

            /*
             fields Parameter
             */

            if (pOBasedInvoiceDetailsFormBAL.AddPOBasedInvoiceDetails(pOBasedInvoiceDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            pOBasedInvoiceDetailsFormUI.ModifiedBy = SessionContext.UserGuid;
            pOBasedInvoiceDetailsFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            pOBasedInvoiceDetailsFormUI.Tbl_POBasedInvoiceDetailsId = Request.QueryString["POBasedInvoiceDetailsId"];
            pOBasedInvoiceDetailsFormUI.Tbl_POBasedInvoiceId = txtlPOBasedInvoiceGuid.Text;
            pOBasedInvoiceDetailsFormUI.Tbl_POId = txtPOGuid.Text;
            pOBasedInvoiceDetailsFormUI.Tbl_LocationId = txtLocationGuid.Text;
            pOBasedInvoiceDetailsFormUI.UOM = txtUOM.Text;
            pOBasedInvoiceDetailsFormUI.Description = txtDescription.Text;
            pOBasedInvoiceDetailsFormUI.QuantityInvoice = Convert.ToDecimal(txtQuantityInvoice.Text);
            pOBasedInvoiceDetailsFormUI.UnitCost = Convert.ToDecimal(txtUnitCost.Text);
            pOBasedInvoiceDetailsFormUI.ExtendedCost = Convert.ToDecimal(txtExtendedCost.Text);

            if (pOBasedInvoiceDetailsFormBAL.UpdatePOBasedInvoiceDetails(pOBasedInvoiceDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm.CS";
            logExcpUIobj.RecordId = pOBasedInvoiceDetailsFormUI.Tbl_POBasedInvoiceDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm : btnUpdate_Click] An error occured in the processing of Record Id : " + pOBasedInvoiceDetailsFormUI.Tbl_POBasedInvoiceDetailsId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    #region POBasedInvoice Search
    protected void btnPOBasedInvoiceSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPOBasedInvoiceSearch.Visible = false;
        btnHtmlPOBasedInvoiceClose.Visible = true;
        SearchPOBasedInvoiceList();
    }

    protected void btnClearPOBasedInvoiceSearch_Click(object sender, EventArgs e)
    {
        BindPOBasedInvoiceList();
        gvPOBasedInvoiceSearch.Visible = true;
        btnHtmlPOBasedInvoiceSearch.Visible = true;
        btnHtmlPOBasedInvoiceClose.Visible = false;
        txtPOBasedInvoiceSearch.Text = "";
        txtPOBasedInvoiceSearch.Focus();
    }

    protected void btnPOBasedInvoiceRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPOBasedInvoiceList();
    }

    #endregion POBasedInvoice Search


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

    #region PO Search
    protected void btnPOSearch_Click(object sender, EventArgs e)
    {
        btnHtmlPOSearch.Visible = false;
        btnHtmlPOClose.Visible = true;
        SearchPOList();
    }
    protected void btnClearPOSearch_Click(object sender, EventArgs e)
    {
        BindPOList();
        gvPOSearch.Visible = true;
        btnHtmlPOSearch.Visible = true;
        btnHtmlPOClose.Visible = false;
        txtPOSearch.Text = "";
        txtPOSearch.Focus();
    }
    protected void btnPORefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPOList();
    }
    #endregion PO Search


    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            pOBasedInvoiceDetailsFormUI.Tbl_POBasedInvoiceDetailsId = Request.QueryString["POBasedInvoiceDetailsId"];

            if (pOBasedInvoiceDetailsFormBAL.DeletePOBasedInvoiceDetails(pOBasedInvoiceDetailsFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm.CS";
            logExcpUIobj.RecordId = pOBasedInvoiceDetailsFormUI.Tbl_POBasedInvoiceDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm : btnDelete_Click] An error occured in the processing of Record Id : " + pOBasedInvoiceDetailsFormUI.Tbl_POBasedInvoiceDetailsId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("POBasedInvoiceDetailsList.aspx");
    }

    protected void btnAuditHistory_Click(object sender, EventArgs e)
    {
        string Form = "~/Finance/Accounts_Payable/PO_Based_Invoice/POBasedInvoiceDetailsForm.aspx";
        string recordId = Request.QueryString["POBasedInvoiceDetailsId"];
        Response.Redirect("~/" + CommonClasses.AUDIT_HISTORY_LINK + "AuditHistoryList.aspx?recordId=" + recordId + "&Form=" + Form);
    }

    #endregion Events

    #region Methods
    private void FillForm(POBasedInvoiceDetailsFormUI pOBasedInvoiceDetailsFormUI)
    {
        try
        {
            DataTable dtb = pOBasedInvoiceDetailsFormBAL.GetPOBasedInvoiceDetailsListById(pOBasedInvoiceDetailsFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtlPOBasedInvoice.Text= dtb.Rows[0]["tbl_POBasedInvoice"].ToString();
                txtlPOBasedInvoiceGuid.Text = dtb.Rows[0]["tbl_POBasedInvoiceId"].ToString();

                txtPO.Text = dtb.Rows[0]["tbl_PO"].ToString();
                txtPOGuid.Text = dtb.Rows[0]["tbl_POId"].ToString();

                txtLocation.Text= dtb.Rows[0]["tbl_Location"].ToString();
                txtLocationGuid.Text= dtb.Rows[0]["tbl_LocationId"].ToString();

                 txtUOM.Text= dtb.Rows[0]["UOM"].ToString();
                txtDescription.Text= dtb.Rows[0]["Description"].ToString();

                txtQuantityInvoice.Text = dtb.Rows[0]["QuantityInvoice"].ToString();

                txtUnitCost.Text = dtb.Rows[0]["UnitCost"].ToString();
                txtExtendedCost.Text = dtb.Rows[0]["ExtendedCost"].ToString();           
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm.CS";
            logExcpUIobj.RecordId = pOBasedInvoiceDetailsFormUI.Tbl_POBasedInvoiceDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm : FillForm] An error occured in the processing of Record Id : " + pOBasedInvoiceDetailsFormUI.Tbl_POBasedInvoiceDetailsId + ". Details : [" + exp.ToString() + "]");
        }
    }


    #region  POBasedInvoice Search
    public void BindPOBasedInvoiceList()
    {
        try
        {
            DataTable dtb = pOBasedInvoiceListBAL.GetPOBasedInvoiceList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPOBasedInvoiceSearch.DataSource = dtb;
                gvPOBasedInvoiceSearch.DataBind();
                divPOBasedInvoiceSearchError.Visible = false;
            }
            else
            {
                divPOBasedInvoiceSearchError.Visible = true;
                lblPOBasedInvoiceSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPOBasedInvoiceSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    public void SearchPOBasedInvoiceList()
    {
        try
        {
            POBasedInvoiceListUI pOBasedInvoiceListUI = new POBasedInvoiceListUI();
            pOBasedInvoiceListUI.Search = txtPOBasedInvoiceSearch.Text;

            DataTable dtb = pOBasedInvoiceListBAL.GetPOBasedInvoiceListBySearchParameters(pOBasedInvoiceListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPOBasedInvoiceSearch.DataSource = dtb;
                gvPOBasedInvoiceSearch.DataBind();
                divPOBasedInvoiceSearchError.Visible = false;
                gvPOBasedInvoiceSearch.Visible = true;
            }
            else
            {
                divPOBasedInvoiceSearchError.Visible = true;
                lblPOBasedInvoiceSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPOBasedInvoiceSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchLocationList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm : SearchLocationList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Location Search

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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
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
                gvLocationSearch.Visible = true;
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm : SearchLocationList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Location Search

    #region PO Search
    private void SearchPOList()
    {
        try
        {
            POListUI pOListUI = new POListUI();
            pOListUI.Search = txtPOSearch.Text;
            DataTable dtb = pOListBAL.GetPOListBySearchParameters(pOListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPOSearch.DataSource = dtb;
                gvPOSearch.DataBind();
                divPOSearchError.Visible = false;
                gvPOSearch.Visible = true;
            }
            else
            {
                divPOSearchError.Visible = true;
                lblPOSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPOSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchPOList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm : SearchPOList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindPOList()
    {
        try
        {
            DataTable dtb = pOListBAL.GetPOList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPOSearch.DataSource = dtb;
                gvPOSearch.DataBind();
                divPOSearchError.Visible = false;
            }
            else
            {
                divPOSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPOSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPOList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm : BindPOList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  PO search


    #endregion Methods
}
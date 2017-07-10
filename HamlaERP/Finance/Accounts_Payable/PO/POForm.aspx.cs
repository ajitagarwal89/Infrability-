using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;


public partial class Finance_Accounts_Payable_PO_POForm : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    POFormBAL pOFormBAL = new POFormBAL();
    POFormUI pOFormUI = new POFormUI();

    CurrencyListBAL currencyListBAL = new CurrencyListBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
    SupplierListBAL supplierListBAL = new SupplierListBAL();
    CommentsListBAL commentsListBAL = new CommentsListBAL();
    UserListBAL userListBAL = new UserListBAL();

    #endregion Data Members

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        POFormUI pOFormUI = new POFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["POId"] != null)
            {
                pOFormUI.Tbl_POId = Request.QueryString["POId"];

                BindStatusDropDown();
                BindTypeDropDown();
                FillForm(pOFormUI);

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update PO";
            }
            else
            {
                BindStatusDropDown();
                BindTypeDropDown();

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New PO";
            }
        }
    }

   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            pOFormUI.CreatedBy = SessionContext.UserGuid;
            pOFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            pOFormUI.opt_Type = int.Parse(ddlOpt_opt_Type.SelectedValue);
            pOFormUI.PONumber = txtPONumber.Text;
            pOFormUI.Tbl_SupplierId = txtSupplierGuid.Text;
            pOFormUI.Tbl_UserId_Buyer = txtUserId_BuyerGuid.Text;
            pOFormUI.Date =DateTime.Parse(txtDate.Text);
            pOFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            if (chkAllowSales.Checked)
            {
                pOFormUI.AllowSales = true;
            }
            else
            {
                pOFormUI.AllowSales = false;
            }
            pOFormUI.RequisitionDate = DateTime.Parse(txtRequisitionDate.Text);
            pOFormUI.PurchaseOrderDate = DateTime.Parse(txtPurchaseOrderDate.Text);
            pOFormUI.LastEditDate = DateTime.Parse(txtLastEditDate.Text);
            pOFormUI.LastPrintedDate = DateTime.Parse(txtLastPrintedDate.Text);
            pOFormUI.ContractExpirationDate = DateTime.Parse(txtContractExpirationDate.Text);
            pOFormUI.DatePlacedOnHold = DateTime.Parse(txtDatePlacedOnHold.Text);
            pOFormUI.DateHoldRemoved = DateTime.Parse(txtDateHoldRemoved.Text);
            pOFormUI.Tbl_UserId_PlacedOnHoldBy = txtPlacedOnHoldByGuid.Text;
            pOFormUI.Tbl_UserId_HoldRemovedBy = txtHoldRemovedByGuid.Text;
            pOFormUI.RemainingSubTotal= Convert.ToDecimal(txtRemainingSubTotal.Text);
            pOFormUI.SubTotal =Convert.ToDecimal(txtSubTotal.Text);
            pOFormUI.TradeDiscount = Convert.ToDecimal(txtTradeDiscount.Text);
            pOFormUI.Freight = Convert.ToDecimal(txtFreight.Text);
            pOFormUI.Miscellaneous =Convert.ToDecimal(txtMiscellaneous.Text);
            pOFormUI.Total = Convert.ToDecimal(txtTotal.Text);
            pOFormUI.Tbl_CommentsId = txtCommentsGuid.Text;
            pOFormUI.Version = int.Parse(txtVersion.Text);
            pOFormUI.opt_Status = int.Parse(ddlopt_Status.SelectedValue);

            if (pOFormBAL.AddPO(pOFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_POForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_POForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            pOFormUI.ModifiedBy = SessionContext.UserGuid;
            pOFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            pOFormUI.Tbl_POId = Request.QueryString["POId"];
            pOFormUI.opt_Type = int.Parse(ddlOpt_opt_Type.SelectedValue);
            pOFormUI.PONumber = txtPONumber.Text;
            pOFormUI.Tbl_SupplierId = txtSupplierGuid.Text;
            pOFormUI.Tbl_UserId_Buyer = txtUserId_BuyerGuid.Text;
            pOFormUI.Date = DateTime.Parse(txtDate.Text);
            pOFormUI.Tbl_CurrencyId = txtCurrencyGuid.Text;
            if (chkAllowSales.Checked)
            {
                pOFormUI.AllowSales = true;
            }
            else
            {
                pOFormUI.AllowSales = false;
            }
            pOFormUI.RequisitionDate = DateTime.Parse(txtRequisitionDate.Text);
            pOFormUI.PurchaseOrderDate = DateTime.Parse(txtPurchaseOrderDate.Text);
            pOFormUI.LastEditDate = DateTime.Parse(txtLastEditDate.Text);
            pOFormUI.LastPrintedDate = DateTime.Parse(txtLastPrintedDate.Text);
            pOFormUI.ContractExpirationDate = DateTime.Parse(txtContractExpirationDate.Text);
            pOFormUI.DatePlacedOnHold = DateTime.Parse(txtDatePlacedOnHold.Text);
            pOFormUI.DateHoldRemoved = DateTime.Parse(txtDateHoldRemoved.Text);
            pOFormUI.Tbl_UserId_PlacedOnHoldBy = txtPlacedOnHoldByGuid.Text;
            pOFormUI.Tbl_UserId_HoldRemovedBy = txtHoldRemovedByGuid.Text;
            pOFormUI.RemainingSubTotal = Convert.ToDecimal(txtRemainingSubTotal.Text);
            pOFormUI.SubTotal = Convert.ToDecimal(txtSubTotal.Text);
            pOFormUI.TradeDiscount = Convert.ToDecimal(txtTradeDiscount.Text);
            pOFormUI.Freight = Convert.ToDecimal(txtFreight.Text);
            pOFormUI.Miscellaneous = Convert.ToDecimal(txtMiscellaneous.Text);
            pOFormUI.Total = Convert.ToDecimal(txtTotal.Text);
            pOFormUI.Tbl_CommentsId = txtCommentsGuid.Text;
            pOFormUI.Version = int.Parse(txtVersion.Text);
            pOFormUI.opt_Status = int.Parse(ddlopt_Status.SelectedValue);
            /*
               fields Parameter
               */

            if (pOFormBAL.UpdatePO(pOFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
            }
            else
            {
                divSuccess.Visible = false;
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_POForm.CS";
            logExcpUIobj.RecordId = pOFormUI.Tbl_POId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_POForm : btnUpdate_Click] An error occured in the processing of Record Id : " + pOFormUI.Tbl_POId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            pOFormUI.Tbl_POId = Request.QueryString["POId"];

            if (pOFormBAL.DeletePO(pOFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_POForm.CS";
            logExcpUIobj.RecordId = pOFormUI.Tbl_POId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_POForm : btnDelete_Click] An error occured in the processing of Record Id : " + pOFormUI.Tbl_POId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("POList.aspx");
    }

    #region Currency Search
    protected void btnCurrencySearch_Click(object sender, EventArgs e)
    {
        btnHtmlCurrencySearch.Visible = false;
        btnHtmlCurrencyClose.Visible = true;
        SearchCurrencyList();
    }
    protected void btnClearCurrencySearch_Click(object sender, EventArgs e)
    {
        BindCurrencyList();
        gvCurrencySearch.Visible = true;
        btnHtmlCurrencySearch.Visible = true;
        btnHtmlCurrencyClose.Visible = false;
        txtCurrencySearch.Text = "";
        txtCurrencySearch.Focus();
    }
    protected void btnCurrencyRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindCurrencyList();
    }
    #endregion Currency Search

    #region Comments Search
    protected void btnCommentsSearch_Click(object sender, EventArgs e)
    {
        btnHtmlCommentsSearch.Visible = false;
        btnHtmlCommentsClose.Visible = true;
        SearchCommentsList();
    }
    protected void btnClearCommentsSearch_Click(object sender, EventArgs e)
    {
        BindCommentsList();
        gvCommentsSearch.Visible = true;
        btnHtmlCommentsSearch.Visible = true;
        btnHtmlCommentsClose.Visible = false;
        txtCommentsSearch.Text = "";
        txtCommentsSearch.Focus();
    }
    protected void btnCommentsRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindCommentsList();
    }
    #endregion Comments Search

    #region Supplier Search
    protected void btnSupplierSearch_Click(object sender, EventArgs e)
    {
        btnHtmlSupplierSearch.Visible = false;
        btnHtmlSupplierClose.Visible = true;
        SearchSupplierList();
    }
    protected void btnClearSupplierSearch_Click(object sender, EventArgs e)
    {
        BindSupplierList();
        gvSupplierSearch.Visible = true;
        btnHtmlSupplierSearch.Visible = true;
        btnHtmlSupplierClose.Visible = false;
        txtSupplierSearch.Text = "";
        txtSupplierSearch.Focus();
    }
    protected void btnSupplierRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindSupplierList();
    }
    #endregion Currency Search

    #region User Buyer
    protected void btnUserId_BuyerSearch_Click(object sender, EventArgs e)
    {
        btnHtmlUserId_BuyerSearch.Visible = false;
        btnHtmlUserId_BuyerClose.Visible = true;
        SearchUserId_BuyerList();
    }
    protected void btnClearUserId_BuyerSearch_Click(object sender, EventArgs e)
    {
        BindUserId_BuyerList();
        gvUserId_BuyerSearch.Visible = true;
        btnHtmlUserId_BuyerSearch.Visible = true;
        btnHtmlUserId_BuyerClose.Visible = false;
        txtUserId_BuyerSearch.Text = "";
        txtUserId_BuyerSearch.Focus();
    }
    protected void btnUserId_BuyerRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindUserId_BuyerList();
    }

    #endregion

    #region PlacedOnHoldBy
    protected void btnPlacedOnHoldBySearch_Click(object sender, EventArgs e)
    {
        btnHtmlPlacedOnHoldBySearch.Visible = false;
        btnHtmlPlacedOnHoldByClose.Visible = true;
        SearchPlacedOnHoldByList();
    }
    protected void btnClearPlacedOnHoldBySearch_Click(object sender, EventArgs e)
    {
        BindPlacedOnHoldByList();
        gvPlacedOnHoldBySearch.Visible = true;
        btnHtmlPlacedOnHoldBySearch.Visible = true;
        btnHtmlPlacedOnHoldByClose.Visible = false;
        txtPlacedOnHoldBySearch.Text = "";
        txtPlacedOnHoldBySearch.Focus();
    }
    protected void btnPlacedOnHoldByRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPlacedOnHoldByList();
    }

    #endregion

    #region HoldRemovedBy

    protected void btnHoldRemovedBySearch_Click(object sender, EventArgs e)
    {
        btnHtmlHoldRemovedBySearch.Visible = false;
        btnHtmlHoldRemovedByClose.Visible = true;
        SearchHoldRemovedByList();
    }
    protected void btnClearHoldRemovedBySearch_Click(object sender, EventArgs e)
    {
        BindHoldRemovedByList();
        gvHoldRemovedBySearch.Visible = true;
        btnHtmlHoldRemovedBySearch.Visible = true;
        btnHtmlHoldRemovedByClose.Visible = false;
        txtHoldRemovedBySearch.Text = "";
        txtHoldRemovedBySearch.Focus();
    }
    protected void btnHoldRemovedByRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindHoldRemovedByList();
    }
    #endregion

    #endregion Events

    #region Methods
    private void FillForm(POFormUI pOFormUI)
    {
        try
        {
            DataTable dtb = pOFormBAL.GetPOListById(pOFormUI);

            if (dtb.Rows.Count > 0)
            {
                ddlOpt_opt_Type.SelectedValue = dtb.Rows[0]["Type"].ToString();
                txtPONumber.Text = dtb.Rows[0]["PONumber"].ToString();
                txtSupplier.Text=dtb.Rows[0]["Supplier"].ToString();
                txtSupplierGuid.Text= dtb.Rows[0]["tbl_SupplierId"].ToString();
                txtUserId_BuyerGuid.Text = dtb.Rows[0]["tbl_UserId_Buyer"].ToString();
                txtUserId_Buyer.Text = dtb.Rows[0]["BuyerName"].ToString();
                txtDate.Text = dtb.Rows[0]["Date"].ToString();
                txtCurrency.Text = dtb.Rows[0]["CurrencyName"].ToString();
                txtCurrencyGuid.Text= dtb.Rows[0]["tbl_CurrencyId"].ToString();
                chkAllowSales.Checked = Convert.ToBoolean(dtb.Rows[0]["AllowSales"].ToString());
                txtRequisitionDate.Text= dtb.Rows[0]["RequisitionDate"].ToString();
                txtPurchaseOrderDate.Text = dtb.Rows[0]["PurchaseOrderDate"].ToString();
                txtLastEditDate.Text= dtb.Rows[0]["LastEditDate"].ToString();
                txtLastPrintedDate.Text = dtb.Rows[0]["LastPrintedDate"].ToString();
                txtContractExpirationDate.Text = dtb.Rows[0]["ContractExpirationDate"].ToString();
                txtDatePlacedOnHold.Text = dtb.Rows[0]["DatePlacedOnHold"].ToString();
                txtDateHoldRemoved.Text = dtb.Rows[0]["DateHoldRemoved"].ToString();

                txtPlacedOnHoldByGuid.Text = dtb.Rows[0]["tbl_UserId_PlacedOnHoldBy"].ToString();
                txtPlacedOnHoldBy.Text = dtb.Rows[0]["PlacedOnHoldByName"].ToString();

                txtHoldRemovedByGuid.Text = dtb.Rows[0]["tbl_UserId_HoldRemovedBy"].ToString();
                txtHoldRemovedBy.Text = dtb.Rows[0]["HoldRemovedByName"].ToString();

                txtRemainingSubTotal.Text = dtb.Rows[0]["RemainingSubTotal"].ToString();
                txtSubTotal.Text = dtb.Rows[0]["SubTotal"].ToString();
                txtTradeDiscount.Text = dtb.Rows[0]["TradeDiscount"].ToString();
                txtFreight.Text = dtb.Rows[0]["Freight"].ToString();
                txtMiscellaneous.Text = dtb.Rows[0]["Miscellaneous"].ToString();
                txtTotal.Text = dtb.Rows[0]["Total"].ToString();
                txtComments.Text = dtb.Rows[0]["Comments"].ToString();
                txtCommentsGuid.Text = dtb.Rows[0]["tbl_CommentsId"].ToString();
                txtVersion.Text = dtb.Rows[0]["Version"].ToString();
                ddlopt_Status.SelectedValue = dtb.Rows[0]["Status"].ToString();
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
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_POForm.CS";
            logExcpUIobj.RecordId = pOFormUI.Tbl_POId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_POForm : FillForm] An error occured in the processing of Record Id : " + pOFormUI.Tbl_POId + ". Details : [" + exp.ToString() + "]");
        }
    }


    #region Currency Search
    private void SearchCurrencyList()
    {
        try
        {
            CurrencyListUI currencyListUI = new CurrencyListUI();
            currencyListUI.Search = txtCurrencySearch.Text;
            DataTable dtb = currencyListBAL.GetCurrencyListBySearchParameters(currencyListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCurrencySearch.DataSource = dtb;
                gvCurrencySearch.DataBind();
                divCurrencySearchError.Visible = false;
            }
            else
            {
                divCurrencySearchError.Visible = true;
                lblCurrencySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCurrencySearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchCurrencyList()";
            logExcpUIobj.ResourceName = "Assets_AssetDisposal_AssetDisposalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetDisposal_AssetDisposalForm : SearchCurrencyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindCurrencyList()
    {
        try
        {
            DataTable dtb = currencyListBAL.GetCurrencyList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCurrencySearch.DataSource = dtb;
                gvCurrencySearch.DataBind();
                divCurrencySearchError.Visible = false;

            }
            else
            {
                divCurrencySearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCurrencySearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCurrencyList()";
            logExcpUIobj.ResourceName = "Assets_AssetDisposal_AssetDisposalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetDisposal_AssetDisposalForm : BindCurrencyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Currency Serach

    #region Comments Search
    private void SearchCommentsList()
    {
        try
        {
            CommentsListUI commentsListUI = new CommentsListUI();
            commentsListUI.Search = txtCommentsSearch.Text;
            DataTable dtb = commentsListBAL.GetCommentsListBySearchParameters(commentsListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCommentsSearch.DataSource = dtb;
                gvCommentsSearch.DataBind();
                divCommentsSearchError.Visible = false;
            }
            else
            {
                divCommentsSearchError.Visible = true;
                lblCommentsSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCommentsSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchCommentsList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_POForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_POForm : SearchCommentsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindCommentsList()
    {
        try
        {
            DataTable dtb = commentsListBAL.GetCommentsList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvCommentsSearch.DataSource = dtb;
                gvCommentsSearch.DataBind();
                divCommentsSearchError.Visible = false;

            }
            else
            {
                divCommentsSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvCommentsSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindCommentsList()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_POForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Accounts_Payable_PO_POForm : BindCommentsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Currency Serach
    
    #region Supplier Search
    private void SearchSupplierList()
    {
        try
        {
            SupplierListUI supplierListUI = new SupplierListUI();
            supplierListUI.Search = txtSupplierSearch.Text;
            DataTable dtb = supplierListBAL.GetSupplierListBySearchParameters(supplierListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSupplierSearch.DataSource = dtb;
                gvSupplierSearch.DataBind();
                divSupplierSearchError.Visible = false;
            }
            else
            {
                divSupplierSearchError.Visible = true;
                lblSupplierSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSupplierSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchSupplierList()";
            logExcpUIobj.ResourceName = "Assets_AssetDisposal_AssetDisposalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetDisposal_AssetDisposalForm : SearchSupplierList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindSupplierList()
    {
        try
        {
            DataTable dtb = supplierListBAL.GetSupplierList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvSupplierSearch.DataSource = dtb;
                gvSupplierSearch.DataBind();
                divSupplierSearchError.Visible = false;

            }
            else
            {
                divSupplierSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvSupplierSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindSupplierList()";
            logExcpUIobj.ResourceName = "Assets_AssetDisposal_AssetDisposalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetDisposal_AssetDisposalForm : BindSupplierList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion  Currency Serach

    #region User Buyer
    private void SearchUserId_BuyerList()
    {
        try
        {
            UserListUI userListUI = new UserListUI();
            userListUI.Search = txtUserId_BuyerSearch.Text;
            DataTable dtb = userListBAL.GetUserListBySearchParameters(userListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvUserId_BuyerSearch.DataSource = dtb;
                gvUserId_BuyerSearch.DataBind();
                divUserId_BuyerSearchError.Visible = false;
            }
            else
            {
                divUserId_BuyerSearchError.Visible = true;
                lblUserId_BuyerSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvUserId_BuyerSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchUserId_BuyerList()";
            logExcpUIobj.ResourceName = "Assets_AssetDisposal_AssetDisposalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetDisposal_AssetDisposalForm : SearchUserId_BuyerList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindUserId_BuyerList()
    {
        try
        {
            DataTable dtb = userListBAL.GetUserList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvUserId_BuyerSearch.DataSource = dtb;
                gvUserId_BuyerSearch.DataBind();
                divUserId_BuyerSearchError.Visible = false;

            }
            else
            {
                divUserId_BuyerSearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvUserId_BuyerSearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindUserId_BuyerList()";
            logExcpUIobj.ResourceName = "Assets_AssetDisposal_AssetDisposalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetDisposal_AssetDisposalForm : BindUserId_BuyerList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    #endregion

    #region PlacedOnHoldBy

    private void SearchPlacedOnHoldByList()
    {
        try
        {
            UserListUI userListUI = new UserListUI();
            userListUI.Search = txtPlacedOnHoldBySearch.Text;
            DataTable dtb = userListBAL.GetUserListBySearchParameters(userListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPlacedOnHoldBySearch.DataSource = dtb;
                gvPlacedOnHoldBySearch.DataBind();
                divPlacedOnHoldBySearchError.Visible = false;
            }
            else
            {
                divPlacedOnHoldBySearchError.Visible = true;
                lblPlacedOnHoldBySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPlacedOnHoldBySearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchPlacedOnHoldByList()";
            logExcpUIobj.ResourceName = "Assets_AssetDisposal_AssetDisposalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetDisposal_AssetDisposalForm : SearchCurrencyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindPlacedOnHoldByList()
    {
        try
        {
            DataTable dtb = userListBAL.GetUserList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvPlacedOnHoldBySearch.DataSource = dtb;
                gvPlacedOnHoldBySearch.DataBind();
                divPlacedOnHoldBySearchError.Visible = false;

            }
            else
            {
                divPlacedOnHoldBySearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvPlacedOnHoldBySearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPlacedOnHoldByList()";
            logExcpUIobj.ResourceName = "Assets_AssetDisposal_AssetDisposalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetDisposal_AssetDisposalForm : BindPlacedOnHoldByList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    #endregion

    #region HoldRemovedBy
    private void SearchHoldRemovedByList()
    {
        try
        {
            UserListUI userListUI = new UserListUI();
            userListUI.Search = txtHoldRemovedBySearch.Text;
            DataTable dtb = userListBAL.GetUserListBySearchParameters(userListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvHoldRemovedBySearch.DataSource = dtb;
                gvHoldRemovedBySearch.DataBind();
                divHoldRemovedBySearchError.Visible = false;
            }
            else
            {
                divHoldRemovedBySearchError.Visible = true;
                lblHoldRemovedBySearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvHoldRemovedBySearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchHoldRemovedBy()";
            logExcpUIobj.ResourceName = "Assets_AssetDisposal_AssetDisposalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetDisposal_AssetDisposalForm : SearchHoldRemovedByList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }
    private void BindHoldRemovedByList()
    {
        try
        {
            DataTable dtb = userListBAL.GetUserList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvHoldRemovedBySearch.DataSource = dtb;
                gvHoldRemovedBySearch.DataBind();
                divHoldRemovedBySearchError.Visible = false;

            }
            else
            {
                divHoldRemovedBySearchError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvHoldRemovedBySearch.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindHoldRemovedByList()";
            logExcpUIobj.ResourceName = "Assets_AssetDisposal_AssetDisposalForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Assets_AssetDisposal_AssetDisposalForm : BindHoldRemovedBy] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    #endregion
    private void BindTypeDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_PO";
            optionSetListUI.OptionSetName = "Opt_Type";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {
                ddlOpt_opt_Type.DataSource = dtb;
                ddlOpt_opt_Type.DataBind();
                ddlOpt_opt_Type.DataTextField = "OptionSetLable";
                ddlOpt_opt_Type.DataValueField = "OptionSetValue";
                ddlOpt_opt_Type.DataBind();
            }
            else
            {
                ddlOpt_opt_Type.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindTypeDropDown()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_POForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_PO_POForm : BindTypeDropDown] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void BindStatusDropDown()
    {
        try
        {
            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_PO";
            optionSetListUI.OptionSetName = "Opt_Status";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {
                ddlopt_Status.DataSource = dtb;
                ddlopt_Status.DataBind();
                ddlopt_Status.DataTextField = "OptionSetLable";
                ddlopt_Status.DataValueField = "OptionSetValue";
                ddlopt_Status.DataBind();
            }
            else
            {
                ddlopt_Status.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindStatusDropDown()";
            logExcpUIobj.ResourceName = "Finance_Accounts_Payable_PO_POForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Accounts_Payable_PO_POForm : BindStatusDropDown] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }
    
    #endregion Methods
}
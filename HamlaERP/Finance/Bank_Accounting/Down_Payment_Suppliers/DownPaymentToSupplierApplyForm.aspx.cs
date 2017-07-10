using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;
public partial class Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm : System.Web.UI.Page
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    DownPaymentToSupplierApplyFormBAL downPaymentToSupplierApplyFormBAL = new DownPaymentToSupplierApplyFormBAL();
    DownPaymentToSupplierApplyFormUI downPaymentToSupplierApplyFormUI = new DownPaymentToSupplierApplyFormUI();
   
    DownPaymentToSupplierListBAL downPaymentToSupplierListBAL = new DownPaymentToSupplierListBAL();
    DownPaymentToSupplierApplyListUI downPaymentToSupplierApplyListUI = new DownPaymentToSupplierApplyListUI();
    DownPaymentToSupplierApplyListBAL downPaymentToSupplierApplyListBAL = new DownPaymentToSupplierApplyListBAL();
    NonPOBasedInvoiceListBAL nonPOBasedInvoiceListBAL = new NonPOBasedInvoiceListBAL();
    POBasedInvoiceListBAL pOBasedInvoiceListBAL = new POBasedInvoiceListBAL();
    OptionSetListBAL optionSetListBAL = new OptionSetListBAL();
   
    #endregion Data Members
   
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {     

        if (!Page.IsPostBack)
        {

            if (Request.QueryString["DownPaymentToSupplierId"] != null)
            {
                downPaymentToSupplierApplyListUI.Tbl_DownPaymentToSupplierId = Request.QueryString["DownPaymentToSupplierId"];
                BindDownPaymentToSupplierApply(downPaymentToSupplierApplyListUI);
                BindTypeDropDownList();
            }
         
           else if (Request.QueryString["DownPaymentToSupplierApplyId"] != null)
            {
                downPaymentToSupplierApplyFormUI.Tbl_DownPaymentToSupplierApplyId = Request.QueryString["DownPaymentToSupplierApplyId"];
                BindTypeDropDownList();
                FillForm(downPaymentToSupplierApplyFormUI);

                divNonPOBasedInvoice.Visible = false;
                divPOBasedInvoice.Visible = false;
                if (rdbNonPOBasedInvoiceId.Checked)
                    divNonPOBasedInvoice.Visible = true;
                else if (rdbPOBasedInvoiceId.Checked)
                    divPOBasedInvoice.Visible = true;

                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Down Payment To Supplier Apply";
            }
            else
            {

                BindTypeDropDownList();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Down Payment To Supplier Apply";
            }
                       
        }

    }
    protected void rdbNonPOBasedInvoiceId_CheckedChanged(object sender, EventArgs e)
    {
        
        divNonPOBasedInvoice.Visible = true;
        divPOBasedInvoice.Visible = false;
    }

    protected void rdbPOBasedInvoiceId_CheckedChanged(object sender, EventArgs e)
    {
        divPOBasedInvoice.Visible = true;
        divNonPOBasedInvoice.Visible = false;

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int applyToDocumentTypeNonPOBaseInvoice = 1;
        int applyToDocumentTypePOBaseInvoice = 2;
        try
        {
            downPaymentToSupplierApplyFormUI.CreatedBy = SessionContext.UserGuid;
            downPaymentToSupplierApplyFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            downPaymentToSupplierApplyFormUI.Tbl_DownPaymentToSupplierId =txtDownPaymentToSupplierGuid.Text;
            if (rdbNonPOBasedInvoiceId.Checked)
            {
                downPaymentToSupplierApplyFormUI.Tbl_ApplyToDocument = txtApplyToDocumentNonPOBasedInvoiceGuid.Text;
                downPaymentToSupplierApplyFormUI.opt_ApplyToDocumentType = applyToDocumentTypeNonPOBaseInvoice;
            }
            else if (rdbPOBasedInvoiceId.Checked)
            {
                downPaymentToSupplierApplyFormUI.Tbl_ApplyToDocument = txtApplyToDocumentPOBasedInvoiceGuid.Text;
                downPaymentToSupplierApplyFormUI.opt_ApplyToDocumentType = applyToDocumentTypePOBaseInvoice;
            }
            
            downPaymentToSupplierApplyFormUI.opt_Type = int.Parse(ddloptType.SelectedValue.ToString());
            downPaymentToSupplierApplyFormUI.DueDate=DateTime.Parse(txtDueDate.Text.ToString());
            downPaymentToSupplierApplyFormUI.RemainingAmount = Convert.ToDecimal(txtRemainingAmount.Text);
            downPaymentToSupplierApplyFormUI.ApplyAmount = Decimal.Parse(txtApplyAmount.Text);
            downPaymentToSupplierApplyFormUI.OrignalDocumentAmount = Convert.ToDecimal(txtOrignalDocumentAmount.Text);
            downPaymentToSupplierApplyFormUI.DiscountDate = DateTime.Parse(txtDiscountDate.Text);
            if (downPaymentToSupplierApplyFormBAL.AddDownPaymentToSupplierApply(downPaymentToSupplierApplyFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int applyToDocumentTypeNonPOBaseInvoice = 1;
        int applyToDocumentTypePOBaseInvoice = 2;
        DownPaymentToSupplierApplyFormUI downPaymentToSupplierApplyFormUI = new DownPaymentToSupplierApplyFormUI();
        try
        {
            downPaymentToSupplierApplyFormUI.ModifiedBy = SessionContext.UserGuid;
            downPaymentToSupplierApplyFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            downPaymentToSupplierApplyFormUI.Tbl_DownPaymentToSupplierId = txtDownPaymentToSupplierGuid.Text;

            if (rdbNonPOBasedInvoiceId.Checked)
            {
                downPaymentToSupplierApplyFormUI.Tbl_ApplyToDocument = txtApplyToDocumentNonPOBasedInvoiceGuid.Text;
                downPaymentToSupplierApplyFormUI.opt_ApplyToDocumentType = applyToDocumentTypeNonPOBaseInvoice;
            }
            else if (rdbPOBasedInvoiceId.Checked)
            {
                downPaymentToSupplierApplyFormUI.Tbl_ApplyToDocument = txtApplyToDocumentPOBasedInvoiceGuid.Text;
                downPaymentToSupplierApplyFormUI.opt_ApplyToDocumentType = applyToDocumentTypePOBaseInvoice;
            }

            downPaymentToSupplierApplyFormUI.opt_Type = int.Parse(ddloptType.SelectedValue.ToString());
            downPaymentToSupplierApplyFormUI.DueDate = DateTime.Parse(txtDueDate.Text.ToString());
            downPaymentToSupplierApplyFormUI.RemainingAmount = Convert.ToDecimal(txtRemainingAmount.Text);
            downPaymentToSupplierApplyFormUI.ApplyAmount = Decimal.Parse(txtApplyAmount.Text);
            downPaymentToSupplierApplyFormUI.OrignalDocumentAmount = Convert.ToDecimal(txtOrignalDocumentAmount.Text);
            downPaymentToSupplierApplyFormUI.DiscountDate = DateTime.Parse(txtDiscountDate.Text);
            downPaymentToSupplierApplyFormUI.Tbl_DownPaymentToSupplierApplyId = Request.QueryString["DownPaymentToSupplierApplyId"];
            if (downPaymentToSupplierApplyFormBAL.UpdateDownPaymentToSupplierApply(downPaymentToSupplierApplyFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm : btnUpdate_Click] An error occured in the processing of Record Id : " + downPaymentToSupplierApplyFormUI.Tbl_DownPaymentToSupplierApplyId + ".  Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            downPaymentToSupplierApplyFormUI.Tbl_DownPaymentToSupplierApplyId = Request.QueryString["DownPaymentToSupplierApplyId"];
            if (downPaymentToSupplierApplyFormBAL.DeleteDownPaymentToSupplierApply(downPaymentToSupplierApplyFormUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = downPaymentToSupplierApplyFormUI.Tbl_DownPaymentToSupplierApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm : btnDelete_Click] An error occured in the processing of Record Id : " + downPaymentToSupplierApplyFormUI.Tbl_DownPaymentToSupplierApplyId + ". Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("DownPaymentToSupplierApplyList.aspx");
    }

    #region DownPaymentToSupplier Search
    protected void btnDownPaymentToSupplierSearch_Click(object sender, EventArgs e)
    {
        btnHtmlDownPaymentToSupplierSearch.Visible = false;
        btnHtmlDownPaymentToSupplierClose.Visible = true;
        SearchDownPaymentToSupplierList();
    }

    protected void btnClearDownPaymentToSupplierSearch_Click(object sender, EventArgs e)
    {
        BindDownPaymentToSupplierSearchList();
        gvDownPaymentToSupplierSearch.Visible = true;
        btnHtmlDownPaymentToSupplierSearch.Visible = true;
        btnHtmlDownPaymentToSupplierClose.Visible = false;
        txtDownPaymentToSupplierSearch.Text = "";
        txtDownPaymentToSupplierSearch.Focus();
    }
    protected void btnDownPaymentToSupplierRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindDownPaymentToSupplierSearchList();
    }
    #endregion DownPaymentToSupplier Search

    #region NonPOBasedInvoiceSearch
    protected void btnApplyToDocumentNonPOBasedInvoiceSearch_Click(object sender, EventArgs e)
    {
        btnApplyToDocumentNonPOBasedInvoiceSearch.Visible = false;
        btnHtmlApplyToDocumentNonPOBasedInvoiceClose.Visible = true;
        SearchNonPOBasedInvoiceList();
    }

    protected void btnClearApplyToDocumentNonPOBasedInvoiceSearch_Click(object sender, EventArgs e)
    {
       BindNonPOBasedInvoiceSearchList();
       gvApplyToDocumentNonPOBasedInvoiceSearch.Visible = true;
       btnHtmlApplyToDocumentNonPOBasedInvoiceSearch.Visible = true;
       btnHtmlApplyToDocumentNonPOBasedInvoiceClose.Visible = false;
       txtApplyToDocumentNonPOBasedInvoiceSearch.Text = "";
       txtApplyToDocumentNonPOBasedInvoiceSearch.Focus();
    }
    protected void btnApplyToDocumentNonPOBasedInvoiceRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindNonPOBasedInvoiceSearchList();
    }
    #endregion NonPOBasedInvoiceSearch

    #region POBasedInvoiceSearch
    protected void btnApplyToDocumentPOBasedInvoiceSearch_Click(object sender, EventArgs e)
    {
        btnApplyToDocumentPOBasedInvoiceSearch.Visible = false;
        btnHtmlApplyToDocumentPOBasedInvoiceClose.Visible = true;
        SearchPOBasedInvoiceList();
    }

    protected void btnClearApplyToDocumentPOBasedInvoiceSearch_Click(object sender, EventArgs e)
    {
        BindPOBasedInvoiceSearchList();
        gvApplyToDocumentPOBasedInvoiceSearch.Visible = true;
        btnHtmlApplyToDocumentPOBasedInvoiceSearch.Visible = true;
        btnHtmlApplyToDocumentPOBasedInvoiceClose.Visible = false;
        txtApplyToDocumentPOBasedInvoiceSearch.Text = "";
        txtApplyToDocumentPOBasedInvoiceSearch.Focus();
    }
    protected void btnApplyToDocumentPOBasedInvoiceRefresh_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        BindPOBasedInvoiceSearchList();
    }
    #endregion POBasedInvoiceSearch
    #endregion Events

    #region Methods

    public void BindDownPaymentToSupplierApply(DownPaymentToSupplierApplyListUI downPaymentToSupplierApplyListUI)
    {

        try
        {
            DataTable dtb = downPaymentToSupplierApplyListBAL.GetDownPaymentToSupplierApplyListByDownPaymentToSupplierId(downPaymentToSupplierApplyListUI);
            {
                if (dtb.Rows.Count > 0)
                {
                    txtDownPaymentToSupplier.Text = dtb.Rows[0]["tbl_DownPaymentToSupplier"].ToString();
                    txtDownPaymentToSupplierGuid.Text= dtb.Rows[0]["tbl_DownPaymentToSupplierId"].ToString();
                    txtSupplierId.Text = dtb.Rows[0]["tbl_Supplier"].ToString();
                    txtSupplierName.Text = dtb.Rows[0]["tbl_Supplier"].ToString();
                    txtType.Text = dtb.Rows[0]["DocumentType"].ToString();
                    txtCurrencyID.Text = dtb.Rows[0]["CurrencyName"].ToString();
                    txtDocumentNumber.Text = dtb.Rows[0]["DocumentNumber"].ToString();
                    txtOrignalAmount.Text = dtb.Rows[0]["Total"].ToString();
                    txtApplydate.Text = dtb.Rows[0]["ApplyDate"].ToString();
                    txtUnappliedAmount.Text = dtb.Rows[0]["Total"].ToString();

                    gvData.DataSource = dtb;
                    gvData.DataBind();
                    divError.Visible = false;
                    gvData.Visible = true;

                }
                else
                {
                    gvData.Visible = false;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearFormAppy();", true);
                }
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "txtDownPaymentcust_TextChanged()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = downPaymentToSupplierApplyFormUI.Tbl_DownPaymentToSupplierApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm : txtDownPaymentcust_TextChanged] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void FillForm(DownPaymentToSupplierApplyFormUI downPaymentToSupplierApplyFormUI)
    {
        try
        {
            DataTable dtb = downPaymentToSupplierApplyFormBAL.GetDownPaymentToSupplierApplyListById(downPaymentToSupplierApplyFormUI);
            if (dtb.Rows.Count > 0)
            {
                txtDownPaymentToSupplierGuid.Text= dtb.Rows[0]["tbl_DownPaymentToSupplierId"].ToString();
                txtDownPaymentToSupplier.Text= dtb.Rows[0]["tbl_DownPaymentToSupplier"].ToString();
                if (int.Parse(dtb.Rows[0]["opt_ApplyToDocumentType"].ToString()) == 1)
                {
                    rdbNonPOBasedInvoiceId.Checked = true;
                    txtApplyToDocumentNonPOBasedInvoice.Text = dtb.Rows[0]["PONumberNPOBI"].ToString();
                    txtApplyToDocumentNonPOBasedInvoiceGuid.Text = dtb.Rows[0]["tbl_ApplyToDocument"].ToString();
                }
                else if (int.Parse(dtb.Rows[0]["opt_ApplyToDocumentType"].ToString()) == 2)
                {
                    rdbPOBasedInvoiceId.Checked = true;
                    txtApplyToDocumentPOBasedInvoice.Text= dtb.Rows[0]["PONumberPOBI"].ToString();
                    txtApplyToDocumentPOBasedInvoiceGuid.Text = dtb.Rows[0]["tbl_ApplyToDocument"].ToString();
                }
                txtDueDate.Text= dtb.Rows[0]["DueDate"].ToString();
                txtRemainingAmount.Text= dtb.Rows[0]["RemainingAmount"].ToString();
                txtApplyAmount.Text= dtb.Rows[0]["ApplyAmount"].ToString();
                ddloptType.SelectedValue = dtb.Rows[0]["Type"].ToString();
                txtOrignalDocumentAmount.Text= dtb.Rows[0]["OrignalDocumentAmount"].ToString();
                txtDiscountDate.Text= dtb.Rows[0]["DiscountDate"].ToString();
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = downPaymentToSupplierApplyFormUI.Tbl_DownPaymentToSupplierApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void BindTypeDropDownList()
    {
        try
        {

            OptionSetListUI optionSetListUI = new OptionSetListUI();
            optionSetListUI.TableName = "tbl_DownPaymentFromCustomerApply";
            optionSetListUI.OptionSetName = "opt_Type";
            DataTable dtb = optionSetListBAL.GetOptionSetListByOptionSetName(optionSetListUI);
            if (dtb.Rows.Count > 0)
            {

                ddloptType.DataSource = dtb;
                ddloptType.DataBind();
                ddloptType.DataTextField = "OptionSetLable";
                ddloptType.DataValueField = "OptionSetValue";
                ddloptType.DataBind();
            }
            else
            {
                ddloptType.Items.Insert(0, new ListItem(Resources.GlobalResource.msgNoRecordFound, "00000000-0000-0000-0000-000000000001"));
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindTypeDropDownList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm : BindTypeDropDownList] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
  
    #region DownPaymentToSupplier Search
    private void SearchDownPaymentToSupplierList()
    {

        try
        {
            DownPaymentToSupplierListUI DownPaymentToSupplierListUI = new DownPaymentToSupplierListUI();
            DownPaymentToSupplierListUI.Search = txtDownPaymentToSupplierSearch.Text;


            DataTable dtb = downPaymentToSupplierListBAL.GetDownPaymentToSupplierListBySearchParameters(DownPaymentToSupplierListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvDownPaymentToSupplierSearch.DataSource = dtb;
                gvDownPaymentToSupplierSearch.DataBind();
                divDownPaymentToSupplierSearchError.Visible = false;
            }
            else
            {
                divDownPaymentToSupplierSearchError.Visible = true;
                lblDownPaymentToSupplierSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvDownPaymentToSupplierSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchDownPaymentToSupplierList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm : SearchDownPaymentToSupplierList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindDownPaymentToSupplierSearchList()
    {
        try
        {
            DataTable dtb = downPaymentToSupplierListBAL.GetDownPaymentToSupplierList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvDownPaymentToSupplierSearch.DataSource = dtb;
                gvDownPaymentToSupplierSearch.DataBind();
                divError.Visible = false;
                gvDownPaymentToSupplierSearch.Visible = true;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvDownPaymentToSupplierSearch.Visible = false;
            }

            txtDownPaymentToSupplierSearch.Text = "";
            txtDownPaymentToSupplierSearch.Focus();
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindDownPaymentToSupplierSearchList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm : BindDownPaymentToSupplierSearchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion DownPaymentToSupplier Search

    #region NonPOBasedInvoice Search
    private void SearchNonPOBasedInvoiceList()
    {

        try
        {
            NonPOBasedInvoiceListUI nonPOBasedInvoiceListUI = new NonPOBasedInvoiceListUI();
            nonPOBasedInvoiceListUI.Search = txtApplyToDocumentNonPOBasedInvoiceSearch.Text;


            DataTable dtb = nonPOBasedInvoiceListBAL.GetNonPOBasedInvoiceListBySearchParameters(nonPOBasedInvoiceListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvApplyToDocumentNonPOBasedInvoiceSearch.DataSource = dtb;
                gvApplyToDocumentNonPOBasedInvoiceSearch.DataBind();
                divApplyToDocumentNonPOBasedInvoiceSearchError.Visible = false;
            }
            else
            {
               divApplyToDocumentNonPOBasedInvoiceSearchError.Visible = true;
               lblApplyToDocumentNonPOBasedInvoiceSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
               gvApplyToDocumentNonPOBasedInvoiceSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchNonPOBasedInvoiceList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm : SearchNonPOBasedInvoiceList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindNonPOBasedInvoiceSearchList()
    {
        try
        {
            DataTable dtb = nonPOBasedInvoiceListBAL.GetNonPOBasedInvoiceList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
               gvApplyToDocumentNonPOBasedInvoiceSearch.DataSource = dtb;
               gvApplyToDocumentNonPOBasedInvoiceSearch.DataBind();
               divError.Visible = false;
               gvApplyToDocumentNonPOBasedInvoiceSearch.Visible = true;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvApplyToDocumentNonPOBasedInvoiceSearch.Visible = false;
            }

           txtApplyToDocumentNonPOBasedInvoiceSearch.Text = "";
           txtApplyToDocumentNonPOBasedInvoiceSearch.Focus();
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindNonPOBasedInvoiceSearchList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm : BindNonPOBasedInvoiceSearchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion NonPOBasedInvoice Search

    #region POBasedInvoice Search
    private void SearchPOBasedInvoiceList()
    {

        try
        {
            POBasedInvoiceListUI POBasedInvoiceListUI = new POBasedInvoiceListUI();
            POBasedInvoiceListUI.Search = txtApplyToDocumentPOBasedInvoiceSearch.Text;


            DataTable dtb = pOBasedInvoiceListBAL.GetPOBasedInvoiceListBySearchParameters(POBasedInvoiceListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvApplyToDocumentPOBasedInvoiceSearch.DataSource = dtb;
                gvApplyToDocumentPOBasedInvoiceSearch.DataBind();
                divApplyToDocumentPOBasedInvoiceSearchError.Visible = false;
            }
            else
            {
                divApplyToDocumentPOBasedInvoiceSearchError.Visible = true;
                lblApplyToDocumentPOBasedInvoiceSearchError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvApplyToDocumentPOBasedInvoiceSearch.Visible = false;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SearchPOBasedInvoiceList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm : SearchPOBasedInvoiceList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    private void BindPOBasedInvoiceSearchList()
    {
        try
        {
            DataTable dtb = pOBasedInvoiceListBAL.GetPOBasedInvoiceList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvApplyToDocumentPOBasedInvoiceSearch.DataSource = dtb;
                gvApplyToDocumentPOBasedInvoiceSearch.DataBind();
                divError.Visible = false;
                gvApplyToDocumentPOBasedInvoiceSearch.Visible = true;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvApplyToDocumentPOBasedInvoiceSearch.Visible = false;
            }

            txtApplyToDocumentPOBasedInvoiceSearch.Text = "";
            txtApplyToDocumentPOBasedInvoiceSearch.Focus();
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindPOBasedInvoiceSearchList()";
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm : BindPOBasedInvoiceSearchList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion POBasedInvoice Search
    #endregion Methods



}
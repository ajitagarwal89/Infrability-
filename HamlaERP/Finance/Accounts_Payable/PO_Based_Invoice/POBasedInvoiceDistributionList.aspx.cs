using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDistributionList : System.Web.UI.Page
{
    #region Data Members

    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    POBasedInvoiceDistributionListBAL pOBasedInvoiceDistributionListBAL = new POBasedInvoiceDistributionListBAL();
    POBasedInvoiceDistributionListUI pOBasedInvoiceDistributionListUI = new POBasedInvoiceDistributionListUI();

    #endregion Data Members
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            BindList();
        }

    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("POBasedInvoiceDistributionForm.aspx");
    }
    protected void gvColLnkBtn_Click(object sender, EventArgs e)
    {
        string pOBasedInvoiceDistributionId = (sender as LinkButton).CommandArgument;
        Response.Redirect("POBasedInvoiceDistributionForm.aspx?POBasedInvoiceDistributionId=" + pOBasedInvoiceDistributionId);
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        CheckBox ch;
        try
        {
            for (int i = 0; i < gvData.Items.Count; i++)
            {
                ch = (CheckBox)gvData.Items[i].Cells[0].FindControl("chkRow");
                if (ch.Checked == true)
                {

                    pOBasedInvoiceDistributionListUI.Tbl_POBasedInvoiceDistributionId = gvData.Items[i].Cells[1].Text;

                    if (pOBasedInvoiceDistributionListBAL.DeletePOBasedInvoiceDistribution(pOBasedInvoiceDistributionListUI) == 1)
                    {
                        divSuccess.Visible = true;
                        divError.Visible = false;
                        lblSuccess.Text = Resources.GlobalResource.msgRecordDeleteSuccessfully;
                    }
                    else
                    {
                        divError.Visible = true;
                        divSuccess.Visible = false;
                        lblError.Text = Resources.GlobalResource.msgCouldNotDeleteRecord;
                    }

                }
            }
            BindList();
        }
        catch (Exception exp)
        {

            logExcpUIobj.MethodName = "btnDelete_Click()";
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_POBasedInvoiceDistributionList.CS";
            logExcpUIobj.RecordId = pOBasedInvoiceDistributionListUI.Tbl_POBasedInvoiceDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_POBasedInvoiceDistributionList : btnDelete_Click] An error occured in the processing of Record Id : " + pOBasedInvoiceDistributionListUI.Tbl_POBasedInvoiceDistributionId + ". Details : [" + exp.ToString() + "]");

        }

    }
    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtb = new DataTable();
            dtb = pOBasedInvoiceDistributionListBAL.GetPOBasedInvoiceDistributionListForExportToExcel();
            string exportedFileName = "POBasedInvoiceDistribution_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            Response.Clear();
            Response.Charset = "";
            Response.ContentType = "application/ms-excel";
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", exportedFileName));
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
            System.Web.UI.WebControls.DataGrid dg = new System.Web.UI.WebControls.DataGrid();
            dg.AllowPaging = false;
            dg.HeaderStyle.BackColor = System.Drawing.Color.RoyalBlue;
            dg.HeaderStyle.ForeColor = System.Drawing.Color.White;
            dg.DataSource = dtb;
            dg.DataBind();
            dg.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "lnkExportToExcel_Click()";
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_POBasedInvoiceDistributionList.CS";
            logExcpUIobj.RecordId = "Export To excel";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_POBasedInvoiceDistributionList : lnkExportToExcel_Click] An error occured in the processing of Records. Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnMainSearch_Click(object sender, EventArgs e)
    {
        btnHtmlSearch.Visible = false;
        btnHtmlClose.Visible = true;

        pOBasedInvoiceDistributionListUI.Search = txtSearch.Text;
        BindListBySearchParameters(pOBasedInvoiceDistributionListUI);
    }
    protected void btnClearMainSearch_Click(object sender, EventArgs e)
    {
        BindList();
        btnHtmlSearch.Visible = true;
        btnHtmlClose.Visible = false;
        txtSearch.Text = "";
        txtSearch.Focus();
    }

    #endregion Events

    #region Methods
    private void BindList()
    {
        try
        {
            DataTable dtb = pOBasedInvoiceDistributionListBAL.GetPOBasedInvoiceDistributionList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvData.DataSource = dtb;
                gvData.DataBind();
                divError.Visible = false;
                gvData.Visible = true;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvData.Visible = false;
            }
            txtSearch.Text = "";
            txtSearch.Focus();
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_POBasedInvoiceDistributionList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_POBasedInvoiceDistributionList : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    private void BindListBySearchParameters(POBasedInvoiceDistributionListUI pOBasedInvoiceDistributionListUI)
    {
        try
        {
            DataTable dtb = pOBasedInvoiceDistributionListBAL.GetPOBasedInvoiceDistributionListBySearchParameters(this.pOBasedInvoiceDistributionListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvData.DataSource = dtb;
                gvData.DataBind();
                divError.Visible = false;
                gvData.Visible = true;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvData.Visible = false;
            }
            txtSearch.Text = "";
            txtSearch.Focus();

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindListBySearchParameters()";
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_POBasedInvoiceDistributionList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_POBasedInvoiceDistributionList : BindListBySearchParameters] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    #endregion Methods


}
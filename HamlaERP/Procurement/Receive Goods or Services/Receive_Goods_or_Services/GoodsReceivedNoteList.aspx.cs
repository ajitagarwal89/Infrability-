using System;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteList : System.Web.UI.Page
{
    #region Data Members

    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    GoodsReceivedNoteListBAL goodsReceivedNoteListBAL = new GoodsReceivedNoteListBAL();
    GoodsReceivedNoteListUI goodsReceivedNoteListUI = new GoodsReceivedNoteListUI();

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
        Response.Redirect("GoodsReceivedNoteForm.aspx");
    }
    protected void gvColLnkBtn_Click(object sender, EventArgs e)
    {
        string goodsReceivedNoteId = (sender as LinkButton).CommandArgument;
        Response.Redirect("GoodsReceivedNoteForm.aspx?GoodsReceivedNoteId=" + goodsReceivedNoteId);
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

                    goodsReceivedNoteListUI.Tbl_GoodsReceivedNoteId = gvData.Items[i].Cells[1].Text;

                    if (goodsReceivedNoteListBAL.DeleteGoodsReceivedNote(goodsReceivedNoteListUI) == 1)
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
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteList.CS";
            logExcpUIobj.RecordId = goodsReceivedNoteListUI.Tbl_GoodsReceivedNoteId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteList : btnDelete_Click] An error occured in the processing of Record Id : " + goodsReceivedNoteListUI.Tbl_GoodsReceivedNoteId + ". Details : [" + exp.ToString() + "]");

        }

    }
    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtb = new DataTable();
            dtb = goodsReceivedNoteListBAL.GetGoodsReceivedNoteListForExportToExcel();
            string exportedFileName = "GoodsReceivedNote_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
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
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteList.CS";
            logExcpUIobj.RecordId = "Export To excel";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteList : lnkExportToExcel_Click] An error occured in the processing of Records. Details : [" + exp.ToString() + "]");
        }
    }
    protected void btnMainSearch_Click(object sender, EventArgs e)
    {
        btnHtmlSearch.Visible = false;
        btnHtmlClose.Visible = true;

        goodsReceivedNoteListUI.Search = txtSearch.Text;
        BindListBySearchParameters(goodsReceivedNoteListUI);
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
            DataTable dtb = goodsReceivedNoteListBAL.GetGoodsReceivedNoteList();
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
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteList : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    private void BindListBySearchParameters(GoodsReceivedNoteListUI goodsReceivedNoteListUI)
    {
        try
        {
            DataTable dtb = goodsReceivedNoteListBAL.GetGoodsReceivedNoteListBySearchParameters(this.goodsReceivedNoteListUI);
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
            logExcpUIobj.ResourceName = "Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteList : BindListBySearchParameters] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    #endregion Methods

}
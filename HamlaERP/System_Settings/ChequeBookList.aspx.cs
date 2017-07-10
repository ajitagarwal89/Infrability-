using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_ChequeBookList : PageBase
{
    #region Data Members
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

  
    ChequeBookListBAL chequeBookListBAL = new ChequeBookListBAL();
    ChequeBookListUI chequeBookListUI = new ChequeBookListUI();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
        //base.Page_Load(sender, e);
        if (!this.IsPostBack)
        {
            BindList();
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChequeBookForm.aspx");
    }

    protected void gvColLnkBtn_Click(object sender, EventArgs e)
    {
        string chequeBookId = (sender as LinkButton).CommandArgument;
        Response.Redirect("ChequeBookForm.aspx?ChequeBookId=" + chequeBookId);
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

                    chequeBookListUI.Tbl_ChequeBookId = gvData.Items[i].Cells[1].Text;

                    if (chequeBookListBAL.DeleteChequeBook(chequeBookListUI) == 1)
                    {
                        divSuccess.Visible = true;
                        lblSuccess.Text = Resources.GlobalResource.msgRecordDeleteSuccessfully;
                    }
                    else
                    {
                        divError.Visible = true;
                        lblError.Text = Resources.GlobalResource.msgCouldNotDeleteRecord;
                    }

                }
            }
            BindList();
        }
        catch (Exception exp)
                {
                    logExcpUIobj.MethodName = "btnDelete_Click()";
                    logExcpUIobj.ResourceName = "System_Settings_ChequeBookList.CS";
                    logExcpUIobj.RecordId = chequeBookListUI.Tbl_ChequeBookId;
                    logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                    logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                    log.Error("[System_Settings_ChequeBookList : btnDelete_Click] An error occured in the processing of Record Id : " + chequeBookListUI.Tbl_ChequeBookId + ". Details : [" + exp.ToString() + "]");
                }           
    }

    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtb = new DataTable();
            dtb = chequeBookListBAL.GetChequeBookListForExportToExcel();

            string exportedFileName = "ChequeBook_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
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
            logExcpUIobj.ResourceName = "System_Settings_ChequeBookList.CS";
            logExcpUIobj.RecordId = "Export To excel";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ChequeBookList : lnkExportToExcel_Click] An error occured in the processing of Records. Details : [" + exp.ToString() + "]");
        }
    }

    #region Main Search
    protected void btnMainSearch_Click(object sender, EventArgs e)
    {
        btnHtmlSearch.Visible = false;
        btnHtmlClose.Visible = true;
        chequeBookListUI.Search = txtSearch.Text;
        BindChequeBookListBySearchParameters(chequeBookListUI);
    }



    protected void btnClearMainSearch_Click(object sender, EventArgs e)
    {
        BindList();
        gvData.Visible = true;
        btnHtmlSearch.Visible = true;
        btnHtmlClose.Visible = false;
        txtSearch.Text = "";
        txtSearch.Focus();
    }

    #endregion
    #endregion Events

    #region Methods

    private void BindList()
    {
        try
        {
            DataTable dtb = chequeBookListBAL.GetChequeBookList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvData.DataSource = dtb;
                gvData.DataBind();
                divError.Visible = false;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvData.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindList()";
            logExcpUIobj.ResourceName = "System_Settings_ChequeBookList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ChequeBookList : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    private void BindChequeBookListBySearchParameters(ChequeBookListUI chequeBookListUI)
    {
        try
        {
            DataTable dtb = chequeBookListBAL.GetChequeBookListBySearchParameters(chequeBookListUI);

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                gvData.DataSource = dtb;
                gvData.DataBind();
                divError.Visible = false;
            }
            else
            {
                divError.Visible = true;
                lblError.Text = Resources.GlobalResource.msgNoRecordFound;
                gvData.Visible = false;
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindChequeBookListBySearchParameters()";
            logExcpUIobj.ResourceName = "System_Settings_ChequeBookList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ChequeBookList : BindChequeBookListBySearchParameters] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods
}
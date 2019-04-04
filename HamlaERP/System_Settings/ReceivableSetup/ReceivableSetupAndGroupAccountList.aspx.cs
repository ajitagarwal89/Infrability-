using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;
public partial class System_Settings_ReceivableSetupAndGroupAccountList : PageBase
{
    #region Data Members
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    ReceivableSetupAndGroupAccountListBAL receivableSetupAndGroupAccountListBAL = new ReceivableSetupAndGroupAccountListBAL();
    ReceivableSetupAndGroupAccountListUI receivableSetupAndGroupAccountListUI = new ReceivableSetupAndGroupAccountListUI();
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {

        if (!this.IsPostBack)
        {
            BindList();
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReceivableSetupAndGroupAccountForm.aspx");
    }

    protected void gvColLnkBtn_Click(object sender, EventArgs e)
    {
        string receivableSetupAndGroupAccountId = (sender as LinkButton).CommandArgument;
        Response.Redirect("ReceivableSetupAndGroupAccountForm.aspx?ReceivableSetupAndGroupAccountId=" + receivableSetupAndGroupAccountId);
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

                    receivableSetupAndGroupAccountListUI.Tbl_ReceivableSetupAndGroupAccountId = gvData.Items[i].Cells[1].Text;

                    if (receivableSetupAndGroupAccountListBAL.DeleteReceivableSetupAndGroupAccount(receivableSetupAndGroupAccountListUI) == 1)
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
            logExcpUIobj.ResourceName = "System_Settings_ReceivableSetupAndGroupAccountList.CS";
            logExcpUIobj.RecordId = receivableSetupAndGroupAccountListUI.Tbl_ReceivableSetupAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableSetupAndGroupAccountList : btnDelete_Click] An error occured in the processing of Record Id : " + receivableSetupAndGroupAccountListUI.Tbl_ReceivableSetupAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtb = new DataTable();
            dtb = receivableSetupAndGroupAccountListBAL.GetReceivableSetupAndGroupAccountListForExportToExcel();

            string exportedFileName = "ReceivableSetupAndGroupAccount_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
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
            logExcpUIobj.ResourceName = "System_Settings_ReceivableSetupAndGroupAccountList.CS";
            logExcpUIobj.RecordId = "Export To excel";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableSetupAndGroupAccountList : lnkExportToExcel_Click] An error occured in the processing of Records. Details : [" + exp.ToString() + "]");
        }
    }

    #region Main Search

    protected void btnMainSearch_Click(object sender, EventArgs e)
    {
        btnHtmlSearch.Visible = false;
        btnHtmlClose.Visible = true;
        receivableSetupAndGroupAccountListUI.Search = txtSearch.Text;
        BindReceivableSetupAndGroupAccountListBySearchParameters(receivableSetupAndGroupAccountListUI);
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

    #endregion Main Search

    #endregion Events

    #region Methods

    private void BindList()
    {
        try
        {
            DataTable dtb = receivableSetupAndGroupAccountListBAL.GetReceivableSetupAndGroupAccountList();

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
            logExcpUIobj.ResourceName = "System_Settings_ReceivableSetupAndGroupAccountList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableSetupAndGroupAccountList : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }


    private void BindReceivableSetupAndGroupAccountListBySearchParameters(ReceivableSetupAndGroupAccountListUI receivableSetupAndGroupAccountListUI)
    {
        try
        {
            DataTable dtb = receivableSetupAndGroupAccountListBAL.GetReceivableSetupAndGroupAccountListBySearchParameters(receivableSetupAndGroupAccountListUI);

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
            logExcpUIobj.MethodName = "BindReceivableSetupAndGroupAccountListBySearchParameters()";
            logExcpUIobj.ResourceName = "System_Settings_ReceivableSetupAndGroupAccountList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_ReceivableSetupAndGroupAccountList : BindReceivableSetupAndGroupAccountListBySearchParameters] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods
}
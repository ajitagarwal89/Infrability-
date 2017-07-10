using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_GLAccountFormatDetialsList : PageBase
{
    #region Data Members
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    BatchListBAL batchListBAL = new BatchListBAL();
    BatchListUI batchListUI = new BatchListUI();
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
        Response.Redirect("BatchForm.aspx");
    }

    protected void gvColLnkBtn_Click(object sender, EventArgs e)
    {
        string batchId = (sender as LinkButton).CommandArgument;
        Response.Redirect("BatchForm.aspx?BatchId=" + batchId);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        CheckBox ch;
        for (int i = 0; i < gvData.Items.Count; i++)
        {
            ch = (CheckBox)gvData.Items[i].Cells[0].FindControl("chkRow");
            if (ch.Checked == true)
            {
                try
                {
                    batchListUI.Tbl_BatchId = gvData.Items[i].Cells[1].Text;

                    if (batchListBAL.DeleteBatch(batchListUI) == 1)
                    {
                        BindList();
                        divSuccess.Visible = true;
                        lblSuccess.Text = Resources.GlobalResource.msgRecordDeleteSuccessfully;
                    }
                    else
                    {
                        divError.Visible = true;
                        lblError.Text = Resources.GlobalResource.msgCouldNotDeleteRecord;
                    }
                }
                catch (Exception exp)
                {
                    logExcpUIobj.MethodName = "btnDelete_Click()";
                    logExcpUIobj.ResourceName = "System_Settings_BatchList.CS";
                    logExcpUIobj.RecordId = batchListUI.Tbl_BatchId;
                    logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                    logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                    log.Error("[System_Settings_BatchList : btnDelete_Click] An error occured in the processing of Record Id : " + batchListUI.Tbl_BatchId + ". Details : [" + exp.ToString() + "]");
                }
            }
        }

    }

    protected void btnMainSearch_Click(object sender, EventArgs e)
    {
        btnHtmlSearch.Visible = false;
        btnHtmlClose.Visible = true;

        batchListUI.Search = txtSearch.Text;
        BindListBySearchParameters(batchListUI);
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
            DataTable dtb = batchListBAL.GetBatchList();

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
            logExcpUIobj.ResourceName = "System_Settings_BatchList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchList : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    private void BindListBySearchParameters(BatchListUI batchListUI)
    {
        try
        {
            DataTable dtb = batchListBAL.GetBatchListBySearchParameters(this.batchListUI);


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
            logExcpUIobj.ResourceName = "System_Settings_BatchList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BatchList : BindListBySearchParameters] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    #endregion Methods
}
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_GLAccountFormatList : PageBase
{
    #region Data Members
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    GLAccountFormatListBAL gLAccountFormatListBAL = new GLAccountFormatListBAL();
    GLAccountFormatListUI gLAccountFormatListUI = new GLAccountFormatListUI();
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
        Response.Redirect("GLAccountFormatForm.aspx");
    }

    protected void gvColLnkBtn_Click(object sender, EventArgs e)
    {
        string gLAccountFormatId = (sender as LinkButton).CommandArgument;
        Response.Redirect("GLAccountFormatForm.aspx?GLAccountFormatId=" + gLAccountFormatId);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        {
            CheckBox ch;
            try
            {
                for (int i = 0; i < gvData.Items.Count; i++)
                {
                    ch = (CheckBox)gvData.Items[i].Cells[0].FindControl("chkRow");
                    if (ch.Checked == true)
                    {

                        gLAccountFormatListUI.Tbl_GLAccountFormatId = gvData.Items[i].Cells[1].Text;

                        if (gLAccountFormatListBAL.DeleteGLAccountFormat(gLAccountFormatListUI) == 1)
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
                logExcpUIobj.ResourceName = "System_Settings_GLAccountFormatList.CS";
                logExcpUIobj.RecordId = gLAccountFormatListUI.Tbl_GLAccountFormatId;
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[System_Settings_GLAccountFormatList : btnDelete_Click] An error occured in the processing of Record Id : " + gLAccountFormatListUI.Tbl_GLAccountFormatId + ". Details : [" + exp.ToString() + "]");
            }
        }

    }

    protected void btnMainSearch_Click(object sender, EventArgs e)
    {
        btnHtmlSearch.Visible = false;
        btnHtmlClose.Visible = true;

        gLAccountFormatListUI.Search = txtSearch.Text;
        BindListBySearchParameters(gLAccountFormatListUI);
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
            DataTable dtb = gLAccountFormatListBAL.GetGLAccountFormatList();

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
            logExcpUIobj.ResourceName = "System_Settings_GLAccountFormatList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountFormatList : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    private void BindListBySearchParameters(GLAccountFormatListUI gLAccountFormatListUI)
    {
        try
        {
            DataTable dtb = gLAccountFormatListBAL.GetGLAccountFormatListBySearchParameters(this.gLAccountFormatListUI);


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
            logExcpUIobj.ResourceName = "System_Settings_GLAccountFormatList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_GLAccountFormatList : BindListBySearchParameters] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    #endregion Methods
}
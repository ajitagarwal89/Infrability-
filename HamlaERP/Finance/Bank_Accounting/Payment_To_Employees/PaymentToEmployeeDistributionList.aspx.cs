﻿using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Finance_Bank_Accounting_Employee_Payment_Processing_PaymentToEmployeeDistributionList : System.Web.UI.Page
{
    #region Data Members
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    PaymentToEmployeeDistributionListBAL paymentToEmployeeDistributionListBAL = new PaymentToEmployeeDistributionListBAL();
    PaymentToEmployeeDistributionListUI paymentToEmployeeDistributionListUI = new PaymentToEmployeeDistributionListUI();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    #endregion


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
        Response.Redirect("PaymentToEmployeeDistributionForm.aspx");
    }
    protected void gvColLnkBtn_Click(object sender, EventArgs e)
    {
        string paymentToEmployeeDistributionId = (sender as LinkButton).CommandArgument;
        Response.Redirect("PaymentToEmployeeDistributionForm.aspx?PaymentToEmployeeDistributionId=" + paymentToEmployeeDistributionId);
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

                    paymentToEmployeeDistributionListUI.Tbl_PaymentToEmployeeDistributionId = gvData.Items[i].Cells[1].Text;

                    if (paymentToEmployeeDistributionListBAL.DeletePaymentToEmployeeDistribution(paymentToEmployeeDistributionListUI) == 1)
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionList.CS";
            logExcpUIobj.RecordId = paymentToEmployeeDistributionListUI.Tbl_PaymentToEmployeeDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionList : btnDelete_Click] An error occured in the processing of Record Id : " + paymentToEmployeeDistributionListUI.Tbl_PaymentToEmployeeDistributionId + ". Details : [" + exp.ToString() + "]");
        }
    }
    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtb = new DataTable();
            dtb = paymentToEmployeeDistributionListBAL.GetPaymentToEmployeeDistributionListForExportToExcel();

            string exportedFileName = "PaymentToEmployeeDistribution" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionList.CS";
            logExcpUIobj.RecordId = "Export To excel";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionList : lnkExportToExcel_Click] An error occured in the processing of Records. Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnMainSearch_Click(object sender, EventArgs e)
    {
        btnHtmlSearch.Visible = false;
        btnHtmlClose.Visible = true;

        paymentToEmployeeDistributionListUI.Search = txtSearch.Text;
        BindListBySearchParameters(paymentToEmployeeDistributionListUI);
    }

    protected void btnClearMainSearch_Click(object sender, EventArgs e)
    {
        BindList();
        btnHtmlSearch.Visible = true;
        btnHtmlClose.Visible = false;
        txtSearch.Text = "";
        txtSearch.Focus();
    }

    #endregion Event end

    #region Methods

    private void BindList()
    {
        try
        {
            DataTable dtb = paymentToEmployeeDistributionListBAL.GetPaymentToEmployeeDistributionList();

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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionList : BindList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }

    private void BindListBySearchParameters(PaymentToEmployeeDistributionListUI paymentToEmployeeDistributionListUI)
    {
        try
        {
            DataTable dtb = paymentToEmployeeDistributionListBAL.GetPaymentToEmployeeDistributionListBySearchParameters(paymentToEmployeeDistributionListUI);


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
            logExcpUIobj.ResourceName = "Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionList : BindListBySearchParameters] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods

}
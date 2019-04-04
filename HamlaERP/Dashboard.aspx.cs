using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Dashboard : PageBase
{
    #region DataMember
    public int Posted = 0;
    public int Pending = 0;
    public string name = string.Empty;
    public decimal cash = 0;
    public decimal cheque = 0;
    public decimal card = 0;
    public decimal banktransfer = 0;
    public decimal totalCash = 0;
    public string piechart = "";
    public string stackedchart = "";
    public string barchart = "";
    public string IsPosted = "";
    public string linechart = "";
    public string plot = "";
    public string periodTime = "";
    public string ganttchart = "";
    public string downPaymentToSupplierpiechart = "";




    OrganizationListBAL objOrganizationListBAL = new OrganizationListBAL();
    ChartBAL chartBAL = new ChartBAL();
    ChartUI ChartUI = new ChartUI();
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    OptionSetFormBAL optionSetFormBAL = new OptionSetFormBAL();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    DataTable dtgv;
    #endregion

    #region Event
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
        if (!Page.IsPostBack)
        {
            FillOrganizations();

            if (SessionContext.tbl_OrganizationId == null && SessionContext.AuthenticationRequired == true)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "showOrganizationSelectModal", "openOrganizationSelectModal();", true);
                ddlChart.SelectedIndex = 0;
                GetDownPaymentFromCustomer_PostingWithoutRevenue_Status();
                GetDownPaymentFromCustomer_Posting_On_Status();
                GetDownPaymentFromCustomer_Chart_Periodically("Year");

            }

        }
    }

    protected void ddlChart_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlChart.SelectedValue == "downPaymentFromCustomer")
        {
            GetDownPaymentFromCustomer_PostingWithoutRevenue_Status();
            GetDownPaymentFromCustomer_Posting_On_Status();
            GetDownPaymentFromCustomer_Chart_Periodically("Year");
            dvdownPaymentFromCustomer.Visible = true;
            dvdownPaymentToSupplier.Visible = false;
            dvPaymentFromCustomer.Visible = false;
            dvPaymentToSupplierEmployee.Visible = false;
            dvCustomerInvoiceProcess.Visible = false;
            dvSupplierEmployeeGeneralExpenses.Visible = false;
            dvNonPOBasedInvoice.Visible = false;
            dvPaymentToSupplier.Visible = false;
            dvEmployeeGeneralExpenses.Visible = false;
            dvPaymentToEmployee.Visible = false;
        }
        else if (ddlChart.SelectedValue == "downPaymentToSupplier")
        {
            GetDownPaymentToSupplier_Chart_Posting_On_Status();
            GetDownPaymentToSupplier_Chart_BasedOnPayment_Mode();
            GetDownPaymentToSupplier_Chart_Periodically("Year");
            dvdownPaymentToSupplier.Visible = true;
            dvPaymentFromCustomer.Visible = false;
            dvdownPaymentFromCustomer.Visible = false;
            dvPaymentToSupplierEmployee.Visible = false;
            dvCustomerInvoiceProcess.Visible = false;
            dvSupplierEmployeeGeneralExpenses.Visible = false;
            dvNonPOBasedInvoice.Visible = false;
            dvPaymentToSupplier.Visible = false;
            dvEmployeeGeneralExpenses.Visible = false;
            dvPaymentToEmployee.Visible = false;

        }
        else if (ddlChart.SelectedValue == "paymentFromCustomer")
        {
            GetPaymentFromCustomer_Posting_On_Status();
            GetPaymentFromCustomer_BasedOnPayment_Mode();
            GetPaymentFromCustomer_Chart_Periodically("Year");
            dvPaymentFromCustomer.Visible = true;
            dvdownPaymentToSupplier.Visible = false;
            dvdownPaymentFromCustomer.Visible = false;
            dvPaymentToSupplierEmployee.Visible = false;
            dvCustomerInvoiceProcess.Visible = false;
            dvSupplierEmployeeGeneralExpenses.Visible = false;
            dvNonPOBasedInvoice.Visible = false;
            dvPaymentToSupplier.Visible = false;
            dvEmployeeGeneralExpenses.Visible = false;
            dvPaymentToEmployee.Visible = false;
        }
        else if (ddlChart.SelectedValue == "paymentToEmployee")
        {
            GetPaymentToEmployee_Chart_PostingOnStatus();
            GetPaymentToEmployee_Chart_BasedOnPaymentMode();
            GetPaymentToEmployee_Chart_Periodically("Year");
            dvPaymentFromCustomer.Visible = false;
            dvdownPaymentFromCustomer.Visible = false;
            dvdownPaymentToSupplier.Visible = false;
            dvPaymentToSupplierEmployee.Visible = false;
            dvCustomerInvoiceProcess.Visible = false;
            dvSupplierEmployeeGeneralExpenses.Visible = false;
            dvNonPOBasedInvoice.Visible = false;
            dvPaymentToSupplier.Visible = false;
            dvEmployeeGeneralExpenses.Visible = false;
            dvPaymentToEmployee.Visible = true;

        }
        else if (ddlChart.SelectedValue == "paymentToSupplierEmployee")
        {
            GetPaymentToSupplierEmployee_Periodically("Year");
            GetPaymentToSupplierEmployee_BasedOnPayment_Mode();
            GetPaymentToSupplierEmployee_Chart_PostingOnStatus();
            dvPaymentFromCustomer.Visible = false;
            dvdownPaymentToSupplier.Visible = false;
            dvdownPaymentFromCustomer.Visible = false;
            dvCustomerInvoiceProcess.Visible = false;
            dvPaymentToSupplierEmployee.Visible = true;
            dvSupplierEmployeeGeneralExpenses.Visible = false;
            dvNonPOBasedInvoice.Visible = false;
            dvPaymentToSupplier.Visible = false;
            dvEmployeeGeneralExpenses.Visible = false;
            dvPaymentToEmployee.Visible = false;

        }
        else if (ddlChart.SelectedValue == "customerInvoice")
        {
        }
        else if (ddlChart.SelectedValue == "customerInvoiceProcess")
        {
            GetCustomerInvoiceProcess_Chart_Periodically("Year");
            GetCustomerInvoiceProcess_Chart_BasedOnPaymentMode();
            GetCustomerInvoiceProcess_Chart_PostingOnStatus();
            dvPaymentFromCustomer.Visible = false;
            dvdownPaymentToSupplier.Visible = false;
            dvdownPaymentFromCustomer.Visible = false;
            dvPaymentToSupplierEmployee.Visible = false;
            dvCustomerInvoiceProcess.Visible = true;
            dvSupplierEmployeeGeneralExpenses.Visible = false;
            dvNonPOBasedInvoice.Visible = false;
            dvEmployeeGeneralExpenses.Visible = false;
            dvPaymentToEmployee.Visible = false;

        }
        else if (ddlChart.SelectedValue == "employeeGeneralExpenses")
        {
            GetEmployeeGeneralExpenses_Chart_PostingOnStatus();
            GetEmployeeGeneralExpenses_Chart_BasedOnPaymentMode();
            GetEmployeeGeneralExpenses_Chart_Periodically("Year");
            dvPaymentFromCustomer.Visible = false;
            dvdownPaymentFromCustomer.Visible = false;
            dvdownPaymentToSupplier.Visible = false;
            dvPaymentToSupplierEmployee.Visible = false;
            dvCustomerInvoiceProcess.Visible = false;
            dvSupplierEmployeeGeneralExpenses.Visible = false;
            dvNonPOBasedInvoice.Visible = false;
            dvPaymentToSupplier.Visible = false;
            dvEmployeeGeneralExpenses.Visible = true;
            dvPaymentToEmployee.Visible = false;
        }
        else if (ddlChart.SelectedValue == "pOBasedInvoice")
        {
        }
        else if (ddlChart.SelectedValue == "paymentToSupplier")
        {
            GetPaymentToSupplier_Chart_Periodically("Year");
            GetPaymentToSupplier_Chart_BasedOnPaymentMode();
            GetPaymentToSupplier_Chart_PostingOnStatus();
            dvPaymentFromCustomer.Visible = false;
            dvdownPaymentFromCustomer.Visible = false;
            dvdownPaymentToSupplier.Visible = false;
            dvPaymentToSupplierEmployee.Visible = false;
            dvCustomerInvoiceProcess.Visible = false;
            dvSupplierEmployeeGeneralExpenses.Visible = false;
            dvNonPOBasedInvoice.Visible = false;
            dvPaymentToSupplier.Visible = true;
            dvEmployeeGeneralExpenses.Visible = false;
            dvPaymentToEmployee.Visible = false;

        }
        else if (ddlChart.SelectedValue == "nonPOBasedInvoice")
        {

            GetNonPOBasedInvoice_Chart_Periodically("Year");
            GetNonPOBasedInvoice_Chart_BasedOnPaymentMode();
            GetNonPOBasedInvoice_Chart_PostingOnStatus();
            dvPaymentFromCustomer.Visible = false;
            dvdownPaymentFromCustomer.Visible = false;
            dvdownPaymentToSupplier.Visible = false;
            dvPaymentToSupplierEmployee.Visible = false;
            dvCustomerInvoiceProcess.Visible = false;
            dvSupplierEmployeeGeneralExpenses.Visible = false;
            dvNonPOBasedInvoice.Visible = true;
            dvPaymentToSupplier.Visible = false;
            dvEmployeeGeneralExpenses.Visible = false;
            dvPaymentToEmployee.Visible = false;
        }
        else if (ddlChart.SelectedValue == "supplierEmployeeGeneralExpenses")
        {
            GetSupplierEmployeeGeneralExpenses_Chart_Periodically("Year");
            GetSupplierEmployeeGeneralExpenses_Chart_BasedOnPaymentMode();
            GetSupplierEmployeeGeneralExpenses_Chart_PostingOnStatus();
            dvPaymentFromCustomer.Visible = false;
            dvdownPaymentFromCustomer.Visible = false;
            dvdownPaymentToSupplier.Visible = false;
            dvPaymentToSupplierEmployee.Visible = false;
            dvCustomerInvoiceProcess.Visible = false;
            dvSupplierEmployeeGeneralExpenses.Visible = true;
            dvNonPOBasedInvoice.Visible = false;
            dvPaymentToSupplier.Visible = false;
            dvEmployeeGeneralExpenses.Visible = false;
            dvPaymentToEmployee.Visible = false;
        }
        else
        {
            dvPaymentFromCustomer.Visible = false;
            dvdownPaymentFromCustomer.Visible = false;
            dvdownPaymentToSupplier.Visible = false;
            dvPaymentToSupplierEmployee.Visible = false;
            dvCustomerInvoiceProcess.Visible = false;
            dvSupplierEmployeeGeneralExpenses.Visible = false;
            dvNonPOBasedInvoice.Visible = false;
            dvPaymentToSupplier.Visible = false;
            dvEmployeeGeneralExpenses.Visible = false;
            dvPaymentToEmployee.Visible = false;
        }
    }

    

    #endregion  Event

    #region Method

    private void FillOrganizations()
    {
        DataTable dtb = objOrganizationListBAL.GetOrganizationListOfUser(Guid.Parse(SessionContext.UserGuid));
        if (dtb.Rows.Count > 0 && dtb != null)
        {
            ddlOrganizationList.DataSource = dtb;
            ddlOrganizationList.DataValueField = "tbl_OrganizationId";
            ddlOrganizationList.DataTextField = "Name";
            ddlOrganizationList.DataBind();
        }
        else
        {
            ddlOrganizationList.Items.Insert(0, new ListItem("No Organization Found", "-1"));
        }
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        SessionContext.tbl_OrganizationId = ddlOrganizationList.SelectedValue;
    }

    #region CHART DownPaymentFromCustomer
    private void GetDownPaymentFromCustomer_PostingWithoutRevenue_Status()
    {
        try
        {
            string[] colorcode = { "#ED7B00", "#7D0096", "#005CDE", "#00A36A", "#992B00", "#169eaf", "#c9205e", "#c6811f", "#aac61b", "#2eea3e", "#1d8e76", "#d1364a", "#b5b038", "#a434e5", "#34acdb" };
            piechart = "var dataSet = [";
            dtgv = chartBAL.GetDownPaymentFromCustomer_Posting_Status();
            if (dtgv.Rows.Count > 0 && dtgv != null)
            {
                for (int i = 0; i < dtgv.Rows.Count; i++)
                {
                    piechart += "{ label: '" + dtgv.Rows[i]["IsPosted"].ToString() + "', data: " + Convert.ToInt32(dtgv.Rows[i]["TotalRecord"].ToString()) + ", color: '" + colorcode[i].ToString() + "' },";
                }
            }
            piechart += "];";
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetDownPaymentFromCustomer_PostingWithoutRevenue_Status()";
            logExcpUIobj.ResourceName = "Dashboard.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Dashboard : GetDownPaymentFromCustomer_PostingWithoutRevenue_Status] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    private void GetDownPaymentFromCustomer_Posting_On_Status()
    {
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dtTotal = new DataTable();
                DataTable dtTotalRevenue = new DataTable();

                stackedchart = "data : [";
                ds = chartBAL.GetDownPaymentFromCustomer_Posting_On_Status();

                dtTotal = ds.Tables[0];
                //dtRegistration = ds.Tables[1];

                if (dtTotal.Rows.Count > 0 && dtgv != null)
                {
                    for (int i = 0; i < dtTotal.Rows.Count; i++)
                    {
                        stackedchart += "{x:'" + dtTotal.Rows[i]["IsPosted"].ToString() + "', y:" + Convert.ToInt32(dtTotal.Rows[i]["TotalRevenue"].ToString()) + ", z:" + Convert.ToInt32(dtTotal.Rows[i]["Total"].ToString()) + "},";
                    }
                }
                stackedchart += "],";
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "GetCompanyCapacityAndRegistration()";
                logExcpUIobj.ResourceName = "Dashboard.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Dashboard : GetDownPaymentFromCustomer_Posting_On_Status] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }
    }

    private void GetDownPaymentFromCustomer_Chart_Periodically(string period)
    {
        ChartUI chartUI = new ChartUI();

        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dtTotal = new DataTable();
                chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                linechart = "data : [";
                ds = chartBAL.GetDownPaymentFromCustomer_Chart_Periodically(chartUI);

                dtTotal = ds.Tables[0];
                if (dtTotal.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTotal.Rows.Count; i++)
                    {
                        linechart += "{x:'" + dtTotal.Rows[i][period].ToString() + "', y:" + Convert.ToInt32(dtTotal.Rows[i]["TotalAmount"].ToString()) + ", z:" + Convert.ToInt32(dtTotal.Rows[i]["TotalTransaction"].ToString()) + "},";
                    }
                }
                linechart += "],";
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "GetDownPaymentFromCustomer_Chart_Periodically()";
                logExcpUIobj.ResourceName = "Dashboard.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Dashboard : GetDownPaymentFromCustomer_Chart_Periodically] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }
    }

    #endregion

    #region Chart downPaymentToSupplier
    private void GetDownPaymentToSupplier_Chart_Posting_On_Status()
    {
        try
        {
            ChartUI chartUI = new ChartUI();
            chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            string[] colorcode = { "#ED7B00", "#7D0096", "#005CDE", "#00A36A", "#992B00", "#169eaf", "#c9205e", "#c6811f", "#aac61b", "#2eea3e", "#1d8e76", "#d1364a", "#b5b038", "#a434e5", "#34acdb" };
            piechart = "var dataSet = [";
            dtgv = chartBAL.GetDownPaymentToSupplier_Chart_Posting_On_Status(chartUI);
            if (dtgv.Rows.Count > 0 && dtgv != null)
            {
                for (int i = 0; i < dtgv.Rows.Count; i++)
                {
                    piechart += "{ label: '" + dtgv.Rows[i]["IsPosted"].ToString() + "', data: " + Convert.ToInt32(dtgv.Rows[i]["TotalAmount"].ToString()) + ", color: '" + colorcode[i].ToString() + "' },";
                }
            }
            piechart += "];";
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetSupplierEmployeeGeneralExpenses_Chart_PostingOnStatus()";
            logExcpUIobj.ResourceName = "Dashboard.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Dashboard : GetSupplierEmployeeGeneralExpenses_Chart_PostingOnStatus] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }

    private void GetDownPaymentToSupplier_Chart_BasedOnPayment_Mode()
    {
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dtTotal = new DataTable();
                DataTable dtTotalRevenue = new DataTable();

                stackedchart = "data : [";
                ds = chartBAL.GetDownPaymentToSupplier_Chart_BasedOnPayment_Mode();

                dtTotal = ds.Tables[0];
                //dtRegistration = ds.Tables[1];

                if (dtTotal.Rows.Count > 0 && dtgv != null)
                {
                    for (int i = 0; i < dtTotal.Rows.Count; i++)
                    {
                        stackedchart += "{x:'" + dtTotal.Rows[i]["ReciptMode"].ToString() + "', y:" + Convert.ToInt32(dtTotal.Rows[i]["TotalPayment"].ToString()) + ", z:" + Convert.ToInt32(dtTotal.Rows[i]["TotalTransaction"].ToString()) + "},";
                    }
                }
                stackedchart += "],";
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "GetDownPaymentToSupplier_Chart_BasedOnPayment_Mode()";
                logExcpUIobj.ResourceName = "Dashboard.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Dashboard : GetDownPaymentToSupplier_Chart_BasedOnPayment_Mode] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }

    }

    private void GetDownPaymentToSupplier_Chart_Periodically(string period)
    {
          
        ChartUI chartUI = new ChartUI();

      
            try
            {
                DataSet ds = new DataSet();
                DataTable dtTotal = new DataTable();
                chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                linechart = "data : [";
                ds = chartBAL.GetDownPaymentToSupplier_Chart_Periodically(chartUI);

                dtTotal = ds.Tables[0];
                if (dtTotal.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTotal.Rows.Count; i++)
                    {
                        linechart += "{x:'" + dtTotal.Rows[i][period].ToString() + "', y:" + Convert.ToInt32(dtTotal.Rows[i]["TotalRevenue"].ToString()) + ", z:" + Convert.ToInt32(dtTotal.Rows[i]["TotalTransaction"].ToString()) + "},";


                    }
                }
                linechart += "],";
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "GetDownPaymentToSupplier_Chart_Periodically()";
                logExcpUIobj.ResourceName = "Dashboard.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Dashboard : GetDownPaymentToSupplier_Chart_Periodically] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            
    }
}

    #endregion

    #region Chart PaymentFromCustomer
    private void GetPaymentFromCustomer_Posting_On_Status()
    {
        try
        {
            ChartUI chartUI = new ChartUI();
            chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            string[] colorcode = { "#ED7B00", "#7D0096", "#005CDE", "#00A36A", "#992B00", "#169eaf", "#c9205e", "#c6811f", "#aac61b", "#2eea3e", "#1d8e76", "#d1364a", "#b5b038", "#a434e5", "#34acdb" };
            piechart = "var dataSet = [";
            dtgv = chartBAL.GetPaymentFromCustomer_Chart_Posting_On_Status(chartUI);
            if (dtgv.Rows.Count > 0 && dtgv != null)
            {
                for (int i = 0; i < dtgv.Rows.Count; i++)
                {
                    piechart += "{ label: '" + dtgv.Rows[i]["IsPosted"].ToString() + "', data: " + Convert.ToInt32(dtgv.Rows[i]["TotalRevenue"].ToString()) + ", color: '" + colorcode[i].ToString() + "' },";
                }
            }
            piechart += "];";
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetSupplierEmployeeGeneralExpenses_Chart_PostingOnStatus()";
            logExcpUIobj.ResourceName = "Dashboard.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Dashboard : GetSupplierEmployeeGeneralExpenses_Chart_PostingOnStatus] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }

    private void GetPaymentFromCustomer_BasedOnPayment_Mode()
    {
        {
            try
            {
                ChartUI chartUI = new ChartUI();
                DataSet ds = new DataSet();
                DataTable dtTotal = new DataTable();
                chartUI.Tbl_OrganizationId = SessionContext.tbl_OrganizationId;
                stackedchart = "data : [";
                ds = chartBAL.GetPaymentFromCustomer_Chart_BasedOnPayment_Mode(chartUI);

                dtTotal = ds.Tables[0];
                //dtRegistration = ds.Tables[1];

                if (dtTotal.Rows.Count > 0 && dtgv != null)
                {
                    for (int i = 0; i < dtTotal.Rows.Count; i++)
                    {
                        stackedchart += "{x:'" + dtTotal.Rows[i]["ReciptMode"].ToString() + "', y:" + Convert.ToInt32(dtTotal.Rows[i]["TotalRevenue"].ToString()) + ", z:" + Convert.ToInt32(dtTotal.Rows[i]["TotalTransaction"].ToString()) + "},";
                    }
                }
                stackedchart += "],";
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "GetPaymentFromCustomer_BasedOnPayment_Mode()";
                logExcpUIobj.ResourceName = "Dashboard.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Dashboard : GetPaymentFromCustomer_BasedOnPayment_Mode] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }

    }

    private void GetPaymentFromCustomer_Chart_Periodically(string period)
    {

        ChartUI chartUI = new ChartUI();


        try
        {
            DataSet ds = new DataSet();
                              DataTable dtTotal = new DataTable();
            chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            linechart = "data : [";
            ds = chartBAL.GetPaymentFromCustomer_Chart_Periodically(chartUI);

            dtTotal = ds.Tables[0];
            if (dtTotal.Rows.Count > 0)
            {
                for (int i = 0; i < dtTotal.Rows.Count; i++)
                {
                    linechart += "{x:'" + dtTotal.Rows[i][period].ToString() + "', y:" + Convert.ToInt32(dtTotal.Rows[i]["TotalAmount"].ToString()) + ", z:" + Convert.ToInt32(dtTotal.Rows[i]["TotalTransaction"].ToString()) + "},";


                }
            }
            linechart += "],";
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetDownPaymentToSupplier_Chart_Periodically()";
            logExcpUIobj.ResourceName = "Dashboard.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Dashboard : GetDownPaymentToSupplier_Chart_Periodically] An error occured in the processing of Record Details : [" + exp.ToString() + "]");

        }
    }
    #endregion

    #region Chart paymentToEmployee
    private void GetPaymentToSupplierEmployee_Periodically( string Peroid)
    {
        ChartUI chartUI = new ChartUI();

        {
            try
             {
                DataSet ds = new DataSet();
                DataTable dtTotal = new DataTable();
                chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                linechart = "data : [";
                ds = chartBAL.GetPaymentToSupplierEmployee_Periodically(chartUI);

                dtTotal = ds.Tables[0];
                if (dtTotal.Rows.Count >0 )
                {
                    for (int i = 0; i < dtTotal.Rows.Count; i++)
                    {
                        linechart += "{x:'" + dtTotal.Rows[i][Peroid].ToString() + "', y:" + Convert.ToInt32(dtTotal.Rows[i]["TotalAmount"].ToString()) + ", z:" + Convert.ToInt32(dtTotal.Rows[i]["TotalTransaction"].ToString()) + "},";
                    
                      
                    }
                }
                linechart += "],";
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "GetPaymentToSupplierEmployee_Periodically()";
                logExcpUIobj.ResourceName = "Dashboard.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Dashboard : GetPaymentToSupplierEmployee_Periodically] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }

    }
    private void GetPaymentToSupplierEmployee_BasedOnPayment_Mode()
    {
        ChartUI chartUI = new ChartUI();
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dtTotal = new DataTable();
                DataTable dtTotalRevenue = new DataTable();
                chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                stackedchart = "data : [";
                ds = chartBAL.GetPaymentToSupplierEmployee_BasedOnPayment_Mode(chartUI);

                dtTotal = ds.Tables[0];
                //dtRegistration = ds.Tables[1];

                if (dtTotal.Rows.Count > 0 )
                {
                    for (int i = 0; i < dtTotal.Rows.Count; i++)
                    {
                        stackedchart += "{x:'" + dtTotal.Rows[i]["ReciptMode"].ToString() + "', y:" + Convert.ToInt32(dtTotal.Rows[i]["TotalRevenue"].ToString()) + ", z:" + Convert.ToInt32(dtTotal.Rows[i]["TotalTransaction"].ToString()) + "},";
                    }
                }
                stackedchart += "],";
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "GetPaymentToSupplierEmployee_BasedOnPayment_Mode()";
                logExcpUIobj.ResourceName = "Dashboard.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Dashboard : GetPaymentToSupplierEmployee_BasedOnPayment_Mode] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }

    }
    private void GetPaymentToSupplierEmployee_Chart_PostingOnStatus()
    {
        try
        {
            ChartUI chartUI = new ChartUI();
            chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            string[] colorcode = { "#ED7B00", "#7D0096", "#005CDE", "#00A36A", "#992B00", "#169eaf", "#c9205e", "#c6811f", "#aac61b", "#2eea3e", "#1d8e76", "#d1364a", "#b5b038", "#a434e5", "#34acdb" };
            piechart = "var dataSet = [";
            dtgv = chartBAL.GetPaymentToSupplierEmployee_Chart_PostingOnStatus(chartUI);
            if (dtgv.Rows.Count > 0 && dtgv != null)
            {
                for (int i = 0; i < dtgv.Rows.Count; i++)
                {
                    piechart += "{ label: '" + dtgv.Rows[i]["IsPosted"].ToString() + "', data: " + Convert.ToInt32(dtgv.Rows[i]["Total"].ToString()) + ", color: '" + colorcode[i].ToString() + "' },";
                }
            }
            piechart += "];";
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetPaymentToSupplierEmployee_Chart_PostingOnStatus()";
            logExcpUIobj.ResourceName = "Dashboard.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Dashboard : GetPaymentToSupplierEmployee_Chart_PostingOnStatus] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void lnkDay_Click(object sender, EventArgs e)
    {
        GetPaymentToSupplierEmployee_Periodically("days");
    }
    protected void lnkBtnWeek_Click(object sender, EventArgs e)
    {
        GetPaymentToSupplierEmployee_Periodically("Week");

    }
    protected void lnkYear_Click(object sender, EventArgs e)
    {
        GetPaymentToSupplierEmployee_Periodically("Year");
    }
    protected void lnkMonth_Click(object sender, EventArgs e)
    {
        GetPaymentToSupplierEmployee_Periodically("month");
    }
    protected void lnkQuarter_Click(object sender, EventArgs e)
    {
        GetPaymentToSupplierEmployee_Periodically("Quarter");
    }

    protected void lnkDayCustomerInvoiceProcess_Click(object sender, EventArgs e)
    {
        GetCustomerInvoiceProcess_Chart_Periodically("days");

    }

    protected void lnkWeekCustomerInvoiceProcess_Click(object sender, EventArgs e)
    {
        GetCustomerInvoiceProcess_Chart_Periodically("Week");
    }

    protected void lnkMonthCustomerInvoiceProcess_Click(object sender, EventArgs e)
    {
        GetCustomerInvoiceProcess_Chart_Periodically("month");

    }

    protected void lnkYearCustomerInvoiceProcess_Click(object sender, EventArgs e)
    {
        GetCustomerInvoiceProcess_Chart_Periodically("Year");
    }

    protected void lnkQuarterCustomerInvoiceProcess_Click(object sender, EventArgs e)
    {
        GetCustomerInvoiceProcess_Chart_Periodically("Quarter");

    }

    protected void lnkSupplierEmployeeGeneralExpensesDay_Click(object sender, EventArgs e)
    {
        GetSupplierEmployeeGeneralExpenses_Chart_Periodically("days");
    }

    protected void lnkSupplierEmployeeGeneralExpensesWeek_Click(object sender, EventArgs e)
    {
        GetSupplierEmployeeGeneralExpenses_Chart_Periodically("Week");
    }

    protected void lnkSupplierEmployeeGeneralExpensesMonth_Click(object sender, EventArgs e)
    {
        GetSupplierEmployeeGeneralExpenses_Chart_Periodically("month");

    }

    protected void lnkSupplierEmployeeGeneralExpensesYear_Click(object sender, EventArgs e)
    {
        GetSupplierEmployeeGeneralExpenses_Chart_Periodically("Year");
    }

    protected void lnkSupplierEmployeeGeneralExpensesQuarter_Click(object sender, EventArgs e)
    {
        GetSupplierEmployeeGeneralExpenses_Chart_Periodically("Quarter");

    }

    #endregion

    #region  SupplierEmployeeGeneralExpenses
    private void GetSupplierEmployeeGeneralExpenses_Chart_PostingOnStatus()
    {
        try
        {
            ChartUI chartUI = new ChartUI();
            chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            string[] colorcode = { "#ED7B00", "#7D0096", "#005CDE", "#00A36A", "#992B00", "#169eaf", "#c9205e", "#c6811f", "#aac61b", "#2eea3e", "#1d8e76", "#d1364a", "#b5b038", "#a434e5", "#34acdb" };
            piechart = "var dataSet = [";
            dtgv = chartBAL.GetSupplierEmployeeGeneralExpenses_Chart_PostingOnStatus(chartUI);
            if (dtgv.Rows.Count > 0 && dtgv != null)
            {
                for (int i = 0; i < dtgv.Rows.Count; i++)
                {
                    piechart += "{ label: '" + dtgv.Rows[i]["IsPosted"].ToString() + "', data: " + Convert.ToInt32(dtgv.Rows[i]["TotalExpenses"].ToString()) + ", color: '" + colorcode[i].ToString() + "' },";
                }
            }
            piechart += "];";
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetSupplierEmployeeGeneralExpenses_Chart_PostingOnStatus()";
            logExcpUIobj.ResourceName = "Dashboard.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Dashboard : GetSupplierEmployeeGeneralExpenses_Chart_PostingOnStatus] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void GetSupplierEmployeeGeneralExpenses_Chart_BasedOnPaymentMode()
    {
        {
            ChartUI chartUI = new ChartUI();
            {
                try
                {
                    DataSet ds = new DataSet();
                    DataTable dtTotal = new DataTable();
                    DataTable dtTotalRevenue = new DataTable();
                    chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                    stackedchart = "data : [";
                    ds = chartBAL.GetSupplierEmployeeGeneralExpenses_Chart_BasedOnPaymentMode(chartUI);

                    dtTotal = ds.Tables[0];
                    //dtRegistration = ds.Tables[1];

                    if (dtTotal.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtTotal.Rows.Count; i++)
                        {
                            stackedchart += "{x:'" + dtTotal.Rows[i]["ReciptMode"].ToString() + "', y:" + Convert.ToInt32(dtTotal.Rows[i]["TotalExpenses"].ToString()) + ", z:" + Convert.ToInt32(dtTotal.Rows[i]["TotalTransaction"].ToString()) + "},";
                        }
                    }
                    stackedchart += "],";
                }
                catch (Exception exp)
                {
                    logExcpUIobj.MethodName = "GetCustomerInvoiceProcess_Chart_BasedOnPaymentMode()";
                    logExcpUIobj.ResourceName = "Dashboard.CS";
                    logExcpUIobj.RecordId = "";
                    logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                    logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                    log.Error("[Dashboard : GetCustomerInvoiceProcess_Chart_BasedOnPaymentMode] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
                }
            }
        }
        }

    private void GetSupplierEmployeeGeneralExpenses_Chart_Periodically(string period)
    {
        ChartUI chartUI = new ChartUI();

        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dtTotal = new DataTable();
                chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                linechart = "data : [";
                ds = chartBAL.GetSupplierEmployeeGeneralExpenses_Chart_Periodically(chartUI);

                dtTotal = ds.Tables[0];
                if (dtTotal.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTotal.Rows.Count; i++)
                    {
                        linechart += "{x:'" + dtTotal.Rows[i][period].ToString() + "', y:" + Convert.ToInt32(dtTotal.Rows[i]["TotalExpenses"].ToString()) + ", z:" + Convert.ToInt32(dtTotal.Rows[i]["TotalTransaction"].ToString()) + "},";


                    }
                }
                linechart += "],";
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "GetPaymentToSupplierEmployee_Periodically()";
                logExcpUIobj.ResourceName = "Dashboard.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Dashboard : GetPaymentToSupplierEmployee_Periodically] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }
    }
    #endregion

    #region Customer Invoice Process
    public void GetCustomerInvoiceProcess_Chart_Periodically(string period)
    {
        ChartUI chartUI = new ChartUI();

        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dtTotal = new DataTable();
                chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                linechart = "data : [";
                ds = chartBAL.GetCustomerInvoiceProcess_Chart_Periodically(chartUI);

                dtTotal = ds.Tables[0];
                if (dtTotal.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTotal.Rows.Count; i++)
                    {
                        linechart += "{x:'" + dtTotal.Rows[i][period].ToString() + "', y:" + Convert.ToInt32(dtTotal.Rows[i]["Total"].ToString()) + ", z:" + Convert.ToInt32(dtTotal.Rows[i]["TotalTransaction"].ToString()) + "},";


                    }
                }
                linechart += "],";
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "GetPaymentToSupplierEmployee_Periodically()";
                logExcpUIobj.ResourceName = "Dashboard.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Dashboard : GetPaymentToSupplierEmployee_Periodically] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }
    }
    private void GetCustomerInvoiceProcess_Chart_PostingOnStatus()
    {
        try
        {
            ChartUI chartUI = new ChartUI();
            chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            string[] colorcode = { "#ED7B00", "#7D0096", "#005CDE", "#00A36A", "#992B00", "#169eaf", "#c9205e", "#c6811f", "#aac61b", "#2eea3e", "#1d8e76", "#d1364a", "#b5b038", "#a434e5", "#34acdb" };
            piechart = "var dataSet = [";
            dtgv = chartBAL.GetCustomerInvoiceProcess_Chart_PostingOnStatus(chartUI);
            if (dtgv.Rows.Count > 0 && dtgv != null)
            {
                for (int i = 0; i < dtgv.Rows.Count; i++)
                {
                    piechart += "{ label: '" + dtgv.Rows[i]["IsPosted"].ToString() + "', data: " + Convert.ToInt32(dtgv.Rows[i]["Total"].ToString()) + ", color: '" + colorcode[i].ToString() + "' },";
                }
            }
            piechart += "];";
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetCustomerInvoiceProcess_Chart_PostingOnStatus()";
            logExcpUIobj.ResourceName = "Dashboard.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Dashboard : GetCustomerInvoiceProcess_Chart_PostingOnStatus] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void GetCustomerInvoiceProcess_Chart_BasedOnPaymentMode()
    {
        ChartUI chartUI = new ChartUI();
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dtTotal = new DataTable();
                DataTable dtTotalRevenue = new DataTable();
                chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                stackedchart = "data : [";
                ds = chartBAL.GetCustomerInvoiceProcess_Chart_BasedOnPaymentMode(chartUI);

                dtTotal = ds.Tables[0];
                //dtRegistration = ds.Tables[1];

                if (dtTotal.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTotal.Rows.Count; i++)
                    {
                        stackedchart += "{x:'" + dtTotal.Rows[i]["ReciptMode"].ToString() + "', y:" + Convert.ToInt32(dtTotal.Rows[i]["Total"].ToString()) + ", z:" + Convert.ToInt32(dtTotal.Rows[i]["TotalTransaction"].ToString()) + "},";
                    }
                }
                stackedchart += "],";
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "GetCustomerInvoiceProcess_Chart_BasedOnPaymentMode()";
                logExcpUIobj.ResourceName = "Dashboard.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Dashboard : GetCustomerInvoiceProcess_Chart_BasedOnPaymentMode] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }

    }
    #endregion
   
    #region Non POBased Invoice

    private void GetNonPOBasedInvoice_Chart_PostingOnStatus()
    {
        try
        {
            ChartUI chartUI = new ChartUI();
            chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            string[] colorcode = { "#ED7B00", "#7D0096", "#005CDE", "#00A36A", "#992B00", "#169eaf", "#c9205e", "#c6811f", "#aac61b", "#2eea3e", "#1d8e76", "#d1364a", "#b5b038", "#a434e5", "#34acdb" };
            piechart = "var dataSet = [";
            dtgv = chartBAL.GetNonPOBasedInvoice_Chart_PostingOnStatus(chartUI);
            if (dtgv.Rows.Count > 0 && dtgv != null)
            {
                for (int i = 0; i < dtgv.Rows.Count; i++)
                {
                    piechart += "{ label: '" + dtgv.Rows[i]["IsPosted"].ToString() + "', data: " + Convert.ToInt32(dtgv.Rows[i]["TotalExpenses"].ToString()) + ", color: '" + colorcode[i].ToString() + "' },";
                }
            }
            piechart += "];";
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetNonPOBasedInvoice_Chart_PostingOnStatus()";
            logExcpUIobj.ResourceName = "Dashboard.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Dashboard : GetNonPOBasedInvoice_Chart_PostingOnStatus] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    private void GetNonPOBasedInvoice_Chart_BasedOnPaymentMode()
    {
        ChartUI chartUI = new ChartUI();
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dtTotal = new DataTable();
                DataTable dtTotalRevenue = new DataTable();
                chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                stackedchart = "data : [";
                ds = chartBAL.GetNonPOBasedInvoice_Chart_BasedOnPaymentMode(chartUI);

                dtTotal = ds.Tables[0];
                //dtRegistration = ds.Tables[1];

                if (dtTotal.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTotal.Rows.Count; i++)
                    {
                        stackedchart += "{x:'" + dtTotal.Rows[i]["ReciptMode"].ToString() + "', y:" + Convert.ToInt32(dtTotal.Rows[i]["TotalExpenses"].ToString()) + ", z:" + Convert.ToInt32(dtTotal.Rows[i]["TotalTransaction"].ToString()) + "},";
                    }
                }
                stackedchart += "],";
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "GetNonPOBasedInvoice_Chart_BasedOnPaymentMode()";
                logExcpUIobj.ResourceName = "Dashboard.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Dashboard : GetNonPOBasedInvoice_Chart_BasedOnPaymentMode] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }
    }

    private void GetNonPOBasedInvoice_Chart_Periodically(string period)
    {

        ChartUI chartUI = new ChartUI();

        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dtTotal = new DataTable();
                chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                linechart = "data : [";
                ds = chartBAL.GetNonPOBasedInvoice_Chart_Periodically(chartUI);

                dtTotal = ds.Tables[0];
                if (dtTotal.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTotal.Rows.Count; i++)
                    {
                        linechart += "{x:'" + dtTotal.Rows[i][period].ToString() + "', y:" + Convert.ToInt32(dtTotal.Rows[i]["TotalExpenses"].ToString()) + ", z:" + Convert.ToInt32(dtTotal.Rows[i]["TotalTransaction"].ToString()) + "},";


                    }
                }
                linechart += "],";
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "GetNonPOBasedInvoice_Chart_Periodically()";
                logExcpUIobj.ResourceName = "Dashboard.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Dashboard : GetNonPOBasedInvoice_Chart_Periodically] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }
    }
    #endregion

    #region PaymentToSupplier
    private void GetPaymentToSupplier_Chart_PostingOnStatus()
    {
        try
        {
            ChartUI chartUI = new ChartUI();
            chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            string[] colorcode = { "#ED7B00", "#7D0096", "#005CDE", "#00A36A", "#992B00", "#169eaf", "#c9205e", "#c6811f", "#aac61b", "#2eea3e", "#1d8e76", "#d1364a", "#b5b038", "#a434e5", "#34acdb" };
            piechart = "var dataSet = [";
            dtgv = chartBAL.GetPaymentToSupplier_Chart_PostingOnStatus(chartUI);
            if (dtgv.Rows.Count > 0 && dtgv != null)
            {
                for (int i = 0; i < dtgv.Rows.Count; i++)
                {
                    piechart += "{ label: '" + dtgv.Rows[i]["IsPosted"].ToString() + "', data: " + Convert.ToInt32(dtgv.Rows[i]["TotalPayment"].ToString()) + ", color: '" + colorcode[i].ToString() + "' },";
                }
            }
            piechart += "];";
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetPaymentToSupplier_Chart_PostingOnStatus()";
            logExcpUIobj.ResourceName = "Dashboard.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Dashboard : GetPaymentToSupplier_Chart_PostingOnStatus] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }

    private void GetPaymentToSupplier_Chart_BasedOnPaymentMode()
    {
        ChartUI chartUI = new ChartUI();
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dtTotal = new DataTable();
                DataTable dtTotalRevenue = new DataTable();
                chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                stackedchart = "data : [";
                ds = chartBAL.GetPaymentToSupplier_Chart_BasedOnPaymentMode(chartUI);

                dtTotal = ds.Tables[0];
                //dtRegistration = ds.Tables[1];

                if (dtTotal.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTotal.Rows.Count; i++)
                    {
                        stackedchart += "{x:'" + dtTotal.Rows[i]["PaymentMode"].ToString() + "', y:" + Convert.ToInt32(dtTotal.Rows[i]["TotalPayment"].ToString()) + ", z:" + Convert.ToInt32(dtTotal.Rows[i]["TotalTransaction"].ToString()) + "},";
                    }
                }
                stackedchart += "],";
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "GetNonPOBasedInvoice_Chart_BasedOnPaymentMode()";
                logExcpUIobj.ResourceName = "Dashboard.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Dashboard : GetNonPOBasedInvoice_Chart_BasedOnPaymentMode] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }
    }

    private void GetPaymentToSupplier_Chart_Periodically(string period)
    {
        ChartUI chartUI = new ChartUI();

        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dtTotal = new DataTable();
                chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                linechart = "data : [";
                ds = chartBAL.GetPaymentToSupplier_Chart_Periodically(chartUI);

                dtTotal = ds.Tables[0];
                if (dtTotal.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTotal.Rows.Count; i++)
                    {
                        linechart += "{x:'" + dtTotal.Rows[i][period].ToString() + "', y:" + Convert.ToInt32(dtTotal.Rows[i]["TotalPayment"].ToString()) + ", z:" + Convert.ToInt32(dtTotal.Rows[i]["TotalTransaction"].ToString()) + "},";


                    }
                }
                linechart += "],";
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "GetPaymentToSupplier_Chart_Periodically()";
                logExcpUIobj.ResourceName = "Dashboard.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Dashboard : GetPaymentToSupplier_Chart_Periodically] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }
    }

    #endregion

    #region EmployeeGeneralExpenses

    private void GetEmployeeGeneralExpenses_Chart_PostingOnStatus()
    {
        try
        {
            ChartUI chartUI = new ChartUI();
            chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            string[] colorcode = { "#ED7B00", "#7D0096", "#005CDE", "#00A36A", "#992B00", "#169eaf", "#c9205e", "#c6811f", "#aac61b", "#2eea3e", "#1d8e76", "#d1364a", "#b5b038", "#a434e5", "#34acdb" };
            piechart = "var dataSet = [";
            dtgv = chartBAL.GetPaymentToSupplier_Chart_PostingOnStatus(chartUI);
            if (dtgv.Rows.Count > 0 && dtgv != null)
            {
                for (int i = 0; i < dtgv.Rows.Count; i++)
                {
                    piechart += "{ label: '" + dtgv.Rows[i]["IsPosted"].ToString() + "', data: " + Convert.ToInt32(dtgv.Rows[i]["TotalPayment"].ToString()) + ", color: '" + colorcode[i].ToString() + "' },";
                }
            }
            piechart += "];";
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetEmployeeGeneralExpenses_Chart_PostingOnStatus()";
            logExcpUIobj.ResourceName = "Dashboard.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Dashboard : GetEmployeeGeneralExpenses_Chart_PostingOnStatus] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }

    private void GetEmployeeGeneralExpenses_Chart_BasedOnPaymentMode()
    {
        ChartUI chartUI = new ChartUI();
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dtTotal = new DataTable();
                DataTable dtTotalRevenue = new DataTable();
                chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                stackedchart = "data : [";
                ds = chartBAL.GetEmployeeGeneralExpenses_Chart_BasedOnPaymentMode(chartUI);

                dtTotal = ds.Tables[0];
                //dtRegistration = ds.Tables[1];

                if (dtTotal.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTotal.Rows.Count; i++)
                    {
                        stackedchart += "{x:'" + dtTotal.Rows[i]["ReciptMode"].ToString() + "', y:" + Convert.ToInt32(dtTotal.Rows[i]["TotalExpenses"].ToString()) + ", z:" + Convert.ToInt32(dtTotal.Rows[i]["TotalTransaction"].ToString()) + "},";
                    }
                }
                stackedchart += "],";
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "GetEmployeeGeneralExpenses_Chart_BasedOnPaymentMode()";
                logExcpUIobj.ResourceName = "Dashboard.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Dashboard : GetEmployeeGeneralExpenses_Chart_BasedOnPaymentMode] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }
    }

    private void GetEmployeeGeneralExpenses_Chart_Periodically(string period)
    {
        ChartUI chartUI = new ChartUI();

        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dtTotal = new DataTable();
                chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                linechart = "data : [";
                ds = chartBAL.GetEmployeeGeneralExpenses_Chart_Periodically(chartUI);

                dtTotal = ds.Tables[0];
                if (dtTotal.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTotal.Rows.Count; i++)
                    {
                        linechart += "{x:'" + dtTotal.Rows[i][period].ToString() + "', y:" + Convert.ToInt32(dtTotal.Rows[i]["TotalPayment"].ToString()) + ", z:" + Convert.ToInt32(dtTotal.Rows[i]["TotalTransaction"].ToString()) + "},";


                    }
                }
                linechart += "],";
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "GetEmployeeGeneralExpenses_Chart_Periodically()";
                logExcpUIobj.ResourceName = "Dashboard.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Dashboard : GetEmployeeGeneralExpenses_Chart_Periodically] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }
    }

    #endregion

    #region paymentToEmployee
    private void GetPaymentToEmployee_Chart_PostingOnStatus()
    {
        try
        {
            ChartUI chartUI = new ChartUI();
            chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            string[] colorcode = { "#ED7B00", "#7D0096", "#005CDE", "#00A36A", "#992B00", "#169eaf", "#c9205e", "#c6811f", "#aac61b", "#2eea3e", "#1d8e76", "#d1364a", "#b5b038", "#a434e5", "#34acdb" };
            piechart = "var dataSet = [";
            dtgv = chartBAL.GetPaymentToEmployee_Chart_PostingOnStatus(chartUI);
            if (dtgv.Rows.Count > 0 && dtgv != null)
            {
                for (int i = 0; i < dtgv.Rows.Count; i++)
                {
                    piechart += "{ label: '" + dtgv.Rows[i]["IsPosted"].ToString() + "', data: " + Convert.ToInt32(dtgv.Rows[i]["Total"].ToString()) + ", color: '" + colorcode[i].ToString() + "' },";
                }
            }
            piechart += "];";
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetPaymentToEmployee_Chart_PostingOnStatus()";
            logExcpUIobj.ResourceName = "Dashboard.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Dashboard : GetPaymentToEmployee_Chart_PostingOnStatus] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

    }

    private void GetPaymentToEmployee_Chart_BasedOnPaymentMode()
    {
        ChartUI chartUI = new ChartUI();
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dtTotal = new DataTable();
                DataTable dtTotalRevenue = new DataTable();
                chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                stackedchart = "data : [";
                ds = chartBAL.GetPaymentToEmployee_Chart_BasedOnPaymentMode(chartUI);

                dtTotal = ds.Tables[0];
                //dtRegistration = ds.Tables[1];

                if (dtTotal.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTotal.Rows.Count; i++)
                    {
                        stackedchart += "{x:'" + dtTotal.Rows[i]["PayementMode"].ToString() + "', y:" + Convert.ToInt32(dtTotal.Rows[i]["TotalRevenue"].ToString()) + ", z:" + Convert.ToInt32(dtTotal.Rows[i]["TotalTransaction"].ToString()) + "},";
                    }
                }
                stackedchart += "],";
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "GetPaymentToEmployee_Chart_BasedOnPaymentMode()";
                logExcpUIobj.ResourceName = "Dashboard.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Dashboard : GetPaymentToEmployee_Chart_BasedOnPaymentMode] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }
    }

    private void GetPaymentToEmployee_Chart_Periodically(string period)
    {
        ChartUI chartUI = new ChartUI();

        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dtTotal = new DataTable();
                chartUI.Tbl_OrganizationId = SessionContext.OrganizationId;
                linechart = "data : [";
                ds = chartBAL.GetPaymentToEmployee_Chart_Periodically(chartUI);

                dtTotal = ds.Tables[0];
                if (dtTotal.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTotal.Rows.Count; i++)
                    {
                        linechart += "{x:'" + dtTotal.Rows[i][period].ToString() + "', y:" + Convert.ToInt32(dtTotal.Rows[i]["TotalRevenue"].ToString()) + ", z:" + Convert.ToInt32(dtTotal.Rows[i]["TotalTransaction"].ToString()) + "},";


                    }
                }
                linechart += "],";
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "GetPaymentToEmployee_Chart_Periodically()";
                logExcpUIobj.ResourceName = "Dashboard.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Dashboard : GetPaymentToEmployee_Chart_Periodically] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }
    }
    #endregion

    protected void lnkNonPOBasedInvoiceDay_Click(object sender, EventArgs e)
    {
        GetCustomerInvoiceProcess_Chart_Periodically("days");

    }

    protected void lnkNonPOBasedInvoiceQuarter_Click(object sender, EventArgs e)
    {
        GetCustomerInvoiceProcess_Chart_Periodically("Quarter");
    }

    protected void lnkNonPOBasedInvoiceWeek_Click(object sender, EventArgs e)
    {
        GetCustomerInvoiceProcess_Chart_Periodically("Week");
    }

    protected void lnkNonPOBasedInvoiceMonth_Click(object sender, EventArgs e)
    {
        GetCustomerInvoiceProcess_Chart_Periodically("month");
    }

    protected void lnkNonPOBasedInvoiceYear_Click(object sender, EventArgs e)
    {
        GetCustomerInvoiceProcess_Chart_Periodically("Year");
    }

    protected void lnkPaymentToSupplierDay_Click(object sender, EventArgs e)
    {
        GetPaymentToSupplierEmployee_Periodically("days");
    }

    protected void lnkPaymentToSupplierWeek_Click(object sender, EventArgs e)
    {
        GetPaymentToSupplierEmployee_Periodically("Week");
    }

    protected void lnkPaymentToSupplierMonth_Click(object sender, EventArgs e)
    {
        GetPaymentToSupplierEmployee_Periodically("month");

    }

    protected void lnkPaymentToSupplierQuarter_Click(object sender, EventArgs e)
    {
        GetPaymentToSupplierEmployee_Periodically("Quarter");
    }

    protected void lnkPaymentToSupplierYear_Click(object sender, EventArgs e)
    {
        GetPaymentToSupplierEmployee_Periodically("Year");
    }

    protected void lnkEmployeeGeneralExpensesDay_Click(object sender, EventArgs e)
    {
        GetEmployeeGeneralExpenses_Chart_Periodically("days");
    }

    protected void lnkEmployeeGeneralExpensesWeek_Click(object sender, EventArgs e)
    {
        GetEmployeeGeneralExpenses_Chart_Periodically("Week");
    }

    protected void lnkEmployeeGeneralExpensesMonth_Click(object sender, EventArgs e)
    {
        GetEmployeeGeneralExpenses_Chart_Periodically("month");
    }

    protected void lnkEmployeeGeneralExpensesQuarter_Click(object sender, EventArgs e)
    {
        GetEmployeeGeneralExpenses_Chart_Periodically("Quarter");
    }

    protected void lnkEmployeeGeneralExpensesYear_Click(object sender, EventArgs e)
    {
        GetEmployeeGeneralExpenses_Chart_Periodically("Year");
    }
    #endregion

    protected void lnldownPaymentFromCustomerDay_Click(object sender, EventArgs e)
    {
        GetDownPaymentFromCustomer_Chart_Periodically("days");

    }

    protected void lnldownPaymentFromCustomerWeek_Click(object sender, EventArgs e)
    {
        GetDownPaymentFromCustomer_Chart_Periodically("Week");
    }

    protected void lnldownPaymentFromCustomerMonth_Click(object sender, EventArgs e)
    {
        GetDownPaymentFromCustomer_Chart_Periodically("month");
    }

    protected void lnldownPaymentFromCustomerQuarter_Click(object sender, EventArgs e)
    {
        GetDownPaymentFromCustomer_Chart_Periodically("Quarter");
    }

    protected void lnldownPaymentFromCustomerYear_Click(object sender, EventArgs e)
    {
        GetDownPaymentFromCustomer_Chart_Periodically("Year");

    }

    protected void lnkdownPaymentToSupplierDay_Click(object sender, EventArgs e)
    {
        GetDownPaymentToSupplier_Chart_Periodically("days");

    }

    protected void lnkdownPaymentToSupplierWeek_Click(object sender, EventArgs e)
    {
        GetDownPaymentToSupplier_Chart_Periodically("Week");
    }

    protected void lnkdownPaymentToSupplierMonth_Click(object sender, EventArgs e)
    {
        GetDownPaymentToSupplier_Chart_Periodically("month");

    }

    protected void lnkdownPaymentToSupplierQuarter_Click(object sender, EventArgs e)
    {
        GetDownPaymentToSupplier_Chart_Periodically("Quarter");
    }

    protected void lnkdownPaymentToSupplierYear_Click(object sender, EventArgs e)
    {
        GetDownPaymentToSupplier_Chart_Periodically("Year");
    }

    protected void lnkPaymentFromCustomerDay_Click(object sender, EventArgs e)
    {
        GetPaymentFromCustomer_Chart_Periodically("days");
    }

    protected void lnkPaymentFromCustomerWeek_Click(object sender, EventArgs e)
    {
        GetPaymentFromCustomer_Chart_Periodically("Week");

    }

    protected void lnkPaymentFromCustomerMonth_Click(object sender, EventArgs e)
    {
        GetPaymentFromCustomer_Chart_Periodically("month");
    }

    protected void lnkPaymentFromCustomerYear_Click(object sender, EventArgs e)
    {
        GetPaymentFromCustomer_Chart_Periodically("Year");
    }

    protected void lnkPaymentFromCustomerQuarter_Click(object sender, EventArgs e)
    {
        GetPaymentFromCustomer_Chart_Periodically("Quarter");
    }

    protected void lnkPaymentToEmployeeDay_Click(object sender, EventArgs e)
    {
        GetPaymentToEmployee_Chart_Periodically("days");
    }

    protected void lnkPaymentToEmployeeWeek_Click(object sender, EventArgs e)
    {
        GetPaymentToEmployee_Chart_Periodically("Week");
    }

    protected void lnkPaymentToEmployeeMonth_Click(object sender, EventArgs e)
    {
        GetPaymentToEmployee_Chart_Periodically("month");
    }

    protected void lnkPaymentToEmployeeQuarter_Click(object sender, EventArgs e)
    {
        GetPaymentToEmployee_Chart_Periodically("Quarter");

    }

    protected void lnkPaymentToEmployeeYear_Click(object sender, EventArgs e)
    {
        GetPaymentToEmployee_Chart_Periodically("Year");

    }
}




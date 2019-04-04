using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ChartBAL
/// </summary>
public class ChartBAL
{
    ChartDAL chartDAL = new ChartDAL();
    ChartUI chartUI = new ChartUI();
    public ChartBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region Down Payment From Customer
    public DataTable GetDownPaymentFromCustomer_Posting_Status()
    {
        DataTable dtb = new DataTable();
        dtb = chartDAL.GetDownPaymentFromCustomer_Posting_Status();
        return dtb;
    }
    public DataSet GetDownPaymentFromCustomer_Posting_On_Status()
    {
        DataSet dts = new DataSet();
        dts = chartDAL.GetDownPaymentFromCustomer_Posting_On_Status();
        return dts;
    }
    public DataSet GetDownPaymentFromCustomer_Chart_Periodically(ChartUI chartUI)
    {
        DataSet dts = new DataSet();
        dts = chartDAL.GetDownPaymentFromCustomer_Chart_Periodically(chartUI);
        return dts;
    }
    #endregion  Down Payment From Customer

    #region DownPaymentToSupplier 
    public DataTable GetDownPaymentToSupplier_Chart_Posting_On_Status(ChartUI chartUI)
    {
        DataTable dtb = new DataTable();
        dtb = chartDAL.GetDownPaymentToSupplier_Chart_Posting_On_Status(chartUI);
        return dtb;
    }

    public DataSet GetDownPaymentToSupplier_Chart_BasedOnPayment_Mode()
    {
        DataSet dts = new DataSet();
        dts = chartDAL.GetDownPaymentToSupplier_Chart_BasedOnPayment_Mode();
        return dts;
    }

    public DataSet GetDownPaymentToSupplier_Chart_Periodically(ChartUI chartUI)
    {
        DataSet dts = new DataSet();
        dts = chartDAL.GetDownPaymentToSupplier_Chart_Periodically(chartUI);
        return dts;
    }
    #endregion

    #region PaymentFromCustomer
    public DataTable GetPaymentFromCustomer_Chart_Posting_On_Status(ChartUI chartUI)
    {
        DataTable dtb = new DataTable();
        dtb = chartDAL.GetPaymentFromCustomer_Posting_On_Status(chartUI);
        return dtb;
    }
    public DataSet GetPaymentFromCustomer_Chart_BasedOnPayment_Mode(ChartUI chartUI)
    {
        DataSet dts = new DataSet();
        dts = chartDAL.GetPaymentFromCustomer_Chart_Periodically(chartUI);
        return dts;
    }
    public DataSet GetPaymentFromCustomer_Chart_Periodically(ChartUI chartUI)
    {
        DataSet dts = new DataSet();
        dts = chartDAL.GetPaymentFromCustomer_Chart_Periodically(chartUI);
        return dts;
    }

    #endregion

    #region Payment To Supplier Employee    
    public DataSet GetPaymentToSupplierEmployee_Periodically(ChartUI chartUI)
    {
        DataSet dts = new DataSet();
        dts = chartDAL.GetPaymentToSupplierEmployee_Periodically(chartUI);
        return dts;
    }

    public DataSet GetPaymentToSupplierEmployee_BasedOnPayment_Mode(ChartUI chartUI)
    {
        DataSet dts = new DataSet();
        dts = chartDAL.GetPaymentToSupplierEmployee_BasedOnPayment_Mode(chartUI);
        return dts;
       }
    public DataTable GetPaymentToSupplierEmployee_Chart_PostingOnStatus(ChartUI chartUI)
    {
        DataTable dtb = new DataTable();
        dtb = chartDAL.GetPaymentToSupplierEmployee_Chart_PostingOnStatus(chartUI);
        return dtb;
    }
    #endregion

    #region Customer Invoice Process
    public DataSet GetCustomerInvoiceProcess_Chart_Periodically(ChartUI chartUI)
    {
        DataSet dts = new DataSet();
        dts = chartDAL.GetCustomerInvoiceProcess_Chart_Periodically(chartUI);
        return dts;
    }

    public DataSet GetCustomerInvoiceProcess_Chart_BasedOnPaymentMode(ChartUI chartUI)
    {
        DataSet dts = new DataSet();
        dts = chartDAL.GetCustomerInvoiceProcess_Chart_BasedOnPaymentMode(chartUI);
        return dts;
    }

    public DataTable GetCustomerInvoiceProcess_Chart_PostingOnStatus(ChartUI chartUI)
    {
        DataTable dtb = new DataTable();
        dtb = chartDAL.GetCustomerInvoiceProcess_Chart_PostingOnStatus(chartUI);
        return dtb;
    }
    #endregion

    #region SupplierEmployeeGeneralExpenses
    public DataSet GetSupplierEmployeeGeneralExpenses_Chart_Periodically(ChartUI chartUI)
    {
        DataSet dts = new DataSet();
        dts = chartDAL.GetSupplierEmployeeGeneralExpenses_Chart_Periodically(chartUI);
        return dts;
    }

    public DataSet GetSupplierEmployeeGeneralExpenses_Chart_BasedOnPaymentMode(ChartUI chartUI)
    {
        DataSet dts = new DataSet();
        dts = chartDAL.GetSupplierEmployeeGeneralExpenses_Chart_BasedOnPaymentMode(chartUI);
        return dts;
    }

    public DataTable GetSupplierEmployeeGeneralExpenses_Chart_PostingOnStatus(ChartUI chartUI)
    {
        DataTable dtb = new DataTable();
        dtb = chartDAL.GetSupplierEmployeeGeneralExpenses_Chart_PostingOnStatus(chartUI);
        return dtb;
    }

    #endregion

    #region NonPOBasedInvoice

    public DataSet GetNonPOBasedInvoice_Chart_Periodically(ChartUI chartUI)
    {
        DataSet dts = new DataSet();
        dts = chartDAL.GetNonPOBasedInvoice_Chart_Periodically(chartUI);
        return dts;
    }

    public DataSet GetNonPOBasedInvoice_Chart_BasedOnPaymentMode(ChartUI chartUI)
    {
        DataSet dts = new DataSet();
        dts = chartDAL.GetNonPOBasedInvoice_Chart_BasedOnPaymentMode(chartUI);
        return dts;
    }

    public DataTable GetNonPOBasedInvoice_Chart_PostingOnStatus(ChartUI chartUI)
    {
        DataTable dtb = new DataTable();
        dtb = chartDAL.GetNonPOBasedInvoice_Chart_PostingOnStatus (chartUI);
        return dtb;
    }
    #endregion
    #region PaymentToSupplier
    public DataSet GetPaymentToSupplier_Chart_Periodically(ChartUI chartUI)
    {
        DataSet dts = new DataSet();
        dts = chartDAL.GetPaymentToSupplier_Chart_Periodically(chartUI);
        return dts;
    }

    public DataSet GetPaymentToSupplier_Chart_BasedOnPaymentMode(ChartUI chartUI)
    {
        DataSet dts = new DataSet();
        dts = chartDAL.GetPaymentToSupplier_Chart_BasedOnPaymentMode(chartUI);
        return dts;
    }

    public DataTable GetPaymentToSupplier_Chart_PostingOnStatus(ChartUI chartUI)
    {
        DataTable dtb = new DataTable();
        dtb = chartDAL.GetPaymentToSupplier_Chart_PostingOnStatus(chartUI);
        return dtb;
    }
    #endregion

    #region EmployeeGeneralExpenses
    public DataSet GetEmployeeGeneralExpenses_Chart_Periodically(ChartUI chartUI)
    {
        DataSet dts = new DataSet();
        dts = chartDAL.GetPaymentToSupplier_Chart_Periodically(chartUI);
        return dts;
    }

    public DataSet GetEmployeeGeneralExpenses_Chart_BasedOnPaymentMode(ChartUI chartUI)
    {
        DataSet dts = new DataSet();
        dts = chartDAL.GetEmployeeGeneralExpenses_Chart_BasedOnPaymentMode(chartUI);
        return dts;
    }

    public DataTable GetEmployeeGeneralExpenses_Chart_PostingOnStatus(ChartUI chartUI)
    {
        DataTable dtb = new DataTable();
        dtb = chartDAL.GetEmployeeGeneralExpenses_Chart_PostingOnStatus(chartUI);
        return dtb;
    }
    #endregion

    #region paymentToEmployee

    public DataSet GetPaymentToEmployee_Chart_Periodically(ChartUI chartUI)
    {
        DataSet dts = new DataSet();
        dts = chartDAL.GetPaymentToEmployee_Chart_Periodically(chartUI);
        return dts;
    }

    public DataSet GetPaymentToEmployee_Chart_BasedOnPaymentMode(ChartUI chartUI)
    {
        DataSet dts = new DataSet();
        dts = chartDAL.GetPaymentToEmployee_Chart_BasedOnPaymentMode(chartUI);
        return dts;
    }

    public DataTable GetPaymentToEmployee_Chart_PostingOnStatus(ChartUI chartUI)
    {
        DataTable dtb = new DataTable();
        dtb = chartDAL.GetPaymentToEmployee_Chart_PostingOnStatus(chartUI);
        return dtb;
    }

    #endregion

}
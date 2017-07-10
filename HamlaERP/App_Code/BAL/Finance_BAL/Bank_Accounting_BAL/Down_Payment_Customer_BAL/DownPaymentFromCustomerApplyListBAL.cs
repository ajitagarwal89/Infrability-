using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for DownPaymentFromCustomerApplyListBAL
/// </summary>
public class DownPaymentFromCustomerApplyListBAL
{
    DownPaymentFromCustomerApplyListDAL downPaymentFromCustomerApplyListDAL = new DownPaymentFromCustomerApplyListDAL();
    public DownPaymentFromCustomerApplyListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetDownPaymentFromCustomerApplyList()
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentFromCustomerApplyListDAL.GetDownPaymentFromCustomerApplyList();
        return dtb;
    }
    public DataTable GetDownPaymentFromCustomerApplyListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentFromCustomerApplyListDAL.GetDownPaymentFromCustomerApplyListForExportToExcel();
        return dtb;
    }
    public DataTable GetDownPaymentFromCustomerApplyListById(DownPaymentFromCustomerApplyListUI downPaymentFromCustomerApplyListUI)
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentFromCustomerApplyListDAL.GetDownPaymentFromCustomerApplyListById(downPaymentFromCustomerApplyListUI);
        return dtb;
    }

    public DataTable GetDownPaymentFromCustomerApplyListBySearchParameters(DownPaymentFromCustomerApplyListUI downPaymentFromCustomerApplyListUI)
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentFromCustomerApplyListDAL.GetDownPaymentFromCustomerApplyListBySearchParameters(downPaymentFromCustomerApplyListUI);
        return dtb;
    }

    public DataTable GetDownPaymentFromCustomerApplyListByDownPaymentFromCustomerId(DownPaymentFromCustomerApplyListUI downPaymentFromCustomerApplyListUI)
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentFromCustomerApplyListDAL.GetDownPaymentFromCustomerApplyListByDownPaymentFromCustomerId(downPaymentFromCustomerApplyListUI);
        return dtb;
    }

    public int DeleteDownPaymentFromCustomerApply(DownPaymentFromCustomerApplyListUI downPaymentFromCustomerApplyListUI)
    {
        int result = 0;
        result = downPaymentFromCustomerApplyListDAL.DeleteDownPaymentFromCustomerApply(downPaymentFromCustomerApplyListUI);
        return result;
    }
}
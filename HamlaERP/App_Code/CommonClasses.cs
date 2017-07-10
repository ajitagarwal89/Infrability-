using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using log4net;

public class CommonClasses
{
    #region Data Members
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    FiscalPeriodDetailsListBAL fiscalPeriodDetailsListBAL = new FiscalPeriodDetailsListBAL();
    BankListUI bankListUI = new BankListUI();
    #endregion Data Members

    public CommonClasses()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void IsPostingEnabled(string Module, DateTime date, int fiscalYear)
    {

    }

    private void BindBankListBySearchParameters(FiscalPeriodDetailsListUI fiscalPeriodDetailsListUI)
    {
        try
        {
            DataTable dtb = fiscalPeriodDetailsListBAL.GetFiscalPeriodDetailsListById(fiscalPeriodDetailsListUI);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                //gvData.DataSource = dtb;
                //gvData.DataBind();
                //divError.Visible = false;
            }
            else
            {
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "BindBankListBySearchParameters()";
            logExcpUIobj.ResourceName = "System_Settings_BankList.CS";
            logExcpUIobj.RecordId = "All";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_BankList : BindBankListBySearchParameters] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

    }

}
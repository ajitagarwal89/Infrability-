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

    public const string AUDIT_HISTORY_LINK = "System_Settings/Audit/";
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

    public DateTime DateFormatMMDDYYY(DateTime dateParaInDDmmYYYY)
    {
        DateTime fomatedDate = new DateTime();

        string[] dateFormats = dateParaInDDmmYYYY.GetDateTimeFormats();

        fomatedDate = Convert.ToDateTime(dateFormats[6]);
        return fomatedDate;
    }

    public int MaxLength(int length)
    {
        int maxLength = 0;

        if (length == 1)
            maxLength = 9;
        else if (length == 2)
            maxLength = 99;
        else if (length == 3)
            maxLength = 999;
        else if (length == 4)
            maxLength = 9999;
        else if (length == 5)
            maxLength = 99999;
        else if (length == 6)
            maxLength = 999999;
        else if (length == 7)
            maxLength = 9999999;
        else if (length == 8)
            maxLength = 99999999;
        else if (length == 9)
            maxLength = 999999999;

        return maxLength;
    }
}
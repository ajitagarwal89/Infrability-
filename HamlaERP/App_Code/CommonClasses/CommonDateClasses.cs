using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;


/// <summary>
/// Summary description for ConvertDate
/// </summary>
/// 

public class CommonDateClasses : Page
{
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    System.Globalization.CultureInfo enGB = new System.Globalization.CultureInfo("en-GB");
    System.Globalization.CultureInfo arSA = new System.Globalization.CultureInfo("ar-SA");

    public CommonDateClasses()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string DateInTextBox(string value)
    {
        string dateString = string.Empty;
        try
        {
            var dateValue = DateTime.Parse(value);
            dateString = dateValue.ToString("dd/MM/yyyy");
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "dateInTextBox()";
            logExcpUIobj.ResourceName = "CommonClasses.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CommonClasses : dateInTextBox] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

        return dateString;
    }

    public string DateInMMDDYYBox(string value)
    {
        string dateString = string.Empty;
        try
        {
            var dateValue = DateTime.Parse(value);
            dateString = dateValue.ToString("MM/dd/yyyy");
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DateInMMDDYYBox()";
            logExcpUIobj.ResourceName = "CommonClasses.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CommonClasses : DateInMMDDYYBox] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }

        return dateString;
    }

    public string DateToInt(string txtBoxDate)  //Input should be dd/mm/yyyy
    {

        DateTime Dt = DateTime.ParseExact(txtBoxDate, "d/M/yyyy", enGB);

        string month = Dt.Month.ToString();
        if (month.Length == 1)
            month = "0" + month;

        string day = Dt.Day.ToString();
        if (day.Length == 1)
            day = "0" + day;

        string StrDt = Convert.ToString(Dt.Year.ToString() + month + day);

        return StrDt;   //Output will be yyyymmdd i.e., 20111219
    }

    public string GetYearFromDate(string txtBoxDate)  //Input should be dd/mm/yyyy
    {
        DateTime Dt = DateTime.ParseExact(txtBoxDate, "d/M/yyyy", enGB);
        string year = Convert.ToString(Dt.Year);
        return year;   //Output will be yyyy i.e., 2011
    }

    public string GetMonthFromDate(string txtBoxDate)  //Input should be dd/mm/yyyy
    {
        DateTime Dt = DateTime.ParseExact(txtBoxDate, "d/M/yyyy", enGB);

        string month = Convert.ToString(Dt.Month);
        if (month.Length == 1)
            month = "0" + month;

        return month;   //Output will be mm i.e., 01 to 12
    }

    public string GetDayFromDate(string txtBoxDate)  //Input should be dd/mm/yyyy
    {
        DateTime Dt = DateTime.ParseExact(txtBoxDate, "d/M/yyyy", enGB);

        string day = Convert.ToString(Dt.Day);
        if (day.Length == 1)
            day = "0" + day;

        return day;   //Output will be mm i.e., 01 to 31
    }

    public DateTime DateToDate(string txtBoxDate)   //Input should be dd/mm/yyyy
    {
        DateTime Dt = DateTime.ParseExact(txtBoxDate, "d/M/yyyy", enGB);
        return Dt;
    }

    public string IntToDate(string IntDate)    //Input should be yyyymmdd i.e., 20111025
    {
        string year = IntDate.Substring(0, 4);
        string month = IntDate.Substring(4, 2);
        string day = IntDate.Substring(6, 2);
        string StrDt = string.Empty;

        string str = Convert.ToString(Session["Language"]);
        int Calendar = Convert.ToInt32(Session["Calendar"]);

        //if (str == "ar-SA")
        if (Calendar == 2)
        {
            StrDt = day + "/" + month + "/" + year;
            DateTime Dt = Convert.ToDateTime(StrDt, arSA.DateTimeFormat);
            StrDt = Dt.ToShortDateString();
            //StrDt = Dt.ToString("dd/MM/yyyy");
        }
        else
        {
            StrDt = day + "/" + month + "/" + year;
            DateTime Dt = DateTime.ParseExact(StrDt, "dd/MM/yyyy", enGB.DateTimeFormat);
            StrDt = Dt.ToShortDateString();
            //StrDt = Dt.ToString("dd/MM/yyyy");

        }
        return StrDt;   //Output will be dd/mm/yyyy
    }

    public string GetYearFromInt(string IntDate)    //Input should be yyyymmdd i.e., 20111025
    {
        string year = IntDate.Substring(0, 4);
        return year;    //Output will be yyyy i.e., 2011
    }

    public string GetMonthFromInt(string IntDate)    //Input should be yyyymmdd i.e., 20111025
    {
        string month = IntDate.Substring(4, 2);
        return month;    //Output will be mm i.e., 01 to 12
    }

    public string GetDayFromInt(string IntDate)    //Input should be yyyymmdd i.e., 20111025
    {
        string day = IntDate.Substring(6, 2);
        return day;    //Output will be mm i.e., 01 to 31
    }
}

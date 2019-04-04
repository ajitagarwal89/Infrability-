using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for OptionSet_L2ListBAL
/// </summary>
public class OptionSet_L2ListBAL
{
    OptionSet_L2ListDAL optionSet_L2ListDAL = new OptionSet_L2ListDAL();
    OptionSetListDAL optionSetListDAL = new OptionSetListDAL();
    public OptionSet_L2ListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetOptionSet_L2List()
    {
        DataTable dtb = new DataTable();
        dtb = optionSet_L2ListDAL.GetOptionSet_L2List();
        return dtb;
    }

    public DataTable GetOptionSet_L2ListById(OptionSet_L2ListUI optionSet_L2ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = optionSet_L2ListDAL.GetOptionSet_L2ListById(optionSet_L2ListUI);
        return dtb;
    }

    public DataTable GetOptionSet_L2ListBySearchParameters(OptionSet_L2ListUI optionSet_L2ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = optionSet_L2ListDAL.GetOptionSet_L2ListBySearchParameters(optionSet_L2ListUI);
        return dtb;
    }
    public int DeleteOptionSet_L2(OptionSet_L2ListUI optionSet_L2ListUI)
    {
        int result = 0;
        result = optionSet_L2ListDAL.DeleteOptionSet_L2(optionSet_L2ListUI);
        return result;
    }
    public DataTable GetOptionSet_L2ListByOptionSetName(OptionSetListUI optionSetListUI)
    {
        DataTable dtb = new DataTable();
        dtb = optionSetListDAL.GetOptionSetListByOptionSetName(optionSetListUI);
        return dtb;
    }
    public DataTable GetOptionSet_L2ListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = optionSet_L2ListDAL.GetOptionSet_L2ListForExportToExcel();
        return dtb;
    }
}
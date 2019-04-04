using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for OptionSet_L3ListBAL
/// </summary>
public class OptionSet_L3ListBAL
{
    OptionSet_L3ListDAL optionSet_L3ListDAL = new OptionSet_L3ListDAL();
    OptionSetListDAL optionSetListDAL = new OptionSetListDAL();
    public OptionSet_L3ListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetOptionSet_L3List()
    {
        DataTable dtb = new DataTable();
        dtb = optionSet_L3ListDAL.GetOptionSet_L3List();
        return dtb;
    }

    public DataTable GetOptionSet_L3ListById(OptionSet_L3ListUI optionSet_L3ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = optionSet_L3ListDAL.GetOptionSet_L3ListById(optionSet_L3ListUI);
        return dtb;
    }

    public DataTable GetOptionSet_L3ListBySearchParameters(OptionSet_L3ListUI optionSet_L3ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = optionSet_L3ListDAL.GetOptionSet_L3ListBySearchParameters(optionSet_L3ListUI);
        return dtb;
    }
    public int DeleteOptionSet_L3(OptionSet_L3ListUI optionSet_L3ListUI)
    {
        int result = 0;
        result = optionSet_L3ListDAL.DeleteOptionSet_L3(optionSet_L3ListUI);
        return result;
    }
    public DataTable GetOptionSet_L3ListByOptionSetName(OptionSetListUI optionSetListUI)
    {
        DataTable dtb = new DataTable();
        dtb = optionSetListDAL.GetOptionSetListByOptionSetName(optionSetListUI);
        return dtb;
    }
    public DataTable GetOptionSet_L3ListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = optionSet_L3ListDAL.GetOptionSet_L3ListForExportToExcel();
        return dtb;
    }
}
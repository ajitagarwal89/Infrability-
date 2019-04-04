using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for OptionSet_L1ListBAL
/// </summary>
public class OptionSet_L1ListBAL
{
    OptionSet_L1ListDAL optionSet_L1ListDAL = new OptionSet_L1ListDAL();
    OptionSetListDAL optionSetListDAL = new OptionSetListDAL();

    public OptionSet_L1ListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetOptionSet_L1List()
    {
        DataTable dtb = new DataTable();
        dtb = optionSet_L1ListDAL.GetOptionSet_L1List();
        return dtb;
    }

    public DataTable GetOptionSet_L1ListById(OptionSet_L1ListUI optionSet_L1ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = optionSet_L1ListDAL.GetOptionSet_L1ListById(optionSet_L1ListUI);
        return dtb;
    }

    public DataTable GetOptionSet_L1ListByOptionsetId(OptionSet_L1ListUI optionSet_L1ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = optionSet_L1ListDAL.GetOptionSet_L1ListByOptionsetId(optionSet_L1ListUI);
        return dtb;
    }    

    public DataTable GetOptionSet_L1ListBySearchParameters(OptionSet_L1ListUI optionSet_L1ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = optionSet_L1ListDAL.GetOptionSet_L1ListBySearchParameters(optionSet_L1ListUI);
        return dtb;
    }

    public int DeleteOptionSet_L1(OptionSet_L1ListUI optionSet_L1ListUI)
    {
        int result = 0;
        result = optionSet_L1ListDAL.DeleteOptionSet_L1(optionSet_L1ListUI);
        return result;
    }

    public DataTable GetOptionSet_L1ListByOptionSetName(OptionSetListUI optionSetListUI)
    {
        DataTable dtb = new DataTable();
        dtb = optionSetListDAL.GetOptionSetListByOptionSetName(optionSetListUI);
        return dtb;
    }
}
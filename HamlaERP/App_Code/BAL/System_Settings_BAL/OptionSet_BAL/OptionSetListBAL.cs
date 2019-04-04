using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for OptionSetListBLL
/// </summary>
public class OptionSetListBAL
{
    OptionSetListDAL optionSetListDAL = new OptionSetListDAL();

    public OptionSetListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetOptionSetList()
    {
        DataTable dtb = new DataTable();
        dtb = optionSetListDAL.GetOptionSetList();
        return dtb;
    }

    public DataTable GetOptionSetListById(OptionSetListUI optionSetListUI)
    {
        DataTable dtb = new DataTable();
        dtb = optionSetListDAL.GetOptionSetListById(optionSetListUI);
        return dtb;
    }

    public DataTable GetOptionSetListBySearchParameters(OptionSetListUI optionSetListUI)
    {
        DataTable dtb = new DataTable();
        dtb = optionSetListDAL.GetOptionSetListBySearchParameters(optionSetListUI);
        return dtb;
    }

    public DataTable GetOptionSetListByOptionSetName(OptionSetListUI optionSetListUI)
    {
        DataTable dtb = new DataTable();
        dtb = optionSetListDAL.GetOptionSetListByOptionSetName(optionSetListUI);
        return dtb;
    }

    public int DeleteOptionSet(OptionSetListUI optionSetListUI)
    {
        int result = 0;
        result = optionSetListDAL.DeleteOptionSet(optionSetListUI);
        return result;
    }

    public DataTable GetColumnByTablesList(OptionSetListUI optionSetListUI)
    {
        DataTable dtb = new DataTable();
        dtb = optionSetListDAL.GetColumnByTablesList(optionSetListUI);
        return dtb;
    }

    public DataTable GetTableList()
    {
        DataTable dtb = new DataTable();
        dtb = optionSetListDAL.GetTableList();
        return dtb;
    }


}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for OptionSet_L3FormBAL
/// </summary>
public class OptionSet_L3FormBAL
{
    OptionSet_L3FormDAL optionSet_L3FormDAL = new OptionSet_L3FormDAL();
    public OptionSet_L3FormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetOptionSet_L3ListById(OptionSet_L3FormUI optionSet_L3FormUI)
    {
        DataTable dtb = new DataTable();
        dtb = optionSet_L3FormDAL.GetOptionSet_L3ListById(optionSet_L3FormUI);
        return dtb;
    }

    public int AddOptionSet_L3(OptionSet_L3FormUI optionSet_L3FormUI)
    {
        int resutl = 0;
        resutl = optionSet_L3FormDAL.AddOptionSet_L3(optionSet_L3FormUI);
        return resutl;
    }

    public int UpdateOptionSet_L3(OptionSet_L3FormUI optionSet_L3FormUI)
    {
        int resutl = 0;
        resutl = optionSet_L3FormDAL.UpdateOptionSet_L3(optionSet_L3FormUI);
        return resutl;
    }

    public int DeleteOptionSet_L3(OptionSet_L3FormUI optionSet_L3FormUI)
    {
        int resutl = 0;
        resutl = optionSet_L3FormDAL.DeleteOptionSet_L3(optionSet_L3FormUI);
        return resutl;
    }
}

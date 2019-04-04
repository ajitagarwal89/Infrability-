using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for OptionSet_L2FormBAL
/// </summary>
public class OptionSet_L2FormBAL
{
    OptionSet_L2FormDAL optionSet_L2FormDAL = new OptionSet_L2FormDAL();
    public OptionSet_L2FormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetOptionSet_L2ListById(OptionSet_L2FormUI optionSet_L2FormUI)
    {
        DataTable dtb = new DataTable();
        dtb = optionSet_L2FormDAL.GetOptionSet_L2ListById(optionSet_L2FormUI);
        return dtb;
    }

    public int AddOptionSet_L2(OptionSet_L2FormUI optionSet_L2FormUI)
    {
        int resutl = 0;
        resutl = optionSet_L2FormDAL.AddOptionSet_L2(optionSet_L2FormUI);
        return resutl;
    }

    public int UpdateOptionSet_L2(OptionSet_L2FormUI optionSet_L2FormUI)
    {
        int resutl = 0;
        resutl = optionSet_L2FormDAL.UpdateOptionSet_L2(optionSet_L2FormUI);
        return resutl;
    }

    public int DeleteOptionSet_L2(OptionSet_L2FormUI optionSet_L2FormUI)
    {
        int resutl = 0;
        resutl = optionSet_L2FormDAL.DeleteOptionSet_L2(optionSet_L2FormUI);
        return resutl;
    }
}
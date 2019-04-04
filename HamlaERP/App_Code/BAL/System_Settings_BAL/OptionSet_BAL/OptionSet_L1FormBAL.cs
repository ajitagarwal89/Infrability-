using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for OptionSet_L1FormBAL
/// </summary>
public class OptionSet_L1FormBAL
{
    OptionSet_L1FormDAL optionSet_L1FormDAL = new OptionSet_L1FormDAL();
    public OptionSet_L1FormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetOptionSet_L1ListById(OptionSet_L1FormUI optionSet_L1FormUI)
    {
        DataTable dtb = new DataTable();
        dtb = optionSet_L1FormDAL.GetOptionSet_L1ListById(optionSet_L1FormUI);
        return dtb;
    }

    public int AddOptionSet_L1(OptionSet_L1FormUI optionSet_L1FormUI)
    {
        int resutl = 0;
        resutl = optionSet_L1FormDAL.AddOptionSet_L1(optionSet_L1FormUI);
        return resutl;
    }

    public int UpdateOptionSet_L1(OptionSet_L1FormUI optionSet_L1FormUI)
    {
        int resutl = 0;
        resutl = optionSet_L1FormDAL.UpdateOptionSet_L1(optionSet_L1FormUI);
        return resutl;
    }

    public int DeleteOptionSet_L1(OptionSet_L1FormUI optionSet_L1FormUI)
    {
        int resutl = 0;
        resutl = optionSet_L1FormDAL.DeleteOptionSet_L1(optionSet_L1FormUI);
        return resutl;
    }
}
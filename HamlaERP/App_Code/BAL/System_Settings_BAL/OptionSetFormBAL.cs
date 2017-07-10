using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for OptionSetFormBLL
/// </summary>
public class OptionSetFormBAL
{
    OptionSetFormDAL optionSetFormDAL = new OptionSetFormDAL();

	public OptionSetFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetOptionSetListById(OptionSetFormUI optionSetFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = optionSetFormDAL.GetOptionSetListById(optionSetFormUI);
        return dtb;
    }

    public int AddOptionSet(OptionSetFormUI optionSetFormUI)
    {
        int resutl = 0;
        resutl = optionSetFormDAL.AddOptionSet(optionSetFormUI);
        return resutl;
    }

    public int UpdateOptionSet(OptionSetFormUI optionSetFormUI)
    {
        int resutl = 0;
        resutl = optionSetFormDAL.UpdateOptionSet(optionSetFormUI);
        return resutl;
    }

    public int DeleteOptionSet(OptionSetFormUI optionSetFormUI)
    {
        int resutl = 0;
        resutl = optionSetFormDAL.DeleteOptionSet(optionSetFormUI);
        return resutl;
    }
}
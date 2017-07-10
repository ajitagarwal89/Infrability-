using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for GLAccountEntryFormBLL
/// </summary>
public class GLAccountEntryFormBAL
{
    GLAccountEntryFormDAL gLAccountEntryFormDAL = new GLAccountEntryFormDAL();

	public GLAccountEntryFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetGLAccountEntryListById(GLAccountEntryFormUI gLAccountEntryFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountEntryFormDAL.GetGLAccountEntryListById(gLAccountEntryFormUI);
        return dtb;
    }

    public int AddGLAccountEntry(GLAccountEntryFormUI gLAccountEntryFormUI)
    {
        int resutl = 0;
        resutl = gLAccountEntryFormDAL.AddGLAccountEntry(gLAccountEntryFormUI);
        return resutl;
    }

    public int UpdateGLAccountEntry(GLAccountEntryFormUI gLAccountEntryFormUI)
    {
        int resutl = 0;
        resutl = gLAccountEntryFormDAL.UpdateGLAccountEntry(gLAccountEntryFormUI);
        return resutl;
    }

    public int DeleteGLAccountEntry(GLAccountEntryFormUI gLAccountEntryFormUI)
    {
        int resutl = 0;
        resutl = gLAccountEntryFormDAL.DeleteGLAccountEntry(gLAccountEntryFormUI);
        return resutl;
    }
}
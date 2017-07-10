using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for GLAccountEntryFormBLL
/// </summary>
public class GLAccountEntryDetailsFormBAL
{
    GLAccountEntryDetailsFormDAL gLAccountEntryDetailsFormDAL = new GLAccountEntryDetailsFormDAL();

	public GLAccountEntryDetailsFormBAL()
	{
		
	}

    public DataTable GetGLAccountEntryDetailsListById(GLAccountEntryDetailsFormUI gLAccountEntryDetailsFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountEntryDetailsFormDAL.GetGLAccountEntryDetailsListById(gLAccountEntryDetailsFormUI);
        return dtb;
    }

    public int AddGLAccountEntryDetails(GLAccountEntryDetailsFormUI gLAccountEntryDetailsFormUI)
    {
        int resutl = 0;
        resutl = gLAccountEntryDetailsFormDAL.AddGLAccountEntryDetails(gLAccountEntryDetailsFormUI);
        return resutl;
    }

    public int UpdateGLAccountEntryDetails(GLAccountEntryDetailsFormUI gLAccountEntryDetailsFormUI)
    {
        int resutl = 0;
        resutl = gLAccountEntryDetailsFormDAL.UpdateGLAccountEntryDetails(gLAccountEntryDetailsFormUI);
        return resutl;
    }

    public int DeleteGLAccountEntryDetails(GLAccountEntryDetailsFormUI gLAccountEntryDetailsFormUI)
    {
        int resutl = 0;
        resutl = gLAccountEntryDetailsFormDAL.DeleteGLAccountEntryDetails(gLAccountEntryDetailsFormUI);
        return resutl;
    }
}
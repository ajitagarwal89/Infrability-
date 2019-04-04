using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for GLAccountSummaryFormBLL
/// </summary>
public class GLAccountSummaryFormBAL
{
    GLAccountSummaryFormDAL gLAccountSummaryFormDAL = new GLAccountSummaryFormDAL();

	public GLAccountSummaryFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetGLAccountSummaryListById(GLAccountSummaryFormUI gLAccountSummaryFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountSummaryFormDAL.GetGLAccountSummaryListById(gLAccountSummaryFormUI);
        return dtb;
    }

    public int AddGLAccountSummary(GLAccountSummaryFormUI gLAccountSummaryFormUI)
    {
        int resutl = 0;
        resutl = gLAccountSummaryFormDAL.AddGLAccountSummary(gLAccountSummaryFormUI);
        return resutl;
    }

    public int UpdateGLAccountSummary(GLAccountSummaryFormUI gLAccountSummaryFormUI)
    {
        int resutl = 0;
        resutl = gLAccountSummaryFormDAL.UpdateGLAccountSummary(gLAccountSummaryFormUI);
        return resutl;
    }

    public int DeleteGLAccountSummary(GLAccountSummaryFormUI gLAccountSummaryFormUI)
    {
        int resutl = 0;
        resutl = gLAccountSummaryFormDAL.DeleteGLAccountSummary(gLAccountSummaryFormUI);
        return resutl;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for GLAccountSummaryDetailsFormBLL
/// </summary>
public class GLAccountSummaryDetailsFormBAL
{
    GLAccountSummaryDetailsFormDAL gLAccountSummaryDetailsFormDAL = new GLAccountSummaryDetailsFormDAL();

	public GLAccountSummaryDetailsFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetGLAccountSummaryDetailsListById(GLAccountSummaryDetailsFormUI gLAccountSummaryDetailsFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountSummaryDetailsFormDAL.GetGLAccountSummaryDetailsListById(gLAccountSummaryDetailsFormUI);
        return dtb;
    }

    public int AddGLAccountSummaryDetails(GLAccountSummaryDetailsFormUI gLAccountSummaryDetailsFormUI)
    {
        int resutl = 0;
        resutl = gLAccountSummaryDetailsFormDAL.AddGLAccountSummaryDetails(gLAccountSummaryDetailsFormUI);
        return resutl;
    }

    public int UpdateGLAccountSummaryDetails(GLAccountSummaryDetailsFormUI gLAccountSummaryDetailsFormUI)
    {
        int resutl = 0;
        resutl = gLAccountSummaryDetailsFormDAL.UpdateGLAccountSummaryDetails(gLAccountSummaryDetailsFormUI);
        return resutl;
    }

    public int DeleteGLAccountSummaryDetails(GLAccountSummaryDetailsFormUI gLAccountSummaryDetailsFormUI)
    {
        int resutl = 0;
        resutl = gLAccountSummaryDetailsFormDAL.DeleteGLAccountSummaryDetails(gLAccountSummaryDetailsFormUI);
        return resutl;
    }
}
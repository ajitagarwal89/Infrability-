using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for GLAccountBudgetDetailsFormBLL
/// </summary>
public class GLAccountBudgetDetailsFormBAL
{
    GLAccountBudgetDetailsFormDAL gLAccountBudgetDetailsFormDAL = new GLAccountBudgetDetailsFormDAL();

	public GLAccountBudgetDetailsFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetGLAccountBudgetDetailsListById(GLAccountBudgetDetailsFormUI gLAccountBudgetDetailsFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountBudgetDetailsFormDAL.GetGLAccountBudgetDetailsListById(gLAccountBudgetDetailsFormUI);
        return dtb;
    }

    public int AddGLAccountBudgetDetails(GLAccountBudgetDetailsFormUI gLAccountBudgetDetailsFormUI)
    {
        int resutl = 0;
        resutl = gLAccountBudgetDetailsFormDAL.AddGLAccountBudgetDetails(gLAccountBudgetDetailsFormUI);
        return resutl;
    }

    public int UpdateGLAccountBudgetDetails(GLAccountBudgetDetailsFormUI gLAccountBudgetDetailsFormUI)
    {
        int resutl = 0;
        resutl = gLAccountBudgetDetailsFormDAL.UpdateGLAccountBudgetDetails(gLAccountBudgetDetailsFormUI);
        return resutl;
    }

    public int DeleteGLAccountBudgetDetails(GLAccountBudgetDetailsFormUI gLAccountBudgetDetailsFormUI)
    {
        int resutl = 0;
        resutl = gLAccountBudgetDetailsFormDAL.DeleteGLAccountBudgetDetails(gLAccountBudgetDetailsFormUI);
        return resutl;
    }
}
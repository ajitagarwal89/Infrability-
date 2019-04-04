using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for GLAccountBudgetFormBLL
/// </summary>
public class GLAccountBudgetFormBAL
{
    GLAccountBudgetFormDAL gLAccountBudgetFormDAL = new GLAccountBudgetFormDAL();

	public GLAccountBudgetFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetGLAccountBudgetListById(GLAccountBudgetFormUI gLAccountBudgetFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountBudgetFormDAL.GetGLAccountBudgetListById(gLAccountBudgetFormUI);
        return dtb;
    }

    public int AddGLAccountBudget(GLAccountBudgetFormUI gLAccountBudgetFormUI)
    {
        int resutl = 0;
        resutl = gLAccountBudgetFormDAL.AddGLAccountBudget(gLAccountBudgetFormUI);
        return resutl;
    }

    public int UpdateGLAccountBudget(GLAccountBudgetFormUI gLAccountBudgetFormUI)
    {
        int resutl = 0;
        resutl = gLAccountBudgetFormDAL.UpdateGLAccountBudget(gLAccountBudgetFormUI);
        return resutl;
    }

    public int DeleteGLAccountBudget(GLAccountBudgetFormUI gLAccountBudgetFormUI)
    {
        int resutl = 0;
        resutl = gLAccountBudgetFormDAL.DeleteGLAccountBudget(gLAccountBudgetFormUI);
        return resutl;
    }
}
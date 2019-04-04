using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for GLAccountCurrencyFormBLL
/// </summary>
public class GLAccountCurrencyFormBAL
{
    GLAccountCurrencyFormDAL gLAccountCurrencyFormDAL = new GLAccountCurrencyFormDAL();

	public GLAccountCurrencyFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetGLAccountCurrencyListById(GLAccountCurrencyFormUI gLAccountCurrencyFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountCurrencyFormDAL.GetGLAccountCurrencyListById(gLAccountCurrencyFormUI);
        return dtb;
    }

    public int AddGLAccountCurrency(GLAccountCurrencyFormUI gLAccountCurrencyFormUI)
    {
        int resutl = 0;
        resutl = gLAccountCurrencyFormDAL.AddGLAccountCurrency(gLAccountCurrencyFormUI);
        return resutl;
    }

    public int UpdateGLAccountCurrency(GLAccountCurrencyFormUI gLAccountCurrencyFormUI)
    {
        int resutl = 0;
        resutl = gLAccountCurrencyFormDAL.UpdateGLAccountCurrency(gLAccountCurrencyFormUI);
        return resutl;
    }

    public int DeleteGLAccountCurrency(GLAccountCurrencyFormUI gLAccountCurrencyFormUI)
    {
        int resutl = 0;
        resutl = gLAccountCurrencyFormDAL.DeleteGLAccountCurrency(gLAccountCurrencyFormUI);
        return resutl;
    }
}
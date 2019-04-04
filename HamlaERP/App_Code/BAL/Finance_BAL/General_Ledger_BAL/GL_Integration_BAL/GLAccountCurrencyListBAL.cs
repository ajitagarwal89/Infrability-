using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for GLAccountCurrencyListBLL
/// </summary>
public class GLAccountCurrencyListBAL
{
    GLAccountCurrencyListDAL gLAccountCurrencyListDAL = new GLAccountCurrencyListDAL();

	public GLAccountCurrencyListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetGLAccountCurrencyList()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountCurrencyListDAL.GetGLAccountCurrencyList();
        return dtb;
    }

    public DataTable GetGLAccountCurrencyListById(GLAccountCurrencyListUI gLAccountCurrencyListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountCurrencyListDAL.GetGLAccountCurrencyListById(gLAccountCurrencyListUI);
        return dtb;
    }

    public DataTable GetGLAccountCurrencyListBySearchParameters(GLAccountCurrencyListUI gLAccountCurrencyListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountCurrencyListDAL.GetGLAccountCurrencyListBySearchParameters(gLAccountCurrencyListUI);
        return dtb;
    }

    public int DeleteGLAccountCurrency(GLAccountCurrencyListUI gLAccountCurrencyListUI)
    {
        int result = 0;
        result = gLAccountCurrencyListDAL.DeleteGLAccountCurrency(gLAccountCurrencyListUI);
        return result;
    }

    public DataTable GetGLAccountCurrencyListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountCurrencyListDAL.GetGLAccountCurrencyListForExportToExcel();
        return dtb;
    }

}
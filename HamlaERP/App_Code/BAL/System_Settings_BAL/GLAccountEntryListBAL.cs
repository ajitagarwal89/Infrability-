using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for GLAccountEntryListBLL
/// </summary>
public class GLAccountEntryListBAL
{
    GLAccountEntryListDAL gLAccountEntryListDAL = new GLAccountEntryListDAL();

	public GLAccountEntryListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetGLAccountEntryList()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountEntryListDAL.GetGLAccountEntryList();
        return dtb;
    }
    public DataTable GetGLAccountEntryListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountEntryListDAL.GetGLAccountEntryListForExportToExcel();
        return dtb;
    }
    public DataTable GetGLAccountEntryListById(GLAccountEntryListUI gLAccountEntryListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountEntryListDAL.GetGLAccountEntryListById(gLAccountEntryListUI);
        return dtb;
    }

    public DataTable GetGLAccountEntryListBySearchParameters(GLAccountEntryListUI gLAccountEntryListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountEntryListDAL.GetGLAccountEntryListBySearchParameters(gLAccountEntryListUI);
        return dtb;
    }

    public int DeleteGLAccountEntry(GLAccountEntryListUI gLAccountEntryListUI)
    {
        int result = 0;
        result = gLAccountEntryListDAL.DeleteGLAccountEntry(gLAccountEntryListUI);
        return result;
    }
}
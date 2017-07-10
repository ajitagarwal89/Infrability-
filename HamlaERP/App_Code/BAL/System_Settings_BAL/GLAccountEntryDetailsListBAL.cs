using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for GLAccountEntryDetailsListBAL
/// </summary>
public class GLAccountEntryDetailsListBAL
{
    GLAccountEntryDetailsListDAL gLAccountEntryDetailsListDAL = new GLAccountEntryDetailsListDAL();

	public GLAccountEntryDetailsListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetGLAccountEntryDetailsList()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountEntryDetailsListDAL.GetGLAccountEntryDetailsList();
        return dtb;
    }

    public DataTable GetGLAccountEntryDetailsForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountEntryDetailsListDAL.GetGLAccountEntryDetailsListForExportToExcel();
        return dtb;
    }
    public DataTable GetGLAccountEntryDetailsListById(GLAccountEntryDetailsListUI gLAccountEntryDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountEntryDetailsListDAL.GetGLAccountEntryDetailsListById(gLAccountEntryDetailsListUI);
        return dtb;
    }

    public DataTable GetGLAccountEntryDetailsListBySearchParameters(GLAccountEntryDetailsListUI gLAccountEntryDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountEntryDetailsListDAL.GetGLAccountEntryDetailsListBySearchParameters(gLAccountEntryDetailsListUI);
        return dtb;
    }

    public int DeleteGLAccountEntryDetails(GLAccountEntryDetailsListUI gLAccountEntryDetailsListUI)
    {
        int result = 0;
        result = gLAccountEntryDetailsListDAL.DeleteGLAccountEntryDetails(gLAccountEntryDetailsListUI);
        return result;
    }
}
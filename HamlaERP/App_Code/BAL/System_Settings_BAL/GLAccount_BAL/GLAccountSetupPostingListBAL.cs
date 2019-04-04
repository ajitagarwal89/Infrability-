using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for GLAccountSetupPostingListBAL
/// </summary>
public class GLAccountSetupPostingListBAL
{
    GLAccountSetupPostingListDAL gLAccountSetupPostingListDAL = new GLAccountSetupPostingListDAL();
    public GLAccountSetupPostingListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetGLAccountSetupPosting_List()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountSetupPostingListDAL.GetGLAccountSetupPosting_List();
        return dtb;
    }

    public DataTable GetGLAccountSetupPostingListById(GLAccountSetupPostingListUI gLAccountSetupPostingListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountSetupPostingListDAL.GetGLAccountSetupPostingListById(gLAccountSetupPostingListUI);
        return dtb;
    }

    public DataTable GetGLAccountSetupPostingListBySearchParameters(GLAccountSetupPostingListUI gLAccountSetupPostingListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountSetupPostingListDAL.GetGLAccountSetupPostingListBySearchParameters(gLAccountSetupPostingListUI);
        return dtb;
    }

    public DataTable GetGLAccountSetupPostingListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountSetupPostingListDAL.GetGLAccountSetupPostingListForExportToExcel();
        return dtb;
    }

    public int DeleteGLAccountSetupPosting(GLAccountSetupPostingListUI gLAccountSetupPostingListUI)
    {
        int result = 0;
        result = gLAccountSetupPostingListDAL.DeleteGLAccountSetupPosting(gLAccountSetupPostingListUI);
        return result;
    }
}
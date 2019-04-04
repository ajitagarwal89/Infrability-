using System;
using System.Data.SqlClient;
using System.Data;
using log4net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Web.Services;
using System.Web.SessionState;
using System.Web;
using Finware;

/// <summary>
/// Summary description for GLAccountSetupListBAL
/// </summary>
public class GLAccountSetupListBAL
{
    GLAccountSetupListDAL gLAccountSetupListDAL = new GLAccountSetupListDAL();
    public GLAccountSetupListBAL()
    {
       
    }
    public DataTable GetGLAccountSetupList()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountSetupListDAL.GetGLAccountSetupList();
        return dtb;
    }

    public DataTable GetGLAccountSetupListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountSetupListDAL.GetGLAccountSetupListForExportToExcel();
        return dtb;
    }
    public DataTable GetGLAccountSetupListById(GLAccountSetupListUI gLAccountSetupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountSetupListDAL.GetGLAccountSetupListById(gLAccountSetupListUI);
        return dtb;
    }

    public DataTable GetGLAccountSetupListBySearchParameters(GLAccountSetupListUI gLAccountSetupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountSetupListDAL.GetGLAccountSetupListBySearchParameters(gLAccountSetupListUI);
        return dtb;
    }

    public int DeleteGLAccountSetup(GLAccountSetupListUI gLAccountSetupListUI)
    {
        int result = 0;
        result = gLAccountSetupListDAL.DeleteGLAccountSetup(gLAccountSetupListUI);
        return result;
    }
}
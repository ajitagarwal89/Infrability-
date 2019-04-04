using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for GLAccountConfigurationSettingsListBAL
/// </summary>
public class GLAccountConfigurationSettingsListBAL
{
    GLAccountConfigurationSettingsListDAL gLAccountConfigurationSettingsListDAL = new GLAccountConfigurationSettingsListDAL();

    public GLAccountConfigurationSettingsListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetGLAccountConfigurationSettingsList()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountConfigurationSettingsListDAL.GetGLAccountConfigurationSettingsList();
        return dtb;
    }

    public DataTable GetGLAccountConfigurationSettingsListById(GLAccountConfigurationSettingsListUI gLAccountConfigurationSettingsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountConfigurationSettingsListDAL.GetGLAccountConfigurationSettingsListById(gLAccountConfigurationSettingsListUI);
        return dtb;
    }

    public DataTable GetGLAccountConfigurationSettingsListBySearchParameters(GLAccountConfigurationSettingsListUI gLAccountConfigurationSettingsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountConfigurationSettingsListDAL.GetGLAccountConfigurationSettingsListBySearchParameters(gLAccountConfigurationSettingsListUI);
        return dtb;
    }

    public int DeleteGLAccountConfigurationSettings(GLAccountConfigurationSettingsListUI gLAccountConfigurationSettingsListUI)
    {
        int result = 0;
        result = gLAccountConfigurationSettingsListDAL.DeleteGLAccountConfigurationSettings(gLAccountConfigurationSettingsListUI);
        return result;
    }

    public DataTable GetGLAccountConfigurationSettingsListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountConfigurationSettingsListDAL.GetGLAccountConfigurationSettingsListForExportToExcel();
        return dtb;
    }

}
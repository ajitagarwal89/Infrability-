using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for GLAccountConfigurationSettingsFormBAL
/// </summary>
public class GLAccountConfigurationSettingsFormBAL
{
    GLAccountConfigurationSettingsFormDAL gLAccountConfigurationSettingsFormDAL = new GLAccountConfigurationSettingsFormDAL();
    public GLAccountConfigurationSettingsFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetGLAccountConfigurationSettingsListById(GLAccountConfigurationSettingsFormUI gLAccountConfigurationSettingsFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountConfigurationSettingsFormDAL.GetGLAccountConfigurationSettingsListById(gLAccountConfigurationSettingsFormUI);
        return dtb;
    }

    public int AddGLAccountConfigurationSettings(GLAccountConfigurationSettingsFormUI gLAccountConfigurationSettingsFormUI)
    {
        int resutl = 0;
        resutl = gLAccountConfigurationSettingsFormDAL.AddGLAccountConfigurationSettings(gLAccountConfigurationSettingsFormUI);
        return resutl;
    }

    public int UpdateGLAccountConfigurationSettings(GLAccountConfigurationSettingsFormUI gLAccountConfigurationSettingsFormUI)
    {
        int resutl = 0;
        resutl = gLAccountConfigurationSettingsFormDAL.UpdateGLAccountConfigurationSettings(gLAccountConfigurationSettingsFormUI);
        return resutl;
    }

    public int DeleteGLAccountConfigurationSettings(GLAccountConfigurationSettingsFormUI gLAccountConfigurationSettingsFormUI)
    {
        int resutl = 0;
        resutl = gLAccountConfigurationSettingsFormDAL.DeleteGLAccountConfigurationSettings(gLAccountConfigurationSettingsFormUI);
        return resutl;
    }
}
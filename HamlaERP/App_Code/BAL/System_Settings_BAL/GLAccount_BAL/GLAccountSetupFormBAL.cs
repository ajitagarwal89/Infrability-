using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GLAccountSetupFormBAL
/// </summary>
public class GLAccountSetupFormBAL
{
    GLAccountSetupFormUI gLAccountSetupFormUI = new GLAccountSetupFormUI();
    GLAccountSetupFormDAL gLAccountSetupFormDAL = new GLAccountSetupFormDAL();
    public GLAccountSetupFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetGLAccountSetupListById(GLAccountSetupFormUI gLAccountSetupFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountSetupFormDAL.GetGLAccountSetupListById(gLAccountSetupFormUI);
        return dtb;
    }

    public int AddGLAccountSetup(GLAccountSetupFormUI gLAccountSetupFormUI)
    {
        int resutl = 0;
       resutl = gLAccountSetupFormDAL.AddGLAccountSetup(gLAccountSetupFormUI);
        return resutl;
    }

    public int UpdateGLAccountSetup(GLAccountSetupFormUI gLAccountSetupFormUI)
    {
        int resutl = 0;
        resutl = gLAccountSetupFormDAL.UpdateGLAccountSetup(gLAccountSetupFormUI);
        return resutl;
    }

    public int DeleteGLAccountSetup(GLAccountSetupFormUI gLAccountSetupFormUI)
    {
        int resutl = 0;
        resutl = gLAccountSetupFormDAL.DeleteGLAccountSetup(gLAccountSetupFormUI);
        return resutl;
    }
}
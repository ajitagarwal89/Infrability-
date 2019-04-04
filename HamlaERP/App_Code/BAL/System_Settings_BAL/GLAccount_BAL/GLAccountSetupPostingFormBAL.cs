using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for GLAccountSetupPostingFormBAL
/// </summary>
public class GLAccountSetupPostingFormBAL
{
    GLAccountSetupPostingFormDAL gLAccountSetupPostingFormDAL = new GLAccountSetupPostingFormDAL();
    public GLAccountSetupPostingFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetGLAccountSetupPostingListById(GLAccountSetupPostingFormUI gLAccountSetupPostingFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountSetupPostingFormDAL.GetGLAccountSetupPostingListById(gLAccountSetupPostingFormUI);
        return dtb;
    }

    public int AddGLAccountSetupPosting(GLAccountSetupPostingFormUI gLAccountSetupPostingFormUI)
    {
        int resutl = 0;
        resutl = gLAccountSetupPostingFormDAL.AddGLAccountSetupPosting(gLAccountSetupPostingFormUI);
        return resutl;
    }

    public int UpdateGLAccountSetupPosting(GLAccountSetupPostingFormUI gLAccountSetupPostingFormUI)
    {
        int resutl = 0;
        resutl = gLAccountSetupPostingFormDAL.UpdateGLAccountSetupPosting(gLAccountSetupPostingFormUI);
        return resutl;
    }

    public int DeleteGLAccountSetupPosting(GLAccountSetupPostingFormUI gLAccountSetupPostingFormUI)
    {
        int resutl = 0;
        resutl = gLAccountSetupPostingFormDAL.DeleteGLAccountSetupPosting(gLAccountSetupPostingFormUI);
        return resutl;
    }
}
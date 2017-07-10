using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PhysicalLocationFormBAL
/// </summary>
public class PhysicalLocationFormBAL
{
    PhysicalLocationFormDAL physicalLocationFormDAL = new PhysicalLocationFormDAL();

    public PhysicalLocationFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetPhysicalLocationListById(PhysicalLocationFormUI physicalLocationFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = physicalLocationFormDAL.GetPhysicalLocationListById(physicalLocationFormUI);
        return dtb;
    }

    public int AddPhysicalLocation(PhysicalLocationFormUI physicalLocationFormUI)
    {
        int resutl = 0;
        resutl = physicalLocationFormDAL.AddPhysicalLocation(physicalLocationFormUI);
        return resutl;
    }

    public int UpdatePhysicalLocation(PhysicalLocationFormUI physicalLocationFormUI)
    {
        int resutl = 0;
        resutl = physicalLocationFormDAL.UpdatePhysicalLocation(physicalLocationFormUI);
        return resutl;
    }

    public int DeletePhysicalLocation(PhysicalLocationFormUI physicalLocationFormUI)
    {
        int resutl = 0;
        resutl = physicalLocationFormDAL.DeletePhysicalLocation(physicalLocationFormUI);
        return resutl;
    }

}
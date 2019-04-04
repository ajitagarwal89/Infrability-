using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for StructureFormBAL
/// </summary>
public class StructureFormBAL
{
    StructureFormDAL structureFormDAL = new StructureFormDAL();

    public StructureFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetStructureListById(StructureFormUI structureFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = structureFormDAL.GetStructureListById(structureFormUI);
        return dtb;
    }

    public int AddStructure(StructureFormUI structureFormUI)
    {
        int resutl = 0;
        resutl = structureFormDAL.AddStructure(structureFormUI);
        return resutl;
    }

    public int UpdateStructure(StructureFormUI structureFormUI)
    {
        int resutl = 0;
        resutl = structureFormDAL.UpdateStructure(structureFormUI);
        return resutl;
    }

    public int DeleteStructure(StructureFormUI structureFormUI)
    {
        int resutl = 0;
        resutl = structureFormDAL.DeleteStructure(structureFormUI);
        return resutl;
    }
}
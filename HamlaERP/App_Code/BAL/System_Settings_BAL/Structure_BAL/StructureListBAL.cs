using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for StructureListBAL
/// </summary>
public class StructureListBAL
{
    StructureListDAL structureListDAL = new StructureListDAL();
    public StructureListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetStructureList()
    {
        DataTable dtb = new DataTable();
        dtb = structureListDAL.GetStructureList();
        return dtb;
    }
    public DataTable GetStructureListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = structureListDAL.GetStructureListForExportToExcel();
        return dtb;
    }

    public DataTable GetStructureListById(StructureListUI structureListUI)
    {
        DataTable dtb = new DataTable();
        dtb = structureListDAL.GetStructureListById(structureListUI);
        return dtb;
    }

    public DataTable GetStructureListBySearchParameters(StructureListUI structureListUI)
    {
        DataTable dtb = new DataTable();
        dtb = structureListDAL.GetStructureListBySearchParameters(structureListUI);
        return dtb;
    }

    public int DeleteStructure(StructureListUI structureListUI)
    {
        int result = 0;
        result = structureListDAL.DeleteStructure(structureListUI);
        return result;
    }
}
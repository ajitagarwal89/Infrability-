using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PhysicalLocationListBAL
/// </summary>
public class PhysicalLocationListBAL
{
    PhysicalLocationListDAL physicalLocationListDAL = new PhysicalLocationListDAL();
    public PhysicalLocationListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetPhysicalLocationList()
    {
        DataTable dtb = new DataTable();
        dtb = physicalLocationListDAL.GetPhysicalLocationList();
        return dtb;
    }
    public DataTable GetPhysicalLocationListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = physicalLocationListDAL.GetPhysicalLocationListForExportToExcel();
        return dtb;
    }
    public DataTable GetPhysicalLocationListById(PhysicalLocationListUI PhysicalLocationListUI)
    {
        DataTable dtb = new DataTable();
        dtb = physicalLocationListDAL.GetPhysicalLocationListById(PhysicalLocationListUI);
        return dtb;
    }

    public DataTable GetPhysicalLocationListBySearchParameters(PhysicalLocationListUI physicalLocationListUI)
    {
        DataTable dtb = new DataTable();
        dtb = physicalLocationListDAL.GetPhysicalLocationListBySearchParameters(physicalLocationListUI);
        return dtb;
    }

    public int DeletePhysicalLocation(PhysicalLocationListUI physicalLocationListUI)
    {
        int result = 0;
        result = physicalLocationListDAL.DeletePhysicalLocation(physicalLocationListUI);
        return result;
    }

}
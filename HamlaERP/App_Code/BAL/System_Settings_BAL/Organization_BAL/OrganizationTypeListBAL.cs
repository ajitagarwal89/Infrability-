using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for OrganizationTypeListBLL
/// </summary>
public class OrganizationTypeListBAL
{

    OrganizationTypeListDAL organizationTypeListDAL = new OrganizationTypeListDAL();

    public OrganizationTypeListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetOrganizationTypeList()
    {
        DataTable dtb = new DataTable();
        dtb = organizationTypeListDAL.GetOrganizationTypeList();
        return dtb;
    }

    public DataTable GetOrganizationTypeListById(OrganizationTypeListUI organizationTypeListUI)
    {
        DataTable dtb = new DataTable();
        dtb = organizationTypeListDAL.GetOrganizationTypeListById(organizationTypeListUI);
        return dtb;
    }

    public DataTable GetOrganizationTypeListBySearchParameters(OrganizationTypeListUI organizationTypeListUI)
    {
        DataTable dtb = new DataTable();
        dtb = organizationTypeListDAL.GetOrganizationTypeListBySearchParameters(organizationTypeListUI);
        return dtb;
    }

    public int DeleteOrganizationType(OrganizationTypeListUI organizationTypeListUI)
    {
        int result = 0;
        result = organizationTypeListDAL.DeleteOrganizationType(organizationTypeListUI);
        return result;
    }

    public DataTable GetOrganizationTypeListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = organizationTypeListDAL.GetOrganizationTypeListForExportToExcel();
        return dtb;
    }

}
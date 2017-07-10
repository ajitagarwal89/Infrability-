using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for OrganizationTypeForm
/// </summary>
public class OrganizationTypeFormBAL
{

    OrganizationTypeFormDAL organizationTypeFormDAL = new OrganizationTypeFormDAL();

    public OrganizationTypeFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetOrganizationTypeListById(OrganizationTypeFormUI organizationTypeFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = organizationTypeFormDAL.GetOrganizationTypeListById(organizationTypeFormUI);
        return dtb;
    }

    public int AddOrganizationType(OrganizationTypeFormUI organizationTypeFormUI)
    {
        int resutl = 0;
        resutl = organizationTypeFormDAL.AddOrganizationType(organizationTypeFormUI);
        return resutl;
    }

    public int UpdateOrganizationType(OrganizationTypeFormUI organizationTypeFormUI)
    {
        int resutl = 0;
        resutl = organizationTypeFormDAL.UpdateOrganizationType(organizationTypeFormUI);
        return resutl;
    }

    public int DeleteOrganizationType(OrganizationTypeFormUI organizationTypeFormUI)
    {
        int resutl = 0;
        resutl = organizationTypeFormDAL.DeleteOrganizationType(organizationTypeFormUI);
        return resutl;
    }
}
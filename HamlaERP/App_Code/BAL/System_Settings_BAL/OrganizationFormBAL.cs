using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for OrganizationFormBLL
/// </summary>
public class OrganizationFormBAL
{
    OrganizationFormDAL organizationFormDAL = new OrganizationFormDAL();

    public OrganizationFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetOrganizationListById(OrganizationFormUI organizationFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = organizationFormDAL.GetOrganizationListById(organizationFormUI);
        return dtb;
    }

    public int AddOrganization(OrganizationFormUI organizationFormUI)
    {
        int resutl = 0;
        resutl = organizationFormDAL.AddOrganization(organizationFormUI);
        return resutl;
    }

    public int UpdateOrganization(OrganizationFormUI organizationFormUI)
    {
        int resutl = 0;
        resutl = organizationFormDAL.UpdateOrganization(organizationFormUI);
        return resutl;
    }

    public int DeleteOrganization(OrganizationFormUI organizationFormUI)
    {
        int resutl = 0;
        resutl = organizationFormDAL.DeleteOrganization(organizationFormUI);
        return resutl;
    }
}
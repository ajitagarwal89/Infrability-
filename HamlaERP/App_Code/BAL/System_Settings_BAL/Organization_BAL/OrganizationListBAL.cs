using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for OrganizationListBLL
/// </summary>
public class OrganizationListBAL
{
    OrganizationListDAL organizationListDAL = new OrganizationListDAL();

    public OrganizationListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetOrganizationList()
    {
        DataTable dtb = new DataTable();
        dtb = organizationListDAL.GetOrganizationList();
        return dtb;
    }

    public DataTable GetOrganizationListById(OrganizationListUI organizationListUI)
    {
        DataTable dtb = new DataTable();
        dtb = organizationListDAL.GetOrganizationListById(organizationListUI);
        return dtb;
    }

    public int DeleteOrganization(OrganizationListUI organizationListUI)
    {
        int result = 0;
        result = organizationListDAL.DeleteOrganization(organizationListUI);
        return result;
    }

    public DataTable GetOrganizationListOfUser(Guid UserUid)
    {
        DataTable dtb = new DataTable();
        dtb = organizationListDAL.GetOrganizationListOfUser(UserUid);
        return dtb;
    }

    public DataTable GetOrganizationListBySearchParameters(OrganizationListUI organizationListUI)
    {
        DataTable dtb = new DataTable();
        dtb = organizationListDAL.GetOrganizationListBySearchParameters(organizationListUI);
        return dtb;
    }

}
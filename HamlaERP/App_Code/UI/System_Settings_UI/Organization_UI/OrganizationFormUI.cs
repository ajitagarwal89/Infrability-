using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrganizationFormUI
/// </summary>
public class OrganizationFormUI
{
    public OrganizationFormUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Tbl_OrganizationId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationTypeId { get; set; }

    public string OrganizationCode { get; set; }

    public string Name{ get; set; }

    public string Address { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string PostalCode { get; set; }

    public string Tbl_CountryId { get; set; }

    public string Tbl_CurrencyId { get; set; }

    public string PhoneNo { get; set; }

    public string FaxNo { get; set; }

    public string Mobile { get; set; }

    public string WebSite { get; set; }

    public string Email { get; set; }

    public string Owner { get; set; }

    public Byte[] Logo { get; set; }

    public string LogoName { get; set; }

    public string LogoContentType { get; set; }

    public string LogoData { get; set; }

    public string Search { get; set; }
}
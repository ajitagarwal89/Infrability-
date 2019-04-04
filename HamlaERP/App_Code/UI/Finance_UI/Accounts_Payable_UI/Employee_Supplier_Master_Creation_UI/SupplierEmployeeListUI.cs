﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SupplierEmployeeListUI
/// </summary>
public class SupplierEmployeeListUI
{
    public SupplierEmployeeListUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Tbl_SupplierEmployeeId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }
    public string ModifiedBy { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public string SupplierEmployeeCode { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }
    public string ChequeName { get; set; }
    public string Contact { get; set; }
    public string Address { get; set; }
    public string City { get; set; }

    public string ZipCode { get; set; }

    public string Tbl_CountryId { get; set; }
    public string Phone { get; set; }
    public string Mobile { get; set; }
    public string FaxNo { get; set; }
    public string Email { get; set; }
    public string Comment1 { get; set; }

    public string Comment2 { get; set; }

    public Int16 Status { get; set; }

    public string Tbl_SupplierEmployeeGroupId { get; set; }

    public Boolean OnHold { get; set; }

    public string Search { get; set; }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HRDivisionFListUI
/// </summary>
public class HRDivisionListUI
{
    public HRDivisionListUI()
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

    public string Search { get; set; }

    public string Tbl_HRDivisionId { get; set; }

    public string DivisionCode { get; set; }

    public string Description { get; set; }

    public string Address { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string ZipCode { get; set; }

    public string Phone { get; set; }

    public string Extension { get; set; }

    public string Fax { get; set; }

    public string Email { get; set; }

}
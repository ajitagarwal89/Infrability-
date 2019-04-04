using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for POBasedInvoiceDetailsFormUI
/// </summary>
public class POBasedInvoiceDetailsFormUI
{
    public POBasedInvoiceDetailsFormUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Tbl_POBasedInvoiceDetailsId { get; set; }
    public string Tbl_POBasedInvoiceId { get; set; }

    public string Tbl_POId { get; set; }
    public DateTime CreatedOn { get; set; }
    public Int64 CreatedOn_Hijri { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public Int64 ModifiedOn_Hijri { get; set; }
    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public string UOM { get; set; }
    public string Description { get; set; }
    public string Tbl_LocationId { get; set; }
    public Decimal QuantityInvoice { get; set; }

    public Decimal UnitCost { get; set; }
    public Decimal ExtendedCost { get; set; }

    public string Search { get; set; }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AssetTransferFormUI
/// </summary>
public class AssetTransferFormUI
{
    public AssetTransferFormUI()
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

    public string Tbl_AssetTransferId { get; set; }

    public Int16 opt_DocumentType { get; set; }

    public string Number { get; set; }

    public string Tbl_BatchId { get; set; }

    public DateTime Date { get; set; }

    public string Tbl_LocationId_From { get; set; }

    public string Tbl_LocationId_To { get; set; }

    public string Search { get; set; }

    public int InvoiceType { get; set; }

    public bool IsPosted { get; set; }
}
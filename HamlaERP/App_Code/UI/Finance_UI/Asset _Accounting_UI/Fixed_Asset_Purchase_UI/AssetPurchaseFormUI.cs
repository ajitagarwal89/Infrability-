using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AssetFormPurchaseUI
/// </summary>
public class AssetPurchaseFormUI
{
    public AssetPurchaseFormUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Tbl_AssetPurchaseId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public int opt_ReceiptType { get; set; }
    public string ReceiptNumber { get; set; }
    public string Tbl_SupplierId { get; set; }
    public string SupplierDocumentNumber { get; set; }
    public string Tbl_CurrencyId { get; set; }
    public DateTime Date{ get; set; }
    public Int64 Date_Hijri { get; set; }
    public string Tbl_BatchId { get; set; }
    public Decimal SubTotal { get; set; }
    public Decimal TradeDiscount { get; set; }
    public Decimal Frieght { get; set; }
    public Decimal Miscellaneous { get; set; }
    public Decimal MainTotal { get; set; }
    public string Search { get; set; }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GoodsReceivedNoteListUI
/// </summary>
public class GoodsReceivedNoteListUI
{
    public GoodsReceivedNoteListUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Tbl_GoodsReceivedNoteId { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public int opt_ReceivedType { get; set; }
    public string GoodsReceivedNoteNumber { get; set; }
    public string Tbl_SupplierId { get; set; }
    public string SupplierDocumentNumber { get; set; }
    public DateTime Date { get; set; }
    public string Tbl_CurrencyId { get; set; }
    public string Tbl_BatchId { get; set; }
    public Decimal SubTotal { get; set; }
    public Decimal TradeDiscount { get; set; }
    public Decimal Freight { get; set; }
    public Decimal Miscellaneous { get; set; }
    public Decimal Total { get; set; }
    public string Search { get; set; }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AssetFormUI
/// </summary>
public class AssetFormUI
{
    public AssetFormUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Tbl_AssetId { get; set; }
    public DateTime CreatedOn { get; set; }
    public Int64 CreatedOn_Hijri { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public Int64 ModifiedOn_Hijri { get; set; }
    public string ModifiedBy { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public string AssetCode { get; set; }
    public string Description { get; set; }
    public string ExtendedDescription { get; set; }
    public string ShortName { get; set; }
    public string Tbl_AssetGroupId { get; set; }
    public int opt_Type { get; set; }
    public string Tbl_AssetAndGroupAccountId { get; set; }
    public DateTime AcquisitionDate { get; set; }
    public Int64 AcquisitionDate_Hijri { get; set; }
    public decimal AcquisitionCost { get; set; }
    public string Tbl_CurrencyId { get; set; }
    public string Tbl_LocationId { get; set; }
    public string Tbl_PhysicalLocationId { get; set; }
    public string AssetBarcode { get; set; }
    public string Tbl_StructureId { get; set; }
    public string Tbl_EmployeeId { get; set; }
    public string ManufacturerName { get; set; }
    public decimal Quantity { get; set; }
    public DateTime LastMaintenanceDate { get; set; }
    public Int64 LastMaintenanceDate_Hijri { get; set; }
    public DateTime DateAdded { get; set; }
    public Int64 DateAdded_Hijri { get; set; }
    public int opt_Status { get; set; }
    public string SerialNumber { get; set; }
    public string ModalNumber { get; set; }
    public DateTime WarrantyDate { get; set; }
    public Int64 WarrantyDate_Hijri { get; set; }
    public string Tbl_GLAccount_DepreciationExpense { get; set; }
    public string Tbl_GLAccount_AccumulatedDepreciation { get; set; }
    public string Tbl_GLAccount_PriorYearDepreciation { get; set; }
    public string Tbl_GLAccount_AssetCost { get; set; }
    public string Tbl_GLAccount_Clearing { get; set; }
    public string Search { get; set; }
    public int InvoiceType { get; set; }
}
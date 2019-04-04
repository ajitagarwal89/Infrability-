using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DownPaymentToSupplierDistributionListUI
/// </summary>
public class DownPaymentToSupplierDistributionListUI
{
    public DownPaymentToSupplierDistributionListUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Tbl_DownPaymentToSupplierDistributionId { get; set; }
    public DateTime CreatedOn { get; set; }
    public Int64 CreatedOn_Hijri { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public Int64 ModifiedOn_Hijri { get; set; }
    public string ModifiedBy { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public string Search { get; set; }
    public string Tbl_DownPaymentToSupplierId { get; set; }
    public string Tbl_GLAccountId { get; set; }
    public int opt_Type { get; set; }
    public Decimal Debit { get; set; }
    public Decimal OriginatingDebit { get; set; }
    public Decimal Credit { get; set; }
    public Decimal OriginatingCredit { get; set; }
    public string Description { get; set; }
    public string DistributionReference { get; set; }
    public string CompanyId { get; set; }
    public string CorrespondenceCompanyId { get; set; }

}
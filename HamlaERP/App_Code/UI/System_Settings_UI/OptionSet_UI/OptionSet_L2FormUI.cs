using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OptionSet_L2FormUI
/// </summary>
public class OptionSet_L2FormUI
{
    public OptionSet_L2FormUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Tbl_OptionSet_L2Id { get; set; }
    

    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public string Tbl_OptionSetId { get; set; }

    public string Tbl_OptionSet_L1Id { get; set; }

    public string OptionSetLable { get; set; }

    public string OptionSetValue { get; set; }
    public string TableObjectId { get; set; }

    public string TableName { get; set; }

    public string OptionSetName { get; set; }
    public string Tbl_OptionSet { get; set; }
    public string ColumnObjectId { get; set; }
}
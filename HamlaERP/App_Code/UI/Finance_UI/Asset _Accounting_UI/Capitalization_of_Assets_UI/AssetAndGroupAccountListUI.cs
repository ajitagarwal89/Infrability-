﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for AssetAndGroupAccountListUI
/// </summary>
public class AssetAndGroupAccountListUI
{
    public AssetAndGroupAccountListUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Tbl_AssetAndGroupAccountId { get; set; }
    public DateTime CreatedOn { get; set; }
    public Int64 CreatedOn_Hijri { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public Int64 ModifiedOn_Hijri { get; set; }
    public string ModifiedBy { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public string Description { get; set; }
    public string Tbl_GLAccount_DepreciationExpense { get; set; }
    // public string Tbl_GLAccount_DepreciationReserve { get; set; }
    public string Tbl_GLAccount_AccumulatedDepreciation { get; set; }
    public string Tbl_GLAccount_PriorYearDepreciation { get; set; }
    public string Tbl_GLAccount_AssetCost { get; set; }
    //public string Tbl_GLAccount_Proceeds { get; set; }
    //public string Tbl_GLAccount_RecognizedGL { get; set; }
    //public string Tbl_GLAccount_NonRecognizedGL { get; set; }
    public string Tbl_GLAccount_Clearing { get; set; }
    public string Search { get; set; }
}
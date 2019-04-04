using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ChartUI
/// </summary>
public class ChartUI
{
    public ChartUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int IsPosted { get; set; }
    public string name { get; set; }
    public decimal cash { get; set; }
    public decimal cheque { get; set; }
    public decimal card { get; set; }
    public decimal banktransfer { get; set; }
    public decimal totalCash { get; set; }
    public string piechart { get; set; }
    public string stackedchart { get; set; }
    public string barchart { get; set; }
    public string Tbl_OrganizationId { get; set; }
}
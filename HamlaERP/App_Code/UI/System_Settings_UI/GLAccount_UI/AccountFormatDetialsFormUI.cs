using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AccountFormatDetailsFormUI
/// </summary>
public class AccountFormatDetailsFormUI
{
	public AccountFormatDetailsFormUI()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public string Tbl_AccountFormatDetialsId { get; set; }

   public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

   public string CreatedBy { get; set; }

   public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

   public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public string Tbl_AccountFormatId { get; set; }

    public int SequenceNumber { get; set; }

    public int SegmentNumber { get; set; }

    public string SegmentName { get; set; }

    public int MaxLength { get; set; }

    public int Length { get; set; }

    public bool IsActive { get; set; }

}
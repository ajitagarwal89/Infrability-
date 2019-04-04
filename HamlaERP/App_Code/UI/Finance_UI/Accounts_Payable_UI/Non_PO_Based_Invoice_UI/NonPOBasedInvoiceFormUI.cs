using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NonPOBasedInvoiceFormUI
/// </summary>
public class NonPOBasedInvoiceFormUI
{
	public NonPOBasedInvoiceFormUI()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Tbl_NonPOBasedInvoiceId { get; set; }   

    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy {get; set;}
     
    public DateTime ModifiedOn {get; set;}
     

    public Int64 ModifiedOn_Hijri {get; set;}
     

    public string ModifiedBy {get; set;}
     
    public string Tbl_OrganizationId {get; set;}
     

    public string VoucherNumber {get; set;}
         

    public Boolean InterCompany {get; set;}
        
    public string Tbl_BatchId {get; set;}
         
    public int Opt_DocumentType {get; set;}

    public int Opt_PayablesType { get; set; }

    public DateTime DocumentDate {get; set;}
        

    public Int64 DocumentDate_Hijri {get; set;}
         

    public string Description {get; set;}
       
    public DateTime PostingDate {get; set;}
       

    public Int64 PostingDate_Hijri {get; set;}
       

    public DateTime InvoiceDate {get; set;}
        

    public Int64 InvoiceDate_Hijri {get; set;}
         
    public DateTime ReceivedDate {get; set;}
         
    public Int64 ReceivedDate_Hijri {get; set;}
         
    public string Tbl_SupplierId {get; set;}
         

    public string Tbl_CurrencyId {get; set;}
       
    public string DocumentNumber {get; set;}
         

    public string PONumber {get; set;}
         
    public string Tbl_PaymentTermsId {get; set;}
        
    public Decimal Purchase {get; set;}
         
    public Decimal TradeDiscount {get; set;}
         
    public Decimal Freight {get; set;}
         
    public Decimal Total {get; set;}
       

    public string Tbl_PayablesId_BankTransfer {get; set;}
         
    public Decimal BankTransferAmount {get; set;}
         
    public string Tbl_PayablesId_Cash {get; set;}
        
    public Decimal CashAmount {get; set;}
         
    public string Tbl_PayablesId_Cheque {get; set;}
        
    public Decimal ChequeAmount {get; set;}
        
    public string Tbl_PayablesId_CreditCard {get; set;}
        
    public Decimal CreditCardAmount {get; set;}
        

    public Decimal OnAccount {get; set;}

    public string Search { get; set; }

    public int InvoiceType { get; set; }

    public bool IsPosted { get; set; }

}
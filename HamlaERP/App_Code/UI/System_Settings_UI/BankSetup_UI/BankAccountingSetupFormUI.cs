using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BankAccountingSetupFormUI
/// </summary>
public class BankAccountingSetupFormUI
{
    public BankAccountingSetupFormUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Tbl_BankAccountingSetupId { get; set; }

    public string Tbl_ReceivableSetupId { get; set; }
    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string RowVersion { get; set; }

    public string Tbl_OrganizationId { get; set; }
    public string Depositcode { get; set; }
    public decimal Deposit { get; set; }
    public string ReceiptCode { get; set; }
    public decimal Receipt { get; set; }
    public string CheckCode { get; set; }
    public decimal Check { get; set; }
    public string WithdrawalCode { get; set; }
    public decimal Withdrawal { get; set; }
    public string IncreaseAdjustmentCode { get; set; }
    public decimal IncreaseAdjustment { get; set; }
    public string DecreaseAdjustmentCode { get; set; }
    public decimal DecreaseAdjustment { get; set; }
    public string TransferCode { get; set; }
    public decimal Transfer { get; set; }
    public Boolean IsTransaction_Reconcilation { get; set; }
    public string Tbl_ChequeBookId { get; set; }
    public string InterestIncomeCode { get; set; }
    public decimal InterestIncome { get; set; }
    public string OtherIncomeCode { get; set; }
    public decimal OtherIncome { get; set; }
    public string OtherExpenseCode { get; set; }
    public decimal OtherExpense { get; set; }
    public string ServiceChargeCode { get; set; }
    public decimal ServiceCharge { get; set; }
    public string Search { get; set; }
}
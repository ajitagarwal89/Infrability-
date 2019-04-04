using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enums
{
    public class CommonEnum
    {
        public CommonEnum()
        {

        }
        public enum Payabletype
        {
            BankTransfer = 1,
            Cheque = 2,
            Cash = 3,
            CreditCard = 4,
        }
        public enum ProcessType
        {
            Sales = 1,
            Purchase = 2,

        }
        public enum type
        {
            Credit = 1,
            Debit = 2,
        }

        public enum transaction
        {
            Payment = 1,
            Receipt = 2,
        }

        public enum Operation
        { Insert=1,
        Update=2,
        Delete=3,
        Select=4,}

        public enum HRStaus
        {
        Active=1,
        InActive=2,}
        public enum Gender
        {
        Male=1,
        Female=2,
        }
        public enum MaritalStatus
        {
            MARRIED=1,
            SINGLE=2,
        }
        public enum ApplyToDocumentType
        {
            NonPOBaseInvoice = 1,
            POBaseInvoice = 2,
            CustomerInvoice = 1,
            CustomerInvoiceProcess = 2,
        }

        public enum Seperator
        {
            comma = ',',
            Tab = '\t',
            Space = ' ',
            Hyphen = '-',
            Slash = '/',
            Colon = ':',
            Pipe = '|',
        }
        public enum Tables
        {
            tbl_Asset,
            tbl_AssetAndGroupAccount,
            tbl_AssetBook,
            tbl_AssetBookGroupSetup,
            tbl_AssetBookSetup,
            tbl_AssetDisposal,
            tbl_AssetDisposalDetails,
            tbl_AssetGroup,
            tbl_AssetPurchase,
            tbl_AssetPurchaseDetails,
            tbl_AssetPurchaseDistribution,
            tbl_AssetTransfer,
            tbl_AssetTransferDetails,
            tbl_Bank,
            tbl_BankAccount,
            tbl_Batch,
            tbl_Budget,
            tbl_BudgetDetails,
            tbl_Card,
            tbl_ChequeBook,
            tbl_Comments,
            tbl_Country,
            tbl_Currency,
            tbl_Customer,
            tbl_CustomerAndGroupAccount,
            tbl_CustomerGroup,
            tbl_CustomerInvoice,
            tbl_CustomerInvoiceDistribution,
            tbl_CustomerInvoiceProcess,
            tbl_CustomerInvoiceProcessDistribution,
            tbl_DownPaymentFromCustomer,
            tbl_DownPaymentFromCustomerApply,
            tbl_DownPaymentFromCustomerDistribution,
            tbl_DownPaymentToSupplier,
            tbl_DownPaymentToSupplierApply,
            tbl_DownPaymentToSupplierDistribution,
            tbl_Employee,
            tbl_EmployeeAndGroupAccount,
            tbl_EmployeeContacts,
            tbl_EmployeeGeneralExpenses,
            tbl_EmployeeGroup,
            tbl_FiscalPeriod,
            tbl_FiscalPeriodDetails,
            tbl_GLAccount,
            tbl_GLAccountBudget,
            tbl_GLAccountBudgetDetails,
            tbl_GLAccountCategory,
            tbl_GLAccountCurrency,
            tbl_GeneralJournal,
            tbl_GeneralJournalDetails,
            tbl_GLAccountFormat,
            tbl_GLAccountFormatDetails,
            tbl_GLAccountSetup,
            tbl_GLAccountSummary,
            tbl_GLAccountSummaryDetails,
            tbl_GoodsReceivedNote,
            tbl_GoodsReceivedNoteDetails,
            tbl_GoodsReceivedNoteDistribution,
            tbl_HR_Branch,
            tbl_HR_Department,
            tbl_HR_Division,
            tbl_HR_Position,
            tbl_HR_Supervisor,
            tbl_HR_Team,
            tbl_Insurance,
            tbl_InvoiceAndOrderType,
            tbl_Location,
            tbl_NonPOBasedInvoice,
            tbl_NonPOBasedInvoiceDistribution,
            tbl_OptionSet,
            tbl_Organization,
            tbl_OrganizationType,
            tbl_Payables,
            tbl_PayablesTransactionDistribution,
            tbl_PaymentFromCustomer,
            tbl_PaymentFromCustomerApply,
            tbl_PaymentFromCustomerDistribution,
            tbl_PaymentTerms,
            tbl_PaymentToEmployee,
            tbl_PaymentToEmployeeApply,
            tbl_PaymentToEmployeeDistribution,
            tbl_PaymentToSupplier,
            tbl_PaymentToSupplierApply,
            tbl_PaymentToSupplierDistribution,
            tbl_PaymentToSupplierEmployee,
            tbl_PaymentToSupplierEmployeeApply,
            tbl_PaymentToSupplierEmployeeDistribution,
            tbl_PettyCash,
            tbl_PhysicalLocation,
            tbl_PO,
            tbl_POBasedInvoice,
            tbl_POBasedInvoiceDetails,
            tbl_POBasedInvoiceDistribution,
            tbl_PODetails,
            tbl_PostingSetup,
            tbl_Segment01,
            tbl_Segment02,
            tbl_Segment03,
            tbl_Segment04,
            tbl_Segment05,
            tbl_Segment06,
            tbl_Segment07,
            tbl_Segment08,
            tbl_Segment09,
            tbl_Segment10,
            tbl_Sites,
            tbl_SourceDocument,
            tbl_Structure,
            tbl_Supplier,
            tbl_SupplierAndGroupAccount,
            tbl_SupplierEmployee,
            tbl_SupplierEmployeeAndGroupAccount,
            tbl_SupplierEmployeeGeneralExpenses,
            tbl_SupplierEmployeeGroup,
            tbl_SupplierGroup,
            tbl_User,
            tbl_Voucher
        }

    }
   
}

/*
 int applyToDocumentCustomerInvoice = (int)Enums.CommonEnum.ApplyToDocumentType.CustomerInvoice;
        int applyToDocumentCustomerInvoiceProcess = (int)Enums.CommonEnum.ApplyToDocumentType.CustomerInvoiceProcess;



    int applyToDocumentTypeNonPOBaseInvoice = (int)Enums.CommonEnum.ApplyToDocumentType.NonPOBaseInvoice;
        int applyToDocumentTypePOBaseInvoice = (int)Enums.CommonEnum.ApplyToDocumentType.POBaseInvoice;

     */

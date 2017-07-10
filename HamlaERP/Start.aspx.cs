using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Start : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!this.IsPostBack)
        {
            if (Request.QueryString["stype"] != null)
            {
                Control ctrl;

                #region System Setting


                if (Request.QueryString["stype"] == "Organisation_Management")
                {
                    #region
                    ctrl = Page.LoadControl("~/usercontrols/Organisation_Management.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }
                if (Request.QueryString["stype"] == "GLAccountFormat")
                {
                    #region
                    ctrl = Page.LoadControl("~/usercontrols/System_Settings/GLAccountFormat.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }

                if (Request.QueryString["stype"] == "BankingSetup")
                {
                    #region Banking Setup
                    ctrl = Page.LoadControl("~/UserControls/System_Settings/BankingSetup.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }

                if (Request.QueryString["stype"] == "Others_Setup")
                {
                    #region OtherSetup

                    ctrl = Page.LoadControl("~/UserControls/System_Settings/Others_Setup.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion

                }
                #endregion System Setting

                #region Finance

                #region Account Payable

                if (Request.QueryString["stype"] == "EmployeeGeneralExpenses")
                {
                    #region
                    ctrl = Page.LoadControl("~/UserControls/Finance/Accounts_Payable/Employee_General_Expenses/EmployeeGeneralExpenses.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }

                if (Request.QueryString["stype"] == "NonPOBasedInvoice")
                {
                    #region
                    ctrl = Page.LoadControl("~/UserControls/Finance/Accounts_Payable/Non_PO_Based_Invoice/NonPOBasedInvoice.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }
                if (Request.QueryString["stype"] == "POBasedInvoice")
                {
                    #region
                    ctrl = Page.LoadControl("~/UserControls/Finance/Accounts_Payable/PO_Based_Invoice/POBasedInvoice.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }

                if (Request.QueryString["stype"] == "EmployeeSupplierMasterCreation")
                {
                    #region
                    ctrl = Page.LoadControl("~/UserControls/Finance/Accounts_Payable/Employee_Supplier_Master_Creation/EmployeeSupplierMasterCreation.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }

                if (Request.QueryString["stype"] == "SupplierMasterCreation")
                {
                    #region
                    ctrl = Page.LoadControl("~/UserControls/Finance/Accounts_Payable/Supplier_Master_Creation/Supplier.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }

                if (Request.QueryString["stype"] == "PO")
                {
                    #region
                    ctrl = Page.LoadControl("~/usercontrols/Procurement/PO.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }

                #endregion Account Payable

                #region Accounts_Receivable
                if (Request.QueryString["stype"] == "CustomerInvoice")
                {
                    #region Accounts_Receivable
                    ctrl = Page.LoadControl("~/UserControls/Finance/Accounts_Receivable/Customer _Invoice_(With_Sales_Order)/CustomerInvoice.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }
                if (Request.QueryString["stype"] == "CustomerInvoiceProcess")
                {
                    #region CustomerInvoiceProcess
                    ctrl = Page.LoadControl("~/UserControls/Finance/Accounts_Receivable/Customer_Invoice_Processing_(Services)/CustomerInvoiceProcess.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }
                if (Request.QueryString["stype"] == "CustomerMasterCreation")
                {
                    #region CustomerMasterCreation
                    ctrl = Page.LoadControl("~/UserControls/Finance/Accounts_Receivable/CustomerMasterCreation/CustomerMasterCreation.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }
                #endregion Accounts Receivable

                #region Bank Accounting

                if (Request.QueryString["stype"] == "DownPaymentToSupplier")
                {
                    #region
                    ctrl = Page.LoadControl("~/UserControls/Finance/Bank_Accounting/Down_Payment_Suppliers/DownPaymentToSuppliers.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }

                if (Request.QueryString["stype"] == "PaymentToSupplier")
                {
                    #region
                    ctrl = Page.LoadControl("~/UserControls/Finance/Bank_Accounting/Payment_To_Suppliers/PaymentToSuppliers.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }

                if (Request.QueryString["stype"] == "PaymentToEmployee")
                {
                    #region
                    ctrl = Page.LoadControl("~/UserControls/Finance/Bank_Accounting/Payment_To_Employees/PaymentToEmployee.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }

                if (Request.QueryString["stype"] == "DownPaymentFromCustomer")
                {
                    #region
                    ctrl = Page.LoadControl("~/UserControls/Finance/Bank_Accounting/Down_Payment_Customer/DownPaymentFromCustomer.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }

                if (Request.QueryString["stype"] == "PaymentFromCustomer")
                {
                    #region
                    ctrl = Page.LoadControl("~/UserControls/Finance/Bank_Accounting/Payment_From_Customer/PaymentFromCustomer.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }

                if (Request.QueryString["stype"] == "PettyCash")
                {
                    #region
                    ctrl = Page.LoadControl("~/UserControls/Finance/Bank_Accounting/Petty_Cash/PettyCash.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }
                

                #endregion Bank Accounting

                #region GL Account
                if (Request.QueryString["stype"] == "GL_Integration")
                {
                    #region GL_Integration
                    ctrl = Page.LoadControl("~/UserControls/Finance/General_Ledger/GL_Integration/GL_Integration.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion 
                }
                #endregion GL Account

                #endregion   Finance 

                #region Reporting
                if (Request.QueryString["stype"] == "SupplierMasters")
                {
                    #region
                    ctrl = Page.LoadControl("~/UserControls/Reporting/Balance_Sheet/Supplier_Masters/SupplierMasters.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }
                #endregion

                #region Extra
                if (Request.QueryString["stype"] == "Positions_Management")
                {
                    #region
                    ctrl = Page.LoadControl("~/usercontrols/Positions_Management.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }
                if (Request.QueryString["stype"] == "Jobs_Management")
                {
                    #region
                    ctrl = Page.LoadControl("~/usercontrols/Jobs_Management.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }

                if (Request.QueryString["stype"] == "Organisation")
                {
                    #region
                    ctrl = Page.LoadControl("~/usercontrols/Organisation.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }

                #endregion Extra
            }
        }
    }
}
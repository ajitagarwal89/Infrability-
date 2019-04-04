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

                if (Request.QueryString["stype"] == "Dashboard")
                {
                    Response.Redirect("Dashboard.aspx");
                }

                #region System Setting


                if (Request.QueryString["stype"] == "Organisation_Management")
                {
                    #region
                    ctrl = Page.LoadControl("~/usercontrols/Organisation_Management.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }
                if (Request.QueryString["stype"] == "GLAccountSetup")
                {
                    #region
                    ctrl = Page.LoadControl("~/usercontrols/System_Settings/GLAccountSetup.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }

                if (Request.QueryString["stype"] == "PayableSetup")
                {
                    #region OtherSetup

                    ctrl = Page.LoadControl("~/UserControls/System_Settings/PayableSetup.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion

                }

                if (Request.QueryString["stype"] == "ReceivableSetup")
                {
                    #region OtherSetup

                    ctrl = Page.LoadControl("~/UserControls/System_Settings/ReceivableSetup.ascx");
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
                if (Request.QueryString["stype"] == "Auditing")
                {
                    #region Audit Setting
                    ctrl = Page.LoadControl("~/UserControls/System_Settings/Auditing.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }

                if (Request.QueryString["stype"] == "FiscalPeriod")
                {
                    #region
                    ctrl = Page.LoadControl("~/UserControls/System_Settings/FiscalPeriod.ascx");
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


                if (Request.QueryString["stype"] == "Fixed_Asset_Purchase")
                {
                    #region 
                    ctrl = Page.LoadControl("~/UserControls/Finance/Asset_Accounting/Fixed_Asset_Purchase/FixedAssetPurchase.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }


                if (Request.QueryString["stype"] == "capofassets")
                {
                    #region 
                    ctrl = Page.LoadControl("~/UserControls/Finance/Asset_Accounting/Capitalization_of_Assets/CapitalizationofAssets.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }

                if (Request.QueryString["stype"] == "Location")
                {
                    #region 
                    ctrl = Page.LoadControl("~/UserControls/Finance/Asset_Accounting/Capitalization_of_Assets/Location/Location.ascx");
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
                
                  if (Request.QueryString["stype"] == "SupplierGeneralExpenses")
                {
                    #region
                    ctrl = Page.LoadControl("~/UserControls/Finance/Accounts_Payable/Supplier_Employee_General_Expenses/SupplierEmployeeGeneralExpenses.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }


                #endregion Account Payable

                #region Accounts_Receivable
                if (Request.QueryString["stype"] == "CustomerInvoice")
                {
                    #region Accounts_Receivable
                    ctrl = Page.LoadControl("~/UserControls/Finance/Accounts_Receivable/Customer_Invoice_(With_Sales_Order)/CustomerInvoice.ascx");
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

                if (Request.QueryString["stype"] == "PaymentToSupplierEmployee")
                {
                    #region
                    ctrl = Page.LoadControl("~/UserControls/Finance/Bank_Accounting/Payment_To_SupplierEmployee/PaymentToSupplierEmployee.ascx");
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

                if (Request.QueryString["stype"] == "GLAccountConfigurationSettings")
                {
                    #region GLAccountConfigurationSettings
                    ctrl = Page.LoadControl("~/UserControls/Finance/General_Ledger/GLAccountConfigurationSettings/GLAccountConfigurationSettings.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion 
                }
                #endregion GL Account

                #region AssetDisposalDetails
                if (Request.QueryString["stype"] == "AssetDisposalDetails")
                {
                    #region 
                    ctrl = Page.LoadControl("~/UserControls/Finance/Asset_Accounting/Disposal_of_Assets/AssetDisposalDetails.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }
                #endregion 
                #region Transfer_of_Assets
                if (Request.QueryString["stype"] == "Transfer_of_Assets")
                {
                    #region 
                    ctrl = Page.LoadControl("~/UserControls/Finance/Asset_Accounting/Transfer_of_Assets/TransferofAssets.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }
                #endregion

                #region Depreciation_of_Assets
                if (Request.QueryString["stype"] == "DepreciationOfAssets")
                {
                    #region
                    ctrl = Page.LoadControl("~/UserControls/Finance/Asset_Accounting/Depreciation_of_Assets/DepreciationOfAssets.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }
                #endregion Depreciation_of_Assets


                #endregion   Finance 

                #region Reporting
               
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
                    ctrl = Page.LoadControl("~/UserControls/System_Settings/Organisation.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }

                #endregion Extra

                #region HumanResource
                #region EmployeeContacts
                if (Request.QueryString["stype"] == "EmployeeContacts")
                {
                    #region
                    ctrl = Page.LoadControl("~/UserControls/Human_Resource/Employee_Contacts/Employee_Contacts.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }
                #endregion
                #region EmployeeDependents
                if (Request.QueryString["stype"] == "EmployeeDependents")
                {
                    #region
                    ctrl = Page.LoadControl("~/UserControls/Human_Resource/Employee_Dependents/Employee_Dependents.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }
                #endregion
                #region Employee_Master_Data
                #region Manage_Personal_Details
                if (Request.QueryString["stype"] == "mpDetails")
                {
                    #region
                    ctrl = Page.LoadControl("~/UserControls/Human_Resource/Employee_Master_Data/Manage_Personal_Details/Employee.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }
                #endregion
                #endregion

                #region HR

                if (Request.QueryString["stype"] == "hr")
                {
                    #region
                    ctrl = Page.LoadControl("~/UserControls/Human_Resource/HR/HR.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }
                #endregion
                #endregion

                #region Procurement
                if (Request.QueryString["stype"] == "GoodsReceivedNote")
                {
                    #region
                    ctrl = Page.LoadControl("~/UserControls/Procurement/Receive_Goods_or_Services/ReceiveGoodsorServices.ascx");
                    ph.Controls.Clear();
                    ph.Controls.Add(ctrl);
                    #endregion
                }
                #endregion 
            }

             
        }
    }
}
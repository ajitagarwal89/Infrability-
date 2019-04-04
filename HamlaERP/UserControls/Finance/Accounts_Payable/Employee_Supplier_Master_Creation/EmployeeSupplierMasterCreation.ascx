<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeeSupplierMasterCreation.ascx.cs" Inherits="UserControls_Finance_Accounts_Payable_EmployeeSupplierMasterCreation" %>
<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 startimg slideDown">
        <img src="../../../images/supplier.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideUp">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYour" Text="<%$ Resources:GlobalResource, ascxEmployeeSupplierMasterCreation_ltrAddYour%>"></asp:Literal>
            </div>
            <br />
            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, ascxEmployeeSupplierMasterCreation_ltrInformation%>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxEmployeeSupplierMasterCreation_ltrParagraph%>"></asp:Literal>
            </p>

            <p>
                <a class="btn btn-success btn-md" style="width:250px"  href="../../../Finance/Accounts_Payable/Employee_Supplier_Master_Creation/SupplierEmployeeAndGroupAccountForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrNew" Text="<%$ Resources:GlobalResource, EmployeeSupplierMasterCreation_btnEmployeeAndGroupAccount%>"></asp:Literal>
                </a>
              

                 <a class="btn btn-success btn-md" style="width:250px"  href="../../../Finance/Accounts_Payable/Employee_Supplier_Master_Creation/SupplierEmployeeGroupForm.aspx" role="button">

                    <asp:Literal runat="server" ID="Literal1" Text="<%$ Resources:GlobalResource, EmployeeSupplierMasterCreation_btnEmployeeGroup%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" style="width:250px"  href="../../../../Finance/Accounts_Payable/Employee_Supplier_Master_Creation/SupplierEmployeeForm.aspx" role="button">

                    <asp:Literal runat="server" ID="Literal2" Text="<%$ Resources:GlobalResource, EmployeeSupplierMasterCreation_btnSupplierEmployee%>"></asp:Literal>
                </a>
            </p>
        </div>
    </div>
<div class="col-md-2"></div>
</div>
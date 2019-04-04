<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Supplier.ascx.cs" Inherits="UserControls_Finance_Accounts_Payable_Supplier_Master_Creation_Supplier" %>

<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 startimg slideDown">
        <img src="../../../images/supplier.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideUp">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYour" Text="<%$ Resources:GlobalResource, ascxSupplierMasterCreation_ltrAddYour%>"></asp:Literal>
            </div>
            <br />
            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, ascxSupplierMasterCreation_ltrInformation%>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxSupplierMasterCreation_ltrParagraph%>"></asp:Literal>
            </p>

            <p>
                <a class="btn btn-success btn-md" style="width:250px" href="../../../../Finance/Accounts_Payable/Supplier_Master_Creation/PaymentTermsForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrNew" Text="<%$ Resources:GlobalResource, ascxSupplierMasterCreation_btnPaymentTerms%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" style="width:250px" style="width:initial;" href="../../../../Finance/Accounts_Payable/Supplier_Master_Creation/SupplierAndGroupAccountForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrView" Text="<%$ Resources:GlobalResource, ascxSupplierMasterCreation_btnSupplierAndGroupAccount%>"></asp:Literal>
                </a>

                <a class="btn btn-success btn-md" style="width:250px" href="../../../../Finance/Accounts_Payable/Supplier_Master_Creation/SupplierForm.aspx" role="button">
                    <asp:Literal runat="server" ID="Literal1" Text="<%$ Resources:GlobalResource, ascxSupplierMasterCreation_btnSupplier%>"></asp:Literal>
                </a>

                <a class="btn btn-success btn-md" style="width:250px" href="../../../../Finance/Accounts_Payable/Supplier_Master_Creation/SupplierGroupForm.aspx" role="button">
                    <asp:Literal runat="server" ID="Literal2" Text="<%$ Resources:GlobalResource, ascxSupplierMasterCreation_btnSupplierGroup%>"></asp:Literal>
                </a>

            </p>
        </div>
    </div>
<div class="col-md-2"></div>
</div>

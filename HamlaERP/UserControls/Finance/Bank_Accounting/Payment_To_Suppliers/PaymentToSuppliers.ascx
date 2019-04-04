<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PaymentToSuppliers.ascx.cs" Inherits="UserControls_Finance_Bank_Accounting_Payment_To_Suppliers_PaymentToSuppliers" %>
<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 startimg slideDown">
        <img src="../../../images/supplier.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideUp">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYour" Text="<%$ Resources:GlobalResource, ascxPaymentToSupplier_ltrAddYour%>"></asp:Literal>
            </div>
            <br />
            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, ascxPaymentToSupplier_ltrInformation%>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxPaymentToSupplier_ltrParagraph%>"></asp:Literal>
            </p>

            <p>
                <a class="btn btn-success btn-md"  style="width:250px" href="../../../../Finance/Bank_Accounting/Payment_To_Suppliers/PaymentToSupplierForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrNew" Text="<%$ Resources:GlobalResource, btnNew%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md"  style="width:250px" href="../../../../Finance/Bank_Accounting/Payment_To_Suppliers/PaymentToSupplierList.aspx" role="button">

                    <asp:Literal runat="server" ID="ltrView" Text="<%$ Resources:GlobalResource, btnView%>"></asp:Literal>
                </a>

            </p>
        </div>
    </div>
    <div class="col-md-2"></div>
</div>

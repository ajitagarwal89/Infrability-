<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NonPOBasedInvoice.ascx.cs" Inherits="UserControls_Finance_Accounts_Payable_Non_PO_Based_Invoice_Non_PO_Based_Invoice" %>
<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 startimg slideDown">
        <img src="../../../images/supplier.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideUp">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYour" Text="<%$ Resources:GlobalResource, ascxNonPOBasedInvoice_ltrAddYour%>"></asp:Literal>
            </div>
            <br />
            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, ascxNonPOBasedInvoice_ltrInformation%>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxNonPOBasedInvoice_ltrParagraph%>"></asp:Literal>
            </p>

            <p>
                <a class="btn btn-success btn-md" href="../../../../Finance/Accounts_Payable/Non_PO_Based_Invoice/NonPOBasedInvoiceForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrNew" Text="<%$ Resources:GlobalResource, btnNew%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" href="../../../../Finance/Accounts_Payable/Non_PO_Based_Invoice/NonPOBasedInvoiceList.aspx" role="button">

                    <asp:Literal runat="server" ID="ltrView" Text="<%$ Resources:GlobalResource, btnView%>"></asp:Literal>
                </a>

            </p>
        </div>
    </div>
<div class="col-md-2"></div>
</div>
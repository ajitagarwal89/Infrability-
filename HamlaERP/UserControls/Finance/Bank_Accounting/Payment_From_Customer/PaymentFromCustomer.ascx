<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PaymentFromCustomer.ascx.cs" Inherits="UserControls_Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomer" %>
<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 startimg slide">
        <img src="../../../images/supplier.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideUp">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYour" Text="<%$ Resources:GlobalResource, ascxPaymentFromCustomer_ltrAddYour%>"></asp:Literal>
            </div>
            <br />
            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, ascxPaymentFromCustomer_ltrInformation%>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxPaymentFromCustomer_ltrParagraph%>"></asp:Literal>
            </p>

            <p>
                <a class="btn btn-success btn-md" href="../../../../Finance/Bank_Accounting/Payment_From_Customer/PaymentFromCustomerForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrNew" Text="<%$ Resources:GlobalResource, btnNew%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" href="../../../../Finance/Bank_Accounting/Payment_From_Customer/PaymentFromCustomerList.aspx" role="button">

                    <asp:Literal runat="server" ID="ltrView" Text="<%$ Resources:GlobalResource, btnView%>"></asp:Literal>
                </a>

            </p>
        </div>
    </div>
    <div class="col-md-2"></div>
</div>
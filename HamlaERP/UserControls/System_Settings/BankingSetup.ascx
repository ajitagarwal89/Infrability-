<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BankingSetup.ascx.cs" Inherits="UserControls_SystemSettings_BankingSetup" %>
<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 startimg slideDown">
        <img src="../../../../images/supplier.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideUp">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYour" Text="<%$ Resources:GlobalResource, ascxBankingSetup_ltrAddYour%>"></asp:Literal>
            </div>

            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, ascxBankingSetup_ltrInformation%>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxBankingSetup_ltrParagraph%>"></asp:Literal>
            </p>
            <div class="row">
                <a class="btn btn-success btn-md" href="../../System_Settings/BankForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrBankNew" Text="<%$ Resources:GlobalResource, btnBank%>"></asp:Literal>
                </a>

                <a class="btn btn-success btn-md" href="../../System_Settings/BankAccountForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrBankAccountNew" Text="<%$ Resources:GlobalResource, btnBankAccount%>"></asp:Literal>
                </a>

                <a class="btn btn-success btn-md" href="../../System_Settings/CardForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrCardNew" Text="<%$ Resources:GlobalResource, btnCard%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" href="../../System_Settings/CurrencyForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrCurrency" Text="<%$ Resources:GlobalResource, btnCurrency%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" href="../../System_Settings/ChequeBookForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrChequeBook" Text="<%$ Resources:GlobalResource, btnChequeBook%>"></asp:Literal>
                </a>

            </div>




            <p>
            </p>
            <p>
            </p>
        </div>
    </div>
<div class="col-md-2"></div>
</div>

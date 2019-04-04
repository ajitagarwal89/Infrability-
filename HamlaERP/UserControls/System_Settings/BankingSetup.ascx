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
                <a class="btn btn-success btn-md"  style="width:200px" href="../../System_Settings/BankSetup/BankForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrBankNew" Text="<%$ Resources:GlobalResource, ascxBankingSetup_btnBank%>"></asp:Literal>
                </a>

                <a class="btn btn-success btn-md"  style="width:200px" href="../../System_Settings/BankSetup/BankAccountForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrBankAccountNew" Text="<%$ Resources:GlobalResource, ascxBankingSetup_btnBankAccount%>"></asp:Literal>
                </a>

                <a class="btn btn-success btn-md"  style="width:200px" href="../../System_Settings/Card/CardForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrCardNew" Text="<%$ Resources:GlobalResource, ascxBankingSetup_btnCard%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md"  style="width:200px" href="../../System_Settings/Currency/CurrencyForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrCurrency" Text="<%$ Resources:GlobalResource, ascxBankingSetup_btnCurrency%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md"  style="width:200px" href="../../System_Settings/Cheque/ChequeBookForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrChequeBook" Text="<%$ Resources:GlobalResource, ascxBankingSetup_btnChequeBook%>"></asp:Literal>
                </a>

                <a class="btn btn-success btn-md"  style="width:200px" href="../../System_Settings/BankSetup/BankAccountingSetupForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrBankSetup" Text="<%$ Resources:GlobalResource, ascxBankingSetup_btnBankSetup%>"></asp:Literal>
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

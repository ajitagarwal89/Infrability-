<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Others_Setup.ascx.cs" Inherits="UserControls_SystemSettings_Others_Setup" %>
<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 startimg slideDown">
        <img src="../../../../images/supplier.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideUp">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYour" Text="<%$ Resources:GlobalResource, ascxOthers_Setup_ltrAddYour%>"></asp:Literal>
            </div>
            <br />
            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, ascxOthers_Setup_ltrInformation%>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxOthers_Setup_ltrParagraph%>"></asp:Literal>
            </p>
            <div class="row">
                <a class="btn btn-success btn-md" href="../../System_Settings/BatchForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrBatchNew" Text="<%$ Resources:GlobalResource, btBatch%>"></asp:Literal>
                </a>

                <a class="btn btn-success btn-md" href="../../System_Settings/BudgetForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrBudget" Text="<%$ Resources:GlobalResource, btnBudget%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" href="../../System_Settings/BudgetDetailsForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrBudgetDetailsNew" Text="<%$ Resources:GlobalResource, btnBudgetDetails%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" href="../../System_Settings/CountryForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrCountry" Text="<%$ Resources:GlobalResource, btnCountry%>"></asp:Literal>
                </a>

                <a class="btn btn-success btn-md" href="../../System_Settings/GLAccountEntryForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrGLAccountEntry" Text="<%$ Resources:GlobalResource, btnGLAccountEntry%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" style="width: 190px" href="../../System_Settings/GLAccountEntryDetailsForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrGLAccountEntryDetails" Text="<%$ Resources:GlobalResource, btnGLAccountEntryDetails%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" style="width: 190px" href="../../System_Settings/InvoiceAndOrderTypeForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrInvoiceAndOrderType" Text="<%$ Resources:GlobalResource, btnInvoiceAndOrderType%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" href="../../System_Settings/PayablesForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrPayables" Text="<%$ Resources:GlobalResource, btnPayables%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" href="../../System_Settings/SourceDocumentForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrSourceDocument" Text="<%$ Resources:GlobalResource, btnSourceDocument%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" href="../../System_Settings/SitesForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrSites" Text="<%$ Resources:GlobalResource, btnSites%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" href="../../System_Settings/UserForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrUser" Text="<%$ Resources:GlobalResource, btnUser%>"></asp:Literal>
                </a>

                 <a class="btn btn-success btn-md" href="../../System_Settings/OptionSetForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrOptionSet" Text="<%$ Resources:GlobalResource, btnOptionSet%>"></asp:Literal>
                </a>                 

            </div>

        </div>
    </div>
    <div class="col-md-2"></div>
</div>

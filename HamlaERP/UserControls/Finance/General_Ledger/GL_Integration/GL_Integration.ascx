<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GL_Integration.ascx.cs" Inherits="UserControls_Finance_General_Ledger_GL_Integration_GL_Integration" %>

<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 startimg slideDown">
        <img src="../../../../images/supplier.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideUp">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYour" Text="<%$ Resources:GlobalResource, ascxGLIntegration_ltrAddYour%>"></asp:Literal>
            </div>
            <br />
            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, ascxGLIntegration_ltrInformation%>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxGLIntegrationltrParagraph%>"></asp:Literal>
            </p>
            <div class="row">
                <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/General_Ledger/GL_Integration/GLAccountForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrGLAccountNew" Text="<%$ Resources:GlobalResource, btnGLAccount%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/General_Ledger/GL_Integration/GLAccountBudgetForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrGLAccountBudgetNew" Text="<%$ Resources:GlobalResource, btnGLAccountBudget%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/General_Ledger/GL_Integration/GLAccountBudgetDetailsForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrGLAccountBudgetDetails" Text="<%$ Resources:GlobalResource, btnGLAccountBudgetDetails%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/General_Ledger/GL_Integration/GLAccountCategoryForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrGLAccountCategory" Text="<%$ Resources:GlobalResource, btnGLAccountCategory%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/General_Ledger/GL_Integration/GLAccountCurrencyForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrGLAccountCurrency" Text="<%$ Resources:GlobalResource, btnGLAccountCurrency%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/General_Ledger/GL_Integration/GLAccountSummaryForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrGLAccountSummary" Text="<%$ Resources:GlobalResource, btnGLAccountSummary%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/General_Ledger/GL_Integration/GLAccountSummaryDetailsForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrGLAccountSummaryDetails" Text="<%$ Resources:GlobalResource, btnGLAccountSummaryDetails%>"></asp:Literal>
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

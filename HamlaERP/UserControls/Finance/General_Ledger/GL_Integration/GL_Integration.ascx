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
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxGLIntegration_ltrParagraph%>"></asp:Literal>
            </p>
            <div class="row">
                <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/General_Ledger/GL_Integration/GLAccountForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrGLAccountNew" Text="<%$ Resources:GlobalResource,ascxGLIntegration_btnGLAccount%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/General_Ledger/GL_Integration/GLAccountCurrencyForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrGLAccountCurrency" Text="<%$ Resources:GlobalResource,ascxGLIntegration_btnGLAccountCurrency%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/General_Ledger/GL_Integration/GLAccountBudgetForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrGLAccountBudgetNew" Text="<%$ Resources:GlobalResource,ascxGLIntegration_btnGLAccountBudget%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/General_Ledger/GL_Integration/GLAccountBudgetDetailsForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrGLAccountBudgetDetails" Text="<%$ Resources:GlobalResource,ascxGLIntegration_btnGLAccountBudgetDetails%>"></asp:Literal>
                </a>                               
                <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/General_Ledger/GL_Integration/GLAccountSummaryForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrGLAccountSummary" Text="<%$ Resources:GlobalResource,ascxGLIntegration_btnGLAccountSummary%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/General_Ledger/GL_Integration/GLAccountSummaryDetailsForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrGLAccountSummaryDetails" Text="<%$ Resources:GlobalResource,ascxGLIntegration_btnGLAccountSummaryDetails%>"></asp:Literal>
                </a>
                 <a class="btn btn-success btn-md" style="width: 200px" href="../../Finance/General_Ledger/GL_GeneralJournal/GeneralJournalForm.aspx" role="button">
                <asp:Literal runat="server" ID="ltrGeneralJournal" Text="<%$ Resources:GlobalResource, ascxGLIntegration_btnGeneralJournal%>"></asp:Literal>
            </a>
            <a class="btn btn-success btn-md" style="width: 200px"  href="../../Finance/General_Ledger/GL_GeneralJournal/GeneralJournalDetailsForm.aspx" role="button">
                <asp:Literal runat="server" ID="ltrGeneralJournalDetails" Text="<%$ Resources:GlobalResource, ascxGLIntegration_btnGeneralJournalDetails%>"></asp:Literal>
            </a>
                <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/General_Ledger/GL_Integration/GLAccountCategoryForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrGLAccountCategory" Text="<%$ Resources:GlobalResource,ascxGLIntegration_btnGLAccountCategory%>"></asp:Literal>
                </a>
            </div>
         
        </div>
    </div>
    <div class="col-md-2"></div>
</div>

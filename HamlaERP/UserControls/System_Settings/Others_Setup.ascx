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
                <a class="btn btn-success btn-md"  style="width:200px" href="../../System_Settings/Batch/BatchForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrBatchNew" Text="<%$ Resources:GlobalResource, ascxOthers_Setup_btnBatch%>"></asp:Literal>
                </a>

                <a class="btn btn-success btn-md"  style="width:200px" href="../../System_Settings/Budget/BudgetForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrBudget" Text="<%$ Resources:GlobalResource, ascxOthers_Setup_btnBudget%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md"  style="width:200px" href="../../System_Settings/Budget/BudgetDetailsForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrBudgetDetailsNew" Text="<%$ Resources:GlobalResource, ascxOthers_Setup_btnBudgetDetails%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md"  style="width:200px" href="../../System_Settings/Comments/CommentsForm.aspx" role="button">
                    <asp:Literal runat="server" ID="Literal1" Text="<%$ Resources:GlobalResource, ascxOthers_Setup_btnComments %>"></asp:Literal>
                </a>

                <a class="btn btn-success btn-md"  style="width:200px" href="../../System_Settings/Country/CountryForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrCountry" Text="<%$ Resources:GlobalResource, ascxOthers_Setup_btnCountry%>"></asp:Literal>
                </a>

               
                <a class="btn btn-success btn-md"  style="width:200px"  href="../../System_Settings/InvoiceAndOrderType/InvoiceAndOrderTypeForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrInvoiceAndOrderType" Text="<%$ Resources:GlobalResource, ascxOthers_Setup_btnInvoiceAndOrderType%>"></asp:Literal>
                </a>

                <a class="btn btn-success btn-md"  style="width:200px" href="../../System_Settings/OptionSet/OptionSetForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrOptionSet" Text="<%$ Resources:GlobalResource, ascxOthers_Setup_btnOptionSet%>"></asp:Literal>
                </a>

                <a class="btn btn-success btn-md"  style="width:200px" href="../../System_Settings/OptionSet/OptionSet_L1_Form.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrOptionSet_L1" Text="<%$ Resources:GlobalResource, ascxOthers_Setup_btnOptionSet_L1%>"></asp:Literal>
                </a>

                <a class="btn btn-success btn-md"  style="width:200px" href="../../System_Settings/OptionSet/OptionSet_L2_Form.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrOptionSet_L2" Text="<%$ Resources:GlobalResource, ascxOthers_Setup_btnOptionSet_L2%>"></asp:Literal>
                </a>

                <a class="btn btn-success btn-md"  style="width:200px" href="../../System_Settings/OptionSet/OptionSet_L3_Form.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrOptionSet_L3" Text="<%$ Resources:GlobalResource, ascxOthers_Setup_btnOptionSet_L3%>"></asp:Literal>
                </a>
                
                <a class="btn btn-success btn-md"  style="width:200px" href="../../System_Settings/Site/SitesForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrSites" Text="<%$ Resources:GlobalResource, ascxOthers_Setup_btnSites%>"></asp:Literal>
                </a>

                <a class="btn btn-success btn-md"  style="width:200px" href="../../System_Settings/SourceDocument/SourceDocumentForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrSourceDocument" Text="<%$ Resources:GlobalResource, ascxOthers_Setup_btnSourceDocument%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md"  style="width:200px" href="../../System_Settings/Structure/StructureForm.aspx" role="button">
                    <asp:Literal runat="server" ID="Literal2" Text="<%$ Resources:GlobalResource, ascxOthers_Setup_btnStructure%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md"  style="width:200px" href="../../System_Settings/User/UserForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrUser" Text="<%$ Resources:GlobalResource, ascxOthers_Setup_btnUser%>"></asp:Literal>
                </a>
            </div>


        </div>
    </div>
    <div class="col-md-2"></div>
</div>

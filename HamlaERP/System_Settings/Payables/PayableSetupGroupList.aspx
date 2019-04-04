<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PayableSetupGroupList.aspx.cs" Inherits="Finance_Accounts_Payable_Setup_PayableSetupGroupList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">    
    <script src="../../infra_ui/js/System_Settings_JS/Payables_JS/PayableSetupGroupList.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <!--page header start-->
        <div class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button runat="server" ID="btnNew" CssClass="btn btn-success" Text="<%$ Resources:GlobalResource, btnNew%>" OnClick="btnNew_Click"  />
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-success" Text="<%$ Resources:GlobalResource, btnDelete%>" OnClick="btnDelete_Click"  />
                      <asp:LinkButton runat="server" ID="lnkExportToExcel"  CssClass="btn btn-success" OnClick="lnkExportToExcel_Click">                        
                        <asp:Literal runat="server" ID="ltrExportToExcel" Text="<%$Resources:GlobalResource, ltrExportToExcel%>"></asp:Literal>
                    </asp:LinkButton>
                    <asp:UpdatePanel runat="server" ID="updpnlMainSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlMainSearch" DefaultButton="btnMainSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlSearch" onclick="CallMainSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlClose" visible="false" onclick="ClearMainSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnMainSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnMainSearch_Click" />
                                <asp:Button runat="server" ID="btnClearMainSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearMainSearch_Click" />
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

        <div class="ui-content-body">
            <div class="ui-container">
                <div class="row">
                    <h3 class="hepad">
                        <asp:Literal runat="server" ID="ltrSearch" Text="<%$ Resources:GlobalResource, PayableSetup_ltrInformation %>"></asp:Literal></h3>
                    <div class="col-md-12 col-sm-12 colformstyle3">

                        <asp:UpdatePanel runat="server" ID="updPanelData">
                            <ContentTemplate>
                                <div runat="server" id="divError" visible="false" class="alert alert-danger" role="alert">
                                    <asp:Label runat="server" ID="lblError"></asp:Label>
                                </div>
                                <div runat="server" id="divSuccess" visible="false" class="alert alert-success" role="alert">
                                    <asp:Label runat="server" ID="lblSuccess"></asp:Label>
                                </div>
                                <asp:DataGrid runat="server" ClientIDMode="Static" Font-Size="10pt" ID="gvData" AutoGenerateColumns="false" Width="100%" GridLines="None" BorderStyle="None" CssClass="table table-hover">
                                    <Columns>
                                        <asp:TemplateColumn>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkRow" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                       
                                        <asp:BoundColumn DataField="tbl_PayableSetupGroupId" Visible="false"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PayableSetup_InvoiceDescription%>" DataField="tbl_PayableSetup"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PayableSetup_ReturnDescription%>" DataField="PaymentPriority"></asp:BoundColumn>

                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PayableSetup_CreditMemoDescription%>" DataField="MinimumOrder"></asp:BoundColumn>

                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PayableSetup_PaymentDescription%>" DataField="TradeDiscount"></asp:BoundColumn>

                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PayableSetup_VoucherNumber%>" DataField="CalenderYear"></asp:BoundColumn>

                                       

                                        <asp:TemplateColumn HeaderImageUrl="~/images/eye.png" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <button id="lnkView_<%# Container.DataSetIndex + 1 %>" type="button" data-toggle="modal" data-target="#divBasicModal" data-keyboard="false" data-backdrop="static" class="btn btn-default btn-sm btn-block" onclick="setDetails('<%#Eval("PayableSetupGroupId_Self")%>','<%#Eval("Default")%>','<%#Eval("Description")%>','<%#Eval("CurrencyName")%>','<%#Eval("PaymentTermsName")%>','<%#Eval("PaymentPriority")%>','<%#Eval("MinimumOrder")%>','<%#Eval("TradeDiscount")%>','<%#Eval("Opt_MinimumPaymentLable")%>','<%#Eval("Opt_MaximumInvoiceAmtLable")%>','<%#Eval("Opt_CreditLimitLable")%>','<%#Eval("Opt_WriteoffLable")%>','<%#Eval("CalenderYear")%>','<%#Eval("Transaction")%>','<%#Eval("FiscalYear")%>','<%#Eval("Distribution")%>','lnkview_<%# Container.DataSetIndex + 1 %>');">
                                                    <asp:Literal runat="server" ID="ltrView" Text="<%$ Resources:GlobalResource, ltrView%>"></asp:Literal></button>
                                                <button id="lnkViewNextPrev_<%# Container.DataSetIndex + 1 %>" style="display: none;" type="button" class="btn btn-default btn-sm" onclick="setDetails('<%#Eval("PayableSetupGroupId_Self")%>','<%#Eval("Default")%>','<%#Eval("Description")%>','<%#Eval("CurrencyName")%>','<%#Eval("PaymentTermsName")%>','<%#Eval("PaymentPriority")%>','<%#Eval("MinimumOrder")%>','<%#Eval("TradeDiscount")%>','<%#Eval("Opt_MinimumPaymentLable")%>','<%#Eval("Opt_MaximumInvoiceAmtLable")%>','<%#Eval("Opt_CreditLimitLable")%>','<%#Eval("Opt_WriteoffLable")%>','<%#Eval("CalenderYear")%>','<%#Eval("Transaction")%>','<%#Eval("FiscalYear")%>','<%#Eval("Distribution")%>','lnkview_<%# Container.DataSetIndex + 1 %>');"></button>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>

                                        <asp:TemplateColumn HeaderImageUrl="~/images/edit.png" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="gvColLnkBtn" OnClick="gvColLnkBtn_Click" class="btn btn-default btn-sm btn-block" CommandArgument='<%#Eval("tbl_PayableSetupGroupId") %>'>
                                                    <asp:Literal runat="server" ID="ltrEdit" Text="<%$ Resources:GlobalResource, ltrEdit%>"></asp:Literal>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:DataGrid>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnMainSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearMainSearch" />

                            </Triggers>
                        </asp:UpdatePanel>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="divBasicModal" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel"><span>
                        <asp:Literal runat="server" ID="ltrRecordDetails" Text="<%$ Resources:GlobalResource, PayableSetup_ltrTitle %>"></asp:Literal></span></h4>
                </div>
                <div class="modal-body">
                    <table class="table table-striped" style="width: 100%; font-size: 9.5pt;">
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrPayableSetupGroupID" Text="<%$ Resources:GlobalResource, PayableSetupGroup_ltrPayableSetupGroupID%>"></asp:Literal>
                            </td>
                              <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrDefault" Text="<%$ Resources:GlobalResource, PayableSetupGroup_ltrDefault%>"></asp:Literal>
                            </td>
                              <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrDescription" Text="<%$ Resources:GlobalResource, PayableSetupGroup_ltrDescription%>"></asp:Literal>
                            </td>
                        </tr>
                        <tr>

                             <td>
                                <asp:Label ID="lblPayableSetupGroupID" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDefault" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                               <td>
                                <asp:Label ID="lblDescription" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrCurrencyId" Text="<%$ Resources:GlobalResource, PayableSetupGroup_ltrCurrencyId%>"></asp:Literal>
                            </td>
                              <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrPaymentTermsId" Text="<%$ Resources:GlobalResource, PayableSetupGroup_ltrPaymentTermsId%>"></asp:Literal>
                            </td>
                              <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrPaymentPriority" Text="<%$ Resources:GlobalResource, PayableSetupGroup_ltrPaymentPriority%>"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCurrencyId" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPaymentTermsId" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPaymentPriority" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrMinimumOrder" Text="<%$ Resources:GlobalResource, PayableSetupGroup_ltrMinimumOrder%>"></asp:Literal>
                            </td>
                              <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrTradeDiscount" Text="<%$ Resources:GlobalResource, PayableSetupGroup_ltrTradeDiscount%>"></asp:Literal>
                            </td>
                              <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrMinimumPayment" Text="<%$ Resources:GlobalResource, PayableSetupGroup_ltrMinimumPayment%>"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMinimumOrder" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTradeDiscount" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                               <td>
                                <asp:Label ID="lblMinimumPayment" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                        </tr>
                         
                             <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrMaximumInvoiceAmt" Text="<%$ Resources:GlobalResource, PayableSetupGroup_ltrMaximumInvoiceAmt%>"></asp:Literal>
                            </td>
                              <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrCreditLimit" Text="<%$ Resources:GlobalResource, PayableSetupGroup_ltrCreditLimit%>"></asp:Literal>
                            </td>
                              <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrWriteOff" Text="<%$ Resources:GlobalResource, PayableSetupGroup_ltrWriteOff%>"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMaximumInvoiceAmt" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCreditLimit" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                               <td>
                                <asp:Label ID="lblWriteOff" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                             
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrCalenderYear" Text="<%$ Resources:GlobalResource, PayableSetupGroup_ltrltrCalenderYear%>"></asp:Literal>
                            </td>
                              <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrTransaction" Text="<%$ Resources:GlobalResource, PayableSetupGroup_ltrTransaction%>"></asp:Literal>
                            </td>
                              <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrFiscalYear" Text="<%$ Resources:GlobalResource, PayableSetupGroup_ltrFiscalYear%>"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCalenderYear" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTransaction" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                               <td>
                                <asp:Label ID="lblFiscalYear" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                             
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrDistribution" Text="<%$ Resources:GlobalResource, PayableSetupGroup_ltrDistribution%>"></asp:Literal>
                            </td>
                              <td>
                                <asp:Label ID="lblDistribution" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                             </tr>
                        
                    </table>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="btn-group pull-right" role="group" aria-label="...">
                        <a id="btnPrevious" class="btn btn-default" role="button" onclick="showPrevRecord();"><i class="fa fa-chevron-circle-left"></i>
                            <asp:Literal runat="server" ID="ltrPrevious" Text="<%$ Resources:GlobalResource, btnPrevious%>"></asp:Literal></a>
                        <a id="btnNext" class="btn btn-default" role="button" onclick="showNextRecord();">
                            <asp:Literal runat="server" ID="ltrNext" Text="<%$ Resources:GlobalResource, btnNext%>"></asp:Literal>
                            <i class="fa fa-chevron-circle-right"></i></a>
                    </div>
                    <asp:Label ID="lblGvRowId" runat="server" Style="display: none;" ClientIDMode="Static"></asp:Label>
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrClose" Text="<%$ Resources:GlobalResource, ltrClose%>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


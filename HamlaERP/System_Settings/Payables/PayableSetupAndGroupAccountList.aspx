<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PayableSetupAndGroupAccountList.aspx.cs" Inherits="Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../../infra_ui/js/System_Settings_JS/Payables_JS/PayableSetupAndGroupAccountList.js"></script>
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
                                       
                                        <asp:BoundColumn DataField="tbl_PayableSetupAndGroupAccountId" Visible="false"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_PayableSetupGroupId%>" DataField="tbl_PayableSetup"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_ChequeBookId%>" DataField="ChequeBookName"></asp:BoundColumn>

                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_Opt_AccountType%>" DataField="Opt_AccountTypeLable"></asp:BoundColumn>

                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_PaymentMode%>" DataField="PaymentMode"></asp:BoundColumn>

                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_tbl_GLAccountId_Cash%>" DataField="Cash"></asp:BoundColumn>

                                       

                                        <asp:TemplateColumn HeaderImageUrl="~/images/eye.png" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <button id="lnkView_<%# Container.DataSetIndex + 1 %>" type="button" data-toggle="modal" data-target="#divBasicModal" data-keyboard="false" data-backdrop="static" class="btn btn-default btn-sm btn-block" onclick="setDetails('<%#Eval("tbl_PayableSetupGroup")%>','<%#Eval("ChequeBookName")%>','<%#Eval("Opt_AccountTypeLable")%>','<%#Eval("PaymentMode")%>','<%#Eval("Cash")%>','<%#Eval("AccountReceivable")%>','<%#Eval("Sales")%>','<%#Eval("CostOfSales")%>','<%#Eval("Inventory")%>','<%#Eval("AccuralDifferedA_C")%>','lnkview_<%# Container.DataSetIndex + 1 %>');">
                                                    <asp:Literal runat="server" ID="ltrView" Text="<%$ Resources:GlobalResource, ltrView%>"></asp:Literal></button>
                                                <button id="lnkViewNextPrev_<%# Container.DataSetIndex + 1 %>" style="display: none;" type="button" class="btn btn-default btn-sm" onclick="setDetails('<%#Eval("tbl_PayableSetupGroup")%>','<%#Eval("ChequeBookName")%>','<%#Eval("Opt_AccountTypeLable")%>','<%#Eval("PaymentMode")%>','<%#Eval("Cash")%>','<%#Eval("AccountReceivable")%>','<%#Eval("Sales")%>','<%#Eval("CostOfSales")%>','<%#Eval("Inventory")%>','<%#Eval("AccuralDifferedA_C")%>','lnkview_<%# Container.DataSetIndex + 1 %>');"></button>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>

                                        <asp:TemplateColumn HeaderImageUrl="~/images/edit.png" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="gvColLnkBtn" OnClick="gvColLnkBtn_Click" class="btn btn-default btn-sm btn-block" CommandArgument='<%#Eval("tbl_PayableSetupAndGroupAccountId") %>'>
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
                        <asp:Literal runat="server" ID="ltrRecordDetails" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_ltrTitle %>"></asp:Literal></span></h4>
                </div>
                <div class="modal-body">
                    <table class="table table-striped" style="width: 100%; font-size: 9.5pt;">
                        <tr>
                             
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrPayableSetupGroupID" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_ltrPayableSetupGroupID%>"></asp:Literal>
                            </td>
                              <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrChequeBookId" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_ltrChequeBookId%>"></asp:Literal>
                            </td>
                              
                        </tr>
                        <tr>
                            
                             <td>
                                <asp:Label ID="lblPayableSetupGroupID" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblChequeBookId" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                             
                        </tr>

                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrAccountType" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_ltrAccountType%>"></asp:Literal>
                            </td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrPaymentMode" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_ltrPaymentMode%>"></asp:Literal>
                            </td>
                              <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrGLAccountId_Cash" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_ltrGLAccountId_Cash%>"></asp:Literal>
                            </td>
                             
                        </tr>
                        <tr>
                              <td>
                                <asp:Label ID="lblAccountType" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPaymentMode" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblGLAccountId_Cash" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                           
                        </tr>

                        <tr>
                             <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrGLAccountId_AccountReceivable" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_ltrGLAccountId_AccountReceivable%>"></asp:Literal>
                            </td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrGLAccountId_Sales" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_ltrGLAccountId_Sales%>"></asp:Literal>
                            </td>
                              <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrGLAccountId_CostOfSales" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_ltrGLAccountId_CostOfSales%>"></asp:Literal>
                            </td>
                              
                        </tr>
                        <tr>
                             <td>
                                <asp:Label ID="lblGLAccountId_AccountReceivable" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblGLAccountId_Sales" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblGLAccountId_CostOfSales" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                              
                        </tr>
                         
                             <tr>
                                 <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrGLAccountId_Inventory" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_ltrGLAccountId_Inventory%>"></asp:Literal>
                            </td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrGLAccountId_AccuralDifferedA_C" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_ltrGLAccountId_AccuralDifferedA_C%>"></asp:Literal>
                            </td>
                            
                        </tr>
                        
                        
                        <tr>
                             <td>
                                <asp:Label ID="lblGLAccountId_Inventory" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblGLAccountId_AccuralDifferedA_C" runat="server" ClientIDMode="Static"></asp:Label>
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


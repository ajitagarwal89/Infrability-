<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GLAccountSetupList.aspx.cs" Inherits="System_Settings_GLAccountSetupList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../infra_ui/js/System_Settings_JS/GLAccountSetupList.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <div class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button runat="server" ID="btnNew" CssClass="btn btn-success" Text="<%$ Resources:GlobalResource, btnNew%>" OnClick="btnNew_Click" />
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-success" Text="<%$ Resources:GlobalResource, btnDelete%>" OnClick="btnDelete_Click" />
                    <asp:LinkButton runat="server" ID="lnkExportToExcel" OnClick="lnkExportToExcel_Click" CssClass="btn btn-success">
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
                                <asp:Literal runat="server" ID="ltrSearch" Text="<%$ Resources:GlobalResource, GLAccountSetup_ltrGLAccountSetupDetails %>"></asp:Literal></h3>
                            <div class="col-md-12 col-sm-12 colformstyle3">
                                <div runat="server" id="divError" visible="false" class="alert alert-danger" role="alert">
                                    <asp:Label runat="server" ID="lblError"></asp:Label>
                                </div>
                                <div runat="server" id="divSuccess" visible="false" class="alert alert-success" role="alert">
                                    <asp:Label runat="server" ID="lblSuccess"></asp:Label>
                                </div>
                                <asp:UpdatePanel runat="server" ID="updPanelData">
                                    <ContentTemplate>

                                        <asp:DataGrid runat="server" ClientIDMode="Static" Font-Size="10pt" ID="gvData" AutoGenerateColumns="false" Width="100%" GridLines="None" BorderStyle="None" CssClass="table table-hover">
                                            <Columns>
                                                <asp:TemplateColumn>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkRow" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="tbl_GLAccountSetupId" Visible="false"></asp:BoundColumn>                                                <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, GLAccountSetup_htDisplay%>" DataField="Display"></asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, GLAccountSetup_htGLAccountId_Account%>" DataField="GLAccountId_Account"></asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, GLAccountSetup_htAccounts%>" DataField="Accounts"></asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, GLAccountSetup_htTransactions%>" DataField="Transactions"></asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, GLAccountSetup_htPostingToHistory%>" DataField="PostingToHistory"></asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, GLAccountSetup_htDeletionOfSavedTransactions%>" DataField="DeletionOfSavedTransactions"></asp:BoundColumn>


                                                <asp:TemplateColumn HeaderImageUrl="~/images/eye.png" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <button id="lnkView_<%# Container.DataSetIndex + 1 %>" type="button" data-toggle="modal" data-target="#divBasicModal" data-keyboard="false" data-backdrop="static" class="btn btn-default btn-sm btn-block" onclick="setDetails('<%#Eval("Display")%>','<%#Eval("GLAccountId_Account")%>','<%#Eval("Accounts")%>','<%#Eval("Transactions")%>','<%#Eval("PostingToHistory")%>','<%#Eval("DeletionOfSavedTransactions")%>','lnkview_<%# Container.DataSetIndex + 1 %>');">
                                                            <asp:Literal runat="server" ID="ltrView" Text="<%$ Resources:GlobalResource, ltrView%>"></asp:Literal></button>
                                                        <button id="lnkViewNextPrev_<%# Container.DataSetIndex + 1 %>" style="display: none;" type="button" class="btn btn-default btn-sm" onclick="setDetails('<%#Eval("Display")%>', '<%#Eval("GLAccountId_Account")%>', '<%#Eval("Accounts")%>','<%#Eval("Transactions")%>','<%#Eval("PostingToHistory")%>','<%#Eval("DeletionOfSavedTransactions")%>','lnkview_<%# Container.DataSetIndex + 1 %>');"></button>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>

                                                <asp:TemplateColumn HeaderImageUrl="~/images/edit.png" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="gvColLnkBtn" class="btn btn-default btn-sm btn-block" OnClick="gvColLnkBtn_Click" CommandArgument='<%#Eval("tbl_GLAccountSetupId") %>'>
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
                                <asp:Literal runat="server" ID="ltrRecordDetails" Text="<%$ Resources:GlobalResource, GLAccountSetup_ltrGLAccountSetup %>"></asp:Literal></span></h4>
                        </div>
                        <div class="modal-body">
                            <table class="table table-striped" style="width: 100%; font-size: 9.5pt;">
                                <tr>
                                    <td class="auto-style1">
                                        <asp:Literal runat="server" ID="ltrDisplay" Text="<%$ Resources:GlobalResource, GLAccountSetup_ltrDisplay%>"></asp:Literal></td>
                                    <td class="auto-style1">
                                        <asp:Literal runat="server" ID="ltrGLAccountId_Account" Text="<%$ Resources:GlobalResource, GLAccountSetup_ltrGLAccountId_Account%>"></asp:Literal></td>
                                    <td class="auto-style1">
                                        <asp:Literal runat="server" ID="ltrAccounts" Text="<%$ Resources:GlobalResource, GLAccountSetup_ltrAccounts%>"></asp:Literal></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDisplay" runat="server" ClientIDMode="Static"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblGLAccountId_Account" runat="server" ClientIDMode="Static"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblAccounts" runat="server" ClientIDMode="Static"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">
                                        <asp:Literal runat="server" ID="ltrTransactions" Text="<%$ Resources:GlobalResource, GLAccountSetup_ltrTransactions%>"></asp:Literal></td>
                                    <td class="auto-style1">
                                        <asp:Literal runat="server" ID="ltrPostingToHistory" Text="<%$ Resources:GlobalResource, GLAccountSetup_ltrPostingToHistory%>"></asp:Literal></td>
                                    <td class="auto-style1">
                                        <asp:Literal runat="server" ID="ltrDeletionOfSavedTransactions" Text="<%$ Resources:GlobalResource, GLAccountSetup_ltrDeletionOfSavedTransactions%>"></asp:Literal></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblTransactions" runat="server" ClientIDMode="Static"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblPostingToHistory" runat="server" ClientIDMode="Static"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lbllDeletionOfSavedTransactions" runat="server" ClientIDMode="Static"></asp:Label>
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


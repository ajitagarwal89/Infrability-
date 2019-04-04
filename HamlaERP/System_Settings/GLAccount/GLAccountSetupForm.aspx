<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GLAccountSetupForm.aspx.cs" Inherits="System_Settings_GLAccountSetupForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../infra_ui/js/System_Settings_JS/GLAccountSetupForm.js"></script>
    <script src="../infra_ui/js/CommonJS/CommonValidations.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <!--page header start-->
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" OnClick="btnSave_Click" Text="<%$ Resources:GlobalResource, btnSave%>" />
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-success" OnClick="btnUpdate_Click" Text="<%$ Resources:GlobalResource, btnUpdate%>" />
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-success" OnClick="btnDelete_Click" Text="<%$ Resources:GlobalResource, btnDelete%>" />
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-success" OnClick="btnBack_Click" Text="<%$ Resources:GlobalResource, btnBack%>" formnovalidate="formnovalidate"></asp:Button>
                    <asp:Button runat="server" ID="btnClear" CssClass="btn btn-success" OnClientClick="return ClearForm();" Text="<%$ Resources:GlobalResource, btnClear%>" formnovalidate="formnovalidate"></asp:Button>
                    <asp:Button runat="server" ID="btnAuditHistory" CssClass="btn btn-success" Text="<%$ Resources:GlobalResource, btnAuditHistory%>" formnovalidate="formnovalidate" OnClick="btnAuditHistory_Click" />
                </div>
            </div>
        </div>

        <div class="ui-content-body">
            <div class="ui-container">
                <div class="row">
                    <h3 class="hepad">
                        <asp:Label runat="server" ID="lblHeading"></asp:Label></h3>
                    <div class="col-md-12 col-sm-12 colformstyle">
                        <div runat="server" id="divError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblError"></asp:Label>
                        </div>
                        <div runat="server" id="divSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblSuccess"></asp:Label>
                        </div>
                        <div class="form-group col-md-12" style="background-color: #f6f6f6">
                            <h5>
                                <asp:Literal runat="server" ID="ltrGLAccountSetupInformation" Text="<%$ Resources:GlobalResource, GLAccountSetup_ltrGLAccountSetupInformation%>"></asp:Literal></h5>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDisplay" Text="<%$ Resources:GlobalResource, GLAccountSetup_lblDisplay %>"></asp:Label>
                            <asp:CheckBox ID="chkDisplay" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:CheckBox>
                        </div>
                                              
                          <div class="form-group col-md-4 col-sm-4">
						 <div>
                                <asp:Label runat="server" ID="lbl_GLAccountId_Account" Text="<%$ Resources:GlobalResource, GLAccountSetuplbl_GLAccountId_Account%>"></asp:Label>
                            </div>
                         <div class="input-group">
                                <asp:TextBox ID="txtGLAccountId_Account" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addonGLAccountId_Account">
                                     <a href="#" data-toggle="modal" data-target="#basicModalGLAccountId_AccountSearch" data-keyboard="false" data-backdrop="static" onclick="CallGLAccountId_AccountRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountId_AccountGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>

                      
                    </div>
                        
                          <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lbl_Accounts" Text="<%$ Resources:GlobalResource, GLAccountSetup_lbl_Accounts %>"></asp:Label>
                            <asp:CheckBox ID="chkAccounts" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:CheckBox>
                        </div>

                          <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblTransactions" Text="<%$ Resources:GlobalResource, GLAccountSetup_lblTransactions %>"></asp:Label>
                            <asp:CheckBox ID="chkTransactions" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:CheckBox>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPostingToHistory" Text="<%$ Resources:GlobalResource, GLAccountSetup_lblPostingToHistory%>"></asp:Label>
                            <asp:CheckBox ID="chkPostingToHistory" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:CheckBox>
                        </div>

                          <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDeletionOfSavedTransactions" Text="<%$ Resources:GlobalResource, GLAccountSetup_lblDeletionOfSavedTransactions%>"></asp:Label>
                            <asp:CheckBox ID="chkDeletionOfSavedTransactions" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:CheckBox>
                        </div>

                </div>
            </div>
        </div>
    </div>

        
				 <div class="modal fade" id="basicModalGLAccountId_AccountSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGLAccountId_Account"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountId_AccountTitle" Text="<%$ Resources:GlobalResource, GLAccountSetup_ltrGLAccountId_AccountTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlGLAccountId_CashSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlGLAccountId_AccountSearch" DefaultButton="btnGLAccountId_AccountSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtGLAccountId_AccountSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlGLAccountId_AccountSearch" onclick="CallGLAccountId_AccountSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlGLAccountId_AccountClose" visible="false" onclick="ClearGLAccountId_AccountSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnGLAccountId_AccountSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnGLAccountId_AccountSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearGLAccountId_AccountSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearGLAccountId_AccountSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountId_AccountSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_AccountSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountId_AccountSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_AccountSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgData" AssociatedUpdatePanelID="updpnlgvGLAccountId_AccountSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountId_AccountSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnGLAccountId_AccountRefresh" ClientIDMode="Static" OnClick="btnGLAccountId_AccountRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvGLAccountId_AccountSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountSetup_htAccountNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetGLAccountId_AccountDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">

                                                    <asp:Literal runat="server" ID="ltrGLAccountId_Cash" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountSetup_htGLAccountId_AccountGuid  %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvGLAccountEntryGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnGLAccountId_AccountSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearGLAccountId_AccountSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrGLAccountId_AccountClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

			

        </div>
</asp:Content>


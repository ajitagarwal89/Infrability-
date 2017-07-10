<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GLAccountEntryDetailsForm.aspx.cs" Inherits="System_Settings_GLAccountEntryDetailsForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../infra_ui/js/System_Settings_JS/GLAccountEntryDetailsForm.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <!--page header start-->
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" OnClick="btnSave_Click" Text="<%$ Resources:GlobalResource, btnSave%>" />
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-success" OnClick="btnUpdate_Click" Text="<%$ Resources:GlobalResource, btnUpdate%>" />
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-success" OnClick="btnDelete_Click" Text="<%$ Resources:GlobalResource, btnDelete%>" />
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-success" OnClick="btnBack_Click" Text="<%$ Resources:GlobalResource, btnBack%>" formnovalidate="formnovalidate"/>
                    <asp:Button runat="server" ID="btnClear" CssClass="btn btn-success" OnClientClick="return ClearForm();" Text="<%$ Resources:GlobalResource, btnClear%>" formnovalidate="formnovalidate"></asp:Button>
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
                                <asp:Literal runat="server" ID="ltrGLAccountEntryDetailsInformation" Text="<%$ Resources:GlobalResource, GLAccountEntryDetails_ltrGLAccountEntryDetailsInformation%>"></asp:Literal></h5>
                        </div>
                           <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblGLAccountEntry" Text="<%$ Resources:GlobalResource, GLAccountEntryDetails_lblGLAccountEntry%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtGLAccountEntry" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addonGLAccountEntry">
                                     <a href="#" data-toggle="modal" data-target="#basicModalGLAccountEntrySearch" data-keyboard="false" data-backdrop="static" onclick="CallGLAccountEntryRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountEntryGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>


                         <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblGLAccountId" Text="<%$ Resources:GlobalResource, GLAccountEntryDetails_lblGLAccountId%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtGLAccount" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon1">
                                     <a href="#" data-toggle="modal" data-target="#basicModalGLAccountSearch" data-keyboard="false" data-backdrop="static" onclick="CallGLAccountRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                      <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDebit" Text="<%$ Resources:GlobalResource, GLAccountEntryDetails_lblDebit %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtDebit" ClientIDMode="Static" class="form-control " placeholder="" required="required" autofocus="autofocus" ></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblCredit" Text="<%$ Resources:GlobalResource, GLAccountEntryDetails_lblCredit %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtCredit" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

   <div class="modal fade" id="basicModalGLAccountEntrySearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGLAccountEntryTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountEntryTitle" Text="<%$ Resources:GlobalResource, GLAccountEntryDetails_ltrGLAccountEntry %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlGLAccountEntrySearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlGLAccountEntrySearch" DefaultButton="btnGLAccountEntrySearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtGLAccountEntrySearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlGLAccountEntrySearch" onclick="CallGLAccountEntrySearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlGLAccountEntryClose" visible="false" onclick="ClearGLAccountEntrySearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnGLAccountEntrySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnGLAccountEntrySearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearGLAccountEntrySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearGLAccountEntrySearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountEntrySearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountEntrySearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountEntrySearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountEntrySearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgData" AssociatedUpdatePanelID="updpnlgvGLAccountEntrySearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountEntrySearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnGLAccountEntryRefresh" ClientIDMode="Static" OnClick="btnGLAccountEntryRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvGLAccountEntrySearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountEntryDetails_htAccountEntry%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetGLAccountEntryDetails('<%#Eval("JournalEntry")%>','<%#Eval("tbl_GLAccountEntryId")%>');">

                                                    <asp:Literal runat="server" ID="ltrJournalEntry" Text='<%# Bind("JournalEntry") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountEntryDetails_htJournalEntryGuid  %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvJGLAccountEntryGuid" runat="server" Text='<%# Bind("tbl_GLAccountEntryId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnGLAccountEntrySearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearGLAccountEntrySearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrGLAccountEntryClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
   <div class="modal fade" id="basicModalGLAccountSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGlAccountTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccount" Text="<%$ Resources:GlobalResource, GLAccountEntryDetails_ltrGLAccount%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlGLAccount">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlGLAccount" DefaultButton="btnGLAccountSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtGLAccountSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlGLAccountSearch" onclick="CallGLAccountSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlGLAccountClose" visible="false" onclick="ClearGLAccountSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnGLAccountSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnGLAccountSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearGLAccountSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearGLAccountSearch_Click" formnovalidate="" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgGLAccountData" AssociatedUpdatePanelID="updpnlgvGLAccountSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnGLAccountRefresh" ClientIDMode="Static" OnClick="btnGLAccountRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvGLAccountSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountEntryDetails_htAccountNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetGLAccountDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvGLAccountCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountEntryDetails_htGLAccountGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvGLAccountGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnGLAccountSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearGLAccountSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divGLAccountFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblGLAccountClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

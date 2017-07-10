<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GLAccountEntryForm.aspx.cs" Inherits="System_Settings_GLAccountEntryForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../infra_ui/js/System_Settings_JS/GLAccountEntryForm.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <!--page header start-->
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" OnClick="btnSave_Click" Text="<%$ Resources:GlobalResource, btnSave%>" />
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-success" OnClick="btnUpdate_Click" Text="<%$ Resources:GlobalResource, btnUpdate%>" />
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-success" OnClick="btnDelete_Click" Text="<%$ Resources:GlobalResource, btnDelete%>" formnovalidate="formnovalidate"></asp:Button>
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-success" OnClick="btnBack_Click" Text="<%$ Resources:GlobalResource, btnBack%>" formnovalidate="formnovalidate" />
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
                                <asp:Literal runat="server" ID="ltr_GLAccountEntry_information" Text="<%$ Resources:GlobalResource, GLAccountEntry_ltrInformation%>"></asp:Literal></h5>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblJournalEntry" Text="<%$ Resources:GlobalResource, GLAccountEntry_lblJournalEntry %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtJournal" ClientIDMode="Static" class="form-control" placeholder="" required></asp:TextBox>
                        </div>
                        
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblTransactionType" Text="<%$ Resources:GlobalResource, GLAccountEntry_lblTransactionType %>"></asp:Label>

                            <asp:CheckBox ID="chkTransactionType" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required />

                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblTransactionDate" Text="<%$ Resources:GlobalResource, GLAccountEntry_lblTransactionDate %>"></asp:Label>


                            <asp:TextBox runat="server" ID="txtTransactionDate" ClientIDMode="Static" class="form-control" placeholder="" required TextMode="Date"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblBatchId" Text="<%$ Resources:GlobalResource, GLAccountEntry_lblBatchId %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtBatch" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon">
                                    <a href="#" data-toggle="modal" data-target="#basicModalBatchSearch" data-keyboard="false" data-backdrop="static" onclick="CallBatchRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtBatchGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCurrencyId" Text="<%$ Resources:GlobalResource, GLAccountEntry_lblCurrencyId %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtCurrency" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon_Cuurency">
                                    <a href="#" data-toggle="modal" data-target="#basicModalCurrencySearch" data-keyboard="false" data-backdrop="static" onclick="CallCurrencyRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtCurrencyGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblSourceDocument" Text="<%$ Resources:GlobalResource, GLAccountEntry_lblSourceDocument %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtSourceDocument" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon2">
                                     <a href="#" data-toggle="modal" data-target="#basicModalSourceDocumentSearch" data-keyboard="false" data-backdrop="static" onclick="CallSource_DocumentRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtSourceDocumentGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                        
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblReference" Text="<%$ Resources:GlobalResource, GLAccountEntry_lblReference %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtReference" ClientIDMode="Static" class="form-control" Placeholder="" required></asp:TextBox>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="basicModalBatchSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalBatchTitle"><span>
                        <asp:Literal runat="server" ID="ltrBatchTitle" Text="<%$ Resources:GlobalResource, GLAccountEntry_ltrBatch_List %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlBatchSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlBatchSearch" DefaultButton="btnBatchSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtBatchSearch" CssClass="form-control" placeholder="Search..." autofocus></asp:TextBox>
                                        <a runat="server" id="btnHtmlBatchSearch" onclick="CallBatchSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlBatchClose" visible="false" onclick="ClearBatchSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnBatchSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnBatchSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearBatchSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearBatchSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divBatchSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblBatchSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divBatchSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblBatchSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgData" AssociatedUpdatePanelID="updpnlgvBatchSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvBatchSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnBatchRefresh" ClientIDMode="Static" OnClick="btnBatchRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvBatchSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountEntry_htCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetBatchDetails('<%#Eval("BatchName")%>','<%#Eval("tbl_BatchId")%>');">

                                                    <asp:Literal runat="server" ID="ltrgvBatchType" Text='<%# Bind("Opt_BatchType") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountEntry_htName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvBatchName" runat="server" Text='<%# Bind("BatchName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Batch Guid" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvBatchGuid" runat="server" Text='<%# Bind("tbl_BatchId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnBatchSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearBatchSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrBatchClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="basicModalSourceDocumentSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrSourceDocumentTitle"><span>
                        <asp:Literal runat="server" ID="ltr_Source_Document" Text="<%$ Resources:GlobalResource, GLAccountEntry_ltrSourceDocument %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlSource_Document">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlSource_DocumentSearch" DefaultButton="btnSource_DocumentSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtSource_DocumentSearch" CssClass="form-control" placeholder="Search..." autofocus></asp:TextBox>
                                        <a runat="server" id="btnHtmlSource_DocumentSearch" onclick="CallSource_DocumentSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlSource_DocumentClose" visible="false" onclick="ClearSource_DocumentSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnSource_DocumentSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnSource_DocumentSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearSource_DocumentSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearSource_DocumentSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divSource_DocumentSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblSource_DocumentSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divSource_DocumentSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblSource_DocumentSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateSource_DocumentProgress" AssociatedUpdatePanelID="updpnlgvSource_DocumentSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvSource_DocumentSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnSource_DocumentRefresh" ClientIDMode="Static" OnClick="btnSource_DocumentRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvSource_DocumentSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,GLAccountEntry_htSource_DocumentNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetSource_DocumentDetails('<%#Eval("Description")%>','<%#Eval("tbl_SourceDocumentId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvtSourceDocumentNumber" Text='<%# Bind("DocumentNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountEntry_htSourceDocumentName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSource_DocumentDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SourceDocumentId Guid" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSourceDocumentId" runat="server" Text='<%# Bind("tbl_SourceDocumentId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnSource_DocumentSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearSource_DocumentSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div1">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrSource_DocumentClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="basicModalCurrencySearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalCurrencyTitle"><span>
                        <asp:Literal runat="server" ID="ltrCurrencyTitle" Text="<%$ Resources:GlobalResource, GLAccountEntry_ltrCurrency%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlCurrency">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlCurrency" DefaultButton="btnCurrencySearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtCurrencySearch" CssClass="form-control" placeholder="Search..." autofocus></asp:TextBox>
                                        <a runat="server" id="btnHtmlCurrencySearch" onclick="CallCurrencySearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlCurrencyClose" visible="false" onclick="ClearCurrencySearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnCurrencySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnCurrencySearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearCurrencySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearCurrencySearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divCurrencySearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblCurrencySearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divCurrencySearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblCurrencySearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgCurrencyData" AssociatedUpdatePanelID="updpnlgvCurrencySearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvCurrencySearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnCurrencyRefresh" ClientIDMode="Static" OnClick="btnCurrencyRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvCurrencySearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,GLAccountEntry_htCurrencyName%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCurrencyDetails('<%#Eval("CurrencyName")%>','<%#Eval("tbl_CurrencyId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCurrencyCode" Text='<%# Bind("CurrencyCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Currency Guid" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCurrencyGuid" runat="server" Text='<%# Bind("CurrencyName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnCurrencySearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearCurrencySearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divCurrencyFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblCurrencyClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>


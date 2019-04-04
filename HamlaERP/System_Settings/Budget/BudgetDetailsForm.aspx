<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BudgetDetailsForm.aspx.cs" Inherits="System_Settings_BudgetDetailsForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../infra_ui/js/System_Settings_JS/BudgetDetailsForm.js"></script>
    <script src="../infra_ui/js/CommonJS/CommonValidations.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">

        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" OnClick="btnSave_Click" Text="<%$ Resources:GlobalResource, btnSave%>" />
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-success" OnClick="btnUpdate_Click" Text="<%$ Resources:GlobalResource, btnUpdate%>" />
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-success" OnClick="btnDelete_Click" Text="<%$ Resources:GlobalResource, btnDelete%>" />
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-success" OnClick="btnBack_Click" Text="<%$ Resources:GlobalResource, btnBack%>" formnovalidate="formnovalidate" />
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
                                <asp:Literal runat="server" ID="ltr_BudgetDetails_BudgetInformations" Text="<%$ Resources:GlobalResource, BudgetDetails_ltrBudgetInformations%>"></asp:Literal></h5>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblBudgetId" Text="<%$ Resources:GlobalResource, BudgetDetails_lblBudget %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtBudget" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addonBudget">
                                    <a href="#" data-toggle="modal" data-target="#basicModalBudgetSearch" data-keyboard="false" data-backdrop="static" onclick="CallBudgetRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtBudgetGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblFiscalId" Text="<%$ Resources:GlobalResource, BudgetDetails_lblFiscalId%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtFiscalPeriod" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addonFiscalPeriod">
                                    <a href="#" data-toggle="modal" data-target="#basicModalFiscalPeriodSearch" data-keyboard="false" data-backdrop="static" onclick="CallFiscalPeriodRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtFiscalPeriodGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPeriodDate" Text="<%$ Resources:GlobalResource, BudgetDetails_PeriodDate%>"></asp:Label>
                            <asp:TextBox TextMode="Date" runat="server" ID="txtPeriodDate" class="form-control" ClientIDMode="Static" Placeholder="" required="required"></asp:TextBox>

                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPeriod" Text="<%$ Resources:GlobalResource, BudgetDetails_lblPeriod%>"> ></asp:Label>

                            <asp:TextBox runat="server" ID="txtPeriod" ClientIDMode="Static" onkeypress="return isNumberKey(this);" MaxLength="1"  class="form-control" Placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPeriodName" Text="<%$ Resources:GlobalResource, BudgetDetails_lblPeriodName%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtPeriodName" class="form-control" ClientIDMode="Static" onkeypress="return isAlphaKey(this);" MaxLength="50"  Placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAmount" Text="<%$ Resources:GlobalResource, BudgetDetails_Amount%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtAmount" class="form-control" ClientIDMode="Static"  onkeypress="return isNumberKeyPoint(this);" MaxLength="9" Placeholder="" required="required"></asp:TextBox>

                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="basicModalBudgetSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header" style="text-align: left;">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title" id="hdrModalBudgetTitle"><span>
                            <asp:Literal runat="server" ID="ltrBudgetTitle" Text="<%$ Resources:GlobalResource, BudgetDetails_ltrtBudgetTitle %>"></asp:Literal>
                        </span>
                        </h4>
                    </div>
                    <div class="modal-body">

                        <asp:UpdatePanel runat="server" ID="updpnlBudgetSearch">
                            <ContentTemplate>
                                <asp:Panel runat="server" ID="pnlBudgetSearch" DefaultButton="btnBudgetSearch">
                                    <div class="col-md-4 col-xs-5">
                                        <div class="icon-addon addon-md">
                                            <asp:TextBox runat="server" ID="txtBudgetSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                            <a runat="server" id="btnHtmlBudgetSearch" onclick="CallBudgetSearch();" class="fa fa-search"></a>
                                            <a runat="server" id="btnHtmlBudgetClose" visible="false" onclick="ClearBudgetSearch();" class="fa fa-close closex"></a>
                                        </div>
                                    </div>
                                    <asp:Button runat="server" ID="btnBudgetSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnBudgetSearch_Click" formnovalidate="formnovalidate" />
                                    <asp:Button runat="server" ID="btnClearBudgetSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearBudgetSearch_Click" formnovalidate="formnovalidate" />

                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div class="col-md-12 col-sm-12 colformstyle3">
                            <div runat="server" id="divBudgetSearchError" visible="false" class="alert alert-danger" role="alert">
                                <asp:Label runat="server" ID="lblBudgetSearchError"></asp:Label>
                            </div>
                            <div runat="server" id="divBudgetSearchSuccess" visible="false" class="alert alert-success" role="alert">
                                <asp:Label runat="server" ID="lblBudgetSearchSuccess"></asp:Label>
                            </div>
                        </div>
                        <div>
                            <asp:UpdateProgress runat="server" ID="updProgBudgetData" AssociatedUpdatePanelID="updpnlgvBudgetSearch">
                                <ProgressTemplate>
                                    Loading...
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:UpdatePanel runat="server" ID="updpnlgvBudgetSearch">
                                <ContentTemplate>
                                    <asp:Button runat="server" ID="btntBudgetRefresh" ClientIDMode="Static" OnClick="btnBudgetRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                    <asp:GridView ID="gvBudgetSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                        EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                        <Columns>
                                            <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, BudgetDetails_htBudgetNumber%>">
                                                <ItemTemplate>
                                                    <a href="#" data-dismiss="modal" onclick="SetBudgetDetails('<%#Eval("BudgetNumber")%>','<%#Eval("tbl_BudgetId")%>');">

                                                        <asp:Literal runat="server" ID="ltrgvBudgetNumber" Text='<%# Bind("Description") %>'></asp:Literal>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,  BudgetDetails_htBudgetName%>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvBudgetName" runat="server" Text='<%# Bind("BudgetNumber") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, BudgetDetails_tmBudgetGuid%>" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvBudgetGuid" runat="server" Text='<%# Bind("tbl_BudgetId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnBudgetSearch" />
                                    <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearBudgetSearch" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="modal-footer row" runat="server" id="divFooter">
                        <div class="pull-left">
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                <asp:Literal runat="server" ID="ltrBudgetClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="basicModalFiscalPeriodSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header" style="text-align: left;">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title" id="hdrModalFiscalPeriodTitle"><span>
                            <asp:Literal runat="server" ID="ltrFiscalPeriodTitle" Text="<%$ Resources:GlobalResource, BudgetDetails_ltrFiscalPeriodTitle %>"></asp:Literal>
                        </span>
                        </h4>
                    </div>
                    <div class="modal-body">

                        <asp:UpdatePanel runat="server" ID="updpnlFiscalPeriodSearch">
                            <ContentTemplate>
                                <asp:Panel runat="server" ID="pnlFiscalPeriodSearch" DefaultButton="btnFiscalPeriodSearch">
                                    <div class="col-md-4 col-xs-5">
                                        <div class="icon-addon addon-md">
                                            <asp:TextBox runat="server" ID="txtFiscalPeriodSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                            <a runat="server" id="btnHtmlFiscalPeriodSearch" onclick="CallFiscalPeriodSearch();" class="fa fa-search"></a>
                                            <a runat="server" id="btnHtmlFiscalPeriodClose" visible="false" onclick="ClearFiscalPeriodSearch();" class="fa fa-close closex"></a>
                                        </div>
                                    </div>
                                    <asp:Button runat="server" ID="btnFiscalPeriodSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnFiscalPeriodSearch_Click" formnovalidate="formnovalidate" />
                                    <asp:Button runat="server" ID="btnClearFiscalPeriodSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearFiscalPeriodSearch_Click" formnovalidate="formnovalidate" />

                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div class="col-md-12 col-sm-12 colformstyle3">
                            <div runat="server" id="divFiscalPeriodSearchError" visible="false" class="alert alert-danger" role="alert">
                                <asp:Label runat="server" ID="lblFiscalPeriodSearchError"></asp:Label>
                            </div>
                            <div runat="server" id="divFiscalPeriodSearchSuccess" visible="false" class="alert alert-success" role="alert">
                                <asp:Label runat="server" ID="lblFiscalPeriodSearchSuccess"></asp:Label>
                            </div>
                        </div>
                        <div>
                            <asp:UpdateProgress runat="server" ID="updProgFiscalPeriodData" AssociatedUpdatePanelID="updpnlgvFiscalPeriodSearch">
                                <ProgressTemplate>
                                    Loading...
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:UpdatePanel runat="server" ID="updpnlgvFiscalPeriodSearch">
                                <ContentTemplate>
                                    <asp:Button runat="server" ID="btnFiscalPeriodRefresh" ClientIDMode="Static" OnClick="btnFiscalPeriodRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                    <asp:GridView ID="gvFiscalPeriodSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                        EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                        <Columns>
                                            <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, BudgetDetails_htFiscalPeriod%>">
                                                <ItemTemplate>
                                                     <a href="#" data-dismiss="modal" onclick="SetFiscalPeriodDetails('<%#Eval("NumberOfPeriod")%>','<%#Eval("tbl_FiscalPeriodId")%>');">

                                                        <asp:Literal runat="server" ID="ltrgvFiscalPeriod" Text='<%# Bind("NumberOfPeriod") %>'></asp:Literal>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
             
                                            <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, BudgetDetails_htFiscalPeriodGuid%>" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvFiscalPeriodGuid" runat="server" Text='<%# Bind("tbl_FiscalPeriodId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnFiscalPeriodSearch" />
                                    <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearFiscalPeriodSearch" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="modal-footer row" runat="server" id="div1">
                        <div class="pull-left">
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                <asp:Literal runat="server" ID="ltrFiscalPeriodClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GLAccountSummaryDetailsForm.aspx.cs" Inherits="Finance_General_Ledger_GL_Integration_GLAccountSummaryDetailsForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/General_Ledger_JS/GL_Integration_JS/GLAccountSummaryDetailsForm.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <!--page header start-->
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" OnClick="btnSave_Click" Text="<%$ Resources:GlobalResource, btnSave%>" />
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-success" OnClick="btnUpdate_Click" Text="<%$ Resources:GlobalResource, btnUpdate%>" />
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-success" OnClick="btnDelete_Click" Text="<%$ Resources:GlobalResource, btnDelete%>" formnovalidate="formnovalidate"/>
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
                                <asp:Literal runat="server" ID="ltrGLAccoutSummaryDetailsInformation" Text="<%$ Resources:GlobalResource, GLAccountSummaryDetails_ltrInformation%>"></asp:Literal></h5>
                        </div>
                     

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblGLAccountSummaryId" Text="<%$ Resources:GlobalResource, GLAccountSummaryDetails_lblGLAccountSummary%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtGLAccountSummary" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon1">
                                     <a href="#" data-toggle="modal" data-target="#basicModalGLAccountSummarySearch" data-keyboard="false" data-backdrop="static" onclick="CallGLAccountSummaryRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountSummaryGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblFiscalPeriodId" Text="<%$ Resources:GlobalResource, GLAccountSummaryDetails_lblFiscalPeriod%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtFiscalPeriod" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon2">
                                     <a href="#" data-toggle="modal" data-target="#basicModalFiscalPeriodSearch" data-keyboard="false" data-backdrop="static" onclick="CallFiscalPeriodRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtFiscalPeriodGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPeriod" Text="<%$ Resources:GlobalResource, GLAccountSummaryDetails_lblPeriod%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtPeriod" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPeriodName" Text="<%$ Resources:GlobalResource, GLAccountSummaryDetails_lblPeriodName%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtPeriodName" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPeriodDate" Text="<%$ Resources:GlobalResource, GLAccountSummaryDetails_lblPeriodDate%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtPeriodDate" TextMode="Date" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDebitAmount" Text="<%$ Resources:GlobalResource, GLAccountSummaryDetails_lblDebitAmount%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtDebitAmount" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblCreditAmount" Text="<%$ Resources:GlobalResource, GLAccountSummaryDetails_lblCreditAmount%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtCreditAmount" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblNetChargeAmount" Text="<%$ Resources:GlobalResource, GLAccountSummaryDetails_lblNetChargeAmount%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtNetChargeAmount" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPeriodBalanceAmount" Text="<%$ Resources:GlobalResource, GLAccountSummaryDetails_lblPeriodBalanceAmount%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtPeriodBalanceAmount" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


       <div class="modal fade" id="basicModalGLAccountSummarySearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGlAccountSummaryTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountSummaryTitle" Text="<%$ Resources:GlobalResource, GLAccountSummaryDetails_lblGLAccountSummary%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlGLAccountSummary">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlGLAccountSummary" DefaultButton="btnGLAccountSummarySearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtGLAccountSummarySearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlGLAccountSummarySearch" onclick="CallGLAccountSummarySearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlGLAccountSummaryClose" visible="false" onclick="ClearGLAccountSummarySearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnGLAccountSummarySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnGLAccountSummarySearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearGLAccountSummarySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearGLAccountSummarySearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountSummarySearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountSummarySearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountSummarySearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountSummarySearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgGLAccountSummaryData" AssociatedUpdatePanelID="updpnlgvGLAccountSummarySearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountSummarySearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnGLAccountSummaryRefresh" ClientIDMode="Static" OnClick="btnGLAccountSummaryRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvGLAccountSummarySearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountSummaryDetails_htAccountNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetGLAccountSummaryDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountSummaryId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvGLAccountSummaryCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountSummaryDetails_htGLAccountSummaryGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvGLAccountSummaryGuid" runat="server" Text='<%# Bind("tbl_GLAccountSummaryId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnGLAccountSummarySearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearGLAccountSummarySearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divGLAccountSummaryFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblGLAccountSummaryClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
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
                        <asp:Literal runat="server" ID="ltrFiscalPeriod" Text="<%$ Resources:GlobalResource, GLAccountSummaryDetails_lblFiscalPeriod%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlFiscalPeriod">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlFiscalPeriod" DefaultButton="btnFiscalPeriodSearch">
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
                        <div runat="server" id="divFiscalPeriodSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblFiscalPeriodSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateProgFiscalPeriod" AssociatedUpdatePanelID="updpnlgvFiscalPeriodSearch">
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountSummaryDetails_htNumberOfPeriod%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetFiscalPeriodDetails('<%#Eval("tbl_FiscalPeriodSetup")%>','<%#Eval("tbl_FiscalPeriodId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvFiscalPeriodCode" Text='<%# Bind("tbl_FiscalPeriodSetup") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountSummaryDetails_htFiscalPeriodGuid%>"  Visible="false">
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
                <div class="modal-footer row" runat="server" id="divFiscalPeriodFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblFiscalPeriodClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


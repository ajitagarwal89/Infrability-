<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GLAccountBudgetDetailsForm.aspx.cs" Inherits="Finance_General_Ledger_GL_Integration_GLAccountBudgetDetailsForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/General_Ledger_JS/GL_Integration_JS/GLAccountBudgetDetailsForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, GLAccountBudgetDetails_ltrInformation%>"></asp:Literal></h5>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblGLAccountBudgetId" Text="<%$ Resources:GlobalResource, GLAccountBudgetDetails_lblGLAccountBudget %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtGLAccountBudget" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon">
                                    <a href="#" data-toggle="modal" data-target="#basicModalGLAccountBudgetSearch" data-keyboard="false" data-backdrop="static" onclick="CallGLAccountBudgetRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountBudgetGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>


                          <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblFiscalPeriod" Text="<%$ Resources:GlobalResource, GLAccountBudgetDetails_lblFiscalPeriod %>"></asp:Label>
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
                           <asp:Label runat="server" ID="lblPeriod" Text="<%$ Resources:GlobalResource,GLAccountBudgetDetails_lblPeriod%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtPeriod" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                         <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblPeriodName" Text="<%$ Resources:GlobalResource, GLAccountBudgetDetails_lblPeriodName%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtPeriodName" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblPeriodDate" Text="<%$ Resources:GlobalResource, GLAccountBudgetDetails_lblPeriodDate%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtPeriodDate" TextMode="Date" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        
                         <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblAmount" Text="<%$ Resources:GlobalResource, GLAccountBudgetDetails_lblAmount%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtAmount" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                </div>
                </div>
            </div>

      <div class="modal fade" id="basicModalGLAccountBudgetSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGLAccountBudgetTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountBudgetTitle" Text="<%$ Resources:GlobalResource, GLAccountBudgetDetails_ltrGLAccountBudgetTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlGLAccountBudgetSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlGLAccountBudgetSearch" DefaultButton="btnGLAccountBudgetSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtGLAccountBudgetSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlGLAccountBudgetSearch" onclick="CallGLAccountBudgetSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlGLAccountBudgetClose" visible="false" onclick="ClearGLAccountBudgetSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnGLAccountBudgetSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnGLAccountBudgetSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearGLAccountBudgetSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearGLAccountBudgetSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountBudgetSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountBudgetSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountBudgetSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountBudgetSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgGLAccountBudgetData" AssociatedUpdatePanelID="updpnlgvGLAccountBudgetSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountBudgetSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnGLAccountBudgetRefresh" ClientIDMode="Static" OnClick="btnGLAccountBudgetRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvGLAccountBudgetSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountBudgetDetails_htAccountNumber%>">
                                            <ItemTemplate>
                                                 <a href="#" data-dismiss="modal" onclick="SetGLAccountBudgetDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountBudgetId")%>');">
                                                   
                                               <asp:Literal runat="server" ID="ltrgvAccountNumber" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,  GLAccountBudgetDetails_htBudgetName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvBudgetName" runat="server" Text='<%# Bind("BudgetName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountBudgetDetails_htBudgetNumber%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvBudgetNumber" runat="server" Text='<%# Bind("BudgetNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,  GLAccountBudgetDetails_htCalculationMethod%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCalculationMethod" runat="server" Text='<%# Bind("CalculationMethod") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,  GLAccountBudgetDetails_htGLAccountBudgetGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvGLAccountBudgetGuid" runat="server" Text='<%# Bind("tbl_GLAccountBudgetId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnGLAccountBudgetSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearGLAccountBudgetSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrGLAccountBudgetClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
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
                        <asp:Literal runat="server" ID="ltrFiscalPeriodTitle" Text="<%$ Resources:GlobalResource, GLAccountBudgetDetails_ltrFiscalPeriodTitle %>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountBudgetDetails_htPeriodName%>">
                                            <ItemTemplate>
                                                 <a href="#" data-dismiss="modal" onclick="SetFiscalPeriodDetails('<%#Eval("PeriodName")%>','<%#Eval("tbl_FiscalPeriodId")%>');">
                                                   
                                               <asp:Literal runat="server" ID="ltrgvFiscalPeriod" Text='<%# Bind("PeriodName") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                         <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,GLAccountBudgetDetails_htFiscalPeriod  %>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPeriodName" runat="server" Text='<%# Bind("Period") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,  GLAccountBudgetDetails_htPeriodDate%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPeriodDate" runat="server" Text='<%# Bind("PeriodDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,  GLAccountBudgetDetails_htFiscalPeriodGuid%>" Visible="false">
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
    

   </asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GLAccountConfigurationSettingsForm.aspx.cs" Inherits="Finance_General_Ledger_GLAccountConfigurationSettings_GLAccountConfigurationSettingsForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/General_Ledger_JS/GLAccountConfigurationSettings_JS/GLAccountConfigurationSettingsForm.js"></script>
	<script src="../../../infra_ui/js/CommonJS/CommonValidations.js"></script>
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
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-success" OnClick="btnBack_Click" Text="<%$ Resources:GlobalResource, btnBack%>" formnovalidate="formnovalidate"/>
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
                                <asp:Literal runat="server" ID="ltrGLAccoountCurrencyInformation" Text="<%$ Resources:GlobalResource, GLAccountConfigurationSettings_ltrInformation%>"></asp:Literal></h5>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblGLAccountRetainedEarning" Text="<%$ Resources:GlobalResource, GLAccountConfigurationSettings_lblGLAccountId_RetainedEarning%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtGLAccountRetainedEarning" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon4">
                                     <a href="#" data-toggle="modal" data-target="#basicModalGLAccountRetainedEarningSearch" data-keyboard="false" data-backdrop="static" onclick="CallGLAccountIdRetainedEarningRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountRetainedEarningGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPostingToHistory" Text="<%$ Resources:GlobalResource, GLAccountConfigurationSettings_lblPostingToHistory%>"></asp:Label>

                            <asp:CheckBox ID="chkPostingToHistory" runat="server"  ClientIDMode="Static" class="form-control" placeholder="" required="required"/>
                        </div>
                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDeletionOfSavedTransaction" Text="<%$ Resources:GlobalResource, GLAccountConfigurationSettings_lblDeletionOfSavedTransaction%>"></asp:Label>

                            <asp:CheckBox ID="chkDeletionOfSavedTransaction" runat="server"  ClientIDMode="Static" class="form-control" placeholder="" required="required"/>
                        </div>
                        
                        
                    </div>
                </div>
            </div>
        </div>
    </div>

     <div class="modal fade" id="basicModalGLAccountRetainedEarningSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGLAccountRetainedEarningTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountRetainedEarningTitle" Text="<%$ Resources:GlobalResource, GLAccountConfigurationSettings_lblGLAccountRetainedEarning%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlGLAccountRetainedEarning">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlGLAccountRetainedEarning" DefaultButton="btnGLAccountRetainedEarningSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtGLAccountRetainedEarningSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlGLAccountRetainedEarningSearch" onclick="CallGLAccountRetainedEarningSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlGLAccountRetainedEarningClose" visible="false" onclick="ClearGLAccountRetainedEarningSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnGLAccountRetainedEarningSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnGLAccountRetainedEarningSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearGLAccountRetainedEarningSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearGLAccountRetainedEarningSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountRetainedEarningSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountRetainedEarningSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountRetainedEarningSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountRetainedEarningSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgGLAccountRetainedEarningData" AssociatedUpdatePanelID="updpnlgvGLAccountRetainedEarningSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountRetainedEarningSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnGLAccountRetainedEarningRefresh" ClientIDMode="Static" OnClick="btnGLAccountRetainedEarningRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvGLAccountRetainedEarningSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountConfigurationSettings_htAccountNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetGLAccountRetainedEarningDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvGLAccountRetainedEarningCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountConfigurationSettings_htGLAccountGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvGLAccountRetainedEarningGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnGLAccountRetainedEarningSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearGLAccountRetainedEarningSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divGLAccountRetainedEarningFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblGLAccountRetainedEarningClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

   
  
</asp:Content>


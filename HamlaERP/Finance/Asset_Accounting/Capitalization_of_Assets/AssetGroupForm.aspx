<%@ Page Title=""  Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AssetGroupForm.aspx.cs" Inherits="System_Settings_AssetGroupForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Asset%20_Accounting_JS/Capitalization_of_Assets_JS/AssetGroupForm.js"></script>
    <script src="../../../infra_ui/js/CommonJS/CommonValidations.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <!--page header start-->
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" OnClick="btnSave_Click" Text="<%$ Resources:GlobalResource, btnSave%>" />
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-success" OnClick="btnUpdate_Click" Text="<%$ Resources:GlobalResource, btnUpdate%>" />
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-success" OnClick="btnDelete_Click" Text="<%$ Resources:GlobalResource, btnDelete%>" formnovalidate="formnovalidate" />
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
                                <asp:Literal runat="server" ID="ltrAssetGroup" Text="<%$ Resources:GlobalResource, AssetGroup_ltrInformation%>"></asp:Literal></h5>
                        </div>

                     

                         <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblAssetAndGroupAccountId" Text="<%$ Resources:GlobalResource, AssetGroup_lblAssetAndGroupAccountId%>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtAssetAndGroupAccountId" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon">
                                    <a href="#" data-toggle="modal" data-target="#basicModalAssetAndGroupAccountSearch" data-keyboard="false" data-backdrop="static" onclick="CallAssetAndGroupAccountRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtAssetAndGroupAccountIdGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                         <%--<div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblInsurance" Text="<%$ Resources:GlobalResource, AssetGroup_lblInsuranceId%>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtInsuranceId" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon1">
                                    <a href="#" data-toggle="modal" data-target="#basicModalInsuranceSearch" data-keyboard="false" data-backdrop="static" onclick="CallInsuranceRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtInsuranceIdGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>--%>
                          <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAssetGroupCode" Text="<%$ Resources:GlobalResource, AssetGroup_lblAssetGroupCode%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtAssetGroupCode"  ClientIDMode="Static" onkeypress="return isAlphaNumberKey(this);" MaxLength="20" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                           <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource, AssetGroup_lblDescription%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDescription"  ClientIDMode="Static" onkeypress="return isAddress(this);" MaxLength="50" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                      </div>
                    </div>
                </div>
            </div>
        </div>

      <div class="modal fade" id="basicModalAssetAndGroupAccountSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalAssetAndGroupAccountTitle"><span>
                        <asp:Literal runat="server" ID="ltrAssetAndGroupAccountinformation1" Text="<%$ Resources:GlobalResource, AssetGroup_ltrinformation %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlAssetAndGroupAccountSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlAssetAndGroupAccountSearch" DefaultButton="btnAssetAndGroupAccountSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtAssetAndGroupAccountSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlAssetAndGroupAccountSearch" onclick="CallAssetAndGroupAccountSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlAssetAndGroupAccountClose" visible="false" onclick="ClearAssetAndGroupAccountSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnAssetAndGroupAccountSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAssetAndGroupAccountSearch_Click" formnovalidate="formnovalidate"/>
                                <asp:Button runat="server" ID="btnClearAssetAndGroupAccountSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearAssetAndGroupAccountSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divAssetAndGroupAccountSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblAssetAndGroupAccountSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divAssetAndGroupAccountSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="AssetAndGroupAccountSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgAssetAndGroupAccountData" AssociatedUpdatePanelID="updpnlgvAssetAndGroupAccountSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvAssetAndGroupAccountSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnAssetAndGroupAccountRefresh" ClientIDMode="Static" OnClick="btnAssetAndGroupAccountRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvAssetAndGroupAccountSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,AssetGroup_htAccountType%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetAssetAndGroupAccountDetails('<%#Eval("AccountType")%>','<%#Eval("tbl_AssetAndGroupAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvAssetAndGroupAccountType" Text='<%# Bind("AccountType") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     


                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetGroup_htAssetAndGroupAccountGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvAssetAndGroupAccountGuid" runat="server" Text='<%# Bind("tbl_AssetAndGroupAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnAssetAndGroupAccountSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearAssetAndGroupAccountSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter1">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrAssetAndGroupAccountClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>     

</asp:Content>

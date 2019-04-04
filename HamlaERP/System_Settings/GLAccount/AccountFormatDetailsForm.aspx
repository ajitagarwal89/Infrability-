<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AccountFormatDetailsForm.aspx.cs" Inherits="System_Settings_AccountFormatDetialsForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../infra_ui/js/System_Settings_JS/GLAccount_JS/AccountFormatDetialsForm.js"></script>
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
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-success" OnClick="btnDelete_Click" Text="<%$ Resources:GlobalResource, btnDelete%>" formnovalidate="formnovalidate"></asp:Button>
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
                                <asp:Literal runat="server" ID="ltr_AccountFormatDetails_information" Text="<%$ Resources:GlobalResource, AccountFormatDetails_ltrInformation%>"></asp:Literal></h5>
                        </div>
                         <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblGLAccountFormatId" Text="<%$ Resources:GlobalResource, AccountFormatDetails_lblGLAccountFormatId %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtGLAccountFormat" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon">
                                    <a href="#" data-toggle="modal" data-target="#basicModalGLAccountFormatSearch" data-keyboard="false" data-backdrop="static" onclick="CallGLAccountFormatRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountFormatGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblSequenceNumber" Text="<%$ Resources:GlobalResource, AccountFormatDetails_lblSequenceNumber %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtSequenceNumber" ClientIDMode="Static" onkeypress="return isNumberKey(this);" MaxLength="3"  class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                        
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblSegmentNumber" Text="<%$ Resources:GlobalResource, AccountFormatDetails_lblSegmentNumber %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtSegmentNumber" ClientIDMode="Static" onkeypress="return isNumberKey(this);" MaxLength="2" class="form-control" placeholder="" required="required" ></asp:TextBox>
                        </div>
                           <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblSegmentName" Text="<%$ Resources:GlobalResource, AccountFormatDetails_lblSegmentName %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtSegmentName" ClientIDMode="Static" onkeypress="return isAlphaNumberKey(this);" MaxLength="30" class="form-control"  Placeholder="" required="required"></asp:TextBox>
                        </div>
                               <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblMaxLength" Text="<%$ Resources:GlobalResource, AccountFormatDetails_lblMaxLength %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtMaxLength" ClientIDMode="Static" onkeypress="return isNumberKey(this);" MaxLength="2" class="form-control" Placeholder="" required="required"></asp:TextBox>
                        </div>
                               <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblLength" Text="<%$ Resources:GlobalResource, AccountFormatDetails_lblLength %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtLength" ClientIDMode="Static" onkeypress="return isNumberKey(this);" MaxLength="2" class="form-control" Placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblIsActive" Text="<%$ Resources:GlobalResource, AccountFormatDetails_lblIsActive %>"></asp:Label>
                            <asp:CheckBox ID="chkIsActive" runat="server" ClientIDMode="Static" /> 
                        
                        </div>
                     
                    </div>
                </div>
            </div>
        </div>
    </div>
   <div class="modal fade" id="basicModalGLAccountFormatSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGLAccountFormatTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountFormatTitle" Text="<%$ Resources:GlobalResource, AccountFormatDetails_ltrAccountFormatTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlGLAccountFormatSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlGLAccountFormatSearch" DefaultButton="btnGLAccountFormatSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtGLAccountFormatSearch" CssClass="form-control" placeholder="Search..." autofocus=""></asp:TextBox>
                                        <a runat="server" id="btnHtmlGLAccountFormatSearch" onclick="CallGLAccountFormatSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlGLAccountFormatClose" visible="false" onclick="ClearGLAccountFormatSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnGLAccountFormatSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAccountFormatSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearGLAccountFormatSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearAccountFormatSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountFormatSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountFormatSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountFormatSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountFormatSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgData" AssociatedUpdatePanelID="updpnlgvGLAccountFormatSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountFormatSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnAccountFormatRefresh" ClientIDMode="Static" OnClick="btnAccountFormatRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvGLAccountFormatSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AccountFormatDetails_htAccountLength%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetGLAccountFormatDetails('<%#Eval("AccountLength")%>','<%#Eval("tbl_AccountFormatId")%>');">

                                                    <asp:Literal runat="server" ID="ltrgvGLAccountFormatType" Text='<%# Bind("AccountLength") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                <%--        <asp:TemplateField HeaderText="GLAccountFormat Guid" Visible="false">--%>
                                         <asp:TemplateField  HeaderText="<%$ Resources:GlobalResource, AccountFormatDetails_GLAccountFormatGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvGLAccountFormatGuid" runat="server" Text='<%# Bind("tbl_AccountFormatId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnGLAccountFormatSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearGLAccountFormatSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrGLAccountFormatClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


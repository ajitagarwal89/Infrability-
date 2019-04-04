<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GoodsReceivedNoteDistributionForm.aspx.cs" Inherits="Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteDistributionForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
	<script src="../../../infra_ui/js/Procurement_JS/Receive%20Goods%20or%20Services_JS/Receive_Goods_or_Services_JS/GoodsReceivedNoteDistributionForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, GoodsReceivedNoteDistribution_ltrInformation%>"></asp:Literal></h5>
                        </div>
                           
                          <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblopt_GLAccountType" Text="<%$ Resources:GlobalResource, GoodsReceivedNoteDistribution_lblopt_GLAccountType %>"></asp:Label>
                           
							  <asp:DropDownList ID="ddlopt_GLAccountType" runat="server" ClientIDMode="Static" class="form-control" required="required" OnSelectedIndexChanged="ddlopt_GLAccountType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                      
									  </div>
                         <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblGoodsReceivedNoteId" Text="<%$ Resources:GlobalResource, GoodsReceivedNoteDistribution_lblGoodsReceivedNoteId %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtGoodsReceivedNote" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon3">
                                    <a href="#" data-toggle="modal" data-target="#basicModalGoodsReceivedNoteSearch" data-keyboard="false" data-backdrop="static" onclick="CallGoodsReceivedNoteRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGoodsReceivedNoteGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                          <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblGLAccountId" Text="<%$ Resources:GlobalResource, GoodsReceivedNoteDistribution_lblGLAccountId%>"></asp:Label>
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

                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource, GoodsReceivedNoteDistribution_lblDescription%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDescription"  ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isAddress(this);" MaxLength="100"  required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblDistributionReference" Text="<%$ Resources:GlobalResource, GoodsReceivedNoteDistribution_lblDistributionReference%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDistributionReference"   ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isAddress(this);" MaxLength="100" required="required"></asp:TextBox>
                        </div>
 
                    <div class="form-group col-md-4 col-sm-4" id="divDedit" runat="server" >

                        <asp:Label runat="server" ID="lblDebit" Text="<%$ Resources:GlobalResource, GoodsReceivedNoteDistribution_lblDebit%>"></asp:Label>
                        <asp:TextBox runat="server" ID="txtDebit" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" required="required"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4 col-sm-4" id="divCredit" runat="server">

                        <asp:Label runat="server" ID="lblCredit" Text="<%$ Resources:GlobalResource, GoodsReceivedNoteDistribution_lblCredit%>"></asp:Label>
                        <asp:TextBox runat="server" ID="txtCredit" ClientIDMode="Static" class="form-control" placeholder=""  onkeypress="return isNumberKeyPoint(this);" MaxLength="9" required="required"></asp:TextBox>
                    </div>
       
                   
                </div>
            </div>
        </div>
    </div>
        </div>
    
    <div class="modal fade" id="basicModalGoodsReceivedNoteSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGoodsReceivedNoteTitle"><span>
                        <asp:Literal runat="server" ID="Literal2" Text="<%$ Resources:GlobalResource, GoodsReceivedNoteDistribution_ltrGoodsReceivedNoteTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlGoodsReceivedNoteSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlGoodsReceivedNoteSearch" DefaultButton="btnGoodsReceivedNoteSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtGoodsReceivedNoteSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlGoodsReceivedNoteSearch" onclick="CallGoodsReceivedNoteSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlGoodsReceivedNoteClose" visible="false" onclick="ClearGoodsReceivedNoteSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnGoodsReceivedNoteSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnGoodsReceivedNoteSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearGoodsReceivedNoteSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearGoodsReceivedNoteSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGoodsReceivedNoteSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblGoodsReceivedNoteSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGoodsReceivedNoteSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGoodsReceivedNoteSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateProgress1" AssociatedUpdatePanelID="updpnlgvGoodsReceivedNoteSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGoodsReceivedNoteSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnGoodsReceivedNoteRefresh" ClientIDMode="Static" OnClick="btnGoodsReceivedNoteRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvGoodsReceivedNoteSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,GoodsReceivedNoteDistribution_htGoodsReceivedNoteNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetGoodsReceivedNoteDetails('<%#Eval("GoodsReceivedNoteNumber")%>','<%#Eval("tbl_GoodsReceivedNoteId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvGoodsReceivedNoteCode" Text='<%# Bind("GoodsReceivedNoteNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,GoodsReceivedNoteDistribution_htReceivedType%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGoodsReceivedNoteName" runat="server" Text='<%# Bind("ReceivedType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:GlobalResource, GoodsReceivedNoteDistribution_htGoodsReceivedNoteGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGoodsReceivedNoteId" runat="server" Text='<%# Bind("tbl_GoodsReceivedNoteId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnGoodsReceivedNoteSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearGoodsReceivedNoteSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div1">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrGoodsReceivedNoteClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
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
                        <asp:Literal runat="server" ID="ltrGLAccountTitle" Text="<%$ Resources:GlobalResource, GLAccountSummary_lblGLAccountTitle%>"></asp:Literal>
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
                                <asp:Button runat="server" ID="btnClearGLAccountSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearGLAccountSearch_Click" formnovalidate="formnovalidate" />

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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNoteDistribution_htAccountNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetGLAccountDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvGLAccountCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNoteDistribution_htGLAccountGuid %>" Visible="false">
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


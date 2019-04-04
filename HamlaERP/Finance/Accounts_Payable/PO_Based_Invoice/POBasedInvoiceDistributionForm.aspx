<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="POBasedInvoiceDistributionForm.aspx.cs" Inherits="Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDistributionForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Accounts_Payable_JS/PO_Based_Invoice_JS/POBasedInvoiceDistributionForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, POBasedInvoiceDistribution_ltrInformation%>"></asp:Literal></h5>
                        </div>
                        
                         <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblPOBasedInvoiceId" Text="<%$ Resources:GlobalResource, POBasedInvoiceDistribution_lblPOBasedInvoiceId %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtPOBasedInvoice" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon3">
                                    <a href="#" data-toggle="modal" data-target="#basicModalPOBasedInvoiceSearch" data-keyboard="false" data-backdrop="static" onclick="CallPOBasedInvoiceRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPOBasedInvoiceGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                          <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblGLAccountId" Text="<%$ Resources:GlobalResource, POBasedInvoiceDistribution_lblGLAccountId%>"></asp:Label>
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
                            <asp:Label runat="server" ID="lblopt_GLAccountType" Text="<%$ Resources:GlobalResource, POBasedInvoiceDistribution_lblopt_GLAccountType %>"></asp:Label>
                             <asp:DropDownList ID="ddlopt_GLAccountType" runat="server" ClientIDMode="Static" class="form-control" required="required"></asp:DropDownList>
                        </div>
                  
                       <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource, POBasedInvoiceDistribution_lblDescription%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDescription"  ClientIDMode="Static" class="form-control" onkeypress="return isAddress(this);" MaxLength="50" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblDistributionReference" Text="<%$ Resources:GlobalResource, POBasedInvoiceDistribution_lblDistributionReference%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDistributionReference"    ClientIDMode="Static" onkeypress="return isAddress(this);" MaxLength="50" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
 
                    <div class="form-group col-md-4 col-sm-4">

                        <asp:Label runat="server" ID="lblDebit" Text="<%$ Resources:GlobalResource, POBasedInvoiceDistribution_lblDebit%>"></asp:Label>
                        <asp:TextBox runat="server" ID="txtDebit" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control"  placeholder="" required="required"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4 col-sm-4">

                        <asp:Label runat="server" ID="lblCredit" Text="<%$ Resources:GlobalResource, POBasedInvoiceDistribution_lblCredit%>"></asp:Label>
                        <asp:TextBox runat="server" ID="txtCredit" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control" placeholder="" required="required"></asp:TextBox>
                    </div>
       
                      <div class="form-group col-md-4 col-sm-4">

                        <asp:Label runat="server" ID="lblOriginatingDebit" Text="<%$ Resources:GlobalResource, POBasedInvoiceDistribution_lblOriginatingDebit%>"></asp:Label>
                        <asp:TextBox runat="server" ID="txtOriginatingDebit" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control" placeholder="" required="required"></asp:TextBox>
                    </div>
                           <div class="form-group col-md-4 col-sm-4">

                        <asp:Label runat="server" ID="lblOriginatingCredit" Text="<%$ Resources:GlobalResource, POBasedInvoiceDistribution_lblOriginatingCredit%>"></asp:Label>
                        <asp:TextBox runat="server" ID="txtOriginatingCredit" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control" placeholder="" required="required"></asp:TextBox>
                    </div>
                           <div class="form-group col-md-4 col-sm-4">

                        <asp:Label runat="server" ID="lblExchangeRate" Text="<%$ Resources:GlobalResource, POBasedInvoiceDistribution_lblExchangeRate%>"></asp:Label>
                        <asp:TextBox runat="server" ID="txtExchangeRate" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control" placeholder="" required="required"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>
        </div>
    
    <div class="modal fade" id="basicModalPOBasedInvoiceSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalPOBasedInvoiceTitle"><span>
                        <asp:Literal runat="server" ID="Literal2" Text="<%$ Resources:GlobalResource, POBasedInvoiceDistribution_ltrPOBasedInvoiceTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlPOBasedInvoiceSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlPOBasedInvoiceSearch" DefaultButton="btnPOBasedInvoiceSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtPOBasedInvoiceSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlPOBasedInvoiceSearch" onclick="CallPOBasedInvoiceSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlPOBasedInvoiceClose" visible="false" onclick="ClearPOBasedInvoiceSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnPOBasedInvoiceSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnPOBasedInvoiceSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearPOBasedInvoiceSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearPOBasedInvoiceSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divPOBasedInvoiceSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblPOBasedInvoiceSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divPOBasedInvoiceSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblPOBasedInvoiceSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateProgress1" AssociatedUpdatePanelID="updpnlgvPOBasedInvoiceSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvPOBasedInvoiceSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnPOBasedInvoiceRefresh" ClientIDMode="Static" OnClick="btnPOBasedInvoiceRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvPOBasedInvoiceSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,POBasedInvoiceDistribution_htReceiptNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetPOBasedInvoiceDetails('<%#Eval("ReceiptNumber")%>','<%#Eval("tbl_POBasedInvoiceId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvReceiptNumber" Text='<%# Bind("ReceiptNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    
                                        <asp:TemplateField HeaderText="<%$Resources:GlobalResource, POBasedInvoiceDistribution_htPOBasedInvoiceGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPOBasedInvoiceGuid" runat="server" Text='<%# Bind("tbl_POBasedInvoiceId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPOBasedInvoiceSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearPOBasedInvoiceSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div1">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrPOBasedInvoiceClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
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
                        <asp:Literal runat="server" ID="ltrGLAccountTitle" Text="<%$ Resources:GlobalResource, POBasedInvoiceDistribution_lblGLAccountTitle%>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, POBasedInvoiceDistribution_htAccountNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetGLAccountDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvAccountNumber" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, POBasedInvoiceDistribution_htGLAccountGuid %>" Visible="false">
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


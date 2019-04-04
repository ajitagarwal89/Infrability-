<%@ Page  Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="NonPOBasedInvoiceDistributionForm.aspx.cs" Inherits="Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceDistributionForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Accounts_Payable_JS/Non_PO_Based_Invoice_JS/NonPOBasedInvoiceDistributionForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrNonPOBasedInvoiceDistribution" Text="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_ltrInformation%>"></asp:Literal></h5>
                        </div>


                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblNonPOBasedInvoiceId" Text="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_lblNonPOBasedInvoiceId%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtNonPOBasedInvoiceId" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control" OnTextChanged="txtNonPOBasedInvoiceId_TextChanged"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon">
                                    <a href="#" data-toggle="modal" data-target="#basicModalNonPOBasedInvoiceIdSearch" data-keyboard="false" data-backdrop="static" onclick="CallNonPOBasedInvoiceIdRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>
                                <asp:TextBox ID="txtNonPOBasedInvoiceIdGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblGLAccountId" Text="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_lblGLAccountId%>"></asp:Label>
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
                            <asp:Label runat="server" ID="lblGLAccountType" Text="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_lblGLAccountType%>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_GLAccountType" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required" OnTextChanged="ddlOpt_GLAccountType_TextChanged">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_lblDescription%>"></asp:Label>
                            <asp:TextBox  runat="server" ID="txtDescription" ClientIDMode="Static" onkeypress="return isAddress(this);" MaxLength="50" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDistributionReference" Text="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_lblDistributionReference%>"></asp:Label>
                            <asp:TextBox  runat="server" ID="txtDistributionReference"  ClientIDMode="Static" onkeypress="return isAddress(this);" MaxLength="50" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4" id="divDebit" runat="server" >
                            <asp:Label runat="server" ID="lblDebit" Text="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_lblDebit%>"></asp:Label>
                            <asp:TextBox  runat="server" ID="txtDebit" ClientIDMode="Static" class="form-control" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4"  id="divCredit" runat="server" >
                            <asp:Label runat="server" ID="lblCredit" Text="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_lblCredit%>"></asp:Label>
                            <asp:TextBox  runat="server" ID="txtCredit" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4" id="divOriginatingDebit" runat="server" >
                            <asp:Label runat="server" ID="lblOriginatingDebit" Text="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_lblOriginatingDebit%>"></asp:Label>
                            <asp:TextBox  runat="server" ID="txtOriginatingDebit" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4" id="divOriginatingCredit" runat="server" >
                            <asp:Label runat="server" ID="lblOriginatingCredit" Text="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_lblOriginatingCredit%>"></asp:Label>
                            <asp:TextBox  runat="server" ID="txtOriginatingCredit" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblExchangeRate" Text="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_lblExchangeRate%>"></asp:Label>
                            <asp:TextBox  runat="server" ID="txtExchangeRate" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>


               <div id="divDownNonPOBasedInvoiceDistribution" runat="server" >

                 <div class="form-group col-md-12" style="background-color: #f6f6f6">
                            <h5>
                                <asp:Literal runat="server" ID="ltrNonPOBasedInvoiceDistribution2" Text="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_ltrNonPOBasedInvoiceDetails%>"></asp:Literal></h5>
                        </div>
                <div class="form-group col-md-4 col-sm-4" id="divSupplierCode" runat="server" >
                            <asp:Label runat="server" ID="lblSupplier" Text="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_lblSupplierCode%>"></asp:Label>
                           <asp:TextBox ID="txtSupplierCode"  runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                        </div>                   
                <div class="form-group col-md-4 col-sm-4" id="divSupplierName" runat="server" >
                            <asp:Label runat="server" ID="lblSupplierName" Text="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_lblSupplierName %>"></asp:Label>
                           <asp:TextBox ID="txtSupplierName"  runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                        </div>
                <div class="form-group col-md-4 col-sm-4" id="divReceiptnumber" runat="server" >
                            <asp:Label runat="server" ID="lblReceiptnumber" Text="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_lblReceiptNumber %>"></asp:Label>
                           <asp:TextBox ID="txtReceiptnumber"  runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                        </div>
                <div class="form-group col-md-4 col-sm-4" id="divDocumentNumber" runat="server" >
                    <asp:Label runat="server" ID="lblDocumentNumber" Text="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_lblDocumentNumber %>"></asp:Label>
                     <asp:TextBox ID="txtDocumentNumber"  runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                   </div>            
                <div class="form-group col-md-4 col-sm-4" id="divCurrency" runat="server" >
                    <asp:Label runat="server" ID="lblCurrencyName" Text="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_lblCurrencyName %>"></asp:Label>
                     <asp:TextBox ID="txtCurrencyName"  runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                 </div>
                <div class="form-group col-md-4 col-sm-4" id="divfunctionalAmount" runat="server" >
                    <asp:Label runat="server" ID="lblFunctionalAmount" Text="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_lblFunctionalAmount %>"></asp:Label>
                     <asp:TextBox ID="txtFunctionalAmount"  runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                 </div>
                <div class="form-group col-md-4 col-sm-4" id="divOrginatingAmount" runat="server" >
                    <asp:Label runat="server" ID="lblOrginatingAmount" Text="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_lblOrginationAmount %>"></asp:Label>
                     <asp:TextBox ID="txtOrginatingAmount"  runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                 </div>
               
             <asp:DataGrid runat="server" ClientIDMode="Static" Font-Size="10pt" ID="gvData" AutoGenerateColumns="False" Width="100%" GridLines="None" CssClass="table table-hover" CellPadding="4" ForeColor="#333333">
                            <AlternatingItemStyle BackColor="White" />
                            <Columns>                                
                                        <asp:BoundColumn DataField="tbl_NonPOBasedInvoiceDistributionId" Visible="false"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_ltrVoucherNumber%>" DataField="tbl_POBasedInvoice"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_ltrGLAccountId%>" DataField="tbl_GLAccount"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_ltrDescription%>" DataField="Description"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_ltrDistributionReference%>" DataField="DistributionReference"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_ltrExchangeRate%>" DataField="ExchangeRate"></asp:BoundColumn>                             
                            </Columns>

                            <EditItemStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <ItemStyle BackColor="#EFF3FB" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:DataGrid>
                    </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

     <div class="modal fade" id="basicModalNonPOBasedInvoiceIdSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalNonPOBasedInvoiceIdTitle"><span>
                        <asp:Literal runat="server" ID="ltr_NonPOBasedInvoiceId_information" Text="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_ltrInformation %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlNonPOBasedInvoiceIdSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlNonPOBasedInvoiceIdSearch" DefaultButton="btnNonPOBasedInvoiceIdSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtNonPOBasedInvoiceIdSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlNonPOBasedInvoiceIdSearch" onclick="CallNonPOBasedInvoiceIdSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlNonPOBasedInvoiceIdClose" visible="false" onclick="ClearNonPOBasedInvoiceIdSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnNonPOBasedInvoiceIdSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnNonPOBasedInvoiceIdSearch_Click" formnovalidate="formnovalidate"/>
                                <asp:Button runat="server" ID="btnClearNonPOBasedInvoiceIdSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearNonPOBasedInvoiceIdSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divNonPOBasedInvoiceIdSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblNonPOBasedInvoiceIdSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divNonPOBasedInvoiceIdSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="NonPOBasedInvoiceIdSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgNonPOBasedInvoiceIdData" AssociatedUpdatePanelID="updpnlgvNonPOBasedInvoiceIdSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvNonPOBasedInvoiceIdSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnNonPOBasedInvoiceIdRefresh" ClientIDMode="Static" OnClick="btnNonPOBasedInvoiceIdRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvNonPOBasedInvoiceIdSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_ltrVoucherNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetNonPOBasedInvoiceIdDetails('<%#Eval("PONumber")%>','<%#Eval("tbl_NonPOBasedInvoiceId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvNonPOBasedInvoiceIdType" Text='<%# Bind("VoucherNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_htPOONumber%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvNonPOBasedInvoiceIdName" runat="server" Text='<%# Bind("PONumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_htNonPOBasedInvoiceIdGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvNonPOBasedInvoiceIdGuid" runat="server" Text='<%# Bind("tbl_NonPOBasedInvoiceId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnNonPOBasedInvoiceIdSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearNonPOBasedInvoiceIdSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrNonPOBasedInvoiceIdClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
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
                        <asp:Literal runat="server" ID="ltrGLAccountTitle" Text="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_ltrGLAccount%>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_htAccountNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetGLAccountDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvGLAccountCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoiceDistribution_htGLAccountGuid%>" Visible="false">
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
   


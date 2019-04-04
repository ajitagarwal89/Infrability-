<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DownPaymentToSupplierApplyForm.aspx.cs" Inherits="Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierApplyForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Bank_Accounting_JS/Down_Payment_Suppliers_JS/DownPaymentToSupplierApplyForm.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
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
                                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_ltrInformation%>"></asp:Literal></h5>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblDownPaymentToSupplierId" Text="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_lblDownPaymentToSupplier%>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtDownPaymentToSupplier" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon">
                                    <a href="#" data-toggle="modal" data-target="#basicModalDownPaymentToSupplierSearch" data-keyboard="false" data-backdrop="static" onclick="CallBatchRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtDownPaymentToSupplierGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:RadioButton runat="server" ID="rdbNonPOBasedInvoiceId" ClientIDMode="Static"   GroupName="grID" AutoPostBack="true" Text="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_lblNonPOBasedInvoiceId %>" OnCheckedChanged="rdbNonPOBasedInvoiceId_CheckedChanged" />
                            <asp:RadioButton runat="server" ID="rdbPOBasedInvoiceId" ClientIDMode="Static"   GroupName="grID" AutoPostBack="true" Text="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_lblPOBasedInvoiceId %>" OnCheckedChanged="rdbPOBasedInvoiceId_CheckedChanged" />
                        </div>

                        <div id="divNonPOBasedInvoice" runat="server" visible="false"  class="form-group col-md-4 col-sm-4" >
                            <div>
                                <asp:Label runat="server" ID="lblApplyToDocumentNonPOBasedInvoiceId" Text="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_lblApplyToDocumentNonPOBasedInvoiceID %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtApplyToDocumentNonPOBasedInvoice" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon_ApplyToDocumentNonPOBasedInvoice">
                                     <a href="#" data-toggle="modal" data-target="#basicModalApplyToDocumentNonPOBasedInvoiceSearch" data-keyboard="false" data-backdrop="static" onclick="CallApplyToDocumentNonPOBasedInvoiceRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtApplyToDocumentNonPOBasedInvoiceGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div id="divPOBasedInvoice" runat="server" visible="false" class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblApplyToDocumentPOBasedInvoice" Text="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_lblApplyToDocumentPOBasedInvoiceID %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtApplyToDocumentPOBasedInvoice" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon_lblApplyToDocumentPOBasedInvoice">
                                    <a href="#" data-toggle="modal" data-target="#basicModalApplyToDocumentPOBasedInvoiceSearch" data-keyboard="false" data-backdrop="static" onclick="CallApplyToDocumentPOBasedInvoiceRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtApplyToDocumentPOBasedInvoiceGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblDueDate" Text="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_lblDueDate%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDueDate" TextMode="Date" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblRemainingAmount" Text="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_lblRemainingAmount%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtRemainingAmount" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblApplyAmount" Text="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_lblApplyAmount%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtApplyAmount" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblopt_Type" Text="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_lblopt_Type %>"></asp:Label>
                            <asp:DropDownList ID="ddloptType" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblOrignalDocumentAmount" Text="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_lblOrignalDocumentAmount%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtOrignalDocumentAmount" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDiscountDate" Text="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_lblDiscountDate%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDiscountDate" TextMode="Date" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>


                    </div>

                    
                           
                            <div class="form-group col-md-12" style="background-color: #f6f6f6">
                                <h5>
                                    <asp:Literal runat="server" ID="ltrDownPaymentToSupplier" Text="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_lblDownPaymentToSupplier%>"></asp:Literal></h5>
                            </div>

                            <div id="divdownPaymentfromCustomer" runat="server" class="form-group col-md-12 col-sm-12">
                                <%--<h3 class="hepad">
                                <asp:Label runat="server" ID="lblDownPaymentFromCustomerId" Text="<%$ Resources:GlobalResource, DownPaymentFromCustomerApply_lblDownPaymentFromCustomer %>"></asp:Label>
                            </h3>--%>
                                <div>
                                    <div class="form-group col-md-4 col-sm-4">
                                        <asp:Label runat="server" ID="lblSupplierId" Text="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_lblSupplierId%>"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtSupplierId" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-4 col-sm-4">
                                        <asp:Label runat="server" ID="lblSupplierName" Text="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_lblSupplierName%>"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtSupplierName" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-4 col-sm-4">
                                        <asp:Label runat="server" ID="lblType1" Text="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_lblType%>"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtType" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-4 col-sm-4">
                                        <asp:Label runat="server" ID="lblCurrency" Text="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_lblCurrency%>"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtCurrencyID" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-4 col-sm-4">
                                        <asp:Label runat="server" ID="lblDocumentNo" Text="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_lblDocumentNo%>"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtDocumentNumber" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-4 col-sm-4">
                                        <asp:Label runat="server" ID="lblOrignalAmount" Text="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_lblOrignalAmount%>"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtOrignalAmount" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-4 col-sm-4">
                                        <asp:Label runat="server" ID="lblApplyDate" Text="<%$ Resources:GlobalResource, DownPaymentToSupplierAApply_lblApplyDate%>"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtApplydate" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-4 col-sm-4">
                                        <asp:Label runat="server" ID="lblUnappliedAmount" Text="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_lblUnappliedAmount%>"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtUnappliedAmount" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                                    </div>

                                </div>
                            </div>



                            <div class="form-group col-md-12 col-sm-12">
                                <asp:DataGrid runat="server" ClientIDMode="Static" Font-Size="10pt" ID="gvData" AutoGenerateColumns="False" Width="100%" GridLines="None" CssClass="table table-hover" CellPadding="4" ForeColor="#333333">
                                    <AlternatingItemStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundColumn DataField="tbl_DownPaymentToSupplierApplyId" Visible="false"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_htDownPaymentToSupplier%>" DataField="tbl_DownPaymentToSupplier"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_htDueDate%>" DataField="DueDate"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_htApplyAmount%>" DataField="ApplyAmount"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_htopt_Type%>" DataField="Type"></asp:BoundColumn>                                   
                                    </Columns>
                                    <EditItemStyle BackColor="#7C6F57" />
                                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                                    <ItemStyle BackColor="#E3EAEB" />
                                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                </asp:DataGrid>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

    <div class="modal fade" id="basicModalDownPaymentToSupplierSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalDownPaymentToSupplierTitle"><span>
                        <asp:Literal runat="server" ID="ltrDownPaymentToSupplierTitle" Text="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_ltrDownPaymentToSupplierTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlDownPaymentToSupplierSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlDownPaymentToSupplierSearch" DefaultButton="btnDownPaymentToSupplierSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtDownPaymentToSupplierSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlDownPaymentToSupplierSearch" onclick="CallDownPaymentToSupplierSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlDownPaymentToSupplierClose" visible="false" onclick="ClearDownPaymentToSupplierSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnDownPaymentToSupplierSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnDownPaymentToSupplierSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearDownPaymentToSupplierSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearDownPaymentToSupplierSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divDownPaymentToSupplierSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblDownPaymentToSupplierSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divDownPaymentToSupplierSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblDownPaymentToSupplierSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgDownPaymentToSupplierData" AssociatedUpdatePanelID="updpnlgvDownPaymentToSupplierSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvDownPaymentToSupplierSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnDownPaymentToSupplierRefresh" ClientIDMode="Static" OnClick="btnDownPaymentToSupplierRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvDownPaymentToSupplierSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_htPaymentNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetDownPaymentToSupplierDetails('<%#Eval("PaymentNumber")%>','<%#Eval("tbl_DownPaymentToSupplierId")%>');">

                                                    <asp:Literal runat="server" ID="ltrgvPaymentNumber" Text='<%# Bind("PaymentNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_htPaymentDate%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPaymentDate" runat="server" Text='<%# Bind("PaymentDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_htBatchName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvBatchName" runat="server" Text='<%# Bind("BatchName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_htSupplierName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvSupplierName" runat="server" Text='<%# Bind("SupplierName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_htDownPaymentToSupplierGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvDownPaymentToSupplierGuid" runat="server" Text='<%# Bind("tbl_DownPaymentToSupplierId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnDownPaymentToSupplierSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearDownPaymentToSupplierSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrDownPaymentToSupplierClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalApplyToDocumentNonPOBasedInvoiceSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrApplyToDocumentApplyToDocumentNonPOBasedInvoiceTitle"><span>
                        <asp:Literal runat="server" ID="ltr_ApplyToDocumentNonPOBasedInvoice" Text="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_ltrApplyToDocumentNonPOBasedInvoice %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlApplyToDocumentNonPOBasedInvoice">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlApplyToDocumentNonPOBasedInvoiceSearch" DefaultButton="btnApplyToDocumentNonPOBasedInvoiceSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtApplyToDocumentNonPOBasedInvoiceSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlApplyToDocumentNonPOBasedInvoiceSearch" onclick="CallApplyToDocumentNonPOBasedInvoiceSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlApplyToDocumentNonPOBasedInvoiceClose" visible="false" onclick="ClearApplyToDocumentNonPOBasedInvoiceSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnApplyToDocumentNonPOBasedInvoiceSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnApplyToDocumentNonPOBasedInvoiceSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearApplyToDocumentNonPOBasedInvoiceSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearApplyToDocumentNonPOBasedInvoiceSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divApplyToDocumentNonPOBasedInvoiceSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblApplyToDocumentNonPOBasedInvoiceSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divApplyToDocumentNonPOBasedInvoiceSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblApplyToDocumentNonPOBasedInvoiceSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateApplyToDocumentNonPOBasedInvoiceProgress" AssociatedUpdatePanelID="updpnlgvApplyToDocumentNonPOBasedInvoiceSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvApplyToDocumentNonPOBasedInvoiceSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnApplyToDocumentNonPOBasedInvoiceRefresh" ClientIDMode="Static" OnClick="btnApplyToDocumentNonPOBasedInvoiceRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvApplyToDocumentNonPOBasedInvoiceSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,DownPaymentToSupplierApply_htNonPOBasedInvoiceDescription%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetApplyToDocumentNonPOBasedInvoiceDetails('<%#Eval("Description")%>','<%#Eval("tbl_NonPOBasedInvoiceId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvDescription" Text='<%# Bind("Description") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_htApplyToDocumentName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplyToDocumentNonPOBasedInvoiceDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_htNonPOBasedInvoiceGuid%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblentNonPOBasedInvoiceGuid" runat="server" Text='<%# Bind("tbl_NonPOBasedInvoiceId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnApplyToDocumentNonPOBasedInvoiceSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearApplyToDocumentNonPOBasedInvoiceSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div2">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrApplyToDocumentNonPOBasedInvoiceClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalApplyToDocumentPOBasedInvoiceSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrApplyToDocumentApplyToDocumentPOBasedInvoiceTitle"><span>
                        <asp:Literal runat="server" ID="ltr_ApplyToDocumentPOBasedInvoice" Text="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_ltrApplyToDocumentPOBasedInvoice %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlApplyToDocumentPOBasedInvoice">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlApplyToDocumentPOBasedInvoiceSearch" DefaultButton="btnApplyToDocumentPOBasedInvoiceSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtApplyToDocumentPOBasedInvoiceSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlApplyToDocumentPOBasedInvoiceSearch" onclick="CallApplyToDocumentPOBasedInvoiceSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlApplyToDocumentPOBasedInvoiceClose" visible="false" onclick="ClearApplyToDocumentPOBasedInvoiceSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnApplyToDocumentPOBasedInvoiceSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnApplyToDocumentPOBasedInvoiceSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearApplyToDocumentPOBasedInvoiceSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearApplyToDocumentPOBasedInvoiceSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divApplyToDocumentPOBasedInvoiceSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblApplyToDocumentPOBasedInvoiceSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divApplyToDocumentPOBasedInvoiceSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblApplyToDocumentPOBasedInvoiceSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateApplyToDocumentPOBasedInvoiceProgress" AssociatedUpdatePanelID="updpnlgvApplyToDocumentPOBasedInvoiceSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvApplyToDocumentPOBasedInvoiceSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnApplyToDocumentPOBasedInvoiceRefresh" ClientIDMode="Static" OnClick="btnApplyToDocumentPOBasedInvoiceRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvApplyToDocumentPOBasedInvoiceSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,DownPaymentToSupplierApply_htPOBasedInvoiceSupplierName%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetApplyToDocumentPOBasedInvoiceDetails('<%#Eval("SupplierName")%>','<%#Eval("tbl_POBasedInvoiceId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvSupplierName" Text='<%# Bind("SupplierName") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_htPOBasedInvoiceCurrencyName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplyToDocumentPOBasedInvoiceCurrencyName" runat="server" Text='<%# Bind("CurrencyName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_htPOBasedInvoiceBatchName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplyToDocumentPOBasedInvoiceBatchName" runat="server" Text='<%# Bind("BatchName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                     <%--    <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, DownPaymentToSupplierApply_htApplyToDocumentPOBasedInvoiceGuid"%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplyToDocumentApplyToDocumentPOBasedInvoiceId" runat="server" Text='<%# Bind("tbl_POBasedInvoiceId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnApplyToDocumentPOBasedInvoiceSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearApplyToDocumentPOBasedInvoiceSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div1">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrApplyToDocumentPOBasedInvoiceClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


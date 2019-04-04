<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GoodsReceivedNoteForm.aspx.cs" Inherits="Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services_GoodsReceivedNoteForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
	<script src="../../../infra_ui/js/Procurement_JS/Receive%20Goods%20or%20Services_JS/Receive_Goods_or_Services_JS/GoodsReceivedNoteForm.js"></script>
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
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-success" OnClick="btnDelete_Click" Text="<%$ Resources:GlobalResource, btnDelete%>" />
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-success" OnClick="btnBack_Click" Text="<%$ Resources:GlobalResource, btnBack%>" formnovalidate="formnovalidate" />
                    <asp:Button runat="server" ID="btnClear" CssClass="btn btn-success" OnClientClick="return ClearForm();" Text="<%$ Resources:GlobalResource, btnClear%>" formnovalidate="formnovalidate"></asp:Button>
                    <asp:Button runat="server" ID="btnGoodsReceivedNoteDetails" Visible="false" Width="200Px" CssClass="btn btn-success" OnClick="btnGoodsReceivedNoteDetails_Click" Text="<%$ Resources:GlobalResource, btnGoodsReceivedNoteDetails%>" formnovalidate="formnovalidate"></asp:Button>
                    <asp:Button runat="server" ID="btnSaveGoodsReceivedNoteDetails" Width="250Px" CssClass="btn btn-success" OnClick="btnSaveGoodsReceivedNoteDetails_Click" Text="<%$ Resources:GlobalResource, btnSaveGoodsReceivedNoteDetails%>" formnovalidate="formnovalidate" />
                    <asp:Button runat="server" ID="btnPost" CssClass="btn btn-success" OnClick="btnPost_Click" Text="<%$ Resources:GlobalResource, btnPost%>" formnovalidate="formnovalidate"></asp:Button>
                </div>
            </div>
        </div>
        <div class="ui-content-body">
            <div class="ui-container">
                <div class="row" runat="server" id="divGoodsReceivedNote">
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
                                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, GoodsReceivedNote_ltrInformation%>"></asp:Literal></h5>
                        </div>
                        <div class="form-group col-md-4 col-sm-4" id="divPO" runat="server">

                            <div>
                                <asp:Label runat="server" ID="lblPOId" Text="<%$ Resources:GlobalResource, GoodsReceivedNote_lblPOId %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtPO" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon4">
                                    <a href="#" data-toggle="modal" data-target="#basicModalPOSearch" data-keyboard="false" data-backdrop="static" onclick="CallPORefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPOGuid" runat="server" ReadOnly="true" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lbOpt_ReceivedType" Text="<%$ Resources:GlobalResource, GoodsReceivedNote_lblOpt_ReceivedType %>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_ReceivedType" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblGoodsReceivedNoteNumber" Text="<%$ Resources:GlobalResource, GoodsReceivedNote_lblGoodsReceivedNoteNumber%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtGoodsReceivedNoteNumber" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isAlphaNumberKey(this);" MaxLength="50" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblSupplier" Text="<%$ Resources:GlobalResource, GoodsReceivedNote_lblSupplierId %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtSupplier" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon3">
                                    <a href="#" data-toggle="modal" data-target="#basicModalSupplierSearch" data-keyboard="false" data-backdrop="static" onclick="CallSupplierRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtSupplierGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblSupplierDocumentNumber" Text="<%$ Resources:GlobalResource, GoodsReceivedNote_lblSupplierDocumentNumber%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtSupplierDocumentNumber" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isAlphaNumberKey(this);" MaxLength="50" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblDate" Text="<%$ Resources:GlobalResource, GoodsReceivedNote_lblDate%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDate" TextMode="Date" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCurrencyId" Text="<%$ Resources:GlobalResource, GoodsReceivedNote_lblCurrencyId %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtCurrency" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon_Cuurency">
                                    <a href="#" data-toggle="modal" data-target="#basicModalCurrencySearch" data-keyboard="false" data-backdrop="static" onclick="CallCurrencyRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtCurrencyGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblBatch" Text="<%$ Resources:GlobalResource, GoodsReceivedNote_lblBatchId %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtBatch" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon">
                                    <a href="#" data-toggle="modal" data-target="#basicModalBatchSearch" data-keyboard="false" data-backdrop="static" onclick="CallBatchRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtBatchGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblSubTotal" Text="<%$ Resources:GlobalResource, GoodsReceivedNote_lblSubTotal%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtSubTotal" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isNumberKeyPoint(this);"  MaxLength="9"  required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblTradeDiscount" Text="<%$ Resources:GlobalResource, GoodsReceivedNote_lblTradeDiscount%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtTradeDiscount" ClientIDMode="Static" class="form-control" onkeypress="return isNumberKeyPoint(this);"  MaxLength="9" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblFreight" Text="<%$ Resources:GlobalResource, GoodsReceivedNote_lblFreight%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtFreight" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isNumberKeyPoint(this);"  MaxLength="9" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblMiscellaneous" Text="<%$ Resources:GlobalResource, GoodsReceivedNote_lblMiscellaneous%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtMiscellaneous" ClientIDMode="Static" class="form-control" onkeypress="return isNumberKeyPoint(this);"  MaxLength="9" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblTotal" Text="<%$ Resources:GlobalResource, GoodsReceivedNote_lblTotal%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtTotal" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-12 col-sm-12" id="divPoDetails" runat="server">
                            <h3 class="hepad">
                                <asp:Label runat="server" ID="lblPurchaseOrder"></asp:Label></h3>
                            <asp:GridView runat="server" ClientIDMode="Static" Font-Size="10pt" ID="gvData" AutoGenerateColumns="False" Width="100%" GridLines="None" CssClass="table table-hover" CellPadding="4" ForeColor="#333333" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvData_SelectedIndexChanged">

                                <Columns>
                                    <asp:BoundField DataField="tbl_POId" Visible="false"></asp:BoundField>
                                    <asp:BoundField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNoteDetails_PO%>" DataField="tbl_PO"></asp:BoundField>
                                    <asp:BoundField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNoteDetails_htFixedAsset%>" DataField="FixedAsset"></asp:BoundField>
                                    <asp:BoundField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htUOM%>" DataField="UOM"></asp:BoundField>
                                    <asp:BoundField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htDescription%>" DataField="Description"></asp:BoundField>
                                    <asp:BoundField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htLocation%>" DataField="tbl_Location"></asp:BoundField>
                                    <asp:BoundField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htQuantityOrdered%>" DataField="QuantityOrdered"></asp:BoundField>
                                    <asp:BoundField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htUnitCost%>" DataField="UnitCost"></asp:BoundField>
                                    <asp:BoundField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htExtendedCost%>" DataField="ExtendedCost"></asp:BoundField>
                                    <%-- <asp:BoundField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htPreviouslyShipped %>" DataField=""></asp:BoundField>
                                    <asp:BoundField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htPreviouslyInvoiced%>" DataField=""></asp:BoundField>
                                    <asp:BoundField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htShippedOty %>" DataField=""></asp:BoundField>
                                    <asp:BoundField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htInvoicedQty%>" DataField=""></asp:BoundField>--%>


                                </Columns>

                            </asp:GridView>

                        </div>
                          

                    </div>
                </div>
                <div class="row" runat="server" id="divGoodsReceivedNoteDetails">
                    <h3 class="hepad">
                        <asp:Label runat="server" ID="lblGoodsReceivedNoteDetails"></asp:Label></h3>
                    <div class="col-md-12 col-sm-12 colformstyle">
                        <div runat="server" id="divError1" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblerror1"></asp:Label>
                        </div>
                        <div runat="server" id="divSuccess1" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblSuccess1"></asp:Label>
                        </div>
                        <div class="form-group col-md-12" style="background-color: #f6f6f6">
                            <h5>
                                <asp:Literal runat="server" ID="ltrInformationGoodReciecvedNoteDetails" Text="<%$ Resources:GlobalResource, GoodsReceivedNoteDetails_ltrInformation%>"></asp:Literal></h5>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPODetails" Text="<%$ Resources:GlobalResource, GoodsReceivedNoteDetails_lblPODetails %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtPODetails" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" ></asp:TextBox>
                            <asp:TextBox ID="txtPODetailsGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblGoodsReceivedNoteId" Text="<%$ Resources:GlobalResource, GoodsReceivedNoteDetails_lblGoodsReceivedNoteId %>"></asp:Label>

                            <asp:TextBox runat="server" ID="txtGoodsReceivedNote" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" ></asp:TextBox>
                            <asp:TextBox ID="txtGoodsReceivedNoteGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPO" Text="<%$ Resources:GlobalResource, GoodsReceivedNoteDetails_lblPOId %>"></asp:Label>

                            <asp:TextBox ID="txtPOId" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:TextBox ID="txtPOIdGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAsset" Text="<%$ Resources:GlobalResource, GoodsReceivedNoteDetails_lblAssetId %>"></asp:Label>

                            <asp:TextBox ID="txtAsset" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:TextBox ID="txtAssetGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblUOM" Text="<%$ Resources:GlobalResource, GoodsReceivedNoteDetails_lblUOM%>"></asp:Label>
                            <asp:TextBox ReadOnly="true" runat="server" ID="txtUOM" ClientIDMode="Static" class="form-control" placeholder="" ></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblLocationId" Text="<%$ Resources:GlobalResource, GoodsReceivedNoteDetails_lblLocationId %>"></asp:Label>

                            <asp:TextBox ID="txtLocation" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:TextBox ID="txtLocationGuid" ReadOnly="true" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource, GoodsReceivedNoteDetails_lblDescription%>"></asp:Label>
                            <asp:TextBox ReadOnly="true" runat="server" ID="txtDescription" ClientIDMode="Static" class="form-control" placeholder=""></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblQuantityOrdered" Text="<%$ Resources:GlobalResource, GoodsReceivedNoteDetails_lblQuantityOrdered%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtQuantityOrdered" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" ></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblQuantityShipped" Text="<%$ Resources:GlobalResource, GoodsReceivedNoteDetails_lblQuantityShipped%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtQuantityShipped" ClientIDMode="Static" class="form-control" placeholder=""  OnTextChanged="txtQuantityShipped_TextChanged"></asp:TextBox>

                        </div>
                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblQuantityInvoiced" Text="<%$ Resources:GlobalResource, GoodsReceivedNoteDetails_lblQuantityInvoiced%>"></asp:Label>
                            <asp:TextBox runat="server" ReadOnly="true" ID="txtQuantityInvoiced" ClientIDMode="Static" class="form-control" placeholder="" ></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblPreviouslyShipped" Text="<%$ Resources:GlobalResource, GoodsReceivedNoteDetails_lblPreviouslyShipped%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtPreviouslyShipped" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder=""></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblPreviouslyInvoiced" Text="<%$ Resources:GlobalResource, GoodsReceivedNoteDetails_lblPreviouslyInvoiced%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtPreviouslyInvoiced" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblUnitCost" Text="<%$ Resources:GlobalResource, GoodsReceivedNoteDetails_lblUnitCost%>"></asp:Label>
                            <asp:TextBox runat="server" ReadOnly="true" ID="txtUnitCost" ClientIDMode="Static" class="form-control" placeholder="" ></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblExtendedCost" Text="<%$ Resources:GlobalResource, GoodsReceivedNoteDetails_lblExtendedCost%>"></asp:Label>
                            <asp:TextBox runat="server" ReadOnly="true" ID="txtExtendedCost" ClientIDMode="Static" class="form-control" placeholder=""></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-md-12 col-sm-12" id="divGoodsReceivedNoteDetail" runat="server">
                            <h3 class="hepad">
                                <asp:Label runat="server" ID="lblGoodsReceivedNoteDetail"></asp:Label></h3>
                            <asp:GridView runat="server" ClientIDMode="Static" Font-Size="10pt" ID="gvdetails" AutoGenerateColumns="False" Width="100%" GridLines="None" CssClass="table table-hover" CellPadding="4" ForeColor="#333333" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvdetails_SelectedIndexChanged" >

                                <Columns>
                                    <asp:BoundField DataField="tbl_GoodsReceivedNoteDetails" Visible="false"></asp:BoundField>
                                    <asp:BoundField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNoteDetails_PO%>" DataField="tbl_PO"></asp:BoundField>
                                    <asp:BoundField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNoteDetails_htFixedAsset%>" DataField="tbl_Asset"></asp:BoundField>
                                    <asp:BoundField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htUOM%>" DataField="UOM"></asp:BoundField>
                                    <asp:BoundField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htDescription%>" DataField="Description"></asp:BoundField>
                                    <asp:BoundField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htLocation%>" DataField="tbl_Location"></asp:BoundField>
                                    <asp:BoundField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htQuantityOrdered%>" DataField="QuantityOrdered"></asp:BoundField>
                                    <asp:BoundField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htUnitCost%>" DataField="UnitCost"></asp:BoundField>
                                    <asp:BoundField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htExtendedCost%>" DataField="ExtendedCost"></asp:BoundField>
                                     <asp:BoundField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htPreviouslyShipped %>" DataField="PreviouslyShipped"></asp:BoundField>
                                    <asp:BoundField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htPreviouslyInvoiced%>" DataField="PreviouslyInvoiced"></asp:BoundField>
                                    <asp:BoundField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htShippedOty %>" DataField="QuantityShipped"></asp:BoundField>
                                    <asp:BoundField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htInvoicedQty%>" DataField="QuantityInvoiced"></asp:BoundField>


                                </Columns>

                            </asp:GridView>

                        </div>
                </div>

            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalPOSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalPOTitle"><span>
                        <asp:Literal runat="server" ID="Literal3" Text="<%$ Resources:GlobalResource, GoodsReceivedNote_ltrPOTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlPOSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlPOSearch" DefaultButton="btnPOSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtPOSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlPOSearch" onclick="CallPOSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlPOClose" visible="false" onclick="ClearPOSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnPOSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnPOSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearPOSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearPOSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divPOSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblPOSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divPOSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblPOSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateProgress2" AssociatedUpdatePanelID="updpnlgvPOSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvPOSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnPORefresh" ClientIDMode="Static" OnClick="btnPORefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvPOSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,GoodsReceivedNote_htPONumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetPODetails('<%#Eval("PONumber")%>','<%#Eval("tbl_POId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvPOCode" Text='<%# Bind("PONumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$Resources:GlobalResource, GoodsReceivedNote_htPOGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPOId" runat="server" Text='<%# Bind("tbl_POId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPOSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearPOSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div2">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrPOClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalBatchSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalBatchTitle"><span>
                        <asp:Literal runat="server" ID="ltrBatchTitle" Text="<%$ Resources:GlobalResource, GoodsReceivedNote_ltrBatchTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlBatchSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlBatchSearch" DefaultButton="btnBatchSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtBatchSearch" CssClass="form-control" placeholder="Search..." autofocu=""></asp:TextBox>
                                        <a runat="server" id="btnHtmlBatchSearch" onclick="CallBatchSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlBatchClose" visible="false" onclick="ClearBatchSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnBatchSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnBatchSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearBatchSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearBatchSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divBatchSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblBatchSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divBatchSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblBatchSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgBatchData" AssociatedUpdatePanelID="updpnlgvBatchSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvBatchSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnBatchRefresh" ClientIDMode="Static" OnClick="btnBatchRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvBatchSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htBatchType%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetBatchDetails('<%#Eval("BatchName")%>','<%#Eval("tbl_BatchId")%>');">

                                                    <asp:Literal runat="server" ID="ltrgvBatchType" Text='<%# Bind("Opt_BatchType") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htBatchName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvBatchName" runat="server" Text='<%# Bind("BatchName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htBatchGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvBatchGuid" runat="server" Text='<%# Bind("tbl_BatchId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnBatchSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearBatchSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrBatchClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="modal fade" id="basicModalSupplierSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalSupplierTitle"><span>
                        <asp:Literal runat="server" ID="ltrSupplierTitle" Text="<%$ Resources:GlobalResource, GoodsReceivedNote_ltrSupplierTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlSupplierSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlSupplierSearch" DefaultButton="btnSupplierSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtSupplierSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlSupplierSearch" onclick="CallSupplierSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlSupplierClose" visible="false" onclick="ClearSupplierSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnSupplierSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnSupplierSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearSupplierSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearSupplierSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divSupplierSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblSupplierSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divSupplierSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblSupplierSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgSupplierData" AssociatedUpdatePanelID="updpnlgvSupplierSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvSupplierSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnSupplierRefresh" ClientIDMode="Static" OnClick="btnSupplierRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvSupplierSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htSupplierCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetSupplierDetails('<%#Eval("Name")%>','<%#Eval("tbl_SupplierId")%>');">

                                                    <asp:Literal runat="server" ID="ltrgvSupplierType" Text='<%# Bind("SupplierCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htSupplierName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvSupplierName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htSupplierGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvSupplierGuid" runat="server" Text='<%# Bind("tbl_SupplierId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnSupplierSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearSupplierSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div1">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrSupplierClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalCurrencySearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalCurrencyTitle"><span>
                        <asp:Literal runat="server" ID="ltrCurrencyTitle" Text="<%$ Resources:GlobalResource, GoodsReceivedNote_ltrCurrencyTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlCurrency">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlCurrency" DefaultButton="btnCurrencySearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtCurrencySearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlCurrencySearch" onclick="CallCurrencySearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlCurrencyClose" visible="false" onclick="ClearCurrencySearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnCurrencySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnCurrencySearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearCurrencySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearCurrencySearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divCurrencySearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblCurrencySearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divCurrencySearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblCurrencySearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgCurrencyData" AssociatedUpdatePanelID="updpnlgvCurrencySearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvCurrencySearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnCurrencyRefresh" ClientIDMode="Static" OnClick="btnCurrencyRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvCurrencySearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>

                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,GoodsReceivedNote_htCurrencyCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCurrencyDetails('<%#Eval("CurrencyName")%>','<%#Eval("tbl_CurrencyId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCurrencyCode" Text='<%# Bind("CurrencyCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htCurrencyName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCurrencyName" runat="server" Text='<%# Bind("CurrencyName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GoodsReceivedNote_htCurrencyGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCurrencyGuid" runat="server" Text='<%# Bind("tbl_CurrencyId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnCurrencySearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearCurrencySearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divCurrencyFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblCurrencyClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>


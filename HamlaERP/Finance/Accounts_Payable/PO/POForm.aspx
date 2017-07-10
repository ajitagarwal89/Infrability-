<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="POForm.aspx.cs" Inherits="Finance_Accounts_Payable_PO_POForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Accounts_Payable_JS/PO_JS/POForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, PO_ltrInformation%>"></asp:Literal></h5>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblopt_Type" Text="<%$ Resources:GlobalResource, PO_lblopt_Type%>"></asp:Label>
                              <asp:DropDownList ID="ddlOpt_opt_Type" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                              <asp:Label runat="server" ID="lblPONumber" Text="<%$ Resources:GlobalResource, PO_lblPONumber%>"></asp:Label>
                          <asp:TextBox type="text" runat="server" ID="txtPONumber" ClientIDMode="Static" class="form-control "  placeholder="" required="required"></asp:TextBox>
                              </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblSupplier" Text="<%$ Resources:GlobalResource, PO_lblSupplierGroup%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtSupplier" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addonSupplier">
                                           <a href="#" data-toggle="modal" data-target="#basicModalSupplierSearch" data-keyboard="false" data-backdrop="static" onclick="CallSupplierGroupRefreshButton();" ">
                                        <i class="fa fa-search"></i></a>
                                </span>

                                <asp:TextBox ID="txtSupplierGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblUserId_Buyer" Text="<%$ Resources:GlobalResource, PO_lblUserId_Buyer%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtUserId_Buyer" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addonBuyer">
                                           <a href="#" data-toggle="modal" data-target="#basicModalUserId_BuyerSearch" data-keyboard="false" data-backdrop="static" onclick="CallUserId_BuyerRefreshButton();" ">
                                        <i class="fa fa-search"></i></a>
                                </span>

                                <asp:TextBox ID="txtUserId_BuyerGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                              <asp:Label runat="server" ID="lblDate" Text="<%$ Resources:GlobalResource, PO_lblDate%>"></asp:Label>
                          <asp:TextBox type="text" runat="server" ID="txtDate" TextMode="Date" ClientIDMode="Static" class="form-control "  placeholder="" required="required"></asp:TextBox>
                              </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCurrencyId" Text="<%$ Resources:GlobalResource, PO_lblCurrencyId %>"></asp:Label>
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
                            <asp:Label runat="server" ID="lblAllowSales" Text="<%$ Resources:GlobalResource, PO_lblAllowSales%>"></asp:Label>

                            <asp:CheckBox ID="chkAllowSales" runat="server"  ClientIDMode="Static" class="form-control" placeholder="" required="required"/>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                              <asp:Label runat="server" ID="lblRequisitionDate" Text="<%$ Resources:GlobalResource, PO_lblRequisitionDate%>"></asp:Label>
                          <asp:TextBox type="text" runat="server" ID="txtRequisitionDate" TextMode="Date" ClientIDMode="Static" class="form-control "  placeholder="" required="required"></asp:TextBox>
                              </div>

                        <div class="form-group col-md-4 col-sm-4">
                              <asp:Label runat="server" ID="lblPurchaseOrderDate" Text="<%$ Resources:GlobalResource, PO_lblPurchaseOrderDate%>"></asp:Label>
                          <asp:TextBox type="text" runat="server" ID="txtPurchaseOrderDate" TextMode="Date" ClientIDMode="Static" class="form-control "  placeholder="" required="required"></asp:TextBox>
                              </div>

                        <div class="form-group col-md-4 col-sm-4">
                              <asp:Label runat="server" ID="lblLastEditDate" Text="<%$ Resources:GlobalResource, PO_lblLastEditDate%>"></asp:Label>
                          <asp:TextBox type="text" runat="server" ID="txtLastEditDate" TextMode="Date" ClientIDMode="Static" class="form-control "  placeholder="" required="required"></asp:TextBox>
                              </div>

                        <div class="form-group col-md-4 col-sm-4">
                              <asp:Label runat="server" ID="lblLastPrintedDate" Text="<%$ Resources:GlobalResource, PO_lblLastPrintedDate%>"></asp:Label>
                          <asp:TextBox type="text" runat="server" ID="txtLastPrintedDate" TextMode="Date" ClientIDMode="Static" class="form-control "  placeholder="" required="required"></asp:TextBox>
                              </div>

                        <div class="form-group col-md-4 col-sm-4">
                              <asp:Label runat="server" ID="lblContractExpirationDate" Text="<%$ Resources:GlobalResource, PO_lblContractExpirationDate%>"></asp:Label>
                          <asp:TextBox type="text" runat="server" ID="txtContractExpirationDate" TextMode="Date" ClientIDMode="Static" class="form-control "  placeholder="" required="required"></asp:TextBox>
                              </div>

                        <div class="form-group col-md-4 col-sm-4">
                              <asp:Label runat="server" ID="lblDatePlacedOnHold" Text="<%$ Resources:GlobalResource, PO_lblDatePlacedOnHold%>"></asp:Label>
                          <asp:TextBox type="text" runat="server" ID="txtDatePlacedOnHold" TextMode="Date" ClientIDMode="Static" class="form-control "  placeholder="" required="required"></asp:TextBox>
                              </div>

                        <div class="form-group col-md-4 col-sm-4">
                              <asp:Label runat="server" ID="lblDateHoldRemoved" Text="<%$ Resources:GlobalResource, PO_lblDateHoldRemoved%>"></asp:Label>
                          <asp:TextBox type="text" runat="server" ID="txtDateHoldRemoved" TextMode="Date" ClientIDMode="Static" class="form-control "  placeholder="" required="required"></asp:TextBox>
                              </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblPlacedOnHoldBy" Text="<%$ Resources:GlobalResource, PO_lblPlacedOnHoldBy %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtPlacedOnHoldBy" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon">
                                    <a href="#" data-toggle="modal" data-target="#basicModalPlacedOnHoldBySearch" data-keyboard="false" data-backdrop="static" onclick="CallPlacedOnHoldByRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPlacedOnHoldByGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblHoldRemovedBy" Text="<%$ Resources:GlobalResource, PO_lblHoldRemovedBy %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtHoldRemovedBy" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon1">
                                    <a href="#" data-toggle="modal" data-target="#basicModalHoldRemovedBySearch" data-keyboard="false" data-backdrop="static" onclick="CallHoldRemovedByRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtHoldRemovedByGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                              <asp:Label runat="server" ID="lblRemainingSubTotal" Text="<%$ Resources:GlobalResource, PO_lblRemainingSubTotal%>"></asp:Label>
                          <asp:TextBox type="text" runat="server" ID="txtRemainingSubTotal" ClientIDMode="Static" class="form-control "  placeholder="" required="required"></asp:TextBox>
                              </div>

                        <div class="form-group col-md-4 col-sm-4">
                              <asp:Label runat="server" ID="lblSubTotal" Text="<%$ Resources:GlobalResource, PO_lblSubTotal%>"></asp:Label>
                          <asp:TextBox type="text" runat="server" ID="txtSubTotal" ClientIDMode="Static" class="form-control "  placeholder="" required="required"></asp:TextBox>
                             
                                </div>

                        <div class="form-group col-md-4 col-sm-4">
                              <asp:Label runat="server" ID="lblTradeDiscount" Text="<%$ Resources:GlobalResource, PO_lblTradeDiscount%>"></asp:Label>
                          <asp:TextBox type="text" runat="server" ID="txtTradeDiscount" ClientIDMode="Static" class="form-control "  placeholder="" required="required"></asp:TextBox>
                             
                                </div>

                        <div class="form-group col-md-4 col-sm-4">
                              <asp:Label runat="server" ID="lblFreight" Text="<%$ Resources:GlobalResource, PO_lblFreight%>"></asp:Label>
                          <asp:TextBox type="text" runat="server" ID="txtFreight" ClientIDMode="Static" class="form-control "  placeholder="" required="required"></asp:TextBox>
                             
                                </div>

                        <div class="form-group col-md-4 col-sm-4">
                              <asp:Label runat="server" ID="lblMiscellaneous" Text="<%$ Resources:GlobalResource, PO_lblMiscellaneous%>"></asp:Label>
                          <asp:TextBox type="text" runat="server" ID="txtMiscellaneous" ClientIDMode="Static" class="form-control "  placeholder="" required="required"></asp:TextBox>
                             
                                </div>

                        <div class="form-group col-md-4 col-sm-4">
                              <asp:Label runat="server" ID="lblTotal" Text="<%$ Resources:GlobalResource, PO_lblTotal%>"></asp:Label>
                          <asp:TextBox type="text" runat="server" ID="txtTotal" ClientIDMode="Static" class="form-control "  placeholder="" required="required"></asp:TextBox>
                             
                                </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblComments" Text="<%$ Resources:GlobalResource, PO_lblComments %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtComments" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon_Comments">
                                    <a href="#" data-toggle="modal" data-target="#basicModalCommentsSearch" data-keyboard="false" data-backdrop="static" onclick="CallCommentsRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtCommentsGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                              <asp:Label runat="server" ID="lblVersion" Text="<%$ Resources:GlobalResource, PO_lblVersion%>"></asp:Label>
                          <asp:TextBox type="text" runat="server" ID="txtVersion" ClientIDMode="Static" class="form-control "  placeholder="" required="required"></asp:TextBox>
                              </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblopt_Status" Text="<%$ Resources:GlobalResource, PO_lblopt_Status%>"></asp:Label>
                              <asp:DropDownList ID="ddlopt_Status" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                    </div>

                    <div class="modal fade" id="basicModalPlacedOnHoldBySearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header" style="text-align: left;">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    <h4 class="modal-title" id="hdrModalPlacedOnHoldByTitle"><span>
                                        <asp:Literal runat="server" ID="ltrPlacedOnHoldByTitle" Text="<%$ Resources:GlobalResource, PO_ltrPlacedOnHoldByInformation %>"></asp:Literal>
                                    </span>
                                    </h4>
                                </div>
                                <div class="modal-body">

                                    <asp:UpdatePanel runat="server" ID="updpnlPlacedOnHoldBy">
                                        <ContentTemplate>
                                            <asp:Panel runat="server" ID="pnlPlacedOnHoldBy" DefaultButton="btnPlacedOnHoldBySearch">
                                                <div class="col-md-4 col-xs-5">
                                                    <div class="icon-addon addon-md">
                                                        <asp:TextBox runat="server" ID="txtPlacedOnHoldBySearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                                        <a runat="server" id="btnHtmlPlacedOnHoldBySearch" onclick="CallPlacedOnHoldBySearch();" class="fa fa-search"></a>
                                                        <a runat="server" id="btnHtmlPlacedOnHoldByClose" visible="false" onclick="ClearPlacedOnHoldBySearch();" class="fa fa-close closex"></a>
                                                    </div>
                                                </div>
                                                <asp:Button runat="server" ID="btnPlacedOnHoldBySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnPlacedOnHoldBySearch_Click" formnovalidate="formnovalidate" />
                                                <asp:Button runat="server" ID="btnClearPlacedOnHoldBySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearPlacedOnHoldBySearch_Click" formnovalidate="formnovalidate" />

                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                    <div class="col-md-12 col-sm-12 colformstyle3">
                                        <div runat="server" id="divPlacedOnHoldBySearchError" visible="false" class="alert alert-danger" role="alert">
                                            <asp:Label runat="server" ID="lblPlacedOnHoldBySearchError"></asp:Label>
                                        </div>
                                        <div runat="server" id="divPlacedOnHoldBySearchSucces" visible="false" class="alert alert-success" role="alert">
                                            <asp:Label runat="server" ID="lblPlacedOnHoldBySearchSucces"></asp:Label>
                                        </div>
                                    </div>
                                    <div>
                                        <asp:UpdateProgress runat="server" ID="updProgPlacedOnHoldByData" AssociatedUpdatePanelID="updpnlgvPlacedOnHoldBySearch">
                                            <ProgressTemplate>
                                                Loading...
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:UpdatePanel runat="server" ID="updpnlgvPlacedOnHoldBySearch">
                                            <ContentTemplate>
                                                <asp:Button runat="server" ID="btnPlacedOnHoldByRefresh" ClientIDMode="Static" OnClick="btnPlacedOnHoldByRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                                <asp:GridView ID="gvPlacedOnHoldBySearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PO_htPlacedOnHoldByCode%>">
                                                            <ItemTemplate>
                                                                <a href="#" data-dismiss="modal" onclick="SetPlacedOnHoldByDetails('<%#Eval("EmployeeCode")%>','<%#Eval("tbl_UserId")%>');">
                                                                    <asp:Literal runat="server" ID="ltrgvDescription" Text='<%# Bind("FullName") %>'></asp:Literal>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PO_htPlacedOnHoldByName%>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvSuplierName" runat="server" Text='<%# Bind("FullName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PO_htPlacedOnHoldByGuid%>" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvPlacedOnHoldByGuid" runat="server" Text='<%# Bind("tbl_UserId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPlacedOnHoldBySearch" />
                                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearPlacedOnHoldBySearch" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="modal-footer row" runat="server" id="divPlacedOnHoldByFooter">
                                    <div class="pull-left">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">
                                            <asp:Literal runat="server" ID="lblPlacedOnHoldByClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="modal fade" id="basicModalHoldRemovedBySearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header" style="text-align: left;">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    <h4 class="modal-title" id="hdrModalHoldRemovedByTitle"><span>
                                        <asp:Literal runat="server" ID="ltrHoldRemovedByTitle" Text="<%$ Resources:GlobalResource, PO_ltrHoldRemovedByInformation %>"></asp:Literal>
                                    </span>
                                    </h4>
                                </div>
                                <div class="modal-body">

                                    <asp:UpdatePanel runat="server" ID="updpnlHoldRemovedBy">
                                        <ContentTemplate>
                                            <asp:Panel runat="server" ID="pnlHoldRemovedBy" DefaultButton="btnHoldRemovedBySearch">
                                                <div class="col-md-4 col-xs-5">
                                                    <div class="icon-addon addon-md">
                                                        <asp:TextBox runat="server" ID="txtHoldRemovedBySearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                                        <a runat="server" id="btnHtmlHoldRemovedBySearch" onclick="CallHoldRemovedBySearch();" class="fa fa-search"></a>
                                                        <a runat="server" id="btnHtmlHoldRemovedByClose" visible="false" onclick="ClearHoldRemovedBySearch();" class="fa fa-close closex"></a>
                                                    </div>
                                                </div>
                                                <asp:Button runat="server" ID="btnHoldRemovedBySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnHoldRemovedBySearch_Click" formnovalidate="formnovalidate" />
                                                <asp:Button runat="server" ID="btnClearHoldRemovedBySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearHoldRemovedBySearch_Click" formnovalidate="formnovalidate" />

                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                    <div class="col-md-12 col-sm-12 colformstyle3">
                                        <div runat="server" id="divHoldRemovedBySearchError" visible="false" class="alert alert-danger" role="alert">
                                            <asp:Label runat="server" ID="lblHoldRemovedBySearchError"></asp:Label>
                                        </div>
                                        <div runat="server" id="divHoldRemovedBySearchSucces" visible="false" class="alert alert-success" role="alert">
                                            <asp:Label runat="server" ID="lblHoldRemovedBySearchSucces"></asp:Label>
                                        </div>
                                    </div>
                                    <div>
                                        <asp:UpdateProgress runat="server" ID="updProgHoldRemovedByData" AssociatedUpdatePanelID="updpnlgvHoldRemovedBySearch">
                                            <ProgressTemplate>
                                                Loading...
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:UpdatePanel runat="server" ID="updpnlgvHoldRemovedBySearch">
                                            <ContentTemplate>
                                                <asp:Button runat="server" ID="btnHoldRemovedByRefresh" ClientIDMode="Static" OnClick="btnHoldRemovedByRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                                <asp:GridView ID="gvHoldRemovedBySearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PO_htHoldRemovedByCode%>">
                                                            <ItemTemplate>
                                                                <a href="#" data-dismiss="modal" onclick="SetHoldRemovedByDetails('<%#Eval("EmployeeCode")%>','<%#Eval("tbl_UserId")%>');">
                                                                    <asp:Literal runat="server" ID="ltrgvDescription" Text='<%# Bind("FullName") %>'></asp:Literal>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PO_htHoldRemovedByName%>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvSuplierName" runat="server" Text='<%# Bind("FullName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PO_htHoldRemovedByGuid%>" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvHoldRemovedByGuid" runat="server" Text='<%# Bind("tbl_UserId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnHoldRemovedBySearch" />
                                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearHoldRemovedBySearch" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="modal-footer row" runat="server" id="divHoldRemovedByFooter">
                                    <div class="pull-left">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">
                                            <asp:Literal runat="server" ID="lblHoldRemovedByClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
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
                                        <asp:Literal runat="server" ID="ltrSupplierTitle" Text="<%$ Resources:GlobalResource, PO_ltrSupplierInformation %>"></asp:Literal>
                                    </span>
                                    </h4>
                                </div>
                                <div class="modal-body">

                                    <asp:UpdatePanel runat="server" ID="updpnlSupplier">
                                        <ContentTemplate>
                                            <asp:Panel runat="server" ID="pnlSupplier" DefaultButton="btnSupplierSearch">
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
                                        <div runat="server" id="divSupplierSearchSucces" visible="false" class="alert alert-success" role="alert">
                                            <asp:Label runat="server" ID="lblSupplierSearchSucces"></asp:Label>
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

                                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PO_htSupplierCode%>">
                                                            <ItemTemplate>
                                                                <a href="#" data-dismiss="modal" onclick="SetSupplierDetails('<%#Eval("SupplierCode")%>','<%#Eval("tbl_SupplierId")%>');">
                                                                    <asp:Literal runat="server" ID="ltrgvDescription" Text='<%# Bind("Name") %>'></asp:Literal>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PO_htSupplierName%>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvSuplierName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PO_htSupplierGuid%>" Visible="false">
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
                                <div class="modal-footer row" runat="server" id="divSupplierFooter">
                                    <div class="pull-left">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">
                                            <asp:Literal runat="server" ID="lblSupplierClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="modal fade" id="basicModalUserId_BuyerSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header" style="text-align: left;">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    <h4 class="modal-title" id="hdrModalUserId_BuyerTitle"><span>
                                        <asp:Literal runat="server" ID="ltrUserId_BuyerTitle" Text="<%$ Resources:GlobalResource, PO_ltrUserId_BuyerInformation %>"></asp:Literal>
                                    </span>
                                    </h4>
                                </div>
                                <div class="modal-body">

                                    <asp:UpdatePanel runat="server" ID="updpnlUserId_Buyer">
                                        <ContentTemplate>
                                            <asp:Panel runat="server" ID="pnlUserId_Buyer" DefaultButton="btnUserId_BuyerSearch">
                                                <div class="col-md-4 col-xs-5">
                                                    <div class="icon-addon addon-md">
                                                        <asp:TextBox runat="server" ID="txtUserId_BuyerSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                                        <a runat="server" id="btnHtmlUserId_BuyerSearch" onclick="CallUserId_BuyerSearch();" class="fa fa-search"></a>
                                                        <a runat="server" id="btnHtmlUserId_BuyerClose" visible="false" onclick="ClearUserId_BuyerSearch();" class="fa fa-close closex"></a>
                                                    </div>
                                                </div>
                                                <asp:Button runat="server" ID="btnUserId_BuyerSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnUserId_BuyerSearch_Click" formnovalidate="formnovalidate" />
                                                <asp:Button runat="server" ID="btnClearUserId_BuyerSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearUserId_BuyerSearch_Click" formnovalidate="formnovalidate" />

                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                    <div class="col-md-12 col-sm-12 colformstyle3">
                                        <div runat="server" id="divUserId_BuyerSearchError" visible="false" class="alert alert-danger" role="alert">
                                            <asp:Label runat="server" ID="lblUserId_BuyerSearchError"></asp:Label>
                                        </div>
                                        <div runat="server" id="divUserId_BuyerSearchSucces" visible="false" class="alert alert-success" role="alert">
                                            <asp:Label runat="server" ID="lblUserId_BuyerSearchSucces"></asp:Label>
                                        </div>
                                    </div>
                                    <div>
                                        <asp:UpdateProgress runat="server" ID="updProgUserId_BuyerData" AssociatedUpdatePanelID="updpnlgvUserId_BuyerSearch">
                                            <ProgressTemplate>
                                                Loading...
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:UpdatePanel runat="server" ID="updpnlgvUserId_BuyerSearch">
                                            <ContentTemplate>
                                                <asp:Button runat="server" ID="btnUserId_BuyerRefresh" ClientIDMode="Static" OnClick="btnUserId_BuyerRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                                <asp:GridView ID="gvUserId_BuyerSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PO_htUserId_BuyerCode%>">
                                                            <ItemTemplate>
                                                                <a href="#" data-dismiss="modal" onclick="SetUserId_BuyerDetails('<%#Eval("EmployeeCode")%>','<%#Eval("tbl_UserId")%>');">
                                                                    <asp:Literal runat="server" ID="ltrgvDescription" Text='<%# Bind("FullName") %>'></asp:Literal>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PO_htUserId_BuyerName%>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvSuplierName" runat="server" Text='<%# Bind("FullName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PO_htUserId_BuyerGuid%>" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvUserId_BuyerGuid" runat="server" Text='<%# Bind("tbl_UserId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnUserId_BuyerSearch" />
                                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearUserId_BuyerSearch" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="modal-footer row" runat="server" id="divUserId_BuyerFooter">
                                    <div class="pull-left">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">
                                            <asp:Literal runat="server" ID="lblUserId_BuyerClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="modal fade" id="basicModalCommentsSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header" style="text-align: left;">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    <h4 class="modal-title" id="hdrModalCommentsTitle"><span>
                                        <asp:Literal runat="server" ID="ltrCommentsTitle" Text="<%$ Resources:GlobalResource, PO_ltrCommentsInformation %>"></asp:Literal>
                                    </span>
                                    </h4>
                                </div>
                                <div class="modal-body">

                                    <asp:UpdatePanel runat="server" ID="updpnlComments">
                                        <ContentTemplate>
                                            <asp:Panel runat="server" ID="pnlComments" DefaultButton="btnCommentsSearch">
                                                <div class="col-md-4 col-xs-5">
                                                    <div class="icon-addon addon-md">
                                                        <asp:TextBox runat="server" ID="txtCommentsSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                                        <a runat="server" id="btnHtmlCommentsSearch" onclick="CallCommentsSearch();" class="fa fa-search"></a>
                                                        <a runat="server" id="btnHtmlCommentsClose" visible="false" onclick="ClearCommentsSearch();" class="fa fa-close closex"></a>
                                                    </div>
                                                </div>
                                                <asp:Button runat="server" ID="btnCommentsSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnCommentsSearch_Click" formnovalidate="formnovalidate" />
                                                <asp:Button runat="server" ID="btnClearCommentsSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearCommentsSearch_Click" formnovalidate="formnovalidate" />

                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                    <div class="col-md-12 col-sm-12 colformstyle3">
                                        <div runat="server" id="divCommentsSearchError" visible="false" class="alert alert-danger" role="alert">
                                            <asp:Label runat="server" ID="lblCommentsSearchError"></asp:Label>
                                        </div>
                                        <div runat="server" id="divCommentsSearchSucces" visible="false" class="alert alert-success" role="alert">
                                            <asp:Label runat="server" ID="lblCommentsSearchSucces"></asp:Label>
                                        </div>
                                    </div>
                                    <div>
                                        <asp:UpdateProgress runat="server" ID="updProgCommentsData" AssociatedUpdatePanelID="updpnlgvCommentsSearch">
                                            <ProgressTemplate>
                                                Loading...
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:UpdatePanel runat="server" ID="updpnlgvCommentsSearch">
                                            <ContentTemplate>
                                                <asp:Button runat="server" ID="btnCommentsRefresh" ClientIDMode="Static" OnClick="btnCommentsRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                                <asp:GridView ID="gvCommentsSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PO_htComments%>">
                                                            <ItemTemplate>
                                                                <a href="#" data-dismiss="modal" onclick="SetCommentsDetails('<%#Eval("Description")%>','<%#Eval("tbl_CommentsId")%>');">
                                                                    <asp:Literal runat="server" ID="ltrgvDescription" Text='<%# Bind("Description") %>'></asp:Literal>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        

                                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PO_htCommentsGuid%>" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvCommentsGuid" runat="server" Text='<%# Bind("tbl_CommentsId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnCommentsSearch" />
                                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearCommentsSearch" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="modal-footer row" runat="server" id="divCommentsFooter">
                                    <div class="pull-left">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">
                                            <asp:Literal runat="server" ID="lblCommentsClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
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
                                        <asp:Literal runat="server" ID="ltrCurrencyTitle" Text="<%$ Resources:GlobalResource, PO_ltrCurrencyInformation %>"></asp:Literal>
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

                                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PO_htCurrencyCode%>">
                                                            <ItemTemplate>
                                                                <a href="#" data-dismiss="modal" onclick="SetCurrencyDetails('<%#Eval("CurrencyName")%>','<%#Eval("tbl_CurrencyId")%>');">
                                                                    <asp:Literal runat="server" ID="ltrgvCurrencyCode" Text='<%# Bind("CurrencyCode") %>'></asp:Literal>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PO_htCurrencyName%>">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvCurrencyName" runat="server" Text='<%# Bind("CurrencyName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PO_htCurrencyGuid%>" Visible="false">
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

                </div>
            </div>
        
        </div>
    </div>
</asp:Content>


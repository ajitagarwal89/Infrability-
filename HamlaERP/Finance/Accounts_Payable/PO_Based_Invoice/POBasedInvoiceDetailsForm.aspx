<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="POBasedInvoiceDetailsForm.aspx.cs" Inherits="Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceDetailsForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Accounts_Payable_JS/PO_Based_Invoice_JS/POBasedInvoiceDetailsForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, POBasedInvoiceDetails_ltrInformation%>"></asp:Literal></h5>
                        </div>
                        
                         <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblPOBasedInvoiceId" Text="<%$ Resources:GlobalResource, POBasedInvoiceDetails_lblPOBasedInvoiceId %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtlPOBasedInvoice" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon3">
                                    <a href="#" data-toggle="modal" data-target="#basicModallPOBasedInvoiceSearch" data-keyboard="false" data-backdrop="static" onclick="CallPOBasedInvoiceRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtlPOBasedInvoiceGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblPOId" Text="<%$ Resources:GlobalResource, POBasedInvoiceDetails_lblPOId %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtPO" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon4">
                                    <a href="#" data-toggle="modal" data-target="#basicModalPOSearch" data-keyboard="false" data-backdrop="static" onclick="CallPORefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPOGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblLocationId" Text="<%$ Resources:GlobalResource,  POBasedInvoiceDetails_lblLocationId %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtLocation" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon_Cuurency">
                                    <a href="#" data-toggle="modal" data-target="#basicModalLocationSearch" data-keyboard="false" data-backdrop="static" onclick="CallLocationRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtLocationGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                        
                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblUOM" Text="<%$ Resources:GlobalResource, POBasedInvoiceDetails_lblUOM%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtUOM" ClientIDMode="Static"  class="form-control" onkeypress="return isAlphaKey(this);" MaxLength="50" placeholder="" required="required"></asp:TextBox>
                        </div>

                           <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource, POBasedInvoiceDetails_lblDescription%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDescription" ClientIDMode="Static" onkeypress="return isAddress(this);" MaxLength="50" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblQuantityInvoice" Text="<%$ Resources:GlobalResource, POBasedInvoiceDetails_lblQuantityInvoice%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtQuantityInvoice" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control"  placeholder="" required="required"></asp:TextBox>
                        </div>

                        
                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblUnitCost" Text="<%$ Resources:GlobalResource, POBasedInvoiceDetails_lblUnitCost%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtUnitCost" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                           <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblExtendedCost" Text="<%$ Resources:GlobalResource, POBasedInvoiceDetails_lblExtendedCost%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtExtendedCost" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9"  class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>



                    </div>
                </div>
            </div>

           <div class="modal fade" id="basicModallPOBasedInvoiceSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalPOBasedInvoiceTitle"><span>
                        <asp:Literal runat="server" ID="Literal2" Text="<%$ Resources:GlobalResource, POBasedInvoiceDetails_ltrPOBasedInvoiceTitle %>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,POBasedInvoiceDetails_htPOBasedInvoiceCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetPOBasedInvoiceDetails('<%#Eval("ReceiptNumber")%>','<%#Eval("tbl_POBasedInvoiceId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvPOBasedInvoiceCode" Text='<%# Bind("ReceiptNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="<%$Resources:GlobalResource, POBasedInvoiceDetails_htPOBasedInvoiceGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPOBasedInvoiceId" runat="server" Text='<%# Bind("tbl_POBasedInvoiceId") %>'></asp:Label>
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

            <div class="modal fade" id="basicModalLocationSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalLocationTitle"><span>
                        <asp:Literal runat="server" ID="Literal1" Text="<%$ Resources:GlobalResource, POBasedInvoiceDetails_ltrLocationTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlLocationSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlLocationSearch" DefaultButton="btnLocationSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtLocationSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlLocationSearch" onclick="CallLocationSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlLocationClose" visible="false" onclick="ClearLocationSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnLocationSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnLocationSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearLocationSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearLocationSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divLocationSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblLocationSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divLocationSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblLocationSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgData" AssociatedUpdatePanelID="updpnlgvLocationSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvLocationSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnLocationRefresh" ClientIDMode="Static" OnClick="btnLocationRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvLocationSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,POBasedInvoiceDetails_htLocationCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetLocationDetails('<%#Eval("Description")%>','<%#Eval("tbl_LocationId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvLocationCode" Text='<%# Bind("LocationCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,POBasedInvoiceDetails_htDescription%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLocationName" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:GlobalResource, POBasedInvoiceDetails_htLocationGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLocationId" runat="server" Text='<%# Bind("tbl_LocationId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnLocationSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearLocationSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrLocationClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
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
                        <asp:Literal runat="server" ID="Literal3" Text="<%$ Resources:GlobalResource, POBasedInvoiceDetails_ltrPOTitle %>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,POBasedInvoiceDetails_htPONumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetPODetails('<%#Eval("PONumber")%>','<%#Eval("tbl_POId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvPOCode" Text='<%# Bind("PONumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="<%$Resources:GlobalResource, POBasedInvoiceDetails_htPOGuid %>" Visible="false">
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

        </div>
    </div>



</asp:Content>


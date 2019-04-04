<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PaymentFromCustomerApplyForm.aspx.cs" Inherits="Finance_Bank_Accounting_Payment_From_Customers_PaymentFromCustomerApplyForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Bank_Accounting_JS/Payment_From_Customer/PaymentFromCustomerApplyForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, PaymentFromCustomerApply_ltrInformation%>"></asp:Literal></h5>
                        </div>
                     
                        <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblPaymentFromCustomerId" Text="<%$ Resources:GlobalResource, PaymentFromCustomerApply_lblPaymentFromCustomerId%>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtPaymentFromCustomer" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon">
                                    <a href="#" data-toggle="modal" data-target="#basicModalPaymentFromCustomerSearch" data-keyboard="false" data-backdrop="static" onclick="CallPaymentFromCustomerRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPaymentFromCustomerGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                          <div class="form-group col-md-4 col-sm-4">
                                <asp:RadioButton ID="rdbtnCustomerInvoice" runat="server" CausesValidation="false" GroupName="grID" AutoPostBack="true" Text="<%$ Resources:GlobalResource, DownPaymentFromCustomerApply_rdbCustomerInvoice%>" OnCheckedChanged="rdbtnCustomerInvoice_CheckedChanged" />
                                <asp:RadioButton ID="RdbtnCustomerInvoiceProcess" runat="server" CausesValidation="false" GroupName="grID" AutoPostBack="true" Text="<%$ Resources:GlobalResource, DownPaymentFromCustomerApply_rdbCustomerInvoiceProcess%>" OnCheckedChanged="RdbtnCustomerInvoiceProcess_CheckedChanged" />
                          </div>


                          <div id="divCustomerInvoice" visible="false" runat="server" class="form-group col-md-4 col-sm-4">
                                <div>
                                    <asp:Label runat="server" ID="lblApplyToDocument" Text="<%$ Resources:GlobalResource, PaymentFromCustomerApply_lblApplyToDocument%>"></asp:Label>
                                </div>

                                <div class="input-group">
                                    <asp:TextBox ID="txtApplyToDocument" ReadOnly="true" ClientIDMode="Static" AutoPostBack="true" runat="server" CssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon lookup" id="sizing-addon 2">
                                         <a href="#" data-toggle="modal" data-target="#basicModalApplyToDocumentCustomerInvoiceSearch" data-keyboard="false" data-backdrop="static" onclick="CallCustomerInvoiceRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                    </span>

                                    <asp:TextBox ID="txtApplyToDocumentGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                                </div>
                            </div>

                          <div id="divCustomerInvoiceProcess" visible="false" runat="server" class="form-group col-md-4 col-sm-4">
                                <div>
                                    <asp:Label runat="server" ID="lblApplytoDocumentCIP" Text="<%$ Resources:GlobalResource, PaymentFromCustomerApply_lblApplytoDocument%>"></asp:Label>
                                </div>

                                <div class="input-group">
                                    <asp:TextBox ID="txtApplyotDocumentCIP" ReadOnly="true" ClientIDMode="Static" AutoPostBack="true" runat="server" CssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon lookup" id="sizing-addon 3">
                                         <a href="#" data-toggle="modal" data-target="#basicModalApplyToDocumentCustomerInvoiceProcessSearch" data-keyboard="false" data-backdrop="static" onclick="CallCustomerInvoiceProcessRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                    </span>

                                    <asp:TextBox ID="txtApplyotDocumentCIPGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                                </div>
                            </div>


                            <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDueDate" Text="<%$ Resources:GlobalResource, PaymentFromCustomerApply_lblDueDate%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDueDate" TextMode="Date" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                        
                         <div class="form-group col-md-4 col-sm-4">
                       <asp:Label runat="server" ID="lblRemainingAmount" Text="<%$ Resources:GlobalResource, PaymentFromCustomerApply_lblRemainingAmount%>"></asp:Label>
                        <asp:TextBox runat="server" ID="txtRemainingAmount" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                    </div>

                        
                      <div class="form-group col-md-4 col-sm-4">

                        <asp:Label runat="server" ID="lblApplyAmount" Text="<%$ Resources:GlobalResource, PaymentFromCustomerApply_lblApplyAmount%>"></asp:Label>
                        <asp:TextBox runat="server" ID="txtApplyAmount" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                    </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblopt_Type" Text="<%$ Resources:GlobalResource, PaymentFromCustomerApply_lblopt_Type %>"></asp:Label>
                            <asp:DropDownList ID="ddloptType" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:DropDownList>
                        </div>
                        
                    <div class="form-group col-md-4 col-sm-4">

                        <asp:Label runat="server" ID="lblOrignalDocumentAmount" Text="<%$ Resources:GlobalResource, PaymentFromCustomerApply_lblOrignalDocumentAmount%>"></asp:Label>
                        <asp:TextBox runat="server" ID="txtOrignalDocumentAmount" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                    </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDiscountDate" Text="<%$ Resources:GlobalResource, PaymentFromCustomerApply_lblDiscountDate%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDiscountDate" TextMode="Date" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                                               
                          <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCurrencyId_ApplyToCurrency" Text="<%$ Resources:GlobalResource, PaymentFromCustomerApply_lblCurrencyId %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtCurrencyId_ApplyToCurrency" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon_Cuurency">
                                    <a href="#" data-toggle="modal" data-target="#basicModalCurrencySearch" data-keyboard="false" data-backdrop="static" onclick="CallCurrencyRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtCurrencyId_ApplyToCurrencyGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                     
                </div>
            </div>

                
                            <div class="form-group col-md-12" style="background-color: #f6f6f6">
                                <h5>
                                    <asp:Literal runat="server" ID="ltrDownPaymentFromCustomer" Text="<%$ Resources:GlobalResource, PaymentFromCustomerApply_lblPaymentFromCustomer%>"></asp:Literal></h5>
                            </div>

                            <div id="divdownPaymentfromCustomer" runat="server" class="form-group col-md-12 col-sm-12">
                                <%--<h3 class="hepad">
                                <asp:Label runat="server" ID="lblDownPaymentFromCustomerId" Text="<%$ Resources:GlobalResource, DownPaymentFromCustomerApply_lblDownPaymentFromCustomer %>"></asp:Label>
                            </h3>--%>
                                <div>
                                    <div class="form-group col-md-4 col-sm-4">
                                        <asp:Label runat="server" ID="lblCustomerId" Text="<%$ Resources:GlobalResource, PaymentFromCustomerApply_lblCustomerId%>"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtCustomerID" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-4 col-sm-4">
                                        <asp:Label runat="server" ID="lblCustomerName" Text="<%$ Resources:GlobalResource, PaymentFromCustomerApply_lblCustomerName%>"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtCustomerName" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-4 col-sm-4">
                                        <asp:Label runat="server" ID="lblType1" Text="<%$ Resources:GlobalResource, PaymentFromCustomerApply_lblType%>"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtType" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-4 col-sm-4">
                                        <asp:Label runat="server" ID="lblCurrency" Text="<%$ Resources:GlobalResource, PaymentFromCustomerApply_lblCurrency%>"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtCurrencyID" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-4 col-sm-4">
                                        <asp:Label runat="server" ID="lblDocumentNo" Text="<%$ Resources:GlobalResource, PaymentFromCustomerApply_lblDocumentNo%>"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtDocumentNumber" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-4 col-sm-4">
                                        <asp:Label runat="server" ID="lblOrignalAmount" Text="<%$ Resources:GlobalResource, PaymentFromCustomerApply_lblOrignalAmount%>"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtOrignalAmount" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-4 col-sm-4">
                                        <asp:Label runat="server" ID="lblApplyDate" Text="<%$ Resources:GlobalResource, PaymentFromCustomerApply_lblApplyDate%>"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtApplydate" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-4 col-sm-4">
                                        <asp:Label runat="server" ID="lblUnappliedAmount" Text="<%$ Resources:GlobalResource, PaymentFromCustomerApply_lblUnappliedAmount%>"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtUnappliedAmount" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                                    </div>

                                </div>
                            </div>


                            <div class="form-group col-md-12 col-sm-12">
                                <asp:DataGrid runat="server" ClientIDMode="Static" Font-Size="10pt" ID="gvData" AutoGenerateColumns="False" Width="100%" GridLines="None" CssClass="table table-hover" CellPadding="4" ForeColor="#333333">
                                    <AlternatingItemStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundColumn DataField="tbl_PaymentFromCustomerApplyId" Visible="false"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomerApply_htPaymentFromCustomer%>" DataField="tbl_Customer"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomerApply_htDueDate%>" DataField="DueDate"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomerApply_htApplyAmount%>" DataField="ApplyAmount"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomerApply_htopt_Type%>" DataField="Type"></asp:BoundColumn>                         
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
      

            <div class="modal fade" id="basicModalPaymentFromCustomerSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalPaymentFromCustomerTitle"><span>
                        <asp:Literal runat="server" ID="ltrPaymentFromCustomerTitle" Text="<%$ Resources:GlobalResource, PaymentFromCustomerApply_ltrPaymentFromCustomerTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlPaymentFromCustomerSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlPaymentFromCustomerSearch" DefaultButton="btnPaymentFromCustomerSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtPaymentFromCustomerSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlPaymentFromCustomerSearch" onclick="CallPaymentFromCustomerSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlPaymentFromCustomerClose" visible="false" onclick="ClearPaymentFromCustomerSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnPaymentFromCustomerSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnPaymentFromCustomerSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearPaymentFromCustomerSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearPaymentFromCustomerSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divPaymentFromCustomerSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblPaymentFromCustomerSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divPaymentFromCustomerSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblPaymentFromCustomerSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgPaymentFromCustomerData" AssociatedUpdatePanelID="updpnlgvPaymentFromCustomerSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvPaymentFromCustomerSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnPaymentFromCustomerRefresh" ClientIDMode="Static" OnClick="btnPaymentFromCustomerRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvPaymentFromCustomerSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                       <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomerApply_htCustomerName%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetPaymentFromCustomerDetails('<%#Eval("CustomerName")%>','<%#Eval("tbl_PaymentFromCustomerId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCustomerCode" Text='<%# Bind("CustomerName") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomerApply_htCustomerGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgv_CustomerId" runat="server" Text='<%# Bind("tbl_PaymentFromCustomerId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPaymentFromCustomerSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearPaymentFromCustomerSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrPaymentFromCustomerClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
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
                        <asp:Literal runat="server" ID="ltrCurrencyTitle" Text="<%$ Resources:GlobalResource, PaymentFromCustomerApply_ltrCurrencyInrformation %>"></asp:Literal>
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

                                           <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PaymentFromCustomerApply_htCurrencyCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCurrencyDetails('<%#Eval("CurrencyName")%>','<%#Eval("tbl_CurrencyId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCurrencyCode" Text='<%# Bind("CurrencyCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomerApply_htCurrencyName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCurrencyName" runat="server" Text='<%# Bind("CurrencyName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomerApply_htCurrencyGuid%>" Visible="false">
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
      
        <div class="modal fade" id="basicModalApplyToDocumentCustomerInvoiceSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalCustomerInvoiceTitle"><span>
                        <asp:Literal runat="server" ID="ltrCustomerInvoiceTitle" Text="<%$ Resources:GlobalResource, PaymentFromCustomerApply_ltrCustomerInvoice %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlCustomerInvoiceSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlCustomerInvoiceSearch" DefaultButton="btnCustomerInvoiceSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtCustomerInvoiceSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlCustomerInvoiceSearch" onclick="CallCustomerInvoiceSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlCustomerInvoiceClose" visible="false" onclick="ClearCustomerInvoiceSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnCustomerInvoiceSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnCustomerInvoiceSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearCustomerInvoiceSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearCustomerInvoiceSearch_Click" formnovalidate="formnovalidate" />
                                
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divCustomerInvoiceSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblCustomerInvoiceSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divCustomerInvoiceSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblCustomerInvoiceSearchSuccess"></asp:Label>
                        </div>
                    </div>

                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgData" AssociatedUpdatePanelID="updpnlgvCustomerInvoiceSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvCustomerInvoiceSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnCustomerInvoiceRefresh"  ClientIDMode="Static" OnClick="btnCustomerInvoiceRefresh_Click" style="display:none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvCustomerInvoiceSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PaymentFromCustomerApply_htCustomerPONumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCustomerInvoiceDetails('<%#Eval("DocumentNumber")%>','<%#Eval("tbl_CustomerInvoiceId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCustomerInvoiceCode" Text='<%# Bind("CustomerPONumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PaymentFromCustomerApply_htDocumentNumber%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCustomerInvoiceName" runat="server" Text='<%# Bind("DocumentNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PaymentFromCustomerApply_htCustomerInvoiceGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCustomerInvoiceGuid" runat="server" Text='<%# Bind("tbl_CustomerInvoiceId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnCustomerInvoiceSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearCustomerInvoiceSearch" />                                
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divCustomerInvoiceFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrCustomerInvoiceClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

         <div class="modal fade" id="basicModalApplyToDocumentCustomerInvoiceProcessSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalCustomerInvoiceProcessTitle"><span>
                        <asp:Literal runat="server" ID="ltrCustomerInvoiceProcessTitle" Text="<%$ Resources:GlobalResource, PaymentFromCustomerApply_ltrCustomerInvoiceProcess %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlCustomerInvoiceProcessSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlCustomerInvoiceProcessSearch" DefaultButton="btnCustomerInvoiceProcessSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtCustomerInvoiceProcessSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlCustomerInvoiceProcessSearch" onclick="CallCustomerInvoiceProcessSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlCustomerInvoiceProcessClose" visible="false" onclick="ClearCustomerInvoiceProcessSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnCustomerInvoiceProcessSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnCustomerInvoiceProcessSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearCustomerInvoiceProcessSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearCustomerInvoiceProcessSearch_Click" formnovalidate="formnovalidate" />
                                
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divCustomerInvoiceProcessSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblCustomerInvoiceProcessSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divCustomerInvoiceProcessSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblCustomerInvoiceProcessSearchSuccess"></asp:Label>
                        </div>
                    </div>

                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgData1" AssociatedUpdatePanelID="updpnlgvCustomerInvoiceProcessSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvCustomerInvoiceProcessSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnCustomerInvoiceProcessRefresh"  ClientIDMode="Static" OnClick="btnCustomerInvoiceProcessRefresh_Click" style="display:none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvCustomerInvoiceProcessSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomerApply_htDocumentNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCustomerInvoiceProcessDetails('<%#Eval("DocumentNumber")%>','<%#Eval("tbl_CustomerInvoiceProcessId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCustomerInvoiceProcessCode" Text='<%# Bind("PONumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomerApply_htPONumber%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCustomerInvoiceName" runat="server" Text='<%# Bind("PONumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomerApply_htCustomerInvoiceProcessGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCustomerInvoiceProcessGuid" runat="server" Text='<%# Bind("tbl_CustomerInvoiceProcessId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnCustomerInvoiceProcessSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearCustomerInvoiceProcessSearch" />                                
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div3">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrCIPClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>


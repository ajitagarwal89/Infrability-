<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CustomerInvoiceDistributionForm.aspx.cs" Inherits="Finance_Accounts_Receivable_Customer__Invoice__With_Sales_Order_CustomerInvoiceDistribution" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Accounts_Receivable_JS/Customer%20_Invoice_(With_Sales_Order)_JS/CustomerInvoiceDistributionForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrCustomerInvoiceDistribution" Text="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_ltrInformation%>"></asp:Literal></h5>
                        </div>


                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCustomerInvoiceId" Text="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_lblCustomerInvoiceId%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtCustomerInvoiceId" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control" OnTextChanged="txtCustomerInvoiceId_TextChanged"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon">
                                    <a href="#" data-toggle="modal" data-target="#basicModalCustomerInvoiceIdSearch" data-keyboard="false" data-backdrop="static" onclick="CallCustomerInvoiceIdRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>
                                <asp:TextBox ID="txtCustomerInvoiceIdGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblGLAccountId" Text="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_lblGLAccountId%>"></asp:Label>
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
                            <asp:Label runat="server" ID="lblGLAccountType" Text="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_lblGLAccountType%>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_GLAccountType" OnSelectedIndexChanged="ddlOpt_GLAccountType_SelectedIndexChanged" runat="server" ClientIDMode="Static" AutoPostBack="true" class="form-control" placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4" id="divDedit1" runat="server">
                            <asp:Label runat="server" ID="lblDebit" Text="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_lblDebit%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDebit" ClientIDMode="Static" Text="" AutoPostBack="true" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4" id="divCredit1" runat="server">
                            <asp:Label runat="server" ID="lblCredit" Text="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_lblCredit%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtCredit" ClientIDMode="Static" Text="" AutoPostBack="true" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4" id="divDedit2" runat="server">
                            <asp:Label runat="server" ID="lblOriginatingDebit" Text="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_lblOriginatingDebit%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtOriginatingDebit" Text="" AutoPostBack="true"  ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4" id="divCredit2" runat="server">
                            <asp:Label runat="server" ID="lblOriginatingCredit" Text="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_lblOriginatingCredit%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtOriginatingCredit" Text="" AutoPostBack="true" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>   
                          <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_lblDescription%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" onkeypress="return isAddress(this);" MaxLength="50" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDistributionReference" Text="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_lblDistributionReference%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDistributionReference" ClientIDMode="Static" onkeypress="return isAddress(this);" MaxLength="50" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                    <div id="divPOBasedInvoiceDistribution" runat="server" >


                 <div class="form-group col-md-12" style="background-color: #f6f6f6">
                            <h5>
                                <asp:Literal runat="server" ID="ltrCustomerInvoiceDistribution2" Text="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_ltrDetails%>"></asp:Literal></h5>
                        </div>
                        <div class="form-group col-md-4 col-sm-4" id="divCustomerCode" runat="server" >
                            <asp:Label runat="server" ID="lblSupplierCode" Text="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_lblSupplierCode%>"></asp:Label>
                           <asp:TextBox ID="txtsupplierCode"  runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                        </div>   
                                    
                <div class="form-group col-md-4 col-sm-4" id="divCustomerName" runat="server" >
                            <asp:Label runat="server" ID="lblSupplierName" Text="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_lblSupplierName%>"></asp:Label>
                           <asp:TextBox ID="txtSupplierName"  runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                        </div>
                <div class="form-group col-md-4 col-sm-4" id="divReceiptnumber" runat="server" >
                            <asp:Label runat="server" ID="lblReceiptnumber" Text="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_lblReceiptNumber %>"></asp:Label>
                           <asp:TextBox ID="txtReceiptnumber"  runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                        </div>
                <div class="form-group col-md-4 col-sm-4" id="divDocumentNumber" runat="server" >
                    <asp:Label runat="server" ID="lblDocumentNumber" Text="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_lblDocumentNumber %>"></asp:Label>
                     <asp:TextBox ID="txtDocumentNumber"  runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                   </div>
                <div class="form-group col-md-4 col-sm-4" id="divDocumentType" runat="server" >
                            <asp:Label runat="server" ID="lblDocumentType" Text="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_lblDocumentType %>"></asp:Label>
                           <asp:TextBox ID="txtDocumentType"  runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                        </div>
                <div class="form-group col-md-4 col-sm-4" id="divCurrency" runat="server" >
                    <asp:Label runat="server" ID="lblCurrencyName" Text="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_lblCurrencyName %>"></asp:Label>
                     <asp:TextBox ID="txtCurrencyName"  runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                 </div>
                <div class="form-group col-md-4 col-sm-4" id="divfunctionalAmount" runat="server" >
                    <asp:Label runat="server" ID="lblFunctionalAmount" Text="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_lblFunctionalAmount %>"></asp:Label>
                     <asp:TextBox ID="txtFunctionalAmount"  runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                 </div>
                <div class="form-group col-md-4 col-sm-4" id="divOrginatingAmount" runat="server" >
                    <asp:Label runat="server" ID="lblOrginatingAmount" Text="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_lblOrginationAmount %>"></asp:Label>
                     <asp:TextBox ID="txtOrginatingAmount"  runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                 </div>
                </div>
            </div>

             <div class="form-group col-md-12 col-sm-12">
                      <asp:DataGrid runat="server" ClientIDMode="Static" Font-Size="10pt" ID="gvData" AutoGenerateColumns="False" Width="100%" GridLines="None" CssClass="table table-hover" CellPadding="4" ForeColor="#333333">
                              <AlternatingItemStyle BackColor="White" />
                               <Columns>                                       
                                        <asp:BoundColumn DataField="tbl_CustomerInvoiceDistributionId" Visible="false"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_ltrCustomerInvoice%>" DataField="tbl_CustomerInvoice"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_ltrGLAccountId%>" DataField="tbl_GLAccount"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_ltrDescription%>" DataField="Description"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_ltrDistributionReference%>" DataField="DistributionReference"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_ltrGLAccountType%>" DataField="GLAccountType"></asp:BoundColumn>
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

     <div class="modal fade" id="basicModalCustomerInvoiceIdSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalCustomerInvoiceIdTitle"><span>
                        <asp:Literal runat="server" ID="ltr_CustomerInvoiceId_information" Text="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_ltrCustomerInvoiceIdInformation %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlCustomerInvoiceIdSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlCustomerInvoiceIdSearch" DefaultButton="btnCustomerInvoiceIdSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtCustomerInvoiceIdSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlCustomerInvoiceIdSearch" onclick="CallCustomerInvoiceIdSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlCustomerInvoiceIdClose" visible="false" onclick="ClearCustomerInvoiceIdSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnCustomerInvoiceIdSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnCustomerInvoiceIdSearch_Click" formnovalidate="formnovalidate"/>
                                <asp:Button runat="server" ID="btnClearCustomerInvoiceIdSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearCustomerInvoiceIdSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divCustomerInvoiceIdSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblCustomerInvoiceIdSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divCustomerInvoiceIdSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="CustomerInvoiceIdSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgCustomerInvoiceIdData" AssociatedUpdatePanelID="updpnlgvCustomerInvoiceIdSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvCustomerInvoiceIdSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnCustomerInvoiceIdRefresh" ClientIDMode="Static" OnClick="btnCustomerInvoiceIdRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvCustomerInvoiceIdSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_ltrDocumentNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCustomerInvoiceIdDetails('<%#Eval("CustomerPONumber")%>','<%#Eval("tbl_CustomerInvoiceId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCustomerInvoiceIdType" Text='<%# Bind("DocumentNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_htCustomerPONumber%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCustomerInvoiceIdName" runat="server" Text='<%# Bind("CustomerPONumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_htCustomerInvoiceIdGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCustomerInvoiceIdGuid" runat="server" Text='<%# Bind("tbl_CustomerInvoiceId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnCustomerInvoiceIdSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearCustomerInvoiceIdSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrCustomerInvoiceIdClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
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
                        <asp:Literal runat="server" ID="ltrGLAccountTitle" Text="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_ltrGLAccount%>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_htAccountNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetGLAccountDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvGLAccountCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, CustomerInvoiceDistribution_htGLAccountGuid%>" Visible="false">
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

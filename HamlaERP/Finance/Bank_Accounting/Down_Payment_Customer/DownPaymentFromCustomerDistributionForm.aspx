<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DownPaymentFromCustomerDistributionForm.aspx.cs" Inherits="Finance_Bank_Accounting_Customer_Down_Payment_DownPaymentFromCustomerDistributionForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Bank_Accounting_JS/Customer_Down_Payment_JS/DownPaymentFromCustomerDistributionForm.js"></script>
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
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-success" OnClick="btnBack_Click" Text="<%$ Resources:GlobalResource, btnBack%>"  formnovalidate="formnovalidate" />
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
                                <asp:Literal runat="server" ID="ltrDownPaymentFromCustomerDistribution" Text="<%$ Resources:GlobalResource, DownPaymentFromCustomerDistribution_ltrinformation%>"></asp:Literal></h5>
                        </div>
                       
                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCustomerId" Text="<%$ Resources:GlobalResource, DownPaymentFromCustomerDistribution_lblCustomerId %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtCustomer" ReadOnly="true" ClientIDMode="Static" runat="server"  CssClass="form-control " OnTextChanged="txtCustomer_TextChanged"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addonCustomer">
                                    <a href="#" data-toggle="modal" data-target="#basicModalCustomerSearch" data-keyboard="false" data-backdrop="static" onclick="CallCustomerRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtCustomerGuid"  runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblGLAccountId" Text="<%$ Resources:GlobalResource, DownPaymentFromCustomerDistribution_lblGLAccountId%>"></asp:Label>
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
                            <asp:Label runat="server" ID="lblOptionType" Text="<%$ Resources:GlobalResource,DownPaymentFromCustomerDistribution_lblOptionType  %>"></asp:Label>
                            <asp:DropDownList ID="ddlOptionType"   runat="server" ClientIDMode="Static" class="form-control" required="required"  AutoPostBack="true"  OnSelectedIndexChanged="ddlOptionType_SelectedIndexChanged" ></asp:DropDownList>
                        </div>
                         <div class="form-group col-md-4 col-sm-4" id="divDebit" runat="server" >
                            <asp:Label runat="server" ID="lblDebit" Text="<%$ Resources:GlobalResource,DownPaymentFromCustomerDistribution_lblDebit  %>"></asp:Label>
                           <asp:TextBox ID="txtDebit"  runat="server" ClientIDMode="Static" class="form-control"></asp:TextBox>
                        </div>
                          <div class="form-group col-md-4 col-sm-4" id="divOriginatingDebit" runat="server" >
                            <asp:Label runat="server" ID="lblOriginatingDebit" Text="<%$ Resources:GlobalResource,DownPaymentFromCustomerDistribution_lblOriginatingDebit %>"></asp:Label>
                           <asp:TextBox ID="txtOriginatingDebit"  runat="server" ClientIDMode="Static" class="form-control" ></asp:TextBox>
                        </div>
                         <div class="form-group col-md-4 col-sm-4" id="divCredit" runat="server" >
                            <asp:Label runat="server" ID="lblCredit" Text="<%$ Resources:GlobalResource,DownPaymentFromCustomerDistribution_lblCredit %>"></asp:Label>
                           <asp:TextBox ID="txtCredit"  runat="server" ClientIDMode="Static" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4" id="divOriginatingCredit" runat="server" >
                            <asp:Label runat="server" ID="lblOriginatingCredit" Text="<%$ Resources:GlobalResource,DownPaymentFromCustomerDistribution_lblOriginatingCredit %>"></asp:Label>
                           <asp:TextBox ID="txtOriginatingCredit"  runat="server" ClientIDMode="Static" class="form-control" ></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource,DownPaymentFromCustomerDistribution_lblDescription%>"></asp:Label>
                           <asp:TextBox ID="txtDescription" TextMode="MultiLine"  runat="server" ClientIDMode="Static" class="form-control" required="required"></asp:TextBox>
                        </div>
                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDistributionReference" Text="<%$ Resources:GlobalResource,DownPaymentFromCustomerDistribution_lblDistributionReference%>"></asp:Label>
                           <asp:TextBox ID="txtDistributionReference"  runat="server" ClientIDMode="Static" class="form-control" required="required"></asp:TextBox>
                        </div>
                         <div id="divDownPaymentFromCustomerDistribution" runat="server" >
                 <div class="form-group col-md-12" style="background-color: #f6f6f6">
                            <h5>
                                <asp:Literal runat="server" ID="ltrCustomerDistribution" Text="<%$ Resources:GlobalResource, DownPaymentFromCustomerDistribution_ltrDownPaymentFromCustomerDetails%>"></asp:Literal></h5>
                        </div>
                <div class="form-group col-md-4 col-sm-4" id="divCustomerCode" runat="server" >
                            <asp:Label runat="server" ID="lblCustomerCode" Text="<%$ Resources:GlobalResource,DownPaymentFromCustomerDistribution_lblCustomerCode%>"></asp:Label>
                           <asp:TextBox ID="txtCustomerCode"  runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                        </div>                   
                <div class="form-group col-md-4 col-sm-4" id="divCustomerName" runat="server" >
                            <asp:Label runat="server" ID="lblCustomerName" Text="<%$ Resources:GlobalResource, DownPaymentFromCustomerDistribution_lblCustomerName %>"></asp:Label>
                           <asp:TextBox ID="txtCustomerName"  runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                        </div>
                <div class="form-group col-md-4 col-sm-4" id="divReceiptnumber" runat="server" >
                            <asp:Label runat="server" ID="lblReceiptnumber" Text="<%$ Resources:GlobalResource, DownPaymentFromCustomerDistribution_lblReceiptNumber %>"></asp:Label>
                           <asp:TextBox ID="txtReceiptnumber"  runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                        </div>
                <div class="form-group col-md-4 col-sm-4" id="divDocumentNumber" runat="server" >
                    <asp:Label runat="server" ID="lblDocumentNumber" Text="<%$ Resources:GlobalResource, DownPaymentFromCustomerDistribution_lblDocumentNumber %>"></asp:Label>
                     <asp:TextBox ID="txtDocumentNumber"  runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                   </div>
                <div class="form-group col-md-4 col-sm-4" id="divDocumentType" runat="server" >
                            <asp:Label runat="server" ID="lblDocumentType" Text="<%$ Resources:GlobalResource, DownPaymentFromCustomerDistribution_lblDocumentType %>"></asp:Label>
                           <asp:TextBox ID="txtDocumentType"  runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                        </div>
                <div class="form-group col-md-4 col-sm-4" id="divCurrency" runat="server" >
                    <asp:Label runat="server" ID="lblCurrencyName" Text="<%$ Resources:GlobalResource, DownPaymentFromCustomerDistribution_lblCurrencyName %>"></asp:Label>
                     <asp:TextBox ID="txtCurrencyName"  runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                 </div>
                <div class="form-group col-md-4 col-sm-4" id="divfunctionalAmount" runat="server" >
                    <asp:Label runat="server" ID="lblFunctionalAmount" Text="<%$ Resources:GlobalResource, DownPaymentFromCustomerDistribution_lblFunctionalAmount %>"></asp:Label>
                     <asp:TextBox ID="txtFunctionalAmount"  runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                 </div>
                <div class="form-group col-md-4 col-sm-4" id="divOrginatingAmount" runat="server" >
                    <asp:Label runat="server" ID="lblOrginatingAmount" Text="<%$ Resources:GlobalResource,DownPaymentFromCustomerDistribution_lblOrginationAmount %>"></asp:Label>
                     <asp:TextBox ID="txtOrginatingAmount"  runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                 </div>
               
             <asp:DataGrid runat="server" ClientIDMode="Static" Font-Size="10pt" ID="gvData" AutoGenerateColumns="False" Width="100%" GridLines="None" CssClass="table table-hover" CellPadding="4" ForeColor="#333333">
                            <AlternatingItemStyle BackColor="White" />
                            <Columns>
                                  <asp:BoundColumn DataField="tbl_DownPaymentFromCustomerId" Visible="false"></asp:BoundColumn>
                                  <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, DownPaymentFromCustomerDistribution_htReceiptNumber%>" DataField="tbl_DownPaymentFromCustomer"></asp:BoundColumn>
                                  <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, DownPaymentFromCustomerDistribution_htGLAccount %>" DataField="tbl_GLAccount"></asp:BoundColumn>
                                 <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource,   DownPaymentFromCustomerDistribution_htMode%>" DataField="Type"></asp:BoundColumn>
                                 <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, DownPaymentFromCustomerDistribution_htApplyDate %>" DataField="ApplyDate"></asp:BoundColumn>
                                  <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, DownPaymentFromCustomer_htDebit %>" DataField="Debit"></asp:BoundColumn>
                                  <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, DownPaymentFromCustomer_htOriginatingDebit %>" DataField="OriginatingDebit"></asp:BoundColumn>
                                  <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, DownPaymentFromCustomer_htCredit %>" DataField="Credit"></asp:BoundColumn>
                                  <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, DownPaymentFromCustomer_htOriginatingCredit %>" DataField="OriginatingCredit"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, DownPaymentFromCustomer_htTotalAmount %>" DataField="TotalAmount"></asp:BoundColumn>
                                  <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, DownPaymentFromCustomer_htDistributionReference%>" DataField="DistributionReference"></asp:BoundColumn>
                                
                               
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

       <div class="modal fade" id="basicModalCustomerSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalCustomerTitle"><span>
                        <asp:Literal runat="server" ID="ltr_CustomerInfomation" Text="<%$ Resources:GlobalResource, DownPaymentFromCustomerDistribution_ltr_CustomerInfomation %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlCustomerSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlCustomerSearch" DefaultButton="btnCustomerSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtCustomerSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlCustomerSearch" onclick="CallCustomerSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlCustomerClose" visible="false" onclick="ClearCustomerSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnCustomerSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnCustomerSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearCustomerSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearCustomerSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divCustomerSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblCustomerSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divCustomerSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblCustomerSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateProgress" AssociatedUpdatePanelID="updpnlgvCustomerSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvCustomerSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnCustomerRefresh" ClientIDMode="Static" OnClick="btnCustomerRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvCustomerSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, DownPaymentFromCustomerDistribution_htCustomerName%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCustomerDetails('<%#Eval("tbl_Customer")%>','<%#Eval("tbl_DownPaymentFromCustomerId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCustomerCode" Text='<%# Bind("tbl_Customer") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <%-- <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,DownPaymentFromCustomerDistribution_htCustomerCode%>">
                                            <ItemTemplate>

                                                <asp:Literal runat="server" ID="ltrgvCustomerCode" Text='<%# Bind("CustomerCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, DownPaymentFromCustomerDistribution_htCustomerGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgv_CustomerId" runat="server" Text='<%# Bind("tbl_DownPaymentFromCustomerId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnCustomerSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearCustomerSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
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
                        <asp:Literal runat="server" ID="ltrGLAccountTitle" Text="<%$ Resources:GlobalResource, DownPaymentFromCustomerDistribution_ltrGLAccountId%>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, DownPaymentFromCustomerDistribution_htAccountNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetGLAccountDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvGLAccountCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, DownPaymentFromCustomerDistribution_htGLAccountGuid %>" Visible="false">
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


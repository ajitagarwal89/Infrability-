<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PayablesForm.aspx.cs" Inherits="System_Settings_PayablesForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../infra_ui/js/System_Settings_JS/PayablesForm.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <!--page header start-->
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" OnClick="btnSave_Click" Text="<%$ Resources:GlobalResource, btnSave%>"/>
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-success" OnClick="btnUpdate_Click" Text="<%$ Resources:GlobalResource, btnUpdate%>"/>
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-success" OnClick="btnDelete_Click" Text="<%$ Resources:GlobalResource, btnDelete%>" formnovalidate="formnovalidate"/>
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-success" OnClick="btnBack_Click" Text="<%$ Resources:GlobalResource, btnBack%>" formnovalidate="formnovalidate"/>
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
                                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, Payables_ltrInformation%>"></asp:Literal></h5>
                        </div>                        
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPayablesType" TabIndex="1" Text="<%$ Resources:GlobalResource, Payables_lblPayablesType%>"></asp:Label>

                            <asp:DropDownList ID="ddlOpt_PayablesType" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required" AutoPostBack="true" OnSelectedIndexChanged="ddlOpt_PayablesType_SelectedIndexChanged"  >
                                                           </asp:DropDownList>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblProcessType" TabIndex="1" Text="<%$ Resources:GlobalResource, Payables_lblOpt_ProcessType%>" ></asp:Label>

                            <asp:DropDownList ID="ddlOpt_ProcessType" runat="server" AutoPostBack="true" ClientIDMode="Static" class="form-control " placeholder="" required="required" OnSelectedIndexChanged="ddlOpt_ProcessType_SelectedIndexChanged">
                               
                            </asp:DropDownList>
                        </div>
                        <div class="form-group col-md-4 col-sm-4" id="divBank" runat="server">
                            <div>
                                <asp:Label runat="server" ID="lbl_Bank" Text="<%$ Resources:GlobalResource, Payables_lblBankAccount %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtBank" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon3">
                                       <a href="#" data-toggle="modal" data-target="#basicModalBankSearch" data-keyboard="false" data-backdrop="static" onclick="CallBankRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtBankGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-md-4 col-sm-4" id="divCreditCard" runat="server">
                            <div>
                                <asp:Label runat="server" ID="lblCreditCard" Text="<%$ Resources:GlobalResource, Payables_lblCreditCard%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtCreditCard" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon6">
                                     <a href="#" data-toggle="modal" data-target="#basicModalCreditCardSearch" data-keyboard="false" data-backdrop="static" onclick="CallCreditCardRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>
                                <asp:TextBox ID="txtCreditCardGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblDocumentNumber" Text="<%$ Resources:GlobalResource, Payables_lblDocumentNumber%>"></asp:Label>
                 
                            <asp:TextBox type="text" runat="server" ID="txtDocumentNumber" ClientIDMode="Static" class="form-control " placeholder="" ></asp:TextBox>
                        </div>
                        
                        <div class="form-group col-md-4 col-sm-4" id="divChequeNumber" runat="server">

                            <asp:Label runat="server" ID="lblChequeNumber" Text="<%$ Resources:GlobalResource, Payables_lblChequeNumber%>"></asp:Label>
                            
                            <asp:TextBox type="text" runat="server" ID="txtChequeNumber" ClientIDMode="Static" class="form-control " placeholder="" ></asp:TextBox>

                        </div>
                        
                        <div class="form-group col-md-4 col-sm-4" id="divReceipt" runat="server">

                            <asp:Label runat="server" ID="lblReceiptNumber" Text="<%$ Resources:GlobalResource, Payables_lblReceiptNumber%>"></asp:Label>
                               <asp:TextBox type="text" runat="server" ID="txtReceiptNumber" ClientIDMode="Static" class="form-control " placeholder="" ></asp:TextBox>

                        </div>

                        <div class="form-group col-md-4 col-sm-4" id="divPayment" runat="server">

                            <asp:Label runat="server" ID="lblPaymentNumber" Text="<%$ Resources:GlobalResource, Payables_lblPaymentNumber%>"></asp:Label>
                            
                            <asp:TextBox type="text" runat="server" ID="txtPaymentNumber" ClientIDMode="Static" class="form-control " placeholder="" ></asp:TextBox>

                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPayablesDate" Text="<%$ Resources:GlobalResource, Payables_lblPayablesDate%>"></asp:Label>
                            <asp:TextBox type="text" TextMode="Date" runat="server" ID="txtPayablesDate" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

     <div class="modal fade" id="basicModalBankSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header" style="text-align: left;">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title" id="hdrModalBankTitle"><span>
                            <asp:Literal runat="server" ID="ltrBankTitle" Text="<%$ Resources:GlobalResource, Payables_ltrBank %>"></asp:Literal>
                        </span>
                        </h4>
                    </div>
                    <div class="modal-body">

                        <asp:UpdatePanel runat="server" ID="updpnlBankSearch">
                            <ContentTemplate>
                                <asp:Panel runat="server" ID="pnlBankSearch" DefaultButton="btnBankSearch">
                                    <div class="col-md-4 col-xs-5">
                                        <div class="icon-addon addon-md">
                                            <asp:TextBox runat="server" ID="txtBankSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                            <a runat="server" id="btnHtmlBankSearch" onclick="CallBankSearch();" class="fa fa-search"></a>
                                            <a runat="server" id="btnHtmlBankClose" visible="false" onclick="ClearBankSearch();" class="fa fa-close closex"></a>
                                        </div>
                                    </div>
                                    <asp:Button runat="server" ID="btnBankSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnBankSearch_Click" formnovalidate="formnovalidate" />
                                    <asp:Button runat="server" ID="btnClearBankSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearBankSearch_Click" formnovalidate="formnovalidate" />

                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div class="col-md-12 col-sm-12 colformstyle3">
                            <div runat="server" id="divBankSearchError" visible="false" class="alert alert-danger" role="alert">
                                <asp:Label runat="server" ID="lblBankSearchError"></asp:Label>
                            </div>
                            <div runat="server" id="divBankSearchSuccess" visible="false" class="alert alert-success" role="alert">
                                <asp:Label runat="server" ID="lblBankSearchSuccess"></asp:Label>
                            </div>
                        </div>
                        <div>
                            <asp:UpdateProgress runat="server" ID="updProgBankData" AssociatedUpdatePanelID="updpnlgvBankSearch">
                                <ProgressTemplate>
                                    Loading...
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:UpdatePanel runat="server" ID="updpnlgvBankSearch">
                                <ContentTemplate>
                                    <asp:Button runat="server" ID="btnBankRefresh" ClientIDMode="Static" OnClick="btnBankRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                    <asp:GridView ID="gvBankSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                        EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                        <Columns>
                                            <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Payables_htBankName%>">
                                                <ItemTemplate>
                                                    <a href="#" data-dismiss="modal" onclick="SetBankDetails('<%#Eval("BankName")%>','<%#Eval("tbl_BankId")%>');">

                                                        <asp:Literal runat="server" ID="ltrgvBankName" Text='<%# Bind("BankName") %>'></asp:Literal>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Payables_htAccount%>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvBankPaymentNumber" runat="server" Text='<%# Bind("BankCode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                 
                                            <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,Payables_htBankGuid %>" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvBankGuid" runat="server" Text='<%# Bind("tbl_BankId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnBankSearch" />
                                    <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearBankSearch" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="modal-footer row" runat="server" id="div2">
                        <div class="pull-left">
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                <asp:Literal runat="server" ID="ltrBankClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    <div class="modal fade" id="basicModalCreditCardSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header" style="text-align: left;">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title" id="hdrModalCreditCardTitle"><span>
                            <asp:Literal runat="server" ID="ltrCreditCardTitle" Text="<%$ Resources:GlobalResource, Payables_ltrpayablesCreditCard %>"></asp:Literal>
                        </span>
                        </h4>
                    </div>
                    <div class="modal-body">

                        <asp:UpdatePanel runat="server" ID="updpnlCreditCardSearch">
                            <ContentTemplate>
                                <asp:Panel runat="server" ID="pnlCreditCardSearch" DefaultButton="btnCreditCardSearch">
                                    <div class="col-md-4 col-xs-5">
                                        <div class="icon-addon addon-md">
                                            <asp:TextBox runat="server" ID="txtCreditCardSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                            <a runat="server" id="btnHtmlCreditCardSearch" onclick="CallCreditCardSearch();" class="fa fa-search"></a>
                                            <a runat="server" id="btnHtmlCreditCardClose" visible="false" onclick="ClearCreditCardSearch();" class="fa fa-close closex"></a>
                                        </div>
                                    </div>
                                    <asp:Button runat="server" ID="btnCreditCardSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnCreditCardSearch_Click" formnovalidate ="formnovalidate"/>
                                    <asp:Button runat="server" ID="btnClearCreditCardSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearCreditCardSearch_Click" formnovalidate="formnovalidate" />

                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div class="col-md-12 col-sm-12 colformstyle3">
                            <div runat="server" id="divCreditCardSearchError" visible="false" class="alert alert-danger" role="alert">
                                <asp:Label runat="server" ID="lblCreditCardSearchError"></asp:Label>
                            </div>
                            <div runat="server" id="divCreditCardSearchSuccess" visible="false" class="alert alert-success" role="alert">
                                <asp:Label runat="server" ID="lblCreditCardSearchSuccess"></asp:Label>
                            </div>
                        </div>
                        <div>
                            <asp:UpdateProgress runat="server" ID="updProgCreditCardData" AssociatedUpdatePanelID="updpnlgvCreditCardSearch">
                                <ProgressTemplate>
                                    Loading...
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:UpdatePanel runat="server" ID="updpnlgvCreditCardSearch">
                                <ContentTemplate>
                                    <asp:Button runat="server" ID="btnCreditCardRefresh" ClientIDMode="Static" OnClick="btnCreditCardRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                    <asp:GridView ID="gvCreditCardSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                        EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                        <Columns>
                                            <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Payables_htCreditCardName%>">
                                                <ItemTemplate>
                                                    <a href="#" data-dismiss="modal" onclick="SetCreditCardDetails('<%#Eval("CardName")%>','<%#Eval("tbl_CardId")%>');">

                                                        <asp:Literal runat="server" ID="ltrgvCard" Text='<%# Bind("CardName") %>'></asp:Literal>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Payables_htCardCode%>">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvCardCode" runat="server" Text='<%# Bind("CardCode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>                                           
                                            
                                            <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Payables_htCardGuid %>" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvCreditCardGuid" runat="server" Text='<%# Bind("tbl_CardId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnCreditCardSearch" />
                                    <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearCreditCardSearch" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="modal-footer row" runat="server" id="div6">
                        <div class="pull-left">
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                <asp:Literal runat="server" ID="ltrPayablesCreditCardClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CustomerGroupForm.aspx.cs" Inherits="Finance_Accounts_Receivable_Customer_Master_Creation_CustomerGroupForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Accounts_Receivable_JS/Customer_Master_Creation_JS/CustomerGroupForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrCustomerGroupInformation" Text="<%$ Resources:GlobalResource, CustomerGroupInformation%>"></asp:Literal></h5>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCustomerGroupId_Self" Text="<%$ Resources:GlobalResource, CustomerGroup_htCustomerGroup %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtCustomerGroupId_Self" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="spnCustomerGroup_">
                                    <a href="#" data-toggle="modal" data-target="#basicModalCustomerGroupSearch" data-keyboard="false" data-backdrop="static" onclick="CallCustomerGroupRefreshButton();" ">
                                          <i class="fa fa-search"></i>

                                    </a>
                                </span>
                                <asp:TextBox ID="txtCustomerGroupId_SelfGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource, CustomerGroup_lblDescription%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtDescription" ClientIDMode="Static" class="form-control" placeholder="" required="required" autofocus="autofocus"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblIsDefault" Text="<%$ Resources:GlobalResource, CustomerGroup_lblIsDefault%>"></asp:Label>
                            <asp:CheckBox runat="server" ID="chckIsDefault" Checked="false" ClientIDMode="Static" class="form-control" placeholder="" required="required" />
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCurrencyId" Text="<%$ Resources:GlobalResource, CustomerGroup_lblCurrencyId %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtCurrency" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control" required="required"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon">
                                    <a href="#" data-toggle="modal" data-target="#basicModalCurrencySearch" data-keyboard="false" data-backdrop="static" onclick="CallCurrencyRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtCurrencyGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblBalanceType" Text="<%$ Resources:GlobalResource, CustomerGroup_lblBalanceType%>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_BalanceType" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblMinimumPayment" Text="<%$ Resources:GlobalResource, CustomerGroup_lblMinimumPayment%>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_MinimumPayment" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblMinimumPaymentAmount" Text="<%$ Resources:GlobalResource, CustomerGroup_lblMinimumPaymentAmount%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtMinimumPaymentAmount" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblCreditLimit" Text="<%$ Resources:GlobalResource, CustomerGroup_lblCreditLimit%>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_CreditLimit" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblCreditLimitAmount" Text="<%$ Resources:GlobalResource, CustomerGroup_lblCreditLimitAmount%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtCreditLimitAmount" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>


                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblWriteOff" Text="<%$ Resources:GlobalResource, CustomerGroup_lblWriteOff%>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_WriteOff" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblWriteOffAmount" Text="<%$ Resources:GlobalResource, CustomerGroup_lblWriteOffAmount%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtWriteOffAmount" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>


                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblTradeDiscount" Text="<%$ Resources:GlobalResource, CustomerGroup_lblTradeDiscount%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtTradeDiscount" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>


                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblPaymentTerms" Text="<%$ Resources:GlobalResource, CustomerGroup_lblPaymentTerms%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtPaymentTerms" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon4">
                                     <a href="#" data-toggle="modal" data-target="#basicModalPaymentTermsSearch" data-keyboard="false" data-backdrop="static" onclick="CallPaymentTermsRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPaymentTermGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>


                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblCalendarYear" Text="<%$ Resources:GlobalResource, CustomerGroup_lblcalendarYear%>"></asp:Label>
                            <asp:CheckBox runat="server" ID="chckCalendarYear" Checked="false" ClientIDMode="Static" class="form-control" placeholder="" required="required" />
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblFiscalYear" Text="<%$ Resources:GlobalResource, CustomerGroup_lblFiscalYear%>"></asp:Label>
                            <asp:CheckBox runat="server" ID="chckFiscalYear" Checked="false" ClientIDMode="Static" class="form-control" placeholder="" required="required" />
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblTransaction" Text="<%$ Resources:GlobalResource, CustomerGroup_lblTransaction%>"></asp:Label>
                            <asp:CheckBox runat="server" ID="chckTransaction" Checked="false" ClientIDMode="Static" class="form-control" placeholder="" required="required" />
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDistribution" Text="<%$ Resources:GlobalResource, CustomerGroup_lblDistribution%>"></asp:Label>
                            <asp:CheckBox runat="server" ID="chckDistribution" Checked="false" ClientIDMode="Static" class="form-control" placeholder="" required="required" />
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblStatementCycle" Text="<%$ Resources:GlobalResource, CustomerGroup_lblStatementCycle%>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_StatementCycle" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
                            </asp:DropDownList>
                        </div>


                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalCustomerGroupSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalCustomerGroupTitle"><span>
                        <asp:Literal runat="server" ID="ltr_CustomerGroup_information1" Text="<%$ Resources:GlobalResource, CustomerGroup_ltrinformation %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlCustomerGroupSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlCustomerGroupSearch" DefaultButton="btnCustomerGroupSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtCustomerGroupSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlCustomerGroupSearch" onclick="CallSupplierGroupSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlCustomerGroupClose" visible="false" onclick="ClearCustomerGroupSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnCustomerGroupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnCustomerGroupSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearCustomerGroupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearCustomerGroupSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divCustomerGroupSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblCustomerGroupSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divCustomerGroupSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="CustomerGroupSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgCustomerGroupData" AssociatedUpdatePanelID="updpnlgvCustomerGroupSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvCustomerGroupSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnCustomerGroupRefresh" ClientIDMode="Static" OnClick="btnCustomerGroupRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvCustomerGroupSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,CustomerGroup_htCustomerGroup%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCustomerGroupDetails('<%#Eval("Description")%>','<%#Eval("tbl_CustomerGroupId")%>');">
                                                    <asp:Literal runat="server" ID="ltrDecription" Text='<%# Bind("Description") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,CustomerGroup_htCustomerGroupGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltbl_CustomerGroupId_Self" runat="server" Text='<%# Bind("tbl_CustomerGroupId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnCustomerGroupSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearCustomerGroupSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrCustomerGroupClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalPaymentTermsSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalPaymentTermsTitle"><span>
                        <asp:Literal runat="server" ID="ltrPaymentTermsTitle" Text="<%$ Resources:GlobalResource, CustomerGroup_lblPaymentTerms%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlPaymentTerms">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlPaymentTerms" DefaultButton="btnPaymentTermsSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtPaymentTermsSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlPaymentTermsSearch" onclick="CallPaymentTermsSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlPaymentTermsClose" visible="false" onclick="ClearPaymentTermsSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnPaymentTermsSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnPaymentTermsSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearPaymentTermsSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearPaymentTermsSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divPaymentTermsSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblPaymentTermsSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divPaymentTermsSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblPaymentTermsSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgPaymentTermsData" AssociatedUpdatePanelID="updpnlgvPaymentTermsSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvPaymentTermsSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnPaymentTermsRefresh" ClientIDMode="Static" OnClick="btnPaymentTermsRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvPaymentTermsSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PaymentTerms_htName%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetPaymentTermsDetails('<%#Eval("PaymentTermsName")%>','<%#Eval("tbl_PaymentTermsId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvPaymentTermsCode" Text='<%# Bind("PaymentTermsName") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PaymentTerms Guid" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPaymentTermsGuid" runat="server" Text='<%# Bind("tbl_PaymentTermsId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPaymentTermsSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearPaymentTermsSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divPaymentTermsFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblPaymentTermsClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
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
                        <asp:Literal runat="server" ID="ltrCurrencyTitle" Text="<%$ Resources:GlobalResource, Currency_ltrCurrency%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlCurrencySearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlCurrencySearch" DefaultButton="btnCurrencySearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtCurrencySearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlCurrencySearch" onclick="CallCurrencySearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlCurrencyClose" visible="false" onclick="ClearCurrencySearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnCurrencySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnCurrencySearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearCurrencySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearCurrencySearch_Click" />
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, CustomerGroup_htCurrencyCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCurrencyDetails('<%#Eval("CurrencyName")%>','<%#Eval("tbl_CurrencyId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCurrencyCode" Text='<%# Bind("CurrencyCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,htName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCurrencyName" runat="server" Text='<%# Bind("CurrencyName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, CustomerGroup_htCurrencyGuid%>" Visible="false">
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


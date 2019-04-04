<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PayableSetupAndGroupAccountForm.aspx.cs" Inherits="Finance_Accounts_Payable_Setup_PayableSetupAndGroupAccountForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../infra_ui/js/System_Settings_JS/Payables_JS/PayableSetupAndGroupAccountForm.js"></script>
    <script src="../infra_ui/js/CommonJS/CommonValidations.js"></script>  
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
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-success" OnClick="btnBack_Click" Text="<%$ Resources:GlobalResource, btnBack%>" formnovalidate="formnovalidate"></asp:Button>
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
                                <asp:Literal runat="server" ID="ltrPayableSetupAndGroupAccountInformation" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_ltrPayableSetupAndGroupAccountInformation%>"></asp:Literal></h5>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblPayableSetupId" Text="<%$ Resources:GlobalResource, PayableSetup_lblPayableSetupId %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtPayableSetup" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addonPayableSetup">
                                    <a href="#" data-toggle="modal" data-target="#basicModalPayableSetupSearch" data-keyboard="false" data-backdrop="static" onclick="CallPayableSetupRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPayableSetupGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblPayableSetupGroupId" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_lblPayableSetupGroupId %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtPayableSetupGroup" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addonPayableSetupGroup">
                                    <a href="#" data-toggle="modal" data-target="#basicModalPayableSetupGroupSearch" data-keyboard="false" data-backdrop="static" onclick="CallPayableGroupRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPayableSetupGroupGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-5">
                            <div>
                                <asp:Label runat="server" ID="lblChequeBook" Text="<%$ Resources:GlobalResource, PayableSetup_lblcheckbookid%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtChequeBook" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addonChequeBook">
                                    <a href="#" data-toggle="modal" data-target="#basicModalChequeBookSearch" data-keyboard="false" data-backdrop="static" onclick="CallChequeBookRefreshButton();">
                                <i class="fa fa-search"></i></a>
                                </span>

                                <asp:TextBox ID="txtChequeBookGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblAccountType" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_lblAccountType %>"></asp:Label>
                            <asp:DropDownList ID="ddlAccountType" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblPaymentMode" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_lblPaymentMode%>"></asp:Label>

                            <asp:CheckBox runat="server" ID="chkPaymentMode" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:CheckBox>

                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblGLAccountId_Cash" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_lblGLAccountId_Cash %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtGLAccountId_Cash" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-GLAccountId_Cash">
                                    <a href="#" data-toggle="modal" data-target="#basicModalGLAccountId_CashSearch" data-keyboard="false" data-backdrop="static" onclick="CallCashRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountId_CashGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblGLAccountId_AccountReceivable" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_lblGLAccountId_AccountReceivable %>"></asp:Label>
                            <div class="input-group">
                                <asp:TextBox ID="txtGLAccountId_AccountReceivable" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-aAccountReceivable">
                                     <a href="#" data-toggle="modal" data-target="#basicModalGLAccountIdAccountReceivable" data-keyboard="false" data-backdrop="static" onclick="CallAccountReceivableRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountId_AccountReceivableGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>

                            </div>

                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblGLAccountId_Sales" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_lblGLAccountId_Sales %>"></asp:Label>
                            <div class="input-group">
                                <asp:TextBox ID="txtGLAccountId_Sales" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-Sales">
                                     <a href="#" data-toggle="modal" data-target="#basicModalGLAccountIdSalesSearch" data-keyboard="false" data-backdrop="static" onclick="CallSalesRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountId_SalesGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>

                            </div>

                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblGLAccountId_CostOfSales" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_lblGLAccountId_CostOfSales %>"></asp:Label>
                            <div class="input-group">
                                <asp:TextBox ID="txtGLAccountId_CostOfSales" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-CostOfSales">
                                    <a href="#" data-toggle="modal" data-target="#basicModalGLAccountIdCostOfSalesSearch" data-keyboard="false" data-backdrop="static" onclick="CallCostOfSalesRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountId_CostOfSalesGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>

                            </div>

                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblGLAccountId_Inventory" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_lblGLAccountId_Inventory %>"></asp:Label>
                            <div class="input-group">
                                <asp:TextBox ID="txtGLAccountId_Inventory" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-Inventory">
                                     <a href="#" data-toggle="modal" data-target="#basicModalGLAccountIdInventorySearch" data-keyboard="false" data-backdrop="static" onclick="CallInventoryRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountId_InventoryGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>

                            </div>

                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblGLAccountId_AccuralDifferedA_C" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_lblGLAccountId_AccuralDifferedA_C %>"></asp:Label>
                            <div class="input-group">
                                <asp:TextBox ID="txtGLAccountId_AccuralDifferedA_C" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-AccuralDifferedA_C">
                                    <a href="#" data-toggle="modal" data-target="#basicModalGLAccountIdAccuralDifferedA_CSearch" data-keyboard="false" data-backdrop="static" onclick="CallAccuralDifferedA_CRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountId_AccuralDifferedA_CGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>

                            </div>

                        </div>

                    </div>


                </div>
            </div>
        </div>
    </div>

    <!--Modals-->

    <%-- Modal Popup for basicModal_Cheque Book Search --%>
    <div class="modal fade" id="basicModalChequeBookSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalChequeBookTitle"><span>
                        <asp:Literal runat="server" ID="ltrChequeBookTitle" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_ltrChequeBookInformation%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlChequeBook">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlChequeBook" DefaultButton="btnChequeBookSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtChequeBookSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlChequeBookSearch" onclick="CallChequeBookSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlChequeBookClose" visible="false" onclick="ClearChequeBookSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>

                                <asp:Button runat="server" ID="btnChequeBookSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnChequeBookSearch_Click" formnovalidate="formnovalidate " />
                                <asp:Button runat="server" ID="btnClearChequeBookSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearChequeBookSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divChequeBookSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblChequeBookSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divChequeBookSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblChequeBookSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgChequeBookData" AssociatedUpdatePanelID="updpnlgvChequeBookSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvChequeBookSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnChequeBookRefresh" ClientIDMode="Static" OnClick="btnChequeBookRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvChequeBookSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PayableSetupAndGroupAccount_htChequeBookNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetChequeBookDetails('<%#Eval("ChequeBookName")%>','<%#Eval("tbl_ChequeBookId")%>');">
                                                                <asp:Literal runat="server" ID="ltrgvChequeBookNumber" Text='<%# Bind("ChequeBookNumber") %>'></asp:Literal>
                                                            </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_htChequeBookGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvChequeBookGuid" runat="server" Text='<%# Bind("tbl_ChequeBookId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnChequeBookSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearChequeBookSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divChequeBookFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblChequeBookClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

     <%-- Modal Popup for basicModal_PayableSetup Search --%>
    <div class="modal fade" id="basicModalPayableSetupSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalPayableSetupTitle"><span>
                        <asp:Literal runat="server" ID="ltrPayableSetupTitle" Text="<%$ Resources:GlobalResource, PayableSetup_ltrPayableSetupInformation%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlPayableSetup">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlPayableSetup" DefaultButton="btnPayableSetupSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtPayableSetupSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlPayableSetupSearch" onclick="CallPayableSetupSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlPayableSetupClose" visible="false" onclick="ClearPayableSetupSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>

                                <asp:Button runat="server" ID="btnPayableSetupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnPayableSetupSearch_Click" formnovalidate="formnovalidate " />
                                <asp:Button runat="server" ID="btnClearPayableSetupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearPayableSetupSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divPayableSetupSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblPayableSetupSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divPayableSetupSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblPayableSetupSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgPayableSetupData" AssociatedUpdatePanelID="updpnlgvPayableSetupSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvPayableSetupSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnPayableSetupRefresh" ClientIDMode="Static" OnClick="btnPayableSetupRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvPayableSetupSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PayableSetup_htPayableSetupDetails%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetPayableSetupDetails('<%#Eval("PaymentCode")%>','<%#Eval("tbl_PayableSetupId")%>');">
                                                                <asp:Literal runat="server" ID="ltrgvPayableSetupNumber" Text='<%# Bind("PaymentDescription") %>'></asp:Literal>
                                                            </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PayableSetup_htPayableSetupGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayableSetupGuid" runat="server" Text='<%# Bind("tbl_PayableSetupId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPayableSetupSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearPayableSetupSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divPayableSetupFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblPayableSetupClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- Modal Popup for basicModalPayableSetupGroupSearch --%>
    <div class="modal fade" id="basicModalPayableSetupGroupSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalPayableSetupGroupTitle"><span>
                        <asp:Literal runat="server" ID="ltrPayableSetupGroupTitle" Text="<%$ Resources:GlobalResource, PayableSetupGroup_ltrInformation%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlPayableSetupGroup">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlPayableSetupGroup" DefaultButton="btnPayableSetupGroupSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtPayableSetupGroupSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlPayableSetupGroupSearch" onclick="CallPayableGroupSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlPayableSetupGroupClose" visible="false" onclick="ClearPayableGroupSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>

                                <asp:Button runat="server" ID="btnPayableSetupGroupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnPayableSetupGroupSearch_Click" formnovalidate="formnovalidate " />
                                <asp:Button runat="server" ID="btnClearPayableSetupGroupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearPayableSetupGroupSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divPayableSetupGroupSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblPayableSetupGroupSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divPayableSetupGroupSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblPayableSetupGroupSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgPayableSetupGroupData" AssociatedUpdatePanelID="updpnlgvPayableSetupGroupSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvPayableSetupGroupSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnPayableSetupGroupRefresh" ClientIDMode="Static" OnClick="btnPayableSetupGroupRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvPayableSetupGroupSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PayableSetupAndGroupAccount_htDescription%>">
                                            <ItemTemplate>
                                                 <a href="#" data-dismiss="modal" onclick="setPayableSetupGroupDetails('<%#Eval("Description")%> ',' <%#Eval("tbl_PayableSetupGroupId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvPayableSetupGroup" Text='<%# Bind("Description") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_htPayableSetupGroupGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayableSetupGroupGuid" runat="server" Text='<%# Bind("tbl_PayableSetupGroupId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPayableSetupGroupSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearPayableSetupGroupSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divPayableSetupGroupFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblPayableSetupGroupClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <%-- Modal Popup for basicModalGLAccountId_CashSearch --%>

    <div class="modal fade" id="basicModalGLAccountId_CashSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGLAccountId_CashTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountId_CashTitle" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_ltrGLAccountId_CashInformation%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlGLAccountId_Cash">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlGLAccountId_Cash" DefaultButton="btnAccountCashSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtGLAccountId_CashSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlGLAccountId_CashSearch" onclick="CallCashSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlGLAccountId_CashClose" visible="false" onclick="ClearCashSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>

                                <asp:Button runat="server" ID="btnAccountCashSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAccountCashSearch_Click" formnovalidate="formnovalidate " />
                                <asp:Button runat="server" ID="btnClearAccountCashSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearAccountCashSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountId_CashSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_CashSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountId_CashSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_CashSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgGLAccountId_CashData" AssociatedUpdatePanelID="updpnlgvGLAccountId_CashSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountId_CashSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnGLAccountId_CashRefresh" ClientIDMode="Static" OnClick="btnAccountCashRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvGLAccountId_CashSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PayableSetupAndGroupAccount_htNameSearch_Cash%>">
                                           <ItemTemplate>
                                                    <a href="#" data-dismiss="modal" onclick="SetCashDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvGLAccountId_CashCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_htGLAccountId_CashGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvGLAccountId_CashGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnAccountCashSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearAccountCashSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divGLAccountId_CashFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblGLAccountId_CashClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

     <%-- Modal Popup for basicModalGLAccountId_AccountReceivable --%>
    <div class="modal fade" id="basicModalGLAccountIdAccountReceivable" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGLAccountId_AccountReceivableTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountId_AccountReceivableTitle" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_ltrGLAccountId_AccountReceivableInformation%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlAccountReceivable">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlAccountReceivable" DefaultButton="btnAccountReceivableSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtAccountReceivableSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlAccountReceivableSearch" onclick="CallAccountReceivableSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlAccountReceivableClose" visible="false" onclick="ClearAccountReceivableSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>

                                <asp:Button runat="server" ID="btnAccountReceivableSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAccountReceivableSearch_Click" formnovalidate="formnovalidate " />
                                <asp:Button runat="server" ID="btnClearAccountReceivableSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearAccountReceivableSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountId_AccountReceivableSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblAccountReceivableSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountId_AccountReceivableSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblAccountReceivableSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgAccountReceivableeData" AssociatedUpdatePanelID="updpnlgvAccountReceivableSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvAccountReceivableSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnAccountCashRefresh" ClientIDMode="Static" OnClick="btnAccountCashRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvAccountReceivableSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PayableSetupAndGroupAccount_htGLAccountId_AccountReceivable%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetAccountReceivableDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvAccountReceivableCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_htGLAccountId_ReceivableGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvAccountReceivableGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnAccountReceivableSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearAccountReceivableSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divGLAccountId_AccountReceivableFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblAccountReceivableClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
     <%-- Modal Popup for basicModalGLAccountId_Sales --%>
    <div class="modal fade" id="basicModalGLAccountIdSalesSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGLAccountId_SalesTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountId_SalesTitle" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_ltrGLAccountId_SalesInformation%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlSales">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlSales" DefaultButton="btnSalesSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtSalesSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlSalesSearch" onclick="CallSalesSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlSalesClose" visible="false" onclick="ClearSalesSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>

                                <asp:Button runat="server" ID="btnSalesSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnSalesSearch_Click" formnovalidate="formnovalidate " />
                                <asp:Button runat="server" ID="btnClearSalesSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearSalesSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountId_SalesSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblSalesSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountId_SalesSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblSalesSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgGLAccountId_SalesData" AssociatedUpdatePanelID="updpnlgvGLAccountId_SalesSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountId_SalesSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnSalesRefresh" ClientIDMode="Static" OnClick="btnSalesRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvSalesSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PayableSetupAndGroupAccount_htGLAccountId_SalesNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetSalesDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                                <asp:Literal runat="server" ID="ltrgvSalesCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                            </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_htGLAccountId_SalesGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvSalesGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnSalesSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearSalesSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divGLAccountId_SalesFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblSalesClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
     <%-- Modal Popup for basicModalGLAccountId_CostOfSales --%>
    <div class="modal fade" id="basicModalGLAccountIdCostOfSalesSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGLAccountId_CostOfSalesTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountId_CostOfSalesTitle" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_ltrGLAccountId_CostOfSalesInformation%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlCostOfSales">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlCostOfSales" DefaultButton="btnCostOfSalesSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtCostOfSalesSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlCostOfSalesSearch" onclick="CallCostOfSalesSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlCostOfSalesClose" visible="false" onclick="ClearCostOfSalesSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>

                                <asp:Button runat="server" ID="btnCostOfSalesSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnCostOfSalesSearch_Click" formnovalidate="formnovalidate " />
                                <asp:Button runat="server" ID="btnClearCostOfSalesSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearCostOfSalesSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountId_CostOfSalesSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblCostOfSalesSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountId_CostOfSalesSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblCostOfSalesSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgGLAccountId_CostOfSalesData" AssociatedUpdatePanelID="updpnlgvGLAccountId_CostOfSalesSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountId_CostOfSalesSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnCostOfSalesRefresh" ClientIDMode="Static" OnClick="btnCostOfSalesRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvCostOfSalesSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PayableSetupAndGroupAccount_htGLAccountId_CostOfSalesNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCostOfSalesDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCostOfSales" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_htGLAccountId_CostOfSalesGuid%>" Visible="false">
                                            <ItemTemplate>
                                                 <asp:Label ID="lblgvCostOfSalesGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnCostOfSalesSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearCostOfSalesSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divGLAccountId_CostOfSalesFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblCostOfSalesClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
   <%-- Modal Popup for basicModalGLAccountId_Inventory --%>
<div class="modal fade" id="basicModalGLAccountIdInventorySearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGLAccountId_InventoryTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountId_InventoryTitle" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_ltrGLAccountId_InventoryInformation%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlInventory">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlInventory" DefaultButton="btnInventorySearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtInventorySearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlInventorySearch" onclick="CallInventorySearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlInventoryClose" visible="false" onclick="ClearInventorySearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>

                                <asp:Button runat="server" ID="btnInventorySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnInventorySearch_Click" formnovalidate="formnovalidate " />
                                <asp:Button runat="server" ID="btnClearInventorySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearInventorySearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountId_InventorySearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_InventorySearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountId_InventorySearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_InventorySearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgGLAccountId_InventoryData" AssociatedUpdatePanelID="updpnlgvGLAccountId_InventorySearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountId_InventorySearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnInventoryRefresh" ClientIDMode="Static" OnClick="btnInventoryRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvInventorySearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PayableSetupAndGroupAccount_htGLAccountId_InventoryNumber%>">
                                            <ItemTemplate>
                                              <a href="#" data-dismiss="modal" onclick="SetInventoryDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvInventoryInventoryCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_htGLAccountId_InventoryGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvInventoryGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnInventorySearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearInventorySearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divGLAccountId_InventoryFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblGLAccountId_InventoryClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
     <%-- Modal Popup for basicModalGLAccountId_AccuralDifferedA_C --%>
    <div class="modal fade" id="basicModalGLAccountIdAccuralDifferedA_CSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGLAccountId_AccuralDifferedA_CTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountId_AccuralDifferedA_CTitle" Text="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_ltrGLAccountId_AccuralDifferedA_CInformation%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlAccuralDifferedA_C">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlAccuralDifferedA_C" DefaultButton="btnAccuralDifferedA_CSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtAccuralDifferedA_CSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlAccuralDifferedA_CSearch" onclick="CallAccuralDifferedA_CSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlAccuralDifferedA_CClose" visible="false" onclick="ClearAccuralDifferedA_CSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>

                                <asp:Button runat="server" ID="btnAccuralDifferedA_CSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAccuralDifferedA_CSearch_Click" formnovalidate="formnovalidate " />
                                <asp:Button runat="server" ID="btnClearAccuralDifferedA_CSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearAccuralDifferedA_CSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountId_AccuralDifferedA_CSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_AccuralDifferedA_CSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountId_AccuralDifferedA_CSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_AccuralDifferedA_CSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgGLAccountId_AccuralDifferedA_CData" AssociatedUpdatePanelID="updpnlgvGLAccountId_AccuralDifferedA_CSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountId_AccuralDifferedA_CSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnAccuralDifferedA_CRefresh" ClientIDMode="Static" OnClick="btnAccuralDifferedA_CRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvAccuralDifferedA_CSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PayableSetupAndGroupAccount_htGLAccountId_AccuralDifferedA_CNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetAccuralDifferedA_CDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrAccuralDifferedA_CCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PayableSetupAndGroupAccount_htGLAccountId_AccuralDifferedA_CGuid%>" Visible="false">
                                            <ItemTemplate>
                                                 <asp:Label ID="lblgvAccuralDifferedA_CGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnAccuralDifferedA_CSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearAccuralDifferedA_CSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divGLAccountId_AccuralDifferedA_CFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblGLAccountId_AccuralDifferedA_CClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--Modals-->

</asp:Content>


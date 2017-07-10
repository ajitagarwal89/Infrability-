<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AssetAndGroupAccountForm.aspx.cs" Inherits="Assets_AssetAndGroupAccount_AssetAndGroupAccountForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../infra_ui/js/Asset/AssetAndGroupAccount_JS/AssetAndGroupAccountForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrAssetAndGroupAccounInformation" Text="<%$ Resources:GlobalResource, AssetAndGroupAccount_ltrAssetAndGroupAccountInformation%>"></asp:Literal></h5>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAccountCode" Text="<%$ Resources:GlobalResource, AssetAndGroupAccount_lblAccountCode%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtAccountCode" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource, AssetAndGroupAccount_lblDescription%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtDescription" ClientIDMode="Static" class="form-control " TextMode="MultiLine" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOpt_AccountType" Text="<%$ Resources:GlobalResource, AssetAndGroupAccount_lblOpt_AccountType %>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_AccountType" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblGLAccount_DepreciationExpense" Text="<%$ Resources:GlobalResource,AssetAndGroupAccount_lblGLAccount_DepreciationExpense %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtDepreciationExpense" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon1">
                                    <a href="#" data-toggle="modal" data-target="#basicModalDepreciationExpenseSearch" data-keyboard="false" data-backdrop="static" onclick="CallDepreciationExpenseRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtDepreciationExpenseGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>

                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblAccumulatedDepreciation" Text="<%$ Resources:GlobalResource,AssetAndGroupAccount_lblAccumulatedDepreciation %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtAccumulatedDepreciation" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon2">
                                    <a href="#" data-toggle="modal" data-target="#basicModalAccumulatedDepreciationSearch" data-keyboard="false" data-backdrop="static" onclick="CallDepreciationReserveRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtAccumulatedDepreciationGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>

                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblPriorYearDepreciation" Text="<%$ Resources:GlobalResource, AssetAndGroupAccount_lblPriorYearDepreciation %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtPriorYearDepreciation" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon3">
                                    <a href="#" data-toggle="modal" data-target="#basicModalPriorYearDepreciationSearch" data-keyboard="false" data-backdrop="static" onclick="CallPriorYearDepreciationRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPriorYearDepreciationGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>

                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblAssetCost" Text="<%$ Resources:GlobalResource,AssetAndGroupAccount_lblAssetCost %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtAssetCost" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon4">
                                    <a href="#" data-toggle="modal" data-target="#basicModalAssetCostSearch" data-keyboard="false" data-backdrop="static" onclick="CallAssetCostRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtAssetCostGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>

                        </div>                       
                                               
                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblClearing" Text="<%$ Resources:GlobalResource,AssetAndGroupAccount_lblClearing%>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtClearing" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon8">
                                    <a href="#" data-toggle="modal" data-target="#basicModalClearingSearch" data-keyboard="false" data-backdrop="static" onclick="CallClearingRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtClearingGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>

                        </div>

                    </div>
                </div>
            </div>

            <%-- Modal Popup for basicModalDepreciationExpense Search --%>
            <div class="modal fade" id="basicModalDepreciationExpenseSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header" style="text-align: left;">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" id="hdrModalDepreciationExpenseTitle"><span>
                                <asp:Literal runat="server" ID="ltr_DepreciationExpense_Infomation" Text="<%$ Resources:GlobalResource, AssetAndGroupAccount_ltr_DepreciationExpense_Infomation%>"></asp:Literal>
                            </span>
                            </h4>
                        </div>
                        <div class="modal-body">

                            <asp:UpdatePanel runat="server" ID="updpnlDepreciationExpenseSearch">
                                <ContentTemplate>
                                    <asp:Panel runat="server" ID="pnlDepreciationExpenseSearch" DefaultButton="btnDepreciationExpenseSearch">
                                        <div class="col-md-4 col-xs-5">
                                            <div class="icon-addon addon-md">
                                                <asp:TextBox runat="server" ID="txtDepreciationExpenseSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                                <a runat="server" id="btnHtmlDepreciationExpenseSearch" onclick="CallDepreciationExpenseSearch();" class="fa fa-search"></a>
                                                <a runat="server" id="btnHtmlDepreciationExpenseClose" visible="false" onclick="ClearDepreciationExpenseSearch();" class="fa fa-close closex"></a>
                                            </div>
                                        </div>
                                        <asp:Button runat="server" ID="btnDepreciationExpenseSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnDepreciationExpenseSearch_Click" formnovalidate="formnovalidate" />
                                        <asp:Button runat="server" ID="btnClearDepreciationExpenseSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearDepreciationExpenseSearch_Click" formnovalidate="formnovalidate" />

                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div class="col-md-12 col-sm-12 colformstyle3">
                                <div runat="server" id="divDepreciationExpenseSearchError" visible="false" class="alert alert-danger" role="alert">
                                    <asp:Label runat="server" ID="lblDepreciationExpenseSearchError"></asp:Label>
                                </div>
                                <div runat="server" id="divDepreciationExpenseSearchSuccess" visible="false" class="alert alert-success" role="alert">
                                    <asp:Label runat="server" ID="lblDepreciationExpenseSearchSuccess"></asp:Label>
                                </div>
                            </div>
                            <div>
                                <asp:UpdateProgress runat="server" ID="updProgData" AssociatedUpdatePanelID="updpnlgvDepreciationExpenseSearch">
                                    <ProgressTemplate>
                                        Loading...
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:UpdatePanel runat="server" ID="updpnlgvDepreciationExpenseSearch">
                                    <ContentTemplate>
                                        <asp:Button runat="server" ID="btnDepreciationExpenseRefresh" ClientIDMode="Static" OnClick="btnDepreciationExpenseRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                        <asp:GridView ID="gvDepreciationExpenseSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                            EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetAndGroupAccount_ht_DepreciationExpense%>">
                                                    <ItemTemplate>
                                                        <a href="#" data-dismiss="modal" onclick="SetDepreciationExpenseDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                            <asp:Literal runat="server" ID="ltrgvDepreciationExpenseNumber" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetAndGroupAccountt_htDepreciationExpenseGuid %>" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_DepreciationExpenseId" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnDepreciationExpenseSearch" />
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearDepreciationExpenseSearch" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="modal-footer row" runat="server" id="divFooter">
                            <div class="pull-left">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    <asp:Literal runat="server" ID="ltrDepreciationExpenseClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <%-- Modal Popup for AccumulatedDepreciation Search --%>

            <div class="modal fade" id="basicModalAccumulatedDepreciationSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header" style="text-align: left;">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" id="hdrModalAccumulatedDepreciationTitle"><span>
                                <asp:Literal runat="server" ID="ltrAccumulatedDepreciationTitle" Text="<%$ Resources:GlobalResource,AssetAndGroupAccount_ltrAccumulatedDepreciationInformation%>"></asp:Literal>
                            </span>
                            </h4>
                        </div>
                        <div class="modal-body">

                            <asp:UpdatePanel runat="server" ID="updpnlAccumulatedDepreciation">
                                <ContentTemplate>
                                    <asp:Panel runat="server" ID="pnlAccumulatedDepreciation" DefaultButton="btnAccumulatedDepreciationSearch">
                                        <div class="col-md-4 col-xs-5">
                                            <div class="icon-addon addon-md">
                                                <asp:TextBox runat="server" ID="txtAccumulatedDepreciationSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                                <a runat="server" id="btnHtmlAccumulatedDepreciationSearch" onclick="CallAccumulatedDepreciationSearch();" class="fa fa-search"></a>
                                                <a runat="server" id="btnHtmlAccumulatedDepreciationClose" visible="false" onclick="ClearAccumulatedDepreciationSearch();" class="fa fa-close closex"></a>
                                            </div>
                                        </div>

                                        <asp:Button runat="server" ID="btnAccumulatedDepreciationSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAccumulatedDepreciationSearch_Click" formnovalidate="formnovalidate " />
                                        <asp:Button runat="server" ID="btnClearAccumulatedDepreciationSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearAccumulatedDepreciationSearch_Click" formnovalidate="formnovalidate" />

                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div class="col-md-12 col-sm-12 colformstyle3">
                                <div runat="server" id="divAccumulatedDepreciationSearchError" visible="false" class="alert alert-danger" role="alert">
                                    <asp:Label runat="server" ID="lblAccumulatedDepreciationSearchError"></asp:Label>
                                </div>
                                <div runat="server" id="divAccumulatedDepreciationSearchSucces" visible="false" class="alert alert-success" role="alert">
                                    <asp:Label runat="server" ID="lblAccumulatedDepreciationSearchSucces"></asp:Label>
                                </div>
                            </div>
                            <div>
                                <asp:UpdateProgress runat="server" ID="updProgAccumulatedDepreciationData" AssociatedUpdatePanelID="updpnlgvAccumulatedDepreciationSearch">
                                    <ProgressTemplate>
                                        Loading...
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:UpdatePanel runat="server" ID="updpnlgvAccumulatedDepreciationSearch">
                                    <ContentTemplate>
                                        <asp:Button runat="server" ID="btnAccumulatedDepreciationRefresh" ClientIDMode="Static" OnClick="btnAccumulatedDepreciationRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                        <asp:GridView ID="gvAccumulatedDepreciationSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                            EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,AssetAndGroupAccount_ht_Name%>">
                                                    <ItemTemplate>
                                                        <a href="#" data-dismiss="modal" onclick="SetAccumulatedDepreciationDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                            <asp:Literal runat="server" ID="ltrgvAccumulatedDepreciationNumber" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetAndGroupAccount_htAccumulatedDepreciationGuid%>" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvAccumulatedDepreciationGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnAccumulatedDepreciationSearch" />
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearAccumulatedDepreciationSearch" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="modal-footer row" runat="server" id="divAccumulatedDepreciationFooter">
                            <div class="pull-left">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    <asp:Literal runat="server" ID="lblAccumulatedDepreciationClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <%-- Modal Popup forPriorYearDepreciation Search --%>

            <div class="modal fade" id="basicModalPriorYearDepreciationSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header" style="text-align: left;">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" id="hdrModalPriorYearDepreciationTitle"><span>
                                <asp:Literal runat="server" ID="ltrPriorYearDepreciationTitle" Text="<%$ Resources:GlobalResource, AssetAndGroupAccount_ltrPriorYearDepreciation%>"></asp:Literal>
                            </span>
                            </h4>
                        </div>
                        <div class="modal-body">

                            <asp:UpdatePanel runat="server" ID="updpnlPriorYearDepreciation">
                                <ContentTemplate>
                                    <asp:Panel runat="server" ID="pnlPriorYearDepreciation" DefaultButton="btnPriorYearDepreciationSearch">
                                        <div class="col-md-4 col-xs-5">
                                            <div class="icon-addon addon-md">
                                                <asp:TextBox runat="server" ID="txtPriorYearDepreciationSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                                <a runat="server" id="btnHtmlPriorYearDepreciationSearch" onclick="CallPriorYearDepreciationSearch();" class="fa fa-search"></a>
                                                <a runat="server" id="btnHtmlPriorYearDepreciationClose" visible="false" onclick="ClearPriorYearDepreciationSearch();" class="fa fa-close closex"></a>
                                            </div>
                                        </div>

                                        <asp:Button runat="server" ID="btnPriorYearDepreciationSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnPriorYearDepreciationSearch_Click" formnovalidate="formnovalidate" />
                                        <asp:Button runat="server" ID="btnClearPriorYearDepreciationSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearPriorYearDepreciationSearch_Click" formnovalidate="formnovalidate" />

                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div class="col-md-12 col-sm-12 colformstyle3">
                                <div runat="server" id="divPriorYearDepreciationSearchError" visible="false" class="alert alert-danger" role="alert">
                                    <asp:Label runat="server" ID="lblPriorYearDepreciationSearchError"></asp:Label>
                                </div>
                                <div runat="server" id="divPriorYearDepreciationSearchSucces" visible="false" class="alert alert-success" role="alert">
                                    <asp:Label runat="server" ID="lblPriorYearDepreciationSearchSucces"></asp:Label>
                                </div>
                            </div>
                            <div>
                                <asp:UpdateProgress runat="server" ID="updProgPriorYearDepreciationData" AssociatedUpdatePanelID="updpnlgvPriorYearDepreciationSearch">
                                    <ProgressTemplate>
                                        Loading...
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:UpdatePanel runat="server" ID="updpnlgvPriorYearDepreciationSearch">
                                    <ContentTemplate>
                                        <asp:Button runat="server" ID="btnPriorYearDepreciationRefresh" ClientIDMode="Static" OnClick="btnPriorYearDepreciationRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                        <asp:GridView ID="gvPriorYearDepreciationSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                            EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetAndGroupAccount_htPriorYearDepreciation%>">
                                                    <ItemTemplate>
                                                        <a href="#" data-dismiss="modal" onclick="SetPriorYearDepreciationDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                            <asp:Literal runat="server" ID="ltrgvPriorYearDepreciationCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetAndGroupAccount_htPriorYearDepreciationGuid%>" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvPriorYearDepreciationGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPriorYearDepreciationSearch" />
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearPriorYearDepreciationSearch" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="modal-footer row" runat="server" id="divPriorYearDepreciationFooter">
                            <div class="pull-left">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    <asp:Literal runat="server" ID="lblPriorYearDepreciationClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <%--- Modal Popup for AssetCost Search ----%>

            <div class="modal fade" id="basicModalAssetCostSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header" style="text-align: left;">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" id="hdrModalAssetCostTitle"><span>
                                <asp:Literal runat="server" ID="ltrAssetCostTitle" Text="<%$ Resources:GlobalResource, AssetAndGroupAccount_ltrAssetCostInfomation%>"></asp:Literal>
                            </span>
                            </h4>
                        </div>
                        <div class="modal-body">
                            <asp:UpdatePanel runat="server" ID="updpnlAssetCost">
                                <ContentTemplate>
                                    <asp:Panel runat="server" ID="pnlAssetCost" DefaultButton="btnAssetCostSearch">
                                        <div class="col-md-4 col-xs-5">
                                            <div class="icon-addon addon-md">
                                                <asp:TextBox runat="server" ID="txtAssetCostSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                                <a runat="server" id="btnHtmlAssetCostSearch" onclick="CallAssetCostSearch();" class="fa fa-search"></a>
                                                <a runat="server" id="btnHtmlAssetCostClose" visible="false" onclick="ClearAssetCostSearch();" class="fa fa-close closex"></a>
                                            </div>
                                        </div>
                                        <asp:Button runat="server" ID="btnAssetCostSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAssetCostSearch_Click" formnovalidate="formnovalidate" />
                                        <asp:Button runat="server" ID="btnClearAssetCostSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearAssetCostSearch_Click" formnovalidate="formnovalidate" />

                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div class="col-md-12 col-sm-12 colformstyle3">
                                <div runat="server" id="divAssetCostSearchError" visible="false" class="alert alert-danger" role="alert">
                                    <asp:Label runat="server" ID="lblAssetCostSearchError"></asp:Label>
                                </div>
                                <div runat="server" id="divAssetCostSearchSucces" visible="false" class="alert alert-success" role="alert">
                                    <asp:Label runat="server" ID="lblAssetCostSearchSucces"></asp:Label>
                                </div>
                            </div>
                            <div>
                                <asp:UpdateProgress runat="server" ID="updProgAssetCosteData" AssociatedUpdatePanelID="updpnlgvAssetCostSearch">
                                    <ProgressTemplate>
                                        Loading...
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:UpdatePanel runat="server" ID="updpnlgvAssetCostSearch">
                                    <ContentTemplate>
                                        <asp:Button runat="server" ID="btnAssetCostRefresh" ClientIDMode="Static" OnClick="btnAssetCostRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                        <asp:GridView ID="gvAssetCostSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                            EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,AssetAndGroupAccount_ht_NameAssetCost%>">
                                                    <ItemTemplate>
                                                        <a href="#" data-dismiss="modal" onclick="SetAssetCostDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                            <asp:Literal runat="server" ID="ltrgvAssetCostCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:GlobalResource,AssetAndGroupAccount_htAssetCostGuid %>" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvAssetCostGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnAssetCostSearch" />
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearAssetCostSearch" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="modal-footer row" runat="server" id="divAssetCostFooter">
                            <div class="pull-left">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    <asp:Literal runat="server" ID="lblAssetCostClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

           
            <%--Modal Popup for Clearing	 setSearch   --%>
            <div class="modal fade" id="basicModalClearingSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header" style="text-align: left;">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" id="hdrModalClearingTitle"><span>
                                <asp:Literal runat="server" ID="ltrClearingTitle" Text="<%$ Resources:GlobalResource, AssetAndGroupAccount_ltrClearingInfomation%>"></asp:Literal>
                            </span>
                            </h4>
                        </div>
                        <div class="modal-body">

                            <asp:UpdatePanel runat="server" ID="updpnlClearing">
                                <ContentTemplate>
                                    <asp:Panel runat="server" ID="pnlClearing" DefaultButton="btnClearingSearch">
                                        <div class="col-md-4 col-xs-5">
                                            <div class="icon-addon addon-md">
                                                <asp:TextBox runat="server" ID="txtClearingSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                                <a runat="server" id="btnHtmlClearingSearch" onclick="CallClearingSearch();" class="fa fa-search"></a>
                                                <a runat="server" id="btnHtmlClearingClose" visible="false" onclick="ClearClearingSearch();" class="fa fa-close closex"></a>
                                            </div>
                                        </div>
                                        <asp:Button runat="server" ID="btnClearingSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearingSearch_Click" formnovalidate="formnovalidate" />
                                        <asp:Button runat="server" ID="btnClearClearingSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearClearingSearch_Click" formnovalidate="formnovalidate" />

                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div class="col-md-12 col-sm-12 colformstyle3">
                                <div runat="server" id="divClearingSearchError" visible="false" class="alert alert-danger" role="alert">
                                    <asp:Label runat="server" ID="lblClearingSearchError"></asp:Label>
                                </div>
                                <div runat="server" id="divClearingSucces" visible="false" class="alert alert-success" role="alert">
                                    <asp:Label runat="server" ID="lblClearingSearchSucces"></asp:Label>
                                </div>
                            </div>
                            <div>
                                <asp:UpdateProgress runat="server" ID="updProgClearingData" AssociatedUpdatePanelID="updpnlgClearingSearch">
                                    <ProgressTemplate>
                                        Loading...
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:UpdatePanel runat="server" ID="updpnlgClearingSearch">
                                    <ContentTemplate>
                                        <asp:Button runat="server" ID="btnClearingRefresh" ClientIDMode="Static" OnClick="btnClearingRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                        <asp:GridView ID="gvClearingSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                            EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,AssetAndGroupAccount_htClearing%>">
                                                    <ItemTemplate>

                                                        <a href="#" data-dismiss="modal" onclick="SetClearingDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                            <asp:Literal runat="server" ID="ltrClearingCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:GlobalResource,AssetAndGroupAccount_htClearingGuid %>" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvClearingGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearingSearch" />
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearClearingSearch" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="modal-footer row" runat="server" id="divClearingFooter">
                            <div class="pull-left">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    <asp:Literal runat="server" ID="lblClearingClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>


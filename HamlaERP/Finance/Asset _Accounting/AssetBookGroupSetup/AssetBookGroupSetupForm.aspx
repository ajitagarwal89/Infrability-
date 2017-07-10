<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AssetBookGroupSetupForm.aspx.cs" Inherits="Assets_AssetBookGroupSetup_AssetBookGroupSetupForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../infra_ui/js/Asset/AssetBookGroupSetup_JS/AssetBookGroupSetupForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrAssetBookGroupSetup" Text="<%$ Resources:GlobalResource, AssetBookGroupSetup_Information%>"></asp:Literal></h5>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAssetBookGroupSetupCode" Text="<%$ Resources:GlobalResource, AssetBookGroupSetup_lblAssetBookGroupSetupCode%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtAssetBookGroupSetupCode" ClientIDMode="Static" class="form-control " placeholder="" required=""></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblAssetGroupId" Text="<%$ Resources:GlobalResource,AssetBookGroupSetup_lblAssetGroupId %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtAssetGroup" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon">
                                    <a href="#" data-toggle="modal" data-target="#basicModalAssetGroupSearch" data-keyboard="false" data-backdrop="static" onclick="CallAssetGroupRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtAssetGroupGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>

                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblAssetBookSetupId" Text="<%$ Resources:GlobalResource,AssetBookGroupSetup_lblAssetBookSetupId %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtAssetBookSetup" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon1">
                                    <a href="#" data-toggle="modal" data-target="#basicModalAssetBookSetupSearch" data-keyboard="false" data-backdrop="static" onclick="CallAssetBookSetupRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtAssetBookSetupGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>

                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblopt_DepreciationMethod" Text="<%$ Resources:GlobalResource, AssetBookGroupSetup_lblopt_DepreciationMethod %>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_DepreciationMethod" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lbl_opt_AveragingConvention" Text="<%$ Resources:GlobalResource, AssetBookGroupSetup_lbl_opt_AveragingConvention %>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_AveragingConvention" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOriginalLifeYear" Text="<%$ Resources:GlobalResource, AssetBookGroupSetup_lblOriginalLifeYear%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtOriginalLifeYear" ClientIDMode="Static" class="form-control " placeholder="" required=""></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOriginalLifeDay" Text="<%$ Resources:GlobalResource, AssetBookGroupSetup_OriginalLifeDay%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtOriginalLifeDay" ClientIDMode="Static" class="form-control " placeholder="" required=""></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblScrapValue" Text="<%$ Resources:GlobalResource, AssetBookGroupSetup_lblScrapValue%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtScrapValue" ClientIDMode="Static" class="form-control " placeholder="" required=""></asp:TextBox>
                        </div>



                    </div>

                    <div class="modal fade" id="basicModalAssetGroupSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header" style="text-align: left;">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    <h4 class="modal-title" id="hdrModalAssetGroupTitle"><span>
                                        <asp:Literal runat="server" ID="ltrAssetGroupTitle" Text="<%$ Resources:GlobalResource, AssetBookGroupSetup_ltrAssetGroupTitle %>"></asp:Literal>
                                    </span>
                                    </h4>
                                </div>
                                <div class="modal-body">

                                    <asp:UpdatePanel runat="server" ID="updpnlAssetGroupSearch">
                                        <ContentTemplate>
                                            <asp:Panel runat="server" ID="pnlAssetGroupSearch" DefaultButton="btnAssetGroupSearch">
                                                <div class="col-md-4 col-xs-5">
                                                    <div class="icon-addon addon-md">
                                                        <asp:TextBox runat="server" ID="txtAssetGroupSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                                        <a runat="server" id="btnHtmlAssetGroupSearch" onclick="CallAssetGroupSearch();" class="fa fa-search"></a>
                                                        <a runat="server" id="btnHtmlAssetGroupClose" visible="false" onclick="ClearAssetGroupSearch();" class="fa fa-close closex"></a>
                                                    </div>
                                                </div>
                                                <asp:Button runat="server" ID="btnAssetGroupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAssetGroupSearch_Click" formnovalidate="formnovalidate" />
                                                <asp:Button runat="server" ID="btnClearAssetGroupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearAssetGroupSearch_Click" formnovalidate="formnovalidate" />

                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                    <div class="col-md-12 col-sm-12 colformstyle3">
                                        <div runat="server" id="divAssetGroupSearchError" visible="false" class="alert alert-danger" role="alert">
                                            <asp:Label runat="server" ID="lblAssetGroupSearchError"></asp:Label>
                                        </div>
                                        <div runat="server" id="divAssetGroupSearchSuccess" visible="false" class="alert alert-success" role="alert">
                                            <asp:Label runat="server" ID="lblAssetGroupSearchSuccess"></asp:Label>
                                        </div>
                                    </div>
                                    <div>
                                        <asp:UpdateProgress runat="server" ID="updProgAssetGroupData" AssociatedUpdatePanelID="updpnlgvAssetGroupSearch">
                                            <ProgressTemplate>
                                                Loading...
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:UpdatePanel runat="server" ID="updpnlgvAssetGroupSearch">
                                            <ContentTemplate>
                                                <asp:Button runat="server" ID="btnAssetGroupRefresh" ClientIDMode="Static" OnClick="btnAssetGroupRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                                <asp:GridView ID="gvAssetGroupSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetBookGroupSetup_htAssetGroupName%>">
                                                            <ItemTemplate>
                                                                <a href="#" data-dismiss="modal" onclick="SetAssetGroupDetails('<%#Eval("Description")%>','<%#Eval("tbl_AssetGroupId")%>');">

                                                                    <asp:Literal runat="server" ID="ltrgvDescription" Text='<%# Bind("Description") %>'></asp:Literal>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetBookGroupSetup_htAssetGroupGuid%>" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvAssetGroupGuid" runat="server" Text='<%# Bind("tbl_AssetGroupId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnAssetGroupSearch" />
                                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearAssetGroupSearch" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="modal-footer row" runat="server" id="divFooter">
                                    <div class="pull-left">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">
                                            <asp:Literal runat="server" ID="ltrAssetGroupClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                      <div class="modal fade" id="basicModalAssetBookSetupSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header" style="text-align: left;">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    <h4 class="modal-title" id="hdrModalAssetBookSetupTitle"><span>
                                        <asp:Literal runat="server" ID="ltrAssetBookSetupTitle" Text="<%$ Resources:GlobalResource, AssetBookGroupSetup_ltrAssetBookSetupTitle %>"></asp:Literal>
                                    </span>
                                    </h4>
                                </div>
                                <div class="modal-body">

                                    <asp:UpdatePanel runat="server" ID="updpnlAssetBookSetupSearch">
                                        <ContentTemplate>
                                            <asp:Panel runat="server" ID="pnlAssetBookSetupSearch" DefaultButton="btnAssetBookSetupSearch">
                                                <div class="col-md-4 col-xs-5">
                                                    <div class="icon-addon addon-md">
                                                        <asp:TextBox runat="server" ID="txtAssetBookSetupSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                                        <a runat="server" id="btnHtmlAssetBookSetupSearch" onclick="CallAssetBookSetupSearch();" class="fa fa-search"></a>
                                                        <a runat="server" id="btnHtmlAssetBookSetupClose" visible="false" onclick="ClearAssetBookSetupSearch();" class="fa fa-close closex"></a>
                                                    </div>
                                                </div>
                                                <asp:Button runat="server" ID="btnAssetBookSetupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAssetBookSetupSearch_Click" formnovalidate="formnovalidate" />
                                                <asp:Button runat="server" ID="btnClearAssetBookSetupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearAssetBookSetupSearch_Click" formnovalidate="formnovalidate" />

                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                    <div class="col-md-12 col-sm-12 colformstyle3">
                                        <div runat="server" id="divAssetBookSetupSearchError" visible="false" class="alert alert-danger" role="alert">
                                            <asp:Label runat="server" ID="lblAssetBookSetupSearchError"></asp:Label>
                                        </div>
                                        <div runat="server" id="divAssetBookSetupSearchSuccess" visible="false" class="alert alert-success" role="alert">
                                            <asp:Label runat="server" ID="lblAssetBookSetupSearchSuccess"></asp:Label>
                                        </div>
                                    </div>
                                    <div>
                                        <asp:UpdateProgress runat="server" ID="updProgAssetBookSetupData" AssociatedUpdatePanelID="updpnlgvAssetBookSetupSearch">
                                            <ProgressTemplate>
                                                Loading...
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:UpdatePanel runat="server" ID="updpnlgvAssetBookSetupSearch">
                                            <ContentTemplate>
                                                <asp:Button runat="server" ID="btnAssetBookSetupRefresh" ClientIDMode="Static" OnClick="btnAssetBookSetupRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                                <asp:GridView ID="gvAssetBookSetupSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetBookGroupSetup_htAssetBookSetupCode%>">
                                                            <ItemTemplate>
                                                                <a href="#" data-dismiss="modal" onclick="SetAssetBookSetupDetails('<%#Eval("Description")%>','<%#Eval("tbl_AssetBookSetupId")%>');">

                                                                    <asp:Literal runat="server" ID="ltrgvDescription" Text='<%# Bind("AssetBookSetupCode") %>'></asp:Literal>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetBookGroupSetup_htAssetBookGroupSetupName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvEmployeeName" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetBookGroupSetup_htAssetBookSetupGuid%>" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvAssetBookSetupGuid" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnAssetBookSetupSearch" />
                                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearAssetBookSetupSearch" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="modal-footer row" runat="server" id="div1">
                                    <div class="pull-left">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">
                                            <asp:Literal runat="server" ID="ltrAssetBookSetupClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                                    </div>
                                </div>
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


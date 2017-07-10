<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AssetTransferForm.aspx.cs" Inherits="Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Asset%20_Accounting_JS/Transfer_of_Assets_JS/AssetTransferForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrAssetTransfer" Text="<%$ Resources:GlobalResource, AssetTransfer_ltrInformation%>"></asp:Literal></h5>
                        </div>

                          <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDocumentType" Text="<%$ Resources:GlobalResource, AssetTransfer_lblDocumentType%>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_DocumentType" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:DropDownList>
                        </div>


                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblNumber" Text="<%$ Resources:GlobalResource, AssetTransfer_lblNumber%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtNumber" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblBatchId" Text="<%$ Resources:GlobalResource, AssetTransfer_lblBatchId%>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtBatchId" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon">
                                    <a href="#" data-toggle="modal" data-target="#basicModalBatchSearch" data-keyboard="false" data-backdrop="static" onclick="CallBatchRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtBatchIdGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDate" Text="<%$ Resources:GlobalResource, AssetTransfer_lblDate%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtDate" TextMode="Date" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                     <div class="form-group col-md-4 col-sm-4">

                        <div>
                            <asp:Label runat="server" ID="lblLocationId_From" Text="<%$ Resources:GlobalResource, AssetTransfer_lblLocationId_From%>"></asp:Label>

                          </div>
                           <div class="input-group">
                             <asp:TextBox ID="txtLocationId_From" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                             <span class="input-group-addon lookup" id="sizing-addon3">
                            <a href="#" data-toggle="modal" data-target="#basicModalLocationFromSearch" data-keyboard="false" data-backdrop="static" onclick="CallLocationFromRefreshButton();">
                           <i class="fa fa-search"></i>
                              </a>
                             </span>
                          <asp:TextBox ID="txtLocation_FromGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                          </div>
                   </div>
                  


                   <div class="form-group col-md-4 col-sm-4">
                      <div>
                           <asp:Label runat="server" ID="lblLocationTo" Text="<%$ Resources:GlobalResource, AssetTransfer_lblLocationId_To%>"></asp:Label>
                      </div>
                    <div class="input-group">
                       <asp:TextBox ID="txtLocationId_To" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                      <span class="input-group-addon lookup" id="sizing-addon4">
                       <a href="#" data-toggle="modal" data-target="#basicModalLocationToSearch" data-keyboard="false" data-backdrop="static" onclick="CallLocationToRefreshButton();">
                       <i class="fa fa-search"></i>
                       </a>
                      </span>
                   <asp:TextBox ID="txtLocation_ToGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                   </div>
                 </div>
                </div>

         <div class="modal fade" id="basicModalLocationFromSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalLocationFromTitle"><span>
                        <asp:Literal runat="server" ID="ltrLocationFromTitle" Text="<%$ Resources:GlobalResource, AssetTransfer_lblLocationFromTitle%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlLocationFrom">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlLocationFrom" DefaultButton="btnLocationFromSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtLocationFromSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlLocationFromSearch" onclick="CallLocationFromSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlLocationFromClose" visible="false" onclick="ClearLocationFromSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnLocationFromSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnLocationFromSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearLocationFromSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearLocationFromSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divLocationFromSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblLocationFromSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divLocationFromSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblLocationFromSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgLocationFromData" AssociatedUpdatePanelID="updpnlgvLocationFromSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvLocationFromSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnLocationFromRefresh" ClientIDMode="Static" OnClick="btnLocationFromRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvLocationFromSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetTransfer_htLocationCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetLocationFromDetails('<%#Eval("City")%>','<%#Eval("tbl_LocationId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvLocationCode" Text='<%# Bind("LocationCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetTransfer_htCity %>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCity" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetTransfer_htLocationFromGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvLocationFromGuid" runat="server" Text='<%# Bind("tbl_LocationId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnLocationFromSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearLocationFromSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divLocationFromFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblLocationFromClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

         <div class="modal fade" id="basicModalLocationToSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalLocationToTitle"><span>
                        <asp:Literal runat="server" ID="ltrLocationToTitle" Text="<%$ Resources:GlobalResource, AssetTransfer_lblLocationToTitle%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlLocationTo">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlLocationTo" DefaultButton="btnLocationToSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtLocationToSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlLocationToSearch" onclick="CallLocationToSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlLocationToClose" visible="false" onclick="ClearLocationToSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnLocationToSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnLocationToSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearLocationToSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearLocationToSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divLocationToSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblLocationToSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divLocationToSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblLocationToSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgLocationToData" AssociatedUpdatePanelID="updpnlgvLocationToSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvLocationToSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnLocationToRefresh" ClientIDMode="Static" OnClick="btnLocationToRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvLocationToSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetTransfer_htLocationCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetLocationToDetails('<%#Eval("City")%>','<%#Eval("tbl_LocationId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvLocationCode" Text='<%# Bind("LocationCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetTransfer_htCity%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCity" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetTransfer_htLocationToGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvLocationToGuid" runat="server" Text='<%# Bind("tbl_LocationId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnLocationToSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearLocationToSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divLocationToFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblLocationToClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

         <div class="modal fade" id="basicModalBatchSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalBatchTitle"><span>
                        <asp:Literal runat="server" ID="ltr_Batch_information1" Text="<%$ Resources:GlobalResource, AssetTransfer_ltrBatchinformation %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlBatchSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlBatchSearch" DefaultButton="btnBatchSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtBatchSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlBatchSearch" onclick="CallBatchSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlBatchClose" visible="false" onclick="ClearBatchSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnBatchSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnBatchSearch_Click" formnovalidate="formnovalidate"/>
                                <asp:Button runat="server" ID="btnClearBatchSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearBatchSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divBatchSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblBatchSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divBatchSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="BatchSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgBatchData" AssociatedUpdatePanelID="updpnlgvBatchSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvBatchSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnBatchRefresh" ClientIDMode="Static" OnClick="btnBatchRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvBatchSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,AssetTransfer_htBatchType%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetBatchDetails('<%#Eval("BatchName")%>','<%#Eval("tbl_BatchId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvBatchType" Text='<%# Bind("Opt_BatchType") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetTransfer_htBatchName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvBatchName" runat="server" Text='<%# Bind("BatchName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetTransfer_htBatchGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvBatchGuid" runat="server" Text='<%# Bind("tbl_BatchId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnBatchSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearBatchSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrBatchClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
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


                      




                      

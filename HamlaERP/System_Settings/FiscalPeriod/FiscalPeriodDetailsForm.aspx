<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FiscalPeriodDetailsForm.aspx.cs" Inherits="FiscalPeriodDetailsForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">  
    <script src="../../infra_ui/js/System_Settings_JS/FiscalPeriod_JS/FiscalPeriodDetailsForm.js"></script>
	<script src="../../../infra_ui/js/CommonJS/CommonValidations.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
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
                                <asp:Literal runat="server" ID="ltrFiscalPeriodInformation" Text="<%$ Resources:GlobalResource, FiscalPeriodDetails_ltrInformation%>"></asp:Literal>
                            </h5>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblFiscalPeriodId" Text="<%$ Resources:GlobalResource, FiscalPeriodDetails_lblFiscalPeriod%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtFiscalPeriod" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon2">
                                     <a href="#" data-toggle="modal" data-target="#basicModalFiscalPeriodSearch" data-keyboard="false" data-backdrop="static" onclick="CallFiscalPeriodRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtFiscalPeriodGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPeriod" Text="<%$ Resources:GlobalResource, FiscalPeriodDetails_lblPeriod%>"></asp:Label>
                                <asp:TextBox type="text" runat="server" ID="txtPeriod"  MaxLength="1"  onkeypress="return isNumberKey(this);"  ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4 col-sm-4">
                                <asp:Label runat="server" ID="lblPeriodName" Text="<%$ Resources:GlobalResource, FiscalPeriodDetails_lblPeriodName%>"></asp:Label>
                                <asp:TextBox type="text" runat="server" ID="txtPeriodName" ClientIDMode="Static" class="form-control " placeholder=""  MaxLength="50"  onkeypress="return isAddress(this);"  required="required"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4 col-sm-4">
                                <asp:Label runat="server" ID="lblPeriodDate" Text="<%$ Resources:GlobalResource, FiscalPeriodDetails_lblPeriodDate%>"></asp:Label>
                                <asp:TextBox type="text" runat="server" ID="txtPeriodDate" TextMode="Date" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4 col-sm-4">
                                <asp:Label runat="server" ID="lblClosingFinancial" Text="<%$ Resources:GlobalResource, FiscalPeriodDetails_lblClosingFinancial%>"></asp:Label>
                                <asp:CheckBox runat="server" ID="chckClosingFinancial" Checked="false" ClientIDMode="Static" class="form-control" PlaceHolder="" required="required"></asp:CheckBox>
                            </div>

                            <div class="form-group col-md-4 col-sm-4">
                                <asp:Label runat="server" ID="lblClosingHR" Text="<%$ Resources:GlobalResource, FiscalPeriodDetails_lblClosingHR%>"></asp:Label>
                                <asp:CheckBox runat="server" ID="ChckClosingHR" Checked="false" ClientIDMode="Static" class="form-control" PlaceHolder="" required="required"></asp:CheckBox>
                            </div>

                            <div class="form-group col-md-4 col-sm-4">
                                <asp:Label runat="server" ID="lblClosingProcurement" Text="<%$ Resources:GlobalResource, FiscalPeriodDetails_lblClosingProcurement%>"></asp:Label>
                                <asp:CheckBox runat="server" ID="ChckClosingProcurement" Checked="false" ClientIDMode="Static" class="form-control" PlaceHolder="" required="required"></asp:CheckBox>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>


        <div class="modal fade" id="basicModalFiscalPeriodSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header" style="text-align: left;">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title" id="hdrModalFiscalPeriodTitle"><span>
                            <asp:Literal runat="server" ID="ltrFiscalPeriod" Text="<%$ Resources:GlobalResource, FiscalPeriodDetails_lblFiscalPeriod%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlFiscalPeriod">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlFiscalPeriod" DefaultButton="btnFiscalPeriodSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtFiscalPeriodSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlFiscalPeriodSearch" onclick="CallFiscalPeriodSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlFiscalPeriodClose" visible="false" onclick="ClearFiscalPeriodSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnFiscalPeriodSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnFiscalPeriodSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearFiscalPeriodSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearFiscalPeriodSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divFiscalPeriodSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblFiscalPeriodSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divFiscalPeriodSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblFiscalPeriodSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateProgFiscalPeriod" AssociatedUpdatePanelID="updpnlgvFiscalPeriodSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvFiscalPeriodSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnFiscalPeriodRefresh" ClientIDMode="Static" OnClick="btnFiscalPeriodRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvFiscalPeriodSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>"
                                AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                <columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, FiscalPeriodDetails_htNumberOfPeriod%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetFiscalPeriodDetails('<%#Eval("NumberOfPeriod")%>','<%#Eval("tbl_FiscalPeriodId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvFiscalPeriodCode" Text='<%# Bind("NumberOfPeriod") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, FiscalPeriodDetails_htFiscalPeriodGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvFiscalPeriodGuid" runat="server" Text='<%# Bind("tbl_FiscalPeriodId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      </columns>
                                <headerstyle backcolor="#24648f" forecolor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnFiscalPeriodSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearFiscalPeriodSearch" />
                            </triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFiscalPeriodFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblFiscalPeriodClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


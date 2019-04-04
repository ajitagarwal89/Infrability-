<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master"  AutoEventWireup="true" CodeFile="HRTeamForm.aspx.cs" Inherits="Human_Resource_HRTeamForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../../infra_ui/js/Human_Resource_JS/HR_JS/HRTeamForm.js"></script>
	<script src="../../infra_ui/js/CommonJS/CommonValidations.js"></script>
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
                                <asp:Literal runat="server" ID="ltrHRTeamInformation" Text="<%$ Resources:GlobalResource, HRTeam_ltrHRTeamInformation%>"></asp:Literal></h5>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblHRDepartment" Text="<%$ Resources:GlobalResource, HRTeam_lblHRDepartment%>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtHRDepartment" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon">
                                    <a href="#" data-toggle="modal" data-target="#basicModalHRDepartmentSearch" data-keyboard="false" data-backdrop="static" onclick="CallHRDepartmentRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>
                                <asp:TextBox ID="txtHRDepartmentGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                        
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblTeamCode" Text="<%$ Resources:GlobalResource, HRTeam_lblTeamCode%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtTeamCode" ClientIDMode="Static" class="form-control " placeholder=""  onkeypress="return isAlphaNumberKey(this);" MaxLength="20" required="required" ></asp:TextBox>
                        </div>  
                        
                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource, HRTeam_lblDescription%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine"  onkeypress="return isAddress(this);" MaxLength="50" ClientIDMode="Static" class="form-control " placeholder="" required="required" ></asp:TextBox>
                        </div>  

                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalHRDepartmentSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalHRDepartmentTitle"><span>
                        <asp:Literal runat="server" ID="ltr_HRDepartment_information1" Text="<%$ Resources:GlobalResource, HRTeam_lblHRDepartment %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlHRDepartmentSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlHRDepartmentSearch" DefaultButton="btnHRDepartmentSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtHRDepartmentSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlHRDepartmentSearch" onclick="CallHRDepartmentSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlHRDepartmentClose" visible="false" onclick="ClearHRDepartmentSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnHRDepartmentSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnHRDepartmentSearch_Click" formnovalidate="formnovalidate"/>
                                <asp:Button runat="server" ID="btnClearHRDepartmentSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearHRDepartmentSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divHRDepartmentSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblHRDepartmentSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divHRDepartmentSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="HRDepartmentSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgHRDepartmentData" AssociatedUpdatePanelID="updpnlgvHRDepartmentSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvHRDepartmentSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnHRDepartmentRefresh" ClientIDMode="Static" OnClick="btnHRDepartmentRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvHRDepartmentSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, HRTeam_htHRDepartmentCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetHRDepartmentDetails('<%#Eval("DepartmentCode")%>','<%#Eval("tbl_HR_DepartmentId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvHRDepartmentType" Text='<%# Bind("DepartmentCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                   
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, HRTeam_htHRDepartmentGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvHRDepartmentGuid" runat="server" Text='<%# Bind("tbl_HR_DepartmentId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnHRDepartmentSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearHRDepartmentSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrHRDepartmentClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>



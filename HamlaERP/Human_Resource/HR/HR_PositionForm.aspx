<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="HR_PositionForm.aspx.cs" Inherits="Human_Resource_HR_PositionForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../../infra_ui/js/Human_Resource_JS/HR_JS/HR_PositionForm.js"></script> 
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
                                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, HR_Position_ltrInformation%>"></asp:Literal></h5>
                        </div>
                        
                          <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblPositionCode" Text="<%$ Resources:GlobalResource, HR_Position_lblPositionCode%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtPositionCode"   ClientIDMode="Static" class="form-control" placeholder=""  onkeypress="return isAlphaNumberKey(this);" MaxLength="30" required="required"></asp:TextBox>
                        </div>

                       
                         <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblHR_PositionId_Self" Text="<%$ Resources:GlobalResource, HR_Position_lblHR_PositionId_Self %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtHR_PositionId_Self" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon3">
                                    <a href="#" data-toggle="modal" data-target="#basicModalHR_PositionId_SelfSearch" data-keyboard="false" data-backdrop="static" onclick="CallHR_PositionId_SelfRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtHR_PositionId_SelfGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                          <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblPayCodes" Text="<%$ Resources:GlobalResource, HR_Position_lblPayCodes%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtPayCodes" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon1">
                                     <a href="#" data-toggle="modal" data-target="#basicModalPayCodesSearch" data-keyboard="false" data-backdrop="static" onclick="CallPayCodesRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPayCodesGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                       </div>
                         
                            <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource, HR_Position_lblDescription%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDescription" onkeypress="return isAddress(this);" MaxLength="100" TextMode="MultiLine"  ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                       
                </div>
            </div>
        </div>
    </div>
        </div>
    
    <div class="modal fade" id="basicModalHR_PositionId_SelfSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalHR_PositionId_SelfTitle"><span>
                        <asp:Literal runat="server" ID="Literal2" Text="<%$ Resources:GlobalResource, HR_Position_ltrHR_PositionId_SelfTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlHR_PositionId_SelfSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlHR_PositionId_SelfSearch" DefaultButton="btnHR_PositionId_SelfSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtHR_PositionId_SelfSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlHR_PositionId_SelfSearch" onclick="CallHR_PositionId_SelfSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlHR_PositionId_SelfClose" visible="false" onclick="ClearHR_PositionId_SelfSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnHR_PositionId_SelfSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnHR_PositionId_SelfSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearHR_PositionId_SelfSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearHR_PositionId_SelfSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divHR_PositionId_SelfSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblHR_PositionId_SelfSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divHR_PositionId_SelfSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblHR_PositionId_SelfSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateProgress1" AssociatedUpdatePanelID="updpnlgvHR_PositionId_SelfSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvHR_PositionId_SelfSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnHR_PositionId_SelfRefresh" ClientIDMode="Static" OnClick="btnHR_PositionId_SelfRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvHR_PositionId_SelfSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,HR_Position_htPositionCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetHR_PositionId_SelfDetails('<%#Eval("PositionCode")%>','<%#Eval("tbl_HR_PositionId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvReceiptNumber" Text='<%# Bind("PositionCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     <asp:TemplateField HeaderText="<%$Resources:GlobalResource, HR_Position_htDescription%>" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$Resources:GlobalResource, HR_Position_htHR_PositionId_SelfGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHR_PositionId_SelfGuid" runat="server" Text='<%# Bind("tbl_HR_PositionId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnHR_PositionId_SelfSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearHR_PositionId_SelfSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div1">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrHR_PositionId_SelfClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <%--  <div class="modal fade" id="basicModalPayCodesSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalPayCodesTitle"><span>
                        <asp:Literal runat="server" ID="ltrPayCodesTitle" Text="<%$ Resources:GlobalResource, HR_Position_lblPayCodesTitle%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlPayCodes">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlPayCodes" DefaultButton="btnPayCodesSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtPayCodesSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlPayCodesSearch" onclick="CallPayCodesSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlPayCodesClose" visible="false" onclick="ClearPayCodesSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnPayCodesSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnPayCodesSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearPayCodesSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearPayCodesSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divPayCodesSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblPayCodesSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divPayCodesSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblPayCodesSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgPayCodesData" AssociatedUpdatePanelID="updpnlgvPayCodesSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvPayCodesSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnPayCodesRefresh" ClientIDMode="Static" OnClick="btnPayCodesRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvPayCodesSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, HR_Position__htAccountNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetPayCodesDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_PayCodesId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvAccountNumber" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, HR_Position_htPayCodesGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayCodesGuid" runat="server" Text='<%# Bind("tbl_PayCodesId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPayCodesSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearPayCodesSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divPayCodesFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblPayCodesClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>

</asp:Content>


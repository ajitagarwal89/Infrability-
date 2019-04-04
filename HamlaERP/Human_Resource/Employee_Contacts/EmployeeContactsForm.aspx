<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EmployeeContactsForm.aspx.cs" Inherits="Human_Resource_Employee_Contacts_EmployeeContactsForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../../infra_ui/js/Human_Resource_JS/Employee_Contacts_JS/EmployeeContactsForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, EmployeeContacts_ltrInformation%>"></asp:Literal></h5>
                        </div>
                        
                         <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblEmployee" Text="<%$ Resources:GlobalResource, EmployeeContacts_lblEmployee %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtEmployee" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon3">
                                    <a href="#" data-toggle="modal" data-target="#basicModalEmployeeSearch" data-keyboard="false" data-backdrop="static" onclick="CallEmployeeRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtEmployeeGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                          <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblContact" Text="<%$ Resources:GlobalResource, EmployeeContacts_lblContact%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtContact" MaxLength="30"  onkeypress="return isAlphaKey(this);"  ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCountry" Text="<%$ Resources:GlobalResource, EmployeeContacts_lblCountry%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtCountry" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon2">
                                    <a href="#" data-toggle="modal" data-target="#basicModalCountrySearch" data-keyboard="false" data-backdrop="static" onclick="CallCountryRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>
                                <asp:TextBox runat="server" ID="txtCountryGuid" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                            <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblRelationship" Text="<%$ Resources:GlobalResource, EmployeeContacts_lblRelationship%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtRelationship"  onkeypress="return isAlphaKey(this);"  MaxLength="50" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                              <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblHomePhone" Text="<%$ Resources:GlobalResource, EmployeeContacts_lblHomePhone%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtHomePhone"  ClientIDMode="Static" MaxLength="15" onkeypress="return isAlphaNumberKey(this);" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                              <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblWorkPhone" Text="<%$ Resources:GlobalResource, EmployeeContacts_lblWorkPhone%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtWorkPhone" MaxLength="15"  onkeypress="return isAlphaNumberKey(this);"   ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                              <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblExt" Text="<%$ Resources:GlobalResource, EmployeeContacts_lblExt%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtExt" onkeypress="return isNumberKey(this);" MaxLength="10"   ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                              <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblAddress" Text="<%$ Resources:GlobalResource, EmployeeContacts_lblAddress%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtAddress" onkeypress="return isAddress(this);" MaxLength="200"   ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                                 <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblCity" Text="<%$ Resources:GlobalResource, EmployeeContacts_lblCity%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtCity" onkeypress="return isAlphaKey(this);" MaxLength="50"   ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                        
                                  <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblState" Text="<%$ Resources:GlobalResource, EmployeeContacts_lblState%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtState"  onkeypress="return isAlphaKey(this);" MaxLength="50"  ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                        
                                  <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblZipCode" Text="<%$ Resources:GlobalResource, EmployeeContacts_lblZipCode%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtZipCode" MaxLength="6" onkeypress="return isNumberKey(this);"   ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                        
                         
                          
                       
                </div>
            </div>
        </div>
    </div>
        </div>
     <div class="modal fade" id="basicModalEmployeeSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalEmployeeTitle"><span>
                        <asp:Literal runat="server" ID="Literal2" Text="<%$ Resources:GlobalResource, EmployeeContacts_ltrEmployeeTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlEmployeeSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlEmployeeSearch" DefaultButton="btnEmployeeSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtEmployeeSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlEmployeeSearch" onclick="CallEmployeeSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlEmployeeClose" visible="false" onclick="ClearEmployeeSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnEmployeeSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnEmployeeSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearEmployeeSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearEmployeeSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divEmployeeSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblEmployeeSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divEmployeeSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblEmployeeSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateProgress1" AssociatedUpdatePanelID="updpnlgvEmployeeSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvEmployeeSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnEmployeeRefresh" ClientIDMode="Static" OnClick="btnEmployeeRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvEmployeeSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,EmployeeContacts_htEmployeeName%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetEmployeeDetails('<%#Eval("FirstName")%>','<%#Eval("tbl_EmployeeId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvEmployeeName" Text='<%# Bind("FirstName") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     <asp:TemplateField HeaderText="<%$Resources:GlobalResource,EmployeeContacts_htEmployeeCode %>" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmployeeCode" runat="server" Text='<%# Bind("EmployeeCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$Resources:GlobalResource, EmployeeContacts_htEmployeeGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmployeeGuid" runat="server" Text='<%# Bind("tbl_EmployeeId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnEmployeeSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearEmployeeSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div1">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrEmployeeClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
   
     <div class="modal fade" id="basicModalCountrySearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalCountryTitle"><span>
                        <asp:Literal runat="server" ID="ltrCountryTitle" Text="<%$ Resources:GlobalResource, EmployeeContacts_lblCountryTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlCountrySearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlCountrySearch" DefaultButton="btnCountrySearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtCountrySearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlCountrySearch" onclick="CallCountrySearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlCountryClose" visible="false" onclick="ClearCountrySearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnCountrySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnCountrySearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearCountrySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearCountrySearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divCountrySearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblCountrySearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divCountrySearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblCountrySearchSuccess"></asp:Label>
                        </div>
                    </div>

                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgData" AssociatedUpdatePanelID="updpnlgvCountrySearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvCountrySearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnCountryRefresh" ClientIDMode="Static" OnClick="btnCountryRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvCountrySearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeContacts_htCountryCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCountryDetails('<%#Eval("CountryName")%>','<%#Eval("tbl_CountryId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCountryCode" Text='<%# Bind("CountryCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeContacts_htCountryName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCountryName" runat="server" Text='<%# Bind("CountryName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField  HeaderText="<%$ Resources:GlobalResource, EmployeeContacts_htCountryGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCountryGuid" runat="server" Text='<%# Bind("tbl_CountryId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnCountrySearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearCountrySearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrCountryClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>


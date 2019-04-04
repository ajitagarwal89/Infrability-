<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EmployeeDependentsForm.aspx.cs" Inherits="Human_Resource_Employee_Dependents_EmployeeDependentsForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

    <script src="../../infra_ui/js/Human_Resource_JS/Employee_Dependents_JS/EmployeeDependentsForm.js"></script>
	<script src="../../infra_ui/js/CommonJS/CommonValidations.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">

     <div id="content" class="ui-content ui-content-aside-overlay">
        <!--page header start-->
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" OnClick="btnSave_Click" Text="<%$ Resources:GlobalResource, btnSave%>" formnovalidate="formnovalidate"></asp:Button>
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
                                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, EmployeeDependents_ltrInformation%>"></asp:Literal></h5>
                        </div>

                           <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblEmployeeId" Text="<%$ Resources:GlobalResource, EmployeeDependents_lblEmployeeID %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtEmployee" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon4">
                                    <a href="#" data-toggle="modal" data-target="#basicModalEmployeeSearch" data-keyboard="false" data-backdrop="static" onclick="CallEmployeeRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtEmployeeGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                          <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCountry" Text="<%$ Resources:GlobalResource, EmployeeDependents_lblCountry%>"></asp:Label>
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
                            <div>
                                <asp:Label runat="server" ID="lblHR_DepartmentId" Text="<%$ Resources:GlobalResource, EmployeeDependents_lblHR_DepartmentId%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtHR_Department" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon3">
                                    <a href="#" data-toggle="modal" data-target="#basicModalHR_DepartmentSearch" data-keyboard="false" data-backdrop="static" onclick="CallHR_DepartmentRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>
                                <asp:TextBox runat="server" ID="txtHR_DepartmentGuid" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                   
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOpt_Relationship" Text="<%$ Resources:GlobalResource, EmployeeDependents_lblOpt_Relationship%>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_Relationship" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
                            </asp:DropDownList>
                        </div>
                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblFirstName" Text="<%$ Resources:GlobalResource, EmployeeDependents_lblFirstName %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtFirstName" ClientIDMode="Static" class="form-control "  onkeypress="return isAlphaKey(this);" MaxLength="30"  placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblMiddleName" Text="<%$ Resources:GlobalResource, EmployeeDependents_lblMiddleName %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtMiddleName" ClientIDMode="Static" class="form-control " onkeypress="return isAlphaKey(this);" MaxLength="30"  placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblLastName" Text="<%$ Resources:GlobalResource, EmployeeDependents_lblLastName %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtLastName" ClientIDMode="Static" class="form-control " onkeypress="return isAlphaKey(this);" MaxLength="30"  placeholder="" required="required"></asp:TextBox>
                        </div>

                          <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDOB" Text="<%$ Resources:GlobalResource, EmployeeDependents_lblDOB %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDOB" TextMode="Date" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblGender" Text="<%$ Resources:GlobalResource, EmployeeDependents_lblGender%>"></asp:Label>
                            <asp:RadioButton ID="rdbMale" runat="server" ClientIDMode="Static" GroupName="Gender" class="form-control" placeholder="" Text="<%$ Resources:GlobalResource, EmployeeDependents_rdbMale%>" /> 
                            <asp:RadioButton ID="rdbFemale" runat="server" ClientIDMode="Static" GroupName="Gender" class="form-control" placeholder="" Text="<%$ Resources:GlobalResource, EmployeeDependents_rdbFemale%>" />
                        </div>
                             <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblHomePhone" Text="<%$ Resources:GlobalResource, EmployeeDependents_lblHomePhone%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtHomePhone" MaxLength="15"  ClientIDMode="Static" class="form-control" onkeypress="return isNumberKey(this);" placeholder="" required="required"></asp:TextBox>
                        </div>
                              <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblWorkPhone" Text="<%$ Resources:GlobalResource, EmployeeDependents_lblWorkPhone%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtWorkPhone" MaxLength="15"  onkeypress="return isNumberKey(this);" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                              <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblExt" Text="<%$ Resources:GlobalResource, EmployeeDependents_lblExt%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtExt"  MaxLength="5" ClientIDMode="Static"  onkeypress="return isNumberKey(this);" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                              <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblAddress1" Text="<%$ Resources:GlobalResource, EmployeeDependents_lblAddress1%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtAddress1"  ClientIDMode="Static" class="form-control" placeholder=""  onkeypress="return isAddress(this);" MaxLength="100"  required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblAddress2" Text="<%$ Resources:GlobalResource, EmployeeDependents_lblAddress2%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtAddress2"  ClientIDMode="Static" class="form-control" onkeypress="return isAddress(this);" MaxLength="100" placeholder="" required="required"></asp:TextBox>
                        </div>      
                           <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblCity" Text="<%$ Resources:GlobalResource, EmployeeDependents_lblCity%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtCity"  ClientIDMode="Static" class="form-control" onkeypress="return isAlphaKey(this);" MaxLength="50" placeholder="" required="required"></asp:TextBox>
                        </div>
                        
                                  <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblState" Text="<%$ Resources:GlobalResource, EmployeeDependents_lblState%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtState"   ClientIDMode="Static" class="form-control" onkeypress="return isAlphaKey(this);" MaxLength="50" placeholder="" required="required"></asp:TextBox>
                        </div>
                        
                                  <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblZipCode" Text="<%$ Resources:GlobalResource, EmployeeDependents_lblZipCode%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtZipCode" MaxLength="6"  onkeypress="return isNumberKey(this);" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
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
                        <asp:Literal runat="server" ID="Literal2" Text="<%$ Resources:GlobalResource, EmployeeDependents_ltrEmployeeTitle %>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,EmployeeDependents_htEmployeeName%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetEmployeeDetails('<%#Eval("FirstName")%>','<%#Eval("tbl_EmployeeId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvEmployeeName" Text='<%# Bind("FirstName") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     <asp:TemplateField HeaderText="<%$Resources:GlobalResource,EmployeeDependents_htEmployeeCode %>" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmployeeCode" runat="server" Text='<%# Bind("EmployeeCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$Resources:GlobalResource, EmployeeDependents_htEmployeeGuid %>" Visible="false">
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
                        <asp:Literal runat="server" ID="ltrCountryTitle" Text="<%$ Resources:GlobalResource, EmployeeDependents_lblCountry %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlCountrySearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlCountrySearch" DefaultButton="btnCountrySearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtCountrySearch" CssClass="form-control" placeholder="Search..." autofocus></asp:TextBox>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeDependents_lblCountryCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCountryDetails('<%#Eval("CountryName")%>','<%#Eval("tbl_CountryId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCountryCode" Text='<%# Bind("CountryCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeDependents_lblCountryName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCountryName" runat="server" Text='<%# Bind("CountryName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeDependents_lblCountryGuid%>" Visible="false">
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

 
    <div class="modal fade" id="basicModalHR_DepartmentSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalHR_DepartmentTitle"><span>
                        <asp:Literal runat="server" ID="ltrHR_DepartmentTitle" Text="<%$ Resources:GlobalResource, EmployeeDependents_ltrHR_Department%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlHR_Department">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlHR_Department" DefaultButton="btnHR_DepartmentSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtHR_DepartmentSearch" CssClass="form-control" placeholder="Search..." autofocus></asp:TextBox>
                                        <a runat="server" id="btnHtmlHR_DepartmentSearch" onclick="CallHR_DepartmentSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlHR_DepartmentClose" visible="false" onclick="ClearHR_DepartmentSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnHR_DepartmentSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnHR_DepartmentSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearHR_DepartmentSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearHR_DepartmentSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divHR_DepartmentSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblHR_DepartmentSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divHR_DepartmentSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblHR_DepartmentSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgHR_DepartmentData" AssociatedUpdatePanelID="updpnlgvHR_DepartmentSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvHR_DepartmentSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnHR_DepartmentRefresh" ClientIDMode="Static" OnClick="btnHR_DepartmentRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvHR_DepartmentSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeDependents_htDepartmentCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetHR_DepartmentDetails('<%#Eval("DepartmentCode")%>','<%#Eval("tbl_HR_DepartmentId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvDivisionCode" Text='<%# Bind("DepartmentCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeDependents_htDescription%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeDependents_htDepartmentGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvHR_DepartmentGuid" runat="server" Text='<%# Bind("tbl_HR_DepartmentId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnHR_DepartmentSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearHR_DepartmentSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divHR_DepartmentFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblHR_DepartmentClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

  

   
 
</asp:Content>


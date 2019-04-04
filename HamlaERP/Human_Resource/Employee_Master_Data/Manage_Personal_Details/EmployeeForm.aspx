<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EmployeeForm.aspx.cs" Inherits="Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Accounts_Payable_JS/Employee_Supplier_Master_Creation_JS/EmployeeForm.js"></script>
	<script src="../../../infra_ui/js/CommonJS/CommonValidations.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
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
                                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, Employee_ltrInformation%>"></asp:Literal></h5>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblEmployeeCode" Text="<%$ Resources:GlobalResource, Employee_lblEmployeeCode %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtEmployeeCode" ClientIDMode="Static" ReadOnly="true" class="form-control " placeholder=""  onkeypress="return isAlphaNumberKey(this);" MaxLength="30"  required="required" ></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblFirstName" Text="<%$ Resources:GlobalResource, Employee_lblFirstName %>">></asp:Label>
                            <asp:TextBox runat="server" ID="txtFirstName"  onkeypress="return isAlphaKey(this);" MaxLength="50"  ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblMiddleName" Text="<%$ Resources:GlobalResource, Employee_lblMiddleName %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtMiddleName" ClientIDMode="Static" class="form-control "  onkeypress="return isAlphaKey(this);" MaxLength="50" placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblLastName" Text="<%$ Resources:GlobalResource, Employee_lblLastName %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtLastName" ClientIDMode="Static" class="form-control " onkeypress="return isAlphaKey(this);" MaxLength="50" placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblContact" Text="<%$ Resources:GlobalResource, Employee_lblContact %>"></asp:Label>
                          <%--  <asp:TextBox runat="server" ID="txtContact" ClientIDMode="Static" class="form-control " onkeypress="return isNumberKey(this);" MaxLength="15"  placeholder="" required="required"></asp:TextBox>--%>
                       <asp:TextBox ID="txtContact" runat="server" ClientIDMode="Static" class="form-control"   onkeypress="return isNumberKey(this);" MaxLength="15"  placeholder="" required="required"></asp:TextBox>
							</div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOpt_EmployeeNationalType" Text="<%$ Resources:GlobalResource, Employee_lblOpt_EmployeeNationalType%>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_EmployeeNationalType" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                           <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblIqamaBathaqaNumber" Text="<%$ Resources:GlobalResource, Employee_lblIqamaBathaqaNumber %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtIqamaBathaqaNumber" ClientIDMode="Static" class="form-control " onkeypress="return isAlphaNumberKey(this);" MaxLength="30"   placeholder=""  required="required"></asp:TextBox>
                        </div>
                        
                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAddress" Text="<%$ Resources:GlobalResource, Employee_lblAddress %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtAddress" ClientIDMode="Static" class="form-control " onkeypress="return isAddress(this);" MaxLength="200" placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblCity" Text="<%$ Resources:GlobalResource, Employee_lblCity %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtCity" ClientIDMode="Static" class="form-control " onkeypress="return isAlphaKey(this);" MaxLength="50"    placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblState" Text="<%$ Resources:GlobalResource, Employee_lblState %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtState" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                          <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblZipCode" Text="<%$ Resources:GlobalResource, Employee_lblZipCode %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtZipCode" ClientIDMode="Static" class="form-control "  onkeypress="return isNumberKey(this);" MaxLength="6"    placeholder="" required="required"></asp:TextBox>
                        </div>


                             <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCountry" Text="<%$ Resources:GlobalResource, Employee_lblCountry%>"></asp:Label>
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
                            <asp:Label runat="server" ID="lblPhone" Text="<%$ Resources:GlobalResource, Employee_lblPhone %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtPhone" ClientIDMode="Static" class="form-control "   MaxLength="15"    placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblMobile" Text="<%$ Resources:GlobalResource, Employee_lblMobile %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtMobile" ClientIDMode="Static" class="form-control "  isNumberKey="return isAlphaKey(this);" MaxLength="15"   placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblFaxNo" Text="<%$ Resources:GlobalResource, Employee_lblFaxNo %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtFaxNo" ClientIDMode="Static" class="form-control " isNumberKey="return isAlphaKey(this);" MaxLength="15"    placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblEmail" Text="<%$ Resources:GlobalResource, Employee_lblEmail %>"></asp:Label>
                            <asp:TextBox runat="server"  ID="txtEmail" TextMode="Email" MaxLength="100" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
         
                           <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblHR_DivisionId" Text="<%$ Resources:GlobalResource, Employee_lblHR_DivisionId%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtHR_Division" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon1">
                                    <a href="#" data-toggle="modal" data-target="#basicModalHR_DivisionSearch" data-keyboard="false" data-backdrop="static" onclick="CallHR_DivisionRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>
                                <asp:TextBox runat="server" ID="txtHR_DivisionGuid" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                 <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblHR_DepartmentId" Text="<%$ Resources:GlobalResource, Employee_lblHR_DepartmentId%>"></asp:Label>
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
                            <div>
                                <asp:Label runat="server" ID="lblHR_PositionId" Text="<%$ Resources:GlobalResource, Employee_lblHR_PositionId%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtHR_Position" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon4">
                                    <a href="#" data-toggle="modal" data-target="#basicModalHR_PositionSearch" data-keyboard="false" data-backdrop="static" onclick="CallHR_PositionRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>
                                <asp:TextBox runat="server" ID="txtHR_PositionGuid" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                   <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblHR_BranchId" Text="<%$ Resources:GlobalResource, Employee_lblHR_BranchId%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtHR_Branch" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon6">
                                    <a href="#" data-toggle="modal" data-target="#basicModalHR_BranchSearch" data-keyboard="false" data-backdrop="static" onclick="CallHR_BranchRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>
                                <asp:TextBox runat="server" ID="txtHR_BranchGuid" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                   <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblHR_SupervisorId" Text="<%$ Resources:GlobalResource, Employee_lblHR_SupervisorId%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtHR_Supervisor" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon7">
                                    <a href="#" data-toggle="modal" data-target="#basicModalHR_SupervisorSearch" data-keyboard="false" data-backdrop="static" onclick="CallHR_SupervisorRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>
                                <asp:TextBox runat="server" ID="txtHR_SupervisorGuid" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                          
                              <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblSeniorityDate" Text="<%$ Resources:GlobalResource, Employee_lblSeniorityDate %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtSeniorityDate" TextMode="Date" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                              <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblHireDate" Text="<%$ Resources:GlobalResource, Employee_lblHireDate %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtHireDate" TextMode="Date" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                              <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAdjustedHireDate" Text="<%$ Resources:GlobalResource, Employee_lblAdjustedHireDate %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtAdjustedHireDate" TextMode="Date" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                              <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblLastWorkingDay" Text="<%$ Resources:GlobalResource, Employee_lblLastWorkingDay %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtLastWorkingDay" TextMode="Date" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                             <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblInactivatedDate" Text="<%$ Resources:GlobalResource, Employee_lblInactivatedDate %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtInactivatedDate" TextMode="Date" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                            <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblReason" Text="<%$ Resources:GlobalResource, Employee_lblReason %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtReason"  ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                          <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCountry_Nationality" Text="<%$ Resources:GlobalResource, Employee_lblCountry_Nationality%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtCountry_Nationality" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon5">
                                    <a href="#" data-toggle="modal" data-target="#basicModalCountry_NationalitySearch" data-keyboard="false" data-backdrop="static" onclick="CallCountry_NationalityRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>
                                <asp:TextBox runat="server" ID="txtCountry_NationalityGuid" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblHRStatus" Text="<%$ Resources:GlobalResource, Employee_chkHRStatus%>"></asp:Label>
                            <asp:RadioButton ID="rdbActive" runat="server" ClientIDMode="Static" GroupName="HRstatus" class="form-control" placeholder="" Text="<%$ Resources:GlobalResource, Employee_rdbActive%>" /> 
                            <asp:RadioButton ID="rdbInActive" runat="server" ClientIDMode="Static" GroupName="HRstatus" class="form-control" placeholder="" Text="<%$ Resources:GlobalResource, Employee_rdbInActive%>" />
                        </div>


                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblopt_EmploymentType" Text="<%$ Resources:GlobalResource, Employee_lblopt_EmploymentType%>"></asp:Label>
                            <asp:DropDownList ID="ddlopt_EmploymentType" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDOB" Text="<%$ Resources:GlobalResource, Employee_lblDOB %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDOB"  ClientIDMode="Static" TextMode="Date" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                            <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblGender" Text="<%$ Resources:GlobalResource, Employee_lblGender%>"></asp:Label>
                            <asp:RadioButton ID="rdbMale" runat="server" ClientIDMode="Static" GroupName="Gender" class="form-control" placeholder="" Text="<%$ Resources:GlobalResource, Employee_rdbMale%>" /> 
                            <asp:RadioButton ID="rdbFemale" runat="server" ClientIDMode="Static" GroupName="Gender" class="form-control" placeholder="" Text="<%$ Resources:GlobalResource, Employee_rdbFemale%>" />
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblMaritalStatus" Text="<%$ Resources:GlobalResource, Employee_lblMaritalStatus%>"></asp:Label>
                            <asp:RadioButton ID="rdbMARRIED" runat="server" ClientIDMode="Static" GroupName="MaritalStatus" class="form-control" placeholder="" Text="<%$ Resources:GlobalResource, Employee_rdbMARRIED%>" /> 
                            <asp:RadioButton ID="rdbSINGLE" runat="server" ClientIDMode="Static" GroupName="MaritalStatus" class="form-control" placeholder="" Text="<%$ Resources:GlobalResource, Employee_rdbSINGLE%>" />
                        </div>
                               <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblWorkHoursPerYear" Text="<%$ Resources:GlobalResource, Employee_lblWorkHoursPerYear %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtWorkHoursPerYear"  ClientIDMode="Static" MaxLength="10" onkeypress="return isNumberKey(this);" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                               <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPassportNumber" Text="<%$ Resources:GlobalResource, Employee_lblPassportNumber %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtPassportNumber"  ClientIDMode="Static" MaxLength="20" onkeypress="return isAlphaNumberKey(this);" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                                   
                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPassportExp" Text="<%$ Resources:GlobalResource, Employee_lblPassportExp %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtPassportExp" TextMode="Date"  ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                             </div>
                        </div>
                            <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblIqamaBathaqaExp" Text="<%$ Resources:GlobalResource, Employee_lblIqamaBathaqaExp%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtIqamaBathaqaExp" TextMode="Date" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
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
                        <asp:Literal runat="server" ID="ltrCountryTitle" Text="<%$ Resources:GlobalResource, Employee_lblCountry %>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Employee_lblCountryCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCountryDetails('<%#Eval("CountryName")%>','<%#Eval("tbl_CountryId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCountryCode" Text='<%# Bind("CountryCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Employee_lblCountryName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCountryName" runat="server" Text='<%# Bind("CountryName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Employee_lblCountryGuid%>" Visible="false">
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

    <div class="modal fade" id="basicModalHR_DivisionSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalHR_DivisionTitle"><span>
                        <asp:Literal runat="server" ID="ltrHR_DivisionTitle" Text="<%$ Resources:GlobalResource, Employee_ltrHR_Division%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlHR_Division">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlHR_Division" DefaultButton="btnHR_DivisionSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtHR_DivisionSearch" CssClass="form-control" placeholder="Search..." autofocus></asp:TextBox>
                                        <a runat="server" id="btnHtmlHR_DivisionSearch" onclick="CallHR_DivisionSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlHR_DivisionClose" visible="false" onclick="ClearHR_DivisionSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnHR_DivisionSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnHR_DivisionSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearHR_DivisionSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearHR_DivisionSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divHR_DivisionSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblHR_DivisionSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divHR_DivisionSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblHR_DivisionSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgHR_DivisionData" AssociatedUpdatePanelID="updpnlgvHR_DivisionSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvHR_DivisionSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnHR_DivisionRefresh" ClientIDMode="Static" OnClick="btnHR_DivisionRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvHR_DivisionSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Employee_htDivisionCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetHR_DivisionDetails('<%#Eval("DivisionCode")%>','<%#Eval("tbl_HR_DivisionId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvDivisionCode" Text='<%# Bind("DivisionCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Employee_htDescription%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Employee_htDivisionGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvHR_DivisionGuid" runat="server" Text='<%# Bind("tbl_HR_DivisionId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnHR_DivisionSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearHR_DivisionSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divHR_DivisionFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblHR_DivisionClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
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
                        <asp:Literal runat="server" ID="ltrHR_DepartmentTitle" Text="<%$ Resources:GlobalResource, Employee_ltrHR_Department%>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Employee_htDepartmentCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetHR_DepartmentDetails('<%#Eval("DepartmentCode")%>','<%#Eval("tbl_HR_DepartmentId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvDivisionCode" Text='<%# Bind("DepartmentCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Employee_htDescription%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Employee_htDepartmentGuid%>" Visible="false">
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

    <div class="modal fade" id="basicModalHR_PositionSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalHR_PositionTitle"><span>
                        <asp:Literal runat="server" ID="ltrHR_PositionTitle" Text="<%$ Resources:GlobalResource, Employee_ltrHR_Position%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlHR_Position">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlHR_Position" DefaultButton="btnHR_PositionSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtHR_PositionSearch" CssClass="form-control" placeholder="Search..." autofocus></asp:TextBox>
                                        <a runat="server" id="btnHtmlHR_PositionSearch" onclick="CallHR_PositionSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlHR_PositionClose" visible="false" onclick="ClearHR_PositionSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnHR_PositionSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnHR_PositionSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearHR_PositionSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearHR_PositionSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divHR_PositionSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblHR_PositionSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divHR_PositionSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblHR_PositionSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgHR_PositionData" AssociatedUpdatePanelID="updpnlgvHR_PositionSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvHR_PositionSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnHR_PositionRefresh" ClientIDMode="Static" OnClick="btnHR_PositionRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvHR_PositionSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Employee_htPositionCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetHR_PositionDetails('<%#Eval("PositionCode")%>','<%#Eval("tbl_HR_PositionId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvDivisionCode" Text='<%# Bind("PositionCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Employee_htDescription%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Employee_htPositionGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvHR_PositionGuid" runat="server" Text='<%# Bind("tbl_HR_PositionId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnHR_PositionSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearHR_PositionSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divHR_PositionFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblHR_PositionClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalHR_BranchSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalHR_BranchTitle"><span>
                        <asp:Literal runat="server" ID="ltrHR_BranchTitle" Text="<%$ Resources:GlobalResource, Employee_ltrHR_Branch%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlHR_Branch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlHR_Branch" DefaultButton="btnHR_BranchSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtHR_BranchSearch" CssClass="form-control" placeholder="Search..." autofocus></asp:TextBox>
                                        <a runat="server" id="btnHtmlHR_BranchSearch" onclick="CallHR_BranchSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlHR_BranchClose" visible="false" onclick="ClearHR_BranchSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnHR_BranchSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnHR_BranchSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearHR_BranchSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearHR_BranchSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divHR_BranchSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblHR_BranchSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divHR_BranchSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblHR_BranchSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgHR_BranchData" AssociatedUpdatePanelID="updpnlgvHR_BranchSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvHR_BranchSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnHR_BranchRefresh" ClientIDMode="Static" OnClick="btnHR_BranchRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvHR_BranchSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Employee_htBranchCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetHR_BranchDetails('<%#Eval("BranchCode")%>','<%#Eval("tbl_HR_BranchId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvDivisionCode" Text='<%# Bind("BranchCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Employee_htDescription%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Employee_htBranchGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvHR_BranchGuid" runat="server" Text='<%# Bind("tbl_HR_BranchId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnHR_BranchSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearHR_BranchSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divHR_BranchFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblHR_BranchClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalHR_SupervisorSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalHR_SupervisorTitle"><span>
                        <asp:Literal runat="server" ID="ltrHR_SupervisorTitle" Text="<%$ Resources:GlobalResource, Employee_ltrHR_Supervisor%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlHR_Supervisor">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlHR_Supervisor" DefaultButton="btnHR_SupervisorSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtHR_SupervisorSearch" CssClass="form-control" placeholder="Search..." autofocus></asp:TextBox>
                                        <a runat="server" id="btnHtmlHR_SupervisorSearch" onclick="CallHR_SupervisorSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlHR_SupervisorClose" visible="false" onclick="ClearHR_SupervisorSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnHR_SupervisorSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnHR_SupervisorSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearHR_SupervisorSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearHR_SupervisorSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divHR_SupervisorSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblHR_SupervisorSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divHR_SupervisorSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblHR_SupervisorSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgHR_SupervisorData" AssociatedUpdatePanelID="updpnlgvHR_SupervisorSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvHR_SupervisorSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnHR_SupervisorRefresh" ClientIDMode="Static" OnClick="btnHR_SupervisorRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvHR_SupervisorSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Employee_htSupervisorCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetHR_SupervisorDetails('<%#Eval("SupervisorCode")%>','<%#Eval("tbl_HR_SupervisorId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvDivisionCode" Text='<%# Bind("SupervisorCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Employee_htDescription%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Employee_htSupervisorGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvHR_SupervisorGuid" runat="server" Text='<%# Bind("tbl_HR_SupervisorId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnHR_SupervisorSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearHR_SupervisorSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divHR_SupervisorFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblHR_SupervisorClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalCountry_NationalitySearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalCountry_NationalityTitle"><span>
                        <asp:Literal runat="server" ID="ltrCountry_NationalityTitle" Text="<%$ Resources:GlobalResource, Employee_lblCountry_NationalityTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlCountry_NationalitySearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlCountry_NationalitySearch" DefaultButton="btnCountry_NationalitySearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtCountry_NationalitySearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlCountry_NationalitySearch" onclick="CallCountry_NationalitySearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlCountry_NationalityClose" visible="false" onclick="ClearCountry_NationalitySearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnCountry_NationalitySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnCountry_NationalitySearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearCountry_NationalitySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearCountry_NationalitySearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divCountry_NationalitySearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblCountry_NationalitySearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divCountry_NationalitySearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblCountry_NationalitySearchSuccess"></asp:Label>
                        </div>
                    </div>

                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateProgress1" AssociatedUpdatePanelID="updpnlgvCountry_NationalitySearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvCountry_NationalitySearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnCountry_NationalityRefresh" ClientIDMode="Static" OnClick="btnCountry_NationalityRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvCountry_NationalitySearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Employee_lblCountryCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCountry_NationalityDetails('<%#Eval("CountryName")%>','<%#Eval("tbl_CountryId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCountryCode" Text='<%# Bind("CountryCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Employee_lblCountryName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCountryName" runat="server" Text='<%# Bind("CountryName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Employee_lblCountry_NationalityGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCountryGuid" runat="server" Text='<%# Bind("tbl_CountryId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnCountry_NationalitySearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearCountry_NationalitySearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div1">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrCountry_NationalityClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>


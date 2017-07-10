<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EmployeeForm.aspx.cs" Inherits="Finance_Accounts_Payable_Employee_Supplier_Master_Creation_EmployeeForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Accounts_Payable_JS/Employee_Supplier_Master_Creation_JS/EmployeeForm.js"></script>
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
                            <asp:TextBox type="text" runat="server" ID="txtEmployeeCode" ClientIDMode="Static" class="form-control " placeholder="" required="required" ></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblName" Text="<%$ Resources:GlobalResource, Employee_lblName %>">></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtName" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblShortName" Text="<%$ Resources:GlobalResource, Employee_lblShortName %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtShortName" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblChequeName" Text="<%$ Resources:GlobalResource, Employee_lblChequeName %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtChequeName" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblContact" Text="<%$ Resources:GlobalResource, Employee_lblContact %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtContact" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAddress" Text="<%$ Resources:GlobalResource, Employee_lblAddress %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtAddress" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblCity" Text="<%$ Resources:GlobalResource, Employee_lblCity %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtCity" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                             <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCountry" Text="<%$ Resources:GlobalResource, Employee_lblCountry%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtCountry" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon2">
                                    <a href="#" data-toggle="modal" data-target="#basicModalCountrySearch" data-keyboard="false" data-backdrop="static" onclick="CallRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>
                                <asp:TextBox runat="server" ID="txtCountryGuid" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblZipCode" Text="<%$ Resources:GlobalResource, Employee_lblZipCode %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtZipCode" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                   

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPhone" Text="<%$ Resources:GlobalResource, Employee_lblPhone %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtPhone" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblMobile" Text="<%$ Resources:GlobalResource, Employee_lblMobile %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtMobile" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblFaxNo" Text="<%$ Resources:GlobalResource, Employee_lblFaxNo %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtFaxNo" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblEmail" Text="<%$ Resources:GlobalResource, Employee_lblEmail %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtEmail" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblComment1" Text="<%$ Resources:GlobalResource, Employee_lblComment1 %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtComment1" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblComment2" Text="<%$ Resources:GlobalResource, Employee_lblComment2 %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtComment2" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblEmployeeGroup" Text="<%$ Resources:GlobalResource, Employee_lblEmployeeGroup%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtEmployeeGroup" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>                                      
                                <span class="input-group-addon lookup" id="spnEmployeeGroup">
                                    <a href="#" data-toggle="modal" data-target="#basicModalEmployeeGroupSearch" data-keyboard="false" data-backdrop="static" onclick="CallEmployeeGroupRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>
                                <asp:TextBox runat="server" ID="txtEmployeeGroupGuid" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>


                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblStatus" Text="<%$ Resources:GlobalResource, Employee_lblStatus%>"></asp:Label>
                            <asp:DropDownList ID="ddlStatus" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOnHold" Text="<%$ Resources:GlobalResource, Employee_chkOnHold%>"></asp:Label>
                            <asp:CheckBox ID="chkOnHold" runat="server" ClientIDMode="Static" class="form-control " placeholder="" />
                        </div>


                        <div class="form-group col-md-8 col-sm-8">
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                        </div>

                        <div class="form-group col-md-8 col-sm-8">
                        </div>
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
                                                <a href="#" data-dismiss="modal" onclick="setCountryDetails('<%#Eval("CountryName")%>','<%#Eval("tbl_CountryId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCountryCode" Text='<%# Bind("CountryCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Employee_lblCountryName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCountryName" runat="server" Text='<%# Bind("CountryName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Country Guid" Visible="false">
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

    <div class="modal fade" id="basicModalEmployeeGroupSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalEmployeeGroupTitle"><span>
                        <asp:Literal runat="server" ID="ltrEmployeeGroupTitle" Text="<%$ Resources:GlobalResource, Employee_ltrEmployeeGroup%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlEmployeeGroup">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlEmployeeGroup" DefaultButton="btnEmployeeGroupSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtEmployeeGroupSearch" CssClass="form-control" placeholder="Search..." autofocus></asp:TextBox>
                                        <a runat="server" id="btnHtmlEmployeeGroupSearch" onclick="CallEmployeeGroupSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlEmployeeGroupClose" visible="false" onclick="ClearEmployeeGroupSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnEmployeeGroupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnEmployeeGroupSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearEmployeeGroupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearEmployeeGroupSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divEmployeeGroupSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblEmployeeGroupSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divEmployeeGroupSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblEmployeeGroupSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgEmployeeGroupData" AssociatedUpdatePanelID="updpnlgvEmployeeGroupSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvEmployeeGroupSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnEmployeeGroupRefresh" ClientIDMode="Static" OnClick="btnEmployeeGroupRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvEmployeeGroupSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Employee_lblEmployeeGroupName%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetEmployeeGroupDetails('<%#Eval("Description")%>','<%#Eval("tbl_EmployeeGroupId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvEmployeeGroupCode" Text='<%# Bind("Description") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Employee Group Guid" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvEmployeeGroupGuid" runat="server" Text='<%# Bind("tbl_EmployeeGroupId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnEmployeeGroupSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearEmployeeGroupSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divEmployeeGroupFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblEmployeeGroupClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


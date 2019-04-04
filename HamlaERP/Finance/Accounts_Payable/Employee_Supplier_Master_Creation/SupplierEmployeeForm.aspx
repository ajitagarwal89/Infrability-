﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SupplierEmployeeForm.aspx.cs" Inherits="Finance_Accounts_Payable_Employee_Supplier_Master_Creation_SupplierEmployeeForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Accounts_Payable_JS/Employee_Supplier_Master_Creation_JS/SupplierEmployeeForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, SupplierEmployee_ltrInformation%>"></asp:Literal></h5>
                        </div>
                          
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblSupplierEmployeeCode" Text="<%$ Resources:GlobalResource, SupplierEmployee_lblSupplierEmployeeCode %>"></asp:Label>
                            <asp:TextBox  runat="server" ID= "txtSupplierEmployeeCode" ClientIDMode="Static" ReadOnly="true" onkeypress="return isAlphaNumberKey(this);" MaxLength="20" class="form-control " placeholder="" required="required" ></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblName" Text="<%$ Resources:GlobalResource, SupplierEmployee_lblName %>">></asp:Label>
                            <asp:TextBox  runat="server" ID="txtName" ClientIDMode="Static" onkeypress="return isAlphaKey(this);" MaxLength="50" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblShortName" Text="<%$ Resources:GlobalResource, SupplierEmployee_lblShortName %>"></asp:Label>
                            <asp:TextBox  runat="server" ID="txtShortName" ClientIDMode="Static" onkeypress="return isAlphaKey(this);" MaxLength="20" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblChequeName" Text="<%$ Resources:GlobalResource, SupplierEmployee_lblChequeName %>"></asp:Label>
                            <asp:TextBox  runat="server" ID="txtChequeName" ClientIDMode="Static" onkeypress="return isAlphaKey(this);" MaxLength="50" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblContact" Text="<%$ Resources:GlobalResource, SupplierEmployee_lblContact %>"></asp:Label>
                            <asp:TextBox  runat="server" ID="txtContact" ClientIDMode="Static" onkeypress="return isNumberKey(this);" MaxLength="13" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAddress" Text="<%$ Resources:GlobalResource, SupplierEmployee_lblAddress %>"></asp:Label>
                            <asp:TextBox  runat="server" ID="txtAddress" ClientIDMode="Static" onkeypress="return isAddress(this);"  MaxLength="200" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblCity" Text="<%$ Resources:GlobalResource, SupplierEmployee_lblCity %>"></asp:Label>
                            <asp:TextBox  runat="server" ID="txtCity" ClientIDMode="Static" onkeypress="return isAlphaKey(this);"  MaxLength="50" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                             <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCountry" Text="<%$ Resources:GlobalResource, SupplierEmployee_ltrCountryTitle%>"></asp:Label>
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
                            <asp:Label runat="server" ID="lblZipCode" Text="<%$ Resources:GlobalResource, SupplierEmployee_lblZipCode %>"></asp:Label>
                            <asp:TextBox  runat="server" ID="txtZipCode" ClientIDMode="Static"  onkeypress="return isNumberKey(this);"  MaxLength="6" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                   

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPhone" Text="<%$ Resources:GlobalResource, SupplierEmployee_lblPhone %>"></asp:Label>
                            <asp:TextBox  runat="server" ID="txtPhone" ClientIDMode="Static" onkeypress="return isNumberKey(this);"  MaxLength="15" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblMobile" Text="<%$ Resources:GlobalResource, SupplierEmployee_lblMobile %>"></asp:Label>
                            <asp:TextBox  runat="server" ID="txtMobile" ClientIDMode="Static" onkeypress="return isNumberKey(this);"  MaxLength="13" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblFaxNo" Text="<%$ Resources:GlobalResource, SupplierEmployee_lblFaxNo %>"></asp:Label>
                            <asp:TextBox  runat="server" ID="txtFaxNo" ClientIDMode="Static" onkeypress="return isAlphaNumberKey(this);"  MaxLength="15"  class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblEmail" Text="<%$ Resources:GlobalResource, SupplierEmployee_lblEmail %>"></asp:Label>
                            <asp:TextBox  runat="server" ID="txtEmail" ClientIDMode="Static" TextMode="Email" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblComment1" Text="<%$ Resources:GlobalResource, SupplierEmployee_lblComment1 %>"></asp:Label>
                            <asp:TextBox  runat="server" ID="txtComment1" TextMode="MultiLine" ClientIDMode="Static" onkeypress="return isAddress(this);"  MaxLength="200" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblComment2" Text="<%$ Resources:GlobalResource, SupplierEmployee_lblComment2 %>"></asp:Label>
                            <asp:TextBox  runat="server" ID="txtComment2"  TextMode="MultiLine"  ClientIDMode="Static" onkeypress="return isAddress(this);"  MaxLength="200" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                      <div class="form-group col-md-4 col-sm-4">
                             <asp:Label runat="server" ID="lblStatus" Text="<%$ Resources:GlobalResource, SupplierEmployee_lblStatus%>"></asp:Label>
                            <asp:DropDownList ID="ddlStatus" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblSupplierEmployeeGroup" Text="<%$ Resources:GlobalResource, SupplierEmployee_lblSupplierEmployeeGroup %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtSupplierEmployeeGroup" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-SupplierEmployeeGroup">
                                    <a href="#" data-toggle="modal" data-target="#basicModalSupplierEmployeeGroupSearch" data-keyboard="false" data-backdrop="static" onclick="CallSupplierEmployeeGroupRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtSupplierEmployeeGroupGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOnHold" Text="<%$ Resources:GlobalResource, SupplierEmployee_chkOnHold%>"></asp:Label>
                            <asp:CheckBox ID="chkOnHold" runat="server" ClientIDMode="Static" class="form-control " placeholder="" />
                        </div>
                          <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblSupplierEmployeeAndGroupAccount" Text="<%$ Resources:GlobalResource, SupplierEmployee_lblSupplierEmployeeAndGroupAccount %>"></asp:Label>
                            </div>

                        <div class="input-group">
                                <asp:TextBox ID="txtSupplierEmployeeAndGroupAccount" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-SupplierEmployeeAndGroupAccount">
                                    <a href="#" data-toggle="modal" data-target="#basicModalSupplierEmployeeAndGroupAccountSearch" data-keyboard="false" data-backdrop="static" onclick="CallSupplierEmployeeAndGroupAccountRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtSupplierEmployeeAndGroupAccountGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                               </div>

                         <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblGLAccountId_Cash" Text="<%$ Resources:GlobalResource, SupplierAndGroupAccount_lblGLAccountId_Cash%>"></asp:Label>

                            <div class="input-group">
                                <asp:TextBox ID="txtGLAccountId_Cash" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon_GLAccountId_Cash">
                                    <a href="#" data-toggle="modal" data-target="#basicModalGLAccountId_CashSearch" data-keyboard="false" data-backdrop="static" onclick="CallCashRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountId_CashGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>                        
                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblAccountPayable" Text="<%$ Resources:GlobalResource, SupplierEmployeeAndGroupAccount_lblAccountPayable%>"></asp:Label>

                            <div class="input-group">
                                <asp:TextBox ID="txtAccountPayable" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon_AccountPayable">
                                     <a href="#" data-toggle="modal" data-target="#basicModaltAccountPayableSearch" data-keyboard="false" data-backdrop="static" onclick="CallAccountPayableRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtAccountPayableGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblPurchase" Text="<%$ Resources:GlobalResource, SupplierEmployeeAndGroupAccount_lblPurchase%>"></asp:Label>

                            <div class="input-group">

                                <asp:TextBox ID="txtPurchase" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon_Purchase">
                                    <a href="#" data-toggle="modal" data-target="#basicModalPurchaseSearch" data-keyboard="false" data-backdrop="static" onclick="CallPurchaseRefreshButton();" ">
                                        <i class="fa fa-search"></i></a>

                                </span>
                                <asp:TextBox ID="txtPurchaseGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblTradeDiscount" Text="<%$ Resources:GlobalResource, SupplierEmployeeAndGroupAccount_lblTradeDiscount%>"></asp:Label>

                            <div class="input-group">
                                <asp:TextBox ID="txtTradeDiscount" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon_TradeDiscount">
                                    <a href="#" data-toggle="modal" data-target="#basicModalTradeDiscountearch" data-keyboard="false" data-backdrop="static" onclick="CallTradeDiscountRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtTradeDiscountGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblFeight" Text="<%$ Resources:GlobalResource, SupplierAndGroupAccount_lblFeight%>"></asp:Label>

                            <div class="input-group">
                                <asp:TextBox ID="txtFeight" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon_Freight">
                                    <a href="#" data-toggle="modal" data-target="#basicModalFreightSearch" data-keyboard="false" data-backdrop="static" onclick="CallFreightRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtFreightGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblAccruedPurchase" Text="<%$ Resources:GlobalResource, SupplierEmployeeAndGroupAccount_lblAccruedPurchase%>"></asp:Label>

                            <div class="input-group">
                                <asp:TextBox ID="txtAccruedPurchase" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon_AccruedPurchase">
                                    <a href="#" data-toggle="modal" data-target="#basicModalAccruedPurchasetSearch" data-keyboard="false" data-backdrop="static" onclick="CallAccruedPurchaseRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtAccruedPurchaseguid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
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
                        <asp:Literal runat="server" ID="ltrCountryTitle" Text="<%$ Resources:GlobalResource, SupplierEmployee_ltrCountryTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlCountrySearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlCountrySearch" DefaultButton="btnCountrySearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtCountrySearch" CssClass="form-control" placeholder="Search..." autofocus=""></asp:TextBox>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, SupplierEmployee_htCountryCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="setCountryDetails('<%#Eval("CountryName")%>','<%#Eval("tbl_CountryId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCountryCode" Text='<%# Bind("CountryCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, SupplierEmployee_htCountryName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCountryName" runat="server" Text='<%# Bind("CountryName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, SupplierEmployee_htCountryGuid%>" Visible="false">
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

  
    <div class="modal fade" id="basicModalSupplierEmployeeGroupSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalSupplierEmployeeGroupTitle"><span>
                        <asp:Literal runat="server" ID="ltrSupplierEmployeeGroupTitle" Text="<%$ Resources:GlobalResource, SupplierEmployee_ltrSupplierEmployeeGroupTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlSupplierEmployeeGroupSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlSupplierEmployeeGroupSearch" DefaultButton="btnSupplierEmployeeGroupSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtSupplierEmployeeGroupSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlSupplierEmployeeGroupSearch" onclick="CallSupplierEmployeeGroupSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlSupplierEmployeeGroupClose" visible="false" onclick="ClearSupplierEmployeeGroupSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnSupplierEmployeeGroupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnSupplierEmployeeGroupSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearSupplierEmployeeGroupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearSupplierEmployeeGroupSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divSupplierEmployeeGroupSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblSupplierEmployeeGroupSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divSupplierEmployeeGroupSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblSupplierEmployeeGroupSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgSupplierEmployeeGroupData" AssociatedUpdatePanelID="updpnlgvSupplierEmployeeGroupSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvSupplierEmployeeGroupSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnSupplierEmployeeGroupRefresh" ClientIDMode="Static" OnClick="btnSupplierEmployeeGroupRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvSupplierEmployeeGroupSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, SupplierEmployee_htSupplierEmployeeGroup%>">
                                            <ItemTemplate>
                                                 <a href="#" data-dismiss="modal" onclick="SetSupplierEmployeeGroupDetails('<%#Eval("Description")%>','<%#Eval("tbl_SupplierEmployeeGroupId")%>');">
                                                   
                                               <asp:Literal runat="server" ID="ltrgvSupplierEmployeeGroupType" Text='<%# Bind("Description") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, SupplierEmployee_htSupplierEmployeeGroupGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvSupplierEmployeeGroupGuid" runat="server" Text='<%# Bind("tbl_SupplierEmployeeGroupId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnSupplierEmployeeGroupSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearSupplierEmployeeGroupSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divSupplierEmployeeGroupFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrSupplierEmployeeGroupClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalSupplierEmployeeAndGroupAccountSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalSupplierEmployeeAndGroupAccountTitle"><span>
                        <asp:Literal runat="server" ID="ltrSupplierEmployeeAndGroupAccountTitle" Text="<%$ Resources:GlobalResource, SupplierEmployee_ltrSupplierEmployeeAndGroupAccountTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlSupplierEmployeeAndGroupAccountSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlSupplierEmployeeAndGroupAccountSearch" DefaultButton="btnSupplierEmployeeAndGroupAccountSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtSupplierEmployeeAndGroupAccountSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlSupplierEmployeeAndGroupAccountSearch" onclick="CallSupplierEmployeeAndGroupAccountSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlSupplierEmployeeAndGroupAccountClose" visible="false" onclick="ClearSupplierEmployeeAndGroupAccountSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnSupplierEmployeeAndGroupAccountSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnSupplierEmployeeAndGroupAccountSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearSupplierEmployeeAndGroupAccountSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearSupplierEmployeeAndGroupAccountSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divSupplierEmployeeAndGroupAccountSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblSupplierEmployeeAndGroupAccountSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divSupplierEmployeeAndGroupAccountSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblSupplierEmployeeAndGroupAccountSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgSupplierEmployeeAndGroupAccountData" AssociatedUpdatePanelID="updpnlgvSupplierEmployeeAndGroupAccountSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvSupplierEmployeeAndGroupAccountSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnSupplierEmployeeAndGroupAccountRefresh" ClientIDMode="Static" OnClick="btnSupplierEmployeeAndGroupAccountRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvSupplierEmployeeAndGroupAccountSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, SupplierEmployee_htSupplierEmployeeAndGroupAccount%>">
                                            <ItemTemplate>
                                                 <a href="#" data-dismiss="modal" onclick="SetSupplierEmployeeAndGroupAccountDetails('<%#Eval("Description")%>','<%#Eval("tbl_SupplierEmployeeAndGroupAccountId")%>');">
                                                   
                                               <asp:Literal runat="server" ID="ltrgvSupplierEmployeeAndGroupAccountType" Text='<%# Bind("Description") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, SupplierEmployee_htSupplierEmployeeAndGroupAccountGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvSupplierEmployeeAndGroupAccountGuid" runat="server" Text='<%# Bind("tbl_SupplierEmployeeAndGroupAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnSupplierEmployeeAndGroupAccountSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearSupplierEmployeeAndGroupAccountSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divSupplierEmployeeAndGroupAccountFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrSupplierEmployeeAndGroupAccountlClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    
        <%-- Modal Popup for basicModalGLAccountId_CashSearch ----%>

    <div class="modal fade" id="basicModalGLAccountId_CashSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGLAccountId_CashTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountId_CashTitle" Text="<%$ Resources:GlobalResource, SupplierEmployee_ltrCashAccountInformation%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlGLAccountId_Cash">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlGLAccountId_Cash" DefaultButton="btnAccountCashSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtGLAccountId_CashSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlGLAccountId_CashSearch" onclick="CallCashSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlGLAccountId_CashClose" visible="false" onclick="ClearCashSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>

                                <asp:Button runat="server" ID="btnAccountCashSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAccountCashSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearAccountCashSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearAccountCashSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountId_CashSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_CashSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountId_CashSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_CashSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgGLAccountId_CashData" AssociatedUpdatePanelID="updpnlgvGLAccountId_CashSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountId_CashSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnAccountCashRefresh" ClientIDMode="Static" OnClick="btnAccountCashRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvGLAccountId_CashSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,SupplierEmployee_htAccountNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCashDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvGLAccountId_CashCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, SupplierEmployee_htGLAccountIdCashGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvGLAccountId_CashGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnAccountCashSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearAccountCashSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divGLAccountId_CashFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblGLAccountId_CashClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%-- Modal Popup for basicModaltAccountPayableSearch ----%>

    <div class="modal fade" id="basicModaltAccountPayableSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModaltAccountPayableTitle"><span>
                        <asp:Literal runat="server" ID="ltrtAccountPayableTitle" Text="<%$ Resources:GlobalResource, SupplierEmployee_ltrAccountPayableInformation%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlAccountPayable">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlAccountPayable" DefaultButton="btnAccountPayableSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtAccountPayableSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlAccountPayableSearch" onclick="CallAccountPayableSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlAccountPayableClose" visible="false" onclick="CleaAccountPayableSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnAccountPayableSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAccountPayableSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearAccountPayableSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearAccountPayableSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divAccountPayableSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblAccountPayableSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divAccountPayableSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblAccountPayableSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgAccountPayableData" AssociatedUpdatePanelID="updpnlgvAccountPayableSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvAccountPayableSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnAccountPayableRefresh" ClientIDMode="Static" OnClick="btnAccountPayableRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvAccountPayableSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,SupplierEmployee_htAccountNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetAccountPayableDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvAccountPayableCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, SupplierEmployee_htAccountPayableGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvAccountPayableGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnAccountPayableSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearAccountPayableSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divAccountPayableFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblAccountPayableClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%-- Modal Popup for basicModalPurchaseSearch ----%>

    <div class="modal fade" id="basicModalPurchaseSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalPurchaseTitle"><span>
                        <asp:Literal runat="server" ID="ltrPurchaseTitle" Text="<%$ Resources:GlobalResource, SupplierEmployee_ltrPurchaseInformation%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlPurchase">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlPurchase" DefaultButton="btnPurchaseSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtPurchaseSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlPurchaseSearch" onclick="CallPurchaseSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlPurchaseClose" visible="false" onclick="ClearPurchaseSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnPurchaseSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnPurchaseSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearPurchaseSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearPurchaseSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divPurchaseSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblPurchaseSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divPurchaseSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblPurchaseSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgPurchaseData" AssociatedUpdatePanelID="updpnlgvPurchaseSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvPurchaseSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnPurchaseRefresh" ClientIDMode="Static" OnClick="btnPurchaseRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvPurchaseSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, SupplierEmployee_htAccountNumber%>">
                                            <ItemTemplate>

                                                <a href="#" data-dismiss="modal" onclick="SetPurchaseDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvPurchaseCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, SupplierEmployee_htPurchaseGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPurchaseGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPurchaseSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearPurchaseSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="diPurchaseFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblPurchaseClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%-- Modal Popup for basicModalTradeDiscountearch ----%>

    <div class="modal fade" id="basicModalTradeDiscountearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalTradeDiscountTitle"><span>
                        <asp:Literal runat="server" ID="ltrTradeDiscountTitle" Text="<%$ Resources:GlobalResource, SupplierEmployee_ltrTradeDiscountInformation%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlTradeDiscount">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlTradeDiscount" DefaultButton="btnTradeDiscountSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtTradeDiscountSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlTradeDiscountSearch" onclick="CallSupplierEmployeeGroupSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlTradeDiscountClose" visible="false" onclick="ClearTradeDiscountSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnTradeDiscountSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnTradeDiscountSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearTradeDiscountSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearTradeDiscountSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divTradeDiscountSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblTradeDiscountSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divTradeDiscountSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblTradeDiscountSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgTradeDiscountData" AssociatedUpdatePanelID="updpnlgvTradeDiscountSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvTradeDiscountSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnTradeDiscountRefresh" ClientIDMode="Static" OnClick="btnTradeDiscountRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvTradeDiscountSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, SupplierEmployee_htAccountNumber%>">
                                            <ItemTemplate>

                                                <a href="#" data-dismiss="modal" onclick="SetTradeDiscountDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvTradeDiscountCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, SupplierEmployee_htTradeDiscountGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvTradeDiscountGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnTradeDiscountSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearTradeDiscountSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divTradeDiscountFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblTradeDiscountClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- Modal Popup for basicModalFreightSearch ----%>

    <div class="modal fade" id="basicModalFreightSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalFreightTitle"><span>
                        <asp:Literal runat="server" ID="ltrFreightInformation" Text="<%$ Resources:GlobalResource, SupplierEmployee_ltrFreightInformation%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlFreight">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlFreight" DefaultButton="btnFreightSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtFreightSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlFreightSearch" onclick="CallFreightSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlFreightClose" visible="false" onclick="ClearFreightSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnFreightSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnFreightSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearFreightSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearFreightSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divFreightSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblFreightSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divFreightSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblFreightSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgFreightData" AssociatedUpdatePanelID="updpnlgvFreightSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvFreightSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnFreightRefresh" ClientIDMode="Static" OnClick="btnFreightRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvFreightSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,SupplierEmployee_htAccountNumber%>">
                                            <ItemTemplate>

                                                <a href="#" data-dismiss="modal" onclick="SetFreightDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvFreightCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, SupplierEmployee_htFreightGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvFreightGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnFreightSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearFreightSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFreightFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblFreightClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- Modal Popup for basicModalAccruedPurchaseSearch ----%>

    <div class="modal fade" id="basicModalAccruedPurchasetSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalAccruedPurchaseTitle"><span>
                        <asp:Literal runat="server" ID="ltrAccruedPurchaseTitlep" Text="<%$ Resources:GlobalResource, SupplierEmployee_ltrAccruedPurchaseInformation%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlAccruedPurchaseGroup">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlAccruedPurchase" DefaultButton="btnAccruedPurchaseSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtAccruedPurchaseSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlAccruedPurchaseSearch" onclick="CallAccruedPurchaseSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlAccruedPurchaseClose" visible="false" onclick="ClearAccruedPurchaseSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnAccruedPurchaseSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAccruedPurchaseSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearAccruedPurchaseSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearAccruedPurchaseSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divAccruedPurchaseSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblAccruedPurchaseSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divAccruedPurchaseSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblAccruedPurchaseSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgAccruedPurchaseData" AssociatedUpdatePanelID="updpnlgAccruedPurchaseSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgAccruedPurchaseSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnAccruedPurchaseRefresh" ClientIDMode="Static" OnClick="btnAccruedPurchaseRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvAccruedPurchaseSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,SupplierEmployee_htAccountNumber%>">
                                            <ItemTemplate>

                                                <a href="#" data-dismiss="modal" onclick="SetAccruedPurchaseDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrAccruedPurchaseCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$  Resources:GlobalResource,SupplierEmployee_htAccruedPurchaseGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvAccruedPurchaseGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnAccruedPurchaseSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearAccruedPurchaseSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divAccruedPurchaseFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblAccruedPurchaseClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CustomerForm.aspx.cs" Inherits="Finance_Accounts_Receivable_Customer_Master_Creation_CustomerForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Accounts_Receivable_JS/Customer_Master_Creation_JS/CustomerForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, Customer_ltrInformation%>"></asp:Literal></h5>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblCustomerCode" Text="<%$ Resources:GlobalResource, Customer_lblCustomerCode %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtCustomerCode" ClientIDMode="Static" onkeypress="return isAlphaNumberKey(this);" MaxLength="20" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblName" Text="<%$ Resources:GlobalResource, Customer_lblName %>">></asp:Label>
                            <asp:TextBox runat="server" ID="txtName" ClientIDMode="Static" onkeypress="return isAlphaKey(this);" MaxLength="50" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblShortName" Text="<%$ Resources:GlobalResource, Customer_lblShortName %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtShortName" ClientIDMode="Static" onkeypress="return isAlphaKey(this);" MaxLength="50" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblStatementName" Text="<%$ Resources:GlobalResource, Customer_lblStatementName %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtStatementName" ClientIDMode="Static" onkeypress="return isAlphaKey(this);" MaxLength="50" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblContact" Text="<%$ Resources:GlobalResource, Customer_lblContact %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtContact" ClientIDMode="Static" onkeypress="return isNumberKey(this);" MaxLength="13" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAddress" Text="<%$ Resources:GlobalResource, Customer_lblAddress %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtAddress" ClientIDMode="Static" onkeypress="return isAddress(this);" MaxLength="200" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblCity" Text="<%$ Resources:GlobalResource, Customer_lblCity %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtCity" ClientIDMode="Static" onkeypress="return isAlphaKey(this);" MaxLength="50"  class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCountry" Text="<%$ Resources:GlobalResource, Customer_lblCountry%>"></asp:Label>
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
                            <asp:Label runat="server" ID="lblZipCode" Text="<%$ Resources:GlobalResource, Customer_lblZipCode %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtZipCode" ClientIDMode="Static"  onkeypress="return isNumberKey(this);" MaxLength="6"  class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                        

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPhone" Text="<%$ Resources:GlobalResource, Customer_lblPhone %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtPhone" ClientIDMode="Static" onkeypress="return isNumberKey(this);" MaxLength="15" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblMobile" Text="<%$ Resources:GlobalResource, Customer_lblMobile %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtMobile" ClientIDMode="Static" onkeypress="return isNumberKey(this);" MaxLength="13" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblFaxNo" Text="<%$ Resources:GlobalResource, Customer_lblFaxNo %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtFaxNo" ClientIDMode="Static" onkeypress="return isAlphaNumberKey(this);" MaxLength="15" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblEmail" Text="<%$ Resources:GlobalResource, Customer_lblEmail %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtEmail" ClientIDMode="Static" TextMode="Email" class="form-control"  placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblComment1" Text="<%$ Resources:GlobalResource, Customer_lblComment1 %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtComment1" ClientIDMode="Static" onkeypress="return isAddress(this);" MaxLength="200"  class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblComment2" Text="<%$ Resources:GlobalResource, Customer_lblComment2 %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtComment2" ClientIDMode="Static" onkeypress="return isAddress(this);" MaxLength="200" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCustomerGroup" Text="<%$ Resources:GlobalResource, Customer_lblCustomerGroup%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtCustomerGroup" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="spnCustomerGroup">
                                    <a href="#" data-toggle="modal" data-target="#basicModalCustomerGroupSearch" data-keyboard="false" data-backdrop="static" onclick="CallCustomerGroupRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>
                                <asp:TextBox runat="server" ID="txtCustomerGroupGuid" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-8 col-sm-8">
                            <div class="form-group col-md-4 col-sm-4">
                                <asp:Label runat="server" ID="lblStatus" Text="<%$ Resources:GlobalResource, Customer_lblStatus%>"></asp:Label>
                                <asp:DropDownList ID="ddlStatus" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                                </asp:DropDownList>
                            </div>

                            <div class="form-group col-md-4 col-sm-4">
                                <asp:Label runat="server" ID="lblOnHold" Text="<%$ Resources:GlobalResource, Customer_chkOnHold%>"></asp:Label>
                                <asp:CheckBox ID="chkOnHold" runat="server" Checked="false" ClientIDMode="Static" class="form-control" placeholder="" required="required"  />
                            </div>
                        </div>
                                              
                            <div class="form-group col-md-4 col-sm-4">
                                     <div >
                                    <asp:Label runat="server" ID="lblGLAccountId_Cash" Text="<%$ Resources:GlobalResource, CustomerAndGroupAccount_lblCash%>"></asp:Label>
                                </div>
                                  <div class=" input-group">
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
                                <div >
                                    <asp:Label runat="server" ID="lblAccountReceivable" Text="<%$ Resources:GlobalResource, CustomerAndGroupAccount_lblAccountReceivable%>"></asp:Label>
                                </div>
                                  <div class=" input-group">
                                    <asp:TextBox ID="txtAccountReceivable" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon lookup" id="sizing-addon_AccountReceivable">
                                        <a href="#" data-toggle="modal" data-target="#basicModalAccountReceivableSearch" data-keyboard="false" data-backdrop="static" onclick="CallAccountReceivableRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                    </span>

                                    <asp:TextBox ID="txtAccountReceivableGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                                </div>
                            </div>                                                                       
                            <div class="form-group col-md-4 col-sm-4">
                                <div >
                                    <asp:Label runat="server" ID="lblSales" Text="<%$ Resources:GlobalResource, CustomerAndGroupAccount_lblSales%>"></asp:Label>
                                </div>
                                <div class="input-group">
                                     <asp:TextBox ID="txtSales" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                  <span class="input-group-addon lookup" id="sizing-addon_Sales">
                                      <a href="#" data-toggle="modal" data-target="#basicModalSalesSearch" data-keyboard="false" data-backdrop="static" onclick="CallSalesRefreshButton();" ">
                                        <i class="fa fa-search"></i></a></span>
                                    <asp:TextBox ID="txtSalesGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                             </div>
                                                         </div>
                        
                                                      
                           <div class="form-group col-md-4 col-sm-4">
                                <div >
                                    <asp:Label runat="server" ID="lblCostOfSales" Text="<%$ Resources:GlobalResource, CustomerAndGroupAccount_lblCostOfSales%>"></asp:Label>
                                </div>
                                <div class="input-group">
                                    <asp:TextBox ID="txtCostOfSales" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon lookup" id="sizing-addon_TradeDiscount">
                                         <a href="#" data-toggle="modal" data-target="#basicModalCostOfSalesSearch" data-keyboard="false" data-backdrop="static" onclick="CallCostOfSalesRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                    </span>

                                    <asp:TextBox ID="txtCostOfSalesGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                                </div>
                            </div>                  
                           <div class="form-group col-md-4 col-sm-4">
                                <div >
                                    <asp:Label runat="server" ID="lblInventory" Text="<%$ Resources:GlobalResource, CustomerAndGroupAccount_lblInventory%>"></asp:Label>
                                </div>
                                <div class="input-group">
                                    <asp:TextBox ID="txtInventory" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon lookup" id="sizing-addon_Inventory">
                                        <a href="#" data-toggle="modal" data-target="#basicModalInventorySearch" data-keyboard="false" data-backdrop="static" onclick="CallInventoryRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                    </span>

                                    <asp:TextBox ID="txtInventoryGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                                </div>
                            </div>
                           <div class="form-group col-md-4 col-sm-4">
                                <div >
                                    <asp:Label runat="server" ID="lblAccuralDifferedA_C" Text="<%$ Resources:GlobalResource, CustomerAndGroupAccount_lblAccuralDifferedA_C%>"></asp:Label>
                                </div>
                                <div class="input-group">
                                    <asp:TextBox ID="txtAccuralDifferedA_C" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon lookup" id="sizing-addon_AccuralDifferedA_C">
                                         <a href="#" data-toggle="modal" data-target="#basicModalAccuralDifferedA_CsetSearch" data-keyboard="false" data-backdrop="static" onclick="CallAccuralDifferedA_CRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                    </span>

                                    <asp:TextBox ID="txtAccuralDifferedA_CGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                                </div>
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
                        <asp:Literal runat="server" ID="ltrCountryTitle" Text="<%$ Resources:GlobalResource, Customer_lblCountry %>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Customer_lblCountryCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCountryDetails('<%#Eval("CountryName")%>','<%#Eval("tbl_CountryId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCountryCode" Text='<%# Bind("CountryCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Customer_lblCountryName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCountryName" runat="server" Text='<%# Bind("CountryName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Customer_lblCountryGuid%>" Visible="false">
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

    <div class="modal fade" id="basicModalCustomerGroupSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalCustomerGroupTitle"><span>
                        <asp:Literal runat="server" ID="ltrCustomerGroupTitle" Text="<%$ Resources:GlobalResource, Customer_lblCustomerGroup%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlCustomerGroup">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlCustomerGroup" DefaultButton="btnCustomerGroupSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtCustomerGroupSearch" CssClass="form-control" placeholder="Search..." autofocus></asp:TextBox>
                                        <a runat="server" id="btnHtmlCustomerGroupSearch" onclick="CallCustomerGroupSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlCustomerGroupClose" visible="false" onclick="ClearCustomerGroupSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnCustomerGroupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnCustomerGroupSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearCustomerGroupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearCustomerGroupSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divCustomerGroupSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblCustomerGroupSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divCustomerGroupSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblCustomerGroupSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgCustomerGroupData" AssociatedUpdatePanelID="updpnlgvCustomerGroupSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvCustomerGroupSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnCustomerGroupRefresh" ClientIDMode="Static" OnClick="btnCustomerGroupRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvCustomerGroupSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Customer_lblCustomerGroupName%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCustomerGroupDetails('<%#Eval("Description")%>','<%#Eval("tbl_CustomerGroupId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCustomerGroupCode" Text='<%# Bind("Description") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Customer_lblCustomerGroupGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCustomerGroupGuid" runat="server" Text='<%# Bind("tbl_CustomerGroupId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnCustomerGroupSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearCustomerGroupSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divCustomerGroupFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblCustomerGroupClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

     <%-- Modal Popup for basicModalGLAccountId_CashSearch --%>

    <div class="modal fade" id="basicModalGLAccountId_CashSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGLAccountId_CashTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountId_CashTitle" Text="<%$ Resources:GlobalResource, Customer_ltrGLAccountIdCashInformation%>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Customer_ht_CashAccount%>">
                                            <ItemTemplate>
                                                 <a href="#" data-dismiss="modal" onclick="SetCashDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvGLAccountId_CashCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Customer_htGLAccountId_CashGuid%>" Visible="false">
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

<%--- Modal Popup for basicModalAccountReceivableSearch Search ----%>

    <div class="modal fade" id="basicModalAccountReceivableSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalAccountReceivableTitle"><span>
                        <asp:Literal runat="server" ID="ltrAccountReceivableTitle" Text="<%$ Resources:GlobalResource, Customer_ltrAccountReceivableInformation%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel runat="server" ID="updpnlAccountReceivable">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlAccountReceivable" DefaultButton="btnAccountReceivableSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtAccountReceivableSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlAccountReceivableSearch" onclick="CallAccountReceivableSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlAccountReceivableClose" visible="false" onclick="ClearAccountReceivableSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnAccountReceivableSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAccountReceivableSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearAccountReceivableSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearAccountReceivableSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divAccountReceivableSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblAccountReceivableSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divAccountReceivableSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblAccountReceivableSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgAccountReceivableeData" AssociatedUpdatePanelID="updpnlgvAccountReceivableSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvAccountReceivableSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnAccountReceivableRefresh" ClientIDMode="Static" OnClick="btnAccountReceivableRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvAccountReceivableSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,Customer_htAccountNumber %>">
                                            <ItemTemplate>                                                
                                                 <a href="#" data-dismiss="modal" onclick="SetAccountReceivableDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvAccountReceivableCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:GlobalResource,Customer_htAccountReceivableGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvAccountReceivableGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnAccountReceivableSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearAccountReceivableSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divAccountReceivableFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblAccountReceivableClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
       <%--    Modal Popup for basicModalSalesSearch ----%>

    <div class="modal fade" id="basicModalSalesSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalSalesTitle"><span>
                        <asp:Literal runat="server" ID="ltrSalesTitle" Text="<%$ Resources:GlobalResource, Customer_ltrSalesInformation%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlSales">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlSales" DefaultButton="btnSalesSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtSalesSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlSalesSearch" onclick="CallSalesSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlSalesClose" visible="false" onclick="ClearSalesSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnSalesSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnSalesSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearSalesSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearSalesSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divSalesSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblSalesSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divSalesSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblSalesSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgSalesData" AssociatedUpdatePanelID="updpnlgvSalesSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvSalesSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnSalesRefresh" ClientIDMode="Static" OnClick="btnSalesRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvSalesSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Customer_htSales%>">
                                            <ItemTemplate>                                               

                                                <a href="#" data-dismiss="modal" onclick="SetSalesDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvSalesCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Customer_htSalesGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvSalesGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnSalesSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearSalesSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divSalesFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblSalesClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
       <%--Modal Popup for basicModalCostOfSalesSearch --%>

    <div class="modal fade" id="basicModalCostOfSalesSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalCostOfSalesTitle"><span>
                        <asp:Literal runat="server" ID="ltrCostOfSalesTitle" Text="<%$ Resources:GlobalResource, Customer_ltrCostOfSalesInformation%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlCostOfSales">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlCostOfSales" DefaultButton="btnCostOfSalesSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtCostOfSalesSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlCostOfSalesSearch" onclick="CallCostOfSalesSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlCostOfSalesClose" visible="false" onclick="ClearCostOfSalesSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnCostOfSalesSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnCostOfSalesSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearCostOfSalesSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearCostOfSalesSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divCostOfSalesSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblCostOfSalesSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divCostOfSalesSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblCostOfSalesSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgCostOfSalesData" AssociatedUpdatePanelID="updpnlgvCostOfSalesSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvCostOfSalesSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnCostOfSalesRefresh" ClientIDMode="Static" OnClick="btnCostOfSalesRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvCostOfSalesSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Customer_htCostOfSales%>">
                                            <ItemTemplate>                                             

                                                 <a href="#" data-dismiss="modal" onclick="SetCostOfSalesDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCostOfSales" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<Resources:GlobalResource, Customer_htCostOfSalesGuid>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCostOfSalesGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnCostOfSalesSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearCostOfSalesSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divCostOfSalesFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblCostOfSalesClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
      <%--  Modal Popup for basicModaInventory --%>

<div class="modal fade" id="basicModalInventorySearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModaInventoryTitle"><span>
                        <asp:Literal runat="server" ID="ltrInventoryTitle" Text="<%$ Resources:GlobalResource, Customer_ltrGLAccountIdInventoryInformation%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlInventory">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlInventory" DefaultButton="btnInventorySearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtInventorySearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlInventorySearch" onclick="CallInventorySearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlInventoryClose" visible="false" onclick="ClearInventorySearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnInventorySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnInventorySearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearInventorySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearInventorySearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divInventorySearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblInventorySearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divInventorySearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblInventorySearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgInventoryData" AssociatedUpdatePanelID="updpnlgvInventorySearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvInventorySearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnInventoryRefresh" ClientIDMode="Static" OnClick="btnInventoryRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvInventorySearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,Customer_htInventoryAccount%>">
                                            <ItemTemplate>                                              

                                                 <a href="#" data-dismiss="modal" onclick="SetInventoryDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvInventoryInventoryCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:GlobalResource,Customer_htInventoryAccountGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvInventoryGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnInventorySearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearInventorySearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divInventoryFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblInventoryClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>     


<%--   Modal Popup for basicModalAccuralDifferedA_CsetSearch   --%>

   <div class="modal fade" id="basicModalAccuralDifferedA_CsetSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalAccuralDifferedA_CTitle"><span>
                        <asp:Literal runat="server" ID="ltrAccuralDifferedA_CTitle" Text="<%$ Resources:GlobalResource, Customer_ltrAccuralDifferedA_CInformation%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlAccuralDifferedA_C">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlAccuralDifferedA_C" DefaultButton="btnAccuralDifferedA_CSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtAccuralDifferedA_CSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlAccuralDifferedA_CSearch" onclick="CallAccuralDifferedA_CSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlAccuralDifferedA_CClose" visible="false" onclick="ClearAccuralDifferedA_CSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnAccuralDifferedA_CSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAccuralDifferedA_CSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearAccuralDifferedA_CSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearAccuralDifferedA_CSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divAccuralDifferedA_CSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblAccuralDifferedA_CSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divAccuralDifferedA_CSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblAccuralDifferedA_CSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgAccuralDifferedA_CData" AssociatedUpdatePanelID="updpnlgAccuralDifferedA_CSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgAccuralDifferedA_CSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnAccuralDifferedA_CRefresh" ClientIDMode="Static" OnClick="btnAccuralDifferedA_CRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvAccuralDifferedA_CSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,Customer_htAccuralDifferedA_C%>">
                                            <ItemTemplate>                                                

                                                  <a href="#" data-dismiss="modal" onclick="SetAccuralDifferedA_CDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrAccuralDifferedA_CCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:GlobalResource,Customer_htAccuralDifferedA_CGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvAccuralDifferedA_CGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnAccuralDifferedA_CSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearAccuralDifferedA_CSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divAccuralDifferedA_CFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblAccuralDifferedA_CClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
   
   
</asp:Content>


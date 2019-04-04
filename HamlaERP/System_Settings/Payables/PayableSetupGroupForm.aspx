<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PayableSetupGroupForm.aspx.cs" Inherits="Finance_Accounts_Payable_Setup_PayableSetupGroupForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../../infra_ui/js/System_Settings_JS/Payables_JS/PayableSetupGroupForm.js"></script>
    <script src="../../../infra_ui/js/CommonJS/CommonValidations.js"></script>
      
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <!--page header start-->
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success"  Text="<%$ Resources:GlobalResource, btnSave%>" OnClick="btnSave_Click"  />
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-success"  Text="<%$ Resources:GlobalResource, btnUpdate%>" OnClick="btnUpdate_Click"  />
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-success"  Text="<%$ Resources:GlobalResource, btnDelete%>" OnClick="btnDelete_Click"  />
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-success"  Text="<%$ Resources:GlobalResource, btnBack%>"  formnovalidate="formnovalidate" OnClick="btnBack_Click" />
                    <asp:Button runat="server" ID="btnClear" CssClass="btn btn-success" OnClientClick="return ClearForm();" Text="<%$ Resources:GlobalResource, btnClear%>" formnovalidate="formnovalidate" ></asp:Button>
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
                               <asp:Literal runat="server" ID="ltrPayableSetupGroupInformation" Text="<%$ Resources:GlobalResource, PayableSetupGroup_ltrPayableSetupGroupInformation%>"></asp:Literal></h5>
                        </div>
                   <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblPayableSetupId" Text="<%$ Resources:GlobalResource, PayableSetupGroup_lblPayableSetupId %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtPayableSetup" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addonPayableSetup">
                                    <a href="#" data-toggle="modal" data-target="#basicModalPayableSetupSearch" data-keyboard="false" data-backdrop="static" onclick="CallPayableSetupRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPayableSetupGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                    <div class="form-group col-md-4 col-sm-4">
                    <div>
                        <asp:Label runat="server" ID="lblGroupID" Text="<%$ Resources:GlobalResource, PayableSetupGroup_lblGroupID%>"></asp:Label>
                    </div>
                    <div class="input-group">
                        <asp:TextBox ID="txtGroupID" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                        <span class="input-group-addon lookup" id="sizing-addonPayableSetupGroup">
                            <a href="#" data-toggle="modal" data-target="#basicModalPayableSetupGroupSearch" data-keyboard="false" data-backdrop="static" onclick="CallPayableSetupGroupRefreshButton();">
                                <i class="fa fa-search"></i></a>
                        </span>

                        <asp:TextBox ID="txtGroupIDGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                    </div>
                
                 </div>
                
                <div class="form-group col-md-4">
                    <asp:Label runat="server" ID="lblDefault"   Text="<%$ Resources:GlobalResource, PayableSetupGroup_chkDefault%>"></asp:Label>
                  
                        <asp:CheckBox ID="chkDefault" ClientIDMode="Static" placeholder="" class="form-control" runat="server" required="required"  />
                  
                       
                    </div>
                      

                <div class="form-group col-md-4">
                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource, PayableSetupGroup_lblDescription %>"  ></asp:Label>
                            <asp:TextBox runat="server" ID="txtDescription" ClientIDMode="Static" class="form-control" onkeypress="return isAddress(this);" MaxLength="50" placeholder="" required="required"></asp:TextBox>


                        </div>
             
                <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCurrency" Text="<%$ Resources:GlobalResource, PayableSetupGroup_lblCurrency %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtCurrency" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon_Cuurency">
                                    <a href="#" data-toggle="modal" data-target="#basicModalCurrencySearch" data-keyboard="false" data-backdrop="static" onclick="CallCurrencyRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtCurrencyGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblPaymentTerms" Text="<%$ Resources:GlobalResource, PayableSetupGroup_lblPaymentTerms %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtPaymentTerms" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon5">
                                    <a href="#" data-toggle="modal" data-target="#basicModalPaymentTermsSearch" data-keyboard="false" data-backdrop="static" onclick="CallPaymentTermsRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPaymentTermsGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                <div class="form-group col-md-4 col-sm-4">

                    <asp:Label ID="lblPaymentPriority" runat="server" Text="<%$ Resources:GlobalResource, PayableSetupGroup_lblPaymentPriority%>"></asp:Label>

                    <asp:TextBox ID="txtPaymentPriority" ClientIDMode="Static"   size="32" class="form-control" placeholder="" onkeypress="return isAddress(this);" MaxLength="50" required="required" runat="server"></asp:TextBox>

                </div>
                <div class="form-group col-md-4 col-sm-4">

                    <asp:Label ID="lblMinimumOrder" runat="server" Text="<%$ Resources:GlobalResource, PayableSetupGroup_lblMinimumOrder%>"></asp:Label>

                    <asp:TextBox ID="txtMinimumOrder"  size="34" ClientIDMode="Static" class="form-control" placeholder="" required="required" onkeypress="return isAddress(this);" MaxLength="50" runat="server"></asp:TextBox>

                </div>
                 <div class="form-group col-md-4 col-sm-4">

                    <asp:Label ID="lblTradeDiscount" runat="server" Text="<%$ Resources:GlobalResource, PayableSetupGroup_lblTradeDiscount%>"></asp:Label>

                    <asp:TextBox ID="txtTradeDiscount"  size="34" class="form-control" onkeypress="return isAddress(this);" MaxLength="50" ClientIDMode="Static" placeholder="" required="required" runat="server"></asp:TextBox>

                </div>


                <div class="form-group col-md-4 col-sm-5">

                    <asp:Label runat="server" ID="lblMinimumPayment" Text="<%$ Resources:GlobalResource, PayableSetupGroup_lblMinimumPayment %>"></asp:Label>
                    <asp:DropDownList ID="ddlMinimumPayment" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
                    </asp:DropDownList>
                </div>
                 <div class="form-group col-md-4 col-sm-5">

                    <asp:Label runat="server" ID="lblMaxInvoiceAmt" Text="<%$ Resources:GlobalResource, PayableSetupGroup_lblMaxInvoiceAmt %>"></asp:Label>
                    <asp:DropDownList ID="ddlMaxInvoiceAmt" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
                    </asp:DropDownList>
                </div>
                 <div class="form-group col-md-4 col-sm-5">

                    <asp:Label runat="server" ID="lblCreditLimit" Text="<%$ Resources:GlobalResource, PayableSetupGroup_lblCreditLimit %>"></asp:Label>
                    <asp:DropDownList ID="ddlCreditLimit" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
                    </asp:DropDownList>
                </div>
                  <div class="form-group col-md-4 col-sm-5">

                    <asp:Label runat="server" ID="lblWriteOff" Text="<%$ Resources:GlobalResource, PayableSetupGroup_lblWriteOff %>"></asp:Label>
                    <asp:DropDownList ID="ddlWriteOff" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
                    </asp:DropDownList>
                </div>
               
                
                <div class="form-group col-md-12 ">
                    <div style="background-color: #f6f6f6">
                        <h5>
                            <asp:Literal runat="server" ID="ltrMaintainhistory" Text="<%$ Resources:GlobalResource, PayableSetupGroup_ltrMaintainhistory%>"></asp:Literal></h5>
                    </div>

                    <div class="form-group col-md-5">
                        <asp:Label runat="server" ID="lblCalenderYear"   Text="<%$ Resources:GlobalResource, PayableSetupGroup_chkCalenderYear %>"></asp:Label>
                        <asp:CheckBox ID="chkCalenderYear" CssClass="form-control" ClientIDMode="Static" placeholder="" required="required" runat="server"  />
                   </div>
                        <div class="form-group col-md-5">
                            <asp:Label runat="server" ID="lblTransaction"   Text="<%$ Resources:GlobalResource, PayableSetupGroup_chkTransaction %>"></asp:Label>
                        <asp:CheckBox ID="chkTransaction" runat="server" ClientIDMode="Static" placeholder="" required="required" CssClass="form-control"  />
                    </div>
                     <div class="form-group col-md-5">
                         <asp:Label runat="server" ID="lblFiscalYear"   Text="<%$ Resources:GlobalResource, PayableSetupGroup_chkFiscalYear %>"></asp:Label>
                        <asp:CheckBox ID="chkFiscalYear" CssClass="form-control" ClientIDMode="Static" runat="server"  />
                  </div>
                         <div class="form-group col-md-5">
                              <asp:Label runat="server" ID="Label1"  Text="<%$ Resources:GlobalResource, PayableSetupGroup_chkDistribution %>"></asp:Label>
                        <asp:CheckBox ID="chkDistribution" runat="server" ClientIDMode="Static" CssClass="form-control"  />
                    </div>
                </div>
                    </div>
                
                       
                   <%-- Modal Popup for basicModal_PayableSetup Search --%>
    <div class="modal fade" id="basicModalPayableSetupSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalPayableSetupTitle"><span>
                        <asp:Literal runat="server" ID="ltrPayableSetupTitle" Text="<%$ Resources:GlobalResource, PayableSetupGroup_ltrPayableSetupInformation%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlPayableSetup">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlPayableSetup" DefaultButton="btnPayableSetupSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtPayableSetupSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlPayableSetupSearch" onclick="CallPayableSetupSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlPayableSetupClose" visible="false" onclick="ClearPayableSetupSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>

                                <asp:Button runat="server" ID="btnPayableSetupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnPayableSetupSearch_Click" formnovalidate="formnovalidate " />
                                <asp:Button runat="server" ID="btnClearPayableSetupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearPayableSetupSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divPayableSetupSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblPayableSetupSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divPayableSetupSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblPayableSetupSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgPayableSetupData" AssociatedUpdatePanelID="updpnlgvPayableSetupSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvPayableSetupSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnPayableSetupRefresh" ClientIDMode="Static" OnClick="btnPayableSetupRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvPayableSetupSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PayableSetupGroup_htPayableSetupDetails%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetPayableSetupDetails('<%#Eval("PaymentCode")%>','<%#Eval("tbl_PayableSetupId")%>');">
                                                                <asp:Literal runat="server" ID="ltrgvPayableSetupNumber" Text='<%# Bind("PaymentDescription") %>'></asp:Literal>
                                                            </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PayableSetupGroup_htPayableSetupGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayableSetupGuid" runat="server" Text='<%# Bind("tbl_PayableSetupId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPayableSetupSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearPayableSetupSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divPayableSetupFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblPayableSetupClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>  
                <%-- Modal Popup for basicModal_PayableSetupGroup Search --%>
                <div class="modal fade" id="basicModalPayableSetupGroupSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header" style="text-align: left;">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title" id="hdrModalPayableSetupGroupTitle"><span>
                                    <asp:Literal runat="server" ID="ltrPayableSetupGroupTitle" Text="<%$ Resources:GlobalResource, PayableSetupGroup_ltrPayableSetupGroupInformation%>"></asp:Literal>
                                </span>
                                </h4>
                            </div>
                            <div class="modal-body">

                                <asp:UpdatePanel runat="server" ID="updpnlPayableSetupGroup">
                                    <ContentTemplate>
                                        <asp:Panel runat="server" ID="pnlPayableSetupGroup" DefaultButton="btnPayableSetupGroupSearch">
                                            <div class="col-md-4 col-xs-5">
                                                <div class="icon-addon addon-md">
                                                    <asp:TextBox runat="server" ID="txtPayableSetupGroupSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus" Width="128px"></asp:TextBox>
                                                    <a runat="server" id="btnHtmlPayableSetupGroupSearch" onclick="CallPayableSetupGroupSearch();" class="fa fa-search"></a>
                                                    <a runat="server" id="btnHtmlPayableSetupGroupClose" visible="false" onclick="ClearPayableSetupGroupSearch();" class="fa fa-close closex"></a>
                                                </div>
                                            </div>

                                            <asp:Button runat="server" ID="btnPayableSetupGroupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnPayableSetupGroupSearch_Click" formnovalidate="formnovalidate " />
                                            <asp:Button runat="server" ID="btnClearPayableSetupGroupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearPayableSetupGroupSearch_Click" formnovalidate="formnovalidate" />

                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <div class="col-md-12 col-sm-12 colformstyle3">
                                    <div runat="server" id="divPayableSetupGroupSearchError" visible="false" class="alert alert-danger" role="alert">
                                        <asp:Label runat="server" ID="lblPayableSetupGroupSearchError"></asp:Label>
                                    </div>
                                    <div runat="server" id="divPayableSetupGroupSearchSuccess" visible="false" class="alert alert-success" role="alert">
                                        <asp:Label runat="server" ID="lblPayableSetupGroupSearchSuccess"></asp:Label>
                                    </div>
                                </div>
                                <div>
                                    <asp:UpdateProgress runat="server" ID="updProgPayableSetupGroupData" AssociatedUpdatePanelID="updpnlgvPayableSetupGroupSearch">
                                        <ProgressTemplate>
                                            Loading...
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:UpdatePanel runat="server" ID="updpnlgvPayableSetupGroupSearch">
                                        <ContentTemplate>
                                            <asp:Button runat="server" ID="btnPayableSetupGroupRefresh" ClientIDMode="Static" OnClick="btnPayableSetupGroupRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                            <asp:GridView ID="gvPayableSetupGroupSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                                EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PayableSetupGroup_htPayableSetupGroupNumber%>">
                                                        <ItemTemplate>
                                                            <a href="#" data-dismiss="modal" onclick="SetPayableSetupGroupDetails('<%#Eval("Description")%>','<%#Eval("tbl_PayableSetupGroupId")%>');">
                                                                <asp:Literal runat="server" ID="ltrgvPayableSetupGroupNumber" Text='<%# Bind("Description") %>'></asp:Literal>
                                                            </a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PayableSetupGroup_htPayableSetupGroupGuid%>" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblgvPayableSetupGroupGuid" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                            </asp:GridView>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPayableSetupGroupSearch" />
                                            <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearPayableSetupGroupSearch" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="modal-footer row" runat="server" id="divPayableSetupGroupFooter">
                                <div class="pull-left">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">
                                        <asp:Literal runat="server" ID="ltrClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                 <%-- Modal Popup for basicModalGLAccountId_Currency Search --%>
                <div class="modal fade" id="basicModalCurrencySearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalCurrencyTitle"><span>
                        <asp:Literal runat="server" ID="ltrCurrencyTitle" Text="<%$ Resources:GlobalResource, PayableSetupGroup_ltrCurrency%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlCurrencySearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlCurrencySearch" DefaultButton="btnCurrencySearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtCurrencySearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlCurrencySearch" onclick="CallCurrencySearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlCurrencyClose" visible="false" onclick="ClearCurrencySearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnCurrencySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnCurrencySearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearCurrencySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearCurrencySearch_Click" />
                            </asp:Panel>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divCurrencySearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblCurrencySearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divCurrencySearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblCurrencySearchSucces"></asp:Label>
                        </div>
                    </div>

                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgCurrencyData" AssociatedUpdatePanelID="updpnlgvCurrencySearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvCurrencySearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnCurrencyRefresh" ClientIDMode="Static" OnClick="btnCurrencyRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvCurrencySearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PayableSetupGroup_htCurrencyCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCurrencyDetails('<%#Eval("CurrencyName")%>','<%#Eval("tbl_CurrencyId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCurrencyCode" Text='<%# Bind("CurrencyCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PayableSetupGroup_htCurrencyName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCurrencyName" runat="server" Text='<%# Bind("CurrencyName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PayableSetupGroup_htCurrencyGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCurrencyGuid" runat="server" Text='<%# Bind("tbl_CurrencyId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnCurrencySearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearCurrencySearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divCurrencyFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblCurrencyClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
                <%-- Modal Popup for basicModalGLAccountId_Payment Terms Search --%>
                <div class="modal fade" id="basicModalPaymentTermsSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalPaymentTermsTitle"><span>
                        <asp:Literal runat="server" ID="ltrPaymentTermsTitle" Text="<%$ Resources:GlobalResource, PayableSetupGroup_ltrPaymentTermsTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlPaymentTermsSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlPaymentTermsSearch" DefaultButton="btnPaymentTermsSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtPaymentTermsSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlPaymentTermsSearch" onclick="CallPaymentTermsSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlPaymentTermsClose" visible="false" onclick="ClearPaymentTermsSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnPaymentTermsSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnPaymentTermsSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearPaymentTermsSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearPaymentTermsSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divPaymentTermsSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblPaymentTermsSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divPaymentTermsSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblPaymentTermsSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgPaymentTermsData" AssociatedUpdatePanelID="updpnlgvPaymentTermsSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvPaymentTermsSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnPaymentTermsRefresh" ClientIDMode="Static" OnClick="btnPaymentTermsRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvPaymentTermsSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PayableSetupGroup_htPaymentTermsName%>">
                                            <ItemTemplate>
                                                 <a href="#" data-dismiss="modal" onclick="SetPaymentTermsDetails('<%#Eval("PaymentTermsName")%>','<%#Eval("tbl_PaymentTermsId")%>');">
                                                   
                                               <asp:Literal runat="server" ID="ltrgvPaymentTermsType" Text='<%# Bind("PaymentTermsName") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PayableSetupGroup_htPaymentTermsGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPaymentTermsGuid" runat="server" Text='<%# Bind("tbl_PaymentTermsId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPaymentTermsSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearPaymentTermsSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div2">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrPaymentTermsClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
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


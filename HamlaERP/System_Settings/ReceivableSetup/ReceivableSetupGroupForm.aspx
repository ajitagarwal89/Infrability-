<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ReceivableSetupGroupForm.aspx.cs" Inherits="System_Settings_ReceivableSetupGroupForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

	<script src="../../../infra_ui/js/CommonJS/CommonValidations.js"></script>
     <script src="../infra_ui/js/System_Settings_JS/ReceivableSetupGroupForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrReceivableSetupGroupInformation" Text="<%$ Resources:GlobalResource, ReceivableSetupGroup_ltrReceivableSetupGroupInformation%>"></asp:Literal></h5>
                        </div>
					    <div class="form-group col-md-4 col-sm-4">
						 <div>
                                <asp:Label runat="server" ID="lblReceivableSetupGroupId_Self" Text="<%$ Resources:GlobalResource, ReceivableSetupGroup_lblReceivableSetupGroupId_Self %>"></asp:Label>
                            </div>						 
						 <div class="input-group">
                                <asp:TextBox ID="txtReceivableSetupGroupId_Self" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addonReceivableSetupGroupId_Self">
                                     <a href="#" data-toggle="modal" data-target="#basicModalReceivableSetupGroupId_SelfSearch" data-keyboard="false" data-backdrop="static" onclick="CallReceivableSetupGroupId_SelfRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtReceivableSetupGroupId_SelfGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
							  </div>
                         <div class="form-group col-md-4 col-sm-4">
						 <div>
                                <asp:Label runat="server" ID="lbl_ReceivableSetup" Text="<%$ Resources:GlobalResource, ReceivableSetupGrouplbl_ReceivableSetup %>"></asp:Label>
                            </div>						 
						 <div class="input-group">
                                <asp:TextBox ID="txtReceivableSetup" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addonReceivableSetup">
                                     <a href="#" data-toggle="modal" data-target="#basicModalReceivableSetupSearch" data-keyboard="false" data-backdrop="static" onclick="CallReceivableSetupRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtReceivableSetupGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
							  </div>
						<div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblDefault" Text="<%$ Resources:GlobalResource, ReceivableSetupGroup_lblDefault%>"></asp:Label>


                           <asp:CheckBox runat="server" ID="chkDefault" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:CheckBox>
                        </div>
					    <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource, ReceivableSetupGroup_lblDescription%>"></asp:Label>


                            <asp:TextBox runat="server" ID="txtDescription" ClientIDMode="Static" onkeypress="return isAddress(this);" MaxLength="50" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
						
						<div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblPaymentTerms" Text="<%$ Resources:GlobalResource, ReceivableSetupGroup_lblPaymentTermsId %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtPaymentTerms" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon2">
                                       <a href="#" data-toggle="modal" data-target="#basicModalPaymentTermsSearch" data-keyboard="false" data-backdrop="static" onclick="CallPaymentTermsRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPaymentTermseGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
					
						<div class="form-group col-md-4 col-sm-4">

										<asp:Label ID="lblBalanceType" runat="server" Text="<%$ Resources:GlobalResource,  ReceivableSetupGroup_lblBalanceType %>"></asp:Label>
					</div>
							<div class="form-group col-md-4 col-sm-4">
										<asp:RadioButton ID="rdbOpenItem"  Checked="true" ClientIDMode="Static"  GroupName="gpBalanceType" runat="server" Text="<%$ Resources:GlobalResource, ReceivableSetupGroup_rdbOpenItem%>" />
					
										<asp:RadioButton ID="rdbBalanceForward" ClientIDMode="Static"  GroupName="gpBalanceType" runat="server" Text="<%$ Resources:GlobalResource, ReceivableSetupGroup_rdbBalanceForward%>" />
								
							</div>
					
						<div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="Server" ID="lblOptMinimumPayment" Text="<%$ Resources:GlobalResource, ReceivableSetupGroup_lblOptMinimumPayment%>"></asp:Label>
						  <asp:DropDownList ID="ddl_OptMinimumPayment" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
								</asp:DropDownList>
                        </div>
				     	<div class="form-group col-md-4 col-sm-4">
								<asp:Label ID="lblMiniumPayment" runat="server" Text="<%$ Resources:GlobalResource,  ReceivableSetupGroup_lblMiniumPayment%>"></asp:Label>
								<asp:TextBox ID="txtMiniumPayment" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
								</asp:TextBox>
							</div>
							
						<div class="form-group col-md-4 col-sm-4">
								<asp:Label ID="lbl_OptCreditLimit" runat="server" Text="<%$ Resources:GlobalResource,  ReceivableSetupGroup_lblMiniumPayment%>"></asp:Label>
								 <asp:DropDownList ID="ddl_OptCreditLimit" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
								</asp:DropDownList>
							</div>
				
						<div class="form-group col-md-4 col-sm-4">
								<asp:Label ID="lblCreditLimit" runat="server" Text="<%$ Resources:GlobalResource,  ReceivableSetupGroup_lblCreditLimit%>"></asp:Label>
									
								<asp:TextBox ID="txtCreditLimit" onkeypress="return isNumberKey (this);"  class="form-control " placeholder="" required="required"  MaxLength="20" runat="server"></asp:TextBox>
							</div>
						
						<div class="form-group col-md-4 col-sm-4">
								<asp:Label ID="lblOptWriteOff" runat="server" Text="<%$ Resources:GlobalResource,  ReceivableSetupGroup_lblWriteOff%>"></asp:Label>
						 <asp:DropDownList ID="ddl_OptWriteOff" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
								</asp:DropDownList>
						</div>
			
						<div class="form-group col-md-4 col-sm-4">
								<asp:Label ID="lblWriteOff" runat="server" Text="<%$ Resources:GlobalResource,  ReceivableSetupGroup_lblWriteOff%>"></asp:Label>
								<asp:TextBox ID="txtWriteOff" onkeypress="return isNumberKey (this);"  class="form-control " placeholder="" required="required"  MaxLength="20" runat="server"></asp:TextBox>
							</div>
							
					    <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblTradeDiscount" Text="<%$ Resources:GlobalResource, ReceivableSetupGroup_lblTradeDiscount%>"></asp:Label>


                            <asp:TextBox runat="server" ID="txtTradeDiscount" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
					    <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblStatementCycle" Text="<%$ Resources:GlobalResource, ReceivableSetupGroup_lblStatementCycle%>"></asp:Label>
						  <asp:DropDownList ID="ddlStatementCycle" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
								</asp:DropDownList>
                        </div>
					    <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblCalendarYear" Text="<%$ Resources:GlobalResource, ReceivableSetupGroup_lblCalendarYear%>"></asp:Label>
                         <asp:CheckBox runat="server" ID="chkCalendarYear" ClientIDMode="Static"  class="form-control" placeholder="" required="required"></asp:CheckBox>
                        </div>
						<div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblFiscalYear" Text="<%$ Resources:GlobalResource, ReceivableSetupGroup_lblFiscalYear%>"></asp:Label>
                         <asp:CheckBox runat="server" ID="chkFiscalYear" ClientIDMode="Static"  class="form-control" placeholder="" required="required"></asp:CheckBox>
                        </div>
						<div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblTransaction" Text="<%$ Resources:GlobalResource, ReceivableSetupGroup_lblTransaction%>"></asp:Label>
                         <asp:CheckBox runat="server" ID="chkTransaction" ClientIDMode="Static"  class="form-control" placeholder="" required="required"></asp:CheckBox>
                        </div>
						<div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDistribution" Text="<%$ Resources:GlobalResource, ReceivableSetupGroup_lblDistribution%>"></asp:Label>
                         <asp:CheckBox runat="server" ID="chkDistribution" ClientIDMode="Static"  class="form-control" placeholder="" required="required"></asp:CheckBox>
                        </div>
						</div>                      
                    </div>
                </div>
            </div>
        </div>
 
	   <div class="modal fade" id="basicModalReceivableSetupGroupId_SelfSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header" style="text-align: left;">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title" id="hdrModalReceivableSetupGroupId_SelfTitle"><span>
                            <asp:Literal runat="server" ID="ltr_ReceivableSetupGroupId_SelfInfomation" Text="<%$ Resources:GlobalResource, ReceivableSetupGroup_ltrRecevableSetupGroupId_Self %>"></asp:Literal>
                        </span>
                        </h4>
                    </div>
                    <div class="modal-body">

                        <asp:UpdatePanel runat="server" ID="updpnlReceivableSetupGroupId_SelfSearch">
                            <ContentTemplate>
                                <asp:Panel runat="server" ID="pnlReceivableSetupGroupId_SelfSearch" DefaultButton="btnReceivableSetupGroupId_SelfSearch">
                                    <div class="col-md-4 col-xs-5">
                                        <div class="icon-addon addon-md">
                                            <asp:TextBox runat="server" ID="txtReceivableSetupGroupId_SelfSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                            <a runat="server" id="btnHtmlReceivableSetupGroupId_SelfSearch" onclick="CallCustomerSearch();" class="fa fa-search"></a>
                                            <a runat="server" id="btnHtmlReceivableSetupGroupId_SelfClose" visible="false" onclick="ClearRecievableSetupGroupId_SelfSearch();" class="fa fa-close closex"></a>
                                        </div>
                                    </div>
                                    <asp:Button runat="server" ID="btnReceivableSetupGroupId_SelfSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnReceivableSetupGroupId_SelfSearch_Click" formnovalidate="formnovalidate" />
                                    <asp:Button runat="server" ID="btnClearReceivableSetupGroupId_SelfSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearReceivableSetupGroupId_SelfSearch_Click" formnovalidate="formnovalidate" />

                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div class="col-md-12 col-sm-12 colformstyle3">
                            <div runat="server" id="divRecievableSetupGroupId_SelfSearchError" visible="false" class="alert alert-danger" role="alert">
                                <asp:Label runat="server" ID="lblReceivableSetupGroupId_SelfSearchError"></asp:Label>
                            </div>
                            <div runat="server" id="divReceivableSetupGroupId_SelfSearchSuccess" visible="false" class="alert alert-success" role="alert">
                                <asp:Label runat="server" ID="lblReceivableSetupGroupId_SelfSearchSuccess"></asp:Label>
                            </div>
                        </div>
                        <div>
                            <asp:UpdateProgress runat="server" ID="UpdateProgress" AssociatedUpdatePanelID="updpnlgvReceivableSetupGroupId_SelfSearch">
                                <ProgressTemplate>
                                    Loading...
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:UpdatePanel runat="server" ID="updpnlgvReceivableSetupGroupId_SelfSearch">
                                <ContentTemplate>
                                    <asp:Button runat="server" ID="btnReceivableSetupGroupId_SelfRefresh" ClientIDMode="Static" OnClick="btnReceivableSetupGroupId_SelfRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                    <asp:GridView ID="gvReceivableSetupGroupId_SelfSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                        EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                        <Columns>
                                            <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,ReceivableSetupGroup_Description%>">
                                                <ItemTemplate>
                                                    <a href="#" data-dismiss="modal" onclick="SetReceivableSetupGroupId_SelfDetails('<%#Eval("Description")%>','<%#Eval("tbl_ReceivableSetupGroupId")%>');">
                                                        <asp:Literal runat="server" ID="ltrgvReceivableSetupGroupId_Self" Text='<%# Bind("Description") %>'></asp:Literal>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,ReceivableSetupGroup_htbl_ReceivableSetupGroupId_Self%>">
                                                <ItemTemplate>

                                                    <asp:Literal runat="server" ID="ltrgvCustomerCode" Text='<%# Bind("tbl_ReceivableSetupGroupId") %>'></asp:Literal>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, ReceivableSetupGroup_htReceivableSetupGroupId_SelfGuid %>" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgv_ReceivableSetupGroupId_Self" runat="server" Text='<%# Bind("tbl_ReceivableSetupGroupId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnReceivableSetupGroupId_SelfSearch" />
                                    <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearReceivableSetupGroupId_SelfSearch" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="modal-footer row" runat="server" id="div1">
                        <div class="pull-left">
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                <asp:Literal runat="server" ID="ltrReceivableSetupGroupId_SelfClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
	  <div class="modal fade" id="basicModalPaymentTermsSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header" style="text-align: left;">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title" id="hdrModalPaymentTermsTitle"><span>
                            <asp:Literal runat="server" ID="ltrPaymentTermsTitle" Text="<%$ Resources:GlobalResource, ReceivableSetupGroup_ltrPaymentTerms%>"></asp:Literal>
                        </span>
                        </h4>
                    </div>
                    <div class="modal-body">

                        <asp:UpdatePanel runat="server" ID="updpnlPaymentTermsGroup">
                            <ContentTemplate>
                                <asp:Panel runat="server" ID="pnlPaymentTerms" DefaultButton="btnPaymentTermsSearch">
                                    <div class="col-md-4 col-xs-5">
                                        <div class="icon-addon addon-md">
                                            <asp:TextBox runat="server" ID="txtPaymentTermsSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                            <a runat="server" id="btnHtmlPaymentTermsSearch" onclick="CallAccruedPurchaseSearch();" class="fa fa-search"></a>
                                            <a runat="server" id="btnHtmlPaymentTermsClose" visible="false" onclick="ClearAccruedPurchaseSearch();" class="fa fa-close closex"></a>
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
                            <div runat="server" id="divPaymentTermsSearchSucces" visible="false" class="alert alert-success" role="alert">
                                <asp:Label runat="server" ID="lblPaymentTermsSearchSucces"></asp:Label>
                            </div>
                        </div>
                        <div>
                            <asp:UpdateProgress runat="server" ID="updProgPaymentTermsData" AssociatedUpdatePanelID="updpnlgPaymentTermsSearch">
                                <ProgressTemplate>
                                    Loading...
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:UpdatePanel runat="server" ID="updpnlgPaymentTermsSearch">
                                <ContentTemplate>
                                    <asp:Button runat="server" ID="btnPaymentTermsRefresh" ClientIDMode="Static" OnClick="btnPaymentTermsRefresh_Click" Style="display: none;" formnovalidate />
                                    <asp:GridView ID="gvPaymentTermsSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                        EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                        <Columns>
                                            <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,ReceivableSetupGroup_htPaymentTerms%>">
                                                <ItemTemplate>

                                                    <a href="#" data-dismiss="modal" onclick="SetPaymentTermsDetails('<%#Eval("PaymentTermsName")%>','<%#Eval("tbl_PaymentTermsId")%>');">
                                                        <asp:Literal runat="server" ID="ltrPaymentTermsCode" Text='<%# Bind("PaymentTermsName") %>'></asp:Literal>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,ReceivableSetupGroup_htDueInDays%>">
                                                <ItemTemplate>

                                                    <asp:Literal runat="server" ID="ltrPaymentTermsCode" Text='<%# Bind("DueInDays") %>'></asp:Literal>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$Resources:GlobalResource, ReceivableSetupGroup_htPaymentTermsGuid %>" Visible="false">
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
                    <div class="modal-footer row" runat="server" id="divPaymentTermsFooter">
                        <div class="pull-left">
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                <asp:Literal runat="server" ID="lblPaymentTermsClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

      <div class="modal fade" id="basicModalReceivableSetupSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header" style="text-align: left;">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title" id="hdrModalReceivableSetupTitle"><span>
                            <asp:Literal runat="server" ID="ltr_ReceivableSetup" Text="<%$ Resources:GlobalResource, ReceivableSetupGroup_ltr_ReceivableSetup%>"></asp:Literal>
                        </span>
                        </h4>
                    </div>
                    <div class="modal-body">

                        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                            <ContentTemplate>
                                <asp:Panel runat="server" ID="Panel1" DefaultButton="btnReceivableSetupSearch">
                                    <div class="col-md-4 col-xs-5">
                                        <div class="icon-addon addon-md">
                                            <asp:TextBox runat="server" ID="txtReceivableSetupSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                            <a runat="server" id="btnHtmlReceivableSetupSearch" onclick="CallReceivableSetupSearch();" class="fa fa-search"></a>
                                            <a runat="server" id="btnHtmlReceivableSetupClose" visible="false" onclick="ClearReceivableSetupSearch();" class="fa fa-close closex"></a>
                                        </div>
                                    </div>
                                    <asp:Button runat="server" ID="btnReceivableSetupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnReceivableSetupSearch_Click" formnovalidate="formnovalidate" />
                                    <asp:Button runat="server" ID="btnClearReceivableSetupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearReceivableSetupSearch_Click" formnovalidate="formnovalidate" />

                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div class="col-md-12 col-sm-12 colformstyle3">
                            <div runat="server" id="divReceivableSetupSearchError" visible="false" class="alert alert-danger" role="alert">
                                <asp:Label runat="server" ID="lblReceivableSetupSearchError"></asp:Label>
                            </div>
                            <div runat="server" id="divReceivableSetupSearchSuccess" visible="false" class="alert alert-success" role="alert">
                                <asp:Label runat="server" ID="lblReceivableSetupSearchSuccess"></asp:Label>
                            </div>
                        </div>
                        <div>
                            <asp:UpdateProgress runat="server" ID="UpdateProgress6" AssociatedUpdatePanelID="updpnlgvReceivableSetupSearch">
                                <ProgressTemplate>
                                    Loading...
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:UpdatePanel runat="server" ID="updpnlgvReceivableSetupSearch">
                                <ContentTemplate>
                                    <asp:Button runat="server" ID="btnReceivableSetupRefresh" ClientIDMode="Static" OnClick="btnReceivableSetupRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                    <asp:GridView ID="gvReceivableSetupSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                        EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                        <Columns>
                                            <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,ReceivableSetupGroup_SaleInvoiceCode%>">
                                                <ItemTemplate>
                                                    <a href="#" data-dismiss="modal" onclick="SetReceivableSetupDetails('<%#Eval("SaleInvoiceCode")%>','<%#Eval("tbl_ReceivableSetupId")%>');">
                                                        <asp:Literal runat="server" ID="ltrgvReceivableSetup" Text='<%# Bind("SaleInvoiceCode") %>'></asp:Literal>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,ReceivableSetupGroup_htRecievableSetup%>">
                                                <ItemTemplate>

                                                    <asp:Literal runat="server" ID="ltrgvReceivableSetup" Text='<%# Bind("tbl_ReceivableSetupId") %>'></asp:Literal>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, ReceivableSetupGroupht_ReceivableSetupIdGuid %>" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgv_RecievableSetup" runat="server" Text='<%# Bind("tbl_ReceivableSetupId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnReceivableSetupSearch" />
                                    <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearReceivableSetupSearch" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="modal-footer row" runat="server" id="div9">
                        <div class="pull-left">
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                <asp:Literal runat="server" ID="ltrReceivableSetupClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
           

     
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ReceivableSetupAndGroupAccountForm.aspx.cs" Inherits="System_Settings_ReceivableSetupAndGroupAccountForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    	<script src="../../../infra_ui/js/CommonJS/CommonValidations.js"></script>
	<script src="../infra_ui/js/System_Settings_JS/ReceivableSetupAndGroupAccountForm.js"></script>
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
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-success" OnClick="btnBack_Click" Text="<%$ Resources:GlobalResource, btnBack%>" formnovalidate="formnovalidate" ></asp:Button>
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
                                <asp:Literal runat="server" ID="ltrReceivableSetupAndGroupAccountInformation" Text="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_ltrReceivableSetupAndGroupAccountInformation%>"></asp:Literal></h5>
                        </div>
                         <div class="form-group col-md-4 col-sm-4">
						 <div>
                                <asp:Label runat="server" ID="lbl_ReceivableSetup" Text="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccountlbl_ReceivableSetupId %>"></asp:Label>
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
						 <div>
                                <asp:Label runat="server" ID="lblRecievableSetupGroupId_Self" Text="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_lblRecievableSetupGroup %>"></asp:Label>
                            </div>						 
						 <div class="input-group">
                                <asp:TextBox ID="txtRecievableSetupGroup" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addonRecievableSetupGroup">
                                     <a href="#" data-toggle="modal" data-target="#basicModalRecievableSetupGroupSearch" data-keyboard="false" data-backdrop="static" onclick="CallRecievableSetupGroupRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtRecievableSetupGroupGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
							  </div>
						<div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_lblDescription%>"></asp:Label>


                            <asp:TextBox runat="server" ID="txtDescription" ClientIDMode="Static" onkeypress="return isAddress(this);" MaxLength="50" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
						<div class="form-group col-md-4 col-sm-4">
								<div>
									<asp:Label runat="server" ID="lblChequeBook" Text="<%$ Resources:GlobalResource, ReceivableConfigurationSetting_lblSummaryView_lblcheckbookid%>"></asp:Label>
								</div>
								<div class="input-group">
									<asp:TextBox ID="txtChequeBook" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
									<span class="input-group-addon lookup" id="sizing-addonChequeBook">
										<a href="#" data-toggle="modal" data-target="#basicModalChequeBookSearch" data-keyboard="false" data-backdrop="static" onclick="CallChequeBookRefreshButton();">
											<i class="fa fa-search"></i></a>
									</span>

									<asp:TextBox ID="txtChequeBookGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
								</div>
							</div>				
						<div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblCashAccountFrom" Text="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_lblCashAccount%>"></asp:Label>
						 
                           <asp:CheckBox runat="server" ID="chkCashAccountFrom" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:CheckBox>     

					 </div>					
						
                         <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblGLAccountId_Cash" Text="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_lblGLAccountId_Cash %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtGLAccountId_Cash" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-GLAccountId_Cash">
                                     <a href="#" data-toggle="modal" data-target="#basicModalGLAccountId_CashSearch" data-keyboard="false" data-backdrop="static" onclick="CallGLAccountId_CashRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountId_CashGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
						
						<div class="form-group col-md-4 col-sm-4">                           
                                <asp:Label runat="server" ID="lblGLAccountId_AccountReceivable" Text="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_lblGLAccountId_AccountReceivable %>"></asp:Label>
                              <div class="input-group">
                                <asp:TextBox ID="txtGLAccountId_AccountReceivable" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-aAccountReceivable">
                                       <a href="#" data-toggle="modal" data-target="#basicModalAccountReceivablesSearch" data-keyboard="false" data-backdrop="static" onclick="CallAccountReceivableRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountId_AccountReceivableGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                           
                        </div>
			               
                    </div>

						<div class="form-group col-md-4 col-sm-4">                           
                                <asp:Label runat="server" ID="lblGLAccountId_Sales" Text="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_lblGLAccountId_Sales %>"></asp:Label>
                              <div class="input-group">
                                <asp:TextBox ID="txtGLAccountId_Sales" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-Sales">
                                       <a href="#" data-toggle="modal" data-target="#basicModalSalesSearch" data-keyboard="false" data-backdrop="static" onclick="CallSalesRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountId_SalesGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                           
                        </div>
			               
                    </div>

						<div class="form-group col-md-4 col-sm-4">                           
                                <asp:Label runat="server" ID="lblGLAccountId_CostOfSales" Text="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_lblGLAccountId_CostOfSales %>"></asp:Label>
                              <div class="input-group">
                                <asp:TextBox ID="txtGLAccountId_CostOfSales" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-CostOfSales">
                                       <a href="#" data-toggle="modal" data-target="#basicModalCostOfSalesSearch" data-keyboard="false" data-backdrop="static" onclick="CallCostOfSalesRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountId_CostOfSalesGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                           
                        </div>
			               
                    </div>
						<div class="form-group col-md-4 col-sm-4">                           
                                <asp:Label runat="server" ID="lblGLAccountId_Inventory" Text="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_lblGLAccountId_Inventory %>"></asp:Label>
                              <div class="input-group">
                                <asp:TextBox ID="txtGLAccountId_Inventory" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-Inventory">
                                       <a href="#" data-toggle="modal" data-target="#basicModalInventorySearch" data-keyboard="false" data-backdrop="static" onclick="CallInventoryRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountId_InventoryGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                           
                        </div>
			               
                    </div>
						<div class="form-group col-md-4 col-sm-4">                           
                                <asp:Label runat="server" ID="lblGLAccountId_AccuralDifferedA_C" Text="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_lblGLAccountId_AccuralDifferedA_C %>"></asp:Label>
                              <div class="input-group">
                                <asp:TextBox ID="txtGLAccountId_AccuralDifferedA_C" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-AccuralDifferedA_C">
                                       <a href="#" data-toggle="modal" data-target="#basicModalAccuralDifferedA_CSearch" data-keyboard="false" data-backdrop="static" onclick="CallAccuralDifferedA_CRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountId_AccuralDifferedA_CGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                           
                        </div>
			               
                    </div>

                </div>
                 </div>

					<!-- Check Book -->
				<div class="modal fade" id="basicModalChequeBookSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
							<div class="modal-dialog">
								<div class="modal-content">
									<div class="modal-header" style="text-align: left;">
										<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
										<h4 class="modal-title" id="hdrModalChequeBookTitle"><span>
											<asp:Literal runat="server" ID="ltrChequeBookTitle" Text="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_ltrChequeBookInformation%>"></asp:Literal>
										</span>
										</h4>
									</div>
									<div class="modal-body">

										<asp:UpdatePanel runat="server" ID="updpnlChequeBook">
											<ContentTemplate>
												<asp:Panel runat="server" ID="pnlChequeBook" DefaultButton="btnChequeBookSearch">
													<div class="col-md-4 col-xs-5">
														<div class="icon-addon addon-md">
															<asp:TextBox runat="server" ID="txtChequeBookSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
															<a runat="server" id="btnHtmlChequeBookSearch" onclick="CallChequeBookSearch();" class="fa fa-search"></a>
															<a runat="server" id="btnHtmlChequeBookClose" visible="false" onclick="ClearChequeBookSearch();" class="fa fa-close closex"></a>
														</div>
													</div>

													<asp:Button runat="server" ID="btnChequeBookSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnChequeBookSearch_Click" formnovalidate="formnovalidate " />
													<asp:Button runat="server" ID="btnClearChequeBookSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearChequeBookSearch_Click" formnovalidate="formnovalidate" />

												</asp:Panel>
											</ContentTemplate>
										</asp:UpdatePanel>

										<div class="col-md-12 col-sm-12 colformstyle3">
											<div runat="server" id="divChequeBookSearchError" visible="false" class="alert alert-danger" role="alert">
												<asp:Label runat="server" ID="lblChequeBookSearchError"></asp:Label>
											</div>
											<div runat="server" id="divChequeBookSearchSucces" visible="false" class="alert alert-success" role="alert">
												<asp:Label runat="server" ID="lblChequeBookSearchSucces"></asp:Label>
											</div>
										</div>
										<div>
											<asp:UpdateProgress runat="server" ID="updProgChequeBookData" AssociatedUpdatePanelID="updpnlgvChequeBookSearch">
												<ProgressTemplate>
													Loading...
												</ProgressTemplate>
											</asp:UpdateProgress>
											<asp:UpdatePanel runat="server" ID="updpnlgvChequeBookSearch">
												<ContentTemplate>
													<asp:Button runat="server" ID="btnChequeBookRefresh" ClientIDMode="Static" OnClick="btnChequeBookRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
													<asp:GridView ID="gvChequeBookSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
														EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
														<Columns>
															<asp:TemplateField HeaderText="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_htChequeBookNumber%>">
																<ItemTemplate>
																	<a href="#" data-dismiss="modal" onclick="SetChequeBookDetails('<%#Eval("ChequeBookName")%>','<%#Eval("tbl_ChequeBookId")%>');">
																		<asp:Literal runat="server" ID="ltrgvChequeBookNumber" Text='<%# Bind("ChequeBookNumber") %>'></asp:Literal>
																	</a>
																</ItemTemplate>
															</asp:TemplateField>
															<asp:TemplateField HeaderText="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_htChequeBookGuid%>" Visible="false">
																<ItemTemplate>
																	<asp:Label ID="lblgvChequeBookGuid" runat="server" Text='<%# Bind("tbl_ChequeBookId") %>'></asp:Label>
																</ItemTemplate>
															</asp:TemplateField>
														</Columns>
														<HeaderStyle BackColor="#24648f" ForeColor="White" />
													</asp:GridView>
												</ContentTemplate>
												<Triggers>
													<asp:AsyncPostBackTrigger EventName="Click" ControlID="btnChequeBookSearch" />
													<asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearChequeBookSearch" />
												</Triggers>
											</asp:UpdatePanel>
										</div>
									</div>
									<div class="modal-footer row" runat="server" id="divChequeBookFooter">
										<div class="pull-left">
											<button type="button" class="btn btn-default" data-dismiss="modal">
												<asp:Literal runat="server" ID="lblChequeBookClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
										</div>
									</div>
								</div>
							</div>
						</div>

				 <div class="modal fade" id="basicModalRecievableSetupGroupSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header" style="text-align: left;">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title" id="hdrModalRecievableSetupGroupTitle"><span>
                            <asp:Literal runat="server" ID="ltr_RecievableSetupGroupInfomation" Text="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_ltrRecievableSetupGroup %>"></asp:Literal>
                        </span>
                        </h4>
                    </div>
                    <div class="modal-body">

                        <asp:UpdatePanel runat="server" ID="updpnlRecievableSetupGroupSearch">
                            <ContentTemplate>
                                <asp:Panel runat="server" ID="pnlRecievableSetupGroupSearch" DefaultButton="btnRecievableSetupGroupSearch">
                                    <div class="col-md-4 col-xs-5">
                                        <div class="icon-addon addon-md">
                                            <asp:TextBox runat="server" ID="txtRecievableSetupGroupSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                            <a runat="server" id="btnHtmlRecievableSetupGroupSearch" onclick="CallCustomerSearch();" class="fa fa-search"></a>
                                            <a runat="server" id="btnHtmlRecievableSetupGroupClose" visible="false" onclick="ClearRecievableSetupGroupSearch();" class="fa fa-close closex"></a>
                                        </div>
                                    </div>
                                    <asp:Button runat="server" ID="btnRecievableSetupGroupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnRecievableSetupGroupSearch_Click" formnovalidate="formnovalidate" />
                                    <asp:Button runat="server" ID="btnClearRecievableSetupGroupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearRecievableSetupGroupSearch_Click" formnovalidate="formnovalidate" />

                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div class="col-md-12 col-sm-12 colformstyle3">
                            <div runat="server" id="divRecievableSetupGroupSearchError" visible="false" class="alert alert-danger" role="alert">
                                <asp:Label runat="server" ID="lblRecievableSetupGroupSearchError"></asp:Label>
                            </div>
                            <div runat="server" id="divRecievableSetupGroupSearchSuccess" visible="false" class="alert alert-success" role="alert">
                                <asp:Label runat="server" ID="lblRecievableSetupGroupSearchSuccess"></asp:Label>
                            </div>
                        </div>
                        <div>
                            <asp:UpdateProgress runat="server" ID="UpdateProgress" AssociatedUpdatePanelID="updpnlgvRecievableSetupGroupSearch">
                                <ProgressTemplate>
                                    Loading...
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:UpdatePanel runat="server" ID="updpnlgvRecievableSetupGroupSearch">
                                <ContentTemplate>
                                    <asp:Button runat="server" ID="btnRecievableSetupGroupRefresh" ClientIDMode="Static" OnClick="btnRecievableSetupGroupRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                    <asp:GridView ID="gvRecievableSetupGroupSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                        EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                        <Columns>
                                            <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,ReceivableSetupAndGroupAccount_Description%>">
                                                <ItemTemplate>
                                                    <a href="#" data-dismiss="modal" onclick="SetRecievableSetupGroupDetails('<%#Eval("Description")%>','<%#Eval("tbl_ReceivableSetupGroupId")%>');">
                                                        <asp:Literal runat="server" ID="ltrgvRecievableSetupGroup" Text='<%# Bind("Description") %>'></asp:Literal>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,ReceivableSetupAndGroupAccount_htRecievableSetupGroup%>">
                                                <ItemTemplate>

                                                    <asp:Literal runat="server" ID="ltrgvCustomerCode" Text='<%# Bind("tbl_ReceivableSetupGroupId") %>'></asp:Literal>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_htRecievableSetupGroupGuid %>" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgv_RecievableSetupGroup" runat="server" Text='<%# Bind("tbl_ReceivableSetupGroupId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnRecievableSetupGroupSearch" />
                                    <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearRecievableSetupGroupSearch" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="modal-footer row" runat="server" id="div1">
                        <div class="pull-left">
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                <asp:Literal runat="server" ID="ltrRecievableSetupGroupClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

				 <div class="modal fade" id="basicModalGLAccountId_CashSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGLAccountId_Cash"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountId_CashTitle" Text="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_ltrGLAccountId_CashTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlGLAccountId_CashSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlGLAccountId_CashSearch" DefaultButton="btnGLAccountId_CashSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtGLAccountId_CashSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlGLAccountId_CashSearch" onclick="CallGLAccountId_CashSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlGLAccountId_CashClose" visible="false" onclick="ClearGLAccountId_CashSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnGLAccountId_CashSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnGLAccountId_CashSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearGLAccountId_CashSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearGLAccountId_CashSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountId_CashSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_CashSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountId_CashSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_CashSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgData" AssociatedUpdatePanelID="updpnlgvGLAccountId_CashSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountId_CashSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnGLAccountId_CashRefresh" ClientIDMode="Static" OnClick="btnGLAccountId_CashRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvGLAccountId_CashSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_htAccountNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetGLAccountId_CashDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">

                                                    <asp:Literal runat="server" ID="ltrGLAccountId_Cash" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_htGLAccountId_CashGuid  %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvGLAccountEntryGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnGLAccountId_CashSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearGLAccountId_CashSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrGLAccountId_CashClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

			     <div class="modal fade" id="basicModalAccountReceivablesSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGLAccountId_AccountReceivableTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountId_AccountReceivableTitle" Text="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_ltrGLAccountId_AccountReceivableTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlGLAccountId_AccountReceivableSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlGLAccountId_AccountReceivableSearch" DefaultButton="btnGLAccountId_AccountReceivableSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtGLAccountId_AccountReceivableSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlGLAccountId_AccountReceivableSearch" onclick="CallGLAccountId_AccountReceivableSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlGLAccountId_AccountReceivableClose" visible="false" onclick="ClearGLAccountId_AccountReceivableSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnGLAccountId_AccountReceivableSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnGLAccountId_AccountReceivableSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearGLAccountId_AccountReceivableSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearGLAccountId_AccountReceivableSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountId_AccountReceivableSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_AccountReceivableSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountId_AccountReceivableSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_AccountReceivableSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateProgress1" AssociatedUpdatePanelID="updpnlgvGLAccountId_AccountReceivableSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountId_AccountReceivableSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnGLAccountId_AccountReceivableRefresh" ClientIDMode="Static" OnClick="btnGLAccountId_AccountReceivableRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvGLAccountId_AccountReceivableSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_htAccountNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetGLAccountId_AccountReceivableDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">

                                                    <asp:Literal runat="server" ID="ltrGLAccountId_AccountReceivable" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_htGLAccountId_AccountReceivableGuid  %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvGLAccountEntryGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnGLAccountId_AccountReceivableSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearGLAccountId_AccountReceivableSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div2">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrGLAccountId_AccountReceivableClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

				 <div class="modal fade" id="basicModalSalesSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGLAccountId_SalesTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountId_SalesTitle" Text="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_ltrGLAccountId_SalesTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlGLAccountId_SalesSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlGLAccountId_SalesSearch" DefaultButton="btnGLAccountId_SalesSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtGLAccountId_SalesSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlGLAccountId_SalesSearch" onclick="CallGLAccountId_SalesSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlGLAccountId_SalesClose" visible="false" onclick="ClearGLAccountId_SalesSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnGLAccountId_SalesSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnGLAccountId_SalesSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearGLAccountId_SalesSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearGLAccountId_SalesSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountId_SalesSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_SalesSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountId_SalesSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_SalesSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateProgress2" AssociatedUpdatePanelID="updpnlgvGLAccountId_SalesSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountId_SalesSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnGLAccountId_SalesRefresh" ClientIDMode="Static" OnClick="btnGLAccountId_SalesRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvGLAccountId_SalesSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_htAccountNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetGLAccountId_SalesDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">

                                                    <asp:Literal runat="server" ID="ltrGLAccountId_Sales" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_htGLAccountId_SalesGuid  %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvGLAccountEntryGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnGLAccountId_SalesSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearGLAccountId_SalesSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div3">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrGLAccountId_SalesClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>					

		        <div class="modal fade" id="basicModalCostOfSalesSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGLAccountId_CostOfSalesTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountId_CostOfSalesTitle" Text="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_ltrGLAccountId_CostOfSalesTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlGLAccountId_CostOfSalesSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlGLAccountId_CostOfSalesSearch" DefaultButton="btnGLAccountId_CostOfSalesSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtGLAccountId_CostOfSalesSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlGLAccountId_CostOfSalesSearch" onclick="CallGLAccountId_CostOfSalesSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlGLAccountId_CostOfSalesClose" visible="false" onclick="ClearGLAccountId_CostOfSalesSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnGLAccountId_CostOfSalesSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnGLAccountId_CostOfSalesSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearGLAccountId_CostOfSalesSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearGLAccountId_CostOfSalesSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountId_CostOfSalesSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_CostOfSalesSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountId_CostOfSalesSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_CostOfSalesSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateProgress3" AssociatedUpdatePanelID="updpnlgvGLAccountId_CostOfSalesSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountId_CostOfSalesSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnGLAccountId_CostOfSalesRefresh" ClientIDMode="Static" OnClick="btnGLAccountId_CostOfSalesRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvGLAccountId_CostOfSalesSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_htAccountNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetGLAccountId_CostOfSalesDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">

                                                    <asp:Literal runat="server" ID="ltrGLAccountId_CostOfSales" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_htGLAccountId_CostOfSalesGuid  %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvGLAccountEntryGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnGLAccountId_CostOfSalesSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearGLAccountId_CostOfSalesSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div4">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrGLAccountId_CostOfSalesClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
					
	        	<div class="modal fade" id="basicModalInventorySearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGLAccountId_InventoryTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountId_InventoryTitle" Text="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_ltrGLAccountId_InventoryTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlGLAccountId_InventorySearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlGLAccountId_InventorySearch" DefaultButton="btnGLAccountId_InventorySearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtGLAccountId_InventorySearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlGLAccountId_InventorySearch" onclick="CallGLAccountId_InventorySearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlGLAccountId_InventoryClose" visible="false" onclick="ClearGLAccountId_InventorySearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnGLAccountId_InventorySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnGLAccountId_InventorySearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearGLAccountId_InventorySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearGLAccountId_InventorySearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountId_InventorySearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_InventorySearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountId_InventorySearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_InventorySearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateProgress4" AssociatedUpdatePanelID="updpnlgvGLAccountId_InventorySearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountId_InventorySearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnGLAccountId_InventoryRefresh" ClientIDMode="Static" OnClick="btnGLAccountId_InventoryRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvGLAccountId_InventorySearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_htAccountNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetGLAccountId_InventoryDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">

                                                    <asp:Literal runat="server" ID="ltrGLAccountId_Inventory" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_htGLAccountId_InventoryGuid  %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvGLAccountEntryGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnGLAccountId_InventorySearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearGLAccountId_InventorySearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div5">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrGLAccountId_InventoryClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

				<div class="modal fade" id="basicModalAccuralDifferedA_CSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGLAccountIdAccuralDifferedA_CTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountId_AccuralDifferedA_CTitle" Text="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_ltrGLAccountId_AccuralDifferedA_CTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlGLAccountId_AccuralDifferedA_CSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlGLAccountId_AccuralDifferedA_CSearch" DefaultButton="btnGLAccountId_AccuralDifferedA_CSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtGLAccountId_AccuralDifferedA_CSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlGLAccountId_AccuralDifferedA_CSearch" onclick="CallGLAccountId_AccuralDifferedA_CSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlGLAccountId_AccuralDifferedA_CClose" visible="false" onclick="ClearGLAccountId_AccuralDifferedA_CSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnGLAccountId_AccuralDifferedA_CSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnGLAccountId_AccuralDifferedA_CSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearGLAccountId_AccuralDifferedA_CSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearGLAccountId_AccuralDifferedA_CSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountId_AccuralDifferedA_CSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_AccuralDifferedA_CSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountId_AccuralDifferedA_CSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_AccuralDifferedA_CSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateProgress5" AssociatedUpdatePanelID="updpnlgvGLAccountId_AccuralDifferedA_CSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountId_AccuralDifferedA_CSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnGLAccountId_AccuralDifferedA_CRefresh" ClientIDMode="Static" OnClick="btnGLAccountId_AccuralDifferedA_CRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvGLAccountId_AccuralDifferedA_CSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_htAccountNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetGLAccountId_AccuralDifferedA_CDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">

                                                    <asp:Literal runat="server" ID="ltrGLAccountId_AccuralDifferedA_C" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_htGLAccountId_AccuralDifferedA_CGuid  %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvGLAccountEntryGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnGLAccountId_AccuralDifferedA_CSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearGLAccountId_AccuralDifferedA_CSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div6">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrGLAccountId_AccuralDifferedA_CClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
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
                            <asp:Literal runat="server" ID="ltr_ReceivableSetup" Text="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_ltr_ReceivableSetup%>"></asp:Literal>
                        </span>
                        </h4>
                    </div>
                    <div class="modal-body">

                        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                            <ContentTemplate>
                                <asp:Panel runat="server" ID="Panel1" DefaultButton="btnRecievableSetupSearch">
                                    <div class="col-md-4 col-xs-5">
                                        <div class="icon-addon addon-md">
                                            <asp:TextBox runat="server" ID="txtRecievableSetupSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                            <a runat="server" id="btnHtmlRecievableSetupSearch" onclick="CallCustomerSearch();" class="fa fa-search"></a>
                                            <a runat="server" id="btnHtmlRecievableSetupClose" visible="false" onclick="ClearRecievableSetupSearch();" class="fa fa-close closex"></a>
                                        </div>
                                    </div>
                                    <asp:Button runat="server" ID="btnRecievableSetupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnRecievableSetupSearch_Click" formnovalidate="formnovalidate" />
                                    <asp:Button runat="server" ID="btnClearRecievableSetupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearRecievableSetupSearch_Click" formnovalidate="formnovalidate" />

                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div class="col-md-12 col-sm-12 colformstyle3">
                            <div runat="server" id="divRecievableSetupSearchError" visible="false" class="alert alert-danger" role="alert">
                                <asp:Label runat="server" ID="lblRecievableSetupSearchError"></asp:Label>
                            </div>
                            <div runat="server" id="divRecievableSetupSearchSuccess" visible="false" class="alert alert-success" role="alert">
                                <asp:Label runat="server" ID="lblRecievableSetupSearchSuccess"></asp:Label>
                            </div>
                        </div>
                        <div>
                            <asp:UpdateProgress runat="server" ID="UpdateProgress6" AssociatedUpdatePanelID="updpnlgvRecievableSetupSearch">
                                <ProgressTemplate>
                                    Loading...
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:UpdatePanel runat="server" ID="updpnlgvRecievableSetupSearch">
                                <ContentTemplate>
                                    <asp:Button runat="server" ID="btnRecievableSetupRefresh" ClientIDMode="Static" OnClick="btnRecievableSetupRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                    <asp:GridView ID="gvRecievableSetupSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                        EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                        <Columns>
                                            <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,ReceivableSetupAndGroupAccount_SaleInvoiceCode%>">
                                                <ItemTemplate>
                                                    <a href="#" data-dismiss="modal" onclick="SetRecievableSetupDetails('<%#Eval("SaleInvoiceCode")%>','<%#Eval("tbl_ReceivableSetupId")%>');">
                                                        <asp:Literal runat="server" ID="ltrgvRecievableSetup" Text='<%# Bind("SaleInvoiceCode") %>'></asp:Literal>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,ReceivableSetupAndGroupAccount_htRecievableSetup%>">
                                                <ItemTemplate>

                                                    <asp:Literal runat="server" ID="ltrgvCustomerCode" Text='<%# Bind("tbl_ReceivableSetupId") %>'></asp:Literal>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, ReceivableSetupAndGroupAccount_htRecievableSetupGuid %>" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgv_RecievableSetup" runat="server" Text='<%# Bind("tbl_ReceivableSetupId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnRecievableSetupSearch" />
                                    <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearRecievableSetupSearch" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="modal-footer row" runat="server" id="div9">
                        <div class="pull-left">
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                <asp:Literal runat="server" ID="ltrRecievableSetupClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
           

        
        </div>
    </div>
</div>
</asp:Content>


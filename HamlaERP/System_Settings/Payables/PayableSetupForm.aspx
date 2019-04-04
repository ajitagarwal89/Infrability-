<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PayableSetupForm.aspx.cs" Inherits="Finance_Accounts_Payable_Setup_PayableSetupForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">  
    <script src="../../infra_ui/js/System_Settings_JS/Payables_JS/PayableSetupForm.js"></script>    
    <script src="../infra_ui/js/CommonJS/CommonValidations.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">


    <div id="content" class="ui-content ui-content-aside-overlay">
        <!--page header start-->
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success"  Text="<%$ Resources:GlobalResource, btnSave%>" OnClick="btnSave_Click"  />
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-success"  Text="<%$ Resources:GlobalResource, btnUpdate%>" OnClick="btnUpdate_Click"  />
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-success"  Text="<%$ Resources:GlobalResource, btnDelete%>" OnClick="btnDelete_Click"  />
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-success"  Text="<%$ Resources:GlobalResource, btnBack%>"  formnovalidate="formnovalidate" OnClick="btnBack_Click" />
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
                    <br />
                    <fieldset>
                        <div class="form-group col-sm-12" style="text-align:justify">
                            <div class="col-sm-3" >
                                <asp:Literal ID="ltrAgingPeriods" runat="server" Text="<%$ Resources:GlobalResource, PayableSetup_ltrAgingPeriods%>"></asp:Literal>
                            </div>

                            <div class="col-sm-3">
                                <asp:RadioButton ID="rdbAgeingDueDate" CausesValidation="false"  ClientIDMode="Static" GroupName="gp" runat="server" Text="<%$ Resources:GlobalResource, PayableSetup_rdbAgeingDueDate%>" />
                            </div>
                            <div class="col-sm-3">
                                <asp:RadioButton ID="rdbAgeingDocumentDate" CausesValidation="false"  ClientIDMode="Static"  GroupName="gp" runat="server" Text="<%$ Resources:GlobalResource, PayableSetup_rdbAgeingDocumentDate%>" />
                            </div>
                            <div class="col-sm-3"> &nbsp;</div>
                        </div>
                    </fieldset>
                </div>
                <div class="form-group col-md-10">
                    <asp:UpdatePanel runat="server" ID="updPanelData">
                        <ContentTemplate>
                            <div runat="server" id="divError" visible="false" class="alert alert-danger" role="alert">
                                <asp:Label runat="server" ID="lblError"></asp:Label>
                            </div>
                            <div runat="server" id="divSuccess" visible="false" class="alert alert-success" role="alert">
                                <asp:Label runat="server" ID="lblSuccess"></asp:Label>
                            </div>
                            <asp:GridView runat="server" DataKeyNames="tbl_PayableSetupPeriodId" ID="gvPeriod" BorderStyle="None" CssClass="table table-hover" ShowFooter="true" AutoGenerateColumns="False" OnRowCommand="gvPeriod_RowCommand" OnRowEditing="gvPeriod_RowEditing" OnRowCancelingEdit="gvPeriod_RowCancelingEdit" OnRowUpdating="gvPeriod_RowUpdating">
                                <HeaderStyle CssClass="headerstyle" />

                                <Columns>
                                    <asp:BoundField DataField="tbl_PayableSetupPeriodId" Visible="false" ReadOnly="true" />
                                  
                                    <asp:TemplateField HeaderText="Current Period">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtCurrentPeriod" Text='<%#Eval("CurrentPeriod") %>'
                                                runat="server" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCurrentPeriod" runat="server" Text='<%# Eval("CurrentPeriod")%>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtCurrentPeriod" runat="server" />
                                        </FooterTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="From">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtFrom" runat="server" Text='<%#Eval("From") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblFrom" runat="server" Text='<%# Eval("From")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtFrom" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="To">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtTo" runat="server" Text='<%#Eval("To") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTo" runat="server" Text='<%# Eval("To")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtTo" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderImageUrl="~/images/edit.png" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="gvColLnkEditBtn" ToolTip="Edit" CommandName="Edit" class="btn btn-default btn-sm btn-block">
                                                <asp:Literal runat="server" ID="ltrEdit"></asp:Literal><span class="glyphicon glyphicon-pencil"></span>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="lbtnUpdate" runat="server" CommandName="Update" ToolTip="Update" class="btn btn-default btn-sm btn-block">
                                                <asp:Literal runat="server" ID="ltrUpdate"></asp:Literal><span class="glyphicon glyphicon-ok"></span>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="lbtnCancel" runat="server" CommandName="Cancel" ToolTip="Cancel" class="btn btn-default btn-sm btn-block">
                                                <asp:Literal runat="server" ID="ltrCancel"></asp:Literal><span class="glyphicon glyphicon-remove"></span>
                                            </asp:LinkButton>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton runat="server" ID="gvColLnkAddBtn" ToolTip="Add" CommandName="Add" class="btn btn-default btn-sm btn-block">
                                                <asp:Literal runat="server" ID="ltrAdd"></asp:Literal><span class="glyphicon glyphicon-plus"></span>
                                            </asp:LinkButton>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>

                                <HeaderStyle BackColor="#24648f" ForeColor="White" />

                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="form-group col-sm-12" style="text-align:justify">
                    <div class="col-sm-3">
                          <asp:Literal ID="ltrApplyBY" runat="server" Text="<%$ Resources:GlobalResource, PayableSetup_ltrApplyBY%>"></asp:Literal>
                    </div>

                    <div class="col-sm-3">
                        <asp:RadioButton ID="rdbApplyByDocumentDate" CausesValidation="false"  ClientIDMode="Static" required="required" GroupName="gp2" runat="server" Text="<%$ Resources:GlobalResource, PayableSetup_rdbApplyByDocumentDate%>" />
                    </div>
                    <div class="col-sm-3">
                        <asp:RadioButton ID="rdbApplyByDuedate" CausesValidation="false"  ClientIDMode="Static" required="required" GroupName="gp2" runat="server" Text="<%$ Resources:GlobalResource, PayableSetup_rdbApplyByDuedate%>" />
                    </div>
                </div>
                <br />
                <div class="form-group col-md-12" style="background-color: #f6f6f6">
                    <h5>
                        <asp:Literal runat="server" ID="ltrdefaults" Text="<%$ Resources:GlobalResource, PayableSetup_ltrdefaults%>"></asp:Literal></h5>
                </div>
                <div class="form-group col-md-4 col-sm-5">

                    <asp:Label runat="server" ID="lblSummaryView" Text="<%$ Resources:GlobalResource, PayableSetup_lblSummaryView %>"></asp:Label>
                    <asp:DropDownList ID="ddlSummaryView" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
                    </asp:DropDownList>
                </div>

                <div class="form-group col-md-4 col-sm-5">
                    <div>
                        <asp:Label runat="server" ID="lblChequeBook" Text="<%$ Resources:GlobalResource, PayableSetup_lblcheckbookid%>"></asp:Label>
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


                <div class="form-group col-md-12" style="background-color: #f6f6f6">
                    <h5>
                        <asp:Literal runat="server" ID="ltrpassword" Text="<%$ Resources:GlobalResource, PayableSetup_ltrpassword%>"></asp:Literal></h5>
                </div>

                <div class="form-group col-md-4 col-sm-4">
                    <asp:Label ID="lblvendorHold" runat="server" Text="<%$ Resources:GlobalResource, PayableSetup_lblvendorHold%>"></asp:Label>

                    <asp:TextBox ID="txtvendorHold"  class="form-control" placeholder="" required="required" onkeypress="return isAlphaNumberKey(this);" MaxLength="20" size="32" runat="server"></asp:TextBox>
                </div>

                <div class="form-group col-md-4 col-sm-4">

                    <asp:Label ID="lblInvoiceamount" runat="server" Text="<%$ Resources:GlobalResource, PayableSetup_lblInvoiceamount%>"></asp:Label>

                    <asp:TextBox ID="txtInvoiceamount"  onkeypress="return isNumberKey(this);" MaxLength="8" size="32" class="form-control" placeholder="" required="required" runat="server"></asp:TextBox>

                </div>
                <div class="form-group col-md-4 col-sm-4">

                    <asp:Label ID="lblWriteOffAmount" runat="server" Text="<%$ Resources:GlobalResource, PayableSetup_lblWriteOffAmount%>"></asp:Label>

                    <asp:TextBox ID="txtWriteOffAmount" onkeypress="return isNumberKey(this);" MaxLength="8" size="34" class="form-control" placeholder="" required="required" runat="server"></asp:TextBox>

                </div>
                <div class="form-group col-md-5">
                    <div style="background-color: #f6f6f6">
                        <h5>
                            <asp:Literal runat="server" ID="ltroptions" Text="<%$ Resources:GlobalResource, PayableSetup_ltroptions%>"></asp:Literal></h5>
                    </div>

                    <div class="form-group">
                        <asp:CheckBox ID="chkTrialbalance" CssClass="form-control" runat="server" Text="<%$ Resources:GlobalResource, PayableSetup_chkTrialbalance %>" />
                  
                        <asp:CheckBox ID="chkPrinteddocuments" runat="server" CssClass="form-control" Text="<%$ Resources:GlobalResource, PayableSetup_chkPrinteddocuments %>" />
                    </div>
                </div>
                &nbsp;
                &nbsp;
                <div class="form-group col-md-4 col-sm-4">
                    <asp:Label ID="lblInvoicespervendor" runat="server" Text="<%$ Resources:GlobalResource, PayableSetup_lblInvoicespervendor %>"></asp:Label>

                    <br />
                    <asp:RadioButton ID="rdbYes" ClientIDMode="Static" required="required" GroupName="gp3"  runat="server" Text="<%$ Resources:GlobalResource, PayableSetup_rdbYes%>" />
                    <asp:RadioButton ID="rdbNo" ClientIDMode="Static" required="required" GroupName="gp3" runat="server" Text="<%$ Resources:GlobalResource, PayableSetup_rdbNo%>" />
                </div>
                 <div class="form-group col-md-12" style="background-color: #f6f6f6">
                            <h5>
                                <asp:Literal runat="server" ID="ltrInvoice" Text="<%$ Resources:GlobalResource, PayableSetup_ltrInvoice%>"></asp:Literal></h5>
                        </div>
                                     <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblInvoiceDescription" Text="<%$ Resources:GlobalResource, PayableSetup_lblInvoiceDescription %>"  ></asp:Label>
                            <asp:TextBox runat="server" ID="txtInvoiceDescription" ClientIDMode="Static" class="form-control" onkeypress="return isAddress(this);" MaxLength="50" placeholder="" required="required"></asp:TextBox>


                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblInvoiceCode" Text="<%$ Resources:GlobalResource, PayableSetup_lblDebitMemosCode%>"  ></asp:Label>
                            <asp:TextBox runat="server" ID="txtInvoiceCode" ClientIDMode="Static" onkeypress="return isAlphaKey(this);" MaxLength="10" class="form-control" placeholder="" required="required"></asp:TextBox>


                        </div>
                   <div class="form-group col-md-12" style="background-color: #f6f6f6">
                            <h5>
                                <asp:Literal runat="server" ID="ltrReturn" Text="<%$ Resources:GlobalResource, PayableSetup_ltrReturn%>"></asp:Literal></h5>
                        </div>
                                     <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblReturnDescription" Text="<%$ Resources:GlobalResource, PayableSetup_lblReturnDescription %>"  ></asp:Label>
                            <asp:TextBox runat="server" ID="txtReturnDescription" ClientIDMode="Static" class="form-control" onkeypress="return isAddress(this);" MaxLength="50" placeholder="" required="required"></asp:TextBox>


                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblReturnCode" Text="<%$ Resources:GlobalResource, PayableSetup_lblReturnCode%>"  ></asp:Label>
                            <asp:TextBox runat="server" ID="txtReturnCode" ClientIDMode="Static" onkeypress="return isAlphaKey(this);" MaxLength="10" class="form-control" placeholder="" required="required"></asp:TextBox>


                        </div>
                  <div class="form-group col-md-12" style="background-color: #f6f6f6">
                            <h5>
                                <asp:Literal runat="server" ID="ltrCreditMemo" Text="<%$ Resources:GlobalResource, PayableSetup_ltrCreditMemo%>"></asp:Literal></h5>
                        </div>
                                     <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblCreditMemoDescription" Text="<%$ Resources:GlobalResource, PayableSetup_lblCreditMemoDescription%>"  ></asp:Label>
                            <asp:TextBox runat="server" ID="txtCreditMemoDescription" ClientIDMode="Static" class="form-control" onkeypress="return isAddress(this);" MaxLength="50" placeholder="" required="required"></asp:TextBox>


                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblCreditMemoCode" Text="<%$ Resources:GlobalResource, PayableSetup_lblCreditMemoCode%>"  ></asp:Label>
                            <asp:TextBox runat="server" ID="txtCreditMemoCode" ClientIDMode="Static" onkeypress="return isAlphaKey(this);" MaxLength="10" class="form-control" placeholder="" required="required"></asp:TextBox>


                        </div>
                   <div class="form-group col-md-12" style="background-color: #f6f6f6">
                            <h5>
                                <asp:Literal runat="server" ID="ltrPayment" Text="<%$ Resources:GlobalResource, PayableSetup_ltrPayment%>"></asp:Literal></h5>
                        </div>
                                     <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPaymentDescription" Text="<%$ Resources:GlobalResource, PayableSetup_lblPaymentDescription%>"  ></asp:Label>
                            <asp:TextBox runat="server" ID="txtPaymentDescription" ClientIDMode="Static" class="form-control" onkeypress="return isAddress(this);" MaxLength="50" placeholder="" required="required"></asp:TextBox>


                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPaymentCode" Text="<%$ Resources:GlobalResource, PayableSetup_lblPaymentCode%>"  ></asp:Label>
                            <asp:TextBox runat="server" ID="txtPaymentCode" ClientIDMode="Static" onkeypress="return isAlphaKey(this);" MaxLength="10" class="form-control" placeholder="" required="required"></asp:TextBox>


                        </div>
                 
                  <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblPayableSetupGroupId" Text="<%$ Resources:GlobalResource, PayableSetup_lblPayableSetupGroupId %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtPayableSetupGroup" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addonPayableSetupGroup">
                                    <a href="#" data-toggle="modal" data-target="#basicModalPayableSetupGroupSearch" data-keyboard="false" data-backdrop="static" onclick="CallPayableGroupRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPayableSetupGroupGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>                    
                <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblPayableSetupAndGroupAccountId" Text="<%$ Resources:GlobalResource, PayableSetup_lblPayableSetupAndGroupAccountId %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtPayableSetupAndGroupAccount" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addonPayableSetupAndGroupAccount">
                                    <a href="#" data-toggle="modal" data-target="#basicModalPayableSetupAndGroupAccountSearch" data-keyboard="false" data-backdrop="static" onclick="CallPayableSetupAndGroupAccountRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPayableSetupAndGroupAccountGUID" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                   <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblGLAccountId_Cash" Text="<%$ Resources:GlobalResource, PayableSetup_lblGLAccountId_Cash %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtGLAccountId_Cash" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-GLAccountId_Cash">
                                    <a href="#" data-toggle="modal" data-target="#basicModalGLAccountId_CashSearch" data-keyboard="false" data-backdrop="static" onclick="CallCashRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountId_CashGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblGLAccountId_AccountReceivable" Text="<%$ Resources:GlobalResource, PayableSetup_lblGLAccountId_AccountReceivable %>"></asp:Label>
                            <div class="input-group">
                                <asp:TextBox ID="txtGLAccountId_AccountReceivable" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-aAccountReceivable">
                                     <a href="#" data-toggle="modal" data-target="#basicModalGLAccountIdAccountReceivable" data-keyboard="false" data-backdrop="static" onclick="CallAccountReceivableRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountId_AccountReceivableGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>

                            </div>

                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblGLAccountId_Sales" Text="<%$ Resources:GlobalResource, PayableSetup_lblGLAccountId_Sales %>"></asp:Label>
                            <div class="input-group">
                                <asp:TextBox ID="txtGLAccountId_Sales" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-Sales">
                                     <a href="#" data-toggle="modal" data-target="#basicModalGLAccountIdSalesSearch" data-keyboard="false" data-backdrop="static" onclick="CallSalesRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountId_SalesGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>

                            </div>

                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblGLAccountId_CostOfSales" Text="<%$ Resources:GlobalResource, PayableSetup_lblGLAccountId_CostOfSales %>"></asp:Label>
                            <div class="input-group">
                                <asp:TextBox ID="txtGLAccountId_CostOfSales" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-CostOfSales">
                                    <a href="#" data-toggle="modal" data-target="#basicModalGLAccountIdCostOfSalesSearch" data-keyboard="false" data-backdrop="static" onclick="CallCostOfSalesRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountId_CostOfSalesGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>

                            </div>

                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblGLAccountId_Inventory" Text="<%$ Resources:GlobalResource, PayableSetup_lblGLAccountId_Inventory %>"></asp:Label>
                            <div class="input-group">
                                <asp:TextBox ID="txtGLAccountId_Inventory" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-Inventory">
                                     <a href="#" data-toggle="modal" data-target="#basicModalGLAccountIdInventorySearch" data-keyboard="false" data-backdrop="static" onclick="CallInventoryRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountId_InventoryGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>

                            </div>

                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblGLAccountId_AccuralDifferedA_C" Text="<%$ Resources:GlobalResource, PayableSetup_lblGLAccountId_AccuralDifferedA_C %>"></asp:Label>
                            <div class="input-group">
                                <asp:TextBox ID="txtGLAccountId_AccuralDifferedA_C" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-AccuralDifferedA_C">
                                    <a href="#" data-toggle="modal" data-target="#basicModalGLAccountIdAccuralDifferedA_CSearch" data-keyboard="false" data-backdrop="static" onclick="CallAccuralDifferedA_CRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountId_AccuralDifferedA_CGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>

                            </div>

                        </div>

                <%-- Modal Popup for basicModalGLAccountId_Cheque Book Search --%>
                
                <div class="modal fade" id="basicModalChequeBookSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalChequeBookTitle"><span>
                        <asp:Literal runat="server" ID="ltrChequeBookTitle" Text="<%$ Resources:GlobalResource, PayableSetup_ltrChequeBookInformation%>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PayableSetup_htChequeBookNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetChequeBookDetails('<%#Eval("ChequeBookName")%>','<%#Eval("tbl_ChequeBookId")%>');">
                                                                <asp:Literal runat="server" ID="ltrgvChequeBookNumber" Text='<%# Bind("ChequeBookNumber") %>'></asp:Literal>
                                                            </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PayableSetup_htChequeBookGuid%>" Visible="false">
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

                 <%-- Modal Popup for basicModalPayableSetupGroupSearch --%>
    <div class="modal fade" id="basicModalPayableSetupGroupSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalPayableSetupGroupTitle"><span>
                        <asp:Literal runat="server" ID="ltrPayableSetupGroupTitle" Text="<%$ Resources:GlobalResource, PayableSetup_ltrPayableSetupGroupInformation%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlPayableSetupGroup">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlPayableSetupGroup" DefaultButton="btnPayableSetupGroupSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtPayableSetupGroupSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlPayableSetupGroupSearch" onclick="CallPayableGroupSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlPayableSetupGroupClose" visible="false" onclick="ClearPayableGroupSearch();" class="fa fa-close closex"></a>
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
                        <div runat="server" id="divPayableSetupGroupSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblPayableSetupGroupSearchSucces"></asp:Label>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PayableSetup_htDescription%>">
                                            <ItemTemplate>
                                                 <a href="#" data-dismiss="modal" onclick="setPayableSetupGroupDetails('<%#Eval("Description")%> ',' <%#Eval("tbl_PayableSetupGroupId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvPayableSetupGroup" Text='<%# Bind("Description") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PayableSetup_htPayableSetupGroupGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayableSetupGroupGuid" runat="server" Text='<%# Bind("tbl_PayableSetupGroupId") %>'></asp:Label>
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
                            <asp:Literal runat="server" ID="lblPayableSetupGroupClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
                <%-- Modal Popup for basicModalPayableSetupAndGroupAccountSearch --%>
    <div class="modal fade" id="basicModalPayableSetupAndGroupAccountSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalPayableSetupAndGroupAccountTitle"><span>
                        <asp:Literal runat="server" ID="ltrPayableSetupAndGroupAccountTitle" Text="<%$ Resources:GlobalResource, PayableSetup_PayableSetupAndGroupAccountInformation%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlPayableSetupAndGroupAccount">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlPayableSetupAndGroupAccount" DefaultButton="btnPayableSetupAndGroupAccountSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtPayableSetupAndGroupAccountSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlPayableSetupAndGroupAccountSearch" onclick="CallPayableSetupAndGroupAccountSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlPayableSetupAndGroupAccountClose" visible="false" onclick="ClearPayableSetupAndGroupAccountSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>

                                <asp:Button runat="server" ID="btnPayableSetupAndGroupAccountSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnPayableSetupAndGroupAccountSearch_Click" formnovalidate="formnovalidate " />
                                <asp:Button runat="server" ID="btnClearPayableSetupAndGroupAccountSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearPayableSetupAndGroupAccountSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divPayableSetupAndGroupAccountSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblPayableSetupAndGroupAccountSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divPayableSetupAndGroupAccountSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblPayableSetupAndGroupAccountSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgPayableSetupAndGroupAccountData" AssociatedUpdatePanelID="updpnlgvPayableSetupAndGroupAccountSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvPayableSetupAndGroupAccountSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnPayableSetupAndGroupAccountRefresh" ClientIDMode="Static" OnClick="btnPayableSetupAndGroupAccountRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvPayableSetupAndGroupAccountSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PayableSetup_htDescription%>">
                                            <ItemTemplate>
                                                 <a href="#" data-dismiss="modal" onclick="setPayableSetupAndGroupAccountDetails('<%#Eval("Description")%> ',' <%#Eval("tbl_PayableSetupAndGroupAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvPayableSetupAndGroupAccount" Text='<%# Bind("Description") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PayableSetup_htPayableSetupAndGroupAccountGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayableSetupAndGroupAccountGuid" runat="server" Text='<%# Bind("tbl_PayableSetupAndGroupAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPayableSetupAndGroupAccountSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearPayableSetupAndGroupAccountSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divPayableSetupAndGroupAccountFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblPayableSetupAndGroupAccountClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
                 <%-- Modal Popup for basicModalGLAccountId_CashSearch  --%>

    <div class="modal fade" id="basicModalGLAccountId_CashSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGLAccountId_CashTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountId_CashTitle" Text="<%$ Resources:GlobalResource, PayableSetup_ltrGLAccountId_CashInformation%>"></asp:Literal>
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

                                <asp:Button runat="server" ID="btnAccountCashSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAccountCashSearch_Click" formnovalidate="formnovalidate " />
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
                                <asp:Button runat="server" ID="btnGLAccountId_CashRefresh" ClientIDMode="Static" OnClick="btnAccountCashRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvGLAccountId_CashSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PayableSetup_htNameSearch_Cash%>">
                                           <ItemTemplate>
                                                    <a href="#" data-dismiss="modal" onclick="SetCashDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvGLAccountId_CashCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PayableSetup_htGLAccountId_CashGuid%>" Visible="false">
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

     <%-- Modal Popup for basicModalGLAccountId_AccountReceivable --%>
    <div class="modal fade" id="basicModalGLAccountIdAccountReceivable" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGLAccountId_AccountReceivableTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountId_AccountReceivableTitle" Text="<%$ Resources:GlobalResource, PayableSetup_ltrGLAccountId_AccountReceivableInformation%>"></asp:Literal>
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

                                <asp:Button runat="server" ID="btnAccountReceivableSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAccountReceivableSearch_Click" formnovalidate="formnovalidate " />
                                <asp:Button runat="server" ID="btnClearAccountReceivableSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearAccountReceivableSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountId_AccountReceivableSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblAccountReceivableSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountId_AccountReceivableSearchSucces" visible="false" class="alert alert-success" role="alert">
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
                                <asp:Button runat="server" ID="btnAccountCashRefresh" ClientIDMode="Static" OnClick="btnAccountCashRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvAccountReceivableSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PayableSetup_htGLAccountId_AccountReceivable%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetAccountReceivableDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvAccountReceivableCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PayableSetup_htGLAccountId_ReceivableGuid%>" Visible="false">
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
                <div class="modal-footer row" runat="server" id="divGLAccountId_AccountReceivableFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblAccountReceivableClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
     <%-- Modal Popup for basicModalGLAccountId_Sales --%>
    <div class="modal fade" id="basicModalGLAccountIdSalesSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGLAccountId_SalesTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountId_SalesTitle" Text="<%$ Resources:GlobalResource, PayableSetup_ltrGLAccountId_SalesInformation%>"></asp:Literal>
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

                                <asp:Button runat="server" ID="btnSalesSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnSalesSearch_Click" formnovalidate="formnovalidate " />
                                <asp:Button runat="server" ID="btnClearSalesSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearSalesSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountId_SalesSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblSalesSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountId_SalesSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblSalesSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgGLAccountId_SalesData" AssociatedUpdatePanelID="updpnlgvGLAccountId_SalesSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountId_SalesSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnSalesRefresh" ClientIDMode="Static" OnClick="btnSalesRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvSalesSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PayableSetup_htGLAccountId_SalesNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetSalesDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                                <asp:Literal runat="server" ID="ltrgvSalesCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                            </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PayableSetup_htGLAccountId_SalesGuid%>" Visible="false">
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
                <div class="modal-footer row" runat="server" id="divGLAccountId_SalesFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblSalesClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
     <%-- Modal Popup for basicModalGLAccountId_CostOfSales --%>
    <div class="modal fade" id="basicModalGLAccountIdCostOfSalesSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGLAccountId_CostOfSalesTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountId_CostOfSalesTitle" Text="<%$ Resources:GlobalResource, PayableSetup_ltrGLAccountId_CostOfSalesInformation%>"></asp:Literal>
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

                                <asp:Button runat="server" ID="btnCostOfSalesSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnCostOfSalesSearch_Click" formnovalidate="formnovalidate " />
                                <asp:Button runat="server" ID="btnClearCostOfSalesSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearCostOfSalesSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountId_CostOfSalesSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblCostOfSalesSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountId_CostOfSalesSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblCostOfSalesSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgGLAccountId_CostOfSalesData" AssociatedUpdatePanelID="updpnlgvGLAccountId_CostOfSalesSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountId_CostOfSalesSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnCostOfSalesRefresh" ClientIDMode="Static" OnClick="btnCostOfSalesRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvCostOfSalesSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PayableSetup_htGLAccountId_CostOfSalesNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCostOfSalesDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCostOfSales" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PayableSetup_htGLAccountId_CostOfSalesGuid%>" Visible="false">
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
                <div class="modal-footer row" runat="server" id="divGLAccountId_CostOfSalesFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblCostOfSalesClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
   <%-- Modal Popup for basicModalGLAccountId_Inventory --%>
<div class="modal fade" id="basicModalGLAccountIdInventorySearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGLAccountId_InventoryTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountId_InventoryTitle" Text="<%$ Resources:GlobalResource, PayableSetup_ltrGLAccountId_InventoryInformation%>"></asp:Literal>
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

                                <asp:Button runat="server" ID="btnInventorySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnInventorySearch_Click" formnovalidate="formnovalidate " />
                                <asp:Button runat="server" ID="btnClearInventorySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearInventorySearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountId_InventorySearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_InventorySearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountId_InventorySearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_InventorySearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgGLAccountId_InventoryData" AssociatedUpdatePanelID="updpnlgvGLAccountId_InventorySearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountId_InventorySearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnInventoryRefresh" ClientIDMode="Static" OnClick="btnInventoryRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvInventorySearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PayableSetup_htGLAccountId_InventoryNumber%>">
                                            <ItemTemplate>
                                              <a href="#" data-dismiss="modal" onclick="SetInventoryDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvInventoryInventoryCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PayableSetup_htGLAccountId_InventoryGuid%>" Visible="false">
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
                <div class="modal-footer row" runat="server" id="divGLAccountId_InventoryFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblGLAccountId_InventoryClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
     <%-- Modal Popup for basicModalGLAccountId_AccuralDifferedA_C --%>
    <div class="modal fade" id="basicModalGLAccountIdAccuralDifferedA_CSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGLAccountId_AccuralDifferedA_CTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountId_AccuralDifferedA_CTitle" Text="<%$ Resources:GlobalResource, PayableSetup_ltrGLAccountId_AccuralDifferedA_CInformation%>"></asp:Literal>
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

                                <asp:Button runat="server" ID="btnAccuralDifferedA_CSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAccuralDifferedA_CSearch_Click" formnovalidate="formnovalidate " />
                                <asp:Button runat="server" ID="btnClearAccuralDifferedA_CSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearAccuralDifferedA_CSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountId_AccuralDifferedA_CSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_AccuralDifferedA_CSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountId_AccuralDifferedA_CSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountId_AccuralDifferedA_CSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgGLAccountId_AccuralDifferedA_CData" AssociatedUpdatePanelID="updpnlgvGLAccountId_AccuralDifferedA_CSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountId_AccuralDifferedA_CSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnAccuralDifferedA_CRefresh" ClientIDMode="Static" OnClick="btnAccuralDifferedA_CRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvAccuralDifferedA_CSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PayableSetup_htGLAccountId_AccuralDifferedA_CNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetAccuralDifferedA_CDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrAccuralDifferedA_CCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PayableSetup_htGLAccountId_AccuralDifferedA_CGuid%>" Visible="false">
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
                <div class="modal-footer row" runat="server" id="divGLAccountId_AccuralDifferedA_CFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblGLAccountId_AccuralDifferedA_CClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
            </div>
        </div>
    </div>
</asp:Content>


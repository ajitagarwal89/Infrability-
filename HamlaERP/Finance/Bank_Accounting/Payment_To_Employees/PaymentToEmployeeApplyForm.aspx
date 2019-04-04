<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PaymentToEmployeeApplyForm.aspx.cs" Inherits="Finance_Bank_Accounting_Payment_To_Employees_PaymentToEmployeeApplyForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Bank_Accounting_JS/Payment_To_Employee_JS/PaymentToEmployeeApplyForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, PaymentToEmployeeApply_ltrInformation%>"></asp:Literal></h5>
                        </div>
                     
                        <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblPaymentToEmployeeId" Text="<%$ Resources:GlobalResource, PaymentToEmployeeApply_lblPaymentToEmployeeId%>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtPaymentToEmployee" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon">
                                    <a href="#" data-toggle="modal" data-target="#basicModalPaymentToEmployeeSearch" data-keyboard="false" data-backdrop="static" onclick="CallPaymentToEmployeeRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPaymentToEmployeeGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                      <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblApplyToDocumentEmployeeGeneralExpenses" Text="<%$ Resources:GlobalResource, PaymentToSupplierApply_lblApplyToDocumentEmployeeGeneralExpenses %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtApplyToDocumentEmployeeGeneralExpenses" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon_lblApplyToDocumentEmployeeGeneralExpenses">
                                    <a href="#" data-toggle="modal" data-target="#basicModalApplyToDocumentEmployeeGeneralExpensesSearch" data-keyboard="false" data-backdrop="static" onclick="CallApplyToDocumentEmployeeGeneralExpensesRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtApplyToDocumentEmployeeGeneralExpensesGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>


                       <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDueDate" Text="<%$ Resources:GlobalResource, PaymentToEmployeeApply_lblDueDate%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDueDate" TextMode="Date" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                        
                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblRemainingAmount" Text="<%$ Resources:GlobalResource, PaymentToEmployeeApply_lblRemainingAmount%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtRemainingAmount" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                    </div>

                        
                      <div class="form-group col-md-4 col-sm-4">

                        <asp:Label runat="server" ID="lblApplyAmount" Text="<%$ Resources:GlobalResource, PaymentToEmployeeApply_lblApplyAmount%>"></asp:Label>
                        <asp:TextBox runat="server" ID="txtApplyAmount" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                    </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblopt_Type" Text="<%$ Resources:GlobalResource, PaymentToEmployeeApply_lblopt_Type %>"></asp:Label>
                            <asp:DropDownList ID="ddloptType" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:DropDownList>
                        </div>
                        
                    <div class="form-group col-md-4 col-sm-4">

                        <asp:Label runat="server" ID="lblOrignalDocumentAmount" Text="<%$ Resources:GlobalResource, PaymentToEmployeeApply_lblOrignalDocumentAmount%>"></asp:Label>
                        <asp:TextBox runat="server" ID="txtOrignalDocumentAmount" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                    </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDiscountDate" Text="<%$ Resources:GlobalResource, PaymentToEmployeeApply_lblDiscountDate%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDiscountDate" TextMode="Date" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>                                           
                </div>

                      <div class="form-group col-md-12" style="background-color: #f6f6f6">
                                <h5>
                                    <asp:Literal runat="server" ID="ltrPaymentToEmployee" Text="<%$ Resources:GlobalResource, PaymentToEmployeeApply_lblPaymentToEmployee%>"></asp:Literal></h5>
                            </div>

                            <div id="divPaymentToEmployee" runat="server" class="form-group col-md-12 col-sm-12">
                                <%--<h3 class="hepad">
                                <asp:Label runat="server" ID="lblDownPaymentFromCustomerId" Text="<%$ Resources:GlobalResource, DownPaymentFromCustomerApply_lblDownPaymentFromCustomer %>"></asp:Label>
                            </h3>--%>
                                <div>
                                    <div class="form-group col-md-4 col-sm-4">
                                        <asp:Label runat="server" ID="lblEmployeeId" Text="<%$ Resources:GlobalResource, PaymentToEmployeeApply_lblEmployeeId%>"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtEmployeeId" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-4 col-sm-4">
                                        <asp:Label runat="server" ID="lblEmployeeName" Text="<%$ Resources:GlobalResource, PaymentToEmployeeApply_lblEmployeeName%>"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtEmployeename" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-4 col-sm-4">
                                        <asp:Label runat="server" ID="lblType" Text="<%$ Resources:GlobalResource, PaymentToEmployeeApply_lblType%>"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtType" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-4 col-sm-4">
                                        <asp:Label runat="server" ID="lblCurrency" Text="<%$ Resources:GlobalResource, PaymentToEmployeeApply_lblCurrency%>"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtCurrencyID" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-4 col-sm-4">
                                        <asp:Label runat="server" ID="lblDocumentNo" Text="<%$ Resources:GlobalResource, PaymentToEmployeeApply_lblDocumentNo%>"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtDocumentNumber" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-4 col-sm-4">
                                        <asp:Label runat="server" ID="lblOrignalAmount" Text="<%$ Resources:GlobalResource, PaymentToEmployeeApply_lblOrignalAmount%>"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtOrignalAmount" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-4 col-sm-4">
                                        <asp:Label runat="server" ID="lblApplyDate" Text="<%$ Resources:GlobalResource, PaymentToEmployeeApply_lblApplyDate%>"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtApplydate" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-4 col-sm-4">
                                        <asp:Label runat="server" ID="lblUnappliedAmount" Text="<%$ Resources:GlobalResource, PaymentToEmployeeApply_lblUnappliedAmount%>"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtUnappliedAmount" ReadOnly="true" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                                    </div>

                                </div>
                            </div>



                            <div class="form-group col-md-12 col-sm-12">
                                <asp:DataGrid runat="server" ClientIDMode="Static" Font-Size="10pt" ID="gvData" AutoGenerateColumns="False" Width="100%" GridLines="None" CssClass="table table-hover" CellPadding="4" ForeColor="#333333">
                                    <AlternatingItemStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundColumn DataField="tbl_PaymentToEmployeeApplyId" Visible="false"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PaymentToEmployeeApply_htPaymentToEmployee%>" DataField="tbl_Employee"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PaymentToEmployeeApply_htDueDate%>" DataField="DueDate"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PaymentToEmployeeApply_htApplyAmount%>" DataField="ApplyAmount"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PaymentToEmployeeApply_htopt_Type%>" DataField="Type"></asp:BoundColumn>                                   
                                    </Columns>
                                    <EditItemStyle BackColor="#7C6F57" />
                                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                                    <ItemStyle BackColor="#E3EAEB" />
                                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                </asp:DataGrid>
                            </div>
                        </div>
                    </div>
                </div>
            </div> 

            <div class="modal fade" id="basicModalPaymentToEmployeeSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalPaymentToEmployeeTitle"><span>
                        <asp:Literal runat="server" ID="ltrPaymentToEmployeeTitle" Text="<%$ Resources:GlobalResource, PaymentToEmployeeApply_ltrPaymentToEmployeeTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlPaymentToEmployeeSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlPaymentToEmployeeSearch" DefaultButton="btnPaymentToEmployeeSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtPaymentToEmployeeSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlPaymentToEmployeeSearch" onclick="CallPaymentToEmployeeSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlPaymentToEmployeeClose" visible="false" onclick="ClearPaymentToEmployeeSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnPaymentToEmployeeSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnPaymentToEmployeeSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearPaymentToEmployeeSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearPaymentToEmployeeSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divPaymentToEmployeeSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblPaymentToEmployeeSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divPaymentToEmployeeSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblPaymentToEmployeeSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgPaymentToEmployeeData" AssociatedUpdatePanelID="updpnlgvPaymentToEmployeeSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvPaymentToEmployeeSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnPaymentToEmployeeRefresh" ClientIDMode="Static" OnClick="btnPaymentToEmployeeRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvPaymentToEmployeeSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                       <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentToEmployeeApply_htEmployeeName%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetPaymentToEmployeeDetails('<%#Eval("EmployeeName")%>','<%#Eval("tbl_PaymentToEmployeeId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvEmployeeName" Text='<%# Bind("EmployeeName") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentToEmployeeApply_htEmployeeGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvEmployeeId" runat="server" Text='<%# Bind("tbl_PaymentToEmployeeId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPaymentToEmployeeSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearPaymentToEmployeeSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrPaymentToEmployeeClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
     <div class="modal fade" id="basicModalApplyToDocumentEmployeeGeneralExpensesSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrApplyToDocumentEmployeeGeneralExpensesTitle"><span>
                        <asp:Literal runat="server" ID="ltr_ApplyToDocumentEmployeeGeneralExpenses" Text="<%$ Resources:GlobalResource, PaymentToEmployeeApply_ltrApplyToDocumentEmployeeGeneralExpenses %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlApplyToDocumentEmployeeGeneralExpenses">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlApplyToDocumentEmployeeGeneralExpensesSearch" DefaultButton="btnApplyToDocumentEmployeeGeneralExpensesSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtApplyToDocumentEmployeeGeneralExpensesSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlApplyToDocumentEmployeeGeneralExpensesSearch" onclick="CallApplyToDocumentEmployeeGeneralExpensesSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlApplyToDocumentEmployeeGeneralExpensesClose" visible="false" onclick="ClearApplyToDocumentEmployeeGeneralExpensesSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnApplyToDocumentEmployeeGeneralExpensesSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnApplyToDocumentEmployeeGeneralExpensesSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearApplyToDocumentEmployeeGeneralExpensesSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearApplyToDocumentEmployeeGeneralExpensesSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divApplyToDocumentEmployeeGeneralExpensesSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblApplyToDocumentEmployeeGeneralExpensesSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divApplyToDocumentEmployeeGeneralExpensesSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblApplyToDocumentEmployeeGeneralExpensesSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateApplyToDocumentEmployeeGeneralExpensesProgress" AssociatedUpdatePanelID="updpnlgvApplyToDocumentEmployeeGeneralExpensesSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvApplyToDocumentEmployeeGeneralExpensesSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnApplyToDocumentEmployeeGeneralExpensesRefresh" ClientIDMode="Static" OnClick="btnApplyToDocumentEmployeeGeneralExpensesRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvApplyToDocumentEmployeeGeneralExpensesSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PaymentToEmployeeApply_htVoucherNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetApplyToDocumentEmployeeGeneralExpensesDetails('<%#Eval("VoucherNumber")%>','<%#Eval("tbl_EmployeeGeneralExpensesId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvVoucherNumber" Text='<%# Bind("VoucherNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentToEmployeeApply_htInterCompany%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInterCompany" runat="server" Text='<%# Bind("InterCompany") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentToEmployeeApply_htEmployeeName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmployeeName" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PaymentToEmployeeApply_htEmployeeGeneralExpensesGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmployeeGeneralExpensesId" runat="server" Text='<%# Bind("tbl_EmployeeGeneralExpensesId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnApplyToDocumentEmployeeGeneralExpensesSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearApplyToDocumentEmployeeGeneralExpensesSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div2">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrApplyToDocumentEmployeeGeneralExpensesClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PaymentToSupplierEmployeeDistributionForm.aspx.cs" Inherits="Finance_Bank_Accounting_Payment_To_Employees_PaymentToSupplierEmployeeDistributionForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">    
    <script src="../../../infra_ui/js/Finance_JS/Bank_Accounting_JS/Payment_To_SupplierEmployee_JS/PaymentToSupplierEmployeeDistributionForm.js"></script>
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
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-success" OnClick="btnBack_Click" Text="<%$ Resources:GlobalResource, btnBack%>"  formnovalidate="formnovalidate" />
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
                                <asp:Literal runat="server" ID="ltrDownPaymentFromCustomerDistribution" Text="<%$ Resources:GlobalResource, PaymentToSupplierEmployeeDistribution_ltrinformation%>"></asp:Literal></h5>
                        </div>
                       
                        
                         <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblEmployeeId" Text="<%$ Resources:GlobalResource, PaymentToSupplierEmployeeDistribution_lblEmployeeid%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtPaymentToSupplierEmployee" ReadOnly="true" ClientIDMode="Static" runat="server" AutoPostBack="true"  CssClass="form-control"  ></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon2">
                                     <a href="#" data-toggle="modal" data-target="#basicModalPaymentToSupplierEmployeeSearch" data-keyboard="false" data-backdrop="static" onclick="CallPaymentToSupplierEmployeeRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPaymentToSupplierEmployeeGuid" AutoPostBack="true"  runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
               

                         <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblGLAccountId" Text="<%$ Resources:GlobalResource, PaymentToSupplierEmployeeDistribution_lblGLAccountId%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtGLAccount" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon1">
                                     <a href="#" data-toggle="modal" data-target="#basicModalGLAccountSearch" data-keyboard="false" data-backdrop="static" onclick="CallGLAccountRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOptionType" Text="<%$ Resources:GlobalResource,PaymentToSupplierEmployeeDistribution_lblOptionType  %>"></asp:Label>
                            <asp:DropDownList ID="ddlOptionType" runat="server" ClientIDMode="Static" class="form-control" required="required"  ></asp:DropDownList>
                        </div>

                         <div class="form-group col-md-4 col-sm-4" id="divDebit" runat="server" >
                            <asp:Label runat="server" ID="lblDebit" Text="<%$ Resources:GlobalResource,PaymentToSupplierEmployeeDistribution_lblDebit  %>"></asp:Label>
                           <asp:TextBox ID="txtDebit"  runat="server" ClientIDMode="Static" class="form-control" required="required"></asp:TextBox>
                        </div>

                         <div class="form-group col-md-4 col-sm-4" id="divOriginatingDebit" runat="server" >
                            <asp:Label runat="server" ID="lblOriginatingDebit" Text="<%$ Resources:GlobalResource,PaymentToSupplierEmployeeDistribution_lblOriginatingDebit %>"></asp:Label>
                           <asp:TextBox ID="txtOriginatingDebit"  runat="server" ClientIDMode="Static" class="form-control" required="required"></asp:TextBox>
                        </div>

                         <div class="form-group col-md-4 col-sm-4" id="divCredit" runat="server" >
                            <asp:Label runat="server" ID="lblCredit" Text="<%$ Resources:GlobalResource,PaymentToSupplierEmployeeDistribution_lblCredit %>"></asp:Label>
                           <asp:TextBox ID="txtCredit"  runat="server" ClientIDMode="Static" class="form-control" required="required"></asp:TextBox>
                        </div>

                         <div class="form-group col-md-4 col-sm-4" id="divOriginatingCredit" runat="server" >
                            <asp:Label runat="server" ID="lblOriginatingCredit" Text="<%$ Resources:GlobalResource,PaymentToSupplierEmployeeDistribution_lblOriginatingCredit %>"></asp:Label>
                           <asp:TextBox ID="txtOriginatingCredit"  runat="server" ClientIDMode="Static" class="form-control" required="required"></asp:TextBox>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource,PaymentToSupplierEmployeeDistribution_lblDescription%>"></asp:Label>
                           <asp:TextBox ID="txtDescription" TextMode="MultiLine"  runat="server" ClientIDMode="Static" class="form-control" required="required"></asp:TextBox>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDistributionReference" Text="<%$ Resources:GlobalResource,PaymentToSupplierEmployeeDistribution_lblDistributionReference%>"></asp:Label>
                           <asp:TextBox ID="txtDistributionReference"  runat="server" ClientIDMode="Static" class="form-control" required="required"></asp:TextBox>
                        </div>

                         <div class="form-group col-md-4 col-sm-4" id="divCountry" runat="server" visible="false">
                               <asp:Label runat="server" ID="lblCompanyId" Text="<%$ Resources:GlobalResource,PaymentToSupplierDistribution_lblCompanyId%>"></asp:Label>
                                <asp:TextBox ID="txtCompanyId"  runat="server" ClientIDMode="Static" class="form-control" ></asp:TextBox>
                             </div>

                         <div class="form-group col-md-4 col-sm-4" id="divCorrespondenceCompanyId" runat="server" visible="false">
                               <asp:Label runat="server" ID="lblCorrespondenceCompanyId" Text="<%$ Resources:GlobalResource, PaymentToSupplierEmployeeDistribution_lblCorrespondenceCompanyId%>"></asp:Label>
                                <asp:TextBox ID="txtCorrespondenceCompanyId"  runat="server" ClientIDMode="Static" class="form-control"></asp:TextBox>
                             </div>
                      
                           <div id="divEmployee" runat="server">
                <div class="form-group col-md-12" style="background-color: #f6f6f6">
                    <h5>
                        <asp:Literal runat="server" ID="ltrEmployeeDetails" Text="<%$ Resources:GlobalResource, PaymentToSupplierEmployeeDistribution_ltrEmployeeDetails%>"></asp:Literal></h5>
                </div>
                <div class="form-group col-md-4 col-sm-4" id="divEmpCode" runat="server">
                    <asp:Label runat="server" ID="lblEmployeeCode" Text="<%$ Resources:GlobalResource,PaymentToSupplierEmployeeDistribution_lblEmployeeCode %>"></asp:Label>
                    <asp:TextBox ID="txtEmployeeCode" runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                </div>
                <div class="form-group col-md-4 col-sm-4" id="divEmpName" runat="server">
                    <asp:Label runat="server" ID="lblEmployeeName" Text="<%$ Resources:GlobalResource,PaymentToSupplierEmployeeDistribution_lblEmployeeName %>"></asp:Label>
                    <asp:TextBox ID="txtEmployeeName" runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                </div>
                <div class="form-group col-md-4 col-sm-4" id="divPayment" runat="server">
                    <asp:Label runat="server" ID="lblPaymentNo" Text="<%$ Resources:GlobalResource,PaymentToSupplierEmployeeDistribution_lblPaymentNumber %>"></asp:Label>
                    <asp:TextBox ID="txtPaymentNumber" runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                </div>
                <div class="form-group col-md-4 col-sm-4" id="div2" runat="server">
                    <asp:Label runat="server" ID="lblDocumentNumber" Text="<%$ Resources:GlobalResource,PaymentToSupplierEmployeeDistribution_lblDocumentNumber %>"></asp:Label>
                    <asp:TextBox ID="txtDocumentNumber" runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                </div>
                <div class="form-group col-md-4 col-sm-4" id="divDocumenttype" runat="server">
                    <asp:Label runat="server" ID="lblDocumenttype" Text="<%$ Resources:GlobalResource,PaymentToSupplierEmployeeDistribution_lblDocumentType %>"></asp:Label>
                    <asp:TextBox ID="txtDocumentType" runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                </div>
                <div class="form-group col-md-4 col-sm-4" id="divCurrencyName" runat="server">
                    <asp:Label runat="server" ID="lblCurrencyName" Text="<%$ Resources:GlobalResource,PaymentToSupplierEmployeeDistribution_lblCurrencyName %>"></asp:Label>
                    <asp:TextBox ID="txtCurrencyName" runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                </div>
                <div class="form-group col-md-4 col-sm-4" id="divfunctionAmt" runat="server">
                    <asp:Label runat="server" ID="lblfunctionalAmount" Text="<%$ Resources:GlobalResource,PaymentToSupplierEmployeeDistribution_lblFunctionalAmount %>"></asp:Label>
                    <asp:TextBox ID="txtfunctionalAmount" runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                </div>
                <div class="form-group col-md-4 col-sm-4" id="divOriginatingAmount" runat="server">
                    <asp:Label runat="server" ID="lblOriginatingAmount" Text="<%$ Resources:GlobalResource,PaymentToSupplierEmployeeDistribution_lblOrginatingAmount %>"></asp:Label>
                    <asp:TextBox ID="txtOriginatingAmount" runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                </div>
                <div class="form-group col-md-4 col-sm-4" id="divReferenceNo" runat="server">
                    <asp:Label runat="server" ID="lblReferenceNo" Text="<%$ Resources:GlobalResource,PaymentToSupplierEmployeeDistribution_lblDistributionReferenceNo %>"></asp:Label>
                    <asp:TextBox ID="txtReferenceNo" runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" required="required"></asp:TextBox>
                </div>
            </div>
            <asp:DataGrid runat="server" ClientIDMode="Static" Font-Size="10pt" ID="gvData" AutoGenerateColumns="False" Width="100%" GridLines="None" CssClass="table table-hover" CellPadding="4" ForeColor="#333333">
                <AlternatingItemStyle BackColor="White" />
                <Columns>
                    <asp:BoundColumn DataField="tbl_PaymentToEmployeeId" Visible="false"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PaymentToEmployee_htEmployeeCode %>" DataField="EmployeeCode"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PaymentToEmployee_htGLAccount %>" DataField="tbl_GLAccount"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PaymentToEmployee_htType %>" DataField="Type"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PaymentToEmployee_htDebit %>" DataField="Debit"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PaymentToEmployee_htOriginatingDebit %>" DataField="OriginatingDebit"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PaymentToEmployee_htCredit %>" DataField="Credit"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PaymentToEmployee_htOriginatingCredit %>" DataField="OriginatingCredit"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PaymentToEmployee_htDownTotal%>" DataField="Total"></asp:BoundColumn>
                     <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PaymentToEmployee_htApplyDate%>" DataField="ApplyDate"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, PaymentToEmployee_htDistributionReference%>" DataField="DistributionReference"></asp:BoundColumn>
                </Columns>

                <EditItemStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#EFF3FB" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            </asp:DataGrid>
                    </div>
                </div>
            </div>

      <div class="modal fade" id="basicModalPaymentToSupplierEmployeeSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalDownPaymentToSupplierEmployeeTitle"><span>
                        <asp:Literal runat="server" ID="ltrPaymentToSupplierEmployeeTitle" Text="<%$ Resources:GlobalResource, PaymentToSupplierEmployeeDistribution_ltrPaymentToSupplierEmployeeTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlDownPaymentToSupplierEmployeeSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlDownPaymentToSupplierEmployeeSearch" DefaultButton="btnPaymentToSupplierEmployeeSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtPaymentToSupplierEmployeeSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlPaymentToSupplierEmployeeSearch" onclick="CallPaymentToSupplierEmployeeSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlPaymentToSupplierEmployeeClose" visible="false" onclick="ClearPaymentToSupplierEmployeeSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnPaymentToSupplierEmployeeSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnPaymentToSupplierEmployeeSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearPaymentToSupplierEmployeeSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearPaymentToSupplierEmployeeSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divPaymentToSupplierEmployeeSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblPaymentToSupplierEmployeeSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divPaymentToSupplierEmployeeSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblPaymentToSupplierEmployeeSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgPaymentToSupplierEmployeeData" AssociatedUpdatePanelID="updpnlgvPaymentToSupplierEmployeeSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvPaymentToSupplierEmployeeSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnPaymentToSupplierEmployeeRefresh" ClientIDMode="Static" OnClick="btnPaymentToSupplierEmployeeRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvPaymentToSupplierEmployeeSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>   <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentToSupplierEmployeeDistribution_htSupplierEmployeeName%>">                                    
                                             
                                            <ItemTemplate>
                                                 <a href="#" data-dismiss="modal" onclick="SetPaymentToSupplierEmployeeDetails('<%#Eval("SupplierEmployeeName")%>','<%#Eval("tbl_PaymentToSupplierEmployeeId")%>');">
                                                    <asp:Label ID="lblgvDownPaymentToSupplierEmployeeName" runat="server" Text='<%# Bind("SupplierEmployeeName") %>'></asp:Label>
                                          
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                 
                                     
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentToSupplierEmployeeDistribution_htPaymentNumber%>">
                                            <ItemTemplate>
                                              
                                                  <asp:Literal runat="server" ID="ltrgvPaymentToSupplierEmployeeType" Text='<%# Bind("PaymentNumber") %>'></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentToSupplierEmployeeDistribution_htPaymentToSupplierEmployeeGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPaymentToSupplierEmployeeGuid" runat="server" Text='<%# Bind("tbl_PaymentToSupplierEmployeeId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPaymentToSupplierEmployeeSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearPaymentToSupplierEmployeeSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrPaymentToSupplierEmployeeClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>                          
             <div class="modal fade" id="basicModalGLAccountSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGlAccountTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountTitle" Text="<%$ Resources:GlobalResource, PaymentToSupplierDistribution_ltrGLAccountId%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlGLAccount">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlGLAccount" DefaultButton="btnGLAccountSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtGLAccountSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlGLAccountSearch" onclick="CallGLAccountSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlGLAccountClose" visible="false" onclick="ClearGLAccountSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnGLAccountSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnGLAccountSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearGLAccountSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearGLAccountSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgGLAccountData" AssociatedUpdatePanelID="updpnlgvGLAccountSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnGLAccountRefresh" ClientIDMode="Static" OnClick="btnGLAccountRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvGLAccountSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentToSupplierDistribution_htAccountNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetGLAccountDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvGLAccountCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentToSupplierDistribution_htGLAccountGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvGLAccountGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnGLAccountSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearGLAccountSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divGLAccountFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblGLAccountClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
        </div>
           </div>
</asp:Content>


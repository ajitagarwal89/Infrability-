<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GLAccountBudgetForm.aspx.cs" Inherits="Finance_General_Ledger_GL_Integration_GLAccountBudgetForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/General_Ledger_JS/GL_Integration_JS/GLAccountBudgetForm.js"></script>
	<script src="../../../infra_ui/js/CommonJS/CommonValidations.js"></script>
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
                                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, GLAccountBudget_ltrInformation%>"></asp:Literal></h5>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblGLAccountId" Text="<%$ Resources:GlobalResource, GLAccountBudget_lblGLAccountId %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtGLAccount" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon">
                                    <a href="#" data-toggle="modal" data-target="#basicModalGLAccountSearch" data-keyboard="false" data-backdrop="static" onclick="CallGLAccountRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>


                          <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblBudgetId" Text="<%$ Resources:GlobalResource, GLAccountBudget_lblBudgetId %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtBudget" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon2">
                                    <a href="#" data-toggle="modal" data-target="#basicModalBudgetSearch" data-keyboard="false" data-backdrop="static" onclick="CallBudgetRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtBudgetGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
						  <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblButdetId_SourceBudgetId" Text="<%$ Resources:GlobalResource, GLAccountBudget_lblButdetId_SourceBudgetId %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtButdetId_SourceBudgetId" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon3">
                                    <a href="#" data-toggle="modal" data-target="#basicModalSourceBudgetSearch" data-keyboard="false" data-backdrop="static" onclick="CallSourceBudgetRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtButdetId_SourceBudgetGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lbOpt_BasedOn" Text="<%$ Resources:GlobalResource, GLAccountBudget_lblOpt_BasedOn %>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_BasedOn" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOpt_BudgetYear" Text="<%$ Resources:GlobalResource, GLAccountBudget_lblOpt_BudgetYear %>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_BudgetYear" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOpt_CalculationMethod" Text="<%$ Resources:GlobalResource, GLAccountBudget_lblOpt_CalculationMethod %>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_CalculationMethod" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                          <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblYear" Text="<%$ Resources:GlobalResource, GLAccountBudget_lblYear%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtYear" ClientIDMode="Static" class="form-control" placeholder=""  onkeypress="return isNumberKey(this);" maxlength="4"  required="required"></asp:TextBox>
                        </div>

                      

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblPercentage" Text="<%$ Resources:GlobalResource, GLAccountBudget_lblPercentage%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtPercentage" ClientIDMode="Static" class="form-control" onkeypress="return isNumberKeyPoint(this);" maxlength="9"   placeholder="" required="required"></asp:TextBox>
                        </div>


                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblAmount" Text="<%$ Resources:GlobalResource, GLAccountBudget_lblAmount%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtAmount" ClientIDMode="Static" class="form-control"  onkeypress="return isNumberKeyPoint(this);" maxlength="9"  placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblIsIncrease" Text="<%$ Resources:GlobalResource, GLAccountBudget_lblIsIncrease%>"></asp:Label>

                            <asp:CheckBox ID="chkIsIncrease" runat="server"  ClientIDMode="Static" class="form-control" placeholder="" required="required"/>
                        </div>
                          
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDisplay" Text="<%$ Resources:GlobalResource, GLAccountBudget_lblDisplay%>"></asp:Label>

                            <asp:CheckBox ID="chkDisplay" runat="server"  ClientIDMode="Static" class="form-control" placeholder="" required="required"/>
                        </div>   
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblIncludeBiginningBalance" Text="<%$ Resources:GlobalResource, GLAccountBudget_lblIncludeBiginningBalance%>"></asp:Label>

                            <asp:CheckBox ID="chkIncludeBiginningBalance" runat="server"  ClientIDMode="Static" class="form-control" placeholder="" required="required"/>
                        </div>
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
                    <h4 class="modal-title" id="hdrModalGLAccountTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountTitle" Text="<%$ Resources:GlobalResource, GLAccountBudget_ltrGLAccountTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlGLAccountSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlGLAccountSearch" DefaultButton="btnGLAccountSearch">
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
                        <div runat="server" id="divGLAccountSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountSearchSuccess"></asp:Label>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountBudget_htGLAccountNumber%>">
                                            <ItemTemplate>
                                                 <a href="#" data-dismiss="modal" onclick="SetGLAccountDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                   
                                               <asp:Literal runat="server" ID="ltrgvGLAccountType" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountBudget_htGLAccountGuid%>" Visible="false">
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
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrGLAccountClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
      <div class="modal fade" id="basicModalBudgetSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalBudgetTitle"><span>
                        <asp:Literal runat="server" ID="ltrBudgetTitle" Text="<%$ Resources:GlobalResource, GLAccountBudget_ltrBudgetTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlBudgetSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlBudgetSearch" DefaultButton="btnBudgetSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtBudgetSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlBudgetSearch" onclick="CallBudgetSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlBudgetClose" visible="false" onclick="ClearBudgetSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnBudgetSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnBudgetSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearBudgetSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearBudgetSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divBudgetSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblBudgetSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divBudgetSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblBudgetSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgBudgetData" AssociatedUpdatePanelID="updpnlgvBudgetSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvBudgetSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnBudgetRefresh" ClientIDMode="Static" OnClick="btnBudgetRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvBudgetSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountBudget_htBudgetNumber%>">
                                            <ItemTemplate>
                                                 <a href="#" data-dismiss="modal" onclick="SetBudgetDetails('<%#Eval("BudgetNumber")%>','<%#Eval("tbl_BudgetId")%>');">
                                                   
                                               <asp:Literal runat="server" ID="ltrgvBudgetNumber" Text='<%# Bind("BudgetNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountBudget_htDescription%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvBudgetDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountBudget_htBudgetGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvBudgetGuid" runat="server" Text='<%# Bind("tbl_BudgetId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnBudgetSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearBudgetSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div1">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrBudgetClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

     <div class="modal fade" id="basicModalSourceBudgetSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalSourceBudgetTitle"><span>
                        <asp:Literal runat="server" ID="ltrSourceBudgetTitle" Text="<%$ Resources:GlobalResource, GLAccountBudget_ltrSourceBudgetTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlSourceBudgetSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlSourceBudgetSearch" DefaultButton="btnSourceBudgetSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtSourceBudgetSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlSourceBudgetSearch" onclick="CallSourceBudgetSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlSourceBudgetClose" visible="false" onclick="ClearSourceBudgetSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnSourceBudgetSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnSourceBudgetSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearSourceBudgetSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearSourceBudgetSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divSourceBudgetSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblSourceBudgetSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divSourceBudgetSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblSourceBudgetSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgSourceBudgetData" AssociatedUpdatePanelID="updpnlgvSourceBudgetSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvSourceBudgetSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnSourceBudgetRefresh" ClientIDMode="Static" OnClick="btnSourceBudgetRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvSourceBudgetSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                       <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountBudget_htBudgetNumber%>">
                                            <ItemTemplate>
                                                 <a href="#" data-dismiss="modal" onclick="SetSourceBudgetDetails('<%#Eval("BudgetNumber")%>','<%#Eval("tbl_BudgetId")%>');">
                                                   
                                               <asp:Literal runat="server" ID="ltrgvSourceBudgetNumber" Text='<%# Bind("BudgetNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountBudget_htDescription%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvSourceBudgetDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccountBudget_htSourceBudgetGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvSourceBudgetGuid" runat="server" Text='<%# Bind("tbl_BudgetId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnSourceBudgetSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearSourceBudgetSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div2">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrSourceBudgetClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>


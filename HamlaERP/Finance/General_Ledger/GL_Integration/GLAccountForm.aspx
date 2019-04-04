<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GLAccountForm.aspx.cs" Inherits="Finance_General_Ledger_GL_Integration_GLAccountForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/General_Ledger_JS/GL_Integration_JS/GLAccountForm.js"></script>
    <script src="../../../infra_ui/js/CommonJS/CommonValidations.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <!--page header start-->
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" OnClick="btnSave_Click" Text="<%$ Resources:GlobalResource, btnSave%>" />
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-success" OnClick="btnUpdate_Click" Text="<%$ Resources:GlobalResource, btnUpdate%>" />
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-success" OnClick="btnDelete_Click" Text="<%$ Resources:GlobalResource, btnDelete%>" formnovalidate="formnovalidate" />
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
                        <div runat="server" id="divSuccess" visible="false" class="alert alert-success" role="alert" onclick="divhide()">
                            <asp:Label runat="server" ID="lblSuccess"></asp:Label>
                        </div>
                        <div class="form-group col-md-12" style="background-color: #f6f6f6">
                            <h5>
                                <asp:Literal runat="server" ID="ltrGLAccountInformation" Text="<%$ Resources:GlobalResource, GLAccount_ltrGlAccountInformation%>"></asp:Literal></h5>
                        </div>
                        <div class="form-group col-md-12">
                            <div class="form-group col-md-1 col-sm-1">
                                <asp:DropDownList ID="ddlSegment01" runat="server" ClientIDMode="Static" class="form-control " Width="100px" placeholder="" AutoPostBack="True" OnSelectedIndexChanged="ddlSegment01_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>

                            <div class="form-group col-md-1 col-sm-1">
                                <asp:DropDownList ID="ddlSegment02" runat="server" ClientIDMode="Static" class="form-control " Width="100px" placeholder="" AutoPostBack="True" OnSelectedIndexChanged="ddlSegment02_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>

                            <div class="form-group col-md-1 col-sm-1">
                                <asp:DropDownList ID="ddlSegment03" runat="server" ClientIDMode="Static" class="form-control " Width="100px" placeholder="" required="required" AutoPostBack="True" OnSelectedIndexChanged="ddlSegment03_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            
                            <div class="form-group col-md-1 col-sm-1">
                                <asp:DropDownList ID="ddlSegment04" runat="server" ClientIDMode="Static" class="form-control " Width="100px" placeholder="" required="required" AutoPostBack="True" OnSelectedIndexChanged="ddlSegment04_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>

                            <div class="form-group col-md-1 col-sm-1">
                                <asp:DropDownList ID="ddlSegment05" runat="server" ClientIDMode="Static" class="form-control " Width="100px" placeholder="" required="required" AutoPostBack="True" OnSelectedIndexChanged="ddlSegment05_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>

                            <div class="form-group col-md-1 col-sm-1">
                                <asp:DropDownList ID="ddlSegment06" runat="server" ClientIDMode="Static" class="form-control " Width="100px" placeholder="" required="required" AutoPostBack="True" OnSelectedIndexChanged="ddlSegment06_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>

                            <div class="form-group col-md-1 col-sm-1">
                                <asp:DropDownList ID="ddlSegment07" runat="server" ClientIDMode="Static" class="form-control " Width="100px" placeholder="" required="required" AutoPostBack="True" OnSelectedIndexChanged="ddlSegment07_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>

                            <div class="form-group col-md-1 col-sm-1">
                                <asp:DropDownList ID="ddlSegment08" runat="server" ClientIDMode="Static" class="form-control " Width="100px" placeholder="" required="required" AutoPostBack="True" OnSelectedIndexChanged="ddlSegment08_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>

                            <div class="form-group col-md-1 col-sm-1">
                                <asp:DropDownList ID="ddlSegment09" runat="server" ClientIDMode="Static" class="form-control " Width="100px" placeholder="" required="required" AutoPostBack="True" OnSelectedIndexChanged="ddlSegment09_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>

                            <div class="form-group col-md-1 col-sm-1">
                                <asp:DropDownList ID="ddlSegment10" runat="server" ClientIDMode="Static" class="form-control " Width="100px" placeholder="" required="required" AutoPostBack="True" OnSelectedIndexChanged="ddlSegment10_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>

                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAccountNumber" Text="<%$ Resources:GlobalResource, GLAccount_lblAccountNumber%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtAccountNumber" ClientIDMode="Static" class="form-control " placeholder="" required="required" aufocus="autofocus"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblInactive" Text="<%$ Resources:GlobalResource, GLAccount_lblInactive%>"></asp:Label>
                            <asp:CheckBox runat="server" ID="chkInActive"  ClientIDMode="Static" class="form-control" PlaceHolder="" required="required"></asp:CheckBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAllowAccountEntry" Text="<%$ Resources:GlobalResource, GLAccount_lblAllowAccountEntry %>"></asp:Label>
                            <asp:CheckBox runat="server" ID="chkAllowAccountEntry"  ClientIDMode="Static" class="form-control" PlaceHolder="" required="required"></asp:CheckBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblGLAccountCategoryId" Text="<%$ Resources:GlobalResource, GLAccount_lblGLAccountCategoryId%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtGLAccountCategory" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon4">
                                    <a href="#" data-toggle="modal" data-target="#basicModalGLAccountCategorySearch" data-keyboard="false" data-backdrop="static" onclick="CallGLAccountCategoryRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountCategoryGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPostingType" Text="<%$ Resources:GlobalResource, GLAccount_lblPostingType %>"></asp:Label>
                           
                            <asp:RadioButton ID="rdbBalanceSheet" class="form-control"  ClientIDMode="Static" runat="server" CausesValidation="false" GroupName="grPostingType"  Text="<%$ Resources:GlobalResource, GLAccount_rdbBalanceSheet%>" />
                            <asp:RadioButton ID="rdbProfitAndLoss" class="form-control" ClientIDMode="Static" runat="server" CausesValidation="false" GroupName="grPostingType"  Text="<%$ Resources:GlobalResource, GLAccount_rdbProfitAndLoss%>" />
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblTypicalBalance" Text="<%$ Resources:GlobalResource, GLAccount_lblTypicalBalance %>"></asp:Label>
                            
                            
                            <asp:RadioButton ID="rdbDebit" class="form-control" runat="server"  ClientIDMode="Static"  CausesValidation="false" GroupName="grTypicalBalance" Text="<%$ Resources:GlobalResource, GLAccount_rdbDebit%>" />
                            <asp:RadioButton ID="rdbCredit" class="form-control" runat="server" ClientIDMode="Static"  CausesValidation="false" GroupName="grTypicalBalance" Text="<%$ Resources:GlobalResource, GLAccount_rdbCredit%>" />
                                   
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAppearInFinance" Text="<%$ Resources:GlobalResource, GLAccount_lblAppearInFinance %>"></asp:Label>
                            <asp:CheckBox runat="server" ID="chkAppearInFinance"  ClientIDMode="Static" class="form-control" PlaceHolder="" required="required"></asp:CheckBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAppearInHR" Text="<%$ Resources:GlobalResource, GLAccount_lblAppearInHR %>"></asp:Label>
                            <asp:CheckBox runat="server" ID="chkAppearInHR"  ClientIDMode="Static" class="form-control" PlaceHolder="" required="required"></asp:CheckBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAppearInProcurement" Text="<%$ Resources:GlobalResource, GLAccount_lblAppearInProcurement %>"></asp:Label>
                            <asp:CheckBox runat="server" ID="chkAppearInProcurement"  ClientIDMode="Static" class="form-control" PlaceHolder="" required="required"></asp:CheckBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAppearInSystemSettings" Text="<%$ Resources:GlobalResource, GLAccount_lblAppearInSystemSettings %>"></asp:Label>
                            <asp:CheckBox runat="server" ID="chkAppearInSystemSettings"  ClientIDMode="Static" class="form-control" PlaceHolder="" required="required"></asp:CheckBox>
                        </div>

                        <div class="form-group col-md-8 col-sm-8">
                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource, GLAccount_lblDescription%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDescription" ClientIDMode="Static" class="form-control " placeholder="" required="required" aufocus="autofocus"></asp:TextBox>
                        </div>

                    </div>

                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="basicModalGLAccountCategorySearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGlAccountCategoryTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountCategoryTitle" Text="<%$ Resources:GlobalResource, GLAccount_lblGLAccount%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlGLAccountCategory">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlGLAccount" DefaultButton="btnGLAccountCategorySearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtGLAccountCategorySearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlGLAccountCategorySearch" onclick="CallGLAccountCategorySearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlGLAccountCategoryClose" visible="false" onclick="ClearGLAccountCategorySearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnGLAccountCategorySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnGLAccountCategorySearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearGLAccountCategorySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearGLAccountCategorySearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountCategorySearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountCategorySearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountCategorySearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountCategorySearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgGLAccountCategoryData" AssociatedUpdatePanelID="updpnlgvGLAccountCategorySearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountCategorySearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnGLAccountCategoryRefresh" ClientIDMode="Static" OnClick="btnGLAccountCategoryRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvGLAccountCategorySearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static" OnPageIndexChanging="gvGLAccountCategorySearch_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccount_AccountCategory%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetGLAccountCategoryDetails('<%#Eval("Description")%>','<%#Eval("tbl_GLAccountCategoryId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvGLAccountCategoryCode" Text='<%# Bind("Description") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccount_htCategoryNumber %>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvGLAccountCategory" runat="server" Text='<%# Bind("CategoryNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GLAccount_GLAccountCategoryGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvGLAccountCategoryGuid" runat="server" Text='<%# Bind("tbl_GLAccountCategoryId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnGLAccountCategorySearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearGLAccountCategorySearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divGLAccountCategoryFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblGLAccountClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


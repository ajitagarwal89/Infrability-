<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GeneralJournalForm.aspx.cs" Inherits="System_Settings_GeneralJournalForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../infra_ui/js/CommonJS/CommonValidations.js"></script>
    <script src="../../../infra_ui/js/Finance_JS/General_Ledger_JS/GL_GeneralJournal_JS/GeneralJournalForm.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">

    <div id="content" class="ui-content ui-content-aside-overlay">
        <!--page header start-->
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" OnClick="btnSave_Click" Text="<%$ Resources:GlobalResource, btnSave%>" formnovalidate="formnovalidate" />
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-success" OnClick="btnUpdate_Click" Text="<%$ Resources:GlobalResource, btnUpdate%>" formnovalidate="formnovalidate" />
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-success" OnClick="btnDelete_Click" Text="<%$ Resources:GlobalResource, btnDelete%>" formnovalidate="formnovalidate"></asp:Button>
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-success" OnClick="btnBack_Click" Text="<%$ Resources:GlobalResource, btnBack%>" formnovalidate="formnovalidate" />
                    <asp:Button runat="server" ID="btnClear" CssClass="btn btn-success" OnClientClick="return ClearForm();" Text="<%$ Resources:GlobalResource, btnClear%>" formnovalidate="formnovalidate"></asp:Button>
                    <asp:Button runat="server" ID="btnAuditHistory" CssClass="btn btn-success" Text="<%$ Resources:GlobalResource, btnAuditHistory%>" formnovalidate="formnovalidate" OnClick="btnAuditHistory_Click" />
                    <asp:Button runat="server" ID="btnPost" CssClass="btn btn-success" OnClick="btnPost_Click" Text="<%$ Resources:GlobalResource, btnPost%>" formnovalidate="formnovalidate"></asp:Button>
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
                                <asp:Literal runat="server" ID="ltr_GeneralJournal_information" Text="<%$ Resources:GlobalResource, GeneralJournal_ltrInformation%>"></asp:Literal></h5>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblGeneralJournalEntry" Text="<%$ Resources:GlobalResource, GeneralJournal_lblGeneralJournalEntry %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtJournalEntry" ClientIDMode="Static" class="form-control" placeholder=""></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblGeneralJournalId_Self" Text="<%$ Resources:GlobalResource, GeneralJournal_lblGeneralJournalId_Self %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtGeneralJournalId_Self" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addonGeneralJournalDetail">
                                    <a href="#" data-toggle="modal" data-target="#basicModalGeneralJournalId_SelfSearch" data-keyboard="false" data-backdrop="static" onclick="CallGeneralJournalId_SelfRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGeneralJournalId_SelfGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblGeneralJournalType" Text="<%$ Resources:GlobalResource, GeneralJournal_lblGeneralJournalType%>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_GeneralJournalType" runat="server" ClientIDMode="Static" class="form-control" placeholder="">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblTransactionType" Text="<%$ Resources:GlobalResource, GeneralJournal_lblTransactionType %>"></asp:Label>
                            <asp:Panel ID="pnlRadioButton" runat="server" class="form-control">
                                <asp:RadioButton ID="rdbStanndard" runat="server" ClientIDMode="Static" GroupName="rdbgntype" Text="<%$ Resources:GlobalResource, GeneralJournal_rdbStanndard %>" />
                                <asp:RadioButton ID="rdbReversing" runat="server" ClientIDMode="Static" GroupName="rdbgntype" Text="<%$ Resources:GlobalResource, GeneralJournal_rdbReversing %>" />
                            </asp:Panel>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblTransactionDate" Text="<%$ Resources:GlobalResource, GeneralJournal_lblTransactionDate %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtTransactionDate" ClientIDMode="Static" class="form-control" placeholder="" TextMode="Date" AutoPostBack="True" OnTextChanged="txtTransactionDate_TextChanged"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblReference" Text="<%$ Resources:GlobalResource, GeneralJournal_lblReference %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtReference" ClientIDMode="Static" onkeypress="return isAlphaKey(this);" MaxLength="50" class="form-control" Placeholder=""></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblBatchId" Text="<%$ Resources:GlobalResource, GeneralJournal_lblBatchId %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtBatch" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control" ></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon">
                                    <a href="#" data-toggle="modal" data-target="#basicModalBatchSearch" data-keyboard="false" data-backdrop="static" onclick="CallBatchRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtBatchGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCurrencyId" Text="<%$ Resources:GlobalResource, GeneralJournal_lblCurrencyId %>"></asp:Label>
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
                                <asp:Label runat="server" ID="lblSourceDocument" Text="<%$ Resources:GlobalResource, GeneralJournal_lblSourceDocument %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtSourceDocument" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon2">
                                    <a href="#" data-toggle="modal" data-target="#basicModalSourceDocumentSearch" data-keyboard="false" data-backdrop="static" onclick="CallSource_DocumentRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtSourceDocumentGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>                        
                        <div class="form-group col-md-12 col-sm-12">
                            <div id="divGeneralJournalDetailsAdd" runat="server">
                                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                    <ContentTemplate>
                                        <asp:Button runat="server" ID="btnAdd"
                                            data-toggle="modal" data-target="#divBasicModalGeneralJournalAdd" data-backdrop="static" class="btn btn-default btn-sm btn-block"
                                            CssClass="btn btn-success" Text="<%$ Resources:GlobalResource, ltrAdd%>" OnClientClick="SetDetailsGeneral();" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <asp:DataGrid ID="gvData" runat="server" ClientIDMode="Static" Font-Size="10pt" AutoGenerateColumns="False" 
                                Width="100%" DataKeyField="tbl_GeneralJournalDetailsId" GridLines="None" BorderStyle="None" CssClass="table table-hover" AllowPaging="True" PageSize="5" PagerStyle-Mode="NumericPages" OnPageIndexChanged="gvData_PageIndexChanged">
                                <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                <Columns>
                                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, GeneralJournal_httblGeneralJournalDetailsId%>" DataField="tbl_GeneralJournalDetailsId" Visible="false" />
                                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, GeneralJournal_httbl_GeneralJournalId%>" DataField="tbl_GeneralJournal" />
                                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, GeneralJournal_httbl_GLAccount%>" DataField="tbl_GLAccountId" Visible="false" />
                                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, GeneralJournal_htAccountNumber%>" DataField="tbl_GLAccount" />
                                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, GeneralJournal_htDebit%>" DataField="Debit" />
                                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, GeneralJournal_htCredit%>" DataField="Credit" />
                                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, GeneralJournal_htDescription%>" DataField="Description" />
                                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, GeneralJournal_htDistributionReference%>" DataField="DistributionReference" />
                                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, GeneralJournal_httbl_CompanyId%>" DataField="tbl_OrganizationId_Company" Visible="false" />
                                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, GeneralJournal_htCompanyId%>" DataField="Company" />
                                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, GeneralJournal_htTotalDebit%>" DataField="TotalDebit" />
                                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, GeneralJournal_htTotalCredit%>" DataField="TotalCredit" />
                                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, GeneralJournal_htDifference%>" DataField="Difference" />

                                    <asp:TemplateColumn HeaderImageUrl="~/images/eye.png"  HeaderStyle-HorizontalAlign="Center" >
                                        <ItemTemplate>
                                            <button id="lnkView" type="button" data-toggle="modal" data-target="#divBasicModalGeneralJournalView" data-keyboard="false" data-backdrop="static" class="btn btn-default btn-sm btn-block"
                                                onclick="SetDetailsView('<%#Eval("Company")%>','<%#Eval("tbl_GeneralJournal")%>','<%#Eval("tbl_GLAccount")%>','<%#Eval("Debit")%>','<%#Eval("Credit")%>','<%#Eval("Description")%>','<%#Eval("DistributionReference")%>','<%#Eval("TotalDebit")%>','<%#Eval("TotalCredit")%>','<%#Eval("Difference")%>','lnkview_<%# Container.DataSetIndex + 1 %>');">
                                                <asp:Literal runat="server" ID="ltrView" Text="<%$ Resources:GlobalResource, ltrView%>"></asp:Literal></button>
                                        </ItemTemplate>                                        
                                    </asp:TemplateColumn>

                                    <asp:TemplateColumn HeaderImageUrl="~/images/edit.png" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <button id="lnkUpdate" type="button" data-toggle="modal" data-target="#divBasicModalGeneralJournalUpdate" data-keyboard="false" data-backdrop="static" class="btn btn-default btn-sm btn-block"
                                                onclick="SetDetailsUpdate('<%#Eval("Company")%>','<%#Eval("tbl_OrganizationId_Company")%>','<%#Eval("tbl_GeneralJournal")%>','<%#Eval("tbl_GLAccount")%>','<%#Eval("tbl_GLAccountId")%>','<%#Eval("Debit")%>','<%#Eval("Credit")%>','<%#Eval("Description")%>','<%#Eval("DistributionReference")%>','<%#Eval("TotalDebit")%>','<%#Eval("TotalCredit")%>','<%#Eval("Difference")%>','<%#Eval("tbl_GeneralJournalDetailsId")%>','lnkview_<%# Container.DataSetIndex + 1 %>');">
                                                <asp:Literal runat="server" ID="ltrUpdate" Text="<%$ Resources:GlobalResource, ltrEdit%>"></asp:Literal></button>
                                        </ItemTemplate>                                       
                                    </asp:TemplateColumn>

                                    <asp:TemplateColumn HeaderImageUrl="~/images/edit.png" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkDelete" class="btn btn-default btn-sm btn-block" OnClick="lnkDelete_Click" CommandArgument='<%#Eval("tbl_GeneralJournalDetailsId") %>'>
                                                <asp:Literal runat="server" ID="ltrDeletr" Text="<%$ Resources:GlobalResource, ltrDelete%>"></asp:Literal>
                                            </asp:LinkButton>
                                        </ItemTemplate>                                       
                                    </asp:TemplateColumn>

                                </Columns>
                                <PagerStyle Mode="NumericPages"></PagerStyle>
                            </asp:DataGrid>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
   
    <div class="modal fade" id="divBasicModalGeneralJournalUpdate" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabelUpdate"><span>
                        <asp:Literal runat="server" ID="ltrRecordDetailsUpdate" Text="<%$ Resources:GlobalResource, GeneralJournal_ltrGeneralJournalDetails %>"></asp:Literal></span></h4>
                </div>
                <div class="modal-body">
                    <div class="form-group col-md-4 col-sm-4">
                        <asp:Label runat="server" ID="lblGeneralJournalUpdate" Text="<%$ Resources:GlobalResource, GeneralJournalDetails_lblGeneralJournal%>"></asp:Label>
                        <asp:TextBox ID="txtGeneralJournalUpdate" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                        <asp:TextBox ID="txtGeneralJournalDetailsGuid" ClientIDMode="Static" runat="server" CssClass="form-control" Style="display: none;"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4 col-sm-4">
                        <div>
                            <asp:Label runat="server" ID="lblCompanyUpdate" Text="<%$ Resources:GlobalResource, GeneralJournal_Company %>"></asp:Label>
                        </div>
                        <div class="input-group">
                            <asp:TextBox ID="txtCompanyUpdate" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                            <span class="input-group-addon lookup" id="sizing-addonCompanyUpdate">
                                <a href="#" data-toggle="modal" data-target="#basicModalCompanyUpdSearch" data-keyboard="false" data-backdrop="static" onclick="CallCompanyRefreshUpdButton();" ">
                                    <i class="fa fa-search"></i>
                                </a>
                            </span>

                            <asp:TextBox ID="txtCompanyGuidUpdate" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-md-4 col-sm-4">
                        <div>
                            <asp:Label runat="server" ID="lblGLAccountUpdate" Text="<%$ Resources:GlobalResource, GeneralJournal_lblGLAccount %>"></asp:Label>
                        </div>
                        <div class="input-group">
                            <asp:TextBox ID="txtGLAccountUpdate" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                            <span class="input-group-addon lookup" id="sizing-addonUpdate">
                                <a href="#" data-toggle="modal" data-target="#basicModalGLAccountUpdSearch" data-keyboard="false" data-backdrop="static" onclick="CallGLAccountUpdRefreshButton();" ">
                                    <i class="fa fa-search"></i>
                                </a>
                            </span>

                            <asp:TextBox ID="txtGLAccountGuidUpdate" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group col-md-4 col-sm-4">
                        <asp:Label runat="server" ID="lblDebitUpdate" Text="<%$ Resources:GlobalResource, GeneralJournal_lblDebit %>"></asp:Label>
                        <asp:TextBox ID="txtDebitUpdate" runat="server" ClientIDMode="Static" class="form-control" onkeypress="return isNumberKey(this);" placeholder="" required="required" />
                    </div>
                    <div class="form-group col-md-4 col-sm-4">
                        <asp:Label runat="server" ID="lblCreditUpdate" Text="<%$ Resources:GlobalResource, GeneralJournal_lblCredit %>"></asp:Label>
                        <asp:TextBox ID="txtCreditUpdate" onkeypress="return isNumberKey(this);" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required" />
                    </div>
                    <div class="form-group col-md-4 col-sm-4">
                        <asp:Label runat="server" ID="lblDescriptionUpdate" Text="<%$ Resources:GlobalResource, GeneralJournal_lblDescription %>"></asp:Label>
                        <asp:TextBox ID="txtDescriptionUpdate" runat="server" ClientIDMode="Static" class="form-control" onkeypress="return isAddress(this);" placeholder="" required="required" />
                    </div>

                    <div class="form-group col-md-4 col-sm-4">
                        <asp:Label runat="server" ID="lblDistributionReferenceUpdate" Text="<%$ Resources:GlobalResource, GeneralJournal_lblDistributionReference %>"></asp:Label>
                        <asp:TextBox ID="txtDistributionReferenceUpdate" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required" />
                    </div>
                    <div class="form-group col-md-4 col-sm-4">
                        <asp:Label runat="server" ID="lblTotalDebitUpdate" Text="<%$ Resources:GlobalResource, GeneralJournal_lblTotalDebit %>"></asp:Label>
                        <asp:TextBox ID="txtTotalDebitUpdate" runat="server" onkeypress="return isNumberKey(this);" ClientIDMode="Static" class="form-control" placeholder="" required="required" />
                    </div>
                    <div class="form-group col-md-4 col-sm-4">
                        <asp:Label runat="server" ID="lblTotalCreditUpdate" Text="<%$ Resources:GlobalResource, GeneralJournal_lblTotalCredit %>"></asp:Label>
                        <asp:TextBox ID="txtTotalCreditUpdate" runat="server" onkeypress="return isNumberKey(this);" ClientIDMode="Static" class="form-control" placeholder="" required="required" />
                    </div>

                    <div class="form-group col-md-4 col-sm-4">
                        <asp:Label runat="server" ID="lblDifferenceUpdate" Text="<%$ Resources:GlobalResource, GeneralJournal_lblDifference %>"></asp:Label>
                        <asp:TextBox ID="txtDifferenceUpdate" runat="server" onkeypress="return isNumberKey(this);" ClientIDMode="Static" class="form-control" placeholder="" required="required" />
                    </div>

                </div>

                <div class="modal-footer row" runat="server" id="div3">
                    <div class="pull-right">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrClose" Text="<%$ Resources:GlobalResource, ltrClose%>"></asp:Literal></button>

                        <asp:Button ID="btnGenerelJournalDetailUpdate" runat="server" class="btn btn-default"
                            Text="<%$ Resources:GlobalResource, ltrUpdate%>"
                            OnClick="btnGenerelJournalDetailUpdate_Click" formnovalidate="formnovalidate" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="divBasicModalGeneralJournalAdd" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabelAdd"><span>
                        <asp:Literal runat="server" ID="ltrRecordDetailsAdd" Text="<%$ Resources:GlobalResource, GeneralJournal_ltrGeneralJournalDetails %>"></asp:Literal></span></h4>
                </div>
                <div class="modal-body">
                    <div class="form-group col-md-4 col-sm-4">
                        <asp:Label runat="server" ID="lblGeneralJournalAdd" Text="<%$ Resources:GlobalResource, GeneralJournalDetails_lblGeneralJournal%>"></asp:Label>
                        <asp:TextBox ID="txtGeneralJournalAdd" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                    </div>
                    <div class="form-group col-md-4 col-sm-4">
                        <div>
                            <asp:Label runat="server" ID="lblCompanyAdd" Text="<%$ Resources:GlobalResource, GeneralJournal_Company %>"></asp:Label>
                        </div>
                        <div class="input-group">
                            <asp:TextBox ID="txtCompanyAdd" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                            <span class="input-group-addon lookup" id="sizing-addonCompanyAdd">
                                <a href="#" data-toggle="modal" data-target="#basicModalCompanySearch" data-keyboard="false" data-backdrop="static" onclick="CallCompanyRefreshButton();" ">
                                    <i class="fa fa-search"></i>
                                </a>
                            </span>

                            <asp:TextBox ID="txtCompanyGuidAdd" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-md-4 col-sm-4">
                        <div>
                            <asp:Label runat="server" ID="lblGLAccountAdd" Text="<%$ Resources:GlobalResource, GeneralJournal_lblGLAccount %>"></asp:Label>
                        </div>
                        <div class="input-group">
                            <asp:TextBox ID="txtGLAccountAdd" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                            <span class="input-group-addon lookup" id="sizing-addonAdd">
                                <a href="#" data-toggle="modal" data-target="#basicModalGLAccountSearch" data-keyboard="false" data-backdrop="static" onclick="CallGLAccountRefreshButton();" ">
                                    <i class="fa fa-search"></i>
                                </a>
                            </span>

                            <asp:TextBox ID="txtGLAccountGuidAdd" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group col-md-4 col-sm-4">
                        <asp:Label runat="server" ID="lblDebitAdd" Text="<%$ Resources:GlobalResource, GeneralJournal_lblDebit %>"></asp:Label>
                        <asp:TextBox ID="txtDebitAdd" runat="server" ClientIDMode="Static" onkeypress="return isNumberKey(this);" class="form-control" placeholder="" required="required" />
                    </div>
                    <div class="form-group col-md-4 col-sm-4">
                        <asp:Label runat="server" ID="lblCreditAdd" Text="<%$ Resources:GlobalResource, GeneralJournal_lblCredit %>"></asp:Label>
                        <asp:TextBox ID="txtCreditAdd" runat="server" ClientIDMode="Static" onkeypress="return isNumberKey(this);" class="form-control" placeholder="" required="required" />
                    </div>
                    <div class="form-group col-md-4 col-sm-4">
                        <asp:Label runat="server" ID="lblDescriptionAdd" Text="<%$ Resources:GlobalResource, GeneralJournal_lblDescription %>"></asp:Label>
                        <asp:TextBox ID="txtDescriptionAdd" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required" />
                    </div>

                    <div class="form-group col-md-4 col-sm-4">
                        <asp:Label runat="server" ID="lblDistributionReferenceAdd" Text="<%$ Resources:GlobalResource, GeneralJournal_lblDistributionReference %>"></asp:Label>
                        <asp:TextBox ID="txtDistributionReferenceAdd" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required" />
                    </div>
                    <div class="form-group col-md-4 col-sm-4">
                        <asp:Label runat="server" ID="lblTotalDebitAdd" Text="<%$ Resources:GlobalResource, GeneralJournal_lblTotalDebit %>"></asp:Label>
                        <asp:TextBox ID="txtTotalDebitAdd" runat="server" ClientIDMode="Static" onkeypress="return isNumberKey(this);" class="form-control" placeholder="" required="required" />
                    </div>
                    <div class="form-group col-md-4 col-sm-4">
                        <asp:Label runat="server" ID="lblTotalCreditAdd" Text="<%$ Resources:GlobalResource, GeneralJournal_lblTotalCredit %>"></asp:Label>
                        <asp:TextBox ID="txtTotalCreditAdd" runat="server" onkeypress="return isNumberKey(this);" ClientIDMode="Static" class="form-control" placeholder="" required="required" />
                    </div>

                    <div class="form-group col-md-4 col-sm-4">
                        <asp:Label runat="server" ID="lblDifferenceAdd" Text="<%$ Resources:GlobalResource, GeneralJournal_lblDifference %>"></asp:Label>
                        <asp:TextBox ID="txtDifferenceAdd" runat="server" onkeypress="return isNumberKey(this);" ClientIDMode="Static" class="form-control" placeholder="" required="required" />
                    </div>
                </div>

                <div class="modal-footer row" runat="server" id="div5">
                    <div class="pull-right">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="Literal1" Text="<%$ Resources:GlobalResource, ltrClose%>"></asp:Literal></button>
                        <asp:Button ID="Button1" runat="server" class="btn btn-default" role="button" Text="<%$ Resources:GlobalResource,GeneralJournal_btnGenerelJournalDetailSave%>" OnClick="btnGenerelJournalDetailSave_Click" formnovalidate="formnovalidate" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="divBasicModalGeneralJournalView" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabelView"><span>
                        <asp:Literal runat="server" ID="ltrRecordDetailsView" Text="<%$ Resources:GlobalResource, GeneralJournal_ltrGeneralJournalDetails %>"></asp:Literal></span></h4>
                </div>

                <div class="modal-body">
                    <div class="form-group col-md-4 col-sm-4">
                        <div>
                            <asp:Label runat="server" ID="lblGeneralJournalView" Text="<%$ Resources:GlobalResource, GeneralJournalDetails_lblGeneralJournal%>"></asp:Label>
                            <asp:TextBox ID="txtGeneralJournalView" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-md-4 col-sm-4">

                        <asp:Label runat="server" ID="lblCompanyView" Text="<%$ Resources:GlobalResource, GeneralJournal_Company %>"></asp:Label>
                        <asp:TextBox ID="txtCompanyView" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                    </div>
                    <div class="form-group col-md-4 col-sm-4">

                        <asp:Label runat="server" ID="lblGLAccountView" Text="<%$ Resources:GlobalResource, GeneralJournal_lblGLAccount %>"></asp:Label>
                        <asp:TextBox ID="txtGLAccountView" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                    </div>

                    <div class="form-group col-md-4 col-sm-4">
                        <asp:Label runat="server" ID="lblDebitView" Text="<%$ Resources:GlobalResource, GeneralJournal_lblDebit %>"></asp:Label>
                        <asp:TextBox ID="txtDebitView" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4 col-sm-4">
                        <asp:Label runat="server" ID="lblCreditView" Text="<%$ Resources:GlobalResource, GeneralJournal_lblCredit %>"></asp:Label>
                        <asp:TextBox ID="txtCreditView" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4 col-sm-4">
                        <asp:Label runat="server" ID="lblDescriptionView" Text="<%$ Resources:GlobalResource, GeneralJournal_lblDescription %>"></asp:Label>
                        <asp:TextBox ID="txtDescriptionView" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-4 col-sm-4">
                        <asp:Label runat="server" ID="lblDistributionReferenceView" Text="<%$ Resources:GlobalResource, GeneralJournal_lblDistributionReference %>"></asp:Label>
                        <asp:TextBox ID="txtDistributionReferenceView" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4 col-sm-4">
                        <asp:Label runat="server" ID="lblTotalDebitView" Text="<%$ Resources:GlobalResource, GeneralJournal_lblTotalDebit %>"></asp:Label>
                        <asp:TextBox ID="txtTotalDebitView" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4 col-sm-4">
                        <asp:Label runat="server" ID="lblTotalCreditView" Text="<%$ Resources:GlobalResource, GeneralJournal_lblTotalCredit %>"></asp:Label>
                        <asp:TextBox ID="txtTotalCreditView" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-4 col-sm-4">
                        <asp:Label runat="server" ID="lblDifferenceView" Text="<%$ Resources:GlobalResource, GeneralJournal_lblDifference %>"></asp:Label>
                        <asp:TextBox ID="txtDifferenceView" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                </div>

                <div class="modal-footer row" runat="server" id="divView">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrCloseView" Text="<%$ Resources:GlobalResource, ltrClose%>"></asp:Literal>
                        </button>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalBatchSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalBatchTitle"><span>
                        <asp:Literal runat="server" ID="ltrBatchTitle" Text="<%$ Resources:GlobalResource, GeneralJournal_ltrBatch_List %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlBatchSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlBatchSearch" DefaultButton="btnBatchSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtBatchSearch" CssClass="form-control" placeholder="Search..." autofocus=""></asp:TextBox>
                                        <a runat="server" id="btnHtmlBatchSearch" onclick="CallBatchSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlBatchClose" visible="false" onclick="ClearBatchSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnBatchSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnBatchSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearBatchSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearBatchSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divBatchSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblBatchSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divBatchSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblBatchSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgData" AssociatedUpdatePanelID="updpnlgvBatchSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvBatchSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnBatchRefresh" ClientIDMode="Static" OnClick="btnBatchRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvBatchSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="5" PagerSettings-Mode="Numeric" ClientIDMode="Static" OnPageIndexChanging="gvBatchSearch_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GeneralJournal_htCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetBatchDetails('<%#Eval("BatchName")%>','<%#Eval("tbl_BatchId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvBatchType" Text='<%# Bind("Opt_BatchType") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GeneralJournal_htName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvBatchName" runat="server" Text='<%# Bind("BatchName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GeneralJournal_htBatchGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvBatchGuid" runat="server" Text='<%# Bind("tbl_BatchId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnBatchSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearBatchSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrBatchClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalSourceDocumentSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrSourceDocumentTitle"><span>
                        <asp:Literal runat="server" ID="ltr_Source_Document" Text="<%$ Resources:GlobalResource, GeneralJournal_ltrSourceDocument %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlSource_Document">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlSource_DocumentSearch" DefaultButton="btnSource_DocumentSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtSource_DocumentSearch" CssClass="form-control" placeholder="Search..." autofocus=""></asp:TextBox>
                                        <a runat="server" id="btnHtmlSource_DocumentSearch" onclick="CallSource_DocumentSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlSource_DocumentClose" visible="false" onclick="ClearSource_DocumentSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnSource_DocumentSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnSource_DocumentSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearSource_DocumentSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearSource_DocumentSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divSource_DocumentSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblSource_DocumentSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divSource_DocumentSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblSource_DocumentSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateSource_DocumentProgress" AssociatedUpdatePanelID="updpnlgvSource_DocumentSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvSource_DocumentSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnSource_DocumentRefresh" ClientIDMode="Static" OnClick="btnSource_DocumentRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvSource_DocumentSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="5" PagerSettings-Mode="Numeric" ClientIDMode="Static" OnPageIndexChanging="gvSource_DocumentSearch_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,GeneralJournal_htSource_DocumentNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetSource_DocumentDetails('<%#Eval("Description")%>','<%#Eval("tbl_SourceDocumentId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvtSourceDocumentNumber" Text='<%# Bind("DocumentNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GeneralJournal_htSourceDocumentName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSource_DocumentDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GeneralJournal_SourceDocumentIdGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSourceDocumentId" runat="server" Text='<%# Bind("tbl_SourceDocumentId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnSource_DocumentSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearSource_DocumentSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div1">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrSource_DocumentClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalCurrencySearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalCurrencyTitle"><span>
                        <asp:Literal runat="server" ID="ltrCurrencyTitle" Text="<%$ Resources:GlobalResource, GeneralJournal_ltrCurrency%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlCurrency">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlCurrency" DefaultButton="btnCurrencySearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtCurrencySearch" CssClass="form-control" placeholder="Search..." autofocus=""></asp:TextBox>
                                        <a runat="server" id="btnHtmlCurrencySearch" onclick="CallCurrencySearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlCurrencyClose" visible="false" onclick="ClearCurrencySearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnCurrencySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnCurrencySearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearCurrencySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearCurrencySearch_Click" formnovalidate="formnovalidate" />

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
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="5" PagerSettings-Mode="Numeric" ClientIDMode="Static" OnPageIndexChanging="gvCurrencySearch_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,GeneralJournal_htCurrencyName%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCurrencyDetails('<%#Eval("CurrencyName")%>','<%#Eval("tbl_CurrencyId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCurrencyCode" Text='<%# Bind("CurrencyCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,GeneralJournal_htCurrencyGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCurrencyGuid" runat="server" Text='<%# Bind("CurrencyName") %>'></asp:Label>
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

    <div class="modal fade" id="basicModalGLAccountSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGlAccountTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccount" Text="<%$ Resources:GlobalResource, GeneralJournalDetails_ltrGLAccount%>"></asp:Literal>
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
                                <asp:Button runat="server" ID="btnClearGLAccountSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearGLAccountSearch_Click" formnovalidate="" />

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
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="5" PagerSettings-Mode="Numeric" ClientIDMode="Static" OnPageIndexChanging="gvGLAccountSearch_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GeneralJournalDetails_htAccountNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetGLAccountDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvGLAccountCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GeneralJournalDetails_htGLAccountGuid %>" Visible="false">
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

    <div class="modal fade" id="basicModalCompanySearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalCompanyTitle"><span>
                        <asp:Literal runat="server" ID="ltrCompanyTitle" Text="<%$ Resources:GlobalResource, GeneralJournal_ltrCompany_List %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlCompanySearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlCompanySearch" DefaultButton="btnCompanySearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtCompanySearch" CssClass="form-control" placeholder="Search..." autofocus=""></asp:TextBox>
                                        <a runat="server" id="btnHtmlCompanySearch" onclick="CallCompanySearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlCompanyClose" visible="false" onclick="ClearCompanySearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnCompanySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnCompanySearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearCompanySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearCompanySearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divCompanySearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblCompanySearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divCompanySearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblCompanySearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateProgress1" AssociatedUpdatePanelID="updpnlgvCompanySearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvCompanySearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnCompanyRefresh" ClientIDMode="Static" OnClick="btnCompanyRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvCompanySearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="5" PagerSettings-Mode="Numeric" ClientIDMode="Static" OnPageIndexChanging="gvCompanySearch_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GeneralJournal_htCompanyCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCompanyDetails('<%#Eval("Name")%>','<%#Eval("tbl_OrganizationId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvGLAccountCode" Text='<%# Bind("Name") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GeneralJournal_htCompanyName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCompanyName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GeneralJournal_htCompanyGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCompanyGuid" runat="server" Text='<%# Bind("tbl_OrganizationId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnCompanySearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearCompanySearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div2">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrCompanyClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalGeneralJournalId_SelfSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGeneralJournalId_SelfTitle"><span>
                        <asp:Literal runat="server" ID="ltrModalGeneralJournalId_SelfTitle" Text="<%$ Resources:GlobalResource, GeneralJournal_ltrModalGeneralJournalId_SelfTitle%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlGeneralJournalId_SelfSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlGeneralJournalId_SelfSearch" DefaultButton="btnGeneralJournalId_SelfSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtGeneralJournalId_SelfSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlGeneralJournalId_SelfSearch" onclick="CallGeneralJournalId_SelfSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlGeneralJournalId_SelfClose" visible="false" onclick="ClearGeneralJournalId_SelfSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnGeneralJournalId_SelfSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnGeneralJournalId_SelfSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearGeneralJournalId_SelfSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearGeneralJournalId_SelfSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGeneralJournalId_SelfSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblGeneralJournalId_SelfSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGeneralJournalId_SelfSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGeneralJournalId_SelfSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateProgress3" AssociatedUpdatePanelID="updpnlgvGeneralJournalId_SelfSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGeneralJournalId_SelfSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnGeneralJournalId_SelfRefresh" ClientIDMode="Static" OnClick="btnGeneralJournalId_SelfRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvGeneralJournalId_SelfSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="5" PagerSettings-Mode="Numeric" ClientIDMode="Static" OnPageIndexChanging="gvGeneralJournalId_SelfSearch_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GeneralJournal_htGeneralJournalId_Self%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetGeneralJournalId_SelfDetails('<%#Eval("JournalEntry")%>','<%#Eval("tbl_GeneralJournalId")%>');">
                                                    <asp:Literal runat="server" ID="ltrGeneralJournalId_Self" Text='<%# Bind("JournalEntry") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GeneralJournal_htGeneralJournalId_SelfGuid  %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvGeneralJournalId_SelfGuid" runat="server" Text='<%# Bind("tbl_GeneralJournalId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnGeneralJournalId_SelfSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearGeneralJournalId_SelfSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div6">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrGeneralJournalId_SelfClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalCompanyUpdSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalCompanyUpdTitle"><span>
                        <asp:Literal runat="server" ID="ltrCompanyUpdTitle" Text="<%$ Resources:GlobalResource, GeneralJournal_ltrCompanyUpd_List %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlCompanyUpdSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlCompanyUpdSearch" DefaultButton="btnCompanyUpdSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtCompanyUpdSearch" CssClass="form-control" placeholder="Search..." autofocus=""></asp:TextBox>
                                        <a runat="server" id="btnHtmlCompanyUpdSearch" onclick="CallCompanyUpdSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlCompanyUpdClose" visible="false" onclick="ClearCompanyUpdSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnCompanyUpdSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnCompanyUpdSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearCompanyUpdSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearCompanyUpdSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divCompanyUpdSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblCompanyUpdSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divCompanyUpdSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblCompanyUpdSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateProgress4" AssociatedUpdatePanelID="updpnlgvCompanyUpdSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvCompanyUpdSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnCompanyUpdRefresh" ClientIDMode="Static" OnClick="btnCompanyUpdRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvCompanyUpdSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="5" PagerSettings-Mode="Numeric" ClientIDMode="Static" OnPageIndexChanging="gvCompanyUpdSearch_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GeneralJournal_htCompanyCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCompanyUpdDetails('<%#Eval("Name")%>','<%#Eval("tbl_OrganizationId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvGLAccountCode" Text='<%# Bind("Name") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GeneralJournal_htCompanyName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCompanyName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GeneralJournal_htCompanyGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCompanyGuid" runat="server" Text='<%# Bind("tbl_OrganizationId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnCompanySearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearCompanySearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div7">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrCompanyUpdClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalGLAccountUpdSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGlAccountUpdTitle"><span>
                        <asp:Literal runat="server" ID="Literal2" Text="<%$ Resources:GlobalResource, GeneralJournalDetails_ltrUpdGLAccount%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="Panel1" DefaultButton="btnGLAccountUpdSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtGLAccountUpdSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlGLAccountUpdSearch" onclick="CallGLAccountUpdSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlGLAccountUpdClose" visible="false" onclick="ClearGLAccountUpdSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnGLAccountUpdSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnGLAccountUpdSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearGLAccountUpdSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearGLAccountUpdSearch_Click" formnovalidate="" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountSearchUpdError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountUpdSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountUpdSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountUpdSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateProgress5" AssociatedUpdatePanelID="updpnlgvGLAccountUpdSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountUpdSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnGLAccountUpdRefresh" ClientIDMode="Static" OnClick="btnGLAccountUpdRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvGLAccountUpdSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="5" PagerSettings-Mode="Numeric" ClientIDMode="Static" OnPageIndexChanging="gvGLAccountUpdSearch_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GeneralJournalDetails_htAccountNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetGLAccountUpdDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvGLAccountCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, GeneralJournalDetails_htGLAccountGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvGLAccountGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnGLAccountUpdSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearGLAccountUpdSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divGLAccountUpdFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblGLAccountUpdClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>


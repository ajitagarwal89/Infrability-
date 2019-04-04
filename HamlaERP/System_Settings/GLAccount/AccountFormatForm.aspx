<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AccountFormatForm.aspx.cs" Inherits="System_Settings_AccountFormatForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">    
    <script src="../../infra_ui/js/System_Settings_JS/GLAccount_JS/AccountFormatForm.js"></script>
    <script src="../infra_ui/js/CommonJS/CommonValidations.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <!--page header start-->
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" OnClick="btnSave_Click" Text="<%$ Resources:GlobalResource, btnSave%>" />
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-success" OnClick="btnUpdate_Click" Text="<%$ Resources:GlobalResource, btnUpdate%>" formnovalidate="formnovalidate"></asp:Button>
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-success" OnClick="btnDelete_Click" Text="<%$ Resources:GlobalResource, btnDelete%>" />
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-success" OnClick="btnBack_Click" Text="<%$ Resources:GlobalResource, btnBack%>" formnovalidate="formnovalidate"></asp:Button>
                    <asp:Button runat="server" ID="btnClear" CssClass="btn btn-success" OnClientClick="return ClearForm();" Text="<%$ Resources:GlobalResource, btnClear%>" formnovalidate="formnovalidate"></asp:Button>

                    <asp:Button runat="server" ID="btnAuditHistory" CssClass="btn btn-success" Text="<%$ Resources:GlobalResource, btnAuditHistory%>" formnovalidate="formnovalidate" OnClick="btnAuditHistory_Click" />
                    <asp:LinkButton runat="server" ID="LinkButton1" OnClick="lnkExportToExcel_Click" CssClass="btn btn-success">
                        <asp:Literal runat="server" ID="ltrExportToExcel" Text="<%$Resources:GlobalResource, ltrExportToExcel%>"></asp:Literal>
                    </asp:LinkButton>
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
                                <asp:Literal runat="server" ID="ltrGLAccountInformation" Text="<%$ Resources:GlobalResource, AccountFormat_ltrInformation%>"></asp:Literal></h5>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblMaximumAccountLength" Text="<%$ Resources:GlobalResource, AccountFormat_htMaxiAccountLength%>"></asp:Label>
                            <asp:TextBox type="number" runat="server" min="1" max="66" AutoPostBack="true" ID="txtMaximumAccountLength" ClientIDMode="Static" class="form-control " placeholder="" required="required" onkeypress="CheckNumeric(event);" OnTextChanged="txtMaximumAccountLength_TextChanged"></asp:TextBox>

                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAccontLength" Text="<%$ Resources:GlobalResource, AccountFormat_htAccontLength%>"></asp:Label>
                            <asp:TextBox type="number" runat="server" min="1" AutoPostBack="true" ID="txtAccountLength" ClientIDMode="Static" class="form-control " placeholder="" required="required" onkeypress="CheckNumeric(event);" OnTextChanged="txtAccountLength_TextChanged"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblMaximumSegment" Text="<%$ Resources:GlobalResource, AccountFormat_MaximumSegment %>"></asp:Label>
                            <asp:TextBox type="number" min="1" max="10" AutoPostBack="true" runat="server" ID="txtMaximumSegment" ClientIDMode="Static" class="form-control " placeholder="" required="required" onkeypress="CheckNumeric(event);" OnTextChanged="txtMaximumSegment_TextChanged"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblSeparatedBy" Text="<%$ Resources:GlobalResource, AccountFormat_htSeparatedBy%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtSeparatedBy" ClientIDMode="Static" class="form-control " placeholder="" required="required" onkeypress="SpecialChar(event);"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblSegment" Text="<%$ Resources:GlobalResource, AccountFormat_htSegment %>"></asp:Label>
                            <asp:TextBox type="number" runat="server" ID="txtSegment" min="1" max="10" MaxLength="2" ClientIDMode="Static" class="form-control " AutoPostBack="true" OnTextChanged="txtSegment_TextChanged" placeholder="" onkeypress="CheckNumeric(event);" required="required"></asp:TextBox>
                        </div>


                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblMainSegmentId" Text="<%$ Resources:GlobalResource, AccountFormat_htMainSegmentId%>"></asp:Label>
                            <asp:DropDownList ID="ddlMainSegmentId" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                        <asp:GridView ID="gvData" runat="server" ClientIDMode="Static" Font-Size="10pt" AutoGenerateColumns="False" DataKeyNames="tbl_AccountFormatDetailsId" Width="100%" GridLines="None" CssClass="table table-hover" CellPadding="4" ForeColor="#333333"
                            OnRowCancelingEdit="gvData_RowCancelingEdit" AutoGenerateEditButton="True"
                            OnRowEditing="gvData_RowEditing" OnRowUpdating="gvData_RowUpdating">
                            <Columns>
                                <asp:TemplateField HeaderText="tbl_AccountFormatDetailsId" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbltbl_AccountFormatDetailsId" runat="server" Value='<%#Eval("tbl_AccountFormatDetailsId")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txttbl_AccountFormatDetailsId" runat="server" Text='<%#Eval("tbl_AccountFormatDetailsId")%>' />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AccountFormat_htSequenceNumber%>" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSequenceNumber" runat="server" Text='<%#Eval("SequenceNumber")%>'></asp:Label>
                                    </ItemTemplate>
                                    <%--  <EditItemTemplate>
                                        <asp:TextBox ID="txtSequenceNumber" runat="server" Text='<%#Eval("SequenceNumber")%>'></asp:TextBox>
                                    </EditItemTemplate>--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AccountFormat_htSegmentNumber%>" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSegmentNumber" runat="server" Text='<%#Eval("SegmentNumber")%>' />
                                    </ItemTemplate>
                                    <%-- <EditItemTemplate>
                                        <asp:TextBox ID="txtSegmentNumber" runat="server" Text='<%#Eval("SegmentNumber")%>' />
                                    </EditItemTemplate>--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AccountFormat_htSegmentName%>">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSegmentName" runat="server" Text='<%#Eval("SegmentName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AccountFormat_htMaxLength %>">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMaxLength" runat="server" Text='<%#Eval("MaxLength")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AccountFormat_htLength %>">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLength" runat="server" Text='<%#Eval("Length")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtLength" runat="server" Text='<%#Eval("Length")%>'></asp:TextBox>

                                        <asp:CompareValidator ID="cvSegment" runat="server" ControlToValidate="txtLength" ErrorMessage="Length should be less than equal to Max Length" Operator="LessThanEqual" Type="Integer" ValueToCompare='<%# Eval("MaxLength") %>'></asp:CompareValidator>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AccountFormat_htIsActive%>" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIsActive" runat="server" Text='<%#Eval("IsActive")%>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="chkIsAcive" Checked="true" runat="server" Text='<%#Eval("IsActive")%>' />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


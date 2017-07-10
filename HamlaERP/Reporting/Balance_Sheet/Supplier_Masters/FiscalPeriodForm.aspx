<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FiscalPeriodForm.aspx.cs" Inherits="Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="MAK" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../infra_ui/js/Reporting_JS/Balance_Sheet_JS/Supplier_Masters_JS/FiscalPeriodForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrBatchInformation" Text="<%$ Resources:GlobalResource, ltrOrganizationInformation%>"></asp:Literal></h5>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblYear" Text="<%$ Resources:GlobalResource, FiscalPeriod_lblYear%>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_Year" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required" autofocus="autofocus" AutoPostBack="True" OnSelectedIndexChanged="ddlOpt_Year_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblFirstDate" Text="<%$ Resources:GlobalResource, FiscalPeriod_lblFirstDate%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtFirstDate" TextMode="Date" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblLastDate" Text="<%$ Resources:GlobalResource, FiscalPeriod_lblLastDate%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtLastDate" TextMode="Date" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>


                        <%--<div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblFirstDate" Text="<%$ Resources:GlobalResource, FiscalPeriod_lblFirstDate%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtFirstDate" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                            <MAK:CalendarExtender ID="ceFirstDate" runat="server" Format="dd/MM/yyyy"
                                TargetControlID="txtFirstDate">
                            </MAK:CalendarExtender>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblLastDate" Text="<%$ Resources:GlobalResource, FiscalPeriod_lblLastDate%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtLastDate" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                            <MAK:CalendarExtender ID="ceLastDate" runat="server" Format="dd/MM/yyyy"
                                TargetControlID="txtLastDate">
                            </MAK:CalendarExtender>
                        </div>--%>


                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblHistoricalYear" Text="<%$ Resources:GlobalResource, FiscalPeriod_lblHistoricalYear%>"></asp:Label>
                            <asp:CheckBox runat="server" ID="chckHistoricalYear" Checked="false" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:CheckBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblNumberOfPeriod" Text="<%$ Resources:GlobalResource, FiscalPeriod_lblNumberOfPeriod%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtNumberOfPeriod" min="1" max="12" ClientIDMode="Static" class="form-control " placeholder="" required="required"
                                onkeypress="CheckNumeric(event);" OnTextChanged="txtNumberOfPeriod_TextChanged" AutoPostBack="True"></asp:TextBox>
                        </div>

                        <%--  <div class="form-group col-md-12 col-sm-12">

                            <asp:GridView ID="gvFiscalPeriod" runat="server" AutoGenerateColumns="False" Visible="False" DataKeyNames="tbl_FiscalPeriodDetailsId"
                                OnRowCancelingEdit="gvFiscalPeriod_RowCancelingEdit" AutoGenerateEditButton="True"
                                OnRowEditing="gvFiscalPeriod_RowEditing" OnRowUpdating="gvFiscalPeriod_RowUpdating">
                                <Columns>
                                    <asp:TemplateField HeaderText="tbl_FiscalPeriodDetailsId" Visible="false">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txttbl_FiscalPeriodDetailsId" runat="server" Text='<%# Bind("tbl_FiscalPeriodDetailsId") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbltbl_FiscalPeriodDetailsId" runat="server" Text='<%# Bind("tbl_FiscalPeriodDetailsId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="tbl_FiscalPeriodId" Visible="false">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txttbl_FiscalPeriodId" runat="server" Text='<%# Bind("tbl_FiscalPeriodId") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbltbl_FiscalPeriodId" runat="server" Text='<%# Bind("tbl_FiscalPeriodId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PeriodSequence">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPeriodSequence" runat="server" Text='<%# Bind("PeriodSequence") %>' Enabled="false"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriodSequence" runat="server" Text='<%# Bind("PeriodSequence") %>' Enabled="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PeriodName">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPeriodName" runat="server" Text='<%# Bind("PeriodName") %>' Enabled="false"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriodName" runat="server" Text='<%# Bind("PeriodName") %>' Enabled="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PeriodDate">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPeriodDate" runat="server" Text='<%# Bind("PeriodDate") %>' Enabled="false"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriodDate" runat="server" Text='<%# Bind("PeriodDate") %>' Enabled="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Financial">
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="chkEditClosingFinancial" runat="server" Checked='<%# Convert.ToBoolean(Eval("ClosingFinancial")) %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkClosingFinancial" runat="server" Checked='<%# Convert.ToBoolean(Eval("ClosingFinancial")) %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="HR">
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="chkEditClosingHR" runat="server" Checked='<%# Convert.ToBoolean(Eval("ClosingHR")) %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkClosingHR" runat="server" Checked='<%# Convert.ToBoolean(Eval("ClosingHR")) %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Procurement">
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="chkEditClosingProcurement" runat="server" Checked='<%# Convert.ToBoolean(Eval("ClosingProcurement"))%>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkClosingProcurement" runat="server" Checked='<%# Convert.ToBoolean(Eval("ClosingProcurement"))%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </div>--%>

                        <div class="form-group col-md-12 col-sm-12">

                            <asp:GridView ID="gvFiscalPeriodDetails" runat="server" AutoGenerateColumns="False" DataKeyNames="tbl_FiscalPeriodDetailsId">
                                <Columns>
                                    <asp:TemplateField HeaderText="tbl_FiscalPeriodDetailsId" Visible="false">
                                        <ItemTemplate>
                                            <asp:TextBox ID="lbltbl_FiscalPeriodDetailsId" runat="server" Text='<%# Eval("tbl_FiscalPeriodDetailsId") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="tbl_FiscalPeriodId" Visible="false">
                                        <ItemTemplate>
                                            <asp:TextBox ID="lbltbl_FiscalPeriodId" runat="server" Text='<%# Eval("tbl_FiscalPeriodId") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PeriodSequence">
                                        <ItemTemplate>
                                            <asp:TextBox ID="lblPeriodSequence" runat="server" Text='<%# Eval("PeriodSequence") %>' Enabled="false"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PeriodName">
                                        <ItemTemplate>
                                            <asp:TextBox ID="lblPeriodName" runat="server" Text='<%# Eval("PeriodName") %>' Enabled="false"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PeriodDate">
                                        <ItemTemplate>
                                            <asp:TextBox ID="lblPeriodDate" runat="server" Text='<%# Eval("PeriodDate") %>' Enabled="false"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Financial" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkClosingFinancial" runat="server" Checked='<%# (bool)Eval("ClosingFinancial") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="HR" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkClosingHR" runat="server" Checked='<%# (bool)Eval("ClosingHR") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Procurement" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkClosingProcurement" runat="server" Checked='<%# (bool)Eval("ClosingProcurement")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>



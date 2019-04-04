<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FiscalPeriodForm.aspx.cs" Inherits="Reporting_Balance_Sheet_Supplier_Masters_FiscalPeriodForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="MAK" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">    
    <script src="../../infra_ui/js/System_Settings_JS/FiscalPeriod_JS/FiscalPeriodForm.js"></script>
    <script src="../../../infra_ui/js/CommonJS/CommonValidations.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <!--page header start-->
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" OnClick="btnSave_Click" Text="<%$ Resources:GlobalResource, btnSave%>" formnovalidate="formnovalidate"/>
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-success" OnClick="btnUpdate_Click" Text="<%$ Resources:GlobalResource, btnUpdate%>" formnovalidate="formnovalidate" />
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-success" OnClick="btnDelete_Click" Text="<%$ Resources:GlobalResource, btnDelete%>" formnovalidate="formnovalidate" />
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-success" OnClick="btnBack_Click" Text="<%$ Resources:GlobalResource, btnBack%>" formnovalidate="formnovalidate"  />
					 <asp:Button runat="server" ID="btnAuditHistory" CssClass="btn btn-success" Text="<%$ Resources:GlobalResource, btnAuditHistory%>" OnClick="btnAuditHistory_Click" />
					<asp:Button runat="server" ID="btnClear" CssClass="btn btn-success" OnClientClick="return ClearForm();" Text="<%$ Resources:GlobalResource, btnClear%>" ></asp:Button>
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
                                <asp:Literal runat="server" ID="ltrBatchInformation" Text="<%$ Resources:GlobalResource, FiscalPeriod_ltrInformation%>"></asp:Literal></h5>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblYear" Text="<%$ Resources:GlobalResource, FiscalPeriod_lblYear%>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_Year" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required" autofocus="autofocus" AutoPostBack="True" OnSelectedIndexChanged="ddlOpt_Year_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblFirstDate" Text="<%$ Resources:GlobalResource, FiscalPeriod_lblFirstDate%>"></asp:Label>
                            <asp:TextBox  runat="server" ID="txtFirstDate" TextMode="Date" ClientIDMode="Static" class="form-control " AutoPostBack="true" placeholder="" required="required" OnTextChanged="txtFirstDate_TextChanged"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblLastDate" Text="<%$ Resources:GlobalResource, FiscalPeriod_lblLastDate%>"></asp:Label>
                            <asp:TextBox  runat="server" ID="txtLastDate"   ClientIDMode="Static" class="form-control " placeholder="" required="required" ></asp:TextBox>
                        </div>


                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblHistoricalYear" Text="<%$ Resources:GlobalResource, FiscalPeriod_lblHistoricalYear%>"></asp:Label>
                            <asp:CheckBox runat="server" ID="chckHistoricalYear" Checked="false" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:CheckBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblNumberOfPeriod" Text="<%$ Resources:GlobalResource, FiscalPeriod_lblNumberOfPeriod%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtNumberOfPeriod" min="1" max="12" ClientIDMode="Static" class="form-control " placeholder="" required="required"
                                onkeypress="CheckNumeric(event);" ></asp:TextBox>
                        </div>
						  <div class="form-group col-md-4 col-sm-4 align-right">
							   
							  <asp:Button ID="CheckAll" runat="server" Text="<%$ Resources:GlobalResource, FiscalPeriod_btnOpenAll%>"  class="btn btn-primary align-right " OnClick="CheckAll_Click" formnovalidate="formnovalidate" />
							<asp:Button ID="UncheckAll" runat="server"  Text="<%$ Resources:GlobalResource, FiscalPeriod_btnCloseAll%>"  class="btn btn-danger align-right" OnClick="UncheckAll_Click" formnovalidate="formnovalidate" />
							  </div>
				        <div class="form-group col-md-12 col-sm-12">

                            <asp:GridView ID="gvFiscalPeriodDetails" runat="server" AutoGenerateColumns="False" DataKeyNames="tbl_FiscalPeriodDetailsId" Width="100%">
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
                                            <asp:Label ID="lblPeriodSequence" runat="server" Text='<%# Eval("PeriodSequence") %>' Enabled="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PeriodName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriodName" runat="server" Text='<%# Eval("PeriodName") %>' Enabled="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PeriodDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriodDate" runat="server" DataFormatString="{0:MM/dd/yyyy}"   Text='<%# Eval("PeriodDate") %>'  Enabled="false"></asp:Label>
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



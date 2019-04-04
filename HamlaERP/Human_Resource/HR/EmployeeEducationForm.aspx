<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EmployeeEducationForm.aspx.cs" Inherits="Human_Resource_HR_EmployeeEducationForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../../infra_ui/js/Human_Resource_JS/HR_JS/EmployeeEducationForm.js"></script>
	<script src="../../infra_ui/js/CommonJS/CommonValidations.js"></script>
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
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-success" OnClick="btnBack_Click" Text="<%$ Resources:GlobalResource, btnBack%>" formnovalidate="formnovalidate"/>
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
                      <h5>
                            <asp:Literal runat="server" ID="ltrEmployeeEducationInformation" Text="<%$ Resources:GlobalResource, EmployeeEducation_ltrEmployeeEducationInformation%>"></asp:Literal></h5>
                    </div>
                    <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblEmployeeId" Text="<%$ Resources:GlobalResource, EmployeeEducation_lblEmployee %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtEmployee" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon4">
                                    <a href="#" data-toggle="modal" data-target="#basicModalEmployeeSearch" data-keyboard="false" data-backdrop="static" onclick="CallEmployeeRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtEmployeeGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                                     
                 

                       <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblSchool" Text="<%$ Resources:GlobalResource, EmployeeEducation_lblSchool%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtSchool" ClientIDMode="Static" class="form-control "  onkeypress="return isAddress(this);" MaxLength="200"  placeholder="" required="required" ></asp:TextBox>
                        </div>  

                      <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lbl_Major" Text="<%$ Resources:GlobalResource, EmployeeEducation_lbl_Major%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtMajor" ClientIDMode="Static" class="form-control "   onkeypress="return isAlphaNumberKey (this);" MaxLength="100"  placeholder="" required="required" ></asp:TextBox>
                        </div>  

                      <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lbl_Year" Text="<%$ Resources:GlobalResource, EmployeeEducation_lbl_Year%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtYear"  ClientIDMode="Static" class="form-control "  onkeypress="return isNumberKey (this);" MaxLength="4"  placeholder="" required="required" ></asp:TextBox>
                        </div> 

                     <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDegree" Text="<%$ Resources:GlobalResource, EmployeeEducation_lbl_Degree%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtDegree"  onkeypress="return isAlphaKey (this);" MaxLength="50"  ClientIDMode="Static" class="form-control " placeholder="" required="required" ></asp:TextBox>
                        </div>
                     
                     <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblGPA" Text="<%$ Resources:GlobalResource, EmployeeEducation_lblGPA%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtGPA" onkeypress="return isNumberKeyPoint (this);" MaxLength="5"  ClientIDMode="Static" class="form-control " placeholder="" required="required" ></asp:TextBox>
                        </div>

                    <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblNote" Text="<%$ Resources:GlobalResource, EmployeeEducation_lblNote%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtNote" TextMode="MultiLine" onkeypress="return isAddress (this);" MaxLength="200"   ClientIDMode="Static" class="form-control " placeholder="" required="required" ></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
   <div class="modal fade" id="basicModalEmployeeSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalEmployeeTitle"><span>
                        <asp:Literal runat="server" ID="Literal2" Text="<%$ Resources:GlobalResource, EmployeeEducation_ltrEmployeeTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlEmployeeSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlEmployeeSearch" DefaultButton="btnEmployeeSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtEmployeeSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlEmployeeSearch" onclick="CallEmployeeSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlEmployeeClose" visible="false" onclick="ClearEmployeeSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnEmployeeSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnEmployeeSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearEmployeeSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearEmployeeSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divEmployeeSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblEmployeeSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divEmployeeSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblEmployeeSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateProgress1" AssociatedUpdatePanelID="updpnlgvEmployeeSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvEmployeeSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnEmployeeRefresh" ClientIDMode="Static" OnClick="btnEmployeeRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvEmployeeSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,EmployeeEducation_htEmployeeName%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetEmployeeDetails('<%#Eval("FirstName")%>','<%#Eval("tbl_EmployeeId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvEmployeeName" Text='<%# Bind("FirstName") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     <asp:TemplateField HeaderText="<%$Resources:GlobalResource,EmployeeEducation_htEmployeeCode %>" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmployeeCode" runat="server" Text='<%# Bind("EmployeeCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$Resources:GlobalResource, EmployeeEducation_htEmployeeGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmployeeGuid" runat="server" Text='<%# Bind("tbl_EmployeeId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnEmployeeSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearEmployeeSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div1">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrEmployeeClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


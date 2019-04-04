<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="HR_BranchForm.aspx.cs" Inherits="Human_Resource_HR_BranchForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../../infra_ui/js/Human_Resource_JS/HR_JS/HR_BranchForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, HR_Branch_ltrInformation%>"></asp:Literal></h5>
                        </div>
                        
                          <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblBranchCode" Text="<%$ Resources:GlobalResource, HR_Branch_lblBranchCode%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtBranchCode"   onkeypress="return isAlphaNumberKey(this);" MaxLength="30" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblopt_CurrentyFiscalYear" Text="<%$ Resources:GlobalResource,HR_Branch_lblopt_CurrentyFiscalYear %>"></asp:Label>
                             <asp:DropDownList ID="ddlopt_CurrentyFiscalYear" runat="server" ClientIDMode="Static" class="form-control" required="required"></asp:DropDownList>
                        </div>
                        
                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblopt_DepreciatedPeriod" Text="<%$ Resources:GlobalResource,HR_Branch_lblopt_DepreciatedPeriod %>"></asp:Label>
                             <asp:DropDownList ID="ddlopt_DepreciatedPeriod" runat="server" ClientIDMode="Static" class="form-control" required="required"></asp:DropDownList>
                        </div>
                          
                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource, HR_Branch_lblDescription%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDescription"  TextMode="MultiLine"   onkeypress="return isAddress(this);" MaxLength="200" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                      </div>    
                </div>
            </div>
        </div>
    </div>
       
   

</asp:Content>


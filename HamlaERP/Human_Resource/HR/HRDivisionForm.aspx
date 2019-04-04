<%@ Page  Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="HRDivisionForm.aspx.cs" Inherits="Human_Resource_HR_HRDivisionForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../../infra_ui/js/Human_Resource_JS/HR_JS/HRDivisionForm.js"></script>
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
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-success" OnClick="btnBack_Click" Text="<%$ Resources:GlobalResource, btnBack%>" formnovalidate="formnovalidate"></asp:Button>
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
                                <asp:Literal runat="server" ID="ltrHRDivisionInformation" Text="<%$ Resources:GlobalResource, HRDivision_ltrHRDivisionInformation%>"></asp:Literal></h5>
                        </div>
                        
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDivisionCode" Text="<%$ Resources:GlobalResource, HRDivision_lblDivisionCode%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDivisionCode" ClientIDMode="Static" class="form-control "  onkeypress="return isAlphaNumberKey(this);" MaxLength="30" placeholder="" required="required" ></asp:TextBox>
                        </div>  
                    
						
                          <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblEmail" Text="<%$ Resources:GlobalResource, HRDivision_lblEmail%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtEmail" TextMode="Email" MaxLength="50" ClientIDMode="Static" class="form-control " placeholder="" required="required" ></asp:TextBox>
                        </div>  
                               <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPhone" Text="<%$ Resources:GlobalResource, HRDivision_lblPhone%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtPhone" MaxLength="15" ClientIDMode="Static" class="form-control "  onkeypress="return isNumberKey(this);" placeholder="" required="required" ></asp:TextBox>
                        </div> 

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblExtension" Text="<%$ Resources:GlobalResource, HRDivision_lblExtension%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtExtension" ClientIDMode="Static" class="form-control " onkeypress="return isNumberKey(this);" MaxLength="5" placeholder="" required="required" ></asp:TextBox>
                        </div> 

                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblFax" Text="<%$ Resources:GlobalResource, HRDivision_lblFax%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtFax" MaxLength="15" ClientIDMode="Static" class="form-control "  onkeypress="return isNumberKey(this);" placeholder="" required="required" ></asp:TextBox>
                        </div> 

                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAddress" Text="<%$ Resources:GlobalResource, HRDivision_lblAddress%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtAddress" ClientIDMode="Static" class="form-control " placeholder=""   onkeypress="return isAddress(this);" MaxLength="100" required="required" ></asp:TextBox>
                        </div> 

                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblCity" Text="<%$ Resources:GlobalResource, HRDivision_lblCity%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtCity" ClientIDMode="Static" class="form-control " placeholder=""   onkeypress="return isAlphaKey(this);" MaxLength="60" required="required" ></asp:TextBox>
                        </div> 

                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblState" Text="<%$ Resources:GlobalResource, HRDivision_lblState%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtState" ClientIDMode="Static" class="form-control "  onkeypress="return isAlphaKey(this);" MaxLength="60" placeholder="" required="required" ></asp:TextBox>
                        </div> 

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblZipCode" Text="<%$ Resources:GlobalResource, HRDivision_lblZipCode%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtZipCode" MaxLength="6"  onkeypress="return isNumberKey(this);"   ClientIDMode="Static" class="form-control " placeholder="" required="required" ></asp:TextBox>
                        </div> 

                     
                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource, HRDivision_lblDescription%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" ClientIDMode="Static" class="form-control " onkeypress="return isAddress(this);" MaxLength="100" placeholder="" required="required" ></asp:TextBox>
                        </div>  
                                         
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


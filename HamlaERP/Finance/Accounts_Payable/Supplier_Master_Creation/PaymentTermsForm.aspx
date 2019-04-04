<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PaymentTermsForm.aspx.cs" Inherits="Finance_Accounts_Payable_Supplier_Master_Creation_PaymentTermsForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Accounts_Payable_JS/Supplier_Master_Creation_JS/PaymentTermsFom.js"></script>
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
                                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, PaymentTerms_ltrInformation%>"></asp:Literal></h5>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblName" Text="<%$ Resources:GlobalResource, PaymentTerms_lblName%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtName" ClientIDMode="Static" onkeypress="return isAlphaKey(this);" MaxLength="50" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                             <asp:Label runat="server" ID="lblDueInDays" Text="<%$ Resources:GlobalResource, PaymentTerms_lblDueInDays%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDueInDays" ClientIDMode="Static" onkeypress="return isNumberKey(this);" MaxLength="3" class="form-control" placeholder="" required="required"></asp:TextBox>
                        
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                                 <asp:Label runat="server" ID="lblDiscountInDays" Text="<%$ Resources:GlobalResource, PaymentTerms_lblDiscountInDays%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDiscountInDays" ClientIDMode="Static" onkeypress="return isNumberKey(this);" MaxLength="3" class="form-control" placeholder="" required="required"></asp:TextBox>
                        
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                                   <asp:Label runat="server" ID="lbl_PaymentTerms_Opt_DiscountType" Text="<%$ Resources:GlobalResource, PaymentTerms_htOpt_DiscountType %>" ></asp:Label>
                            <asp:DropDownList ID="ddlOpt_DiscountType" runat="server" ClientIDMode="Static"  class="form-control" placeholder="" required="required">
                            </asp:DropDownList>


                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                        
                            <asp:Label runat="server" ID="lblDiscountTypeValue" Text="<%$ Resources:GlobalResource, PaymentTerms_lblDiscountTypeValue%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDiscountTypeValue" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control" placeholder="" required="required"></asp:TextBox>
                        

                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            
                              <asp:Label runat="server" ID="lblSalesOrPurchase" Text="<%$ Resources:GlobalResource, PaymentTerms_lblSalesOrPurchase%>"></asp:Label>
                           <asp:CheckBox ID="chkSalesOrPurchase" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required" />
                      </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


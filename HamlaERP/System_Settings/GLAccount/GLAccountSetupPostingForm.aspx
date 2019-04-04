<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GLAccountSetupPostingForm.aspx.cs" Inherits="Finance_Accounts_Payable_Setup_GLAccountSetupPostingForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Accounts_Payable_JS/Setup/GLAccountSetupPostingForm.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <!--page header start-->
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" Text="<%$ Resources:GlobalResource, btnSave%>" OnClick="btnSave_Click" />
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-success" Text="<%$ Resources:GlobalResource, btnUpdate%>" OnClick="btnUpdate_Click" />
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-success" Text="<%$ Resources:GlobalResource, btnDelete%>" OnClick="btnDelete_Click" />
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-success" Text="<%$ Resources:GlobalResource, btnBack%>" formnovalidate="formnovalidate" OnClick="btnBack_Click" />
                    <asp:Button runat="server" ID="btnClear" CssClass="btn btn-success" OnClientClick="return ClearForm();" Text="<%$ Resources:GlobalResource, btnClear%>" formnovalidate="formnovalidate" />
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
                                <asp:Literal runat="server" ID="ltrGLAccountSetupPostingInformation" Text="<%$ Resources:GlobalResource, GLAccountSetupPosting_ltrGLAccountSetupPostingInformation%>"></asp:Literal></h5>
                        </div>

                        <div class="form-group col-md-4 col-sm-5">

                            <asp:Label runat="server" ID="lblSeries" Text="<%$ Resources:GlobalResource, GLAccountSetupPosting_lblSeries %>"></asp:Label>
                            <asp:DropDownList ID="ddlSeries" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group col-md-4 col-sm-5">

                            <asp:Label runat="server" ID="lblOrigin" Text="<%$ Resources:GlobalResource, GLAccountSetupPosting_lblOrigin %>"></asp:Label>
                            <asp:DropDownList ID="ddlOrigin" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4">
                            <asp:Label runat="server" ID="lblPostToGL" Text="<%$ Resources:GlobalResource, GLAccountSetupPosting_chkPostToGL%>"></asp:Label>

                            <asp:CheckBox ID="chkPostToGL" ClientIDMode="Static" class="form-control " placeholder="" required="required" runat="server" />


                        </div>
                        <div class="form-group col-md-4">
                            <asp:Label runat="server" ID="lblPostThroughGLFile" Text="<%$ Resources:GlobalResource, GLAccountSetupPosting_lblPostThroughGLFile%>"></asp:Label>

                            <asp:CheckBox ID="chkPostThroughGLFile" ClientIDMode="Static" class="form-control " placeholder="" required="required" runat="server" />


                        </div>
                        <div class="form-group col-md-4">
                            <asp:Label runat="server" ID="lblAllowTransactionPosting" Text="<%$ Resources:GlobalResource, GLAccountSetupPosting_lblAllowTransactionPosting%>"></asp:Label>

                            <asp:CheckBox ID="chkAllowTransactionPosting" ClientIDMode="Static" class="form-control " placeholder="" required="required" runat="server" />


                        </div>
                        <div class="form-group col-md-4">
                            <asp:Label runat="server" ID="lblIncludeMultiCurrencyInfo" Text="<%$ Resources:GlobalResource, GLAccountSetupPosting_chkIncludeMultiCurrencyInfo%>"></asp:Label>

                            <asp:CheckBox ID="chkIncludeMultiCurrencyInfo" ClientIDMode="Static" class="form-control " placeholder="" required="required" runat="server" />


                        </div>
                        <div class="form-group col-md-4">
                            <asp:Label runat="server" ID="lblVerifyNumberOfTransaction" Text="<%$ Resources:GlobalResource, GLAccountSetupPosting_chkVerifyNumberOfTransaction%>"></asp:Label>

                            <asp:CheckBox ID="chkVerifyNumberOfTransaction" ClientIDMode="Static" class="form-control " placeholder="" required="required" runat="server" />


                        </div>
                        <div class="form-group col-md-4">
                            <asp:Label runat="server" ID="lblVerifyBatchAmount" Text="<%$ Resources:GlobalResource, GLAccountSetupPosting_chkVerifyBatchAmount%>"></asp:Label>

                            <asp:CheckBox ID="chkVerifyBatchAmount" ClientIDMode="Static" class="form-control " placeholder="" required="required" runat="server" />


                        </div>
                        <div class="form-group col-md-4">
                            <asp:Label runat="server" ID="lblTransaction" Text="<%$ Resources:GlobalResource, GLAccountSetupPosting_chkTransaction%>"></asp:Label>

                            <asp:CheckBox ID="chkTransaction" ClientIDMode="Static" class="form-control " placeholder="" required="required" runat="server" />


                        </div>
                        <div class="form-group col-md-4">
                            <asp:Label runat="server" ID="lblBatch" Text="<%$ Resources:GlobalResource, GLAccountSetupPosting_chkBatch%>"></asp:Label>

                            <asp:CheckBox ID="chkBatch" ClientIDMode="Static" class="form-control " placeholder="" required="required" runat="server" />


                        </div>
                        <div class="form-group col-md-4">
                            <asp:Label runat="server" ID="lblUseAccountSetting" Text="<%$ Resources:GlobalResource, GLAccountSetupPosting_chkUseAccountSetting%>"></asp:Label>

                            <asp:CheckBox ID="chkUseAccountSetting" ClientIDMode="Static" class="form-control " placeholder="" required="required" runat="server" />


                        </div>
                        <div class="form-group col-md-4">
                            <asp:Label runat="server" ID="lblPostingDateFromBatch" Text="<%$ Resources:GlobalResource, GLAccountSetupPosting_chkPostingDateFromBatch%>"></asp:Label>

                            <asp:CheckBox ID="chkPostingDateFromBatch" ClientIDMode="Static" class="form-control " placeholder="" required="required" runat="server" />


                        </div>
                        <div class="form-group col-md-4">
                            <asp:Label runat="server" ID="lblPostingDateFromTrx" Text="<%$ Resources:GlobalResource, GLAccountSetupPosting_chkPostingDateFromTrx%>"></asp:Label>

                            <asp:CheckBox ID="chkPostingDateFromTrx" ClientIDMode="Static" class="form-control " placeholder="" required="required" runat="server" />


                        </div>
                        <div class="form-group col-md-4">
                            <asp:Label runat="server" ID="lblIfExistingBatchAppend" Text="<%$ Resources:GlobalResource, GLAccountSetupPosting_chkIfExistingBatchAppend%>"></asp:Label>

                            <asp:CheckBox ID="chkIfExistingBatchAppend" ClientIDMode="Static" class="form-control " placeholder="" required="required" runat="server" />


                        </div>
                        <div class="form-group col-md-4">
                            <asp:Label runat="server" ID="lblIfExistingBatchCreateNew" Text="<%$ Resources:GlobalResource, GLAccountSetupPosting_chkIfExistingBatchCreateNew%>"></asp:Label>

                            <asp:CheckBox ID="chkIfExistingBatchCreateNew" ClientIDMode="Static" class="form-control " placeholder="" required="required" runat="server" />


                        </div>
                        <div class="form-group col-md-4">
                            <asp:Label runat="server" ID="lblRequireBatchApproval" Text="<%$ Resources:GlobalResource, GLAccountSetupPosting_chkRequireBatchApproval%>"></asp:Label>

                            <asp:CheckBox ID="chkRequireBatchApproval" ClientIDMode="Static" class="form-control " placeholder="" required="required" runat="server" />

                        </div>

                        <div class="form-group col-md-4">
                            <asp:Label runat="server" ID="lblBatchApprovalPassword" Text="<%$ Resources:GlobalResource, GLAccountSetupPosting_lblBatchApprovalPassword %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtBatchApprovalPassword" ClientIDMode="Static" class="form-control" onkeypress="return isAddress(this);" MaxLength="50" placeholder="" required="required"></asp:TextBox>
                        </div>

                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="PageMappingEdit.aspx.cs" Inherits="Finware.PageMapping.PageMappingEdit"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <script>
        function ClearForm() {
            document.getElementById('txtPageMappingX').value = '';
        }
    </script>
    <div id="content" class="ui-content ui-content-aside-overlay">
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:LinkButton ID="btUpdate" runat="server" CssClass="btn btn-success" OnClick="btpageUpdate_Click">Save</asp:LinkButton>
                    <asp:LinkButton ID="btSave" runat="server" CssClass="btn btn-success" OnClick="btpageSave_Click">Save</asp:LinkButton>
                    <asp:LinkButton ID="btDelete" runat="server" CssClass="btn btn-success" CausesValidation="False" OnClick="btpageDelete_Click">Delete</asp:LinkButton>
                    <button id="btnclear" runat="server" type="button" class="btn btn-success" onclick="ClearForm();">Clear</button>
                    <asp:Button ID="btnBack" runat="server" CssClass="btn btn-success" CausesValidation="False" Text="Back" OnClick="btnBack_Click" formnovalidate="formnovalidate"></asp:Button>
                </div>
            </div>
        </div>

        <div class="ui-content-body">
            <div class="ui-container">
                <div class="row">
                    <h3 class="hepad">
                        <asp:Label ID="lblSearchHeaderText" runat="server" Text="Page Mapping Edit"></asp:Label></h3>
                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="msgalert" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label ID="lblMsg" runat="server" Text="Role can not be deleted.It is assigned to some other User."></asp:Label></div>
                        <div runat="server" id="msgcool" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lbsuccess"></asp:Label></div>
                        <div class="form-group col-md-4 col-sm-4">
                            <label for="web">PageMapping Name</label>
                            <asp:TextBox ID="txtPageMappingX" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="50" autofocus></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valPageMappingX" runat="server" ClientIDMode="Static" ErrorMessage="<br/>This field is required" ControlToValidate="txtPageMappingX" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>

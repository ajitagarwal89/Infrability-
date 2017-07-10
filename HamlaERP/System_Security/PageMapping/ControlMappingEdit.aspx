<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ControlMappingEdit.aspx.cs" Inherits="Finware.PageMapping.ControlMappingEdit"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <script>
    function ClearForm() {
        document.getElementById('txtControlMappingX').value = '';
    }
    </script>
    <div id="content" class="ui-content ui-content-aside-overlay">
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button ID="btSave" runat="server" CssClass="btn btn-success" OnClick="btcontrolSave_Click" Text="Save"></asp:Button>
                    <asp:Button ID="btUpdate" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btcontrolUpdate_Click"></asp:Button>
                    <asp:Button ID="btDelete" runat="server" CausesValidation="false" CssClass="btn btn-success" Text="Delete" OnClick="btdeleteControl_Click"></asp:Button>
                    <button id="btnclear" runat="server" type="button" class="btn btn-success" onclick="ClearForm();">Clear</button>
                    <asp:Button ID="btnBack" runat="server" CssClass="btn btn-success" Text="Back" OnClick="btnBack_Click" formnovalidate="formnovalidate"></asp:Button>
                </div>
            </div>
        </div>

        <div class="ui-content-body">
            <div class="ui-container">
                <div class="row">
                    <h3 class="hepad"><asp:Label ID="lblPageName" runat="server" Text="Update Control Name"></asp:Label></h3>
                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="msgalert" visible="false" class="alert alert-danger" role="alert"><asp:Label ID="lblMsg" runat="server" Text="Role can not be deleted.It is assigned to some other User."></asp:Label></div>
                        <div runat="server" id="msgcool" visible="false" class="alert alert-success" role="alert"><asp:Label runat="server" ID="lbsuccess"></asp:Label></div>
                        <div class="form-group col-md-4 col-sm-4">
                            <label for="web">ControlMapping Name</label>
                            <asp:TextBox ID="txtControlMappingX" runat="server" ClientIDMode="Static" CssClass="form-control" Text='<%# ds.Tables[0].Rows[0]["ControlMappingX"] %>' MaxLength="50" autofocus></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valControlMappingX" runat="server" ErrorMessage="<br/>This field is required" ControlToValidate="txtControlMappingX" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <label for="web">Control Code</label>
                            <asp:TextBox ID="txtControlMappingCode" runat="server" Enabled="false" CssClass="form-control" MaxLength="50" Text='<%# ds.Tables[0].Rows[0]["ControlMappingCode"] %>'></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

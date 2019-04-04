<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="SecurityProfileEdit.aspx.cs" Inherits="Finware.SecurityProfile.SecurityProfileEdit"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <script>
    function ClearForm() {
        document.getElementById('txtSecurityProfileX').value = '';
    }
    </script>
    <div id="content" class="ui-content ui-content-aside-overlay">
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button ID="btSave" runat="server" CssClass="btn btn-success" OnClick="btprofileSave_Click" Text="Save"></asp:Button>
                    <asp:Button ID="btUpdate" runat="server" CssClass="btn btn-success" OnClick="btprofileUpdate_Click" Text="Save"></asp:Button>
                    <asp:Button ID="btDelete" runat="server" CssClass="btn btn-success" CausesValidation="False" OnClick="btprofileDelete_Click" Text="Delete"></asp:Button>
                    <button id="btnclear" runat="server" type="button" class="btn btn-success" onclick="ClearForm();">Clear</button>
                    <asp:Button ID="btnBack" runat="server" CssClass="btn btn-success" CausesValidation="False" Text="Back" OnClick="btnProfileList_Click" formnovalidate="formnovalidate"></asp:Button>
                    <asp:Button ID="btnManageProfile" runat="server" Visible="false" CssClass="btn btn-success" CausesValidation="False" Text="Manage Profile" OnClick="btnManageProfile_Click" formnovalidate="formnovalidate"></asp:Button>
                </div>
            </div>
        </div>

        <div class="ui-content-body">
            <div class="ui-container">
                <div class="row">
                    <h3 class="hepad"><asp:Label ID="lblSearchHeaderText" runat="server" Text="Security Profile Edit"></asp:Label></h3>
                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="msgalert" visible="false" class="alert alert-danger" role="alert"><asp:Label runat="server" ID="lbmsg"></asp:Label></div>
                        <div runat="server" id="msgcool" visible="false" class="alert alert-success" role="alert"><asp:Label runat="server" ID="lbsuccess"></asp:Label></div>
                        <div class="form-group col-md-4 col-sm-4">
                        <asp:TextBox ID="txtSecurityProfileX" runat="server" ClientIDMode="Static" CssClass="form-control" Text='<%# ds.Tables[0].Rows[0]["SecurityProfileX"] %>' MaxLength="50" required autofocus></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="ProfileId" />
    <asp:HiddenField runat="server" ID="ProfileName" />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <div class="ui-content-body">
            <div class="ui-container">
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4"></div>
                    <div class="col-md-4">
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        function openOrganizationSelectModal() {
            document.getElementById('btnOpenOrganizationModal').click();
        }
    </script>
    <a href="#" id="btnOpenOrganizationModal" class="btn btn-default" data-toggle="modal" data-keyboard="false" data-backdrop="static" data-target="#organizationModal" style="display:none"></a>
    <div class="modal fade" id="organizationModal" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <%--<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>--%>
                    <h4 class="modal-title" id="myModalLabel"><span>Organizations</span></h4>
                </div>
                <div class="modal-body">
                    <asp:Label runat="server" ID="lblOrganization" Text="Select Oganization"></asp:Label>
                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlOrganizationList"></asp:DropDownList><br />
                </div>
                <div class="modal-footer row" runat="server" id="div_bk_footer">
                    <div class="pull-right">
                        <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button></div>--%>
                        <div class="pull-right"><asp:Button runat="server" CssClass="btn btn-default" ID="btnOk" Text="Ok and Continue" OnClick="btnOk_Click" formnovalidate="formnovalidate"></asp:Button></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="PageMappingView.aspx.cs" Inherits="Finware.PageMapping.PageMappingView"
    Title="View Page Mapping" %>


<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button ID="btCreate" runat="server" CssClass="btn btn-success" OnClick="btCreate_Click" Text="New"></asp:Button>
                    <%--<asp:Button ID="lnkEdit" runat="server" CssClass="btn btn-success" OnClick="lnkEdit_Click1" Text="Edit"></asp:Button>--%>
                    <asp:LinkButton ID="btcontroldelete" runat="server" CssClass="btn btn-success" CausesValidation="False" OnClick="btcontroldelete_Click" >Delete</asp:LinkButton>
                    <asp:Button ID="lnkCancel" runat="server" CssClass="btn btn-success" OnClick="lnkCancel_Click1" Text="Back"></asp:Button>
                </div>
            </div>
        </div>

        <div class="ui-content-body">
            <div class="ui-container">
                <div class="row">
                    <h3 class="hepad"><asp:Label ID="lblPageMappingX" runat="server"></asp:Label></h3>
                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="msgalert" visible="false" class="alert alert-danger" role="alert"><asp:Label runat="server" ID="lblmsg"></asp:Label></div>
                        <div runat="server" id="msgcool" visible="false" class="alert alert-success" role="alert"><asp:Label runat="server" ID="lbsuccess"></asp:Label></div>
                        <asp:DataGrid ID="grdControlMapping" GridLines="None" Width="100%" Font-Size="10pt" BorderStyle="None" CssClass="table table-hover" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundColumn DataField="ControlMapping" Visible="false"></asp:BoundColumn>
                                <asp:TemplateColumn ItemStyle-Width="5%">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkrow" runat="server" />
                                </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn HeaderText="Control Names" HeaderStyle-HorizontalAlign="Left" DataField="ControlMappingX" ItemStyle-Width="80%"></asp:BoundColumn>
                                <asp:HyperLinkColumn DataNavigateUrlField="JumpParam" HeaderStyle-HorizontalAlign="Center" DataNavigateUrlFormatString="{0}"
                                    HeaderImageUrl="~/images/edit.png" Text="Edit"></asp:HyperLinkColumn>
                            </Columns>
                            <HeaderStyle BackColor="#24648f" ForeColor="White" />
                        </asp:DataGrid>
                        <style>
                        table.table td a {
                            display: inline-block;
                            padding: 6px 12px;
                            margin-bottom: 0;
                            font-size: 12px;
                            font-weight: 400;
                            line-height: 1.42857143;
                            text-align: center;
                            white-space: nowrap;
                            vertical-align: middle;
                            -ms-touch-action: manipulation;
                            touch-action: manipulation;
                            cursor: pointer;
                            -webkit-user-select: none;
                            -moz-user-select: none;
                            -ms-user-select: none;
                            user-select: none;
                            background-image: none;
                            border: 1px solid transparent;
                            border-radius: 0px;
                            color: #333;
                            background-color: #fff;
                            border-color: #e26f63;
                            border-width:2px;
                            width:100%;
                        }
                        table.table td a:hover {
                            text-decoration:none;
                            color: #333;
                            background-color: #2c8fe9;
                            border-color: #24648f;
                            color:#fff;
                            border-width:2px;
                        }
                    </style>
                    </div>
                </div>
            </div>
        </div>
    </div>

    
</asp:Content>

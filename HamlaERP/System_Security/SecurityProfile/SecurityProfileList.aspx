<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="SecurityProfileList.aspx.cs" Inherits="Finware.SecurityProfile.SecurityProfileList"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <div class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button ID="btprofileCreate" runat="server" CssClass="btn btn-success" Text="New" OnClick="btprofileCreate_Click" />
                    <asp:LinkButton ID="btprofiledelete" runat="server" CssClass="btn btn-success" CausesValidation="False" OnClick="btprofiledelete_Click">Delete</asp:LinkButton>
                    <%--<asp:Button ID="lnkBack" runat="server" Text="Back" CssClass="btn btn-success" OnClick="lnkBack_Click" />--%>
                </div>
            </div>
        </div>
        <div class="ui-content-body">
            <div class="ui-container">
                <div class="row">
                    <h3 class="hepad">Security Profile(s)</h3>
                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="msgalert" visible="false" class="alert alert-danger" role="alert"><asp:Label runat="server" ID="lbmsg"></asp:Label></div>
                        <div runat="server" id="msgcool" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lbsuccess"></asp:Label></div>
                        <asp:DataGrid ID="grdPage" runat="server" PageSize="20" AllowPaging="True" AutoGenerateColumns="False" Width="100%" GridLines="None" BorderStyle="None" CssClass="table table-hover">
                            <PagerStyle HorizontalAlign="Left" Mode="NumericPages" CssClass="pagination-ys"></PagerStyle>
                            <Columns>
                                <asp:BoundColumn DataField="SecurityProfile" Visible="false"></asp:BoundColumn>
                                <asp:TemplateColumn>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkrow" runat="server" />
                                </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn HeaderText="Security Profile" DataField="SecurityProfileX" ItemStyle-Width="69%"></asp:BoundColumn>
                                <asp:HyperLinkColumn DataNavigateUrlField="JumpParam" ItemStyle-Width="13%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataNavigateUrlFormatString="{0}"
                                    HeaderText="Page List" Text="View">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:HyperLinkColumn>
                                <asp:TemplateColumn HeaderImageUrl="~/images/edit.png" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="lnkeditprofile" ItemStyle-Width="15%" OnClick="lnkEdit_Click" CommandArgument='<%#Eval("SecurityProfile") %>'>Edit</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
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

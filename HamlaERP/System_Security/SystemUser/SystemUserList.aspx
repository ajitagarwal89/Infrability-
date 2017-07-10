<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="SystemUserList.aspx.cs" Inherits="Finware.SystemUserList" Title="System User" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button ID="lnkCreate" CausesValidation="false" runat="server" CssClass="btn btn-success" Text="New" OnClick="lnkCreate_Click1" />
                    <%--<asp:Button ID="lnkCancel" CausesValidation="false" runat="server" CssClass="btn btn-success" Text="Clone" OnClick="lnkCancel_Click1" />--%>
                    <asp:Button runat="server" ID="btnUserDelete" CssClass="btn btn-success" ClientIDMode="Static" Text="Delete" OnClick="btUserDelete_Click" />
                    <asp:Panel runat="server" ID="pnlorgsearch" DefaultButton="btnSearch">
                        <div class="col-md-4 col-xs-5">
                            <div class="icon-addon addon-md">
                                <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control" placeholder="Search..." autofocus></asp:TextBox>
                                <a onclick="SearchOrg();" class="fa fa-search"></a>
                            </div>
                        </div>
                        <asp:Button runat="server" ID="btnSearch" Style="display: none;" ClientIDMode="Static" />
                    </asp:Panel>
                </div>
            </div>
        </div>


        <div class="ui-content-body">
            <div class="ui-container">
                <div class="row">
                    <h3 class="hepad"><asp:Label ID="lblPageName" runat="server" Text="System User List"></asp:Label></h3>
                <div class="col-md-12 col-sm-12 colformstyle3">
                    <div runat="server" id="msgalert" visible="false" class="alert alert-danger" role="alert"><asp:Label runat="server" ID="lblmsg"></asp:Label></div>
                    <div runat="server" id="msgcool" visible="false" class="alert alert-success" role="alert"><asp:Label runat="server" ID="lbsuccess"></asp:Label></div>
                    
                    <div class="row padding-for-labels">
                        <div class="col-md-12"><asp:Label ID="lblSchoolAccess" runat="server" Visible="False"> Click "Grant Access" for each person you wish to add to the School user list.</asp:Label></div>
                    </div>
                    <div class="row padding-for-labels">
                        <div class="col-md-12"><asp:Label ID="lblConfirmation" Visible="false" runat="server" /></div>
                    </div>
                    
                <asp:DataGrid ID="grdPage" ClientIDMode="Static" runat="server" AutoGenerateColumns="False"
                    GridLines="None" Font-Size="10pt" Width="100%" BorderStyle="None" CssClass="test table table-hover" OnItemDataBound="grdPage_ItemDataBound"
                    AllowPaging="True" PageSize="15">
                    <Columns>
                        <asp:BoundColumn DataField="SystemUser" Visible="False"></asp:BoundColumn>
                        <asp:TemplateColumn ItemStyle-Width="3%">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkrow" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        <asp:ButtonColumn Visible="False" Text="Grant Access" CommandName="Select"></asp:ButtonColumn>
                        <asp:BoundColumn HeaderText="Name" DataField="FullName" ItemStyle-Width="20%"></asp:BoundColumn>
                        <asp:BoundColumn DataField="UserId" HeaderText="Login Id" ItemStyle-Width="14%" ItemStyle-HorizontalAlign="Left">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="EmailAddress" Visible="false" HeaderText="Email" ItemStyle-HorizontalAlign="Left">
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="IsActive" ItemStyle-Width="10%">
                            <ItemStyle />
                            <ItemTemplate>
                                <asp:Button ID="btnUserActivate" OnClick="btnUserActivate_Click" ToolTip="Activate User"
                                    CssClass="btn btn-default btn-sm btn-block" Text="Activate" CommandArgument='<%# Eval("SystemUser") %>' Visible='<%# Convert.ToBoolean(Eval("IsActive")) %>'
                                    runat="server" />
                                <asp:Button ID="btnUserDeactivate" OnClick="btnUserDeactivate_Click" Text="Deactivate" ToolTip="Deactivate User"
                                    CssClass="btn btn-default btn-sm btn-block" CommandArgument='<%# Eval("SystemUser") %>' Visible='<%#! Convert.ToBoolean(Eval("IsActive")) %>'
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="IsLocked" ItemStyle-Width="10%">
                            <ItemStyle/>
                            <ItemTemplate>
                                <asp:Button ID="btnUserLock" OnClick="btnUserLock_Click" Text="Unlock" CssClass="btn btn-default btn-sm btn-block" ToolTip="Unlock User"
                                    CommandArgument='<%# Eval("SystemUser") %>' Visible='<%# Convert.ToBoolean(Eval("IsLocked")) %>'
                                    runat="server" />
                                <asp:Button ID="btnUserUnlock" OnClick="btnUserUnlock_Click" Text="Lock" CssClass="btn btn-default btn-sm btn-block" ToolTip="Lock User"
                                    CommandArgument='<%# Eval("SystemUser") %>' Visible='<%#! Convert.ToBoolean(Eval("IsLocked")) %>'
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Password" ItemStyle-Width="10%">
                            <ItemStyle />
                            <ItemTemplate>
                                <asp:Button ID="btnResetPassword" CommandArgument='<%# Eval("SystemUser") %>'
                                    OnClick="btnUserResetPassword_Click" CssClass="btn btn-default btn-sm btn-block" ToolTip="Reset Password" runat="server"
                                    Text="Reset" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <%--<asp:TemplateColumn HeaderText="Delete">
                            <ItemStyle Width="6%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="imgDelete" CommandArgument='<%# Eval("SystemUser") %>' CommandName="Delete"
                                    CssClass="imgCursor" ToolTip="Delete User" runat="server" SkinID="DeleteGrid"
                                    OnClientClick="return confirmDeletion()"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>--%>
                        <asp:TemplateColumn HeaderImageUrl="~/images/eye.png" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <button id="lnkview_<%# Container.DataSetIndex + 1 %>" type="button" data-toggle="modal" data-target="#basicModalOrg" data-keyboard="false" data-backdrop="static" class="btn btn-default btn-sm btn-block" onclick="setUserDetails('<%#Eval("fullname")%>','<%#Eval("UserId")%>','<%#Eval("dateofbirth")%>','<%#Eval("educationqaulification")%>','<%#Eval("emailaddress")%>','<%#Eval("phone")%>','<%#Eval("permanentaddress")%>','<%#Eval("correspondanceaddress")%>','lnkview_<%# Container.DataSetIndex + 1 %>');">View</button>
                                    <button id="lnkv_<%# Container.DataSetIndex + 1 %>" style="display:none;" type="button" class="btn btn-default btn-sm" onclick="setUserDetails('<%#Eval("fullname")%>','<%#Eval("UserId")%>','<%#Eval("dateofbirth")%>','<%#Eval("educationqaulification")%>','<%#Eval("emailaddress")%>','<%#Eval("phone")%>','<%#Eval("permanentaddress")%>','<%#Eval("correspondanceaddress")%>','lnkview_<%# Container.DataSetIndex + 1 %>');"></button>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        <asp:HyperLinkColumn ItemStyle-CssClass="test" ItemStyle-Width="10%" DataNavigateUrlField="JumpParam" Text="Edit" DataNavigateUrlFormatString="{0}" HeaderImageUrl="~/images/edit.png" HeaderStyle-HorizontalAlign="Center"></asp:HyperLinkColumn>
                    </Columns>
                    <HeaderStyle BackColor="#24648f" ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" />
                    <PagerStyle Mode="NumericPages" HorizontalAlign="Left" CssClass="pagination-ys"></PagerStyle>
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
    <script type="text/javascript">
        function setUserDetails(name, id, dob, edu, email, phone, padd, cadd, lid) {
            document.getElementById("lbname").innerHTML = name;
            document.getElementById("lblogin").innerHTML = id;
            //document.getElementById("lbsrole").innerHTML = role;
            document.getElementById("lbdob").innerHTML = dob;
            document.getElementById("lbedu").innerHTML = edu;
            document.getElementById("lbemail").innerHTML = email;
            document.getElementById("lbphone").innerHTML = phone;
            document.getElementById("lbpadd").innerHTML = padd;
            document.getElementById("lbcadd").innerHTML = cadd;
            document.getElementById("lbid").innerHTML = lid;
            var maxrows = document.getElementById('grdPage').rows.length - 1;
            var num = document.getElementById('lbid').innerHTML.split('_');
            if (num[1] == maxrows) {
                document.getElementById('next').class = 'btn btn-default disabled';
            }
            else {
                document.getElementById('next').class = 'btn btn-default';
            }
            if (num[1] == 1) {
                document.getElementById('prev').class = 'btn btn-default disabled';
            }
            else {
                document.getElementById('prev').class = 'btn btn-default';
            }
        }
    </script>
    <div class="modal fade" id="basicModalOrg" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header" style="text-align:left;">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h4 class="modal-title" id="myModalLabel"><span>System User Details</span></h4>
          </div>
          <div class="modal-body">
            <table class="table table-striped" style="width:100%;font-size:9.5pt;">
                <tr>
                    <td>Name</td>
                    <td>Login ID</td>
                </tr>
                <tr>
                    <td><asp:Label ID="lbname" runat="server" ClientIDMode="Static"></asp:Label></td>
                    <td><asp:Label ID="lblogin" runat="server" ClientIDMode="Static"></asp:Label></td>
                    
                    
                </tr>
                <tr>
                    <td>System Role</td>
                    <td>Date of Birth</td>
                </tr>
                <tr>
                    <td><asp:Label ID="lbsrole" runat="server" ClientIDMode="Static"></asp:Label></td>
                    <td><asp:Label ID="lbdob" runat="server" ClientIDMode="Static"></asp:Label></td>
                </tr>
                <tr>
                    <td>Education</td>
                    <td>Phone</td>
                </tr>
                <tr>
                    <td><asp:Label ID="lbedu" runat="server" ClientIDMode="Static"></asp:Label></td>
                    <td><asp:Label ID="lbphone" runat="server" ClientIDMode="Static"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2">Email</td>
                </tr>
                <tr>
                    <td colspan="2"><asp:Label ID="lbemail" runat="server" ClientIDMode="Static"></asp:Label></td>
                </tr>
                <tr>
                    <td style="word-wrap:break-word;width:340px;">Permanent Address</td>
                    <td style="word-wrap:break-word;width:340px;">Correspondence Address</td>
                </tr>
                <tr>
                    <td><asp:Label ID="lbpadd" runat="server" ClientIDMode="Static"></asp:Label></td>
                    <td><asp:Label ID="lbcadd" runat="server" ClientIDMode="Static"></asp:Label></td>
                </tr>
            </table>
          </div>
          <div class="modal-footer row" runat="server" id="div_bk_footer">
              <div class="btn-group pull-right" role="group" aria-label="...">
                  <a id="prev" class="btn btn-default" role="button" onclick="showPrevRecord();"><i class="fa fa-chevron-circle-left"></i> Prev</a>
                  <a id="next" class="btn btn-default" role="button" onclick="showNextRecord();">Next <i class="fa fa-chevron-circle-right"></i></a>
              </div>
            <asp:Label ID="lbid" runat="server" style="display:none;" ClientIDMode="Static"></asp:Label>
            <div class="pull-left"><button type="button" class="btn btn-default" data-dismiss="modal">Close</button></div>
          </div>
        </div>
      </div>
    </div>
    <script>
        function showNextRecord() {
            var num = document.getElementById('lbid').innerHTML.split('_');
            var lnk = parseInt(num[1]) + 1;
            //alert(lnk)
            document.getElementById('lnkv_' + lnk).click();
        }
        function showPrevRecord() {
            var num = document.getElementById('lbid').innerHTML.split('_');
            var lnk = parseInt(num[1]) - 1;
            //alert(lnk)
            document.getElementById('lnkv_' + lnk).click();
        }
    </script>

    <script type="text/javascript">
    function confirmDeletion()
    {
        if(confirm("Delete the user?"))
            return true;
        else
            return false;
    }
    function confirmResetPassword()
    {
        if(confirm("Reset the Password?"))
           return true;
        else
         return false;
    }
    </script>

</asp:Content>

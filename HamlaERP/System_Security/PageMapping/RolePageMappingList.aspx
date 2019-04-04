<%@ Page Language="c#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    Inherits="Finware.RolePageMappingList" CodeFile="RolePageMappingList.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <script src="../../infra_components/jquery/dist/jquery-1.3.2.min.js"></script>
    <div id="content" class="ui-content ui-content-aside-overlay">
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" OnClick="btnSavePageMapping_Click" Text="Save"></asp:Button>
                    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-success" OnClick="btnBack_Click" />
                </div>
            </div>
        </div>

        <div class="ui-content-body">
            <div class="ui-container">
                <div class="row">
                    <h3 class="hepad"><asp:Label ID="lblPageName" runat="server" Text="Role Page Mapping List"></asp:Label></h3>
                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="msgalert" visible="false" class="alert alert-danger" role="alert"><asp:Label runat="server" ID="lblmsg"></asp:Label></div>
                        <div runat="server" id="msgcool" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lbsuccess"></asp:Label></div>
                       <%-- <asp:UpdatePanel ID="pnl" runat="server">
                    <ContentTemplate>--%>
                        <asp:DataGrid ID="grdPage" runat="server" GridLines="None" BorderStyle="None" CssClass="table table-hover"
                            AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundColumn DataField="PageMapping" Visible="false"></asp:BoundColumn>
                                <asp:BoundColumn DataField="PageMappingX" HeaderText="Page Name"></asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Select" ItemStyle-Width="13%">
                                    <HeaderTemplate>
                                       <asp:CheckBox ID="chkCheckall" Visible="false" runat="server" AutoPostBack="true" Text="Read" Font-Size="12pt" Font-Bold="true" />
                                        <div id="selallR"><span id='CheckItAll' class="fa fa-circle-o chkredR" style="font-size:15pt;cursor:pointer;"></span><span style="font-size:11pt;color:#fff;"> Access</span></div>
                                        <div id="unselallR" style="display:none;"><span id='UnCheckItAll' class="fa fa-check chkgreenR" style="font-size:15pt;cursor:pointer;"></span><span style="font-size:11pt;color:#fff;"> Access</span></div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <input type="checkbox" runat="server" class='chkread' style="display:none" value='<%# Eval("Pagemapping") %>' id="chkRead"
                                            checked='<%# Convert.ToBoolean( Eval("Read")) %>' />
                                        <div onclick="unselroleR_<%#Eval("Pagemapping")%>();"><span id='CheckItR<%# Container.ItemIndex %>' class="fa fa-check chkgreenR" style="display:none;font-size:15pt;cursor:pointer"></span></div>
                                        <div onclick="selroleR_<%#Eval("Pagemapping")%>();"><span id='UnCheckItR<%# Container.ItemIndex %>' class="fa fa-circle-o chkredR" style="font-size:15pt;cursor:pointer"></span></div>
                                        <script>
                                            function selroleR_<%#Eval("Pagemapping")%>() {
                                                    $('#PageContent_grdPage_chkRead_' + '<%# Container.ItemIndex %>').prop('checked', true);
                                                    $('#CheckItR' + '<%# Container.ItemIndex %>').css({ 'display': 'block' });
                                                    $('#UnCheckItR' + '<%# Container.ItemIndex %>').css({ 'display': 'none' });
                                                }
                                            function unselroleR_<%#Eval("Pagemapping")%>() {
                                                $('#PageContent_grdPage_chkRead_' + '<%# Container.ItemIndex %>').prop('checked', false);
                                                $('#CheckItR' + '<%# Container.ItemIndex %>').css({ 'display': 'none' });
                                                $('#UnCheckItR' + '<%# Container.ItemIndex %>').css({ 'display': 'block' });
                                            }
                                            $('#selallR').click(function(event) {
                                                $('input.chkread').prop('checked', true);
                                                $("#unselallR").css({ 'display': 'block' });
                                                $("#selallR").css({ 'display': 'none' });
                                                $('.chkgreenR').show();
                                                $('.chkredR').hide();
                                            });
                                            $('#unselallR').click(function(event) {
                                                $('input.chkread').attr('checked', false);
                                                $("#unselallR").css({ 'display': 'none' });
                                                $("#selallR").css({ 'display': 'block' });
                                                $('.chkgreenR').hide();
                                                $('.chkredR').show();
                                            });
                                        </script>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                
                                
                                <asp:HyperLinkColumn DataNavigateUrlField="JumpParam" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataNavigateUrlFormatString="{0}"
                                    HeaderText="Settings" Text="Advance" ItemStyle-Width="12%"></asp:HyperLinkColumn>
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
                    <%--</ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>--%>
                    <script type="text/javascript">
                        $(document).ready(function(){
                            var grid = document.getElementById('<%=grdPage.ClientID %>');

                            for (var r = 0; r < grid.rows.length; r++)
                            {
                                if ($('#PageContent_grdPage_chkRead_' + r).prop('checked') == true) {
                                    $('#CheckItR' + r).css({ 'display': 'block' });
                                    $('#UnCheckItR' + r).css({ 'display': 'none' });
                                }
                            }
                        });
                    </script>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

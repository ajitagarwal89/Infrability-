<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="SecurityDetailEdit.aspx.cs" Inherits="Finware.SecurityProfile.SecurityDetailEdit"
    Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" OnClick="btnSavePageControlMapping_Click" Text="Save"></asp:Button>
                    <asp:Button ID="btnBack" runat="server" CssClass="btn btn-success" OnClick="btnBack_Click" Text="Back"></asp:Button>
                </div>
            </div>
        </div>

        <div class="ui-content-body">
            <div class="ui-container">
                <div class="row">
                    <h3 class="hepad"><asp:Label ID="lblSearchHeaderText" runat="server" Text="Edit Control(s)"></asp:Label></h3>
                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="msgalert" visible="false" class="alert alert-danger" role="alert"><asp:Label runat="server" ID="lblmsg"></asp:Label></div>
                        <div runat="server" id="msgcool" visible="false" class="alert alert-success" role="alert"><asp:Label runat="server" ID="lbsuccess"></asp:Label></div>
                        <asp:DataGrid ID="grdSecurityDetail" GridLines="None" BorderStyle="None" CssClass="table table-hover" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundColumn DataField="ControlMapping" Visible="false"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Control Name" DataField="ControlName" HeaderStyle-HorizontalAlign="Left"></asp:BoundColumn>
                                <%--<asp:BoundColumn HeaderText="Control Type" DataField="ControlMappingX" ItemStyle-Width="15%"></asp:BoundColumn>--%>
                                <asp:TemplateColumn HeaderText="Control State" ItemStyle-Width="50%" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <div class="controls radio">
                                        <asp:RadioButtonList ID="optControlState" Width="100%" runat="server" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "Privelege") %>' RepeatDirection="Horizontal">
                                            <asp:ListItem Value="V"><span class="label label-success text-center" style="font-size:11pt;">Enable</span></asp:ListItem>
                                            <asp:ListItem Value="D"><span class="label label-default text-center" style="font-size:11pt;">Disable</span></asp:ListItem>
                                            <asp:ListItem Value="M"><span class="label label-info text-center" style="font-size:11pt;">Mask</span></asp:ListItem>
                                            <asp:ListItem Value="H"><span class="label label-danger text-center" style="font-size:11pt;">Hide</span></asp:ListItem>                                            
                                        </asp:RadioButtonList>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <%--<asp:TemplateColumn Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSecurityProfile" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SecurityProfile") %>'>Label</asp:Label>
                                        <asp:Label ID="lblControlMapping" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ControlMapping") %>'>Label</asp:Label>
                                        <asp:Label ID="lblSecurityDetail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SecurityDetail") %>'>Label</asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>--%>
                            </Columns>
                            <HeaderStyle BackColor="#24648f" ForeColor="White" HorizontalAlign="Center" />
                        </asp:DataGrid>
                    </div>
                </div>
            </div>
        </div>
    </div>

    
</asp:Content>

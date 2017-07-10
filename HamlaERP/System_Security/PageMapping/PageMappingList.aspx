<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="PageMappingList.aspx.cs" Inherits="Finware.PageMapping.PageMappingList"
    Title="Untitled Page" %>


<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button ID="btPageCreate" runat="server" CssClass="btn btn-success" Text="New" OnClick="btPageCreate_Click" />
                    <%--<a id="lnkScannPagesEXE" runat="server" href="../DLL/FormReader.exe" class="btn btn-success" type="application/octet-stream">Scan Pages</a>--%>
                    <asp:LinkButton ID="btDelete" runat="server" CssClass="btn btn-success" CausesValidation="False" OnClick="btPageDelete_Click">Delete</asp:LinkButton>
                </div>
            </div>
        </div>

        <div class="ui-content-body">
            <div class="ui-container">
                <div class="row">
                    <h3 class="hepad">
                        <asp:Label ID="lblSearchHeaderText" runat="server" Text="Page Mapping"></asp:Label></h3>
                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="msgalert" visible="false" class="alert alert-danger" role="alert"><asp:Label runat="server" ID="lbmsg"></asp:Label></div>
                        <div runat="server" id="msgcool" visible="false" class="alert alert-success" role="alert"><asp:Label runat="server" ID="lbsuccess"></asp:Label></div>
                        <asp:DataGrid ID="grdPage" GridLines="None" Width="100%" Font-Size="10pt" BorderStyle="None" CssClass="table table-hover" runat="server" PageSize="20" AllowPaging="True" AutoGenerateColumns="False">
                            <PagerStyle HorizontalAlign="Left" CssClass="pagination-ys" Mode="NumericPages"></PagerStyle>
                            <Columns>
                                <asp:BoundColumn DataField="PageMapping" Visible="false"></asp:BoundColumn>
                                <asp:TemplateColumn ItemStyle-Width="5%">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkrow" runat="server" />
                                </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn HeaderText="Page Name" HeaderStyle-HorizontalAlign="Left" DataField="PageMappingX" ItemStyle-Width="65%"></asp:BoundColumn>
                                <asp:HyperLinkColumn Text="View" ItemStyle-Width="15%" DataNavigateUrlField="JumpParam" DataNavigateUrlFormatString="{0}"
                                    HeaderText="Page Controls">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:HyperLinkColumn>
                                <asp:TemplateColumn HeaderImageUrl="~/images/edit.png" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="lnkeditpage" ItemStyle-Width="15%" OnClick="lnkEdit_Click" CommandArgument='<%#Eval("Pagemapping") %>'>Edit</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                            <HeaderStyle BackColor="#24648f" ForeColor="White" HorizontalAlign="Center" />
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


    <div class="container-fluid">
        
        <div class="row margin-for-labels">
            <div class="col-md-2"></div>
            <div class="col-md-2"></div>
            <div class="col-md-5"></div>
            <div class="col-md-3">
                
            </div>
        </div>
    </div>

</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="SecurityProfileView.aspx.cs" Inherits="Finware.SecurityProfile.SecurityProfileView"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button ID="lnkEdit" runat="server" CssClass="btn btn-success" Text="Edit" OnClick="lnkEdit_Click" />
                <asp:Button ID="lnkCancel" runat="server" Text="Back" CssClass="btn btn-success" OnClick="lnkCancel_Click" />
                </div>
            </div>
        </div>
        <div class="ui-content-body">
            <div class="ui-container">
                <div class="row">
                    <h3 class="hepad"><asp:Label ID="lblPageTitle" runat="server" SkinID="LabelPageTitle" Text="Security Profile View"></asp:Label></h3>
                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="msgalert" visible="false" class="alert alert-danger" role="alert">No records found!</div>
                        <div runat="server" id="msgcool" visible="false" class="alert alert-success" role="alert"><asp:Label runat="server" ID="lbsuccess"></asp:Label></div>
                    </div>
                    <div>
                        <asp:Label ID="lblSecurityProfileX" runat="server" Text='<%# ds.Tables[0].Rows[0]["SecurityProfileX"] %>'></asp:Label>
                    </div>
                    <div>
                        <asp:DataGrid ID="grdPageMapping" runat="server" AutoGenerateColumns="False" GridLines="None" BorderStyle="None" CssClass="table table-hover">
                            <Columns>
                                <asp:HyperLinkColumn DataNavigateUrlField="JumpParam" DataNavigateUrlFormatString="{0}"
                                    HeaderText="System Forms" DataTextField="PageMappingX"></asp:HyperLinkColumn>
                            </Columns>
                        </asp:DataGrid>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

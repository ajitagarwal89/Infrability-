<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <%--<div id="content" class="ui-content ui-content-aside-overlay">
        <div class="ui-content-body">
            <div class="ui-container">
                <h4>FORM CONTENT</h4>
            </div>
        </div>
    </div>--%>
    
    <div id="content" class="ui-content ui-content-aside-overlay">
                <!--page header start-->
                <div id="ButtonBar" class="page-head-wrap">
                <div class="row">
                <div class="btn-group col-md-10 col-xs-12 pull-left" role="group">
                    <a href="#menu-toggle" class="btn btn-success" id="menu-toggle">Hide Sidebar</a>
                    <a href="#show-menu-toggle" class="btn btn-success" id="show-menu-toggle" style="display:none;">Show Sidebar</a>
                    <button type="button" class="btn btn-success">New</button>
                    <button type="button" class="btn btn-success">Save</button>
                    <button type="button" class="btn btn-success">Delete</button>
                    <button type="button" class="btn btn-success">Clear</button>
                </div>
                </div>
                </div>
                <!--page header end-->

                <div class="ui-content-body">
                    <div class="ui-container">
                        <div class="row">
                            <h4>Vendor Maintenance</h4>
                            <div class="col-md-10 col-sm-10 colformstyle">
                                <div class="col-md-6 col-sm-6">
                                    <label for="name">Vendor ID*</label>
                                    <div class="input-group">
                                        <input type="text" class="form-control" id="namex" placeholder="">
                                        <span class="input-group-btn">
                                            <button type="button" class="btn btn-default"><span class="fa fa-search"></span></button>
                                            <button type="button" class="btn btn-default"><span class="fa fa-file-text"></span></button>
                                        </span>
                                    </div>
                                </div>
                                
                                <div class="form-group col-md-6 col-sm-3">
                                    <label for="email">Status*</label>
                                    <asp:DropDownList runat="server" class="form-control" id="ddlstatus">
                                        <asp:ListItem Value="1">Active</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group col-md-6 col-sm-3">
                                    <label for="vendorid">Name</label>
                                    <input type="text" class="form-control" id="name" placeholder="">
                                </div>

                                <div class="form-group col-md-6 col-sm-6">
                                    <label for="name">Supplier Group Setup</label>
                                    <div class="input-group">
                                        <input type="text" class="form-control" id="name" placeholder="">
                                        <span class="input-group-btn">
                                            <button type="button" class="btn btn-default"><span class="fa fa-search"></span></button>
                                        </span>
                                    </div>
                                </div>

                                <div class="form-group col-md-6 col-sm-3">
                                    <label for="vendorid">Short Name</label>
                                    <input type="text" class="form-control" id="name" placeholder="">
                                </div>

                                <div class="form-group col-md-6 col-sm-3">
                                    <label for="vendorid">Check Name</label>
                                    <input type="text" class="form-control" id="name" placeholder="">
                                </div>

                                <div class="form-group col-md-12 col-sm-12" style="background-color:#24648f;text-align:center"><h5 style="color:#fff;">PRIMARY ADDRESS</h5></div>

                                <div class="form-group col-md-6 col-sm-3">
                                    <label for="vendorid">Contact</label>
                                    <input type="text" class="form-control" id="name" placeholder="">
                                </div>

                                <div class="form-group col-md-6 col-sm-3">
                                    <label for="vendorid">Phone</label>
                                    <input type="text" class="form-control" id="name" placeholder="">
                                </div>

                                <div class="form-group col-md-6 col-sm-3">
                                    <label for="vendorid">Mobile</label>
                                    <input type="text" class="form-control" id="name" placeholder="">
                                </div>

                                <div class="form-group col-md-6 col-sm-3">
                                    <label for="vendorid">Fax</label>
                                    <input type="text" class="form-control" id="name" placeholder="">
                                </div>

                                <div class="form-group col-md-6 col-sm-3">
                                    <label for="vendorid">City</label>
                                    <asp:TextBox runat="server" class="form-control" ID="txtcity" placeholder=""></asp:TextBox>
                                </div>

                                <div class="form-group col-md-6 col-sm-3">
                                    <label for="vendorid">Zip Code</label>
                                    <asp:TextBox runat="server" class="form-control" ID="txtzipcode" placeholder=""></asp:TextBox>
                                </div>

                                <div class="form-group col-md-6 col-sm-6">
                                    <label for="name">Country Code</label>
                                    <div class="input-group">
                                        <input type="text" class="form-control" id="name" placeholder="">
                                        <span class="input-group-btn">
                                            <button type="button" class="btn btn-default"><span class="fa fa-search"></span></button>
                                        </span>
                                    </div>
                                </div>

                                <div class="form-group col-md-6 col-sm-3">
                                    <label for="vendorid">Address</label>
                                    <asp:TextBox runat="server" class="form-control" ID="txtaddress" placeholder="" TextMode="MultiLine" Height="70px"></asp:TextBox>
                                </div>

                                <div class="form-group col-md-6 col-sm-3">
                                    <label for="vendorid">Comment 1</label>
                                    <asp:TextBox runat="server" class="form-control" ID="TextBox1" placeholder=""></asp:TextBox>
                                </div>

                                <div class="form-group col-md-6 col-sm-3">
                                    <label for="vendorid">Comment 2</label>
                                    <asp:TextBox runat="server" class="form-control" ID="TextBox2" placeholder=""></asp:TextBox>
                                </div>

                                <div class="form-group col-md-6 col-sm-6">
                                    <label for="name">Vendor ID*</label>
                                    <div class="input-group">
                                        <span class="input-group-btn">
                                            <button type="button" class="btn btn-default"><span class="fa fa-step-backward"></span></button>
                                            <button type="button" class="btn btn-default"><span class="fa fa-chevron-left"></span></button>
                                            <button type="button" class="btn btn-default"><span class="fa fa-chevron-right"></span></button>
                                            <button type="button" class="btn btn-default"><span class="fa fa-step-forward"></span></button>
                                        </span>
                                        <asp:DropDownList runat="server" class="form-control" id="ddlvndor" placeholder="">
                                            <asp:ListItem Value="0" Text="by Vendor ID"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>

                            
                        </div>
                 </div>
                </div>

   
</asp:Content>


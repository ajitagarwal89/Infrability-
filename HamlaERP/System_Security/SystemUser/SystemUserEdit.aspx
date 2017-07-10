<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="SystemUserEdit.aspx.cs" Inherits="Finware.SystemUserEdit" Title="System User" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
   
            
    <div id="content" class="ui-content ui-content-aside-overlay">
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button ID="btSave" runat="server" CssClass="btn btn-success" OnClick="btAddUser_Click" Text="Save"></asp:Button>
                    <asp:Button ID="btUpdate" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btUpdateUser_Click"></asp:Button>
                    <asp:Button ID="btDelete" runat="server" CssClass="btn btn-success" CausesValidation="False" Text="Delete" OnClick="btDeleteUser_Click"></asp:Button>
                    <button id="btnClear" runat="server" type="button" class="btn btn-success" onclick="ClearForm();">Clear</button>
                    <button id="btRoles" runat="server" class="btn btn-success" type="button" data-toggle="modal" data-target="#basicModalOrg" data-keyboard="false" data-backdrop="static">Manage Profiles</button>
                    <a href="../SystemUser/SystemUserList.aspx" class="btn btn-success">Back</a>
                </div>
            </div>
        </div>
        <div class="ui-content-body">
            <div class="ui-container">
                <div class="row">
                    <div class="col-md-6">
                        <h3 class="hepad pull-left"><asp:Label ID="lbHeaderText" runat="server" Text="Edit System User"></asp:Label></h3>
                    </div>
                    <div class="col-md-6">
                        <h6 class="pull-right" style="margin-top:30px;color:crimson">* Save User to access Advanced Controls</h6>
                    </div>
                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="msgalert" visible="false" class="alert alert-danger" role="alert"><asp:Label ID="valDuplicatePassword" runat="server"></asp:Label></div>
                        <div runat="server" id="msgcool" visible="false" class="alert alert-success" role="alert"><asp:Label ID="lblConfirmation" runat="server" /></div>
                        <div class="form-group col-md-12 text-left" style="background-color:#f6f6f6"><h5>Personal Details</h5></div>
                        <div class="form-group col-md-4 col-sm-4">
                            <label for="code"><asp:Label ID="lblFirstName" runat="Server" Text="First Name *"></asp:Label></label>
                            <asp:RegularExpressionValidator ID="REVLName" CssClass="validcheck" runat="server" Display="Dynamic"  ErrorMessage="Not Valide Name [A-Z],[a-z]" ControlToValidate="txtFirstName" ValidationExpression="^[a-zA-Z\s.]*$"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" Text='<%# ds.Tables[0].Rows[0]["FirstName"] %>' MaxLength="50" autofocus required></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <label for="code"><asp:Label ID="lblLastName" runat="Server" Text="Last Name *"></asp:Label></label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="validcheck" Display="Dynamic" runat="server" ErrorMessage="Not Valide Name [A-Z],[a-z]" ControlToValidate="txtLastName" ValidationExpression="^[a-zA-Z\s.]*$"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" Text='<%# ds.Tables[0].Rows[0]["LastName"] %>' MaxLength="50" required></asp:TextBox>
                            
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <label for="code"><asp:Label ID="lblEmailID" runat="Server" Text="Email Address *"></asp:Label></label>
                            <asp:TextBox ID="txtEmailAddress" runat="server" type="email" CssClass="form-control" Text='<%# ds.Tables[0].Rows[0]["EmailAddress"] %>' MaxLength="50" required></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <label for="code"><asp:Label ID="lblPhone" runat="Server" Text="Cell Phone"></asp:Label></label>
                            <asp:RegularExpressionValidator CssClass="validcheck" ID="RegularExpressionValidator3" runat="server" ErrorMessage="Not Valide CELL No [0-9]" Display="Dynamic" ControlToValidate="txtCellPhone" ValidationExpression="^[0-9]*"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="txtCellPhone" runat="server" CssClass="form-control" Text='<%# ds.Tables[0].Rows[0]["Phone"] %>' MaxLength="15"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <label for="code"><asp:Label ID="lblEduQualification" runat="Server" Text="Education Qualification"></asp:Label></label>
                            <asp:TextBox ID="txtEduQualification" runat="server" CssClass="form-control" Text='<%# ds.Tables[0].Rows[0]["EducationQaulification"] %>' MaxLength="40"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <label for="code"><asp:Label ID="lblDateOfBirth" runat="server" Text="Date Of Birth"></asp:Label></label>
                            <asp:CompareValidator CssClass="validcheck" ErrorMessage="DOB Format (mm/dd/yyyy)" Display="Dynamic" ID="valcDate" ControlToValidate="txtDateOfBirth" Operator="DataTypeCheck" Type="Date" runat="server"></asp:CompareValidator>           
                           <asp:RangeValidator ID="valrDate" CssClass="validcheck"  runat="server" ControlToValidate="txtDateOfBirth" MinimumValue="1/1/1951" MaximumValue="1/1/1999" Type="Date" text="Invald DOB (Age < 18)" Display="Dynamic"/>
                            <div class="icon-addon addon-md">
                            <asp:TextBox ID="txtDateOfBirth" runat="server" CssClass="form-control" Text='<%# string.Format("{0:d}",ds.Tables[0].Rows[0]["DateOfBirth"]) %>' required></asp:TextBox>
                            <label for="dob" class="fa fa-calendar" runat="server" id="calBdate" rel="tooltip" title="Date of Birth"></label>
                            <asp:CalendarExtender ID="calDate" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDateOfBirth"
                                PopupButtonID="calBDate" EnabledOnClient="true">
                            </asp:CalendarExtender>
                            </div>
                        </div>
                        <div class="form-group col-md-6 col-sm-6">
                            <label for="code"><asp:Label ID="lblPermanentAddress" runat="Server" Text="Permanent Address *"></asp:Label></label>
                            <asp:TextBox ID="txtPermanentAddress" runat="server" TextMode="MultiLine" CssClass="form-control" Text='<%# ds.Tables[0].Rows[0]["PermanentAddress"] %>' MaxLength="50" Height="70px" required></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6 col-sm-6">
                            <label for="code"><asp:Label ID="lblCoAddress" runat="Server" Text="Correspondance Address *"></asp:Label></label>
                            <asp:TextBox ID="txtCoAddress" runat="server" TextMode="MultiLine" CssClass="form-control" Text='<%# ds.Tables[0].Rows[0]["CorrespondanceAddress"] %>' MaxLength="50" Height="70px" required></asp:TextBox>
                        </div>
                        <div class="form-group col-md-12" style="background-color:#f6f6f6"><h5>Account Details</h5></div>
                        <div class="form-group col-md-4 col-sm-4">
                            <label for="code"><asp:Label ID="lblLoginID" runat="server" Text="Login ID *"></asp:Label></label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" CssClass="validcheck" ErrorMessage="Not Valid Login, Letters between [A-Z],[a-z] allowed" ControlToValidate="txtUserId" Display="Dynamic" ValidationExpression="^[0-9a-zA-Z''_''@''.'\s.]*$"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="txtUserId" CssClass="form-control" runat="server" Text='<%# ds.Tables[0].Rows[0]["LoginEmailAddress"] %>' MaxLength="50"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4" runat="server" id="divPassword">
                            <label for="code"><asp:Label ID="lblPassword" runat="server" Text="Password *"></asp:Label></label>
                            <asp:UpdatePanel runat="server" ID="UpdPasswd">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" Text='<%#ds.Tables[0].Rows[0]["Password"] %>' TextMode="Password"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <label for="code"><asp:Label ID="lblOrgCode" runat="server" Text="Select Organisation *"></asp:Label></label>
                            <asp:DropDownList ID="drpOrgCode" CssClass="form-control" runat="server" required></asp:DropDownList> 
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <label for="code"><asp:Label ID="lblFailedLoginCount" runat="server" Text="Failed Login Count"></asp:Label></label>
                            <asp:RangeValidator ID="valFailedLoginCount" runat="server" CssClass="validcheck" Display="Dynamic" ControlToValidate="txtFailedLoginCount" ErrorMessage="Invalid number" MaximumValue="1000" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                            <asp:TextBox ID="txtFailedLoginCount" CssClass="form-control" runat="server" Columns="5" Text='<%# ds.Tables[0].Rows[0]["FailedLoginCount"] %>'
                                MaxLength="1" Enabled="False"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-2 col-sm-2">
                            <label for="code"><asp:Label ID="lblActive" runat="server" Text="Active"></asp:Label></label><br />
                            <div style="padding:6px 0 0 0;"><asp:CheckBox ID="chkIsActive" runat="server" Checked='<%# ds.Tables[0].Rows[0]["IsActive"] %>'></asp:CheckBox></div>
                        </div>
                        <div class="form-group col-md-2 col-sm-2">
                            <label for="code"><asp:Label ID="lblLastLogin" Text="Last Login" runat="server" /></label><br />
                            <asp:Label ID="lblLastLoginResult" CssClass="label label-info" runat="server" Font-Size="11pt" Text='<%# ds.Tables[0].Rows[0]["LastLogin"] %>'></asp:Label>
                        </div>
                        <div class="form-group col-md-12" style="background-color:#f6f6f6"><h5>Employee Details</h5></div>
                        <div class="form-group col-md-12">
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalOrg" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header" style="text-align:left;">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h4 class="modal-title" id="myModalLabel"><span>Manage Roles</span></h4>
          </div>
            <div class="modal-body">
                <div runat="server" id="divNoRolesFound" visible="false" class="alert alert-danger" role="alert"><asp:Label ID="lblNoRolesFound" Text="No Roles Found" runat="server"></asp:Label></div>
                <asp:DataGrid ID="grdPage" ShowHeader="false" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="None" BorderStyle="None">
                    <Columns>
                        <asp:BoundColumn DataField="SecurityProfile" Visible="false"></asp:BoundColumn>
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <div id="profilerow_<%#Eval("SecurityProfile")%>" onclick="selprofile_<%#Eval("SecurityProfile")%>('<%#Eval("SecurityProfile")%>');" class="row sprofile">
                                    <div class="container-fluid">
                                        <input type="text" class='<%#Eval("SecurityProfile")%>' style="display: none;" runat="server" id="chkpro" value="0" />
                                        <div id="divselected" class="col-md-8">
                                            <asp:Label runat="server" ID="lbsprofile" Text='<%#Eval("SecurityProfileX")%>'></asp:Label></div>
                                        <div id="sign" class="col-md-4 text-right"><span id="chksign_<%#Eval("SecurityProfile")%>" class="fa fa-circle-o chkred"></span></div>
                                    </div>
                                </div>
                                <script>
                                    function selprofile_<%#Eval("SecurityProfile")%>(id, chk) {
                                        var counter = $('.' + id).val();
                                        if (chk == 'new') {
                                            $('.' + id).val('1');
                                            $("#chksign_" + id).attr("class", "fa fa-check chkgreen");
                                            return false;
                                        }
                                        if (counter == 1) {
                                            $('.' + id).val('0');
                                            $("#chksign_" + id).attr("class", "fa fa-circle-o chkred");
                                        }
                                        else {
                                            $('.' + id).val('1');
                                            $("#chksign_" + id).attr("class", "fa fa-check chkgreen");
                                        }
                                    }
                                </script>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <%--<asp:BoundColumn HeaderText="Security Profile" DataField="SecurityProfileX" ItemStyle-Width="90%"></asp:BoundColumn>--%>
                    </Columns>
                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                </asp:DataGrid>
            </div>
          <div class="modal-footer row" runat="server" id="div_bk_footer">
            <div class="pull-left"><button type="button" class="btn btn-default" data-dismiss="modal">Close</button></div>
            <div class="pull-right"><asp:Button runat="server" CssClass="btn btn-default" ID="btnSave" Text="Save" OnClick="btnSaveRole_Click" formnovalidate="formnovalidate"></asp:Button></div>
          </div>
        </div>
      </div>
    </div>
            
        
    
   
    <asp:HiddenField runat="server" ID="SystemUserId" />
    
    

    <table width="100%" cellspacing="0" cellpadding="0" align="center" class="pageTitleBar">
        <tr>
            <td>
                
            </td>
            <td align="right">
                
                
            </td>
        </tr>
        <tr>
            <td class="containerHdBg" colspan="2">
            </td>
        </tr>
        <tr>
            <td align="center">
                
            </td>
        </tr>
    </table>
    <br />
    <table width="100%" cellspacing="0" cellpadding="0" border="0">
        
        <tr is="trDetail" runat="server" visible="false">
            <td>
                <fieldset>
                    <table width="100%" border="0" cellpadding="5" cellspacing="5" align="center">
                        <tr>
                            <td class="darkgreybgcolor">
                                Employee Details
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="95%" cellspacing="5" cellpadding="5" align="center">
                                    <tr>
                                        <td width="20%">
                                            <asp:Label ID="lblDepartment" runat="server" Text="Department"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpDepartment" runat="server" Width="231px" OnSelectedIndexChanged="drpDepartment_SelectedIndexChanged"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                            <%--<asp:TextBox ID="txtDepartment" runat="server" SkinID="textProjectList" Text='<%# ds.Tables[0].Rows[0]["Department"] %>'>
                                </asp:TextBox>--%>
                                            <span class="rqField">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="drpDepartment"
                                                Display="Dynamic" ErrorMessage="Field Required" InitialValue="-1" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblDateofJoining" runat="server" Text="Date Of Joining"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDateofJoining" runat="server" SkinID="textProjectList1" Text='<%# string.Format("{0:d}",ds.Tables[0].Rows[0]["DateOfJoining"]) %>'>
                                            </asp:TextBox>
                                            <asp:ImageButton ID="calJDate" runat="server" ImageUrl="~/images/calendar.gif" SkinID="calen" />
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" CssClass="redtext" ControlToValidate="txtDateofJoining"
                                                ErrorMessage="Invalid Date" Display="Dynamic" ForeColor="" Type="Date" Operator="DataTypeCheck"></asp:CompareValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="redtext"
                                                ControlToValidate="txtDateofJoining" ErrorMessage="*">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="lblDesignation" runat="server" Text="Designation"></asp:Label>
                                        </td>
                                        <td valign="top">
                                            <asp:DropDownList ID="drpDesignation" runat="server" Width="231px">
                                            </asp:DropDownList>
                                            <%--<asp:TextBox ID="txtDesignation" runat="server" Text='<%# ds.Tables[0].Rows[0]["Designation"] %>'
                                    Columns="35" MaxLength="50">
                                </asp:TextBox>--%>
                                            <span class="rqField">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" CssClass="Validator"
                                                Display="Dynamic" ControlToValidate="drpDesignation" ErrorMessage="Field required"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                                <asp:CalendarExtender ID="caljoDate" runat="server" TargetControlID="txtDateofJoining"
                                    PopupButtonID="calJDate" EnabledOnClient="true">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
            <td align="right">
                
                
            </td>
            <td>
                &nbsp; &nbsp;
            </td>
        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        
    </table>
</asp:Content>

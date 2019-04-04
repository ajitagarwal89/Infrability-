﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Employee.ascx.cs" Inherits="UserControls_Human_Resource_Employee_Master_Data_Manage_Personal_Details_Employee" %>
<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 startimg slideDown">
        <img src="../../../images/supplier.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideUp">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYour" Text="<%$ Resources:GlobalResource, ascxEmployee_ltrAddYour%>"></asp:Literal>
            </div>
            <br />
            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, ascxEmployee_ltrInformation%>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxEmployee_ltrParagraph%>"></asp:Literal>
            </p>

            <p>
              
                <a class="btn btn-success btn-md"  style="width:250px" href="../../../../Human_Resource/Employee_Master_Data/Manage_Personal_Details/EmployeeForm.aspx" role="button">

                    <asp:Literal runat="server" ID="ltrEmployee" Text="<%$ Resources:GlobalResource, btnNew%>"></asp:Literal>
                </a>

                  <a class="btn btn-success btn-md" style="width:250px"  href="../../../../Human_Resource/Employee_Master_Data/Manage_Personal_Details/EmployeeList.aspx" role="button">

                    <asp:Literal runat="server" ID="ltrEmployeeList" Text="<%$ Resources:GlobalResource, btnView%>"></asp:Literal>
                </a>
            </p>
        </div>
    </div>
    <div class="col-md-2"></div>
</div>
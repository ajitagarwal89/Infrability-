<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HR.ascx.cs" Inherits="UserControls_Human_Resource_HR_HR" %>
<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 startimg slideDown">
        <img src="../../../../images/supplier.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideUp">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYour" Text="<%$ Resources:GlobalResource, ascxHR_ltrAddYour%>"></asp:Literal>
            </div>
            <br />
            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, ascxHR_ltrInformation%>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxHR_ltrParagraph%>"></asp:Literal>
            </p>
            <div class="row">
                <a class="btn btn-success btn-md" style="width: 200px" href="../../../Human_Resource/HR/EmployeeEducationForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrEmployeeEducation" Text="<%$ Resources:GlobalResource, ascxHR_ltrEmployeeEducation%>"></asp:Literal>
                </a>

                <a class="btn btn-success btn-md"  style="width:250px" href="../../../Human_Resource/HR/HR_BranchForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrHR_Branch" Text="<%$ Resources:GlobalResource,ascxHR_ltrHR_Branch%>"></asp:Literal>
                </a>

                <a class="btn btn-success btn-md"  style="width:250px" href="../../../Human_Resource/HR/HR_PositionForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrHR_Position" Text="<%$ Resources:GlobalResource, ascxHR_ltrHR_Position%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md"  style="width:250px" href="../../../Human_Resource/HR/HR_SupervisorForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrHR_Supervisor" Text="<%$ Resources:GlobalResource, ascxHR_ltrHR_Supervisor%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md"  style="width:250px" href="../../../Human_Resource/HR/HRDepartmentForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrHRDepartment" Text="<%$ Resources:GlobalResource, ascxHR_ltrHRDepartment%>"></asp:Literal>
                </a>

                <a class="btn btn-success btn-md"  style="width:250px" href="../../../Human_Resource/HR/HRDivisionForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrHRDivision" Text="<%$ Resources:GlobalResource, ascxHR_ltrHRDivision%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md"  style="width:250px"  href="../../../Human_Resource/HR/HRTeamForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrHRTeam" Text="<%$ Resources:GlobalResource, ascxHR_ltrHRTeam%>"></asp:Literal>
                </a>

            </div>

        </div>
    </div>
    <div class="col-md-2"></div>
</div>

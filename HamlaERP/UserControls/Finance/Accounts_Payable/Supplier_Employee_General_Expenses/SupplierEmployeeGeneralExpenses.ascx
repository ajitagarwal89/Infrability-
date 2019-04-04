<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SupplierEmployeeGeneralExpenses.ascx.cs" Inherits="UserControls_Finance_Accounts_Payable_Supplier_General_Expenses_SupplierEmployeeGeneralExpenses" %>
<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 startimg slideDown">
        <img src="../../../images/supplier.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideUp">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYour" Text="<%$ Resources:GlobalResource, ascxSupplierEmployeeGeneralExpenses_ltrAddYour%>"></asp:Literal>
            </div>
            <br />
            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, ascxSupplierEmployeeGeneralExpenses_ltrInformation%>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxSupplierEmployeeGeneralExpenses_ltrParagraph%>"></asp:Literal>
            </p>

            <p>
                <a class="btn btn-success btn-md"  style="width:250px" href="../../../../Finance/Accounts_Payable/Supplier_Employee_General_Expenses/SupplierEmployeeGeneralExpensesForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrNew" Text="<%$ Resources:GlobalResource, btnNew%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" style="width:250px"  href="../../../../Finance/Accounts_Payable/Supplier_Employee_General_Expenses/SupplierEmployeeGeneralExpensesList.aspx" role="button">

                    <asp:Literal runat="server" ID="ltrView" Text="<%$ Resources:GlobalResource, btnView%>"></asp:Literal>
                </a>

            </p>
        </div>
    </div>
<div class="col-md-2"></div>
</div>
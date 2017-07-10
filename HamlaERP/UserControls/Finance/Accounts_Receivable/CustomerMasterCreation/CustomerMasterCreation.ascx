<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CustomerMasterCreation.ascx.cs" Inherits="UserControls_Finance_Accounts_Receivable_CustomerMasterCreation_CustomerMasterCreation" %>
<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 startimg slideDown">
        <img src="../../../../images/supplier.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideUp">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYour" Text="<%$ Resources:GlobalResource, ascxCustomerMasterCreationltrAddYour%>"></asp:Literal>
            </div>
            <br />
            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, ascxCustomerMasterCreationltrInformation%>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxCustomerMasterCreationltrParagraph%>"></asp:Literal>
            </p>
                               
                  <a class="btn btn-success btn-md"  style="width:200px" href="../../../../Finance/Accounts_Receivable/Customer_Master_Creation/CustomerAndGroupAccountForm.aspx" role="button">
                  <asp:Literal runat="server" ID="ltrCustomerAndGroupAccount" Text="<%$ Resources:GlobalResource, btnCustomerAndGroupAccount%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md"  style="width:200px" href="../../../../Finance/Accounts_Receivable/Customer_Master_Creation/CustomerForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrCustomer" Text="<%$ Resources:GlobalResource, btnCustomer%>"></asp:Literal>
                </a> 
             <a class="btn btn-success btn-md"  style="width:200px" href="../../../../Finance/Accounts_Receivable/Customer_Master_Creation/CustomerGroupForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrCustomerGroup" Text="<%$ Resources:GlobalResource, btnCustomerGroup%>"></asp:Literal>
                </a>            
                        <p>
            </p>
            <p>
                
                

            </p>
        </div>
    </div>
    <div class="col-md-2"></div>
</div>
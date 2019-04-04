<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CustomerInvoiceProcess.ascx.cs" Inherits="UserControls_Finance_Accounts_Receivable_Customer_Invoice_Processing__Services_CustomerInvoiceProcess" %>
<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 startimg slideDown">
        <img src="../../../../images/supplier.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideUp">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYour" Text="<%$ Resources:GlobalResource, ascxCustomerInvoiceProcess_ltrAddYour%>"></asp:Literal>
            </div>
            <br />
            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, ascxCustomerInvoiceProcess_ltrInformation%>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxCustomerInvoiceProcess_ltrParagraph%>"></asp:Literal>
            </p>
                               
                  <a class="btn btn-success btn-md"  style="width:250px" href="../../../../Finance/Accounts_Receivable/Customer_Invoice_Processing_(Services)/CustomerInvoiceProcessForm.aspx" role="button">
                  <asp:Literal runat="server" ID="ltrCustomerInvoiceProcessing" Text="<%$ Resources:GlobalResource,btnNew%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md"  style="width:250px" href="../../../../Finance/Accounts_Receivable/Customer_Invoice_(With_Sales_Order)/CustomerInvoiceList.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrCustomerInvoiceProcessingList" Text="<%$ Resources:GlobalResource,btnView%>"></asp:Literal>
                </a>        
                        <p>
            </p>
            <p>
                
                

            </p>
        </div>
    </div>
    <div class="col-md-2"></div>
</div>

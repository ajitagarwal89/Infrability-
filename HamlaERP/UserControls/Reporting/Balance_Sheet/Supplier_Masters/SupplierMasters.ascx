<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SupplierMasters.ascx.cs" Inherits="UserControls_Reporting_Balance_Sheet_Supplier_Masters_SupplierMasters" %>
<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 startimg slideDown">
        <img src="../../../images/supplier.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideUp">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYour" Text="<%$ Resources:GlobalResource, ascxSupplierMasters_ltrAddYour%>"></asp:Literal>
            </div>
            <br />
            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, ascxSupplierMasters_ltrInformation%>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxSupplierMasters_ltrParagraph%>"></asp:Literal>
            </p>

            <p>
                <a class="btn btn-success btn-md" href="../../../../Reporting/Balance_Sheet/Supplier_Masters/FiscalPeriodDetailsForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrNew" Text="<%$ Resources:GlobalResource, ascxSupplierMasters_ltrFiscalPeriodDetails%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" href="../../../../Reporting/Balance_Sheet/Supplier_Masters/FiscalPeriodForm.aspx" role="button">

                    <asp:Literal runat="server" ID="ltrView" Text="<%$ Resources:GlobalResource, ascxSupplierMasters_ltrFiscalPeriod%>"></asp:Literal>
                </a>

            </p>
        </div>
    </div>
<div class="col-md-2"></div>
</div>
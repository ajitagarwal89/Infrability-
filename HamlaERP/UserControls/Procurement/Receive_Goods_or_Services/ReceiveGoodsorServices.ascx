<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReceiveGoodsorServices.ascx.cs" Inherits="UserControls_Procurement_Receive_Goods_or_Services_Receive_Goods_or_Services" %>

<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 startimg slideDown">
        <img src="../../../images/supplier.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideUp">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYour" Text="<%$ Resources:GlobalResource, ascxReceiveGoodsorServices_ltrAddYour%>"></asp:Literal>
            </div>
            <br />
            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, ascxReceiveGoodsorServices_ltrInformation%>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxReceiveGoodsorServices_ltrParagraph%>"></asp:Literal>
            </p>

            <p>
                <a class="btn btn-success btn-md"  style="width:250px"  href="../../../Procurement/Receive Goods or Services/Receive_Goods_or_Services/GoodsReceivedNoteDetailsForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrGoodReceivedNoteDetails" Text="<%$ Resources:GlobalResource, ltrGoodReceivedNoteDetails%>"></asp:Literal>
                </a>

                <a class="btn btn-success btn-md"  style="width:250px"  href="../../../Procurement/Receive Goods or Services/Receive_Goods_or_Services/GoodsReceivedNoteDistributionForm.aspx"  role="button">

                    <asp:Literal runat="server" ID="ltrGoodReceivedNoteDistribution" Text="<%$ Resources:GlobalResource, ltrGoodReceivedNoteDistribution%>"></asp:Literal>
                </a>

                 <a class="btn btn-success btn-md"  style="width:250px"     href="../../../Procurement/Receive Goods or Services/Receive_Goods_or_Services/GoodsReceivedNoteForm.aspx"  role="button">

                    <asp:Literal runat="server" ID="ltrGoodsReceivedNote" Text="<%$ Resources:GlobalResource, ltrGoodsReceivedNote%>"></asp:Literal>
                </a>

            </p>
        </div>
    </div>
<div class="col-md-2"></div>
</div>

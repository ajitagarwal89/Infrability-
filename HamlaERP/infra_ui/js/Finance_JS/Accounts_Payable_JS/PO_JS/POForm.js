function ClearForm() {
    document.getElementById('ddlOpt_opt_Type').selectedIndex = 0;
    document.getElementById('txtPONumber').value = '';
    document.getElementById('txtSupplier').value = '';
    document.getElementById('txtSupplierGuid').value = '';
    document.getElementById('txtUserId_Buyer').value = '';
    document.getElementById('txtUserId_BuyerGuid').value = '';
    document.getElementById('txtCurrency').value = '';
    document.getElementById('txtCurrencyGuid').value = '';
    document.getElementById('chkAllowSales').checked = false;
    document.getElementById('txtRequisitionDate').value = '';
    document.getElementById('txtPurchaseOrderDate').value = '';
    document.getElementById('txtLastEditDate').value = '';
    document.getElementById('txtLastPrintedDate').value = '';
    document.getElementById('txtContractExpirationDate').value = '';
    document.getElementById('txtDatePlacedOnHold').value = '';
    document.getElementById('txtDateHoldRemoved').value = '';
    document.getElementById('txtPlacedOnHoldBy').value = '';
    document.getElementById('txtPlacedOnHoldByGuid').value = '';
    document.getElementById('txtHoldRemovedBy').value = '';
    document.getElementById('txtHoldRemovedByGuid').value = '';
    document.getElementById('txtRemainingSubTotal').value = '';
    document.getElementById('txtSubTotal').value = '';
    document.getElementById('txtTradeDiscount').value = '';
    document.getElementById('txtFreight').value = '';
    document.getElementById('txtMiscellaneous').value = '';
    document.getElementById('txtTotal').value = '';
    document.getElementById('txtComments').value = '';
    document.getElementById('txtCommentsGuid').value = '';
    document.getElementById('txtVersion').value = '';
    document.getElementById('ddlopt_Status').selectedIndex = 0;

    return false;
}


function SetUserId_BuyerDetails(userId_Buyer, userId_BuyerGuid) {

    document.getElementById("txtUserId_Buyer").value = userId_Buyer;
    document.getElementById("txtUserId_BuyerGuid").value = userId_BuyerGuid;
}

function CallUserId_BuyerSearch() {
    document.getElementById("btnUserId_BuyerSearch").click();

}

function ClearUserId_BuyerSearch() {
    document.getElementById("btnClearUserId_BuyerSearch").click();
}

function CallUserId_BuyerRefreshButton() {
    document.getElementById("btnUserId_BuyerRefresh").click();
    document.getElementById("btnClearUserId_BuyerSearch").click();
}



function SetPlacedOnHoldByDetails(placedOnHoldBy, placedOnHoldByGuid) {

    document.getElementById("txtPlacedOnHoldBy").value = placedOnHoldBy;
    document.getElementById("txtPlacedOnHoldByGuid").value = placedOnHoldByGuid;
}

function CallPlacedOnHoldBySearch() {
    document.getElementById("btnPlacedOnHoldBySearch").click();

}

function ClearPlacedOnHoldBySearch() {
    document.getElementById("btnClearPlacedOnHoldBySearch").click();
}

function CallPlacedOnHoldByRefreshButton() {
    document.getElementById("btnPlacedOnHoldByRefresh").click();
    document.getElementById("btnClearPlacedOnHoldBySearch").click();
}




function SetHoldRemovedByDetails(holdRemovedBy, holdRemovedByGuid) {
  
    document.getElementById("txtHoldRemovedBy").value = holdRemovedBy;
    document.getElementById("txtHoldRemovedByGuid").value = holdRemovedByGuid;
}

function CallHoldRemovedBySearch() {
    document.getElementById("btnHoldRemovedBySearch").click();

}

function ClearHoldRemovedBySearch() {
    document.getElementById("btnClearHoldRemovedBySearch").click();
}

function CallHoldRemovedByRefreshButton() {
    document.getElementById("btnHoldRemovedByRefresh").click();
    document.getElementById("btnClearHoldRemovedBySearch").click();
}




function SetSupplierDetails(supplier, supplierGuid) {

    document.getElementById("txtSupplier").value = supplier;
    document.getElementById("txtSupplierGuid").value = supplierGuid;

}

function CallSupplierSearch() {
    document.getElementById("btnSupplierSearch").click();

}

function ClearSupplierSearch() {
    document.getElementById("btnClearSupplierSearch").click();
}

function CallSupplierRefreshButton() {
    document.getElementById("btnSupplierRefresh").click();
    document.getElementById("btnClearSupplierSearch").click();
}


function SetCurrencyDetails(currency, currencyGuid) {

    document.getElementById("txtCurrency").value = currency;
    document.getElementById("txtCurrencyGuid").value = currencyGuid;
}

function CallCurrencySearch() {
    document.getElementById("btnCurrencySearch").click();

}

function ClearCurrencySearch() {
    document.getElementById("btnClearCurrencySearch").click();
}

function CallCurrencyRefreshButton() {
    document.getElementById("btnCurrencyRefresh").click();
    document.getElementById("btnClearCurrencySearch").click();
}

function SetCommentsDetails(comments, commentsGuid) {

    document.getElementById("txtComments").value = comments;
    document.getElementById("txtCommentsGuid").value = commentsGuid;
}

function CallCommentsSearch() {
    document.getElementById("btnCommentsSearch").click();

}

function ClearCommentsSearch() {
    document.getElementById("btnClearCommentsSearch").click();
}

function CallCommentsRefreshButton() {
    document.getElementById("btnCommentsRefresh").click();
    document.getElementById("btnClearCommentsSearch").click();
}


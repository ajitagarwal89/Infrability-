function ClearForm() {

    document.getElementById('txtSupplierCode').value = '';
    document.getElementById('txtName').value = '';
    document.getElementById('txtShortName').value = '';
    document.getElementById('txtChequeName').value = '';
    document.getElementById('txtContact').value = '';
    document.getElementById('txtAddress').value = '';
    document.getElementById('txtCity').value = '';
    document.getElementById('txtCountry').value = '';
    document.getElementById('txtCountryGuid').value = '';
    document.getElementById('txtZipCode').value = '';
    document.getElementById('txtPhone').value = '';
    document.getElementById('txtMobile').value = '';
    document.getElementById('txtFaxNo').value = '';
    document.getElementById('txtEmail').value = '';
    document.getElementById('txtComment1').value = '';
    document.getElementById('txtComment2').value = '';
    document.getElementById('txtSupplierGroup').value = '';
    document.getElementById('txtSupplierGroupGuid').value = '';
    document.getElementById('txtGLAccountId_Cash').value = '';
    document.getElementById('txtAccountPayable').value = '';
    document.getElementById('txtPurchase').value = '';
    document.getElementById('txtTradeDiscount').value = '';
    document.getElementById('txtFreight').value = '';
    document.getElementById('txtAccruedPurchase').value = '';

    return false;
}

function SetCountryDetails(countryName, countryGuid) {
    document.getElementById("txtCountry").value = countryName;
    document.getElementById("txtCountryGuid").value = countryGuid;
}

function CallCountrySearch() {
    document.getElementById("btnCountrySearch").click();

}

function ClearCountrySearch() {
    document.getElementById("btnClearCountrySearch").click();
}

function CallRefreshButton() {
    document.getElementById("btnCountryRefresh").click();
    document.getElementById("btnClearCountrySearch").click();
}


function SetSupplierGroupDetails(supplierGroupName, supplierGroupGuid) {
    document.getElementById("txtSupplierGroup").value = supplierGroupName;
    document.getElementById("txtSupplierGroupGuid").value = supplierGroupGuid;
}

function CallSupplierGroupSearch() {
    document.getElementById("btnSupplierGroupSearch").click();

}

function ClearSupplierGroupSearch() {
    document.getElementById("btnClearSupplierGroupSearch").click();
}

function CallSupplierGroupRefreshButton() {
    document.getElementById("btnSupplierGroupRefresh").click();
    document.getElementById("btnClearSupplierGroupSearch").click();
}
function SetCashDetails(cash, cashGuid) {
    document.getElementById("txtGLAccountId_Cash").value = cash;
    document.getElementById("txtGLAccountId_CashGuid").value = cashGuid;
}

function CallCashSearch() {
    document.getElementById("btnAccountCashSearch").click();
}

function ClearCashSearch() {
    document.getElementById("btnClearAccountCashSearch").click();
}

function CallCashRefreshButton() {
    document.getElementById("btnAccountCashRefresh").click();
    document.getElementById("btnClearAccountCashSearch").click();
}


function SetAccountPayableDetails(accountPayable, accountPayableGuid) {
    document.getElementById("txtAccountPayable").value = accountPayable;
    document.getElementById("txtAccountPayableGuid").value = accountPayableGuid;
}

function CallAccountPayableSearch() {
    document.getElementById("btntAccountPayableSearch").click();

}

function ClearAccountPayableSearch() {
    document.getElementById("btnCleartAccountPayableSearch").click();
}

function CallAccountPayableRefreshButton() {

    document.getElementById("btnAccountPayableRefresh").click();
    document.getElementById("btnCleartAccountPayableSearch").click();
}


function SetPurchaseDetails(purchase, purchaseGuid) {
    document.getElementById("txtPurchase").value = purchase;
    document.getElementById("txtPurchaseGuid").value = purchaseGuid;
}

function CallPurchaseSearch() {
    document.getElementById("btnPurchaseSearch").click();

}

function ClearPurchaseSearch() {
    document.getElementById("btnClearPurchaseSearch").click();
}

function CallPurchaseRefreshButton() {
    document.getElementById("btnPurchaseRefresh").click();
    document.getElementById("btnClearPurchaseSearch").click();
}


function SetTradeDiscountDetails(tradeDiscount, tradeDiscountGuid) {
    document.getElementById("txtTradeDiscount").value = tradeDiscount;
    document.getElementById("txtTradeDiscountGuid").value = tradeDiscountGuid;
}

function CallEmplTradeDiscountSearch() {
    document.getElementById("btnTradeDiscountSearch").click();

}

function ClearTradeDiscountSearch() {
    document.getElementById("btnClearTradeDiscountSearch").click();
}

function CallTradeDiscountRefreshButton() {
    document.getElementById("btnTradeDiscountRefresh").click();
    document.getElementById("btnClearTradeDiscountSearch").click();
}



function SetFreightDetails(feight, freightGuid) {
    document.getElementById("txtFreight").value = feight;
    document.getElementById("txtFreightGuid").value = freightGuid;
}

function CallFreightSearch() {
    document.getElementById("btFreightSearch").click();

}

function ClearFreightSearch() {
    document.getElementById("btnClearFreightSearch").click();
}

function CallFreightRefreshButton() {
    document.getElementById("btnFreightRefresh").click();
    document.getElementById("btnClearFreightSearch").click();
}


function SetAccruedPurchaseDetails(accruedPurchase, accruedPurchaseguid) {
    document.getElementById("txtAccruedPurchase").value = accruedPurchase;
    document.getElementById("txtAccruedPurchaseguid").value = accruedPurchaseguid;
}

function CallAccruedPurchaseSearch() {
    document.getElementById("btnAccruedPurchaseSearch").click();

}

function ClearAccruedPurchaseSearch() {
    document.getElementById("btnClearAccruedPurchaseSearch").click();
}

function CallAccruedPurchaseRefreshButton() {
    document.getElementById("btnAccruedPurchaseRefresh").click();
    document.getElementById("btnClearAccruedPurchaseSearch").click();
}

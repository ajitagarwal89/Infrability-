function ClearForm() {

    document.getElementById('ddlopt_ReceiptType').value = selectedIndex = 0;
    document.getElementById('txtReceiptNumber').value = '';
    document.getElementById('txtBatch').value = '';
    document.getElementById('txtBatchGuid').value = '';
    document.getElementById('txtSupplier').value = '';
    document.getElementById('txtSupplierGuid').value = '';
    document.getElementById('txtSupplierDocumentNumber').value = '';
    document.getElementById('txtDate').value = '';
    document.getElementById('txtCurrency').value = '';
    document.getElementById('txtCurrencyGuid').value = '';
    document.getElementById('txtSubTotal').value = '';
    document.getElementById('txtTradeDiscount').value = '';
    document.getElementById('txtFrieght').value = '';
    document.getElementById('txtMiscellaneous').value = '';
    document.getElementById('txtMainTotal').value = '';   
    return false;
}


function SetBatchDetails(batch, batchGuid) {

    document.getElementById("txtBatch").value = batch;
    document.getElementById("txtBatchGuid").value = batchGuid;

}

function CallBatchSearch() {
    document.getElementById("btnBatchSearch").click();

}

function ClearBatchSearch() {
    document.getElementById("btnClearBatchSearch").click();
}

function CallBatchRefreshButton() {
    document.getElementById("btnBatchRefresh").click();
    document.getElementById("btnClearBatchSearch").click();
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




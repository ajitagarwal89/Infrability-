function ClearForm() {


    
    document.getElementById('txtBatch').value = '';
    document.getElementById('txtReceiptNumber').value = '';
    document.getElementById('txtInvoiceDate').value = '';
    document.getElementById('txtPostingDate').value = '';
    document.getElementById('txtSubTotalAmount').value = '';
    document.getElementById('txtSupplier').value = '';
    document.getElementById('txtCurrency').value = '';
    document.getElementById('txtTradeDiscountAmount').value = '';
    document.getElementById('txtFreightAmount').value = '';
    document.getElementById('txtTotalAmount').value = ''; 
    document.getElementById('txtPaymentTerms').value = '';
   
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


function SetPaymentTermsDetails(paymentterms, paymenttermsGuid) {

    alert("SetPaymentTermsDetails");
    document.getElementById("txtPaymentTerms").value = paymentterms;
    document.getElementById("txtPaymentTermsGuid").value = paymenttermsGuid;

}

function CallPaymentTermsSearch() {
    document.getElementById("btnPaymentTermsSearch").click();

}

function ClearPaymentTermsSearch() {
    document.getElementById("btnClearPaymentTermsSearch").click();
}

function CallPaymentTermsRefreshButton() {
    document.getElementById("btnPaymentTermsRefresh").click();
    document.getElementById("btnClearPaymentTermsSearch").click();
}

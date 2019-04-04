function ClearForm() {

    document.getElementById('txtPO').value = '';
    document.getElementById('txtGoodsReceivedNote').value = '';
    document.getElementById('txtBatch').value = '';
    document.getElementById('txtReceiptNumber').value = '';
    document.getElementById('txtInvoiceDate').value = '';
    
    document.getElementById('txtSubTotalAmount').value = '';
    document.getElementById('txtSupplier').value = '';
    document.getElementById('txtSupplierDocumentNumber').value = ''; 
    document.getElementById('txtCurrency').value = '';
    document.getElementById('txtTradeDiscountAmount').value = '';
    document.getElementById('txtFreightAmount').value = '';
    document.getElementById('txtMiscellaneous').value = '';
    document.getElementById('txtTotalAmount').value = '';    
    document.getElementById('txtPaymentTerms').value = '';
   
    return false;
}

function SetPODetails(poNumber, POGuid) {
   
    document.getElementById("txtPO").value = poNumber
    document.getElementById("txtPOGuid").value = POGuid;

}

function CallPOSearch() {
  
    document.getElementById("btnPOSearch").click();

}

function ClearPOSearch() {
    document.getElementById("btnClearPOSearch").click();
}

function CallPORefreshButton() {
  
    document.getElementById("btnPORefresh").click();
    document.getElementById("btnClearPOSearch").click();
}


function SetGoodsReceivedNoteDetails(goodsReceivedNoteNumber, goodsReceivedNoteGuid) {
   
    document.getElementById("txtGoodsReceivedNote").value = goodsReceivedNoteNumber;
    document.getElementById("txtGoodsReceivedNoteGuid").value = goodsReceivedNoteGuid;

}

function CallGoodsReceivedNoteSearch() {

    document.getElementById("btnGoodsReceivedNoteSearch").click();

}

function ClearGoodsReceivedNoteSearch() {
   
    document.getElementById("btnClearGoodsReceivedNoteSearch").click();
}

function CallGoodsReceivedNoteRefreshButton() {
    
    document.getElementById("btnGoodsReceivedNoteRefresh").click();
    document.getElementById("btnClearGoodsReceivedNoteSearch").click();
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

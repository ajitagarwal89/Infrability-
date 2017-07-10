function ClearForm() {
    document.getElementById("txtJournal").value = '';
    document.getElementById("txtBatch").value = '';    
    document.getElementById("chkTransactionType").checked = false;
    document.getElementById('txtTransactionDate').value = '';
    document.getElementById('txtSourceDocument').value = '';
    document.getElementById('txtCurrency').value = '';    
    document.getElementById('txtReference').value = '';
    return false;
}

function SetSource_DocumentDetails(sourceDocument, sourceDocumentGuid) {
    document.getElementById("txtSourceDocument").value = sourceDocument;
    document.getElementById("txtSourceDocumentGuid").value = sourceDocumentGuid;
}

function CallSource_DocumentSearch() {
    document.getElementById("btnSource_DocumentSearch").click();

}

function ClearSource_DocumentSearch() {
    document.getElementById("btnClearSource_DocumentSearch").click();
}

function CallSource_DocumentRefreshButton() {
    document.getElementById("btnSource_DocumentRefresh").click();
    document.getElementById("btnClearSource_DocumentSearch").click();
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
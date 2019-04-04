function ClearForm() {
    document.getElementById('txtPaymentNumber').value = '';
    document.getElementById('txtPaymentDate').value = '';
    document.getElementById('txtBatch').value = '';
    document.getElementById('txtBatchGuid').value = '';
    document.getElementById('txtSupplierEmployee').value = '';
    document.getElementById('txtSupplierEmployeeGuid').value = '';
    document.getElementById('txtCurrency').value = '';
    document.getElementById('txtCurrencyGuid').value = '';
    document.getElementById('txtPayablesBank').value = '';
    document.getElementById('txtPayablesBankGuid').value = '';
    document.getElementById('txtBankTransferAmount').value = '';
    document.getElementById('txtPayablesCash').value = '';
    document.getElementById('txtPayablesCashGuid').value = '';
    document.getElementById('txtCashAmount').value = '';
    document.getElementById('txtPayablesCheque').value = '';
    document.getElementById('txtPayablesChequeGuid').value = '';
    document.getElementById('txtChequeAmount').value = '';
    document.getElementById('txtPayablesCreditCard').value = '';
    document.getElementById('txtCreditCardAmount').value = '';
    document.getElementById('txtCreditCardAmount').value = '';
    document.getElementById('txtUnapplied').value = '';
    document.getElementById('txtApplied').value = '';
    document.getElementById('txtTotal').value = '';
    document.getElementById('chkIsAutoAppliyTo').checked = false;
    document.getElementById('chkIsPosted').checked = false;
    document.getElementById('txtApplied').value = '';
    document.getElementById('txtPostingDate').value = '';
    document.getElementById('txtSourceDocument').value = '';
    document.getElementById('txtSourceDocumentGuid').value = '';
    document.getElementById('ddlOpt_DocumentType').selectedIndex = 0;


    return false;
}

function SetBatchDetails(batchId, batchIdGuid) {
    document.getElementById("txtBatch").value = batchId;
    document.getElementById("txtBatchGuid").value = batchIdGuid;
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


function SetSupplierEmployeeDetails(employeeid, employeeGuid) {
    document.getElementById("txtSupplierEmployee").value = employeeid;
    document.getElementById("txtSupplierEmployeeGuid").value = employeeGuid;
}

function CallSupplierEmployeeSearch() {
    document.getElementById("btnSupplierEmployeeSearch").click();

}

function ClearSupplierEmployeeSearch() {
    document.getElementById("btnClearSupplierEmployeeSearch").click();
}

function CallSupplierEmployeeRefreshButton() {
    document.getElementById("btnSupplierEmployeeRefresh").click();
    document.getElementById("btnClearSupplierEmployeeSearch").click();
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


function SetPayablesBankDetails(payablesBank, payablesBankGuid) {
    document.getElementById("txtPayablesBank").value = payablesBank;
    document.getElementById("txtPayablesBankGuid").value = payablesBankGuid;

}

function CallPayablesBankSearch() {
    document.getElementById("btnPayablesBankSearch").click();

}

function ClearPayablesBankSearch() {
    document.getElementById("btnClearPayablesBankSearch").click();
}

function CallPayablesBankRefreshButton() {
    document.getElementById("btnPayablesBankRefresh").click();
    document.getElementById("btnClearPayablesBankSearch").click();
}


function SetPayablesCashDetails(paymentNumber, payablesId) {

    document.getElementById("txtPayablesCash").value = paymentNumber;
    document.getElementById("txtPayablesCashGuid").value = payablesId;

}

function CallPayablesCashSearch() {
    document.getElementById("btnPayablesCashSearch").click();

}

function ClearPayablesCashSearch() {
    document.getElementById("btnClearPayablesCashSearch").click();
}

function CallPayablesCashRefreshButton() {
    document.getElementById("btnPayablesCashRefresh").click();
    document.getElementById("btnClearPayablesCashSearch").click();
}


function SetPayablesChequeDetails(chequenumber, payablesChequeGuid) {
    document.getElementById("txtPayablesCheque").value = chequenumber;
    document.getElementById("txtPayablesChequeGuid").value = payablesChequeGuid;

}

function CallPayablesChequeSearch() {
    document.getElementById("btnPayablesChequeSearch").click();

}

function ClearPayablesChequeSearch() {
    document.getElementById("btnClearPayablesChequeSearch").click();
}

function CallPayablesChequeRefreshButton() {
    document.getElementById("btnPayablesChequeRefresh").click();
    document.getElementById("btnClearPayablesChequeSearch").click();
}


function SetPayablesCreditCardDetails(payablesCreditCard, payablesCreditCardGuid) {

    document.getElementById("txtPayablesCreditCard").value = payablesCreditCard;
    document.getElementById("txtPayablesCreditCardGuid").value = payablesCreditCardGuid;

}

function CallPayablesCreditCardSearch() {
    document.getElementById("btnPayablesCreditCardSearch").click();

}

function ClearPayablesCreditCardSearch() {
    document.getElementById("btnClearPayablesCreditCardSearch").click();
}

function CallPayablesCreditCardRefreshButton() {
    document.getElementById("btnPayablesCreditCardRefresh").click();
    document.getElementById("btnClearPayablesCreditCardSearch").click();
}



function SetSource_DocumentDetails(sourceDocument, sourceDocumentGuid) {

    document.getElementById("txtSourceDocument").value = sourceDocument;
    document.getElementById("txtSourceDocumentGuid").value = sourceDocumentGuid;

}
function CallSource_DocumentSearch() {
    document.getElementById("btnHtmlSource_DocumentSearch").click();

}

function ClearSource_DocumentSearch() {
    document.getElementById("btnClearSource_DocumentSearch").click();
}

function CallSource_DocumentRefreshButton() {
    document.getElementById("btnSource_DocumentRefresh").click();
    document.getElementById("btnClearSource_DocumentSearch").click();
}

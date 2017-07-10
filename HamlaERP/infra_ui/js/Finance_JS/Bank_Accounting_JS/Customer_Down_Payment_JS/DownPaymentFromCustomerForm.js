function ClearForm() {
    document.getElementById('txtReceiptNumber').value = '';
    document.getElementById('txtReceiptDate').value = '';
    document.getElementById('txtBatchId').value = '';
    document.getElementById('txtCustomer').value ='';
    document.getElementById('txtCurrency').value = '';
    document.getElementById('txtPayablesCash').value = '';
    document.getElementById('txtCashAmount').value = '';
    document.getElementById('txtPayablesCheque').value = '';
    document.getElementById('txtChequeAmount').value = '';
    document.getElementById('txtPayablesCreditCard').value = '';
    document.getElementById('txtCreditCardAmount').value = '';
    document.getElementById('txtDocumentNumber').value = '';
    document.getElementById('txtComments').value = '';
    document.getElementById('chckIsAutoApplyTo').checked = false;
    document.getElementById('chckIsPosted').checked = false;
    document.getElementById('txtPostingDate').value = '';
    document.getElementById('txtApplyDate').value = '';
    document.getElementById('txtSourceDocument').value = '';
    document.getElementById('ddlOpt_DocumentType').selectedIndex = 0;
    return false;
}

function SetBatchDetails(batchId, batchIdGuid) {
    document.getElementById("txtBatchId").value = batchId;
    document.getElementById("txtBatchIdGuid").value = batchIdGuid;
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

function SetCustomerDetails(customer, customerGuid) {

    document.getElementById("txtCustomer").value = customer;
    document.getElementById("txtCustomerGuid").value = customerGuid;
}

function CallCustomerSearch() {
    document.getElementById("btnHtmlCustomerSearch").click();

}

function ClearCustomerSearch() {
    document.getElementById("btnClearCustomerSearch").click();
}

function CallCustomerRefreshButton() {
    document.getElementById("btnCustomerRefresh").click();
    document.getElementById("btnClearCustomerSearch").click();
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

function SetSourceDocumentDetails(documentNumber, description) {
    document.getElementById("txtSourceDocument").value = documentNumber;
    document.getElementById("txtSourceDocumentGuid").value = description;
}

function CallSourceDocumentSearch() {
    document.getElementById("btnSourceDocumentSearch").click();

}

function ClearSourceDocumentSearch() {
    document.getElementById("btnClearSourceDocumentSearch").click();
}

function CallSourceDocumentRefreshButton() {
    document.getElementById("btnSourceDocumentRefresh").click();
    document.getElementById("btnClearSourceDocumentSearch").click();
}

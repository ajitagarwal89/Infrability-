function ClearForm() {
    document.getElementById('txtDownPaymentcust').value = '';
    document.getElementById('txtDownPaymentcustGuid').value = '';
    document.getElementById('rdbtnCustomerInvoice').checked = false;
    document.getElementById('RdbtnCustomerInvoiceProcess').checked = false;
    document.getElementById('txtApplyToDocument').value = '';
    document.getElementById('txtApplyToDocumentGuid').value = '';
    document.getElementById('txtApplyotDocumentCIP').value = '';
    document.getElementById('txtApplyotDocumentCIPGuid').value = '';
    document.getElementById('txtDueDate').value = '';
    document.getElementById('txtRemainingAmount').value = '';
    document.getElementById('txtApplyAmount').value = '';
    document.getElementById('ddloptType').selectedIndex = 0;
    document.getElementById('txtOrignalDocumentAmount').value = '';
    document.getElementById('txtDiscountDate').value = '';
    document.getElementById('txtCurrency').value = '';
    document.getElementById('txtCurrencyGuid').value = '';
    return false;
}

function ClearFormAppy() {
    document.getElementById('txtCustomerID').value = '';
    document.getElementById('txtCustomerName').value = '';
    document.getElementById('txtType').value = '';
    document.getElementById('txtCurrencyID').value = '';
    document.getElementById('txtDocumentNumber').value = '';
    document.getElementById('txtOrignalDocumentAmount').value = '';
    document.getElementById('txtApplydate').value = '';
    document.getElementById('txtUnappliedAmount').value = '';
    return false;
}

function SetDownPaymentCustDetails(receiptNumber, cashAmount) {

    document.getElementById("txtDownPaymentcust").value = receiptNumber;
    document.getElementById("txtDownPaymentcustGuid").value = cashAmount;

    document.getElementById("txtDownPaymentcust").onchange();
    document.getElementById("txtDownPaymentcustGuid").onchange();

    document.getElementById("txtDownPaymentcust").value = receiptNumber;
    document.getElementById("txtDownPaymentcustGuid").value = cashAmount;

}

function CallDownPaymentCustSearch() {
    document.getElementById("btnDownPaymentCustSearch").click();

}

function ClearDownPaymentCustSearch() {
    document.getElementById("btnClearDownPaymentCustSearch").click();
}

function CallDownPaymentCustRefreshButton() {
    document.getElementById("btnDownPaymentCustRefresh").click();
    document.getElementById("btnClearDownPaymentCustSearch").click();
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


function SetCustomerInvoiceDetails(documentNumber, applytoDocumentGuid) {
    document.getElementById("txtApplyToDocument").value = documentNumber;
    document.getElementById("txtApplyToDocumentGuid").value = applytoDocumentGuid;

}

function CallCustomerInvoiceSearch() {
    document.getElementById("btnCustomerInvoiceSearch").click();

}

function ClearCustomerInvoiceSearch() {
    document.getElementById("btnClearCustomerInvoiceSearch").click();
}

function CallCustomerInvoiceRefreshButton() {
    document.getElementById("btnCustomerInvoiceRefresh").click();
    document.getElementById("btnClearCustomerInvoiceSearch").click();
}


function SetCustomerInvoiceProcessDetails(documentNumber, applytoDocumentGuid) {
    document.getElementById("txtApplyotDocumentCIP").value = documentNumber;
    document.getElementById("txtApplyotDocumentCIPGuid").value = applytoDocumentGuid;

}

function CallCustomerInvoiceProcessSearch() {
    document.getElementById("btnCustomerInvoiceProcessSearch").click();

}

function ClearCustomerInvoiceProcessSearch() {
    document.getElementById("btnClearCustomerInvoiceProcessSearch").click();
}

function CallCustomerInvoiceProcessRefreshButton() {
    document.getElementById("btnCustomerInvoiceProcessRefresh").click();
    document.getElementById("btnClearCustomerInvoiceProcessSearch").click();
}

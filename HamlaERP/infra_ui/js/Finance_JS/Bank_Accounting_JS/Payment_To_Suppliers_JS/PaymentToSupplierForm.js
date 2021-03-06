﻿function ClearForm() {
    document.getElementById('txtPaymentNumber').value = '';
    document.getElementById('txtPaymentDate').value = '';
    document.getElementById('txtBatchId').value = '';
    document.getElementById('txtSupplierId').value = '';
    document.getElementById('txtCurrency').value = '';
    document.getElementById('txtPayablesBank').value = '';
    document.getElementById('txtBankTransferAmount').value = '';
    document.getElementById('txtPayablesCash').value = '';
    document.getElementById('txtCashAmount').value = '';
    document.getElementById('txtPayablesCheque').value = '';
    document.getElementById('txtChequeAmount').value = '';
    document.getElementById('txtPayablesCreditCard').value = '';
    document.getElementById('txtCreditCardAmount').value = '';
    document.getElementById('txtUnapplied').value = '';
    document.getElementById('txtApplied').value = '';
    document.getElementById('txtTotal').value = '';
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


function SetSupplierDetails(supplierId, supplierGuid) {
        document.getElementById("txtSupplierId").value = supplierId;
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

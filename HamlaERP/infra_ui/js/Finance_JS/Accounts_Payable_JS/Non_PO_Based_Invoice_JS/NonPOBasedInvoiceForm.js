function ClearForm() {
    
    document.getElementById('txtVoucherNumber').value = '';
    document.getElementById('chkInterCompany').checked = false;
    document.getElementById('txtBatch').value ='';
    document.getElementById('ddlOpt_DocumentType').selectedIndex = 0;
    document.getElementById('txtDocumentDate').value = '';
    document.getElementById('txtDescription').value = '';
    document.getElementById('txtPostingDate').value = '';
    document.getElementById('txtInvoiceDate').value = '';
    document.getElementById('txtReceivedDate').value = '';
    document.getElementById('txtSupplier').value = '';
    document.getElementById('txtCurrency').value = '';
    document.getElementById('txtDocumentNumber').value = '';
    document.getElementById('txtPONumber').value = '';
    document.getElementById('txtPaymentTerms').value ='';
    document.getElementById('txtPurchase').value ='';
    document.getElementById('txtTradeDiscount').value ='';
    document.getElementById('txtFreight').value = '';
    document.getElementById('txtTotal').value = '';
    document.getElementById('ddlOpt_PayablesType').selectedIndex = 0;
    document.getElementById('txtPayablesBank').value = '';
    document.getElementById('txtBankTransferAmount').value ='';
    document.getElementById('txtPayablesCash').value ='';
    document.getElementById('txtCashAmount').value ='';
    document.getElementById('txtPayablesCheque').value ='';
    document.getElementById('txtChequeAmount').value ='';
    document.getElementById('txtPayablesCreditCard').value ='';
    document.getElementById('txtCreditCardAmount').value ='';
    document.getElementById('txtOnAccount').value ='';
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


function SetPayablesBankDetails(payablesBank, payablesBankGuid)
{

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


function SetPayablesCashDetails(payablesType, payablesId) {

    document.getElementById("txtPayablesCash").value = payablesType;
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


function SetPayablesChequeDetails(payablesType, payablesChequeGuid) {
    document.getElementById("txtPayablesCheque").value = payablesType;
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
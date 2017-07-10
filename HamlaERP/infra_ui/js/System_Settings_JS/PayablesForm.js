function ClearForm() {
    document.getElementById("ddlOpt_PayablesType").selectedIndex = 0;
    document.getElementById("ddlOpt_ProcessType").selectedIndex = 0;
    document.getElementById('txtBank').value = '';
    document.getElementById('txtBankGuid').value = '';
    document.getElementById('txtCreditCard').value = '';
    document.getElementById('txtCreditCardGuid').value = '';
    document.getElementById('txtDocumentNumber').value = '';
    document.getElementById('txtReceiptNumber').value = '';
    document.getElementById('txtChequeNumber').value = '';
    document.getElementById('txtPayablesDate').value = '';
    document.getElementById('txtPaymentNumber').value = '';
    return false;
}


function SetBankDetails(bank, bankGuid) {

    document.getElementById("txtBank").value = bank;
    document.getElementById("txtBankGuid").value = bankGuid;

}

function CallBankSearch() {
    document.getElementById("btnBankSearch").click();

}

function ClearBankSearch() {
    document.getElementById("btnClearBankSearch").click();
}

function CallBankRefreshButton() {
    document.getElementById("btnBankRefresh").click();
    document.getElementById("btnClearBankSearch").click();
}


function SetCreditCardDetails(creditCard, creditCardGuid) {

    document.getElementById("txtCreditCard").value = creditCard;
    document.getElementById("txtCreditCardGuid").value = creditCardGuid;
}

function CallCreditCardSearch() {
    document.getElementById("btnCreditCardSearch").click();

}

function ClearCreditCardSearch() {
    document.getElementById("btnClearCreditCardSearch").click();
}

function CallCreditCardRefreshButton() {
    document.getElementById("btnCreditCardRefresh").click();
    document.getElementById("btnClearCreditCardSearch").click();
}
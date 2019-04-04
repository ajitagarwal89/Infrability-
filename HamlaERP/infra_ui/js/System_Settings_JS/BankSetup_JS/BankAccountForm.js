function ClearForm() {
    document.getElementById('txtBankAccountId').value = '';
    document.getElementById('txtDescription').value = '';
    document.getElementById('ChckIsInactive').checked = false;
    document.getElementById('txtIban').value = '';
    document.getElementById('txtCurrency').value = '';
    document.getElementById('txtChequebookBal').value = '';
    document.getElementById('txtCashAccountBal').value = '';
    document.getElementById('txtGLAccount').value = '';
    document.getElementById('txtNextChckNmbr').value = '';
    document.getElementById('txtNextDepositNumber').value = '';
    document.getElementById('txtlastRecounciledBal').value = '';
    document.getElementById('txtLastRecounciledDate').value = '';
    document.getElementById('txtAccountNumber').value = '';
    document.getElementById('txtBank').value = '';
    document.getElementById('txtDuplicateChequeNumber').value = '';
    document.getElementById('txtOverrideChequeNmbr').value = '';
    return false;
}

function SetGLAccountDetails(glaccount, glaccountGuid) {
    document.getElementById("txtGLAccount").value = glaccount;
    document.getElementById("txtGLAccountGuid").value = glaccountGuid;
}

function CallGLAccountSearch() {
    document.getElementById("btnGLAccountSearch").click();

}

function ClearGLAccountSearch() {
    document.getElementById("btnClearGLAccountSearch").click();
}

function CallGLAccountRefreshButton() {
    document.getElementById("btnGLAccountRefresh").click();
    document.getElementById("btnClearGLAccountSearch").click();
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
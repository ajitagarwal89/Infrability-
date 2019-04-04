function ClearForm() {
    document.getElementById('txtPettyCashId').value = '';   
    document.getElementById('txtDescription').value = '';
    document.getElementById('chckIsInactive').checked = false;
    document.getElementById('txtIBAN').value = '';
    document.getElementById('txtCurrency').value = '';
    document.getElementById('txtCurrencyGuid').value = '';
    document.getElementById('txtCurrentPettyCashBal').value = '';
    document.getElementById('txtCashAccountBal').value = '';
    document.getElementById('txtGLAccount').value = '';
    document.getElementById('txtGLAccountGuid').value = '';
    document.getElementById('txtNextPettyCashNumber').value = '';
    document.getElementById('txtNextDepositNumber').value = '';
    document.getElementById('txtAccountNumber').value = '';
    document.getElementById('txtDuplicateChequeuNo').value = '';
    document.getElementById('txtOverrideChequeNumber').value = '';
    return false;
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

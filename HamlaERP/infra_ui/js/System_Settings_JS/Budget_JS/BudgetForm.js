function ClearForm() {
    document.getElementById('txtBudgetNumber').value = '';
    document.getElementById('txtDescription').value = '';
    document.getElementById('txtGLAccount').value = '';
    document.getElementById('chkAnnual').checked = false;
    document.getElementById('ChkDisplay').checked = false;
    return false;
}
function SetGLAccountDetails(accountNumber, gLAccountGuid) {

    document.getElementById("txtGLAccount").value = accountNumber;
    document.getElementById("txtGLAccountGuid").value = gLAccountGuid;

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
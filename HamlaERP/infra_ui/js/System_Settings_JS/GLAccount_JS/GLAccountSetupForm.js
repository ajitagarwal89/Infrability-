function ClearForm() {
    document.getElementById('chkDisplay').checked = false;
    document.getElementById('txtGLAccountId_Account').value = '';
    document.getElementById('txtGLAccountId_AccountGuid').value = '';
    document.getElementById('chkAccounts').checked = false;
    document.getElementById('chkTransactions').checked = false;
    document.getElementById('chkPostingToHistory').checked = false;
    document.getElementById('chkDeletionOfSavedTransactions').checked = false;   

    return false;
}
//GLAccountId_Cash

function SetGLAccountId_AccountDetails(GLAccountId_Account, GLAccountId_AccountGuid) {
  
    document.getElementById("txtGLAccountId_Account").value = GLAccountId_Account;
    document.getElementById("txtGLAccountId_AccountGuid").value = GLAccountId_AccountGuid;

}

function CallGLAccountId_AccountSearch() {

    document.getElementById("btnGLAccountId_AccountSearch").click();

}

function ClearGLAccountId_AccountSearch() {

    document.getElementById("btnClearGLAccountId_AccountSearch").click();
}

function CallGLAccountId_AccountRefreshButton() {

    document.getElementById("btnGLAccountId_AccountRefresh").click();
    document.getElementById("btnClearGLAccountId_AccountSearch").click();
}
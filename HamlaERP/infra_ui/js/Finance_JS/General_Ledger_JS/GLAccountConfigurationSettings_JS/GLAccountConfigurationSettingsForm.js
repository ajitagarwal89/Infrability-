function ClearForm() {
    document.getElementById('txtGLAccountRetainedEarning').value = '';
    document.getElementById('txtGLAccountRetainedEarningGuid').value = '';
    document.getElementById('chkPostingToHistory').checked = false;
    document.getElementById('chkDeletionOfSavedTransaction').checked = false;

    return false;
}

function SetGLAccountRetainedEarningDetails(glaccount, glaccountGuid) {
    document.getElementById("txtGLAccountRetainedEarning").value = glaccount;
    document.getElementById("txtGLAccountRetainedEarningGuid").value = glaccountGuid;
}

function CallGLAccountRetainedEarningSearch() {
    document.getElementById("btnGLAccountRetainedEarningSearch").click();

}

function ClearGLAccountRetainedEarningSearch() {
    document.getElementById("btnClearGLAccountRetainedEarningSearch").click();
}

function CallGLAccountIdRetainedEarningRefreshButton() {
    document.getElementById("btnGLAccountRetainedEarningRefresh").click();
    document.getElementById("btnClearGLAccountRetainedEarningSearch").click();
}

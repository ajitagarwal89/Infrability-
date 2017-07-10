function ClearForm() {
    document.getElementById("txtGLAccountEntry").value = '';
    document.getElementById("txtGLAccountEntryGuid").value = '';
    document.getElementById("txtGLAccount").value = '';
    document.getElementById('txtGLAccountGuid').value = ''; 
    document.getElementById('txtDebit').value = '';
    document.getElementById('txtCredit').value = '';
    return false;
}


function SetGLAccountEntryDetails(gLAccountEntry, gLAccountGuid) {
   
    document.getElementById("txtGLAccountEntry").value = gLAccountEntry;
    document.getElementById("txtGLAccountEntryGuid").value = gLAccountGuid;
    
}

function CallGLAccountEntrySearch() {
    document.getElementById("btnGLAccountEntrySearch").click();

}

function ClearGLAccountEntrySearch() {
    document.getElementById("btnClearGLAccountEntrySearch").click();
}

function CallGLAccountEntryRefreshButton() {
    document.getElementById("btnGLAccountEntryRefresh").click();
    document.getElementById("btnClearGLAccountEntrySearch").click();
}

function SetGLAccountDetails(glaccount, glaccountGuid) {
    alert(glaccountGuid + " / " + glaccount);
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


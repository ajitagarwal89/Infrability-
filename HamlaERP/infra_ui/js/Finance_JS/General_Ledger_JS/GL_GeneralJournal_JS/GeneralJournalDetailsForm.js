function ClearForm() {
    document.getElementById("txtGeneralJournal").value = '';
    document.getElementById("txtGeneralJournalGuid").value = '';
    document.getElementById("txtGLAccount").value = '';
    document.getElementById('txtGLAccountGuid').value = ''; 
    document.getElementById('txtDebit').value = '';
    document.getElementById('txtCredit').value = '';
    return false;
}


function SetGeneralJournalDetails(generalJournal, gLAccountGuid) {
   
    document.getElementById("txtGeneralJournal").value = generalJournal;
    document.getElementById("txtGeneralJournalGuid").value = gLAccountGuid;
    
}

function CallGeneralJournalSearch() {
    document.getElementById("btnGeneralJournalSearch").click();

}

function ClearGeneralJournalSearch() {
    document.getElementById("btnClearGeneralJournalSearch").click();
}

function CallGeneralJournalRefreshButton() {
    document.getElementById("btnGeneralJournalRefresh").click();
    document.getElementById("btnClearGeneralJournalSearch").click();
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


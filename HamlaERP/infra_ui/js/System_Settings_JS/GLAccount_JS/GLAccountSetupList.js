
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(display, gLAccountId_Account, accounts, transactions, postingToHistory, deletionOfSavedTransactions, lblGvRowId) {
    document.getElementById("lblDisplay").innerHTML = display;
    document.getElementById("lblGLAccountId_Account").innerHTML = gLAccountId_Account;
    document.getElementById("lblAccounts").innerHTML = accounts;
    document.getElementById("lblTransactions").innerHTML = transactions;
    document.getElementById("lblPostingToHistory").innerHTML = postingToHistory;
    document.getElementById("lbllDeletionOfSavedTransactions").innerHTML = deletionOfSavedTransactions;
    
    document.getElementById("lblGvRowId").innerHTML = lblGvRowId;
    var maxrows = document.getElementById('gvData').rows.length - 1;
    var num = document.getElementById('lblGvRowId').innerHTML.split('_');
    if (num[1] == maxrows) {
        document.getElementById('next').class = 'btn btn-default disabled';
    }
    else {
        document.getElementById('next').class = 'btn btn-default';
    }
    if (num[1] == 1) {
        document.getElementById('prev').class = 'btn btn-default disabled';
    }
    else {
        document.getElementById('prev').class = 'btn btn-default';
    }
}

function showNextRecord() {
    var id = document.getElementById('lblGvRowId').innerHTML.split('_');
    var lnk = parseInt(id[1]) + 1;
    document.getElementById('lnkViewNextPrev_' + lnk).click();
}

function showPrevRecord() {
    var id = document.getElementById('lblGvRowId').innerHTML.split('_');
    var lnk = parseInt(id[1]) - 1;
    document.getElementById('lnkViewNextPrev_' + lnk).click();
}

function CallMainSearch() {
    document.getElementById("btnMainSearch").click();
}

function ClearMainSearch() {
    document.getElementById("btnClearMainSearch").click();
}
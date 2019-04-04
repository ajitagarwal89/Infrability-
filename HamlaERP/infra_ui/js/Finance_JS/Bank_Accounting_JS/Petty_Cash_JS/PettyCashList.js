$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function SetDetails(pettyCashId, description, iBAN, currencyName, currentPettyCashBalance, cashAccountBalance, gLAccountId, nextPettyCashNumber, nextDepositNumber, accountNumber, duplicateChequeNumber, overrideChequeNumber, lblGvRowId) {

    document.getElementById("lblPettyCashId").innerHTML = pettyCashId;
    document.getElementById("lblDescription").innerHTML = description;
    document.getElementById("lblIBAN").innerHTML = iBAN;
    document.getElementById("lblCurrency").innerHTML = currencyName;
    document.getElementById("lblCurrenctPrettyCashBal").innerHTML = currentPettyCashBalance;
    document.getElementById("lblCashAccountBal").innerHTML = cashAccountBalance;
    document.getElementById("lblGLAccount").innerHTML = gLAccountId;
    document.getElementById("lblNextPettyCashNumber").innerHTML = nextPettyCashNumber;
    document.getElementById("lblNextDepositNumber").innerHTML = nextDepositNumber;
    document.getElementById("lblAccountNumber").innerHTML = accountNumber;
    document.getElementById("lblDuplicateChequeNumber").innerHTML = duplicateChequeNumber;
    document.getElementById("lblOverrideChequeNumber").innerHTML = overrideChequeNumber;

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
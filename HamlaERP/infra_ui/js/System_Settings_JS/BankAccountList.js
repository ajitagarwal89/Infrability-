$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(bankAccountId, description, iBan, currencyName, currentChequeBookBalance, cashAccountBalance, gLAccount, nextChequeNumber, nextDepositNumber, lastrecounciledBalance, accountNumber, bankName, duplicateChequeNumber, overrideChequeNumber, lblGvRowId) {

    document.getElementById("lblBankAccountId").innerHTML = bankAccountId;
    document.getElementById("lblDescription").innerHTML = description;
    document.getElementById("lblIBAN").innerHTML = iBan;
    document.getElementById("lblCurrency").innerHTML = currencyName;
    document.getElementById("lblCurrentChequeBal").innerHTML = currentChequeBookBalance;
    document.getElementById("lblCashAccountBal").innerHTML = cashAccountBalance;
    document.getElementById("lblGLAccount").innerHTML = gLAccount;
    document.getElementById("lblNextChequeNum").innerHTML = nextChequeNumber;
    document.getElementById("lblNextDepositNum").innerHTML = nextDepositNumber;
    document.getElementById("lblLastRecounciledBal").innerHTML = lastrecounciledBalance;
    document.getElementById("lblAccountNumber").innerHTML = accountNumber;
    document.getElementById("lblbank").innerHTML = bankName;
    document.getElementById("lblDuplicateChequeNumber").innerHTML = duplicateChequeNumber;
    document.getElementById("lblOverrideCheque").innerHTML = overrideChequeNumber;
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
    //alert(id);
    document.getElementById('lnkViewNextPrev_' + lnk).click();
}

function showPrevRecord() {
    var id = document.getElementById('lblGvRowId').innerHTML.split('_');
    var lnk = parseInt(id[1]) - 1;
    //alert(id)
    document.getElementById('lnkViewNextPrev_' + lnk).click();
}

function CallMainSearch() {
    document.getElementById("btnMainSearch").click();
}

function ClearMainSearch() {
    document.getElementById("btnClearMainSearch").click();
}
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(paymentNumber, batchName, employeeName, currencyName, bankTransferAmount, cashAmount, chequeAmount, creditCardAmount, unapplied, applied, total, lblGvRowId) {


    document.getElementById("lblPaymentNumber").innerHTML = paymentNumber;
    document.getElementById("lblBatchName").innerHTML = batchName;
    document.getElementById("lblEmployeeName").innerHTML = supplierName;
    document.getElementById("lblCurrencyName").innerHTML = currencyName;
    document.getElementById("lblBankTransferAmount").innerHTML = bankTransferAmount;
    document.getElementById("lblCashAmount").innerHTML = cashAmount;
    document.getElementById("lblChequeAmount").innerHTML = chequeAmount;
    document.getElementById("lblCreditCardAmount").innerHTML = creditCardAmount;
    document.getElementById("lblUnapplied").innerHTML = unapplied;
    document.getElementById("lblApplied").innerHTML = applied;
    document.getElementById("lblTotal").innerHTML = total;
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

$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(voucherNumber, batchName, documentType, employeeName, currencyName, expenses, bankTransferAmount, Cash, cheque, creditCard, onAccount, lblGvRowId) {

    document.getElementById("lblVoucherNumber").innerHTML = voucherNumber;
    document.getElementById("lblBatchId").innerHTML = batchName;
    document.getElementById("lblDocumentType").innerHTML = documentType;
    document.getElementById("lblEmployeeId").innerHTML = employeeName;
    document.getElementById("lblCurrencyId").innerHTML = currencyName;
    document.getElementById("lblExpenses").innerHTML = expenses;
    document.getElementById("lblBankTransferAmount").innerHTML = bankTransferAmount;
    document.getElementById("lblCash").innerHTML = Cash;
    document.getElementById("lblCheque").innerHTML = cheque;
    document.getElementById("lblCreditCard").innerHTML = creditCard;
    document.getElementById("lblOnAccount").innerHTML = onAccount;
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
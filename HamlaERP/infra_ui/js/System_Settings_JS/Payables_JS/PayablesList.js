
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(payablesType, processType, bankAccount, card, documentNumber, receiptNumber, chequeNumber, payablesDate, paymentNumber, lblGvRowId) {
    document.getElementById("lblPayablesType").innerHTML = payablesType;
    document.getElementById("lblProcessType").innerHTML = processType;
    document.getElementById("lblBankAccount").innerHTML = bankAccount;
    document.getElementById("lblCard").innerHTML = card;
    document.getElementById("lblDocumentNumber").innerHTML = documentNumber;
    document.getElementById("lblReceiptNumber").innerHTML = receiptNumber;
    document.getElementById("lblChequeNumber").innerHTML = chequeNumber;
    document.getElementById("lblPayablesDate").innerHTML = payablesDate;
    document.getElementById("lblPaymentNumber").innerHTML = paymentNumber;
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
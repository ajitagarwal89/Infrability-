$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(receiptNumber, batchId, customerName, currencyId, payablesCash, cashAmount, payablesCheque, chequeAmount, payablesCreditCard, creditCardAmount, documentNumber, comments, lblGvRowId) {

    document.getElementById("lblReceiptNumber").innerHTML = receiptNumber;
    document.getElementById("lblBatchId").innerHTML = batchId;
    document.getElementById("lblCustomer").innerHTML = customerName;
    document.getElementById("lblCurrencyId").innerHTML = currencyId;
    document.getElementById("lblPayablesCash").innerHTML = payablesCash;
    document.getElementById("lblCashAmount").innerHTML = cashAmount;
    document.getElementById("lblPayablesCheque").innerHTML = payablesCheque;
    document.getElementById("lblChequeAmount").innerHTML = chequeAmount;
    document.getElementById("lblPayablesCreditCard").innerHTML = payablesCreditCard;
    document.getElementById("lblCreditCardAmount").innerHTML = creditCardAmount;
    document.getElementById("lblDocumentNumber").innerHTML = documentNumber;
    document.getElementById("lblComments").innerHTML = comments;
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

$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(description,tradeDiscount,minimumPayment,maximumInvoiceAmount,creditLimit,writeOff,currencyName,paymentTermsName, lblGvRowId) {

    
    document.getElementById("lblDescription").innerHTML = description;
    document.getElementById("lblTradeDiscount").innerHTML = tradeDiscount;
    document.getElementById("lblMinimumPayment").innerHTML = minimumPayment;
    document.getElementById("lblMaximumInvoiceAmount").innerHTML = maximumInvoiceAmount;
    document.getElementById("lblCreditLimit").innerHTML = creditLimit;
    document.getElementById("lblWriteOff").innerHTML = writeOff;
    document.getElementById("lblCurrencyName").innerHTML = currencyName;
    document.getElementById("lblPaymentTermsName").innerHTML = paymentTermsName;
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

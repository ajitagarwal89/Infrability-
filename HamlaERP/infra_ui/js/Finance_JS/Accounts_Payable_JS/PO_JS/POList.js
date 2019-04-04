
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(pONumber, date, purchaseOrderDate, lastEditDate, lastPrintedDate, contractExpirationDate, status, version, currencyName, remainingSubTotal, subTotal, tradeDiscount, freight, miscellaneous,total, lblGvRowId) {


    document.getElementById("lblPONumber").innerHTML = pONumber;
    document.getElementById("lblDate").innerHTML = date;
    document.getElementById("lblPurchaseOrderDate").innerHTML = purchaseOrderDate;
    document.getElementById("lblLastEditDate").innerHTML = lastEditDate;
    document.getElementById("lblLastPrintedDate").innerHTML = lastPrintedDate;
    document.getElementById("lblContractExpirationDate").innerHTML = contractExpirationDate;
    document.getElementById("lblStatus").innerHTML = status;
    document.getElementById("lblVersion").innerHTML = version;
    document.getElementById("lblCurrencyName").innerHTML = currencyName;
    document.getElementById("lblRemainingSubTotal").innerHTML = remainingSubTotal;
    document.getElementById("lblSubTotal").innerHTML = subTotal;
    document.getElementById("lblTradeDiscount").innerHTML = tradeDiscount;
    document.getElementById("lblFreight").innerHTML = freight;
    document.getElementById("lblMiscellaneous").innerHTML = miscellaneous;
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

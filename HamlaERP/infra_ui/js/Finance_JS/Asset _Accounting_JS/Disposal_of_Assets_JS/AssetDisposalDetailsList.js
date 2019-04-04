
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(assetDisposalCode,quantity,cost,percent,cashProceeds,nonCashProceeds,expensesOfSales,originatingAmount, lblGvRowId) {
    document.getElementById("lblAssetDisposalCode").innerHTML = assetDisposalCode;
    document.getElementById("lblQuantity").innerHTML = quantity;
    document.getElementById("lblCost").innerHTML = cost;
    document.getElementById("lblPercent").innerHTML = percent;
    document.getElementById("lblCashProceeds").innerHTML = cashProceeds;
    document.getElementById("lblNonCashProceeds").innerHTML = nonCashProceeds;
    document.getElementById("lblExpensesOfSales").innerHTML = expensesOfSales;
    document.getElementById("lblOriginatingAmount").innerHTML = originatingAmount;
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
    //;
    document.getElementById('lnkViewNextPrev_' + lnk).click();
}

function showPrevRecord() {
    var id = document.getElementById('lblGvRowId').innerHTML.split('_');
    var lnk = parseInt(id[1]) - 1;
    //
    document.getElementById('lnkViewNextPrev_' + lnk).click();
}
function CallMainSearch() {
    //
    document.getElementById("btnMainSearch").click();
}

function ClearMainSearch() {
    //
    document.getElementById("btnClearMainSearch").click();
}
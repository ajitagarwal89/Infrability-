
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function SetDetails(employeeGroupId, accountType, cash, accountPayable, purchase, tradeDiscount, freight, accruedPurchase, lblGvRowId) {
   
    document.getElementById("lblEmployeeGroupId").innerHTML = employeeGroupId;
    document.getElementById("lblAccountType").innerHTML = accountType;
    document.getElementById("lblCash").innerHTML = cash;
    document.getElementById("lblAccountPayable").innerHTML = accountPayable;
    document.getElementById("lblPurchase").innerHTML = purchase;
    document.getElementById("lblTradeDiscount").innerHTML = tradeDiscount;
    document.getElementById("lblFreight").innerHTML = freight;
    document.getElementById("lblAccruedPurchase").innerHTML = accruedPurchase;
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
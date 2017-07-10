
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function SetDetails(customerGroupID, accountType, chequeBook, cash, accountReceivable, sales, costOfSales, inventory, accuralDifferedA_C, lblGvRowId) {
       document.getElementById("lblCustomerGroupID").innerHTML = customerGroupID;
    document.getElementById("lblAccountType").innerHTML = accountType;
    document.getElementById("lblChequeBook").innerHTML = chequeBook;
    document.getElementById("lblCash").innerHTML = cash;
    document.getElementById("lblAccountReceivable").innerHTML = accountReceivable;
    document.getElementById("lblSales").innerHTML = sales;
    document.getElementById("lblCostOfSales").innerHTML = costOfSales;
    document.getElementById("lblInventory").innerHTML = inventory;
    document.getElementById("lblAccuralDifferedA_C").innerHTML = accuralDifferedA_C;
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
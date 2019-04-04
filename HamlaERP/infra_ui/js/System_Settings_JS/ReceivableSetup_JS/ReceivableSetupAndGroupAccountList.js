
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(ReceivableSetupGroup, Description, ChequeBookName, Cash, AccountReceivable, Sales, CostOfSales, Inventory, AccuralDifferedA_C,  lblGvRowId) {
    document.getElementById("lbltbl_ReceivableSetupGroup").innerHTML = ReceivableSetupGroup;
    document.getElementById("lblDescription").innerHTML = Description;
    document.getElementById("lblChequeBookName").innerHTML = ChequeBookName;
    document.getElementById("lblCash").innerHTML = Cash;
    document.getElementById("lblAccountReceivable").innerHTML = AccountReceivable;
    document.getElementById("lblSales").innerHTML = Sales;
    document.getElementById("lblCostOfSales").innerHTML = CostOfSales;
    document.getElementById("lblInventory").innerHTML = Inventory;
    document.getElementById("lblAccuralDifferedA_C").innerHTML = AccuralDifferedA_C;
   
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
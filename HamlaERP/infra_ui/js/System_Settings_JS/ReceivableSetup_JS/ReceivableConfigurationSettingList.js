
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(exceedCardLimit, removeCustomerHold, exceedMaximumWriteOffs, chequeBookName, documentFormateLabel, summaryViewLabel, receivableSetupGroup, receivableSetupAndGroupAccount, cash, accountReceivable, sales, costOfSales, inventory, accuralDifferedA_C, gvRowId) {
    
    document.getElementById("lblExceedCardLimit").innerHTML = exceedCardLimit;
    document.getElementById("lblRemoveCustomerHold").innerHTML = removeCustomerHold;
    document.getElementById("lblExceedMaximumWriteOffs").innerHTML = exceedMaximumWriteOffs;
    document.getElementById("lblChequeBookName").innerHTML = chequeBookName;
    document.getElementById("lblDocumentFormateLabel").innerHTML = documentFormateLabel;
    document.getElementById("lblSummaryViewLabel").innerHTML = summaryViewLabel;
    document.getElementById("lblReceivableSetupGroup").innerHTML = receivableSetupGroup;
    document.getElementById("lblReceivableSetupAndGroupAccount").innerHTML = receivableSetupAndGroupAccount;
    document.getElementById("lblGLAccountId_Cash").innerHTML = cash;
    document.getElementById("lblGLAccountId_AccountReceivable").innerHTML = accountReceivable;
    document.getElementById("lblGLAccountId_Sales").innerHTML = sales;
    document.getElementById("lblGLAccountId_CostOfSales").innerHTML = costOfSales;
    document.getElementById("lblGLAccountId_Inventory").innerHTML = inventory;
    document.getElementById("lblGLAccountId_AccuralDifferedA_C").innerHTML = accuralDifferedA_C;
    document.getElementById("lblGvRowId").innerHTML = gvRowId;
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
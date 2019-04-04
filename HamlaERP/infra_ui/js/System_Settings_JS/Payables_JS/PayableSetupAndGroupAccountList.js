
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(PayableSetupGroupID, ChequeBookId, AccountType, PaymentMode, GLAccountId_Cash, GLAccountId_AccountReceivable, GLAccountId_Sales, GLAccountId_CostOfSales, GLAccountId_Inventory, GLAccountId_AccuralDifferedA_C, lblGvRowId) {
   
    
    document.getElementById("lblPayableSetupGroupID").innerHTML = PayableSetupGroupID;
    document.getElementById("lblChequeBookId").innerHTML = ChequeBookId;
    document.getElementById("lblAccountType").innerHTML = AccountType;
    document.getElementById("lblPaymentMode").innerHTML = PaymentMode;
    document.getElementById("lblGLAccountId_Cash").innerHTML = GLAccountId_Cash;
    document.getElementById("lblGLAccountId_AccountReceivable").innerHTML = GLAccountId_AccountReceivable;
    document.getElementById("lblGLAccountId_Sales").innerHTML = GLAccountId_Sales;
    document.getElementById("lblGLAccountId_CostOfSales").innerHTML = GLAccountId_CostOfSales;
    document.getElementById("lblGLAccountId_Inventory").innerHTML = GLAccountId_Inventory;
    document.getElementById("lblGLAccountId_AccuralDifferedA_C").innerHTML = GLAccountId_AccuralDifferedA_C;
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
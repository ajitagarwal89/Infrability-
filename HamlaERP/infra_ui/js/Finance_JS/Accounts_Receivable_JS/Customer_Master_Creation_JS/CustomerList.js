
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function SetDetails(name, customerCode, contact, phone, mobile, email, status, cash, accountReceivable, sales, costOfSales, inventory, accuralDifferedA_C, lblGvRowId) {

    document.getElementById("lblName").innerHTML = name;
    document.getElementById("lblCode").innerHTML = customerCode;
    document.getElementById("lblContact").innerHTML = contact;
    document.getElementById("lblPhone").innerHTML = phone;
    document.getElementById("lblMobile").innerHTML = mobile;
    document.getElementById("lblEmail").innerHTML = email;
    document.getElementById("lblStatus").innerHTML = status;
    document.getElementById("lblGLAccountId_Cash").innerHTML = cash;
    document.getElementById("lblGLAccountId_AccountReceivable").innerHTML = accountReceivable;
    document.getElementById("lblGLAccountId_Sales").innerHTML = sales;
    document.getElementById("lblGLAccountId_CostOfSales").innerHTML = costOfSales;
    document.getElementById("lblGLAccountId_Inventory").innerHTML = inventory;
    document.getElementById("lblGLAccountId_AccuralDifferedA_C").innerHTML = accuralDifferedA_C;

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
    //
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
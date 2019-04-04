
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function SetDetails(name, supplierCode, contact, phone, mobile, email,Status,GLAccountId_Cash,GLAccountId_AccountPayable,GLAccountId_Purchase,GLAccountId_TradeDiscount,GLAccountId_Freight,GLAccountId_AccruedPurchase,lblGvRowId) {

    document.getElementById("lblName").innerHTML = name;
    document.getElementById("lblCode").innerHTML = supplierCode;
    document.getElementById("lblContact").innerHTML = contact;
    document.getElementById("lblPhone").innerHTML = phone;
    document.getElementById("lblMobile").innerHTML = mobile;
    document.getElementById("lblEmail").innerHTML = email;
    document.getElementById("lblStatus").innerHTML = Status;
    document.getElementById("lblGLAccountId_Cash").innerHTML = GLAccountId_Cash;
    document.getElementById("lblGLAccountId_AccountPayable").innerHTML = GLAccountId_AccountPayable;
    document.getElementById("lblGLAccountId_Purchase").innerHTML = GLAccountId_Purchase;
    document.getElementById("lblGLAccountId_TradeDiscount").innerHTML = GLAccountId_TradeDiscount;
    document.getElementById("lblGLAccountId_Freight").innerHTML = GLAccountId_Freight;
    document.getElementById("lblGLAccountId_AccruedPurchase").innerHTML = GLAccountId_AccruedPurchase;
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
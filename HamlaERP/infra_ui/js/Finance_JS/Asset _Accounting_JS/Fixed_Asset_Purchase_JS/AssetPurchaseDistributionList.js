
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(assetPurchase,gLAccount, gLAccountType, description, distributionReference, debit, credit, lblGvRowId) {
    document.getElementById("lblAssetPurchase").innerHTML = assetPurchase;
    document.getElementById("lblGLAccount").innerHTML = gLAccount;
    document.getElementById("lblGLAccountType").innerHTML = gLAccountType;
    document.getElementById("lblDescription").innerHTML = description;
    document.getElementById("lblDistributionReference").innerHTML = distributionReference;
    document.getElementById("lblDebit").innerHTML = debit;
    document.getElementById("lblCredit").innerHTML = credit;
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
    //alert(id);
    document.getElementById('lnkViewNextPrev_' + lnk).click();
}

function showPrevRecord() {
    var id = document.getElementById('lblGvRowId').innerHTML.split('_');
    var lnk = parseInt(id[1]) - 1;
    //alert(id)
    document.getElementById('lnkViewNextPrev_' + lnk).click();
}
function CallMainSearch() {
    alert("calll");
    document.getElementById("btnMainSearch").click();
}

function ClearMainSearch() {
    alert("clear");
    document.getElementById("btnClearMainSearch").click();
}
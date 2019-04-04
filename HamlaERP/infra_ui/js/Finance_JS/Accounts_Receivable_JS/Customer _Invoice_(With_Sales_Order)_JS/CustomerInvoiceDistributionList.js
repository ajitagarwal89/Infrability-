$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(customerInvoiceId, gLAccount, gLAccountType, description, distributionRefernce, debit, credit, originatingDebit, originatingCredit, lblGvRowId) {
    document.getElementById("lblCustomerInvoiceId").innerHTML = customerInvoiceId;
    document.getElementById("lblGlAccount").innerHTML = gLAccount;
    document.getElementById("lblGlAccountType").innerHTML = gLAccountType;
    document.getElementById("lblDescription").innerHTML = description;
    document.getElementById("lblDistributionReference").innerHTML = distributionRefernce;
    document.getElementById("lblDebit").innerHTML = debit;
    document.getElementById("lblCredit").innerHTML = credit;
    document.getElementById("lblOriginatingDebit").innerHTML = originatingDebit;
    document.getElementById("lblOriginatingCredit").innerHTML = originatingCredit;
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
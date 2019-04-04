$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});


function setDetails(glaccountSummary, fiscalPeriod, period, periodName, periodDate, debitAmount, creditAmount, netChargeAmount, periodBalanceAmount, lblGvRowId) {
   
    document.getElementById("lblGLAccountSummary").innerHTML = glaccountSummary;
    document.getElementById("lblFiscalPeriod").innerHTML = fiscalPeriod;   
    document.getElementById("lblPeriod").innerHTML = period;    
    document.getElementById("lblPeriodName").innerHTML = periodName;  
    document.getElementById("lblPeriodDate").innerHTML = periodDate;    
    document.getElementById("lblDebitAmount").innerHTML = debitAmount;   
    document.getElementById("lblCreditAmount").innerHTML = creditAmount;    
    document.getElementById("lblNetChargeAmount").innerHTML = netChargeAmount;    
    document.getElementById("lblPeriodBalanceAmount").innerHTML = periodBalanceAmount;   
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


$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(Description, MinimumPayment, CreditLimit, WriteOff, TradeDiscount, PaymentTermsName, StatementCycle, Calendar, FiscalYear, Transaction, Distribution, lblGvRowId) {
   
    document.getElementById("lblDescription").innerHTML = Description;
    document.getElementById("lblMinimumPayment").innerHTML = MinimumPayment;
    document.getElementById("lblCreditLimit").innerHTML = CreditLimit;
    document.getElementById("lblWriteOff").innerHTML = WriteOff;
    document.getElementById("lblTradeDiscount").innerHTML = TradeDiscount;
    document.getElementById("lblPaymentTerms").innerHTML = PaymentTermsName;
    document.getElementById("lblStatementCycle").innerHTML = StatementCycle;
    document.getElementById("lblCalendar").innerHTML = Calendar;
    document.getElementById("lblFiscalYear").innerHTML = FiscalYear;
    document.getElementById("lblTransaction").innerHTML = Transaction;
    document.getElementById("lblDistribution").innerHTML = Distribution;

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
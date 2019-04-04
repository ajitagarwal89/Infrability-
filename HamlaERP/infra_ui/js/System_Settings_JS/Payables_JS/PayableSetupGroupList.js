
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(GroupID, Default, Description, Currency, PaymentTerms, PaymentPriority, MinimumOrder, TradeDiscount, MinimumPayment, MaxInvoiceAmt, CreditLimit, WriteOff, CalenderYear, Transaction, FiscalYear, Distribution, lblGvRowId) {
    
    document.getElementById("lblPayableSetupGroupID").innerHTML = GroupID;
    document.getElementById("lblDefault").innerHTML = Default;
    document.getElementById("lblDescription").innerHTML = Description;
    document.getElementById("lblCurrencyId").innerHTML = Currency;
    document.getElementById("lblPaymentTermsId").innerHTML = PaymentTerms;
    document.getElementById("lblPaymentPriority").innerHTML = PaymentPriority;
    document.getElementById("lblMinimumOrder").innerHTML = MinimumOrder;
    document.getElementById("lblTradeDiscount").innerHTML = TradeDiscount;
    document.getElementById("lblMinimumPayment").innerHTML = MinimumPayment;
    document.getElementById("lblMaximumInvoiceAmt").innerHTML = MaxInvoiceAmt;
    document.getElementById("lblCreditLimit").innerHTML = CreditLimit;
    document.getElementById("lblWriteOff").innerHTML = WriteOff;
    document.getElementById("lblCalenderYear").innerHTML = CalenderYear;
    document.getElementById("lblTransaction").innerHTML = Transaction;
    document.getElementById("lblFiscalYear").innerHTML = FiscalYear;
    document.getElementById("lblDistribution").innerHTML = Distribution;
    document.getElementById("lblGvRowId").innerHTML = lblGvRowId;
   
    var maxrows = document.getElementById('gvData').rows.length - 1;
    var num = document.getElementById('lblGvRowId').innerHTML.split('_');
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
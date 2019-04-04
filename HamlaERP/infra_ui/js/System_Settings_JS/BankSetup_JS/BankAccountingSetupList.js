
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(Depositcode, Deposit, ReceiptCode, Receipt, CheckCode, Check, WithdrawalCode, Withdrawal, IncreaseAdjustmentCode, IncreaseAdjustment,DecreaseAdjustmentCode, DecreaseAdjustment, lblGvRowId) {
    document.getElementById("lblDepositcode").innerHTML = Depositcode;
    document.getElementById("lblDeposit").innerHTML = Deposit;
    document.getElementById("lblReceiptCode").innerHTML = ReceiptCode;
    document.getElementById("lblReceipt").innerHTML = Receipt;
    document.getElementById("lblCheckCode").innerHTML = CheckCode;
    document.getElementById("lblCheck").innerHTML = Check;
    document.getElementById("lblWithdrawalCode").innerHTML = WithdrawalCode;
    document.getElementById("lblWithdrawal").innerHTML = Withdrawal;
    document.getElementById("lblIncreaseAdjustmentCode").innerHTML = IncreaseAdjustmentCode;
    document.getElementById("lblIncreaseAdjustment").innerHTML = IncreaseAdjustment;
    document.getElementById("lblDecreaseAdjustmentCode").innerHTML = DecreaseAdjustmentCode;
    document.getElementById("lblDecreaseAdjustment").innerHTML = DecreaseAdjustment;

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
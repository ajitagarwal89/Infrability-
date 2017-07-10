
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function SetDetails(paymentToEmployee, applyToDocument, dueDate, remainingAmount, applyAmount, type, orignalDocumentAmount, discountDate, lblGvRowId)
{
    document.getElementById("lblPaymentToEmployee").innerHTML = paymentToEmployee;
    document.getElementById("lblDueDate").innerHTML = dueDate;
    document.getElementById("lblRemainingAmount").innerHTML = remainingAmount;
    document.getElementById("lblApplyAmount").innerHTML = applyAmount;
    document.getElementById("lblType").innerHTML = type;
    document.getElementById("lblOrignalDocumentAmount").innerHTML = orignalDocumentAmount;
    document.getElementById("lblDiscountDate").innerHTML = discountDate;
    document.getElementById("lblGvRowId").innerHTML = lblGvRowId;
    //document.getElementById("lblApplyToDocument").innerHTML = applyToDocument;
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
    document.getElementById("btnMainSearch").click();
}

function ClearMainSearch() {
    document.getElementById("btnClearMainSearch").click();
}
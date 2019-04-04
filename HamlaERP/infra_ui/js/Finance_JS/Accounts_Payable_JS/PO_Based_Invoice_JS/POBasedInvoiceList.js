
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function SetDetails(supplierName, currencyName, receiptNumber, paymentTermsName, batchName, invoiceDate, subTotalAmount,
    tradeDiscountAmount, freightAmount, totalAmount, lblGvRowId)
{
    document.getElementById("lblSupplierName").innerHTML = supplierName;
    document.getElementById("lblCurrencyName").innerHTML = currencyName;
    document.getElementById("lblReceiptNumber").innerHTML = receiptNumber;
    document.getElementById("lblPaymentTermsName").innerHTML = paymentTermsName;
    
    document.getElementById("lblInvoiceDate").innerHTML = batchName;
    document.getElementById("lblBatchName").innerHTML = invoiceDate;
    document.getElementById("lblSubTotalAmount").innerHTML = subTotalAmount;
    document.getElementById("lblTradeDiscountAmount").innerHTML = tradeDiscountAmount;
    document.getElementById("lblFreightAmount").innerHTML = freightAmount;
    document.getElementById("lblTotalAmount").innerHTML = totalAmount;
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
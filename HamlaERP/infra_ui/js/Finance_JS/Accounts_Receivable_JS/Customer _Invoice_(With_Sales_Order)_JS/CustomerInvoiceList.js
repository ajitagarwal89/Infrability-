
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function SetDetails(documentDate, opt_InvoiceAndOrderTypeLable, documentNumber, batchName, name, siteNumber, customerPONumber, currencyName, amountReceived,
    onAccount, subTotalAmount, tradeDiscountAmount, freightAmount, totalAmount, postingDate, qoteDate, orderDate, invoiceDate, backOrderDate, returnDate,
    requestedShipDate, dateFulfilled, actualShipDate, lblGvRowId) {

    document.getElementById("lblDocumentDate").innerHTML = documentDate;
    document.getElementById("lblopt_InvoiceAndOrderTypeLable").innerHTML = opt_InvoiceAndOrderTypeLable;
    document.getElementById("lblDocumentNumber").innerHTML = documentNumber;
    document.getElementById("lblBatchName").innerHTML = batchName;
    document.getElementById("lblCustomerName").innerHTML = name;
    document.getElementById("lblSiteNumber").innerHTML = siteNumber;
    document.getElementById("lblCustomerPONumber").innerHTML = customerPONumber;
    document.getElementById("lblCurrencyName").innerHTML = currencyName;
    document.getElementById("lblAmountReceived").innerHTML = amountReceived;
    document.getElementById("lblOnAccount").innerHTML = onAccount;
    document.getElementById("lblSubTotalAmount").innerHTML = subTotalAmount;
    document.getElementById("lblTradeDiscountAmount").innerHTML = tradeDiscountAmount;
    document.getElementById("lblFreightAmount").innerHTML = freightAmount;
    document.getElementById("lblTotalAmount").innerHTML = totalAmount;
    document.getElementById("lblPostingDate").innerHTML = postingDate;    
    document.getElementById("lblQuoteDate").innerHTML = qoteDate;
    document.getElementById("lblOrderDate").innerHTML = orderDate;
    document.getElementById("lblInvoiceDate").innerHTML = invoiceDate;
    document.getElementById("lblBackOrderDate").innerHTML = backOrderDate;
    document.getElementById("lblReturnDate").innerHTML = returnDate;
    document.getElementById("lblRequestedShipDate").innerHTML = requestedShipDate;
    document.getElementById("lblDateFulfilled").innerHTML = dateFulfilled;
    document.getElementById("lblActualShipDate").innerHTML = actualShipDate;

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
    document.getElementById("btnMainSearch").click();
}

function ClearMainSearch() {
    document.getElementById("btnClearMainSearch").click();
}
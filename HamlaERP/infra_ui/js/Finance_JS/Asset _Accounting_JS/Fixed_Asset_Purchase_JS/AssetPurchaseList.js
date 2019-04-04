


function setDetails(receiptType, receiptNumber, supplier, currencyName, supplierDocumentNumber, currencyName, date, batch, subTotal, tradeDiscount, frieght, miscellaneous, mainTotal, lblGvRowId) {
    
    document.getElementById("lblReceiptType").innerHTML = receiptType;
    document.getElementById("lblReceiptNumber").innerHTML = receiptNumber;
    document.getElementById("lblSupplier").innerHTML = supplier;
    document.getElementById("lblCurrencyName").innerHTML = currencyName;
    document.getElementById("lblSupplierDocumentNumber").innerHTML = supplierDocumentNumber;
    document.getElementById("lblDate").innerHTML = date;   
    document.getElementById("lblBatch").innerHTML = batch;
    document.getElementById("lblSubTotal").innerHTML = subTotal;
    document.getElementById("lblTradeDiscount").innerHTML = tradeDiscount;
    document.getElementById("lblFrieght").innerHTML = frieght;
    document.getElementById("lblMiscellaneous").innerHTML = miscellaneous;
    document.getElementById("lblMainTotal").innerHTML = mainTotal;
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
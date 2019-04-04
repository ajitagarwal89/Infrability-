
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function SetDetails(pOBasedInvoiceId, pOId, locationId, uOM, quantityInvoice, unitCost, extendedCost, lblGvRowId) {
    document.getElementById("lblPOBasedInvoiceId").innerHTML = pOBasedInvoiceId;
    document.getElementById("lblPOId").innerHTML = pOId;
    document.getElementById("lblLocationId").innerHTML = locationId;
    document.getElementById("lblUOM").innerHTML = uOM;
    document.getElementById("lblQuantityInvoice").innerHTML = quantityInvoice;
    document.getElementById("lblUnitCost").innerHTML = unitCost;
    document.getElementById("lblExtendedCost").innerHTML = extendedCost;
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
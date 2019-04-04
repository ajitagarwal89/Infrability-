
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(PONumber, Asset, UOM, Location, QuantityOrdered, QuantityShipped, QuantityInvoiced, PreviouslyShipped, PreviouslyInvoiced, UnitCost, ExtendedCost, lblGvRowId) {
    document.getElementById("lblPONumber").innerHTML = PONumber;
    document.getElementById("lblAsset").innerHTML = Asset;
    document.getElementById("lblUOM").innerHTML = UOM;
    document.getElementById("lblLocation").innerHTML = Location;
    document.getElementById("lblQuantityOrdered").innerHTML = QuantityOrdered;
    document.getElementById("lblQuantityShipped").innerHTML = QuantityShipped;
    document.getElementById("lblQuantityInvoiced").innerHTML = QuantityInvoiced;
    document.getElementById("lblPreviouslyShipped").innerHTML = PreviouslyShipped;
    document.getElementById("lblPreviouslyInvoiced").innerHTML = PreviouslyInvoiced;
    document.getElementById("lblUnitCost").innerHTML = UnitCost;
    document.getElementById("lblExtendedCost").innerHTML = ExtendedCost;
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
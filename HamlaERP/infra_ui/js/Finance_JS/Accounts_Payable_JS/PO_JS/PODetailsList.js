$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(pOId, asset, description, location, quanityOrdered, quantityCanceled, unitCost, extendedCost, lblGvRowId) {

    document.getElementById("lblPoId").innerHTML = pOId;
    document.getElementById("lblAsset").innerHTML = asset;
    document.getElementById("lblDescription").innerHTML = description;
    document.getElementById("lblLocation").innerHTML = location;
    document.getElementById("lblQuantityOrdered").innerHTML = quanityOrdered;
    document.getElementById("lblQuantityCanceled").innerHTML = quantityCanceled;
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
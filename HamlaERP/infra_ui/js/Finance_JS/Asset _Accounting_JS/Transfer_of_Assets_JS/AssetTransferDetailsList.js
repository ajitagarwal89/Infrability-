
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(assetTransfer,asset,uOM,quantity,description,location_From,location_To,subTotal,quantityAvailable, lblGvRowId) {
    document.getElementById("lblAssetTransfer").innerHTML = assetTransfer;
    document.getElementById("lblAsset").innerHTML = asset;
    document.getElementById("lblUOM").innerHTML = uOM;
    document.getElementById("lblQuantity").innerHTML = quantity;
    document.getElementById("lblDescription").innerHTML = description;
    document.getElementById("lblLocationFrom").innerHTML = location_From;
    document.getElementById("lblLocationTo").innerHTML = location_To;
    document.getElementById("lblSubTotal").innerHTML = subTotal;
    document.getElementById("lblQuantityAvailable").innerHTML = quantityAvailable;
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
    alert("calll");
    document.getElementById("btnMainSearch").click();
}

function ClearMainSearch() {
    alert("clear");
    document.getElementById("btnClearMainSearch").click();
}
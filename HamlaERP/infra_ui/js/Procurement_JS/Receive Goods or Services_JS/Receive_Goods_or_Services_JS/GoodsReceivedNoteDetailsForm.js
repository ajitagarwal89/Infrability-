function ClearForm() {
    document.getElementById('txtAsset').value = '';
    document.getElementById('txtAssetGuid').value = '';
    document.getElementById('txtGoodsReceivedNote').value = '';
    document.getElementById('txtGoodsReceivedNoteGuid').value = '';
    document.getElementById('txtPO').value = '';
    document.getElementById('txtPOGuid').value = '';
    document.getElementById('txtUOM').value = '';
    document.getElementById('txtLocation').value = '';
    document.getElementById('txtLocationGuid').value = '';
    document.getElementById('txtDescription').value = '';
    document.getElementById('txtQuantityOrdered').value = '';
    document.getElementById('txtQuantityShipped').value = '';
    document.getElementById('txtQuantityInvoiced').value = '';
    document.getElementById('txtPreviouslyShipped').value = '';
    document.getElementById('txtPreviouslyInvoiced').value = '';
    document.getElementById('txtUnitCost').value = '';
    document.getElementById('txtExtendedCost').value = '';
    return false;
}


function SetAssetDetails(accountNumber, AssetGuid) {

    document.getElementById("txtAsset").value = accountNumber
    document.getElementById("txtAssetGuid").value = AssetGuid;

}

function CallAssetSearch() {
    document.getElementById("btnAssetSearch").click();

}

function ClearAssetSearch() {
    document.getElementById("btnClearAssetSearch").click();
}

function CallAssetRefreshButton() {
    document.getElementById("btnAssetRefresh").click();
    document.getElementById("btnClearAssetSearch").click();
}
function SetLocationDetails(description, locationGuid) {
    document.getElementById("txtLocation").value = description;
    document.getElementById("txtLocationGuid").value = locationGuid;
}

function CallLocationSearch() {
    document.getElementById("btnLocationSearch").click();

}

function ClearLocationSearch() {
    document.getElementById("btnClearLocationSearch").click();
}

function CallLocationRefreshButton() {
    document.getElementById("btnLocationRefresh").click();
    document.getElementById("btnClearLocationSearch").click();
}
function SetGoodsReceivedNoteDetails(goodsReceivedNoteNumber, goodsReceivedNoteGuid) {

    document.getElementById("txtGoodsReceivedNote").value = goodsReceivedNoteNumber;
    document.getElementById("txtGoodsReceivedNoteGuid").value = goodsReceivedNoteGuid;

}

function CallGoodsReceivedNoteSearch() {
    document.getElementById("btnGoodsReceivedNoteSearch").click();

}

function ClearGoodsReceivedNoteSearch() {
    document.getElementById("btnClearGoodsReceivedNoteSearch").click();
}

function CallGoodsReceivedNoteRefreshButton() {
    document.getElementById("btnGoodsReceivedNoteRefresh").click();
    document.getElementById("btnClearGoodsReceivedNoteSearch").click();
}
function SetPODetails(poNumber, POGuid) {

    document.getElementById("txtPO").value = poNumber
    document.getElementById("txtPOGuid").value = POGuid;

}

function CallPOSearch() {
    document.getElementById("btnPOSearch").click();

}

function ClearPOSearch() {
    document.getElementById("btnClearPOSearch").click();
}

function CallPORefreshButton() {
    document.getElementById("btnPORefresh").click();
    document.getElementById("btnClearPOSearch").click();
}

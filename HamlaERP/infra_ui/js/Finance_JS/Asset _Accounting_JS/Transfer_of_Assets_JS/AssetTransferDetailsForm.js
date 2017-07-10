function ClearForm() {
    document.getElementById('txtAssetTransfer').value = '';
    document.getElementById('txtAssetTransferGuid').value = '';
    document.getElementById('txtAsset').value = '';
    document.getElementById('txtAssetGuid').value = '';
    document.getElementById('txtUOM').value = '';
    document.getElementById('txtQuantity').value = '';
    document.getElementById('txtDescription').value = '';
    document.getElementById('txtLocationId_From').value = '';
    document.getElementById('txtLocation_FromGuid').value = '';
    document.getElementById('txtLocationId_To').value = '';
    document.getElementById('txtLocation_ToGuid').value = '';
    document.getElementById('txtSubTotal').value = '';
    document.getElementById('txtQuantityAvailable').value = '';
    
    return false;
}
function SetAssetTransferDetails(AssetTransfer, AssetTransferGuid) {
    document.getElementById("txtAssetTransfer").value = AssetTransfer;
    document.getElementById("txtAssetTransferGuid").value = AssetTransferGuid;
}

function CallAssetTransferSearch() {
    document.getElementById("btnAssetTransferSearch").click();

}

function ClearAssetTransferSearch() {
    document.getElementById("btnClearAssetTransferSearch").click();
}

function CallAssetTransferRefreshButton() {
    document.getElementById("btnAssetTransferRefresh").click();
    document.getElementById("btnClearAssetTransferSearch").click();
}

function SetLocationFromDetails(LocationFrom, LocationFromGuid) {
    document.getElementById("txtLocationId_From").value = LocationFrom;
    document.getElementById("txtLocation_FromGuid").value = LocationFromGuid;
}

function CallLocationFromSearch() {
    document.getElementById("btnLocationFromSearch").click();

}

function ClearLocationFromSearch() {
    document.getElementById("btnClearLocationFromSearch").click();
}

function CallLocationFromRefreshButton() {
    document.getElementById("btnLocationFromRefresh").click();
    document.getElementById("btnClearLocationFromSearch").click();
}

function SetLocationToDetails(LocationTo, LocationToGuid) {
    document.getElementById("txtLocationId_To").value = LocationTo;
    document.getElementById("txtLocation_ToGuid").value = LocationToGuid;
}

function CallLocationToSearch() {
    document.getElementById("btnLocationToSearch").click();

}

function ClearLocationToSearch() {
    document.getElementById("btnClearLocationToSearch").click();
}

function CallLocationToRefreshButton() {
    document.getElementById("btnLocationToRefresh").click();
    document.getElementById("btnClearLocationToSearch").click();
}
function SetAssetDetails(asset, assetGuid) {
    document.getElementById("txtAsset").value = asset;
    document.getElementById("txtAssetGuid").value = assetGuid;
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
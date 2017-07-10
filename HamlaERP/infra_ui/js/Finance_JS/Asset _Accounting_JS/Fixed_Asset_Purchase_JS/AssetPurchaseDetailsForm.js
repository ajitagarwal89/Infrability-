function ClearForm() {

    document.getElementById('txtAssetPurchase').value = '';
    document.getElementById('txtAssetPurchaseGuid').value = '';
    document.getElementById('txtPONumber').value = '';
    document.getElementById('txtPONumberGuid').value = '';
    document.getElementById('txtAsset').value = '';
    document.getElementById('txtAssetGuid').value = '';
    document.getElementById('txtLocation').value = '';
    document.getElementById('txtLocationGuid').value = '';
    document.getElementById('txtUOM').value = '';
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


function SetLocationDetails(location, locationGuid) {
    document.getElementById("txtLocation").value = location;
    document.getElementById("txtLocationGuid").value = locationGuid;
}

function CallLocationSearch() {
    document.getElementById("btnLocationSearch").click();

}

function ClearLocationSearch() {
    document.getElementById("btnCleaLocationSearch").click();
}

function CallLocationRefreshButton() {
    document.getElementById("btnLocationRefresh").click();
    document.getElementById("btnClearLocationSearch").click();
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

function SetPONumberDetails(poNumber, poNumberGuid) {
    document.getElementById("txtPONumber").value = poNumber;
    document.getElementById("txtPONumberGuid").value = poNumberGuid;
}

function CallPONumberSearch() {
    document.getElementById("btnPONumberSearch").click();

}

function ClearPONumberSearch() {
    document.getElementById("btnClearPONumberSearch").click();
}

function CallPONumberRefreshButton() {
    document.getElementById("btnPONumberRefresh").click();
    document.getElementById("btnClearPONumberSearch").click();
}



function SetAssetPurchaseDetails(assetPurchase, assetPurchaseGuid) {
    document.getElementById("txtAssetPurchase").value = assetPurchase;
    document.getElementById("txtAssetPurchaseGuid").value = assetPurchaseGuid;
}

function CallAssetPurchaseSearch() {
    document.getElementById("btnAssetPurchaseSearch").click();

}

function ClearAssetPurchaseSearch() {
    document.getElementById("btnClearAssetPurchaseSearch").click();
}

function CallAssetPurchaseRefreshButton() {
    document.getElementById("btnAssetPurchaseRefresh").click();
    document.getElementById("btnClearAssetPurchaseSearch").click();
}
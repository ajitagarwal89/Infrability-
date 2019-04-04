function ClearForm() {

    document.getElementById('txtPOId').value = '';
    document.getElementById('txtPOIdGuid').value = '';
    document.getElementById('txtAssetId').value = '';
    document.getElementById('txtAssetIdGuid').value = '';
    document.getElementById('txtUOM').value = '';
    document.getElementById('txtDescription').value = '';
    document.getElementById('txtLocation').value = '';
    document.getElementById('txtLocationGuid').value = '';
    document.getElementById('txtQuantityOrdered').value = '';
    document.getElementById('txtQuantityCanceled').value = '';
    document.getElementById('txtUnitCost').value = '';
    document.getElementById('txtExtendedCost').value = '';
    return false;
}

function SetPODetails(pOID, pOIDGUID) {

    document.getElementById("txtPOId").value = pOID;
    document.getElementById("txtPOIdGuid").value = pOIDGUID;

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


function SetAssetDetails(assetId, assetIdGuid) {

    document.getElementById("txtAssetId").value = assetId;
    document.getElementById("txtAssetIdGuid").value = assetIdGuid;
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



function SetLocationDetails(location, locationGuid) {

    document.getElementById("txtLocation").value = location;
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

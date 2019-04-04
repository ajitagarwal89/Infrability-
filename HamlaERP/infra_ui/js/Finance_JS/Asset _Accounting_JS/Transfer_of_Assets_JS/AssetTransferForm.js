function ClearForm() {
    document.getElementById('ddlOpt_DocumentType').selectedIndex = 0;
    document.getElementById('txtNumber').value = '';
    document.getElementById('txtBatchId').value = ''; 
    document.getElementById('txtBatchIdGuid').value = '';
    document.getElementById('txtDate').value = '';
    document.getElementById('txtLocationId_From').value = '';
    document.getElementById('txtLocation_FromGuid').value = '';
    document.getElementById('txtLocationId_To').value = '';
    document.getElementById('txtLocation_ToGuid').value = '';
    return false;
}

function SetBatchDetails(batchId, batchIdGuid) {
    document.getElementById("txtBatchId").value = batchId;
    document.getElementById("txtBatchIdGuid").value = batchIdGuid;
}

function CallBatchSearch() {
    document.getElementById("btnBatchSearch").click();

}

function ClearBatchSearch() {
    document.getElementById("btnClearBatchSearch").click();
}

function CallBatchRefreshButton() {
    document.getElementById("btnBatchRefresh").click();
    document.getElementById("btnClearBatchSearch").click();
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


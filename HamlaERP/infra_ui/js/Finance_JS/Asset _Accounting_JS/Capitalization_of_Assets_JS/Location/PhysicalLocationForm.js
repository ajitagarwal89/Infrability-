
function ClearForm() {
   
    document.getElementById('txtDescription').value = '';
    document.getElementById('txtLastInventoryDate').value = '';
    document.getElementById('txtLocation').value = '';
    document.getElementById('txtLocationGuid').value = '';
    return false;
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




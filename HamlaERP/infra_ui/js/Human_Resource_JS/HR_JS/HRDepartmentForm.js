function ClearForm() {
    document.getElementById('txtHRDivision').value = '';
    document.getElementById('txtHRDivisionGuid').value = '';
    document.getElementById('txtDepartmentCode').value = '';
    document.getElementById('txtDescription').value = '';
   
    return false;
}


function SetHRDivisionDetails(hRDivision, hRDivisionGuid) {

    document.getElementById("txtHRDivision").value = hRDivision;
    document.getElementById("txtHRDivisionGuid").value = hRDivisionGuid;

}

function CallHRDivisionSearch() {
    document.getElementById("btnHRDivisionSearch").click();

}

function ClearHRDivisionSearch() {
    document.getElementById("btnClearHRDivisionSearch").click();
}

function CallHRDivisionRefreshButton() {
    document.getElementById("btnHRDivisionRefresh").click();
    document.getElementById("btnClearHRDivisionSearch").click();
}
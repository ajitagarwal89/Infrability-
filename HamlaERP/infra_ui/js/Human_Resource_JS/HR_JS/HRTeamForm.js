function ClearForm() {
    document.getElementById('txtHRDepartment').value = '';
    document.getElementById('txtHRDepartmentGuid').checked = false;
    document.getElementById('txtTeamCode').value = '';
    document.getElementById('txtDescription').value = '';
    return false;
}
function SetHRDepartmentDetails(hRDepartment, hRDepartmentGuid) {
    document.getElementById("txtHRDepartment").value = hRDepartment;
    document.getElementById("txtHRDepartmentGuid").value = hRDepartmentGuid;
}

function CallHRDepartmentSearch() {
    document.getElementById("btnHRDepartmentSearch").click();

}

function ClearHRDepartmentSearch() {
    document.getElementById("btnClearHRDepartmentSearch").click();
}

function CallHRDepartmentRefreshButton() {
    document.getElementById("btnHRDepartmentRefresh").click();
    document.getElementById("btnClearHRDepartmentSearch").click();
}

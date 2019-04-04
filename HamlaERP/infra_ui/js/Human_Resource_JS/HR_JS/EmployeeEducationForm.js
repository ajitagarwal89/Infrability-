function ClearForm() {
    document.getElementById('txtEmployeeGuid').value = '';
    document.getElementById('txtEmployee').value = '';
    document.getElementById('txtSchool').value = '';
    document.getElementById('txtMajor').value = '';
    document.getElementById('txtYear').value = '';
    document.getElementById('txtDegree').value = '';
    document.getElementById('txtGPA').value = '';
    document.getElementById('txtNote').value = '';

}
function SetEmployeeDetails(employeeName, employeeGuid) {
    document.getElementById("txtEmployee").value = employeeName;
    document.getElementById("txtEmployeeGuid").value = employeeGuid;
}


function CallEmployeeSearch() {
    document.getElementById("btnEmployeeSearch").click();

}

function ClearEmployeeSearch() {
    document.getElementById("btnClearEmployeeSearch").click();
}

function CallEmployeeRefreshButton() {
    document.getElementById("btnEmployeeRefresh").click();
    document.getElementById("btnClearEmployeeSearch").click();
}
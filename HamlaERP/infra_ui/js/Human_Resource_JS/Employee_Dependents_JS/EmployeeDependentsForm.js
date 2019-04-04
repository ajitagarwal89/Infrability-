function ClearForm() {

    document.getElementById('txtEmployee').value = '';
    document.getElementById('txtEmployeeGuid').value = '';
    document.getElementById('txtCountry').value = '';
    document.getElementById('txtCountryGuid').value = '';
    document.getElementById('txtHR_Department').value = '';
    document.getElementById('txtHR_DepartmentGuid').value = '';
    document.getElementById('ddlOpt_Relationship').selectedIndex = 0;
    document.getElementById('txtFirstName').value = '';
    document.getElementById('txtMiddleName').value = '';
    document.getElementById('txtLastName').value = '';
    document.getElementById('txtDOB').value = '';
    document.getElementById('rdbMale').checked = false;
    document.getElementById('rdbFemale').checked = false;
    document.getElementById('txtHomePhone').value = '';
    document.getElementById('txtWorkPhone').value = '';
    document.getElementById('txtExt').value = '';
    document.getElementById('txtAddress1').value = '';
    document.getElementById('txtAddress2').value = '';
    document.getElementById('txtCity').value = '';
    document.getElementById('txtState').value = '';
    document.getElementById('txtZipCode').value = '';

    return false;
}

function SetCountryDetails(countryName, countryGuid) {
    document.getElementById("txtCountry").value = countryName;
    document.getElementById("txtCountryGuid").value = countryGuid;
}

function CallCountrySearch() {
    document.getElementById("btnCountrySearch").click();

}

function ClearCountrySearch() {
    document.getElementById("btnClearCountrySearch").click();
}

function CallCountryRefreshButton() {
    document.getElementById("btnCountryRefresh").click();
    document.getElementById("btnClearCountrySearch").click();
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
function SetHR_DepartmentDetails(HR_DepartmentCode, HR_DepartmentGuid) {
    document.getElementById("txtHR_Department").value = HR_DepartmentCode;
    document.getElementById("txtHR_DepartmentGuid").value = HR_DepartmentGuid;
}

function CallHR_DepartmentSearch() {
    document.getElementById("btnHR_DepartmentSearch").click();

}

function ClearHR_DepartmentSearch() {
    document.getElementById("btnClearHR_DepartmentSearch").click();
}

function CallHR_DepartmentRefreshButton() {
    document.getElementById("btnHR_DepartmentRefresh").click();
    document.getElementById("btnClearHR_DepartmentSearch").click();
}

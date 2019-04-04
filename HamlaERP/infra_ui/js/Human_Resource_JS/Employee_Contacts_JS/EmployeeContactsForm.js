function ClearForm() {

    document.getElementById('txtEmployee').value = '';
    document.getElementById('txtEmployeeGuid').value = '';
    document.getElementById('txtContact').value = '';
    document.getElementById('txtCountry').value = '';
    document.getElementById('txtCountryGuid').value = '';
    document.getElementById('txtRelationship').value = '';
    document.getElementById('txtHomePhone').value = '';
    document.getElementById('txtWorkPhone').value = '';
    document.getElementById('txtExt').value = '';
    document.getElementById('txtAddress').value = '';
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

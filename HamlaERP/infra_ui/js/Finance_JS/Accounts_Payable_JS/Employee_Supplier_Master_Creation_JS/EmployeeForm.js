function ClearForm() {

    document.getElementById('txtEmployeeCode').value = '';
    document.getElementById('txtName').value = '';
    document.getElementById('txtShortName').value = '';
    document.getElementById('txtChequeName').value = '';
    document.getElementById('txtContact').value = '';
    document.getElementById('txtAddress').value = '';
    document.getElementById('txtCity').value = '';
    document.getElementById('txtCountry').value = '';
    document.getElementById('txtCountryGuid').value = '';
    document.getElementById('txtZipCode').value = '';
    document.getElementById('txtPhone').value = '';
    document.getElementById('txtMobile').value = '';
    document.getElementById('txtFaxNo').value = '';
    document.getElementById('txtEmail').value = '';
    document.getElementById('txtComment1').value = '';
    document.getElementById('txtComment2').value = '';
    document.getElementById('txtEmployeeGroup').value = '';
    document.getElementById('txtEmployeeGroupGuid').value = '';    
    document.getElementById('ddlStatus').selectedIndex = 0;  
    document.getElementById('chkOnHold').checked = false;

    return false;
}

function setCountryDetails(countryName, countryGuid) {
    document.getElementById("txtCountry").value = countryName;
    document.getElementById("txtCountryGuid").value = countryGuid;
}

function CallCountrySearch() {
    document.getElementById("btnCountrySearch").click();

}

function ClearCountrySearch() {
    document.getElementById("btnClearCountrySearch").click();
}

function CallRefreshButton() {
    document.getElementById("btnCountryRefresh").click();
    document.getElementById("btnClearCountrySearch").click();
}


function SetEmployeeGroupDetails(employeeGroupName, employeeGroupGuid) {
    document.getElementById("txtEmployeeGroup").value = employeeGroupName;
    document.getElementById("txtEmployeeGroupGuid").value = employeeGroupGuid;
}

function CallEmployeeGroupSearch() {
    document.getElementById("btnEmployeeGroupSearch").click();

}

function ClearEmployeeGroupSearch() {
    document.getElementById("btnClearEmployeeGroupSearch").click();
}

function CallEmployeeGroupRefreshButton() {
    document.getElementById("btnEmployeeGroupRefresh").click();
    document.getElementById("btnClearEmployeeGroupSearch").click();
}
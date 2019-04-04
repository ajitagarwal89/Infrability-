function ClearForm() {
    document.getElementById('txtFullName').value = '';
    document.getElementById('txtEmployeeCode').value = '';
    document.getElementById('txtDOB').value = '';
    document.getElementById('txtPermanentAddress').value = '';
    document.getElementById('txtCorrespondanceAddress').value = '';
    document.getElementById('txtCity').value = '';
    document.getElementById('txtState').value = '';
    document.getElementById('txtPostalCode').value = '';
    document.getElementById('txtCountry').value = '';
    document.getElementById('txtPhone').value = '';
    document.getElementById('txtFax').value = ''; 
    document.getElementById('txtMobile').value = '';
    document.getElementById('txtEmail').value = '';
    document.getElementById('ddlOpt_Department').selectedIndex = 0;
    document.getElementById('txtDateOfJoining').value = '';
    document.getElementById('ddlopt_Designation').selectedIndex = 0;
    document.getElementById('txtUserName').value = '';
    document.getElementById('txtPassword').value = '';   
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

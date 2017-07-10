function ClearForm() {
    document.getElementById('txtBankCode').value = '';
    document.getElementById('txtBankName').value = '';
    document.getElementById('txtAddress').value = '';
    document.getElementById('txtCity').value = '';
    document.getElementById('txtState').value = '';
    document.getElementById('txtZipCode').value = '';
    document.getElementById('txtCountry').value = '';
    document.getElementById('txtPhone').value = '';
    document.getElementById('txtMobile').value = '';
    document.getElementById('txtFax').value = '';
    document.getElementById('txtBranch').value = '';
    document.getElementById('txtIban').value = '';

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

function CallRefreshButton() {
    document.getElementById("btnRefresh").click();
    document.getElementById("btnClearCountrySearch").click();
}
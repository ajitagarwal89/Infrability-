function ClearForm() {
    document.getElementById('txtLocationCode').value = '';
    document.getElementById('txtDescription').value = '';
    document.getElementById('txtCountry').value = '';
    document.getElementById('txtCountryGuid').value = '';
    document.getElementById('txtCity').value = '';
    return false;
}

function setCountryDetails(countryName, countryGuid) {
    document.getElementById("txtCountry").value = countryName;
    document.getElementById("txtCountryGuid").innerHTML = countryGuid;
}

function CallCountrySearch() {
    document.getElementById("btnCountrySearch").click();

}

function ClearCountrySearch() {
    document.getElementById("btnClearCountrySearch").click();
}

function CallCountryRefreshButton() {
    document.getElementById("btnRefresh").click();
    document.getElementById("btnClearCountrySearch").click();
}
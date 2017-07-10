function ClearForm() {

    document.getElementById('txtSupplierCode').value = '';
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
    document.getElementById('txtSupplierGroup').value = '';
    document.getElementById('txtSupplierGroupGuid').value = '';

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
    document.getElementById("btnCountryRefresh").click();
    document.getElementById("btnClearCountrySearch").click();
}


function SetSupplierGroupDetails(supplierGroupName, supplierGroupGuid) {
    document.getElementById("txtSupplierGroup").value = supplierGroupName;
    document.getElementById("txtSupplierGroupGuid").value = supplierGroupGuid;
}

function CallSupplierGroupSearch() {
    document.getElementById("btnSupplierGroupSearch").click();

}

function ClearSupplierGroupSearch() {
    document.getElementById("btnClearSupplierGroupSearch").click();
}

function CallSupplierGroupRefreshButton() {
    document.getElementById("btnSupplierGroupRefresh").click();
    document.getElementById("btnClearSupplierGroupSearch").click();
}
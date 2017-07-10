function ClearForm() {
    alert("ClearForm");
    document.getElementById('txtCustomerCode').value = '';
    document.getElementById('txtName').value = '';
    document.getElementById('txtShortName').value = '';
    document.getElementById('txtStatementName').value = '';
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
    document.getElementById('txtCustomerGroup').value = '';
    document.getElementById('txtCustomerGroupGuid').value = '';
    document.getElementById("chkPaymentMode").checked = false;
    document.getElementById("ddlStatus").selectedIndex = 0;
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


function SetCustomerGroupDetails(customerGroupName, customerGroupGuid) {
    document.getElementById("txtCustomerGroup").value = customerGroupName;
    document.getElementById("txtCustomerGroupGuid").value = customerGroupGuid;
}

function CallCustomerGroupSearch() {
    document.getElementById("btnCustomerGroupSearch").click();

}

function ClearCustomerGroupSearch() {
    document.getElementById("btnClearCustomerGroupSearch").click();
}

function CallCustomerGroupRefreshButton() {
    document.getElementById("btnCustomerGroupRefresh").click();
    document.getElementById("btnClearCustomerGroupSearch").click();
}
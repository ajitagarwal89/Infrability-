function ClearForm() {
    document.getElementById('txtDescription').value = '';
    document.getElementById('txtAssetAndGroupAccountId').value = '';
    document.getElementById('txtInsuranceId').value = '';
    return false;
}

function SetAssetAndGroupAccountDetails(accountType, assetAndGroupAccountGuid) {
    document.getElementById("txtAssetAndGroupAccountId").value = accountType;
    document.getElementById("txtAssetAndGroupAccountIdGuid").value = assetAndGroupAccountGuid;
}

function CallAssetAndGroupAccountSearch() {
    document.getElementById("btnAssetAndGroupAccountSearch").click();

}

function ClearAssetAndGroupAccountSearch() {
    document.getElementById("btnClearAssetAndGroupAccountSearch").click();
}

function CallAssetAndGroupAccountRefreshButton() {
    document.getElementById("btnAssetAndGroupAccountRefresh").click();
    document.getElementById("btnClearAssetAndGroupAccountSearch").click();
}

function SetInsuranceDetails(insuranceCode, insuranceGuid) {
    document.getElementById("txtInsuranceId").value = insuranceCode;
    document.getElementById("txtInsuranceIdGuid").value = insuranceGuid;
}

function CallInsuranceSearch() {
    document.getElementById("btnInsuranceSearch").click();
}

function ClearInsuranceSearch() {
    document.getElementById("btnClearInsuranceSearch").click();
}

function CallInsuranceRefreshButton() {
    document.getElementById("btnInsuranceRefresh").click();
    document.getElementById("btnClearInsuranceSearch").click();
}
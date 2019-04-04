function ClearForm() {
    document.getElementById('txtAssetDisposalCode').value = '';
    document.getElementById('txtAsset').value = '';
    document.getElementById('txtAssetGuid').value = '';
    document.getElementById('txtCurrency').value = '';
    document.getElementById('txtCurrencyGuid').value = '';
    document.getElementById('txtRetirementDate').value = '';
    document.getElementById('ddlOpt_RetirementType').value = selectedIndex = 0;
    document.getElementById('txtRetirementEvent').value = '';  
    return false;
}


function SetAssetDetails(asset, assetGuid) {
    document.getElementById("txtAsset").value = asset;
    document.getElementById("txtAssetGuid").value = assetGuid;
}

function CallAssetSearch() {
    document.getElementById("btnAssetSearch").click();

}

function ClearAssetSearch() {
    document.getElementById("btnClearAssetSearch").click();
}

function CallAssetRefreshButton() {
    document.getElementById("btnAssetRefresh").click();
    document.getElementById("btnClearAssetSearch").click();
}

function SetCurrencyDetails(currency, currencyGuid) {

    document.getElementById("txtCurrency").value = currency;
    document.getElementById("txtCurrencyGuid").value = currencyGuid;
}

function CallCurrencySearch() {
    document.getElementById("btnCurrencySearch").click();

}

function ClearCurrencySearch() {
    document.getElementById("btnClearCurrencySearch").click();
}

function CallCurrencyRefreshButton() {
    document.getElementById("btnCurrencyRefresh").click();
    document.getElementById("btnClearCurrencySearch").click();
}
function ClearForm() {
    document.getElementById('txtAssetDisposal').value = '';
    document.getElementById('txtAssetDisposalGuid').value = '';
    document.getElementById('txtQuantity').value = '';
    document.getElementById('txtCost').value = '';
    document.getElementById('txtPercent').value = '';
    document.getElementById('txtCashProceeds').value = '';
    document.getElementById('txtNonCashProceeds').value = '';
    document.getElementById('txtExpensesOfSales').value = '';
    document.getElementById('txtOriginatingAmount').value = '';
    
    return false;
}


function SetAssetDisposalDetails(assetDisposalCode, assetDisposalGuid) {

    document.getElementById("txtAssetDisposal").value = assetDisposalCode;
    document.getElementById("txtAssetDisposalGuid").value = assetDisposalGuid;

}

function CallAssetDisposalSearch() {
    document.getElementById("btnAssetDisposalSearch").click();

}

function ClearAssetDisposalSearch() {
    document.getElementById("btnClearAssetDisposalSearch").click();
}

function CallAssetDisposalRefreshButton() {
    document.getElementById("btnAssetDisposalRefresh").click();
    document.getElementById("btnClearAssetDisposalSearch").click();
}

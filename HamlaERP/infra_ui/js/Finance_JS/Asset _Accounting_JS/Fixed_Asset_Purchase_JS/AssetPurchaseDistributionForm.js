function ClearForm() {
   // document.getElementById('txtGLAccount').value = '';
   // document.getElementById('txtGLAccountGuid').value = '';
    document.getElementById('txtGLAccount').value = '';
    document.getElementById('txtGLAccountGuid').value = '';
    document.getElementById('ddlopt_GLAccountType').selectedIndex = 0;
    document.getElementById('txtDescription').value = '';
    document.getElementById('txtDistributionReference').value = '';
    document.getElementById('txtDebit').value = '';
    document.getElementById('txtCredit').value = '';
    return false;
}


function SetGLAccountDetails(accountNumber, gLAccountGuid) {

    document.getElementById("txtGLAccount").value = accountNumber
    document.getElementById("txtGLAccountGuid").value = gLAccountGuid;

}

function CallGLAccountSearch() {
    document.getElementById("btnGLAccountSearch").click();

}

function ClearGLAccountSearch() {
    document.getElementById("btnClearGLAccountSearch").click();
}

function CallGLAccountRefreshButton() {
    document.getElementById("btnGLAccountRefresh").click();
    document.getElementById("btnClearGLAccountSearch").click();
}

function SetAssetPurchaseDetails(accountNumber, AssetPurchaseGuid) {

    document.getElementById("txtAssetPurchase").value = accountNumber
    document.getElementById("txtAssetPurchaseGuid").value = AssetPurchaseGuid;

}

function CallAssetPurchaseSearch() {
    document.getElementById("btnAssetPurchaseSearch").click();

}

function ClearAssetPurchaseSearch() {
    document.getElementById("btnClearAssetPurchaseSearch").click();
}

function CallAssetPurchaseRefreshButton() {
    document.getElementById("btnAssetPurchaseRefresh").click();
    document.getElementById("btnClearAssetPurchaseSearch").click();
}

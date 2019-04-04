function ClearForm() {
    document.getElementById('txtAssetBookGroupSetupCode').value = '';
    document.getElementById('txtAssetGroup').value = '';
    document.getElementById('txtAssetGroupGuid').value = '';
    document.getElementById('txtAssetBookSetup').value = '';
    document.getElementById('txtAssetBookSetupGuid').value = '';
    document.getElementById('ddlOpt_DepreciationMethod').value = selectedIndex = 0;
    document.getElementById('ddlOpt_AveragingConvention').value = selectedIndex = 0;
    document.getElementById('txtOriginalLifeYear').value = '';
    document.getElementById('txtOriginalLifeDay').value = '';
    document.getElementById('txtScrapValue').value = '';
    return false;
}


function SetAssetGroupDetails(assetGroup, assetGroupGuid) {
    document.getElementById("txtAssetGroup").value = assetGroup;
    document.getElementById("txtAssetGroupGuid").value = assetGroupGuid;
}

function CallAssetGroupSearch() {
    document.getElementById("btnAssetGroupSearch").click();

}

function ClearAssetGroupSearch() {
    document.getElementById("btnClearAssetGroupSearch").click();
}

function CallAssetGroupRefreshButton() {
    document.getElementById("btnAssetGroupRefresh").click();
    document.getElementById("btnClearAssetGroupSearch").click();
}


function SetAssetBookSetupDetails(assetBookSetup, assetBookSetupGuid) {
    document.getElementById("txtAssetBookSetup").value = assetBookSetup;
    document.getElementById("txtAssetBookSetupGuid").value = assetBookSetupGuid;
}

function CallAssetBookSetupSearch() {
    document.getElementById("btnAssetBookSetupSearch").click();

}

function ClearAssetBookSetupSearch() {
  
    document.getElementById("btnClearAssetBookSetupSearch").click();
}

function CallAssetBookSetupRefreshButton() {
    document.getElementById("btnAssetBookSetupRefresh").click();
    document.getElementById("btnClearAssetBookSetupSearch").click();
}

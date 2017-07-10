function ClearForm() {
    document.getElementById('txtAsset').value = '';
    document.getElementById('txtAssetGuid').value = '';
    document.getElementById('txtAssetBookCode').value = '';
    document.getElementById('txtPlaceInServiceDate').value = ''; 
    document.getElementById('txtDepreciatedDueDate').value = '';
    document.getElementById('txtBeginYearCost').value = '';
    document.getElementById('txtCostBasis').value = '';
    document.getElementById('txtScrapValue').value = '';
    document.getElementById('txtYearlyDepreciationRate').value = ''; 
    document.getElementById('txtCurrentDepreciation').value = '';
    document.getElementById('txtNetBookValue').value = '';
    document.getElementById('ddlopt_DepreciationMethod').selectedIndex = 0;
    document.getElementById('ddlopt_AveragingConvention').selectedIndex = 0;
    document.getElementById('chkFullDepreciationFlag').checked = false;
    document.getElementById('txtYearlyDepreciationRate').value = ''; 
    document.getElementById('ddlopt_Status').selectedIndex = 0;
    document.getElementById('txtOriginalLifeYear').value = '';
    document.getElementById('txtOriginalLifeDay').value = '';
  
    return false;
}


function SetAssetDetails(accountNumber, AssetGuid) {

    document.getElementById("txtAsset").value = accountNumber
    document.getElementById("txtAssetGuid").value = AssetGuid;

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

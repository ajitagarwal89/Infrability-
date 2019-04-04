function ClearForm() {
    document.getElementById('txtAccountCode ').value = '';
    document.getElementById('txtDescription').value = '';
    document.getElementById('ddlOpt_AccountType').value = selectedIndex = 0;
    document.getElementById('txtDepreciationExpense').value = '';
    document.getElementById('txtDepreciationExpenseGuid').value = '';
    document.getElementById('txtAccumulatedDepreciation').value = '';
    document.getElementById('txtAccumulatedDepreciationGuid').value = '';
    document.getElementById('txtPriorYearDepreciation').value = '';
    document.getElementById('txtPriorYearDepreciationGuid').value = '';
    document.getElementById('txtAssetCost').value = '';
    document.getElementById('txtAssetCostGuid').value = '';
    document.getElementById('txtClearing').value = '';
    document.getElementById('txtClearingGuid').value = '';

    return false;
}

function SetDepreciationExpenseDetails(depreciationExpense, depreciationExpenseGuid) {
    document.getElementById("txtDepreciationExpense").value = depreciationExpense;
    document.getElementById("txtDepreciationExpenseGuid").value = depreciationExpenseGuid;
}

function CallDepreciationExpenseSearch() {
    document.getElementById("btnDepreciationExpenseSearch").click();

}

function ClearDepreciationExpenseSearch() {
    document.getElementById("btnClearDepreciationExpenseSearch").click();
}

function CallDepreciationExpenseRefreshButton() {
    document.getElementById("btnDepreciationExpenseRefresh").click();
    document.getElementById("btnClearDepreciationExpenseSearch").click();
}



function SetAccumulatedDepreciationDetails(depreciationReserve, depreciationReserveGuid) {

    document.getElementById("txtAccumulatedDepreciation").value = depreciationReserve;
    document.getElementById("txtAccumulatedDepreciationGuid").value = depreciationReserveGuid;

}

function CallAccumulatedDepreciationSearch() {
    document.getElementById("btnAccumulatedDepreciationSearch").click();

}

function ClearAccumulatedDepreciationSearch() {
    document.getElementById("btnClearAccumulatedDepreciationSearch").click();
}

function CallAccumulatedDepreciationRefreshButton() {
    document.getElementById("btnAccumulatedDepreciationRefresh").click();
    document.getElementById("btnClearAccumulatedDepreciationSearch").click();
}


function SetPriorYearDepreciationDetails(priorYearDepreciation, priorYearDepreciationGuid) {
    document.getElementById("txtPriorYearDepreciation").value = priorYearDepreciation;
    document.getElementById("txtPriorYearDepreciationGuid").value = priorYearDepreciationGuid;
}

function CallPriorYearDepreciationSearch() {
    document.getElementById("btnPriorYearDepreciationSearch").click();
}

function ClearPriorYearDepreciationSearch() {
    document.getElementById("btnClearPriorYearDepreciationSearch").click();
}

function CallPriorYearDepreciationRefreshButton() {
    document.getElementById("btnPriorYearDepreciationRefresh").click();
    document.getElementById("btnClearPriorYearDepreciationSearch").click();
}


function SetAssetCostDetails(assetCost, assetCostGuid) {
    document.getElementById("txtAssetCost").value = assetCost;
    document.getElementById("txtAssetCostGuid").value = assetCostGuid;
}

function CallAssetCostSearch() {
    document.getElementById("btnAssetCostSearch").click();

}

function ClearAssetCostSearch() {
    document.getElementById("btnClearAssetCostSearch").click();
}

function CallAssetCostRefreshButton() {
    document.getElementById("btnAssetCostRefresh").click();
    document.getElementById("btnClearAssetCostSearch").click();
}


function SetClearingDetails(clearing, clearingGuid) {

    document.getElementById("txtClearing").value = clearing;
    document.getElementById("txtClearingGuid").value = clearingGuid;
}

function CallClearingSearch() {
    document.getElementById("btnClearingSearch").click();

}

function ClearClearingSearch() {
    document.getElementById("btnClearClearingSearch").click();
}

function CallClearingRefreshButton() {
    document.getElementById("btnClearingRefresh").click();
    document.getElementById("btnClearClearingSearch").click();
}


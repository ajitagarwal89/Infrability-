function ClearForm() {
    document.getElementById('txtAssetCode').value = '';
    document.getElementById('txtDescription').value = '';
    document.getElementById('txtExtendedDescription').value = '';
    document.getElementById('txtShortName').value = '';
    document.getElementById('txtAssetGroup').value = '';
    document.getElementById('txtAssetGroupGuid').value = '';
    document.getElementById('ddlOpt_opt_Type').value = selectedIndex = 0;    
    document.getElementById('txtAssetAndGroupAccount').value = '';
    document.getElementById('txtAssetAndGroupAccountGuid').value = '';
    document.getElementById('txtAcquisitionDate').value = '';
    document.getElementById('txtAcquisitionCost').value = '';
    document.getElementById('txtCurrency').value = '';
    document.getElementById('txtCurrencyGuid').value = '';
    document.getElementById('txtLocation').value = '';
    document.getElementById('txtLocationGuid').value = '';
    document.getElementById('txtPhysicalLocation').value = '';
    document.getElementById('txtPhysicalLocationGuid').value = '';
    document.getElementById('txtAssetBarcode').value = '';
    document.getElementById('txtStructure').value = '';
    document.getElementById('txtStructureGuid').value = '';
    document.getElementById('txtEmployee').value = '';
    document.getElementById('txtEmployeeGuid').value = '';
    document.getElementById('txtManufacturerName').value = '';
    document.getElementById('txtQuantity').value = '';
    document.getElementById('txtLastMaintenanceDate').value = '';   
    document.getElementById('txtDateAdded').value = '';
    document.getElementById('ddlopt_Status').selectedIndex = 0;
    document.getElementById('txtSerialNumber').value = '';
    document.getElementById('txtModalNumber').value = '';
    document.getElementById('txtWarrantyDate').value = '';
    document.getElementById("txtDepreciationExpense").value = '';
    document.getElementById("txtDepreciationExpenseGuid").value = '';
    document.getElementById("txtAccumulatedDepreciation").value = '';
    document.getElementById("txtAccumulatedDepreciationGuid").value = '';
    document.getElementById("txtPriorYearDepreciation").value = '';
    document.getElementById("txtPriorYearDepreciationGuid").value = '';
    document.getElementById("txtAssetCost").value = '';
    document.getElementById("txtAssetCostGuid").value = '';
    document.getElementById("txtClearing").value = '';
    document.getElementById("txtClearingGuid").value = '';

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


function SetAssetAndGroupAccountDetails(assetAndGroupAccount, assetAndGroupAccountGuid) {

    document.getElementById("txtAssetAndGroupAccount").value = assetAndGroupAccount;
    document.getElementById("txtAssetAndGroupAccountGuid").value = assetAndGroupAccountGuid;

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

function SetLocationDetails(location, locationGuid) {
    document.getElementById("txtLocation").value = location;
    document.getElementById("txtLocationGuid").value = locationGuid;
}

function CallLocationSearch() {
    document.getElementById("btnLocationSearch").click();

}

function ClearLocationSearch() {
    document.getElementById("btnCleaLocationSearch").click();
}

function CallLocationRefreshButton() {
    document.getElementById("btnLocationRefresh").click();
    document.getElementById("btnClearLocationSearch").click();
}

function SetPhysicalLocationDetails(physicalLocation, physicalLocationGuid) {
    document.getElementById("txtPhysicalLocation").value = physicalLocation;
    document.getElementById("txtPhysicalLocationGuid").value = physicalLocationGuid;
}

function CallPhysicalLocationSearch() {
    document.getElementById("btnPhysicalLocationSearch").click();

}

function ClearPhysicalLocationSearch() {
    document.getElementById("btnCleaPhysicalLocationSearch").click();
}

function CallPhysicalLocationRefreshButton() {
    document.getElementById("btnPhysicalLocationRefresh").click();
    document.getElementById("btnClearPhysicalLocationSearch").click();
}

function SetEmployeeDetails(employeeid, employeeGuid) {
    document.getElementById("txtEmployee").value = employeeid;
    document.getElementById("txtEmployeeGuid").value = employeeGuid;
}

function CallEmployeeSearch() {
    document.getElementById("btnEmployeeSearch").click();

}

function ClearEmployeeSearch() {
    document.getElementById("btnClearEmployeeSearch").click();
}

function CallEmployeeRefreshButton() {
    document.getElementById("btnEmployeeRefresh").click();
    document.getElementById("btnClearEmployeeSearch").click();
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


function SetStructureDetails(structure, structureGuid) {
 
    document.getElementById("txtStructure").value = structure;
    document.getElementById("txtStructureGuid").value = structureGuid;
}

function CallStructureSearch() {
     document.getElementById("btnStructureSearch").click();

}

function ClearStructureSearch() {
  
    document.getElementById("btnClearStructureSearch").click();
}

function CallStructureRefreshButton()
{
    document.getElementById("btnStructureRefresh").click();
    document.getElementById("btnClearStructureSearch").click();
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



function SetAccumulatedDepreciationDetails(accumulatedDepreciation, accumulatedDepreciationGuid) {

    document.getElementById("txtAccumulatedDepreciation").value = accumulatedDepreciation;
    document.getElementById("txtAccumulatedDepreciationGuid").value = accumulatedDepreciationGuid;

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


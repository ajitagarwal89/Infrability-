function ClearForm() {
  
    document.getElementById('rdbYes').checked = false;
    document.getElementById('rdbNo').checked = false;
    document.getElementById('chkunposteddocuments').checked = false;
    document.getElementById('chkTrialbalance').checked = false;
    document.getElementById('rdbAgeingDueDate').checked = false;
    document.getElementById('rdbAgeingDocumentDate').checked = false;
    document.getElementById('rdbApplyByDocumentDate').checked = false;
    document.getElementById('rdbApplyByDuedate').checked = false;
    document.getElementById('ddlSummaryView').selectedIndex = 0;
    document.getElementById('txtvendorHold').value = '';
    document.getElementById('txtInvoiceamount').value = '';
    document.getElementById('txtWriteOffAmount').value = '';
    document.getElementById('txtInvoiceDescription').value = '';
    document.getElementById('txtInvoiceCode').value = '';
    document.getElementById('txtReturnDescription').value = '';
    document.getElementById('txtReturnCode').value = '';
    document.getElementById('txtCreditMemoDescription').value = '';
    document.getElementById('txtCreditMemoCode').value = '';
    document.getElementById('txtPaymentDescription').value = '';
    document.getElementById('txtPaymentCode').value = '';
    document.getElementById('txtGLAccountId_CashGuid').value = '';
    document.getElementById('txtGLAccountId_Cash').value = '';
    document.getElementById('txtGLAccountId_AccountReceivableGuid').value = '';
    document.getElementById('txtGLAccountId_AccountReceivable').value = '';
    document.getElementById('txtGLAccountId_SalesGuid').value = '';
    document.getElementById('txtGLAccountId_Sales').value = '';
    document.getElementById('txtGLAccountId_CostOfSalesGuid').value = '';
    document.getElementById('txtGLAccountId_CostOfSales').value = '';
    document.getElementById('txtGLAccountId_InventoryGuid').value = '';
    document.getElementById('txtGLAccountId_Inventory').value = '';
    document.getElementById('txtGLAccountId_AccuralDifferedA_CGuid').value = '';
    document.getElementById('txtGLAccountId_AccuralDifferedA_C').value = '';
   
    
    return false;
}
function SetChequeBookDetails(countryName, countryGuid) {
    document.getElementById("txtChequeBook").value = countryName;
    document.getElementById("txtChequeBookGuid").value = countryGuid;
}

function CallChequeBookSearch() {
    document.getElementById("btnChequeBookSearch").click();

}

function ClearChequeBookSearch() {
    document.getElementById("btnClearChequeBookSearch").click();
}

function CallChequeBookRefreshButton() {
    document.getElementById("btnChequeBookRefresh").click();
    document.getElementById("btnClearChequeBookSearch").click();
}
function setPayableSetupGroupDetails(payableSetupGroup, payableSetupGroupGuid) {

    document.getElementById("txtPayableSetupGroup").value = payableSetupGroup;

    document.getElementById("txtPayableSetupGroupGuid").value = payableSetupGroupGuid;

}

function CallPayableGroupSearch() {

    document.getElementById("btnPayableSetupGroupSearch").click();

}

function ClearPayableGroupSearch() {
    document.getElementById("btnClearPayableSetupGroupSearch").click();
}

function CallPayableGroupRefreshButton() {

    document.getElementById("btnPayableSetupGroupRefresh").click();
    document.getElementById("btnClearPayableSetupGroupSearch").click();
}
function SetCashDetails(cash, cashGuid) {
    document.getElementById("txtGLAccountId_Cash").value = cash;
    document.getElementById("txtGLAccountId_CashGuid").value = cashGuid;
}

function CallCashSearch() {
    document.getElementById("btnAccountCashSearch").click();
}

function ClearCashSearch() {
    document.getElementById("btnClearAccountCashSearch").click();
}

function CallCashRefreshButton() {
    document.getElementById("btnGLAccountId_CashRefresh").click();
    document.getElementById("btnClearAccountCashSearch").click();
}


function SetAccountReceivableDetails(accountReceivable, accountReceivableGuid) {
    document.getElementById("txtGLAccountId_AccountReceivable").value = accountReceivable;
    document.getElementById("txtGLAccountId_AccountReceivableGuid").value = accountReceivableGuid;
}

function CallAccountReceivableSearch() {
    document.getElementById("btnAccountReceivableSearch").click();

}

function ClearAccountReceivableSearch() {
    document.getElementById("btnClearAccountReceivableSearch").click();
}

function CallAccountReceivableRefreshButton() {

    document.getElementById("btnAccountCashRefresh").click();
    document.getElementById("btnClearAccountReceivableSearch").click();
}


function SetSalesDetails(sales, salesGuid) {
    document.getElementById("txtGLAccountId_Sales").value = sales;
    document.getElementById("txtGLAccountId_SalesGuid").value = salesGuid;
}

function CallSalesSearch() {
    document.getElementById("btnSalesSearch").click();

}

function ClearSalesSearch() {
    document.getElementById("btnClearSalesSearch").click();
}

function CallSalesRefreshButton() {

    document.getElementById("btnSalesRefresh").click();
    document.getElementById("btnClearSalesSearch").click();
}


function SetCostOfSalesDetails(costOfSales, costOfSalesGuid) {
    document.getElementById("txtGLAccountId_CostOfSales").value = costOfSales;
    document.getElementById("txtGLAccountId_CostOfSalesGuid").value = costOfSalesGuid;
}

function CallCostOfSalesSearch() {
    document.getElementById("btnCostOfSalesSearch").click();

}

function ClearCostOfSalesSearch() {
    document.getElementById("btnClearCostOfSalesSearch").click();
}

function CallCostOfSalesRefreshButton() {
    document.getElementById("btnCostOfSalesRefresh").click();
    document.getElementById("btnClearCostOfSalesSearch").click();
}



function SetInventoryDetails(inventory, inventoryGuid) {
    document.getElementById("txtGLAccountId_Inventory").value = inventory;
    document.getElementById("txtGLAccountId_InventoryGuid").value = inventoryGuid;
}

function CallInventorySearch() {
    document.getElementById("btnInventorySearch").click();

}

function ClearInventorySearch() {
    document.getElementById("btnClearInventorySearch").click();
}

function CallInventoryRefreshButton() {

    document.getElementById("btnInventoryRefresh").click();
    document.getElementById("btnClearInventorySearch").click();
}


function SetAccuralDifferedA_CDetails(accuralDifferedA_C, accuralDifferedA_CGuid) {
    document.getElementById("txtGLAccountId_AccuralDifferedA_C").value = accuralDifferedA_C;
    document.getElementById("txtGLAccountId_AccuralDifferedA_CGuid").value = accuralDifferedA_CGuid;
}

function CallAccuralDifferedA_CSearch() {
    document.getElementById("btnAccuralDifferedA_CSearch").click();

}

function ClearAccuralDifferedA_CSearch() {
    document.getElementById("btnClearAccuralDifferedA_CSearch").click();
}

function CallAccuralDifferedA_CRefreshButton() {
    document.getElementById("btnAccuralDifferedA_CRefresh").click();
    document.getElementById("btnClearAccuralDifferedA_CSearch").click();
}
function setPayableSetupAndGroupAccountDetails(payableSetupAndGroupAccount, payableSetupAndGroupAccountGUID) {

    document.getElementById("txtPayableSetupAndGroupAccount").value = payableSetupAndGroupAccount;

    document.getElementById("txtPayableSetupAndGroupAccountGUID").value = payableSetupAndGroupAccountGUID;

}

function CallPayableSetupAndGroupAccountSearch() {

    document.getElementById("btnPayableSetupAndGroupAccountSearch").click();

}

function ClearPayableSetupAndGroupAccountSearch() {
    document.getElementById("btnClearPayableSetupAndGroupAccountSearch").click();
}

function CallPayableSetupAndGroupAccountRefreshButton() {

    document.getElementById("btnPayableSetupAndGroupAccountRefresh").click();
    document.getElementById("btnClearPayableSetupAndGroupAccountSearch").click();
}

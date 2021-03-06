﻿function ClearForm() {
    document.getElementById('txtCustomerGroup').value = '';
    document.getElementById('txtChequeBook').value = '';
    document.getElementById('txtGLAccountId_Cash').value = '';
    document.getElementById('txtAccountReceivable').value = '';
    document.getElementById('txtSales').value = '';
    document.getElementById('txtCostOfSales').value = '';
    document.getElementById('txtInventory').value = '';
    document.getElementById('txtAccuralDifferedA_C').value = '';
    document.getElementById("chkPaymentMode").checked = false;
    return false;
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


function SetChequeBookDetails(chequeBookName, chequeBookGuid) {
    document.getElementById("txtChequeBook").value = chequeBookName;
    document.getElementById("txtChequeBookGuid").value = chequeBookGuid;
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
    document.getElementById("btnAccountCashRefresh").click();
    document.getElementById("btnClearAccountCashSearch").click();
}


function SetAccountReceivableDetails(accountReceivable, accountReceivableGuid) {
    document.getElementById("txtAccountReceivable").value = accountReceivable;
    document.getElementById("txtAccountReceivableGuid").value = accountReceivableGuid;
}

function CallAccountReceivableSearch() {
    document.getElementById("btnAccountReceivableSearch").click();

}

function ClearAccountReceivableSearch() {
    document.getElementById("btnClearAccountReceivableSearch").click();
}

function CallAccountReceivableRefreshButton() {

    document.getElementById("btnAccountReceivableRefresh").click();
    document.getElementById("btnClearAccountReceivableSearch").click();
}


function SetSalesDetails(sales, salesGuid) {
    document.getElementById("txtSales").value = sales;
    document.getElementById("txtSalesGuid").value = salesGuid;
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
    document.getElementById("txtCostOfSales").value = costOfSales;
    document.getElementById("txtCostOfSalesGuid").value = costOfSalesGuid;
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
    document.getElementById("txtInventory").value = inventory;
    document.getElementById("txtInventoryGuid").value = inventoryGuid;
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
    document.getElementById("txtAccuralDifferedA_C").value = accuralDifferedA_C;
    document.getElementById("txtAccuralDifferedA_CGuid").value = accuralDifferedA_CGuid;
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

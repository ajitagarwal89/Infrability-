function ClearForm() {
   
    document.getElementById("rdbDueDate").checked = true;
 
    document.getElementById("rdbDocumentDate").checked = false;
  
    document.getElementById("rdbDocumentDate1").checked = true;
   
    document.getElementById("rdbDuedate1").checked = false;
 
    document.getElementById("txtChequeBook").value = '';
 
    document.getElementById("txtChequeBookGuid").value = '';

    document.getElementById('ddlDocumentFormat').selectedIndex == 0;
 
    document.getElementById('ddlSummaryView').selectedIndex == 0;

    document.getElementById('txtExceedCredit').value = '';
   
    document.getElementById('txtRemoveCustomerHold').value = '';
   
    document.getElementById('txtWriteOffAmount').value = '';
   
    document.getElementById('chkTrialbalance').checked = false;
    
    document.getElementById('chkunposteddocuments').checked = false;
   
    document.getElementById('txtSaleInvoiceCode').value = '';
 
    document.getElementById('txtSaleInvoiceDescription').value = '';
    
    document.getElementById('txtDebitMemoCode').value = '';
   
    document.getElementById('txtDebitMemoDescription').value = '';
    
    document.getElementById('txtCreditMemoCode').value = '';
    
    document.getElementById('txtCreditMemoDescription').value = '';
    
    document.getElementById('txtReturnCode').value = '';
   
    document.getElementById('txtReturnDescription').value = '';
   
    document.getElementById('txtCashReceiptCode').value = '';
    
    document.getElementById('txtCashReceiptDescription').value = '';
   
    document.getElementById('txtStatementsPrintedDate').value = '';
    
    document.getElementById('txtOpenitemAccountsAgedDate').value = '';

    document.getElementById('txtBalanceForwardAccountsAgedDate').value = '';
   
    document.getElementById('chkSale').checked = false;
    
    document.getElementById('chkDiscount').checked = false;
   
    document.getElementById('chkFreight').checked = false;
    document.getElementById('txtRecievableSetupGroup').value = '';
    document.getElementById('txtRecievableSetupGroupGuid').value = '';
    document.getElementById('txtReceivableSetupAndGroupAccount').value = '';
    document.getElementById('txtReceivableSetupAndGroupAccountGuid').value = '';
    document.getElementById('txtGLAccountId_Cash').value = '';
    document.getElementById('txtGLAccountId_CashGuid').value = '';
    document.getElementById('txtGLAccountId_AccountReceivable').value = '';
    document.getElementById('txtGLAccountId_AccountReceivableGuid').value = '';
    document.getElementById('txtGLAccountId_Sales').value = '';
    document.getElementById('txtGLAccountId_SalesGuid').value = '';
    document.getElementById('txtGLAccountId_CostOfSales').value = '';
    document.getElementById('txtGLAccountId_CostOfSalesGuid').value = '';
    document.getElementById('txtGLAccountId_Inventory').value = '';
    document.getElementById('txtGLAccountId_InventoryGuid').value = '';
    document.getElementById('txtGLAccountId_AccuralDifferedA_C').value = '';
    document.getElementById('txtGLAccountId_AccuralDifferedA_CGuid').value = '';
  
    return false;
}

function SetChequeBookDetails(chequeBook, chequeBookGuid) {

    document.getElementById("txtChequeBook").value = chequeBook;
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


function SetRecievableSetupDetails(receivableSetup, receivableSetupGuid) {
   
    document.getElementById("txtReceivableSetup").value = receivableSetup;
    document.getElementById("txtReceivableSetupGuid").value = receivableSetupGuid;
}

function CallRecievableSetupSearch() {

    document.getElementById("btnRecievableSetupSearch").click();

}

function ClearRecievableSetupSearch() {

    document.getElementById("btnClearRecievableSetupSearch").click();
}

function CallReceivableSetupRefreshButton() {

    document.getElementById("btnRecievableSetupRefresh").click();
    document.getElementById("btnClearRecievableSetupSearch").click();
}


function SetRecievableSetupGroupDetails(recievableSetupGroup, recievableSetupGroupGuid) {

    document.getElementById("txtRecievableSetupGroup").value = recievableSetupGroup;
    document.getElementById("txtRecievableSetupGroupGuid").value = recievableSetupGroupGuid;
}

function CallRecievableSetupGroupSearch() {

    document.getElementById("btnRecievableSetupGroupSearch").click();

}

function ClearRecievableSetupGroupSearch() {

    document.getElementById("btnClearRecievableSetupGroupSearch").click();
}

function CallRecievableSetupGroupRefreshButton() {

    document.getElementById("btnRecievableSetupGroupRefresh").click();
    document.getElementById("btnClearRecievableSetupGroupSearch").click();
}

function SetReceivableSetupAndGroupAccountDetails(receivableSetupAndGroupAccount, receivableSetupAndGroupAccountGuid) {

    document.getElementById("txtReceivableSetupAndGroupAccount").value = receivableSetupAndGroupAccount;
    document.getElementById("txtReceivableSetupAndGroupAccountGuid").value = receivableSetupAndGroupAccountGuid;
}

function CallReceivableSetupAndGroupAccountSearch() {

    document.getElementById("btnReceivableSetupAndGroupAccountSearch").click();

}

function ClearReceivableSetupAndGroupAccountSearch() {

    document.getElementById("btnClearReceivableSetupAndGroupAccountSearch").click();
}

function CallReceivableSetupAndGroupAccountRefreshButton() {

    document.getElementById("btnReceivableSetupAndGroupAccountRefresh").click();
    document.getElementById("btnClearReceivableSetupAndGroupAccountSearch").click();
}

function SetChequeBookDetails(chequeBook, chequeBookGuid) {

    document.getElementById("txtChequeBook").value = chequeBook;
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

//GLAccountId_Cash

function SetGLAccountId_CashDetails(GLAccountId_Cash, GLAccountId_CashGuid) {
    document.getElementById("txtGLAccountId_Cash").value = GLAccountId_Cash;
    document.getElementById("txtGLAccountId_CashGuid").value = GLAccountId_CashGuid;

}

function CallGLAccountId_CashSearch() {

    document.getElementById("btnGLAccountId_CashSearch").click();

}

function ClearGLAccountId_CashSearch() {

    document.getElementById("btnClearGLAccountId_CashSearch").click();
}

function CallGLAccountId_CashRefreshButton() {

    document.getElementById("btnGLAccountId_CashRefresh").click();
    document.getElementById("btnClearGLAccountId_CashSearch").click();
}
//GLAccountId_AccountReceivable

function SetGLAccountId_AccountReceivableDetails(GLAccountId_AccountReceivable, GLAccountId_AccountReceivableGuid) {

    document.getElementById("txtGLAccountId_AccountReceivable").value = GLAccountId_AccountReceivable;
    document.getElementById("txtGLAccountId_AccountReceivableGuid").value = GLAccountId_AccountReceivableGuid;

}

function CallGLAccountId_AccountReceivablehSearch() {

    document.getElementById("btnGLAccountId_AccountReceivableSearch").click();

}

function CallAccountReceivableRefreshButton() {

    document.getElementById("btnGLAccountId_AccountReceivableRefresh").click();
    document.getElementById("btnClearGLAccountId_AccountReceivableSearch").click();
}
function ClearGLAccountId_AccountReceivableSearch() {

    document.getElementById("btnGLAccountId_AccountReceivableSearch").click();
}

function CallGLAccountId_AccountReceivableRefreshButton() {

    document.getElementById("btnGLAccountId_AccountReceivableRefresh").click();
    document.getElementById("btnClearGLAccountId_AccountReceivableSearch").click();
}

//GLAccountId_Sales

function SetGLAccountId_SalesDetails(GLAccountId_Sales, GLAccountId_SalesGuid) {

    document.getElementById("txtGLAccountId_Sales").value = GLAccountId_Sales;
    document.getElementById("txtGLAccountId_SalesGuid").value = GLAccountId_SalesGuid;

}

function CallGLAccountId_SalesSearch() {

    document.getElementById("btnGLAccountId_AccountReceivableSearch").click();

}

function ClearGLAccountId_SalesSearch() {

    document.getElementById("btnGLAccountId_SalesSearch").click();
}

function CallSalesRefreshButton() {

    document.getElementById("btnGLAccountId_SalesRefresh").click();
    document.getElementById("btnClearGLAccountId_SalesSearch").click();
}
//GLAccountId_CostOfSales


function SetGLAccountId_CostOfSalesDetails(GLAccountId_CostOfSales, GLAccountId_CostOfSalesGuid) {

    document.getElementById("txtGLAccountId_CostOfSales").value = GLAccountId_CostOfSales;
    document.getElementById("txtGLAccountId_CostOfSalesGuid").value = GLAccountId_CostOfSalesGuid;

}

function CallGLAccountId_CostOfSalesSearch() {

    document.getElementById("btnGLAccountId_CostOfSalesSearch").click();

}

function ClearGLAccountId_CostOfSalesSearch() {

    document.getElementById("btnGLAccountId_CostOfSalesSearch").click();
}

function CallCostOfSalesRefreshButton() {

    document.getElementById("btnGLAccountId_CostOfSalesRefresh").click();
    document.getElementById("btnClearGLAccountId_CostOfSalesSearch").click();
}
//GLAccountId_Inventory


function SetGLAccountId_InventoryDetails(GLAccountId_Inventory, GLAccountId_InventoryGuid) {

    document.getElementById("txtGLAccountId_Inventory").value = GLAccountId_Inventory;
    document.getElementById("txtGLAccountId_InventoryGuid").value = GLAccountId_InventoryGuid;

}

function CallGLAccountId_InventorySearch() {

    document.getElementById("btnGLAccountId_InventorySearch").click();

}

function ClearGLAccountId_InventorySearch() {

    document.getElementById("btnGLAccountId_InventorySearch").click();
}

function CallInventoryRefreshButton() {

    document.getElementById("btnGLAccountId_InventoryRefresh").click();
    document.getElementById("btnClearGLAccountId_InventorySearch").click();
}

//GLAccountId_AccuralDifferedA_C



function SetGLAccountId_AccuralDifferedA_CDetails(GLAccountId_AccuralDifferedA_C, GLAccountId_AccuralDifferedA_CGuid) {

    document.getElementById("txtGLAccountId_AccuralDifferedA_C").value = GLAccountId_AccuralDifferedA_C;
    document.getElementById("txtGLAccountId_AccuralDifferedA_CGuid").value = GLAccountId_AccuralDifferedA_CGuid;

}

function CallGLAccountId_AccuralDifferedA_CSearch() {

    document.getElementById("btnGLAccountId_AccuralDifferedA_CSearch").click();

}

function ClearGLAccountId_AccuralDifferedA_CSearch() {

    document.getElementById("btnGLAccountId_AccuralDifferedA_CSearch").click();
}

function CallAccuralDifferedA_CRefreshButton() {

    document.getElementById("btnGLAccountId_AccuralDifferedA_CRefresh").click();
    document.getElementById("btnClearGLAccountId_AccuralDifferedA_CSearch").click();
}
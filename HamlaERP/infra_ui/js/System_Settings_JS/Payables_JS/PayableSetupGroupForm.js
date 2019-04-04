function ClearForm() {
   
    document.getElementById('chkCalenderYear').checked = false;
    document.getElementById('chkTransaction').checked = false;
    document.getElementById('chkFiscalYear').checked = false;
    document.getElementById('chkDistribution').checked = false;
    document.getElementById('chkDefault').checked = false;
    document.getElementById('txtDescription').value = '';
    document.getElementById('txtPaymentPriority').value = '';
    document.getElementById('txtMinimumOrder').value = '';
    document.getElementById('txtTradeDiscount').value = '';  
    document.getElementById('ddlMinimumPayment').selectedIndex = 0;
    document.getElementById('ddlMaxInvoiceAmt').selectedIndex = 0;
    document.getElementById('ddlCreditLimit').selectedIndex = 0;
    document.getElementById('ddlWriteOff').selectedIndex = 0;
    document.getElementById('ddlSummaryView').selectedIndex = 0;
    document.getElementById('txtPayableSetup').value = '';
    document.getElementById('txtPayableSetupGuid').value = '';
    document.getElementById('txtGroupID').value = '';
    document.getElementById('txtGroupIDGuid').value = '';
    document.getElementById('txtCurrency').value = '';
    document.getElementById('txtCurrencyGuid').value = '';
    document.getElementById('txtPaymentTerms').value = '';
    document.getElementById('txtPaymentTermsGuid').value = '';
   
    
    return false;
}

function SetPayableSetupGroupDetails(Description, GroupGuid) {
    
    document.getElementById("txtGroupID").value = Description;
    document.getElementById("txtGroupIDGuid").value = GroupGuid;
}

function CallPayableSetupGroupSearch() {
    document.getElementById("btnPayableSetupGroupSearch").click();

}

function ClearPayableSetupGroupSearch() {
    document.getElementById("btnClearPayableSetupGroupSearch").click();
}

function CallPayableSetupGroupRefreshButton() {
   
    document.getElementById("btnPayableSetupGroupRefresh").click();
    document.getElementById("btnClearPayableSetupGroupSearch").click();
}
function SetPayableSetupDetails(chequeBookName, chequeBookGuid) {
    document.getElementById("txtPayableSetup").value = chequeBookName;
    document.getElementById("txtPayableSetupGuid").value = chequeBookGuid;
}

function CallPayableSetupSearch() {
    document.getElementById("btnPayableSetupSearch").click();
}

function ClearPayableSetupSearch() {
    document.getElementById("btnClearPayableSetupSearch").click();
}

function CallPayableSetupRefreshButton() {
    document.getElementById("btnPayableSetupRefresh").click();
    document.getElementById("btnClearPayableSetupSearch").click();
}

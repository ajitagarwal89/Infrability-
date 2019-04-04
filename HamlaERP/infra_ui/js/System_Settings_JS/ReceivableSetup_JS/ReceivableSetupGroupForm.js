function ClearForm() {
   
    document.getElementById('txtReceivableSetupGroupId_Self').value = '';
   
    document.getElementById('txtReceivableSetupGroupId_SelfGuid').value = '';
    
    document.getElementById('txtReceivableSetup').value = '';
  
    document.getElementById('txtReceivableSetupGuid').value = '';

    document.getElementById('chkDefault').checked = false;

    document.getElementById('txtDescription').value = '';
   
    document.getElementById('txtPaymentTerms').value = '';
  
    document.getElementById('txtPaymentTermseGuid').value = '';
 
    document.getElementById('rdbOpenItem').checked = true;  
      
    document.getElementById('ddl_OptMinimumPayment').selectedIndex == 0;
   
    document.getElementById('txtMiniumPayment').value = '';
   
    document.getElementById('ddl_OptCreditLimit').selectedIndex == 0;
    
    document.getElementById('txtCreditLimit').value = '';
  
    document.getElementById('ddl_OptWriteOff').selectedIndex == 0;
    
    document.getElementById('txtWriteOff').value = '';
   
    document.getElementById('txtTradeDiscount').value = '';
 
    document.getElementById('ddlStatementCycle').selectedIndex == 0;
  
    document.getElementById('chkCalendarYear').checked = false;
  
    document.getElementById('chkFiscalYear').checked = false;
  
    document.getElementById('chkTransaction').checked = false;

    document.getElementById('chkDistribution').checked = false;
   
    return false;
}



function SetPaymentTermsDetails(paymentTerms, paymentTermseGuid) {
    document.getElementById("txtPaymentTerms").value = paymentTerms;
    document.getElementById("txtPaymentTermseGuid").value = paymentTermseGuid;
}

function CallPaymentTermsSearch() {
    document.getElementById("btnPaymentTermsSearch").click();

}

function ClearPaymentTermsSearch() {
    document.getElementById("btnClearPaymentTermsSearch").click();
}

function CallPaymentTermsRefreshButton() {

    document.getElementById("btnPaymentTermsRefresh").click();
    document.getElementById("btnClearPaymentTermsSearch").click();
}


function SetReceivableSetupDetails(receivableSetup, receivableSetupGuid) {
    document.getElementById("txtReceivableSetup").value = receivableSetup;
    document.getElementById("txtReceivableSetupGuid").value = receivableSetupGuid;
}

function CallReceivableSetupSearch() {

    document.getElementById("btnReceivableSetupSearch").click();

}

function ClearReceivableSetupSearch() {

    document.getElementById("btnClearReceivableSetupSearch").click();
}

function CallReceivableSetupRefreshButton() {

    document.getElementById("btnReceivableSetupRefresh").click();
    document.getElementById("btnClearReceivableSetupSearch").click();
}




function SetReceivableSetupGroupId_SelfDetails(customer, customerGuid) {
    document.getElementById("txtReceivableSetupGroupId_Self").value = customer;
    document.getElementById("txtReceivableSetupGroupId_SelfGuid").value = customerGuid;
}

function CallReceivableSetupGroupId_SelfSearch() {
    document.getElementById("btnReceivableSetupGroupId_SelfSearch").click();

}

function ClearReceivableSetupGroupId_SelfSearch() {
    document.getElementById("btnClearReceivableSetupGroupId_SelfSearch").click();
}

function CallReceivableSetupGroupId_SelfRefreshButton() {
    document.getElementById("btnReceivableSetupGroupId_SelfRefresh").click();
    document.getElementById("btnClearReceivableSetupGroupId_SelfSearch").click();
}
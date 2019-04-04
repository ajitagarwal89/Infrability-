function ClearForm() {
  
    document.getElementById('txtGLAccount').value = '';
    document.getElementById('txtFiscalPeriodSetup').value = '';

    return false;
}

function SetGLAccountDetails(glaccount, glaccountGuid) {
    document.getElementById("txtGLAccount").value = glaccount;
    document.getElementById("txtGLAccountGuid").value = glaccountGuid;
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



function SetFiscalPeriodSetupDetails(fiscalPeriodSetup, fiscalPeriodSetupGuid) {
    
    document.getElementById("txtFiscalPeriodSetup").value = fiscalPeriodSetup;
    document.getElementById("txtFiscalPeriodSetupGuid").value = fiscalPeriodSetupGuid;
}

function CallFiscalPeriodSetupSearch() {
  
    document.getElementById("btnFiscalPeriodSetupSearch").click();

}

function ClearFiscalPeriodSetupSearch() {
   
    document.getElementById("btnClearFiscalPeriodSetupSearch").click();
}

function CallFiscalPeriodSetupRefreshButton() {
   
    document.getElementById("btnFiscalPeriodSetupRefresh").click();
    document.getElementById("btnClearFiscalPeriodSetupSearch").click();
}


function ClearForm() {
    document.getElementById('txtGLAccountSummary').value = '';
    document.getElementById('txtFiscalPeriod').value = '';
    document.getElementById('txtPeriod').value = '';
    document.getElementById('txtPeriodName').value = '';
    document.getElementById('txtPeriodDate').value = '';
    document.getElementById('txtDebitAmount').value = '';
    document.getElementById('txtCreditAmount').value = '';
    document.getElementById('txtNetChargeAmount').value = '';
    document.getElementById('txtPeriodBalanceAmount').value = '';
    return false;
}

function SetGLAccountSummaryDetails(glaccountSummary, glaccountSummaryGuid) {
    document.getElementById("txtGLAccountSummary").value = glaccountSummary;
    document.getElementById("txtGLAccountSummaryGuid").value = glaccountSummaryGuid;
}

function CallGLAccountSummarySearch() {
    document.getElementById("btnGLAccountSummarySearch").click();

}

function ClearGLAccountSummarySearch() {
    document.getElementById("btnClearGLAccountSummarySearch").click();
}

function CallGLAccountSummaryRefreshButton() {
    document.getElementById("btnGLAccountSummaryRefresh").click();
    document.getElementById("btnClearGLAccountSummarySearch").click();
}



function SetFiscalPeriodDetails(fiscalPeriod, fiscalPeriodGuid) {
    document.getElementById("txtFiscalPeriod").value = fiscalPeriod;
    document.getElementById("txtFiscalPeriodGuid").value = fiscalPeriodGuid;
}

function CallFiscalPeriodSearch() {
    document.getElementById("btnFiscalPeriodSearch").click();

}

function ClearFiscalPeriodSearch() {
    document.getElementById("btnClearFiscalPeriodSearch").click();
}

function CallFiscalPeriodRefreshButton() {
    document.getElementById("btnFiscalPeriodRefresh").click();
    document.getElementById("btnClearFiscalPeriodSearch").click();
}

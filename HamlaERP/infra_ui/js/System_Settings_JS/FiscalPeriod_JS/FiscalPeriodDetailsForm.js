function ClearForm() {
    document.getElementById('txtFiscalPeriod').value = '';
    document.getElementById('txtPeriod').value = '';
    document.getElementById('txtPeriodName').value = '';
    document.getElementById('txtPeriodDate').value = '';
    document.getElementById('chckClosingFinancial').checked = false;
    document.getElementById('ChckClosingHR').checked = false;
    document.getElementById('ChckClosingProcurement').checked = false;


    return false;
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

function ClearForm() {
    document.getElementById('txtBudget').value = '';
    document.getElementById('txtBudgetGuid').value = '';
    document.getElementById('txtFiscalPeriod').value = '';
    document.getElementById('txtFiscalPeriodGuid').value = '';
    document.getElementById('txtPeriodDate').value = '';
    document.getElementById('txtPeriod').value = '';
    document.getElementById('txtPeriodName').value = '';
    document.getElementById('txtAmount').value = '';
    return false;
}


function SetBudgetDetails(budget, budgetGuid) {

    document.getElementById("txtBudget").value = budget;
    document.getElementById("txtBudgetGuid").value = budgetGuid;
}

function CallBudgetSearch() {
    document.getElementById("btnBudgetSearch").click();
}

function ClearBudgetSearch() {
    document.getElementById("btnClearBudgetSearch").click();
}

function CallBudgetRefreshButton() {
    document.getElementById("btnBudgetRefresh").click();
    document.getElementById("btnClearBudgetSearch").click();
}


function SetFiscalPeriodDetails(fiscalPeriod, FiscalPeriodGuid) {
    document.getElementById("txtFiscalPeriod").value = fiscalPeriod;
    document.getElementById("txtFiscalPeriodGuid").value = FiscalPeriodGuid;

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



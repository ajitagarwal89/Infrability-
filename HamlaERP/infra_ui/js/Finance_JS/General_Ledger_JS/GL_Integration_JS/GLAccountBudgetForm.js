function ClearForm() {

    document.getElementById('txtGLAccount').value = '';
    document.getElementById('txtBudget').value = '';
    document.getElementById('ddlOpt_BasedOn').selectedIndex = 0;
    document.getElementById('ddlOpt_BudgetYear').selectedIndex = 0;
    document.getElementById('ddlOpt_CalculationMethod').selectedIndex = 0;
    document.getElementById('txtYear').value = '';
    document.getElementById('txtButdetId_SourceBudgetId').value = '';
    document.getElementById('txtPercentage').value = '';
    document.getElementById('txtAmount').value = '';
    document.getElementById('chkIsIncrease').checked = false;
    document.getElementById('chkDisplay').checked = false;
    document.getElementById('chkIncludeBiginningBalance').checked = false;
    return false;
}
function SetGLAccountDetails(accountNumber, gLAccountGuid) {

    document.getElementById("txtGLAccount").value = accountNumber;
    document.getElementById("txtGLAccountGuid").value = gLAccountGuid;

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

function SetBudgetDetails(budgetNumber, budgetGuid) {

    document.getElementById("txtBudget").value = budgetNumber
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


function SetSourceBudgetDetails(budgetNumber, budgetGuid) {

    document.getElementById("txtButdetId_SourceBudgetId").value = budgetNumber
    document.getElementById("txtButdetId_SourceBudgetGuid").value = budgetGuid;

}

function CallSourceBudgetSearch() {
    document.getElementById("btnSourceBudgetSearch").click();

}

function ClearSourceBudgetSearch() {
    document.getElementById("btnClearSourceBudgetSearch").click();
}

function CallSourceBudgetRefreshButton() {
    document.getElementById("btnSourceBudgetRefresh").click();
    document.getElementById("btnClearSourceBudgetSearch").click();
}

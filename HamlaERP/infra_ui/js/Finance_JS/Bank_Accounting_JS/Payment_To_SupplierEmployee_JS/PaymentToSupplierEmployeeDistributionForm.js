function ClearForm() {
    
    document.getElementById('txtPaymentToSupplierEmployee').value = '';
    document.getElementById('txtPaymentToSupplierEmployeeGuid').value = '';
    document.getElementById('txtGLAccount').value = '';
    document.getElementById('txtGLAccountGuid').value = '';
    document.getElementById("ddlOptionType").selectedIndex = 0;
    document.getElementById("txtDebit").value = '';
    document.getElementById("txtOriginatingDebit").value = '';
    document.getElementById("txtCredit").value = '';
    document.getElementById("txtOriginatingCredit").value = '';
    document.getElementById("txtDescription").value = '';
    document.getElementById("txtDistributionReference").value = '';
    document.getElementById("txtCompanyId").value = '';
    document.getElementById("txtCorrespondenceCompanyId").value = '';

    return false;
}

function SetPaymentToSupplierEmployeeDetails(employee, employeeGuid) {

    document.getElementById("txtPaymentToSupplierEmployee").value = employee;
    document.getElementById("txtPaymentToSupplierEmployeeGuid").value = employeeGuid;
}

function CallPaymentToSupplierEmployeeSearch() {
    document.getElementById("btnPaymentToSupplierEmployeeSearch").click();

}

function ClearPaymentToSupplierEmployeeSearch() {
    document.getElementById("btnClearPaymentToSupplierEmployeeSearch").click();
}

function CallPaymentToSupplierEmployeeRefreshButton() {

    document.getElementById("btnPaymentToSupplierEmployeeRefresh").click();
    document.getElementById("btnClearPaymentToSupplierEmployeeSearch").click();
}

function SetGLAccountDetails(gLAccount, gLAccountGuid) {

    document.getElementById("txtGLAccount").value = gLAccount;
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

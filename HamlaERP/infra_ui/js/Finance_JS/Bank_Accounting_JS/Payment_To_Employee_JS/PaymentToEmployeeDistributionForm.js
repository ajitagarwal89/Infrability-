function ClearForm() {
    //alert("ClearForm"); 
    document.getElementById('txtPaymentToEmployee').value = '';
    document.getElementById('txtPaymentToEmployeeGuid').value = '';
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

function SetPaymentToEmployeeDetails(employee, employeeGuid) {

    document.getElementById("txtPaymentToEmployee").value = employee;
    document.getElementById("txtPaymentToEmployeeGuid").value = employeeGuid;
}

function CallPaymentToEmployeeSearch() {
    document.getElementById("btnPaymentToEmployeeSearch").click();

}

function ClearPaymentToEmployeeSearch() {
    document.getElementById("btnClearPaymentToEmployeeSearch").click();
}

function CallEmployeeRefreshButton() {
    alert("CallEmployeeRefreshButton");
    document.getElementById("btnPaymentToEmployeeRefresh").click();
    document.getElementById("btnClearPaymentToEmployeeSearch").click();
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
    alert("CallCustomerRefreshButton");
    document.getElementById("btnGLAccountRefresh").click();
    document.getElementById("btnClearGLAccountSearch").click();
}

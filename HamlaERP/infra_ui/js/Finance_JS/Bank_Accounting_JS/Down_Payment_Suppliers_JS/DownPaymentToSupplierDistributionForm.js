function ClearForm() {
    //alert("ClearForm"); 
    document.getElementById('txtDownPaymentToSupplier').value = '';
    document.getElementById('txtDownPaymentToSupplierGuid').value = '';
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

function SetDownPaymentToSupplierDetails(supplier, supplierGuid) {

    document.getElementById("txtDownPaymentToSupplier").value = supplier;
    document.getElementById("txtDownPaymentToSupplierGuid").value = supplierGuid;
}

function CallDownPaymentToSupplierSearch() {
    document.getElementById("btnDownPaymentToSupplierSearch").click();

}

function ClearDownPaymentToSupplierSearch() {
    document.getElementById("btnClearDownPaymentToSupplierSearch").click();
}

function CallSupplierRefreshButton() {
    alert("CallSupplierRefreshButton");
    document.getElementById("btnDownPaymentToSupplierRefresh").click();
    document.getElementById("btnClearDownPaymentToSupplierSearch").click();
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

function ClearForm() {
    //alert("ClearForm"); 
    document.getElementById('txtPaymentToSupplier').value = '';
    document.getElementById('txtPaymentToSupplierGuid').value = '';
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

function SetPaymentToSupplierDetails(supplier, supplierGuid) {
    alert("SetPaymentToSupplierDetails");
    document.getElementById("txtPaymentToSupplier").value = supplier;
    document.getElementById("txtPaymentToSupplierGuid").value = supplierGuid;

    document.getElementById("txtPaymentToSupplier").onchange();
    document.getElementById("txtPaymentToSupplierGuid").onchange();

    document.getElementById("txtPaymentToSupplier").value = supplier;
    document.getElementById("txtPaymentToSupplierGuid").value = supplierGuid;
}

function CallPaymentToSupplierSearch() {
    alert("CallPaymentToSupplierSearch");
    document.getElementById("btnPaymentToSupplierSearch").click();

}

function ClearPaymentToSupplierSearch()
{
    alert("ClearPaymentToSupplierSearch");
    document.getElementById("btnClearPaymentToSupplierSearch").click();
}

function CallSupplierRefreshButton() {
    alert("CallSupplierRefreshButton");
    document.getElementById("btnPaymentToSupplierRefresh").click();
    document.getElementById("btnClearPaymentToSupplierSearch").click();
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

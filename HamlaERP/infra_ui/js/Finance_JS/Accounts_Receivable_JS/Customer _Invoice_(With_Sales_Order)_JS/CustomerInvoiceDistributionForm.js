function ClearForm() {
    document.getElementById('txtCustomerInvoiceId').value = '';
    document.getElementById('txtCustomerInvoiceIdGuid').value = '';
    document.getElementById('txtGLAccount').value = '';
    document.getElementById('txtGLAccountGuid').value = '';
    document.getElementById('ddlOpt_GLAccountType').selectedIndex = 0;
    document.getElementById('txtDescription').value = '';
    document.getElementById('txtDistributionReference').value = '';
    document.getElementById('txtDebit').value = '';
    document.getElementById('txtCredit').value = '';
    document.getElementById('txtOriginatingDebit').value = '';
    document.getElementById('txtOriginatingCredit').value = '';
    return false;
}
function SetCustomerInvoiceIdDetails(CustomerInvoiceId, CustomerInvoiceIdGuid) {
    document.getElementById("txtCustomerInvoiceId").value = CustomerInvoiceId;
    document.getElementById("txtCustomerInvoiceIdGuid").value = CustomerInvoiceIdGuid;
}

function CallCustomerInvoiceIdSearch() {
    document.getElementById("btnCustomerInvoiceIdSearch").click();

}

function ClearCustomerInvoiceIdSearch() {
    document.getElementById("btnClearCustomerInvoiceIdSearch").click();
}

function CallCustomerInvoiceIdRefreshButton() {
    document.getElementById("btnCustomerInvoiceIdRefresh").click();
    document.getElementById("btnClearCustomerInvoiceIdSearch").click();
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

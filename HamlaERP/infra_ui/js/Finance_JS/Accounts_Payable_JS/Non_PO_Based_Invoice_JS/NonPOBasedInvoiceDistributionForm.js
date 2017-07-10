function ClearForm() {
    document.getElementById('txtNonPOBasedInvoiceId').value = '';
    document.getElementById('txtNonPOBasedInvoiceIdGuid').value = '';  
    document.getElementById('txtGLAccount').value = '';
    document.getElementById('txtGLAccountGuid').value = '';
    document.getElementById('ddlOpt_GLAccountType').selectedIndex = 0;
    document.getElementById('txtDescription').value = '';
    document.getElementById('txtDistributionReference').value = '';
    document.getElementById('txtDebit').value = '';
    document.getElementById('txtCredit').value = '';
    document.getElementById('txtOriginatingDebit').value = '';
    document.getElementById('txtOriginatingCredit').value = '';
    document.getElementById('txtExchangeRate').value = '';
    return false;
}
function SetNonPOBasedInvoiceIdDetails(nonPOBasedInvoiceId, nonPOBasedInvoiceIdGuid) {
    document.getElementById("txtNonPOBasedInvoiceId").value = nonPOBasedInvoiceId;
    document.getElementById("txtNonPOBasedInvoiceIdGuid").value = nonPOBasedInvoiceIdGuid;
}

function CallNonPOBasedInvoiceIdSearch() {
    document.getElementById("btnNonPOBasedInvoiceIdSearch").click();

}

function ClearNonPOBasedInvoiceIdSearch() {
    document.getElementById("btnClearNonPOBasedInvoiceIdSearch").click();
}

function CallNonPOBasedInvoiceIdRefreshButton() {
    document.getElementById("btnNonPOBasedInvoiceIdRefresh").click();
    document.getElementById("btnClearNonPOBasedInvoiceIdSearch").click();
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

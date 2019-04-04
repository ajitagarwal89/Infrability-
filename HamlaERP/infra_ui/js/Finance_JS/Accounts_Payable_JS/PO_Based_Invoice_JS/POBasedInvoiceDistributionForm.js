function ClearForm() {
    document.getElementById('txtGLAccount').value = '';
    document.getElementById('txtGLAccountGuid').value = '';
    document.getElementById('txtPOBasedInvoice').value = '';
    document.getElementById('txtPOBasedInvoiceGuid').value = '';
    document.getElementById('ddlopt_GLAccountType').selectedIndex = 0;
    document.getElementById('txtDescription').value = '';
    document.getElementById('txtDistributionReference').value = '';
    document.getElementById('txtDebit').value = '';
    document.getElementById('txtCredit').value = '';
    document.getElementById('txtOriginatingDebit').value = '';
    document.getElementById('txtOriginatingCredit').value = '';
    document.getElementById('txtExchangeRate').value = '';

    return false;
}


function SetGLAccountDetails(accountNumber, gLAccountGuid) {

    document.getElementById("txtGLAccount").value = accountNumber
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

function SetPOBasedInvoiceDetails(POBasedInvoiceNumber, POBasedInvoiceGuid) {

    document.getElementById("txtPOBasedInvoice").value = POBasedInvoiceNumber;
    document.getElementById("txtPOBasedInvoiceGuid").value = POBasedInvoiceGuid;

}

function CallPOBasedInvoiceSearch() {
    document.getElementById("btnPOBasedInvoiceSearch").click();

}

function ClearPOBasedInvoiceSearch() {
    document.getElementById("btnClearPOBasedInvoiceSearch").click();
}

function CallPOBasedInvoiceRefreshButton() {
    document.getElementById("btnPOBasedInvoiceRefresh").click();
    document.getElementById("btnClearPOBasedInvoiceSearch").click();
}


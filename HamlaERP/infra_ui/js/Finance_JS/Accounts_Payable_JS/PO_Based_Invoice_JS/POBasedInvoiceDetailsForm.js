function ClearForm() {

    document.getElementById('txtlPOBasedInvoice').value = '';
    document.getElementById('txtlPOBasedInvoiceGuid').value = '';
    document.getElementById('txtPO').value = '';
    document.getElementById('txtPOGuid').value = '';
    document.getElementById('txtLocation').value = '';
    document.getElementById('txtLocationGuid').value = '';
    document.getElementById('txtUOM').value = '';
    document.getElementById('txtDescription').value = '';
    document.getElementById('txtQuantityInvoice').value = '';
    document.getElementById('txtUnitCost').value = '';
    document.getElementById('txtExtendedCost').value = '';
      return false;
}

function SetPOBasedInvoiceDetails(pOBasedInvoice, pOBasedInvoiceGuid) {
    document.getElementById("txtlPOBasedInvoice").value = pOBasedInvoice;
    document.getElementById("txtlPOBasedInvoiceGuid").value = pOBasedInvoiceGuid;
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



function SetLocationDetails(description, locationGuid) {
    document.getElementById("txtLocation").value = description;
    document.getElementById("txtLocationGuid").value = locationGuid;
}

function CallLocationSearch() {
    document.getElementById("btnLocationSearch").click();

}

function ClearLocationSearch() {
    document.getElementById("btnClearLocationSearch").click();
}

function CallLocationRefreshButton() {
    document.getElementById("btnLocationRefresh").click();
    document.getElementById("btnClearLocationSearch").click();
}

function SetPODetails(poNumber, POGuid) {

    document.getElementById("txtPO").value = poNumber
    document.getElementById("txtPOGuid").value = POGuid;

}

function CallPOSearch() {
    document.getElementById("btnPOSearch").click();

}

function ClearPOSearch() {
    document.getElementById("btnClearPOSearch").click();
}

function CallPORefreshButton() {
    document.getElementById("btnPORefresh").click();
    document.getElementById("btnClearPOSearch").click();
}


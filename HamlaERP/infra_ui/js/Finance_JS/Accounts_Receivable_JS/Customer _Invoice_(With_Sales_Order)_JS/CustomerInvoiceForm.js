function ClearForm() {
    //alert("ClearForm");
    document.getElementById('txtDocumentDate').value = '';

    document.getElementById('txtInvoiceAndOrderType').value = '';
    document.getElementById('txtInvoiceAndOrderTypeGuid').value = '';

    document.getElementById('ddlOpt_InvoiceAndOrderType').selectedIndex = 0;
    
    document.getElementById('txtDocumentNumber').value = '';

    document.getElementById('txtBatch').value = '';
    document.getElementById('txtBatchGuid').value = '';

    document.getElementById('txtCustomer').value = '';
    document.getElementById('txtCustomerGuid').value = '';

    document.getElementById('txtSites').value = '';
    document.getElementById('txtSitesGuid').value = '';

    document.getElementById('txtCustomerPONumber').value = '';

    document.getElementById('txtCurrency').value = '';
    document.getElementById('txtCurrencyGuid').value = '';

    document.getElementById('txtAmountReceived').value = '';

    document.getElementById('txtOnAccount').value = '';

    document.getElementById('txtSubTotalAmount').value = '';

    document.getElementById('txtTradeDiscountAmount').value = '';

    document.getElementById('txtFreightAmount').value = '';

    document.getElementById('ddlOpt_DocumentStatus').selectedIndex = 0;    

    document.getElementById('txtTotalAmount').value = '';

    document.getElementById('txtPostingDate').value = '';

    document.getElementById('txtQuoteDate').value = '';

    document.getElementById('txtOrderDate').value = '';

    document.getElementById('txtInvoiceDate').value = '';

    document.getElementById('txtBackOrderDate').value = '';

    document.getElementById('txtReturnDate').value = '';

    document.getElementById('txtRequestedShipDate').value = '';

    document.getElementById('txtDateFulfilled').value = '';

    document.getElementById('txtActualShipDate').value = '';
    

    return false;
}

function SetInvoiceAndOrderTypeDetails(invoiceAndOrderType, invoiceAndOrderTypeGuid) {

    document.getElementById("txtInvoiceAndOrderType").value = invoiceAndOrderType;
    document.getElementById("txtInvoiceAndOrderTypeGuid").value = invoiceAndOrderTypeGuid;
}

function CallInvoiceAndOrderTypeSearch() {
    document.getElementById("btnHtmlInvoiceAndOrderTypeSearch").click();

}

function ClearInvoiceAndOrderTypeSearch() {
    document.getElementById("btnClearInvoiceAndOrderTypeSearch").click();
}

function CallInvoiceAndOrderTypeRefreshButton() {
    document.getElementById("btnInvoiceAndOrderTypeRefresh").click();
    document.getElementById("btnClearInvoiceAndOrderTypeSearch").click();
}


function SetBatchDetails(batch, batchGuid) {

    document.getElementById("txtBatch").value = batch;
    document.getElementById("txtBatchGuid").value = batchGuid;

}

function CallBatchSearch() {
    document.getElementById("btnBatchSearch").click();

}

function ClearBatchSearch() {
    document.getElementById("btnClearBatchSearch").click();
}

function CallBatchRefreshButton() {
    document.getElementById("btnBatchRefresh").click();
    document.getElementById("btnClearBatchSearch").click();
}

function SetCurrencyDetails(currency, currencyGuid) {

    document.getElementById("txtCurrency").value = currency;
    document.getElementById("txtCurrencyGuid").value = currencyGuid;
}

function CallCurrencySearch() {
    document.getElementById("btnCurrencySearch").click();

}

function ClearCurrencySearch() {
    document.getElementById("btnClearCurrencySearch").click();
}

function CallCurrencyRefreshButton() {
    document.getElementById("btnCurrencyRefresh").click();
    document.getElementById("btnClearCurrencySearch").click();
}


function SetCustomerDetails(customer, customerGuid) {

    document.getElementById("txtCustomer").value = customer;
    document.getElementById("txtCustomerGuid").value = customerGuid;
}

function CallCustomerSearch() {
    document.getElementById("btnHtmlCustomerSearch").click();

}

function ClearCustomerSearch() {
    document.getElementById("btnClearCustomerSearch").click();
}

function CallCustomerRefreshButton() {
    document.getElementById("btnCustomerRefresh").click();
    document.getElementById("btnClearCustomerSearch").click();
}

function SetSitesDetails(sites, sitesGuid) {

    document.getElementById("txtSites").value = sites;
    document.getElementById("txtSitesGuid").value = sitesGuid;
}

function CallSitesSearch() {
    document.getElementById("btnHtmlSitesSearch").click();

}

function ClearSitesSearch() {
    document.getElementById("btnClearSitesSearch").click();
}

function CallSitesRefreshButton() {
    document.getElementById("btnSitesRefresh").click();
    document.getElementById("btnClearSitesSearch").click();
}
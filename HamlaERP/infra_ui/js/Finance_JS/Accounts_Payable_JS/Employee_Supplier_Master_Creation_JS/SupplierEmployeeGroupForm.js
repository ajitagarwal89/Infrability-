function ClearForm() {
    document.getElementById('txtSupplierEmployeeGroupId_SelfGuid').value = '';
    document.getElementById('txtSupplierEmployeeGroupId_Self').value = '';
    document.getElementById('txtDescription').value = '';
    document.getElementById('txtCurrency').value = '';
    document.getElementById('txtPaymentTerms').value = '';
    document.getElementById('txtTradeDiscount').value = '';
    document.getElementById('chckCalendarYear').checked = false;
    document.getElementById('chckFiscalYear').checked = false;
    document.getElementById('chckTransaction').checked = false;
    document.getElementById('chckDistribution').checked = false;
    document.getElementById("ddlOpt_MinimumPayment").selectedIndex = 0;
    document.getElementById("ddlOpt_MaximumInvoiceAmount").selectedIndex = 0;
    document.getElementById("ddlOpt_CreditLimit").selectedIndex = 0;
    document.getElementById("ddlOpt_WriteOff").selectedIndex = 0;
    return false;
}

function SetSupplierEmployeeGroupDetails(SupplierEmployeeGroupName, SupplierEmployeeGroupGuid) {
    document.getElementById("txtSupplierEmployeeGroupId_Self").value = SupplierEmployeeGroupName;
    document.getElementById("txtSupplierEmployeeGroupId_SelfGuid").value = SupplierEmployeeGroupGuid;
}

function CallSupplierEmployeeGroupSearch() {
    document.getElementById("btnSupplierEmployeeGroupSearch").click();

}

function ClearSupplierEmployeeGroupSearch() {
    document.getElementById("btnClearSupplierEmployeeGroupSearch").click();
}

function CallSupplierEmployeeGroupRefreshButton() {
    document.getElementById("btnSupplierEmployeeGroupRefresh").click();
    document.getElementById("btnClearSupplierEmployeeGroupSearch").click();
}


function SetPaymentTermsDetails(paymentTerms, paymentTermsGuid) {
    document.getElementById("txtPaymentTerms").value = paymentTerms;
    document.getElementById("txtPaymentTermGuid").value = paymentTermsGuid;
}

function CallPaymentTermsSearch() {
    document.getElementById("btnPaymentTermsSearch").click();

}

function ClearPaymentTermsSearch() {
    document.getElementById("btnClearPaymentTermsSearch").click();
}

function CallPaymentTermsRefreshButton() {
    document.getElementById("btnPaymentTermsRefresh").click();
    document.getElementById("btnClearPaymentTermsSearch").click();
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


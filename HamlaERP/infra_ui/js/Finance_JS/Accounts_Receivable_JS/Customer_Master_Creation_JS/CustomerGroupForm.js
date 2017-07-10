function ClearForm() {
    document.getElementById('txtCustomerGroupId_SelfGuid').value = '';
    document.getElementById('txtCustomerGroupId_Self').value = '';
    document.getElementById('txtDescription').value = '';
    document.getElementById('chckIsDefault').checked = false;
    document.getElementById('txtCurrency').value = '';    
    document.getElementById('txtMinimumPaymentAmount').value = '';
    document.getElementById('txtCreditLimitAmount').value = '';
    document.getElementById('txtWriteOffAmount').value = '';
    document.getElementById('txtTradeDiscount').value = '';
    document.getElementById('txtPaymentTerms').value = '';
    document.getElementById('chckCalendarYear').checked = false;
    document.getElementById('chckFiscalYear').checked = false;
    document.getElementById('chckTransaction').checked = false;
    document.getElementById('chckDistribution').checked = false;
    document.getElementById("ddlOpt_MinimumPayment").selectedIndex = 0;   
    document.getElementById("ddlOpt_CreditLimit").selectedIndex = 0;
    document.getElementById("ddlOpt_WriteOff").selectedIndex = 0;
    document.getElementById("ddlOpt_BalanceType").selectedIndex = 0;
    document.getElementById("ddlOpt_StatementCycle").selectedIndex = 0;
    
    return false;
}

function SetCustomerGroupDetails(customerGroupName, customerGroupGuid) {
    document.getElementById("txtCustomerGroupId_Self").value = customerGroupName;
    document.getElementById("txtCustomerGroupId_SelfGuid").value = customerGroupGuid;
}

function CallCustomerGroupSearch() {
    document.getElementById("btnCustomerGroupSearch").click();

}

function ClearCustomerGroupSearch() {
    document.getElementById("btnClearCustomerGroupSearch").click();
}

function CallCustomerGroupRefreshButton() {
    document.getElementById("btnCustomerGroupRefresh").click();
    document.getElementById("btnClearCustomerGroupSearch").click();
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

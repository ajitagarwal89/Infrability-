function ClearForm() {
    document.getElementById('ddlOpt_DocumentType').selectedIndex = 0;
    document.getElementById('txtBatch').value = '';
    document.getElementById('txtBatchGuid').value = '';
    document.getElementById('txtDocumentNumber').value = '';
    document.getElementById('txtDocumentDate').value = '';
    document.getElementById('txtDescription').value = '';
    document.getElementById('txtPostingDate').value = '';
    document.getElementById('txtInvoiceDate').value = '';
    document.getElementById('txtInvoiceIssueDate').value = '';
    document.getElementById('txtCustomer').value = '';
    document.getElementById('txtCustomerGuid').value = '';
    document.getElementById('txtCurrency').value = '';
    document.getElementById('txtCurrencyGuid').value = '';
    document.getElementById('txtPaymentTerms').value = '';
    document.getElementById('txtPaymentTermseGuid').value = '';
    document.getElementById('txtPONumber').value = '';
    document.getElementById('txtCost').value = '';
    document.getElementById('txtSales').value = '';
    document.getElementById('txtTradeDiscount').value = '';
    document.getElementById('txtFreight').value = '';
    document.getElementById('txtTotal').value = '';
    document.getElementById('txtPayablesBank').value = '';
    document.getElementById('txtPayablesBankGuid').value = '';
    document.getElementById('txtBankTransferAmount').value = '';
    document.getElementById('txtPayablesCash').value = '';
    document.getElementById('txtPayablesCashGuid').value = '';
    document.getElementById('txtCash').value = '';
    document.getElementById('txtPayablesCheque').value = '';
    document.getElementById('txtPayablesChequeGuid').value = '';
    document.getElementById('txtCheque').value = '';
    document.getElementById('txtPayablesCreditCard').value = '';
    document.getElementById('txtPayablesCreditCardGuid').value = '';
    document.getElementById('txtCreditCard').value = '';
    document.getElementById('txtOnAccount').value = '';
    return false;
}
function SetBatchDetails(batchId, batchIdGuid) {
    document.getElementById("txtBatch").value = batchId;
    document.getElementById("txtBatchGuid").value = batchIdGuid;
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
 
function SetPaymentTermsDetails(paymentTerms, paymentTermseGuid) {
    document.getElementById("txtPaymentTerms").value = paymentTerms;
    document.getElementById("txtPaymentTermseGuid").value = paymentTermseGuid;
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
 
function SetCustomerDetails(customer, customerGuid) {
    document.getElementById("txtCustomer").value = customer;
    document.getElementById("txtCustomerGuid").value = customerGuid;
}
 
function CallCustomerSearch() {
    document.getElementById("btnCustomerSearch").click();
 
}
 
function ClearCustomerSearch() {
    document.getElementById("btnClearCustomerSearch").click();
}
 
function CallCustomerRefreshButton() {
    document.getElementById("btnCustomerRefresh").click();
    document.getElementById("btnClearCustomerSearch").click();
}
 
function SetPayablesBankDetails(payablesBank, payablesBankGuid) {
    document.getElementById("txtPayablesBank").value = payablesBank;
    document.getElementById("txtPayablesBankGuid").value = payablesBankGuid;
 
}
 
function CallPayablesBankSearch() {
    document.getElementById("btnPayablesBankSearch").click();
 
}
 
function ClearPayablesBankSearch() {
    document.getElementById("btnClearPayablesBankSearch").click();
}
 
function CallPayablesBankRefreshButton() {
    document.getElementById("btnPayablesBankRefresh").click();
    document.getElementById("btnClearPayablesBankSearch").click();
}
 
function SetPayablesCashDetails(paymentNumber, payablesId) {
 
    document.getElementById("txtPayablesCash").value = paymentNumber;
    document.getElementById("txtPayablesCashGuid").value = payablesId;
 
}
 
function CallPayablesCashSearch() {
    document.getElementById("btnPayablesCashSearch").click();
 
}
 
function ClearPayablesCashSearch() {
    document.getElementById("btnClearPayablesCashSearch").click();
}
 
function CallPayablesCashRefreshButton() {
    document.getElementById("btnPayablesCashRefresh").click();
    document.getElementById("btnClearPayablesCashSearch").click();
}
 
function SetPayablesChequeDetails(chequenumber, payablesChequeGuid) {
    document.getElementById("txtPayablesCheque").value = chequenumber;
    document.getElementById("txtPayablesChequeGuid").value = payablesChequeGuid;
 
}
 
function CallPayablesChequeSearch() {
    document.getElementById("btnPayablesChequeSearch").click();
 
}
 
function ClearPayablesChequeSearch() {
    document.getElementById("btnClearPayablesChequeSearch").click();
}
 
function CallPayablesChequeRefreshButton() {
    document.getElementById("btnPayablesChequeRefresh").click();
    document.getElementById("btnClearPayablesChequeSearch").click();
}
 
function SetPayablesCreditCardDetails(payablesCreditCard, payablesCreditCardGuid) {
 
    document.getElementById("txtPayablesCreditCard").value = payablesCreditCard;
    document.getElementById("txtPayablesCreditCardGuid").value = payablesCreditCardGuid;
 
}
 
function CallPayablesCreditCardSearch() {
    document.getElementById("btnPayablesCreditCardSearch").click();
 
}
 
function ClearPayablesCreditCardSearch() {
    document.getElementById("btnClearPayablesCreditCardSearch").click();
}
 
function CallPayablesCreditCardRefreshButton() {
    document.getElementById("btnPayablesCreditCardRefresh").click();
    document.getElementById("btnClearPayablesCreditCardSearch").click();
}
  
 
 

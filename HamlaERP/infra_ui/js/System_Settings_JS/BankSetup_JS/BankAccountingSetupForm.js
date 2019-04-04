function ClearForm() {
    document.getElementById('txtDepositcode').value = '';
    document.getElementById('txtDeposit').value = '';
    document.getElementById('txtReceiptCode').value = '';
    document.getElementById('txtReceipt').value = '';
    document.getElementById('txtCheckCode').value = '';
    document.getElementById('txtCheck').value = '';
    document.getElementById('txtWithdrawalCode').value = '';
    document.getElementById('txtWithdrawal').value = '';
    document.getElementById('txtIncreaseAdjustmentCode').value = '';
    document.getElementById('txtIncreaseAdjustment').value = '';
    document.getElementById('txtDecreaseAdjustmentCode').value = '';
    document.getElementById('txtDecreaseAdjustment').value = '';
    document.getElementById('txtTransferCode').value = '';
    document.getElementById('txtTransfer').value = '';
    document.getElementById('chkIsTransaction_Reconcilation').checked= false;
    document.getElementById('txtChequeBookGuid').value = '';
    document.getElementById('txtChequeBook').value = '';
    document.getElementById('txtInterestIncomeCode').value = '';
    document.getElementById('txtInterestIncome').value = '';
    document.getElementById('txtOtherIncomeCode').value = '';
    document.getElementById('txtOtherIncome').value = '';
    document.getElementById('txtOtherExpenseCode').value = '';
    document.getElementById('txtOtherExpense').value = '';
    document.getElementById('txtServiceChargeCode').value = '';
    document.getElementById('txtServiceCharge').value = '';

    return false;
}

function SetChequeBookDetails(ChequeBook, ChequeBookGuid) {

    document.getElementById("txtChequeBook").value = ChequeBook;
    document.getElementById("txtChequeBookGuid").value = ChequeBookGuid;

}

function CallChequeBookSearch() {
    document.getElementById("btnChequeBookSearch").click();

}

function ClearChequeBookSearch() {
    document.getElementById("btnClearChequeBookSearch").click();
}

function CallChequeBookRefreshButton() {
    document.getElementById("btnChequeBookRefresh").click();
    document.getElementById("btnClearChequeBookSearch").click();
}
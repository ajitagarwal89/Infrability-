
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(agingPeriods, applyBy, opt_SummaryView, tbl_ChequeBookId, vendorHold, invoiceAmount, writeOffAmount, trialBalance, printedDocuments, duplicateInvoices, invoiceDescription, invoiceCode, returnDescription, returnCode, creditMemoDescription, creditMemoCode, paymentDescription, paymentCode, payableSetupGroup, payableSetupAndGroupAccount, cash, accountReceivable, sales, costOfSales, inventory, accuralDifferedA_C, gvRowId) {

    document.getElementById("lblAgingPeriods").innerHTML = agingPeriods;
    document.getElementById("lblApplyBy").innerHTML = applyBy;
    document.getElementById("lblOpt_SummaryView").innerHTML = opt_SummaryView;
    document.getElementById("lbltbl_ChequeBookId").innerHTML = tbl_ChequeBookId;
    document.getElementById("lblVendorHold").innerHTML = vendorHold;
    document.getElementById("lblInvoiceAmount").innerHTML = invoiceAmount;
    document.getElementById("lblWriteOffAmount").innerHTML = writeOffAmount;
    document.getElementById("lblTrialBalance").innerHTML = trialBalance;
    document.getElementById("lblPrintedDocuments").innerHTML = printedDocuments;
    document.getElementById("lblDuplicateInvoices").innerHTML = duplicateInvoices;
    document.getElementById("lblInvoiceDescription").innerHTML = invoiceDescription;
    document.getElementById("lblInvoiceCode").innerHTML = invoiceCode;
    document.getElementById("lblReturnDescription").innerHTML = returnDescription;
    document.getElementById("lblReturnCode").innerHTML = returnCode;
    document.getElementById("lblCreditMemoDescription").innerHTML = creditMemoDescription;
    document.getElementById("lblCreditMemoCode").innerHTML = creditMemoCode;
    document.getElementById("lblPaymentDescription").innerHTML = paymentDescription;
    document.getElementById("lblPaymentCode").innerHTML = paymentCode;
    document.getElementById("lblPayableSetupGroup").innerHTML = payableSetupGroup;
    document.getElementById("lblPayableSetupAndGroupAccount").innerHTML = payableSetupAndGroupAccount;
    document.getElementById("lblCash").innerHTML = cash;
    document.getElementById("lblAccountReceivable").innerHTML = accountReceivable;
    document.getElementById("lblSales").innerHTML = sales;
    document.getElementById("lblCostOfSales").innerHTML = costOfSales;
    document.getElementById("lblInventory").innerHTML = inventory;
    document.getElementById("lblAccuralDifferedA_C").innerHTML = accuralDifferedA_C;
    document.getElementById("lblGvRowId").innerHTML = gvRowId;
    
   
    var maxrows = document.getElementById('gvData').rows.length - 1;
    var num = document.getElementById('lblGvRowId').innerHTML.split('_');
    if (num[1] == maxrows) {
        document.getElementById('next').class = 'btn btn-default disabled';
    }
    else {
        document.getElementById('next').class = 'btn btn-default';
    }
    if (num[1] == 1) {
        document.getElementById('prev').class = 'btn btn-default disabled';
    }
    else {
        document.getElementById('prev').class = 'btn btn-default';
    }
}

function showNextRecord() {
    var id = document.getElementById('lblGvRowId').innerHTML.split('_');
    var lnk = parseInt(id[1]) + 1;
   
    document.getElementById('lnkViewNextPrev_' + lnk).click();
}

function showPrevRecord() {
    var id = document.getElementById('lblGvRowId').innerHTML.split('_');
    var lnk = parseInt(id[1]) - 1;
   
    document.getElementById('lnkViewNextPrev_' + lnk).click();
}

function CallMainSearch() {
    document.getElementById("btnMainSearch").click();
}

function ClearMainSearch() {
    document.getElementById("btnClearMainSearch").click();
}
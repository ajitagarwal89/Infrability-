
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function SetDetails(documentType, batch, documentNumber, documentDate, description, postingDate, invoiceDate, invoiceIssueDate, customer, currency, paymentTerms, pONumber, cost, sales, tradeDiscount, freight, totalAmount, payablesIdBankTransfer, bankTransferAmount, payablesIdCash, cashAmount, payablesIdCheque, chequeAmount, payablesIdCreditCard, creditCardAmount, onAccount, lblGvRowId) {
   
    document.getElementById("lblDocumentType").innerHTML = documentType;
    document.getElementById("lblBatch").innerHTML = batch;
    document.getElementById("lblDocumentNumber").innerHTML = documentNumber;
    document.getElementById("lblDocumentDate").innerHTML = documentDate;
    document.getElementById("lblDescription").innerHTML = description;
    document.getElementById("lblPostingDate").innerHTML = postingDate;
    document.getElementById("lblInvoiceDate").innerHTML = invoiceDate;
    document.getElementById("lblInvoiceIssueDate").innerHTML = invoiceIssueDate;
    document.getElementById("lblCustomer").innerHTML = customer;
    document.getElementById("lblCurrency").innerHTML = currency;
    document.getElementById("lblPaymentTerms").innerHTML = paymentTerms;
    document.getElementById("lblPONumber").innerHTML = pONumber;
    document.getElementById("lblCost").innerHTML = cost;
    document.getElementById("lblSales").innerHTML = sales;
    document.getElementById("lblTradeDiscount").innerHTML = tradeDiscount;
    document.getElementById("lblFreight").innerHTML = freight;
    document.getElementById("lblTotalAmount").innerHTML = totalAmount;
    document.getElementById("lblPayablesIdBankTransfer").innerHTML = payablesIdBankTransfer;
    document.getElementById("lblBankTransferAmount").innerHTML = bankTransferAmount;
    document.getElementById("lblPayablesIdCash").innerHTML = payablesIdCash;
    document.getElementById("lblCashAmount").innerHTML = cashAmount;
    document.getElementById("lblPayablesIdCheque").innerHTML = payablesIdCheque;
    document.getElementById("lblChequeAmount").innerHTML = chequeAmount;
    document.getElementById("lblPayablesIdCreditCard").innerHTML = payablesIdCreditCard;
    document.getElementById("lblCreditCardAmount").innerHTML = creditCardAmount;
    document.getElementById("lblOnAccount").innerHTML = onAccount;

    document.getElementById("lblGvRowId").innerHTML = lblGvRowId;
    var maxrows = document.getElementById('gvData').rows.length - 1;
    var num = document.getElementById('lblGvRowId').innerHTML.split('_');
    if (num[1] == maxrows) {
        alert("next");
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
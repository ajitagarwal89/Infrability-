function ClearForm() {

    document.getElementById('txtPaymentToSupplier').value = '';
    document.getElementById('rdbNonPOBasedInvoiceId').checked = false;
    document.getElementById('rdbPOBasedInvoiceId').checked = false;
    document.getElementById('txtApplyToDocumentNonPOBasedInvoice').value = '';
    document.getElementById('txtApplyToDocumentNonPOBasedInvoiceGuid').value = '';
    document.getElementById('txtApplyToDocumentPOBasedInvoice').value = '';
    document.getElementById('txtApplyToDocumentPOBasedInvoiceGuid').value = '';
    document.getElementById('txtDueDate').value = '';
    document.getElementById('txtRemainingAmount').value = '';
    document.getElementById('txtApplyAmount').value = '';
    document.getElementById('ddloptType').selectedIndex = 0;
    document.getElementById('txtOrignalDocumentAmount').value = '';
    document.getElementById('txtDiscountDate').value = '';
    document.getElementById('txtCurrencyId_ApplyToCurrency').value = '';
    return false;
}
var validFilesTypes2 = ["png", "jpg", "pdf", "jpeg"];

function CheckExtension(file) {
    /*global document: false */
    var filePath = file.value;
    var ext = filePath.substring(filePath.lastIndexOf('.') + 1).toLowerCase();
    var isValidFile = false;

    for (var i = 0; i < validFilesTypes2.length; i++) {
        if (ext == validFilesTypes2[i]) {
            showimagepreview(file);
            isValidFile = true;
            break;
        }
    }

    if (!isValidFile) {
        file.value = null;
        alert("Invalid File. Valid extensions are:\n\n" + validFilesTypes2.join(", "));
    }

    return false;
}

function showimagepreview(input) {
    if (input.files && input.files[0]) {
        var filerdr = new FileReader();
        filerdr.onload = function (e) {
            document.getElementById("imgLogo").style.display = 'block';
            $('#imgLogo').attr('src', e.target.result);
            document.getElementById("imgLogo").style.textAlign = 'right';
        }
        filerdr.readAsDataURL(input.files[0]);
        document.getElementById("idp").innerHTML = document.getElementById("<%=updocpic.ClientID%>").value;
    }
}

function SetPaymentToSupplierDetails(supplierName, paymentToSupplierGuid) {

    document.getElementById("txtPaymentToSupplier").value = supplierName;
    document.getElementById("txtPaymentToSupplierGuid").value = paymentToSupplierGuid;

}

function CallPaymentToSupplierSearch() {
    document.getElementById("btnPaymentToSupplierSearch").click();

}

function ClearPaymentToSupplierSearch() {
    document.getElementById("btnClearPaymentToSupplierSearch").click();
}

function CallPaymentToSupplierRefreshButton() {
    document.getElementById("btnPaymentToSupplierRefresh").click();
    document.getElementById("btnClearPaymentToSupplierSearch").click();
}


function SetCurrencyDetails(currency, currencyGuid) {

    document.getElementById("txtCurrencyId_ApplyToCurrency").value = currency;
    document.getElementById("txtCurrencyId_ApplyToCurrencyGuid").value = currencyGuid;
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

function SetApplyToDocumentNonPOBasedInvoiceDetails(description, applyToDocumentNonPOBasedInvoiceGuid) {

   
    document.getElementById("txtApplyToDocumentNonPOBasedInvoice").value = description;
    document.getElementById("txtApplyToDocumentNonPOBasedInvoiceGuid").value = applyToDocumentNonPOBasedInvoiceGuid;

}

function CallApplyToDocumentNonPOBasedInvoiceSearch() {
    document.getElementById("btnApplyToDocumentNonPOBasedInvoiceSearch").click();

}

function ClearApplyToDocumentNonPOBasedInvoiceSearch() {
    document.getElementById("btnClearApplyToDocumentNonPOBasedInvoiceSearch").click();
}

function CallApplyToDocumentNonPOBasedInvoiceRefreshButton() {
    
    document.getElementById("btnApplyToDocumentNonPOBasedInvoiceRefresh").click();
    document.getElementById("btnClearApplyToDocumentNonPOBasedInvoiceSearch").click();
}


function SetApplyToDocumentPOBasedInvoiceDetails(supplierName, applyToDocumentPOBasedInvoiceGuid) {

   
    document.getElementById("txtApplyToDocumentPOBasedInvoice").value = supplierName;
    document.getElementById("txtApplyToDocumentPOBasedInvoiceGuid").value = applyToDocumentPOBasedInvoiceGuid;

}

function CallApplyToDocumentPOBasedInvoiceSearch() {
    document.getElementById("btnApplyToDocumentPOBasedInvoiceSearch").click();

}

function ClearApplyToDocumentPOBasedInvoiceSearch() {
    document.getElementById("btnClearApplyToDocumentPOBasedInvoiceSearch").click();
}

function CallApplyToDocumentPOBasedInvoiceRefreshButton() {
   
    document.getElementById("btnApplyToDocumentPOBasedInvoiceRefresh").click();
    document.getElementById("btnClearApplyToDocumentPOBasedInvoiceSearch").click();
}





function ClearForm() {

    document.getElementById('txtPaymentFromCustomer').value = '';
    document.getElementById('txtPaymentFromCustomerGuid').value = '';
    document.getElementById('rdbtnCustomerInvoice').checked = false;
    document.getElementById('RdbtnCustomerInvoiceProcess').checked = false;
    document.getElementById('txtApplyToDocument').value = '';
    document.getElementById('txtApplyToDocumentGuid').value = '';
    document.getElementById('txtApplyotDocumentCIP').value = '';
    document.getElementById('txtApplyotDocumentCIPGuid').value = '';
    document.getElementById('txtDueDate').value = '';
    document.getElementById('txtRemainingAmount').value = '';
    document.getElementById('txtApplyAmount').value = '';
    document.getElementById('ddloptType').selectedIndex = 0;
    document.getElementById('txtOrignalDocumentAmount').value = '';
    document.getElementById('txtDiscountDate').value = '';
    document.getElementById('txtCurrency').value = '';
    document.getElementById('txtCurrencyId_ApplyToCurrencyGuid').value = '';
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

function SetPaymentFromCustomerDetails(customerName, paymentFromCustomerGuid) {
    document.getElementById("txtPaymentFromCustomer").value = customerName;
    document.getElementById("txtPaymentFromCustomerGuid").value = paymentFromCustomerGuid;

}

function CallPaymentFromCustomerSearch() {
    document.getElementById("btnPaymentFromCustomerSearch").click();

}

function ClearPaymentFromCustomerSearch() {
    document.getElementById("btnClearPaymentFromCustomerSearch").click();
}

function CallPaymentFromCustomerRefreshButton() {
    document.getElementById("btnPaymentFromCustomerRefresh").click();
    document.getElementById("btnClearPaymentFromCustomerSearch").click();
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


function SetCustomerInvoiceDetails(documentNumber, applytoDocumentGuid) {
    document.getElementById("txtApplyToDocument").value = documentNumber;
    document.getElementById("txtApplyToDocumentGuid").value = applytoDocumentGuid;

}

function CallCustomerInvoiceSearch() {
    document.getElementById("btnCustomerInvoiceSearch").click();

}

function ClearCustomerInvoiceSearch() {
    document.getElementById("btnClearCustomerInvoiceSearch").click();
}

function CallCustomerInvoiceRefreshButton() {
    document.getElementById("btnCustomerInvoiceRefresh").click();
    document.getElementById("btnClearCustomerInvoiceSearch").click();
}


function SetCustomerInvoiceProcessDetails(documentNumber, applytoDocumentGuid) {
    document.getElementById("txtApplyotDocumentCIP").value = documentNumber;
    document.getElementById("txtApplyotDocumentCIPGuid").value = applytoDocumentGuid;

}

function CallCustomerInvoiceProcessSearch() {
    document.getElementById("btnCustomerInvoiceProcessSearch").click();

}

function ClearCustomerInvoiceProcessSearch() {
    document.getElementById("btnClearCustomerInvoiceProcessSearch").click();
}

function CallCustomerInvoiceProcessRefreshButton() {  
    document.getElementById("btnCustomerInvoiceProcessRefresh").click();
    document.getElementById("btnClearCustomerInvoiceProcessSearch").click();
}



function ClearForm() {

    document.getElementById('ddlOpt_ReceivedType').selectedIndex = 0;
    document.getElementById('txtGoodsReceivedNoteNumber').value = '';
    document.getElementById('txtSupplier').value = '';
    document.getElementById('txtSupplierGuid').value = '';
    document.getElementById('txtSupplierDocumentNumber').value = '';
    document.getElementById('txtDate').value = '';
    document.getElementById('txtCurrency').value = '';
    document.getElementById('txtCurrencyGuid').value = '';
    document.getElementById('txtBatch').value = '';
    document.getElementById('txtBatchGuid').value = '';
    document.getElementById('txtSubTotal').value = '';
    document.getElementById('txtTradeDiscount').value = '';
    document.getElementById('txtFreight').value = '';
    document.getElementById('txtMiscellaneous').value = '';
    document.getElementById('txtTotal').value = '';

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


function SetSupplierDetails(supplier, supplierGuid) {

    document.getElementById("txtSupplier").value = supplier;
    document.getElementById("txtSupplierGuid").value = supplierGuid;

}

function CallSupplierSearch() {
    document.getElementById("btnSupplierSearch").click();

}

function ClearSupplierSearch() {
    document.getElementById("btnClearSupplierSearch").click();
}

function CallSupplierRefreshButton() {
    document.getElementById("btnSupplierRefresh").click();
    document.getElementById("btnClearSupplierSearch").click();
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



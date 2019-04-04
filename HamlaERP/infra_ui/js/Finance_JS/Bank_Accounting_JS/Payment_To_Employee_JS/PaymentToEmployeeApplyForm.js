function ClearForm() {

    document.getElementById('txtPaymentToEmployee').value = '';
    document.getElementById('txtApplyToDocumentEmployeeGeneralExpenses').value = '';
    document.getElementById('txtApplyToDocumentEmployeeGeneralExpensesGuid').value = '';
    document.getElementById('txtDueDate').value = '';
    document.getElementById('txtRemainingAmount').value = '';
    document.getElementById('txtApplyAmount').value = '';
    document.getElementById('ddloptType').selectedIndex = 0;
    document.getElementById('txtOrignalDocumentAmount').value = '';
    document.getElementById('txtDiscountDate').value = '';
    
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

function SetPaymentToEmployeeDetails(employeeName, paymentToEmployeeGuid) {

    document.getElementById("txtPaymentToEmployee").value = employeeName;
    document.getElementById("txtPaymentToEmployeeGuid").value = paymentToEmployeeGuid;

}

function CallPaymentToEmployeeSearch() {
    document.getElementById("btnPaymentToEmployeeSearch").click();

}

function ClearPaymentToEmployeeSearch() {
    document.getElementById("btnClearPaymentToEmployeeSearch").click();
}

function CallPaymentToEmployeeRefreshButton() {
    document.getElementById("btnPaymentToEmployeeRefresh").click();
    document.getElementById("btnClearPaymentToEmployeeSearch").click();
}


function SetApplyToDocumentEmployeeGeneralExpensesDetails(voucherNumber, employeeGeneralExpensesGuid) {

    document.getElementById("txtApplyToDocumentEmployeeGeneralExpenses").value = voucherNumber;
    document.getElementById("txtApplyToDocumentEmployeeGeneralExpensesGuid").value = employeeGeneralExpensesGuid;

}

function CallApplyToDocumentEmployeeGeneralExpensesSearch() {
    document.getElementById("btnApplyToDocumentEmployeeGeneralExpensesSearch").click();

}

function ClearApplyToDocumentEmployeeGeneralExpensesSearch() {
    document.getElementById("btnClearApplyToDocumentEmployeeGeneralExpensesSearch").click();
}

function CallApplyToDocumentEmployeeGeneralExpensesRefreshButton() {
    document.getElementById("btnApplyToDocumentEmployeeGeneralExpensesRefresh").click();
    document.getElementById("btnClearApplyToDocumentEmployeeGeneralExpensesSearch").click();
}


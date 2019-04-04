function ClearForm() {

    document.getElementById('txtGLAccountBudget').value = '';
    document.getElementById('txtFiscalPeriod').value = '';
    document.getElementById('txtPeriod').value = '';
    document.getElementById('txtAmount').value = '';
    document.getElementById('txtPeriodName').value = '';
    document.getElementById('txtPeriodDate').value = '';
    
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

function SetGLAccountBudgetDetails(accountNumber, gLAccountBudgetGuid) {

    document.getElementById("txtGLAccountBudget").value = accountNumber;
    document.getElementById("txtGLAccountBudgetGuid").value = gLAccountBudgetGuid;

}

function CallGLAccountBudgetSearch() {
    document.getElementById("btnGLAccountBudgetSearch").click();

}

function ClearGLAccountBudgetSearch() {
    document.getElementById("btnClearGLAccountBudgetSearch").click();
}

function CallGLAccountBudgetRefreshButton() {
    document.getElementById("btnGLAccountBudgetRefresh").click();
    document.getElementById("btnClearGLAccountBudgetSearch").click();
}
function SetFiscalPeriodDetails(period, fiscalperiodGuid) {

    document.getElementById("txtFiscalPeriod").value = period;
    document.getElementById("txtFiscalPeriodGuid").value = fiscalperiodGuid;

}

function CallFiscalPeriodSearch() {
    document.getElementById("btnFiscalPeriodSearch").click();

}

function ClearFiscalPeriodSearch() {
    document.getElementById("btnClearFiscalPeriodSearch").click();
}

function CallFiscalPeriodRefreshButton() {
    document.getElementById("btnFiscalPeriodRefresh").click();
    document.getElementById("btnClearFiscalPeriodSearch").click();
}

function ClearForm() {

    document.getElementById('txtGLAccount').value = '';
    document.getElementById('txtBudget').value = '';
    document.getElementById('ddlOpt_BasedOn').selectedIndex = 0;
    document.getElementById('ddlOpt_BudgetYear').selectedIndex = 0;
    document.getElementById('ddlOpt_CalculationMethod').selectedIndex = 0;
    document.getElementById('txtYear').value = '';
    document.getElementById('txtButdetId_SourceBudgetId').value = '';
    document.getElementById('txtPercentage').value = '';
    document.getElementById('txtAmount').value = '';
    document.getElementById('chkIsIncrease').checked = false;
    document.getElementById('chkDisplay').checked = false;
    document.getElementById('chkIncludeBiginningBalance').checked = false;
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

function SetGLAccountDetails(accountNumber, gLAccountGuid) {

    document.getElementById("txtGLAccount").value = accountNumber;
    document.getElementById("txtGLAccountGuid").value = gLAccountGuid;

}

function CallGLAccountSearch() {
    document.getElementById("btnGLAccountSearch").click();

}

function ClearGLAccountSearch() {
    document.getElementById("btnClearGLAccountSearch").click();
}

function CallGLAccountRefreshButton() {
    document.getElementById("btnGLAccountRefresh").click();
    document.getElementById("btnClearGLAccountSearch").click();
}
function SetBudgetDetails(budgetNumber, budgetGuid) {

    document.getElementById("txtBudget").value = budgetNumber
    document.getElementById("txtBudgetGuid").value = budgetGuid;

}

function CallBudgetSearch() {
    document.getElementById("btnBudgetSearch").click();

}

function ClearBudgetSearch() {
    document.getElementById("btnClearBudgetSearch").click();
}

function CallBudgetRefreshButton() {
    document.getElementById("btnBudgetRefresh").click();
    document.getElementById("btnClearBudgetSearch").click();
}

function SetSourceBudgetDetails(budgetNumber, budgetGuid) {

    document.getElementById("txtButdetId_SourceBudgetId").value = budgetNumber
    document.getElementById("txtButdetId_SourceBudgetGuid").value = budgetGuid;

}

function CallSourceBudgetSearch() {
    document.getElementById("btnSourceBudgetSearch").click();

}

function ClearSourceBudgetSearch() {
    document.getElementById("btnClearSourceBudgetSearch").click();
}

function CallSourceBudgetRefreshButton() {
    document.getElementById("btnSourceBudgetRefresh").click();
    document.getElementById("btnClearSourceBudgetSearch").click();
}

function ClearForm() {
    document.getElementById('txtBudgetNumber').value = '';
    document.getElementById('txtDescription').value = '';
    document.getElementById('txtGLAccount').value = '';
    document.getElementById('chkAnnual').checked = false;
    document.getElementById('ChkDisplay').checked = false;
    return false;
}
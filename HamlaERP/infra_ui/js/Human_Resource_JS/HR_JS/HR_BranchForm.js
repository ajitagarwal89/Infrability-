function ClearForm() {

    document.getElementById('txtBranchCode').value = '';
    document.getElementById('txtDescription').value = '';
    document.getElementById('ddlopt_CurrentyFiscalYear').selectedIndex = 0;
    document.getElementById('ddlopt_DepreciatedPeriod').selectedIndex=0;
    
    return false;
}

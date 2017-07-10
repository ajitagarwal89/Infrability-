function ClearForm() {
    document.getElementById('ddlOpt_Year').selectedIndex = 0;
    document.getElementById('txtFirstDate').value = '';
    document.getElementById('txtLastDate').value = '';
    document.getElementById('chckHistoricalYear').checked = false;
    document.getElementById('txtNumberOfPeriod').value = '';
    return false;
}
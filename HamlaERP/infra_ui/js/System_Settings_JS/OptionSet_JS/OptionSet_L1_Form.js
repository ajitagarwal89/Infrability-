function ClearForm() {
    document.getElementById('ddlTables').selectedIndex = 0;
    document.getElementById('ddlOptionSet').selectedIndex = 0;
    document.getElementById('ddlColoumnByTable').selectedIndex = 0;
    document.getElementById('txtOptionSetName').value = '';
    document.getElementById('txtOptionSetLable').value = '';
    document.getElementById('txtOptionSetValue').value = '';
    document.getElementById('txtTableName').value = '';
    return false;
}
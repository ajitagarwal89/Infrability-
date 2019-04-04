function ClearForm() {
    
    document.getElementById('ddlTables').selectedIndex = 0;
    document.getElementById('txtTableName').value = '';
    document.getElementById('ddlColoumnByTable').selectedIndex = 0;
    document.getElementById('txtOptionSetName').value = '';
    document.getElementById('ddlOptionSetId').selectedIndex = 0;
    document.getElementById('ddlOptionSet_L1Id').selectedIndex = 0;
    document.getElementById('ddlOptionSet_L2Id').selectedIndex = 0;
    document.getElementById('txtOptionSetLable').value = '';
    document.getElementById('txtOptionSetValue').value = '';
    return false;
}
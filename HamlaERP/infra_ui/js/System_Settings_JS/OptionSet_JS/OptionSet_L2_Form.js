function ClearForm() {
    document.getElementById('ddlOptionSetId').selectedIndex = 0;
    document.getElementById('ddlOptionSet_L1Id').selectedIndex = 0;
    document.getElementById('txtOptionSetLable').value = '';
    document.getElementById('txtOptionSetValue').value = '';
    return false;
}
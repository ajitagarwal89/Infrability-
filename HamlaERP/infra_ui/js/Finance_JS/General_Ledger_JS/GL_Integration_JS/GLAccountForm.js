function ClearForm() {
    document.getElementById('txtAccountNumber').value = '';
    document.getElementById('chckIsActive').checked = false;
    document.getElementById('chckAllowAccountEntry').checked = false;
    document.getElementById('txtGLAccountCategory').value = '';
    document.getElementById('chckPostingType').checked = false;
    document.getElementById('chckTypicalBalance').checked = false;
    document.getElementById('chckAppearInFinance').checked = false;
    document.getElementById('chckAppearInHR').checked = false;
    document.getElementById('chckAppearInProcurement').checked = false;
    document.getElementById('chckAppearInSystemSettings').checked = false;
    return false;
}

function SetGLAccountCategoryDetails(glaccountCategory, glaccountCategoryGuid) {
    document.getElementById("txtGLAccountCategory").value = glaccountCategory;

    document.getElementById("txtGLAccountCategoryGuid").value = glaccountCategoryGuid;
}

function CallGLAccountCategorySearch() {
    document.getElementById("btnGLAccountCategorySearch").click();

}

function ClearGLAccountCategorySearch() {
    document.getElementById("btnClearGLAccountCategorySearch").click();
}

function CallGLAccountCategoryRefreshButton() {
    document.getElementById("btnGLAccountCategoryRefresh").click();
    document.getElementById("btnClearGLAccountCategorySearch").click();
}

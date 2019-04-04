function ClearForm() {    
    document.getElementById('rdbBalanceSheet').checked = false;
    document.getElementById('rdbProfitAndLoss').checked = false;
    document.getElementById('chkAppearInFinance').checked = false;
    document.getElementById('chkAppearInHR').checked = false;
    document.getElementById('txtGLAccountCategory').value = '';
    document.getElementById('txtAccountNumber').value = '';
    document.getElementById('txtDescription').value = '';
    document.getElementById('chkAppearInProcurement').checked = false;
    document.getElementById('chkAppearInSystemSettings').checked = false;
    document.getElementById('chkInActive').checked = false;
    document.getElementById('chkAllowAccountEntry').checked = false;
    document.getElementById('rdbBalanceSheet').checked = false;
    document.getElementById('rdbProfitAndLoss').checked = false;
    document.getElementById('rdbDebit').checked = false;
    document.getElementById('rdbCredit').checked = false;
    document.getElementById('chkAppearInFinance').checked = false;
    document.getElementById('chkAppearInHR').checked = false;
    document.getElementById('ddlSegment01').selectedIndex = 0;
    document.getElementById('ddlSegment02').selectedIndex = 0;
    document.getElementById('ddlSegment03').selectedIndex = 0;
    document.getElementById('ddlSegment04').selectedIndex = 0;
    document.getElementById('ddlSegment05').selectedIndex = 0;
    document.getElementById('ddlSegment06').selectedIndex = 0;
    document.getElementById('ddlSegment07').selectedIndex = 0;
    document.getElementById('ddlSegment08').selectedIndex = 0;
    document.getElementById('ddlSegment09').selectedIndex = 0;
    document.getElementById('ddlSegment10').selectedIndex = 0;

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

function HideLabel() {
    
    var seconds = 5;
    setTimeout(function () {
        document.getElementById("<%=divSuccess.ClientID %>").style.display = "none";
    }, seconds * 1000);
};


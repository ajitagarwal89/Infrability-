function ClearForm() {
    document.getElementById('txtGLAccount').value = '';
    document.getElementById('txtGLAccountGuid').value = '';
    document.getElementById('txtGoodsReceivedNote').value = '';
    document.getElementById('txtGoodsReceivedNoteGuid').value = '';
    document.getElementById('ddlopt_GLAccountType').selectedIndex=0;
    document.getElementById('txtDescription').value = '';
    document.getElementById('txtDistributionReference').value = '';
    document.getElementById('txtDebit').value = '';
    document.getElementById('txtCredit').value = '';
   
    return false;
}



function SetGLAccountDetails(accountNumber, gLAccountGuid) {

    document.getElementById("txtGLAccount").value = accountNumber
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

function SetGoodsReceivedNoteDetails(goodsReceivedNoteNumber, goodsReceivedNoteGuid) {

    document.getElementById("txtGoodsReceivedNote").value = goodsReceivedNoteNumber;
    document.getElementById("txtGoodsReceivedNoteGuid").value = goodsReceivedNoteGuid;

}

function CallGoodsReceivedNoteSearch() {
    document.getElementById("btnGoodsReceivedNoteSearch").click();

}

function ClearGoodsReceivedNoteSearch() {
    document.getElementById("btnClearGoodsReceivedNoteSearch").click();
}

function CallGoodsReceivedNoteRefreshButton() {
    document.getElementById("btnGoodsReceivedNoteRefresh").click();
    document.getElementById("btnClearGoodsReceivedNoteSearch").click();
}


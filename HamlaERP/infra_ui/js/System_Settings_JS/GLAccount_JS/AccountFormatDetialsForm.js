function ClearForm() {
    document.getElementById("txtGLAccountFormat").value = '';
    document.getElementById("txtGLAccountFormatGuid").value = '';
    document.getElementById("chkIsActive").checked = false;
    document.getElementById('txtSequenceNumber').value = '';
    document.getElementById('txtSegmentNumber').value = '';
    document.getElementById('txtSegmentName').value = '';
    document.getElementById('txtMaxLength').value = '';
    document.getElementById('txtLength').value = '';

    return false;
}



function SetGLAccountFormatDetails(GLAccountFormat, GLAccountFormatGuid) {

    document.getElementById("txtGLAccountFormat").value = GLAccountFormat;
    document.getElementById("txtGLAccountFormatGuid").value = GLAccountFormatGuid;

}

function CallGLAccountFormatSearch() {
    document.getElementById("btnGLAccountFormatSearch").click();

}

function ClearGLAccountFormatSearch() {
    document.getElementById("btnClearGLAccountFormatSearch").click();
}

function CallGLAccountFormatRefreshButton() {
    document.getElementById("btnAccountFormatRefresh").click();
    document.getElementById("btnClearGLAccountFormatSearch").click();
}

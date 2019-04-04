
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(SeriesLable, OriginLabel, PostToGL, PostThroughGLFile, AllowTransactionPosting, IncludeMultiCurrencyInfo, VerifyNumberOfTransaction, VerifyBatchAmount, Transaction, Batch, lblGvRowId) {
    document.getElementById("lblSeriesLable").innerHTML = SeriesLable;
    document.getElementById("lblOriginLabel").innerHTML = OriginLabel;
    document.getElementById("lblPostToGL").innerHTML = PostToGL;
    document.getElementById("lblPostThroughGLFile").innerHTML = PostThroughGLFile;
    document.getElementById("lblAllowTransactionPosting").innerHTML = AllowTransactionPosting;
    document.getElementById("lblIncludeMultiCurrencyInfo").innerHTML = IncludeMultiCurrencyInfo;
    document.getElementById("lblVerifyNumberOfTransaction").innerHTML = VerifyNumberOfTransaction;
    document.getElementById("lblVerifyBatchAmount").innerHTML = VerifyBatchAmount;
    document.getElementById("lblTransaction").innerHTML = Transaction;
    document.getElementById("lblBatch").innerHTML = Batch;

    document.getElementById("lblGvRowId").innerHTML = lblGvRowId;
    var maxrows = document.getElementById('gvData').rows.length - 1;
    var num = document.getElementById('lblGvRowId').innerHTML.split('_');
    if (num[1] == maxrows) {
        document.getElementById('next').class = 'btn btn-default disabled';
    }
    else {
        document.getElementById('next').class = 'btn btn-default';
    }
    if (num[1] == 1) {
        document.getElementById('prev').class = 'btn btn-default disabled';
    }
    else {
        document.getElementById('prev').class = 'btn btn-default';
    }
}

function showNextRecord() {
    var id = document.getElementById('lblGvRowId').innerHTML.split('_');
    var lnk = parseInt(id[1]) + 1;
    document.getElementById('lnkViewNextPrev_' + lnk).click();
}

function showPrevRecord() {
    var id = document.getElementById('lblGvRowId').innerHTML.split('_');
    var lnk = parseInt(id[1]) - 1;
    document.getElementById('lnkViewNextPrev_' + lnk).click();
}

function CallMainSearch() {
    document.getElementById("btnMainSearch").click();
}

function ClearMainSearch() {
    document.getElementById("btnClearMainSearch").click();
}
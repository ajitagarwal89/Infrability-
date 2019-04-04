
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(assetBookSetupCode, description, lblGvRowId) {
    document.getElementById("lblAssetBookGroupSetupCode").innerHTML = assetBookSetupCode;
    document.getElementById("lblAssetBookSetup").innerHTML = description;
    document.getElementById("lblAssetGroup").innerHTML = description
    document.getElementById("lblDepreciationMethod").innerHTML = description
    document.getElementById("lblAveragingConvention").innerHTML = description
    document.getElementById("lblOriginalLifeYear").innerHTML = description
    document.getElementById("lblOriginalLifeDay").innerHTML = description
    document.getElementById("lblScrapValue").innerHTML = description
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
    //
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
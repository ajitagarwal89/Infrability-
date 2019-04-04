
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(tableName, optionSetName, tbl_OptionSetLabel, tbl_OptionSetValue, optionSetLabel, optionSetValue, tbl_OptionSet_L1Lable, tbl_OptionSet_L1Value, gvRowId) {

    document.getElementById("lblTableName").innerHTML = tableName;
    document.getElementById("lblOptionSetName").innerHTML = optionSetName;
    document.getElementById("lbltbl_OptionSetLabel").innerHTML = tbl_OptionSetLabel;
    document.getElementById("lbltbl_OptionSetValue").innerHTML = tbl_OptionSetValue;
    document.getElementById("lblOptionSetLabel").innerHTML = optionSetLabel;
    document.getElementById("lblOptionSetValue").innerHTML = optionSetValue;
    document.getElementById("lbltbl_OptionSet_L1Lable").innerHTML = tbl_OptionSet_L1Lable;
    document.getElementById("lbltbl_OptionSet_L1Value").innerHTML = tbl_OptionSet_L1Value;
    document.getElementById("lblGvRowId").innerHTML = gvRowId;
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
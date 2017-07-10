
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(opt_BatchTypeLable, batchName, opt_OriginLable, opt_FrequencyLable, daysToIncrement, lastDatePosted, comment, numberOfTimesPosted, controlJournalEntries, actualJournalEntries, lblGvRowId) {
    document.getElementById("lblOpt_BatchTypeLable").innerHTML = opt_BatchTypeLable;
    document.getElementById("lblBatchName").innerHTML = batchName;
    document.getElementById("lblOpt_OriginLable").innerHTML = opt_OriginLable;
    document.getElementById("lblOpt_FrequencyLable").innerHTML = opt_FrequencyLable;
    document.getElementById("lblDaysToIncrement").innerHTML = daysToIncrement;
    document.getElementById("lblLastDatePosted").innerHTML = lastDatePosted;
    document.getElementById("lblComment").innerHTML = comment;
    document.getElementById("lblNumberOfTimesPosted").innerHTML = numberOfTimesPosted;
    document.getElementById("lblControlJournalEntries").innerHTML = controlJournalEntries;
    document.getElementById("lblActualJournalEntries").innerHTML = actualJournalEntries;

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
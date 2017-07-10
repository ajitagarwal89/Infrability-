
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function SetDetails(number, description, segment01Name, segment02Name, lblGvRowId) {
   
    document.getElementById("lblNumber").innerHTML = number;
    document.getElementById("lblDescription").innerHTML = description;
    document.getElementById("lblSegment01Name").innerHTML = segment01Name;
    document.getElementById("lblSegment02Name").innerHTML = segment02Name;
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
    //alert(id);
    document.getElementById('lnkViewNextPrev_' + lnk).click();
}

function showPrevRecord() {
  
    var id = document.getElementById('lblGvRowId').innerHTML.split('_');
    var lnk = parseInt(id[1]) - 1;
    //alert(id)
    document.getElementById('lnkViewNextPrev_' + lnk).click();
}

function CallMainSearch() {
    document.getElementById("btnMainSearch").click();
}

function ClearMainSearch() {
    document.getElementById("btnClearMainSearch").click();
}


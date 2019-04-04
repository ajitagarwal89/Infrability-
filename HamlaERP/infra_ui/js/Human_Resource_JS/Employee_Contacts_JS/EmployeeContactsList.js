
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});


function setDetails(employeeName,contacts,countryName,relationship,homePhone,WorkPhone,Ext,address,city,state,zipCode, lblGvRowId) {

    document.getElementById("lblEmployeeName").innerHTML = employeeName;
    document.getElementById("lblContact").innerHTML = contacts;
    document.getElementById("lblCountryName").innerHTML = countryName;
    document.getElementById("lblRelationship").innerHTML = relationship;
    document.getElementById("lblHomePhone").innerHTML = homePhone;
    document.getElementById("lblWorkPhone").innerHTML = WorkPhone;
    document.getElementById("lblExt").innerHTML = Ext;
    document.getElementById("lblAddress").innerHTML = address;
    document.getElementById("lblCity").innerHTML = city;
    document.getElementById("lblState").innerHTML = state;
    document.getElementById("lblZipCode").innerHTML = zipCode;
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
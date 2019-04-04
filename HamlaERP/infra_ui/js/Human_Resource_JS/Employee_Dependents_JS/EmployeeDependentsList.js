
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function SetDetails(employeeName,hR_Department,firstName,middleName,lastName,gender,homePhone,workPhone,ext,address1,address2,city,state,zipCode,lblGvRowId) {

    
    document.getElementById("lblEmployeeName").innerHTML = employeeName;
    document.getElementById("lblHRDepartment").innerHTML = hR_Department;
    document.getElementById("lblFirstName").innerHTML = firstName;
    document.getElementById("lblMiddleName").innerHTML = middleName;
    document.getElementById("lblLastName").innerHTML = lastName;
    document.getElementById("lblGender").innerHTML = gender;
    document.getElementById("lblHomePhone").innerHTML = homePhone;
    document.getElementById("lblWorkPhone").innerHTML = workPhone;
    document.getElementById("lblExt").innerHTML = ext;
    document.getElementById("lblAddress1").innerHTML = address1;
    document.getElementById("lblAddress2").innerHTML = address2;
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
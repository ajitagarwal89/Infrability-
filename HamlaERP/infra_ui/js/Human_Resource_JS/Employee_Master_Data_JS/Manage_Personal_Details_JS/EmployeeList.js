
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function SetDetails(employeeCode,firstName,middleName,lastName,contact,phone,mobile,email,address,hR_Division,hR_Department,hR_Branch,hR_Position,hR_Supervisor, lblGvRowId) {
    
    document.getElementById("lblEmployeeCode").innerHTML = employeeCode;
    document.getElementById("lblFirstName").innerHTML = firstName;
    document.getElementById("lblMiddleName").innerHTML = middleName;
    document.getElementById("lblLastName").innerHTML = lastName;
    document.getElementById("lblContact").innerHTML = contact;
    document.getElementById("lblPhone").innerHTML = phone;
    document.getElementById("lblMobile").innerHTML = mobile;
    document.getElementById("lblEmail").innerHTML = email;
    document.getElementById("lblAddress").innerHTML = address;
    document.getElementById("lblHR_DivisionCode").innerHTML = hR_Division;
    document.getElementById("lblHR_DepartmentCode").innerHTML = hR_Department;
    document.getElementById("lblHR_BranchCode").innerHTML = hR_Branch;
    document.getElementById("lblHR_PositionCode").innerHTML = hR_Position;
    document.getElementById("lblHR_SupervisorCode").innerHTML = hR_Supervisor;
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
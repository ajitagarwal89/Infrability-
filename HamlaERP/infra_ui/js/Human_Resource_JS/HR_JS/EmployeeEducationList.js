
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(EmployeeCode, Employee, School, Major, Year, Degree, GPA, Note, lblGvRowId) {
    document.getElementById("lblEmployeeCode").innerHTML = EmployeeCode;
    document.getElementById("lblEmployee").innerHTML = Employee;
    document.getElementById("lblSchool").innerHTML = School;
    document.getElementById("lblMajor").innerHTML = Major;
    document.getElementById("lblYear").innerHTML = Year;
    document.getElementById("lblDegree").innerHTML = Degree;
    document.getElementById("lblGPA").innerHTML = GPA;
    document.getElementById("lblNote").innerHTML = Note;
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
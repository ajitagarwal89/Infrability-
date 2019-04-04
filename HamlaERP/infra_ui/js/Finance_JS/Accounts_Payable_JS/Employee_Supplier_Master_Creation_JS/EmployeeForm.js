function ClearForm() {

    document.getElementById('txtEmployeeCode').value = '';
    document.getElementById('txtFirstName').value = '';
    document.getElementById('txtMiddleName').value = '';
    document.getElementById('txtLastName').value = '';
    document.getElementById('txtContact').value = '';
    document.getElementById('ddlOpt_EmployeeNationalType').selectedIndex = 0;
    document.getElementById('txtIqamaBathaqaNumber').value = '';
    document.getElementById('txtAddress').value = '';
    document.getElementById('txtCity').value = '';
    document.getElementById('txtState').value = '';
    document.getElementById('txtZipCode').value = '';
    document.getElementById('txtCountry').value = '';
    document.getElementById('txtCountryGuid').value = ''; 
    document.getElementById('txtMobile').value = '';
    document.getElementById('txtPhone').value = '';
    document.getElementById('txtFaxNo').value = '';
    document.getElementById('txtEmail').value = '';
    document.getElementById('txtHR_Division').value = '';
    document.getElementById('txtHR_DivisionGuid').value = '';
    document.getElementById('txtHR_Department').value = '';
    document.getElementById('txtHR_DepartmentGuid').value = '';
    document.getElementById('txtHR_Position').value = '';
    document.getElementById('txtHR_PositionGuid').value = '';
    document.getElementById('txtHR_Branch').value = '';
    document.getElementById('txtHR_BranchGuid').value = '';
    document.getElementById('txtHR_Supervisor').value = '';
    document.getElementById('txtHR_SupervisorGuid').value = '';
    document.getElementById('txtSeniorityDate').value = '';
    document.getElementById('txtHireDate').value = '';
    document.getElementById('txtAdjustedHireDate').value = '';
    document.getElementById('txtLastWorkingDay').value = '';
    document.getElementById('txtInactivatedDate').value = '';
    document.getElementById('txtReason').value = '';
    document.getElementById('txtCountry_Nationality').value = '';
    document.getElementById('txtCountry_NationalityGuid').value = '';
    document.getElementById('rdbActive').checked = false;
    document.getElementById('rdbInActive').checked = false;
    document.getElementById('ddlopt_EmploymentType').selectedIndex = 0;
    document.getElementById('txtDOB').value = '';
    document.getElementById('rdbMale').checked = false;
    document.getElementById('rdbFemale').checked = false;
    document.getElementById('rdbMARRIED').checked = false;
    document.getElementById('rdbSINGLE').checked = false;
    document.getElementById('txtWorkHoursPerYear').value = '';
    document.getElementById('txtPassportNumber').value = '';
    document.getElementById('txtPassportExp').value = '';
    document.getElementById('txtIqamaBathaqaExp').value = '';



    return false;
}

function SetCountryDetails(countryName, countryGuid) {
    document.getElementById("txtCountry").value = countryName;
    document.getElementById("txtCountryGuid").value = countryGuid;
}

function CallCountrySearch() {
    document.getElementById("btnCountrySearch").click();

}

function ClearCountrySearch() {
    document.getElementById("btnClearCountrySearch").click();
}

function CallCountryRefreshButton() {
    document.getElementById("btnCountryRefresh").click();
    document.getElementById("btnClearCountrySearch").click();
}
function SetHR_DivisionDetails(HR_DivisionCode, HR_DivisionGuid) {
    
    document.getElementById("txtHR_Division").value = HR_DivisionCode;
    document.getElementById("txtHR_DivisionGuid").value = HR_DivisionGuid;
}

function CallHR_DivisionSearch() {
    document.getElementById("btnHR_DivisionSearch").click();

}

function ClearHR_DivisionSearch() {
    document.getElementById("btnClearHR_DivisionSearch").click();
}

function CallHR_DivisionRefreshButton() {
    document.getElementById("btnHR_DivisionRefresh").click();
    document.getElementById("btnClearHR_DivisionSearch").click();
}


function SetHR_DepartmentDetails(HR_DepartmentCode, HR_DepartmentGuid) {
    document.getElementById("txtHR_Department").value = HR_DepartmentCode;
    document.getElementById("txtHR_DepartmentGuid").value = HR_DepartmentGuid;
}

function CallHR_DepartmentSearch() {
    document.getElementById("btnHR_DepartmentSearch").click();

}

function ClearHR_DepartmentSearch() {
    document.getElementById("btnClearHR_DepartmentSearch").click();
}

function CallHR_DepartmentRefreshButton() {
    document.getElementById("btnHR_DepartmentRefresh").click();
    document.getElementById("btnClearHR_DepartmentSearch").click();
}


function SetHR_BranchDetails(HR_BranchCode, HR_BranchGuid) {
    document.getElementById("txtHR_Branch").value = HR_BranchCode;
    document.getElementById("txtHR_BranchGuid").value = HR_BranchGuid;
}

function CallHR_BranchSearch() {
    document.getElementById("btnHR_BranchSearch").click();

}

function ClearHR_BranchSearch() {
    document.getElementById("btnClearHR_BranchSearch").click();
}

function CallHR_BranchRefreshButton() {
    document.getElementById("btnHR_BranchRefresh").click();
    document.getElementById("btnClearHR_BranchSearch").click();
}

function SetHR_PositionDetails(HR_PositionCode, HR_PositionGuid) {
    document.getElementById("txtHR_Position").value = HR_PositionCode;
    document.getElementById("txtHR_PositionGuid").value = HR_PositionGuid;
}

function CallHR_PositionSearch() {
    document.getElementById("btnHR_PositionSearch").click();

}

function ClearHR_PositionSearch() {
    document.getElementById("btnClearHR_PositionSearch").click();
}

function CallHR_PositionRefreshButton() {
    document.getElementById("btnHR_PositionRefresh").click();
    document.getElementById("btnClearHR_PositionSearch").click();
}

function SetHR_SupervisorDetails(HR_SupervisorCode, HR_SupervisorGuid) {
    document.getElementById("txtHR_Supervisor").value = HR_SupervisorCode;
    document.getElementById("txtHR_SupervisorGuid").value = HR_SupervisorGuid;
}

function CallHR_SupervisorSearch() {
    document.getElementById("btnHR_SupervisorSearch").click();

}

function ClearHR_SupervisorSearch() {
    document.getElementById("btnClearHR_SupervisorSearch").click();
}

function CallHR_SupervisorRefreshButton() {
    document.getElementById("btnHR_SupervisorRefresh").click();
    document.getElementById("btnClearHR_SupervisorSearch").click();
}

function SetCountry_NationalityDetails(Country_NationalityName, Country_NationalityGuid) {

    
    document.getElementById("txtCountry_Nationality").value = Country_NationalityName;
    document.getElementById("txtCountry_NationalityGuid").value = Country_NationalityGuid;
}

function CallCountry_NationalitySearch() {
    document.getElementById("btnCountry_NationalitySearch").click();

}

function ClearCountry_NationalitySearch() {
    document.getElementById("btnClearCountry_NationalitySearch").click();
}

function CallCountry_NationalityRefreshButton() {
    
    document.getElementById("btnCountry_NationalityRefresh").click();
    document.getElementById("btnClearCountry_NationalitySearch").click();
}


//function SetEmployeeGroupDetails(employeeGroupName, employeeGroupGuid) {
//    document.getElementById("txtEmployeeGroup").value = employeeGroupName;
//    document.getElementById("txtEmployeeGroupGuid").value = employeeGroupGuid;
//}

//function CallEmployeeGroupSearch() {
//    document.getElementById("btnEmployeeGroupSearch").click();

//}

//function ClearEmployeeGroupSearch() {
//    document.getElementById("btnClearEmployeeGroupSearch").click();
//}

//function CallEmployeeGroupRefreshButton() {
//    document.getElementById("btnEmployeeGroupRefresh").click();
//    document.getElementById("btnClearEmployeeGroupSearch").click();
//}
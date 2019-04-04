
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(bankCode, bankName, address, city, state, zipCode, country, phone, mobile, fax, branch, iban, lblGvRowId) {
    document.getElementById("lblBankCode").innerHTML = bankCode;
    document.getElementById("lblBankName").innerHTML = bankName;
    document.getElementById("lblAddress").innerHTML = address;
    document.getElementById("lblCity").innerHTML = city;
    document.getElementById("lblState").innerHTML = state;
    document.getElementById("lblZipCode").innerHTML = zipCode;
    document.getElementById("lblCountry").innerHTML = country;
    document.getElementById("lblPhone").innerHTML = phone;
    document.getElementById("lblMobile").innerHTML = mobile;
    document.getElementById("lblFax").innerHTML = fax;
    document.getElementById("lblBranch").innerHTML = branch;
    document.getElementById("lblIban").innerHTML = iban;
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


//Allow only integer Values
function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if ((charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57)))
        return false;
    return true;
}
// Accept Only AlphaNumeric
function isAlphaNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if ((charCode > 31
        && (charCode < 48 || charCode > 57)) && ((charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122)))
        return false;
    return true;
}
// Accept Only Alphabets
function isAlphaKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode != 8 && charCode != 32 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
        return false;
    return true;
}

//Special Key
function isSpecialKey1(evt) {
    var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : ((evt.which) ? evt.which : 0));
    if (charCode > 37 && charCode > 39 && charCode > 31 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 48 || charCode > 57) && (charCode != 47)) {
        return false;
    }
}
//Special Key
function isSpecialKey2(evt) {
    var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : ((evt.which) ? evt.which : 0));
    if (charCode != 39 && charCode != 37 && charCode > 32 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 48 || charCode > 57) && (charCode != 45)) {
        return false;
    }
}

//For Address

function isAddress(evt) {
    var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : ((evt.which) ? evt.which : 0));
    if (charCode != 37 && charCode != 39 && charCode > 32 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 48 || charCode > 57) && (charCode != 47) && (charCode != 44) && (charCode != 45) && (charCode != 46) && (charCode != 58)) {
        return false;
    }
}
//For Special character
function isSpecialKey(evt) {
    var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : ((evt.which) ? evt.which : 0));
    if (charCode > 32 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 48 || charCode > 57)) {
        return false;
    }
}
//Number include  point
function isNumberKeyPoint(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57))
        return false;
    return true;
}
// Number With plus Symbol
function isNumberKeyPlus(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode > 31
        && (charCode < 48 || charCode > 57) && (charCode != 47))
        return false;
    return true;
}
//Date formate MM/DD/YYYY
function isValidDate(subject) {
    if (subject.match(/^(?:(0[1-9]|1[012])[\- \/.](0[1-9]|[12][0-9]|3[01])[\- \/.](19|20)[0-9]{2})$/)) {
        return true;
    } else {
        return false;
    }
}

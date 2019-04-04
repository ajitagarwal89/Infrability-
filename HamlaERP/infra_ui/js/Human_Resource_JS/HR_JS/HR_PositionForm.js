function ClearForm() {

    document.getElementById('txtPositionCode').value = '';
    document.getElementById('txtDescription').value = '';
    document.getElementById('txtPayCodes').value = '';
    document.getElementById('txtPayCodesGuid').value = '';
    document.getElementById('txtHR_PositionId_Self').value = '';
    document.getElementById('txtHR_PositionId_SelfGuid').value = '';

    return false;
}


//function SetPayCodesDetails(accountNumber, PayCodesGuid) {

//    document.getElementById("txtPayCodes").value = accountNumber
//    document.getElementById("txtPayCodesGuid").value = PayCodesGuid;

//}

//function CallPayCodesSearch() {
//    document.getElementById("btnPayCodesSearch").click();

//}

//function ClearPayCodesSearch() {
//    document.getElementById("btnClearPayCodesSearch").click();
//}

//function CallPayCodesRefreshButton() {
//    document.getElementById("btnPayCodesRefresh").click();
//    document.getElementById("btnClearPayCodesSearch").click();
//}

function SetHR_PositionId_SelfDetails(hR_PositionId_SelfNumber, hR_PositionId_SelfGuid) {

    document.getElementById("txtHR_PositionId_Self").value = hR_PositionId_SelfNumber;
    document.getElementById("txtHR_PositionId_SelfGuid").value = hR_PositionId_SelfGuid;

}

function CallHR_PositionId_SelfSearch() {
    document.getElementById("btnHR_PositionId_SelfSearch").click();

}

function ClearHR_PositionId_SelfSearch() {
    document.getElementById("btnClearHR_PositionId_SelfSearch").click();
}

function CallHR_PositionId_SelfRefreshButton() {
    document.getElementById("btnHR_PositionId_SelfRefresh").click();
    document.getElementById("btnClearHR_PositionId_SelfSearch").click();
}


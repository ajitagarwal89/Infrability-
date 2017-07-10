
function SetDetails(assetCode, shortName, tbl_AssetGroup, type, tbl_AssetAndGroupAccount, acquisitionDate,
    acquisitionCost, currencyName, tbl_Location, tbl_PhysicalLocation, assetBarcode, tbl_Employee,
    manufacturerName, quantity, lastMaintenanceDate, serialNumber, modalNumber, wrrantyDate, lblGvRowId) {   
    document.getElementById("lblAssetCode").innerHTML = assetCode;
    document.getElementById("lblShortName").innerHTML = shortName;
    document.getElementById("lbltbl_AssetGroup").innerHTML = tbl_AssetGroup;
    document.getElementById("lblType").innerHTML = type;
    document.getElementById("lbltbl_AssetAndGroupAccount").innerHTML = tbl_AssetAndGroupAccount;
    document.getElementById("lblAcquisitionDate").innerHTML = acquisitionDate;
    document.getElementById("lblAcquisitionCost").innerHTML = acquisitionCost;
    document.getElementById("lblCurrencyName").innerHTML = currencyName;
    document.getElementById("lbltbl_Location").innerHTML = tbl_Location;
    document.getElementById("lbltbl_PhysicalLocation").innerHTML = tbl_PhysicalLocation;
    document.getElementById("lblAssetBarcode").innerHTML = assetBarcode;
    document.getElementById("lbltbl_Employee").innerHTML = tbl_Employee;
    document.getElementById("lblManufacturerName").innerHTML = manufacturerName;
    document.getElementById("lblQuantity").innerHTML = quantity;
    document.getElementById("lblLastMaintenanceDate").innerHTML = lastMaintenanceDate;
    document.getElementById("lblSerialNumber").innerHTML = serialNumber;
    document.getElementById("lblModalNumber").innerHTML = modalNumber;
    document.getElementById("lblWarrantyDate").innerHTML = wrrantyDate;
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
    return false;
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



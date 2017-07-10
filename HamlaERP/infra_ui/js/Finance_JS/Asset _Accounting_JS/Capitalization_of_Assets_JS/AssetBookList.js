
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function setDetails(asset,assetBookCode,placeInServiceDate,depreciatedDueDate,beginYearCost,costBasis,scrapValue,yearlyDepreciationRate,currentDepreciation,netBookValue,depreciationMethod,averagingConvention,fullDepreciationFlag,status,originalLifeYear,originalLifeDay, lblGvRowId) {
    document.getElementById("lblAsset").innerHTML = asset;
    document.getElementById("lblAssetBookCode").innerHTML = assetBookCode;
    document.getElementById("lblPlaceInServiceDate").innerHTML = placeInServiceDate;
    document.getElementById("lblDepreciatedDueDate").innerHTML = depreciatedDueDate;
    document.getElementById("lblBeginYearCost").innerHTML = beginYearCost;
    document.getElementById("lblCostBasis").innerHTML = costBasis;
    document.getElementById("lblScrapValue").innerHTML = scrapValue;
    document.getElementById("lblYearlyDepreciationRate").innerHTML = yearlyDepreciationRate;
    document.getElementById("lblCurrentDepreciation").innerHTML = currentDepreciation;
    document.getElementById("lblNetBookValue").innerHTML = netBookValue;
    document.getElementById("lblDepreciationMethod").innerHTML = depreciationMethod;
    document.getElementById("lblAveragingConvention").innerHTML = averagingConvention;
    document.getElementById("lblStatus").innerHTML = status;
    document.getElementById("lblOriginalLifeYear").innerHTML = originalLifeYear;
    document.getElementById("lblOriginalLifeDay").innerHTML = originalLifeDay;
    document.getElementById("lblFullDepreciationFlag").innerHTML = fullDepreciationFlag;
    
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
$('#sidebar-wrapper').on('click', function () {
    $(this).toggleClass('sidebar-open');
});

function SetDetails(accountNumber,budgetNumber,opt_BasedOn,opt_BudgetYear,opt_CalculationMethod,year,percentage,amount,isIncrease,display,includeBiginningBalance, lblGvRowId) {
    document.getElementById("lblAccountNumber").innerHTML =accountNumber;
    document.getElementById("lblBudgetNumber").innerHTML = budgetNumber;
    document.getElementById("lblBasedOn").innerHTML = opt_BasedOn;
    document.getElementById("lblOpt_BudgetYear").innerHTML = opt_BudgetYear;
    document.getElementById("lblOpt_CalculationMethod").innerHTML = opt_CalculationMethod;
    document.getElementById("lblYear").innerHTML = year;
    document.getElementById("lblPercentage").innerHTML = percentage; 

    document.getElementById("lblAmount").innerHTML = amount;
    document.getElementById("lblIsIncrease").innerHTML = isIncrease;
    document.getElementById("lblDisplay").innerHTML = display; 
    document.getElementById("lblIncludeBiginningBalance").innerHTML = includeBiginningBalance
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
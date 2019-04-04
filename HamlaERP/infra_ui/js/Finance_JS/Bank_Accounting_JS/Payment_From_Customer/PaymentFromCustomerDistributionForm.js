function ClearForm() {
  
    document.getElementById('txtCustomer').value = '';
    document.getElementById('txtCustomerGuid').value = '';
    document.getElementById('txtGLAccount').value = '';
    document.getElementById('txtGLAccountGuid').value = '';
    document.getElementById("ddlOptionType").selectedIndex = 0;
    document.getElementById("txtDebit").value = '';
    document.getElementById("txtOriginatingDebit").value = '';
    document.getElementById("txtCredit").value = '';
    document.getElementById("txtOriginatingCredit").value = '';
    document.getElementById("txtDescription").value = '';
    document.getElementById("txtDistributionReference").value = '';      

    return false;
}

function SetCustomerDetails(customer, customerGuid) {

    document.getElementById("txtCustomer").value = customer;
    document.getElementById("txtCustomerGuid").value = customerGuid;
}

function CallCustomerSearch() {
    document.getElementById("btnCustomerSearch").click();

}

function ClearCustomerSearch() {
    document.getElementById("btnClearCustomerSearch").click();
}

function CallCustomerRefreshButton() {
   
    document.getElementById("btnCustomerRefresh").click();
    document.getElementById("btnClearCustomerSearch").click();
}

function SetGLAccountDetails(gLAccount, gLAccountGuid) {

    document.getElementById("txtGLAccount").value = gLAccount;
    document.getElementById("txtGLAccountGuid").value = gLAccountGuid;
}

function CallGLAccountSearch() {
    document.getElementById("btnGLAccountSearch").click();

}

function ClearGLAccountSearch() {
    document.getElementById("btnClearGLAccountSearch").click();
}

function CallGLAccountRefreshButton() {
    
    document.getElementById("btnGLAccountRefresh").click();
    document.getElementById("btnClearGLAccountSearch").click();
}

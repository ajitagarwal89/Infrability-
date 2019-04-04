function ClearForm() {
   
    document.getElementById('ddlSeries').selectedIndex == 0;
   
    document.getElementById('ddlOrigin').selectedIndex == 0;
    
    document.getElementById('chkPostToGL').checked = false;
    
    document.getElementById('chkPostThroughGLFile').checked = false;
    
    document.getElementById('chkAllowTransactionPosting').checked = false;
    
    document.getElementById('chkIncludeMultiCurrencyInfo').checked = false;
   
    document.getElementById('chkVerifyNumberOfTransaction').checked = false;
    
    document.getElementById('chkVerifyBatchAmount').checked = false;
    
    document.getElementById('chkTransaction').checked = false;
    
    document.getElementById('chkBatch').checked = false;
    
    document.getElementById('chkUseAccountSetting').checked = false;
   
    document.getElementById('chkPostingDateFromBatch').checked = false;
    
    document.getElementById('chkPostingDateFromTrx').checked = false;
    
    document.getElementById('chkIfExistingBatchAppend').checked = false;
    
    document.getElementById('chkIfExistingBatchCreateNew').checked = false;
   
    document.getElementById('chkRequireBatchApproval').checked = false;
    
     document.getElementById('txtBatchApprovalPassword').value = '';   
    return false;
}
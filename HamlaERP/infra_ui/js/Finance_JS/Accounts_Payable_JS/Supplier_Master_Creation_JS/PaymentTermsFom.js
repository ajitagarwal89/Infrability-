function ClearForm() {
    
    document.getElementById('txtName').value = '';
    document.getElementById('txtDueInDays').value = '';
    document.getElementById('txtDiscountInDays').value = '';
    document.getElementById('ddlOpt_DiscountType').value = '';
    document.getElementById('txtDiscountTypeValue').value = '';
    document.getElementById('chkSalesOrPurchase').value = '';
    
    return false;
}

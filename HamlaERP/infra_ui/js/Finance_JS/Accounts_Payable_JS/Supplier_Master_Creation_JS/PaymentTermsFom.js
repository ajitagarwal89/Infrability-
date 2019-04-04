function ClearForm() {
   
    document.getElementById('ddlOpt_DiscountType').selectedIndex = 0;
    document.getElementById('chkSalesOrPurchase').checked = false;
    document.getElementById('txtName').value = '';
    document.getElementById('txtDueInDays').value = '';
    document.getElementById('txtDiscountInDays').value = '';
    
    document.getElementById('txtDiscountTypeValue').value = '';
   
    
    return false;
}

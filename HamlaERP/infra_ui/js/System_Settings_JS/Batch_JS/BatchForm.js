function ClearForm() {   
    document.getElementById('txtBatchName').value = '';
    document.getElementById('txtComment').value = '';
    document.getElementById('txtRecurringPosting').value = '';
    document.getElementById('txtDaysToIncrement').value = '';
    document.getElementById('txtNumberOfdays').value = '';
    document.getElementById('txtJournalEntries').value = '';
    document.getElementById('txtActualJournalEntries').value = '';
    document.getElementById('chkIsApproved').checked = false;
    return false;
}
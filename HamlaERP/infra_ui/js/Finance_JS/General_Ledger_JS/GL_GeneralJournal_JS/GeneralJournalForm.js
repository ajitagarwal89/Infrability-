function ClearForm() {
    document.getElementById("txtJournalEntry").value = '';
    document.getElementById("txtGeneralJournalId_Self").value = '';
    document.getElementById("txtGeneralJournalId_SelfGuid").value = '';
    document.getElementById("ddlOpt_GeneralJournalType").selectedselectedIndex = 0;
    document.getElementById("rdbgntype").checked = false;
    document.getElementById("rdbgntype").checked = false;
    document.getElementById("txtTransactionDate").value = '';
    document.getElementById("txtBatch").value = '';
    document.getElementById("txtBatchGuid").value = '';
    document.getElementById('txtCurrency').value = '';
    document.getElementById('txtCurrencyGuid').value = '';
    document.getElementById('txtSourceDocument').value = '';
    document.getElementById('txtSourceDocumentGuid').value = '';
    document.getElementById('txtReference').value = '';
    return false;
}

function ClearGeneralDetailsForm() {
    document.getElementById("txtGeneralJournalAdd").value = '';
    document.getElementById("txtCompanyAdd").value = '';
    document.getElementById("txtCompanyGuidAdd").value = '';
    document.getElementById("txtGLAccountAdd").value = '';
    document.getElementById("txtGLAccountGuidAdd").value = '';
    document.getElementById("txtDebitAdd").value = '';
    document.getElementById("txtCreditAdd").value = '';
    document.getElementById("txtDescriptionAdd").value = '';
    document.getElementById("txtDistributionReferenceAdd").value = '';
    document.getElementById("txtTotalDebitAdd").value = '';
    document.getElementById("txtTotalCreditAdd").value = '';
    document.getElementById("txtDifferenceAdd").value = '';
    return false;
}

function SetSource_DocumentDetails(sourceDocument, sourceDocumentGuid) {
    document.getElementById("txtSourceDocument").value = sourceDocument;
    document.getElementById("txtSourceDocumentGuid").value = sourceDocumentGuid;
}

function CallSource_DocumentSearch() {
    document.getElementById("btnSource_DocumentSearch").click();

}

function ClearSource_DocumentSearch() {
    document.getElementById("btnClearSource_DocumentSearch").click();
}

function CallSource_DocumentRefreshButton() {
    document.getElementById("btnSource_DocumentRefresh").click();
    document.getElementById("btnClearSource_DocumentSearch").click();
}


function SetBatchDetails(batch, batchGuid) {

    document.getElementById("txtBatch").value = batch;
    document.getElementById("txtBatchGuid").value = batchGuid;

}

function CallBatchSearch() {
    document.getElementById("btnBatchSearch").click();

}

function ClearBatchSearch() {
    document.getElementById("btnClearBatchSearch").click();
}

function CallBatchRefreshButton() {
    document.getElementById("btnBatchRefresh").click();
    document.getElementById("btnClearBatchSearch").click();
}


function SetCurrencyDetails(currency, currencyGuid) {

    document.getElementById("txtCurrency").value = currency;
    document.getElementById("txtCurrencyGuid").value = currencyGuid;
}

function CallCurrencySearch() {
    document.getElementById("btnCurrencySearch").click();

}

function ClearCurrencySearch() {
    document.getElementById("btnClearCurrencySearch").click();
}

function CallCurrencyRefreshButton() {
    document.getElementById("btnCurrencyRefresh").click();
    document.getElementById("btnClearCurrencySearch").click();
}


function SetGLAccountDetails(glaccount, glaccountGuid) {
    document.getElementById("txtGLAccountAdd").value = glaccount;
    document.getElementById("txtGLAccountGuidAdd").value = glaccountGuid;
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


function SetGLAccountUpdDetails(glaccountUpd, glaccountGuidUpd) {

    document.getElementById("txtGLAccountUpdate").value = glaccountUpd;
    document.getElementById("txtGLAccountGuidUpdate").value = glaccountGuidUpd;
}

function CallGLAccountUpdSearch() {
    document.getElementById("btnGLAccountUpdSearch").click();
}

function ClearGLAccountUpdSearch() {
    document.getElementById("btnClearGLAccountUpdSearch").click();
}

function CallGLAccountUpdRefreshButton() {
    document.getElementById("btnGLAccountUpdRefresh").click();
    document.getElementById("btnClearGLAccountUpdSearch").click();
}


function SetCompanyDetails(company, companyGuid) {


    document.getElementById("txtCompanyAdd").value = company;
    document.getElementById("txtCompanyGuidAdd").value = companyGuid;
}

function CallCompanySearch() {

    document.getElementById("btnCompanySearch").click();

}

function ClearCompanySearch() {

    document.getElementById("btnClearCompanySearch").click();
}

function CallCompanyRefreshButton() {

    document.getElementById("btnCompanyRefresh").click();
    document.getElementById("btnClearCompanySearch").click();
}


function SetCompanyUpdDetails(companyUpd, companyGuidUpd) {


    document.getElementById("txtCompanyUpdate").value = companyUpd;
    document.getElementById("txtCompanyGuidUpdate").value = companyGuidUpd;
}

function CallCompanyUpdSearch() {

    document.getElementById("btnCompanyUpdSearch").click();

}

function ClearCompanyUpdSearch() {

    document.getElementById("btnClearCompanyUpdSearch").click();
}

function CallCompanyRefreshUpdButton() {

    document.getElementById("btnCompanyUpdRefresh").click();
    document.getElementById("btnClearCompanyUpdSearch").click();
}


function SetGeneralJournalDetails(generalJournal, gLAccountGuid) {
    document.getElementById("txtGeneralJournal").value = generalJournal;
    document.getElementById("txtGeneralJournalGuid").value = gLAccountGuid;

}

function CallGeneralJournalSearch() {
    document.getElementById("btnGeneralJournalSearch").click();

}

function ClearGeneralJournalSearch() {
    document.getElementById("btnClearGeneralJournalSearch").click();
}

function CallGeneralJournalRefreshButton() {
    document.getElementById("btnGeneralJournalRefresh").click();
    document.getElementById("btnClearGeneralJournalSearch").click();
}


function SetDetailsView(company, generalJournal, glaccount, Debit, Credit, Description, DistributionReference, TotalDebit, TotalCredit, Difference) {

    document.getElementById("txtCompanyView").value = company;
    document.getElementById("txtGeneralJournalView").value = generalJournal;
    document.getElementById("txtGLAccountView").value = glaccount;
    document.getElementById("txtDebitView").value = Debit;
    document.getElementById("txtCreditView").value = Credit;
    document.getElementById("txtDescriptionView").value = Description;
    document.getElementById("txtDistributionReferenceView").value = DistributionReference;
    document.getElementById("txtTotalDebitView").value = TotalDebit;
    document.getElementById("txtTotalCreditView").value = TotalCredit;
    document.getElementById("txtDifferenceView").value = Difference;
}

function SetDetailsUpdate(company, companyGuid, generalJournal, glaccount, glaccountGuid, Debit, Credit, Description, DistributionReference, TotalDebit, TotalCredit, Difference, GeneralJournalDetailsGuid) {
    document.getElementById("txtGeneralJournalUpdate").value = generalJournal;
    document.getElementById("txtCompanyUpdate").value = company;
    document.getElementById("txtCompanyGuidUpdate").value = companyGuid;
    document.getElementById("txtGLAccountUpdate").value = glaccount;
    document.getElementById("txtGLAccountGuidUpdate").value = glaccountGuid;
    document.getElementById("txtDebitUpdate").value = Debit;
    document.getElementById("txtCreditUpdate").value = Credit;
    document.getElementById("txtDescriptionUpdate").value = Description;
    document.getElementById("txtDistributionReferenceUpdate").value = DistributionReference;
    document.getElementById("txtTotalDebitUpdate").value = TotalDebit;
    document.getElementById("txtTotalCreditUpdate").value = TotalCredit;
    document.getElementById("txtDifferenceUpdate").value = Difference;
    document.getElementById("txtGeneralJournalDetailsGuid").value = GeneralJournalDetailsGuid;

}

function SetDetailsGeneral() {    
    document.getElementById("txtGeneralJournalAdd").value = document.getElementById("txtJournalEntry").value;
}


function SetGeneralJournalId_SelfDetails(generalJournalId_Self, generalJournalId_SelfGuid) {

    document.getElementById("txtGeneralJournalId_Self").value = generalJournalId_Self;
    document.getElementById("txtGeneralJournalId_SelfGuid").value = generalJournalId_SelfGuid;
}

function CallGeneralJournalId_SelfSearch() {
    document.getElementById("btnGeneralJournalId_SelfSearch").click();
}

function ClearGeneralJournalId_SelfSearch() {
    document.getElementById("btnClearGeneralJournalId_SelfSearch").click();
}

function CallGeneralJournalId_SelfRefreshButton() {
    document.getElementById("btnGeneralJournalId_SelfRefresh").click();
    document.getElementById("btnClearGeneralJournalId_SelfSearch").click();
}
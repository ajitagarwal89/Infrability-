
function GetRowValue(pagePath) {
    //alert("hi");
    window.opener.document.getElementById("PageContent_btnRefresh").click();
    window.close(pagePath);
    self.close(pagePath);
}


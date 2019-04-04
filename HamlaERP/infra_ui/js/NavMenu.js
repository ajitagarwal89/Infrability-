function show_sub_F(id, x) {
    $("#" + id).addClass('active');
    $("#" + x).addClass('activex');
    $("#" + id).toggle(200);
    $(".hr").slideUp(200);
    $(".proc").slideUp(200);
    $(".repo").slideUp(200);
    $(".sys").slideUp(200);
    $(".sec").slideUp(200);
    $("#hr").removeClass('activex');
    $("#procurement").removeClass('activex');
    $("#reporting").removeClass('activex');
    $("#syst").removeClass('activex');
    $("#security").removeClass('activex');
}
function show_sub_H(id, x) {
    $("#" + id).addClass('active');
    $("#" + x).addClass('activex');
    $("#" + id).toggle(200);
    $(".finance").slideUp(200);
    $(".proc").slideUp(200);
    $(".repo").slideUp(200);
    $(".sys").slideUp(200);
    $(".sec").slideUp(200);
    $("#finance").removeClass('activex');
    $("#procurement").removeClass('activex');
    $("#reporting").removeClass('activex');
    $("#syst").removeClass('activex');
    $("#security").removeClass('activex');
}
function show_sub_P(id, x) {
    $("#" + id).addClass('active');
    $("#" + x).addClass('activex');
    $("#" + id).toggle(200);
    $(".finance").slideUp(200);
    $(".hr").slideUp(200);
    $(".repo").slideUp(200);
    $(".sys").slideUp(200);
    $(".sec").slideUp(200);
    $("#finance").removeClass('activex');
    $("#reporting").removeClass('activex');
    $("#syst").removeClass('activex');
    $("#hr").removeClass('activex');
    $("#security").removeClass('activex');
}
function show_sub_R(id, x) {
    $("#" + id).addClass('active');
    $("#" + x).addClass('activex');
    $("#" + id).toggle(200);
    $(".finance").slideUp(200);
    $(".hr").slideUp(200);
    $(".proc").slideUp(200);
    $(".sys").slideUp(200);
    $(".sec").slideUp(200);
    $("#finance").removeClass('activex');
    $("#procurement").removeClass('activex');
    $("#syst").removeClass('activex');
    $("#hr").removeClass('activex');
    $("#security").removeClass('activex');
}
function show_sub_S(id, x) {
    $("#" + id).addClass('active');
    $("#" + x).addClass('activex');
    $("#" + id).toggle(200);
    $(".finance").slideUp(200);
    $(".hr").slideUp(200);
    $(".proc").slideUp(200);
    $(".repo").slideUp(200);
    $(".sec").slideUp(200);
    $("#finance").removeClass('activex');
    $("#procurement").removeClass('activex');
    $("#reporting").removeClass('activex');
    $("#hr").removeClass('activex');
    $("#security").removeClass('activex');
}
function show_sub_Sec(id, x) {
    $("#" + id).addClass('active');
    $("#" + x).addClass('activex');
    $("#" + id).toggle(200);
    $(".finance").slideUp(200);
    $(".hr").slideUp(200);
    $(".proc").slideUp(200);
    $(".repo").slideUp(200);
    $(".sys").slideUp(200);
    $("#finance").removeClass('activex');
    $("#procurement").removeClass('activex');
    $("#reporting").removeClass('activex');
    $("#syst").removeClass('activex');
    $("#hr").removeClass('activex');
}
function show_sub(id, sm) {
    $("#" + id).toggleClass('active');
    $("#" + sm).toggleClass('activex');
    $("#" + id).toggle(200);
}
function makeactive(nav, navsub) {
    document.getElementById(nav).style.color = '#ffffff';
    document.getElementById(nav).style.backgroundColor = '#2d3756';
    document.getElementById(navsub).style.color = '#ffffff';
    document.getElementById(navsub).style.backgroundColor = '#2d3756';
}

function getnav() {
    var url = window.location.pathname;
    var myPageName = url.substring(url.lastIndexOf('/') + 1);
    if (myPageName == 'OrganizationList.aspx' || myPageName == 'OrganizationForm.aspx') {
        setTimeout(function () { show_sub_S('sys_sub', 'syst'); }, 1000);
        setTimeout(function () { makeactive('org'); }, 1000);
    }
}
function getstartnav() {
    var qs = (function (a) {
        if (a == "") return {};
        var b = {};
        for (var i = 0; i < a.length; ++i) {
            var p = a[i].split('=', 2);
            if (p.length == 1)
                b[p[0]] = "";
            else
                b[p[0]] = decodeURIComponent(p[1].replace(/\+/g, " "));
        }
        return b;
    })(window.location.search.substr(1).split('&'));
    if (qs["stype"] == 'Supplier') {
        setTimeout(function () { show_sub_F('finance_sub', 'finance'); }, 1000);
        setTimeout(function () { show_sub('accp_sub'); }, 1500);
        setTimeout(function () { makeactive('smc', 'accp'); }, 1500);
    }
    if (qs["stype"] == 'Organisation_Management') {
        setTimeout(function () { show_sub_H('hr_sub', 'hr'); }, 1000);
        setTimeout(function () { show_sub('os_sub'); }, 1500);
        setTimeout(function () { makeactive('om', 'os'); }, 1500);
    }
    if (qs["stype"] == 'Positions_Management') {
        setTimeout(function () { show_sub_H('hr_sub', 'hr'); }, 1000);
        setTimeout(function () { show_sub('os_sub'); }, 1500);
        setTimeout(function () { makeactive('mp', 'os'); }, 1500);
    }
    if (qs["stype"] == 'Jobs_Management') {
        setTimeout(function () { show_sub_H('hr_sub', 'hr'); }, 1000);
        setTimeout(function () { show_sub('os_sub'); }, 1500);
        setTimeout(function () { makeactive('mj', 'os'); }, 1500);
    }
    if (qs["stype"] == 'Organisation') {
        setTimeout(function () { show_sub_S('sys_sub', 'syst'); }, 1000);
        setTimeout(function () { makeactive('org'); }, 1000);
    }
}


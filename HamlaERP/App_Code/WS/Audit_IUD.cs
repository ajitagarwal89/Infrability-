using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;
using AuditWS;
using System.Net;
using System.IO;
/// <summary>
/// Summary description for Audit_IUD
/// </summary>
public class Audit_IUD
{
    AuditWSSoapClient auditWSSoapClient = new AuditWSSoapClient();
    string iPAddress = ""; string browser = "";

    public Audit_IUD()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void WebServiceInsert(string tbl_OrganizationId, string tableName, string tbl_RecordId, string tbl_UserId, string newValue)
    {
        IPHostEntry hostname = Dns.GetHostByName(iPAddress);
        IPAddress[] ip = hostname.AddressList;
        iPAddress = ip[0].ToString();
        browser = HttpContext.Current.Request.Browser.Browser;
        auditWSSoapClient.Audit_InsertAsync(tbl_OrganizationId, tableName, tbl_RecordId, tbl_UserId, newValue, iPAddress, browser);


    }

    public void WebServiceUpdate(string tbl_OrganizationId, string tableName, string tbl_RecordId, string tbl_UserId, string newValue)
    {
        IPHostEntry hostname = Dns.GetHostByName(iPAddress);
        IPAddress[] ip = hostname.AddressList;
        iPAddress = ip[0].ToString();
        browser = HttpContext.Current.Request.Browser.Browser;
        auditWSSoapClient.Audit_UpdateAsync(tbl_OrganizationId, tableName, tbl_RecordId, tbl_UserId, newValue, iPAddress, browser);


    }

    public void WebServiceDelete(string tableName, string tbl_RecordId)
    {
        IPHostEntry hostname = Dns.GetHostByName(iPAddress);
        IPAddress[] ip = hostname.AddressList;
        iPAddress = ip[0].ToString();
        browser = HttpContext.Current.Request.Browser.Browser;
        auditWSSoapClient.Audit_DeleteAsync(SessionContext.OrganizationId, tableName, tbl_RecordId, SessionContext.UserGuid, iPAddress, browser);
    }

    public void WebServiceSelectInsert(string tableName, string tbl_RecordId, string selectedValue)
    {
        IPHostEntry hostname = Dns.GetHostByName(iPAddress);
        IPAddress[] ip = hostname.AddressList;
        iPAddress = ip[0].ToString();
        browser = HttpContext.Current.Request.Browser.Browser;
        auditWSSoapClient.Audit_Select_InsertAsync(SessionContext.OrganizationId, tableName, tbl_RecordId, SessionContext.UserGuid, selectedValue, iPAddress, browser);
    }

}
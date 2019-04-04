using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using log4net;

namespace InfraWebServices
{
    /// <summary>
    /// Summary description for AuditWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class AuditWS : System.Web.Services.WebService
    {
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        LogExceptionUI logExcpUIobj = new LogExceptionUI();
        LogException logExcpDALobj = new LogException();

        const int OPERATION_INSERT = 1;
        const int OPERATION_UPDATE = 2;
        const int OPERATION_DELETE = 3;

        [WebMethod]
        public void Audit_Insert(string tbl_OrganizationId, string tableName, string tbl_RecordId, string tbl_UserId, string newValue, string iPAddress, string browser)
        {
            Audit_IUDFormUI audit_IUDFormUI = new Audit_IUDFormUI();
            audit_IUDFormUI.Tbl_OrganizationId = tbl_OrganizationId;
            audit_IUDFormUI.TableName = tableName;
            audit_IUDFormUI.Tbl_RecordId = tbl_RecordId;
            audit_IUDFormUI.Tbl_UserId = tbl_UserId;
            audit_IUDFormUI.Operation =Convert.ToInt32(OPERATION_INSERT.ToString());
            audit_IUDFormUI.NewValue = newValue;            
            audit_IUDFormUI.IPAddress = iPAddress;
            audit_IUDFormUI.Browser = browser;
            try
            {
                Audit_IUDFormBAL audit_IUDFormBAL = new Audit_IUDFormBAL();
                audit_IUDFormBAL.AddAudit_IUD(audit_IUDFormUI);

            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "Audit_IUD()";
                logExcpUIobj.ResourceName = "AuditWS.CS";
                logExcpUIobj.RecordId = "New Record";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[AuditWS : Audit_IUD] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }

        [WebMethod]
        public void Audit_Update(string tbl_OrganizationId, string tableName, string tbl_RecordId, string tbl_UserId, string newValue, string iPAddress, string browser)
        {
            Audit_IUDFormUI audit_IUDFormUI = new Audit_IUDFormUI();
            audit_IUDFormUI.Tbl_OrganizationId = tbl_OrganizationId;
            audit_IUDFormUI.TableName = tableName;
            audit_IUDFormUI.Tbl_RecordId = tbl_RecordId;
            audit_IUDFormUI.Tbl_UserId = tbl_UserId;
            audit_IUDFormUI.Operation =Convert.ToInt32(OPERATION_UPDATE.ToString());
            audit_IUDFormUI.NewValue = newValue;
            audit_IUDFormUI.IPAddress = iPAddress;
            audit_IUDFormUI.Browser = browser;

            try
            {
                Audit_IUDFormBAL audit_IUDFormBAL = new Audit_IUDFormBAL();
                audit_IUDFormUI.OldValue = audit_IUDFormBAL.GetOldRecordData(tbl_RecordId); //this is required only in case of Update.
                audit_IUDFormBAL.UpdateAudit_IUD(audit_IUDFormUI);

            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "Audit_IUD()";
                logExcpUIobj.ResourceName = "AuditWS.CS";
                logExcpUIobj.RecordId = "New Record";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[AuditWS : Audit_IUD] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }

        [WebMethod]
        public void Audit_Delete(string tbl_OrganizationId, string tableName, string tbl_RecordId, string tbl_UserId, string iPAddress, string browser)
        {
            Audit_IUDFormUI audit_IUDFormUI = new Audit_IUDFormUI();
            audit_IUDFormUI.Tbl_OrganizationId = tbl_OrganizationId;
            audit_IUDFormUI.TableName = tableName;
            audit_IUDFormUI.Tbl_RecordId = tbl_RecordId;
            audit_IUDFormUI.Tbl_UserId = tbl_UserId;
            audit_IUDFormUI.Operation = OPERATION_DELETE;           
            audit_IUDFormUI.IPAddress = iPAddress;
            audit_IUDFormUI.Browser = browser;
            try
            {
                Audit_IUDFormBAL audit_IUDFormBAL = new Audit_IUDFormBAL();
                audit_IUDFormBAL.DeleteAudit_IUD(audit_IUDFormUI);

            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "Audit_Delete()";
                logExcpUIobj.ResourceName = "AuditWS.CS";
                logExcpUIobj.RecordId = "New Record";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[AuditWS : Audit_Delete] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }

        [WebMethod]
        public void Audit_Select_Insert(string tbl_OrganizationId, string tableName, string tbl_RecordId, string tbl_UserId, string selectedValue, string iPAddress, string browser)

        {
            Audit_Select_InsertUI audit_Select_InsertUI = new Audit_Select_InsertUI();
            audit_Select_InsertUI.Tbl_OrganizationId = tbl_OrganizationId;
            audit_Select_InsertUI.TableName = tableName;
            audit_Select_InsertUI.Tbl_RecordId = tbl_RecordId;
            audit_Select_InsertUI.Tbl_UserId = tbl_UserId;
            audit_Select_InsertUI.SelectedValue = selectedValue;
            audit_Select_InsertUI.IPAddress = iPAddress;
            audit_Select_InsertUI.Browser = browser;
            try
            {
                Audit_S_InsertBAL audit_S_InsertBAL = new Audit_S_InsertBAL();
                audit_S_InsertBAL.Audit_S_Insert(audit_Select_InsertUI);

            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "Audit_Select_Insert()";
                logExcpUIobj.ResourceName = "AuditWS.CS";
                logExcpUIobj.RecordId = "New Record";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[AuditWS : Audit_Select_Insert] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }

        }

    }
}

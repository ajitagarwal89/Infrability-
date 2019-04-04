using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
/// <summary>
/// Summary description for AuditHistoryListBAL
/// </summary>
public class AuditHistoryListBAL
{
    AuditHistoryListDAL auditHistoryListDAL = new AuditHistoryListDAL();
    public AuditHistoryListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetAudit_IUD_SelectByRecordId(AuditHistoryListUI auditHistoryListUI)
    {
        DataTable dtb = new DataTable();
        dtb = auditHistoryListDAL.GetAudit_IUD_SelectByRecordId(auditHistoryListUI);
        return dtb;
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Audit_IUDListBAL
/// </summary>
public class Audit_IUDListBAL
{
    Audit_IUDListDAL audit_IUDListDAL = new Audit_IUDListDAL();
    public Audit_IUDListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetAudit()
    {
        DataTable dtb = new DataTable();
        dtb = audit_IUDListDAL.GetAudit_IUDList();
        return dtb;
    }
    public DataTable GetAuidtListByRecordIDAndTableName(Audit_IUDListUI audit_IUDListUI)
    {
        DataTable dtb = new DataTable();
        dtb = audit_IUDListDAL.GetAuidtListByRecordIDAndTableName(audit_IUDListUI);
        return dtb;
    }
}
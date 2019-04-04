using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Audit_SettingFormBAL
/// </summary>
public class Audit_SettingFormBAL
{
    Audit_SettingFormDAL audit_SettingFormDAL = new Audit_SettingFormDAL();
    public Audit_SettingFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetAuditSettinListById(Audit_SettingFormUI audit_SettingFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = audit_SettingFormDAL.GetAudit_SettingListById(audit_SettingFormUI);
        return dtb;
    }
    public int AddAudit_Setting(Audit_SettingFormUI audit_SettingFormUI)
    {
        int resutl = 0;
        resutl = audit_SettingFormDAL.AddAudit_Setting(audit_SettingFormUI);
        return resutl;
    }
    public int UpdateAudit_Setting(Audit_SettingFormUI audit_SettingFormUI)
    {
        int resutl = 0;
        resutl = audit_SettingFormDAL.UpdateAudit_Setting(audit_SettingFormUI);
        return resutl;
    }

    public DataTable GetSystemTables()
    {
        DataTable dtb = new DataTable();
        dtb = audit_SettingFormDAL.GetSystemTables();
        return dtb;
    }

}
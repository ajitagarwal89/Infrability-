using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Audit_SettingBAL
/// </summary>
public class Audit_SettingListBAL
{
    Audit_SettingListDAL audit_SettingListDAL = new Audit_SettingListDAL();
    public Audit_SettingListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetAudit_Setting_Select()
    {
        DataTable dtb = new DataTable();
        dtb = audit_SettingListDAL.GetAudit_SettingList();
        return dtb;
    }

   
    
    public DataTable GetAudit_SettingListBySearchParameters(Audit_SettingListUI audit_SettingListUI)
    {
        DataTable dtb = new DataTable();
        dtb = audit_SettingListDAL.GetAudit_SettingListBySearchParameters(audit_SettingListUI);
        return dtb;
    }

    public DataTable GetAudit_SettingListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = audit_SettingListDAL.GetAudit_SettingListForExportToExcel();
        return dtb;
    }


}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Audit_S_BAL
/// </summary>
public class Audit_S_BAL
{
    Audit_SDAL audit_SDAL = new Audit_SDAL();
    public Audit_S_BAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetAudit_Audit_SList()
    {
        DataTable dtlb = new DataTable();
        dtlb = audit_SDAL.GetAudit_Audit_SList();
        return dtlb;
    }
    public DataTable GetAudit_SListSearchParameter(Audit_SUI audit_SUI)
    {
        DataTable dtlb = new DataTable();
        dtlb = audit_SDAL.GetAudit_SListSearchParameter(audit_SUI);
        return dtlb;
    }
}
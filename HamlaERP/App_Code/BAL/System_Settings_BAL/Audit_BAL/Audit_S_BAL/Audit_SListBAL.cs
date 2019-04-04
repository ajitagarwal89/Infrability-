using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Audit_SListBAL
/// </summary>
public class Audit_SListBAL
{
    Audit_SListDAL audit_SListDAL = new Audit_SListDAL();
    public Audit_SListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetAudit_SList()
    {
        DataTable dtb = new DataTable();
        dtb = audit_SListDAL.GetAudit_SList();
        return dtb;
    }
}
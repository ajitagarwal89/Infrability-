using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace InfraWebServices
{
    public class Audit_IUDListBAL
    {
        Audit_IUDListDAL audit_IUDListDAL = new Audit_IUDListDAL();
        public DataTable GetAudit_IUDList()
        {
            DataTable dtb = new DataTable();
            dtb = audit_IUDListDAL.GetAudit_IUDList();
            return dtb;
        }
      
    }
}


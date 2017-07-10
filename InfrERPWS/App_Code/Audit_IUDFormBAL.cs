using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfrERPWS
{
    public class Audit_IUDFormBAL
    {
        Audit_IUDFormDAL audit_IUDFormDAL = new Audit_IUDFormDAL();
        public int AddAudit_IUD(Audit_IUDFormUI audit_IUDFormUI)
        {
            int resutl = 0;
            resutl = audit_IUDFormDAL.AddAudit_IUD(audit_IUDFormUI);
            return resutl;
        }
    }
}
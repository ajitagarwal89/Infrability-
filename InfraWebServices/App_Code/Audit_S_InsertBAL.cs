using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfraWebServices
{
    public class Audit_S_InsertBAL
    {
        Audit_S_InsertDAL audit_S_InsertDAL = new Audit_S_InsertDAL();
        public int Audit_S_Insert(Audit_Select_InsertUI audit_S_InsertUI)
        {
            int resutl = 0;
            resutl = audit_S_InsertDAL.Audit_S_insert(audit_S_InsertUI);
            return resutl;
        }

    }
}
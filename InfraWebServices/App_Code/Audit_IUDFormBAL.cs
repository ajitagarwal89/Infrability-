using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfraWebServices
{
    public class Audit_IUDFormBAL
    {
        Audit_IUDFormDAL audit_IUDFormDAL = new Audit_IUDFormDAL();
        public int AddAudit_IUD(Audit_IUDFormUI audit_IUDFormUI)
        {
            int result = 0;
            result = audit_IUDFormDAL.AddAudit_IUD(audit_IUDFormUI);
            return result;
        }
        public int UpdateAudit_IUD(Audit_IUDFormUI audit_IUDFormUI)
        {
            int result = 0;
            result = audit_IUDFormDAL.UpdateAudit_IUD(audit_IUDFormUI);
            return result;
        }
        public int DeleteAudit_IUD(Audit_IUDFormUI audit_IUDFormUI)
        {
            int result = 0;
            result = audit_IUDFormDAL.DeleteAudit_IUD(audit_IUDFormUI);
            return result;
        }

        public string  GetOldRecordData(string recordId)
        {
            string oldRecord = string.Empty;
            oldRecord = audit_IUDFormDAL.GetOldRecordData(recordId);
            return oldRecord;
        }
    }
}
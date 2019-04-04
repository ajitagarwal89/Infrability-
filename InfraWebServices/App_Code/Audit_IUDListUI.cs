using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfraWebServices
{
    public class Audit_IUDListUI
    {
        public string Tbl_Audit_IUDId { get; set; }
        public string Tbl_OrganizationId { get; set; }
        public string TableName { get; set; }
        public string Tbl_UserId { get; set; }
        public int Operation { get; set; }
        public string Tbl_RecordId { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string IPAddress { get; set; }
        public string Browser { get; set; }
        public string Serach { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SecurityProfileFormUI
/// </summary>
namespace Infra.SecuritySystem
{
    public class SecurityProfileFormUI
    {
        public SecurityProfileFormUI()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        DateTime createdOn = DateTime.Now;
        DateTime updatedOn = DateTime.Now;
        string securityProfileX;

        public string SecurityProfileX
        {
            get { return securityProfileX; }
            set { securityProfileX = value; }
        }

        public DateTime CreatedOn
        {
            get { return createdOn; }
            set { createdOn = value; }
        }

        public DateTime UpdatedOn
        {
            get { return updatedOn; }
            set { updatedOn = value; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PageMappingFormUI
/// </summary>
namespace Infra.SecuritySystem
{
    public class PageFormUI
    {
        public PageFormUI()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        DateTime createdOn = DateTime.Now;
        DateTime updatedOn = DateTime.Now;
        string pageMappingX;
        string pageMappingXX;

        public string PageMappingX
        {
            get { return pageMappingX; }
            set { pageMappingX = value; }
        }

        public string PageMappingXX
        {
            get { return pageMappingXX; }
            set { pageMappingXX = value; }
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
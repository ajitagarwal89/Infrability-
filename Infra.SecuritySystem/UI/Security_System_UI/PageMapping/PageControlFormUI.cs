using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ControlMappingFormUI
/// </summary>
namespace Infra.SecuritySystem
{
    public class PageControlFormUI
    {
        public PageControlFormUI()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        DateTime createdOn = DateTime.Now;
        DateTime updatedOn = DateTime.Now;
        int pageMapping;
        string controlMappingX;
        string controlMappingCode;

        public int PageMapping
        {
            get { return pageMapping; }
            set { pageMapping = value; }
        }

        public string ControlMappingX
        {
            get { return controlMappingX; }
            set { controlMappingX = value; }
        }

        public string ControlMappingCode
        {
            get { return controlMappingCode; }
            set { controlMappingCode = value; }
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
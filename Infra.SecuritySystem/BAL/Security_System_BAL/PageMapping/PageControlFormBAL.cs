using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ControlMappingFormBAL
/// </summary>
namespace Infra.SecuritySystem
{
    public class PageControlFormBAL
    {
        PageControlFormDAL pageControlFormDAL = new PageControlFormDAL();

        public PageControlFormBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int AddControl(PageControlFormUI pageControlFormUI)
        {
            int result = 0;
            result = pageControlFormDAL.AddControl(pageControlFormUI);
            return result;
        }

        public int UpdateControl(PageControlFormUI pageControlFormUI, int id)
        {
            int result = 0;
            result = pageControlFormDAL.UpdateControl(pageControlFormUI, id);
            return result;
        }

        public int DeleteControl(int id)
        {
            int result = 0;
            result = pageControlFormDAL.DeleteControl(id);
            return result;
        }
    }
}
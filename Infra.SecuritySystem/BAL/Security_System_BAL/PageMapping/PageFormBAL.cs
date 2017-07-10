using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PageMappingFormBAL
/// </summary>
namespace Infra.SecuritySystem
{
    public class PageFormBAL
    {
        PageFormDAL pageFormDAL = new PageFormDAL();

        public PageFormBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int AddPage(PageFormUI pageFormUI)
        {
            int result = 0;
            result = pageFormDAL.AddPage(pageFormUI);
            return result;
        }

        public int UpdatePage(PageFormUI pageFormUI, int id)
        {
            int result = 0;
            result = pageFormDAL.UpdatePage(pageFormUI, id);
            return result;
        }

        public int DeletePage(int id)
        {
            int result = 0;
            result = pageFormDAL.DeletePage(id);
            return result;
        }
    }
}
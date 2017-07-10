using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PageListBAL
/// </summary>
namespace Infra.SecuritySystem
{
    public class PageListBAL
    {
        PageListDAL pageListDAL = new PageListDAL();

        public PageListBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetPageList()
        {
            DataTable dtb = new DataTable();
            dtb = pageListDAL.GetPageList();
            return dtb;
        }

        public DataTable GetPage(int id)
        {
            DataTable dtb = new DataTable();
            dtb = pageListDAL.GetPage(id);
            return dtb;
        }

        public int DeletePage(string id)
        {
            int result = 0;
            result = pageListDAL.DeletePage(id);
            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PageControlListBAL
/// </summary>
namespace Infra.SecuritySystem
{
    public class PageControlListBAL
    {
        PageControlListDAL pageControlListDAL = new PageControlListDAL();

        public PageControlListBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable getPageControlList(int id)
        {
            DataTable dtb = new DataTable();
            dtb = pageControlListDAL.GetPageControlListDAL(id);
            return dtb;
        }

        public DataTable getPageControl(int id)
        {
            DataTable dtb = new DataTable();
            dtb = pageControlListDAL.GetPageControl(id);
            return dtb;
        }

        public int DeleteControl(string id)
        {
            int result = 0;
            result = pageControlListDAL.DeleteControl(id);
            return result;
        }
    }
}
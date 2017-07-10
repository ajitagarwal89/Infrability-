using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for PagePriveleges
/// </summary>
namespace Infra.SecuritySystem
{
    public class PagePrivelegesBAL
    {
        PagePrivelegesDAL pagePrivelegesDAL = new PagePrivelegesDAL();

        public PagePrivelegesBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int GetUserPrivelegesForPage(int userId, string pageName)
        {
            int result = 0;

            DataTable dtb = new DataTable();
            dtb = pagePrivelegesDAL.GetUserPrivelegesForPage(userId, pageName);
            if (dtb.Rows.Count > 0)
            {
                if (dtb.Rows[0]["Read"].ToString() == "1")
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
            return result;
        }

        public static DataSet GetUserPrivelegesForControls(int userId, string pageName)
        {
            PagePrivelegesDAL pagePrivelegesDAL = new PagePrivelegesDAL();
            DataSet ds = new DataSet();
            ds = pagePrivelegesDAL.GetUserPrivelegesForControls(userId, pageName);
            return ds;
        }

        public static void SecurePage(Page aPage, int userId, string pageName)
        {
            //Get PageName From Current URL		
            //For Menu items the control name should look like pageMenu.controlname
            //For Form items the control name should look like Content.controlname.

            DataSet dsSecurityControl = GetUserPrivelegesForControls(userId, pageName);
            DataTable dtPageControlList = dsSecurityControl.Tables[0];
            DataTable dtControlAccessList = dsSecurityControl.Tables[1];

            string ParentControl = String.Empty;
            Control rawControl = null;
            int ColumnID = 0;

            foreach (DataRow drPageControl in dtPageControlList.Rows)
            {
                string eachControlName = drPageControl["ControlName"].ToString();
                string eachControlId = drPageControl["ControlID"].ToString();

                ParentControl = "PageContent";
                rawControl = aPage.Master.FindControl(ParentControl).FindControl(eachControlName);

                string Clausex = "ControlID=" + eachControlId;

                DataRow[] drEachControlAccess = dtControlAccessList.Select(Clausex);

                int maxPriveleges = 0;
                foreach (DataRow drControlAccess in drEachControlAccess)
                {
                    int privelege = Convert.ToInt32(drControlAccess["ControlPrivelege"]);
                    if (maxPriveleges < privelege)
                        maxPriveleges = privelege;
                }

                SecurePageControl(rawControl, maxPriveleges, ColumnID);
            }
        }

        private static void SecurePageControl(Control rawControl, int privelege, int ColumnID)
        {
            string setToState = string.Empty;

            switch (privelege)
            {
                case 1:
                    setToState = "H";
                    break;
                case 2:
                    setToState = "M";
                    break;
                case 3:
                    setToState = "D";
                    break;
                case 4:
                    setToState = "V";
                    break;
                default:
                    setToState = "V";
                    break;
            }

            if (rawControl != null)
            {
                if (rawControl is WebControl)
                {
                    if (rawControl is GridView)
                    {
                        if (setToState.Equals("H"))
                            ((GridView)rawControl).Columns[ColumnID].Visible = false;

                        else if (setToState.Equals("D"))
                            ((GridView)rawControl).Columns[ColumnID].Visible = false;
                    }
                    else if (rawControl is DataGrid)
                    {
                        if (setToState.Equals("H"))
                            ((DataGrid)rawControl).Columns[ColumnID].Visible = false;

                        else if (setToState.Equals("D"))
                            ((DataGrid)rawControl).Columns[ColumnID].Visible = false;
                    }

                    else
                    {
                        if (setToState.Equals("H"))
                            ((WebControl)rawControl).Visible = false;

                        else if (setToState.Equals("D"))
                            ((WebControl)rawControl).Enabled = false;

                        else if (setToState.Equals("M"))
                        {
                            if (rawControl is TextBox)
                            {
                                ((TextBox)((WebControl)rawControl)).TextMode = TextBoxMode.Password;
                                ((TextBox)((WebControl)rawControl)).Attributes["disabled"] = "disabled";
                                ((TextBox)((WebControl)rawControl)).Attributes["value"] = "********";
                            }
                        }
                    }

                }
                if (rawControl is HtmlControl)
                {
                    if (setToState.Equals("H"))
                        ((HtmlControl)rawControl).Visible = false;

                    else if (setToState.Equals("D"))                    // Enabled=false; no such property
                        ((HtmlControl)rawControl).Visible = false;
                }
            }

        }

    }
}
using System;
using System.Data;
using System.Web.UI;

namespace Finware.SecurityProfile
{
    public partial class SecurityProfileView : PageBase
    {
        protected DataSet ds = new DataSet();


        protected new void Page_Load(object sender, System.EventArgs e)
        {

            PageCode = "SecurityProfile";
            PageName = "Security Profile";
            if (!Page.IsPostBack)
            {
                //PrepView();
            }
        }


        //private void PrepView()
        //{
        //    RowId = URLMessage.GetParam(PageCode, 0);
        //    SecurityProfileBL bl = new SecurityProfileBL(SessionContext.SystemUser);
        //    bl.Fetch(ds, RowId);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        PageMappingBL bl2 = new PageMappingBL(SessionContext.SystemUser);
        //        bl2.FetchAll(ds);
        //        ds.Tables[1].Columns.Add("JumpParam");
        //        foreach (DataRow item in ds.Tables[1].Rows)
        //        {
        //            item["JumpParam"] = "SecurityDetailEdit.aspx?" + URLMessage.Encrypt("action=update&PageMapping=" + item["PageMapping"] + "&SecurityProfile=" + RowId.ToString());
        //        }
        //        grdPageMapping.DataSource = ds.Tables[1].DefaultView;
        //        grdPageMapping.DataBind();
        //        this.DataBind();
        //    }
        //    //else
        //    // Error Page	Issue.RaisePage.ItemNotFound(Request.RawUrl);
        //}

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }
        #endregion

        protected void lnkEdit_Click(object sender, System.EventArgs e)
        {
            string id = URLMessage.GetParam(PageCode, "0");
            if (!id.Equals("0"))
            {
                Response.Redirect(PageCode + "Edit.aspx?" + URLMessage.Encrypt("action=" + URLAction.update.ToString() + "&" + PageCode + "=" + id));
            }
        }

        protected void lnkCancel_Click(object sender, System.EventArgs e)
        {
            Response.Redirect(PageCode + "List.aspx");
        }

        private void grdPageMapping_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }
    }
}

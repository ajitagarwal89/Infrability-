using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infra.SecuritySystem;

namespace Finware.PageMapping
{
    public partial class PageMappingList : PageBase
    {
        PageListBAL objPageListBAL = new PageListBAL();

        protected new void Page_Load(object sender, System.EventArgs e)
        {

            PageCode = "PageMapping";
            PageName = "Page Mapping";
            if (!Page.IsPostBack)
            {
                BindPageList(SessionContext.GridPage);
            }
        }

        private void BindPageList(int aPageNumber)
        {
            DataTable dtb = objPageListBAL.GetPageList();

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                dtb.Columns.Add("JumpParam");
                foreach (DataRow item in dtb.Rows)
                {
                    item["JumpParam"] = "PageMappingView.aspx?" + URLMessage.Encrypt("PageMapping=" + item["PageMapping"]);
                }
                grdPage.DataSource = dtb;
                grdPage.DataBind();
                grdPage.CurrentPageIndex = aPageNumber > grdPage.PageCount ? 0 : aPageNumber;
                grdPage.DataBind();
                SessionContext.GridPage = grdPage.CurrentPageIndex;
                msgalert.Visible = false;
            }
            else
            {
                msgalert.Visible = true;
                lbmsg.Text = "No Records Found";
                grdPage.Visible = false;
            }
        }

        protected void lnkEdit_Click(object sender, System.EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            if (!id.Equals("0"))
            {
                Response.Redirect("../PageMapping/PageMappingEdit.aspx?" + URLMessage.Encrypt("action=" + URLAction.update.ToString() + "&PageMapping=" + id));
            }
        }


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
            this.grdPage.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grdPage_PageIndexChanged);
            this.Load += new System.EventHandler(this.Page_Load);
        }
        #endregion


        private void grdPage_PageIndexChanged(object sender, DataGridPageChangedEventArgs e)
        {
            BindPageList(e.NewPageIndex);
        }

        protected void btPageCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageCode + "Edit.aspx?" + URLMessage.Encrypt("action=create"));
        }
        protected void lnkBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ControlPanel/ControlPanelHomeList.aspx");
        }
        protected void btPageDelete_Click(object sender, EventArgs e)
        {
            CheckBox ch;
            for (int i = 0; i < grdPage.Items.Count; i++)
            {
                ch = (CheckBox)grdPage.Items[i].Cells[0].FindControl("chkrow");
                if (ch.Checked == true)
                {
                    string id = grdPage.Items[i].Cells[0].Text;
                    if (objPageListBAL.DeletePage(id) == -1)
                    {
                        msgcool.Visible = true;
                        lbsuccess.Text = "Profile(s) deleted successfully";
                    }
                    else
                    {
                        msgalert.Visible = true;
                        lbmsg.Text = "Could not process your request, Please try again";
                    }
                }
            }
            BindPageList(SessionContext.GridPage);
        }

        //protected void btnMainSearch_Click(object sender, EventArgs e)
        //{
        //    btnHtmlSearch.Visible = false;
        //    btnHtmlClose.Visible = true;

        //    employeeContactsListUI.Search = txtSearch.Text;
        //    BindListBySearchParameters(employeeContactsListUI);
        //}
        //protected void btnClearMainSearch_Click(object sender, EventArgs e)
        //{
        //    BindList();
        //    btnHtmlSearch.Visible = true;
        //    btnHtmlClose.Visible = false;
        //    txtSearch.Text = "";
        //    txtSearch.Focus();
        //}
    }
}

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;
using Infra.SecuritySystem;

namespace Finware.SecurityProfile
{
    public partial class SecurityProfileList : PageBase
    {
        SecurityProfileListBAL objSecurityProfileList = new SecurityProfileListBAL();
        protected new void Page_Load(object sender, System.EventArgs e)
        {
            PageCode = "SecurityProfile";
            PageName = "Security Profile";
            if (!Page.IsPostBack)
            {
                BindSecurityProfileList(SessionContext.GridPage);
            }
        }
        private void BindSecurityProfileList(int aPageNumber)
        {
            DataTable dtb = objSecurityProfileList.GetSecurityProfileList();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                dtb.Columns.Add("JumpParam");
                foreach (DataRow item in dtb.Rows)
                {
                    item["JumpParam"] = "../PageMapping/RolePageMappingList.aspx?" + URLMessage.Encrypt("SecurityProfile=" + item["SecurityProfile"] + "&Name=" + item["SecurityProfileX"].ToString());
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
                grdPage.Visible = false;
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
            this.grdPage.PageIndexChanged += new DataGridPageChangedEventHandler(this.grdPage_PageIndexChanged);
            this.Load += new System.EventHandler(this.Page_Load);
        }
        #endregion


        private void grdPage_PageIndexChanged(object sender, DataGridPageChangedEventArgs e)
        {
            BindSecurityProfileList(e.NewPageIndex);
        }
        protected void lnkEdit_Click(object sender, System.EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            if (!id.Equals("0"))
            {
                Response.Redirect("../SecurityProfile/SecurityProfileEdit.aspx?" + URLMessage.Encrypt("action=" + URLAction.update.ToString() + "&SecurityProfile=" + id));
            }
        }
        protected void btprofiledelete_Click(object sender, EventArgs e)
        {
            CheckBox ch;
            for (int i = 0; i < grdPage.Items.Count; i++)
            {
                ch = (CheckBox)grdPage.Items[i].Cells[0].FindControl("chkrow");
                if (ch.Checked == true)
                {
                    string id = grdPage.Items[i].Cells[0].Text;
                    if (objSecurityProfileList.DeleteSecurityProfile(id) == -1)
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
            BindSecurityProfileList(SessionContext.GridPage);
        }
        protected void btprofileCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageCode + "Edit.aspx?" + URLMessage.Encrypt("action=create"));
        }
        protected void lnkBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ControlPanel/ControlPanelHomeList.aspx");
        }
    }
}

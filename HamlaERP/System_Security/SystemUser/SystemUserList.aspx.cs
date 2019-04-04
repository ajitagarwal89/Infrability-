using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;
using Infra.SecuritySystem;

namespace Finware
{
    public partial class SystemUserList : PageBase
    {
        EncryptDecrypt ED = new EncryptDecrypt();
        SystemUserListBAL objSystemUserListBAL = new SystemUserListBAL();

        //URLMessage URLMessage = new URLMessage();
        protected override void Page_Load(object sender, EventArgs e)
        {

            base.Page_Load(sender, e);
            PageCode = "SystemUser";
            PageName = "System User";
            lblConfirmation.Visible = false;

            if (!Page.IsPostBack)
            {
                //lblSearchHeaderText.Text = "System User Maintenance";
                //txtSearch.Text = WebUtility.GetCookie(Request, _SearchHintCookie, "");
                //btnSearch_Click1(this, null);
                BindUserList(SessionContext.GridPage);
                //if (URLMessage.GetParam("SystemUser", 0) != 0)
                //{
                //    BindGrid(Convert.ToString(URLMessage.GetParam("SystemUser", 0)));
                //}
            }
        }
        private void BindUserList(int aPageNumber)
        {
            DataTable dtb = objSystemUserListBAL.GetUserList();

            //Button UserActivate;
            //Button UserDeactivate;
            //Button UserLock;
            //Button UserUnlock;

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                dtb.Columns.Add("JumpParam");
                foreach (DataRow item in dtb.Rows)
                {
                    item["JumpParam"] = "SystemUserEdit.aspx?" + URLMessage.Encrypt("action=update&SystemUser=" + item["SystemUser"] + "&Referrer=SystemUserList.aspx");
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
                lblmsg.Text = "No Records Found";
                grdPage.Visible = false;
            }
        }
        protected void btnUserLock_Click(object sender, EventArgs e)
        {
            string Id = (sender as Button).CommandArgument;
            objSystemUserListBAL.LockUser(Convert.ToInt32(Id), 1);
            BindUserList(SessionContext.GridPage);
        }
        protected void btnUserUnlock_Click(object sender, EventArgs e)
        {
            string Id = (sender as Button).CommandArgument;
            objSystemUserListBAL.LockUser(Convert.ToInt32(Id), 0);
            BindUserList(SessionContext.GridPage);
        }
        protected void btnUserActivate_Click(object sender, EventArgs e)
        {
            string Id = (sender as Button).CommandArgument;
            objSystemUserListBAL.ActivateUser(Convert.ToInt32(Id), 1);
            BindUserList(SessionContext.GridPage);
        }
        protected void btnUserDeactivate_Click(object sender, EventArgs e)
        {
            string Id = (sender as Button).CommandArgument;
            objSystemUserListBAL.ActivateUser(Convert.ToInt32(Id), 0);
            BindUserList(SessionContext.GridPage);
        }
        protected void btnUserResetPassword_Click(object sender, EventArgs e)
        {
            string Id = (sender as Button).CommandArgument;
            objSystemUserListBAL.ResetPassword(Convert.ToInt32(Id));
            BindUserList(SessionContext.GridPage);
        }
        #region "CREATE LINK"
        protected void lnkCreate_Click1(object sender, EventArgs e)
        {
            Response.Redirect(PageCode + "Edit.aspx?" + URLMessage.Encrypt("action=create"));
        }
        protected void btUserDelete_Click(object sender, EventArgs e)
        {
            try
            {
                CheckBox ch;
                for (int i = 0; i < grdPage.Items.Count; i++)
                {
                    ch = (CheckBox)grdPage.Items[i].Cells[0].FindControl("chkrow");
                    if (ch.Checked == true)
                    {
                        string id = grdPage.Items[i].Cells[0].Text;
                        objSystemUserListBAL.DeleteUser(id);
                    }
                }
                BindUserList(SessionContext.GridPage);
                msgcool.Visible = true;
                lbsuccess.Text = "User(s) deleted successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        protected void grdPage_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Pager && e.Item.ItemType != ListItemType.Footer)
            {
                Button imgUserActivate = (Button)e.Item.FindControl("btnUserActivate");
                Button imgUserDeactivate = (Button)e.Item.FindControl("btnUserDeactivate");
                Button imgUserLock = (Button)e.Item.FindControl("btnUserLock");
                Button imgUserUnlock = (Button)e.Item.FindControl("btnUserUnlock");
                //ImageButton imgDelete = (ImageButton)e.Item.FindControl("btnUserdelete");
                Button imgResetPassword = (Button)e.Item.FindControl("btnResetPassword");
                //if (e.Item.Cells[0].Text == "1")
                //{
                e.Item.Cells[7].Style["text-align"] = "center !important;";
                e.Item.Cells[8].Style["text-align"] = "center !important;";
                e.Item.Cells[9].Style["text-align"] = "center !important;";
                e.Item.Cells[10].Style["text-align"] = "center !important;";
                //}
                //else
                //{
                //imgUserActivate.Visible = false;
                //imgUserDeactivate.Visible = false;
                //imgUserLock.Visible = false;
                //imgUserUnlock.Visible = false;
                //imgResetPassword.Visible = false;
            }
        }

    }
}
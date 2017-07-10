using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Infra.SecuritySystem;

namespace Finware
{
    public partial class RolePageMappingList : PageBase
    {
        RolePageMappingListBAL objRolePageMappingListBAL = new RolePageMappingListBAL();
        ProfilePageMappingInsertBAL objProfilePageMappingInsertBAL = new ProfilePageMappingInsertBAL();
        int pagemappingId = 0;

        protected override void Page_Load(object sender, System.EventArgs e)
        {
            base.Page_Load(sender, e);
            PageCode = "PageMapping";
            PageName = "Page Mapping";
            if (!Page.IsPostBack)
            {

                lblPageName.Text = "Role Page Mapping List for " + URLMessage.GetParam("Name", "");
                RowId = URLMessage.GetParam("SecurityProfile", 0);
                BindRolePageMappingList(SessionContext.GridPage);
            }
        }
        private void BindRolePageMappingList(int aPageNumber)
        {
            DataTable dtb = objRolePageMappingListBAL.GetRolePageMappingList(RowId);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                dtb.Columns.Add("JumpParam");
                foreach (DataRow item in dtb.Rows)
                {
                    item["JumpParam"] = "../Securityprofile/SecurityDetailEdit.aspx?" + URLMessage.Encrypt("action=update&PageMapping=" + item["PageMapping"] + "&SecurityProfile=" + RowId.ToString() + "&Name=" + URLMessage.GetParam("Name", ""));
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
        protected void lnkEdit_Click(object sender, System.EventArgs e)
        {
            string id = URLMessage.GetParam("SecurityProfile", "0");
            if (!id.Equals("0"))
            {
                Response.Redirect("../SecurityProfile/SecurityProfileEdit.aspx?" + URLMessage.Encrypt("action=" + URLAction.update.ToString() + "&SecurityProfile=" + id + "&Name=" + URLMessage.GetParam("Name", "")));
            }
        }
        protected void btnBack_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("../SecurityProfile/SecurityProfileList.aspx");
        }

        private void grdPage_PageIndexChanged(object sender, DataGridPageChangedEventArgs e)
        {
            BindRolePageMappingList(e.NewPageIndex);
        }
        protected void lnkCreate_Click(object sender, System.EventArgs e)
        {
            Response.Redirect(PageCode + "Edit.aspx?" + URLMessage.Encrypt("action=create"));
        }


        protected void btnSavePageMapping_Click(object sender, System.EventArgs e)
        {
            int Read = 0;

            HtmlInputCheckBox chRead;

            if (objRolePageMappingListBAL.RemovePageMapping(RowId) >= 0)
            {
                for (int i = 0; i < grdPage.Items.Count; i++)
                {
                    chRead = (HtmlInputCheckBox)grdPage.Items[i].Cells[0].FindControl("chkRead");

                    if (chRead.Checked == true)
                    {
                        Read = 1;
                    }
                    string PageId = grdPage.Items[i].Cells[0].Text;
                    if (objProfilePageMappingInsertBAL.AddProfilePageMapping(RowId, Convert.ToInt32(PageId), Read) == 1)
                    {
                        msgcool.Visible = true;
                        lbsuccess.Text = "Profile Page Mapping completed successfully";
                        Read = 0;
                    }
                    else
                    {
                        msgalert.Visible = true;
                        lblmsg.Text = "Could not process your request, Please try again";
                    }
                }
            }
            else
            {
                msgalert.Visible = true;
                lblmsg.Text = "Could not process your request, Please try again";
            }
        }
    }
}

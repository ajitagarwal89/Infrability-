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
    public partial class SecurityDetailEdit : PageBase
    {

        PrivilegesDetailsBAL objPrivilegesDetailsBAL = new PrivilegesDetailsBAL();
        protected DataSet ds = new DataSet();

        protected new void Page_Load(object sender, System.EventArgs e)
        {

            PageCode = "SecurityProfile";
            PageName = "Security Profile";
            if (!Page.IsPostBack)
            {
                switch (URLMessage.URLAction)
                {
                    case URLAction.update:
                        GetControlListEdit();
                        break;
                }
            }
        }
        private void GetControlListEdit()
        {
            DataTable dtb = objPrivilegesDetailsBAL.GetPrivilegesDetails(URLMessage.GetParam("SecurityProfile", -1), URLMessage.GetParam("PageMapping", -1));
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                lblSearchHeaderText.Text = dtb.Rows[0]["RoleName"].ToString() + " > " + dtb.Rows[0]["PageName"].ToString() + " > Edit Controls";
                grdSecurityDetail.DataSource = dtb;
                grdSecurityDetail.DataBind();
            }
            else
            {
                msgalert.Visible = true;
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
            this.Load += new System.EventHandler(this.Page_Load);
        }
        #endregion


        protected void btnSavePageControlMapping_Click(object sender, System.EventArgs e)
        {
            if (objPrivilegesDetailsBAL.RemoveProfilePageControlMapping(URLMessage.GetParam("SecurityProfile", -1), URLMessage.GetParam("PageMapping", -1)) == -1)
            {
                for (int i = 0; i < grdSecurityDetail.Items.Count; i++)
                {
                    RadioButtonList rblShippers = (RadioButtonList)grdSecurityDetail.Items[i].Cells[0].FindControl("optControlState");

                    string ControlId = grdSecurityDetail.Items[i].Cells[0].Text;
                    if (objPrivilegesDetailsBAL.AddProfilePageControlMapping(URLMessage.GetParam("SecurityProfile", -1), URLMessage.GetParam("PageMapping", -1), Convert.ToInt32(ControlId), rblShippers.SelectedValue) == 1)
                    {
                        msgcool.Visible = true;
                        lbsuccess.Text = "Profile Page Control Mapping completed successfully";
                    }
                    else
                    {
                        msgalert.Visible = true;
                        lblmsg.Text = "Could not process your request, Please try again";
                    }
                }
            }
        }
        protected void btnBack_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("../PageMapping/RolePageMappingList.aspx?" + URLMessage.Encrypt("action=view&SecurityProfile=" + URLMessage.GetParam("SecurityProfile", "0") + "&Name=" + URLMessage.GetParam("Name", "")));
        }
    }
}

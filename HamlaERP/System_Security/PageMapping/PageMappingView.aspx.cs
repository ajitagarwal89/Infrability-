using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infra.SecuritySystem;

namespace Finware.PageMapping
{
    public partial class PageMappingView : PageBase
    {
        PageControlListBAL objPageControlListBAL = new PageControlListBAL();
        protected DataSet ds = new DataSet();
        protected DataTable dtb = new DataTable();

        protected new void Page_Load(object sender, System.EventArgs e)
        {

            PageCode = "PageMapping";
            PageName = "Page Mapping";
            if (!Page.IsPostBack)
            {
                BindPageControlList();
            }
        }
        private void BindPageControlList()
        {
            RowId = URLMessage.GetParam(PageCode, 0);
            dtb = objPageControlListBAL.getPageControlList(RowId);
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                lblPageMappingX.Text = dtb.Rows[0]["PageMappingX"].ToString().Replace(".aspx", " Page Control List");
                dtb.Columns.Add("JumpParam");
                foreach (DataRow item in dtb.Rows)
                {
                    item["JumpParam"] = "ControlMappingEdit.aspx?" + URLMessage.Encrypt("action=update&ControlMapping=" + item["ControlMapping"]);
                }
                grdControlMapping.DataSource = dtb;
                grdControlMapping.DataBind();
                msgalert.Visible = false;
            }
            else
            {
                msgalert.Visible = true;
                lblmsg.Text = "No Records Found";
                grdControlMapping.Visible = false;
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

        protected void btCreate_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("ControlMappingEdit.aspx?" + URLMessage.Encrypt("action=create&PageMapping=" + RowId));
        }

        protected void lnkEdit_Click1(object sender, EventArgs e)
        {
            Response.Redirect(PageCode + "Edit.aspx?" + URLMessage.Encrypt("action=" + URLAction.update.ToString() + "&" + PageCode + "=" + RowId));
        }
        protected void lnkCancel_Click1(object sender, EventArgs e)
        {
            Response.Redirect(PageCode + "List.aspx");
        }
        protected void btcontroldelete_Click(object sender, EventArgs e)
        {
            CheckBox ch;
            for (int i = 0; i < grdControlMapping.Items.Count; i++)
            {
                ch = (CheckBox)grdControlMapping.Items[i].Cells[0].FindControl("chkrow");
                if (ch.Checked == true)
                {
                    string id = grdControlMapping.Items[i].Cells[0].Text;
                    if (objPageControlListBAL.DeleteControl(id) == -1)
                    {
                        msgcool.Visible = true;
                        lbsuccess.Text = "Control(s) deleted successfully";
                    }
                    else
                    {
                        msgalert.Visible = true;
                        lblmsg.Text = "Could not process your request, Please try again";
                    }
                }
            }
            BindPageControlList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Finware;
using System.Web.UI.WebControls;

public partial class Site : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblUserName.Text = SessionContext.FirstName + " " + SessionContext.LastName;
            lblCopyRightYear.Text = System.DateTime.Now.Year.ToString();
            bootstrapCss.Href = "infra_components/bootstrap/dist/css/bootstrap.min.css";
            mainCss.Href = "infra_ui/css/main.css";
            //FormMaster.Attributes.Add("dir", "rtl");
        }


    }

    protected void btn_ar_Click(object sender, EventArgs e)
    {
        bootstrapCss.Href = "infra_components/bootstrap/dist/css/bootstrap-ar.min.css";
        mainCss.Href = "infra_ui/css/main-ar.css";

    }
    protected void btn_en_Click(object sender, EventArgs e)
    {
        bootstrapCss.Href = "infra_components/bootstrap/dist/css/bootstrap.min.css";
        mainCss.Href = "infra_ui/css/main.css";

    }
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("~/Login.aspx");
    }
}
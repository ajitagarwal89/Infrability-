using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class Dashboard : PageBase
{
    OrganizationListBAL objOrganizationListBAL = new OrganizationListBAL();

    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
        if (!Page.IsPostBack)
        {
            FillOrganizations();
            if (SessionContext.tbl_OrganizationId == null && SessionContext.AuthenticationRequired == true)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "showOrganizationSelectModal", "openOrganizationSelectModal();", true);
            }
        }
    }
    private void FillOrganizations() 
    {
        DataTable dtb = objOrganizationListBAL.GetOrganizationListOfUser(Guid.Parse(SessionContext.UserGuid));
        if (dtb.Rows.Count > 0 && dtb != null)
        {
            ddlOrganizationList.DataSource = dtb;
            ddlOrganizationList.DataValueField = "tbl_OrganizationId";
            ddlOrganizationList.DataTextField = "Name";
            ddlOrganizationList.DataBind();
        }
        else
        {
            ddlOrganizationList.Items.Insert(0, new ListItem("No Organization Found", "-1"));
        }
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        SessionContext.tbl_OrganizationId = ddlOrganizationList.SelectedValue;
    }
}
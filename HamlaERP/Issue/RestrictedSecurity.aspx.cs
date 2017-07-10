//===========================================================================
// This file was modified as part of an ASP.NET 2.0 Web project conversion.
// The class name was changed and the class modified to inherit from the abstract base class 
//// in file 'App_Code\Migrated\Issue\Stub_ItemNotFound_aspx_cs.cs'.
// During runtime, this allows other classes in your web application to bind and access 
// the code-behind page using the abstract base class.
// The associated content page 'Issue\ItemNotFound.aspx' was also modified to refer to the new class name.
// For more information on this code pattern, please refer to http://go.microsoft.com/fwlink/?LinkId=46995 
//===========================================================================
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Finware
{
    public partial class RestrictedSecurity : PageBase
    {

        protected override void Page_Load(object sender, System.EventArgs e)
        {

        }


        protected void lnkHome_Click(object sender, System.EventArgs e)
        {
            Response.Redirect(@"../Home.aspx");
        }
    }
}

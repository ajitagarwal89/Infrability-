using System;
using System.IO;
using Infra.SecuritySystem;


namespace Finware
{
    public class PageBase : System.Web.UI.Page
    {
        PagePrivelegesBAL objPagePrivelegesBAL = new PagePrivelegesBAL();
        protected URLMessage URLMessage;
        public string _pageCode;
        protected string PageName;
        protected Cargo CargoBag;

        public PageBase()
        {

        }

        public string PageCode
        {
            set
            {
                _pageCode = value;
                SessionContext.PageCode = _pageCode;
            }
            get { return _pageCode; }
        }

        public void Confirm(System.Web.UI.WebControls.LinkButton aLinkButton, String aMessage)
        {
            aLinkButton.Attributes.Add("onClick", "javascript:return confirm('" + aMessage + "')");

        }

        public void Confirm(System.Web.UI.WebControls.Button aButton, String aMessage)
        {
            aButton.Attributes.Add("onClick", "javascript:return confirm('" + aMessage + "')");

        }

        protected virtual void Page_Load(object sender, System.EventArgs e)
        {
            // License.Validate();
            CargoBag = new Cargo(ViewState);

            if (SessionContext.AuthenticationRequired == true)
            {
                string currentPageFileName = new FileInfo(this.Request.Url.LocalPath).Name;
                if (objPagePrivelegesBAL.GetUserPrivelegesForPage(SessionContext.SystemUser, currentPageFileName) == 0)
                {
                    Response.Redirect("~/Issue/RestrictedSecurity.aspx");
                }
                else
                {
                    PagePrivelegesBAL.SecurePage(this, SessionContext.SystemUser, currentPageFileName);
                }
            }
            URLMessage = new URLMessage();

            this.Title = "HAMLA ERP SYSTEM";
        }

        protected int RowId
        {
            get
            {
                return CargoBag.GetValue("RowId", -1);
            }
            set
            {
                CargoBag.SetValue("RowId", value);
            }
        }

        protected int ParentId
        {
            get
            {
                return CargoBag.GetValue("ParentId", -1);
            }
            set
            {
                CargoBag.SetValue("ParentId", value);
            }
        }

    }

}

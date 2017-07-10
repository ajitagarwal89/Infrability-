using Finware;
using System;
using System.Data;
using System.Net;
using System.Net.Sockets;
using Infra.SecuritySystem;
using log4net;

public partial class Login : PageBase
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    EncryptDecrypt encryptDecrypt = new EncryptDecrypt();
    UserLoginFormBAL userLoginFormBAL = new UserLoginFormBAL();
    UserLoginInsertBAL userLoginInsertBAL = new UserLoginInsertBAL();

    protected override void Page_Load(object sender, EventArgs e)
    {
        loginrightdiv.Attributes.CssStyle.Add("background", "url('images/evening-city.jpg') no-repeat;");

        lblDayTime.Text = Resources.GlobalResource.lblGoodEvening;
    }

    private string GetUserIP()
    {
        string localIP;
        using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
        {
            socket.Connect("8.8.8.8", 65530);
            IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
            localIP = endPoint.Address.ToString();
            return localIP;
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        UserLoginFormUI userLoginFormUI = new UserLoginFormUI();
        System.Web.HttpBrowserCapabilities browser = Request.Browser;

        string enPWD = encryptDecrypt.base64Encode(txtPassword.Text.Trim());
        txtPassword.Text = enPWD;

        userLoginFormUI.UserId = txtUserName.Text.Trim();
        userLoginFormUI.Password = txtPassword.Text;

        DataTable dtbl = userLoginFormBAL.GetUser(userLoginFormUI);

        if (dtbl == null)
        {
            cvError.Visible = true;
            cvError.IsValid = false;
            return;
        }
        try
        {
            if (dtbl.Rows.Count > 0 && dtbl != null)
            {
                SessionContext.Theme = dtbl.Rows[0]["Theme"].ToString();
                SessionContext.UserId = dtbl.Rows[0]["UserId"].ToString();
                SessionContext.SystemUser = Convert.ToInt32(dtbl.Rows[0]["SystemUser"].ToString());
                SessionContext.Language = dtbl.Rows[0]["Language"].ToString();
                SessionContext.FirstName = dtbl.Rows[0]["FirstName"].ToString();
                SessionContext.LastName = dtbl.Rows[0]["LastName"].ToString();
                SessionContext.IP = GetUserIP();
                SessionContext.Browser = browser.Browser;
                SessionContext.UserGuid = dtbl.Rows[0]["UserGuid"].ToString();
                SessionContext.AuthenticationRequired = Convert.ToBoolean(dtbl.Rows[0]["AuthenticationRequired"]);
                SessionContext.OrganizationId = dtbl.Rows[0]["tbl_OrganizationId"].ToString();

                userLoginFormUI.SystemUser = Convert.ToInt32(dtbl.Rows[0]["SystemUser"].ToString());
                userLoginFormUI.CreatedOn = DateTime.Now;
                userLoginFormUI.UserBrowser = browser.Browser;
                userLoginFormUI.UserIP = GetUserIP();
                userLoginFormUI.UserGuid = dtbl.Rows[0]["UserGuid"].ToString();


                //userLoginFormUI.userIP = "127.0.0.1";

                if (userLoginInsertBAL.AddUser(userLoginFormUI) == -1)
                {
                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    cvError.Visible = true;
                    cvError.IsValid = false;
                }
            }
            else
            {
                cvSignIn.Visible = true;
                cvSignIn.IsValid = false;
            }
        }
        catch (Exception exp)
        {
            cvError.Visible = true;
            cvError.IsValid = false;

            logExcpUIobj.MethodName = "btnLogin_Click()";
            logExcpUIobj.ResourceName = "Login.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Login : btnLogin_Click] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");


        }
    }
}

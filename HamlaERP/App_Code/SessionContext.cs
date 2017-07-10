using System;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;


namespace Finware
{
    public class SessionContext
    {
        public static string tbl_OrganizationId
        {
            set
            {
                CurrentSession["tbl_OrganizationId"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["tbl_OrganizationId"];
                }
                catch
                {
                    result = String.Empty;
                }
                return result;
            }
        }
        public static int SystemUser
        {
            set
            {
                CurrentSession["SystemUser"] = value;
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["SystemUser"];
                }
                catch
                {
                    result = -1;
                }
                return result;
            }
        }
        public static string UserId
        {
            set
            {
                CurrentSession["UserId"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["UserId"];
                }
                catch
                {
                    result = string.Empty;
                }
                return result;
            }
        }
        public static string FirstName
        {
            set
            {
                CurrentSession["FirstName"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["FirstName"];
                }
                catch
                {
                    result = String.Empty;
                }
                return result;
            }
        }
        public static string LastName
        {
            set
            {
                CurrentSession["LastName"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["LastName"];
                }
                catch
                {
                    result = String.Empty;
                }
                return result;
            }
        }
        public static string UserGuid
        {
            set
            {
                CurrentSession["UserGuid"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["UserGuid"];
                }
                catch
                {
                    result = String.Empty;
                }
                return result;
            }
        }
        public static string Theme
        {
            set
            {
                CurrentSession["Theme"] = value;
            }
            get
            {
                string result = "Default";
                try
                {
                    result = (string)CurrentSession["Theme"];
                }
                catch
                {
                    result = "Default";
                }
                return result;
            }
        }
        public static string Language
        {
            set
            {
                CurrentSession["Language"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["Language"];
                }
                catch
                {
                    result = String.Empty;
                }
                return result;
            }
        }
        public static string IP
        {
            set
            {
                CurrentSession["IP"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["IP"];
                }
                catch
                {
                    result = String.Empty;
                }
                return result;
            }
        }
        public static string Browser
        {
            set
            {
                CurrentSession["Browser"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["Browser"];
                }
                catch
                {
                    result = String.Empty;
                }
                return result;
            }
        }
        public static Boolean AuthenticationRequired
        {
            set
            {
                CurrentSession["AuthenticationRequired"] = value;
            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["AuthenticationRequired"];
                }
                catch
                {
                    result = true;
                }
                return result;
            }
        }
        public static string OrganizationId
        {
            set
            {
                CurrentSession["OrganizationId"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["OrganizationId"];
                }
                catch
                {
                    result = string.Empty;
                }
                return result;
            }
        }
        //********************************************************
        //********************************************************
        public static int GridPage
        {
            set
            {
                CurrentSession["GridPage"] = value;
            }
            get
            {
                int result;
                try
                {
                    result = (int)CurrentSession["GridPage"];
                }
                catch
                {
                    result = 0;
                }
                return result;
            }
        }



        //********************************************************
        //********************************************************
        public static bool IsAccountLocked
        {
            set
            {
                CurrentSession["AccountLocked"] = value;
            }
            get
            {
                bool result;
                try
                {
                    result = (bool)CurrentSession["AccountLocked"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }




        //********************************************************
        //********************************************************
        public static string PageCode
        {
            set
            {
                CurrentSession["PageCode"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["PageCode"];
                }
                catch
                {
                    result = String.Empty;
                }
                return result;
            }
        }


        //********************************************************
        //********************************************************
        public static string SecurityProfile
        {
            set
            {
                CurrentSession["SecurityProfile"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["SecurityProfile"];
                }
                catch
                {
                    result = string.Empty;
                }
                return result;
            }
        }

        public static string BaseURL
        {
            set
            {
                CurrentSession["BaseURL"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["BaseURL"];
                }
                catch
                {
                    result = string.Empty;
                }
                return result;
            }
        }

        //********************************************************
        //********************************************************
        public static string SessionID
        {
            get
            {
                return CurrentSession.SessionID;
            }
        }

        public static DateTime GetTimestamp()
        {
            DateTime result;
            try
            {
                result = (DateTime)CurrentSession["TimeStamp"];
            }
            catch
            {
                result = DateTime.MinValue;
            }
            return result;
        }

        private static void SetTimeStamp()
        {
            CurrentSession["Timestamp"] = DateTime.Now;
        }

        public static HttpSessionState CurrentSession
        {
            get
            {
                return HttpContext.Current.Session;
            }
        }


        //********************************************************
        public static void Logout()
        {
            FormsAuthentication.SignOut();
            CurrentSession.Abandon();
        }


        //********************************************************
        //********************************************************
        public static DateTime LastLogin
        {
            set
            {
                CurrentSession["LastLogin"] = value;
            }
            get
            {
                DateTime result;
                try
                {
                    result = (DateTime)CurrentSession["LastLogin"];
                }
                catch
                {
                    result = DateTime.Now;
                }
                return result;
            }
        }
    }
}

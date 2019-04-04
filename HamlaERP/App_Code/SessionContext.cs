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

        public static bool GlobalAuditEnabledStatus
        {
            set
            {
                CurrentSession["globalAuditEnabledStatus"] = value;
            }
            get
            {
                bool result = false;
                try
                {
                    result = (bool)CurrentSession["globalAuditEnabledStatus"];
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }

        public static string tbl_CurrencyId
        {
            set
            {
                CurrentSession["tbl_CurrencyId"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["tbl_CurrencyId"];
                }
                catch
                {
                    result = String.Empty;
                }
                return result;
            }
        }

        public static string tbl_POId
        {
            set { CurrentSession["tbl_POId"] = value; }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["tbl_POId"];
                }
                catch
                {
                    result = String.Empty;
                }
                return result;
            }
        }

        public static string tbl_GoodsReceivedNoteId
        {
            set { CurrentSession["tbl_GoodsReceivedNoteId"] = value; }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["tbl_GoodsReceivedNoteId"];
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

        public static string OrganizationName
        {
            set
            {
                CurrentSession["OrganizationName"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["OrganizationName"];
                }
                catch
                {
                    result = string.Empty;
                }
                return result;
            }
        }

        public static string CountryId
        {
            set
            {
                CurrentSession["CountryId"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["CountryId"];
                }
                catch
                {
                    result = string.Empty;
                }
                return result;
            }
        }

        public static string CountryName
        {
            set
            {
                CurrentSession["CountryName"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["CountryName"];
                }
                catch
                {
                    result = string.Empty;
                }
                return result;
            }
        }

        public static string CountryCode
        {
            set
            {
                CurrentSession["CountryCode"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["CountryCode"];
                }
                catch
                {
                    result = string.Empty;
                }
                return result;
            }
        }

        public static string CurrencyId
        {
            set
            {
                CurrentSession["CurrencyId"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["CurrencyId"];
                }
                catch
                {
                    result = string.Empty;
                }
                return result;
            }
        }

        public static string CurrencyName
        {
            set
            {
                CurrentSession["CurrencyName"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["CurrencyName"];
                }
                catch
                {
                    result = string.Empty;
                }
                return result;
            }
        }

        public static string CurrencyCode
        {
            set
            {
                CurrentSession["CurrencyCode"] = value;
            }
            get
            {
                string result;
                try
                {
                    result = (string)CurrentSession["CurrencyCode"];
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

        public static DateTime FiscalPeriodStartDate
        {
            set { CurrentSession["FiscalPeriodStartDate"] = value; }
            get
            {
                DateTime fiscalPeriodStartDate;
                try
                {

                    fiscalPeriodStartDate = Convert.ToDateTime(CurrentSession["FiscalPeriodStartDate"]);
                }
                catch
                {
                    fiscalPeriodStartDate = DateTime.Now;
                }
                return fiscalPeriodStartDate;

            }
        }

        public static DateTime FiscalPeriodEndDate
        {
            set { CurrentSession["FiscalPeriodEndDate"] = value; }
            get
            {
                DateTime fiscalPeriodEndDate;
                try
                {

                    fiscalPeriodEndDate = Convert.ToDateTime(CurrentSession["FiscalPeriodEndDate"]);
                }
                catch
                {
                    fiscalPeriodEndDate = DateTime.Now;
                }
                return fiscalPeriodEndDate;

            }
        }
    }

}

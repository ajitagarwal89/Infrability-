using System.Collections.Specialized;
using System.Web;
using Infra.SecuritySystem;

namespace Finware
{
    public enum URLAction
	{
		undefined,
		view,
		create,
		update,
		delete,
		list
	}


	public class URLMessage
	{
		private const string ACTIONKEY = "Action";
		private URLAction        _urlAction;
		private StringDictionary _params;
		 
		private Secure secure = new Secure("^%&*()JUHtg43@!~$9lLKo)(","(*&^y54$#EWEd3@!0(8Mk)(*");

		public URLMessage()
		{
			Parse();
		}

		public void Parse()
		{
			Params.Clear();
			URLAction = URLAction.undefined;
			string query =   HttpContext.Current.Request.QueryString.ToString();
			query=Decrypt(HttpUtility.HtmlDecode(query));
			if (!query.Equals(""))
			{  
				string[] keys = query.Split("&".ToCharArray());
				foreach (string key in keys)
				{
					try
					{
						string[] part = key.Split("=".ToCharArray());
						Params.Add(part[0], part[1]);
					} 
					catch {
						//do nothing
					}
				}
			}

			// From them..determine the action.
			if (Params.ContainsKey(ACTIONKEY))
			{
				string buffer = Params[ACTIONKEY].ToLower();
				try
				{
					
					URLAction = (URLAction) URLAction.Parse(typeof(URLAction),buffer,true);
				}
				catch
				{
					URLAction = URLAction.undefined;
				}
			}
		}

		
		//*********************************************//
		//********************************************//
		public string Encrypt(string aValue)
		{
			 
            return secure.EncryptTripleDES(aValue);
            // return aValue;
		}

		//**************************************//
		//**************************************//
		public string Decrypt(string aValue)
		{
			 
            return secure.DecryptTripleDES(aValue);
            // return aValue;
		}

		public string GetParam(string aKeyName, string aDefault)
		{
			string result;
			if (Params.ContainsKey(aKeyName))
				result = Params[aKeyName];
			else
				result = aDefault;
			return result;
		}

		public int GetParam(string aKeyName, int aDefault)
		{
			string buffer = GetParam(aKeyName,aDefault.ToString());
			int result;

			try
			{
				result = int.Parse(buffer);

			}
			catch
			{
				result = aDefault;
			}
			return result;
			
		}

		public double GetParam(string aKeyName, double aDefault)
		{
			string buffer = GetParam(aKeyName,aDefault.ToString());
			double result;

			try
			{
				result = double.Parse(buffer);

			}
			catch
			{
				result = aDefault;
			}
			return result;
			
		}

		public bool GetParam(string aKeyName, bool aDefault)
		{
			return GetParam(aKeyName,aDefault?"1":"0")=="1";
		}



		public StringDictionary Params
		{
			get
			{
				if (_params==null)
				{
					_params = new StringDictionary();
				}
				return _params;
			}
		}

		public URLAction URLAction
		{
			get{ return _urlAction;}
			set{ _urlAction=value;}
		}


		public  string SourceIP()
		{
			string strIpAddress;
			strIpAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
			if (strIpAddress == null)
			{
				strIpAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
			}
			return strIpAddress;
		}

		public  string SourceMessage()
		{
			string strMessage;
			string encrypted_query =   HttpContext.Current.Request.QueryString.ToString();
			string decrypted_query =Decrypt(encrypted_query);
			strMessage = HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString() + "[" +  decrypted_query==""?encrypted_query:decrypted_query +"]";
			return strMessage;
		}

		public  string ApplicationPath()
		{
			 
			return HttpContext.Current.Request.ApplicationPath.ToString();
			 
		}

	}
}

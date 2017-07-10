using System;
using System.Web;

namespace Finware.Issue
{
	public class RaisePage
	{
		private RaisePage()
		{
		}

		public static void ItemNotFound(string aExtraMessage)
		{
			string msg = FindAlternateMessage( aExtraMessage );
			HttpContext.Current.Response.Redirect(@"~/Issue/ItemNotFound.aspx?message=" + msg);
		}

		public static void ConfirmationPage(string aExtraMessage)
		{
			string msg = FindAlternateMessage( aExtraMessage );
			HttpContext.Current.Response.Redirect(@"~/Issue/ConfirmationPage.aspx?message=" + msg);
		}

		public static void DataError(Exception aException)
		{
			string msg =  FindAlternateMessage( aException.Message );
			HttpContext.Current.Response.Redirect(@"~/Issue/DataError.aspx?message=" + msg);
		}

		private static string FindAlternateMessage(string aMessage)
		{
			string result = aMessage;
			
			if (aMessage.ToLower().IndexOf("violation of unique key")>-1)
			{
				result = "The key value for the entry you are attempting to update already exists.";
			}

			return HttpContext.Current.Server.UrlEncode(result);
		}

	}
}

using System;
using System.Web.UI;

namespace Finware
{
    /// <summary>
    /// Summary description for Cargo.
    /// </summary>
    public class Cargo
    {
        StateBag _ViewState;

        public Cargo(StateBag aViewState)
        {
            _ViewState = aViewState;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aKey"></param>
        /// <param name="aOnIssue"></param>
        /// <returns></returns>
        public int GetValue(string aKey, int aOnIssue)
        {
            int result = aOnIssue;
            try
            {
                result = int.Parse(ViewState[aKey].ToString());
            }
            catch
            {
                result = aOnIssue;
            }
            return result;
        }

        public bool GetValue(string aKey, bool aOnIssue)
        {
            bool result = aOnIssue;
            try
            {
                result = bool.Parse(ViewState[aKey].ToString());
            }
            catch
            {
                result = aOnIssue;
            }
            return result;
        }


        public DateTime GetValue(string aKey, DateTime aOnIssue)
        {
            DateTime result = aOnIssue;
            try
            {
                result = DateTime.Parse(ViewState[aKey].ToString());
            }
            catch
            {
                result = aOnIssue;
            }
            return result;
        }

        public string GetValue(string aKey, string aOnIssue)
        {
            string result = aOnIssue;
            try
            {
                result = ViewState[aKey].ToString();
            }
            catch
            {
                result = aOnIssue;
            }
            return result;
        }


        public void SetValue(string aKey, object aValue)
        {
            try
            {
                ViewState[aKey] = aValue;
            }
            catch
            {
                ViewState.Add(aKey, aValue);
            }

        }


        private StateBag ViewState
        {
            get
            {
                return _ViewState;
            }
        }
    }
}

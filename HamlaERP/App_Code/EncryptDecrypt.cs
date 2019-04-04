using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using log4net;

/// <summary>
/// Summary description for EncryptDecrypt
/// </summary>

namespace Finware
{
    public class EncryptDecrypt
    {
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public EncryptDecrypt()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string base64Encode(string sData)
        {
            try
            {
                byte[] encData_byte = new byte[sData.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception exp)
            {
                log.Error("[EncryptDecrypt : base64Encode] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");

                throw new Exception("Error in base64Encode" + exp.Message);


            }
        }

        public string base64Decode(string sData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(sData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
    }

}
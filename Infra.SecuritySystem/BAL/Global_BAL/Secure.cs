using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace Infra.SecuritySystem
{
    public class Secure
    {

        /* IV is used to encrypt the first block of the string to hide and avoid repetative pattern*/
        byte[] KEY_192 = null;
        byte[] IV_192 = null;


        public Secure()
        {
        }

        public Secure(string aSecureKey, string aSecureIV)
        {
            Key(aSecureKey, aSecureIV);
        }

        public void Key(string aSecureKey, string aSecureIV)
        {
            if (Encoding.UTF8.GetByteCount(aSecureKey) != 24)
            {
                throw new Exception("Rquired 24 characters long Security Key");
            }
            else
            {
                KEY_192 = Encoding.UTF8.GetBytes(aSecureKey);
            }
            if (Encoding.UTF8.GetByteCount(aSecureIV) != 24)
            {
                throw new Exception("Requires 24 characters long IV Key");
            }
            else
            {
                IV_192 = Encoding.UTF8.GetBytes(aSecureIV);
            }
        }

        //TRIPLE DES encryption
        public string EncryptTripleDES(string aValue)
        {
            string result = "";
            if (!aValue.Equals(""))
            {
                TripleDESCryptoServiceProvider cryptoProvider = new TripleDESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateEncryptor(KEY_192, IV_192), CryptoStreamMode.Write);
                StreamWriter sw = new StreamWriter(cs);
                sw.Write(aValue);
                sw.Flush();
                cs.FlushFinalBlock();
                ms.Flush();
                //convert back to a string
                result = System.Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
            }
            return Hex(result);
        }


        //TRIPLE DES decryption
        public string DecryptTripleDES(string aValue)
        {
            string result = "";
            if (!aValue.Equals(""))
            {
                try
                {
                    TripleDESCryptoServiceProvider cryptoProvider = new TripleDESCryptoServiceProvider();
                    //convert from string to byte array
                    byte[] buffer = Convert.FromBase64String(DeHex(aValue));
                    MemoryStream ms = new MemoryStream(buffer);
                    CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(KEY_192, IV_192), CryptoStreamMode.Read);
                    StreamReader sr = new StreamReader(cs);
                    result = sr.ReadToEnd();
                }
                catch
                {
                }
            }
            return result;
        }

        private string DeHex(string hexstring)
        {
            string ret = String.Empty;
            StringBuilder sb = new StringBuilder(hexstring.Length / 2);
            for (int i = 0; i <= hexstring.Length - 1; i = i + 2)
            {
                sb.Append((char)int.Parse(hexstring.Substring(i, 2), System.Globalization.NumberStyles.HexNumber));
            }
            return sb.ToString();
        }

        private string Hex(string sData)
        {
            string temp = String.Empty; ;
            string newdata = String.Empty;
            StringBuilder sb = new StringBuilder(sData.Length * 2);
            for (int i = 0; i < sData.Length; i++)
            {
                if ((sData.Length - (i + 1)) > 0)
                {
                    temp = sData.Substring(i, 2);
                    if (temp == @"\n") newdata += "0A";
                    else if (temp == @"\b") newdata += "20";
                    else if (temp == @"\r") newdata += "0D";
                    else if (temp == @"\c") newdata += "2C";
                    else if (temp == @"\\") newdata += "5C";
                    else if (temp == @"\0") newdata += "00";
                    else if (temp == @"\t") newdata += "07";
                    else
                    {
                        sb.Append(String.Format("{0:X2}", (int)(sData.ToCharArray())[i]));
                        i--;
                    }
                }
                else
                {
                    sb.Append(String.Format("{0:X2}", (int)(sData.ToCharArray())[i]));
                }
                i++;
            }
            return sb.ToString();
        }
    }
}
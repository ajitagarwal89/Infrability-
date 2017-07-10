using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace Infra.Security.AESEncryptionLibrary
{
    public class RidjindalEncryption
    {
        private const string PASS_PHRASE = "!n7r@6!1iTY";
        private const string SALT_VALUE = "H@ml@S0l4t!oN";
        private const string HASH_ALGORITHM = "SHA1";
        private const int PASSWORD_INTERATIONS = 2;
        private const string INIT_VECTOR = "M5Dy4@m!cCrM2016";
        private const int KEY_SIZE = 256;

        public RidjindalEncryption()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Encrypt String in using AES Encryption Technique
        /// </summary>
        public static string Encrypt(string plainText)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(INIT_VECTOR);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(SALT_VALUE);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(
                PASS_PHRASE,
                saltValueBytes,
                HASH_ALGORITHM,
                PASSWORD_INTERATIONS);
            byte[] keyBytes = password.GetBytes(KEY_SIZE / 8);

            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;

            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(
                keyBytes,
                initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();

            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                encryptor,
                CryptoStreamMode.Write);

            // Start encrypting.
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

            // Finish encrypting.
            cryptoStream.FlushFinalBlock();

            // Convert our encrypted data from a memory stream into a byte array.
            byte[] cipherTextBytes = memoryStream.ToArray();

            // Close both streams.
            memoryStream.Close();
            cryptoStream.Close();

            // Convert encrypted data into a base64-encoded string.
            string cipherText = Convert.ToBase64String(cipherTextBytes);

            // Return encrypted string.
            return cipherText;
        }

        /// <summary>
        /// Decrypt String in using AES Encryption Technique
        /// </summary>
        public static string Decrypt(string cipherText)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(INIT_VECTOR);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(SALT_VALUE);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            PasswordDeriveBytes password = new PasswordDeriveBytes(
                PASS_PHRASE,
                saltValueBytes,
                HASH_ALGORITHM,
                PASSWORD_INTERATIONS);

            byte[] keyBytes = password.GetBytes(KEY_SIZE / 8);

            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;

            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(
                keyBytes,
                initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                decryptor,
                CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes,
                0,
                plainTextBytes.Length);

            memoryStream.Close();
            cryptoStream.Close();

            string plainText = Encoding.UTF8.GetString(plainTextBytes,
                0,
                decryptedByteCount);

            return plainText;
        }

        public static string PortalEncrypt(string plainText)
        {
            string keyStr = "QIMENCDECKEYVALU";

            RijndaelManaged aes = new RijndaelManaged();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Mode = CipherMode.ECB;

            byte[] keyArr = Encoding.UTF8.GetBytes(keyStr);
            aes.Key = keyArr;

            ICryptoTransform encrypto = aes.CreateEncryptor();

            byte[] plainTextByte = ASCIIEncoding.UTF8.GetBytes(plainText);
            byte[] CipherText = encrypto.TransformFinalBlock(plainTextByte, 0, plainTextByte.Length);
            return Convert.ToBase64String(CipherText);
        }

        public static string PortalDecrypt(string cipherText)
        {
            string keyStr = "QIMENCDECKEYVALU";

            RijndaelManaged aes = new RijndaelManaged();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Mode = CipherMode.ECB;

            byte[] keyArr = Encoding.UTF8.GetBytes(keyStr);
            aes.Key = keyArr;

            ICryptoTransform decrypto = aes.CreateDecryptor();

            byte[] encryptedBytes = Convert.FromBase64CharArray(cipherText.ToCharArray(), 0, cipherText.Length);
            byte[] decryptedData = decrypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
            return ASCIIEncoding.UTF8.GetString(decryptedData);

        }


    }
}

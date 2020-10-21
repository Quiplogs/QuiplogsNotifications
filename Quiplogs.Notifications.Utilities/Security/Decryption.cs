using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Quiplogs.Notifications.Utilities.Security
{
    public static class Decryption
    {
        public static string DecryptString(string key, byte[] text)
        {
            byte[] iv = new byte[16];
            byte[] buffer = text;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}

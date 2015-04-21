using System;
using System.Text;
using System.Security.Cryptography;

namespace ISSU.Data.Encryption
{
    public static class PasswordEncrypter
    {
        public static string Encrypt(string plainText)
        {
            if (String.IsNullOrEmpty(plainText))
                throw new ArgumentNullException("password can not be null or empty.");

            byte[] bytes = Encoding.Unicode.GetBytes(plainText);
            byte[] encrypted = ProtectedData.Protect(bytes, null, DataProtectionScope.LocalMachine);
            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(string encrypted)
        {
            if (String.IsNullOrEmpty(encrypted))
                throw new ArgumentNullException("cannot decrypt a null string");

            byte[] bytes = Convert.FromBase64String(encrypted);
            byte[] decrypted = ProtectedData.Unprotect(bytes, null, DataProtectionScope.LocalMachine);
            return Encoding.Unicode.GetString(decrypted);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace SI.Utility
{
    public static class EncryptDecrypt
    {

        //public static string Decrypt_Password(string encryptpassword)
        //{
        //    string pswstr = string.Empty;
        //    if (encryptpassword != null)
        //    {
        //        System.Text.UTF8Encoding encode_psw = new System.Text.UTF8Encoding();
        //        System.Text.Decoder Decode = encode_psw.GetDecoder();
        //        byte[] todecode_byte = Convert.FromBase64String(encryptpassword);
        //        int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
        //        char[] decoded_char = new char[charCount];
        //        Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
        //        pswstr = new String(decoded_char);
        //    }
        //    return pswstr;
        //}

        //public static string Encrypt_Password(string Paasword)
        //{
        //    string pswstr = string.Empty;
        //    if (Paasword != null)
        //    {
        //        byte[] psw_encode = new byte[Paasword.Length];
        //        psw_encode = System.Text.Encoding.UTF8.GetBytes(Paasword);
        //        pswstr = Convert.ToBase64String(psw_encode);
        //    }
        //    return pswstr;
        //}

        public static string Encrypt_Password(string clearText)
       {
           string EncryptionKey = "XL5tY_vh19";
           byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);

           using (Aes encryptor = Aes.Create())
           {
               Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
               encryptor.Key = pdb.GetBytes(32);
               encryptor.IV = pdb.GetBytes(16);
               using (MemoryStream ms = new MemoryStream())
               {
                   using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                   {
                       cs.Write(clearBytes, 0, clearBytes.Length);
                       cs.Close();
                   }
                   clearText = Convert.ToBase64String(ms.ToArray());
               }
           }
           return clearText;
       }
       public static string Decrypt_Password(string cipherText)
       {
           string EncryptionKey = "XL5tY_vh19";
           cipherText = cipherText.Replace(" ", "+");
           int mod4 = cipherText.Length % 4;
           if (mod4 > 0)
           {
               cipherText += new string('=', 4 - mod4);
           }
           byte[] cipherBytes = Convert.FromBase64String(cipherText);
           using (Aes encryptor = Aes.Create())
           {
               Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
               encryptor.Key = pdb.GetBytes(32);
               encryptor.IV = pdb.GetBytes(16);
               using (MemoryStream ms = new MemoryStream())
               {
                   using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                   {
                       cs.Write(cipherBytes, 0, cipherBytes.Length);
                       cs.Close();
                   }
                   cipherText = Encoding.Unicode.GetString(ms.ToArray());
               }
           }
           return cipherText;
       }
    }
}

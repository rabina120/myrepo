using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace SI.Utility
{
    public static class CryptoHelper
    {
        //for connect IPS
        public static string getIPSToken(string clearText)
        {


           // string certPath = Path.Combine(@"C:\", "NIBLFUND.pfx");  //live

            string certPath = Path.Combine(@"C:\", "PKey", "SSFNEPAL.p12", "CREDITOR.pfx");  //test
            var concateStr = clearText;
            byte[] buffer = Encoding.UTF8.GetBytes(concateStr);
            HashAlgorithm hash = SHA256.Create();
            byte[] hashValue = hash.ComputeHash(buffer);
            return Convert.ToBase64String(signContent(hashValue, certPath));
        }

        //for connectIPS
        private static byte[] signContent(byte[] hashValue, string publicKeyLocation)
        {
            X509Certificate2 publicCert = new X509Certificate2(publicKeyLocation, "123",
                X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);
            X509Certificate2 privateCert = null;
            X509Store store = new X509Store(StoreLocation.LocalMachine);

            store.Open(OpenFlags.ReadOnly);

            foreach (X509Certificate2 cert in store.Certificates)
            {
                if (cert.GetCertHashString() == publicCert.GetCertHashString())
                    privateCert = cert;
            }

            RSACryptoServiceProvider key = new RSACryptoServiceProvider();

            key.FromXmlString(privateCert.PrivateKey.ToXmlString(true));

            byte[] signature = key.SignHash(hashValue, CryptoConfig.MapNameToOID("SHA256"));
            key = (RSACryptoServiceProvider)publicCert.PublicKey.Key;
            if (!key.VerifyHash(hashValue, CryptoConfig.MapNameToOID("SHA256"), signature))
                throw new CryptographicException();
            return signature;
        }
    }
}

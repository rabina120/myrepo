using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Security.Cryptography;
using SI.Utility;

namespace MF.Utility
{
    public class Header
    {
        public string Alg { get; set; } // Encoding algorithm
    }
    public class Payload
    {
        public string ID { get; set; }
        public string Role { get; set; }
        public string Type { get; set; }
    }

    public class JWT
    {
        public Header header { get; set; }
        public Payload payload { get; set; }
    }
    public class JSONWebToken
    {
        public static string GenerateToken(string id, string role, string type, string guid)
        {
            // The Header contains the encoding algorithm.
            Header header = new Header();
            header.Alg = "HS256"; // Using HS256 as default as this is the only algorithm currently in use.

            Payload payload = new Payload();
            payload.ID = id;
            payload.Type = type;
            payload.Role = role;

            var jsonHeader = new JavaScriptSerializer().Serialize(header);
            var jsonpayload = new JavaScriptSerializer().Serialize(payload);

            var b64header = Convert.ToBase64String(Encoding.ASCII.GetBytes(jsonHeader));
            var b64claims = Convert.ToBase64String(Encoding.ASCII.GetBytes(jsonpayload));
            var spayload = b64header + "." + b64claims;
            // The private key used for encoding and decoding
            byte[] key = System.Text.Encoding.ASCII.GetBytes(guid);
            byte[] message = Encoding.UTF8.GetBytes(spayload);
            string sig = Convert.ToBase64String(HashHMAC(key, message));
            string token = spayload + "." + sig;

            return token;
        }

        public static byte[] HashHMAC(byte[] key, byte[] message)
        {
            var hash = new HMACSHA256(key);
            return hash.ComputeHash(message);
        }

        public static JWT DecodeToken(string token, string guid)
        {
            string encHeader = "";
            string encPayload = "";
            string encSignature = "";
            string[] outputs = token.Split('.');
            try
            {
                encHeader = outputs[0];
                encPayload = outputs[1];
                encSignature = outputs[2];
            }
            catch (Exception)
            {
                throw new Exception("403");
            }
            var spayload = encHeader + "." + encPayload;
            byte[] key = System.Text.Encoding.ASCII.GetBytes(guid);
            byte[] message = Encoding.UTF8.GetBytes(spayload);

            string sig = Convert.ToBase64String(HashHMAC(key, message));
            if (sig != encSignature)
            {
                throw new System.ArgumentException("Signature doesn't Match", "original");
            }
            string decodedJsonPayload, decodedJsonHeader;

            byte[] bytePayload = System.Convert.FromBase64String(encPayload.Trim());
            decodedJsonPayload = System.Text.ASCIIEncoding.ASCII.GetString(bytePayload);
            Payload payload = JsonUtility.DeSerialize(decodedJsonPayload, typeof(Payload)) as Payload;

            byte[] byteHeader = System.Convert.FromBase64String(encHeader.Trim());
            decodedJsonHeader = System.Text.ASCIIEncoding.ASCII.GetString(byteHeader);
            Header header = JsonUtility.DeSerialize(decodedJsonHeader, typeof(Header)) as Header;

            JWT output = new JWT();
            output.header = header;
            output.payload = payload;
            return output;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SI.Utility;
using RestSharp;
using System.Net;
using System.Text;
using SI.Security.BLL;

namespace Openend_SIP.Handler.Security
{
    /// <summary>
    /// Summary description for SMSHandler
    /// </summary>
    public class SMSHandler : BaseHandler
    {
        //public object SMSIntegration(string Message, string ContactNumber)
        public object SMSIntegration( string ContactNumber)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            string msg = string.Empty;
            try
            {
                string Message = "";
                //var client = new RestClient("http://api.ininepal.com/api/index?");
                //var request = new RestRequest(Method.POST);
                //request.AddHeader("Authorization", "key qrQtz8KnpHvxj4GBZ2LfsyoOWPcNF7ImVEed6lJu");
                //request.AddHeader("Content-Type", "application/json");         
                //request.AddHeader("content-type", "multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW");
                //request.AddParameter("username", "ininiblsahabhagita");
                //request.AddParameter("password", "nepal@12345");
                //request.AddParameter("message", "Your OTP is " + Message + ".");
                //request.AddParameter("destination", ContactNumber);
                //request.AddParameter("sender", "sms");
                //IRestResponse restResponse = client.Execute(request);

                msg = "Successful";
                response.Message = msg;
                response.IsSucess = true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return JsonUtility.Serialize(response);

        }

        public object SENDSMS(string ContactNumber,string OTP) 
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            //if (IsValidContact(ContactNumber))
            //{
                try
                {
                    BLLSMS bllObj = new BLLSMS();
                    response = bllObj.SENDSMS(ContactNumber, OTP);
                    response.IsSucess = true;
                    return JsonUtility.Serialize(response);

                }
                catch
                {
                    response.IsSucess = false;
                }
            //}
            //else
            //{
            //    response.IsSucess = false;
            //    response.Message = "Enter Email Address is Not Valid";
            //}
            return JsonUtility.Serialize(response);
        }



        public object CHECKContactNoOTP(string ContactNo, string ContatNoOTP)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                BLLSMS bllObj = new BLLSMS();
                response = bllObj.CHECKContactNoOTP(ContactNo, ContatNoOTP); 
                // response.IsSucess = true;
                return JsonUtility.Serialize(response);
            }
            catch
            {
                response.IsSucess = false;
            }
            return JsonUtility.Serialize(response);
        }


    
     }
    
}
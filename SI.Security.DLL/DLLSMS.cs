using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using System.Data.SqlClient;
using System.Data;
using RestSharp;

namespace SI.Security.DLL
{
   public class DLLSMS
    {
       public JsonResponse SENDSMS(string ContactNumber,string OTP) 
       {
           JsonResponse response = new JsonResponse();
           string spName = "";
           string msg = "";

           //string msg = string.Empty;
           //var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
          // var characters = "0123456789";
           //var Charsarr = new char[6];
           //var random = new Random();

           //for (int i = 0; i < Charsarr.Length; i++)
           //{
           //    Charsarr[i] = characters[random.Next(characters.Length)];
           //}

           //var OTP = new String(Charsarr);

           try
           {
               DataSet ds = new DataSet();

               spName = "SaveContactNoOTP";
               SqlParameter[] param = new SqlParameter[2];
               param[0] = new SqlParameter("@Contact_No", ContactNumber);
               param[1] = new SqlParameter("@OTP", OTP);

               ds = DAO.gettable(spName, param);        
               try
               {

                    var client = new RestClient("http://api.ininepal.com/api/index?");
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("Authorization", "key qrQtz8KnpHvxj4GBZ2LfsyoOWPcNF7ImVEed6lJu");
                    request.AddHeader("Content-Type", "application/json");
                    request.AddHeader("content-type", "multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW");
                    request.AddParameter("username", "ininiblsahabhagita");
                    request.AddParameter("password", "nepal@12345");
                    request.AddParameter("message", "Your OTP for NIBL Sahabhagita Fund is " + OTP + ".");
                    request.AddParameter("destination", ContactNumber);
                    request.AddParameter("sender", "sms");
                    IRestResponse restResponse = client.Execute(request);

                    msg = "Successful";
                    response.Message = msg;
                    response.IsSucess = true;




                    //var client = new RestClient("http://api.ininepal.com/api/index?");
                    //client.Timeout = -1;
                    //var request = new RestRequest(Method.POST);
                    //request.AddHeader("Authorization", "key qrQtz8KnpHvxj4GBZ2LfsyoOWPcNF7ImVEed6lJu");
                    //request.AddHeader("Cookie", "easy1session=a%3A5%3A%7Bs%3A10%3A%22session_id%22%3Bs%3A32%3A%225011a056e55ac44085e0f03c213200e8%22%3Bs%3A10%3A%22ip_address%22%3Bs%3A12%3A%22139.5.71.237%22%3Bs%3A10%3A%22user_agent%22%3Bs%3A21%3A%22PostmanRuntime%2F7.29.0%22%3Bs%3A13%3A%22last_activity%22%3Bi%3A1648097660%3Bs%3A9%3A%22user_data%22%3Bs%3A0%3A%22%22%3B%7Dced69690dd3c0f64c9c861013ab9b413");
                    //request.AlwaysMultipartFormData = true;
                    //request.AddParameter("username", "ininiblsahabhagita");
                    //request.AddParameter("password", "nepal@12345");
                    //request.AddParameter("message", "Your OTP for NIBL Sahabhagita Fund is");
                    //request.AddParameter("destination", "9864040045");
                    //request.AddParameter("sender", "sms");
                    //IRestResponse response1 = client.Execute(request);
                    //Console.WriteLine(response1.Content);
                }
               catch (Exception ex)
               {
                 //msg = ex.Message;
               }

           }
           catch (Exception ex)
           {
               throw new Exception("Error" + ex.Message);

           }

           return response;
       }


       public JsonResponse CHECKContactNoOTP(string ContactNo, string ContatNoOTP)
       {

           string spName = "";
           JsonResponse jsonResponse = new JsonResponse();

           try
           {
               DataSet ds = new DataSet();


               spName = "CHECKCONTACTOTP";
               SqlParameter[] param = new SqlParameter[2];
               param[0] = new SqlParameter("@Contact_No", ContactNo);
               param[1] = new SqlParameter("@OTP", ContatNoOTP);

               ds = DAO.gettable(spName, param);
               if (ds.Tables[0].Rows.Count > 0)
               {
                   foreach (DataRow dr in ds.Tables[0].Rows)
                   {
                       jsonResponse.IsSucess = Convert.ToBoolean(dr["IsSucess"]);
                       if (Convert.ToBoolean(dr["IsSucess"].ToString()) == false) throw new Exception("You have entered wrong OTP or the OTP time has expired. PLease Re-Generate the OTP and verify the OTP.");
                   }
               }
               else
               {
                   jsonResponse.IsSucess = false;
               }

           }
           catch (Exception ex)
           {
               throw new Exception("Error" + ex.Message);
           }

           return jsonResponse;
       }

       public JsonResponse VALIDATECONTACTOTP(string ContactNumber, string ContactOTP)  
       {

           string spName = "";
           JsonResponse jsonResponse = new JsonResponse();

           try
           {
               DataSet ds = new DataSet();


               spName = "VALIDATECONTACTOTP";
               SqlParameter[] param = new SqlParameter[2];
               param[0] = new SqlParameter("@Contact_No", ContactNumber);
               param[1] = new SqlParameter("@OTP", ContactOTP);

               ds = DAO.gettable(spName, param);
               if (ds.Tables[0].Rows.Count > 0)
               {
                   foreach (DataRow dr in ds.Tables[0].Rows)
                   {
                       jsonResponse.IsSucess = Convert.ToBoolean(dr["IsSucess"]);

                   }
               }
               else
               {
                   jsonResponse.IsSucess = false;
               }

           }
           catch (Exception ex)
           {
               throw new Exception("Error" + ex.Message);
           }

           return jsonResponse;
       }
    }
}

using System;
using SI.Security.DLL;
using SI.Utility;

namespace SI.Security.BLL
{
    public class BLLSMS
    {
       public JsonResponse SENDSMS(string ContactNumber, string OTP)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSMS objDll = new DLLSMS();
                response.ResponseData = objDll.SENDSMS(ContactNumber,OTP);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;
        }

       public JsonResponse CHECKContactNoOTP(string ContactNo, string ContatNoOTP)
       {
           JsonResponse response = new JsonResponse();
           try
           {

               DLLSMS objDll = new DLLSMS();
               //response.ResponseData = objDll.CHECKOTP(Email,OTP);
               response = objDll.CHECKContactNoOTP(ContactNo, ContatNoOTP);
               //response.IsSucess = true;

           }
           catch (Exception ex)
           {
               response.Message = ex.Message;
               response.IsSucess = false;

           }
           return response;
       }

       public JsonResponse VALIDATECONTACTOTP(string ContactNumber, string ContactOTP)
       {
           JsonResponse response = new JsonResponse();
           try
           {

               DLLSMS objDll = new DLLSMS();
               response = objDll.VALIDATECONTACTOTP(ContactNumber, ContactOTP); 

           }
           catch (Exception ex)
           {
               response.Message = ex.Message;
               response.IsSucess = false;

           }
           return response;
       }
    }
}

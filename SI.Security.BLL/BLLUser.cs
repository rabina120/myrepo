using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.Security.DLL;
using SI.Security.ATT;

namespace SI.Security.BLL
{
   public class BLLUser
    {
        public JsonResponse SearchWebLoginUser(string scheme_code, Int64 Bo_Account_No, string ccode, string l_company_id, string shholder)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLUser objDll = new DLLUser();
                response.ResponseData = objDll.SearchWebLoginUser(scheme_code, Bo_Account_No, ccode, l_company_id, shholder);
                response.IsSucess = true;
                response.Message = "Record Fetched Succesfully!!!";

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        public JsonResponse GetWebHolderDetail(string scheme_code, string Bo_Account_No, string UserName, int ShHolderNo)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLUser objDll = new DLLUser();
                response.ResponseData = objDll.GetWebHolderDetail(scheme_code, Bo_Account_No, UserName, ShHolderNo);
                response.IsSucess = true;
                response.Message = "Password Change Succesfully!!!";

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        public JsonResponse SaveEventLog(ATTUser objATT)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLUser objDll = new DLLUser();
                response.Message = objDll.SaveEventLog(objATT);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        public JsonResponse UpdatePassword(string UserName, string Password, string Email, int UserId)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLUser objDll = new DLLUser();
                response.Message = objDll.UpdatePassword(UserName, Password, Email, UserId);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        public JsonResponse CheckAndChangePass(string UserName, string OldPass, string NewPass)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLUser objDll = new DLLUser();
                response.Message = objDll.CheckAndChangePass(UserName, OldPass, NewPass);
                response.IsSucess = true;
                var value = string.Format(response.Message);
                response.Message = response.Message;
                SaveEventLog objEvent = new SaveEventLog();
                objEvent.SaveEvent(UserName, "Change Password", value);

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        public JsonResponse SaveWebUser(ATTUser objATT)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLUser objDll = new DLLUser();
                response.Message = objDll.SaveWebUser(objATT);
                response.IsSucess = true;
                response.Message = "Login Request is Successfully Sent. Please Check Your Email !!!";
                var value = string.Format("Login Request Saved");
                response.Message = "Record Saved Successfully !!!";
                SaveEventLog objEvent = new SaveEventLog();
                objEvent.SaveEvent(objATT.Name, "Sign Up Form", value);

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }


        public JsonResponse GetDetail(string scheme_code, string Bo_Account_No, string ShHolderNo)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLUser objDll = new DLLUser();
                response.TCount = objDll.GetDetail(scheme_code, Bo_Account_No, ShHolderNo);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;
        }


        public JsonResponse validateEmailaddress(string Email)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLUser objDll = new DLLUser();
                response.ResponseData = objDll.validateEmailaddress(Email);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;
        }

        public JsonResponse SendMailForOTP(string Email, string ContactNumber)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLUser objDll = new DLLUser();
                response.ResponseData = objDll.SendMailForOTP(Email, ContactNumber);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;
        }


        public JsonResponse CHECKOTP(string Email,string OTP)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLUser objDll = new DLLUser();
                //response.ResponseData = objDll.CHECKOTP(Email,OTP);
                response = objDll.CHECKOTP(Email, OTP);
                //response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;
        }
        public JsonResponse VALIDATEOTP(string Email, string OTP)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLUser objDll = new DLLUser();
                //response.ResponseData = objDll.CHECKOTP(Email,OTP);
                response = objDll.VALIDATEOTP(Email, OTP);
                //response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;
        }
        public JsonResponse VALIDATEOTPANDPIN(string Email, string OTP, string Pin)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLUser objDll = new DLLUser();
                //response.ResponseData = objDll.CHECKOTP(Email,OTP);
                response = objDll.VALIDATEOTPANDPIN(Email, OTP, Pin);
                //response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;
        }
        public JsonResponse CheckUser(string UserName, string Password)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLUser objDll = new DLLUser();
                response.ResponseData = objDll.CheckUser(UserName,Password);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        public JsonResponse validateUserName(string UserName)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLUser objDll = new DLLUser();
                response.ResponseData = objDll.validateUserName(UserName);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }

        public JsonResponse GetUsername(string Email, string BOID)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLUser objDll = new DLLUser();
                response = objDll.GetUsername(Email, BOID);
                if (response.Message != null)
                {
                    response.IsSucess = true;
                }
                else
                {
                    response.IsSucess = false;
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }

        public JsonResponse CheckOldPassword(string Password)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLUser objDll = new DLLUser();
                response.ResponseData = objDll.CheckOldPassword(Password);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        public JsonResponse CheckAndChangeOldPass(string UserName, string OldPass, string NewPass)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLUser objDll = new DLLUser();
                response.Message = objDll.CheckAndChangeOldPass(UserName, OldPass, NewPass);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        public JsonResponse Changepassword(string UserName, string NewPass, int UserId, string BOID, string Email)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLUser objDll = new DLLUser();
                response = objDll.Changepassword(UserName, NewPass, UserId, BOID, Email);
               

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }

        public JsonResponse UpdateWebUser(ATTUser objATT)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLUser objDll = new DLLUser();
                response.Message = objDll.UpdateWebUser(objATT);
                response.IsSucess = true;
                response.Message = " User Profile Update Sucessfully !!!";

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }


        public JsonResponse ForgetTransactionPin(ATTTransactionPin objATT)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLUser objDll = new DLLUser();
                response.ResponseData = objDll.ForgetTransactionPin(objATT);
                response.IsSucess = true;
                
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;
        }

        public JsonResponse SubmitPinVerification(ATTTransactionPin objATT)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLUser objDll = new DLLUser();
                response.Message = objDll.SubmitPinVerification(objATT);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;
        }

        public JsonResponse ChangeTransactionPin(ATTTransactionPin objATT)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLUser objDll = new DLLUser();
                response.Message = objDll.ChangeTransactionPin(objATT);
                response.IsSucess = true;

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

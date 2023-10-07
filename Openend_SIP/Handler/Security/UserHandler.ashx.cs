using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SI.Utility;
using SI.Security.BLL;
using SI.Security.ATT;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Openend_SIP.Handler.Security
{
    /// <summary>
    /// Summary description for UserHandler
    /// </summary>
    public class UserHandler : BaseHandler
    {
        
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public object SearchWebLoginUser(string scheme_code, Int64 Bo_Account_No, string ccode, string l_company_id, string shholder)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();

            BLLUser bllObj = new BLLUser();
            response = bllObj.SearchWebLoginUser(scheme_code, Bo_Account_No, ccode, l_company_id, shholder);
            return JsonUtility.Serialize(response);
        }
        public object CheckAndChangePass(string UserName, string OldPass, string NewPass)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            if (OldPass != NewPass)
            {
                BLLUser bllObj = new BLLUser();
                response = bllObj.CheckAndChangePass(UserName, OldPass, NewPass);
            }
            else
            {
                response.Message = "Invalid Password";
                response.IsSucess = false;
            }
            return JsonUtility.Serialize(response);
        }
        public object SaveWebUser(string args)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            JsonResponse otpresponse = new JsonResponse();
            //JsonResponse otpContactresponse = new JsonResponse();
            ATTUser objATT = JsonUtility.DeSerialize(args, typeof(ATTUser)) as ATTUser;
            BLLUser blluser = new BLLUser();
            BLLSMS bllsms = new BLLSMS();
            if (objATT.Gatewaycode == null)
            {
                otpresponse = blluser.VALIDATEOTP(objATT.Email.ToString(), objATT.OTP.ToString());
                //otpContactresponse = bllsms.VALIDATECONTACTOTP(objATT.Contact_No.ToString(), objATT.OTPContact);
            }
            else
            {
                otpresponse.IsSucess = true;
                //otpContactresponse.IsSucess = true;
            }
            if (otpresponse.IsSucess == true)
            {

                BLLUser bllObj = new BLLUser();
                objATT.Password = GeneratePassword.CreateRandomPassword();
                response = bllObj.SaveWebUser(objATT);
                return JsonUtility.Serialize(response);
            }
            else
            {
                otpresponse.Message = "You have entered wrong OTP or the OTP time has expired. PLease Re-Generate the OTP and verify the OTP";
                return JsonUtility.Serialize(otpresponse);
            }
        }

        public object GetDetail(string scheme_code, string Bo_Account_No, string ShHolderNo)
        {
            JsonResponse response = new JsonResponse();
            ValidateToken("A", null);
            BLLUser bllObj = new BLLUser();
            response = bllObj.GetDetail(scheme_code, Bo_Account_No, ShHolderNo);
            return JsonUtility.Serialize(response);
        }
        public object validateUserName(string UserName)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                BLLUser bllObj = new BLLUser();
                response = bllObj.validateUserName(UserName);
                response.IsSucess = true;
                return JsonUtility.Serialize(response);

            }
            catch
            {
                response.IsSucess = false;
            }
            return JsonUtility.Serialize(response);
        }
        public object GetWebHolderDetail(string scheme_code, string Bo_Account_No, string UserName, int ShHolderNo)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            BLLUser bllObj = new BLLUser();
            response = bllObj.GetWebHolderDetail(scheme_code, Bo_Account_No, UserName, ShHolderNo);
            return JsonUtility.Serialize(response);
        }

        public object GetUsername(string Email, string BOID)
        {
            JsonResponse response = new JsonResponse();
            if (IsValidEmail(Email))
            {
                BLLUser bllObj = new BLLUser();
                response = bllObj.GetUsername(Email, BOID);
                if (response.IsSucess)
                {
                    //EmailHandler emailHan = new EmailHandler();
                    //emailHan.SendMailForUserName(response.Message, Email, BOID);
                    response.Message = "UserName Send to Your Mail";
                }
            }
            else
            {
                response.IsSucess = false;
                response.Message = "Enter Email Address is Not Valid"; 
            }
            return JsonUtility.Serialize(response);
        }

        //public object CheckOldPassword(string Password)
        //{
        //    JsonResponse response = new JsonResponse();
        //    try
        //    {
        //        BLLUser bllObj = new BLLUser();
        //        response = bllObj.CheckOldPassword(Password);
        //        response.IsSucess = true;
        //        return JsonUtility.Serialize(response);

        //    }
        //    catch
        //    {
        //        response.IsSucess = false;
        //    }
        //    return JsonUtility.Serialize(response);
        //}

        public object CheckAndChangeOldPass(string UserName, string OldPass, string NewPass)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            BLLUser bllObj = new BLLUser();
            response = bllObj.CheckAndChangeOldPass(UserName, OldPass, NewPass);
            return JsonUtility.Serialize(response);
        }

       
        public object UpdateWebUser(string args)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            ATTUser objATT = JsonUtility.DeSerialize(args, typeof(ATTUser)) as ATTUser;
            BLLUser bllObj = new BLLUser();
            response = bllObj.UpdateWebUser(objATT);
            return JsonUtility.Serialize(response);
        }

        public object DeleteFile(string FileName)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            string path = HttpContext.Current.Server.MapPath(FileName);
             new Task(() =>
            {

            try
            {
               
     
                FileInfo file = new FileInfo(path);
                if (file.Exists)//check file exsit or not  
                {
                    Thread.Sleep(7000);
                    file.Delete();
                    response.IsSucess = true;
                    response.Message = "File DELETED";
                }
                else
                {
                    response.IsSucess = false;
                    response.Message = "File NOT Found";
                } 
            }
            catch (IOException ioExp)
            {
                response.IsSucess = false;
                response.Message = ioExp.Message;
                Console.WriteLine(ioExp.Message);
            }
            }).Start();

            return JsonUtility.Serialize(response);
        }
    }
}
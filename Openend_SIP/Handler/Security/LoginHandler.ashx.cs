using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SI.Utility;
using SI.Security.BLL;
using SI.Security.ATT;


namespace Openend_SIP.Handler.Security
{
    /// <summary>
    /// Summary description for LoginHandler
    /// </summary>
    public class LoginHandler : BaseHandler
    {

        public object LoginUser(string args)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();

            ATTUser user = JsonUtility.DeSerialize(args, typeof(ATTUser)) as ATTUser;
            BLLLogin objBLLLogin = new BLLLogin();
            response = objBLLLogin.LoginUser(user);

            if (response.IsSucess)
            {
                HttpContext.Current.Session["User"] = user;
                BLLUser bllUser = new BLLUser();// to save event into log table
                bllUser.SaveEventLog(user);//
             
                HttpContext.Current.Session["User"] = user;
                SessionManager.CurrentUser = user.UserId.ToString();
                string userType = "A";
                HttpContext.Current.Session["UserType"] = userType;
                GenerateToken(user.UserId.ToString(), null, userType);
                HttpContext.Current.Session["Valid"] = true;

            }

            return JsonUtility.Serialize(response);
        }
        public object LoadSchemes(string l_company_id, string ccode)
        {
            JsonResponse response = new JsonResponse();

            BLLLogin bllObj = new BLLLogin();
            response = bllObj.LoadSchemes(l_company_id, ccode);
            return JsonUtility.Serialize(response);
        }
        public object ClearSession()
        {
            JsonResponse response = new JsonResponse();


            System.Web.HttpContext.Current.Session["User"] = null;
            var httpSession = System.Web.HttpContext.Current.Session;
            System.Web.HttpContext.Current.Session.Clear();
            System.Web.HttpContext.Current.Session.Abandon();

            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.ClearContent();
            System.Web.HttpContext.Current.Response.ClearHeaders();

            response.IsSucess = true;
            response.Message = "User Logged Out";

            return JsonUtility.Serialize(response);
        }
        public object ValidateUser()
        {
            JsonResponse response = new JsonResponse();

            if (IsValidUser())
            {
                response.IsSucess = true;
               // response.Token = Auth.Token();
                response.Token = HttpContext.Current.Session["Token"].ToString();
                response.Message = GetUser();
            }
            else
            {
                response.IsSucess = false;
                response.Message = "Please Login !!!";
                HttpContext.Current.Session["User"] = null;
              

            }

            return JsonUtility.Serialize(response);
        }
        public object ValidatePage()
        {
            JsonResponse response = new JsonResponse();

            if (IsValidPage())
            {
                response.IsSucess = true;
                response.Token = HttpContext.Current.Session["Token"].ToString();
                response.Message = "Successfull";
            }
            else
            {
                response.IsSucess = false;
                response.Message = "Please Load Page";
                HttpContext.Current.Session["Token"] = null;


            }

            return JsonUtility.Serialize(response);
        }

        public object EncryptPassword(string args)
        {
            JsonResponse response = new JsonResponse();
            ATTUser user = JsonUtility.DeSerialize(args, typeof(ATTUser)) as ATTUser;
            response.ResponseData = EncryptDecrypt.Encrypt_Password(user.Password); 
            return JsonUtility.Serialize(response);
             
        }

        public object LoginUserVerify(string args)

        {
            JsonResponse response = new JsonResponse();
            ATTUser user = JsonUtility.DeSerialize(args, typeof(ATTUser)) as ATTUser;
            BLLLogin objBLLLogin = new BLLLogin();
            user.Password = EncryptDecrypt.Decrypt_Password(user.Password); 
            response = objBLLLogin.LoginUser(user);
            if (response.IsSucess)
            {
                HttpContext.Current.Session["User"] = user;
                //   HttpContext.Current.Session["Test"] = "abc";
                BLLUser bllUser = new BLLUser();// to save event into log table
                bllUser.SaveEventLog(user);//

            }

            return JsonUtility.Serialize(response);
        }

    }
}
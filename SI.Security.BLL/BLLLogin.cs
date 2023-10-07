using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.Security.DLL;
using SI.Security.ATT;

namespace SI.Security.BLL
{
    public class BLLLogin
    {
        public JsonResponse LoginUser(ATTUser user)
        {
            JsonResponse response = new JsonResponse();

            try
            {
                DLLLogin objDLLUser = new DLLLogin();
                user = objDLLUser.LoginUser(user);

                if (user.LoggedIn)
                {
                    response.Message = "Login Success!!!";
                    response.IsSucess = true;
                    response.ResponseData = user;
                    var value = string.Format("Logged In Successfully");
                    response.Message = "Logged In Successfully !!!";
                    SaveEventLog objEvent = new SaveEventLog();
                    objEvent.SaveEvent(user.UserName, "Login Form", value);
                }
                else
                {
                    response.Message = "Login Failed !!!";
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
        public JsonResponse LoadSchemes(string l_company_id, string ccode)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLLogin objDll = new DLLLogin();
                response.ResponseData = objDll.LoadSchemes(l_company_id, ccode);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        public JsonResponse GetCurrentDate()
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLLogin objDll = new DLLLogin();
                response.ResponseData = objDll.GetCurrentDate();
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

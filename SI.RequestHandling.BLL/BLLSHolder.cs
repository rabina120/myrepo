using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.RequestHandling.DLL;
using SI.RequestHandling.ATT;
using SI.KYC.ATT;

namespace SI.RequestHandling.BLL
{
    public class BLLSHolder
    {
        public JsonResponse GetSHolders(string scheme_code, Int64 Bo_Account_No, string ccode, string l_company_id, string shholder)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSHolder objDll = new DLLSHolder();
                response.ResponseData = objDll.GetSHolders(scheme_code, Bo_Account_No, ccode, l_company_id, shholder);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }

        public JsonResponse GetSHolderForDREP(string scheme_code, Int64 Bo_Account_No, string ccode, string l_company_id)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSHolder objDll = new DLLSHolder();
                response = objDll.GetSHolderForDREP(scheme_code, Bo_Account_No, ccode, l_company_id);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }

        public JsonResponse CheckSHolders(string scheme_code, string Bo_Account_No, string l_company_id)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSHolder objDll = new DLLSHolder();
                response.ResponseData = objDll.CheckSHolders(scheme_code, Bo_Account_No, l_company_id);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }

        public JsonResponse GetSHoldersforSignUp(string scheme_code, string Bo_Account_No, string ccode, string l_company_id, int shholder)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSHolder objDll = new DLLSHolder();
                response = objDll.GetSHoldersforSignUp(scheme_code, Bo_Account_No, ccode, l_company_id, shholder);
                //response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }

        public JsonResponse SearchHoldersByName(string ASearch, string FSearch, string GSearch, string scheme_code)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSHolder objDll = new DLLSHolder();
                response.ResponseData = objDll.SearchHoldersByName(ASearch, FSearch, GSearch, scheme_code);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        public JsonResponse SearchRedemHolders(string ASearch, string FSearch, string GSearch, string scheme_code, string type, string APPSTATUS)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSHolder objDll = new DLLSHolder();
                response.ResponseData = objDll.SearchRedemHolders(ASearch, FSearch, GSearch, scheme_code, type, APPSTATUS);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        public JsonResponse SearchHolders(string ASearch, string FSearch, string GSearch, string scheme_code, string type, string APPSTATUS)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSHolder objDll = new DLLSHolder();
                response.ResponseData = objDll.SearchHolders(ASearch, FSearch, GSearch, scheme_code, type, APPSTATUS);
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

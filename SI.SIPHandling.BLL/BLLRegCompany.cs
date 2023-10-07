using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.SIPHandling.DLL;
using SI.SIPHandling.ATT;

namespace SI.SIPHandling.BLL
{
    public class BLLRegCompany
    {
        public JsonResponse GetDistrict(string ProvinceCode)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLRegCompany objDll = new DLLRegCompany();
                response.ResponseData = objDll.GetDistrict(ProvinceCode);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }

        public JsonResponse GetState()
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLRegCompany objDll = new DLLRegCompany();
                response.ResponseData = objDll.GetState();
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }

        public JsonResponse SaveCompRegistration(ATTRegCompany objATT)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLRegCompany objDll = new DLLRegCompany();
                response.ResponseData = objDll.SaveCompRegistration(objATT);
                response.IsSucess = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        public JsonResponse GetCompDetail(string scheme_code, string ccode,string l_company_id, int? SubmissionNo, string Action)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLRegCompany objDll = new DLLRegCompany();
                response.ResponseData = objDll.GetCompDetail(scheme_code, ccode, l_company_id , SubmissionNo, Action);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        public JsonResponse DeleteCompInfo(string l_company_id, string scheme_code, string ccode, int SubmissionNo)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                var value = string.Format("Purchase entry of request no {0} deleted", SubmissionNo);
                DLLRegCompany objDll = new DLLRegCompany();
                response.Message = objDll.DeleteCompInfo(l_company_id, scheme_code, ccode, SubmissionNo);
                response.IsSucess = true;
                SaveEventLog objEvent = new SaveEventLog();
                objEvent.SaveEvent(l_company_id, "Purchase Entry Form", value);


            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }

        public JsonResponse GetCertificate()
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLRegCompany objDll = new DLLRegCompany();
                response.ResponseData = objDll.GetCertificate();
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }

        public JsonResponse GetAddress()
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLRegCompany objDll = new DLLRegCompany();
                response.ResponseData = objDll.GetAddress();
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

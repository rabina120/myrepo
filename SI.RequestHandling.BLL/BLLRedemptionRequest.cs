using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.RequestHandling.DLL;
using SI.RequestHandling.ATT;
using SI.Security.ATT;

namespace SI.RequestHandling.BLL
{
    public class BLLRedemptionRequest
    {
        public JsonResponse GetAllocatedData(int SHHOLDERNO, string scheme_code, string Action, string ccode, int? REQUEST_NO, string Flag)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                DLLRedemptionRequest objdll = new DLLRedemptionRequest();
                response.ResponseData = objdll.GetAllocatedData(SHHOLDERNO, scheme_code, Action, ccode, REQUEST_NO, Flag);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;
            }
            return response;
        }
        public JsonResponse GetClientDetial(string BOID, string scheme_code, string l_company_id)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                DLLRedemptionRequest objdll = new DLLRedemptionRequest();
                response.ResponseData = objdll.GetClientDetial(BOID, scheme_code, l_company_id);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;
            }
            return response;
        }
        public JsonResponse SaveRedemptionEntry(ATTShareTransaction objATT, string type)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLRedemptionRequest objDll = new DLLRedemptionRequest();
                response.ResponseData = objDll.SaveRedemptionEntry(objATT, type);
                response.IsSucess = true;
                if (objATT.Action == "A")
                {
                    var value = string.Format("Redemption entry saved with request no {0}", response.ResponseData);
                    response.Message = "Record Added Successfully !!!";
                    SaveEventLog objEvent = new SaveEventLog();
                    objEvent.SaveEvent(objATT.ENTRY_BY, "Redemption Entry Form", value); 
                }
               
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        public JsonResponse GetRedemRequestNo(string scheme_code, string ccode)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLRedemptionRequest objDll = new DLLRedemptionRequest();
                response.ResponseData = objDll.GetRedemRequestNo(scheme_code, ccode);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        
        public JsonResponse GetRedemData(string scheme_code, string ccode, int REQUEST_NO, string Action, string l_company_id)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLRedemptionRequest objDll = new DLLRedemptionRequest();
                response.ResponseData = objDll.GetRedemData(scheme_code, ccode, REQUEST_NO, Action, l_company_id);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        public JsonResponse DeleteRedemeEntry(string shholderno, string scheme_code, string ccode, int REQUEST_NO, string Action, string UserName)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                var value = string.Format("Redemption entry of request no {0} deleted", REQUEST_NO); 
                DLLRedemptionRequest objDll = new DLLRedemptionRequest();
                response.Message = objDll.DeleteRedemeEntry(shholderno, scheme_code, ccode, REQUEST_NO, Action, UserName);
                response.IsSucess = true;
                SaveEventLog objEvent = new SaveEventLog();
                objEvent.SaveEvent(UserName, "Redemption Entry Form", value);

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }

        public JsonResponse VerifyingSecurity(string username, string password, ATTTransactionPin objATT)
        {

            JsonResponse response = new JsonResponse();

            try
            {
                DLLRedemptionRequest objDLLUser = new DLLRedemptionRequest();
                response.ResponseData = objDLLUser.VerifyingSecurity(username, password, objATT);
                response.Message = objDLLUser.VerifyingSecurity(username, password, objATT);
                response.IsSucess = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;
            }


            return response;
        }

        public JsonResponse CheckRedemptionDetail(ATTShareTransaction objATT, string type)
        {

            JsonResponse response = new JsonResponse();

            try
            {
                DLLRedemptionRequest objDLLUser = new DLLRedemptionRequest();
                response.ResponseData = objDLLUser.CheckRedemptionDetail(objATT, type);
                response.Message = "REQUEST SEND SUCCESFULLY";
                response.IsSucess = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;
            }


            return response;
        }
        public JsonResponse VerifyingTransaction(string username, ATTTransactionPin objATT)
        {
            JsonResponse response = new JsonResponse();

            try
            {
                DLLRedemptionRequest objDLLUser = new DLLRedemptionRequest();
                response.ResponseData = objDLLUser.VerifyingSecurity(username, objATT);
                response.IsSucess = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;
            }


            return response;
        }
        public JsonResponse CHECKUNITTOBEREDEM(string scheme_code, float APPLIED_UNIT, string BOID, string L_COMPANY_ID, int SHHOLDERNO, string APPLY_DT)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLRedemptionRequest objDll = new DLLRedemptionRequest();
                response = objDll.CHECKUNITTOBEREDEM(scheme_code, APPLIED_UNIT, BOID, L_COMPANY_ID, SHHOLDERNO, APPLY_DT);
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

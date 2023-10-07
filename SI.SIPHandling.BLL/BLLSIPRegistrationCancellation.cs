using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.SIPHandling.DLL;
using SI.SIPHandling.ATT;


namespace SI.SIPHandling.BLL
{
    public class BLLSIPRegistrationCancellation
    {
        public JsonResponse GetHolderInfoByBoid(string scheme_code, Int64 Bo_Account_No, string ccode, string l_company_id)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSIPRegistrationCancellation objDll = new DLLSIPRegistrationCancellation();
                response.ResponseData = objDll.GetSIPHolderDetail(scheme_code, Bo_Account_No, ccode, l_company_id);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;
        }


        public JsonResponse checkcancellation(string scheme_code, string Bo_Account_No, string l_company_id, string SIP_Reg_No)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSIPRegistrationCancellation objDll = new DLLSIPRegistrationCancellation();
                response.ResponseData = objDll.checkcancellation(scheme_code, Bo_Account_No, l_company_id, SIP_Reg_No);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;
        }
        public JsonResponse CancelSIPHolderDetails(ATTSIP_Registration objATT)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                DLLSIPRegistrationCancellation objDll = new DLLSIPRegistrationCancellation();
                response.ResponseData = objDll.CancelSIPHolderDetails(objATT);
                response.IsSucess = true;
                response.Message = "Has Been Cancelled Successfully !!!";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;
        }

        public JsonResponse CancelSIPRegistration(ATTSIP_Registration objATT)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                DLLSIPRegistrationCancellation objDll = new DLLSIPRegistrationCancellation();
                response.ResponseData = objDll.CancelSIPRegistration(objATT);
                response.IsSucess = true;
                response.Message = "Has Been Cancelled Successfully !!!";
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.SIPHandling.DLL;

namespace SI.SIPHandling.BLL
{
   public  class BLLSIPPurchaseReqReport
    {
       public JsonResponse searchbyreqno(string scheme_code, string ccode, string reqnofrom, string reqnoto, string l_company_id)
       {

           JsonResponse response = new JsonResponse();
           try
           {

               DLLSIPPurchaseReqReport objDll = new DLLSIPPurchaseReqReport();
               response.ResponseData = objDll.searchbyreqno(scheme_code, ccode, reqnofrom, reqnoto, l_company_id);
               response.IsSucess = true;

           }
           catch (Exception ex)
           {
               response.Message = ex.Message;
               response.IsSucess = false;

           }
           return response;

       }

       public JsonResponse searchbyboid(string scheme_code, string ccode, string Bo_Account_No, string l_company_id)
       {

           JsonResponse response = new JsonResponse();
           try
           {

               DLLSIPPurchaseReqReport objDll = new DLLSIPPurchaseReqReport();
               response.ResponseData = objDll.searchbyboid(scheme_code, ccode, Bo_Account_No, l_company_id);
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

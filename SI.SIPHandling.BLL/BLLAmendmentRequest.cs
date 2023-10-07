using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.SIPHandling.DLL;
using SI.SIPHandling.ATT;

namespace SI.SIPHandling.BLL
{
   public class BLLAmendmentRequest
    {
       public JsonResponse LoadData(string scheme_code, string ccode, string Holder_typeNo, string BOID, string l_company_id)
       {
           JsonResponse response = new JsonResponse();
           try
           {

               DLLAmendmentRequest objDll = new DLLAmendmentRequest();
               response.ResponseData = objDll.LoadData(scheme_code, ccode, Holder_typeNo, BOID, l_company_id);
               response.IsSucess = true;

           }
           catch (Exception ex)
           {
               response.Message = ex.Message;
               response.IsSucess = false;

           }
           return response;

       }

       public JsonResponse SaveAmmendment(ATTSIP_Registration objATT)
       {
           JsonResponse response = new JsonResponse();
           try
           {

               DLLAmendmentRequest objDll = new DLLAmendmentRequest();
               response.ResponseData = objDll.SaveAmmendment(objATT);
               response.IsSucess = true;


           }
           catch (Exception ex)
           {
               response.Message = ex.Message;
               response.IsSucess = false;

           }
           return response;

       }

       public JsonResponse GetSipRegNo(string BOID)
       {
           JsonResponse response = new JsonResponse();
           try
           {

               DLLAmendmentRequest objDll = new DLLAmendmentRequest();
               response.ResponseData = objDll.GetSipRegNo(BOID);
               response.IsSucess = true;

           }
           catch (Exception ex)
           {
               response.Message = ex.Message;
               response.IsSucess = false;

           }
           return response;

       }

       public JsonResponse GetSIPHolderDetail(string scheme_code, string ccode, string SIP_Reg_No, string Action, string l_company_id)
       {
           JsonResponse response = new JsonResponse();
           try
           {

               DLLAmendmentRequest objDll = new DLLAmendmentRequest();
               response.ResponseData = objDll.GetSIPHolderDetail(scheme_code, ccode, SIP_Reg_No, Action, l_company_id);
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

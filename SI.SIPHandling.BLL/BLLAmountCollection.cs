using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.SIPHandling.DLL;
using SI.SIPHandling.ATT;

namespace SI.SIPHandling.BLL
{
   public class BLLAmountCollection
    {
       public JsonResponse GetDPDetail()
       {
           JsonResponse response = new JsonResponse();
           try
           {
              
               DLLAmountCollection objDll = new DLLAmountCollection();
               response.ResponseData = objDll.GetDPDetail();
               response.IsSucess = true;
              // response.ResponseData = objDll.GetDPDetail();

           }
           catch (Exception ex)
           {
               response.Message = ex.Message;
               response.IsSucess = false;

           }
           return response;

       }
       public JsonResponse GetCollectedAmtDet(string scheme_code, string ccode)
       {
           JsonResponse response = new JsonResponse();
           try
           {

               DLLAmountCollection objDll = new DLLAmountCollection();
               response.ResponseData = objDll.GetCollectedAmtDet(scheme_code, ccode);
               response.IsSucess = true;
               // response.ResponseData = objDll.GetDPDetail();

           }
           catch (Exception ex)
           {
               response.Message = ex.Message;
               response.IsSucess = false;

           }
           return response;

       }
       public JsonResponse GetSHolders(string scheme_code, Int64 Bo_Account_No, string ccode, int? SHHOLDERNO)
       {
           JsonResponse response = new JsonResponse();
           try
           {

               DLLAmountCollection objDll = new DLLAmountCollection();
               response.ResponseData = objDll.GetSHolders(scheme_code, Bo_Account_No, ccode, SHHOLDERNO);
               response.IsSucess = true;

           }
           catch (Exception ex)
           {
               response.Message = ex.Message;
               response.IsSucess = false;

           }
           return response;

       }
       public JsonResponse GetFundCollectionDetail(string scheme_code, string ccode,string l_company_id, string Action)
       {
           JsonResponse response = new JsonResponse();
           try
           {

               DLLAmountCollection objDll = new DLLAmountCollection();
               response.ResponseData = objDll.GetFundCollectionDetail(scheme_code, ccode,l_company_id, Action);
               response.IsSucess = true;

           }
           catch (Exception ex)
           {
               response.Message = ex.Message;
               response.IsSucess = false;

           }
           return response;

       }
       public JsonResponse SaveAmtCollection(List<ATTAmtCollection> objATT)
       {
           JsonResponse response = new JsonResponse();
           try
           {

               DLLAmountCollection objDll = new DLLAmountCollection();
               response.ResponseData = objDll.SaveAmtCollection(objATT);
               response.IsSucess = true;
             


           }
           catch (Exception ex)
           {
               response.Message = ex.Message;
               response.IsSucess = false;

           }
           return response;

       }
       public JsonResponse GetCollDetail(string scheme_code, string ccode, int trans_no, string Action)
       {
           JsonResponse response = new JsonResponse();
           try
           {

               DLLAmountCollection objDll = new DLLAmountCollection();
               response.ResponseData = objDll.GetCollDetail(scheme_code, ccode, trans_no,Action);
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

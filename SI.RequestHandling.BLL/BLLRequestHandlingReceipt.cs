using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.RequestHandling.DLL;
using SI.RequestHandling.ATT;

namespace SI.RequestHandling.BLL
{
  public  class BLLRequestHandlingReceipt
    {
      public JsonResponse GetPostedDataByBOID(string scheme_code, string ccode, string FormType, string Bo_Account_No)
      {
         
          JsonResponse response = new JsonResponse();
          try
          {

              DLLRequestHandlingReceipt objDll = new DLLRequestHandlingReceipt();
              response.ResponseData = objDll.GetPostedDataByBOID(scheme_code, ccode, FormType, Bo_Account_No);
              response.IsSucess = true;

          }
          catch (Exception ex)
          {
              response.Message = ex.Message;
              response.IsSucess = false;

          }
          return response;

      }
      public JsonResponse GetPostedDataByReqNo(string scheme_code, string ccode, string FormType, string reqnofrom, string reqnoto)
      {

          JsonResponse response = new JsonResponse();
          try
          {

              DLLRequestHandlingReceipt objDll = new DLLRequestHandlingReceipt();
              response.ResponseData = objDll.GetPostedDataByReqNo(scheme_code, ccode, FormType, reqnofrom, reqnoto);
              response.IsSucess = true;

          }
          catch (Exception ex)
          {
              response.Message = ex.Message;
              response.IsSucess = false;

          }
          return response;

      }
      public JsonResponse GetStatusByBoid(string scheme_code, string ccode, string FormType, string Type, string ShHolderNo )
      {

          JsonResponse response = new JsonResponse();
          try
          {

              DLLRequestHandlingReceipt objDll = new DLLRequestHandlingReceipt();
              response.ResponseData = objDll.GetStatusByBoid(scheme_code, ccode, FormType ,Type, ShHolderNo);
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

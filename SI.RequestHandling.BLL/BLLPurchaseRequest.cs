using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.RequestHandling.DLL;
using SI.RequestHandling.ATT;


namespace SI.RequestHandling.BLL
{
  public  class BLLPurchaseRequest
    {

      public JsonResponse GetNAV(string Scheme_code, string ApplyDate)
      {
          JsonResponse response = new JsonResponse();
          try
          {

              DLLPurchaseRequest objDll = new DLLPurchaseRequest();
              response.ResponseData = objDll.GetNAV(Scheme_code, ApplyDate);
              response.IsSucess = true;

          }
          catch (Exception ex)
          {
              response.Message = ex.Message;
              response.IsSucess = false;

          }
          return response;

      }

      public JsonResponse GetChargeType(string Scheme_code)
      {
          JsonResponse response = new JsonResponse();
          try
          {

              DLLPurchaseRequest objDll = new DLLPurchaseRequest();
              response.ResponseData = objDll.GetChargeType(Scheme_code);
              response.IsSucess = true;

          }
          catch (Exception ex)
          {
              response.Message = ex.Message;
              response.IsSucess = false;

          }
          return response;

      }

      public JsonResponse GetUnCheckChequeDetail(string scheme_code, string ccode)
      {
          JsonResponse response = new JsonResponse();
          try
          {

              DLLPurchaseRequest objDll = new DLLPurchaseRequest();
              response.ResponseData = objDll.GetUnCheckChequeDetail(scheme_code, ccode);
              response.IsSucess = true;

          }
          catch (Exception ex)
          {
              response.Message = ex.Message;
              response.IsSucess = false;

          }
          return response;

      }
      public JsonResponse GetServiceChargeAmt(string Scheme_code, string ApplyDate, string NAV_Date, string SCharge_Code)
      {
          JsonResponse response = new JsonResponse();
          try
          {

              DLLPurchaseRequest objDll = new DLLPurchaseRequest();
              response.ResponseData = objDll.GetServiceChargeAmt(Scheme_code, ApplyDate, NAV_Date, SCharge_Code);
              response.IsSucess = true;

          }
          catch (Exception ex)
          {
              response.Message = ex.Message;
              response.IsSucess = false;

          }
          return response;

      }

      public JsonResponse UpdateToken(string Token, string TXNID, string Action)
      {
          JsonResponse response = new JsonResponse();
          try
          {

              DLLPurchaseRequest objDll = new DLLPurchaseRequest();
              response.ResponseData = objDll.UpdateToken(Token,TXNID, Action);
              response.IsSucess = true;

          }
          catch (Exception ex)
          {
              response.Message = ex.Message;
              response.IsSucess = false;

          }
          return response;

      }


      public JsonResponse SavePurchaseEntry(ATTShareTransaction objATTShare)
      {
          JsonResponse response = new JsonResponse();
          try
          {
              JsonResponse jresp1 = new JsonResponse();
              jresp1 = ValidateNAV(objATTShare.APPLY_DT.ToString(), objATTShare.AMOUNT.ToString(), objATTShare.APPLY_UNIT.ToString());
              if (jresp1.IsSucess == true)
              {
                  DLLPurchaseRequest objDll = new DLLPurchaseRequest();
                  response.ResponseData = objDll.SavePurchaseEntry(objATTShare);
                  response.IsSucess = true;

                  if (objATTShare.Action == "A")
                  {
                      var value = string.Format("Purchase entry submitted with request no {0}", response.ResponseData);
                      response.Message = "Record Saved Successfully !!!";
                      SaveEventLog objEvent = new SaveEventLog();
                      objEvent.SaveEvent(objATTShare.FName, "Purchase Entry Form", value);
                  }
                  else if (objATTShare.Action == "I")
                  {
                      var value = string.Format("Purchase entry saved with request no {0}", response.ResponseData);
                      response.Message = "Record Saved Successfully !!!";
                      SaveEventLog objEvent = new SaveEventLog();
                      objEvent.SaveEvent(objATTShare.FName, "Purchase Entry Form", value);
                  }

              }
              else {
                  response.Message ="Record Mismatched!!";
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
      public JsonResponse UpdateKhaltiTransactionStatus(ATTPayment objATTShare, string Action, string GatewayCode, string TXNID, string ReferenceID, string PaymentCode)
      {
          JsonResponse response = new JsonResponse();
          try
          {

              DLLPurchaseRequest objDll = new DLLPurchaseRequest();
              response.ResponseData = objDll.UpdateKhaltiTransactionStatus(objATTShare, Action, GatewayCode, ReferenceID, TXNID, PaymentCode);
              response.IsSucess = true;

          }
          catch (Exception ex)
          {
              response.Message = ex.Message;
              response.IsSucess = false;

          }
          return response;

      }

      public JsonResponse UpdateTransactionStatus(ATTPayment objATTShare, string Action, string ReferenceID, string PayAppName, string GatewayCode, string PaymentCode)
      {
          JsonResponse response = new JsonResponse();
          try
          {

              DLLPurchaseRequest objDll = new DLLPurchaseRequest();
              response.ResponseData = objDll.UpdateTransactionStatus(objATTShare, Action, ReferenceID, PayAppName, GatewayCode, PaymentCode);
              response.IsSucess = true;
             
          }
          catch (Exception ex)
          {
              response.Message = ex.Message;
              response.IsSucess = false;

          }
          return response;

      }
        public JsonResponse UpdateEbankingTransactionStatus(ATTPayment objATTShare, string Action, string GatewayCode, string PaymentCode)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLPurchaseRequest objDll = new DLLPurchaseRequest();
                response.ResponseData = objDll.UpdateEbankingTransactionStatus(objATTShare, Action, GatewayCode, PaymentCode);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }

        public JsonResponse GetData(string scheme_code, string ccode, int REQUEST_NO, string Action, string l_company_id)
      {
          JsonResponse response = new JsonResponse();
          try
          {

              DLLPurchaseRequest objDll = new DLLPurchaseRequest();
              response.ResponseData = objDll.GetData(scheme_code, ccode, REQUEST_NO, Action, l_company_id);
              response.IsSucess = true;

          }
          catch (Exception ex)
          {
              response.Message = ex.Message;
              response.IsSucess = false;

          }
          return response;

      }

      public JsonResponse ValidateAmount(string TXNID)
      {
          JsonResponse response = new JsonResponse();
          try
          {

              DLLPurchaseRequest objDll = new DLLPurchaseRequest();
              response.ResponseData = objDll.ValidateAmount(TXNID);
              response.IsSucess = true;

          }
          catch (Exception ex)
          {
              response.Message = ex.Message;
              response.IsSucess = false;

          }
          return response;

      }
      public JsonResponse GetHolderUnitRpt(string scheme_code, string ccode, string Bo_Account_No, string l_company_id, DateTime startdate , DateTime enddate)
      {
          JsonResponse response = new JsonResponse();
          try
          {

              DLLPurchaseRequest objDll = new DLLPurchaseRequest();
              response.ResponseData = objDll.GetHolderUnitRpt(scheme_code, ccode, Bo_Account_No, l_company_id, startdate , enddate);
              response.IsSucess = true;

          }
          catch (Exception ex)
          {
              response.Message = ex.Message;
              response.IsSucess = false;

          }
          return response;

      }
      public JsonResponse GetRequestNo(string scheme_code, string ccode)
      {
          JsonResponse response = new JsonResponse();
          try
          {

              DLLPurchaseRequest objDll = new DLLPurchaseRequest();
              response.ResponseData = objDll.GetRequestNo(scheme_code, ccode);
              response.IsSucess = true;

          }
          catch (Exception ex)
          {
              response.Message = ex.Message;
              response.IsSucess = false;

          }
          return response;

      }



      public JsonResponse DeletePurchaseEntry(string username, string shholderno, string scheme_code, string ccode, int REQUEST_NO, string l_company_id)
      {
          JsonResponse response = new JsonResponse();
          try
          {
              var value = string.Format("Purchase entry of request no {0} deleted", REQUEST_NO); 
              DLLPurchaseRequest objDll = new DLLPurchaseRequest();
              response.Message = objDll.DeletePurchaseEntry(username, shholderno, scheme_code, ccode, REQUEST_NO, l_company_id);
              response.IsSucess = true;
              SaveEventLog objEvent = new SaveEventLog();
              objEvent.SaveEvent(username, "Purchase Entry Form", value);


          }
          catch (Exception ex)
          {
              response.Message = ex.Message;
              response.IsSucess = false;

          }
          return response;

      }
      public JsonResponse UpdateChequeStatus(List<ATTShareTransaction> objATT)
      {
          JsonResponse response = new JsonResponse();
          try
          {

              DLLPurchaseRequest objDll = new DLLPurchaseRequest();
              response.ResponseData = objDll.UpdateChequeStatus(objATT);
              response.IsSucess = true;
              foreach (ATTShareTransaction objATTShare in objATT)
              {
                  var value = string.Format("Cheque status with request no {0} updated", objATTShare.REQUEST_NO);
                  SaveEventLog objEvent = new SaveEventLog();
                  objEvent.SaveEvent(objATTShare.ChequeCheckedBy, "Check Cheque Status", value);
              }


          }
          catch (Exception ex)
          {
              response.Message = ex.Message;
              response.IsSucess = false;

          }
          return response;

      }

      public JsonResponse GetDPInfo()
      {
          JsonResponse response = new JsonResponse();
          try
          {

              DLLPurchaseRequest objDll = new DLLPurchaseRequest();
              response.ResponseData = objDll.GetDPInfo();
              response.IsSucess = true;

          }
          catch (Exception ex)
          {
              response.Message = ex.Message;
              response.IsSucess = false;

          }
          return response;

      }

      public JsonResponse GetDPInfo2()
      {
          JsonResponse response = new JsonResponse();
          try
          {

              DLLPurchaseRequest objDll = new DLLPurchaseRequest();
              response.ResponseData = objDll.GetDPInfo2();
              response.IsSucess = true;

          }
          catch (Exception ex)
          {
              response.Message = ex.Message;
              response.IsSucess = false;

          }
          return response;

      }

      public JsonResponse DeletePostedPurchase(string shholderno, string scheme_code, string ccode, int REQUEST_NO, string Action, string username, string l_company_id)
      {
          JsonResponse response = new JsonResponse();
          try
          {
              var value = string.Format("Posted Purchase entry of request no {0} deleted", REQUEST_NO); 
              DLLPurchaseRequest objDll = new DLLPurchaseRequest();
              response.Message = objDll.DeletePostedPurchase(shholderno, scheme_code, ccode, REQUEST_NO, Action, username, l_company_id);
              response.IsSucess = true;
              SaveEventLog objEvent = new SaveEventLog();
              objEvent.SaveEvent(username, "Purchase Entry Form", value);


          }
          catch (Exception ex)
          {
              response.Message = ex.Message;
              response.IsSucess = false;

          }
          return response;

      }

      public JsonResponse ValidateNAV(string APPLY_DT, string Amount, string APPLY_UNIT)
      {
          JsonResponse response = new JsonResponse();
          try
          {

              DLLPurchaseRequest objDll = new DLLPurchaseRequest();
              response = objDll.ValidateNAV(APPLY_DT, Amount, APPLY_UNIT);
              //response.IsSucess = true;

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

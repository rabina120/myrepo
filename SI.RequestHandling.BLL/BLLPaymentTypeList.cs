using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.RequestHandling.DLL;

namespace SI.RequestHandling.BLL
{
  public class BLLPaymentTypeList
    {

      public JsonResponse GetFilePathByStatusPayment()
      {
          JsonResponse response = new JsonResponse();
          try
          {

              DLLPaymentTypeList objDll = new DLLPaymentTypeList();
              response.ResponseData = objDll.GetFilePathByStatusPayment();
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

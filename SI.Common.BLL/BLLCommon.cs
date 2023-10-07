using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.Common.DLL;

namespace SI.Common.BLL
{
   public class BLLCommon
    {
       public JsonResponse GetDataByTXNID(string GatewayCode, string TXNID)
      {
          JsonResponse response = new JsonResponse();
          try
          {

              DLLCommon objDll = new DLLCommon();
              response.ResponseData = objDll.GetDataByTXNID(GatewayCode, TXNID);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.RequestHandling.DLL;
using SI.RequestHandling.ATT;


namespace SI.RequestHandling.BLL
{
   public  class BLLBank
    {
       public JsonResponse GetBank()
       {
           JsonResponse response = new JsonResponse();
           try
           {

               DLLBank objDll = new DLLBank();
               response.ResponseData = objDll.GetBank();
               response.IsSucess = true;

           }
           catch (Exception ex)
           {
               response.Message = ex.Message;
               response.IsSucess = false;

           }
           return response;

       }
       public JsonResponse GetBranch(string bankcode)
       {
           JsonResponse response = new JsonResponse();
           try
           {

               DLLBank objDll = new DLLBank();
               response.ResponseData = objDll.GetBranch(bankcode);
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

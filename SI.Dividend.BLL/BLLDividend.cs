using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.Dividend.DLL;
using SI.Dividend.ATT;

namespace SI.Dividend.BLL
{
    public class BLLDividend
    {
        public JsonResponse SubmitDivRequest(ATTDividend objATT)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLDividend objDll = new DLLDividend();
                response.ResponseData = objDll.SubmitDivRequest(objATT);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        public JsonResponse CheckBoidPosted(Int64 Bo_Account_No)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLDividend objDll = new DLLDividend();
                response.ResponseData = objDll.CheckBoidPosted(Bo_Account_No);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;
        }

        public JsonResponse SubmitDREPRequest(ATTDividend objATT)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLDividend objDll = new DLLDividend();
                response.ResponseData = objDll.SubmitDREPRequest(objATT);
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

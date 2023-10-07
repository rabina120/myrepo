using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.SIPHandling.DLL;
using SI.SIPHandling.ATT;

namespace SI.SIPHandling.BLL
{
    public class BLLSIPPayment
    {
        public JsonResponse GetActionDate(Int64 BOID)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSIPPayment objDll = new DLLSIPPayment();
                response.ResponseData = objDll.GetActionDate(BOID);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
     
        public JsonResponse GetTXNData(string TXNID)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSIPPayment objDll = new DLLSIPPayment();
                response.ResponseData = objDll.GetTXNData(TXNID);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        public JsonResponse InsertSipPayment(List<ATTSIP_Registration> objATT)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSIPPayment objDll = new DLLSIPPayment();
                response.ResponseData = objDll.InsertSipPayment(objATT);
                response.IsSucess = true;
                //foreach (ATTSIP_Registration objATTFund in objATT)
                //{
                //    var value = string.Format("SIP Payment saved with registration no {0}", response.ResponseData);
                //    response.Message = "Record Saved Successfully !!!";
                //    SaveEventLog objEvent = new SaveEventLog();
                //    objEvent.SaveEvent(objATTFund.Name, "SIP Payment ", value);
                //}

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }

        public JsonResponse ValidateInterval(List<ATTSIP_Registration> objATT)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSIPPayment objDll = new DLLSIPPayment();
                //response.ResponseData = objDll.ValidateInterval(objATT);
                response = objDll.ValidateInterval(objATT);
             //   response.IsSucess = true;
               
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        public JsonResponse SubmitSipPayment(ATTSIP_Registration objATT)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSIPPayment objDll = new DLLSIPPayment();
                response.ResponseData = objDll.SubmitSipPayment(objATT);
                response.IsSucess = true;
                var value = string.Format("SIP Payment submitted with registration no {0}", response.ResponseData);
                response.Message = "Record Added Successfully !!!";
                SaveEventLog objEvent = new SaveEventLog();
                objEvent.SaveEvent(objATT.Name, "SIP Payment", value);


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

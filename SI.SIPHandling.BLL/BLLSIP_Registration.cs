using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.SIPHandling.DLL;
using SI.SIPHandling.ATT;
namespace SI.SIPHandling.BLL
{
    public class BLLSIP_Registration
    {
        public JsonResponse GetBankName()
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSIP_Registration objDll = new DLLSIP_Registration();
                response.ResponseData = objDll.GetBankName();
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        public JsonResponse ValidateSIPAmount(string TXNID, string Action)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSIP_Registration objDll = new DLLSIP_Registration();
                response.ResponseData = objDll.ValidateSIPAmount(TXNID, Action);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        
        public JsonResponse GetNAV(string Scheme_code, string ApplyDate)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSIP_Registration objDll = new DLLSIP_Registration();
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
        public JsonResponse GetHolderType()
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSIP_Registration objDll = new DLLSIP_Registration();
                response.ResponseData = objDll.GetHolderType();
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }

        public JsonResponse LoadPaymentMode()
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSIP_Registration objDll = new DLLSIP_Registration();
                response.ResponseData = objDll.LoadPaymentMode();
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        public JsonResponse LoadPaymentModeforAmend()
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSIP_Registration objDll = new DLLSIP_Registration();
                response.ResponseData = objDll.LoadPaymentModeforAmend();
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        public JsonResponse GetSipIntervals()
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSIP_Registration objDll = new DLLSIP_Registration();
                response.ResponseData = objDll.GetSipIntervals();
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

                DLLSIP_Registration objDll = new DLLSIP_Registration();
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

        public JsonResponse SearchHoldersByName(string ASearch, string FSearch, string GSearch, string scheme_code, string l_company_id)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSIP_Registration objDll = new DLLSIP_Registration();
                response.ResponseData = objDll.SearchHoldersByName(ASearch, FSearch, GSearch, scheme_code, l_company_id);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }

        public JsonResponse SaveFundCollection(ATTAmtCollection objATT)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSIP_Registration objDll = new DLLSIP_Registration();
                response.ResponseData = objDll.SaveFundCollection(objATT);
                response.IsSucess = true;


            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        public JsonResponse SaveSipRegistration(ATTSIP_Registration objATT)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSIP_Registration objDll = new DLLSIP_Registration();
                response.ResponseData = objDll.SaveSipRegistration(objATT);
                response.IsSucess = true;
                //foreach (ATTSIP_Registration objATT in objATTShare)
                //{
                if (objATT.Action == "A")
                {
                    var value = string.Format("SIP Registration submitted with registration no {0}", response.ResponseData);
                    response.Message = "Record Saved Successfully !!!";
                    SaveEventLog objEvent = new SaveEventLog();
                    objEvent.SaveEvent(objATT.Name, "SIP Registration Form", value);
                }
                else if (objATT.Action == "I" )
                {
                    var value = string.Format("SIP Registration saved with registration no {0}", response.ResponseData);
                    response.Message = "Record Saved Successfully !!!";
                    SaveEventLog objEvent = new SaveEventLog();
                    objEvent.SaveEvent(objATT.Name, "SIP Registration Form", value);
                }
                //}


            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }

        public JsonResponse GetHolderInfoByBoid(string scheme_code, Int64 Bo_Account_No, string ccode, string l_company_id)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSIP_Registration objDll = new DLLSIP_Registration();
                response.ResponseData = objDll.GetHolderInfoByBoid(scheme_code, Bo_Account_No, ccode, l_company_id);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }

        public JsonResponse GetSIPHolderInfoByBoid(string scheme_code, string Bo_Account_No, string ccode, string l_company_id)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSIP_Registration objDll = new DLLSIP_Registration();
                response.ResponseData = objDll.GetSIPHolderInfoByBoid(scheme_code, Bo_Account_No, ccode, l_company_id);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        public JsonResponse CheckSIPSHolders(string scheme_code, string Bo_Account_No, string l_company_id)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLSIP_Registration objDll = new DLLSIP_Registration();
                response.ResponseData = objDll.CheckSIPSHolders(scheme_code, Bo_Account_No, l_company_id);
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

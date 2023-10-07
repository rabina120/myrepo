using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SI.Utility;
using SI.SIPHandling.BLL;
using SI.SIPHandling.ATT;
using SI.Security.ATT;
using SI.Security.BLL;
using SI.RequestHandling.ATT;

namespace Openend_Sip.Handler.SIPHandling
{
    /// <summary>
    /// Summary description for SIP_Registration
    /// </summary>
    public class SIP_Registration : BaseHandler
    {
        public object GetNAV(string Scheme_code, string ApplyDate)
        {
            JsonResponse response = new JsonResponse();
            BLLSIP_Registration objbll = new BLLSIP_Registration();
            response = objbll.GetNAV(Scheme_code, ApplyDate);
            return JsonUtility.Serialize(response);
        }
        public object GetBankName()
        {
            JsonResponse response = new JsonResponse();

            BLLSIP_Registration bllObj = new BLLSIP_Registration();
            response = bllObj.GetBankName();
            return JsonUtility.Serialize(response);
        }

        public object GetHolderType()
        {
            JsonResponse response = new JsonResponse();

            BLLSIP_Registration bllObj = new BLLSIP_Registration();
            response = bllObj.GetHolderType();
            return JsonUtility.Serialize(response);
        }
        public object LoadPaymentMode()
        {
            JsonResponse response = new JsonResponse();

            BLLSIP_Registration bllObj = new BLLSIP_Registration();
            response = bllObj.LoadPaymentMode();
            return JsonUtility.Serialize(response);
        }
        public object LoadPaymentModeforAmend()
        {
            JsonResponse response = new JsonResponse();

            BLLSIP_Registration bllObj = new BLLSIP_Registration();
            response = bllObj.LoadPaymentModeforAmend();
            return JsonUtility.Serialize(response);
        }
        public object GetSipIntervals()
        {
            JsonResponse response = new JsonResponse();
            BLLSIP_Registration bllObj = new BLLSIP_Registration();
            response = bllObj.GetSipIntervals();
            return JsonUtility.Serialize(response);
        }

        public object SaveSipRegistration(string args,string SignUp)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            JsonResponse otpresponse = new JsonResponse();
            //JsonResponse otpContactresponse = new JsonResponse();
            ATTSIP_Registration objATT = JsonUtility.DeSerialize(args, typeof(ATTSIP_Registration)) as ATTSIP_Registration;
            if (objATT.Sip_amt >= 1000)
            {
                BLLUser blluser = new BLLUser();
                BLLSMS bllsms = new BLLSMS();

                if (objATT.GatewayCode == "002" && objATT.APPSTATUS == "INITIAL")
                { 
                    otpresponse = blluser.VALIDATEOTP(objATT.Email.ToString(), objATT.OTP);
                    //otpContactresponse = bllsms.VALIDATECONTACTOTP(objATT.Contact1.ToString(), objATT.OTPContact);
                    //if (otpresponse.IsSucess == true && otpContactresponse.IsSucess == true)
                    if (otpresponse.IsSucess == true)
                    {

                        BLLSIP_Registration bllObj = new BLLSIP_Registration();
                        response = bllObj.SaveSipRegistration(objATT);
                        if (SignUp != null)
                        {
                            ATTUser objSign = JsonUtility.DeSerialize(SignUp, typeof(ATTUser)) as ATTUser;
                            BLLUser bllSign = new BLLUser();
                            response = bllSign.SaveWebUser(objSign);
                        }
                        return JsonUtility.Serialize(response);
                    }
                    else
                    {
                        otpresponse.Message = "You have entered wrong OTP or the OTP time has expired. PLease Re-Generate the OTP and verify the OTP";
                        return JsonUtility.Serialize(otpresponse);
                    }
                }
                else
                {
                    BLLSIP_Registration bllObj = new BLLSIP_Registration();
                    response = bllObj.SaveSipRegistration(objATT);
                    if (SignUp != null)
                    {
                        ATTUser objSign = JsonUtility.DeSerialize(SignUp, typeof(ATTUser)) as ATTUser;
                        BLLUser bllSign = new BLLUser();
                        response = bllSign.SaveWebUser(objSign);
                    }
                    return JsonUtility.Serialize(response);
                }
              
            }
            else {
                response.Message = "Something went wrong.Please try again later.";
                return JsonUtility.Serialize(response);
            }

        }
        public object ValidateSIPAmount(string TXNID, string Action)
        {
            JsonResponse response = new JsonResponse();
            BLLSIP_Registration bllObj = new BLLSIP_Registration();
            response = bllObj.ValidateSIPAmount(TXNID, Action);
            return JsonUtility.Serialize(response);
        }
        public object SaveFundCollection(string args)
        {
            JsonResponse response = new JsonResponse();
            ATTAmtCollection objATT = JsonUtility.DeSerialize(args, typeof(ATTAmtCollection)) as ATTAmtCollection;
             ValidateToken("A", null);
            BLLSIP_Registration bllObj = new BLLSIP_Registration();
            response = bllObj.SaveFundCollection(objATT);
           
            return JsonUtility.Serialize(response);

        }
        //public object SearchHoldersByName(string ASearch, string FSearch, string GSearch, string scheme_code, string l_company_id)
        //{
        //    JsonResponse response = new JsonResponse();

        //    BLLSIP_Registration bllObj = new BLLSIP_Registration();
        //    response = bllObj.SearchHoldersByName(ASearch, FSearch, GSearch, scheme_code, l_company_id);
        //    return JsonUtility.Serialize(response);
        //}
        public object GetSIPHolderDetail(string scheme_code, string ccode, string SIP_Reg_No, string Action,string l_company_id)
        {
            JsonResponse response = new JsonResponse();
            ValidateToken("A", null);
            BLLSIP_Registration bllObj = new BLLSIP_Registration();
            response = bllObj.GetSIPHolderDetail(scheme_code, ccode, SIP_Reg_No, Action,l_company_id);
            return JsonUtility.Serialize(response);
        }
        public object GetHolderInfoByBoid(string scheme_code, Int64 Bo_Account_No, string ccode, string l_company_id)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            BLLSIP_Registration bllObj = new BLLSIP_Registration();
            response = bllObj.GetHolderInfoByBoid(scheme_code, Bo_Account_No, ccode, l_company_id);
            return JsonUtility.Serialize(response);
        }
        public object GetSIPHolderInfoByBoid(string scheme_code, string Bo_Account_No, string ccode, string l_company_id)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();

            BLLSIP_Registration bllObj = new BLLSIP_Registration();
            response = bllObj.GetSIPHolderInfoByBoid(scheme_code, Bo_Account_No, ccode, l_company_id);
            return JsonUtility.Serialize(response);
        }
        public object CheckSIPSHolders(string scheme_code, string Bo_Account_No, string l_company_id)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();

            BLLSIP_Registration bllObj = new BLLSIP_Registration();
            response = bllObj.CheckSIPSHolders(scheme_code, Bo_Account_No, l_company_id);
            return JsonUtility.Serialize(response);
        }

  
    }
}
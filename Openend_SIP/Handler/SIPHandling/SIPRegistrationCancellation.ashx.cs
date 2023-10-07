using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SI.Utility;
using SI.SIPHandling.BLL;
using SI.SIPHandling.ATT;

namespace Openend_SIP.Handler.SIPHandling
{
    /// <summary>
    /// Summary description for SIPRegistrationCancellation
    /// </summary>
    public class SIPRegistrationCancellation : BaseHandler
    {

        public object GetHolderInfoByBoid(string scheme_code, Int64 Bo_Account_No, string ccode, string l_company_id)
        {
            JsonResponse response = new JsonResponse();
            ValidateToken("A", null);
            BLLSIPRegistrationCancellation bllObj = new BLLSIPRegistrationCancellation();
            response = bllObj.GetHolderInfoByBoid(scheme_code, Bo_Account_No, ccode, l_company_id);
            return JsonUtility.Serialize(response);
        }
        public object checkcancellation(string scheme_code, string Bo_Account_No, string l_company_id, string SIP_Reg_No)
        {
            JsonResponse response = new JsonResponse();
            ValidateToken("A", null);
            BLLSIPRegistrationCancellation bllObj = new BLLSIPRegistrationCancellation();
            response = bllObj.checkcancellation(scheme_code, Bo_Account_No, l_company_id, SIP_Reg_No);
            return JsonUtility.Serialize(response);
        }
        public object CancelSIPHolderDetails(string args)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            ATTSIP_Registration objATT = JsonUtility.DeSerialize(args, typeof(ATTSIP_Registration)) as ATTSIP_Registration;
            BLLSIPRegistrationCancellation bllObj = new BLLSIPRegistrationCancellation();
            response = bllObj.CancelSIPHolderDetails(objATT);
            return JsonUtility.Serialize(response);
        }
        public object CancelSIPRegistration(string args)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            ATTSIP_Registration objATT = JsonUtility.DeSerialize(args, typeof(ATTSIP_Registration)) as ATTSIP_Registration;
            BLLSIPRegistrationCancellation bllObj = new BLLSIPRegistrationCancellation();
            response = bllObj.CancelSIPRegistration(objATT);
            return JsonUtility.Serialize(response);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
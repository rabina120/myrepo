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
    /// Summary description for AmendmentRequestHandler
    /// </summary>
    public class AmendmentRequestHandler : BaseHandler
    {

        public object GetSipRegNo(string BOID)
        {
            JsonResponse response = new JsonResponse();

            BLLAmendmentRequest bllObj = new BLLAmendmentRequest();
            response = bllObj.GetSipRegNo(BOID);
            return JsonUtility.Serialize(response);
        }

        public object GetSIPHolderDetail(string scheme_code, string ccode, string SIP_Reg_No, string Action, string l_company_id)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();

            BLLAmendmentRequest bllObj = new BLLAmendmentRequest();
            response = bllObj.GetSIPHolderDetail(scheme_code, ccode, SIP_Reg_No, Action, l_company_id);
            return JsonUtility.Serialize(response);
        }

        public object SaveAmmendment(string args)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            ATTSIP_Registration objATT = JsonUtility.DeSerialize(args, typeof(ATTSIP_Registration)) as ATTSIP_Registration;
            BLLAmendmentRequest bllObj = new BLLAmendmentRequest();
            response = bllObj.SaveAmmendment(objATT);
            return JsonUtility.Serialize(response);

        }

        public object LoadData(string scheme_code, string ccode, string Holder_typeNo, string BOID, string l_company_id)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            BLLAmendmentRequest bllObj = new BLLAmendmentRequest();
            response = bllObj.LoadData(scheme_code, ccode, Holder_typeNo, BOID, l_company_id);
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
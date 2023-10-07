using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SI.Utility;
using SI.Dividend.ATT;
using SI.Dividend.BLL;

namespace Openend_SIP.Handler.Dividend
{

    public class DividendHandler : BaseHandler
    {
        public object SubmitDivRequest(string args)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            ATTDividend objATT = JsonUtility.DeSerialize(args, typeof(ATTDividend)) as ATTDividend;
            BLLDividend bllObj = new BLLDividend();
            response = bllObj.SubmitDivRequest(objATT);
            return JsonUtility.Serialize(response);
        }

        //checking is boid posted or not
        public object CheckBoidPosted(Int64 Bo_Account_No)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            BLLDividend bllObj = new BLLDividend();
            response = bllObj.CheckBoidPosted(Bo_Account_No);
            return JsonUtility.Serialize(response);
            
        }
        public object SubmitDREPRequest(string args)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            ATTDividend objATT = JsonUtility.DeSerialize(args, typeof(ATTDividend)) as ATTDividend;
            BLLDividend bllObj = new BLLDividend();
            response = bllObj.SubmitDREPRequest(objATT);
            return JsonUtility.Serialize(response);
        }


        
    }
}
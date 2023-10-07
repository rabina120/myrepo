using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SI.Utility;
using SI.Security.ATT;
using SI.Security.BLL;

namespace Openend_SIP.Handler.Security
{
    /// <summary>
    /// Summary description for TransactionPin
    /// </summary>
    public class TransactionPin : BaseHandler
    {

        public object ForgetTransactionPin(string args)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            ATTTransactionPin objATT = JsonUtility.DeSerialize(args, typeof(ATTTransactionPin)) as ATTTransactionPin;
            BLLUser bllObj = new BLLUser();
            response = bllObj.ForgetTransactionPin(objATT);
            return JsonUtility.Serialize(response);
        }

        public object SubmitPinVerification(string args)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            ATTTransactionPin objATT = JsonUtility.DeSerialize(args, typeof(ATTTransactionPin)) as ATTTransactionPin;
            BLLUser bllObj = new BLLUser();
            response = bllObj.SubmitPinVerification(objATT);
            return JsonUtility.Serialize(response);
        }

        public object ChangeTransactionPin(string args)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            ATTTransactionPin objATT = JsonUtility.DeSerialize(args, typeof(ATTTransactionPin)) as ATTTransactionPin;
            BLLUser bllObj = new BLLUser();
            response = bllObj.ChangeTransactionPin(objATT);
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
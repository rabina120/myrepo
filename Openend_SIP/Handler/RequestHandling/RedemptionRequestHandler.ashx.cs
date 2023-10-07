using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SI.Utility;
using SI.RequestHandling.BLL;
using SI.RequestHandling.ATT;
using SI.Security.ATT;
using SI.Security.BLL;

namespace Openend_SIP.Handler.RequestHandling
{
    /// <summary>
    /// Summary description for RedemptionRequestHandler
    /// </summary>
    public class RedemptionRequestHandler : BaseHandler
    {

        public object GetAllocatedData(int SHHOLDERNO, string scheme_code, string Action, string ccode, int? REQUEST_NO, string Flag)
        {
            JsonResponse response = new JsonResponse();
            BLLRedemptionRequest objbll = new BLLRedemptionRequest();
            response = objbll.GetAllocatedData(SHHOLDERNO, scheme_code, Action, ccode, REQUEST_NO, Flag);

            return JsonUtility.Serialize(response);
        }

        public object GetClientDetial(string BOID, string scheme_code, string l_company_id)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            BLLRedemptionRequest objbll = new BLLRedemptionRequest();
            response = objbll.GetClientDetial(BOID, scheme_code, l_company_id);

            return JsonUtility.Serialize(response);
        }
        public object SaveRedemptionEntry(string args, string type, string Email, string OTP, string password, string username, string args2)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();

            JsonResponse CheckUnitResponse = new JsonResponse();
            BLLRedemptionRequest bllredem1 = new BLLRedemptionRequest();
            ATTShareTransaction objunit = JsonUtility.DeSerialize(args, typeof(ATTShareTransaction)) as ATTShareTransaction;
            CheckUnitResponse = bllredem1.CHECKUNITTOBEREDEM(objunit.Scheme_code, objunit.APPLY_UNIT, objunit.BOID, objunit.l_company_id, objunit.ShHolderNo ?? 0,objunit.APPLY_DT);

            if (CheckUnitResponse.IsSucess == false)
            {
                response.IsSucess = false;
                response.Message = CheckUnitResponse.Message;
                return JsonUtility.Serialize(response);
            }

            JsonResponse otpvalidate = new JsonResponse();
            ATTShareTransaction objATTotp = JsonUtility.DeSerialize(args, typeof(ATTShareTransaction)) as ATTShareTransaction;
            BLLUser bllObjotp = new BLLUser();
            otpvalidate = bllObjotp.CHECKOTP(Email, OTP);
            if (otpvalidate.IsSucess == false)
            {
                response.IsSucess = false;
                response.Message = "You have entered wrong OTP or the OTP time has expired. PLease Re-Generate the OTP and verify the OTP";
                return JsonUtility.Serialize(response);
            }
       
            JsonResponse otpresponse = new JsonResponse();
            ATTShareTransaction objATT = JsonUtility.DeSerialize(args, typeof(ATTShareTransaction)) as ATTShareTransaction;
            BLLUser bllObj = new BLLUser();
            otpresponse = bllObj.VALIDATEOTP(Email, OTP);
            if (otpresponse.IsSucess == false) 
            {
                response.IsSucess = false;
                response.Message = "You have entered wrong OTP or the OTP time has expired. PLease Re-Generate the OTP and verify the OTP";
                return JsonUtility.Serialize(response);
            }
            

            JsonResponse response1 = new JsonResponse();
            BLLRedemptionRequest bllredem = new BLLRedemptionRequest();
            ATTTransactionPin objpin = JsonUtility.DeSerialize(args2, typeof(ATTTransactionPin)) as ATTTransactionPin;
            response1 = bllredem.VerifyingSecurity(username, password, objpin);

            if (response1.Message == "Success")
            {
                if (objATT.APPLY_UNIT >= 100)
                {
                    response = bllredem.CheckRedemptionDetail(objATT, type);
                    return JsonUtility.Serialize(response);
                }
                else
                {
                    response.IsSucess = false;
                    response.Message = "Please Enter Apply Unit Greater than equal to 100";
                    return JsonUtility.Serialize(response);
                }
            }
            else
            {
                response1.IsSucess = false;
              //  response.Message = "You have entered wrong OTP or the OTP time has expired. PLease Re-Generate the OTP and verify the OTP";
                return JsonUtility.Serialize(response1);
            }

           

        }
       
        public object GetRedemData(string scheme_code, string ccode, int REQUEST_NO, string Action, string l_company_id)
        {
              ValidateToken("A", null);
            JsonResponse response = new JsonResponse();

            BLLRedemptionRequest bllObj = new BLLRedemptionRequest();
            response = bllObj.GetRedemData(scheme_code, ccode, REQUEST_NO, Action, l_company_id);
            return JsonUtility.Serialize(response);
        }

        public object CHECKUNITTOBEREDEM(string scheme_code, float APPLIED_UNIT, string BOID, string L_COMPANY_ID, int SHHOLDERNO, string APPLY_DT)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            BLLRedemptionRequest bllObj = new BLLRedemptionRequest();
            response = bllObj.CHECKUNITTOBEREDEM(scheme_code, APPLIED_UNIT, BOID, L_COMPANY_ID, SHHOLDERNO, APPLY_DT);
            return JsonUtility.Serialize(response);
        }

        public object VerifyingSecurity(string username, string password, string args) {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            ATTTransactionPin objATT = JsonUtility.DeSerialize(args, typeof(ATTTransactionPin)) as ATTTransactionPin;
            BLLRedemptionRequest bllObj = new BLLRedemptionRequest();
            response = bllObj.VerifyingSecurity(username, password, objATT);
            return JsonUtility.Serialize(response);
        }

        public object VerifyingTransaction(string username, string args)
        {
              ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            ATTTransactionPin objATT = JsonUtility.DeSerialize(args, typeof(ATTTransactionPin)) as ATTTransactionPin;
            BLLRedemptionRequest bllObj = new BLLRedemptionRequest();
            response = bllObj.VerifyingTransaction(username, objATT);
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
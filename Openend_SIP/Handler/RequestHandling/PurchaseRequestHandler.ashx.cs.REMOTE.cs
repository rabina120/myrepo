using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SI.Utility;
using SI.RequestHandling.BLL;
using SI.RequestHandling.ATT;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SI.Security.BLL;


namespace Mutual_Fund.Handler.RequestHandling
{
    /// <summary>
    /// Summary description for PurchaseRequestHandler
    /// </summary>
    public class PurchaseRequestHandler : BaseHandler
    {
       
        public object GetBank()
        {
            JsonResponse response = new JsonResponse();

            BLLBank bllObj = new BLLBank();
            response = bllObj.GetBank();
            return JsonUtility.Serialize(response);
        }
        public object GetBranch(string bankcode)
        {
            JsonResponse response = new JsonResponse();

            BLLBank bllObj = new BLLBank();
            response = bllObj.GetBranch(bankcode);
            return JsonUtility.Serialize(response);
        }

        public object GetNAV(string Scheme_code, string ApplyDate)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            BLLPurchaseRequest objbll = new BLLPurchaseRequest();
            response = objbll.GetNAV(Scheme_code, ApplyDate);
            return JsonUtility.Serialize(response);
        }
        public object GetChargeType(string Scheme_code)
        {
            JsonResponse response = new JsonResponse();
            BLLPurchaseRequest objbll = new BLLPurchaseRequest();
            response = objbll.GetChargeType(Scheme_code);
            return JsonUtility.Serialize(response);
        }
        public object GetServiceChargeAmt(string Scheme_code, string ApplyDate, string NAV_Date, string SCharge_Code)
        {
            JsonResponse response = new JsonResponse();
            BLLPurchaseRequest objbll = new BLLPurchaseRequest();
            response = objbll.GetServiceChargeAmt(Scheme_code, ApplyDate, NAV_Date, SCharge_Code);
            return JsonUtility.Serialize(response);
        }


        public object SavePurchaseEntry(string args)
        {
            ValidateToken("A", null);
            JsonResponse otpresponse = new JsonResponse();
            JsonResponse otpContactresponse = new JsonResponse();
            ATTShareTransaction objATTShare = JsonUtility.DeSerialize(args, typeof(ATTShareTransaction)) as ATTShareTransaction;
            BLLUser blluser = new BLLUser();
            BLLSMS bllsms = new BLLSMS();
            if (objATTShare.GatewayCode == "001" && objATTShare.APPSTATUS=="INITIAL")
            {
                otpresponse = blluser.VALIDATEOTP(objATTShare.Email_ID.ToString(), objATTShare.OTP);
               // otpContactresponse = bllsms.VALIDATECONTACTOTP(objATTShare.P_Tel_No.ToString(), objATTShare.OTPContact);
                if (otpresponse.IsSucess == true)
                {
                    JsonResponse response = new JsonResponse();
                    BLLPurchaseRequest bllObj = new BLLPurchaseRequest();
                    response = bllObj.SavePurchaseEntry(objATTShare);
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
                JsonResponse response = new JsonResponse();
                BLLPurchaseRequest bllObj = new BLLPurchaseRequest();
                response = bllObj.SavePurchaseEntry(objATTShare);
                return JsonUtility.Serialize(response);
            }
           
        }
        public object UpdateToken(string Token, string TXNID, string Action)
        {
            ValidateToken("A", null);
            
            JsonResponse response = new JsonResponse();
            BLLPurchaseRequest bllObj = new BLLPurchaseRequest();
            response = bllObj.UpdateToken(Token, TXNID, Action);
            return JsonUtility.Serialize(response);

        }
        public object ValidateAmount(string TXNID)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            BLLPurchaseRequest bllObj = new BLLPurchaseRequest();
            response = bllObj.ValidateAmount(TXNID);
            return JsonUtility.Serialize(response);
        }
        public object GetData(string scheme_code, string ccode, int REQUEST_NO, string Action, string l_company_id)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            BLLPurchaseRequest bllObj = new BLLPurchaseRequest();
            response = bllObj.GetData(scheme_code, ccode, REQUEST_NO, Action, l_company_id);
            return JsonUtility.Serialize(response);
        }

        public object GetHolderUnitRpt(string scheme_code, string ccode, string Bo_Account_No, string l_company_id, DateTime startdate, DateTime enddate)
        {
            JsonResponse response = new JsonResponse();

            BLLPurchaseRequest bllObj = new BLLPurchaseRequest();
            response = bllObj.GetHolderUnitRpt(scheme_code, ccode, Bo_Account_No, l_company_id, startdate, enddate);
            return JsonUtility.Serialize(response);
        }
        //public object GetUnCheckChequeDetail(string scheme_code, string ccode)
        //{
        //    JsonResponse response = new JsonResponse();

        //    BLLPurchaseRequest bllObj = new BLLPurchaseRequest();
        //    response = bllObj.GetUnCheckChequeDetail(scheme_code, ccode);
        //    return JsonUtility.Serialize(response);
        //}
        //public object GetRequestNo(string scheme_code, string ccode)
        //{
        //    JsonResponse response = new JsonResponse();

        //    BLLPurchaseRequest bllObj = new BLLPurchaseRequest();
        //    response = bllObj.GetRequestNo(scheme_code, ccode);
        //    return JsonUtility.Serialize(response);
        //}
        //public object SearchHoldersByName(string ASearch, string FSearch, string GSearch, string scheme_code)
        //{
        //    JsonResponse response = new JsonResponse();

        //    BLLSHolder bllObj = new BLLSHolder();
        //    response = bllObj.SearchHoldersByName(ASearch, FSearch, GSearch, scheme_code);
        //    return JsonUtility.Serialize(response);
        //}
        //public object DeletePurchaseEntry(string username,string shholderno, string scheme_code, string ccode, int REQUEST_NO, string l_company_id)
        //{
        //    JsonResponse response = new JsonResponse();
        //    BLLPurchaseRequest bllObj = new BLLPurchaseRequest();
        //    response = bllObj.DeletePurchaseEntry(username, shholderno, scheme_code, ccode, REQUEST_NO, l_company_id);
        //    return JsonUtility.Serialize(response);
        //}
        //public object SearchHolders(string ASearch, string FSearch, string GSearch, string scheme_code, string type, string APPSTATUS)
        //{
        //    JsonResponse response = new JsonResponse();

        //    BLLSHolder bllObj = new BLLSHolder();
        //    response = bllObj.SearchHolders(ASearch, FSearch, GSearch, scheme_code, type, APPSTATUS);
        //    return JsonUtility.Serialize(response);
        //}
        //public object UpdateChequeStatus(string args)
        //{
        //    JsonResponse response = new JsonResponse();
        //    List<ATTShareTransaction> objATT = JsonUtility.DeSerialize(args, typeof(List<ATTShareTransaction>)) as List<ATTShareTransaction>;
        //    BLLPurchaseRequest bllObj = new BLLPurchaseRequest();
        //    response = bllObj.UpdateChequeStatus(objATT);
        //    return JsonUtility.Serialize(response);

        //}
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public object GetDPInfo()
        {
            JsonResponse response = new JsonResponse();

            BLLPurchaseRequest bllObj = new BLLPurchaseRequest();
            response = bllObj.GetDPInfo();
            return JsonUtility.Serialize(response);
        }

        public object GetDPInfo2()
        {
            JsonResponse response = new JsonResponse();

            BLLPurchaseRequest bllObj = new BLLPurchaseRequest();
            response = bllObj.GetDPInfo2();
            return JsonUtility.Serialize(response);
        }
       
        public object GetFilePathByStatusPayment()
        {
            JsonResponse response = new JsonResponse();
            BLLPaymentTypeList bllObj = new BLLPaymentTypeList();
            response = bllObj.GetFilePathByStatusPayment();
            return JsonUtility.Serialize(response);
        }

        public object ValidateNAV(string APPLY_DT, string Amount, string APPLY_UNIT)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            try
            {
                BLLPurchaseRequest bllObj = new BLLPurchaseRequest();
                response = bllObj.ValidateNAV(APPLY_DT, Amount, APPLY_UNIT);
                return JsonUtility.Serialize(response);
            }
            catch
            {
                response.IsSucess = false;
            }
            return JsonUtility.Serialize(response);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SI.Utility;
using SI.RequestHandling.BLL;
using SI.RequestHandling.ATT;

namespace Mutual_Fund.Handler.RequestHandling
{
    /// <summary>
    /// Summary description for ShHolderHandler
    /// </summary>
    public class ShHolderHandler : BaseHandler
    {

        public object GetSHolders(string scheme_code, Int64 Bo_Account_No, string ccode, string l_company_id, string shholder)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();

            BLLSHolder bllObj = new BLLSHolder();
            response = bllObj.GetSHolders(scheme_code, Bo_Account_No, ccode, l_company_id, shholder);
            return JsonUtility.Serialize(response);
        }

        public object GetSHolderForDREP(string scheme_code, Int64 Bo_Account_No, string ccode, string l_company_id)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            BLLSHolder bllObj = new BLLSHolder();
            response = bllObj.GetSHolderForDREP(scheme_code, Bo_Account_No, ccode, l_company_id);
            return JsonUtility.Serialize(response);
        }

        public object CheckSHolders(string scheme_code, string Bo_Account_No,  string l_company_id)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();

            BLLSHolder bllObj = new BLLSHolder();
            response = bllObj.CheckSHolders(scheme_code, Bo_Account_No, l_company_id);
            return JsonUtility.Serialize(response);
        }


        public object GetSHoldersforSignUp(string scheme_code, string Bo_Account_No, string ccode, string l_company_id, int shholder)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            BLLSHolder bllObj = new BLLSHolder();
            response = bllObj.GetSHoldersforSignUp(scheme_code, Bo_Account_No, ccode, l_company_id, shholder);
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
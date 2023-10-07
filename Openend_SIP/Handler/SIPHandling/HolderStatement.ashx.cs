using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SI.Utility;
using SI.SIPHandling.BLL;

namespace Openend_SIP.Handler.SIPHandling
{
    /// <summary>
    /// Summary description for HolderStatement
    /// </summary>
    public class HolderStatement : BaseHandler 
    {

        public object GetHolderStatement(string scheme_code, string Bo_Account_No, string ccode, string l_company_id, DateTime startdate, DateTime enddate)
        {
            JsonResponse response = new JsonResponse();
            BLLHolderStatementReport objbll = new BLLHolderStatementReport();
            response = objbll.GetHolderStatement(scheme_code, ccode, startdate, enddate, Bo_Account_No, l_company_id);
            return JsonUtility.Serialize(response);
        }
    }

}
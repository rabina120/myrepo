using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.SIPHandling.DLL;

namespace SI.SIPHandling.BLL
{
    public class BLLHolderStatementReport
    {
        public JsonResponse GetHolderStatement(string scheme_code, string ccode, DateTime startdate, DateTime enddate, string boid, string l_company_id)
        {

            JsonResponse response = new JsonResponse();
            try
            {

                DLLHolderStatementReport objDll = new DLLHolderStatementReport();
                response.ResponseData = objDll.GetHolderStatement(scheme_code, ccode, startdate, enddate, boid, l_company_id);
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

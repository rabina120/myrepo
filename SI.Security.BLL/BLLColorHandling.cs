using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.Security.DLL;

namespace SI.Security.BLL
{
    public class BLLColorHandling
    {

        public JsonResponse ColorCode()
        {
            JsonResponse response = new JsonResponse();

            try
            {
                DLLColorHandling objDLLUser = new DLLColorHandling();
                response.ResponseData = objDLLUser.ColorCode();
                response.IsSucess = true;


            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;
            }


            return response;
        }

        public JsonResponse ReportImage(string company_id)
        {
            JsonResponse response = new JsonResponse();

            try
            {
                DLLColorHandling objDLLUser = new DLLColorHandling();
                response.ResponseData = objDLLUser.ReportImage(company_id);
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

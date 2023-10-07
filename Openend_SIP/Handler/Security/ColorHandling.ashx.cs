using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SI.Utility;
using SI.Security.BLL;

namespace Openend_SIP.Handler.Security
{
    /// <summary>
    /// Summary description for ColorHandling
    /// </summary>
    public class ColorHandling : BaseHandler
    {

        public object ColorCode()
        {
            JsonResponse response = new JsonResponse();

            BLLColorHandling bllObj = new BLLColorHandling();
            response = bllObj.ColorCode();
            return JsonUtility.Serialize(response);

        }

        public object ReportImage(string company_id)
        {
            JsonResponse response = new JsonResponse();
            BLLColorHandling bllObj = new BLLColorHandling();
            response = bllObj.ReportImage(company_id);
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
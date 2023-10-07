using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SI.Utility;
using System.Text;
using SI.RequestHandling.ATT;
using SI.RequestHandling.BLL;
using SI.Security.BLL;

namespace Openend_SIP.Handler.Collection
{
    /// <summary>
    /// Summary description for DateHandler
    /// </summary>
    public class DateHandler : BaseHandler
    {

        public object GetCurrentDate()
        {
            JsonResponse response = new JsonResponse();

            BLLLogin bllObj = new BLLLogin();
            response = bllObj.GetCurrentDate();
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
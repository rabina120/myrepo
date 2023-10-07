using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SI.Utility;
using SI.Security.BLL;
using SI.Security.ATT;

namespace Mutual_Fund.Handler.Security
{
    /// <summary>
    /// Summary description for MenuHandler
    /// </summary>
    public class MenuHandler : BaseHandler
    {

        public object GetMenus()
        {
            JsonResponse response = new JsonResponse();
            BLLMenu objbll = new BLLMenu();
            response = objbll.GetMenus();
            return JsonUtility.Serialize(response);
        }
        public object GetWebMenus()
        {
            JsonResponse response = new JsonResponse();
            BLLMenu objbll = new BLLMenu();
            response = objbll.GetWebMenus();
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
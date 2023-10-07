using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.Security.DLL;

namespace SI.Security.BLL
{
    public  class BLLPageAccess
    {
        public JsonResponse CheckOnlineAccessPage(String urlPath)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLPageAccess objDll = new DLLPageAccess();
                response = objDll.CheckOnlineAccessPage(urlPath);

            }
            catch (Exception ex)
            {
                response.IsSucess = false;
            }
            return response;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.Security.DLL;

namespace SI.Security.BLL
{
    public  class BLLMenu
    {
        public JsonResponse GetMenus()
        {
            JsonResponse response = new JsonResponse();
            try
            {
                DLLMenu objDll = new DLLMenu();
                response.ResponseData = objDll.GetMenus();
                response.IsSucess = true;


            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }
        public JsonResponse GetWebMenus()
        {
            JsonResponse response = new JsonResponse();
            try
            {
                DLLMenu objDll = new DLLMenu();
                response.ResponseData = objDll.GetWebMenus();
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

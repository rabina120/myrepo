using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.RequestHandling.DLL;
using SI.RequestHandling.ATT;

namespace SI.RequestHandling.BLL
{
    public class BllBoidTransfer
    {
        public JsonResponse BoidTransfer(ATTBoidTransfer objATT)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLBoidTransfer objDll = new DLLBoidTransfer();
                response.ResponseData = objDll.BoidTransfer(objATT);
                response.IsSucess = true;
                if (objATT.Action == "A")
                {
                    response.Message = "Record Added Successfully !!!";
                    var value = string.Format("Boid updated with transfer id {0}", response.ResponseData);
                    SaveEventLog objEvent = new SaveEventLog();
                    objEvent.SaveEvent(objATT.entry_by, "BOID UPDATE", value);
                }
                else
                {
                    response.Message = "Record Updated Successfully !!!";
                    var value = string.Format("Boid update edited with transfer id {0}", response.ResponseData);
                    SaveEventLog objEvent = new SaveEventLog();
                    objEvent.SaveEvent(objATT.entry_by, "BOID UPDATE", value);
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }

        public JsonResponse GetUsersBoid(string scheme_code, string ccode, int transfer_id, string app_status)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLBoidTransfer objDll = new DLLBoidTransfer();
                response.ResponseData = objDll.GetUsersBoid(scheme_code, ccode, transfer_id, app_status);
                response.IsSucess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSucess = false;

            }
            return response;

        }

        public JsonResponse SearchUsersBoid(string ASearch, string FSearch, string GSearch, string scheme_code, string ccode, string app_status)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLBoidTransfer objDll = new DLLBoidTransfer();
                response.ResponseData = objDll.SearchUsersBoid(ASearch, FSearch, GSearch, scheme_code,ccode,app_status);
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

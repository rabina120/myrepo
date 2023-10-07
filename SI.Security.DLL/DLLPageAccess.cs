using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using System.Data;
using System.Data.SqlClient;

namespace SI.Security.DLL
{
   public class DLLPageAccess
   {
       public JsonResponse CheckOnlineAccessPage(string urlPath)
       {
           JsonResponse jsonResponse = new JsonResponse();
           DataSet ds = new DataSet();
           SqlParameter[] param = new SqlParameter[1];
           param[0] = new SqlParameter("@UrlPath", urlPath);
           ds = DAO.gettable("CHECK_Online_ACCESS_PAGE", param);
           if (ds.Tables[0].Rows.Count > 0)
           {
               foreach (DataRow dr in ds.Tables[0].Rows)
               {
                   jsonResponse.IsSucess = Convert.ToBoolean(dr["IsSucess"]);
               }
           }
           else
           {
               jsonResponse.IsSucess = false;
           }

           return jsonResponse;

       }
   }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SI.Utility;
using System.Data.SqlClient;

namespace SI.Common.DLL
{
  public  class DLLCommon
    {
      public string GetDataByTXNID(string GatewayCode, string TXNID)
      {
       
          string data="";
          DataSet ds = new DataSet();
          SqlParameter[] param = new SqlParameter[02];
          param[0] = new SqlParameter("@GatewayCode", GatewayCode);
          param[1] = new SqlParameter("@TXNID", TXNID);
          ds = DAO.gettable("GetDataByTXNID", param);
          if (ds.Tables[0].Rows.Count > 0)
          {
              foreach (DataRow dr in ds.Tables[0].Rows)
              {
                  string AMT = dr["AMT"].ToString();
                  string REGNO =dr["REGNO"].ToString();
                  data = AMT + " " + REGNO;
              }

          }
          return data;
      }
    }
}

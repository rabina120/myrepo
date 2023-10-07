using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.RequestHandling.ATT;
using System.Data;

namespace SI.RequestHandling.DLL
{
  public  class DLLPaymentTypeList
    {

      public List<ATTPaymentTypeList> GetFilePathByStatusPayment()
      {
          List<ATTPaymentTypeList> lstPaymentMode = new List<ATTPaymentTypeList>();

          DataSet ds = new DataSet();
          ds = DAO.gettable("GetFilePathByStatusPayment", null);

          if (ds.Tables[0].Rows.Count > 0)
          {
              foreach (DataRow dr in ds.Tables[0].Rows)
              {
                  ATTPaymentTypeList objATT = new ATTPaymentTypeList();
                  objATT.PaymentCode = dr["PaymentCode"].ToString();
                  objATT.PaymentMode = dr["PaymentMode"].ToString();
                  objATT.PaymentStatus = dr["Status"].ToString();
                  objATT.PaymentFileName = dr["FileName"].ToString();
                  lstPaymentMode.Add(objATT);
              }

          }
          return lstPaymentMode;
      }
    }
}

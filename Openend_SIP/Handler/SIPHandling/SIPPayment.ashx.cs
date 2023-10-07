using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SI.Utility;
using SI.SIPHandling.BLL;
using SI.SIPHandling.ATT;
using System.Data.SqlClient;

namespace Openend_SIP.Handler.SIPHandling
{
    /// <summary>
    /// Summary description for SIPPayment
    /// </summary>
    public class SIPPayment : BaseHandler
    {

        public object GetActionDate(Int64 BOID)
        {
            
            JsonResponse response = new JsonResponse();

            BLLSIPPayment bllObj = new BLLSIPPayment();
            response = bllObj.GetActionDate(BOID);
            return JsonUtility.Serialize(response);
        }
        

        public object InsertSipPayment(string args)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();

            List<ATTSIP_Registration> objATT = JsonUtility.DeSerialize(args, typeof(List<ATTSIP_Registration>)) as List<ATTSIP_Registration>;
            BLLSIPPayment bllObj = new BLLSIPPayment();
            response = bllObj.ValidateInterval(objATT);
            if (response.IsSucess == true)
            {
                BLLSIPPayment bllsip = new BLLSIPPayment();
                response = bllsip.InsertSipPayment(objATT);
            }
            else {
                response.IsSucess = false;
                response.Message = "Record Mismatched";
            }
            return JsonUtility.Serialize(response);

        }

        public object ValidateInterval(string args)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            List<ATTSIP_Registration> objATT = JsonUtility.DeSerialize(args, typeof(List<ATTSIP_Registration>)) as List<ATTSIP_Registration>;
            BLLSIPPayment bllObj = new BLLSIPPayment();
            response = bllObj.ValidateInterval(objATT);
            return JsonUtility.Serialize(response);

        }

        public object GetTXNData(string TXNID)
        {
            JsonResponse response = new JsonResponse();

            BLLSIPPayment bllObj = new BLLSIPPayment();
            response = bllObj.GetTXNData(TXNID);
            return JsonUtility.Serialize(response);
        }
        public object SubmitSipPayment(string args)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            ATTSIP_Registration objATT = JsonUtility.DeSerialize(args, typeof(ATTSIP_Registration)) as ATTSIP_Registration;

            BLLSIPPayment bllObj = new BLLSIPPayment();
            response = bllObj.SubmitSipPayment(objATT);

            return JsonUtility.Serialize(response);

        }

        public object IntervalStatus(string SIP_Reg_No, string Interval_Seq_No, string ShHolderNo, string scheme_code)
        {
            JsonResponse response = new JsonResponse();
            SqlConnection conn = DAO.getConnection();
             SqlTransaction transaction;

            using (conn)
            {
                transaction = conn.BeginTransaction();
                try
                {
                    SqlParameter[] param = new SqlParameter[4];
                    param[0] = new SqlParameter("@SIP_Reg_No", SIP_Reg_No);
                    param[1] = new SqlParameter("@Interval_Seq_No",Interval_Seq_No);
                    param[2] = new SqlParameter("@ShHolderNo", ShHolderNo);
                    param[3] = new SqlParameter("@scheme_code", scheme_code);
                   
                    DAO.executeTranProcedure("UpdateIntervalStatus", param, transaction, conn);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error" + ex.Message);
                }

                transaction.Commit();
            }

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
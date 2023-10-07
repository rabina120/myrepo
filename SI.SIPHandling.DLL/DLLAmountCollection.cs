using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.SIPHandling.ATT;
using System.Data;
using System.Data.SqlClient;

namespace SI.SIPHandling.DLL
{
   public class DLLAmountCollection
    {
       public List<ATTDp> GetDPDetail()
       {
           List<ATTDp> lstDp = new List<ATTDp>();
           var msg = "ssd";
           DataSet ds = new DataSet();
           ds = DAO.gettable("GetDpInfo", null);

           if (ds.Tables[0].Rows.Count > 0)
           {
               foreach (DataRow dr in ds.Tables[0].Rows)
               {
                   ATTDp objATT = new ATTDp();
                   objATT.DPCode = dr["DP_CODE"].ToString();
                   objATT.DP_Id_Cds = dr["DP_Id_Cds"].ToString();
                   objATT.DPName = dr["DP_Id_Cds"].ToString() + ' ' + dr["DP_NAME"].ToString();
                   lstDp.Add(objATT);
               }

           }
           return lstDp;

       }
       public List<ATTAmtCollection> GetCollectedAmtDet(string scheme_code, string ccode)
       {
           List<ATTAmtCollection> lstamtdel = new List<ATTAmtCollection>();
           var msg = "ssd";
           DataSet ds = new DataSet();
           SqlParameter[] param = new SqlParameter[2];
           param[0] = new SqlParameter("@scheme_code", scheme_code != null ? scheme_code : null);
           param[1] = new SqlParameter("@ccode", ccode != null ? ccode : null);
           ds = DAO.gettable("GetCollectedAmtDet", param);

           if (ds.Tables[0].Rows.Count > 0)
           {
               foreach (DataRow dr in ds.Tables[0].Rows)
               {
                   ATTAmtCollection objATT = new ATTAmtCollection();
                   objATT.ShHolderNo = string.IsNullOrEmpty(dr["ShHolderNo"].ToString()) ? (int?)null : int.Parse(dr["ShHolderNo"].ToString());
                   objATT.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? "" : dr["Name"].ToString();
                   objATT.BOID = string.IsNullOrEmpty(dr["BOID"].ToString()) ? "" : dr["BOID"].ToString();
                   objATT.Amount = float.Parse(dr["Amount"].ToString());
                   objATT.trans_no = dr["trans_no"].ToString();
                   objATT.remarks = string.IsNullOrEmpty(dr["remarks"].ToString()) ? "" : dr["remarks"].ToString();
                   objATT.SIP_Reg_No = string.IsNullOrEmpty(dr["SIP_Reg_No"].ToString()) ? "" : dr["SIP_Reg_No"].ToString();
                   lstamtdel.Add(objATT);
               }

           }
           return lstamtdel;

       }
       public List<ATTAmtCollection> GetSHolders(string scheme_code, Int64 Bo_Account_No, string ccode, int? SHHOLDERNO)
       {
           List<ATTAmtCollection> lstSHolders = new List<ATTAmtCollection>();
           string spName = "";
           DataSet ds = new DataSet();
           SqlParameter[] param = new SqlParameter[4];
           try
           {
               param[0] = new SqlParameter("@Bo_Account_No", Bo_Account_No);
               param[1] = new SqlParameter("@scheme_code", scheme_code != null ? scheme_code : null);
               param[2] = new SqlParameter("@ccode", ccode != null ? ccode : null);
               param[3] = new SqlParameter("@SHHOLDERNO", SHHOLDERNO != null ? SHHOLDERNO : null);


               spName = "GetSHolders";
               ds = DAO.gettable(spName, param);

               if (ds.Tables[0].Rows.Count > 0)
               {
                   foreach (DataRow dr in ds.Tables[0].Rows)
                   {
                       ATTAmtCollection objATT = new ATTAmtCollection();
                       objATT.Name = dr["Name"].ToString() != "" ? dr["Name"].ToString() : "";
                       objATT.SIP_Reg_No = dr["SIP_Reg_No"].ToString() != "" ? dr["SIP_Reg_No"].ToString() : "";
                  //     objATT.tran_dt = dr["tran_dt"].ToString() != "" ? dr["tran_dt"].ToString() : "";
                       lstSHolders.Add(objATT);

                   }
               }
               return lstSHolders;

           }

           catch (Exception ex)
           {

               throw ex;
           }
       }
         
        public List<ATTUnitSIPRequest> GetFundCollectionDetail(string scheme_code, string ccode, string l_company_id,string Action)
        {
            List<ATTUnitSIPRequest> lstholder = new List<ATTUnitSIPRequest>();
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@scheme_code", scheme_code);
            param[1] = new SqlParameter("@ccode", ccode);
            param[2] = new SqlParameter("@Action", Action);
            param[3] = new SqlParameter("@l_company_id", l_company_id);
            ds = DAO.gettable("GetFundCollectionDetail", param);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ATTUnitSIPRequest objATT = new ATTUnitSIPRequest();
                    objATT.Sip_amt = float.Parse(dr["SIP_Amt"].ToString());
                    objATT.Name = dr["Name"].ToString();
                    objATT.boid = dr["BOID"].ToString();
                    objATT.SIP_Reg_No = dr["SIP_Reg_No"].ToString();
                    objATT.Action_Date = Convert.ToDateTime(dr["Action_Date"]).ToString("yyyy-MM-dd");
                    objATT.DP_Charge = float.Parse(dr["DP_Charge"].ToString());
                    objATT.SEBON_Fee = float.Parse(dr["SEBON_Fee"].ToString());
                    objATT.PaymentMode = (dr["PaymentMode"].ToString());
                    //var extendeddays = Convert.ToDateTime(dr["ExtendedDay"]).ToString("dd/MM/yyyy");
                    objATT.SIP_Due_Day =  dr["dueday"].ToString();
                    objATT.BalanceAmt = float.Parse(dr["bal"].ToString());
                    objATT.PType=   LoadPaymentMode();
                    lstholder.Add(objATT);

                }

            }
            return lstholder;
        }

        public List<ATTPaymentMode> LoadPaymentMode()
        {
            List<ATTPaymentMode> lstpaymentmode = new List<ATTPaymentMode>();

            DataSet ds = new DataSet();
            ds = DAO.gettable("LoadPaymentMode", null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ATTPaymentMode objATT = new ATTPaymentMode();
                    objATT.PaymentCode = (dr["PaymentCode"].ToString());
                    objATT.PaymentMode = dr["PaymentMode"].ToString();
                    lstpaymentmode.Add(objATT);
                }

            }
            return lstpaymentmode;

        }
        public int? SaveAmtCollection(List<ATTAmtCollection> objATTShare)
       {

           string spName = "";
           string msg = "No Data To Save !!!";
           int? trans_no = 0;
           SqlTransaction transaction;

           msg = "Successfully Saved !!!";
           SqlConnection conn = DAO.getConnection();

           using (conn)
           {
               transaction = conn.BeginTransaction();
               //if (objATTShare.Action == "E") {
               //        spName = "EditCollectionDetail";
               //        trans_no = string.IsNullOrEmpty(objATTShare.trans_no.ToString()) ? (int?)null : int.Parse(objATTShare.trans_no.ToString());


               //    }
               //else if (objATTShare.Action == "D")
               //{
               //    spName = "DeleteCollectionDetail";
               //    trans_no = string.IsNullOrEmpty(objATTShare.trans_no.ToString()) ? (int?)null : int.Parse(objATTShare.trans_no.ToString());


               //}
               //else if (objATTShare.Action == "A")
               //    {

                       //if (objATTShare.trans_no != null)
                       //{
                       //    trans_no = string.IsNullOrEmpty(objATTShare.trans_no.ToString()) ? (int?)null : int.Parse(objATTShare.trans_no.ToString());
                       //}
                       //else
                       //{
                           #region To Get MAX ID

               foreach (var obj in objATTShare)
               {
                   SqlCommand cmdd = new SqlCommand();
                   cmdd.Connection = conn;
                   cmdd.Transaction = transaction;
                   cmdd.CommandText = "GetMaxtranNo";
                   cmdd.CommandType = CommandType.StoredProcedure;

                   SqlParameter para1 = new SqlParameter();
                   para1.ParameterName = "@trans_no";
                   para1.Value = trans_no;
                   para1.SqlDbType = SqlDbType.Int;
                   para1.Size = 100;
                   para1.Direction = ParameterDirection.InputOutput;
                   cmdd.Parameters.Add(para1);
                   cmdd.Parameters.AddWithValue("@scheme_code", obj.scheme_code);
                   cmdd.Parameters.AddWithValue("@ccode", obj.ccode);
                   cmdd.Parameters.AddWithValue("@SIP_Reg_No", obj.SIP_Reg_No);
                   cmdd.Parameters.AddWithValue("@l_company_id", obj.l_company_id);
                   cmdd.ExecuteNonQuery();

                   if (cmdd.Parameters["@trans_no"].Value.ToString() == "") { cmdd.Parameters["@trans_no"].Value = 0; }
                   trans_no = int.Parse(cmdd.Parameters["@trans_no"].Value.ToString()) + 1;

                           #endregion
                   //}
                   spName = "SaveCollectionDetail";
                   // }
                   try
                   {
                       SqlParameter[] param = new SqlParameter[13];
                       param[0] = new SqlParameter("@scheme_code", obj.scheme_code);
                       param[1] = new SqlParameter("@ccode", obj.ccode);
                       param[2] = new SqlParameter("@trans_no", trans_no);
                       param[3] = new SqlParameter("@SIP_Reg_No", obj.SIP_Reg_No);
                       param[4] = new SqlParameter("@ShHolderNo", obj.ShHolderNo);
                       param[5] = new SqlParameter("@Amount", obj.Amount);
                       param[6] = new SqlParameter("@tran_dt", obj.tran_dt);
                       param[7] = new SqlParameter("@dbcr", obj.dbcr);
                       param[8] = new SqlParameter("@entry_user", obj.entry_user);
                       param[9] = new SqlParameter("@entry_dt", obj.entry_dt);
                       param[10] = new SqlParameter("@remarks", obj.remarks);
                       param[11] = new SqlParameter("@l_company_id", obj.l_company_id);
                       param[12] = new SqlParameter("@PaymentCode", obj.PaymentCode);
                       DAO.executeTranProcedure(spName, param, transaction, conn);
                   }


                   catch (Exception ex)
                   {
                       transaction.Rollback();
                       throw new Exception("Error" + ex.Message);
                   }
               }
               transaction.Commit();
           }
           return trans_no;
       }
       public List<ATTAmtCollection> GetCollDetail(string scheme_code, string ccode, int trans_no, string Action)
       {
           List<ATTAmtCollection> lstcolldet = new List<ATTAmtCollection>();
           string spName = "";
           DataSet ds = new DataSet();
           SqlParameter[] param = new SqlParameter[4];
           try
           {

               param[0] = new SqlParameter("@scheme_code", scheme_code != null ? scheme_code : null);
               param[1] = new SqlParameter("@ccode", ccode != null ? ccode : null);
               param[2] = new SqlParameter("@trans_no", trans_no);
               param[3] = new SqlParameter("@Action", Action);
               spName = "GetCollDetail";
               ds = DAO.gettable(spName, param);

               if (ds.Tables[0].Rows.Count > 0)
               {
                   foreach (DataRow dr in ds.Tables[0].Rows)
                   {
                       ATTAmtCollection objATT = new ATTAmtCollection();

                       objATT.ShHolderNo = string.IsNullOrEmpty(dr["ShHolderNo"].ToString()) ? (int?)null : int.Parse(dr["ShHolderNo"].ToString());
                       objATT.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? "" : dr["Name"].ToString();
                       objATT.BOID = string.IsNullOrEmpty(dr["BOID"].ToString()) ? "" : dr["BOID"].ToString();
                       objATT.Amount = float.Parse(dr["Amount"].ToString());
                       objATT.remarks = string.IsNullOrEmpty(dr["remarks"].ToString()) ? "" : dr["remarks"].ToString();
                       objATT.SIP_Reg_No = string.IsNullOrEmpty(dr["SIP_Reg_No"].ToString()) ? "" : dr["SIP_Reg_No"].ToString();

                       // objATT.ShHolder = lstSHolders;
                       lstcolldet.Add(objATT);
                   }
               }
               return lstcolldet;
           }
           catch (Exception ex)
           {

               throw ex;
           }
       }

    }
}

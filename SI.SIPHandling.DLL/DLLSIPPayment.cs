using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SI.Utility;
using SI.SIPHandling.ATT;

namespace SI.SIPHandling.DLL
{
    public class DLLSIPPayment
    {
        public List<ATTSIP_Registration> GetActionDate(Int64 BOID)
        {
            List<ATTSIP_Registration> lstSHolders = new List<ATTSIP_Registration>();
           

            string spName = "";
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            try
            {
                param[0] = new SqlParameter("@BOID", BOID);


                spName = "GetActionDate";
                ds = DAO.gettable(spName, param);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTSIP_Registration objATT = new ATTSIP_Registration();
                        objATT.Action_Date = string.IsNullOrEmpty(dr["Action_Date"].ToString()) ? "" : Convert.ToDateTime(dr["Action_Date"]).ToString("yyyy-MM-dd");
                        objATT.Interval_Seq_No = string.IsNullOrEmpty(dr["Interval_Seq_No"].ToString()) ? "" : dr["Interval_Seq_No"].ToString();
                        objATT.l_company_id = string.IsNullOrEmpty(dr["l_company_id"].ToString()) ? "" : dr["l_company_id"].ToString();
                        objATT.scheme_code = string.IsNullOrEmpty(dr["scheme_code"].ToString()) ? "" : dr["scheme_code"].ToString();
                        objATT.ccode = string.IsNullOrEmpty(dr["ccode"].ToString()) ? "" : dr["ccode"].ToString();
                        objATT.ShHolderNo = string.IsNullOrEmpty(dr["ShHolderNo"].ToString()) ? (int?)null : int.Parse(dr["ShHolderNo"].ToString());
                        objATT.Sip_amt = float.Parse(dr["Sip_Amount"].ToString());
                        objATT.SIP_Reg_No = string.IsNullOrEmpty(dr["SIP_Reg_No"].ToString()) ? "" : (dr["SIP_Reg_No"].ToString());
                        objATT.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? "" : (dr["Name"].ToString());
                        objATT.Contact2 = string.IsNullOrEmpty(dr["ContactNo2"].ToString()) ? "" : (dr["ContactNo2"].ToString());
                        objATT.Contact1 = string.IsNullOrEmpty(dr["ContactNo1"].ToString()) ? "" : (dr["ContactNo1"].ToString());
                        objATT.BalanceAmt = string.IsNullOrEmpty(dr["BalanceAmt"].ToString()) ? "" : (dr["BalanceAmt"].ToString());
                        var Received_Amount = objATT.Sip_amt - float.Parse(objATT.BalanceAmt);
                        objATT.Received_Amount = Received_Amount.ToString();
                        var sip_due_day = (dr["dueday"].ToString()) ;
                        if (int.Parse(sip_due_day.ToString()) < 0)
                        {
                            objATT.SIP_DueDay = 0;
                        }
                        else
                        {
                            objATT.SIP_DueDay = int.Parse(dr["dueday"].ToString());
                        }
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

        public string InsertSipPayment(List<ATTSIP_Registration> objATT)
        {
            int? Interval_No = 0;
            int? trans_no = 0;
            string TXNID ="fsdf";
            string msg = "No Data To Save !!!";
            SqlTransaction transaction;
            msg = "Transaction Succesfull !!!";
            SqlConnection conn = DAO.getConnection();

            using (conn)
            {
                transaction = conn.BeginTransaction();

                try
                {
                    #region To Get MAX ID


                    SqlCommand cmdd2 = new SqlCommand();
                    cmdd2.Connection = conn;
                    cmdd2.Transaction = transaction;
                    cmdd2.CommandText = "GetTXNID";
                    cmdd2.CommandType = CommandType.StoredProcedure;

                    SqlParameter para2 = new SqlParameter();
                    para2.ParameterName = "@TXNID";
                    para2.Value = Interval_No;
                    para2.SqlDbType = SqlDbType.NVarChar;
                    para2.Size = 100;
                    para2.Direction = ParameterDirection.InputOutput;
                    cmdd2.Parameters.Add(para2);
                    cmdd2.Parameters.AddWithValue("@SIP_Reg_No", objATT[0].SIP_Reg_No);
                    cmdd2.Parameters.AddWithValue("@Integrationcode", objATT[0].Integrationcode);  
                    cmdd2.ExecuteNonQuery();

                    if (cmdd2.Parameters["@TXNID"].Value.ToString() == "") { cmdd2.Parameters["@TXNID"].Value = 0; }
                    TXNID = (cmdd2.Parameters["@TXNID"].Value.ToString());

                    #endregion
                    foreach (ATTSIP_Registration objATTFund in objATT)
                    {
                        //if (objATTFund.Interval_No != null)
                        //{
                        //    Interval_No = string.IsNullOrEmpty(objATTFund.Interval_No.ToString()) ? (int?)null : int.Parse(objATTFund.Interval_No.ToString());
                        //}
                        //else
                        //{
                        //    #region To Get MAX ID


                        //    SqlCommand cmdd = new SqlCommand();
                        //    cmdd.Connection = conn;
                        //    cmdd.Transaction = transaction;
                        //    cmdd.CommandText = "GetMaxIntervalNo";
                        //    cmdd.CommandType = CommandType.StoredProcedure;

                        //    SqlParameter para1 = new SqlParameter();
                        //    para1.ParameterName = "@Interval_No";
                        //    para1.Value = Interval_No;
                        //    para1.SqlDbType = SqlDbType.Int;
                        //    para1.Size = 100;
                        //    para1.Direction = ParameterDirection.InputOutput;
                        //    cmdd.Parameters.Add(para1);
                        //    cmdd.Parameters.AddWithValue("@SIP_Reg_No", objATTFund.SIP_Reg_No);
                        //    cmdd.ExecuteNonQuery();

                        //    if (cmdd.Parameters["@Interval_No"].Value.ToString() == "") { cmdd.Parameters["@Interval_No"].Value = 0; }
                        //    Interval_No = int.Parse(cmdd.Parameters["@Interval_No"].Value.ToString()) + 1;

                        //    #endregion
                          
                        //}
                        SqlCommand cmd = new SqlCommand("InsertSipPayment", conn, transaction);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@l_company_id", SqlDbType.VarChar, 3).Value = objATTFund.l_company_id;
                        cmd.Parameters.Add("@scheme_code", SqlDbType.VarChar, 3).Value = objATTFund.scheme_code;
                        cmd.Parameters.Add("@ccode", SqlDbType.VarChar, 4).Value = objATTFund.ccode;
                        cmd.Parameters.Add("@SIP_Reg_No", SqlDbType.VarChar, 50).Value = objATTFund.SIP_Reg_No;
                        cmd.Parameters.Add("@Interval_Seq_No", SqlDbType.Int).Value = objATTFund.Interval_Seq_No;
                        cmd.Parameters.Add("@ShHolderNo", SqlDbType.Int).Value = objATTFund.ShHolderNo;
                        cmd.Parameters.Add("@Sip_amt", SqlDbType.Float).Value = objATTFund.Sip_amt;
                        cmd.Parameters.Add("@ReceivedAmt", SqlDbType.Float).Value = objATTFund.Received_Amount;
                        cmd.Parameters.Add("@TXNID", SqlDbType.VarChar, 20).Value = TXNID.ToString();
                        cmd.Parameters.Add("@trans_no", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@entry_dt", SqlDbType.DateTime).Value = objATTFund.entry_dt;  
                        cmd.Parameters.Add("@Gatewaycode", SqlDbType.VarChar, 3).Value = objATTFund.GatewayCode;
                        cmd.Parameters.Add("@Integrationcode", SqlDbType.VarChar, 50).Value = objATTFund.Integrationcode;
                        cmd.ExecuteNonQuery();
                        trans_no = Convert.ToInt32(cmd.Parameters["@trans_no"].Value);
                        TXNID = TXNID.ToString();
                       
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error" + ex.Message);
                }

                transaction.Commit();
            }
            return trans_no + " " + TXNID; 


        }
        public JsonResponse ValidateInterval(List<ATTSIP_Registration> objATT)
        {
            JsonResponse response = new JsonResponse();
            int IsSucess;
            float Validate_Amount;
            float Sum=0;
            string msg = "No Data To Save !!!";
            SqlTransaction transaction;
            msg = "Transaction Succesfull !!!";
            SqlConnection conn = DAO.getConnection();

            using (conn)
            {
                transaction = conn.BeginTransaction();

                try
                {
                    foreach (ATTSIP_Registration objATTFund in objATT)
                    {

                        SqlCommand cmd = new SqlCommand("ValidateInterval", conn, transaction);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@scheme_code", SqlDbType.VarChar, 3).Value = objATTFund.scheme_code;
                        cmd.Parameters.Add("@ccode", SqlDbType.VarChar, 4).Value = objATTFund.ccode;
                        cmd.Parameters.Add("@SIP_Reg_No", SqlDbType.VarChar, 50).Value = objATTFund.SIP_Reg_No;
                        cmd.Parameters.Add("@Interval_Seq_No", SqlDbType.Int).Value = objATTFund.Interval_Seq_No;
                        cmd.Parameters.Add("@ShHolderNo", SqlDbType.Int).Value = objATTFund.ShHolderNo;
                        cmd.Parameters.Add("@Sip_amt", SqlDbType.Float).Value = objATTFund.Sip_amt;
                        cmd.Parameters.Add("@Validate_Amount", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@IsSucess", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        IsSucess = Int32.Parse(cmd.Parameters["@IsSucess"].Value.ToString());
                        Validate_Amount = float.Parse(cmd.Parameters["@Validate_Amount"].Value.ToString());
                        if (IsSucess == 1) {
                            Sum += Validate_Amount;
                        }
                        if (objATTFund.TotalAmount == Sum)
                        {
                            response.IsSucess = true;
                        }
                        else {
                            response.IsSucess = false;
                        }

                     }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error" + ex.Message);
                }

                transaction.Commit();
            }
            return response;


        }
        public string SubmitSipPayment(ATTSIP_Registration objATT)
        {
            string spName = "";
            string msg = "No Data To Save !!!";
            SqlTransaction transaction;

            msg = "Your Payment Has Been Submitted !!!";
            SqlConnection conn = DAO.getConnection();

            using (conn)
            {
                transaction = conn.BeginTransaction();
                try
                {
                    spName = "SubmitSipPayment";
                    SqlParameter[] param = new SqlParameter[6];
                    param[0] = new SqlParameter("@l_company_id", objATT.l_company_id);
                    param[1] = new SqlParameter("@scheme_code", objATT.scheme_code);
                    param[2] = new SqlParameter("@ccode", objATT.ccode);
                    param[3] = new SqlParameter("@SIP_Reg_No", objATT.SIP_Reg_No);
                    param[4] = new SqlParameter("@Interval_Seq_No", objATT.Interval_Seq_No);
                    param[5] = new SqlParameter("@trans_no", objATT.trans_no);

                    DAO.executeTranProcedure(spName, param, transaction, conn);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error" + ex.Message);
                }

                transaction.Commit();
            }
            return msg;


        }
        public List<ATTSIP_Registration> GetTXNData(string TXNID)
        {
            List<ATTSIP_Registration> lstSHolders = new List<ATTSIP_Registration>();


            string spName = "";
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            try
            {
                param[0] = new SqlParameter("@TXNID", TXNID);


                spName = "GetTXNData";
                ds = DAO.gettable(spName, param);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTSIP_Registration objATT = new ATTSIP_Registration();
                        objATT.boid = string.IsNullOrEmpty(dr["BOID"].ToString()) ? "" : (dr["BOID"]).ToString();
                        objATT.Action_Date = string.IsNullOrEmpty(dr["Action_Date"].ToString()) ? "" : Convert.ToDateTime(dr["Action_Date"]).ToString("yyyy-MM-dd");
                        objATT.Interval_Seq_No = string.IsNullOrEmpty(dr["Interval_Seq_No"].ToString()) ? "" : dr["Interval_Seq_No"].ToString();
                        objATT.l_company_id = string.IsNullOrEmpty(dr["l_company_id"].ToString()) ? "" : dr["l_company_id"].ToString();
                        objATT.scheme_code = string.IsNullOrEmpty(dr["scheme_code"].ToString()) ? "" : dr["scheme_code"].ToString();
                        objATT.ccode = string.IsNullOrEmpty(dr["ccode"].ToString()) ? "" : dr["ccode"].ToString();
                        objATT.ShHolderNo = string.IsNullOrEmpty(dr["ShHolderNo"].ToString()) ? (int?)null : int.Parse(dr["ShHolderNo"].ToString());
                        objATT.Sip_amt = float.Parse(dr["SIP_Amount"].ToString());
                        objATT.Received_Amount = (dr["Receive_Amount"].ToString());
                        objATT.ReceivedAmt = (dr["Receive_Amount"].ToString());
                        objATT.SIP_Reg_No = string.IsNullOrEmpty(dr["SIP_Reg_No"].ToString()) ? "" : (dr["SIP_Reg_No"].ToString());
                        objATT.trans_no = string.IsNullOrEmpty(dr["trans_no"].ToString()) ? "" : (dr["trans_no"].ToString());
                        objATT.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? "" : (dr["Name"].ToString());
                        //objATT.Interval_No = (dr["Interval_No"].ToString());
                        objATT.Contact1 = (dr["ContactNo1"].ToString());
                        objATT.Contact2 = (dr["ContactNo2"].ToString());
                        objATT.boid = (dr["BOID"].ToString());
                        var sip_due_day = (dr["dueday"].ToString());
                        if (int.Parse(sip_due_day.ToString()) < 0)
                        {
                            objATT.SIP_DueDay = 0;
                        }
                        else
                        {
                            objATT.SIP_DueDay = int.Parse(dr["dueday"].ToString());
                        }
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
    }
}

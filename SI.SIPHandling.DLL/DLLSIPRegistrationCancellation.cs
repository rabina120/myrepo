using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SI.Utility;
using SI.KYC.ATT;
using SI.SIPHandling.ATT;
using System.Data;

namespace SI.SIPHandling.DLL
{
    public class DLLSIPRegistrationCancellation
    {
        public object GetSIPHolderDetail(string scheme_code, long Bo_Account_No, string ccode, string l_company_id)
        {
            List<ATTSIP_Registration> lstSHolders = new List<ATTSIP_Registration>();
            //List<ATTSign> lstsigns = new List<ATTSign>();

            string spName = "";
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[4];
            try
            {
                param[0] = new SqlParameter("@Bo_Account_No", Bo_Account_No);
                param[1] = new SqlParameter("@scheme_code", scheme_code != null ? scheme_code : null);
                param[2] = new SqlParameter("@ccode", ccode != null ? ccode : null);
                param[3] = new SqlParameter("@l_company_id", l_company_id != null ? l_company_id : null);

                DataSet ds1 = new DataSet();

                spName = "GetSIPHolderInfoForCancellation";
                ds = DAO.gettable(spName, param);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTSIP_Registration objATT = new ATTSIP_Registration();
                        //Convert.ToDateTime(dr["p_dt"]).ToString("yyyy-MM-dd");SIP_Reg_Date
                        objATT.ShHolderNo = string.IsNullOrEmpty(dr["ShHolderNo"].ToString()) ? (int?)null : int.Parse(dr["ShHolderNo"].ToString());
                        objATT.Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? "" : dr["Name"].ToString();
                        objATT.Email = string.IsNullOrEmpty(dr["Email"].ToString()) ? "" : dr["Email"].ToString();
                        objATT.boid = string.IsNullOrEmpty(dr["BOID"].ToString()) ? "" : dr["BOID"].ToString();
                        objATT.SIP_DT = Convert.ToDateTime(dr["SIP_Reg_Date"]).ToString("dd/MM/yyyy");
                        objATT.Model_of_Sip = string.IsNullOrEmpty(dr["Model_of_SIP"].ToString()) ? "" : dr["Model_of_SIP"].ToString();
                        objATT.SIP_Last_Date = string.IsNullOrEmpty(dr["SIP_Last_Date"].ToString()) ? "" : Convert.ToDateTime(dr["SIP_Last_Date"]).ToString("yyyy-MM-dd");
                        objATT.SIP_Eff_Date = string.IsNullOrEmpty(dr["SIP_Eff_Date"].ToString()) ? "" : Convert.ToDateTime(dr["SIP_Eff_Date"]).ToString("yyyy-MM-dd");
                        objATT.Action_Date = string.IsNullOrEmpty(dr["SIP_Reg_Date"].ToString()) ? "" : Convert.ToDateTime(dr["SIP_Reg_Date"]).ToString("yyyy-MM-dd");

                        objATT.Online = string.IsNullOrEmpty(dr["ISOnline"].ToString()) ? "" : dr["ISOnline"].ToString();
                        objATT.Address = string.IsNullOrEmpty(dr["Address"].ToString()) ? "" : dr["Address"].ToString();
                        objATT.Contact1 = string.IsNullOrEmpty(dr["ContactNo1"].ToString()) ? "" : dr["ContactNo1"].ToString();
                        objATT.Contact2 = string.IsNullOrEmpty(dr["ContactNo2"].ToString()) ? "" : dr["ContactNo2"].ToString();
                        objATT.PayeeName = string.IsNullOrEmpty(dr["PayeeName"].ToString()) ? "" : dr["PayeeName"].ToString();
                        objATT.Introducer = string.IsNullOrEmpty(dr["Introducer"].ToString()) ? "" : dr["Introducer"].ToString();
                        objATT.HolderTypeNo = string.IsNullOrEmpty(dr["HolderType_No"].ToString()) ? "" : dr["HolderType_No"].ToString();
                        objATT.PayeeContactNo = string.IsNullOrEmpty(dr["PayeeContactNo"].ToString()) ? "" : dr["PayeeContactNo"].ToString();
                        // objATT.Contact2 = string.IsNullOrEmpty(dr["Contact2"].ToString()) ? "" : dr["Contact2"].ToString();
                        objATT.Sip_amt = float.Parse(dr["SIP_Amt"].ToString());
                        objATT.SIP_Interval = string.IsNullOrEmpty(dr["SIP_Interval"].ToString()) ? "" : dr["SIP_Interval"].ToString();
                        objATT.SIP_Reg_No = string.IsNullOrEmpty(dr["SIP_Reg_No"].ToString()) ? "" : dr["SIP_Reg_No"].ToString();
                        objATT.HolderType = string.IsNullOrEmpty(dr["Holder_Type_Name"].ToString()) ? "" : dr["Holder_Type_Name"].ToString();
                        objATT.BankCode = string.IsNullOrEmpty(dr["BankCode"].ToString()) ? "" : dr["BankCode"].ToString();
                        objATT.Bank_Account_No = string.IsNullOrEmpty(dr["Bank_Account_No"].ToString()) ? "" : dr["Bank_Account_No"].ToString();
                        objATT.Terms = string.IsNullOrEmpty(dr["Terms"].ToString()) ? "" : dr["Terms"].ToString();
                        objATT.IntroducerRem = string.IsNullOrEmpty(dr["IntroducerRem"].ToString()) ? "" : dr["IntroducerRem"].ToString();
                        objATT.PaymentCode = string.IsNullOrEmpty(dr["PaymentCode"].ToString()) ? "" : dr["PaymentCode"].ToString();
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
        public object checkcancellation(string scheme_code, string Bo_Account_No, string l_company_id, string SIP_Reg_No)
        {
            List<ATTSIP_Registration> lstSHolders = new List<ATTSIP_Registration>();
            //List<ATTSign> lstsigns = new List<ATTSign>();

            string spName = "";
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[4];
            try
            {
                param[0] = new SqlParameter("@Bo_Account_No", Bo_Account_No);
                param[1] = new SqlParameter("@scheme_code", scheme_code != null ? scheme_code : null);
                param[2] = new SqlParameter("@SIP_Reg_No", SIP_Reg_No != null ? SIP_Reg_No : null);
                param[3] = new SqlParameter("@l_company_id", l_company_id != null ? l_company_id : null);

                DataSet ds1 = new DataSet();

                spName = "checkcancellation";
                ds = DAO.gettable(spName, param);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ATTSIP_Registration objATT = new ATTSIP_Registration();
                        objATT.ShHolderNo = string.IsNullOrEmpty(dr["ShHolderNo"].ToString()) ? (int?)null : int.Parse(dr["ShHolderNo"].ToString());
                        objATT.APPSTATUS = string.IsNullOrEmpty(dr["App_Status"].ToString()) ? "" : dr["App_Status"].ToString();
                        objATT.IsApproved = string.IsNullOrEmpty(dr["IsApproved"].ToString()) ? "" : dr["IsApproved"].ToString();
                        //objATT.Cancel_Reg_No = string.IsNullOrEmpty(dr["Cancel_Reg_No"].ToString()) ? "" : dr["Cancel_Reg_No"].ToString();
                  
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
        public object CancelSIPHolderDetails(ATTSIP_Registration objATT)
        {
            string spName1 = "UpdateActionType";
            string spName2 = "";
            string msg = "No Data To Cancel !!!";
            int? Amdnt_No = 0;
            SqlTransaction transaction;

            msg = "Canceled Successfully !!!";
            SqlConnection conn = DAO.getConnection();

            using (conn)
            {
                transaction = conn.BeginTransaction();
                #region To Get MAX ID





                SqlCommand cmdd = new SqlCommand();
                cmdd.Connection = conn;
                cmdd.Transaction = transaction;
                cmdd.CommandText = "GetAmmendmentNo";
                cmdd.CommandType = CommandType.StoredProcedure;

                SqlParameter para1 = new SqlParameter();
                para1.ParameterName = "@Amdnt_No";
                para1.Value = Amdnt_No;
                para1.SqlDbType = SqlDbType.Int;
                para1.Size = 100;
                para1.Direction = ParameterDirection.InputOutput;
                cmdd.Parameters.Add(para1);
                cmdd.Parameters.AddWithValue("@scheme_code", objATT.scheme_code);
                cmdd.Parameters.AddWithValue("@ccode", objATT.ccode);
                cmdd.Parameters.AddWithValue("@SIP_Reg_No", objATT.SIP_Reg_No);
                cmdd.ExecuteNonQuery();

                if (cmdd.Parameters["@Amdnt_No"].Value.ToString() == "") { cmdd.Parameters["@Amdnt_No"].Value = 0; }
                Amdnt_No = int.Parse(cmdd.Parameters["@Amdnt_No"].Value.ToString()) + 1;

                #endregion

          
                try
                {
                    
                    SqlParameter[] param = new SqlParameter[10];
                    param[0] = new SqlParameter("@l_company_id", objATT.l_company_id);
                    param[1] = new SqlParameter("@scheme_code", objATT.scheme_code);
                    param[2] = new SqlParameter("@ccode", objATT.ccode);
                    param[3] = new SqlParameter("@SIPRegNo", objATT.SIP_Reg_No);
                    param[4] = new SqlParameter("@EntryBy", objATT.ENTRY_BY);
                    param[5] = new SqlParameter("@EntryDate", objATT.ENTRY_DT);
                    param[6] = new SqlParameter("@BOIDNo", objATT.boid);
                    param[7] = new SqlParameter("@TranType", objATT.TranType);
                    param[8] = new SqlParameter("@amendmentno", Amdnt_No);
                    param[9] = new SqlParameter("@Action", objATT.Action);
                    DAO.executeTranProcedure(spName1, param, transaction, conn);
                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error" + ex.Message);
                }
            }
            return Amdnt_No;

        }
        public object CancelSIPRegistration(ATTSIP_Registration objATT)
        {
            string spName1 = "UpdateActionType";
            string msg = "No Data To Cancel !!!";
            int? Amdnt_No = 0;
            SqlTransaction transaction;

            msg = "Canceled Successfully !!!";
            SqlConnection conn = DAO.getConnection();

            using (conn)
            {
                transaction = conn.BeginTransaction();
                #region To Get MAX ID


                SqlCommand cmdd = new SqlCommand();
                cmdd.Connection = conn;
                cmdd.Transaction = transaction;
                cmdd.CommandText = "GetAmmendmentNo";
                cmdd.CommandType = CommandType.StoredProcedure;

                SqlParameter para1 = new SqlParameter();
                para1.ParameterName = "@Amdnt_No";
                para1.Value = Amdnt_No;
                para1.SqlDbType = SqlDbType.Int;
                para1.Size = 100;
                para1.Direction = ParameterDirection.InputOutput;
                cmdd.Parameters.Add(para1);
                cmdd.Parameters.AddWithValue("@scheme_code", objATT.scheme_code);
                cmdd.Parameters.AddWithValue("@ccode", objATT.ccode);
                cmdd.Parameters.AddWithValue("@SIP_Reg_No", objATT.SIP_Reg_No);
                cmdd.ExecuteNonQuery();

                if (cmdd.Parameters["@Amdnt_No"].Value.ToString() == "") { cmdd.Parameters["@Amdnt_No"].Value = 0; }
                Amdnt_No = int.Parse(cmdd.Parameters["@Amdnt_No"].Value.ToString()) + 1;
                #endregion

                try
                {
                 
                    SqlParameter[] param = new SqlParameter[10];
                    param[0] = new SqlParameter("@l_company_id", objATT.l_company_id);
                    param[1] = new SqlParameter("@scheme_code", objATT.scheme_code);
                    param[2] = new SqlParameter("@ccode", objATT.ccode);
                    param[3] = new SqlParameter("@amendmentno", Amdnt_No);
                    param[4] = new SqlParameter("@EntryDate", objATT.ENTRY_DT);
                    param[5] = new SqlParameter("@BOIDNo", objATT.boid);
                    param[6] = new SqlParameter("@SIPRegNo", objATT.SIP_Reg_No);
                    param[7] = new SqlParameter("@EntryBy", objATT.ENTRY_BY);
                    param[8] = new SqlParameter("@TranType", "02");
                    param[9] = new SqlParameter("@Action", "05");
                    DAO.executeTranProcedure(spName1, param, transaction, conn);
                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error" + ex.Message);
                }
            }
            return Amdnt_No;

        }
    }
}

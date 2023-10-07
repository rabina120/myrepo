using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Utility;
using SI.RequestHandling.ATT;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SI.RequestHandling.DLL
{
    public class DLLBoidTransfer
    {
        public int? BoidTransfer(ATTBoidTransfer objATT)
        {

            string spName = "";
            string msg = "No Data To Save !!!";
            int? transfer_id = 0;
            SqlTransaction transaction;

            msg = "Successfully Saved !!!";
            SqlConnection conn = DAO.getConnection();

            using (conn)
            {
                transaction = conn.BeginTransaction();


                if (objATT.Action == "E" )
                {
                    spName = "EditBoidTransfer";
                    transfer_id = string.IsNullOrEmpty(objATT.transfer_id.ToString()) ? (int?)null : int.Parse(objATT.transfer_id.ToString());


                }
                else if (objATT.Action == "A")
                {

                    if (objATT.transfer_id != null)
                    {
                        transfer_id = string.IsNullOrEmpty(objATT.transfer_id.ToString()) ? (int?)null : int.Parse(objATT.transfer_id.ToString());
                    }
                    else
                    {
                        #region To Get MAX ID


                        SqlCommand cmdd = new SqlCommand();
                        cmdd.Connection = conn;
                        cmdd.Transaction = transaction;
                        cmdd.CommandText = "GetTransferid";
                        cmdd.CommandType = CommandType.StoredProcedure;

                        SqlParameter para1 = new SqlParameter();
                        para1.ParameterName = "@tranfer_id";
                        para1.Value = transfer_id;
                        para1.SqlDbType = SqlDbType.Int;
                        para1.Size = 100;
                        para1.Direction = ParameterDirection.InputOutput;
                        cmdd.Parameters.Add(para1);
                        cmdd.Parameters.AddWithValue("@scheme_code", objATT.Scheme_code);
                        cmdd.Parameters.AddWithValue("@ccode", objATT.ccode);
                        cmdd.ExecuteNonQuery();

                        if (cmdd.Parameters["@tranfer_id"].Value.ToString() == "") { cmdd.Parameters["@tranfer_id"].Value = 0; }
                        transfer_id = int.Parse(cmdd.Parameters["@tranfer_id"].Value.ToString()) + 1;

                        #endregion
                    }
                    spName = "BoidTransfer";
                }
                try
                {
                    SqlParameter[] param = new SqlParameter[11];
                    param[0] = new SqlParameter("@scheme_code", objATT.Scheme_code);
                    param[1] = new SqlParameter("@tranfer_id", transfer_id);
                    param[2] = new SqlParameter("@shholderno", objATT.shholderno);
                    param[3] = new SqlParameter("@boidno_from", objATT.boidno_from);
                    param[4] = new SqlParameter("@boidno_to", objATT.boidno_to);
                    param[5] = new SqlParameter("@transfer_dt", objATT.transfer_dt);
                    param[6] = new SqlParameter("@entry_by", objATT.entry_by);
                    param[7] = new SqlParameter("@entry_dt", objATT.entry_dt);
                    param[8] = new SqlParameter("@is_approved", objATT.is_approved);
                    param[9] = new SqlParameter("@app_status", objATT.app_status);
                    param[10] = new SqlParameter("@ccode", objATT.ccode);
                      DAO.executeTranProcedure(spName, param, transaction, conn);
                      transaction.Commit();
                     

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error" + ex.Message);
                }

            }
            return transfer_id;
        }

        public List<ATTBoidTransfer> GetUsersBoid(string scheme_code, string ccode, int transfer_id, string app_status)
        {
           // List<ATTShareTransaction> lstShareholder = new List<ATTShareTransaction>();
            List<ATTBoidTransfer> lstBoid = new List<ATTBoidTransfer>();
            string spName = "";
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            try
            {
                if (app_status == "UNPOSTED")
                {
                    param[0] = new SqlParameter("@scheme_code", scheme_code != null ? scheme_code : null);
                    param[1] = new SqlParameter("@ccode", ccode != null ? ccode : null);
                    param[2] = new SqlParameter("@tranfer_id", transfer_id);

                    spName = "GetUsersBoid";
                    ds = DAO.gettable(spName, param);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            ATTBoidTransfer objATT = new ATTBoidTransfer();
                            objATT.shholderno = string.IsNullOrEmpty(dr["shholderno"].ToString()) ? (int?)null : int.Parse(dr["shholderno"].ToString());
                            objATT.boidno_from = string.IsNullOrEmpty(dr["boidno_from"].ToString()) ? "" : dr["boidno_from"].ToString();
                            objATT.boidno_to = string.IsNullOrEmpty(dr["boidno_to"].ToString()) ? "" : dr["boidno_to"].ToString();
                            objATT.FName = string.IsNullOrEmpty(dr["FName"].ToString()) ? "" : dr["FName"].ToString();
                            lstBoid.Add(objATT);
                        }
                        
                    }
                }
                return lstBoid;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<ATTBoidTransfer> SearchUsersBoid(string ASearch, string FSearch, string GSearch, string scheme_code, string ccode, string app_status)
        {
            List<ATTBoidTransfer> lstSHolders = new List<ATTBoidTransfer>();
            string spName = "";
            DataSet ds = new DataSet();

            string whereCondition = " t2.scheme_code = '" + scheme_code + "'";

            try
            {

                if (app_status == "UNPOSTED")
                {
                    if (!(string.IsNullOrEmpty(ASearch)))
                    {
                        whereCondition += " and t2.FNAME like '" + ASearch + "%'";

                    }
                    if (!(string.IsNullOrEmpty(FSearch)))
                    {
                        whereCondition += " and t2.FaName like '" + FSearch + "%'";

                    }
                    if (!(string.IsNullOrEmpty(GSearch)))
                    {
                        whereCondition += " and t2.GFName like '" + GSearch + "%'";

                    }
                    if (app_status == "UNPOSTED")
                    {
                        whereCondition += " and t1.app_status= '" + app_status + "'";
                    }
                    SqlParameter[] param = new SqlParameter[1];

                    param[0] = new SqlParameter("@whereCondition", whereCondition);

                    spName = "SearchUsersBoid";
                    ds = DAO.gettable(spName, param);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            ATTBoidTransfer objATT = new ATTBoidTransfer();
                            objATT.shholderno = string.IsNullOrEmpty(dr["shholderno"].ToString()) ? (int?)null : int.Parse(dr["shholderno"].ToString());
                            objATT.Bo_Account_No = string.IsNullOrEmpty(dr["boidno_from"].ToString()) ? "" : dr["boidno_from"].ToString();
                            objATT.boidno_to = string.IsNullOrEmpty(dr["boidno_to"].ToString()) ? "" : dr["boidno_to"].ToString();
                            objATT.FName = string.IsNullOrEmpty(dr["FName"].ToString()) ? "" : dr["FName"].ToString();
                            objATT.Scheme_code = string.IsNullOrEmpty(dr["scheme_code"].ToString()) ? "" : dr["scheme_code"].ToString();
                            objATT.FaName = string.IsNullOrEmpty(dr["FaName"].ToString()) ? "" : dr["FaName"].ToString();
                            objATT.transfer_id = string.IsNullOrEmpty(dr["tranfer_id"].ToString()) ? 0 : int.Parse(dr["tranfer_id"].ToString());
                            objATT.GFName = string.IsNullOrEmpty(dr["GFName"].ToString()) ? "" : dr["GFName"].ToString();
                            lstSHolders.Add(objATT);
                        }
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


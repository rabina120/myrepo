using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.SIPHandling.ATT;
using System.Data;
using SI.Utility;
using System.Data.SqlClient;

namespace SI.SIPHandling.DLL
{
    public class DLLSIPPurchaseRequest
    {
        public List<ATTUnitSIPRequest> LoadData(string l_company_id,string scheme_code, string ccode, string Action, string date, float current_nav)
        {
            List<ATTUnitSIPRequest> lstholder = new List<ATTUnitSIPRequest>();
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@scheme_code", scheme_code);
            param[1] = new SqlParameter("@ccode", ccode);
            param[2] = new SqlParameter("@Action", Action);
            param[3] = new SqlParameter("@l_company_id", l_company_id);
            ds = DAO.gettable("GetSIPPurchaseRequest", param);

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
                    objATT.Interval_No = dr["Interval_Seq_No"].ToString();
                    objATT.SIP_Reg_Date = Convert.ToDateTime(dr["SIP_Reg_Date"]).ToString("yyyy-MM-dd");
                    objATT.SIP_Last_Date = string.IsNullOrEmpty((dr["SIP_Reg_Date"]).ToString()) ? null : Convert.ToDateTime(dr["SIP_Reg_Date"]).ToString("yyyy-MM-dd");
                    var today = DateTime.Now.ToString();
                    var extendeddays = Convert.ToDateTime(dr["ExtendedDay"]).ToString("dd/MM/yyyy");
                    //var dueday = (DateTime.Parse(extendeddays) - DateTime.Parse(objATT.Action_Date)).TotalDays;
                    //if (dueday > 1)
                    //{
                    //    continue;
                    //}
                   float SIPUnit = (objATT.Sip_amt - (objATT.DP_Charge)) / current_nav;
                    objATT.SIP_Unit = (float)Math.Round(SIPUnit * 100f) / 100f;
                    lstholder.Add(objATT);

                }

            }
            return lstholder;
        }

        public string ProceedPurchaseData(List<ATTUnitSIPRequest> objATT)
        {

            string spName = "";
            string msg = "No Data To Save !!!";
            SqlTransaction transaction;

            msg = "Successfully Saved !!!";
            SqlConnection conn = DAO.getConnection();

            using (conn)
            {
                transaction = conn.BeginTransaction();
                spName = "ProceedPurchaseData";

                try
                {
                    foreach (var obj in objATT)
                    {

                        int? Request_No = 0;
                        #region To Get MAX ID


                        SqlCommand cmdd = new SqlCommand();
                        cmdd.Connection = conn;
                        cmdd.Transaction = transaction;
                        cmdd.CommandText = "GetRequest_No";
                        cmdd.CommandType = CommandType.StoredProcedure;

                        SqlParameter para1 = new SqlParameter();
                        para1.ParameterName = "@Request_No";
                        para1.Value = Request_No;
                        para1.SqlDbType = SqlDbType.Int;
                        para1.Size = 100;
                        para1.Direction = ParameterDirection.InputOutput;
                        cmdd.Parameters.Add(para1);
                        cmdd.Parameters.AddWithValue("@scheme_code",  obj.scheme_code);
                        cmdd.Parameters.AddWithValue("@ccode", obj.ccode);
                        cmdd.Parameters.AddWithValue("@SIP_Reg_No", obj.SIP_Reg_No);
                        cmdd.ExecuteNonQuery();

                        if (cmdd.Parameters["@Request_No"].Value.ToString() == "") { cmdd.Parameters["@Request_No"].Value = 0; }
                        Request_No = int.Parse(cmdd.Parameters["@Request_No"].Value.ToString()) + 1;

                        #endregion
                        SqlParameter[] param = new SqlParameter[21];
                        param[0] = new SqlParameter("@scheme_code", obj.scheme_code);
                        param[1] = new SqlParameter("@ccode", obj.ccode);
                        param[2] = new SqlParameter("@SIP_Reg_No", obj.SIP_Reg_No);
                        param[3] = new SqlParameter("@BOID", obj.boid);
                        param[4] = new SqlParameter("@SIP_Amount", obj.Sip_amt);
                        param[5] = new SqlParameter("@DP_Charge", obj.DP_Charge);
                        param[6] = new SqlParameter("@SEBON_Fee", obj.SEBON_Fee);
                        param[7] = new SqlParameter("@SIP_Unit", obj.SIP_Unit);
                        param[8] = new SqlParameter("@Request_No", Request_No);
                        param[9] = new SqlParameter("@ENTRY_BY", obj.ENTRY_BY);
                        param[10] = new SqlParameter("@ENTRY_DT", obj.ENTRY_DT);
                        param[11] = new SqlParameter("@APPROVED", obj.IsApproved);
                        param[12] = new SqlParameter("@Current_NAV", obj.Current_NAV);
                        param[13] = new SqlParameter("@NAV_Date", obj.NAV_Date);
                        param[14] = new SqlParameter("@Action_Date", obj.Action_Date);
                        param[15] = new SqlParameter("@Payment_Date", obj.ENTRY_DT);
                        param[16] = new SqlParameter("@FNAME", obj.Name);
                        param[17] = new SqlParameter("@Interval_No", obj.Interval_No);
                        param[18] = new SqlParameter("@SIP_Reg_Date", obj.SIP_Reg_Date);
                        param[19] = new SqlParameter("@SIP_Last_Date", obj.SIP_Last_Date);
                        param[20] = new SqlParameter("@l_company_id", obj.l_company_id);
                        DAO.executeTranProcedure(spName, param, transaction, conn);
                    }
                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error" + ex.Message);
                }
            }
            return msg;
        }
    }
}

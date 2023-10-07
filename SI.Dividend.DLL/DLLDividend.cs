using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SI.Dividend.ATT;
using System.Data;
using SI.Utility;
using System.Data.SqlClient;


namespace SI.Dividend.DLL
{
    public class DLLDividend
    {


        public string SubmitDivRequest(ATTDividend objATT)
        {
            string msg = "Sucessfully Saved";

            SqlConnection conn = DAO.getConnection();
            SqlTransaction transaction;
            using (conn)
            {
                transaction = conn.BeginTransaction();
                try
                {
                    DataSet ds = new DataSet();
                    SqlParameter[] param = new SqlParameter[09];
                    param[0] = new SqlParameter("@l_company_id", objATT.l_company_id);
                    param[1] = new SqlParameter("@scheme_code", objATT.scheme_code);
                    param[2] = new SqlParameter("@ccode", objATT.ccode);
                    param[3] = new SqlParameter("@ShHolderNo", int.Parse(objATT.ShHolderNo.ToString()));
                    param[4] = new SqlParameter("@Bo_Account_No", objATT.Bo_Account_No);
                    param[5] = new SqlParameter("@ENTRY_BY", objATT.ENTRY_BY);
                    param[6] = new SqlParameter("@ENTRY_Date", objATT.ENTRY_Date);
                    param[7] = new SqlParameter("@TranType", objATT.TranType);
                    param[8] = new SqlParameter("@RequestType", objATT.RequestType);
                    DAO.executeTranProcedure("SubmitDividendRequest", param, transaction, conn);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    msg = "Failed to Update!!";
                }
            }

            return msg;
        }

        public object CheckBoidPosted(Int64 Bo_Account_No)
        {
            DataSet ds = new DataSet();
            string spName = "";
            ATTDividend objAtt = new ATTDividend();
            SqlParameter[] param = new SqlParameter[1];
            try
            {
                param[0] = new SqlParameter("@Bo_Account_No",Bo_Account_No);
                spName = "CheckBoidPostedForDividend";
                ds = DAO.gettable(spName, param);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        objAtt.Status = dr["AppStatus"].ToString() != "" ? dr["AppStatus"].ToString() : " ";
                        objAtt.RequestType= dr["RequestType"].ToString() != "" ? dr["RequestType"].ToString() : " ";
                    }
                }
                return objAtt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string SubmitDREPRequest(ATTDividend objATT)
        {
            string msg = "Sucessfully Saved";

            SqlConnection conn = DAO.getConnection();
            SqlTransaction transaction;
            using (conn)
            {
                transaction = conn.BeginTransaction();
                try
                {
                    DataSet ds = new DataSet();
                    SqlParameter[] param = new SqlParameter[15];
                    param[0] = new SqlParameter("@l_company_id", objATT.l_company_id);
                    param[1] = new SqlParameter("@scheme_code", objATT.scheme_code);
                    param[2] = new SqlParameter("@ccode", objATT.ccode);
                    param[3] = new SqlParameter("@ShHolderNo", int.Parse(objATT.ShHolderNo.ToString()));
                    param[4] = new SqlParameter("@Bo_Account_No", objATT.Bo_Account_No);
                    param[5] = new SqlParameter("@ENTRY_BY", objATT.ENTRY_BY);
                    param[6] = new SqlParameter("@ENTRY_Date", objATT.ENTRY_Date);
                    param[7] = new SqlParameter("@TranType", objATT.TranType);
                    param[8] = new SqlParameter("@RequestType", objATT.RequestType);
                    param[9] = new SqlParameter("@Name", objATT.Name);
                    param[10] = new SqlParameter("@Email", objATT.Email);
                    param[11] = new SqlParameter("@P_Tel_No", objATT.P_Tel_No);
                    param[12] = new SqlParameter("@P_Mobile_no", objATT.P_Mobile_no);
                    param[13] = new SqlParameter("@CitizenshipNo", objATT.CitizenshipNo);
                    param[14] = new SqlParameter("@DOB", objATT.DOB);
                    DAO.executeTranProcedure("CREATE_Dividend_Request_Apply", param, transaction, conn);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    msg = "Failed to Save!!";
                }
            }

            return msg;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SI.Security.ATT;

namespace SI.Utility
{
    public  class SaveEventLog
    {
        public  string SaveEvent(string username,string reffile,string remarks)
        {

            string spName = "";
            string msg = "";
            
            SqlTransaction transaction;

            msg = "Successfully Saved !!!";
            SqlConnection conn = DAO.getConnection();
            spName = "ActivityDetails";

            using (conn)
            {
                transaction = conn.BeginTransaction();


                SqlCommand cmdd = new SqlCommand();
                cmdd.Connection = conn;
                cmdd.Transaction = transaction;
                cmdd.CommandType = CommandType.StoredProcedure;

                try
                {
                    SqlParameter[] param = new SqlParameter[4];
                    param[0] = new SqlParameter("@username", username);
                    param[1] = new SqlParameter("@reffile", reffile);
                    param[2] = new SqlParameter("@remarks", remarks);
                    param[3] = new SqlParameter("@TranType", "02");
                    DAO.executeTranProcedure(spName, param, transaction, conn);
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
        public string EmailLogDetail(string username, string reffile, string remarks, string BOID, string Email, string Pdf)
        {

            string spName = "";
            string msg = "";

            SqlTransaction transaction;

            msg = "Successfully Saved !!!";
            SqlConnection conn = DAO.getConnection();
            spName = "EmailLogDetail";

            using (conn)
            {
                transaction = conn.BeginTransaction();


                SqlCommand cmdd = new SqlCommand();
                cmdd.Connection = conn;
                cmdd.Transaction = transaction;
                cmdd.CommandType = CommandType.StoredProcedure;

                try
                {
                    
                    SqlParameter[] param = new SqlParameter[7];
                    param[0] = new SqlParameter("@username", username);
                    param[1] = new SqlParameter("@reffile", reffile);
                    param[2] = new SqlParameter("@remarks", remarks);
                    param[3] = new SqlParameter("@TranType", "01");
                    param[4] = new SqlParameter("@BOID", BOID);
                    param[5] = new SqlParameter("@Email_ID", Email);
                    param[6] = new SqlParameter("@Pdf_file", Pdf);
                    DAO.executeTranProcedure(spName, param, transaction, conn);
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

